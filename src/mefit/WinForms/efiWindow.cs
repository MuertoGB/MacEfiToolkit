// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// efiWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Firmware.EFI;
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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class efiWindow : Form
    {

        #region Private Members
        private string _strInitialDirectory = METPath.CurrentDirectory;
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
        public efiWindow()
        {
            InitializeComponent();

            // Attach event handlers.
            Load += mainWindow_Load;
            KeyDown += mainWindow_KeyDown;
            DragEnter += mainWindow_DragEnter;
            DragDrop += mainWindow_DragDrop;
            Deactivate += mainWindow_Deactivate;
            Activated += mainWindow_Activated;

            // Set tip handlers for controls.
            SetTipHandlers();

            // Set mouse move event handlers.
            SetMouseMoveEventHandlers();

            // Set button properties (font and text).
            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            lblAppVersion.Text = 
                Application.ProductVersion;

            // Get and set the primary file dialog initial directory.
            SetPrimaryInitialDirectory();

            OpenBinary(Program.MAIN_WINDOW.loadedFile);
        }

        private void mainWindow_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged.
                if (draggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder.
                    string draggedFile = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(draggedFile);

                    // If it's a file (not a folder) then allow the copy operation.
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            // Disable the drop operation.
            e.Effect = DragDropEffects.None;
        }

        private void mainWindow_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            // Open the binary file.
            OpenBinary(draggedFilename);
        }

        private void mainWindow_Deactivate(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.DEACTIVATED_TEXT);

        private void mainWindow_Activated(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.WHITE_TEXT);
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        Process.Start(METUrl.GithubLatest);
                        break;
                    case Keys.O:
                        cmdMenuOpen.PerformClick();
                        break;
                    case Keys.R:
                        cmdMenuReset.PerformClick();
                        break;
                    case Keys.C:
                        cmdMenuCopy.PerformClick();
                        break;
                    case Keys.M:
                        UITools.ShowContextMenuAtControlPoint(
                            cmdMenuFolders,
                            cmsFolders,
                            MenuPosition.BottomLeft);
                        break;
                }
            }
            else if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.B:
                        cmdMenuBackupToZip.PerformClick();
                        break;
                    case Keys.N:
                        cmdOpenInExplorer.PerformClick();
                        break;
                    case Keys.R:
                        cmdMenuReload.PerformClick();
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
                tlpTitle,
                lblWindowTitle,
                tlpMenu };

            foreach (Control control in controls)
                control.MouseMove += mainWindow_MouseMove;
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void cmdMin_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

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

        private void cmdReload_Click(object sender, EventArgs e)
        {
            // Check the loaded binary exists.
            if (!File.Exists(EFIROM.LoadedBinaryPath))
            {
                // Loaded binary not exist.
                METMessageBox.Show(
                    this,
                    DialogStrings.DS_FILE_MOVED_OR_DELETED,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file.
            byte[] fileBytes =
                File.ReadAllBytes(
                    EFIROM.LoadedBinaryPath);

            // Check if the binaries match in size and data.
            if (BinaryUtils.ByteArraysMatch(fileBytes, EFIROM.LoadedBinaryBytes))
            {
                // Loaded binaries match.
                METMessageBox.Show(
                    this,
                    DialogStrings.DS_DISK_MATCHES_BUFFER,
                    METMessageBoxType.Warning,
                    METMessageBoxButtons.Okay);

                return;
            }

            // File data has changed.
            OpenBinary(EFIROM.LoadedBinaryPath);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                ToggleControlEnable(false);
                ResetAllData();
                return;
            }

            DialogResult result =
                METMessageBox.Show(
                    this,
                    DialogStrings.DS_UNLOAD_RESET,
                    METMessageBoxType.Warning,
                    METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetAllData();
            }
        }

        private void cmdBackupToZip_Click(object sender, EventArgs e)
        {
            if (EFIROM.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(
                    this,
                    $"FWBase.LoadedBinaryBytes() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            if (!Directory.Exists(METPath.BackupsDirectory))
                Directory.CreateDirectory(
                    METPath.BackupsDirectory);

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.InitialDirectory = METPath.BackupsDirectory;
                dialog.Filter = "Zip files (*.zip)|*.zip";
                dialog.FileName = $"{EFIROM.FileInfoData.FileName}_{MainWinStrings.MW_BACKUP.ToLower()}";
                dialog.OverwritePrompt = true;

                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                FileUtils.BackupFileToZip(
                    EFIROM.LoadedBinaryBytes,
                    EFIROM.FileInfoData.FileNameExt,
                    dialog.FileName);

                if (File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerNavigationPrompt(
                        this,
                        DialogStrings.DS_ARCHIVE_SUCCESS,
                        dialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DialogStrings.DS_ARCHIVE_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void cmdPatch_Click(object sender, EventArgs e)
        {
            if (EFIROM.LoadedBinaryBytes == null)
            {
                METMessageBox.Show(
                    this,
                    $"FWBase.LoadedBinaryBytes() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Warning,
                    METMessageBoxButtons.Okay);

                return;
            }

            bool bOpenEditor =
                Settings.ReadBool
                    (SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                UITools.SetHalfOpacity(this);

                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult result = frm.ShowDialog();
                    bOpenEditor = (result != DialogResult.No);
                }
            }

            if (bOpenEditor)
            {
                UITools.SetHalfOpacity(this);

                using (Form frm = new patcherWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    frm.ShowDialog();
                }
            }
        }

        private void cmdCopyMenu_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsCopy,
                MenuPosition.BottomLeft);

        private void cmdMenuExport_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsExport,
            MenuPosition.BottomLeft);

        private void cmdMenuPatch_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsPatch,
            MenuPosition.BottomLeft);

        private void cmdMenuOptions_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsOptions,
            MenuPosition.BottomLeft);

        private void cmdMenuFolders_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsFolders,
            MenuPosition.BottomLeft);

        private void cmdNavigate_Click(object sender, EventArgs e)
        {
            // Check the loaded binary path is not null or empty.
            if (string.IsNullOrEmpty(EFIROM.LoadedBinaryPath))
            {
                // Binary path is null or empty.
                METMessageBox.Show(
                    this,
                    $"FWBase.LoadedBinaryPath() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Navigate and highlight the file in explorer.
            FileUtils.HighlightPathInExplorer(
                EFIROM.LoadedBinaryPath);
        }
        #endregion

        #region Toolstrip Events
        private void openLocalFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start("explorer.exe", METPath.CurrentDirectory);

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
                DialogStrings.DS_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
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
                DialogStrings.DS_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
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
                DialogStrings.DS_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
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
                DialogStrings.DS_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        // File Clipboard Menu.
        private void filenameToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFilename(true);

        private void sizeBytesToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileSize();

        private void crc32ToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileCrc32();

        private void createdDateToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileCreationTime();

        private void modifiedDateToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileModifiedTime();

        // Firmware Clipboard Menu.
        private void modelToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareModel();

        private void configCodeToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareConfigCode();

        private void fsysCRC32ToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareFsysCrc32();

        private void serialToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareSerial();

        private void hwcToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareHwc();

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareOrderNumber();

        private void efiVersionToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareVersion();

        private void boardIDToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareBoardId();

        private void fitVersionToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareFitVersion();

        private void meVersionToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareMeVersion();

        private void pdrBaseToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetPdrRegionOffsets();

        private void meBaseToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetMeRegionOffsets();

        private void biosBaseToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetBiosRegionOffsets();
        #endregion

        #region Label Events
        private void lblAppVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(
                    METUrl.GithubLatest);
        }

        private void lblFilename_Click(object sender, EventArgs e) =>
            ClipboardSetFilename(true);

        private void lblFileSize_Click(object sender, EventArgs e) =>
            ClipboardSetFileSize();

        private void lblFileCrc32_Click(object sender, EventArgs e) =>
            ClipboardSetFileCrc32();

        private void lblFileCreatedDate_Click(object sender, EventArgs e) =>
            ClipboardSetFileCreationTime();

        private void lblFileModifiedDate_Click(object sender, EventArgs e) =>
            ClipboardSetFileModifiedTime();

        private void lblModel_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareFullModel();

        private void lblConfigCode_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareConfigCode();

        private void lblFsysCrc32_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareFsysCrc32();

        private void lblSerialNumber_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareSerial();

        private void lblHwc_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareHwc();

        private void lblOrderNumber_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareOrderNumber();

        private void lblEfiVersion_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareVersion();

        private void lblBoardId_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareBoardId();

        private void lblMeVersion_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareMeVersion();
        #endregion

        #region Update Main Window
        internal void UpdateUI()
        {
            // File information.
            UpdateFileNameControls();
            UpdateFileSizeControls();
            UpdateFileCrc32Controls();
            UpdateFileCreationDateControls();
            UpdateFileModifiedDateControls();

            // Firmware Data.
            UpdateModelControls();
            UpdateConfigCodeControls();
            UpdateFsysControls();
            UpdateSerialNumberControls();
            UpdateHardwareConfigControls();
            UpdateOrderNumberControls();
            UpdateEfiVersionControls();

            UpdateNvramLabel(
                lblVssStore,
                EFIROM.VssStoreData,
                MainWinStrings.MW_VSS);
            UpdateNvramLabel(
                lblSvsStore,
                EFIROM.SvsStoreData,
                MainWinStrings.MW_SVS);

            UpdateEfiLockControls();
            UpdateBoardIdControls();
            UpdateApfsCapableControls();
            UpdateIntelFitControls();
            UpdateIntelMeControls();

            // Apply DISABLED_TEXT color to N/A text labels.
            ApplyNestedPanelLabelForeColor(
                tlpFirmware,
                AppColours.DISABLED_TEXT);

            // Check which descriptor copy menu items should be enabled.
            pdrBaseToolStripMenuItem.Enabled =
                IFD.PDR_REGION_BASE != 0;
            meBaseToolStripMenuItem.Enabled =
                IFD.ME_REGION_BASE != 0;
            biosBaseToolStripMenuItem.Enabled =
                IFD.BIOS_REGION_BASE != 0;

            // Hide loading image.
            pbxLoad.Image = null;

            // Check and set control enable.
            ToggleControlEnable(true);
        }

        private void UpdateFileNameControls() =>
            lblFilename.Text = $"{MainWinStrings.MW_FILE}: '{EFIROM.FileInfoData.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            int fileSizeDecimal =
                EFIROM.FileInfoData.Length;

            bool isValidSize =
                FileUtils.GetIsValidBinSize(
                    fileSizeDecimal);

            lblFilesize.Text =
                $"{FileUtils.FormatFileSize(fileSizeDecimal)} {MainWinStrings.MW_BYTES} ({fileSizeDecimal:X}h)";

            if (!isValidSize)
            {
                lblFilesize.ForeColor =
                    AppColours.ERROR;

                lblFilesize.Text +=
                    isValidSize
                    ? string.Empty
                    : $" ({FileUtils.GetSizeDifference(fileSizeDecimal)})";
            }
        }

        private void UpdateFileCrc32Controls() =>
            lblFileCrc32.Text = $"{EFIROM.FileInfoData.CRC32:X8}";

        private void UpdateFileCreationDateControls() =>
            lblFileCreatedDate.Text = EFIROM.FileInfoData.CreationTime;

        private void UpdateFileModifiedDateControls() =>
            lblFileModifiedDate.Text = EFIROM.FileInfoData.LastWriteTime;

        private void UpdateModelControls()
        {
            string identifier =
                EFIROM.EfiBiosIdSectionData.ModelPart;

            if (!string.IsNullOrEmpty(identifier))
            {
                string model =
                    MacUtils.ConvertEfiModelCode(
                        EFIROM.EfiBiosIdSectionData.ModelPart);

                lblModel.Text =
                    $"{model} ({identifier})"
                    ?? AppStrings.AS_NA;

                modelToolStripMenuItem.Enabled = true;

                lblModel.Click += lblModel_Click;
                lblModel.Cursor = Cursors.Hand;

                return;
            }

            lblModel.Text = AppStrings.AS_NA;
            modelToolStripMenuItem.Enabled = false;
            lblModel.Cursor = Cursors.Default;
        }

        private void UpdateConfigCodeControls()
        {
            if (!string.IsNullOrEmpty(EFIROM.ConfigCode))
            {
                lblConfigCode.Text = EFIROM.ConfigCode;
                lblConfigCode.Click += lblConfigCode_Click;
                lblConfigCode.Cursor = Cursors.Hand;

                configCodeToolStripMenuItem.Enabled = true;

                return;
            }

            lblConfigCode.Text = AppStrings.AS_CONTACT_SERVER;
            lblConfigCode.ForeColor = Colours.INFO_BOX;

            AppendConfigCodeAsync(EFIROM.FsysStoreData.HWC);
        }

        internal async void AppendConfigCodeAsync(string hwc)
        {
            string configCode =
                await MacUtils.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configCode))
            {
                EFIROM.ConfigCode = configCode;

                lblConfigCode.Text = configCode;
                lblConfigCode.ForeColor = Color.White;
                lblConfigCode.Click += lblConfigCode_Click;
                lblConfigCode.Cursor = Cursors.Hand;

                configCodeToolStripMenuItem.Enabled = true;

                return;
            }

            lblConfigCode.Text = AppStrings.AS_NA;
            lblConfigCode.ForeColor = Colours.CONTROL_DISABLED_TEXT;
            lblConfigCode.Cursor = Cursors.Default;

            configCodeToolStripMenuItem.Enabled = false;
        }

        private void UpdateFsysControls()
        {
            string fsysCrc32 =
                EFIROM.FsysStoreData.CrcString;

            if (!string.IsNullOrEmpty(fsysCrc32))
            {
                lblFsysCrc32.Text =
                    $"{fsysCrc32}h{(EFIROM.ForceFoundFsys ? " [F]" : string.Empty)}";

                lblFsysCrc32.ForeColor = string.Equals(
                    fsysCrc32,
                    EFIROM.FsysStoreData.CrcCalcString)
                    ? AppColours.COMPLETE
                    : AppColours.ERROR;

                fsysCRC32ToolStripMenuItem.Enabled = true;
                lblFsysCrc32.Click += lblFsysCrc32_Click;
                lblFsysCrc32.Cursor = Cursors.Hand;

                return;
            }

            fsysCRC32ToolStripMenuItem.Enabled = false;
            lblFsysCrc32.Text = AppStrings.AS_NA;
            lblFsysCrc32.Cursor = Cursors.Default;
        }

        private void UpdateSerialNumberControls()
        {
            string serialNumber =
                EFIROM.FsysStoreData.Serial;

            lblSerialNumber.Text =
                serialNumber
                ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(serialNumber))
            {
                lblSerialNumber.Text +=
                    (serialNumber.Length == 11 || serialNumber.Length == 12)
                    ? $" ({serialNumber.Length})"
                    : string.Empty;

                serialToolStripMenuItem.Enabled = true;
                lblSerialNumber.Click += lblSerialNumber_Click;
                lblSerialNumber.Cursor = Cursors.Hand;

                return;
            }

            serialToolStripMenuItem.Enabled = false;
            lblSerialNumber.Cursor = Cursors.Default;
        }

        private void UpdateHardwareConfigControls()
        {
            string hwc =
                EFIROM.FsysStoreData.HWC;

            lblHwc.Text =
                 hwc
                 ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(hwc))
            {
                hwcToolStripMenuItem.Enabled = true;
                lblHwc.Click += lblHwc_Click;
                lblHwc.Cursor = Cursors.Hand;

                return;
            }

            hwcToolStripMenuItem.Enabled = false;
            lblHwc.Cursor = Cursors.Default;
        }

        private void UpdateOrderNumberControls()
        {
            string orderNumber =
                EFIROM.FsysStoreData.SON;

            lblOrderNumber.Text =
                orderNumber
                ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(orderNumber))
            {
                orderNoToolStripMenuItem.Enabled = true;
                lblOrderNumber.Click += lblOrderNumber_Click;
                lblOrderNumber.Cursor = Cursors.Hand;

                return;
            }

            orderNoToolStripMenuItem.Enabled = false;
            lblOrderNumber.Cursor = Cursors.Default;
        }

        private void UpdateEfiVersionControls()
        {
            string efiVersion =
                EFIROM.FirmwareVersion;

            lblEfiVersion.Text =
                efiVersion
                ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(efiVersion))
            {
                efiVersionToolStripMenuItem.Enabled = true;
                lblEfiVersion.Click += lblEfiVersion_Click;
                lblEfiVersion.Cursor = Cursors.Hand;

                return;
            }

            efiVersionToolStripMenuItem.Enabled = false;
            lblEfiVersion.Cursor = Cursors.Default;
        }

        private void UpdateNvramLabel(
            Label nvramLabel, NvramStore storeData, string text)
        {
            nvramLabel.Text = text;

            Color foreColor =
                storeData.PrimaryStoreBase == -1
                ? AppColours.DISABLED_TEXT
                : !storeData.IsPrimaryStoreEmpty || !storeData.IsBackupStoreEmpty
                ? AppColours.WARNING
                : AppColours.COMPLETE;

            nvramLabel.ForeColor = foreColor;
        }

        private void UpdateEfiLockControls()
        {
            switch (EFIROM.EfiPrimaryLockData.LockType)
            {
                case EfiLockType.Locked:
                    lblEfiLock.Text = MainWinStrings.MW_LOCKED.ToUpper();
                    lblEfiLock.ForeColor = AppColours.ERROR;
                    break;
                case EfiLockType.Unlocked:
                    lblEfiLock.Text = MainWinStrings.MW_UNLOCKED.ToUpper();
                    lblEfiLock.ForeColor = AppColours.COMPLETE;
                    break;
                case EfiLockType.Unknown:
                default:
                    lblEfiLock.Text = MainWinStrings.MW_UNKNOWN.ToUpper();
                    lblEfiLock.ForeColor = AppColours.WARNING;
                    break;
            }
        }

        private void UpdateBoardIdControls()
        {
            string boardId =
                EFIROM.PdrSectionData.BoardId;

            lblBoardId.Text =
                boardId
                ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(boardId))
            {
                boardIDToolStripMenuItem.Enabled = true;
                lblBoardId.Click += lblBoardId_Click;
                lblBoardId.Cursor = Cursors.Hand;

                return;
            }

            boardIDToolStripMenuItem.Enabled = false;
            lblBoardId.Cursor = Cursors.Default;
        }

        private void UpdateApfsCapableControls()
        {
            switch (EFIROM.IsApfsCapable)
            {
                case ApfsCapable.Yes:
                    lblApfsCapable.Text = MainWinStrings.MW_APFS_DRIVER_FOUND;
                    lblApfsCapable.ForeColor = AppColours.COMPLETE;
                    break;
                case ApfsCapable.No:
                    lblApfsCapable.Text = MainWinStrings.MW_APFS_DRIVER_NOT_FOUND;
                    lblApfsCapable.ForeColor = AppColours.WARNING;
                    break;
                case ApfsCapable.Unknown:
                    lblApfsCapable.Text = MainWinStrings.MW_UNKNOWN.ToUpper();
                    lblApfsCapable.ForeColor = AppColours.ERROR;
                    break;
            }
        }

        private void UpdateIntelFitControls() =>
            fitVersionToolStripMenuItem.Enabled =
            !string.IsNullOrEmpty(EFIROM.FitVersion)
            ? true
            : false;

        private void UpdateIntelMeControls()
        {
            string meVersion =
                EFIROM.MeVersion;

            lblMeVersion.Text =
                meVersion
                ?? AppStrings.AS_NA;

            if (!string.IsNullOrEmpty(meVersion))
            {
                if (IFD.ME_REGION_BASE != 0)
                    if (!string.IsNullOrEmpty(meVersion))
                        lblMeVersion.Text += $" (0x{IFD.ME_REGION_BASE:X}h)";

                meVersionToolStripMenuItem.Enabled = true;
                lblMeVersion.Click += lblMeVersion_Click;
                lblMeVersion.Cursor = Cursors.Hand;

                return;
            }

            meVersionToolStripMenuItem.Enabled = false;
            lblMeVersion.Cursor = Cursors.Default;
        }
        #endregion

        #region UI Events
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

        private void ToggleControlEnable(bool enable)
        {
            Button[] standardButtons =
            {
                cmdMenuReset,
                cmdMenuCopy,
                cmdMenuBackupToZip,
                cmdOpenInExplorer,
                cmdMenuReload,
                };

            void EnableButtons(params Button[] buttons)
            {
                foreach (Button button in buttons)
                    button.Enabled = enable;
            }

            if (!enable)
            {
                EnableButtons(standardButtons);
            }
            else
            {
                EnableButtons(standardButtons);

                bool modelPartExists =
                    EFIROM.EfiBiosIdSectionData.ModelPart
                    != null;

                bool fsysBytesExist =
                    EFIROM.FsysStoreData.FsysBytes
                    != null;

                bool fsysCrcMismatch = fsysBytesExist &&
                    !string.Equals(EFIROM.FsysStoreData.CrcCalcString,
                        EFIROM.FsysStoreData.CrcString);

                //cmdFixFsysCrc.Enabled = fsysCrcMismatch;

                //cmdExportFsys.Enabled = fsysBytesExist;

                //cmdPatch.Enabled =
                //    modelPartExists
                //    && fsysBytesExist
                //    || fsysCrcMismatch;

                //cmdAppleRomInfo.Enabled =
                //    EFIROM.AppleRomInfoSectionData.SectionExists;

                //cmdInvalidateEfiLock.Enabled =
                //    EFIROM.EfiPrimaryLockData.LockType == EfiLockType.Locked;

                //cmdEveryMacSearch.Enabled =
                    //!string.IsNullOrEmpty(EFIROM.FsysStoreData.Serial)
                    //&& !MacUtils.IsBannedSerial(EFIROM.FsysStoreData.Serial);

                //cmdExportMe.Enabled =
                //    IFD.IsDescriptorMode
                //    && IFD.ME_REGION_BASE != 0
                //    && IFD.ME_REGION_LIMIT != 0;
            }

            tlpFilename.Enabled = enable;
            tlpFirmware.Enabled = enable;
        }

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdClose,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.EXIT_CROSS },
                new { Button = cmdOpenInExplorer,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FILE_EXPLORER },
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
                cmdMenuFolders,
                cmdMenuOpen,
                cmdMenuReset,
                cmdOpenInExplorer,
                cmdMenuReload,
                cmdMenuBackupToZip,
                cmdMenuCopy,
            };

            Label[] labels =
            {
                lblVssStore,
                lblSvsStore,
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
            if (!Settings.ReadBool(SettingsBoolType.DisableTips))
            {
                Dictionary<object, string> tooltips = new Dictionary<object, string>
                {
                    { cmdMenuOpen, "Open a Mac UEFI/BIOS (CTRL + O)" },
                    { cmdMenuReset, "Reset Window Data (CTRL + R)" },
                    { cmdMenuCopy, "Open the Clipboard Copy Menu (CTRL + C)" },
                    { cmdMenuFolders, "More options... (CTRL + M)" },
                    { cmdOpenInExplorer, "Open File in Explorer (ALT + N)" },
                    { cmdMenuReload, "Reload File from Disk (ALT + R)" },
                    { cmdMenuBackupToZip, "Backup File to .zip (ALT + B)" },
                    { lblVssStore, SetNvramStoreTip(EFIROM.VssStoreData, MainWinStrings.MW_VSS) },
                    { lblSvsStore, SetNvramStoreTip(EFIROM.SvsStoreData, MainWinStrings.MW_SVS) },
                };

                if (tooltips.ContainsKey(sender))
                    lblStatusBarTip.Text = tooltips[sender];
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e) =>
            lblStatusBarTip.Text = string.Empty;

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

        void ApplyNestedPanelLabelForeColor(TableLayoutPanel tableLayoutPanel, Color color)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label && label.Text == AppStrings.AS_NA)
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
                ctrl.ForeColor = foreColor;
        }
        #endregion

        #region Misc Events

        internal void SetPrimaryInitialDirectory()
        {
            // Get the initial directory from settings.
            string path = Settings.ReadString(SettingsStringType.InitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(path))
            {
                _strInitialDirectory = Directory.Exists(path)
                    ? path
                    : METPath.CurrentDirectory;
            }
        }

        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            // If a firmware is loaded, reset all data.
            if (EFIROM.FirmwareLoaded)
                ResetAllData();

            // Check the filesize
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
            {
                ResetAllData();
                return;
            }

            // Set the binary path and load the bytes.
            EFIROM.LoadedBinaryPath = filePath;

            EFIROM.LoadedBinaryBytes =
                File.ReadAllBytes(
                    filePath);

            // Process the descriptor.
            IFD.ParseRegionData(
                EFIROM.LoadedBinaryBytes);

            // Check if the image is what we're looking for.
            if (!EFIROM.IsValidImage(EFIROM.LoadedBinaryBytes))
            {
                METMessageBox.Show(
                    this,
                    DialogStrings.DS_NOT_VALID_FW,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                ResetAllData();

                return;
            }

            // Show loading resource.
            pbxLoad.Image = Properties.Resources.loading;

            // Set the current initial directory.
            _strInitialDirectory = Path.GetDirectoryName(filePath);

            // Load the firmware base in a separate thread.
            Thread thread = new Thread(() => LoadFirmwareBase(filePath))
            {
                IsBackground = true
            };

            thread.Start();
        }

        private void LoadFirmwareBase(string filePath)
        {
            // Load firmware base data from loaded binary bytes.
            EFIROM.LoadFirmwareBaseData(
                EFIROM.LoadedBinaryBytes,
                filePath);

            // Update controls on the main UI thread using Invoke.
            Invoke((MethodInvoker)UpdateUI);

            // Set firmware loaded flag to true.
            EFIROM.FirmwareLoaded = true;
        }

        private void ResetAllData()
        {
            // Clear labels.
            Label[] labels =
            {
                lblFilename,
                lblFilesize,
                lblFileCrc32,
                lblFileCreatedDate,
                lblFileModifiedDate,
                lblModel,
                lblConfigCode,
                lblSerialNumber,
                lblHwc,
                lblFsysCrc32,
                lblOrderNumber,
                lblEfiVersion,
                lblVssStore,
                lblSvsStore,
                lblEfiLock,
                lblBoardId,
                lblApfsCapable,
                lblMeVersion
            };

            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = Color.FromArgb(235, 235, 235);
            }

            // Remove click event handlers.
            lblModel.Click -= lblModel_Click;
            lblConfigCode.Click -= lblConfigCode_Click;
            lblFsysCrc32.Click -= lblFsysCrc32_Click;
            lblSerialNumber.Click -= lblSerialNumber_Click;
            lblHwc.Click -= lblHwc_Click;
            lblOrderNumber.Click -= lblOrderNumber_Click;
            lblEfiVersion.Click -= lblEfiVersion_Click;
            lblBoardId.Click -= lblBoardId_Click;
            lblMeVersion.Click -= lblMeVersion_Click;

            // Reset initial directory.
            SetPrimaryInitialDirectory();

            // Reset descriptor values.
            IFD.ClearRegionData();

            // Reset FWBase.
            EFIROM.ResetFirmwareBaseData();
        }
        #endregion

        #region Clipboard
        internal void SetClipboardText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Clipboard.SetText(text);

            METMessageBox.Show(
                this,
                $"'{text}' copied to the clipboard.",
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void ClipboardSetFilename(bool showExtension) => SetClipboardText(
            showExtension
            ? EFIROM.FileInfoData.FileNameExt
            : EFIROM.FileInfoData.FileName);

        private void ClipboardSetFileSize() => SetClipboardText(
            $"{FileUtils.FormatFileSize(EFIROM.FileInfoData.Length)} " +
            $"bytes ({EFIROM.FileInfoData.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText(
            $"{EFIROM.FileInfoData.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(
            EFIROM.FileInfoData.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(
            EFIROM.FileInfoData.LastWriteTime);

        private void ClipboardSetFirmwareModel() => SetClipboardText(
            $"{MacUtils.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart)}");

        private void ClipboardSetFirmwareFullModel() => SetClipboardText(
            MacUtils.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart));

        private void ClipboardSetFirmwareConfigCode() => SetClipboardText(
                EFIROM.ConfigCode);

        private void ClipboardSetFirmwareFsysCrc32() => SetClipboardText(
            EFIROM.FsysStoreData.CrcString);

        private void ClipboardSetFirmwareSerial() => SetClipboardText(
                EFIROM.FsysStoreData.Serial);

        private void ClipboardSetFirmwareHwc() => SetClipboardText(
            EFIROM.FsysStoreData.HWC);

        private void ClipboardSetFirmwareOrderNumber() => SetClipboardText(
            EFIROM.FsysStoreData.SON);

        private void ClipboardSetFirmwareVersion() => SetClipboardText(
            EFIROM.FirmwareVersion);

        private void ClipboardSetFirmwareBoardId() => SetClipboardText(
            EFIROM.PdrSectionData.BoardId);

        private void ClipboardSetFirmwareFitVersion() => SetClipboardText(
            EFIROM.FitVersion);

        private void ClipboardSetFirmwareMeVersion() => SetClipboardText(
            EFIROM.MeVersion);

        private void ClipboardSetPdrRegionOffsets() => SetClipboardText(
            $"Base: 0x{IFD.PDR_REGION_BASE:X}h, " +
            $"Limit: 0x{IFD.PDR_REGION_LIMIT:X}h, " +
            $"Size: 0x{IFD.PDR_REGION_SIZE:X}h");

        private void ClipboardSetMeRegionOffsets() => SetClipboardText(
            $"Base: 0x{IFD.ME_REGION_BASE:X}h, " +
            $"Limit: 0x{IFD.ME_REGION_LIMIT:X}h, " +
            $"Size: 0x{IFD.ME_REGION_SIZE:X}h");

        private void ClipboardSetBiosRegionOffsets() => SetClipboardText(
            $"Base: 0x{IFD.BIOS_REGION_BASE:X}h, " +
            $"Limit: 0x{IFD.BIOS_REGION_LIMIT:X}h, " +
            $"Size: 0x{IFD.BIOS_REGION_SIZE:X}h");
        #endregion

        private void exportFirmwareInformationTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"{MainWinStrings.MW_FW_INFO}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("File");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Filename:        {EFIROM.FileInfoData.FileNameExt}");
                builder.AppendLine($"Size (Bytes):    {FileUtils.FormatFileSize(EFIROM.FileInfoData.Length)} bytes");
                builder.AppendLine($"Size (Hex):      {EFIROM.FileInfoData.Length:X}h");
                builder.AppendLine($"Size (MB):       {Helper.GetBytesReadableSize(EFIROM.FileInfoData.Length)}");
                builder.AppendLine($"CRC32:           {EFIROM.FileInfoData.CRC32:X}");
                builder.AppendLine($"Created:         {EFIROM.FileInfoData.CreationTime}");
                builder.AppendLine($"Modified:        {EFIROM.FileInfoData.LastWriteTime}\r\n");

                builder.AppendLine("Descriptor Regions");
                builder.AppendLine("----------------------------------");
                if (IFD.IsDescriptorMode)
                {
                    builder.AppendLine(
                        $"PDR Region:      Base: 0x{IFD.PDR_REGION_BASE:X}h, " +
                        $"Limit: 0x{IFD.PDR_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.PDR_REGION_SIZE:X}h");
                    builder.AppendLine(
                        $"ME Region:       Base: 0x{IFD.ME_REGION_BASE:X}h, " +
                        $"Limit: 0x{IFD.ME_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.ME_REGION_SIZE:X}h");
                    builder.AppendLine(
                        $"BIOS Region:     Base: 0x{IFD.BIOS_REGION_BASE:X}h, " +
                        $"Limit: 0x{IFD.BIOS_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.BIOS_REGION_SIZE:X}h\r\n");
                }
                else
                {
                    builder.AppendLine("Descriptor mode is disabled.\r\n");
                }

                builder.AppendLine("Model Information");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Identifier:      {EFIROM.EfiBiosIdSectionData.ModelPart ?? "N/A"}");
                builder.AppendLine($"Model:           {MacUtils.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart) ?? "N/A"}");
                builder.AppendLine($"Configuration:   {EFIROM.ConfigCode ?? "N/A"}");
                builder.AppendLine($"Board ID:        {EFIROM.PdrSectionData.BoardId ?? "N/A"}\r\n");

                builder.AppendLine("Fsys Store");
                builder.AppendLine("----------------------------------");
                if (EFIROM.FsysStoreData.FsysBytes != null)
                {
                    builder.AppendLine($"Base:            0x{EFIROM.FsysStoreData.FsysBase:X}h");
                    builder.AppendLine($"Size:            {EFIROM.FSYS_RGN_SIZE:X}h");
                    builder.AppendLine($"CRC32:           {EFIROM.FsysStoreData.CrcString ?? "N/A"}");
                    builder.AppendLine($"Serial:          {EFIROM.FsysStoreData.Serial ?? "N/A"}");
                    builder.AppendLine($"HWC:             {EFIROM.FsysStoreData.HWC ?? "N/A"}");
                    builder.AppendLine($"SON:             {EFIROM.FsysStoreData.SON ?? "N/A"}\r\n");
                }
                else
                {
                    builder.AppendLine("Fsys Store was not found.\r\n");
                }

                builder.AppendLine("Firmware");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"EFI Version:     {EFIROM.FirmwareVersion ?? "N/A"}");
                builder.AppendLine($"EFI Lock:        {EFIROM.EfiPrimaryLockData.LockType.ToString() ?? "N/A"}");
                builder.AppendLine($"APFS Capable:    {EFIROM.IsApfsCapable.ToString() ?? "N/A"}\r\n");

                File.WriteAllText(
                    dialog.FileName,
                    builder.ToString());

                if (!File.Exists(dialog.FileName))
                {
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_DATA_EXPORT_FAIL,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);

                    return;
                }

                UITools.ShowExplorerNavigationPrompt(
                 this,
                 DialogStrings.DS_DATA_EXPORT_SUCCESS,
                 dialog.FileName);
            }
        }

        private void automaticFilenameGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string model =
                EFIROM.EfiBiosIdSectionData.ModelPart
                ?? MainWinStrings.MW_NOMODEL;

            string serial =
                EFIROM.FsysStoreData.Serial
                ?? MainWinStrings.MW_NOSERIAL;

            if (MacUtils.IsBannedSerial(serial))
                serial = MainWinStrings.MW_NOSERIAL;

            string efiversion =
                EFIROM.FirmwareVersion
                ?? MainWinStrings.MW_NOFWVER;

            SetClipboardText($"{model}_{serial}_{efiversion}");
        }

        private void exportIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IFD.ME_REGION_BASE == 0 || IFD.ME_REGION_LIMIT == 0)
            {
                METMessageBox.Show(
                    this,
                    DialogStrings.DS_ME_BOL_NOT_FOUND,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Check the Fsys stores directory exists.
            if (!Directory.Exists(METPath.MeDirectory))
            {
                // Create the Fsys stores directory.
                Status status =
                    FileUtils.CreateDirectory(
                        METPath.MeDirectory);

                // Directory creation failed.
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_ME_DIR_FAIL,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);
                }
            }

            // Set SaveFileDialog params.
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"{MainWinStrings.MW_ME_REGION}_{EFIROM.FsysStoreData.Serial}_{EFIROM.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.MeDirectory
            })
            {
                // Action was cancelled.
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                byte[] meBytes =
                    BinaryUtils.GetBytesBaseLength(
                        EFIROM.LoadedBinaryBytes,
                        (int)IFD.ME_REGION_BASE,
                        (int)IFD.ME_REGION_SIZE);

                if (FileUtils.WriteAllBytesEx(dialog.FileName, meBytes) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerNavigationPrompt(
                        this,
                        DialogStrings.DS_ME_EXPORT_SUCCESS,
                        dialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DialogStrings.DS_ME_EXPORT_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void exportFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fsys store bytes were null.
            if (EFIROM.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(
                    this,
                    $"FsysSectionData.FsysBytes() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Check the Fsys stores directory exists.
            if (!Directory.Exists(METPath.FsysDirectory))
            {
                // Create the Fsys stores directory.
                Status status =
                    FileUtils.CreateDirectory(
                        METPath.FsysDirectory);

                // Directory creation failed.
                if (status == Status.FAILED)
                {
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_FSYS_DIR_FAIL,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);
                }
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"{MainWinStrings.MW_FSYS}_{EFIROM.FsysStoreData.Serial}_{EFIROM.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.FsysDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                // Save the Fsys stores bytes to disk.
                if (FileUtils.WriteAllBytesEx(
                    dialog.FileName,
                    EFIROM.FsysStoreData.FsysBytes) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerNavigationPrompt(
                        this,
                        DialogStrings.DS_FSYS_EXPORT_SUCCESS,
                        dialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DialogStrings.DS_FSYS_EXPORT_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void lookupSerialNumberOnEveryMacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EFIROM.FsysStoreData.Serial == null)
            {
                METMessageBox.Show(
                    this,
                    $"FsysSectionData.Serial() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            Process.Start(
                $"https://everymac.com/ultimate-mac-lookup/?search_keywords={EFIROM.FsysStoreData.Serial}");
        }

        private void viewRomInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check the Rom Information section exists.
            if (EFIROM.AppleRomInfoSectionData.SectionExists == false)
            {
                // ROM Information section does not exist.
                METMessageBox.Show(
                    this,
                    $"ROMInfoData.SectionExists() {DialogStrings.DS_RETURNED_FALSE}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Set window half opacity.
            UITools.SetHalfOpacity(this);

            // Open the Rom Information Window.
            using (Form formWindow = new infoWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void fixFsysChecksumCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fsys store was not found by the firmware parser.
            if (EFIROM.FsysStoreData.FsysBytes == null)
            {
                METMessageBox.Show(
                    this,
                    $"FsysSectionData.FsysBytes() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = $"{MainWinStrings.MW_CRC_FIXED}_{EFIROM.FileInfoData.FileName}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled.
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                bool buildFailed = false;

                // Make binary with patched Fsys crc.
                byte[] patchedBinary =
                    BinaryUtils.MakeFsysCrcPatchedBinary(
                        EFIROM.LoadedBinaryBytes,
                        EFIROM.FsysStoreData.FsysBase,
                        EFIROM.FsysStoreData.FsysBytes,
                        EFIROM.FsysStoreData.CRC32CalcInt);

                // Check patchedBinary is not null.
                if (patchedBinary == null)
                {
                    Logger.WriteToAppLog(
                        $"{MainWinStrings.MW_LOG_BU_MAKEFSYSPB_NULL}");

                    buildFailed = true;
                }

                // Check binary was written without error.
                if (!FileUtils.WriteAllBytesEx(dialog.FileName, patchedBinary))
                {
                    Logger.WriteToAppLog(
                        $"{MainWinStrings.MW_LOG_FU_WRITEALL_RETURNED_FALSE}");

                    buildFailed = true;
                }

                // The build failed flag was set.
                if (buildFailed)
                {
                    METMessageBox.Show(
                         this,
                         DialogStrings.DS_FSYS_CRC_PATCH_FAIL,
                         METMessageBoxType.Error,
                         METMessageBoxButtons.YesNo);

                    return;
                }

                // Ask if user wants to open the repaired file.
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_FSYS_CRC_PATCH_SUCCESS,
                        METMessageBoxType.Information,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(dialog.FileName);
            }
        }

        private void invalidateEFILockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // SVS primary store bytes were null.
            if (EFIROM.SvsStoreData.PrimaryStoreBytes == null)
            {
                METMessageBox.Show(
                    this,
                    $"SvsStoreData.PrimaryStoreBytes() {DialogStrings.DS_DATA_NULL}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // SVS primary store base was not set.
            if (EFIROM.SvsStoreData.PrimaryStoreBase == -1)
            {
                METMessageBox.Show(
                    this,
                    $"SvsStoreData.PrimaryStoreBase() {DialogStrings.DS_BASE_NOT_FOUND}",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            // Check editing terms have been accepted.
            bool allowOperation =
                Settings.ReadBool(
                    SettingsBoolType.AcceptedEditingTerms);

            // Allow user to accept editing terms.
            if (!allowOperation)
            {
                UITools.SetHalfOpacity(this);

                using (Form frm = new termsWindow())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult result = frm.ShowDialog();
                    allowOperation = (result != DialogResult.No);
                }
            }

            // If terms were rejected then disallow operation.
            if (!allowOperation)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = $"{MainWinStrings.MW_UNLOCKED}_{EFIROM.FileInfoData.FileName}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled.
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                bool buildFailed = false;

                // Clone the loaded binary.
                byte[] patchedBinary = EFIROM.LoadedBinaryBytes;

                // Create empty stores
                byte[] unlockedPrimaryStore = null;
                byte[] unlockedBackupStore = null;

                // Create a patched primary store.
                unlockedPrimaryStore =
                    BinaryUtils.PatchSvsStoreMac(
                        EFIROM.SvsStoreData.PrimaryStoreBytes,
                        EFIROM.EfiPrimaryLockData.LockCrcBase);

                // Write patched primary store to the cloned binary.
                BinaryUtils.OverwriteBytesAtBase(
                    patchedBinary,
                    EFIROM.SvsStoreData.PrimaryStoreBase,
                    unlockedPrimaryStore);

                // We should probably patch any Message Authentication Code in the backup SVS store as well.
                if (EFIROM.EfiBackupLockData.LockCrcBase != -1)
                {
                    // A MAC CRC base was found in the backup store so we need to patch it.
                    unlockedBackupStore =
                        BinaryUtils.PatchSvsStoreMac(
                            EFIROM.SvsStoreData.BackupStoreBytes,
                            EFIROM.EfiBackupLockData.LockCrcBase);

                    // Write patched backup store to the cloned binary.
                    BinaryUtils.OverwriteBytesAtBase(
                        patchedBinary,
                        EFIROM.SvsStoreData.BackupStoreBase,
                        unlockedBackupStore);
                }

                // Load SVS NVRAM stores from the patched binary.
                NvramStore svsStore =
                    EFIROM.GetNvramStoreData(
                        patchedBinary,
                        NvramStoreType.SVS);

                // Check patched primary store matches the patched buffer.
                if (!BinaryUtils.ByteArraysMatch(svsStore.PrimaryStoreBytes, unlockedPrimaryStore))
                {
                    Logger.WriteToAppLog(
                        $"{MainWinStrings.MW_LOG_PS_BUFFER_MISMATCH}");

                    buildFailed = true;
                }

                // Check patched backup store matches the patched buffer (if backup store is ! null).
                if (unlockedBackupStore != null)
                {
                    if (!BinaryUtils.ByteArraysMatch(svsStore.BackupStoreBytes, unlockedBackupStore))
                    {
                        Logger.WriteToAppLog(
                            $"{MainWinStrings.MW_LOG_BS_BUFFER_MISMATCH}");

                        buildFailed = true;
                    }
                }

                // Check binary was written without error.
                if (!FileUtils.WriteAllBytesEx(dialog.FileName, patchedBinary))
                {
                    Logger.WriteToAppLog(
                        $"{MainWinStrings.MW_LOG_FU_WRITEALL_RETURNED_FALSE}");

                    buildFailed = true;
                }

                // The build failed flag was set.
                if (buildFailed)
                {
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_INVALIDATING_LOCK_FAIL,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.YesNo);

                    return;
                }

                // Ask if user wants to open the patched file.
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DialogStrings.DS_INVALIDATING_LOCK_SUCCESS,
                        METMessageBoxType.Information,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(dialog.FileName);
            }
        }
    }
}