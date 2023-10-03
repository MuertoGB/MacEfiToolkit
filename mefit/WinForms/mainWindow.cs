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

        #region Private Enums
        private enum MenuPosition
        {
            TopRight,
            BottomLeft
        }
        #endregion

        #region Private Members
        private string _strInitialDirectory = METPath.CurrentDirectory;
        private string _configCode = string.Empty;
        private static readonly object _lockObject = new object();
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.Style |= Program.WS_MINIMIZEBOX;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

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

            // Set tip handlers for controls
            SetTipHandlers();

            // Set mouse move event handlers
            SetMouseMoveEventHandlers();

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
                CheckForNewVersion();

            // Set up memory timer to retrieve private memory usage
            TimerCallback callback = new TimerCallback(GetPrivateMemoryUsage);

            Program.memoryTimer = new System.Threading.Timer(
                callback,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if ALT+F4 was pressed to close the form
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first if confirmation dialogs are not disabled
                if (!Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
                    e.Cancel = true;

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

        private void tlpVersionLabel_Click(object sender, EventArgs e)
        {
            ShowContextMenuAtCursor(sender, e, cmsApplication, false);
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        Process.Start(METUrl.LatestGithubRelease);
                        break;
                    case Keys.O:
                        cmdOpen.PerformClick();
                        break;
                    case Keys.R:
                        cmdReset.PerformClick();
                        break;
                    case Keys.P:
                        cmdPatch.PerformClick();
                        break;
                    case Keys.C:
                        cmdCopyMenu.PerformClick();
                        break;
                    case Keys.M:
                        ShowContextMenuAtControlPoint(
                            cmdMore,
                            cmsOverflow,
                            MenuPosition.BottomLeft);
                        break;
                    case Keys.S:
                        cmdSettings.PerformClick();
                        break;
                    case Keys.A:
                        cmdAbout.PerformClick();
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
                    case Keys.B:
                        cmdBackupToZip.PerformClick();
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
                    case Keys.L:
                        cmdInvalidateEfiLock.PerformClick();
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
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }

        private void SetMouseMoveEventHandlers()
        {
            Control[] controls = {
                tlpMain,
                tlpTitle,
                lblWindowTitle,
                tlpVersionLabel,
                tlpMenu };

            foreach (Control control in controls)
            {
                control.MouseMove += mainWindow_MouseMove;
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Program.PerformMetAction(
                this,
                MetAction.Exit);
        }

        private void cmdMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void cmdMore_Click(object sender, EventArgs e)
        {
            ShowContextMenuAtControlPoint(
                sender,
                cmsOverflow,
                MenuPosition.BottomLeft);
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
                    OpenBinary(dialog.FileName);
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
                METMessageBox.Show(
                    this,
                    "Reset",
                    "This will unload the firmware and all associated data, are you sure you want to reset?",
                    METMessageType.Warning,
                    METMessageButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetAllData();
            }
        }

        private void cmdPatch_Click(object sender, EventArgs e)
        {
            if (AppleEFI.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "FWBase.LoadedBinaryBytes data is null.\r\nCannot continue.",
                    METMessageType.Warning,
                    METMessageButtons.Okay);

                return;
            }

            bool bOpenEditor =
                Settings.SettingsGetBool
                    (SettingsBoolType.AcceptedEditingTerms);

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

                using (Form frm = new patcherWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    frm.ShowDialog();
                }
            }
        }

        private void cmdCopyMenu_Click(object sender, EventArgs e)
        {
            ShowContextMenuAtControlPoint(
                sender,
                cmsClipboard,
                MenuPosition.BottomLeft);
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();

            using (Form formWindow = new settingsWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();

            using (Form formWindow = new aboutWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void cmdNavigate_Click(object sender, EventArgs e)
        {
            // Check the loaded binary path is not null or empty
            if (string.IsNullOrEmpty(AppleEFI.LoadedBinaryPath))
            {
                // Binary path is null or empty
                METMessageBox.Show(
                    this,
                    "Error",
                    "FWBase.LoadedBinaryPath data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // Navigate and highlight the file in explorer
            FileUtils.HighlightPathInExplorer(
                AppleEFI.LoadedBinaryPath);
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            // Check the loaded binary exists
            if (!File.Exists(AppleEFI.LoadedBinaryPath))
            {
                // Loaded binary not exist
                METMessageBox.Show(
                    this,
                    "MET",
                    "The file on disk could not be found, it may have been moved or deleted.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file
            byte[] fileBytes =
                File.ReadAllBytes(
                    AppleEFI.LoadedBinaryPath);

            // Check if the binaries match in size and data
            if (BinaryUtils.ByteArraysMatch(fileBytes, AppleEFI.LoadedBinaryBytes))
            {
                // Loaded binaries match
                METMessageBox.Show(
                    this,
                    "MET",
                    "File on disk matches file in memory, data was not refreshed.",
                    METMessageType.Information,
                    METMessageButtons.Okay);

                return;
            }

            // File data has changed
            OpenBinary(AppleEFI.LoadedBinaryPath);
        }

        private void cmdBackupToZip_Click(object sender, EventArgs e)
        {
            if (AppleEFI.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "FWBase.LoadedBinaryBytes data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            if (!Directory.Exists(METPath.BackupsDirectory))
                Directory.CreateDirectory(
                    METPath.BackupsDirectory);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = METPath.BackupsDirectory;
                sfd.Filter = "Zip files (*.zip)|*.zip";
                sfd.FileName = $"{AppleEFI.FileInfoData.FileNameNoExt}_backup";
                sfd.OverwritePrompt = true;

                // Action was cancelled
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string backupPath = sfd.FileName;

                FileUtils.BackupFileToZip(
                    AppleEFI.LoadedBinaryBytes,
                    AppleEFI.FileInfoData.FileNameWithExt,
                    backupPath);

                if (File.Exists(backupPath))
                {
                    ShowExplorerNavigationPrompt(
                        "Backup archive created successfully.",
                        backupPath);

                    return;
                }

                METMessageBox.Show(
                    this,
                    "Error",
                    "The file could not be backed up.",
                     METMessageType.Error,
                     METMessageButtons.Okay);
            }
        }

        private void cmdEveryMacSearch_Click(object sender, EventArgs e)
        {

            if (AppleEFI.FsysStoreData.Serial == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "FsysSectionData.Serial data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            Process.Start(
                $"https://everymac.com/ultimate-mac-lookup/?search_keywords={AppleEFI.FsysStoreData.Serial}");
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {
            Button control = (Button)sender;

            // Fsys store was not found by the firmware parser
            if (AppleEFI.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "FsysSectionData.FsysBytes data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = $"CRC_FIXED_{AppleEFI.FileInfoData.FileNameNoExt}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                bool buildFailed = false;

                // Make binary with patched Fsys crc
                byte[] patchedBinary =
                    BinaryUtils.MakeFsysCrcPatchedBinary(
                        AppleEFI.LoadedBinaryBytes,
                        AppleEFI.FsysStoreData.FsysBase,
                        AppleEFI.FsysStoreData.FsysBytes,
                        AppleEFI.FsysStoreData.CRC32CalcInt);

                // Check patchedBinary is not null
                if (patchedBinary == null)
                {
                    Logger.WriteToLogFile(
                        $"[{control.Name}] 'MakeCrcPatchedBinary' returned null data",
                        LogType.Application);

                    buildFailed = true;
                }

                // Check binary was written without error
                if (!FileUtils.WriteAllBytesEx(dialog.FileName, patchedBinary))
                {
                    Logger.WriteToLogFile(
                        $"[{control.Name}] 'WriteAllBytesEx' returned false",
                        LogType.Application);

                    buildFailed = true;
                }

                // The build failed flag was set
                if (buildFailed)
                {
                    DialogResult failResult =
                        METMessageBox.Show(
                            this,
                            "Error",
                            "Fsys patching failed. Open the log?",
                            METMessageType.Error,
                            METMessageButtons.YesNo);

                    if (failResult == DialogResult.Yes)
                        Logger.ViewLogFile(
                            LogType.Application);

                    return;
                }

                // Ask if user wants to open the repaired file
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        "File Saved",
                        "Fsys checksum repaired. Would you like to load the new file?",
                        METMessageType.Information,
                        METMessageButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(dialog.FileName);
            }
        }

        private void cmdExportFsys_Click(object sender, EventArgs e)
        {
            // Fsys store bytes were null
            if (AppleEFI.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "FsysSectionData.FsysBytes data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // Check the Fsys stores directory exists
            if (!Directory.Exists(METPath.FsysDirectory))
            {
                // Create the Fsys stores directory
                Status status =
                    FileUtils.CreateDirectory(
                        METPath.FsysDirectory);

                // Directory creation failed
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this,
                        "MET",
                        "Failed to create the Fsys Stores directory.",
                        METMessageType.Error,
                        METMessageButtons.Okay);
                }
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"FSYS_{AppleEFI.FsysStoreData.Serial}_{AppleEFI.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.FsysDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string fsysPath = dialog.FileName;

                // Save the Fsys stores bytes to disk
                if (FileUtils.WriteAllBytesEx(
                    fsysPath,
                    AppleEFI.FsysStoreData.FsysBytes) && File.Exists(fsysPath))
                {
                    ShowExplorerNavigationPrompt(
                        "Fsys Store export successful.",
                        fsysPath);

                    return;
                }

                METMessageBox.Show(
                    this,
                    "Error",
                    "Fsys export failed.",
                    METMessageType.Error,
                    METMessageButtons.Okay);
            }
        }

        private void cmdAppleRomInfo_Click(object sender, EventArgs e)
        {
            // Check the Rom Information section exists
            if (AppleEFI.AppleRomInfoSectionData.SectionExists == false)
            {
                // ROM Information section does not exist
                METMessageBox.Show(
                    this,
                    "Error",
                    "ROMInfoData.SectionExists returned false.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

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

        private void cmdInvalidateEfiLock_Click(object sender, EventArgs e)
        {
            Button control = (Button)sender;

            // SVS primary store bytes were null
            if (AppleEFI.SvsStoreData.PrimaryStoreBytes == null)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "SvsStoreData.PrimaryStoreBytes data is null.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // SVS primary store base was not set
            if (AppleEFI.SvsStoreData.PrimaryStoreBase == -1)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "SvsStoreData.PrimaryStoreBase base not found.\r\nCannot continue.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // Check editing terms have been accepted
            bool allowOperation =
                Settings.SettingsGetBool(
                    SettingsBoolType.AcceptedEditingTerms);

            // Allow user to accept editing terms
            if (!allowOperation)
            {
                SetHalfOpacity();

                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult result = frm.ShowDialog();
                    allowOperation = (result != DialogResult.No);
                }
            }

            // If terms were rejected then disallow operation
            if (!allowOperation)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = $"UNLOCKED_{AppleEFI.FileInfoData.FileNameNoExt}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                bool buildFailed = false;

                // Clone the loaded binary
                byte[] patchedBinary = AppleEFI.LoadedBinaryBytes;

                // Create empty stores
                byte[] unlockedPrimaryStore = null;
                byte[] unlockedBackupStore = null;

                // Create a patched primary store
                unlockedPrimaryStore =
                    BinaryUtils.PatchSvsStoreMac(
                        AppleEFI.SvsStoreData.PrimaryStoreBytes,
                        AppleEFI.EfiPrimaryLockData.LockCrcBase);

                // Write patched primary store to the cloned binary
                BinaryUtils.OverwriteBytesAtBase(
                    patchedBinary,
                    AppleEFI.SvsStoreData.PrimaryStoreBase,
                    unlockedPrimaryStore);

                // We should probably patch any Message Authentication Code in the backup SVS store as well
                if (AppleEFI.EfiBackupLockData.LockCrcBase != -1)
                {
                    // A MAC CRC base was found in the backup store so we need to patch it
                    unlockedBackupStore =
                        BinaryUtils.PatchSvsStoreMac(
                            AppleEFI.SvsStoreData.BackupStoreBytes,
                            AppleEFI.EfiBackupLockData.LockCrcBase);

                    // Write patched backup store to the cloned binary
                    BinaryUtils.OverwriteBytesAtBase(
                        patchedBinary,
                        AppleEFI.SvsStoreData.BackupStoreBase,
                        unlockedBackupStore);
                }

                // Load SVS NVRAM stores from the patched binary
                NvramStore svsStore =
                    AppleEFI.GetNvramStoreData(
                        patchedBinary,
                        NvramStoreType.SVS);

                // Check patched primary store matches the patched buffer
                if (!BinaryUtils.ByteArraysMatch(svsStore.PrimaryStoreBytes, unlockedPrimaryStore))
                {
                    Logger.WriteToLogFile(
                        $"[{control.Name}] Patched primary store does not match buffer",
                        LogType.Application);

                    buildFailed = true;
                }

                // Check patched backup store matches the patched buffer (if backup store is ! null)
                if (unlockedBackupStore != null)
                {
                    if (!BinaryUtils.ByteArraysMatch(svsStore.BackupStoreBytes, unlockedBackupStore))
                    {
                        Logger.WriteToLogFile(
                            $"[{control.Name}] Patched backup store does not match buffer",
                            LogType.Application);

                        buildFailed = true;
                    }
                }

                // Check binary was written without error
                if (!FileUtils.WriteAllBytesEx(dialog.FileName, patchedBinary))
                {
                    Logger.WriteToLogFile(
                        $"[{control.Name}] 'WriteAllBytesEx' returned false",
                        LogType.Application);

                    buildFailed = true;
                }

                // The build failed flag was set
                if (buildFailed)
                {
                    DialogResult failResult =
                        METMessageBox.Show(
                            this,
                            "Error",
                            "Invalidating EFI Lock failed. Open the log?",
                            METMessageType.Error,
                            METMessageButtons.YesNo);

                    if (failResult == DialogResult.Yes)
                        Logger.ViewLogFile(
                            LogType.Application);

                    return;
                }

                // Ask if user wants to open the patched file
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        "File Saved",
                        "Unlock successful. Would you like to load the new file?",
                        METMessageType.Information,
                        METMessageButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(dialog.FileName);
            }
        }

        private void cmdExportMe_Click(object sender, EventArgs e)
        {
            if (IntelFD.ME_REGION_BASE == 0 || IntelFD.ME_REGION_LIMIT == 0)
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "Management Engine base or limit not found.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return;
            }

            // Check the Fsys stores directory exists
            if (!Directory.Exists(METPath.MeDirectory))
            {
                // Create the Fsys stores directory
                Status status =
                    FileUtils.CreateDirectory(
                        METPath.MeDirectory);

                // Directory creation failed
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this,
                        "Error",
                        "Failed to create the ME region directory.",
                        METMessageType.Error,
                        METMessageButtons.Okay);
                }
            }

            // Set SaveFileDialog params
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"ME_REGION_{AppleEFI.FsysStoreData.Serial}_{AppleEFI.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.MeDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string mePath = dialog.FileName;

                byte[] meBytes =
                    BinaryUtils.GetBytesBaseLength(
                        AppleEFI.LoadedBinaryBytes,
                        (int)IntelFD.ME_REGION_BASE,
                        (int)IntelFD.ME_REGION_SIZE);

                if (FileUtils.WriteAllBytesEx(mePath, meBytes) && File.Exists(mePath))
                {
                    ShowExplorerNavigationPrompt(
                        "Intel ME export successful.",
                        mePath);

                    return;
                }

                METMessageBox.Show(
                    this,
                    "Error",
                    "ME export failed.",
                    METMessageType.Error,
                    METMessageButtons.Okay);
            }
        }
        #endregion

        #region Toolstrip Events
        private void openLocalFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                "explorer.exe",
                METPath.CurrentDirectory);
        }

        private void backupsDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.BackupsDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.BackupsDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                "MET",
                "The backups folder has not been created yet.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }

        private void openBuildsDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.BuildsDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.BuildsDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                "MET",
                "The builds folder has not been created yet.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }

        private void openFsysDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.FsysDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.FsysDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                "MET",
                "The Fsys folder has not been created yet.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }

        private void openMeRegionDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.MeDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.MeDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                "MET",
                "The ME folder has not been created yet.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.strLogFilePath))
            {
                Process.Start(
                    Logger.strLogFilePath);

                return;
            }

            METMessageBox.Show(
                this,
                "File Information",
                "The log file has not been created yet.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }

        private void createADebugLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(
                METPath.DebugLog,
                Debug.GenerateDebugReport(null));

            if (File.Exists(METPath.DebugLog))
                ShowExplorerNavigationPrompt(
                    "Debug log created successfully.",
                    METPath.DebugLog);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.PerformMetAction(
                this,
                MetAction.Restart);
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                METUrl.Changelog);
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                METUrl.Homepage);
        }

        private void usageManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
                METUrl.Manual);
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
            Program.PerformMetAction(
                this,
                MetAction.Exit);
        }

        // File Clipboard Menu
        private void filenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FileInfoData.FileNameWithExt);
        }

        private void sizeBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string size =
                FileUtils.FormatFileSize(
                    AppleEFI.FileInfoData.FileLength);

            SetClipboardText($"{size} bytes");
        }

        private void sizeHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                $"{AppleEFI.FileInfoData.FileLength:X}h");
        }

        private void crc32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                $"{AppleEFI.FileInfoData.CRC32:X8}");
        }

        private void createdDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FileInfoData.CreationTime);
        }

        private void modifiedDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FileInfoData.LastWriteTime);
        }

        // Firmware Clipboard Menu
        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                MacUtils.ConvertEfiModelCode(
                    AppleEFI.EfiBiosIdSectionData.ModelPart));
        }

        private void configCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                _configCode);
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FsysStoreData.Serial);
        }

        private void hwcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FsysStoreData.HWC);
        }

        private void fsysCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FsysStoreData.CrcString);
        }

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FsysStoreData.SON);
        }

        private void efiVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FirmwareVersion);
        }

        private void boardIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.PdrSectionData.BoardId);
        }

        private void fitVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.FitVersion);
        }

        private void meVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                AppleEFI.MeVersion);
        }

        private void pdrBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                $"{IntelFD.PDR_REGION_BASE:X}h ({IntelFD.PDR_REGION_BASE} decimal)");
        }

        private void meBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                $"{IntelFD.ME_REGION_BASE:X}h ({IntelFD.ME_REGION_BASE} decimal)");
        }

        private void biosBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboardText(
                $"{IntelFD.BIOS_REGION_BASE:X}h ({IntelFD.BIOS_REGION_BASE} decimal)");
        }
        #endregion

        #region Label Events
        private void lblWindowTitle_Click(object sender, EventArgs e)
        {
            ShowContextMenuAtCursor(
                sender,
                e,
                cmsApplication,
                false);
        }

        private void lblVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(
                    METUrl.LatestGithubRelease);
        }
        #endregion

        #region Picturebox Events
        private void pbxTitleLogo_Click(object sender, EventArgs e)
        {
            ShowContextMenuAtControlPoint(
                sender,
                cmsApplication,
                MenuPosition.BottomLeft);
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

            UpdateFsysLabel();

            UpdateFirmwareSerialNumber();

            UpdateHardwareConfigLabel();

            UpdateOrderNumberLabel();

            UpdateEfiVersionLabel();

            UpdateNvramLabel(
                lblVssStore,
                AppleEFI.VssStoreData,
                "VSS");

            UpdateNvramLabel(
                lblSvsStore,
                AppleEFI.SvsStoreData,
                "SVS");

            UpdateNvramLabel(
                lblNssStore,
                AppleEFI.NssStoreData,
                "NSS");

            UpdateEfiLockLabel();

            UpdateBoardIdLabel();

            UpdateApfsCapableLabel();

            UpdateIntelMeLabel();

            // Apply DISABLED_TEXT color to N/A text labels
            ApplyNestedPanelLabelForeColor(
                tlpRom,
                Colours.DISABLED_TEXT);

            // Check which copy menu items should be enabled
            ToggleCopyMenuItemEnable();

            // Check and set control enable
            ToggleControlEnable(true);

            // Hide loading image
            pbxLoad.Image = null;
        }

        private void UpdateFileNameLabel()
        {
            lblFilename.Text = $"FILE: '{AppleEFI.FileInfoData.FileNameWithExt}'";
        }

        private void UpdateFileSizeLabel()
        {
            int fileSizeDecimal = (int)AppleEFI.FileInfoData.FileLength;

            bool isValidSize =
                FileUtils.GetIsValidBinSize(
                    fileSizeDecimal);

            lblFileSizeBytes.Text = $"{FileUtils.FormatFileSize(fileSizeDecimal)} • {fileSizeDecimal:X}h";

            if (!isValidSize)
            {
                lblFileSizeBytes.ForeColor = Colours.ERROR_RED;

                lblFileSizeBytes.Text +=
                    isValidSize
                    ? string.Empty
                    : $" ({FileUtils.GetSizeDifference(fileSizeDecimal)})";
            }
        }

        private void UpdateFileCrc32Label()
        {
            lblFileCrc.Text = $"{AppleEFI.FileInfoData.CRC32:X8}";
        }

        private void UpdateFileCreationDateLabel()
        {
            lblFileCreatedDate.Text = AppleEFI.FileInfoData.CreationTime;
        }

        private void UpdateFileModifiedDateLabel()
        {
            lblFileModifiedDate.Text = AppleEFI.FileInfoData.LastWriteTime;
        }

        private void UpdateModelLabel()
        {
            lblModel.Text =
                $"MODEL: {MacUtils.ConvertEfiModelCode(AppleEFI.EfiBiosIdSectionData.ModelPart) ?? "N/A"}";

            // Load and append the config code asynchronously
            if (AppleEFI.FsysStoreData.HWC != null)
                AppendConfigCodeTextAsync(
                    AppleEFI.FsysStoreData.HWC);
        }

        private void UpdateFsysLabel()
        {
            if (AppleEFI.FsysStoreData.CrcString != null)
            {
                lblFsysCrc.Text =
                    $"CRC: {AppleEFI.FsysStoreData.CrcString}h{(AppleEFI.ForceFoundFsys ? " [F]" : string.Empty)}";

                lblFsysCrc.ForeColor = string.Equals(
                    AppleEFI.FsysStoreData.CrcCalcString,
                    AppleEFI.FsysStoreData.CrcString)
                    ? Colours.COMPLETE_GREEN
                    : Colours.ERROR_RED;
            }
            else
            {
                lblFsysCrc.Text = "N/A";
            }
        }

        private void UpdateFirmwareSerialNumber()
        {
            string serialNumber = AppleEFI.FsysStoreData.Serial;

            lblSerialNumber.Text =
                serialNumber
                ?? "N/A";

            if (!string.IsNullOrEmpty(serialNumber)
                && (serialNumber.Length == 11
                || serialNumber.Length == 12))
                lblSerialNumber.Text += $" ({serialNumber.Length})";
        }

        private void UpdateHardwareConfigLabel()
        {
            lblHwc.Text =
                AppleEFI.FsysStoreData.HWC
                ?? "N/A";
        }

        private void UpdateOrderNumberLabel()
        {
            lblOrderNo.Text =
                AppleEFI.FsysStoreData.SON
                ?? "N/A";
        }

        private void UpdateEfiVersionLabel()
        {
            lblEfiVersion.Text =
                AppleEFI.FirmwareVersion
                ?? "N/A";
        }

        private void UpdateNvramLabel(Label label, NvramStore storeData, string text)
        {
            label.Text = text;

            Color foreColor = storeData.PrimaryStoreBase == -1
                ? Colours.DISABLED_TEXT
                : !storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty
                ? Color.White
                : Colours.COMPLETE_GREEN;

            label.ForeColor = foreColor;
        }

        private void UpdateEfiLockLabel()
        {
            switch (AppleEFI.EfiPrimaryLockData.LockStatus)
            {
                case EfiLockStatus.Locked:
                    lblEfiLockStatus.Text = "LOCKED";
                    lblEfiLockStatus.ForeColor = Colours.ERROR_RED;
                    break;
                case EfiLockStatus.Unlocked:
                    lblEfiLockStatus.Text = "UNLOCKED";
                    break;
                case EfiLockStatus.Unknown:
                default:
                    lblEfiLockStatus.Text = "UNKNOWN";
                    lblEfiLockStatus.ForeColor = Colours.WARNING_ORANGE;
                    break;
            }
        }

        private void UpdateBoardIdLabel()
        {
            lblBoardId.Text =
                AppleEFI.PdrSectionData.BoardId
                ?? "N/A";
        }

        private void UpdateApfsCapableLabel()
        {

            switch (AppleEFI.IsApfsCapable)
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
                    lblApfsCapable.Text = "UNKNOWN";
                    lblApfsCapable.ForeColor = Colours.ERROR_RED;
                    break;
            }
        }

        private void UpdateIntelMeLabel()
        {
            lblMeVersion.Text =
                AppleEFI.MeVersion
                ?? "N/A";

            if (IntelFD.ME_REGION_BASE != 0)
            {
                if (!string.IsNullOrEmpty(AppleEFI.MeVersion))
                {
                    lblMeVersion.Text += $" ({IntelFD.ME_REGION_BASE:X2}h)";
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
                    OpenBinary(Program.lastBuildPath);

                Program.openLastBuild = false;
                Program.lastBuildPath = string.Empty;
            }
        }

        private void ShowContextMenuAtControlPoint(object sender, ContextMenuStrip menu, MenuPosition menuPosition)
        {
            Control control = sender as Control;

            if (control == null)
                throw new ArgumentException(
                    "Invalid sender object type. Expected a Control.");

            Point position;

            switch (menuPosition)
            {
                case MenuPosition.TopRight:
                    position = control.PointToScreen(
                        new Point(
                            control.Width + 1,
                            -1));
                    break;
                case MenuPosition.BottomLeft:
                    position = control.PointToScreen(
                        new Point(
                            0,
                            control.Height + 1));
                    break;
                default:
                    throw new ArgumentException(
                        "Invalid MenuPosition value.");
            }

            menu.Show(position);
        }

        private void ShowContextMenuAtCursor(object sender, EventArgs e, ContextMenuStrip menu, bool showOnLeftClick)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            if (mouseEventArgs != null && (
                mouseEventArgs.Button == MouseButtons.Right
                || (showOnLeftClick && mouseEventArgs.Button == MouseButtons.Left)))
                menu.Show(Cursor.Position);
        }

        private void ToggleControlEnable(bool enable)
        {
            Button[] buttons =
            {
                cmdReset,
                cmdCopyMenu,
                cmdPatch,
                cmdNavigate,
                cmdReload,
                cmdBackupToZip,
                cmdFixFsysCrc,
                cmdExportFsys,
                cmdAppleRomInfo,
                cmdInvalidateEfiLock,
                cmdExportMe
            };

            foreach (Button button in buttons)
                button.Enabled = enable;

            cmdEveryMacSearch.Enabled =
                AppleEFI.FsysStoreData.Serial != null;

            if (AppleEFI.FsysStoreData.FsysBytes != null)
            {
                cmdFixFsysCrc.Enabled =
                    MacUtils.GetUintFsysCrc32(
                        AppleEFI.FsysStoreData.FsysBytes).ToString("X8") == AppleEFI.FsysStoreData.CrcString
                    ? false
                    : true;
            }
            else
            {
                cmdFixFsysCrc.Enabled = false;
                cmdExportFsys.Enabled = false;
                cmdPatch.Enabled = false;
            }

            cmdAppleRomInfo.Enabled =
                AppleEFI.AppleRomInfoSectionData.SectionExists;

            cmdInvalidateEfiLock.Enabled =
                AppleEFI.EfiPrimaryLockData.LockStatus == EfiLockStatus.Locked;

            cmdExportMe.Enabled =
                IntelFD.IsDescriptorMode &&
                IntelFD.ME_REGION_BASE != 0 &&
                IntelFD.ME_REGION_LIMIT != 0;

            tlpFile.Enabled = enable;
            tlpRom.Enabled = enable;
        }

        private void ToggleCopyMenuItemEnable()
        {
            modelToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.EfiBiosIdSectionData.ModelPart);
            configCodeToolStripMenuItem.Enabled =
                IsStringNotEmpty(_configCode);
            serialToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FsysStoreData.Serial);
            hwcToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FsysStoreData.HWC);
            fsysCRC32ToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FsysStoreData.CrcString);
            orderNoToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FsysStoreData.SON);
            efiVersionToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FirmwareVersion);
            boardIDToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.PdrSectionData.BoardId);
            fitVersionToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.FitVersion);
            meVersionToolStripMenuItem.Enabled =
                IsStringNotEmpty(AppleEFI.MeVersion);

            pdrBaseToolStripMenuItem.Enabled =
                IntelFD.PDR_REGION_BASE != 0;
            meBaseToolStripMenuItem.Enabled =
                IntelFD.ME_REGION_BASE != 0;
            biosBaseToolStripMenuItem.Enabled =
                IntelFD.BIOS_REGION_BASE != 0;

        }

        private bool IsStringNotEmpty(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdMore,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.MORE },
                new { Button = cmdClose,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.EXIT_CROSS },
                new { Button = cmdNavigate,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FILE_EXPLORER },
                new { Button = cmdReload,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.REFRESH },
                new { Button = cmdBackupToZip,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.UPLOAD },
                new { Button = cmdEveryMacSearch,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.WEB_SEARCH },
                new { Button = cmdExportFsys,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.SAVE },
                new { Button = cmdFixFsysCrc,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.REPAIR },
                new { Button = cmdAppleRomInfo,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.FORWARD },
                new { Button = cmdInvalidateEfiLock,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.UNLOCKED },
                new { Button = cmdExportMe,
                    Font = Program.FONT_MDL2_REG_9,
                    Text = Chars.SAVE }
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
                cmdMore,
                cmdOpen,
                cmdReset,
                cmdPatch,
                cmdSettings,
                cmdAbout,
                cmdNavigate,
                cmdReload,
                cmdBackupToZip,
                cmdCopyMenu,
                cmdEveryMacSearch,
                cmdFixFsysCrc,
                cmdExportFsys,
                cmdAppleRomInfo,
                cmdInvalidateEfiLock,
                cmdExportMe
            };

            Label[] labels =
            {
                lblVssStore,
                lblSvsStore,
                lblNssStore,
                lblVersion
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
                    { cmdReset, "Reset Window Data (CTRL + R)" },
                    { cmdPatch, "Open the Firmware Patcher (CTRL + P)" },
                    { cmdCopyMenu, "Open the Clipboard Copy Menu (CTRL + C)" },
                    { cmdSettings, "Open Settings Window (CTRL + S)" },
                    { cmdAbout, "Open About Window (CTRL + A)" },
                    { cmdMore, "More options... (CTRL + M)"},
                    { cmdNavigate, "Open Explorer at file (ALT + N)" },
                    { cmdReload, "Reload file from Disk (ALT + R)" },
                    { cmdBackupToZip, "Backup file to .zip (ALT + B)" },
                    { cmdEveryMacSearch, "Search Serial Number on EveryMac (ALT + S)" },
                    { cmdFixFsysCrc, "Repair Fsys CRC32 (ALT + F)" },
                    { cmdExportFsys, "Export Fsys Store (ALT + E)" },
                    { cmdAppleRomInfo, "Open the ROM Information Window (ALT + I)" },
                    { cmdInvalidateEfiLock, "Remove EFI Lock (ALT + L)" },
                    { cmdExportMe, "Export ME Region (ALT + M)" },
                    { lblVssStore, SetNvramStoreTip(AppleEFI.VssStoreData, "VSS") },
                    { lblSvsStore, SetNvramStoreTip(AppleEFI.SvsStoreData, "SVS") },
                    { lblNssStore, SetNvramStoreTip(AppleEFI.NssStoreData, "NSS") },
                    { lblVersion, "Go to latest release (CTRL + G)" },
                };

                if (tooltips.ContainsKey(sender))
                    lblMessage.Text = tooltips[sender];
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
            else if (storeData.IsPrimaryStoreEmpty && !storeData.IsBackupStoreEmpty)
                return $"Data present in the backup {storeType} store";
            else if (storeData.PrimaryStoreBase != -1)
                return $"{storeType} NVRAM stores are empty (0xFF)";

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
                _configCode = configCode;
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
                    ApplyNestedPanelLabelForeColor(
                        nestedTableLayoutPanel,
                        color);
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
        private void ShowExplorerNavigationPrompt(string message, string path)
        {
            DialogResult result =
                METMessageBox.Show(
                        this,
                        "MET",
                        $"{message} Navigate to file?",
                        METMessageType.Information,
                        METMessageButtons.YesNo);

            if (result == DialogResult.Yes)
                FileUtils.HighlightPathInExplorer(path);
        }

        internal async void CheckForNewVersion()
        {
            // Check for a new version using the specified URL
            VersionResult result =
                await AppVersion.CheckForNewVersion(
                    METUrl.VersionXml);

            // If a new version is available and update the UI
            if (result == VersionResult.NewVersionAvailable)
            {
                lblVersion.ForeColor = Color.FromArgb(255, 128, 128);
                lblVersion.Text += " (OUTDATED)";
            }
        }

        internal void SetPrimaryInitialDirectory()
        {
            // Get the initial directory from settings
            string path = Settings.SettingsGetString(SettingsStringType.InitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory
            if (!string.IsNullOrEmpty(path))
            {
                _strInitialDirectory = Directory.Exists(path)
                    ? path
                    : METPath.CurrentDirectory;
            }
        }

        private void OpenBinary(string filePath)
        {
            // Disable window controls
            ToggleControlEnable(false);

            // If a firmware is loaded, reset all data
            if (AppleEFI.FirmwareLoaded)
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
            AppleEFI.LoadedBinaryPath = filePath;

            AppleEFI.LoadedBinaryBytes =
                File.ReadAllBytes(
                    filePath);

            // Process the descriptor
            IntelFD.ParseRegionData(
                AppleEFI.LoadedBinaryBytes);

            // Check if the image is what we're looking for
            if (!AppleEFI.IsValidImage(AppleEFI.LoadedBinaryBytes))
            {
                METMessageBox.Show(
                    this,
                    "Error",
                    "The selected file is not a valid firmware image.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                ResetAllData();

                return;
            }

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
        }

        private void LoadFirmwareBase(string filePath)
        {
            // Load firmware base data from loaded binary bytes
            AppleEFI.LoadFirmwareBaseData(
                AppleEFI.LoadedBinaryBytes,
                filePath);

            // Update controls on the main UI thread using Invoke
            Invoke((MethodInvoker)UpdateUI);

            // Set firmware loaded flag to true
            AppleEFI.FirmwareLoaded = true;
        }

        private bool IsValidMinMaxSize(string filePath)
        {
            FileInfo fileInfo =
                new FileInfo(
                    filePath);

            // Check if the file size is smaller than the minimum allowed size
            if (fileInfo.Length < AppleEFI.MIN_IMAGE_SIZE) // 1048576 bytes
            {
                // Show an error message if the file is too small
                METMessageBox.Show(
                    this,
                    "Error",
                    $"The selected file does not meet the minimum size requirement of {AppleEFI.MIN_IMAGE_SIZE:X}h.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return false;
            }

            // Check if the file size is larger than the maximum allowed size
            if (fileInfo.Length > AppleEFI.MAX_IMAGE_SIZE) // 33554432 bytes
            {
                // Show an error message if the file is too large
                METMessageBox.Show(
                    this,
                    "Error",
                    $"The selected file exceeds the maximum size limit of {AppleEFI.MAX_IMAGE_SIZE:X}h.",
                    METMessageType.Error,
                    METMessageButtons.Okay);

                return false;
            }

            // The file size is within the valid range
            return true;
        }

        private void ResetAllData()
        {
            // Clear labels
            Label[] labels =
            {
                lblFilename,
                lblFileSizeBytes,
                lblFileCrc,
                lblFileCreatedDate,
                lblFileModifiedDate,
                lblModel,
                lblSerialNumber,
                lblHwc,
                lblFsysCrc,
                lblOrderNo,
                lblEfiVersion,
                lblVssStore,
                lblSvsStore,
                lblNssStore,
                lblEfiLockStatus,
                lblBoardId,
                lblApfsCapable,
                lblMeVersion
            };

            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = Color.White;
            }

            // Clear private member
            _configCode = string.Empty;

            // Reset label colours
            ApplyNestedPanelLabelForeColor(
                tlpRom,
                Color.White);

            // Reset initial directory
            SetPrimaryInitialDirectory();

            // Reset descriptor values
            IntelFD.ClearRegionData();

            // Reset FWBase
            AppleEFI.ResetFirmwareBaseData();
        }

        internal void SetClipboardText(string text)
        {
            Clipboard.SetText(text);

            METMessageBox.Show(
                this,
                "Information",
                $"'{text}' copied to the clipboard.",
                METMessageType.Information,
                METMessageButtons.Okay);
        }
        #endregion

    }
}