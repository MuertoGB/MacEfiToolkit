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
        private string _strInitialDirectory = METPath.WORKING_DIR;
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
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
            Load += efiWindow_Load;
            FormClosing += efiWindow_FormClosing;
            FormClosed += efiWindow_FormClosed;
            KeyDown += efiWindow_KeyDown;
            DragEnter += efiWindow_DragEnter;
            DragDrop += efiWindow_DragDrop;
            Deactivate += efiWindow_Deactivate;
            Activated += efiWindow_Activated;

            // Set tip handlers for controls.
            SetTipHandlers();

            // Set mouse move event handlers.
            SetMouseMoveEventHandlers();

            // Set button properties (font and text).
            SetButtonProperties();

            if (this.Owner == null && this.Parent == null)
                StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region Window Events
        private void efiWindow_Load(object sender, EventArgs e)
        {
            // Get and set the primary file dialog initial directory.
            SetInitialDirectory();

            _cancellationToken =
                new CancellationTokenSource();

            OpenBinary(Program.MAIN_WINDOW.loadedFile);
        }

        private void efiWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
                _cancellationToken.Cancel();
        }

        private void efiWindow_FormClosed(object sender, FormClosedEventArgs e) =>
            _cancellationToken?.Dispose();

        private void efiWindow_DragEnter(object sender, DragEventArgs e)
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

        private void efiWindow_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            // Open the binary file.
            OpenBinary(draggedFilename);
        }

        private void efiWindow_Deactivate(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.DEACTIVATED_TEXT);

        private void efiWindow_Activated(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.WHITE_TEXT);
        #endregion

        #region KeyDown Events
        private void efiWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        cmdMenuOpen.PerformClick();
                        break;
                    case Keys.R:
                        cmdMenuReset.PerformClick();
                        break;
                    case Keys.C:
                        cmdMenuCopy.PerformClick();
                        break;
                    case Keys.L:
                        cmdMenuReload.PerformClick();
                        break;
                    case Keys.E:
                        cmdMenuExport.PerformClick();
                        break;
                    case Keys.P:
                        cmdMenuPatch.PerformClick();
                        break;
                    case Keys.T:
                        cmdMenuOptions.PerformClick();
                        break;
                }
            }
            else if ((e.Modifiers & Keys.Control) == Keys.Control && (e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.L:
                        cmdOpenInExplorer.PerformClick();
                        break;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void efiWindow_MouseMove(object sender, MouseEventArgs e)
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
                control.MouseMove += efiWindow_MouseMove;
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void cmdMinimize_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_SUPPORT_FIRMWARE
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    OpenBinary(openFileDialog.FileName);
            }
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
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
                    DIALOGSTRINGS.WARN_DATA_MATCHES_BUFF,
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
                ResetWindow();
                return;
            }

            DialogResult result =
                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.UNLOAD_FIRMWARE_RESET,
                    METMessageBoxType.Warning,
                    METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetWindow();
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

        private void cmdMenuPatch_Click(object sender, EventArgs e)
        {
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
                UITools.ShowContextMenuAtControlPoint(
                    sender,
                    cmsPatch,
                    MenuPosition.BottomLeft);
        }


        private void cmdMenuOptions_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsOptions,
            MenuPosition.BottomLeft);


        private void cmdNavigate_Click(object sender, EventArgs e)
        {
            // Navigate and highlight the file in explorer.
            FileUtils.HighlightPathInExplorer(
                EFIROM.LoadedBinaryPath);
        }
        #endregion

        #region Copy Toolstrip Events
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

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFirmwareConfigCode();

        private void fsysBaseAddressToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFsysBaseAddress();

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

        private void vSSBaseAddressToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetVssBaseAddress();

        private void sVSBaseAddressToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetSvsBaseAddress();

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

        #region Export Toolstrip Events
        private void exportFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{EFISTRINGS.FSYS}_{EFIROM.FsysStoreData.Serial}_{EFIROM.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.FSYS_DIR
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                // Save the Fsys stores bytes to disk.
                if (FileUtils.WriteAllBytesEx(
                    saveFileDialog.FileName,
                    EFIROM.FsysStoreData.FsysBytes) && File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlight(
                        this,
                        saveFileDialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.FSYS_EXPORT_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void exportIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IFD.ME_REGION_BASE == 0 || IFD.ME_REGION_LIMIT == 0)
            {
                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.IME_BASE_LIM_NOT_FOUND,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return;
            }

            Program.EnsureDirectoriesExist();

            // Set SaveFileDialog params.
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{EFISTRINGS.ME_REGION}_{EFIROM.FsysStoreData.Serial}_{EFIROM.EfiBiosIdSectionData.ModelPart}",
                OverwritePrompt = true,
                InitialDirectory = METPath.INTELME_DIR
            })
            {
                // Action was cancelled.
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                byte[] meBytes =
                    BinaryUtils.GetBytesBaseLength(
                        EFIROM.LoadedBinaryBytes,
                        (int)IFD.ME_REGION_BASE,
                        (int)IFD.ME_REGION_SIZE);

                if (FileUtils.WriteAllBytesEx(saveFileDialog.FileName, meBytes) && File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlight(
                        this,
                        saveFileDialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.IME_EXPORT_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void exportNVRAMVSSStoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportNVRAM(
                EFIROM.VssStoreData.PrimaryStoreBytes,
                EFIROM.VssStoreData.BackupStoreBytes,
                EFISTRINGS.VSS);
        }

        private void exportNVRAMSVSStoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportNVRAM(
                EFIROM.SvsStoreData.PrimaryStoreBytes,
                EFIROM.SvsStoreData.BackupStoreBytes,
                EFISTRINGS.SVS);
        }

        public void ExportNVRAM(byte[] primaryStore, byte[] backupStore, string storeType)
        {
            Program.EnsureDirectoriesExist();

            if (primaryStore != null && backupStore != null)
            {
                SaveFilesInFolder(primaryStore, backupStore, storeType);
                return;
            }

            var fileToSave =
                primaryStore ??
                backupStore;

            if (fileToSave != null)
            {
                SaveSingleFile(fileToSave, storeType);
                return;
            }
        }

        private void SaveFilesInFolder(byte[] primaryStore, byte[] backupStore, string storeType)
        {
            using (var folderDialog = new FolderBrowserDialog
            {
                Description = APPSTRINGS.SELECT_FOLDER,
                SelectedPath = METPath.NVRAM_DIR
            })
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath =
                        Path.Combine(folderDialog.SelectedPath,
                        $"{storeType}_{EFIROM.FileInfoData.FileName}");

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    SaveFile(
                        Path.Combine(
                            folderPath,
                            $"{storeType}_PRIMARY_REGION_{EFIROM.FileInfoData.FileName}.bin"),
                        primaryStore);

                    SaveFile(
                        Path.Combine(
                            folderPath,
                            $"{storeType}_BACKUP_REGION_{EFIROM.FileInfoData.FileName}.bin"),
                       backupStore);

                    UITools.ShowExplorerDirectory(
                        this,
                        folderPath);
                }
            }
        }

        private void SaveSingleFile(byte[] fileToSave, string storeType)
        {
            string defaultFileName =
                fileToSave ==
                    EFIROM.VssStoreData.PrimaryStoreBytes
                        ? $"{storeType}_PRIMARY_REGION_{EFIROM.FileInfoData.FileName}.bin"
                        : $"{storeType}_BACKUP_REGION_{EFIROM.FileInfoData.FileName}.bin";

            using (var saveDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = defaultFileName,
                InitialDirectory = METPath.NVRAM_DIR
            })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(
                        saveDialog.FileName,
                        fileToSave);

                    UITools.ShowExplorerFileHighlight(
                        this,
                        saveDialog.FileName);
                }
            }
        }

        private void SaveFile(string filePath, byte[] fileData) =>
            File.WriteAllBytes(filePath, fileData);

        private void backupFirmwareZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = METPath.BACKUPS_DIR,
                Filter = APPSTRINGS.FILTER_ZIP,
                FileName = $"{EFIROM.FileInfoData.FileName}_{EFISTRINGS.BACKUP.ToLower()}",
                OverwritePrompt = true
            })
            {
                // Action was cancelled
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                FileUtils.BackupFileToZip(
                    EFIROM.LoadedBinaryBytes,
                    EFIROM.FileInfoData.FileNameExt,
                    saveFileDialog.FileName);

                if (File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlight(
                        this,
                        saveFileDialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.ARCHIVE_CREATE_FAILED,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
            }
        }

        private void exportFirmwareInformationTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{EFISTRINGS.FIRMWARE_INFO}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
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
                    saveFileDialog.FileName,
                    builder.ToString());

                if (!File.Exists(saveFileDialog.FileName))
                {
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlight(
                 this,
                 saveFileDialog.FileName);
            }
        }
        #endregion

        #region Patch Toolstrip Events
        private void changeSerialNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UITools.SetHalfOpacity(this);

            using (ssnWindow child = new ssnWindow())
            {
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();

                if (child.DialogResult == DialogResult.OK)
                {
                    PatchSSN(EFIROM.NewSSN);
                }
            }
        }

        private void replaceFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteToAppLog(
                $"{LOGSTRINGS.PATCH_START} " +
                $"{LOGSTRINGS.FSYS_REPLACE}");

            using (OpenFileDialog openFileDialog = CreateFsysOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.PATCH_END} " +
                        $"{LOGSTRINGS.FSYS_IMPORT_CANCELLED}");

                    return;
                }

                byte[] newFsysStore =
                    LoadFileBytes(
                        openFileDialog.FileName);

                if (!ValidateFsysStore(newFsysStore))
                    return;

                Logger.WriteToAppLog(
                    LOGSTRINGS.VALIDATION_PASS);

                FsysStore fsysStore =
                    EFIROM.GetFsysStoreData(
                        newFsysStore,
                        true);

                LogFsysStoreDetails(fsysStore);

                if (!ValidateFsysCrc(fsysStore, ref newFsysStore))
                    return;

                byte[] newImage =
                    EFIROM.LoadedBinaryBytes;

                if (!WriteNewFsysStore(newImage, newFsysStore))
                    return;

                Logger.WriteToAppLog(
                    LOGSTRINGS.FSYS_WRITE_SUCCESS);

                // Prompt the user to save changes
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.FSYS_PATCH_SUCCESS_SAVE,
                        METMessageBoxType.Question,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SaveOutputFirmware(newImage);
                    return;
                }

                Logger.WriteToAppLog(
                   $"{LOGSTRINGS.PATCH_END} " +
                   $"{LOGSTRINGS.FILE_EXPORT_CANCELLED}");
            }
        }

        private void replaceIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Logger.WriteToAppLog(
                $"{LOGSTRINGS.PATCH_START} " +
                $"{LOGSTRINGS.IME_REPLACE}");

            using (OpenFileDialog openFileDialog = CreateImeOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.PATCH_END} " +
                        $"{LOGSTRINGS.IME_IMPORT_CANCELLED}");

                    return;
                }

                byte[] imeBuffer =
                    LoadFileBytes(
                        openFileDialog.FileName);

                if (!ValidateMeRegion(imeBuffer))
                    return;

                Logger.WriteToAppLog(
                    LOGSTRINGS.VALIDATION_PASS);

                string imeVersion =
                    IME.GetVersionData(
                    imeBuffer,
                    VersionType.ManagementEngine);

                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.IME_VERSION} " +
                    $"{imeVersion}" ??
                    APPSTRINGS.NOT_FOUND);

                byte[] binaryBuffer =
                    EFIROM.LoadedBinaryBytes;

                if (!WriteNewMeRegion(imeBuffer, binaryBuffer))
                    return;

                Logger.WriteToAppLog(
                    LOGSTRINGS.IME_WRITE_SUCCESS);

                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.IME_PATCH_SUCCESS_SAVE,
                        METMessageBoxType.Question,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SaveOutputFirmware(binaryBuffer);
                    return;
                }

                Logger.WriteToAppLog(
                   $"{LOGSTRINGS.PATCH_END} " +
                   $"{LOGSTRINGS.FILE_EXPORT_CANCELLED}");
            }
        }

        private void resetNVRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UITools.SetHalfOpacity(this);

            using (nvramWindow child = new nvramWindow())
            {
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();

                if (child.DialogResult == DialogResult.OK)
                {
                    ResetNVRAM(EFIROM.bResetVss, EFIROM.bResetSvs);
                }
            }
        }

        private void fixFsysChecksumCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{EFISTRINGS.CRC_FIXED}_{EFIROM.FileInfoData.FileName}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled.
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                // Make binary with patched Fsys crc.
                byte[] patchedBinary =
                    BinaryUtils.MakeFsysCrcPatchedBinary(
                        EFIROM.LoadedBinaryBytes,
                        EFIROM.FsysStoreData.FsysBase,
                        EFIROM.FsysStoreData.FsysBytes,
                        EFIROM.FsysStoreData.CRC32CalcInt);

                // Ask if user wants to open the repaired file.
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.FSYS_SUM_PATCH_SUCCESS,
                        METMessageBoxType.Information,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(saveFileDialog.FileName);
            }
        }

        private void invalidateEFILockToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{EFISTRINGS.UNLOCKED}_{EFIROM.FileInfoData.FileName}.bin",
                OverwritePrompt = true,
                InitialDirectory = _strInitialDirectory
            })
            {
                // Action was cancelled.
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                bool buildFailed = false;

                // Clone the loaded binary.
                byte[] binaryBuffer = EFIROM.LoadedBinaryBytes;

                // Create store buffers.
                byte[] unlockedPrimaryStore = null;
                byte[] unlockedBackupStore = null;

                // Create a patched primary store.
                unlockedPrimaryStore =
                    BinaryUtils.PatchSvsStoreMac(
                        EFIROM.SvsStoreData.PrimaryStoreBytes,
                        EFIROM.EfiPrimaryLockData.LockCrcBase);

                // Write patched primary store the buffer
                BinaryUtils.OverwriteBytesAtBase(
                    binaryBuffer,
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

                    // Write patched backup store to the buffer.
                    BinaryUtils.OverwriteBytesAtBase(
                        binaryBuffer,
                        EFIROM.SvsStoreData.BackupStoreBase,
                        unlockedBackupStore);
                }

                // Load SVS NVRAM stores from the buffer.
                NvramStore svsStore =
                    EFIROM.GetNvramStoreData(
                        binaryBuffer,
                        NvramStoreType.SVS);

                // Check patched primary store matches the patched buffer.
                if (!BinaryUtils.ByteArraysMatch(svsStore.PrimaryStoreBytes, unlockedPrimaryStore))
                {
                    Logger.WriteToAppLog(
                        $"{EFISTRINGS.PRIMARY_STORE_BUFFER_MISMATCH}");

                    buildFailed = true;
                }

                // Check patched backup store matches the patched buffer (if backup store is ! null).
                if (unlockedBackupStore != null)
                {
                    if (!BinaryUtils.ByteArraysMatch(svsStore.BackupStoreBytes, unlockedBackupStore))
                    {
                        Logger.WriteToAppLog(
                            $"{EFISTRINGS.BACKUP_STORE_BUFFER_MISMATCH}");

                        buildFailed = true;
                    }
                }

                // The build failed flag was set.
                if (buildFailed)
                {
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.EFI_LOCK_FAIL,
                        METMessageBoxType.Error,
                        METMessageBoxButtons.YesNo);

                    return;
                }

                // Ask if user wants to open the patched file.
                DialogResult result =
                    METMessageBox.Show(
                        this,
                        DIALOGSTRINGS.EFI_LOCK_SUCCESS,
                        METMessageBoxType.Information,
                        METMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    OpenBinary(saveFileDialog.FileName);
            }
        }
        #endregion

        #region Options Toolstrip Events
        private void automaticFilenameGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string efiModel =
                EFIROM.EfiBiosIdSectionData.ModelPart
                ?? EFISTRINGS.NOMODEL;

            string systemSerial =
                EFIROM.FsysStoreData.Serial
                ?? EFISTRINGS.NOSERIAL;

            if (MacUtils.IsValidAppleSerial(systemSerial))
                systemSerial = EFISTRINGS.NOSERIAL;

            string efiversion =
                EFIROM.FirmwareVersion
                ?? EFISTRINGS.NOFWVER;

            SetClipboardText($"{efiModel}_{systemSerial}_{efiversion}");
        }

        private void viewRomInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set window half opacity.
            UITools.SetHalfOpacity(this);

            // Open the Rom Information Window.
            using (Form formWindow = new infoWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void lookupSerialNumberOnEveryMacToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start($"https://everymac.com/ultimate-mac-lookup/?search_keywords={EFIROM.FsysStoreData.Serial}");
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
            UpdateBoardIdControls();
            UpdateNvramControls();
            UpdateEfiLockControls();
            UpdateApfsCapableControls();
            UpdateIntelFitControls();
            UpdateDescriptorModeControls();
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

            // Set window text.
            this.Text =
                EFIROM.FileInfoData.FileNameExt ??
                APPSTRINGS.EFIROM;

            // Check and set control enable.
            ToggleControlEnable(true);
        }

        private void UpdateFileNameControls() =>
            lblFilename.Text = $"{EFISTRINGS.FILE}: '{EFIROM.FileInfoData.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            int fileSizeDecimal =
                EFIROM.FileInfoData.Length;

            bool isValidSize =
                FileUtils.GetIsValidBinSize(
                    fileSizeDecimal);

            lblFilesize.Text =
                $"{FileUtils.FormatFileSize(fileSizeDecimal)} {EFISTRINGS.BYTES} ({fileSizeDecimal:X}h)";

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
                    ?? APPSTRINGS.NA;

                modelToolStripMenuItem.Enabled = true;

                return;
            }

            lblModel.Text = APPSTRINGS.NA;
            modelToolStripMenuItem.Enabled = false;
        }

        private void UpdateConfigCodeControls()
        {
            if (!string.IsNullOrEmpty(EFIROM.ConfigCode))
            {
                lblConfigCode.Text = EFIROM.ConfigCode;

                configurationToolStripMenuItem.Enabled = true;

                return;
            }

            lblConfigCode.Text = APPSTRINGS.CONTACT_SERVER;
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

                configurationToolStripMenuItem.Enabled = true;

                return;
            }

            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.CONTROL_DISABLED_TEXT;

            configurationToolStripMenuItem.Enabled = false;
        }

        private void UpdateFsysControls()
        {
            if (EFIROM.FsysStoreData.FsysBase != -1)
            {
                lblFsysStore.Text =
                    $"0x{EFIROM.FsysStoreData.FsysBase:X2}h";

                bool crcMatch =
                    string.Equals(
                        EFIROM.FsysStoreData.CrcString,
                        EFIROM.FsysStoreData.CrcCalcString);

                if (!string.IsNullOrEmpty(EFIROM.FsysStoreData.CrcString))
                {
                    lblFsysStore.Text +=
                        crcMatch ?
                        " (VALID CRC)" :
                        " (INVALID CRC)";
                    lblFsysStore.ForeColor =
                        crcMatch ?
                        lblFsysStore.ForeColor :
                        AppColours.WARNING;
                }

                if (EFIROM.ForceFoundFsys)
                    lblFsysStore.Text += " [F]";


                fsysBaseAddressToolStripMenuItem.Enabled = true;
                fsysCRC32ToolStripMenuItem.Enabled = true;

                return;
            }

            fsysBaseAddressToolStripMenuItem.Enabled = false;
            fsysCRC32ToolStripMenuItem.Enabled = false;
            lblFsysStore.Text = APPSTRINGS.NA;
        }

        private void UpdateSerialNumberControls()
        {
            string serialNumber =
                EFIROM.FsysStoreData.Serial;

            lblSerialNumber.Text =
                serialNumber
                ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(serialNumber))
            {
                // Prototype in testing
                if (!MacUtils.IsValidAppleSerial(serialNumber))
                    lblSerialNumber.ForeColor = AppColours.WARNING;

                lblSerialNumber.Text +=
                    (serialNumber.Length == 11 || serialNumber.Length == 12)
                    ? $" ({serialNumber.Length})"
                    : string.Empty;

                serialToolStripMenuItem.Enabled = true;

                return;
            }

            serialToolStripMenuItem.Enabled = false;
        }

        private void UpdateHardwareConfigControls()
        {
            string hwc =
                EFIROM.FsysStoreData.HWC;

            lblHwc.Text =
                 hwc
                 ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(hwc))
            {
                hwcToolStripMenuItem.Enabled = true;

                return;
            }

            hwcToolStripMenuItem.Enabled = false;
        }

        private void UpdateOrderNumberControls()
        {
            string orderNumber =
                EFIROM.FsysStoreData.SON;

            lblOrderNumber.Text =
                orderNumber
                ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(orderNumber))
            {
                orderNoToolStripMenuItem.Enabled = true;

                return;
            }

            orderNoToolStripMenuItem.Enabled = false;
        }

        private void UpdateEfiVersionControls()
        {
            string efiVersion =
                EFIROM.FirmwareVersion;

            lblEfiVersion.Text =
                efiVersion
                ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(efiVersion))
            {
                efiVersionToolStripMenuItem.Enabled = true;

                return;
            }

            efiVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateBoardIdControls()
        {
            string boardId =
                EFIROM.PdrSectionData.BoardId;

            lblBoardId.Text =
                boardId
                ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(boardId))
            {
                boardIDToolStripMenuItem.Enabled = true;

                return;
            }

            boardIDToolStripMenuItem.Enabled = false;
        }

        private void UpdateNvramControls()
        {
            // Retrieve base addresses and empty states
            int vssBase = EFIROM.VssStoreData.PrimaryStoreBase;
            int svsBase = EFIROM.SvsStoreData.PrimaryStoreBase;
            bool isVssEmpty = EFIROM.VssStoreData.IsPrimaryStoreEmpty;
            bool isSvsEmpty = EFIROM.SvsStoreData.IsPrimaryStoreEmpty;

            // Update labels and menu items
            UpdateStoreDisplay(lblVss, vSSBaseAddressToolStripMenuItem, vssBase, isVssEmpty);
            UpdateStoreDisplay(lblSvs, sVSBaseAddressToolStripMenuItem, svsBase, isSvsEmpty);
        }

        // Helper method to update label text and menu item enabled state
        private void UpdateStoreDisplay(Label label, ToolStripMenuItem menuItem, int baseAddress, bool isEmpty)
        {
            if (baseAddress != -1)
            {
                label.Text = $"0x{baseAddress:X2}h {(isEmpty ? "[Empty]" : string.Empty)}";
                menuItem.Enabled = true;
            }
            else
            {
                label.Text = APPSTRINGS.NA;
                menuItem.Enabled = false;
            }
        }


        private void UpdateEfiLockControls()
        {
            switch (EFIROM.EfiPrimaryLockData.LockType)
            {
                case EfiLockType.Locked:
                    lblEfiLock.Text = EFISTRINGS.LOCKED.ToUpper();
                    lblEfiLock.ForeColor = AppColours.WARNING;
                    break;
                case EfiLockType.Unlocked:
                    lblEfiLock.Text = EFISTRINGS.UNLOCKED.ToUpper();
                    break;
                case EfiLockType.Unknown:
                default:
                    lblEfiLock.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblEfiLock.ForeColor = AppColours.WARNING;
                    break;
            }
        }

        private void UpdateApfsCapableControls()
        {
            switch (EFIROM.IsApfsCapable)
            {
                case ApfsCapable.Yes:
                    lblApfsCapable.Text = EFISTRINGS.APFS_DRIVER_FOUND;
                    break;
                case ApfsCapable.No:
                    lblApfsCapable.Text = EFISTRINGS.APFS_DRIVER_NOT_FOUND;
                    lblApfsCapable.ForeColor = AppColours.WARNING;
                    break;
                case ApfsCapable.Unknown:
                    lblApfsCapable.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblApfsCapable.ForeColor = AppColours.WARNING;
                    break;
            }
        }

        private void UpdateDescriptorModeControls() =>
            lblDescriptorMode.Text = $"{IFD.IsDescriptorMode}";

        private void UpdateIntelMeControls()
        {
            string meVersion =
                EFIROM.MeVersion;

            lblMeVersion.Text =
                meVersion
                ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(meVersion))
            {
                if (IFD.ME_REGION_BASE != 0)
                    if (!string.IsNullOrEmpty(meVersion))
                        lblMeVersion.Text += $" (0x{IFD.ME_REGION_BASE:X}h)";

                meVersionToolStripMenuItem.Enabled = true;

                return;
            }

            meVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateIntelFitControls() =>
            fitVersionToolStripMenuItem.Enabled =
                !string.IsNullOrEmpty(EFIROM.FitVersion) ?
                true :
                false;
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
            Button[] menuButtons =
            {
                cmdMenuReset,
                cmdMenuCopy,
                cmdMenuReload,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuOptions,
                cmdOpenInExplorer,
                };

            void EnableButtons(params Button[] buttons)
            {
                foreach (Button button in buttons)
                    button.Enabled = enable;
            }

            if (!enable)
            {
                EnableButtons(menuButtons);
            }
            else
            {
                EnableButtons(menuButtons);

                bool modelPartExists =
                    EFIROM.EfiBiosIdSectionData.ModelPart
                    != null;

                bool fsysBytesExist =
                    EFIROM.FsysStoreData.FsysBytes
                    != null;

                bool fsysCrcMismatch = fsysBytesExist &&
                    !string.Equals(EFIROM.FsysStoreData.CrcCalcString,
                        EFIROM.FsysStoreData.CrcString);

                bool isAppleFirmware =
                    modelPartExists
                    && fsysBytesExist;

                // Export Menu
                exportFsysStoreToolStripMenuItem.Enabled =
                    fsysBytesExist;

                exportIntelMERegionToolStripMenuItem.Enabled =
                    IFD.IsDescriptorMode &&
                    IFD.ME_REGION_BASE != 0 &&
                    IFD.ME_REGION_LIMIT != 0;

                exportNVRAMVSSStoresToolStripMenuItem.Enabled =
                    EFIROM.VssStoreData.PrimaryStoreBase != -1 &&
                    !EFIROM.VssStoreData.IsPrimaryStoreEmpty;

                exportNVRAMSVSStoresToolStripMenuItem.Enabled =
                    EFIROM.SvsStoreData.PrimaryStoreBase != -1 &&
                    !EFIROM.SvsStoreData.IsPrimaryStoreEmpty;

                // Patch Menu
                changeSerialNumberToolStripMenuItem.Enabled =
                    EFIROM.FsysStoreData.FsysBase != -1 &&
                    EFIROM.FsysStoreData.SerialBase != -1;

                replaceFsysStoreToolStripMenuItem.Enabled =
                    EFIROM.FsysStoreData.FsysBase != -1;

                resetNVRAMToolStripMenuItem.Enabled =
                    !EFIROM.VssStoreData.IsPrimaryStoreEmpty ||
                    !EFIROM.SvsStoreData.IsPrimaryStoreEmpty;

                fixFsysChecksumCRC32ToolStripMenuItem.Enabled =
                    fsysCrcMismatch;

                invalidateEFILockToolStripMenuItem.Enabled =
                    EFIROM.EfiPrimaryLockData.LockType == EfiLockType.Locked;

                // Options Menu
                viewRomInformationToolStripMenuItem.Enabled =
                    EFIROM.AppleRomInfoSectionData.SectionExists;

                lookupSerialNumberOnEveryMacToolStripMenuItem.Enabled =
                    !string.IsNullOrEmpty(EFIROM.FsysStoreData.Serial) &&
                    MacUtils.IsValidAppleSerial(EFIROM.FsysStoreData.Serial);
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
                cmdMenuOpen,
                cmdMenuReset,
                cmdMenuCopy,
                cmdMenuReload,
                cmdOpenInExplorer,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuOptions
            };

            Label[] labels =
            {
                lblVss,
                lblSvs,
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
                    { cmdMenuOpen, $"{EFISTRINGS.MENU_TIP_OPEN} (CTRL + O)" },
                    { cmdMenuReset, $"{EFISTRINGS.MENU_TIP_RESET} (CTRL + R)" },
                    { cmdMenuCopy, $"{EFISTRINGS.MENU_TIP_COPY} (CTRL + C)" },
                    { cmdMenuReload, $"{EFISTRINGS.MENU_TIP_RELOAD} (CTRL + L)" },
                    { cmdMenuExport, $"{EFISTRINGS.MENU_TIP_EXPORT} (CTRL + E)"},
                    { cmdMenuPatch, $"{EFISTRINGS.MENU_TIP_PATCH} (CTRL + P)"},
                    { cmdMenuOptions, $"{EFISTRINGS.MENU_TIP_OPTIONS} (CTRL + T)"},
                    { cmdOpenInExplorer, $"{EFISTRINGS.MENU_TIP_OPENFILELOCATION} (CTRL + SHIFT + L)" }
                };

                if (tooltips.ContainsKey(sender))
                    lblStatusBarTip.Text = tooltips[sender];
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e) =>
            lblStatusBarTip.Text = string.Empty;

        void ApplyNestedPanelLabelForeColor(TableLayoutPanel tableLayoutPanel, Color color)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label && label.Text == APPSTRINGS.NA)
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
        internal void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory =
                Settings.ReadString(SettingsStringType.EfiInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory)
                    ? directory
                    : METPath.WORKING_DIR;
            }
        }

        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            // If a firmware is loaded, reset all data.
            if (EFIROM.FirmwareLoaded)
                ResetWindow();

            // Check the filesize
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
            {
                ResetWindow();
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
                    DIALOGSTRINGS.FILE_NOT_VALID,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                ResetWindow();

                return;
            }

            // Show loading resource.
            pbxLoad.Image = Properties.Resources.loading;

            // Set the current initial directory.
            _strInitialDirectory = Path.GetDirectoryName(filePath);

            // Load the firmware base in a separate thread.
            _tLoadFirmware = new Thread(() => LoadFirmwareBase(filePath, _cancellationToken.Token))
            {
                IsBackground = true
            };

            _tLoadFirmware.Start();
        }

        private void LoadFirmwareBase(string filePath, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            EFIROM.LoadFirmwareBaseData(
                EFIROM.LoadedBinaryBytes,
                filePath);

            if (cancellationToken.IsCancellationRequested)
                return;

            if (this.IsHandleCreated && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateUI();
                    });
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }

            if (!cancellationToken.IsCancellationRequested)
                EFIROM.FirmwareLoaded = true;
        }

        private void ResetWindow()
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
                lblFsysStore,
                lblDescriptorMode,
                lblOrderNumber,
                lblEfiVersion,
                lblVss,
                lblSvs,
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

            // Reset window text
            Text = APPSTRINGS.EFIROM;

            // Reset initial directory.
            SetInitialDirectory();

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

            if (!Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                METMessageBox.Show(
                    this,
                    $"'{text}' {EFISTRINGS.COPIED_TO_CB_LC}",
                    METMessageBoxType.Information,
                    METMessageBoxButtons.Okay);
            }
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
            MacUtils.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart));

        private void ClipboardSetFirmwareConfigCode() => SetClipboardText(
            EFIROM.ConfigCode);

        private void ClipboardSetFsysBaseAddress() => SetClipboardText(
            $"0x{EFIROM.FsysStoreData.FsysBase:X2}h");

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

        private void ClipboardSetVssBaseAddress() => SetClipboardText(
            $"0x{EFIROM.VssStoreData.PrimaryStoreBase:X2}h");

        private void ClipboardSetSvsBaseAddress() => SetClipboardText(
            $"0x{EFIROM.SvsStoreData.PrimaryStoreBase:X2}h");

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

        #region Patching
        private OpenFileDialog CreateFsysOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = METPath.FSYS_DIR,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateFsysStore(byte[] fsysStore)
        {
            int sigBase =
                BinaryUtils.GetBaseAddress(
                    fsysStore,
                    EFIROM.FSYS_SIG);

            if (fsysStore.Length != EFIROM.FSYS_RGN_SIZE)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.EXPECTED_STORE_SIZE_NOT} " +
                    $"{EFIROM.FSYS_RGN_SIZE:X2}h ({fsysStore.Length:X2}h)");

                NotifyPatchingFailure();
                return false;
            }
            else if (sigBase != 0)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.STORE_SIG_MISALIGNED} ({sigBase:X2}h)");

                NotifyPatchingFailure();
                return false;
            }

            return true;
        }

        private void LogFsysStoreDetails(FsysStore fsysStore)
        {
            Logger.WriteToAppLog(
                $"{LOGSTRINGS.NEW_SERIAL} " +
                $"{fsysStore.Serial} | " +
                $"{LOGSTRINGS.LENGTH} " +
                $"{fsysStore.Serial.Length}");

            Logger.WriteToAppLog(
                $"{LOGSTRINGS.NEW_HWC} " +
                $"{fsysStore.HWC} | " +
                $"{LOGSTRINGS.LENGTH} " +
                $"{fsysStore.HWC.Length}");
        }

        private bool ValidateFsysCrc(FsysStore fsysStore, ref byte[] newFsysStore)
        {
            if (!string.Equals(fsysStore.CrcString, fsysStore.CrcCalcString))
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.FSYS_SUM_INVALID} " +
                    $"({LOGSTRINGS.FOUND} {fsysStore.CrcString}, " +
                    $"{LOGSTRINGS.CALCULATED} {fsysStore.CrcCalcString})");

                Logger.WriteToAppLog(
                    LOGSTRINGS.MASKING_SUM);

                newFsysStore =
                    BinaryUtils.PatchFsysCrc(
                        fsysStore.FsysBytes,
                        fsysStore.CRC32CalcInt);

                fsysStore =
                    EFIROM.GetFsysStoreData(
                        newFsysStore,
                        true);

                if (!string.Equals(fsysStore.CrcString, fsysStore.CrcCalcString))
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.PATCH_END} " +
                        $"{LOGSTRINGS.SUM_MASKING_FAIL}");

                    NotifyPatchingFailure();
                    return false;
                }
                else
                {
                    Logger.WriteToAppLog(
                        LOGSTRINGS.FSYS_SUM_MASK_SUCCESS);
                }
            }

            return true;
        }

        private bool WriteNewFsysStore(byte[] newImage, byte[] newFsysStore)
        {
            BinaryUtils.OverwriteBytesAtBase(
                newImage,
                EFIROM.FsysStoreData.FsysBase,
                newFsysStore);

            FsysStore fsysFromNewBin =
                EFIROM.GetFsysStoreData(
                    newImage,
                    false);

            if (!BinaryUtils.ByteArraysMatch(fsysFromNewBin.FsysBytes, newFsysStore))
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.STORE_COMP_FAILED}");

                NotifyPatchingFailure();
                return false;
            }

            return true;
        }

        private OpenFileDialog CreateImeOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = METPath.INTELME_DIR,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateMeRegion(byte[] meRegion)
        {
            int fptBase =
                BinaryUtils.GetBaseAddress(
                    meRegion,
                    IME.FPT_SIGNATURE);

            if (fptBase == -1)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.IME_FPT_NOT_FOUND}");

                NotifyPatchingFailure();
                return false;
            }

            if (meRegion.Length > IFD.ME_REGION_SIZE)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.IME_TOO_LARGE} " +
                    $"{meRegion.Length:X2}h > {IFD.ME_REGION_SIZE}h");

                NotifyPatchingFailure();
                return false;
            }

            if (meRegion.Length < IFD.ME_REGION_SIZE)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.IME_TOO_SMALL} " +
                    $"{meRegion.Length:X2}h > {IFD.ME_REGION_SIZE}h");
            }

            return true;
        }

        private bool WriteNewMeRegion(byte[] imeBuffer, byte[] binaryBuffer)
        {
            byte[] ffBuffer =
                new byte[IFD.ME_REGION_SIZE];

            BinaryUtils.EraseByteArray(ffBuffer, 0xFF);

            Array.Copy(imeBuffer, 0, ffBuffer, 0, imeBuffer.Length);

            Array.Copy(ffBuffer, 0, binaryBuffer, IFD.ME_REGION_BASE, ffBuffer.Length);

            byte[] patchedMeBuffer =
                BinaryUtils.GetBytesBaseLimit(
                    binaryBuffer,
                    (int)IFD.ME_REGION_BASE,
                    (int)IFD.ME_REGION_LIMIT);

            if (!BinaryUtils.ByteArraysMatch(patchedMeBuffer, ffBuffer))
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.IME_BUFFER_MISMATCH}");

                NotifyPatchingFailure();
                return false;
            }

            return true;
        }

        private void PatchSSN(string newSerial)
        {
            Logger.WriteToAppLog(
                $"{LOGSTRINGS.PATCH_START} " +
                $"{LOGSTRINGS.SSN_REPLACE}");

            // Check whether the serial base is present
            if (EFIROM.FsysStoreData.SerialBase == -1)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.SSN_BASE_NOT_FOUND}");

                NotifyPatchingFailure();
                return;
            }

            // Check if the HWC Base is present (if not we don't write the new one)
            bool isHwcBasePresent = EFIROM.FsysStoreData.HWCBase != -1;
            string newHwc = null;

            // Clone EFIROM.LoadedBinary
            byte[] binaryBuffer = EFIROM.LoadedBinaryBytes;

            // Convert string to byte
            byte[] newSerialBytes = Encoding.UTF8.GetBytes(newSerial);

            // Overwrite serial in binary buffer
            BinaryUtils.OverwriteBytesAtBase(
                binaryBuffer,
                EFIROM.FsysStoreData.SerialBase,
                newSerialBytes);

            // Check whether to write the new hwc
            if (isHwcBasePresent)
            {
                newHwc =
                    EFIROM.FsysStoreData.Serial.Length == 11
                        ? newSerial.Substring(8, 3)
                        : newSerial.Substring(8, 4);

                byte[] newHwcBytes = Encoding.UTF8.GetBytes(newHwc);

                // Write new hwc
                BinaryUtils.OverwriteBytesAtBase(
                    binaryBuffer,
                    EFIROM.FsysStoreData.HWCBase,
                    newHwcBytes);
            }

            // Load patched fsys from binary buffer
            FsysStore fsys =
                EFIROM.GetFsysStoreData(
                    binaryBuffer,
                    false);

            // Check serial was written properly
            if (!string.Equals(newSerial, fsys.Serial))
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.SSN_NOT_WRITTEN}");

                NotifyPatchingFailure();
                return;
            }

            // Check the hwc was written properly
            if (fsys.HWCBase != 0)
            {
                if (!string.Equals(newHwc, fsys.HWC))
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.PATCH_END} " +
                        $"{LOGSTRINGS.HWC_NOT_WRITTEN}");

                    NotifyPatchingFailure();
                    return;
                }
            }

            // Patch fsys checksum in the binary buffer
            binaryBuffer =
                BinaryUtils.MakeFsysCrcPatchedBinary(
                    binaryBuffer,
                    fsys.FsysBase,
                    fsys.FsysBytes,
                    fsys.CRC32CalcInt);

            // Reload fsys store from the binary buffer
            fsys =
                EFIROM.GetFsysStoreData(
                    binaryBuffer,
                    false);

            // Check fsys to determine whether the new crc was masked successfully
            if (!string.Equals(fsys.CrcString, fsys.CrcCalcString))
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.FSYS_SUM_MASK_FAIL}");

                NotifyPatchingFailure();
                return;
            }

            Logger.WriteToAppLog(
                $"{LOGSTRINGS.PATCH_END} " +
                $"{LOGSTRINGS.SSN_WRITE_SUCCESS}");

            SaveOutputFirmware(binaryBuffer);
        }

        private SaveFileDialog CreateSaveFileDialog()
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = EFIROM.FileInfoData.FileName + "_outimage.bin",
                OverwritePrompt = true,
                InitialDirectory = METPath.BUILDS_DIR
            };
        }

        private void SaveOutputFirmware(byte[] newImage)
        {
            using (SaveFileDialog saveFileDialog = CreateSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.FILE_EXPORT_CANCELLED}");

                    return;
                }

                if (FileUtils.WriteAllBytesEx(saveFileDialog.FileName, newImage)
                    && File.Exists(saveFileDialog.FileName))
                {
                    Logger.WriteToAppLog(
                        $"{LOGSTRINGS.FILE_SAVE_SUCCESS} {saveFileDialog.FileName}");

                    DialogResult result =
                        METMessageBox.Show(
                            this,
                            DIALOGSTRINGS.FW_SAVED_SUCCESS_LOAD,
                            METMessageBoxType.Question,
                            METMessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                        OpenBinary(saveFileDialog.FileName);
                }
            }
        }

        private byte[] LoadFileBytes(string fileName)
        {
            try
            {
                return File.ReadAllBytes(fileName);
            }
            catch (Exception ex)
            {
                Logger.WriteToAppLog(
                    $"{LOGSTRINGS.PATCH_END} " +
                    $"{LOGSTRINGS.ERROR_FILE_BYTES} " +
                    $"{ex.Message}");

                NotifyPatchingFailure();
                return null;
            }
        }

        private void NotifyPatchingFailure()
        {
            DialogResult result =
                METMessageBox.Show(
                    this,
                    DIALOGSTRINGS.PATCH_FAIL_APP_LOG,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Logger.ViewLogFile(this);
        }

        private void ResetNVRAM(bool resetVss, bool resetSvs)
        {
            // TODO
        }
        #endregion
    }
}