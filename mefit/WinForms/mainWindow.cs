// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// mainWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.UI.Renderers;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using Mac_EFI_Toolkit.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class mainWindow : Form
    {
        #region Private Members
        private string _strInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string _strLoadedBinaryFilePath;
        private string _strFilenameWithoutExt;
        private string _strCreationTime;
        private string _strModifiedTime;
        private string _strRememberPath;
        private string _strFilename;
        private string _strSerialNumber;
        private string _strHwc;
        private string _strEfiVersion;
        private string _strBootromVersion;
        private string _strApfsCapable;
        private string _strFsysChecksumInBinary;
        private string _strFsysCalculation;
        private string _strFitcVersion;
        private string _strMeVersion;
        private string _strBoardId;
        private string _strSon;

        private byte[] _bytesLoadedFile;
        private byte[] _bytesFsys;

        private uint _uiCrcOfLoadedFile;

        private long _lFilesize;
        private long _lFsysOffset;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.Style |= Program.WS_MINIMIZEBOX;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Window Events
        public mainWindow()
        {
            InitializeComponent();

            lblMessage.Hide();

            Load += mainWindow_Load;
            Shown += mainWindow_Shown;
            FormClosing += mainWindow_FormClosing;
            KeyDown += mainWindow_KeyDown;

            tlpMain.MouseMove += Move_Form;
            tlpMainIcon.MouseMove += Move_Form;
            lblWindowTitle.MouseMove += Move_Form;

            DragEnter += mainWindow_DragEnter;
            DragDrop += mainWindow_DragDrop;

            CreateTipHandlers();

            cmsMainMenu.Renderer = new METMenuRenderer();
            cmsApplication.Renderer = new METMenuRenderer();
            cmsFsysMenu.Renderer = new METMenuRenderer();

            cmdMenu.Font = Program.FONT_MDL2_REG_14;
            cmdMenu.Text = "\xE169";
            cmdExportFsysBlock.Font = Program.FONT_MDL2_REG_9;
            cmdExportFsysBlock.Text = "\xE74E";
            cmdFixFsysCrc.Font = Program.FONT_MDL2_REG_9;
            cmdFixFsysCrc.Text = "\xE90F";
            cmdEveryMacSearch.Font = Program.FONT_MDL2_REG_9;
            cmdEveryMacSearch.Text = "\xF6FA";
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            var dbgMode = false;
#if DEBUG
            dbgMode = true;
#endif

            ToggleControlEnable(false);

            lblVersion.Text = Application.ProductVersion;

            if (!Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck))
            {
                if (!dbgMode) CheckForNewVersion();
            }

            if (Program.blUserDraggedFile)
            {
                LoadDataNoOfd(Program.strDraggedFile);
            }

        }

        private void mainWindow_Shown(object sender, EventArgs e)
        {
            if (!Program.blUserDraggedFile) InterfaceUtils.FlashForecolor(cmdOpenBin);
        }

        internal async void CheckForNewVersion()
        {
            var result = await METVersion.CheckForNewVersion("https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml");

            if (result == VersionCheckResult.NewVersionAvailable)
            {
                lblVersion.ForeColor = Color.Tomato;
                lblVersion.Cursor = Cursors.Hand;
                lblVersion.Click += lblVersion_Click;
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first, otherwise ExitMet() will close the application regardless of user choice.
                if (!Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
                {
                    e.Cancel = true;
                }

                Program.ExitMet(this);
            }
        }

        private void mainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1
                && ((string[])e.Data.GetData(DataFormats.FileDrop))[0].EndsWith(".bin", StringComparison.OrdinalIgnoreCase))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void mainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string strDraggedFileName = strFiles[0];
            LoadDataNoOfd(strDraggedFileName);
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O) cmdOpenBin.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R) cmdReset.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E) cmdExportFsysBlock.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C) cmdEveryMacSearch.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M) ShowContextMenu(cmdMenu, cmsMainMenu);
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) using (var frm = new settingsWindow()) frm.Show();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A) using (var frm = new aboutWindow()) frm.Show();
        }
        #endregion

        #region Mouse Events
        private void Move_Form(object sender, MouseEventArgs e)
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
            Program.ExitMet(this);
        }

        private void cmdMin_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsMainMenu);
        }

        private void cmdOpenBin_Click(object sender, EventArgs e)
        {
            string initialDirectory;

            if (!string.IsNullOrEmpty(_strRememberPath))
            {
                initialDirectory = _strRememberPath;
            }
            else
            {
                initialDirectory = Settings.SettingsGetString(SettingsStringType.InitialDirectory);
                if (string.IsNullOrEmpty(initialDirectory) || !Directory.Exists(initialDirectory))
                {
                    initialDirectory = _strInitialDirectory;
                }
            }

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = initialDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _strLoadedBinaryFilePath = dialog.FileName;
                    _strFilenameWithoutExt = Path.GetFileNameWithoutExtension(dialog.FileName);
                    _bytesLoadedFile = File.ReadAllBytes(_strLoadedBinaryFilePath);
                    var fsysOut = FirmwareParser.GetFsysRegionBytes(_bytesLoadedFile, true);
                    _bytesFsys = fsysOut.BlockBytes; _lFsysOffset = fsysOut.Offset;
                    if (boolIsValidFirmware())
                    {
                        ToggleControlEnable(false);
                        _strInitialDirectory = _strLoadedBinaryFilePath;
                        _strRememberPath = _strLoadedBinaryFilePath;
                        LoadEfiData();
                    }
                    else
                    {
                        _strLoadedBinaryFilePath = string.Empty;
                        ResetData();
                    }
                }
            }
        }

        private void cmdResetUnload_Click(object sender, EventArgs e)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                ResetData();
            }
            else
            {
                var result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", MsgType.Warning, MsgButton.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        ResetData();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void cmdSerialCheck_Click(object sender, EventArgs e)
        {
            // Opens a browser window to EveryMac, and automatically loads in the serial.
            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", _strSerialNumber));
        }

        private void cmdExportFsysBlock_Click(object sender, EventArgs e)
        {
            if (_bytesFsys == null)
            {
                MessageBox.Show("Fsys block bytes[] empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export Fsys block data...",
                FileName = string.Concat("FSYS_RGN_", _strFilenameWithoutExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = _strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllBytes(dialog.FileName, _bytesFsys);
            }
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {

            if (_bytesFsys == null)
            {
                METMessageBox.Show(this, "Error", "Fsys block bytes empty, cannot continue.", MsgType.Critical, MsgButton.Okay);
                return;
            }

            if (_lFsysOffset == -1)
            {
                METMessageBox.Show(this, "Error", "The Fsys block location is not set, cannot continue.", MsgType.Critical, MsgButton.Okay);
                return;
            }

            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export repaired binary...",
                FileName = string.Concat("FSYS_Fixed_", _strFilenameWithoutExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = _strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                int len = 0x7FC;
                byte[] bytesTempFsys = new byte[len];
                Array.Copy(_bytesFsys, bytesTempFsys, Math.Min(_bytesFsys.Length, len));
                uint uintNewCrc = FileUtils.GetCRC32FromBytes(bytesTempFsys);
                byte[] newCrc = BitConverter.GetBytes(uintNewCrc);
                BinaryUtils.OverwriteBytesAtOffset(_bytesLoadedFile, _lFsysOffset + len, newCrc);

                File.WriteAllBytes(dialog.FileName, _bytesLoadedFile);

                if (File.Exists(dialog.FileName))
                {
                    DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?", MsgType.Information, MsgButton.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        LoadDataNoOfd(dialog.FileName);
                    }
                }
            }
        }
        #endregion

        #region Toolstrip Events

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.strLogFilePath))
            {
                Process.Start(Logger.strLogFilePath);
            }
            else
            {
                METMessageBox.Show(this, "File Information", "The log file was not detected, it has not yet been created.", MsgType.Information, MsgButton.Okay);
            }
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new settingsWindow()) frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new aboutWindow()) frm.ShowDialog();
        }

        private void MinimizeWindow()
        {
            WindowState = FormWindowState.Minimized;
        }

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void restartApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ExitMet(this);
        }
        #endregion

        #region Label Events
        private void lblVersion_Click(object sender, EventArgs e)
        {
            Process.Start(METVersion.strLatestUrl);
        }

        private void CreateTipHandlers()
        {
            cmdExportFsysBlock.MouseEnter += HandleMouseEnterTip;
            cmdExportFsysBlock.MouseLeave += HandleMouseLeaveTip;
            cmdFixFsysCrc.MouseEnter += HandleMouseEnterTip;
            cmdFixFsysCrc.MouseLeave += HandleMouseLeaveTip;
            cmdEveryMacSearch.MouseEnter += HandleMouseEnterTip;
            cmdEveryMacSearch.MouseLeave += HandleMouseLeaveTip;
            cmdOpenBin.MouseEnter += HandleMouseEnterTip;
            cmdOpenBin.MouseLeave += HandleMouseLeaveTip;
            cmdReset.MouseEnter += HandleMouseEnterTip;
            cmdReset.MouseLeave += HandleMouseLeaveTip;
            cmdEditEfirom.MouseEnter += HandleMouseEnterTip;
            cmdEditEfirom.MouseLeave += HandleMouseLeaveTip;
        }

        private void HandleMouseEnterTip(object sender, EventArgs e)
        {
            if (sender == cmdExportFsysBlock)
                lblMessage.Text = "Export Fsys block to disk...";
            else if (sender == cmdFixFsysCrc)
                lblMessage.Text = "Repair Fsys CRC32...";
            else if (sender == cmdEveryMacSearch)
                lblMessage.Text = "View serial number information on EveryMac...";
            else if (sender == cmdOpenBin)
                lblMessage.Text = "Open a Mac EFIROM...";
            else if (sender == cmdReset)
                lblMessage.Text = "Unload EFIROM and clear all data...";
            else if (sender == cmdEditEfirom)
                lblMessage.Text = "Edit serial number, clear NVRAM, etc...";

            lblMessage.Show();
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            lblMessage.Hide();
        }
        #endregion

        #region Picturebox Events
        private void pbxTitleLogo_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsApplication);
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
        }
        #endregion

        #region Window Events

        private void ShowContextMenu(Control control, ContextMenuStrip menu)
        {
            Point ptLowerLeft = new Point(-1, control.Height + 2);
            ptLowerLeft = control.PointToScreen(ptLowerLeft);
            menu.Show(ptLowerLeft);
        }
        #endregion

        #region Firmware Parsing

        internal bool boolIsValidFirmware()
        {
            FileInfo fInfo = new FileInfo(_strLoadedBinaryFilePath);
            // Binary too small? Potential bug here.
            if (fInfo.Length < FirmwareParser.intMinROMSize) // 1048576 bytes
            {
                METMessageBox.Show(this, "File Error", "File ignored, the file was too small.", MsgType.Warning, MsgButton.Okay);
                return false;
            }
            // Binary too large, no Mac EFI is this big.
            if (fInfo.Length > FirmwareParser.intMaxROMSize) // 33554432 bytes
            {
                METMessageBox.Show(this, "File Error", "File ignored, the file was too large.", MsgType.Warning, MsgButton.Okay);
                return false;
            }

            if (!Settings.SettingsGetBool(SettingsBoolType.DisableDescriptorEnforce))
            {
                if (!FirmwareParser.GetIsValidFlashHeader(_bytesLoadedFile))
                {
                    METMessageBox.Show(this, "File Error", "File ignored, the flash descriptor signature was invalid.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }

            if (!Settings.SettingsGetBool(SettingsBoolType.DisableFsysEnforce))
            {
                if (_bytesFsys == null)
                {
                    METMessageBox.Show(this, "Data Error", "Could not locate the Fsys block, the file was not loaded.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }
            return true;
        }

        internal void LoadEfiData()
        {
            var fileInfo = new FileInfo(_strLoadedBinaryFilePath);
            DateTime creationTime = fileInfo.CreationTime;
            DateTime modifiedTime = fileInfo.LastWriteTime;

            // Filename
            _strFilename = Path.GetFileName(_strLoadedBinaryFilePath);
            // Size
            _lFilesize = FileUtils.GetFileSizeBytes(_strLoadedBinaryFilePath);
            // File CRC32
            _uiCrcOfLoadedFile = FileUtils.GetCRC32FromBytes(_bytesLoadedFile);
            // Created time
            _strCreationTime = $"{creationTime}";
            // Modified time
            _strModifiedTime = $"{modifiedTime}";
            // Serial number
            _strSerialNumber = FirmwareParser.GetFsysRegionSerialNumber(_bytesFsys);
            // HWC
            _strHwc = FirmwareParser.GetFsysRegionHwc(_bytesFsys);
            // EFI Version
            _strEfiVersion = FirmwareParser.GetRomSectionEFIVersion(_bytesLoadedFile);
            // ROM version
            _strBootromVersion = FirmwareParser.GetRomSectionBootROMVersion(_bytesLoadedFile);
            // Fsys CRC32 string
            _strFsysChecksumInBinary = FirmwareParser.GetFsysRegionCRC32(_bytesLoadedFile);
            // Fsys CRC32
            byte[] bytesTempFsys = new byte[0x7FC];
            if (_bytesFsys != null) Array.Copy(_bytesFsys, 0, bytesTempFsys, 0, bytesTempFsys.Length);
            _strFsysCalculation = FileUtils.GetCRC32FromBytes(bytesTempFsys).ToString("X8");
            // APFSJumpStart
            _strApfsCapable = $"{ FirmwareParser.GetIsApfsCapableBool(_bytesLoadedFile) }";
            // FITC
            _strFitcVersion = MEParser.GetFITCVersion(_bytesLoadedFile);
            //ME
            _strMeVersion = MEParser.GetMEVersion(_bytesLoadedFile);
            // Get the BoardId
            _strBoardId = FirmwareParser.GetBoardId(_bytesLoadedFile);
            // SON
            _strSon = FirmwareParser.GetFsysRegionSon(_bytesFsys);

            UpdateControls();
        }

        internal void UpdateControls()
        {
            lblFilename.Text = $"· {_strFilename}";
            lblFilesizeBytes.ForeColor = EFIUtils.GetIsValidBinSize((int)_lFilesize) ? Colours.clrGood : Colours.clrUnknown;
            lblFilesizeBytes.Text = FileUtils.FormatFileSizeBytesWithCommas(FileUtils.GetFileSizeBytes(_strLoadedBinaryFilePath));
            lblCreated.Text = _strCreationTime;
            lblModified.Text = _strModifiedTime;
            lblFileChecksum.Text = _uiCrcOfLoadedFile.ToString("X8");
            lblFsysCrc.Text = $"{ _strFsysChecksumInBinary }h";
            lblFsysCrc.ForeColor = (_strFsysCalculation == _strFsysChecksumInBinary) ? lblFsysCrc.ForeColor = Colours.clrGood : lblFsysCrc.ForeColor = Colours.clrError;
            cmdFixFsysCrc.Enabled = (_strFsysCalculation == _strFsysChecksumInBinary) ? false : true;
            lblApfsCapable.Text = _strApfsCapable;
            if (_strApfsCapable == "Yes") lblApfsCapable.ForeColor = Colours.clrGood; else lblApfsCapable.ForeColor = Colours.clrUnknown;
            CheckHwcAsync(_strHwc);
            lblSerialNumber.Text = _strSerialNumber;
            lblHwc.Text = _strHwc;
            lblEfiVersion.Text = _strEfiVersion;
            lblRomVersion.Text = _strBootromVersion;
            lblFitcVersion.Text = _strFitcVersion;
            lblMeVersion.Text = _strMeVersion;
            lblBoardId.Text = _strBoardId;
            lblSon.Text = _strSon;

            ToggleControlEnable(true);
        }

        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils.GetConfigCodeAsync(strHwc);
            lblConfig.Text = $"· {configCode}";
        }
        #endregion

        #region Reset / Reload
        private void ResetData()
        {
            // Clear labels
            Label[] labels =
            {
                lblFilename, lblFileChecksum, lblFilesizeBytes, lblCreated, lblModified,
                lblConfig, lblSerialNumber, lblHwc, lblEfiVersion, lblRomVersion,
                lblFsysCrc, lblApfsCapable, lblFitcVersion, lblMeVersion, lblBoardId,
                lblSon
            };
            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = Color.White;
            }

            // Clear strings
            string[] strFields =
            {
                _strLoadedBinaryFilePath, _strFilenameWithoutExt, _strCreationTime, _strModifiedTime,
                _strRememberPath, _strFilename, _strSerialNumber, _strHwc, _strEfiVersion, _strBootromVersion,
                _strApfsCapable, _strFsysChecksumInBinary, _strFsysCalculation, _strFitcVersion,
                _strMeVersion, _strBoardId, _strSon
            };
            for (int i = 0; i < strFields.Length; i++)
            {
                strFields[i] = string.Empty;
            }

            // Clear byte arrays
            byte[][] byteFields =
            {
                _bytesLoadedFile, _bytesFsys
            };
            for (int i = 0; i < byteFields.Length; i++)
            {
                byteFields[i] = null;
            }

            // Clear the large object heap
            GC.Collect();
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                if (GC.WaitForFullGCComplete() == GCNotificationStatus.Succeeded)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            // Clear the integers
            _uiCrcOfLoadedFile = 0;
            _lFilesize = 0;
            _lFsysOffset = 0;

            // Disable controls
            ToggleControlEnable(false);
        }

        private void ToggleControlEnable(bool Enable)
        {
            Button[] buttons = { cmdReset, cmdExportFsysBlock, cmdEveryMacSearch };
            tlpMain.Enabled = Enable;
            foreach (Button button in buttons)
            {
                button.Enabled = (Enable) ? true : false;
            }
        }

        private void LoadDataNoOfd(string filePath)
        {
            _strLoadedBinaryFilePath = filePath;
            _strFilenameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            _bytesLoadedFile = File.ReadAllBytes(filePath);
            var fsysOut = FirmwareParser.GetFsysRegionBytes(_bytesLoadedFile, true);
            _bytesFsys = fsysOut.BlockBytes; _lFsysOffset = fsysOut.Offset;
            if (boolIsValidFirmware())
            {
                ToggleControlEnable(false);
                _strInitialDirectory = _strLoadedBinaryFilePath;
                _strRememberPath = _strLoadedBinaryFilePath;
                LoadEfiData();
            }
            else
            {
                _strLoadedBinaryFilePath = string.Empty;
                ResetData();
            }
        }
        #endregion

    }
}