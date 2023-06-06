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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class mainWindow : Form
    {

        #region Private Members
        private string _strInitialDirectory = Program.appDirectory;
        private static readonly object _lockObject = new object();
        private static System.Threading.Timer _statsTimer;
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

            TimerCallback callback = new TimerCallback(UpdateMemoryStats);
            _statsTimer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            lblVersion.Text = Application.ProductVersion;

            SetPrimaryInitialDirectory();

            if (!string.IsNullOrEmpty(Program.draggedFile))
            {
                OpenBinary(Program.draggedFile);
            }

            if (!Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck) && !IsDebugMode())
            {
                CheckForNewVersion();
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
                _statsTimer.Dispose();
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
            OpenBinary(draggedFilename);
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Key combinations
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    cmdOpenBin.PerformClick();
                }
                else if (e.KeyCode == Keys.R)
                {
                    cmdReset.PerformClick();
                }
                else if (e.KeyCode == Keys.E)
                {
                    cmdEditEfirom.PerformClick();
                }
                else if (e.KeyCode == Keys.M)
                {
                    ShowContextMenu(cmdMenu, cmsMainMenu);
                }
                else if (e.KeyCode == Keys.S)
                {
                    using (var frm = new settingsWindow())
                    {
                        frm.ShowDialog();
                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    using (var frm = new aboutWindow())
                    {
                        frm.ShowDialog();
                    }
                }
            }

            // Alt + Key combinations
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.N)
                {
                    cmdNavigate.PerformClick();
                }
                else if (e.KeyCode == Keys.R)
                {
                    cmdReload.PerformClick();
                }
                else if (e.KeyCode == Keys.C)
                {
                    cmdEveryMacSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.E)
                {
                    cmdExportFsysBlock.PerformClick();
                }
                else if (e.KeyCode == Keys.F)
                {
                    cmdFixFsysCrc.PerformClick();
                }
            }
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

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
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

        private void cmdEveryMacSearch_Click(object sender, EventArgs e)
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
                InitialDirectory = _strInitialDirectory
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
                InitialDirectory = _strInitialDirectory
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
                        OpenBinary(dialog.FileName);
                    }
                }
            }
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            var fileBytes = File.ReadAllBytes(FWParser.strLoadedBinaryFilePath);
            var shaOnDisk = FileUtils.GetSha256Digest(fileBytes);
            var shaInMemory = FileUtils.GetSha256Digest(FWParser.bytesLoadedFile);

            if (!string.Equals(shaOnDisk, shaInMemory))
            {
                OpenBinary(FWParser.strLoadedBinaryFilePath);
            }
            else
            {
                METMessageBox.Show(this, "MET", "File on disk matches file in memory. Data was not refreshed.", MsgType.Information, MsgButton.Okay);
            }
        }

        private void cmdNavigate_Click(object sender, EventArgs e)
        {
            FileUtils.OpenFileInExplorer(FWParser.strLoadedBinaryFilePath);
        }

        private void SetButtonProperties()
        {
            cmdMenu.Font = Program.FONT_MDL2_REG_14;
            cmdMenu.Text = "\xE169";
            cmdNavigate.Font = Program.FONT_MDL2_REG_9;
            cmdNavigate.Text = "\xEC50";
            cmdReload.Font = Program.FONT_MDL2_REG_9;
            cmdReload.Text = "\xE72C";
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
            cmdNavigate.MouseEnter += HandleMouseEnterTip;
            cmdNavigate.MouseLeave += HandleMouseLeaveTip;
            cmdReload.MouseEnter += HandleMouseEnterTip;
            cmdReload.MouseLeave += HandleMouseLeaveTip;
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
            if (sender == cmdNavigate)
                lblMessage.Text = "Navigate to file in explorer";
            else if (sender == cmdReload)
                lblMessage.Text = "Reload current file from disk";
            else if (sender == cmdExportFsysBlock)
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
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
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

        #region Misc Events
        private void ToggleControlEnable(bool enable)
        {
            Button[] buttons = { cmdReset, cmdEditEfirom, cmdExportFsysBlock, cmdEveryMacSearch };
            foreach (Button button in buttons)
            {
                button.Enabled = enable ? true : false;
            }

            // Overrides > For when setting 'Override valid fsys enforement' is enabled, and the Fsys region is not found.
            // I may revisit here in the future.
            if (FWParser.bytesLoadedFsys != null)
            {
                cmdFixFsysCrc.Enabled = FWParser.strRealFsysChecksum == FWParser.strFsysChecksumInBinary ? false : true;
            }
            else
            {
                cmdFixFsysCrc.Enabled = false;
                cmdExportFsysBlock.Enabled = false;
                cmdEditEfirom.Enabled = false;
            }

            cmdEveryMacSearch.Enabled = (FWParser.strSerialNumber != null);

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

        private void SetPrimaryInitialDirectory()
        {
            string path = Settings.SettingsGetString(SettingsStringType.InitialDirectory);
            if (!string.IsNullOrEmpty(path))
            {
                if (Directory.Exists(path))
                {
                    _strInitialDirectory = path;
                }
                else
                {
                    _strInitialDirectory = Program.appDirectory;
                }
            }
        }

        private void UpdateMemoryStats(object state)
        {
            lock (_lockObject)
            {
                string workingSetString = Helper.FormatSize((ulong)Program.GetWorkingSetSize());
                string privateMemoryString = Helper.FormatSize((ulong)Program.GetPrivateMemorySize());

                lblWorkingSet.Invoke((Action)(() =>
                {
                    lblWorkingSet.Text = $"{workingSetString}";
                }));

                lblPrivateMemory.Invoke((Action)(() =>
                {
                    lblPrivateMemory.Text = $"{privateMemoryString}";
                }));
            }
        }
        #endregion

        #region Firmware Parsing
        private bool GetIsValidFirmware()
        {
            var fileInfo = new FileInfo(FWParser.strLoadedBinaryFilePath);
            // Binary too small
            if (fileInfo.Length < FWParser.MIN_IMAGE_SIZE) // 1048576 bytes
            {
                METMessageBox.Show(this, "Warning", "The file is too small and was ignored.", MsgType.Warning, MsgButton.Okay);
                return false;
            }

            // Binary too large
            if (fileInfo.Length > FWParser.MAX_IMAGE_SIZE) // 33554432 bytes
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

        internal void ParseFirmwareData()
        {
            var fileInfo = new FileInfo(FWParser.strLoadedBinaryFilePath);

            ParseFileInfo(fileInfo);

            FWParser.strSerialNumber = FWParser.bytesLoadedFsys != null ? FWParser.GetSystemSerialNumber(FWParser.bytesLoadedFsys) : null;
            FWParser.strHwc = FWParser.bytesLoadedFsys != null ? FWParser.GetSystemHardwareConfig(FWParser.bytesLoadedFsys) : null;
            var task = Task.Run(() =>
            {
                FWParser.strModel = EFIUtils.GetDeviceConfigCodeAsync(FWParser.strHwc).ConfigureAwait(false).GetAwaiter().GetResult();
            });
            FWParser.strModelFallback = FWParser.GetModelIdentifier(FWParser.bytesLoadedFile);
            FWParser.strEfiVersion = FWParser.GetEfiVersion(FWParser.bytesLoadedFile);
            FWParser.strBootromVersion = FWParser.GetBootromVersion(FWParser.bytesLoadedFile);
            FWParser.strFsysChecksumInBinary = FWParser.GetFsysCrc32(FWParser.bytesLoadedFile);
            FWParser.strRealFsysChecksum = FWParser.bytesLoadedFsys != null ? EFIUtils.GetUintFsysCrc32(FWParser.bytesLoadedFsys).ToString("X8") : null;
            FWParser.strApfsCapable = FWParser.GetIsApfsCapable(FWParser.bytesLoadedFile).ToString();
            FWParser.strFitcVersion = MEParser.GetVersionData(FWParser.bytesLoadedFile, HeaderType.Fitc);
            FWParser.strMeVersion = MEParser.GetVersionData(FWParser.bytesLoadedFile, HeaderType.ManagementEngine);
            FWParser.strBoardId = FWParser.GetBoardId(FWParser.bytesLoadedFile);
            FWParser.strSon = FWParser.bytesLoadedFsys != null ? FWParser.GetSystemOrderNumber(FWParser.bytesLoadedFsys) : null;
        }

        private void ParseFileInfo(FileInfo fileInfo)
        {
            FWParser.strFilename = fileInfo.Name;
            FWParser.lLoadedFileSize = fileInfo.Length;
            FWParser.uiCrcOfLoadedFile = FileUtils.GetCrc32Digest(FWParser.bytesLoadedFile);
            FWParser.strCreationTime = fileInfo.CreationTime.ToString();
            FWParser.strModifiedTime = fileInfo.LastWriteTime.ToString();
        }

        internal void UpdateControls()
        {
            lblFilename.Text = FWParser.strFilename;
            lblFilesizeBytes.ForeColor = EFIUtils.GetIsValidBinSize((int)FWParser.lLoadedFileSize) ? Colours.clrGood : Colours.clrUnknown;
            lblFilesizeBytes.Text = FileUtils.FormatFileSize(FWParser.lLoadedFileSize);
            lblCreated.Text = FWParser.strCreationTime;
            lblModified.Text = FWParser.strModifiedTime;
            lblFileChecksum.Text = FWParser.uiCrcOfLoadedFile.ToString("X8");
            lblApfsCapable.Text = FWParser.strApfsCapable;
            lblApfsCapable.ForeColor = FWParser.strApfsCapable == "Yes" ? Colours.clrGood : Colours.clrUnknown;
            lblFitcVersion.Text = FWParser.strFitcVersion;
            lblMeVersion.Text = FWParser.strMeVersion;

            lblModel.Text = FWParser.strModel ?? FWParser.strModelFallback ?? "N/A";
            lblSerialNumber.Text = FWParser.strSerialNumber ?? "N/A";
            lblHwc.Text = FWParser.strHwc ?? "N/A";
            lblFsysCrc.Text = FWParser.strFsysChecksumInBinary != null ? $"{FWParser.strFsysChecksumInBinary}h" : "N/A";
            lblFsysCrc.ForeColor = FWParser.strFsysChecksumInBinary != null && FWParser.strRealFsysChecksum == FWParser.strFsysChecksumInBinary ? Colours.clrGood : Color.White;
            lblEfiVersion.Text = FWParser.strEfiVersion ?? "N/A";
            lblRomVersion.Text = FWParser.strBootromVersion ?? "N/A";
            lblBoardId.Text = FWParser.strBoardId ?? "N/A";
            lblSon.Text = FWParser.strSon ?? "N/A";

            ToggleControlEnable(true);
        }

        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            FWParser.strLoadedBinaryFilePath = filePath;
            FWParser.strFilenameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            FWParser.bytesLoadedFile = File.ReadAllBytes(filePath);

            var fsysData = FWParser.GetFsysRegionBytes(FWParser.bytesLoadedFile, true);
            FWParser.bytesLoadedFsys = fsysData.BlockBytes;
            FWParser.lFsysOffset = fsysData.Offset;

            if (GetIsValidFirmware())
            {
                _strInitialDirectory = Path.GetDirectoryName(filePath);
                ParseFirmwareData();
                UpdateControls();
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
                lblModel, lblSerialNumber, lblHwc, lblEfiVersion, lblRomVersion,
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

            // Reset private members
            SetPrimaryInitialDirectory();

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