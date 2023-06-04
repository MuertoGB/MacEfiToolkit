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

        #region Constructor
        public mainWindow()
        {
            InitializeComponent();

            lblMessage.Hide();

            Load += mainWindow_Load;
            FormClosing += mainWindow_FormClosing;
            KeyDown += mainWindow_KeyDown;
            DragEnter += mainWindow_DragEnter;
            DragDrop += mainWindow_DragDrop;

            SetTipHandlers();

            SetMouseMoveEventHandlers();
            SetContextMenuRenderers();
            SetButtonProperties();

            lblVersion.Text = Application.ProductVersion;
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            lblVersion.Text = Application.ProductVersion;

            if (!Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck) && !IsDebugMode())
            {
                CheckForNewVersion();
            }

            if (Program.blUserDraggedFile)
            {
                LoadFirmwareData(Program.strDraggedFile);
            }
        }

        private bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
    return false;
#endif
        }
        #endregion

        #region Window Events

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
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (draggedFiles.Length == 1)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void mainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];
            LoadFirmwareData(draggedFilename);
        }

        private void ChildWindowClosed(object sender, EventArgs e)
        {
            Opacity = 1.0;
        }

        private void ShowContextMenu(Control control, ContextMenuStrip menu)
        {
            Point lowerLeft = new Point(-1, control.Height + 2);
            lowerLeft = control.PointToScreen(lowerLeft);
            menu.Show(lowerLeft);
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
        private void mainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }

        private void SetMouseMoveEventHandlers()
        {
            Control[] controls = { tlpMain, tlpMainIcon, lblWindowTitle, tlpMenu };
            foreach (Control control in controls)
            {
                control.MouseMove += mainWindow_MouseMove;
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

            if (!string.IsNullOrEmpty(Program.strRememberPath))
            {
                initialDirectory = Program.strRememberPath;
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
                    LoadFirmwareData(dialog.FileName);
                }
            }
        }

        private void cmdResetUnload_Click(object sender, EventArgs e)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                ResetAllData();
            }
            else
            {
                var result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", MsgType.Warning, MsgButton.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        ResetAllData();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void cmdEditEfirom_Click(object sender, EventArgs e)
        {
            bool bOpenEditor = Settings.SettingsGetBool(SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                Opacity = 0.5;
                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult dr = frm.ShowDialog();
                    bOpenEditor = (dr != DialogResult.No);
                }
            }

            if (bOpenEditor)
            {
                Opacity = 0.5;
                using (Form frm = new editorWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    frm.ShowDialog();
                }
            }

        }

        private void cmdSerialCheck_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", FWParser.strSerialNumber));
        }

        private void cmdExportFsysBlock_Click(object sender, EventArgs e)
        {
            if (FWParser.bytesLoadedFsys == null)
            {
                METMessageBox.Show(this, "Error", "Fsys block bytes empty.", MsgType.Critical, MsgButton.Okay);
                return;
            }

            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export Fsys region data...",
                FileName = string.Concat("FSYS_RGN_", FWParser.strFilenameWithoutExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = Program.strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllBytes(dialog.FileName, FWParser.bytesLoadedFsys);
            }
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {
            // Fsys region was not found by the firmware parser
            if (FWParser.bytesLoadedFsys == null)
            {
                METMessageBox.Show(this, "Error", "Fsys block bytes empty.", MsgType.Critical, MsgButton.Okay);
                return;
            }

            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Save File...",
                FileName = $"FSYS_Fixed_{FWParser.strFilenameWithoutExt}.bin",
                OverwritePrompt = true,
                InitialDirectory = Program.strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    // Action was cancelled, nothing to do
                    return;
                }

                //// Calculate crc32 of the temporary Fsys bytes
                uint newCrc = EFIUtils.GetUintFsysCrc32(FWParser.bytesLoadedFsys);
                // Convert new crc32 uint to bytes
                byte[] newCrcBytes = BitConverter.GetBytes(newCrc);
                // Overwrite the loaded Fsys crc32 with the newly calculated crc32
                BinaryUtils.OverwriteBytesAtOffset(FWParser.bytesLoadedFile, FWParser.lFsysOffset + 0x7FC, newCrcBytes);

                // Write the new binary to disk
                File.WriteAllBytes(dialog.FileName, FWParser.bytesLoadedFile);

                // Check the new file exists
                if (File.Exists(dialog.FileName))
                {
                    // Ask if user wants to open the repaired file
                    DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?", MsgType.Information, MsgButton.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        // Load new file data
                        LoadFirmwareData(dialog.FileName);
                    }
                }
            }
        }

        private void SetButtonProperties()
        {
            cmdMenu.Font = Program.FONT_MDL2_REG_14;
            cmdMenu.Text = "\xE169";
            cmdExportFsysBlock.Font = Program.FONT_MDL2_REG_9;
            cmdExportFsysBlock.Text = "\xE74E";
            cmdFixFsysCrc.Font = Program.FONT_MDL2_REG_9;
            cmdFixFsysCrc.Text = "\xE90F";
            cmdEveryMacSearch.Font = Program.FONT_MDL2_REG_9;
            cmdEveryMacSearch.Text = "\xF6FA";
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
            Opacity = 0.5;
            using (Form formWindow = new settingsWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            using (Form formWindow = new aboutWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }

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

        private void SetTipHandlers()
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
                lblMessage.Text = "Export Fsys Region";
            else if (sender == cmdFixFsysCrc)
                lblMessage.Text = "Repair Fsys CRC32";
            else if (sender == cmdEveryMacSearch)
                lblMessage.Text = "View serial number information with EveryMac";
            else if (sender == cmdOpenBin)
                lblMessage.Text = "Open an EFIROM";
            else if (sender == cmdReset)
                lblMessage.Text = "Unload EFIROM and clear all data";
            else if (sender == cmdEditEfirom)
                lblMessage.Text = "Open the firmware editor";

            lblMessage.Show();
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            lblMessage.Hide();
        }
        #endregion

        #region Misc Control Events
        private void ToggleControlEnable(bool enable)
        {
            Button[] buttons = { cmdReset, cmdEditEfirom, cmdExportFsysBlock, cmdEveryMacSearch };
            foreach (Button button in buttons)
            {
                button.Enabled = (enable) ? true : false;
            }

            // Overrides > For when setting 'Override valid fsys enforement' is enabled, and the Fsys region is not found.
            // I may revisit here in the future.
            if (FWParser.bytesLoadedFsys != null)
            {
                cmdFixFsysCrc.Enabled = (FWParser.strRealFsysChecksum == FWParser.strFsysChecksumInBinary) ? false : true;
            }
            else
            {
                cmdFixFsysCrc.Enabled = false;
                cmdExportFsysBlock.Enabled = false;
                cmdEditEfirom.Enabled = false;
            }

            cmdEveryMacSearch.Enabled = (FWParser.strSerialNumber != "N/A");

            tlpMain.Enabled = enable;
        }

        private void SetContextMenuRenderers()
        {
            ContextMenuStrip[] menus = { cmsMainMenu, cmsApplication, cmsFsysMenu };
            foreach (var menu in menus)
            {
                menu.Renderer = new METMenuRenderer();
            }
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

        #region Firmware Parsing

        private bool GetIsValidFirmware()
        {
            var fileInfo = new FileInfo(FWParser.strLoadedBinaryFilePath);
            // Binary too small
            if (fileInfo.Length < FWParser.intMinROMSize) // 1048576 bytes
            {
                METMessageBox.Show(this, "Warning", "The file is too small and was ignored.", MsgType.Warning, MsgButton.Okay);
                return false;
            }

            // Binary too large
            if (fileInfo.Length > FWParser.intMaxROMSize) // 33554432 bytes
            {
                METMessageBox.Show(this, "Warning", "The file is too large and was ignored.", MsgType.Warning, MsgButton.Okay);
                return false;
            }

            // Invalid flash descriptor signature
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableDescriptorEnforce))
            {
                if (!FWParser.GetIsValidFlashHeader(FWParser.bytesLoadedFile))
                {
                    METMessageBox.Show(this, "Warning", "File ignored, the flash descriptor signature was invalid.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }

            // Fsys region not found
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableFsysEnforce))
            {
                if (FWParser.bytesLoadedFsys == null)
                {
                    METMessageBox.Show(this, "Warning", "Could not locate the Fsys block, the file was not loaded.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }

            return true;
        }

        internal void LoadEfiData()
        {
            var fileInfo = new FileInfo(FWParser.strLoadedBinaryFilePath);
            DateTime creationTime = fileInfo.CreationTime;
            DateTime modifiedTime = fileInfo.LastWriteTime;

            // Filename
            FWParser.strFilename = Path.GetFileName(FWParser.strLoadedBinaryFilePath);
            // Size
            FWParser.lLoadedFileSize = fileInfo.Length;
            // File CRC32
            FWParser.uiCrcOfLoadedFile = FileUtils.GetUintCrc32(FWParser.bytesLoadedFile);
            // Created time
            FWParser.strCreationTime = $"{creationTime}";
            // Modified time
            FWParser.strModifiedTime = $"{modifiedTime}";
            // Serial number
            FWParser.strSerialNumber = FWParser.bytesLoadedFsys != null ? FWParser.GetFsysSerialNumber(FWParser.bytesLoadedFsys) : "N/A";
            // HWC
            FWParser.strHwc = FWParser.bytesLoadedFsys != null ? FWParser.GetFsysHwc(FWParser.bytesLoadedFsys) : "N/A";
            // EFI Version
            FWParser.strEfiVersion = FWParser.GetEfiVersion(FWParser.bytesLoadedFile);
            // ROM version
            FWParser.strBootromVersion = FWParser.GetBootromVersion(FWParser.bytesLoadedFile);
            // Fsys CRC32 string
            FWParser.strFsysChecksumInBinary = FWParser.GetFsysCrc32(FWParser.bytesLoadedFile);
            // Fsys CRC32
            FWParser.strRealFsysChecksum = EFIUtils.GetUintFsysCrc32(FWParser.bytesLoadedFsys).ToString("X8");
            // APFSJumpStart
            FWParser.strApfsCapable = $"{ FWParser.GetIsApfsCapable(FWParser.bytesLoadedFile) }";
            // FITC
            FWParser.strFitcVersion = MEParser.GetFitcVersion(FWParser.bytesLoadedFile);
            //ME
            FWParser.strMeVersion = MEParser.GetManagementEngineVersion(FWParser.bytesLoadedFile);
            // Get the BoardId
            FWParser.strBoardId = FWParser.GetBoardId(FWParser.bytesLoadedFile);
            // SON
            FWParser.strSon = FWParser.bytesLoadedFsys != null ? FWParser.GetFsysSon(FWParser.bytesLoadedFsys) : "N/A";

            UpdateControls();
        }

        internal void UpdateControls()
        {
            lblFilename.Text = $"{FWParser.strFilename}";
            lblFilesizeBytes.ForeColor = EFIUtils.GetIsValidBinSize((int)FWParser.lLoadedFileSize) ? Colours.clrGood : Colours.clrUnknown;
            lblFilesizeBytes.Text = FileUtils.FormatFileSize(FWParser.lLoadedFileSize);
            lblCreated.Text = FWParser.strCreationTime;
            lblModified.Text = FWParser.strModifiedTime;
            lblFileChecksum.Text = FWParser.uiCrcOfLoadedFile.ToString("X8");

            if (FWParser.strFsysChecksumInBinary != "N/A")
            {
                lblFsysCrc.Text = $"{ FWParser.strFsysChecksumInBinary }h";
                lblFsysCrc.ForeColor = (FWParser.strRealFsysChecksum == FWParser.strFsysChecksumInBinary) ? lblFsysCrc.ForeColor = Colours.clrGood : lblFsysCrc.ForeColor = Colours.clrError;
            }
            else
            {
                lblFsysCrc.Text = "N/A";
                lblFsysCrc.ForeColor = Color.White;
            }

            lblApfsCapable.Text = FWParser.strApfsCapable;
            if (FWParser.strApfsCapable == "Yes")
            {
                lblApfsCapable.ForeColor = Colours.clrGood;
            }
            else
            {
                lblApfsCapable.ForeColor = Colours.clrUnknown;
            }

            GetHwcAsync(FWParser.strHwc);
            lblSerialNumber.Text = FWParser.strSerialNumber;
            lblHwc.Text = FWParser.strHwc;
            lblEfiVersion.Text = FWParser.strEfiVersion;
            lblRomVersion.Text = FWParser.strBootromVersion;
            lblFitcVersion.Text = FWParser.strFitcVersion;
            lblMeVersion.Text = FWParser.strMeVersion;
            lblBoardId.Text = FWParser.strBoardId;
            lblSon.Text = FWParser.strSon;

            ToggleControlEnable(true);
        }

        internal async void GetHwcAsync(string strHwc)
        {
            // Fallback method, maybe we should use the serial number first, and this as last resort?
            if (string.Equals(strHwc, "N/A", StringComparison.OrdinalIgnoreCase))
            {
                lblConfig.Text = $"{FWParser.GetModelIdentifier(FWParser.bytesLoadedFile)}";
                return; // Exit immediately.
            }

            var configCode = await EFIUtils.GetDeviceConfigCodeAsync(strHwc);
            lblConfig.Text = $"{configCode}";
        }

        private void LoadFirmwareData(string filePath)
        {
            FWParser.strLoadedBinaryFilePath = filePath;
            FWParser.strFilenameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            FWParser.bytesLoadedFile = File.ReadAllBytes(filePath);

            var fsysData = FWParser.GetFsysRegionBytes(FWParser.bytesLoadedFile, true);
            FWParser.bytesLoadedFsys = fsysData.BlockBytes;
            FWParser.lFsysOffset = fsysData.Offset;

            if (GetIsValidFirmware())
            {
                ToggleControlEnable(false);
                _strInitialDirectory = FWParser.strLoadedBinaryFilePath;
                Program.strRememberPath = FWParser.strLoadedBinaryFilePath;
                LoadEfiData();
            }
            else
            {
                FWParser.strLoadedBinaryFilePath = string.Empty;
                ResetAllData();
            }
        }

        private void ResetAllData()
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

            // Clear FWParser members
            FWParser.ClearBaseData();

            // Clear private members
            Program.strRememberPath = string.Empty;

            // Clear the large object heap
            GC.Collect();
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                if (GC.WaitForFullGCComplete() == GCNotificationStatus.Succeeded)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            // Disable controls
            ToggleControlEnable(false);
        }
        #endregion

    }
}