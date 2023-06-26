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
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class mainWindow : Form
    {

        #region Private Members
        private string _strInitialDirectory = Program.appDirectory;
        private static readonly object _lockObject = new object();
        private static bool _firmwareLoaded = false;
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
            Activated += mainWindow_Activated;
            Deactivate += mainWindow_Deactivate;

            lblEfiLock.Font = Program.FONT_MDL2_REG_9;

            SetTipHandlers();
            SetMouseMoveEventHandlers();
            SetContextMenuRenderers();
            SetButtonProperties();

            TimerCallback callback = new TimerCallback(GetPrivateMemoryUsage);
            Program.memoryTimer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            // Set version text
            lblVersion.Text = Application.ProductVersion;

            // Get and set the primary file dialog initial directory
            SetPrimaryInitialDirectory();

            // Open dragged file is the arg path is ! null or ! empty
            if (!string.IsNullOrEmpty(Program.draggedFile))
            {
                OpenBinary(Program.draggedFile);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.draggedFile = string.Empty;
            }

            // Check for a new application version
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck))
            {
                CheckForNewVersion();
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if ALT+F4 was passed
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
                    // Check if the dragged item is a file and not a folder
                    string draggedFile = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(draggedFile);
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
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

        private void mainWindow_Activated(object sender, EventArgs e)
        {
            SetControlForeColor(pnlTitle, Color.White);
        }

        private void mainWindow_Deactivate(object sender, EventArgs e)
        {
            SetControlForeColor(pnlTitle, Color.FromArgb(100, 100, 100));
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
                    cmdEdit.PerformClick();
                }
                else if (e.KeyCode == Keys.M)
                {
                    ShowContextMenu(cmdMenu, cmsMainMenu);
                }
                else if (e.KeyCode == Keys.S)
                {
                    settingsToolStripMenuItem.PerformClick();
                }
                else if (e.KeyCode == Keys.A)
                {
                    aboutToolStripMenuItem.PerformClick();
                }
                else if (e.KeyCode == Keys.V)
                {
                    viewLogToolStripMenuItem.PerformClick();
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
                else if (e.KeyCode == Keys.S)
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
                else if (e.KeyCode == Keys.I)
                {
                    cmdAppleRomInfo.PerformClick();
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
            WindowState = FormWindowState.Minimized;
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsMainMenu);
        }

        private void cmdOpenBin_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                ToggleControlEnable(false);
                ResetAllData();
                return;
            }

            DialogResult result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", METMessageType.Warning, UI.METMessageButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetAllData();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (FWBase.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryBytes data is null.\r\nCannot continue.", METMessageType.Warning, UI.METMessageButtons.Okay);
                return;
            }

            bool bOpenEditor = Settings.SettingsGetBool(SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                SetHalfOpacity();
                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult dr = frm.ShowDialog();
                    bOpenEditor = (dr != DialogResult.No);
                }
            }

            if (bOpenEditor)
            {
                SetHalfOpacity();
                using (Form frm = new editorWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    frm.ShowDialog();
                }
            }
        }

        private void cmdEveryMacSearch_Click(object sender, EventArgs e)
        {

            if (FWBase.FsysSectionData.Serial == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.Serial data is null.\r\nCannot continue.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", FWBase.FsysSectionData.Serial));
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {
            // Fsys store was not found by the firmware parser
            if (FWBase.FsysSectionData.FsysBytes == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export new binary",
                FileName = $"CRC_FIXED_{FWBase.FileInfoData.FileNameNoExt}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    // Action was cancelled
                    return;
                }

                bool buildFailed = false;

                // Make binary with patched Fsys crc
                byte[] patchedBinary = BinaryUtils.MakeFsysCrcPatchedBinary
                    (
                    FWBase.LoadedBinaryBytes,
                    FWBase.FsysSectionData.FsysOffset,
                    FWBase.FsysSectionData.FsysBytes,
                    FWBase.FsysSectionData.CRC32CalcInt
                    );

                // Check patchedBinary is not null
                if (patchedBinary == null)
                {
                    Logger.WriteToLogFile("'MakeCrcPatchedBinary' returned null data", LogType.Application);
                    buildFailed = true;
                }

                // Check binary was written without error
                if (!FileUtils.WriteAllBytesEx(dialog.FileName, patchedBinary))
                {
                    Logger.WriteToLogFile($"'WriteAllBytesEx' returned false", LogType.Application);
                    buildFailed = true;
                }

                // The build failed flag was set
                if (buildFailed)
                {
                    DialogResult failResult = METMessageBox.Show(this, "Error", "Fsys patching failed. Open the log?", METMessageType.Error, UI.METMessageButtons.YesNo);

                    if (failResult == DialogResult.Yes)
                    {
                        Logger.ViewLogFile(LogType.Application);
                    }

                    return;
                }

                // Ask if user wants to open the repaired file
                DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?", METMessageType.Information, UI.METMessageButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdExportFsysBlock_Click(object sender, EventArgs e)
        {
            // Fsys store bytes were null
            if (FWBase.FsysSectionData.FsysBytes == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            // Check the Fsys stores directory exists
            if (!Directory.Exists(Program.fsysDirectory))
            {
                // Create the Fsys stores directory
                Status status = FileUtils.CreateDirectory(Program.fsysDirectory);

                // Directory creation failed
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(this, "MET", "Failed to create the Fsys Stores directory.", METMessageType.Error, UI.METMessageButtons.Okay);
                }
            }

            // Set SaveFileDialog params
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export Fsys store",
                FileName = string.Concat("FSYS_STORE_", FWBase.FileInfoData.FileNameNoExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = Program.fsysDirectory
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the Fsys stores bytes to disk
                    File.WriteAllBytes(dialog.FileName, FWBase.FsysSectionData.FsysBytes);
                }
            }
        }

        private void cmdAppleRomInfo_Click(object sender, EventArgs e)
        {
            // Check the Rom Information section exists
            if (FWBase.ROMInfoData.SectionExists == false)
            {
                // ROM Information section does not exist
                METMessageBox.Show(this, "Error", "ROMInfoData.SectionExists returned false.\r\nCannot continue.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            // Set window half opacity
            SetHalfOpacity();

            // Open the Rom Information Window
            using (Form formWindow = new infoWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            // Check the loaded binary exists
            if (!File.Exists(FWBase.LoadedBinaryPath))
            {
                // Loaded binary not exist
                METMessageBox.Show(this, "MET", "The file on disk could not be found, it may have been moved or deleted.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            // Load bytes from loaded binary file
            byte[] fileBytes = File.ReadAllBytes(FWBase.LoadedBinaryPath);

            // Check if the binaries match in size and data
            if (BinaryUtils.ByteArraysMatch(fileBytes, FWBase.LoadedBinaryBytes))
            {
                // Loaded binaries match
                METMessageBox.Show(this, "MET", "File on disk matches file in memory, data was not refreshed.", METMessageType.Information, UI.METMessageButtons.Okay);
                return;
            }

            // File data has changed
            OpenBinary(FWBase.LoadedBinaryPath);
        }

        private void cmdNavigate_Click(object sender, EventArgs e)
        {
            // Check the loaded binary path is not null or empty
            if (string.IsNullOrEmpty(FWBase.LoadedBinaryPath))
            {
                // Binary path is null or empty
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryPath data is null.\r\nCannot continue.", METMessageType.Error, UI.METMessageButtons.Okay);
                return;
            }

            // Navigate and highlight the file in explorer
            FileUtils.HighlightPathInExplorer(FWBase.LoadedBinaryPath);
        }
        #endregion

        #region Toolstrip Events
        private void openBuildsDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.buildsDirectory))
            {
                Process.Start("explorer.exe", Program.buildsDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The builds folder has not been created yet.", METMessageType.Information, UI.METMessageButtons.Okay);
        }

        private void openFsysDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.fsysDirectory))
            {
                Process.Start("explorer.exe", Program.fsysDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The Fsys directory has not been created yet.", METMessageType.Information, UI.METMessageButtons.Okay);
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.strLogFilePath))
            {
                Process.Start(Logger.strLogFilePath);
                return;
            }

            METMessageBox.Show(this, "File Information", "The log file has not been created yet.", METMessageType.Information, UI.METMessageButtons.Okay);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();
            using (Form formWindow = new settingsWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();
            using (Form formWindow = new aboutWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
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
        #endregion

        #region Picturebox Events
        private void pbxTitleLogo_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsApplication);
        }
        #endregion

        #region UI Events
        internal void UpdateControls()
        {
            // File information
            lblFilename.Text = $"FILE: '{FWBase.FileInfoData.FileNameWithExt}'";
            int fileLength = (int)FWBase.FileInfoData.FileLength;
            bool isValidSize = FileUtils.GetIsValidBinSize(fileLength);
            lblFileSizeBytes.Text = FileUtils.FormatFileSize(fileLength);
            lblFileSizeBytes.ForeColor = isValidSize ? Colours.COMPLETE_GREEN : Colours.WARNING_ORANGE;
            lblFileSizeBytes.Text += isValidSize ? string.Empty : $" ({FileUtils.GetSizeDifference(fileLength)})";
            lblFileCreatedDate.Text = FWBase.FileInfoData.CreationTime;
            lblFileModifiedDate.Text = FWBase.FileInfoData.LastWriteTime;
            lblFileCrc.Text = $"{FWBase.FileInfoData.CRC32:X8}";

            // Firmware Data
            lblSerialNumber.Text = FWBase.FsysSectionData.Serial ?? "N/A";
            lblHwc.Text = FWBase.FsysSectionData.HWC ?? "N/A";
            if (FWBase.FsysSectionData.CrcString != null)
            {
                lblFsysCrc.Text = $"{FWBase.FsysSectionData.CrcString}h";
                lblFsysCrc.ForeColor = string.Equals(FWBase.FsysSectionData.CrcCalcString, FWBase.FsysSectionData.CrcString) ? Colours.COMPLETE_GREEN : Colours.ERROR_RED;
            }
            else
            {
                lblFsysCrc.Text = "N/A";
                lblFsysCrc.ForeColor = Color.White;
            }
            lblApfsCapable.Text = FWBase.IsApfsCapable;
            lblApfsCapable.ForeColor = FWBase.IsApfsCapable == "Yes" ? Colours.COMPLETE_GREEN : Colours.WARNING_ORANGE;
            lblEfiVersion.Text = FWBase.ROMInfoData.EfiVersion ?? "N/A";

            UpdateNvramLabel(lblVssStore, FWBase.VssStoreData, "VSS");
            UpdateNvramLabel(lblSvsStore, FWBase.SvsStoreData, "SVS");
            UpdateNvramLabel(lblNssStore, FWBase.NssStoreData, "NSS");

            switch (FWBase.EfiLock)
            {
                case EfiLockStatus.Locked:
                    lblEfiLock.Text = Chars.LOCKED;
                    lblEfiLock.ForeColor = Colours.ERROR_RED;
                    break;
                case EfiLockStatus.Unlocked:
                    lblEfiLock.Text = Chars.UNLOCKED;
                    lblEfiLock.ForeColor = Colours.COMPLETE_GREEN;
                    break;
                case EfiLockStatus.Unknown:
                    lblEfiLock.Text = Chars.UNLOCKED;
                    lblEfiLock.ForeColor = Colours.DISABLED_TEXT;
                    break;
            }

            lblFitVersion.Text = FWBase.FitVersion ?? "N/A";
            lblMeVersion.Text = FWBase.MeVersion ?? "N/A";
            lblModel.Text = $"MODEL: {FWBase.EFISectionStore.Model ?? "N/A"}";
            lblBoardId.Text = FWBase.PDRSectionData.MacBoardId ?? "N/A";
            lblOrderNo.Text = FWBase.FsysSectionData.SON ?? "N/A";

            // Load the config code asynchronously
            if (FWBase.FsysSectionData.HWC != null)
            {
                AppendConfigCodeAsync(FWBase.FsysSectionData.HWC);
            }

            ApplyNestedPanelLabelForeColor(tlpRom, Colours.DISABLED_TEXT);

            pbxLoad.Image = null;

            ToggleControlEnable(true);
        }

        void UpdateNvramLabel(Label label, NvramStore storeData, string text)
        {
            label.Text = text;

            Color foreColor = (!storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty)
                ? Colours.WARNING_ORANGE
                : (storeData.PrimaryStoreOffset != -1 ? Colours.COMPLETE_GREEN : Colours.DISABLED_TEXT);

            label.ForeColor = foreColor;
        }

        private void SetContextMenuRenderers()
        {
            ContextMenuStrip[] menus = { cmsMainMenu, cmsApplication };
            foreach (ContextMenuStrip menu in menus)
            {
                menu.Renderer = new METMenuRenderer();
            }
        }

        internal void SetHalfOpacity()
        {
            Opacity = 0.5;
        }

        private void ChildWindowClosed(object sender, EventArgs e)
        {
            Opacity = 1.0;

            if (Program.openLastBuild)
            {
                if (File.Exists(Program.lastBuildPath))
                {
                    OpenBinary(Program.lastBuildPath);
                }

                Program.openLastBuild = false;
                Program.lastBuildPath = string.Empty;
            }
        }

        private void ShowContextMenu(Control control, ContextMenuStrip menu)
        {
            Point lowerLeft = new Point(-1, control.Height + 2);
            lowerLeft = control.PointToScreen(lowerLeft);
            menu.Show(lowerLeft);
        }

        private void ToggleControlEnable(bool enable)
        {
            tlpMain.Enabled = enable;

            Button[] buttons = { cmdReset, cmdNavigate, cmdReload, cmdEdit, cmdEveryMacSearch, cmdFixFsysCrc, cmdExportFsysBlock, cmdAppleRomInfo };
            foreach (Button button in buttons)
            {
                button.Enabled = enable;
            }

            cmdEveryMacSearch.Enabled = (FWBase.FsysSectionData.Serial != null);

            if (FWBase.FsysSectionData.FsysBytes != null)
            {
                cmdFixFsysCrc.Enabled = EFIUtils.GetUintFsysCrc32(FWBase.FsysSectionData.FsysBytes).ToString("X8") == FWBase.FsysSectionData.CrcString ? false : true;
            }
            else
            {
                cmdFixFsysCrc.Enabled = false;
                cmdExportFsysBlock.Enabled = false;
                cmdEdit.Enabled = false;
            }

            cmdAppleRomInfo.Enabled = FWBase.ROMInfoData.SectionExists;
        }

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.FONT_MDL2_REG_12, Text = Chars.EXIT_CROSS },
                new { Button = cmdMenu, Font = Program.FONT_MDL2_REG_14, Text = Chars.SHOW },
                new { Button = cmdNavigate, Font = Program.FONT_MDL2_REG_10, Text = Chars.FILE_EXPLORER },
                new { Button = cmdReload, Font = Program.FONT_MDL2_REG_10, Text = Chars.REFRESH },
                new { Button = cmdEveryMacSearch, Font = Program.FONT_MDL2_REG_9, Text = Chars.WEB_SEARCH },
                new { Button = cmdExportFsysBlock, Font = Program.FONT_MDL2_REG_9, Text = Chars.SAVE },
                new { Button = cmdFixFsysCrc, Font = Program.FONT_MDL2_REG_9, Text = Chars.REPAIR },
                new { Button = cmdAppleRomInfo, Font = Program.FONT_MDL2_REG_9, Text = Chars.FORWARD }
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdOpenBin, cmdReset, cmdEdit, cmdNavigate, cmdReload,
                cmdEveryMacSearch, cmdFixFsysCrc, cmdExportFsysBlock, cmdAppleRomInfo
            };

            Label[] labels =
            {
                lblEfiLock, lblPrivateMemory, lblVssStore, lblSvsStore, lblNssStore
            };

            foreach (Button button in buttons)
            {
                button.MouseEnter += HandleMouseEnterTip;
                button.MouseLeave += HandleMouseLeaveTip;
            }

            foreach (Label label in labels)
            {
                label.MouseEnter += HandleMouseEnterTip;
                label.MouseLeave += HandleMouseLeaveTip;
            }
        }

        private void HandleMouseEnterTip(object sender, EventArgs e)
        {
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableTips))
            {
                if (sender == cmdNavigate)
                    lblMessage.Text = "Navigate to file (ALT + N)";
                else if (sender == cmdReload)
                    lblMessage.Text = "Reload file from disk (ALT + R)";
                else if (sender == cmdExportFsysBlock)
                    lblMessage.Text = "Export Fsys Store (ALT + E)";
                else if (sender == cmdFixFsysCrc)
                    lblMessage.Text = "Repair Fsys CRC32 (ALT + F)";
                else if (sender == cmdEveryMacSearch)
                    lblMessage.Text = "Search serial with EveryMac (ALT + S)";
                else if (sender == cmdOpenBin)
                    lblMessage.Text = "Open a Mac BIOS (CTRL + O)";
                else if (sender == cmdReset)
                    lblMessage.Text = "Reset (CTRL + R)";
                else if (sender == cmdEdit)
                    lblMessage.Text = "Open the editor (CTRL + E)";
                else if (sender == cmdAppleRomInfo)
                    lblMessage.Text = "Open ROM information window (ALT + I)";
                else if (sender == lblPrivateMemory)
                    lblMessage.Text = "Private memory consumption";
                else if (sender == lblVssStore)
                    lblMessage.Text = SetNvramStoreTip(FWBase.VssStoreData, "VSS");
                else if (sender == lblSvsStore)
                    lblMessage.Text = SetNvramStoreTip(FWBase.SvsStoreData, "SVS");
                else if (sender == lblNssStore)
                    lblMessage.Text = SetNvramStoreTip(FWBase.NssStoreData, "NSS");
                else if (sender == lblEfiLock)
                    SetEfiLockStatusTip();
            }
        }

        private string SetNvramStoreTip(NvramStore storeData, string storeType)
        {
            if (!storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty)
                return $"{storeType} data present in the NVRAM";
            else if (storeData.PrimaryStoreOffset != -1)
                return $"{storeType} NVRAM stores are empty (0xFF)";

            return string.Empty;
        }

        private void SetEfiLockStatusTip()
        {
            string statusText;

            switch (FWBase.EfiLock)
            {
                case EfiLockStatus.Locked:
                    statusText = "EFI is password locked (Authentication Code present)";
                    break;
                case EfiLockStatus.Unlocked:
                    statusText = "EFI is not password locked";
                    break;
                case EfiLockStatus.Unknown:
                    return;
                default:
                    return;
            }

            lblMessage.Text = statusText;
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private void GetPrivateMemoryUsage(object state)
        {
            lock (_lockObject)
            {
                using (Process currentProcess = Process.GetCurrentProcess())
                {
                    lblPrivateMemory.Invoke((Action)(() =>
                    {
                        lblPrivateMemory.Text = $"{Helper.GetBytesReadableSize(currentProcess.PrivateMemorySize64)}";
                    }));
                }
            }
        }

        internal async void AppendConfigCodeAsync(string strHwc)
        {
            string configCode = await EFIUtils.GetDeviceConfigCodeAsync(strHwc);

            if (configCode != null)
            {
                lblModel.Text += $" '{configCode}'";
            }
        }

        void ApplyNestedPanelLabelForeColor(TableLayoutPanel tableLayoutPanel, Color color)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label && label.Text == "N/A")
                {
                    label.ForeColor = color;
                }
                else if (control is TableLayoutPanel nestedTableLayoutPanel)
                {
                    ApplyNestedPanelLabelForeColor(nestedTableLayoutPanel, color);
                }
            }
        }

        private void SetControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                ctrl.ForeColor = foreColor;
            }
        }
        #endregion

        #region Misc Events

        internal async void CheckForNewVersion()
        {
            VersionCheckResult result = await METVersion.CheckForNewVersion("https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml");

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
                _strInitialDirectory = Directory.Exists(path) ? path : Program.appDirectory;
            }
        }

        //        private bool IsDebugMode()
        //        {
        //#if DEBUG
        //            return true;
        //#else
        //    return false;
        //#endif
        //        }

        private bool IsValidMinMaxSize()
        {
            FileInfo fileInfo = new FileInfo(FWBase.LoadedBinaryPath);

            // The file is too small, ignore it.
            if (fileInfo.Length < FWBase.MIN_IMAGE_SIZE) // 1048576 bytes
            {
                METMessageBox.Show(this, "Warning", "The selected file is too small and will not be loaded.", METMessageType.Warning, UI.METMessageButtons.Okay);
                return false;
            }

            // The file is too large, ignore it.
            if (fileInfo.Length > FWBase.MAX_IMAGE_SIZE) // 33554432 bytes
            {
                METMessageBox.Show(this, "Warning", "The selected file is too large and will not be loaded.", METMessageType.Warning, UI.METMessageButtons.Okay);
                return false;
            }

            return true;
        }

        private bool IsValidFlashHeader()
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableDescriptorEnforce))
            {
                return true;
            }

            if (!FWBase.GetIsValidDescriptorSignature(FWBase.LoadedBinaryBytes))
            {
                METMessageBox.Show(this, "Warning", "The binary does not contain a valid flash descriptor.\r\nThis check can be disabled in settings.", METMessageType.Warning, UI.METMessageButtons.Okay);
                return false;
            }

            return true;
        }

        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            if (_firmwareLoaded)
            {
                ResetAllData();
            }

            FWBase.LoadedBinaryBytes = File.ReadAllBytes(filePath);
            FWBase.LoadedBinaryPath = filePath;

            if (IsValidMinMaxSize() && IsValidFlashHeader())
            {
                pbxLoad.Image = Properties.Resources.loading;

                _strInitialDirectory = Path.GetDirectoryName(filePath);

                Thread thr = new Thread(() => LoadFirmwareBase(filePath))
                {
                    IsBackground = true
                };

                thr.Start();

                return;
            }

            ResetAllData();
            _firmwareLoaded = false;
        }

        private void LoadFirmwareBase(string filePath)
        {
            FWBase.LoadFirmwareBaseData(FWBase.LoadedBinaryBytes, filePath);
            Invoke((MethodInvoker)UpdateControls);
            _firmwareLoaded = true;
        }

        private void ResetAllData()
        {
            // Clear labels
            Label[] labels =
            {
                lblFilename, lblFileSizeBytes, lblFileCrc, lblFileCreatedDate, lblFileModifiedDate,
                lblModel, lblSerialNumber, lblHwc, lblFsysCrc, lblApfsCapable, lblEfiVersion, lblVssStore,
                lblSvsStore, lblNssStore, lblEfiLock, lblFitVersion, lblMeVersion, lblBoardId, lblOrderNo
            };
            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = Color.White;
            }

            // Reset label colours
            ApplyNestedPanelLabelForeColor(tlpRom, Color.White);

            // Reset initial directory
            SetPrimaryInitialDirectory();

            // Reset FWBase
            FWBase.ResetFirmwareBaseData();

            // Garbage collect
            GC.Collect();
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                if (GC.WaitForFullGCComplete() == GCNotificationStatus.Succeeded)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            _firmwareLoaded = false;
        }
        #endregion

    }
}