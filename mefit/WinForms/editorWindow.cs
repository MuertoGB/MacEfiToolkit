﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0
// Yes, the code is messy, it's far from complete and unoptimised, stop crying.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class editorWindow : Form
    {

        #region Private Members
        private byte[] _bytesNewFsysRegion = null;
        private byte[] _bytesNewBinary = null;
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

            Load += mainWindow_Load;
            lblTitle.MouseMove += editorWindow_MouseMove;

            var font = Program.FONT_MDL2_REG_9;
            SetLabelProperties(lblSvsChevRight, font, Chars.CHEVRON_RIGHT);
            SetLabelProperties(lblVssChevRight, font, Chars.CHEVRON_RIGHT);
            SetLabelProperties(lblNssChevRight, font, Chars.CHEVRON_RIGHT);

            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            tbxSerialNumber.MaxLength = FWBase.FsysSectionData.Serial.Length;

            Logger.WriteLogTextToRtb($"{DateTime.Now}", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"The editor is unfinished, use caution!", RtbLogPrefix.Warning, rtbLog);

            LogLoadedBinarySize();
            LogFsysData();

            if (FWBase.VssStoreData.PrimaryStoreOffset == -1)
            {
                cbxClearVssStore.Enabled = false;
                Logger.WriteLogTextToRtb($"No VSS store present: Option disabled", RtbLogPrefix.Info, rtbLog);
            }

            if (FWBase.SvsStoreData.PrimaryStoreOffset == -1)
            {
                cbxClearSvsStore.Enabled = false;
                Logger.WriteLogTextToRtb($"No SVS store present: Option disabled", RtbLogPrefix.Info, rtbLog);
            }

            if (FWBase.NssStoreData.PrimaryStoreOffset == -1)
            {
                Logger.WriteLogTextToRtb($"No NSS store present: Option disabled", RtbLogPrefix.Info, rtbLog);
                cbxClearNssStore.Enabled = false;
            }

            Logger.WriteLogTextToRtb($"Initial checks complete", RtbLogPrefix.Complete, rtbLog);
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
            Close();
        }
        private void cmdOpenBuildsDir_Click(object sender, EventArgs e)
        {
            Program.CreateCheckBuildsFolder();
            Process.Start("explorer.exe", Program.buildsDirectory);
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {
            Program.CheckCreateFsysFolder();

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = Program.fsysDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceFsysStore.Checked = false;
                    return;
                }

                Logger.WriteLogTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.Info, rtbLog);
                _bytesNewFsysRegion = File.ReadAllBytes(dialog.FileName);
                bool isValid = ValidateNewFsysRegion(_bytesNewFsysRegion);
                if (!isValid) cbxReplaceFsysStore.Checked = false;
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
            var filename = $"outimage_{FWBase.FileInfoData.FileNameNoExt}.bin";
            Program.CreateCheckBuildsFolder();
            _fullBuildPath = Path.Combine(Program.buildsDirectory, filename);
            int saveResult = FileUtils.WriteAllBytesEx(_fullBuildPath, _bytesNewBinary);

            if (saveResult != 0)
            {
                Logger.WriteLogTextToRtb($"'WriteAllBytesEx' returned {saveResult}", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            Logger.WriteLogTextToRtb($"'WriteAllBytesEx' returned {saveResult}", RtbLogPrefix.Complete, rtbLog);
            Logger.WriteLogTextToRtb($"Save path: {_fullBuildPath}", RtbLogPrefix.Info, rtbLog);
            return true;
        }
        #endregion

        #region Checkbox Events

        private void cbxClearVssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblVssChevRight.Visible = cb.Checked;
            cbxClearVssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblSvsChevRight.Visible = cb.Checked;
            cbxClearSvsBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblNssChevRight.Visible = cb.Checked;
            cbxClearNssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysRgn_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            cmdFsysPath.Enabled = isChecked;
            tlpSerialA.Enabled = !isChecked;

            if (isChecked)
            {
                cmdFsysPath.PerformClick();
            }
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            tlpSerialB.Enabled = isChecked;
            tlpFsysA.Enabled = !isChecked;

            if (!isChecked)
            {
                tbxSerialNumber.Text = string.Empty;
                tbxHwc.Text = string.Empty;
            }
        }

        private void cmdSaveLog_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Save Log File...",
                FileName = $"metlog_{DateTime.Now:yyMMdd_HHmmss}.txt",
                OverwritePrompt = true,
                InitialDirectory = Program.appDirectory
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

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textLength = tb.Text.Length;

            if (textLength == FWBase.FsysSectionData.Serial.Length)
            {
                if (EFIUtils.GetIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.COMPLETE_GREEN);
                    Logger.WriteLogTextToRtb("Valid serial characters entered", RtbLogPrefix.Info, rtbLog);
                    if (FWBase.FsysSectionData.Serial.Length == 11)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 3));
                    }
                    if (FWBase.FsysSectionData.Serial.Length == 12)
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

        #region Validation
        private bool ValidateNewFsysRegion(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb("Validating donor Fsys region:-", RtbLogPrefix.Info, rtbLog);

            if (sourceBytes.Length != FWBase.FSYS_RGN_SIZE)
            {
                Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            long lSigPos = BinaryUtils.GetOffset(sourceBytes, FWBase.FSYS_SIG);
            if (lSigPos == -1 || lSigPos != 0)
            {
                Logger.WriteLogTextToRtb(lSigPos == -1 ? "Fsys signature not found." : $"Fsys signature misaligned at {lSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            int lenSerial = FWBase.FsysSectionData.Serial.Length;
            string strHwc = lenSerial == 11 ? FWBase.FsysSectionData.Serial.Substring(FWBase.FsysSectionData.Serial.Length - 3).ToUpper() : lenSerial == 12 ? FWBase.FsysSectionData.Serial.Substring(FWBase.FsysSectionData.Serial.Length - 4).ToUpper() : string.Empty;

            Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Fsys signature found at {lSigPos:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Serial: {FWBase.FsysSectionData.Serial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"HWC: {strHwc}", RtbLogPrefix.Info, rtbLog);

            string strCrcInSourceBytes = FWBase.GetCrcStringFromFsys(sourceBytes);
            string strCrcCalculated = EFIUtils.GetUintFsysCrc32(sourceBytes).ToString("X8");

            Logger.WriteLogTextToRtb($"File: {strCrcInSourceBytes}h > Calc: {strCrcCalculated}h", RtbLogPrefix.Info, rtbLog);

            if (strCrcInSourceBytes != strCrcCalculated)
            {
                Logger.WriteLogTextToRtb("Donor Fsys Store CRC32 is invalid, 'Mask CRC32' flag set!", RtbLogPrefix.Warning, rtbLog);
                _maskCrc = true;
            }
            else
            {
                _maskCrc = false;
            }

            Logger.WriteLogTextToRtb("Validation completed", RtbLogPrefix.Complete, rtbLog);

            return true;
        }
        #endregion

        #region Misc Events
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

        #region Logging
        private void LogFsysData()
        {
            if (FWBase.FsysSectionData.FsysOffset != 0)
            {
                Logger.WriteLogTextToRtb($"Fsys: Offset {FWBase.FsysSectionData.FsysOffset:X2}h, Size {FWBase.FSYS_RGN_SIZE:X2}h", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void LogLoadedBinarySize()
        {
            if (!FileUtils.GetIsValidBinSize((int)FWBase.FileInfoData.FileLength))
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is invalid and should not be used as a donor.", RtbLogPrefix.Error, rtbLog);
            }
            else
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is valid", RtbLogPrefix.Info, rtbLog);
            }
        }
        #endregion

        #region Editing
        private bool WriteNewFsysStore()
        {
            // Mask Fsys CRC
            if (_maskCrc)
            {
                // Mask CRC32 was checked
                Logger.WriteLogTextToRtb("Masking Fsys CRC32", RtbLogPrefix.Info, rtbLog);

                // Calculate actual CRC32 from _bytesNewFsysRegion
                uint newCrc = EFIUtils.GetUintFsysCrc32(_bytesNewFsysRegion);

                // Get bytes from newCrc uint
                byte[] newCrcBytes = BitConverter.GetBytes(newCrc);

                // Write newCrcBytes to the donor Fsys region
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewFsysRegion, FWBase.FSYS_CRC_POS, newCrcBytes);

                // Read CRC32 string from _bytesNewFsysRegion
                uint patchedCrcBytes = EFIUtils.GetUintFsysCrc32(_bytesNewFsysRegion);

                Logger.WriteLogTextToRtb($"{newCrc:X8}h > {patchedCrcBytes:X8}h", RtbLogPrefix.Info, rtbLog);

                // Convert newCrc to hex string to string and compare it to was was read.
                if (string.Equals(newCrc.ToString("X8"), patchedCrcBytes.ToString("X8")))
                {
                    Logger.WriteLogTextToRtb("CRC32 masking successful", RtbLogPrefix.Info, rtbLog);
                }
                else
                {
                    HandleBuildFailure("CRC32 masking failed.");
                    return false;
                }
            }

            // Write new Fsys bytes to _bytesNewBinary
            BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.FsysOffset, _bytesNewFsysRegion);

            // Validate new Fsys was written
            FsysStoreSection fsysNew = FWBase.GetFsysStoreData(_bytesNewBinary);
            if (fsysNew.FsysBytes.SequenceEqual(_bytesNewFsysRegion))
            {
                Logger.WriteLogTextToRtb("Fsys comparison check passed", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                HandleBuildFailure("Fsys comparison check failed");
                return false;
            }

            Logger.WriteLogTextToRtb("New Fsys region written successfully", RtbLogPrefix.Complete, rtbLog);
            return true;
        }

        private bool WriteNewSerialData()
        {
            if (FWBase.FsysSectionData.FsysBytes != null && FWBase.FsysSectionData.SerialOffset != -1)
            {
                var newSerial = tbxSerialNumber.Text;
                var newHwc = tbxHwc.Text;
                byte[] newSerialBytes = Encoding.UTF8.GetBytes(newSerial);
                byte[] newHwcBytes = Encoding.UTF8.GetBytes(newHwc);

                // Write new serial number bytes
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.SerialOffset, newSerialBytes);

                // Determine and write new HWC
                if (FWBase.FsysSectionData.HWCOffset != -1)
                {
                    BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.HWCOffset, newHwcBytes);
                }
                else
                {
                    Logger.WriteLogTextToRtb("No HWC offset present, new data was not written!", RtbLogPrefix.Warning, rtbLog);
                }

                // Load new Fsys store
                var newFsys = FWBase.GetFsysStoreData(_bytesNewBinary);

                if (!string.Equals(newSerial, newFsys.Serial))
                {
                    HandleBuildFailure("Serial was not written successfully");
                    return false;
                }

                if (FWBase.FsysSectionData.HWCOffset != -1)
                {
                    if (!string.Equals(newHwc, newFsys.HWC))
                    {
                        HandleBuildFailure("HWC was not written successfully");
                        return false;
                    }
                }

                Logger.WriteLogTextToRtb("Serial number written successfully", RtbLogPrefix.Complete, rtbLog);
                Logger.WriteLogTextToRtb("HWC written successfully", RtbLogPrefix.Complete, rtbLog);
                Logger.WriteLogTextToRtb("Masking Fsys CRC32:-", RtbLogPrefix.Info, rtbLog);

                // Load new Fsys store bytes
                byte[] newFsysStore = newFsys.FsysBytes;
                // Calculate Fsys CRC32 from given bytes
                uint newCrc = EFIUtils.GetUintFsysCrc32(newFsysStore);
                // Get bytes from new CRC uint
                byte[] newCrcBytes = BitConverter.GetBytes(newCrc);
                // Write new CRC bytes to loaded Fsys store
                BinaryUtils.OverwriteBytesAtOffset(newFsysStore, FWBase.FSYS_CRC_POS, newCrcBytes);
                // Get the patched bytes from the Fsys store
                uint patchedCrcBytes = EFIUtils.GetUintFsysCrc32(newFsysStore);
                // Compare the checksums
                if (string.Equals(newCrc.ToString("X8"), patchedCrcBytes.ToString("X8")))
                {
                    Logger.WriteLogTextToRtb("CRC32 masking successful", RtbLogPrefix.Info, rtbLog);
                }
                else
                {
                    HandleBuildFailure("CRC32 masking failed.");
                    return false;
                }

                // Write back patched Fsys store
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.FsysOffset, newFsysStore);

                // Load Fsys store from the new binary again
                newFsys = FWBase.GetFsysStoreData(_bytesNewBinary);

                // Check the Fsys store matches the patched store
                if (newFsys.FsysBytes.SequenceEqual(newFsysStore))
                {
                    Logger.WriteLogTextToRtb("Patched Fsys store written successfully", RtbLogPrefix.Complete, rtbLog);
                }
                else
                {
                    HandleBuildFailure("Fsys comparison check failed");
                    return false;
                }
            }
            else
            {
                HandleBuildFailure("Loaded binary Fsys store is invalid");
                return false;
            }

            return true;
        }

        private bool ClearNvramStore(NvramStoreSection storeData, bool clearBackup)
        {
            int headerLen = 0x10;
            long primBodyStart = storeData.PrimaryStoreOffset + headerLen;
            int primBodyEnd = storeData.PrimaryStoreLength - headerLen;
            long backBodyStart = storeData.BackupStoreOffset + headerLen;
            int backBodyEnd = storeData.BackupStoreLength - headerLen;

            if (!storeData.IsPrimaryStoreEmpty)
            {
                Logger.WriteLogTextToRtb($"Primary {storeData.StoreType} store is not empty", RtbLogPrefix.Info, rtbLog);
                byte[] primaryData = BinaryUtils.GetBytesAtOffset(storeData.PrimaryStoreBytes, headerLen, primBodyEnd);
                Logger.WriteLogTextToRtb($"Overwriting {storeData.StoreType} buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.FillByteArrayWithFF(primaryData);
                Logger.WriteLogTextToRtb($"Writing clean {storeData.StoreType} store to file buffer", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, primBodyStart, primaryData);

                NvramStoreSection newStore = FWBase.GetNvramStoreData(_bytesNewBinary, storeData.StoreType);

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
                byte[] backupData = BinaryUtils.GetBytesAtOffset(storeData.BackupStoreBytes, headerLen, backBodyEnd);
                Logger.WriteLogTextToRtb($"Overwriting backup {storeData.StoreType} buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.FillByteArrayWithFF(backupData);
                Logger.WriteLogTextToRtb($"Writing clean {storeData.StoreType} store to file buffer", RtbLogPrefix.Info, rtbLog);
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, backBodyStart, backupData);

                NvramStoreSection newStore = FWBase.GetNvramStoreData(_bytesNewBinary, storeData.StoreType);

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
        }
        #endregion

        private void cmdOpenLast_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fullBuildPath))
            {
                Program.openLastBuild = true;
                Program.lastBuildPath = _fullBuildPath;
                Close();
            }
            else
            {
                Logger.WriteLogTextToRtb($"The last build path is empty!", RtbLogPrefix.Warning, rtbLog);
            }
        }
    }
}