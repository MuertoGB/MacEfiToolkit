// Mac EFI Toolkit
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
        private byte[] _bytesNewFsysStore = null;
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

            GetRtbInitialData();


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
                _bytesNewFsysStore = File.ReadAllBytes(dialog.FileName);
                bool isValid = ValidateNewFsysStore(_bytesNewFsysStore);
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
            Program.CreateCheckBuildsFolder();

            var filename = FWBase.FileInfoData.FileNameWithExt.StartsWith("outimage_")
                ? $"{FWBase.FileInfoData.FileNameNoExt}_{DateTime.Now:yyyyMMddHHmmss}.bin"
                : $"outimage_{FWBase.FileInfoData.FileNameNoExt}_{DateTime.Now:yyyyMMddHHmmss}.bin";

            _fullBuildPath = Path.Combine(Program.buildsDirectory, filename);

            int saveResult = FileUtils.WriteAllBytesEx(_fullBuildPath, _bytesNewBinary);

            if (saveResult != 0)
            {
                Logger.WriteLogTextToRtb($"'WriteAllBytesEx' returned {saveResult}, file could not be saved!", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            Logger.WriteLogTextToRtb($"'WriteAllBytesEx' returned {saveResult}", RtbLogPrefix.Complete, rtbLog);
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
        #endregion

        #region Checkbox Events

        private void cbxClearVssStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblVssChevRight.Visible = cb.Checked;
            cbxClearVssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblSvsChevRight.Visible = cb.Checked;
            cbxClearSvsBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssStore_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            lblNssChevRight.Visible = cb.Checked;
            cbxClearNssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysStore_CheckedChanged(object sender, EventArgs e)
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

        #region UI Events
        private void GetRtbInitialData()
        {
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
                return;
            }

            Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is valid", RtbLogPrefix.Info, rtbLog);

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

            long fsysSigPos = BinaryUtils.GetOffset(sourceBytes, FWBase.FSYS_SIG);

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
            var fsysStore = FWBase.GetFsysStoreData(sourceBytes, true);

            Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Fsys signature found at {fsysSigPos:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Serial: {fsysStore.Serial} ({fsysStore.Serial.Length}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"HWC: {fsysStore.HWC}", RtbLogPrefix.Info, rtbLog);

            if (!string.Equals(fsysStore.CrcString, fsysStore.CrcCalcString))
            {
                Logger.WriteLogTextToRtb("Donor Fsys Store CRC32 is invalid, 'Mask CRC32' flag set!", RtbLogPrefix.Warning, rtbLog);
                _maskCrc = true;
            }

            Logger.WriteLogTextToRtb($"File: {fsysStore.CrcString}h > Calc: {fsysStore.CrcCalcString}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Validation completed", RtbLogPrefix.Complete, rtbLog);

            _maskCrc = false;

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
                var fsysNew = FWBase.GetFsysStoreData(_bytesNewFsysStore, true);

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
            BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.FsysOffset, _bytesNewFsysStore);

            // Load the Fsys from the new binary
            FsysStoreSection fsysNewBinary = FWBase.GetFsysStoreData(_bytesNewBinary, false);

            // Validate new Fsys was written
            if (!BinaryUtils.ByteArraysMatch(fsysNewBinary.FsysBytes, _bytesNewFsysStore))
            {
                HandleBuildFailure("ByteArraysMatch: Fsys comparison check failed");
                return false;
            }

            Logger.WriteLogTextToRtb("Fsys comparison check passed", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb("Fsys store written successfully", RtbLogPrefix.Complete, rtbLog);

            return true;
        }

        private bool WriteNewSerialData()
        {
            // Given serial is too short
            if (tbxSerialNumber.Text.Length != FWBase.FsysSectionData.Serial.Length)
            {
                HandleBuildFailure("The given serial number was too short");
                return false;
            }

            // Fsys postition was not found
            if (FWBase.FsysSectionData.SerialOffset == -1)
            {
                HandleBuildFailure("FsysSectionData store offset is -1");
                return false;
            }

            // Fsys store bytes are empty
            if (FWBase.FsysSectionData.FsysBytes == null)
            {
                HandleBuildFailure("FsysSectionData store bytes are empty");
                return false;
            }

            // Write new serial number bytes
            var newSerial = tbxSerialNumber.Text;
            byte[] newSerialBytes = Encoding.UTF8.GetBytes(newSerial);
            BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.SerialOffset, newSerialBytes);

            // Write new HWC bytes

            var newHwc = tbxHwc.Text;
            if (FWBase.FsysSectionData.HWCOffset != -1)
            {
                byte[] newHwcBytes = Encoding.UTF8.GetBytes(newHwc);
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.HWCOffset, newHwcBytes);
            }
            else
            {
                Logger.WriteLogTextToRtb("HWC offset is -1, new HWC will not be written!", RtbLogPrefix.Warning, rtbLog);
            }

            // Load new Fsys store
            var newFsys = FWBase.GetFsysStoreData(_bytesNewBinary, false);

            // Check serial numbers match
            if (!string.Equals(newSerial, newFsys.Serial))
            {
                HandleBuildFailure("Serial number comparison failed");
                return false;
            }

            // Check HWC's match
            if (FWBase.FsysSectionData.HWCOffset != -1)
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
               newFsys.FsysOffset,
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
            // Reload _bytesNewBinary
            _bytesNewBinary = FWBase.LoadedBinaryBytes;
        }
        #endregion

        private void cmdReset_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;

            GetRtbInitialData();

            _bytesNewFsysStore = null;
            _bytesNewBinary = null;
            _maskCrc = false;
            _fullBuildPath = string.Empty;

            cbxReplaceFsysStore.Checked = false;
            cbxReplaceSerial.Checked = false;
            cbxClearVssStore.Checked = false;
            cbxClearSvsStore.Checked = false;
            cbxClearNssStore.Checked = false;

            cmdOpenLast.Enabled = false;
        }
    }
}