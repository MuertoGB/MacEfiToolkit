// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmEfiRom.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFIROM;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmEfiRom : FormEx
    {
        #region Private Members
        private EFIROM _efirom = new EFIROM();
        private EFIPatcher _patcher = new EFIPatcher();
        private string _strInitialDirectory = ApplicationPaths.WorkingDirectory;
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        private Button[] _menuButtons;
        private ContextMenuStrip[] _contextMenus;
        #endregion

        #region Constructor
        public frmEfiRom()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Set tip handlers for controls.
            SetTipHandlers();

            // Set button properties.
            SetButtonFontAndGlyph();

            // Set label properties.
            SetLabelFontAndGlyph();

            // Get and disable menu items.
            GetAndDisableMenuItems();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);
        }
        #endregion

        #region Window Events
        private void frmEfiRom_Load(object sender, EventArgs e)
        {
            // Get and set the primary file dialog initial directory.
            SetInitialDirectory();

            _cancellationToken = new CancellationTokenSource();

            if (!string.IsNullOrEmpty(Program.MainWindow.LoadedFirmware))
            {
                OpenBinary(Program.MainWindow.LoadedFirmware);
                Program.MainWindow.LoadedFirmware = null;
            }

            MemoryTracker.Instance.OnMemoryUsageUpdated += MemoryTracker_OnMemoryUsageUpdated;
        }

        private void MemoryTracker_OnMemoryUsageUpdated(object sender, ulong pagefileUsage)
        {
            Invoke(new Action(() =>
            {
                if (!lblPagefile.Visible)
                {
                    lblPagefile.Visible = true;
                }

                lblPagefile.Text = FileTools.FormatBytesToReadableUnit(pagefileUsage);
            }));
        }

        private void frmEfiRom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancellationToken != null & !_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.Cancel();
            }

            MemoryTracker.Instance.OnMemoryUsageUpdated -= MemoryTracker_OnMemoryUsageUpdated;

            _efirom = null;
        }

        private void frmEfiRom_FormClosed(object sender, FormClosedEventArgs e)
            => _cancellationToken?.Dispose();

        private void frmEfiRom_DragEnter(object sender, DragEventArgs e)
            => Program.HandleDragEnter(sender, e, null);

        private void frmEfiRom_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = draggedFiles[0];

            // Open the binary file.
            this.BeginInvoke(new Action(() =>
            {
                OpenBinary(file);
            }));
        }

        private void frmEfiRom_Deactivate(object sender, EventArgs e)
            => SetControlForeColor(tlpTitle, ApplicationColours.InactiveFormText);

        private void frmEfiRom_Activated(object sender, EventArgs e)
            => SetControlForeColor(tlpTitle, ApplicationColours.ActiveFormText);
        #endregion

        #region KeyDown Events
        private void frmEfiRom_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Alt key is pressed
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                // Let the system handle Alt+F4 to close the window
                e.Handled = false;
                return;
            }

            // Handle individual keys (F12, ESC) without modifiers.
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F1:
                    manualToolStripMenuItem.PerformClick();
                    break;
                case Keys.F4:
                    settingsToolStripMenuItem.PerformClick();
                    break;
                case Keys.F5:
                    reloadFileFromDiskToolStripMenuItem.PerformClick();
                    break;
                case Keys.F12:
                    viewApplicationLogToolStripMenuItem.PerformClick();
                    break;
            }

            // Handle control key + other combinations.
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    // Main menu.
                    case Keys.O:
                        cmdMenuOpen.PerformClick();
                        break;
                    case Keys.L:
                        cmdMenuFolders.PerformClick();
                        break;
                    case Keys.C:
                        cmdMenuCopy.PerformClick();
                        break;
                    case Keys.E:
                        cmdMenuExport.PerformClick();
                        break;
                    case Keys.P:
                        cmdMenuPatch.PerformClick();
                        break;
                    case Keys.T:
                        cmdMenuTools.PerformClick();
                        break;
                    case Keys.H:
                        cmdMenuHelp.PerformClick();
                        break;

                    // Tools menu.
                    case Keys.I:
                        viewRomInformationToolStripMenuItem.PerformClick();
                        break;
                    case Keys.R:
                        resetWindowToolStripMenuItem.PerformClick();
                        break;
                }
            }
            // Handle control key + shift key + other combinations.
            else if ((e.Modifiers & Keys.Control) == Keys.Control && (e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.L:
                        cmdOpenInExplorer.PerformClick();
                        break;
                    case Keys.N:
                        cbxCensor.Checked = !cbxCensor.Checked;
                        break;
                }
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
            => Close();

        private void cmdMinimize_Click(object sender, EventArgs e)
            => WindowState = FormWindowState.Minimized;

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = AppStrings.FILTER_EFI_SUPPORTED_FIRMWARE
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdCopyMenu_Click(object sender, EventArgs e)
            => UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsCopy,
                MenuPosition.BottomLeft);

        private void cmdMenuFolders_Click(object sender, EventArgs e)
            => UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsFolders,
                MenuPosition.BottomLeft);

        private void cmdMenuExport_Click(object sender, EventArgs e)
            => UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsExport,
                MenuPosition.BottomLeft);

        private void cmdMenuPatch_Click(object sender, EventArgs e)
        {
            bool openEditor = Settings.ReadBoolean(Settings.BooleanKey.AcceptedEditingTerms);

            if (!openEditor)
            {
                BlurHelper.ApplyBlur(this);

                using (Form form = new frmTerms())
                {
                    form.FormClosed += ChildWindowClosed;
                    DialogResult dlgResult = form.ShowDialog();
                    openEditor = (dlgResult != DialogResult.No);
                }
            }

            if (openEditor)
            {
                UITools.ShowContextMenuAtControlPoint(
                    sender,
                    cmsPatch,
                    MenuPosition.BottomLeft);
            }
        }

        private void cmdMenuTools_Click(object sender, EventArgs e)
            => UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsTools,
                MenuPosition.BottomLeft);

        private void cmdMenuHelp_Click(object sender, EventArgs e)
            => UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsHelp,
                MenuPosition.BottomLeft);

        private void cmdOpenInExplorer_Click(object sender, EventArgs e)
            => UITools.HighlightPathInExplorer(_efirom.LoadedBinaryPath, this);
        #endregion

        #region Switch Events
        private void cbxCensor_CheckedChanged(object sender, EventArgs e)
            => UpdateSerialNumberControls();
        #endregion

        #region Label Events
        private void lblDxeArchiveGlyph_MouseEnter(object sender, EventArgs e)
        {
            Label control = (Label)sender;

            if (_efirom.LzmaDecompressedBuffer == null)
            {
                control.Cursor = Cursors.Default;
                return;
            }

            control.Cursor = Cursors.Hand;
        }

        private void lblDxeArchiveGlyph_Click(object sender, EventArgs e)
            => ExportDxeArchive();


        private void lblFmmEmailGlyph_MouseEnter(object sender, EventArgs e)
        {
            Label control = (Label)sender;

            if (string.IsNullOrEmpty(_efirom.MobileMeEmail))
            {
                control.Cursor = Cursors.Default;
                return;
            }

            control.Cursor = Cursors.Hand;
        }

        private void lblFmmEmailGlyph_Click(object sender, EventArgs e)
            => ExportFmmMobileMeEmail();

        private void lblEfiLockGlyph_MouseEnter(object sender, EventArgs e)
        {
            Label control = (Label)sender;

            if (_efirom.EfiPrimaryLockStatus.LockType != EfiLockType.Locked)
            {
                control.Cursor = Cursors.Default;
                return;
            }

            control.Cursor = Cursors.Hand;
        }

        private void lblEfiLockGlyph_Click(object sender, EventArgs e)
            => DisableEfiLock();
        #endregion

        #region Context Menu Events
        // Folders Context Menu
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e)
             => UITools.OpenFolderInExplorer(ApplicationPaths.BackupsDirectory, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.BuildsDirectory, this);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.FsysDirectory, this);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.IntelMeDirectory, this);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.NvramDirectory, this);

        private void openLZMADXEFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.LzmaDirectory, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.OpenFolderInExplorer(ApplicationPaths.WorkingDirectory, this);

        // Copy Context Menu
        private void filenameToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFilename(true);

        private void sizeBytesToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFileSize();

        private void crc32ToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFileCrc32();

        private void createdDateToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFileCreationTime();

        private void modifiedDateToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFileModifiedTime();

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareModel();

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareConfigCode();

        private void fsysBaseAddressToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFsysBaseAddress();

        private void fsysCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareFsysCrc32();

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string serial = _efirom.Fsys.Serial;

            if (string.IsNullOrEmpty(serial))
                return;

            Clipboard.SetText(serial);

            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"{AppStrings.SERIAL_NUMBER} " +
                    $"{EfiWindowStrings.COPIED_TO_CB_LC}",
                    METPrompt.PType.Information,
                    METPrompt.PButtons.Okay);
            }
        }

        private void hwcToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareHwc();

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareOrderNumber();

        private void efiVersionToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareVersion();

        private void vSSBaseAddressToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetVssBaseAddress();

        private void sVSBaseAddressToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetSvsBaseAddress();

        private void boardIDToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareBoardId();

        private void fitVersionToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareFitVersion();

        private void meVersionToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetFirmwareMeVersion();

        private void pdrBaseToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetPdrRegionOffsets();

        private void meBaseToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetMeRegionOffsets();

        private void biosBaseToolStripMenuItem_Click(object sender, EventArgs e)
            => ClipboardSetBiosRegionOffsets();

        // Export Context Menu
        private void exportFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = AppStrings.FILTER_BIN,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EfiWindowStrings.FSYS_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.FsysDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                if (FileTools.WriteAllBytesEx(dialog.FileName, _efirom.Fsys.Buffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DialogStrings.FSYS_EXPORT_FAIL,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void exportIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_efirom.Descriptor.MeBase == 0 || _efirom.Descriptor.MeLimit == 0)
            {
                METPrompt.Show(
                    this,
                    DialogStrings.IME_BASE_LIM_NOT_FOUND,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);

                return;
            }

            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = AppStrings.FILTER_BIN,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EfiWindowStrings.ME_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.IntelMeDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                byte[] meBuffer = BinaryTools.GetBytesBaseLength(_efirom.LoadedBinaryBuffer, (int)_efirom.Descriptor.MeBase, (int)_efirom.Descriptor.MeSize);

                if (FileTools.WriteAllBytesEx(dialog.FileName, meBuffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DialogStrings.IME_EXPORT_FAIL,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void exportNVRAMVSSStoresToolStripMenuItem_Click(object sender, EventArgs e)
            => ExportNVRAM(_efirom.VssPrimary, _efirom.VssSecondary, NvramStoreType.Variable, this);

        private void exportNVRAMSVSStoresToolStripMenuItem_Click(object sender, EventArgs e)
            => ExportNVRAM(_efirom.SvsPrimary, _efirom.SvsSecondary, NvramStoreType.Secure, this);

        internal void ExportNVRAM(NvramStore nvramprimary, NvramStore nvramsecondary, NvramStoreType nvramstoretype, Form owner)
        {
            Program.EnsureDirectoriesExist();

            switch (nvramstoretype)
            {
                case NvramStoreType.Variable:
                    SaveFilesInFolder(nvramprimary.StoreBuffer, nvramsecondary.StoreBuffer, "VSS", owner);
                    break;
                case NvramStoreType.Secure:
                    SaveFilesInFolder(nvramprimary.StoreBuffer, nvramsecondary.StoreBuffer, "SVS", owner);
                    break;
            }
        }

        private void SaveFilesInFolder(byte[] primarystore, byte[] secondarystore, string nvramstoretype, Form owner)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = AppStrings.SELECT_FOLDER,
                SelectedPath = ApplicationPaths.NvramDirectory
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(dialog.SelectedPath, $"{nvramstoretype}_{_efirom.FirmwareInfo.FileName}");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (primarystore != null)
                    {
                        SaveFile(Path.Combine(path, $"{nvramstoretype}_{EfiWindowStrings.PRIMARY_REGION}_{_efirom.FirmwareInfo.FileName}.bin"), primarystore);
                    }

                    if (secondarystore != null)
                    {
                        SaveFile(Path.Combine(path, $"{nvramstoretype}_{EfiWindowStrings.BACKUP_REGION}_{_efirom.FirmwareInfo.FileName}.bin"), secondarystore);
                    }

                    UITools.ShowOpenFolderInExplorerPrompt(owner, path);
                }
            }
        }

        private static void SaveFile(string filepath, byte[] buffer)
            => File.WriteAllBytes(filepath, buffer);

        private void exportDXEArchiveToolStripMenuItem_Click(object sender, EventArgs e)
            => ExportDxeArchive();

        private void backupFirmwareZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                InitialDirectory = ApplicationPaths.BackupsDirectory,
                Filter = AppStrings.FILTER_ZIP,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{AppStrings.EFIROM}_{AppStrings.BACKUP}",
                OverwritePrompt = true
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                FileTools.BackupFileToZip(_efirom.LoadedBinaryBuffer, _efirom.FirmwareInfo.FileNameExt, dialog.FileName);

                if (File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DialogStrings.ARCHIVE_CREATE_FAILED,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void exportFirmwareInformationTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = AppStrings.FILTER_TEXT,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{AppStrings.FIRMWARE_INFO}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("File");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Filename:        {_efirom.FirmwareInfo.FileNameExt}");
                builder.AppendLine($"Size (Bytes):    {FileTools.FormatBytesWithCommas(_efirom.FirmwareInfo.Length)} bytes");
                builder.AppendLine($"Size (MB):       {FileTools.FormatBytesToReadableUnit((ulong)_efirom.FirmwareInfo.Length)}");
                builder.AppendLine($"Size (Hex):      {_efirom.FirmwareInfo.Length:X}h");
                builder.AppendLine($"Entropy:         {_efirom.FirmwareInfo.Entropy}");
                builder.AppendLine($"SHA256:          {_efirom.FirmwareInfo.SHA256}");
                builder.AppendLine($"CRC32:           {_efirom.FirmwareInfo.CRC32:X8}");
                builder.AppendLine($"Created:         {_efirom.FirmwareInfo.CreationTime}");
                builder.AppendLine($"Modified:        {_efirom.FirmwareInfo.LastWriteTime}\r\n");

                builder.AppendLine("Descriptor");
                builder.AppendLine("----------------------------------");
                if (_efirom.Descriptor.IsDescriptorMode)
                {
                    builder.AppendLine(
                        $"PDR Region:      Base: {_efirom.Descriptor.PdrBase:X}h, " +
                        $"Limit: {_efirom.Descriptor.PdrLimit:X}h, " +
                        $"Size: {_efirom.Descriptor.PdrSize:X}h");
                    builder.AppendLine(
                        $"ME Region:       Base: {_efirom.Descriptor.MeBase:X}h, " +
                        $"Limit: {_efirom.Descriptor.MeLimit:X}h, " +
                        $"Size: {_efirom.Descriptor.MeSize:X}h");
                    builder.AppendLine(
                        $"BIOS Region:     Base: {_efirom.Descriptor.BiosBase:X}h, " +
                        $"Limit: {_efirom.Descriptor.BiosLimit:X}h, " +
                        $"Size: {_efirom.Descriptor.BiosSize:X}h\r\n");
                }
                else
                {
                    builder.AppendLine("Descriptor mode is disabled.\r\n");
                }

                builder.AppendLine("Model");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Identifier:      {_efirom.EfiBiosIdSectionData.ModelPart ?? "N/A"}");
                builder.AppendLine($"Model:           {MacTools.ConvertEfiModelCode(_efirom.EfiBiosIdSectionData.ModelPart) ?? "N/A"}");
                builder.AppendLine($"Configuration:   {_efirom.ConfigCode ?? "N/A"}");
                builder.AppendLine($"Board ID:        {_efirom.PdrSectionData.BoardId ?? "N/A"}\r\n");

                builder.AppendLine("Fsys");
                builder.AppendLine("----------------------------------");
                if (_efirom.Fsys.Buffer != null)
                {
                    builder.AppendLine($"Base:            {_efirom.Fsys.BaseAddress:X}h");
                    builder.AppendLine($"Size:            {_efirom.Fsys.Size:X}h");
                    builder.AppendLine($"CRC32:           {_efirom.Fsys.CrcString ?? "N/A"}");
                    builder.AppendLine($"Serial:          {_efirom.Fsys.Serial ?? "N/A"}");
                    builder.AppendLine($"HWC:             {_efirom.Fsys.HWC ?? "N/A"}");
                    builder.AppendLine($"SON:             {_efirom.Fsys.SON ?? "N/A"}\r\n");
                }
                else
                {
                    builder.AppendLine("Not found\r\n");
                }

                builder.AppendLine("Firmware");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"EFI Version:     {_efirom.FirmwareVersion ?? "N/A"}");
                builder.AppendLine($"EFI Lock:        {_efirom.EfiPrimaryLockStatus.LockType.ToString() ?? "N/A"}");
                builder.AppendLine($"APFS Capable:    {_efirom.IsApfsCapable.ToString() ?? "N/A"}\r\n");

                File.WriteAllText(dialog.FileName, builder.ToString());

                builder.Clear();

                if (!File.Exists(dialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DialogStrings.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }

        private void exportFmmmobilemeEmailTextToolStripMenuItem_Click(object sender, EventArgs e)
            => ExportFmmMobileMeEmail();

        // Patch Context Menu
        private void changeSerialNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (frmSerialSelect form = new frmSerialSelect(_efirom))
            {
                form.Tag = SerialSenderTag.EFIROMWindow;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    byte[] patchedBuffer = _patcher.WriteNewSerial(_efirom.NewSerial, _efirom);

                    if (patchedBuffer == null)
                    {
                        NotifyPatchingFailure();
                        return;
                    }

                    HandlePostPatch(patchedBuffer);
                }
            }
        }

        private void eraseNvramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (frmNvramSelect form = new frmNvramSelect(_efirom))
            {
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    Logger.WriteCallerLine(LogStrings.PATCH_START);

                    // Load current firmware into buffer.
                    byte[] patchedBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);

                    // Erase NVRAM sections if required
                    if (_efirom.ResetNvVariableStore)
                    {
                        Logger.WriteCallerLine(LogStrings.NVRAM_VSS_ERASE);
                        _patcher.CheckEraseStore(nameof(_efirom.VssPrimary), _efirom.VssPrimary, patchedBuffer);
                        _patcher.CheckEraseStore(nameof(_efirom.VssSecondary), _efirom.VssSecondary, patchedBuffer);
                    }

                    if (_efirom.ResetNvSecureStore)
                    {
                        Logger.WriteCallerLine(LogStrings.NVRAM_SVS_ERASE);
                        _patcher.CheckEraseStore(nameof(_efirom.SvsPrimary), _efirom.SvsPrimary, patchedBuffer);
                        _patcher.CheckEraseStore(nameof(_efirom.SvsSecondary), _efirom.SvsSecondary, patchedBuffer);
                    }

                    Logger.WriteCallerLine(LogStrings.PATCH_SUCCESS);

                    HandlePostPatch(patchedBuffer);
                }
            }
        }

        private void replaceFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] patchedBuffer = _patcher.WriteNewFsysStore(_efirom);

            if (patchedBuffer == null)
            {
                NotifyPatchingFailure();
                return;
            }

            HandlePostPatch(patchedBuffer);
        }

        private void replaceIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] patchedBuffer = _patcher.WriteNewIntelMeRegion(_efirom);

            if (patchedBuffer == null)
            {
                NotifyPatchingFailure();
                return;
            }

            HandlePostPatch(patchedBuffer);
        }

        private void fixFsysChecksumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] patchedBuffer =
                _patcher.MakeFsysCrcPatchedBinary(
                    BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer),
                    _efirom.Fsys.BaseAddress,
                    _efirom.Fsys.Buffer,
                    _efirom.Fsys.CrcActual,
                    _efirom.Fsys.Size,
                    _efirom);

            if (patchedBuffer == null)
            {
                NotifyPatchingFailure();
                return;
            }

            HandlePostPatch(patchedBuffer);
        }

        private void DisableEFILockToolStripMenuItem_Click(object sender, EventArgs e)
            => DisableEfiLock();

        // Tools Context Menu
        private void generateFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string model = _efirom.EfiBiosIdSectionData.ModelPart ?? EfiWindowStrings.NOMODEL;
            string version = _efirom.FirmwareVersion ?? EfiWindowStrings.NOFWVER;
            string serial = _efirom.Fsys.Serial ?? EfiWindowStrings.NOSERIAL;

            SetClipboardText($"{model}_{version}_{serial}");
        }

        private void lookupSerialNumberToolStripMenuItem_Click(object sender, EventArgs e) =>
            MacTools.LookupSerialOnEveryMac(_efirom.Fsys.Serial);

        private void viewRomInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmRominfo(_efirom))
            {
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }

        private void resetWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                ToggleControlEnable(false);
                ResetWindow();
                return;
            }

            DialogResult result =
                METPrompt.Show(
                    this,
                    DialogStrings.UNLOAD_FIRMWARE_RESET,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetWindow();
            }
        }
        private void reloadFileFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_efirom.LoadedBinaryPath))
            {
                METPrompt.Show(
                    this,
                    DialogStrings.COULD_NOT_RELOAD,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file.
            byte[] binaryBuffer = File.ReadAllBytes(_efirom.LoadedBinaryPath);

            // Check if the binaries match in size and data.
            if (BinaryTools.ByteArraysMatch(binaryBuffer, _efirom.LoadedBinaryBuffer))
            {
                // Loaded binaries match.
                METPrompt.Show(
                    this,
                    DialogStrings.WARN_DATA_MATCHES_BUFF,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            OpenBinary(_efirom.LoadedBinaryPath);
        }

        // Help Context Menu

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.GithubManual);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
            => Logger.OpenLogFile(this);

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmAbout())
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmSettings())
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }
        #endregion

        #region Open binary
        private void OpenBinary(string filepath)
        {
            // Check the filesize
            if (!FirmwareFile.IsValidMinMaxSize(filepath, this, FirmwareFile.MIN_IMAGE_SIZE, FirmwareFile.MAX_IMAGE_SIZE))
                return;

            // Check if the image is what we're looking for.
            if (!_efirom.IsValidImage(File.ReadAllBytes(filepath)))
            {
                METPrompt.Show(
                    this,
                    DialogStrings.NOT_VALID_EFIROM,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            // If a firmware is loaded, reset all data.
            if (_efirom.FirmwareLoaded)
            {
                ResetWindow();
            }

            ToggleControlEnable(false);

            // Set the binary path and load the bytes.
            _efirom.LoadedBinaryPath = filepath;
            _efirom.LoadedBinaryBuffer = File.ReadAllBytes(filepath);

            // Set the current directory.
            _strInitialDirectory = Path.GetDirectoryName(filepath);

            // Show loading bar.
            pbxLoad.Image = Properties.Resources.loading;

            // Load the firmware base in a separate thread.
            _tLoadFirmware = new Thread(() => LoadFirmwareBase(filepath, _cancellationToken.Token)) { IsBackground = true };
            _tLoadFirmware.Start();
        }

        private void LoadFirmwareBase(string filepath, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            _efirom.LoadFirmwareBaseData(_efirom.LoadedBinaryBuffer, filepath);

            if (token.IsCancellationRequested)
                return;

            if (this.IsHandleCreated && !token.IsCancellationRequested)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateUIControls();
                    });
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }

            if (!token.IsCancellationRequested)
            {
                _efirom.FirmwareLoaded = true;
            }
        }
        #endregion

        #region User Interface
        internal void UpdateUIControls()
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
            UpdateDxeArchiveControls();
            UpdateFmmEmailControls();

            // Apply DISABLED_TEXT to N/A labels.
            UITools.ApplyNestedPanelLabelForeColor(tlpFirmware, ApplicationColours.DisabledText);

            // Check which descriptor copy menu items should be enabled.
            pdrBaseToolStripMenuItem.Enabled = _efirom.Descriptor.PdrBase != 0;
            meBaseToolStripMenuItem.Enabled = _efirom.Descriptor.MeBase != 0;
            biosBaseToolStripMenuItem.Enabled = _efirom.Descriptor.BiosBase != 0;

            // Update window title.
            UpdateWindowTitle();

            // Hide loading image.
            pbxLoad.Image = null;

            // Check and set control enable.
            ToggleControlEnable(true);
        }

        private void UpdateParseTimeControls()
            => lblParseTime.Text = $"{_efirom.ParseTime.TotalSeconds:F2}s";

        private void UpdateFileNameControls()
            => lblFilename.Text = $"{AppStrings.FILE}: '{_efirom.FirmwareInfo.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            long length = _efirom.FirmwareInfo.Length;
            bool validSize = FirmwareFile.IsValidBinSize(length);

            lblFilesize.Text = $"{FileTools.FormatBytesWithCommas(length)} {AppStrings.BYTES} ({length:X}h)";

            if (!validSize)
            {
                lblFilesize.ForeColor = ApplicationColours.Error;
                lblFilesize.Text += validSize ? string.Empty : $" ({FirmwareFile.CalculateInvalidSize(length)})";
            }
        }

        private void UpdateFileCrc32Controls()
            => lblFileCrc32.Text = $"{_efirom.FirmwareInfo.CRC32:X8}";

        private void UpdateFileCreationDateControls()
            => lblFileCreatedDate.Text = _efirom.FirmwareInfo.CreationTime;

        private void UpdateFileModifiedDateControls()
            => lblFileModifiedDate.Text = _efirom.FirmwareInfo.LastWriteTime;

        private void UpdateModelControls()
        {
            string identifier = _efirom.EfiBiosIdSectionData.ModelPart;

            if (!string.IsNullOrEmpty(identifier))
            {
                string model = MacTools.ConvertEfiModelCode(_efirom.EfiBiosIdSectionData.ModelPart);
                lblModel.Text = $"{model} ({identifier})" ?? AppStrings.NA;
                modelToolStripMenuItem.Enabled = true;
                return;
            }

            lblModel.Text = AppStrings.NA;
            modelToolStripMenuItem.Enabled = false;
        }

        private void UpdateConfigCodeControls()
        {
            if (!string.IsNullOrEmpty(_efirom.ConfigCode))
            {
                lblConfigCode.Text = _efirom.ConfigCode;
                configurationToolStripMenuItem.Enabled = true;
                return;
            }

            lblConfigCode.Text = AppStrings.CONTACT_SERVER;
            lblConfigCode.ForeColor = ApplicationColours.Information;
            GetConfigCodeAsync(_efirom.Fsys.HWC);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configCode = await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configCode))
            {
                _efirom.ConfigCode = configCode;
                lblConfigCode.Text = configCode;
                lblConfigCode.ForeColor = ApplicationColours.NormalText;
                configurationToolStripMenuItem.Enabled = true;
                return;
            }

            lblConfigCode.Text = AppStrings.NA;
            lblConfigCode.ForeColor = ApplicationColours.DisabledText;
            configurationToolStripMenuItem.Enabled = false;
        }

        private void UpdateFsysControls()
        {
            if (_efirom.Fsys.BaseAddress != -1)
            {
                lblFsysStore.Text = $"{_efirom.Fsys.BaseAddress:X2}h";
                bool crcMatch = string.Equals(_efirom.Fsys.CrcString, _efirom.Fsys.CrcActualString);

                if (!string.IsNullOrEmpty(_efirom.Fsys.CrcString))
                {
                    lblFsysStore.Text += crcMatch ? $" ({EfiWindowStrings.CRC_VALID})" : $" ({EfiWindowStrings.CRC_INVALID})";
                    lblFsysStore.ForeColor = crcMatch ? lblFsysStore.ForeColor : ApplicationColours.Warning;
                }

                if (_efirom.ForceFoundFsys)
                {
                    lblFsysStore.Text += " [F]";
                }

                fsysBaseAddressToolStripMenuItem.Enabled = true;
                fsysCRC32ToolStripMenuItem.Enabled = true;

                return;
            }

            fsysBaseAddressToolStripMenuItem.Enabled = false;
            fsysCRC32ToolStripMenuItem.Enabled = false;
            lblFsysStore.Text = AppStrings.NA;
        }

        private void UpdateSerialNumberControls()
        {
            string serial = _efirom.Fsys.Serial;

            if (!string.IsNullOrEmpty(serial))
            {
                if (cbxCensor.Checked)
                {
                    lblSerialNumber.Text = serial;
                }
                else
                {
                    if (serial.Length == 11)
                    {
                        lblSerialNumber.Text = $"{serial.Substring(0, 2)}******{serial.Substring(8, 3)}";
                    }
                    else if (serial.Length == 12)
                    {
                        lblSerialNumber.Text = $"{serial.Substring(0, 2)}******{serial.Substring(8, 4)}";
                    }
                }

                if (!Serial.IsValid(serial))
                {
                    lblSerialNumber.ForeColor = ApplicationColours.Warning;
                }

                cbxCensor.Enabled = true;
                serialToolStripMenuItem.Enabled = true;
            }
            else
            {
                lblSerialNumber.Text = AppStrings.NA;
                cbxCensor.Enabled = false;
                serialToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateHardwareConfigControls()
        {
            string hwc = _efirom.Fsys.HWC;
            lblHwc.Text = hwc ?? AppStrings.NA;

            if (!string.IsNullOrEmpty(hwc))
            {
                hwcToolStripMenuItem.Enabled = true;

                return;
            }

            hwcToolStripMenuItem.Enabled = false;
        }

        private void UpdateOrderNumberControls()
        {
            string son = _efirom.Fsys.SON;
            lblOrderNumber.Text = son ?? AppStrings.NA;

            if (!string.IsNullOrEmpty(son))
            {
                orderNoToolStripMenuItem.Enabled = true;
                return;
            }

            orderNoToolStripMenuItem.Enabled = false;
        }

        private void UpdateEfiVersionControls()
        {
            string efiVersion = _efirom.FirmwareVersion;
            lblEfiVersion.Text = efiVersion ?? AppStrings.NA;

            if (!string.IsNullOrEmpty(efiVersion))
            {
                efiVersionToolStripMenuItem.Enabled = true;
                return;
            }

            efiVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateBoardIdControls()
        {
            string boardId = _efirom.PdrSectionData.BoardId;
            lblBoardId.Text = boardId ?? AppStrings.NA;

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
            int vssBase = _efirom.VssPrimary.StoreBase;
            int svsBase = _efirom.SvsPrimary.StoreBase;
            bool vssStoreEmpty = _efirom.VssPrimary.IsStoreEmpty;
            bool svsStoreEmpty = _efirom.SvsPrimary.IsStoreEmpty;

            // Update labels and menu items
            UpdateStoreDisplay(lblVss, vSSBaseAddressToolStripMenuItem, vssBase, vssStoreEmpty);
            UpdateStoreDisplay(lblSvs, sVSBaseAddressToolStripMenuItem, svsBase, svsStoreEmpty);
        }

        private static void UpdateStoreDisplay(Label label, ToolStripMenuItem menuitem, int baseposition, bool isstoreempty)
        {
            if (baseposition != -1)
            {
                label.Text = $"{baseposition:X2}h {(isstoreempty ? $"[{EfiWindowStrings.EMPTY}]" : $"[{EfiWindowStrings.ACTIVE}]")}";
                menuitem.Enabled = true;
            }
            else
            {
                label.Text = AppStrings.NA;
                menuitem.Enabled = false;
            }
        }

        private void UpdateEfiLockControls()
        {
            switch (_efirom.EfiPrimaryLockStatus.LockType)
            {
                case EfiLockType.Locked:
                    lblEfiLock.Text = EfiWindowStrings.LOCKED.ToUpper();
                    lblEfiLockGlyph.ForeColor = ApplicationColours.Warning;
                    break;
                case EfiLockType.Unlocked:
                    lblEfiLock.Text = EfiWindowStrings.UNLOCKED.ToUpper();
                    break;
                case EfiLockType.Unknown:
                default:
                    lblEfiLock.Text = AppStrings.UNKNOWN.ToUpper();
                    break;
            }
        }

        private void UpdateApfsCapableControls()
        {
            switch (_efirom.IsApfsCapable)
            {
                case ApfsCapableType.Yes:
                    lblApfsCapable.Text = EfiWindowStrings.APFS_DRIVER_FOUND;
                    lblApfsGlyph.ForeColor = ApplicationColours.GlyphActive;
                    break;
                case ApfsCapableType.No:
                    lblApfsCapable.Text = EfiWindowStrings.APFS_DRIVER_NOT_FOUND;
                    break;
                case ApfsCapableType.Unknown:
                    lblApfsCapable.Text = AppStrings.UNKNOWN.ToUpper();
                    break;
            }
        }

        private void UpdateDescriptorModeControls()
            => lblDescriptorMode.Text = $"{_efirom.Descriptor.IsDescriptorMode}";

        private void UpdateIntelMeControls()
        {
            string meVersion = _efirom.MeVersion;

            lblMeVersion.Text = meVersion ?? AppStrings.NA;

            if (!string.IsNullOrEmpty(meVersion))
            {
                if (_efirom.Descriptor.MeBase != 0)
                {
                    if (!string.IsNullOrEmpty(meVersion))
                    {
                        lblMeVersion.Text += $" ({_efirom.Descriptor.MeBase:X}h)";
                    }
                }

                meVersionToolStripMenuItem.Enabled = true;
                return;
            }

            meVersionToolStripMenuItem.Enabled = false;
        }

        private void UpdateIntelFitControls()
            => fitVersionToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_efirom.FitVersion);

        private void UpdateDxeArchiveControls()
            => lblDxeArchiveGlyph.ForeColor = _efirom.LzmaDecompressedBuffer != null
            ? ApplicationColours.GlyphActive
            : ApplicationColours.GlyphDefault;

        private void UpdateFmmEmailControls() =>
            lblFmmEmailGlyph.ForeColor = _efirom.MobileMeEmail != null
            ? ApplicationColours.GlyphActive
            : ApplicationColours.GlyphDefault;

        private void ChildWindowClosed(object sender, EventArgs e)
            => BlurHelper.RemoveBlur(this);

        private void EnableButtons(bool enable, params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = enable;
            }
        }

        private void EnableMenus(bool enable, params ContextMenuStrip[] contextmenustrips)
        {
            foreach (ContextMenuStrip menu in contextmenustrips)
            {
                menu.Enabled = enable;
            }
        }

        private void ToggleControlEnable(bool enable)
        {
            EnableButtons(enable, _menuButtons);
            EnableMenus(enable, _contextMenus);

            if (enable)
            {
                // Logic for enabling menus when controls are enabled.
                bool fsysBufferNull = _efirom.Fsys.Buffer != null;
                bool fsysCrcMatch = fsysBufferNull && !string.Equals(_efirom.Fsys.CrcActualString, _efirom.Fsys.CrcString);
                bool allNvramStoresEmpty =
                    _efirom.VssPrimary.IsStoreEmpty &&
                    _efirom.VssSecondary.IsStoreEmpty &&
                    _efirom.SvsPrimary.IsStoreEmpty &&
                    _efirom.SvsSecondary.IsStoreEmpty;

                // Export Menu.
                exportFsysStoreToolStripMenuItem.Enabled = fsysBufferNull;
                exportIntelMERegionToolStripMenuItem.Enabled = _efirom.Descriptor.IsDescriptorMode && _efirom.Descriptor.MeBase != 0 && _efirom.Descriptor.MeLimit != 0;
                exportNVRAMVSSStoresToolStripMenuItem.Enabled = !_efirom.VssPrimary.IsStoreEmpty || !_efirom.VssSecondary.IsStoreEmpty;
                exportNVRAMSVSStoresToolStripMenuItem.Enabled = !_efirom.SvsPrimary.IsStoreEmpty || !_efirom.SvsSecondary.IsStoreEmpty;
                exportLZMADXEArchiveToolStripMenuItem.Enabled = _efirom.LzmaDecompressedBuffer != null;
                exportFmmmobilemeEmailTextToolStripMenuItem.Enabled = _efirom.MobileMeEmail != null;

                // Patch Menu.
                changeSerialNumberToolStripMenuItem.Enabled = _efirom.Fsys.BaseAddress != -1 && _efirom.Fsys.SerialBase != -1;
                replaceIntelMERegionToolStripMenuItem.Enabled = _efirom.Descriptor.IsDescriptorMode && _efirom.Descriptor.MeBase != 0 && _efirom.Descriptor.MeLimit != 0;
                replaceFsysStoreToolStripMenuItem.Enabled = _efirom.Fsys.BaseAddress != -1;
                eraseNVRAMToolStripMenuItem.Enabled = !allNvramStoresEmpty;
                fixFsysChecksumToolStripMenuItem.Enabled = fsysCrcMatch;
                DisableEFILockToolStripMenuItem.Enabled = _efirom.EfiPrimaryLockStatus.LockType == EfiLockType.Locked;

                // Options Menu.
                viewRomInformationToolStripMenuItem.Enabled = _efirom.AppleRomInfoSectionData.SectionExists;
                lookupSerialNumberToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_efirom.Fsys.Serial);
            }

            // Always enable/disable these controls.
            tlpFilename.Enabled = enable;
            tlpFirmware.Enabled = enable;
        }

        private void SetButtonFontAndGlyph()
        {
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.FluentRegular14, Text = ApplicationChars.FLUENT_DISMISS },
                new { Button = cmdOpenInExplorer, Font = Program.FluentRegular14, Text = ApplicationChars.FLUENT_FOLDEROPEN },
            };

            foreach (var control in buttons)
            {
                control.Button.Font = control.Font;
                control.Button.Text = control.Text;
            }
        }

        private void SetLabelFontAndGlyph()
        {
            var labels = new[]
            {
                new { Label = lblDxeArchiveGlyph, Font = Program.FluentRegular12, Text = ApplicationChars.FLUENT_ZIPFILLED },
                new { Label = lblFmmEmailGlyph, Font = Program.FluentRegular12, Text = ApplicationChars.FLUENT_MAILCHECKFILLED },
                new { Label = lblApfsGlyph, Font = Program.FluentRegular12, Text = ApplicationChars.FLUENT_FOLDERLIGHTENING },
                new { Label = lblEfiLockGlyph, Font = Program.FluentRegular12, Text = ApplicationChars.FLUENT_FOLDERPROHIBITED }
            };

            foreach (var control in labels)
            {
                control.Label.Font = control.Font;
                control.Label.Text = control.Text;
            }
        }

        private void GetAndDisableMenuItems()
        {
            _menuButtons = new Button[]
            {
                cmdMenuCopy,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuTools,
                cmdOpenInExplorer,
            };

            _contextMenus = new ContextMenuStrip[]
            {
                cmsCopy,
                cmsExport,
                cmsPatch,
                cmsTools
            };

            EnableButtons(false, _menuButtons);
            EnableMenus(false, _contextMenus);
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdMenuOpen,
                cmdMenuCopy,
                cmdMenuFolders,
                cmdOpenInExplorer,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuTools,
                cmdMenuHelp
            };

            foreach (Button button in buttons)
            {
                button.MouseEnter += HandleMouseEnterTip;
                button.MouseLeave += HandleMouseLeaveTip;
            }

            Label[] labels =
            {
                lblParseTime,
                lblDxeArchiveGlyph,
                lblFmmEmailGlyph,
                lblApfsGlyph,
                lblEfiLockGlyph
            };

            foreach (Label label in labels)
            {
                label.MouseEnter += HandleMouseEnterTip;
                label.MouseLeave += HandleMouseLeaveTip;
            }

            CheckBox[] checkBoxes =
            {
                cbxCensor
            };

            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.MouseEnter += HandleMouseEnterTip;
                checkBox.MouseLeave += HandleMouseLeaveTip;
                checkBox.CheckedChanged += HandleCheckBoxChanged;
            }
        }

        private void HandleMouseEnterTip(object sender, EventArgs e)
        {
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableTips))
            {
                Dictionary<object, string> tooltips = new Dictionary<object, string>
                {
                    { cmdMenuOpen, $"{EfiWindowStrings.MENU_TIP_OPEN} (CTRL + O)" },
                    { cmdMenuCopy, $"{EfiWindowStrings.MENU_TIP_COPY} (CTRL + C)" },
                    { cmdMenuFolders, $"{EfiWindowStrings.MENU_TIP_FOLDERS} (CTRL + L)" },
                    { cmdMenuExport, $"{EfiWindowStrings.MENU_TIP_EXPORT} (CTRL + E)"},
                    { cmdMenuPatch, $"{EfiWindowStrings.MENU_TIP_PATCH} (CTRL + P)"},
                    { cmdMenuTools, $"{EfiWindowStrings.MENU_TIP_TOOLS} (CTRL + T)"},
                    { cmdMenuHelp, $"{EfiWindowStrings.MENU_TIP_HELP} (CTRL + H)" },
                    { cmdOpenInExplorer, $"{EfiWindowStrings.MENU_TIP_OPENFILELOCATION} (CTRL + SHIFT + L)" },
                    { lblParseTime, AppStrings.FW_PARSE_TIME},
                    { cbxCensor, SwitchStateTipString() },
                    { lblDxeArchiveGlyph, DxeTipString() },
                    { lblFmmEmailGlyph, FMMEmailTipString() },
                    { lblApfsGlyph , APFSTipString() },
                    { lblEfiLockGlyph, EFILockTipString() }
                };

                if (tooltips.TryGetValue(sender, out string value))
                {
                    lblStatusBarTip.Text = value;
                }

                tooltips.Clear();
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
            => lblStatusBarTip.Text = string.Empty;

        private string SwitchStateTipString()
            => $"{(cbxCensor.Checked ? AppStrings.HIDE : AppStrings.SHOW)} {AppStrings.SERIAL_NUMBER} (CTRL + SHIFT + N)";

        private string DxeTipString()
            => _efirom.LzmaDecompressedBuffer != null
            ? EfiWindowStrings.LZMA_VOL_FOUND
            : string.Empty;

        private string APFSTipString()
            => _efirom.IsApfsCapable == ApfsCapableType.Yes
            ? EfiWindowStrings.EFI_APFS
            : string.Empty;

        private string FMMEmailTipString()
            => _efirom.MobileMeEmail != null
            ? EfiWindowStrings.FMM_EMAIL_FOUND
            : string.Empty;

        private string EFILockTipString()
            => _efirom.EfiPrimaryLockStatus.LockType == EfiLockType.Locked
            ? EfiWindowStrings.EFI_LOCKED
            : string.Empty;

        private void HandleCheckBoxChanged(object sender, EventArgs e)
        {
            if (sender == cbxCensor && cbxCensor.ClientRectangle.Contains(cbxCensor.PointToClient(Cursor.Position)))
            {
                if (!Settings.ReadBoolean(Settings.BooleanKey.DisableTips))
                {
                    lblStatusBarTip.Text = SwitchStateTipString();
                }
            }
        }

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
            this.Text = _efirom.FirmwareInfo.FileNameExt;
            lblTitle.Text = $"{AppStrings.EFIROM} {ApplicationChars.SEGUI_RIGHTWARDSARROW} {_efirom.FirmwareInfo.FileNameExt}";
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
                label.ForeColor = ApplicationColours.NormalText;
            }

            // Reset parse time.
            lblParseTime.Text = "0.00s";
            lblDxeArchiveGlyph.ForeColor = ApplicationColours.GlyphDefault;
            lblFmmEmailGlyph.ForeColor = ApplicationColours.GlyphDefault;
            lblEfiLockGlyph.ForeColor = ApplicationColours.GlyphDefault;
            lblApfsGlyph.ForeColor = ApplicationColours.GlyphDefault;

            // Reset window text.
            Text = AppStrings.EFIROM;
            lblTitle.Text = AppStrings.EFIROM;

            // Reset initial directory.
            SetInitialDirectory();

            _efirom.ResetFirmwareBaseData();
        }
        #endregion

        #region Set Clipboard Text
        private void SetClipboardText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Clipboard.SetText(text);

            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"'{text}' {EfiWindowStrings.COPIED_TO_CB_LC}",
                    METPrompt.PType.Information,
                    METPrompt.PButtons.Okay);
            }
        }

        private void ClipboardSetFilename(bool showFileExtension)
            => SetClipboardText(showFileExtension ? _efirom.FirmwareInfo.FileNameExt : _efirom.FirmwareInfo.FileName);

        private void ClipboardSetFileSize()
            => SetClipboardText(
                $"{FileTools.FormatBytesWithCommas(_efirom.FirmwareInfo.Length)} " +
                $"{AppStrings.BYTES} ({_efirom.FirmwareInfo.Length:X}h)");

        private void ClipboardSetFileCrc32()
            => SetClipboardText($"{_efirom.FirmwareInfo.CRC32:X8}");

        private void ClipboardSetFileCreationTime()
            => SetClipboardText(_efirom.FirmwareInfo.CreationTime);

        private void ClipboardSetFileModifiedTime()
            => SetClipboardText(_efirom.FirmwareInfo.LastWriteTime);

        private void ClipboardSetFirmwareModel()
            => SetClipboardText(MacTools.ConvertEfiModelCode(_efirom.EfiBiosIdSectionData.ModelPart));

        private void ClipboardSetFirmwareConfigCode()
            => SetClipboardText(_efirom.ConfigCode);

        private void ClipboardSetFsysBaseAddress()
            => SetClipboardText($"{_efirom.Fsys.BaseAddress:X2}");

        private void ClipboardSetFirmwareFsysCrc32()
            => SetClipboardText(_efirom.Fsys.CrcString);

        private void ClipboardSetFirmwareHwc()
            => SetClipboardText(_efirom.Fsys.HWC);

        private void ClipboardSetFirmwareOrderNumber()
            => SetClipboardText(_efirom.Fsys.SON);

        private void ClipboardSetFirmwareVersion()
            => SetClipboardText(_efirom.FirmwareVersion);

        private void ClipboardSetVssBaseAddress()
            => SetClipboardText($"{_efirom.VssPrimary.StoreBase:X2}");

        private void ClipboardSetSvsBaseAddress()
            => SetClipboardText($"{_efirom.SvsPrimary.StoreBase:X2}");

        private void ClipboardSetFirmwareBoardId()
            => SetClipboardText(_efirom.PdrSectionData.BoardId);

        private void ClipboardSetFirmwareFitVersion()
            => SetClipboardText(_efirom.FitVersion);

        private void ClipboardSetFirmwareMeVersion()
            => SetClipboardText(_efirom.MeVersion);

        private void ClipboardSetPdrRegionOffsets()
            => SetClipboardText(
                $"{AppStrings.BASE} {_efirom.Descriptor.PdrBase:X}h, " +
                $"{AppStrings.LIMIT} {_efirom.Descriptor.PdrLimit:X}h, " +
                $"{AppStrings.SIZE} {_efirom.Descriptor.PdrSize:X}h");

        private void ClipboardSetMeRegionOffsets()
            => SetClipboardText(
                $"{AppStrings.BASE} {_efirom.Descriptor.MeBase:X}h, " +
                $"{AppStrings.LIMIT} {_efirom.Descriptor.MeLimit:X}h, " +
                $"{AppStrings.SIZE} {_efirom.Descriptor.MeSize:X}h");

        private void ClipboardSetBiosRegionOffsets()
            => SetClipboardText(
                $"{AppStrings.BASE} {_efirom.Descriptor.BiosBase:X}h, " +
                $"{AppStrings.LIMIT} {_efirom.Descriptor.BiosLimit:X}h, " +
                $"{AppStrings.SIZE} {_efirom.Descriptor.BiosSize:X}h");
        #endregion

        #region Private Events
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
            lblDxeArchiveGlyph.MouseEnter += lblDxeArchiveGlyph_MouseEnter;
            lblFmmEmailGlyph.MouseEnter += lblFmmEmailGlyph_MouseEnter;
            lblEfiLockGlyph.MouseEnter += lblEfiLockGlyph_MouseEnter;
        }

        private void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(Settings.StringKey.EfiInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory) ? directory : ApplicationPaths.WorkingDirectory;
            }
        }

        private void ExportDxeArchive()
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = AppStrings.FILTER_LZMA,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EfiWindowStrings.DXE_ARCHIVE}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.LzmaDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                if (FileTools.WriteAllBytesEx(dialog.FileName, _efirom.LzmaDecompressedBuffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DialogStrings.ARCHIVE_EXPORT_FAIL,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void ExportFmmMobileMeEmail()
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = AppStrings.FILTER_TEXT,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EfiWindowStrings.FMM_EMAIL}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("Find My Mac Email:");
                builder.AppendLine("----------------------------------");
                builder.AppendLine(_efirom.MobileMeEmail);

                File.WriteAllText(dialog.FileName, builder.ToString());

                builder.Clear();

                if (!File.Exists(dialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DialogStrings.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }

        private void DisableEfiLock()
        {
            byte[] patchedBuffer = _patcher.RemoveEfiLock(_efirom);

            if (patchedBuffer == null)
            {
                NotifyPatchingFailure();
                return;
            }

            HandlePostPatch(patchedBuffer);
        }

        private void HandlePostPatch(byte[] patchedBuffer)
        {
            if (Prompts.ShowPatchSuccessPrompt(this) == DialogResult.Yes)
            {
                string savePath = _patcher.SaveOutputFirmware(patchedBuffer, _efirom);
                if (!string.IsNullOrEmpty(savePath) && Prompts.PromptLoadNewFirmware(this) == DialogResult.Yes)
                {
                    OpenBinary(savePath);
                }
            }
            else
            {
                Logger.WriteCallerLine(LogStrings.FILE_EXPORT_CANCELLED);
            }
        }
        #endregion
    }
}