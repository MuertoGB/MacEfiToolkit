// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
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
    public partial class patcherWindow : Form
    {

        #region Private Members
        private byte[] _bytesNewBinary = null;
        private byte[] _bytesNewFsysStore = null;
        private byte[] _bytesNewMeRegion = null;
        //private bool _maskCrc = false;
        private string _fullBuildPath = string.Empty;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public patcherWindow()
        {
            InitializeComponent();

            Load += editorWindow_Load;
            FormClosing += editorWindow_FormClosing;
            KeyDown += editorWindow_KeyDown;

            pbxLogo.MouseMove += editorWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += editorWindow_MouseMove;

            Font font = Program.FONT_MDL2_REG_9;

            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void editorWindow_Load(object sender, EventArgs e)
        {
            if (EFIROM.FsysStoreData.Serial == null)
            {
                swReplaceSerialNumber.Enabled = false;
            }
            else
            {
                tbxSerialNumber.MaxLength = EFIROM.FsysStoreData.Serial.Length;
            }

            GetRtbInitialData();
        }

        private void editorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first, otherwise ExitMet() will close the application regardless of user choice.
                if (Settings.ReadBool(SettingsBoolType.DisableConfDiag))
                {
                    e.Cancel = false;
                    return;
                }

                DialogResult result =
                    METMessageBox.Show(
                    this,
                    "Close Editor",
                    "Are you sure you want to close the editor?",
                    METMessageBoxType.Question,
                    METMessageBoxButtons.YesNo);

                e.Cancel = result == DialogResult.Yes
                    ? false
                    : true;
            }
        }
        #endregion

        #region Mouse Events
        private void editorWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            CloseWindow();

        private void CloseWindow()
        {
            if (Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                Close();

                return;
            }

            DialogResult result =
                METMessageBox.Show(
                    this,
                    "Close Editor",
                    "Are you sure you want to close the editor?",
                    METMessageBoxType.Question,
                    METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Close();
        }

        private void cmdBuildsFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(METPath.BuildsDirectory))
            {
                METMessageBox.Show(
                    this,
                    "MET",
                    "The builds directory has not been created yet.",
                    METMessageBoxType.Information,
                    METMessageBoxButtons.Okay);

                return;
            }

            Process.Start(
                "explorer.exe",
                METPath.BuildsDirectory);
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(METPath.FsysDirectory))
            {
                Status status = FileUtils.CreateDirectory(
                    METPath.FsysDirectory);

                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this, "MET",
                        "Failed to create the Fsys Stores directory.",
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);
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
                    swReplaceFsysStore.Checked = false;

                    return;
                }

                Logger.WriteLogTextToRtb(
                    $"Opening '{dialog.FileName}'",
                    RtbLogPrefix.Info,
                    rtbLog);

                _bytesNewFsysStore = File.ReadAllBytes(dialog.FileName);

                if (!ValidateNewFsysStore(_bytesNewFsysStore))
                    swReplaceFsysStore.Checked = false;
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
                    swReplaceMeRegion.Checked = false;

                    return;
                }

                Logger.WriteLogTextToRtb(
                    $"Opening '{dialog.FileName}'",
                    RtbLogPrefix.Info,
                    rtbLog);

                _bytesNewMeRegion = File.ReadAllBytes(dialog.FileName);

                if (!ValidateNewMeRegion(_bytesNewMeRegion))
                    swReplaceMeRegion.Checked = false;
            }
        }

        private void cmdBuild_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ToggleControlEnable(false);

            //    _bytesNewBinary = EFIROM.LoadedBinaryBytes;

            //    if (swReplaceFsysStore.Checked)
            //    {
            //        Logger.WriteLogTextToRtb(
            //            "Replacing Fsys Store:",
            //            RtbLogPrefix.Start,
            //            rtbLog);

            //        if (!WriteNewFsysStore())
            //            return;
            //    }

            //    if (swReplaceSerialNumber.Checked)
            //    {
            //        Logger.WriteLogTextToRtb(
            //            $"Replacing Serial Number data:",
            //            RtbLogPrefix.Start,
            //            rtbLog);

            //        if (!WriteNewSerialData())
            //            return;
            //    }

            //    if (cbxClearVssStore.Checked)
            //    {
            //        Logger.WriteLogTextToRtb(
            //            "Clearing VSS NVRAM data:",
            //            RtbLogPrefix.Start,
            //            rtbLog);

            //        EraseNvramStore(EFIROM.VssStoreData);
            //    }

            //    if (cbxClearSvsStore.Checked)
            //    {
            //        Logger.WriteLogTextToRtb(
            //            "Clearing SVS NVRAM data:",
            //            RtbLogPrefix.Start,
            //            rtbLog);

            //        EraseNvramStore(EFIROM.SvsStoreData);
            //    }

            //    if (swReplaceMeRegion.Checked)
            //    {
            //        Logger.WriteLogTextToRtb(
            //            "Writing new ME Region:",
            //            RtbLogPrefix.Start,
            //            rtbLog);

            //        if (!WriteNewMeRegion())
            //            return;
            //    }

            //    if (!SaveBuild())
            //        return;

            //    Logger.WriteLogTextToRtb(
            //        $"Firmware patching completed",
            //        RtbLogPrefix.Complete,
            //        rtbLog);

            //    cmdShowLastBuild.Enabled = true;
            //    cmdLoadLastBuild.Enabled = true;
            //}
            //finally
            //{
            //    ToggleControlEnable(true);
            //}
        }

        private bool SaveBuild()
        {
            if (!Directory.Exists(METPath.BuildsDirectory))
            {
                Status status = FileUtils.CreateDirectory(METPath.BuildsDirectory);

                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this,
                        "MET",
                        "Failed to create the builds directory.",
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);
                }
            }

            if (_bytesNewBinary == null)
            {
                METMessageBox.Show(
                    this,
                    "MET",
                    "New binary data is empty. Cannot continue.",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return false;
            }

            FsysStore fsysStore = EFIROM.GetFsysStoreData(
                _bytesNewBinary, false);

            string serialNumber = string.IsNullOrEmpty(fsysStore.Serial)
                ? "SERIALNUM"
                : fsysStore.Serial;

            string fileName = $"outimage_{serialNumber}_{MacUtils.GetFirmwareVersion()}";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                InitialDirectory = METPath.BuildsDirectory,
                OverwritePrompt = true,
                FileName = fileName
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fullBuildPath = saveFileDialog.FileName;

                    if (!FileUtils.WriteAllBytesEx(_fullBuildPath, _bytesNewBinary))
                    {
                        Logger.WriteLogTextToRtb(
                            $"'WriteAllBytesEx' returned false, file could not be saved!",
                            RtbLogPrefix.Error,
                            rtbLog);

                        return false;
                    }

                    Logger.WriteLogTextToRtb(
                        $"Save path: {_fullBuildPath}",
                        RtbLogPrefix.Info,
                        rtbLog);

                    return true;
                }
                else
                {
                    Logger.WriteLogTextToRtb(
                        $"File export cancelled by user",
                        RtbLogPrefix.Warning,
                        rtbLog);

                    return false;
                }
            }
        }

        private void cmdShowLastBuild_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fullBuildPath))
            {
                FileUtils.HighlightPathInExplorer(
                    _fullBuildPath);

                return;
            }

            Logger.WriteLogTextToRtb(
                $"The last build path is empty!",
                RtbLogPrefix.Warning,
                rtbLog);
        }

        private void cmdLoadLastBuild_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fullBuildPath))
            {
                Program.openLastBuild = true;
                Program.lastBuildPath = _fullBuildPath;

                Close();

                return;
            }

            Logger.WriteLogTextToRtb(
                $"The last build path is empty!",
                RtbLogPrefix.Warning,
                rtbLog);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;

            GetRtbInitialData();

            _bytesNewFsysStore = null;
            _bytesNewBinary = null;
            _bytesNewMeRegion = null;
            //_maskCrc = false;
            _fullBuildPath = string.Empty;

            swReplaceFsysStore.Checked = false;
            swReplaceSerialNumber.Checked = false;
            cbxClearVssStore.Checked = false;
            cbxClearSvsStore.Checked = false;
            swReplaceMeRegion.Checked = false;

            cmdShowLastBuild.Enabled = false;
            cmdLoadLastBuild.Enabled = false;
        }

        private void swReplaceSerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
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
                FileName = $"patcherlog_{DateTime.Now:yyMMdd_HHmmss}",
                OverwritePrompt = true,
                InitialDirectory = METPath.CurrentDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                File.WriteAllText(dialog.FileName, rtbLog.Text);
            }
        }
        #endregion

        #region KeyDown Events
        private void editorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseWindow();
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

        #region Checkbox Events

        private void swReplaceFsysStore_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = (CheckBox)sender;

            bool isChecked = control.Checked;

            cmdFsysPath.Enabled = isChecked;

            tlpSerialA.Enabled = !isChecked;

            if (isChecked)
                cmdFsysPath.PerformClick();
        }

        private void swReplaceMeRegion_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = (CheckBox)sender;

            cmdMePath.Enabled = control.Checked;
            cmdMePath.PerformClick();
        }
        #endregion

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb =
                (TextBox)sender;

            int textLength =
                tb.Text.Length;

            if (textLength == EFIROM.FsysStoreData.Serial.Length)
            {
                if (MacUtils.IsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(
                        tb,
                        AppColours.COMPLETE);

                    Logger.WriteLogTextToRtb(
                        "Valid serial characters entered",
                        RtbLogPrefix.Complete,
                        rtbLog);

                    if (EFIROM.FsysStoreData.Serial.Length == 11)
                    {
                        UpdateHwcTextBoxText(
                            tb.Text.Substring(textLength - 3));
                    }
                    if (EFIROM.FsysStoreData.Serial.Length == 12)
                    {
                        UpdateHwcTextBoxText(
                            tb.Text.Substring(textLength - 4));
                    }
                    cmdBuild.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColor(
                        tb,
                        AppColours.ERROR);

                    Logger.WriteLogTextToRtb(
                        "Invalid serial characters entered",
                        RtbLogPrefix.Error,
                        rtbLog);

                    UpdateHwcTextBoxText("???");

                    cmdBuild.Enabled = false;
                }
            }
            else
            {
                UpdateTextBoxColor(
                    tb,
                    Color.White);

                UpdateHwcTextBoxText(
                    string.Empty);

                cmdBuild.Enabled = true;
            }
        }
        #endregion

        #region UI Events
        private void GetRtbInitialData()
        {
            Logger.WriteLogTextToRtb(
                $"{DateTime.Now}",
                RtbLogPrefix.Info,
                rtbLog);

            LogBinarySize();

            LogDescriptorData();

            LogFsysData();

            if (EFIROM.VssStoreData.PrimaryStoreBase == -1)
            {
                cbxClearVssStore.Enabled = false;

                Logger.WriteLogTextToRtb(
                    "VSS store not found or initialised",
                    RtbLogPrefix.Warning,
                    rtbLog);
            }

            if (EFIROM.SvsStoreData.PrimaryStoreBase == -1)
            {
                cbxClearSvsStore.Enabled = false;

                Logger.WriteLogTextToRtb(
                    "SVS store not found or initialised",
                    RtbLogPrefix.Warning,
                    rtbLog);
            }

            Logger.WriteLogTextToRtb(
                "Initial checks complete",
                RtbLogPrefix.Complete,
                rtbLog);
        }

        private void LogBinarySize()
        {
            if (!FileUtils.GetIsValidBinSize(EFIROM.FileInfoData.Length))
            {
                Logger.WriteLogTextToRtb(
                    $"Loaded binary size {EFIROM.FileInfoData.Length:X2}h is invalid.",
                    RtbLogPrefix.Error,
                    rtbLog);

                return;
            }

            Logger.WriteLogTextToRtb(
                $"Loaded binary size {EFIROM.FileInfoData.Length:X2}h is valid",
                RtbLogPrefix.Info,
                rtbLog);
        }

        private void LogDescriptorData()
        {
            if (IFD.PDR_REGION_BASE != 0 && IFD.PDR_REGION_LIMIT != 0)
                Logger.WriteLogTextToRtb(
                    $"PDR Region: Base {IFD.PDR_REGION_BASE:X2}h, Limit {IFD.PDR_REGION_LIMIT:X2}h",
                    RtbLogPrefix.Info,
                    rtbLog);

            if (IFD.ME_REGION_BASE != 0 && IFD.ME_REGION_LIMIT != 0)
            {
                Logger.WriteLogTextToRtb(
                    $"ME Region: Base {IFD.ME_REGION_BASE:X2}h, Limit {IFD.ME_REGION_LIMIT:X2}h",
                    RtbLogPrefix.Info,
                    rtbLog);
            }
            else
            {
                swReplaceMeRegion.Enabled = false;

                Logger.WriteLogTextToRtb(
                    $"ME Region not found: Option disabled",
                    RtbLogPrefix.Warning,
                    rtbLog);
            }

            if (IFD.BIOS_REGION_BASE != 0 && IFD.BIOS_REGION_LIMIT != 0)
                Logger.WriteLogTextToRtb(
                    $"BIOS Region: Base {IFD.BIOS_REGION_BASE:X2}h, Limit {IFD.BIOS_REGION_LIMIT:X2}h",
                    RtbLogPrefix.Info,
                    rtbLog);
        }

        private void LogFsysData()
        {
            if (EFIROM.FsysStoreData.FsysBase != 0)
            {
                Logger.WriteLogTextToRtb(
                    $"Fsys: Base {EFIROM.FsysStoreData.FsysBase:X2}h, Size {EFIROM.FSYS_RGN_SIZE:X2}h",
                    RtbLogPrefix.Info,
                    rtbLog);

                if (EFIROM.FsysStoreData.SerialBase != -1)
                    Logger.WriteLogTextToRtb(
                        $"Serial: Base {EFIROM.FsysStoreData.SerialBase:X2}h",
                        RtbLogPrefix.Info,
                        rtbLog);

                if (EFIROM.FsysStoreData.HWCBase != -1)
                    Logger.WriteLogTextToRtb(
                        $"HWC: Base {EFIROM.FsysStoreData.HWCBase:X2}h",
                        RtbLogPrefix.Info,
                        rtbLog);
            }
        }

        private void UpdateTextBoxColor(TextBox textBox, Color color) =>
            textBox.ForeColor = color;

        private void UpdateHwcTextBoxText(string text) =>
            tbxHwc.Text = text;

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
            //Logger.WriteLogTextToRtb(
            //    "Validating donor Fsys store:",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //int fsysSigPos =
            //    BinaryUtils.GetBaseAddress(
            //    sourceBytes,
            //    EFIROM.FSYS_SIG);

            //if (fsysSigPos == -1)
            //{
            //    Logger.WriteLogTextToRtb(
            //        "Fsys signature not found",
            //        RtbLogPrefix.Error,
            //        rtbLog);

            //    return false;
            //}

            //if (fsysSigPos != 0)
            //{
            //    Logger.WriteLogTextToRtb(
            //        $"Fsys signature misaligned: {fsysSigPos:X2}h",
            //        RtbLogPrefix.Error,
            //        rtbLog);

            //    return false;
            //}

            //if (sourceBytes.Length != EFIROM.FSYS_RGN_SIZE)
            //{
            //    Logger.WriteLogTextToRtb(
            //        $"Filesize: {sourceBytes.Length:X2}h, expected 800h",
            //        RtbLogPrefix.Error,
            //        rtbLog);

            //    return false;
            //}

            //// We have validated the Fsys store, now we can load it.
            //FsysStore fsysStore =
            //    EFIROM.GetFsysStoreData(
            //    sourceBytes,
            //    true);

            //Logger.WriteLogTextToRtb(
            //    $"Filesize: {sourceBytes.Length:X2}h",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //Logger.WriteLogTextToRtb(
            //    $"Fsys signature found at {fsysSigPos:X2}h",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //Logger.WriteLogTextToRtb(
            //    $"Serial: {fsysStore.Serial} ({fsysStore.Serial.Length}char)",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //Logger.WriteLogTextToRtb(
            //    $"HWC: {fsysStore.HWC}",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //if (!string.Equals(fsysStore.CrcString, fsysStore.CrcCalcString))
            //{
            //    Logger.WriteLogTextToRtb(
            //        "Donor Fsys Store CRC32 is invalid, 'Mask CRC32' flag set!",
            //        RtbLogPrefix.Warning,
            //        rtbLog);

            //    _maskCrc = true;
            //}
            //else
            //{
            //    _maskCrc = false;
            //}

            //Logger.WriteLogTextToRtb(
            //    $"File: {fsysStore.CrcString}h > Calc: {fsysStore.CrcCalcString}h",
            //    RtbLogPrefix.Info,
            //    rtbLog);

            //Logger.WriteLogTextToRtb(
            //    "Validation completed",
            //    RtbLogPrefix.Complete,
            //    rtbLog);

            //return true;
            return true;
        }

        private bool ValidateNewMeRegion(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb(
                "Validating ME Region:",
                RtbLogPrefix.Info,
                rtbLog);

            int fptSignature =
                BinaryUtils.GetBaseAddress(
                    sourceBytes,
                    IME.FPT_SIGNATURE);

            if (fptSignature == -1)
            {
                Logger.WriteLogTextToRtb(
                    "FPT signature not found",
                    RtbLogPrefix.Error,
                    rtbLog);

                return false;
            }

            if (sourceBytes.Length > IFD.ME_REGION_SIZE)
            {
                Logger.WriteLogTextToRtb(
                    $"ME will not fit: {sourceBytes.Length:X2}h > {IFD.ME_REGION_SIZE:X2}h",
                    RtbLogPrefix.Error,
                    rtbLog);

                return false;
            }

            if (sourceBytes.Length < IFD.ME_REGION_SIZE)
                Logger.WriteLogTextToRtb(
                    $"ME is smaller ({sourceBytes.Length:X2}h) and will be adjusted at build time",
                    RtbLogPrefix.Warning,
                    rtbLog);

            string meVersion =
                IME.GetVersionData(
                    _bytesNewMeRegion,
                    VersionType.ManagementEngine);

            Logger.WriteLogTextToRtb(
                $"ME Version: {meVersion}",
                RtbLogPrefix.Info,
                rtbLog);

            Logger.WriteLogTextToRtb(
                "Validation completed",
                RtbLogPrefix.Complete,
                rtbLog);

            return true;
        }
        #endregion

        #region Editing
        //private bool WriteNewFsysStore()
        //{
        //    // Mask Fsys CRC
        //    if (_maskCrc)
        //    {
        //        Logger.WriteLogTextToRtb(
        //            "Masking Fsys store CRC",
        //            RtbLogPrefix.Info, rtbLog);

        //        // Load the new Fsys store
        //        FsysStore fsysNew =
        //            EFIROM.GetFsysStoreData(
        //                _bytesNewFsysStore,
        //                true);

        //        // Load the new Fsys store bytes and patch the crc
        //        _bytesNewFsysStore =
        //            BinaryUtils.PatchFsysCrc(
        //                fsysNew.FsysBytes,
        //                fsysNew.CRC32CalcInt);

        //        // Load the patched store
        //        fsysNew =
        //            EFIROM.GetFsysStoreData(
        //                _bytesNewFsysStore,
        //                true);

        //        // Check CRC32 masking was successful
        //        if (!string.Equals(fsysNew.CrcString, fsysNew.CrcCalcString))
        //        {
        //            HandleBuildFailure(
        //                "CRC masking failed");

        //            return false;
        //        }

        //        Logger.WriteLogTextToRtb(
        //            "CRC masking successful",
        //            RtbLogPrefix.Info,
        //            rtbLog);
        //    }

        //    // Write new Fsys to the output file
        //    BinaryUtils.OverwriteBytesAtBase(
        //        _bytesNewBinary,
        //        EFIROM.FsysStoreData.FsysBase,
        //        _bytesNewFsysStore);

        //    // Load the Fsys from the new binary
        //    FsysStore fsysNewBinary
        //        = EFIROM.GetFsysStoreData(
        //            _bytesNewBinary,
        //            false);

        //    // Validate new Fsys was written
        //    if (!BinaryUtils.ByteArraysMatch(fsysNewBinary.FsysBytes, _bytesNewFsysStore))
        //    {
        //        HandleBuildFailure(
        //            "ByteArraysMatch: Fsys comparison check failed");

        //        return false;
        //    }

        //    Logger.WriteLogTextToRtb(
        //        "Fsys comparison check passed",
        //        RtbLogPrefix.Info,
        //        rtbLog);

        //    Logger.WriteLogTextToRtb(
        //        "Data written successfully",
        //        RtbLogPrefix.Complete,
        //        rtbLog);

        //    return true;
        //}

        private bool WriteNewMeRegion()
        {
            // Create a blank array
            byte[] meData = new byte[IFD.ME_REGION_SIZE];

            // 0xFF the blank array
            BinaryUtils.EraseByteArray(meData, 0xFF);

            // Copy in the ME Region
            Array.Copy(
                _bytesNewMeRegion,
                0,
                meData,
                0,
                _bytesNewMeRegion.Length);

            // Write the new array to the new binary
            Array.Copy(
                meData,
                0,
                _bytesNewBinary,
                IFD.ME_REGION_BASE,
                meData.Length);

            // Validate write
            byte[] meNewBinary =
                BinaryUtils.GetBytesBaseLimit(
                    _bytesNewBinary,
                    (int)IFD.ME_REGION_BASE,
                    (int)IFD.ME_REGION_LIMIT);

            if (!BinaryUtils.ByteArraysMatch(meNewBinary, meData))
            {
                HandleBuildFailure(
                    "ME Region write failed");

                return false;
            }

            Logger.WriteLogTextToRtb(
                "ME Region comparison check passed",
                RtbLogPrefix.Info,
                rtbLog);

            Logger.WriteLogTextToRtb(
                "Data written successfully",
                RtbLogPrefix.Complete,
                rtbLog);

            return true;
        }

        private bool WriteNewSerialData()
        {
            // Given serial is too short
            if (tbxSerialNumber.Text.Length != EFIROM.FsysStoreData.Serial.Length)
            {
                HandleBuildFailure(
                    "The given serial number was too short");

                return false;
            }

            // Fsys postition was not found
            if (EFIROM.FsysStoreData.SerialBase == -1)
            {
                HandleBuildFailure(
                    "FsysSectionData store base is -1");

                return false;
            }

            // Fsys store bytes are empty
            if (EFIROM.FsysStoreData.FsysBytes == null)
            {
                HandleBuildFailure(
                    "FsysSectionData store bytes are empty");

                return false;
            }

            // Write new serial number bytes
            byte[] newSerialBytes = Encoding.UTF8.GetBytes(tbxSerialNumber.Text);

            BinaryUtils.OverwriteBytesAtBase(
                _bytesNewBinary,
                EFIROM.FsysStoreData.SerialBase,
                newSerialBytes);

            // Write new HWC bytes

            if (EFIROM.FsysStoreData.HWCBase != -1)
            {
                byte[] newHwcBytes = Encoding.UTF8.GetBytes(tbxHwc.Text);

                BinaryUtils.OverwriteBytesAtBase(
                    _bytesNewBinary,
                    EFIROM.FsysStoreData.HWCBase,
                    newHwcBytes);
            }
            else
            {
                Logger.WriteLogTextToRtb(
                    "HWC base is -1, new HWC will not be written!",
                    RtbLogPrefix.Warning,
                    rtbLog);
            }

            // Load new Fsys store
            FsysStore newFsys =
                EFIROM.GetFsysStoreData(
                    _bytesNewBinary,
                    false);

            // Check serial numbers match
            if (!string.Equals(tbxSerialNumber.Text, newFsys.Serial))
            {
                HandleBuildFailure(
                    "Serial number comparison failed");

                return false;
            }

            // Check HWC's match
            if (EFIROM.FsysStoreData.HWCBase != -1)
                if (!string.Equals(tbxHwc.Text, newFsys.HWC))
                {
                    HandleBuildFailure(
                        "HWC comparison failed");

                    return false;
                }

            Logger.WriteLogTextToRtb(
                "Serial number comparison successful",
                RtbLogPrefix.Complete,
                rtbLog);

            Logger.WriteLogTextToRtb(
                "HWC comparison successful",
                RtbLogPrefix.Complete,
                rtbLog);

            Logger.WriteLogTextToRtb(
                "Masking Fsys CRC32:",
                RtbLogPrefix.Info,
                rtbLog);

            _bytesNewBinary =
                BinaryUtils.MakeFsysCrcPatchedBinary(
                    _bytesNewBinary,
                    newFsys.FsysBase,
                    newFsys.FsysBytes,
                    newFsys.CRC32CalcInt);

            // Load Fsys store from the new binary again
            newFsys =
                EFIROM.GetFsysStoreData(
                    _bytesNewBinary,
                    false);

            // Check the Fsys store matches the patched store
            if (!string.Equals(newFsys.CrcCalcString, newFsys.CrcString))
            {
                HandleBuildFailure(
                    "CRC comparison check failed");

                return false;
            }

            Logger.WriteLogTextToRtb(
                "CRC masking was successful",
                RtbLogPrefix.Complete,
                rtbLog);

            return true;
        }

        private bool EraseNvramStore(NvramStore store)
        {
            // Oh what's this? Well what could this possibly be?
            // Because it looks like you're inside a function, INSIDE a function.
            bool EraseAndWriteStore(int baseAddress, int storeSize, byte[] storeBytes, Func<NvramStore, bool> isStoreEmpty)
            {
                int headerLen = 0x10;
                int bodyEnd = storeSize - headerLen;

                Logger.WriteLogTextToRtb(
                    $"Erasing {store.StoreType} store at 0x{baseAddress:X2}h",
                    RtbLogPrefix.Info,
                    rtbLog);

                Logger.WriteLogTextToRtb(
                    "Initialising store header",
                    RtbLogPrefix.Info,
                    rtbLog);

                // Initialize header
                for (int i = 0x4; i <= 0x7; i++)
                    storeBytes[i] = 0xFF;

                // VSS also needs these bytes erasing
                if (store.StoreType == NvramStoreType.VSS)
                {
                    storeBytes[0x9] = 0xFF;
                    storeBytes[0xA] = 0xFF;
                }

                Logger.WriteLogTextToRtb(
                    "Erasing store body (0xFF)",
                    RtbLogPrefix.Info,
                    rtbLog);

                // Erase store body
                byte[] erasedBody =
                    BinaryUtils.GetBytesBaseLength(
                        storeBytes,
                        headerLen,
                        bodyEnd);

                BinaryUtils.EraseByteArray(erasedBody, 0xFF);

                BinaryUtils.OverwriteBytesAtBase(
                    storeBytes,
                    headerLen,
                    erasedBody);

                // Write store back to firmware
                Logger.WriteLogTextToRtb(
                    "Writing to firmware",
                    RtbLogPrefix.Info,
                    rtbLog);

                BinaryUtils.OverwriteBytesAtBase(
                    _bytesNewBinary,
                    baseAddress,
                    storeBytes);

                NvramStore newStore =
                    EFIROM.GetNvramStoreData(
                        _bytesNewBinary,
                        store.StoreType);

                return isStoreEmpty(newStore);
            }

            if (!store.IsPrimaryStoreEmpty)
            {
                if (!EraseAndWriteStore(store.PrimaryStoreBase, store.PrimaryStoreSize, store.PrimaryStoreBytes, s => s.IsPrimaryStoreEmpty))
                {
                    HandleBuildFailure("Primary store write unsuccessful");
                    return false;
                }
                Logger.WriteLogTextToRtb("Primary store written successfully", RtbLogPrefix.Complete, rtbLog);
            }
            else
                Logger.WriteLogTextToRtb($"Primary {store.StoreType} store already empty", RtbLogPrefix.Info, rtbLog);

            if (!store.IsBackupStoreEmpty)
            {
                if (!EraseAndWriteStore(store.BackupStoreBase, store.BackupStoreSize, store.BackupStoreBytes, s => s.IsBackupStoreEmpty))
                {
                    HandleBuildFailure("Backup store write unsuccessful");
                    return false;
                }
                Logger.WriteLogTextToRtb("Backup store written successfully", RtbLogPrefix.Complete, rtbLog);
            }
            else
                Logger.WriteLogTextToRtb($"Backup {store.StoreType} store already empty", RtbLogPrefix.Info, rtbLog);

            return true;
        }

        private void HandleBuildFailure(string errorMessage)
        {
            Logger.WriteLogTextToRtb(
                "BUILD FAILED:",
                RtbLogPrefix.Error,
                rtbLog);

            Logger.WriteLogTextToRtb(
                errorMessage,
                RtbLogPrefix.Error,
                rtbLog);

            // Reload _bytesNewBinary
            _bytesNewBinary = EFIROM.LoadedBinaryBytes;
        }
        #endregion

    }
}