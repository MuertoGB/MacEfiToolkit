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

            // Set font for lblEfiLock
            lblEfiLock.Font = Program.FONT_MDL2_REG_9;

            // Set tip handlers for controls
            SetTipHandlers();

            // Set mouse move event handlers
            SetMouseMoveEventHandlers();

            // Set context menu renderers
            SetContextMenuRenderers();

            // Set button properties (font and text)
            SetButtonProperties();
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
                Program.ExitMet(this);
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
                else if (e.KeyCode == Keys.C)
                {
                    cmdCopy.PerformClick();
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
                    cmdExportFsys.PerformClick();
                }
                else if (e.KeyCode == Keys.F)
                {
                    cmdFixFsysCrc.PerformClick();
                }
                else if (e.KeyCode == Keys.I)
                {
                    cmdAppleRomInfo.PerformClick();
                }
                else if (e.KeyCode == Keys.M)
                {
                    cmdExportMe.PerformClick();
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

            DialogResult result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", METMessageType.Warning, METMessageButtons.YesNo);

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
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryBytes data is null.\r\nCannot continue.", METMessageType.Warning, METMessageButtons.Okay);
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

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsCopy);
        }

        private void cmdEveryMacSearch_Click(object sender, EventArgs e)
        {

            if (FWBase.FsysStoreData.Serial == null)
            {
                METMessageBox.Show(this, "Error", "FsysSectionData.Serial data is null.\r\nCannot continue.", METMessageType.Error, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "MET", "The file on disk could not be found, it may have been moved or deleted.", METMessageType.Error, METMessageButtons.Okay);
                return;
            }

            // Load bytes from loaded binary file
            byte[] fileBytes = File.ReadAllBytes(FWBase.LoadedBinaryPath);

            // Check if the binaries match in size and data
            if (BinaryUtils.ByteArraysMatch(fileBytes, FWBase.LoadedBinaryBytes))
            {
                // Loaded binaries match
                METMessageBox.Show(this, "MET", "File on disk matches file in memory, data was not refreshed.", METMessageType.Information, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "Error", "FWBase.LoadedBinaryPath data is null.\r\nCannot continue.", METMessageType.Error, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.", METMessageType.Error, METMessageButtons.Okay);
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
                    DialogResult failResult = METMessageBox.Show(this, "Error", "Fsys patching failed. Open the log?", METMessageType.Error, METMessageButtons.YesNo);

                    if (failResult == DialogResult.Yes)
                    {
                        Logger.ViewLogFile(LogType.Application);
                    }

                    return;
                }

                // Ask if user wants to open the repaired file
                DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?", METMessageType.Information, METMessageButtons.YesNo);

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
                METMessageBox.Show(this, "Error", "FsysSectionData.FsysBytes data is null.\r\nCannot continue.", METMessageType.Error, METMessageButtons.Okay);
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
                    METMessageBox.Show(this, "MET", "Failed to create the Fsys Stores directory.", METMessageType.Error, METMessageButtons.Okay);
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
                    METMessageBox.Show(this, "MET", $"Fsys export successful:\r\n'{fsysPath.Replace(" ", Chars.NBSPACE)}'", METMessageType.Information, METMessageButtons.Okay);
                    return;
                }

                METMessageBox.Show(this, "Error", "Fsys export failed.", METMessageType.Error, METMessageButtons.Okay);
            }
        }

        private void cmdAppleRomInfo_Click(object sender, EventArgs e)
        {
            // Check the Rom Information section exists
            if (FWBase.ROMInfoSectionData.SectionExists == false)
            {
                // ROM Information section does not exist
                METMessageBox.Show(this, "Error", "ROMInfoData.SectionExists returned false.\r\nCannot continue.", METMessageType.Error, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "Error", "Management Engine base or limit not found.", METMessageType.Error, METMessageButtons.Okay);
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
                    METMessageBox.Show(this, "Error", "Failed to create the ME region directory.", METMessageType.Error, METMessageButtons.Okay);
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
                    METMessageBox.Show(this, "MET", $"ME export successful:\r\n'{mePath.Replace(" ", Chars.NBSPACE)}'", METMessageType.Information, METMessageButtons.Okay);
                    return;
                }

                METMessageBox.Show(this, "Error", $"ME export failed.", METMessageType.Error, METMessageButtons.Okay);
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

            METMessageBox.Show(this, "MET", "The builds folder has not been created yet.", METMessageType.Information, METMessageButtons.Okay);
        }

        private void openFsysDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.FsysDirectory))
            {
                Process.Start("explorer.exe", METPath.FsysDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The Fsys folder has not been created yet.", METMessageType.Information, METMessageButtons.Okay);
        }

        private void openMeRegionDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.MeDirectory))
            {
                Process.Start("explorer.exe", METPath.MeDirectory);
                return;
            }

            METMessageBox.Show(this, "MET", "The ME folder has not been created yet.", METMessageType.Information, METMessageButtons.Okay);
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.strLogFilePath))
            {
                Process.Start(Logger.strLogFilePath);
                return;
            }

            METMessageBox.Show(this, "File Information", "The log file has not been created yet.", METMessageType.Information, METMessageButtons.Okay);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ExitMet(this);
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

        private void efiVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.ROMInfoSectionData.EfiVersion);
        }

        private void fitVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FitVersion);
        }

        private void meVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.MeVersion);
        }

        private void boardIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.PDRSectionData.MacBoardId);
        }

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(FWBase.FsysStoreData.SON);
        }
        #endregion

        #region Label Events
        private void lblVersion_Click(object sender, EventArgs e)
        {
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

        #region UI Events
        internal void UpdateControls()
        {
            // File information
            UpdateFileInfoLabels();

            // Firmware Data
            UpdateFirmwareDataLabels();

            // EFI Lock
            UpdateEfiLockStatus();

            // Apply DISABLED_TEXT color to N/A text labels
            ApplyNestedPanelLabelForeColor(tlpRom, Colours.DISABLED_TEXT);

            // Hide loading image
            pbxLoad.Image = null;

            // Check which copy menu items should be enabled
            ToggleCopyMenuItemEnable();

            // Check and set control enable
            ToggleControlEnable(true);
        }

        private void UpdateFileInfoLabels()
        {
            lblFilename.Text = $"FILE: '{FWBase.FileInfoData.FileNameWithExt}'";
            int fileLength = (int)FWBase.FileInfoData.FileLength;
            bool isValidSize = FileUtils.GetIsValidBinSize(fileLength);
            lblFileSizeBytes.Text = FileUtils.FormatFileSize(fileLength);
            lblFileSizeBytes.ForeColor = isValidSize ? Colours.COMPLETE_GREEN : Colours.WARNING_ORANGE;
            lblFileSizeBytes.Text += isValidSize ? string.Empty : $" ({FileUtils.GetSizeDifference(fileLength)})";
            lblFileCreatedDate.Text = FWBase.FileInfoData.CreationTime;
            lblFileModifiedDate.Text = FWBase.FileInfoData.LastWriteTime;
            lblFileCrc.Text = $"{FWBase.FileInfoData.CRC32:X8}";
        }

        private void UpdateFirmwareDataLabels()
        {
            lblSerialNumber.Text = FWBase.FsysStoreData.Serial ?? "N/A";
            lblHwc.Text = FWBase.FsysStoreData.HWC ?? "N/A";

            if (FWBase.FsysStoreData.CrcString != null)
            {
                lblFsysCrc.Text = $"{FWBase.FsysStoreData.CrcString}h";
                lblFsysCrc.ForeColor = string.Equals(FWBase.FsysStoreData.CrcCalcString, FWBase.FsysStoreData.CrcString) ? Colours.COMPLETE_GREEN : Colours.ERROR_RED;
            }
            else
            {
                lblFsysCrc.Text = "N/A";
                lblFsysCrc.ForeColor = Color.White;
            }

            lblApfsCapable.Text = FWBase.IsApfsCapable;
            lblApfsCapable.ForeColor = FWBase.IsApfsCapable == "Yes" ? Colours.COMPLETE_GREEN : Colours.WARNING_ORANGE;
            lblEfiVersion.Text = FWBase.ROMInfoSectionData.EfiVersion ?? "N/A";

            UpdateNvramLabel(lblVssStore, FWBase.VssStoreData, "VSS");
            UpdateNvramLabel(lblSvsStore, FWBase.SvsStoreData, "SVS");
            UpdateNvramLabel(lblNssStore, FWBase.NssStoreData, "NSS");

            lblFitVersion.Text = FWBase.FitVersion ?? "N/A";
            lblMeVersion.Text = FWBase.MeVersion ?? "N/A";
            lblModel.Text = $"MODEL: {EFIUtils.ConvertEfiModelCode(FWBase.EFISectionData.Model) ?? "N/A"}";
            lblBoardId.Text = FWBase.PDRSectionData.MacBoardId ?? "N/A";
            lblOrderNo.Text = FWBase.FsysStoreData.SON ?? "N/A";

            // Load the config code asynchronously
            if (FWBase.FsysStoreData.HWC != null)
            {
                AppendConfigCodeAsync(FWBase.FsysStoreData.HWC);
            }
        }

        private void UpdateNvramLabel(Label label, NvramStore storeData, string text)
        {
            label.Text = text;

            Color foreColor = (!storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty)
                ? Colours.WARNING_ORANGE
                : (storeData.PrimaryStoreBase != -1 ? Colours.COMPLETE_GREEN : Colours.DISABLED_TEXT);

            label.ForeColor = foreColor;
        }

        private void UpdateEfiLockStatus()
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

        private void SetContextMenuRenderers()
        {
            ContextMenuStrip[] menus = { cmsMainMenu, cmsApplication, cmsCopy };
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
            Button[] buttons = { cmdReset, cmdEdit, cmdCopy, cmdNavigate, cmdReload,
                cmdFixFsysCrc, cmdExportFsys , cmdAppleRomInfo, cmdExportMe};
            foreach (Button button in buttons)
            {
                button.Enabled = enable;
            }

            cmdEveryMacSearch.Enabled = (FWBase.FsysStoreData.Serial != null);

            if (FWBase.FsysStoreData.FsysBytes != null)
            {
                cmdFixFsysCrc.Enabled = EFIUtils.GetUintFsysCrc32(FWBase.FsysStoreData.FsysBytes).ToString("X8") == FWBase.FsysStoreData.CrcString ? false : true;
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
            serialToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.FsysStoreData.Serial) ? false : true;

            hwcToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.FsysStoreData.HWC) ? false : true;

            fsysCRC32ToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.FsysStoreData.CrcString) ? false : true;

            efiVersionToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.ROMInfoSectionData.EfiVersion) ? false : true;

            fitVersionToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.FitVersion) ? false : true;

            meVersionToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.MeVersion) ? false : true;

            boardIDToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.PDRSectionData.MacBoardId) ? false : true;

            orderNoToolStripMenuItem.Enabled =
                string.IsNullOrEmpty(FWBase.FsysStoreData.SON) ? false : true;
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
                cmdOpenBin, cmdReset, cmdCopy, cmdEdit, cmdNavigate, cmdReload,
                cmdEveryMacSearch, cmdFixFsysCrc, cmdExportFsys, cmdAppleRomInfo,
                cmdExportMe
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
                if (sender == cmdOpenBin)
                    lblMessage.Text = "Open a Mac UEFI/BIOS (CTRL + O)";
                else if (sender == cmdReset)
                    lblMessage.Text = "Reset (CTRL + R)";
                else if (sender == cmdEdit)
                    lblMessage.Text = "Open the Firmware Editor (CTRL + E)";
                else if (sender == cmdCopy)
                    lblMessage.Text = "Open the Copy Menu (CTRL + C)";
                if (sender == cmdNavigate)
                    lblMessage.Text = "Navigate to File (ALT + N)";
                else if (sender == cmdReload)
                    lblMessage.Text = "Reload File from Disk (ALT + R)";
                else if (sender == cmdEveryMacSearch)
                    lblMessage.Text = "Search Serial with EveryMac (ALT + S)";
                else if (sender == cmdFixFsysCrc)
                    lblMessage.Text = "Repair Fsys CRC32 (ALT + F)";
                else if (sender == cmdExportFsys)
                    lblMessage.Text = "Export Fsys Store (ALT + E)";
                else if (sender == cmdAppleRomInfo)
                    lblMessage.Text = "Open the ROM Information Window (ALT + I)";
                else if (sender == cmdExportMe)
                    lblMessage.Text = "Export ME Region (ALT + M)";
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

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private string SetNvramStoreTip(NvramStore storeData, string storeType)
        {
            if (!storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty)
                return $"{storeType} data present in the NVRAM";
            else if (storeData.PrimaryStoreBase != -1)
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
            // Check for a new version using the specified URL
            VersionResult result = await AppVersion.CheckForNewVersion(METUrl.VersionXml);

            // If a new version is available and update the UI
            if (result == VersionResult.NewVersionAvailable)
            {
                lblVersion.ForeColor = Color.Tomato;
                lblVersion.Cursor = Cursors.Hand;
                lblVersion.Click += lblVersion_Click;
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

            // Set the binary path and load the bytes
            FWBase.LoadedBinaryPath = filePath;
            FWBase.LoadedBinaryBytes = File.ReadAllBytes(filePath);

            // Check the filesize
            if (!IsValidMinMaxSize())
            {
                ResetAllData();
                return;
            }

            // Process the descriptor
            Descriptor.Parse(FWBase.LoadedBinaryBytes);

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
            Invoke((MethodInvoker)UpdateControls);

            // Set firmware loaded flag to true
            FWBase.FirmwareLoaded = true;
        }

        private bool IsValidMinMaxSize()
        {
            FileInfo fileInfo = new FileInfo(FWBase.LoadedBinaryPath);

            // Check if the file size is smaller than the minimum allowed size
            if (fileInfo.Length < FWBase.MIN_IMAGE_SIZE) // 1048576 bytes
            {
                // Show a warning message if the file is too small
                METMessageBox.Show(this, "Warning", "The selected file is too small and will not be loaded.", METMessageType.Warning, METMessageButtons.Okay);
                return false;
            }

            // Check if the file size is larger than the maximum allowed size
            if (fileInfo.Length > FWBase.MAX_IMAGE_SIZE) // 33554432 bytes
            {
                // Show a warning message if the file is too large
                METMessageBox.Show(this, "Warning", "The selected file is too large and will not be loaded.", METMessageType.Warning, METMessageButtons.Okay);
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
                METMessageBox.Show(this, "Warning", "The binary does not contain a valid flash descriptor.\r\nThis check can be disabled in settings.", METMessageType.Warning, METMessageButtons.Okay);
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