// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmEfiRom.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmEfiRom : METForm
    {
        #region Private Members
        private string _strInitialDirectory = METPath.WORKING_DIR;
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        #endregion

        #region Constructor
        public frmEfiRom()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);

            // Set tip handlers for controls.
            SetTipHandlers();

            // Set button properties.
            SetButtonFontAndGlyph();

            // Set label properties.
            SetLabelFontAndGlyph();
        }

        private void WireEventHandlers()
        {
            Load += frmEfiRom_Load;
            FormClosing += frmEfiRom_FormClosing;
            FormClosed += frmEfiRom_FormClosed;
            KeyDown += frmEfiRom_KeyDown;
            DragEnter += frmEfiRom_DragEnter;
            DragDrop += frmEfiRom_DragDrop;
            Deactivate += frmEfiRom_Deactivate;
            Activated += frmEfiRom_Activated;
            lblFmmEmail.MouseEnter += lblFmmEmail_MouseEnter;
        }
        #endregion

        #region Window Events
        private void frmEfiRom_Load(object sender, EventArgs e)
        {
            // Get and set the primary file dialog initial directory.
            SetInitialDirectory();

            _cancellationToken = new CancellationTokenSource();

            if (!string.IsNullOrEmpty(Program.MAIN_WINDOW.loadedFile))
            {
                OpenBinary(Program.MAIN_WINDOW.loadedFile);
                Program.MAIN_WINDOW.loadedFile = null;
            }
        }

        private void frmEfiRom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.Cancel();
            }
        }

        private void frmEfiRom_FormClosed(object sender, FormClosedEventArgs e) => _cancellationToken?.Dispose();

        private void frmEfiRom_DragEnter(object sender, DragEventArgs e) => Program.HandleDragEnter(sender, e);

        private void frmEfiRom_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            // Open the binary file.
            OpenBinary(draggedFilename);
        }

        private void frmEfiRom_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.CLR_INACTIVEFORM);

        private void frmEfiRom_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.CLR_ACTIVEFORM);
        #endregion

        #region KeyDown Events
        private void frmEfiRom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

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
                        cmdMenuFolders.PerformClick();
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
                    case Keys.S:
                        cbxCensor.Checked = !cbxCensor.Checked;
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

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void cmdMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_EFI_SUPPORTED_FIRMWARE
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(openFileDialog.FileName);
                }
            }
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
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.UNLOAD_FIRMWARE_RESET,
                    METPromptType.Warning,
                    METPromptButtons.YesNo);

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

        private void cmdMenuFolders_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsFolders,
                MenuPosition.BottomLeft);

        private void cmdMenuExport_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsExport,
                MenuPosition.BottomLeft);

        private void cmdMenuPatch_Click(object sender, EventArgs e)
        {
            bool bOpenEditor = Settings.ReadBool(SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                BlurHelper.ApplyBlur(this);

                using (Form frm = new frmTerms())
                {
                    frm.FormClosed += ChildWindowClosed;
                    DialogResult result = frm.ShowDialog();
                    bOpenEditor = (result != DialogResult.No);
                }
            }

            if (bOpenEditor)
            {
                UITools.ShowContextMenuAtControlPoint(
                    sender,
                    cmsPatch,
                    MenuPosition.BottomLeft);
            }
        }

        private void cmdMenuOptions_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsOptions,
                MenuPosition.BottomLeft);

        private void cmdOpenInExplorer_Click(object sender, EventArgs e) => UITools.HighlightPathInExplorer(EFIROM.LoadedBinaryPath, this);
        #endregion

        #region Switch Events
        private void cbxCensor_CheckedChanged(object sender, EventArgs e) => UpdateSerialNumberControls();
        #endregion

        #region Label Events
        private void lblFmmEmail_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (EFIROM.FmmEmail == null)
            {
                label.Cursor = Cursors.Default;
                return;
            }

            label.Cursor = Cursors.Hand;
        }

        private void lblFmmEmail_Click(object sender, EventArgs e)
        {
            if (EFIROM.FmmEmail != null)
            {
                METPrompt.Show(this, EFIROM.FmmEmail, METPromptType.Information, METPromptButtons.Okay);
                return;
            }
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

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string serial = EFIROM.FsysStoreData.Serial;

            if (string.IsNullOrEmpty(serial))
            {
                return;
            }

            Clipboard.SetText(serial);

            if (!Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"{APPSTRINGS.SERIAL_NUMBER} " +
                    $"{EFISTRINGS.COPIED_TO_CB_LC}",
                    METPromptType.Information,
                    METPromptButtons.Okay);
            }
        }

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

        #region Folders Context Menu Events
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.BACKUPS_DIR, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.BUILDS_DIR, this);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.FSYS_DIR, this);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.INTELME_DIR, this);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.NVRAM_DIR, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.WORKING_DIR, this);
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
                {
                    return;
                }

                // Save the Fsys stores bytes to disk.
                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, EFIROM.FsysStoreData.FsysBytes) && File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.FSYS_EXPORT_FAIL,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }

        private void exportIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IFD.ME_REGION_BASE == 0 || IFD.ME_REGION_LIMIT == 0)
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.IME_BASE_LIM_NOT_FOUND,
                    METPromptType.Error,
                    METPromptButtons.Okay);

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
                {
                    return;
                }

                byte[] meBytes = BinaryTools.GetBytesBaseLength(EFIROM.LoadedBinaryBuffer, (int)IFD.ME_REGION_BASE, (int)IFD.ME_REGION_SIZE);

                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, meBytes) && File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.IME_EXPORT_FAIL,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }

        private void exportNVRAMVSSStoresToolStripMenuItem_Click(object sender, EventArgs e) =>
            ExportNVRAM(EFIROM.VssPrimary, EFIROM.VssSecondary, NvramStoreType.Variable, this);

        private void exportNVRAMSVSStoresToolStripMenuItem_Click(object sender, EventArgs e) =>
            ExportNVRAM(EFIROM.SvsPrimary, EFIROM.SvsSecondary, NvramStoreType.Secure, this);

        internal static void ExportNVRAM(NvramStore primaryStore, NvramStore secondaryStore, NvramStoreType storeType, Form owner)
        {
            Program.EnsureDirectoriesExist();

            switch (storeType)
            {
                case NvramStoreType.Variable:
                    SaveFilesInFolder(primaryStore.StoreBuffer, secondaryStore.StoreBuffer, "VSS", owner);
                    break;
                case NvramStoreType.Secure:
                    SaveFilesInFolder(primaryStore.StoreBuffer, secondaryStore.StoreBuffer, "SVS", owner);
                    break;
            }
        }

        private static void SaveFilesInFolder(byte[] primaryStore, byte[] backupStore, string storeType, Form owner)
        {
            using (var folderDialog = new FolderBrowserDialog
            {
                Description = APPSTRINGS.SELECT_FOLDER,
                SelectedPath = METPath.NVRAM_DIR
            })
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(folderDialog.SelectedPath, $"{storeType}_{EFIROM.FileInfoData.FileName}");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (primaryStore != null) SaveFile(Path.Combine(folderPath, $"{storeType}_{EFISTRINGS.PRIMARY_REGION}_{EFIROM.FileInfoData.FileName}.bin"), primaryStore);
                    if (backupStore != null) SaveFile(Path.Combine(folderPath, $"{storeType}_{EFISTRINGS.BACKUP_REGION}_{EFIROM.FileInfoData.FileName}.bin"), backupStore);

                    UITools.ShowOpenFolderInExplorerPromt(owner, folderPath);
                }
            }
        }

        private static void SaveFile(string filePath, byte[] fileData) => File.WriteAllBytes(filePath, fileData);

        private void exportLZMADXEArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_LZMA,
                FileName = $"{EFISTRINGS.DXE_ARCHIVE}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = METPath.LZMA_DIR
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Save the Fsys stores bytes to disk.
                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, EFIROM.LzmaDecompressedBuffer) && File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.ARCHIVE_EXPORT_FAIL,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }

        private void backupFirmwareZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = METPath.BACKUPS_DIR,
                Filter = APPSTRINGS.FILTER_ZIP,
                FileName = $"{EFIROM.FileInfoData.FileName}_{APPSTRINGS.EFIROM}_{APPSTRINGS.BACKUP}",
                OverwritePrompt = true
            })
            {
                // Action was cancelled
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileTools.BackupFileToZip(EFIROM.LoadedBinaryBuffer, EFIROM.FileInfoData.FileNameExt, saveFileDialog.FileName);

                if (File.Exists(saveFileDialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.ARCHIVE_CREATE_FAILED,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }

        private void exportFirmwareInformationTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{APPSTRINGS.FIRMWARE_INFO}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = METPath.WORKING_DIR
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("File");
                stringBuilder.AppendLine("----------------------------------");
                stringBuilder.AppendLine($"Filename:        {EFIROM.FileInfoData.FileNameExt}");
                stringBuilder.AppendLine($"Size (Bytes):    {FileTools.FormatFileSize(EFIROM.FileInfoData.Length)} bytes");
                stringBuilder.AppendLine($"Size (MB):       {Helper.GetBytesReadableSize(EFIROM.FileInfoData.Length)}");
                stringBuilder.AppendLine($"Size (Hex):      {EFIROM.FileInfoData.Length:X}h");
                stringBuilder.AppendLine($"CRC32:           {EFIROM.FileInfoData.CRC32:X}");
                stringBuilder.AppendLine($"Created:         {EFIROM.FileInfoData.CreationTime}");
                stringBuilder.AppendLine($"Modified:        {EFIROM.FileInfoData.LastWriteTime}\r\n");

                stringBuilder.AppendLine("Descriptor");
                stringBuilder.AppendLine("----------------------------------");
                if (IFD.IsDescriptorMode)
                {
                    stringBuilder.AppendLine(
                        $"PDR Region:      Base: {IFD.PDR_REGION_BASE:X}h, " +
                        $"Limit: {IFD.PDR_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.PDR_REGION_SIZE:X}h");
                    stringBuilder.AppendLine(
                        $"ME Region:       Base: {IFD.ME_REGION_BASE:X}h, " +
                        $"Limit: {IFD.ME_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.ME_REGION_SIZE:X}h");
                    stringBuilder.AppendLine(
                        $"BIOS Region:     Base: {IFD.BIOS_REGION_BASE:X}h, " +
                        $"Limit: {IFD.BIOS_REGION_LIMIT:X}h, " +
                        $"Size: {IFD.BIOS_REGION_SIZE:X}h\r\n");
                }
                else
                {
                    stringBuilder.AppendLine("Descriptor mode is disabled.\r\n");
                }

                stringBuilder.AppendLine("Model");
                stringBuilder.AppendLine("----------------------------------");
                stringBuilder.AppendLine($"Identifier:      {EFIROM.EfiBiosIdSectionData.ModelPart ?? "N/A"}");
                stringBuilder.AppendLine($"Model:           {MacTools.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart) ?? "N/A"}");
                stringBuilder.AppendLine($"Configuration:   {EFIROM.ConfigCode ?? "N/A"}");
                stringBuilder.AppendLine($"Board ID:        {EFIROM.PdrSectionData.BoardId ?? "N/A"}\r\n");

                stringBuilder.AppendLine("Fsys");
                stringBuilder.AppendLine("----------------------------------");
                if (EFIROM.FsysStoreData.FsysBytes != null)
                {
                    stringBuilder.AppendLine($"Base:            {EFIROM.FsysStoreData.FsysBase:X}h");
                    stringBuilder.AppendLine($"Size:            {EFIROM.FSYS_RGN_SIZE:X}h");
                    stringBuilder.AppendLine($"CRC32:           {EFIROM.FsysStoreData.CrcString ?? "N/A"}");
                    stringBuilder.AppendLine($"Serial:          {EFIROM.FsysStoreData.Serial ?? "N/A"}");
                    stringBuilder.AppendLine($"HWC:             {EFIROM.FsysStoreData.HWC ?? "N/A"}");
                    stringBuilder.AppendLine($"SON:             {EFIROM.FsysStoreData.SON ?? "N/A"}\r\n");
                }
                else
                {
                    stringBuilder.AppendLine("Fsys Store was not found.\r\n");
                }

                stringBuilder.AppendLine("Firmware");
                stringBuilder.AppendLine("----------------------------------");
                stringBuilder.AppendLine($"EFI Version:     {EFIROM.FirmwareVersion ?? "N/A"}");
                stringBuilder.AppendLine($"EFI Lock:        {EFIROM.EfiPrimaryLockData.LockType.ToString() ?? "N/A"}");
                stringBuilder.AppendLine($"APFS Capable:    {EFIROM.IsApfsCapable.ToString() ?? "N/A"}\r\n");

                File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());

                stringBuilder.Clear();

                if (!File.Exists(saveFileDialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPromptType.Error,
                        METPromptButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
            }
        }

        private void exportFmmmobilemeEmailTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{EFISTRINGS.FMM_EMAIL}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = METPath.WORKING_DIR
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("Find My Mac Email:");
                stringBuilder.AppendLine("----------------------------------");
                stringBuilder.AppendLine(EFIROM.FmmEmail);

                File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());

                stringBuilder.Clear();

                if (!File.Exists(saveFileDialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPromptType.Error,
                        METPromptButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
            }
        }
        #endregion

        #region Patch Toolstrip Events
        private void changeSerialNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (frmSerialSelect child = new frmSerialSelect())
            {
                child.Tag = SerialSenderTag.EFIROM;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();

                if (child.DialogResult == DialogResult.OK)
                {
                    WriteEfiromSerialNumber(EFIROM.NewSerial);
                }
            }
        }

        private void eraseNvramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (frmNvramSelect child = new frmNvramSelect())
            {
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();

                if (child.DialogResult == DialogResult.OK)
                {
                    EraseNvram(EFIROM.bResetVss, EFIROM.bResetSvs);
                }
            }
        }

        private void replaceFsysStoreToolStripMenuItem_Click(object sender, EventArgs e) => WriteFsysStore();

        private void replaceIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e) => WriteIntelMeRegion();

        private void fixFsysChecksumCRC32ToolStripMenuItem_Click(object sender, EventArgs e) => MaskFsysChecksum();

        private void invalidateEFILockToolStripMenuItem_Click(object sender, EventArgs e) => RemoveEfiLock();
        #endregion

        #region Options Toolstrip Events
        private void automaticFilenameGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string efiModel = EFIROM.EfiBiosIdSectionData.ModelPart ?? EFISTRINGS.NOMODEL;
            string efiversion = EFIROM.FirmwareVersion ?? EFISTRINGS.NOFWVER;
            string systemSerial = EFIROM.FsysStoreData.Serial ?? EFISTRINGS.NOSERIAL;

            SetClipboardText($"{efiModel}_{efiversion}_{systemSerial}");
        }

        private void reloadFileFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(EFIROM.LoadedBinaryPath))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.COULD_NOT_RELOAD,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file.
            byte[] fileBytes = File.ReadAllBytes(EFIROM.LoadedBinaryPath);

            // Check if the binaries match in size and data.
            if (BinaryTools.ByteArraysMatch(fileBytes, EFIROM.LoadedBinaryBuffer))
            {
                // Loaded binaries match.
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.WARN_DATA_MATCHES_BUFF,
                    METPromptType.Warning,
                    METPromptButtons.Okay);

                return;
            }

            OpenBinary(EFIROM.LoadedBinaryPath);
        }

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e) => Logger.OpenLogFile(this);

        private void viewRomInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form formWindow = new frmRominfo())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void lookupSerialNumberOnEveryMacToolStripMenuItem_Click(object sender, EventArgs e) =>
            MacTools.LookupSerialOnEveryMac(EFIROM.FsysStoreData.Serial);
        #endregion

        #region Open binary
        private void OpenBinary(string filePath)
        {
            // Check the filesize
            if (!FileTools.IsValidMinMaxSize(filePath, this))
            {
                return;
            }

            // Check if the image is what we're looking for.
            if (!EFIROM.IsValidImage(File.ReadAllBytes(filePath)))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.NOT_VALID_EFIROM,
                    METPromptType.Warning,
                    METPromptButtons.Okay);

                return;
            }

            // If a firmware is loaded, reset all data.
            if (EFIROM.FirmwareLoaded)
            {
                ResetWindow();
            }

            ToggleControlEnable(false);

            // Set the binary path and load the bytes.
            EFIROM.LoadedBinaryPath = filePath;
            EFIROM.LoadedBinaryBuffer = File.ReadAllBytes(filePath);

            // Set the current directory.
            _strInitialDirectory = Path.GetDirectoryName(filePath);

            // Show loading bar.
            pbxLoad.Image = Properties.Resources.loading;

            // Load the firmware base in a separate thread.
            _tLoadFirmware = new Thread(() => LoadFirmwareBase(filePath, _cancellationToken.Token)) { IsBackground = true };
            _tLoadFirmware.Start();
        }

        private void LoadFirmwareBase(string filePath, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            EFIROM.LoadFirmwareBaseData(EFIROM.LoadedBinaryBuffer, filePath);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

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
            {
                EFIROM.FirmwareLoaded = true;
            }
        }
        #endregion

        #region Update Window
        internal void UpdateUI()
        {
            // Parse time.
            UpdateParseTimeControls();

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

            UpdateLzmaArchiveControls();
            UpdateFmmEmailControls();

            // Apply DISABLED_TEXT to N/A labels.
            UITools.ApplyNestedPanelLabelForeColor(tlpFirmware, Colours.CLR_NATEXT);

            // Check which descriptor copy menu items should be enabled.
            pdrBaseToolStripMenuItem.Enabled = IFD.PDR_REGION_BASE != 0;
            meBaseToolStripMenuItem.Enabled = IFD.ME_REGION_BASE != 0;
            biosBaseToolStripMenuItem.Enabled = IFD.BIOS_REGION_BASE != 0;

            // Update window title.
            UpdateWindowTitle();

            // Hide loading image.
            pbxLoad.Image = null;

            // Check and set control enable.
            ToggleControlEnable(true);
        }

        private void UpdateParseTimeControls() => lblParseTime.Text = $"{EFIROM.tsParseTime.TotalSeconds:F2}s";

        private void UpdateFileNameControls() => lblFilename.Text = $"{APPSTRINGS.FILE}: '{EFIROM.FileInfoData.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            int fileSizeDecimal = EFIROM.FileInfoData.Length;

            bool isValidSize = FileTools.GetIsValidBinSize(fileSizeDecimal);

            lblFilesize.Text = $"{FileTools.FormatFileSize(fileSizeDecimal)} {APPSTRINGS.BYTES} ({fileSizeDecimal:X}h)";

            if (!isValidSize)
            {
                lblFilesize.ForeColor = Colours.CLR_ERROR;

                lblFilesize.Text += isValidSize ? string.Empty : $" ({FileTools.GetSizeDifference(fileSizeDecimal)})";
            }
        }

        private void UpdateFileCrc32Controls() => lblFileCrc32.Text = $"{EFIROM.FileInfoData.CRC32:X8}";

        private void UpdateFileCreationDateControls() => lblFileCreatedDate.Text = EFIROM.FileInfoData.CreationTime;

        private void UpdateFileModifiedDateControls() => lblFileModifiedDate.Text = EFIROM.FileInfoData.LastWriteTime;

        private void UpdateModelControls()
        {
            string identifier = EFIROM.EfiBiosIdSectionData.ModelPart;

            if (!string.IsNullOrEmpty(identifier))
            {
                string model = MacTools.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart);

                lblModel.Text = $"{model} ({identifier})" ?? APPSTRINGS.NA;

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
            lblConfigCode.ForeColor = Colours.CLR_INFO;

            GetConfigCodeAsync(EFIROM.FsysStoreData.HWC);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configCode = await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configCode))
            {
                EFIROM.ConfigCode = configCode;

                lblConfigCode.Text = configCode;
                lblConfigCode.ForeColor = Colours.CLR_NORMALTEXT;

                configurationToolStripMenuItem.Enabled = true;

                return;
            }

            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.CLR_DISABLEDTEXT;

            configurationToolStripMenuItem.Enabled = false;
        }

        private void UpdateFsysControls()
        {
            if (EFIROM.FsysStoreData.FsysBase != -1)
            {
                lblFsysStore.Text = $"{EFIROM.FsysStoreData.FsysBase:X2}h";

                bool crcMatch = string.Equals(EFIROM.FsysStoreData.CrcString, EFIROM.FsysStoreData.CrcCalcString);

                if (!string.IsNullOrEmpty(EFIROM.FsysStoreData.CrcString))
                {
                    lblFsysStore.Text += crcMatch ? $" ({EFISTRINGS.CRC_VALID})" : $" ({EFISTRINGS.CRC_INVALID})";
                    lblFsysStore.ForeColor = crcMatch ? lblFsysStore.ForeColor : Colours.CLR_WARNING;
                }

                if (EFIROM.ForceFoundFsys)
                {
                    lblFsysStore.Text += " [F]";
                }

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
            string serialNumber = EFIROM.FsysStoreData.Serial;

            if (!string.IsNullOrEmpty(serialNumber))
            {
                if (cbxCensor.Checked)
                {
                    lblSerialNumber.Text = serialNumber;
                }
                else
                {
                    if (serialNumber.Length == 11)
                    {
                        lblSerialNumber.Text = $"{serialNumber.Substring(0, 2)}******{serialNumber.Substring(8, 3)}";
                    }
                    else if (serialNumber.Length == 12)
                    {
                        lblSerialNumber.Text = $"{serialNumber.Substring(0, 2)}******{serialNumber.Substring(8, 4)}";
                    }
                }

                // Prototype in testing
                if (!Serial.IsValid(serialNumber))
                {
                    lblSerialNumber.ForeColor = Colours.CLR_WARNING;
                }

                cbxCensor.Enabled = true;
                serialToolStripMenuItem.Enabled = true;
            }
            else
            {
                lblSerialNumber.Text = APPSTRINGS.NA;
                cbxCensor.Enabled = false;
                serialToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateHardwareConfigControls()
        {
            string hwc = EFIROM.FsysStoreData.HWC;
            lblHwc.Text = hwc ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(hwc))
            {
                hwcToolStripMenuItem.Enabled = true;

                return;
            }

            hwcToolStripMenuItem.Enabled = false;
        }

        private void UpdateOrderNumberControls()
        {
            string orderNumber = EFIROM.FsysStoreData.SON;

            lblOrderNumber.Text = orderNumber ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(orderNumber))
            {
                orderNoToolStripMenuItem.Enabled = true;

                return;
            }

            orderNoToolStripMenuItem.Enabled = false;
        }

        private void UpdateEfiVersionControls()
        {
            string efiVersion = EFIROM.FirmwareVersion;

            lblEfiVersion.Text = efiVersion ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(efiVersion))
            {
                efiVersionToolStripMenuItem.Enabled = true;

                return;
            }

            efiVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateBoardIdControls()
        {
            string boardId = EFIROM.PdrSectionData.BoardId;

            lblBoardId.Text = boardId ?? APPSTRINGS.NA;

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
            int vssBase = EFIROM.VssPrimary.StoreBase;
            int svsBase = EFIROM.SvsPrimary.StoreBase;
            bool isVssEmpty = EFIROM.VssPrimary.IsStoreEmpty;
            bool isSvsEmpty = EFIROM.SvsPrimary.IsStoreEmpty;

            // Update labels and menu items
            UpdateStoreDisplay(lblVss, vSSBaseAddressToolStripMenuItem, vssBase, isVssEmpty);
            UpdateStoreDisplay(lblSvs, sVSBaseAddressToolStripMenuItem, svsBase, isSvsEmpty);
        }

        // Helper method to update label text and menu item enabled state
        private static void UpdateStoreDisplay(Label label, ToolStripMenuItem menuItem, int baseAddress, bool isEmpty)
        {
            if (baseAddress != -1)
            {
                label.Text = $"{baseAddress:X2}h {(isEmpty ? $"[{EFISTRINGS.EMPTY}]" : $"[{EFISTRINGS.ACTIVE}]")}";
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
                    lblEfiLock.ForeColor = Colours.CLR_WARNING;
                    break;
                case EfiLockType.Unlocked:
                    lblEfiLock.Text = EFISTRINGS.UNLOCKED.ToUpper();
                    break;
                case EfiLockType.Unknown:
                default:
                    lblEfiLock.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblEfiLock.ForeColor = Colours.CLR_WARNING;
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
                    lblApfsCapable.ForeColor = Colours.CLR_WARNING;
                    break;
                case ApfsCapable.Unknown:
                    lblApfsCapable.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblApfsCapable.ForeColor = Colours.CLR_WARNING;
                    break;
            }
        }

        private void UpdateDescriptorModeControls() => lblDescriptorMode.Text = $"{IFD.IsDescriptorMode}";

        private void UpdateIntelMeControls()
        {
            string meVersion = EFIROM.MeVersion;

            lblMeVersion.Text = meVersion ?? APPSTRINGS.NA;

            if (!string.IsNullOrEmpty(meVersion))
            {
                if (IFD.ME_REGION_BASE != 0)
                {
                    if (!string.IsNullOrEmpty(meVersion))
                    {
                        lblMeVersion.Text += $" ({IFD.ME_REGION_BASE:X}h)";
                    }
                }

                meVersionToolStripMenuItem.Enabled = true;

                return;
            }

            meVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateIntelFitControls() =>
            fitVersionToolStripMenuItem.Enabled = !string.IsNullOrEmpty(EFIROM.FitVersion);

        private void UpdateLzmaArchiveControls() =>
            lblLzma.ForeColor = EFIROM.LzmaDecompressedBuffer != null ? Colours.CLR_SB_FOUND : Colours.CLR_SB_DEFAULT;

        private void UpdateFmmEmailControls() =>
            lblFmmEmail.ForeColor = EFIROM.FmmEmail != null ? Colours.CLR_SB_FOUND : Colours.CLR_SB_DEFAULT;
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e) => BlurHelper.RemoveBlur(this);

        private void ToggleControlEnable(bool enable)
        {
            Button[] menuButtons =
            {
                cmdMenuReset,
                cmdMenuCopy,
                cmdMenuFolders,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuOptions,
                cmdOpenInExplorer,
            };

            void EnableButtons(params Button[] buttons)
            {
                foreach (Button button in buttons)
                {
                    button.Enabled = enable;
                }
            }

            if (!enable)
            {
                EnableButtons(menuButtons);
            }
            else
            {
                EnableButtons(menuButtons);

                bool fsysBytesExist = EFIROM.FsysStoreData.FsysBytes != null;
                bool fsysCrcMismatch = fsysBytesExist && !string.Equals(EFIROM.FsysStoreData.CrcCalcString, EFIROM.FsysStoreData.CrcString);
                bool allNvStoresEmpty =
                    EFIROM.VssPrimary.IsStoreEmpty &&
                    EFIROM.VssSecondary.IsStoreEmpty &&
                    EFIROM.SvsPrimary.IsStoreEmpty &&
                    EFIROM.SvsSecondary.IsStoreEmpty;

                // Export Menu
                exportFsysStoreToolStripMenuItem.Enabled = fsysBytesExist;
                exportIntelMERegionToolStripMenuItem.Enabled = IFD.IsDescriptorMode && IFD.ME_REGION_BASE != 0 && IFD.ME_REGION_LIMIT != 0;
                exportNVRAMVSSStoresToolStripMenuItem.Enabled = !EFIROM.VssPrimary.IsStoreEmpty || !EFIROM.VssSecondary.IsStoreEmpty;
                exportNVRAMSVSStoresToolStripMenuItem.Enabled = !EFIROM.SvsPrimary.IsStoreEmpty || !EFIROM.SvsSecondary.IsStoreEmpty;
                exportLZMADXEArchiveToolStripMenuItem.Enabled = EFIROM.LzmaDecompressedBuffer != null;
                exportFmmmobilemeEmailTextToolStripMenuItem.Enabled = EFIROM.FmmEmail != null;

                // Patch Menu
                changeSerialNumberToolStripMenuItem.Enabled = EFIROM.FsysStoreData.FsysBase != -1 && EFIROM.FsysStoreData.SerialBase != -1;
                replaceIntelMERegionToolStripMenuItem.Enabled = IFD.IsDescriptorMode && IFD.ME_REGION_BASE != 0 && IFD.ME_REGION_LIMIT != 0;
                replaceFsysStoreToolStripMenuItem.Enabled = EFIROM.FsysStoreData.FsysBase != -1;
                eraseNVRAMToolStripMenuItem.Enabled = !allNvStoresEmpty;
                fixFsysChecksumCRC32ToolStripMenuItem.Enabled = fsysCrcMismatch;
                invalidateEFILockToolStripMenuItem.Enabled = EFIROM.EfiPrimaryLockData.LockType == EfiLockType.Locked;

                // Options Menu
                viewRomInformationToolStripMenuItem.Enabled = EFIROM.AppleRomInfoSectionData.SectionExists;
                lookupSerialNumberOnEveryMacToolStripMenuItem.Enabled = !string.IsNullOrEmpty(EFIROM.FsysStoreData.Serial);
            }

            tlpFilename.Enabled = enable;
            tlpFirmware.Enabled = enable;
        }

        private void SetButtonFontAndGlyph()
        {
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.FONT_MDL2_REG_12, Text = Program.GLYPH_EXIT_CROSS },
                new { Button = cmdOpenInExplorer, Font = Program.FONT_MDL2_REG_10, Text = Program.GLYPH_FILE_EXPLORER },
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }

        private void SetLabelFontAndGlyph()
        {
            lblLzma.Font = Program.FONT_MDL2_REG_10;
            lblLzma.Text = Program.GLYPH_REPORT;

            lblFmmEmail.Font = Program.FONT_MDL2_REG_10;
            lblFmmEmail.Text = Program.GLYPH_ACCOUNT;
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdMenuOpen,
                cmdMenuReset,
                cmdMenuCopy,
                cmdMenuFolders,
                cmdOpenInExplorer,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuOptions
            };

            Label[] labels =
            {
                lblParseTime,
                lblLzma,
                lblFmmEmail
            };

            CheckBox[] checkBoxes = { cbxCensor };

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

            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.MouseEnter += HandleMouseEnterTip;
                checkBox.MouseLeave += HandleMouseLeaveTip;
                checkBox.CheckedChanged += HandleCheckBoxChanged;
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
                    { cmdMenuFolders, $"{EFISTRINGS.MENU_TIP_FOLDERS} (CTRL + L)" },
                    { cmdMenuExport, $"{EFISTRINGS.MENU_TIP_EXPORT} (CTRL + E)"},
                    { cmdMenuPatch, $"{EFISTRINGS.MENU_TIP_PATCH} (CTRL + P)"},
                    { cmdMenuOptions, $"{EFISTRINGS.MENU_TIP_OPTIONS} (CTRL + T)"},
                    { cmdOpenInExplorer, $"{EFISTRINGS.MENU_TIP_OPENFILELOCATION} (CTRL + SHIFT + L)" },
                    { lblParseTime, APPSTRINGS.FW_PARSE_TIME},
                    { cbxCensor, censorString() },
                    { lblLzma, lzmaString() },
                    { lblFmmEmail, emailString() }
                };

                if (tooltips.TryGetValue(sender, out string value))
                {
                    lblStatusBarTip.Text = value;
                }

                tooltips.Clear();
            }
        }

        private string censorString() =>
            $"{(cbxCensor.Checked ? APPSTRINGS.HIDE : APPSTRINGS.SHOW)} {APPSTRINGS.SERIAL_NUMBER} (CTRL + S)";

        private string lzmaString() =>
            EFIROM.LzmaDecompressedBuffer != null ? EFISTRINGS.LZMA_VOL_FOUND : string.Empty;

        private string emailString() =>
            EFIROM.FmmEmail != null ? EFISTRINGS.FMM_EMAIL_FOUND : string.Empty;

        private void HandleCheckBoxChanged(object sender, EventArgs e)
        {
            if (sender == cbxCensor && cbxCensor.ClientRectangle.Contains(cbxCensor.PointToClient(Cursor.Position)))
            {
                if (!Settings.ReadBool(SettingsBoolType.DisableTips))
                {
                    lblStatusBarTip.Text = censorString();
                }
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e) => lblStatusBarTip.Text = string.Empty;

        private static void SetControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control control in parentControl.Controls)
            {
                control.ForeColor = foreColor;
            }
        }

        private void NotifyPatchingFailure()
        {
            if (Prompts.ShowPatchFailedPrompt(this) == DialogResult.Yes)
            {
                Logger.OpenLogFile(this);
            }
        }

        private void UpdateWindowTitle()
        {
            this.Text = EFIROM.FileInfoData.FileNameExt;
            lblTitle.Text = $"{APPSTRINGS.EFIROM} {Program.GLYPH_RIGHT_ARROW} {EFIROM.FileInfoData.FileNameExt}";
        }
        #endregion

        #region Misc Events
        internal void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(SettingsStringType.EfiInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory) ? directory : METPath.WORKING_DIR;
            }
        }

        private void ResetWindow()
        {
            // Reset censor switch.
            cbxCensor.Checked = false;
            cbxCensor.Enabled = false;

            // Clear label data, and reset color properties.
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
                label.ForeColor = Colours.CLR_NORMALTEXT;
            }

            // Reset parse time.
            lblParseTime.Text = "0.00s";
            lblLzma.ForeColor = Colours.CLR_SB_DEFAULT;
            lblFmmEmail.ForeColor = Colours.CLR_SB_DEFAULT;

            // Reset window text.
            Text = APPSTRINGS.EFIROM;
            lblTitle.Text = APPSTRINGS.EFIROM;

            // Reset initial directory.
            SetInitialDirectory();

            // Reset Intel FD.
            IFD.ClearRegionData();

            // Reset EFIROM.
            EFIROM.ResetFirmwareBaseData();
        }
        #endregion

        #region Clipboard
        internal void SetClipboardText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Clipboard.SetText(text);

            if (!Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"'{text}' {EFISTRINGS.COPIED_TO_CB_LC}",
                    METPromptType.Information,
                    METPromptButtons.Okay);
            }
        }

        private void ClipboardSetFilename(bool showExtension) =>
            SetClipboardText(
                showExtension
                ? EFIROM.FileInfoData.FileNameExt
                : EFIROM.FileInfoData.FileName);

        private void ClipboardSetFileSize() =>
            SetClipboardText(
                $"{FileTools.FormatFileSize(EFIROM.FileInfoData.Length)} " +
                $"{APPSTRINGS.BYTES} ({EFIROM.FileInfoData.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText($"{EFIROM.FileInfoData.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(EFIROM.FileInfoData.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(EFIROM.FileInfoData.LastWriteTime);

        private void ClipboardSetFirmwareModel() =>
            SetClipboardText(MacTools.ConvertEfiModelCode(EFIROM.EfiBiosIdSectionData.ModelPart));

        private void ClipboardSetFirmwareConfigCode() => SetClipboardText(EFIROM.ConfigCode);

        private void ClipboardSetFsysBaseAddress() => SetClipboardText($"{EFIROM.FsysStoreData.FsysBase:X2}");

        private void ClipboardSetFirmwareFsysCrc32() => SetClipboardText(EFIROM.FsysStoreData.CrcString);

        private void ClipboardSetFirmwareHwc() => SetClipboardText(EFIROM.FsysStoreData.HWC);

        private void ClipboardSetFirmwareOrderNumber() => SetClipboardText(EFIROM.FsysStoreData.SON);

        private void ClipboardSetFirmwareVersion() => SetClipboardText(EFIROM.FirmwareVersion);

        private void ClipboardSetVssBaseAddress() => SetClipboardText($"{EFIROM.VssPrimary.StoreBase:X2}");

        private void ClipboardSetSvsBaseAddress() => SetClipboardText($"{EFIROM.SvsPrimary.StoreBase:X2}");

        private void ClipboardSetFirmwareBoardId() => SetClipboardText(EFIROM.PdrSectionData.BoardId);

        private void ClipboardSetFirmwareFitVersion() => SetClipboardText(EFIROM.FitVersion);

        private void ClipboardSetFirmwareMeVersion() => SetClipboardText(EFIROM.MeVersion);

        private void ClipboardSetPdrRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {IFD.PDR_REGION_BASE:X}h, " +
                $"{APPSTRINGS.LIMIT} {IFD.PDR_REGION_LIMIT:X}h, " +
                $"{APPSTRINGS.SIZE} {IFD.PDR_REGION_SIZE:X}h");

        private void ClipboardSetMeRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {IFD.ME_REGION_BASE:X}h, " +
                $"{APPSTRINGS.LIMIT} {IFD.ME_REGION_LIMIT:X}h, " +
                $"{APPSTRINGS.SIZE} {IFD.ME_REGION_SIZE:X}h");

        private void ClipboardSetBiosRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {IFD.BIOS_REGION_BASE:X}h, " +
                $"{APPSTRINGS.LIMIT} {IFD.BIOS_REGION_LIMIT:X}h, " +
                $"{APPSTRINGS.SIZE} {IFD.BIOS_REGION_SIZE:X}h");
        #endregion

        #region Write Serial
        private void WriteEfiromSerialNumber(string serial)
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);

            // Check serial length.
            if (serial.Length != 11 && serial.Length != 12)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SERIAL_LEN_INVALID} ({serial.Length})");
                NotifyPatchingFailure();
                return;
            }

            // Check if the SerialBase exists.
            if (EFIROM.FsysStoreData.SerialBase == -1)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                NotifyPatchingFailure();
                return;
            }

            // Create buffers.
            Logger.WritePatchLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] binaryBuffer = (byte[])EFIROM.LoadedBinaryBuffer.Clone();
            byte[] newSerialBytes = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WritePatchLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, EFIROM.FsysStoreData.SerialBase, newSerialBytes);

            // Check HWC base and write new HWC.
            bool isHwcBasePresent = EFIROM.FsysStoreData.HWCBase != -1;
            string newHwc = null;

            if (isHwcBasePresent)
            {
                newHwc = serial.Substring(8, EFIROM.FsysStoreData.Serial.Length == 11 ? 3 : 4);
                byte[] newHwcBytes = Encoding.UTF8.GetBytes(newHwc);

                Logger.WritePatchLine(LOGSTRINGS.HWC_WTB);

                // Write new HWC.
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, EFIROM.FsysStoreData.HWCBase, newHwcBytes);
            }

            Logger.WritePatchLine(LOGSTRINGS.FSYS_LFB);

            // Load patched fsys from the binary buffer.
            FsysStore fsysStoreFromBuffer = EFIROM.GetFsysStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, fsysStoreFromBuffer.Serial))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_NOT_WRITTEN}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.SSN_WRITE_SUCCESS);

            // Verify the HWC was written correctly, if applicable.
            if (isHwcBasePresent && fsysStoreFromBuffer.HWCBase != -1 && !string.Equals(newHwc, fsysStoreFromBuffer.HWC))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.HWC_NOT_WRITTEN}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.HWC_WRITE_SUCCESS);

            // Patch fsys checksum in the binary buffer.
            binaryBuffer = EFIROM.MakeFsysCrcPatchedBinary(binaryBuffer, fsysStoreFromBuffer.FsysBase, fsysStoreFromBuffer.FsysBytes, fsysStoreFromBuffer.CRC32CalcInt);

            // Reload fsys store from the binary buffer and verify CRC masking success.
            fsysStoreFromBuffer = EFIROM.GetFsysStoreData(binaryBuffer, false);

            if (!string.Equals(fsysStoreFromBuffer.CrcString, fsysStoreFromBuffer.CrcCalcString))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_SUM_MASK_FAIL}");
                NotifyPatchingFailure();
                return;
            }

            // Log success and prompt for saving the patched firmware.
            Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Erase NVRAM
        private void EraseNvram(bool resetVss, bool resetSvs)
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);

            // Load current firmware into buffer.
            byte[] binaryBuffer = (byte[])EFIROM.LoadedBinaryBuffer.Clone();

            // Erase NVRAM sections if required
            if (resetVss)
            {
                Logger.WritePatchLine(LOGSTRINGS.NVRAM_VSS_ERASE);
                CheckEraseStore(nameof(EFIROM.VssPrimary), EFIROM.VssPrimary, binaryBuffer);
                CheckEraseStore(nameof(EFIROM.VssSecondary), EFIROM.VssSecondary, binaryBuffer);
            }

            if (resetSvs)
            {
                Logger.WritePatchLine(LOGSTRINGS.NVRAM_SVS_ERASE);
                CheckEraseStore(nameof(EFIROM.SvsPrimary), EFIROM.SvsPrimary, binaryBuffer);
                CheckEraseStore(nameof(EFIROM.SvsSecondary), EFIROM.SvsSecondary, binaryBuffer);
            }

            Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }

        private void CheckEraseStore(string storeName, NvramStore store, byte[] buffer)
        {
            if (store.StoreBase == -1)
            {
                Logger.WritePatchLine($"{storeName} {LOGSTRINGS.NVR_BASE_NOT_FOUND}");
            }
            else if (store.IsStoreEmpty)
            {
                Logger.WritePatchLine($"{storeName} {LOGSTRINGS.NVR_IS_EMPTY}");
            }
            else if (!GetAndEraseStore(storeName, store, buffer))
            {
                return;
            }
        }

        private bool GetAndEraseStore(string storeName, NvramStore nvramStore, byte[] binaryBuffer)
        {
            Logger.WritePatchLine($"{storeName} {LOGSTRINGS.AT} {nvramStore.StoreBase:X}h {LOGSTRINGS.NVR_HAS_BODY_ERASING}");

            byte[] erasedBuffer = EraseNvramStore(NvramStoreType.Variable, nvramStore);

            if (erasedBuffer == null)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.NVR_FAIL_ERASE_BODY} ({storeName})");
                NotifyPatchingFailure();
                return false;
            }

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, nvramStore.StoreBase, erasedBuffer);

            byte[] tempBuffer = BinaryTools.GetBytesBaseLength(binaryBuffer, nvramStore.StoreBase, nvramStore.StoreSize);

            if (!BinaryTools.ByteArraysMatch(tempBuffer, erasedBuffer))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.NVR_FAIL_WRITE_VERIFY} ({storeName})");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }

        private byte[] EraseNvramStore(NvramStoreType storeType, NvramStore store)
        {
            try
            {
                byte[] storeBuffer = (byte[])store.StoreBuffer.Clone();
                int bodyStart = EFIROM.HDR_SIZE;
                int bodyEnd = store.StoreBuffer.Length - EFIROM.HDR_SIZE;

                // Initialize header.
                Logger.WritePatchLine(LOGSTRINGS.NVRAM_INIT_HDR);
                for (int i = 0x4; i <= 0x7; i++)
                {
                    storeBuffer[i] = 0xFF;
                }

                if (storeType == NvramStoreType.Variable)
                {
                    Logger.WritePatchLine(LOGSTRINGS.NVRAM_INIT_HDR_VSS);
                    for (int i = 0x9; i <= 0xA; i++)
                    {
                        storeBuffer[i] = 0xFF;
                    }
                }

                // Verify that the relevant header bytes have been set to 0xFF.
                if (!VerifyErasedHeader(storeBuffer, storeType))
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.NVRAM_INIT_HDR_FAIL}");
                    return null;
                }

                Logger.WritePatchLine(LOGSTRINGS.NVRAM_INIT_HDR_SUCCESS);

                // Pull the store body from the buffer.
                byte[] erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                Logger.WritePatchLine(LOGSTRINGS.NVR_ERASE_BODY);

                // Erase the store body.
                BinaryTools.EraseByteArray(erasedStoreBodyBuffer);

                Logger.WritePatchLine(LOGSTRINGS.NVR_WRITE_ERASED_BODY);

                // Write the erased store back to the nvram store buffer.
                BinaryTools.OverwriteBytesAtBase(storeBuffer, bodyStart, erasedStoreBodyBuffer);

                // Check the body was erased.
                erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                if (!BinaryTools.IsByteBlockEmpty(erasedStoreBodyBuffer))
                {
                    MessageBox.Show(LOGSTRINGS.NVR_BODY_WRITE_FAIL);
                    return null;
                }

                Logger.WritePatchLine(LOGSTRINGS.NVR_STORE_ERASE_SUCESS);

                return storeBuffer;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(EraseNvramStore), e.GetType(), e.Message);
                return null;
            }
        }

        private static bool VerifyErasedHeader(byte[] storeBuffer, NvramStoreType storeType)
        {
            for (int i = 0x4; i <= 0x7; i++)
            {
                if (storeBuffer[i] != 0xFF)
                    return false;
            }

            if (storeType == NvramStoreType.Variable)
            {
                for (int i = 0x9; i <= 0xA; i++)
                {
                    if (storeBuffer[i] != 0xFF)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Write Fsys Store
        private void WriteFsysStore()
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog openFileDialog = CreateFsysOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_IMPORT_CANCELLED}");
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] newFsysBuffer = File.ReadAllBytes(openFileDialog.FileName);

                if (!ValidateFsysStore(newFsysBuffer))
                {
                    return;
                }

                FsysStore fsysTempStore = EFIROM.GetFsysStoreData(newFsysBuffer, true);

                if (!ValidateFsysCrc(fsysTempStore, ref newFsysBuffer))
                {
                    return;
                }

                byte[] binaryBuffer = (byte[])EFIROM.LoadedBinaryBuffer.Clone();

                if (!WriteNewFsysStore(binaryBuffer, newFsysBuffer))
                {
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareEfirom(binaryBuffer);
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
            }
        }

        private static OpenFileDialog CreateFsysOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = METPath.FSYS_DIR,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateFsysStore(byte[] fsysBuffer)
        {
            int fsysBase = BinaryTools.GetBaseAddress(fsysBuffer, EFIROM.FSYS_SIG);

            // Fsys store length should equal 800h, 2048 bytes.
            if (fsysBuffer.Length != EFIROM.FSYS_RGN_SIZE)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.EXPECTED_STORE_SIZE_NOT} {EFIROM.FSYS_RGN_SIZE:X}h ({fsysBuffer.Length:X}h)");
                NotifyPatchingFailure();
                return false;
            }

            // Expect Fsys signature at 0h.
            if (fsysBase != 0)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_SIG_MISALIGNED}");
                NotifyPatchingFailure();
                return false;
            }

            Logger.WritePatchLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool ValidateFsysCrc(FsysStore tempFsysBuffer, ref byte[] newFsysBuffer)
        {
            if (!string.Equals(tempFsysBuffer.CrcString, tempFsysBuffer.CrcCalcString))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.FSYS_SUM_INVALID} ({LOGSTRINGS.FOUND} {tempFsysBuffer.CrcString}, {LOGSTRINGS.CALCULATED} {tempFsysBuffer.CrcCalcString})");

                Logger.WritePatchLine(LOGSTRINGS.MASKING_SUM);

                newFsysBuffer = EFIROM.PatchFsysCrc(tempFsysBuffer.FsysBytes, tempFsysBuffer.CRC32CalcInt);
                tempFsysBuffer = EFIROM.GetFsysStoreData(newFsysBuffer, true);

                if (!string.Equals(tempFsysBuffer.CrcString, tempFsysBuffer.CrcCalcString))
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SUM_MASKING_FAIL}");
                    NotifyPatchingFailure();
                    return false;
                }

                Logger.WritePatchLine(LOGSTRINGS.FSYS_SUM_MASK_SUCCESS);
            }

            return true;
        }

        private bool WriteNewFsysStore(byte[] binaryBuffer, byte[] newFsysBuffer)
        {
            Logger.WritePatchLine(LOGSTRINGS.WRITE_NEW_DATA);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, EFIROM.FsysStoreData.FsysBase, newFsysBuffer);
            FsysStore fsysTempBuffer = EFIROM.GetFsysStoreData(binaryBuffer, false);

            if (!BinaryTools.ByteArraysMatch(fsysTempBuffer.FsysBytes, newFsysBuffer))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }
        #endregion

        #region Mask Fsys Checksum
        private void MaskFsysChecksum()
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);

            // Make binary with patched Fsys crc.
            byte[] binaryBuffer =
                EFIROM.MakeFsysCrcPatchedBinary(
                    (byte[])EFIROM.LoadedBinaryBuffer.Clone(),
                    EFIROM.FsysStoreData.FsysBase,
                    EFIROM.FsysStoreData.FsysBytes,
                    EFIROM.FsysStoreData.CRC32CalcInt);

            if (binaryBuffer == null)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.CRC_BUFFER_EMPTY}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Remove EFI Lock
        private void RemoveEfiLock()
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);
            Logger.WritePatchLine(LOGSTRINGS.CREATING_BUFFERS);

            // Initialize buffers.
            byte[] binaryBuffer = (byte[])EFIROM.LoadedBinaryBuffer.Clone();

            // Patch the primary store.
            byte[] unlockedPrimaryStore = PatchPrimaryStore(binaryBuffer);

            // Patch the backup store, if necessary.
            byte[] unlockedBackupStore = PatchBackupStore(binaryBuffer);

            // Verify patched stores.
            if (!VerifyPatchedStores(binaryBuffer, unlockedPrimaryStore, unlockedBackupStore))
            {
                NotifyPatchingFailure();
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

            // Prompt for saving and export if confirmed.
            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }

        private byte[] PatchPrimaryStore(byte[] binaryBuffer)
        {
            Logger.WritePatchLine(LOGSTRINGS.LOCK_PRIMARY_MAC);
            byte[] unlockedPrimaryStore = EFIROM.PatchSvsStoreMac(EFIROM.SvsPrimary.StoreBuffer, EFIROM.EfiPrimaryLockData.LockCrcBase);

            Logger.WritePatchLine(LOGSTRINGS.WRITE_NEW_DATA);
            BinaryTools.OverwriteBytesAtBase(binaryBuffer, EFIROM.SvsPrimary.StoreBase, unlockedPrimaryStore);

            return unlockedPrimaryStore;
        }

        private byte[] PatchBackupStore(byte[] binaryBuffer)
        {
            byte[] unlockedBackupStore = null;

            if (EFIROM.EfiBackupLockData.LockCrcBase != -1)
            {
                Logger.WritePatchLine(LOGSTRINGS.LOCK_BACKUP_MAC);
                unlockedBackupStore = EFIROM.PatchSvsStoreMac(EFIROM.SvsSecondary.StoreBuffer, EFIROM.EfiBackupLockData.LockCrcBase);

                Logger.WritePatchLine(LOGSTRINGS.WRITE_NEW_DATA);
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, EFIROM.SvsSecondary.StoreBase, unlockedBackupStore);
            }

            return unlockedBackupStore;
        }

        private bool VerifyPatchedStores(byte[] binaryBuffer, byte[] unlockedPrimaryStore, byte[] unlockedBackupStore)
        {
            Logger.WritePatchLine(LOGSTRINGS.LOCK_LOAD_SVS);

            int svsPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(binaryBuffer, EFIROM.SVS_STORE_SIG, EFIROM.NVRAM_BASE, EFIROM.NVRAM_LIMIT);
            NvramStore svsPrimary = EFIROM.ParseNvramStore(binaryBuffer, svsPrimaryBase, NvramStoreType.Secure);

            if (!BinaryTools.ByteArraysMatch(svsPrimary.StoreBuffer, unlockedPrimaryStore))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_PRIM_VERIF_FAIL}");
                return false;
            }

            if (unlockedBackupStore != null)
            {
                int svsBackupBase = BinaryTools.GetBaseAddressUpToLimit(binaryBuffer, EFIROM.SVS_STORE_SIG, svsPrimaryBase + EFIROM.HDR_SIZE, EFIROM.NVRAM_LIMIT);
                NvramStore svsBackup = EFIROM.ParseNvramStore(binaryBuffer, svsBackupBase, NvramStoreType.Secure);

                if (!BinaryTools.ByteArraysMatch(svsBackup.StoreBuffer, unlockedBackupStore))
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_BACK_VERIF_FAIL}");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Write Intel ME
        private void WriteIntelMeRegion()
        {
            Logger.WritePatchLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog openFileDialog = CreateImeOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_IMPORT_CANCELLED}");
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] imeBuffer = File.ReadAllBytes(openFileDialog.FileName);

                if (!ValidateMeRegion(imeBuffer))
                {
                    return;
                }

                string imeVersion = IME.GetVersionData(imeBuffer, ImeVersionType.ManagementEngine);

                Logger.WritePatchLine($"{LOGSTRINGS.IME_VERSION} {imeVersion ?? APPSTRINGS.NOT_FOUND}");

                byte[] binaryBuffer = (byte[])EFIROM.LoadedBinaryBuffer.Clone();

                if (!WriteMeRegion(imeBuffer, binaryBuffer))
                {
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareEfirom(binaryBuffer);
                    return;
                }

                Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
            }
        }

        private static OpenFileDialog CreateImeOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = METPath.INTELME_DIR,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateMeRegion(byte[] newImeBuffer)
        {
            int fptBase = BinaryTools.GetBaseAddress(newImeBuffer, IME.FPT_SIGNATURE);

            if (fptBase == -1)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_FPT_NOT_FOUND}");
                NotifyPatchingFailure();
                return false;
            }

            if (newImeBuffer.Length > IFD.ME_REGION_SIZE)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_TOO_LARGE} {newImeBuffer.Length:X}h > {IFD.ME_REGION_SIZE:X}h");
                NotifyPatchingFailure();
                return false;
            }

            if (newImeBuffer.Length < IFD.ME_REGION_SIZE)
            {
                Logger.WritePatchLine($"{LOGSTRINGS.IME_TOO_SMALL} {newImeBuffer.Length:X}h > {IFD.ME_REGION_SIZE:X}h");
            }

            Logger.WritePatchLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool WriteMeRegion(byte[] newImeBuffer, byte[] binaryBuffer)
        {
            byte[] ffBuffer = new byte[IFD.ME_REGION_SIZE];
            BinaryTools.EraseByteArray(ffBuffer);

            Array.Copy(newImeBuffer, 0, ffBuffer, 0, newImeBuffer.Length);
            Array.Copy(ffBuffer, 0, binaryBuffer, IFD.ME_REGION_BASE, ffBuffer.Length);

            byte[] patchedMeBuffer = BinaryTools.GetBytesBaseLimit(binaryBuffer, (int)IFD.ME_REGION_BASE, (int)IFD.ME_REGION_LIMIT);

            if (!BinaryTools.ByteArraysMatch(patchedMeBuffer, ffBuffer))
            {
                Logger.WritePatchLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_BUFFER_MISMATCH}");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }
        #endregion

        #region Patching IO
        private static SaveFileDialog CreateFirmwareSaveFileDialog()
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = EFIROM.FileInfoData.FileName,
                OverwritePrompt = true,
                InitialDirectory = METPath.BUILDS_DIR
            };
        }

        private void SaveOutputFirmwareEfirom(byte[] binaryBuffer)
        {
            using (SaveFileDialog saveFileDialog = CreateFirmwareSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WritePatchLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return;
                }

                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, binaryBuffer) && File.Exists(saveFileDialog.FileName))
                {
                    Logger.WritePatchLine($"{LOGSTRINGS.FILE_SAVE_SUCCESS} {saveFileDialog.FileName}");

                    DialogResult result =
                        METPrompt.Show(
                            this,
                            DIALOGSTRINGS.FW_SAVED_SUCCESS_LOAD,
                            METPromptType.Question,
                            METPromptButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        OpenBinary(saveFileDialog.FileName);
                    }
                }
            }
        }
        #endregion
    }
}