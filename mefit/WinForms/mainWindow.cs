// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// mainWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using Mac_EFI_Toolkit.WinForms;
using System;
using System.Collections.Generic;
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
        private string _strInitialDirectory = METPath.CurrentDirectory;
        private static readonly object _lockObject = new object();
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

            // Attach event handlers
            Load += mainWindow_Load;
            FormClosing += mainWindow_FormClosing;
            KeyDown += mainWindow_KeyDown;
            DragEnter += mainWindow_DragEnter;
            DragDrop += mainWindow_DragDrop;
            Activated += mainWindow_Activated;
            Deactivate += mainWindow_Deactivate;
            lblVersion.MouseClick += lblVersion_MouseClick;

            // Set font for lblEfiLock
            lblEfiLock.Font = Program.FONT_MDL2_REG_9;

            InterfaceUtils.SetTableLayoutPanelHeight(tlpMain);

            // Set tip handlers for controls
            SetTipHandlers();

            // Set mouse move event handlers
            SetMouseMoveEventHandlers();

            // Set button properties (font and text)
            SetButtonProperties();

            ArrowDrawer.Draw(cmdCopyMenu, Colours.DROP_ARROW_DISABLED);
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
            if (!string.IsNullOrEmpty(Program.draggedFilePath))
            {
                OpenBinary(Program.draggedFilePath);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.draggedFilePath = string.Empty;
            }

            // Check for a new application version
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck))
            {
                CheckForNewVersion();
            }

            // Set up memory timer to retrieve private memory usage
            TimerCallback callback = new TimerCallback(GetPrivateMemoryUsage);
            Program.memoryTimer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if ALT+F4 was pressed to close the form
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first if confirmation dialogs are not disabled
                if (!Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
                {
                    e.Cancel = true;
                }

                // Show confirmation dialog
                Program.PerformMetAction(this, MetAction.Exit);
            }
        }

        private void mainWindow_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged
                if (draggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder
                    string draggedFile = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(draggedFile);

                    // If it's a file (not a folder) then allow the copy operation
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            // Disable the drop operation
            e.Effect = DragDropEffects.None;
        }

        private void mainWindow_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            // Open the binary file
            OpenBinary(draggedFilename);
        }

        private void mainWindow_Activated(object sender, EventArgs e)
        {
            SetControlForeColor(tlpTitle, Color.White);
        }

        private void mainWindow_Deactivate(object sender, EventArgs e)
        {
            SetControlForeColor(tlpTitle, Color.FromArgb(100, 100, 100));
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        cmdOpen.PerformClick();
                        break;
                    case Keys.R:
                        cmdReset.PerformClick();
                        break;
                    case Keys.C:
                        cmdCopyMenu.PerformClick();
                        break;
                    case Keys.E:
                        cmdEdit.PerformClick();
                        break;
                    case Keys.M:
                        ShowContextMenu(cmdMenu, cmsMainMenu);
                        break;
                    case Keys.S:
                        settingsToolStripMenuItem.PerformClick();
                        break;
                    case Keys.A:
                        aboutToolStripMenuItem.PerformClick();
                        break;
                    case Keys.V:
                        viewLogToolStripMenuItem.PerformClick();
                        break;
                }
            }
            else if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdNavigate.PerformClick();
                        break;
                    case Keys.R:
                        cmdReload.PerformClick();
                        break;
                    case Keys.S:
                        cmdEveryMacSearch.PerformClick();
                        break;
                    case Keys.E:
                        cmdExportFsys.PerformClick();
                        break;
                    case Keys.F:
                        cmdFixFsysCrc.PerformClick();
                        break;
                    case Keys.I:
                        cmdAppleRomInfo.PerformClick();
                        break;
                    case Keys.M:
                        cmdExportMe.PerformClick();
                        break;
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
            Control[] controls = { tlpMain, tlpTitle, lblWindowTitle, tlpMenu };
            foreach (Control control in controls)
            {
                control.MouseMove += mainWindow_MouseMove;
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Program.PerformMetAction(this, MetAction.Exit);
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

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = "UEFI/BIOS Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*"
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

            DialogResult result =
                METMessageBox.Show(this, "Reset", "This will unload the firmware and all associated data, are you sure you want to reset?",
                METMessageType.Warning, METMessageButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetAllData();
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsCopy);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (FWBase.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryBytes data is null.\r\nCannot continue.",
                    METMessageType.Warning, METMessageButtons.Okay);
                return;
            }

            bool bOpenEditor = Settings.SettingsGetBool(SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                SetHalfOpacity();
                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult result = frm.ShowDialog();
                    bOpenEditor = (result != DialogResult.No);
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

            if (FWBase.FsysStoreData.Serial == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.Serial data is null.\r\nCannot continue.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", FWBase.FsysStoreData.Serial));
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            // Check the loaded binary exists
            if (!File.Exists(FWBase.LoadedBinaryPath))
            {
                // Loaded binary not exist
                METMessageBox.Show(this, "MET", "The file on disk could not be found, it may have been moved or deleted.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            // Load bytes from loaded binary file
            byte[] fileBytes = File.ReadAllBytes(FWBase.LoadedBinaryPath);

            // Check if the binaries match in size and data
            if (BinaryUtils.ByteArraysMatch(fileBytes, FWBase.LoadedBinaryBytes))
            {
                // Loaded binaries match
                METMessageBox.Show(this, "MET", "File on disk matches file in memory, data was not refreshed.",
                    METMessageType.Information, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryPath data is null.\r\nCannot continue.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            // Navigate and highlight the file in explorer
            FileUtils.HighlightPathInExplorer(FWBase.LoadedBinaryPath);
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {
            // Fsys store was not found by the firmware parser
            if (FWBase.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
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
                    FWBase.FsysStoreData.FsysBase,
                    FWBase.FsysStoreData.FsysBytes,
                    FWBase.FsysStoreData.CRC32CalcInt
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
                    DialogResult failResult = METMessageBox.Show(this, "Error", "Fsys patching failed. Open the log?",
                        METMessageType.Error, METMessageButtons.YesNo);

                    if (failResult == DialogResult.Yes)
                    {
                        Logger.ViewLogFile(LogType.Application);
                    }

                    return;
                }

                // Ask if user wants to open the repaired file
                DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?",
                    METMessageType.Information, METMessageButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdExportFsys_Click(object sender, EventArgs e)
        {
            // Fsys store bytes were null
            if (FWBase.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            // Check the Fsys stores directory exists
            if (!Directory.Exists(METPath.FsysDirectory))
            {
                // Create the Fsys stores directory
                Status status = FileUtils.CreateDirectory(METPath.FsysDirectory);

                // Directory creation failed
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(this, "MET", "Failed to create the Fsys Stores directory.",
                        METMessageType.Error, METMessageButtons.Okay);
                }
            }

            // Set SaveFileDialog params
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = string.Concat("FSYS_STORE_", FWBase.FileInfoData.FileNameNoExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = METPath.FsysDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fsysPath = dialog.FileName;

                // Save the Fsys stores bytes to disk
                if (FileUtils.WriteAllBytesEx(fsysPath, FWBase.FsysStoreData.FsysBytes) && File.Exists(fsysPath))
                {
                    METMessageBox.Show(this, "MET", $"Fsys export successful:\r\n'{fsysPath.Replace(" ", Chars.NBSPACE)}'",
                        METMessageType.Information, METMessageButtons.Okay);
                    return;
                }

                METMessageBox.Show(this, "Error", "Fsys export failed.",
                    METMessageType.Error, METMessageButtons.Okay);
            }
        }

        private void cmdAppleRomInfo_Click(object sender, EventArgs e)
        {
            // Check the Rom Information section exists
            if (FWBase.ROMInfoSectionData.SectionExists == false)
            {
                // ROM Information section does not exist
                METMessageBox.Show(this, "Error", "ROMInfoData.SectionExists returned false.\r\nCannot continue.",
                    METMessageType.Error, METMessageButtons.Okay);
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

        private void cmdExportMe_Click(object sender, EventArgs e)
        {
            if (Descriptor.MeBase == 0 || Descriptor.MeLimit == 0)
            {
                METMessageBox.Show(this, "Error", "Management Engine base or limit not found.",
                    METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            // Check the Fsys stores directory exists
            if (!Directory.Exists(METPath.MeDirectory))
            {
                // Create the Fsys stores directory
                Status status = FileUtils.CreateDirectory(METPath.MeDirectory);

                // Directory creation failed
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(this, "Error", "Failed to create the ME region directory.",
                        METMessageType.Error, METMessageButtons.Okay);
                }
            }

            // Set SaveFileDialog params
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = string.Concat("ME_RGN_", FWBase.FileInfoData.FileNameNoExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = METPath.MeDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string mePath = dialog.FileName;

                byte[] meBytes = BinaryUtils.GetBytesBaseLength(FWBase.LoadedBinaryBytes, (int)Descriptor.MeBase, (int)Descriptor.MeSize);

                if (FileUtils.WriteAllBytesEx(mePath, meBytes) && File.Exists(mePath))
                {
                    METMessageBox.Show(this, "MET", $"ME export successful:\r\n'{mePath.Replace(" ", Chars.NBSPACE)}'",
                        METMessageType.Information, METMessageButtons.Okay);
                    return;
                }

                METMessageBox.Show(this, "Error", $"ME export failed.",
                    METMessageType.Error, METMessageButtons.Okay);
            }
        }
        #endregion

        #region Toolstrip Events
        private void openLocalFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", METPath.CurrentDirectory);
        }

        private void openBuildsDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.BuildsDirectory))
            {
                Process.Start("explorer.exe", METPath.BuildsDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The builds folder has not been created yet.",
                METMessageType.Information, METMessageButtons.Okay);
        }

        private void openFsysDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.FsysDirectory))
            {
                Process.Start("explorer.exe", METPath.FsysDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The Fsys folder has not been created yet.",
                METMessageType.Information, METMessageButtons.Okay);
        }

        private void openMeRegionDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.MeDirectory))
            {
                Process.Start("explorer.exe", METPath.MeDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The ME folder has not been created yet.",
                METMessageType.Information, METMessageButtons.Okay);
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.strLogFilePath))
            {
                Process.Start(Logger.strLogFilePath);
                return;
            }

            METMessageBox.Show(this, "File Information", "The log file has not been created yet.",
                METMessageType.Information, METMessageButtons.Okay);
        }

        private void createADebugLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(METPath.DebugLog, Debug.GenerateDebugReport(null));

            if (File.Exists(METPath.DebugLog))
                FileUtils.HighlightPathInExplorer(METPath.DebugLog);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.PerformMetAction(this, MetAction.Restart);
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

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(METUrl.Changelog);
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(METUrl.Homepage);
        }

        private void usageManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(METUrl.Manual);
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.PerformMetAction(this, MetAction.Exit);
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string size = FileUtils.FormatFileSize(FWBase.FileInfoData.FileLength);
            Clipboard.SetText($"{size} bytes");
        }

        private void crc32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{FWBase.FileInfoData.CRC32:X8}");
        }

        private void createdDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{FWBase.FileInfoData.CreationTime}");
        }

        private void modifiedDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{FWBase.FileInfoData.LastWriteTime}");
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FsysStoreData.Serial);
        }

        private void hwcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FsysStoreData.HWC);
        }

        private void fsysCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FsysStoreData.CrcString);
        }

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FsysStoreData.SON);
        }

        private void efiVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FirmwareVersion);
        }

        private void boardIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.PDRSectionData.BoardId);
        }

        private void fitVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FitVersion);
        }

        private void meVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.MeVersion);
        }
        #endregion

        #region Label Events
        private void lblVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(METUrl.LatestGithubRelease);
        }
        #endregion

        #region Picturebox Events
        private void pbxTitleLogo_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsApplication);
        }
        #endregion

        #region Update Main Window
        internal void UpdateUI()
        {
            // File information
            UpdateFileNameLabel();
            UpdateFileSizeLabel();
            UpdateFileCrc32Label();
            UpdateFileCreationDateLabel();
            UpdateFileModifiedDateLabel();

            // Firmware Data
            UpdateModelLabel();
            UpdateFirmwareSerialNumber();
            UpdateHardwareConfigLabel();
            UpdateFsysLabel();
            UpdateOrderNumberLabel();
            UpdateEfiVersionLabel();
            UpdateNvramLabel(lblVssStore, FWBase.VssStoreData, "VSS");
            UpdateNvramLabel(lblSvsStore, FWBase.SvsStoreData, "SVS");
            UpdateNvramLabel(lblNssStore, FWBase.NssStoreData, "NSS");
            UpdateEfiLockLabel();
            UpdateBoardIdLabel();
            UpdateApfsCapableLabel();
            UpdateFitVersionLabel();
            UpdateIntelMeLabel();

            // Apply DISABLED_TEXT color to N/A text labels
            ApplyNestedPanelLabelForeColor(tlpRom, Colours.DISABLED_TEXT);

            // Check which copy menu items should be enabled
            ToggleCopyMenuItemEnable();

            // Check and set control enable
            ToggleControlEnable(true);

            // Hide loading image
            pbxLoad.Image = null;
        }

        private void UpdateFileNameLabel()
        {
            lblFilename.Text = $"FILE: '{FWBase.FileInfoData.FileNameWithExt}'";
        }

        private void UpdateFileSizeLabel()
        {
            int fileSize = (int)FWBase.FileInfoData.FileLength;
            bool isValidSize = FileUtils.GetIsValidBinSize(fileSize);

            lblFileSizeBytes.Text = FileUtils.FormatFileSize(fileSize);

            if (!isValidSize)
            {
                lblFileSizeBytes.ForeColor = Colours.ERROR_RED;

                lblFileSizeBytes.Text +=
                    isValidSize
                    ? string.Empty
                    : $" ({FileUtils.GetSizeDifference(fileSize)})";
            }
        }

        private void UpdateFileCrc32Label()
        {
            lblFileCrc.Text = $"{FWBase.FileInfoData.CRC32:X8}";
        }

        private void UpdateFileCreationDateLabel()
        {
            lblFileCreatedDate.Text = FWBase.FileInfoData.CreationTime;
        }

        private void UpdateFileModifiedDateLabel()
        {
            lblFileModifiedDate.Text = FWBase.FileInfoData.LastWriteTime;
        }

        private void UpdateModelLabel()
        {
            lblModel.Text =
                $"MODEL: {MacUtils.ConvertEfiModelCode(FWBase.EFISectionData.ModelPart) ?? "N/A"}";

            // Load and append the config code asynchronously
            if (FWBase.FsysStoreData.HWC != null)
            {
                AppendConfigCodeTextAsync(FWBase.FsysStoreData.HWC);
            }
        }

        private void UpdateFirmwareSerialNumber()
        {
            lblSerialNumber.Text =
                FWBase.FsysStoreData.Serial ??
                "N/A";
        }

        private void UpdateHardwareConfigLabel()
        {
            lblHwc.Text =
                FWBase.FsysStoreData.HWC
                ?? "N/A";
        }

        private void UpdateFsysLabel()
        {
            if (FWBase.FsysStoreData.CrcString != null)
            {
                lblFsysCrc.Text = $"CRC32: {FWBase.FsysStoreData.CrcString}h";
                lblFsysCrc.ForeColor =
                    string.Equals(FWBase.FsysStoreData.CrcCalcString, FWBase.FsysStoreData.CrcString)
                    ? Colours.COMPLETE_GREEN
                    : Colours.ERROR_RED;
            }
            else
            {
                lblFsysCrc.Text = "N/A";
            }
        }

        private void UpdateOrderNumberLabel()
        {
            lblOrderNo.Text =
                FWBase.FsysStoreData.SON
                ?? "N/A";
        }

        private void UpdateEfiVersionLabel()
        {
            lblEfiVersion.Text =
                FWBase.FirmwareVersion
                ?? "N/A";
        }

        private void UpdateNvramLabel(Label label, NvramStore storeData, string text)
        {
            label.Text = text;

            Color foreColor =
                !storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty
                ? Color.White
                : storeData.PrimaryStoreBase != -1
                ? Colours.COMPLETE_GREEN
                : Colours.DISABLED_TEXT;

            label.ForeColor = foreColor;
        }

        private void UpdateEfiLockLabel()
        {
            lblEfiLock.Text = GetEfiLockStatusText(FWBase.EfiLock);
            lblEfiLock.ForeColor = GetEfiLockStatusColor(FWBase.EfiLock);
        }

        private string GetEfiLockStatusText(EfiLockStatus lockStatus)
        {
            switch (lockStatus)
            {
                case EfiLockStatus.Locked:
                    return Chars.LOCKED;
                case EfiLockStatus.Unlocked:
                    return Chars.UNLOCKED;
                case EfiLockStatus.Unknown:
                default:
                    return Chars.UNLOCKED;
            }
        }

        private Color GetEfiLockStatusColor(EfiLockStatus lockStatus)
        {
            switch (lockStatus)
            {
                case EfiLockStatus.Locked:
                    return Colours.ERROR_RED;
                case EfiLockStatus.Unlocked:
                    return Colours.COMPLETE_GREEN;
                case EfiLockStatus.Unknown:
                default:
                    return Colours.DISABLED_TEXT;
            }
        }

        private void UpdateBoardIdLabel()
        {
            lblBoardId.Text =
                FWBase.PDRSectionData.BoardId
                ?? "N/A";
        }

        private void UpdateApfsCapableLabel()
        {

            switch (FWBase.IsApfsCapable)
            {
                case ApfsCapable.Guid:
                    lblApfsCapable.Text = "YES (DXE)";
                    break;
                case ApfsCapable.Lzma:
                    lblApfsCapable.Text = "YES (LZMA DXE)";
                    break;
                case ApfsCapable.No:
                    lblApfsCapable.Text = "DRIVER NOT FOUND";
                    lblApfsCapable.ForeColor = Colours.WARNING_ORANGE;
                    break;
                case ApfsCapable.Unknown:
                    lblApfsCapable.Text = "UNKOWN";
                    lblApfsCapable.ForeColor = Colours.ERROR_RED;
                    break;
            }
        }

        private void UpdateFitVersionLabel()
        {
            lblFitVersion.Text =
                FWBase.FitVersion
                ?? "N/A";
        }

        private void UpdateIntelMeLabel()
        {
            lblMeVersion.Text =
                FWBase.MeVersion
                ?? "N/A";

            if (Descriptor.MeBase != 0)
            {
                if (!string.IsNullOrEmpty(FWBase.MeVersion))
                {
                    lblMeVersion.Text +=
                        $" ({Descriptor.MeBase:X2}h)";
                }
            }
        }
        #endregion

        #region UI Events
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
            ArrowDrawer.Draw
            (
                cmdCopyMenu,
                enable
                ? Colours.DROP_ARROW_ENABLED
                : Colours.DROP_ARROW_DISABLED
            );

            Button[] buttons =
            {
                cmdReset, cmdEdit, cmdCopyMenu, cmdNavigate, cmdReload,
                cmdFixFsysCrc, cmdExportFsys , cmdAppleRomInfo, cmdExportMe
            };

            foreach (Button button in buttons)
            {
                button.Enabled = enable;
            }

            cmdEveryMacSearch.Enabled =
                FWBase.FsysStoreData.Serial != null;

            if (FWBase.FsysStoreData.FsysBytes != null)
            {
                cmdFixFsysCrc.Enabled =
                    MacUtils.GetUintFsysCrc32(FWBase.FsysStoreData.FsysBytes).ToString("X8") == FWBase.FsysStoreData.CrcString
                    ? false
                    : true;
            }
            else
            {
                cmdFixFsysCrc.Enabled = false;
                cmdExportFsys.Enabled = false;
                cmdEdit.Enabled = false;
            }

            cmdAppleRomInfo.Enabled = FWBase.ROMInfoSectionData.SectionExists;

            cmdExportMe.Enabled =
                Descriptor.DescriptorMode &&
                Descriptor.MeBase != 0 &&
                Descriptor.MeLimit != 0;

            tlpMain.Enabled = enable;
        }

        private void ToggleCopyMenuItemEnable()
        {
            serialToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FsysStoreData.Serial);
            hwcToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FsysStoreData.HWC);
            fsysCRC32ToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FsysStoreData.CrcString);
            orderNoToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FsysStoreData.SON);
            efiVersionToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FirmwareVersion);
            boardIDToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.PDRSectionData.BoardId);
            fitVersionToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.FitVersion);
            meVersionToolStripMenuItem.Enabled = IsStringNotEmpty(FWBase.MeVersion);
        }

        private bool IsStringNotEmpty(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdMenu, Font = Program.FONT_MDL2_REG_14, Text = Chars.SHOW },
                new { Button = cmdClose, Font = Program.FONT_MDL2_REG_12, Text = Chars.EXIT_CROSS },
                new { Button = cmdNavigate, Font = Program.FONT_MDL2_REG_10, Text = Chars.FILE_EXPLORER },
                new { Button = cmdReload, Font = Program.FONT_MDL2_REG_10, Text = Chars.REFRESH },
                new { Button = cmdEveryMacSearch, Font = Program.FONT_MDL2_REG_9, Text = Chars.WEB_SEARCH },
                new { Button = cmdExportFsys, Font = Program.FONT_MDL2_REG_9, Text = Chars.SAVE },
                new { Button = cmdFixFsysCrc, Font = Program.FONT_MDL2_REG_9, Text = Chars.REPAIR },
                new { Button = cmdAppleRomInfo, Font = Program.FONT_MDL2_REG_9, Text = Chars.FORWARD },
                new { Button = cmdExportMe, Font = Program.FONT_MDL2_REG_9, Text = Chars.SAVE }
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
                cmdMenu, cmdOpen, cmdReset, cmdCopyMenu, cmdEdit, cmdNavigate,
                cmdReload, cmdEveryMacSearch, cmdFixFsysCrc, cmdExportFsys,
                cmdAppleRomInfo, cmdExportMe
            };

            Label[] labels =
            {
                lblVssStore, lblSvsStore, lblNssStore, lblEfiLock
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
                Dictionary<object, string> tooltips = new Dictionary<object, string>
                {
                    { cmdOpen, "Open a Mac UEFI/BIOS (CTRL + O)" },
                    { cmdReset, "Reset (CTRL + R)" },
                    { cmdEdit, "Firmware Editor (CTRL + E)" },
                    { cmdMenu, "Application Menu (CTRL + M)"},
                    { cmdCopyMenu, "Copy (CTRL + C)" },
                    { cmdNavigate, "Navigate to File (ALT + N)" },
                    { cmdReload, "Reload File from Disk (ALT + R)" },
                    { cmdEveryMacSearch, "Search Serial with EveryMac (ALT + S)" },
                    { cmdFixFsysCrc, "Repair Fsys CRC32 (ALT + F)" },
                    { cmdExportFsys, "Export Fsys Store (ALT + E)" },
                    { cmdAppleRomInfo, "ROM Information (ALT + I)" },
                    { cmdExportMe, "Export ME Region (ALT + M)" },
                    { lblVssStore, SetNvramStoreTip(FWBase.VssStoreData, "VSS") },
                    { lblSvsStore, SetNvramStoreTip(FWBase.SvsStoreData, "SVS") },
                    { lblNssStore, SetNvramStoreTip(FWBase.NssStoreData, "NSS") },
                    { lblEfiLock, SetEfiLockStatusTip() }
                };

                if (tooltips.ContainsKey(sender))
                {
                    lblMessage.Text = tooltips[sender];
                }
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private string SetNvramStoreTip(NvramStore storeData, string storeType)
        {
            if (!storeData.IsPrimaryStoreEmpty && !storeData.IsBackupStoreEmpty)
                return $"Data present in both {storeType} stores";
            else if (!storeData.IsPrimaryStoreEmpty && storeData.IsBackupStoreEmpty)
                return $"Data present in the primary {storeType} store";
            else if (storeData.PrimaryStoreBase != -1)
                return $"{storeType} NVRAM stores are empty (0xFF)";

            return string.Empty;
        }

        private string SetEfiLockStatusTip()
        {
            switch (FWBase.EfiLock)
            {
                case EfiLockStatus.Locked:
                    return "EFI is password locked (Authentication Code present)";
                case EfiLockStatus.Unlocked:
                    return "EFI is not password locked";
                case EfiLockStatus.Unknown:
                    return "EFI lock status is unknown";
            }

            return string.Empty;
        }

        private void GetPrivateMemoryUsage(object state)
        {
            lock (_lockObject)
            {
                using (Process currentProcess = Process.GetCurrentProcess())
                {
                    lblPrivateMemory.Invoke((Action)(() =>
                    {
                        lblPrivateMemory.Text =
                        $"{Helper.GetBytesReadableSize(currentProcess.PrivateMemorySize64)}";
                    }));
                }
            }
        }

        internal async void AppendConfigCodeTextAsync(string strHwc)
        {
            string configCode = await MacUtils.GetDeviceConfigCodeAsync(strHwc);

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
            // Check for a new version using the specified URL
            VersionResult result = await AppVersion.CheckForNewVersion(METUrl.VersionXml);

            // If a new version is available and update the UI
            if (result == VersionResult.NewVersionAvailable)
            {
                lblVersion.ForeColor = Color.Tomato;
            }
        }

        private void SetPrimaryInitialDirectory()
        {
            // Get the initial directory from settings
            string path = Settings.SettingsGetString(SettingsStringType.InitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory
            if (!string.IsNullOrEmpty(path))
            {
                _strInitialDirectory = Directory.Exists(path) ? path : METPath.CurrentDirectory;
            }
        }

        private void OpenBinary(string filePath)
        {
            // Disable window controls
            ToggleControlEnable(false);

            // If a firmware is loaded, reset all data
            if (FWBase.FirmwareLoaded)
            {
                ResetAllData();
            }

            // Check the filesize
            if (!IsValidMinMaxSize(filePath))
            {
                ResetAllData();
                return;
            }

            // Set the binary path and load the bytes
            FWBase.LoadedBinaryPath = filePath;
            FWBase.LoadedBinaryBytes = File.ReadAllBytes(filePath);

            // Process the descriptor
            Descriptor.Parse(FWBase.LoadedBinaryBytes);

            // Check if the image is what we're looking for
            if (!FWBase.IsValidImage(FWBase.LoadedBinaryBytes))
            {
                METMessageBox.Show(this, "Error", "The selected file is not a valid firmware image.",
                    METMessageType.Error, METMessageButtons.Okay);
                ResetAllData();
                return;
            }

            // Check parameters
            if (IsValidFlashHeader())
            {
                // Show loading resource
                pbxLoad.Image = Properties.Resources.loading;

                // Set the current initial directory
                _strInitialDirectory = Path.GetDirectoryName(filePath);

                // Load the firmware base in a separate thread
                Thread thr = new Thread(() => LoadFirmwareBase(filePath))
                {
                    IsBackground = true
                };
                thr.Start();

                return;
            }

            ResetAllData();
        }

        private void LoadFirmwareBase(string filePath)
        {
            // Load firmware base data from loaded binary bytes
            FWBase.LoadFirmwareBaseData(FWBase.LoadedBinaryBytes, filePath);

            // Update controls on the main UI thread using Invoke
            Invoke((MethodInvoker)UpdateUI);

            // Set firmware loaded flag to true
            FWBase.FirmwareLoaded = true;
        }

        private bool IsValidMinMaxSize(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Check if the file size is smaller than the minimum allowed size
            if (fileInfo.Length < FWBase.MIN_IMAGE_SIZE) // 1048576 bytes
            {
                // Show an error message if the file is too small
                METMessageBox.Show(this, "Error", $"The selected file does not meet the minimum size requirement of {FWBase.MIN_IMAGE_SIZE:X}h.",
                    METMessageType.Error, METMessageButtons.Okay);
                return false;
            }

            // Check if the file size is larger than the maximum allowed size
            if (fileInfo.Length > FWBase.MAX_IMAGE_SIZE) // 33554432 bytes
            {
                // Show an error message if the file is too large
                METMessageBox.Show(this, "Error", $"The selected file exceeds the maximum size limit of {FWBase.MAX_IMAGE_SIZE:X}h.",
                    METMessageType.Error, METMessageButtons.Okay);
                return false;
            }

            // The file size is within the valid range
            return true;
        }

        private bool IsValidFlashHeader()
        {
            // Check if descriptor enforcement is disabled in settings
            if (Settings.SettingsGetBool(SettingsBoolType.DisableDescriptorEnforce))
            {
                return true;
            }

            // Check if the loaded binary has a valid flash descriptor signature
            if (!Descriptor.DescriptorMode)
            {
                // Show a warning message if the binary does not have a valid flash descriptor
                METMessageBox.Show(this, "Warning", "The binary does not contain a valid flash descriptor.\r\nThis check can be disabled in settings.",
                    METMessageType.Warning, METMessageButtons.Okay);
                return false;
            }

            // The flash header is valid
            return true;
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

            // Reset descriptor values
            Descriptor.ResetValues();

            // Reset FWBase
            FWBase.ResetFirmwareBaseData();

            FWBase.FirmwareLoaded = false;
        }
        #endregion

    }
}