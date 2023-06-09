﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class editorWindow : Form
    {

        #region Private Members
        private byte[] _bytesNewBinary = null;
        private byte[] _bytesNewFsysStore = null;
        private byte[] _bytesNewMeRegion = null;
        private bool _maskCrc = false;
        private string _fullBuildPath = string.Empty;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public editorWindow()
        {
            InitializeComponent();

            Load += editorWindow_Load;
            FormClosing += editorWindow_FormClosing;
            KeyDown += editorWindow_KeyDown;
            lblTitle.MouseMove += editorWindow_MouseMove;

            Font font = Program.FONT_MDL2_REG_9;
            SetLabelProperties(lblSvsChevRight, font, Chars.CHEVRON_RIGHT);
            SetLabelProperties(lblVssChevRight, font, Chars.CHEVRON_RIGHT);
            SetLabelProperties(lblNssChevRight, font, Chars.CHEVRON_RIGHT);

            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void editorWindow_Load(object sender, EventArgs e)
        {
            if (FWBase.FsysStoreData.Serial == null)
            {
                cbxReplaceSerial.Enabled = false;
            }
            else
            {
                tbxSerialNumber.MaxLength = FWBase.FsysStoreData.Serial.Length;
            }

            GetRtbInitialData();
        }

        private void editorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first, otherwise ExitMet() will close the application regardless of user choice.
                if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
                {
                    e.Cancel = false;
                    return;
                }

                DialogResult result = METMessageBox.Show(this, "Close Editor", "Are you sure you want to close the editor?", METMessageType.Question, METMessageButtons.YesNo);

                e.Cancel = result == DialogResult.Yes ? false : true;
            }
        }
        #endregion

        #region Mouse Events
        private void editorWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region Button Events

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                Close();
                return;
            }

            DialogResult result = METMessageBox.Show(this, "Close Editor", "Are you sure you want to close the editor?", METMessageType.Question, METMessageButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cmdOpenBuildsDir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(METPath.BuildsDirectory))
            {
                METMessageBox.Show(this, "MET", "The builds directory has not been created yet.", METMessageType.Information, METMessageButtons.Okay);
                return;
            }

            Process.Start("explorer.exe", METPath.BuildsDirectory);
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(METPath.FsysDirectory))
            {
                Status status = FileUtils.CreateDirectory(METPath.FsysDirectory);

                if (status == Status.FAILED)
                {
                    METMessageBox.Show(this, "MET", "Failed to create the Fsys Stores directory.", METMessageType.Error, METMessageButtons.Okay);
                }
            }

            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = METPath.FsysDirectory,
                Filter = "Binary Files (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceFsysStore.Checked = false;
                    return;
                }

                Logger.WriteLogTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.Info, rtbLog);
                _bytesNewFsysStore = File.ReadAllBytes(dialog.FileName);

                if (!ValidateNewFsysStore(_bytesNewFsysStore))
                    cbxReplaceFsysStore.Checked = false;
            }
        }

        private void cmdMePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = METPath.MeDirectory,
                Filter = "Binary Files (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceMeRegion.Checked = false;
                    return;
                }

                Logger.WriteLogTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.Info, rtbLog);

                _bytesNewMeRegion = File.ReadAllBytes(dialog.FileName);

                if (!ValidateNewMeRegion(_bytesNewMeRegion))
                    cbxReplaceMeRegion.Checked = false;
            }
        }

        private void cmdBuild_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleControlEnable(false);

                _bytesNewBinary = FWBase.LoadedBinaryBytes;

                if (cbxReplaceFsysStore.Checked)
                {
                    Logger.WriteLogTextToRtb("Replacing Fsys Store:-", RtbLogPrefix.Info, rtbLog);
                    if (!WriteNewFsysStore())
                        return;
                }

                if (cbxReplaceSerial.Checked)
                {
                    Logger.WriteLogTextToRtb($"Replacing Serial Number data:-", RtbLogPrefix.Info, rtbLog);

                    if (!WriteNewSerialData())
                        return;
                }

                if (cbxClearVssStore.Checked)
                {
                    Logger.WriteLogTextToRtb("Clearing VSS NVRAM data:", RtbLogPrefix.Info, rtbLog);
                    if (!ClearNvramStore(FWBase.VssStoreData, cbxClearVssBackup.Checked))
                        return;
                }

                if (cbxClearSvsStore.Checked)
                {
                    Logger.WriteLogTextToRtb("Clearing SVS NVRAM data:", RtbLogPrefix.Info, rtbLog);
                    if (!ClearNvramStore(FWBase.SvsStoreData, cbxClearSvsBackup.Checked))
                        return;
                }

                if (cbxClearNssStore.Checked)
                {
                    Logger.WriteLogTextToRtb("Clearing NSS NVRAM data:", RtbLogPrefix.Info, rtbLog);
                    if (!ClearNvramStore(FWBase.NssStoreData, cbxClearNssBackup.Checked))
                        return;
                }

                if (cbxReplaceMeRegion.Checked)
                {
                    Logger.WriteLogTextToRtb("Writing new ME Region:", RtbLogPrefix.Info, rtbLog);
                    if (!WriteNewMeRegion())
                        return;
                }

                if (!SaveBuild())
                    return;

                Logger.WriteLogTextToRtb($"Process Completed!", RtbLogPrefix.Complete, rtbLog);
                cmdOpenLast.Enabled = true;
            }
            finally
            {
                ToggleControlEnable(true);
            }
        }

        private bool SaveBuild()
        {
            if (!Directory.Exists(METPath.BuildsDirectory))
            {
                Status status = FileUtils.CreateDirectory(METPath.BuildsDirectory);

                if (status == Status.FAILED)
                {
                    METMessageBox.Show(this, "MET", "Failed to create the builds directory.", METMessageType.Error, METMessageButtons.Okay);
                }
            }

            string filename = FWBase.FileInfoData.FileNameWithExt.StartsWith("outimage_")
                ? $"{FWBase.FileInfoData.FileNameNoExt}_{DateTime.Now:yyyyMMddHHmmss}.bin"
                : $"outimage_{FWBase.FileInfoData.FileNameNoExt}_{DateTime.Now:yyyyMMddHHmmss}.bin";

            _fullBuildPath = Path.Combine(METPath.BuildsDirectory, filename);

            if (!FileUtils.WriteAllBytesEx(_fullBuildPath, _bytesNewBinary))
            {
                Logger.WriteLogTextToRtb($"'WriteAllBytesEx' returned false, file could not be saved!", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            Logger.WriteLogTextToRtb($"Save path: {_fullBuildPath}", RtbLogPrefix.Info, rtbLog);

            return true;
        }

        private void cmdOpenLast_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fullBuildPath))
            {
                Program.openLastBuild = true;
                Program.lastBuildPath = _fullBuildPath;
                Close();
                return;
            }

            Logger.WriteLogTextToRtb($"The last build path is empty!", RtbLogPrefix.Warning, rtbLog);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;

            GetRtbInitialData();

            _bytesNewFsysStore = null;
            _bytesNewBinary = null;
            _bytesNewMeRegion = null;
            _maskCrc = false;
            _fullBuildPath = string.Empty;

            cbxReplaceFsysStore.Checked = false;
            cbxReplaceSerial.Checked = false;
            cbxClearVssStore.Checked = false;
            cbxClearSvsStore.Checked = false;
            cbxClearNssStore.Checked = false;
            cbxReplaceMeRegion.Checked = false;

            cmdOpenLast.Enabled = false;
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            tlpSerialB.Enabled = isChecked;
            tlpFsys.Enabled = !isChecked;

            if (!isChecked)
            {
                tbxSerialNumber.Text = string.Empty;
                tbxHwc.Text = string.Empty;
            }
        }

        private void cmdSaveLog_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"metlog_{DateTime.Now:yyMMdd_HHmmss}.txt",
                OverwritePrompt = true,
                InitialDirectory = METPath.CurrentDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllText(dialog.FileName, rtbLog.Text);
            }
        }
        #endregion

        #region KeyDown Events
        private void editorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseWindow();
            }
        }
        #endregion

        #region Checkbox Events

        private void cbxClearVssStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox control = (METCheckbox)sender;

            lblVssChevRight.Visible = control.Checked;
            cbxClearVssBackup.Enabled = control.Checked;

            if (!control.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox control = (METCheckbox)sender;

            lblSvsChevRight.Visible = control.Checked;
            cbxClearSvsBackup.Enabled = control.Checked;

            if (!control.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox control = (METCheckbox)sender;

            lblNssChevRight.Visible = control.Checked;
            cbxClearNssBackup.Enabled = control.Checked;

            if (!control.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox control = (METCheckbox)sender;
            bool isChecked = control.Checked;

            cmdFsysPath.Enabled = isChecked;
            tlpSerialA.Enabled = !isChecked;

            if (isChecked)
            {
                cmdFsysPath.PerformClick();
            }
        }

        private void cbxReplaceMeRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox control = (METCheckbox)sender;

            cmdMePath.Enabled = control.Checked;
            cmdMePath.PerformClick();
        }
        #endregion

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textLength = tb.Text.Length;

            if (textLength == FWBase.FsysStoreData.Serial.Length)
            {
                if (MacUtils.GetIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.COMPLETE_GREEN);
                    Logger.WriteLogTextToRtb("Valid serial characters entered", RtbLogPrefix.Info, rtbLog);
                    if (FWBase.FsysStoreData.Serial.Length == 11)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 3));
                    }
                    if (FWBase.FsysStoreData.Serial.Length == 12)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 4));
                    }
                    cmdBuild.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColor(tb, Colours.ERROR_RED);
                    Logger.WriteLogTextToRtb("Invalid serial characters entered", RtbLogPrefix.Error, rtbLog);
                    UpdateHwcTextBoxText("???");
                    cmdBuild.Enabled = false;
                }
            }
            else
            {
                UpdateTextBoxColor(tb, Color.White);
                UpdateHwcTextBoxText(string.Empty);
                cmdBuild.Enabled = true;
            }
        }
        #endregion

        #region UI Events
        private void GetRtbInitialData()
        {
            Logger.WriteLogTextToRtb($"{DateTime.Now}", RtbLogPrefix.Info, rtbLog);

            LogBinarySize();
            LogDescriptorData();
            LogFsysData();

            if (FWBase.VssStoreData.PrimaryStoreBase == -1)
            {
                cbxClearVssStore.Enabled = false;
                Logger.WriteLogTextToRtb($"VSS store not found: Option disabled", RtbLogPrefix.Warning, rtbLog);
            }

            if (FWBase.SvsStoreData.PrimaryStoreBase == -1)
            {
                cbxClearSvsStore.Enabled = false;
                Logger.WriteLogTextToRtb($"SVS store not found: Option disabled", RtbLogPrefix.Warning, rtbLog);
            }

            if (FWBase.NssStoreData.PrimaryStoreBase == -1)
            {
                cbxClearNssStore.Enabled = false;
                Logger.WriteLogTextToRtb($"NSS store not found: Option disabled", RtbLogPrefix.Warning, rtbLog);
            }

            Logger.WriteLogTextToRtb($"Initial checks complete", RtbLogPrefix.Complete, rtbLog);
        }

        private void LogBinarySize()
        {
            if (!FileUtils.GetIsValidBinSize(FWBase.FileInfoData.FileLength))
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is invalid.", RtbLogPrefix.Error, rtbLog);
                return;
            }

            Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is valid", RtbLogPrefix.Info, rtbLog);
        }

        private void LogDescriptorData()
        {
            if (Descriptor.PdrBase != 0 && Descriptor.PdrLimit != 0)
            {
                Logger.WriteLogTextToRtb($"PDR Region: Base {Descriptor.PdrBase:X2}h, Limit {Descriptor.PdrLimit:X2}h", RtbLogPrefix.Info, rtbLog);
            }

            if (Descriptor.MeBase != 0 && Descriptor.MeLimit != 0)
            {
                Logger.WriteLogTextToRtb($"ME Region: Base {Descriptor.MeBase:X2}h, Limit {Descriptor.MeLimit:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxReplaceMeRegion.Enabled = false;
                Logger.WriteLogTextToRtb($"ME Region not found: Option disabled", RtbLogPrefix.Warning, rtbLog);
            }

            if (Descriptor.BiosBase != 0 && Descriptor.BiosLimit != 0)
            {
                Logger.WriteLogTextToRtb($"BIOS Region: Base {Descriptor.BiosBase:X2}h, Limit {Descriptor.BiosLimit:X2}h", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void LogFsysData()
        {
            if (FWBase.FsysStoreData.FsysBase != 0)
            {
                Logger.WriteLogTextToRtb($"Fsys: Base {FWBase.FsysStoreData.FsysBase:X2}h, Size {FWBase.FSYS_RGN_SIZE:X2}h", RtbLogPrefix.Info, rtbLog);

                if (FWBase.FsysStoreData.SerialBase != -1)
                    Logger.WriteLogTextToRtb($"Serial: Base {FWBase.FsysStoreData.SerialBase:X2}h", RtbLogPrefix.Info, rtbLog);

                if (FWBase.FsysStoreData.HWCBase != -1)
                    Logger.WriteLogTextToRtb($"HWC: Base {FWBase.FsysStoreData.HWCBase:X2}h", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void UpdateTextBoxColor(TextBox textBox, Color color)
        {
            textBox.ForeColor = color;
        }

        private void UpdateHwcTextBoxText(string text)
        {
            tbxHwc.Text = text;
        }

        private void SetLabelProperties(Label label, Font font, string text)
        {
            label.Font = font;
            label.Text = text;
            label.Visible = false;
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }

        private void ToggleControlEnable(bool enable)
        {
            tlpOptions.Enabled = enable;
            cmdBuild.Enabled = enable;
        }
        #endregion

        #region Validation
        private bool ValidateNewFsysStore(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb("Validating donor Fsys store:-", RtbLogPrefix.Info, rtbLog);

            int fsysSigPos = BinaryUtils.GetBasePosition(sourceBytes, FWBase.FSYS_SIG);

            if (fsysSigPos == -1)
            {
                Logger.WriteLogTextToRtb("Fsys signature not found", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            if (fsysSigPos != 0)
            {
                Logger.WriteLogTextToRtb($"Fsys signature misaligned: {fsysSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            if (sourceBytes.Length != FWBase.FSYS_RGN_SIZE)
            {
                Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            // We have validated the Fsys store, now we can load it.
            FsysStore fsysStore = FWBase.GetFsysStoreData(sourceBytes, true);

            Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Fsys signature found at {fsysSigPos:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Serial: {fsysStore.Serial} ({fsysStore.Serial.Length}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"HWC: {fsysStore.HWC}", RtbLogPrefix.Info, rtbLog);

            if (!string.Equals(fsysStore.CrcString, fsysStore.CrcCalcString))
            {
                Logger.WriteLogTextToRtb("Donor Fsys Store CRC32 is invalid, 'Mask CRC32' flag set!", RtbLogPrefix.Warning, rtbLog);
                _maskCrc = true;
            }
            else
            {
                _maskCrc = false;
            }

            Logger.WriteLogTextToRtb($"File: {fsysStore.CrcString}h > Calc: {fsysStore.CrcCalcString}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Validation completed", RtbLogPrefix.Complete, rtbLog);

            return true;
        }

        private bool ValidateNewMeRegion(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb("Validating ME Region:-", RtbLogPrefix.Info, rtbLog);

            int fptSignature = BinaryUtils.GetBasePosition(sourceBytes, MEParser.FPT_SIGNATURE);

            if (fptSignature == -1)
            {
                Logger.WriteLogTextToRtb($"FPT signature not found", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            if (sourceBytes.Length > Descriptor.MeSize)
            {
                Logger.WriteLogTextToRtb($"ME will not fit: {sourceBytes.Length:X2}h > {Descriptor.MeSize:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            if (sourceBytes.Length < Descriptor.MeSize)
            {
                Logger.WriteLogTextToRtb($"ME is smaller ({sourceBytes.Length:X2}h) and will be adjusted at build time", RtbLogPrefix.Warning, rtbLog);
            }

            string meVersion = MEParser.GetVersionData(_bytesNewMeRegion, HeaderType.ManagementEngine);

            Logger.WriteLogTextToRtb($"ME Version: {meVersion}", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Validation completed", RtbLogPrefix.Complete, rtbLog);

            return true;
        }
        #endregion

        #region Editing
        private bool WriteNewFsysStore()
        {
            // Mask Fsys CRC
            if (_maskCrc)
            {
                Logger.WriteLogTextToRtb("Masking Fsys store CRC", RtbLogPrefix.Info, rtbLog);

                // Load the new Fsys store
                FsysStore fsysNew = FWBase.GetFsysStoreData(_bytesNewFsysStore, true);

                // Load the new Fsys store bytes and patch the crc
                _bytesNewFsysStore = BinaryUtils.PatchFsysCrc(fsysNew.FsysBytes, fsysNew.CRC32CalcInt);

                // Load the patched store
                fsysNew = FWBase.GetFsysStoreData(_bytesNewFsysStore, true);

                // Check CRC32 masking was successful
                if (!string.Equals(fsysNew.CrcString, fsysNew.CrcCalcString))
                {
                    HandleBuildFailure("CRC masking failed");
                    return false;
                }

                Logger.WriteLogTextToRtb("CRC masking successful", RtbLogPrefix.Info, rtbLog);
            }

            // Write new Fsys to the output file
            BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, FWBase.FsysStoreData.FsysBase, _bytesNewFsysStore);

            // Load the Fsys from the new binary
            FsysStore fsysNewBinary = FWBase.GetFsysStoreData(_bytesNewBinary, false);

            // Validate new Fsys was written
            if (!BinaryUtils.ByteArraysMatch(fsysNewBinary.FsysBytes, _bytesNewFsysStore))
            {
                HandleBuildFailure("ByteArraysMatch: Fsys comparison check failed");
                return false;
            }

            Logger.WriteLogTextToRtb("Fsys comparison check passed", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Data written successfully", RtbLogPrefix.Complete, rtbLog);

            return true;
        }

        private bool WriteNewMeRegion()
        {
            // Create a blank array
            byte[] meData = new byte[Descriptor.MeSize];

            // 0xFF the blank array
            BinaryUtils.EraseByteArray(meData, 0xFF);

            // Copy in the ME Region
            Array.Copy(_bytesNewMeRegion, 0, meData, 0, _bytesNewMeRegion.Length);

            // Write the new array to the new binary
            Array.Copy(meData, 0, _bytesNewBinary, Descriptor.MeBase, meData.Length);

            // Validate write
            byte[] meNewBinary = BinaryUtils.GetBytesBaseLimit(_bytesNewBinary, (int)Descriptor.MeBase, (int)Descriptor.MeLimit);

            if (!BinaryUtils.ByteArraysMatch(meNewBinary, meData))
            {
                HandleBuildFailure("ME Region write failed");
                return false;
            }

            Logger.WriteLogTextToRtb("ME Region comparison check passed", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Data written successfully", RtbLogPrefix.Complete, rtbLog);

            return true;
        }

        private bool WriteNewSerialData()
        {
            // Given serial is too short
            if (tbxSerialNumber.Text.Length != FWBase.FsysStoreData.Serial.Length)
            {
                HandleBuildFailure("The given serial number was too short");
                return false;
            }

            // Fsys postition was not found
            if (FWBase.FsysStoreData.SerialBase == -1)
            {
                HandleBuildFailure("FsysSectionData store base is -1");
                return false;
            }

            // Fsys store bytes are empty
            if (FWBase.FsysStoreData.FsysBytes == null)
            {
                HandleBuildFailure("FsysSectionData store bytes are empty");
                return false;
            }

            // Write new serial number bytes
            string newSerial = tbxSerialNumber.Text;
            byte[] newSerialBytes = Encoding.UTF8.GetBytes(newSerial);
            BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, FWBase.FsysStoreData.SerialBase, newSerialBytes);

            // Write new HWC bytes

            string newHwc = tbxHwc.Text;
            if (FWBase.FsysStoreData.HWCBase != -1)
            {
                byte[] newHwcBytes = Encoding.UTF8.GetBytes(newHwc);
                BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, FWBase.FsysStoreData.HWCBase, newHwcBytes);
            }
            else
            {
                Logger.WriteLogTextToRtb("HWC base is -1, new HWC will not be written!", RtbLogPrefix.Warning, rtbLog);
            }

            // Load new Fsys store
            FsysStore newFsys = FWBase.GetFsysStoreData(_bytesNewBinary, false);

            // Check serial numbers match
            if (!string.Equals(newSerial, newFsys.Serial))
            {
                HandleBuildFailure("Serial number comparison failed");
                return false;
            }

            // Check HWC's match
            if (FWBase.FsysStoreData.HWCBase != -1)
            {
                if (!string.Equals(newHwc, newFsys.HWC))
                {
                    HandleBuildFailure("HWC comparison failed");
                    return false;
                }
            }

            Logger.WriteLogTextToRtb("Serial number comparison successful", RtbLogPrefix.Complete, rtbLog);
            Logger.WriteLogTextToRtb("HWC comparison successful", RtbLogPrefix.Complete, rtbLog);
            Logger.WriteLogTextToRtb("Masking Fsys CRC32:-", RtbLogPrefix.Info, rtbLog);

            _bytesNewBinary = BinaryUtils.MakeFsysCrcPatchedBinary
            (
               _bytesNewBinary,
               newFsys.FsysBase,
               newFsys.FsysBytes,
               newFsys.CRC32CalcInt
            );

            // Load Fsys store from the new binary again
            newFsys = FWBase.GetFsysStoreData(_bytesNewBinary, false);

            // Check the Fsys store matches the patched store
            if (!string.Equals(newFsys.CrcCalcString, newFsys.CrcString))
            {
                HandleBuildFailure("CRC comparison check failed");
                return false;
            }

            Logger.WriteLogTextToRtb("CRC masking was successful", RtbLogPrefix.Complete, rtbLog);

            return true;
        }

        private bool ClearNvramStore(NvramStore storeData, bool clearBackup)
        {
            int headerLen = 0x10;
            int primBodyStart = storeData.PrimaryStoreBase + headerLen;
            int primBodyEnd = storeData.PrimaryStoreSize - headerLen;
            int backBodyStart = storeData.BackupStoreBase + headerLen;
            int backBodyEnd = storeData.BackupStoreSize - headerLen;

            if (!storeData.IsPrimaryStoreEmpty)
            {
                Logger.WriteLogTextToRtb($"Primary {storeData.StoreType} store is not empty", RtbLogPrefix.Info, rtbLog);
                byte[] primaryData = BinaryUtils.GetBytesBaseLength(storeData.PrimaryStoreBytes, headerLen, primBodyEnd);
                Logger.WriteLogTextToRtb($"Overwriting {storeData.StoreType} buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.EraseByteArray(primaryData, 0xFF);
                Logger.WriteLogTextToRtb($"Writing clean {storeData.StoreType} store to file buffer", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, primBodyStart, primaryData);

                NvramStore newStore = FWBase.GetNvramStoreData(_bytesNewBinary, storeData.StoreType);

                if (newStore.IsPrimaryStoreEmpty)
                {
                    Logger.WriteLogTextToRtb($"Clean {storeData.StoreType} store written successfully", RtbLogPrefix.Complete, rtbLog);
                }
                else
                {
                    HandleBuildFailure($"Clean {storeData.StoreType} store was not written successfully");
                    return false;
                }
            }
            else
            {
                Logger.WriteLogTextToRtb($"Primary {storeData.StoreType} store is already empty (0xFF)", RtbLogPrefix.Info, rtbLog);
            }

            if (clearBackup && !storeData.IsBackupStoreEmpty)
            {
                Logger.WriteLogTextToRtb($"Backup {storeData.StoreType} is not empty", RtbLogPrefix.Info, rtbLog);
                byte[] backupData = BinaryUtils.GetBytesBaseLength(storeData.BackupStoreBytes, headerLen, backBodyEnd);
                Logger.WriteLogTextToRtb($"Overwriting backup {storeData.StoreType} buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.EraseByteArray(backupData, 0xFF);
                Logger.WriteLogTextToRtb($"Writing clean {storeData.StoreType} store to file buffer", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, backBodyStart, backupData);

                NvramStore newStore = FWBase.GetNvramStoreData(_bytesNewBinary, storeData.StoreType);

                if (newStore.IsBackupStoreEmpty)
                {
                    Logger.WriteLogTextToRtb($"Clean {storeData.StoreType} store written successfully", RtbLogPrefix.Complete, rtbLog);
                }
                else
                {
                    HandleBuildFailure($"Clean {storeData.StoreType} store was not written successfully");
                    return false;
                }
            }
            else
            {
                if (clearBackup)
                {
                    Logger.WriteLogTextToRtb($"Backup {storeData.StoreType} store is already empty (0xFF)", RtbLogPrefix.Info, rtbLog);
                }
            }

            return true;
        }

        private void HandleBuildFailure(string errorMessage)
        {
            Logger.WriteLogTextToRtb("BUILD FAILED:", RtbLogPrefix.Error, rtbLog);
            Logger.WriteLogTextToRtb(errorMessage, RtbLogPrefix.Error, rtbLog);
            // Reload _bytesNewBinary
            _bytesNewBinary = FWBase.LoadedBinaryBytes;
        }
        #endregion

    }
}