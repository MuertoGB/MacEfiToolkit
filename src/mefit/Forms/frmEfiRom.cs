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
        // EFIROM instance
        private EFIROM _efirom = new EFIROM();

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

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);

            // Set tip handlers for controls.
            SetTipHandlers();

            // Set button properties.
            SetButtonFontAndGlyph();

            // Set label properties.
            SetLabelFontAndGlyph();

            // Get and disable menu items.
            GetAndDisableMenuItems();
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
                cmsCopy, cmsExport, cmsPatch, cmsTools
            };

            EnableButtons(false, _menuButtons);
            EnableMenus(false, _contextMenus);
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
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.Cancel();
            }

            MemoryTracker.Instance.OnMemoryUsageUpdated -= MemoryTracker_OnMemoryUsageUpdated;

            _efirom = null;
        }

        private void frmEfiRom_FormClosed(object sender, FormClosedEventArgs e) => _cancellationToken?.Dispose();

        private void frmEfiRom_DragEnter(object sender, DragEventArgs e) => Program.HandleDragEnter(sender, e, null);

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

        private void frmEfiRom_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.InactiveFormText);

        private void frmEfiRom_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.ActiveFormText);
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
        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void cmdMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_EFI_SUPPORTED_FIRMWARE
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
                }
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

        private void cmdMenuTools_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsTools,
                MenuPosition.BottomLeft);

        private void cmdMenuHelp_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsHelp,
                MenuPosition.BottomLeft);

        private void cmdOpenInExplorer_Click(object sender, EventArgs e) => UITools.HighlightPathInExplorer(_efirom.LoadedBinaryPath, this);
        #endregion

        #region Switch Events
        private void cbxCensor_CheckedChanged(object sender, EventArgs e) => UpdateSerialNumberControls();
        #endregion

        #region Label Events
        private void lblFmmEmail_MouseEnter(object sender, EventArgs e)
        {
            Label control = (Label)sender;

            if (_efirom.MobileMeEmail == null)
            {
                control.Cursor = Cursors.Default;
                return;
            }

            control.Cursor = Cursors.Hand;
        }

        private void lblFmmEmail_Click(object sender, EventArgs e)
        {
            if (_efirom.MobileMeEmail != null)
            {
                METPrompt.Show(this, _efirom.MobileMeEmail, METPrompt.PType.Information, METPrompt.PButtons.Okay);
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
            string serial = _efirom.Fsys.Serial;

            if (string.IsNullOrEmpty(serial))
            {
                return;
            }

            Clipboard.SetText(serial);

            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"{APPSTRINGS.SERIAL_NUMBER} " +
                    $"{EFISTRINGS.COPIED_TO_CB_LC}",
                    METPrompt.PType.Information,
                    METPrompt.PButtons.Okay);
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
            UITools.OpenFolderInExplorer(ApplicationPaths.BackupsDirectory, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.BuildsDirectory, this);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.FsysDirectory, this);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.IntelMeDirectory, this);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.NvramDirectory, this);

        private void openLZMADXEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.LzmaDirectory, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.WorkingDirectory, this);
        #endregion

        #region Export Toolstrip Events
        private void exportFsysStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EFISTRINGS.FSYS_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.FsysDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Save the Fsys stores bytes to disk.
                if (FileTools.WriteAllBytesEx(dialog.FileName, _efirom.Fsys.Buffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.FSYS_EXPORT_FAIL,
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
                    DIALOGSTRINGS.IME_BASE_LIM_NOT_FOUND,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);

                return;
            }

            Program.EnsureDirectoriesExist();

            // Set SaveFileDialog params.
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EFISTRINGS.ME_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.IntelMeDirectory
            })
            {
                // Action was cancelled.
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                byte[] meBuffer = BinaryTools.GetBytesBaseLength(_efirom.LoadedBinaryBuffer, (int)_efirom.Descriptor.MeBase, (int)_efirom.Descriptor.MeSize);

                if (FileTools.WriteAllBytesEx(dialog.FileName, meBuffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.IME_EXPORT_FAIL,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void exportNVRAMVSSStoresToolStripMenuItem_Click(object sender, EventArgs e) =>
            ExportNVRAM(_efirom.VssPrimary, _efirom.VssSecondary, NvramStoreType.Variable, this);

        private void exportNVRAMSVSStoresToolStripMenuItem_Click(object sender, EventArgs e) =>
            ExportNVRAM(_efirom.SvsPrimary, _efirom.SvsSecondary, NvramStoreType.Secure, this);

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
                Description = APPSTRINGS.SELECT_FOLDER,
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

                    if (primarystore != null) SaveFile(Path.Combine(path, $"{nvramstoretype}_{EFISTRINGS.PRIMARY_REGION}_{_efirom.FirmwareInfo.FileName}.bin"), primarystore);
                    if (secondarystore != null) SaveFile(Path.Combine(path, $"{nvramstoretype}_{EFISTRINGS.BACKUP_REGION}_{_efirom.FirmwareInfo.FileName}.bin"), secondarystore);

                    UITools.ShowOpenFolderInExplorerPrompt(owner, path);
                }
            }
        }

        private static void SaveFile(string filepath, byte[] buffer) => File.WriteAllBytes(filepath, buffer);

        private void exportLZMADXEArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_LZMA,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EFISTRINGS.DXE_ARCHIVE}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.LzmaDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (FileTools.WriteAllBytesEx(dialog.FileName, _efirom.LzmaDecompressedBuffer) && File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.ARCHIVE_EXPORT_FAIL,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void backupFirmwareZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                InitialDirectory = ApplicationPaths.BackupsDirectory,
                Filter = APPSTRINGS.FILTER_ZIP,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{APPSTRINGS.EFIROM}_{APPSTRINGS.BACKUP}",
                OverwritePrompt = true
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileTools.BackupFileToZip(_efirom.LoadedBinaryBuffer, _efirom.FirmwareInfo.FileNameExt, dialog.FileName);

                if (File.Exists(dialog.FileName))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.ARCHIVE_CREATE_FAILED,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);
            }
        }

        private void exportFirmwareInformationTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{APPSTRINGS.FIRMWARE_INFO}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("File");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Filename:        {_efirom.FirmwareInfo.FileNameExt}");
                builder.AppendLine($"Size (Bytes):    {FileTools.FormatBytesWithCommas(_efirom.FirmwareInfo.Length)} bytes");
                builder.AppendLine($"Size (MB):       {FileTools.FormatBytesToReadableUnit((ulong)_efirom.FirmwareInfo.Length)}");
                builder.AppendLine($"Size (Hex):      {_efirom.FirmwareInfo.Length:X}h");
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
                    builder.AppendLine("Fsys Store was not found.\r\n");
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
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }

        private void exportFmmmobilemeEmailTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{_efirom.FirmwareInfo.FileName}_{EFISTRINGS.FMM_EMAIL}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

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
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }
        #endregion

        #region Patch Toolstrip Events
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
                    WriteEfiromSerialNumber(_efirom.NewSerial);
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
                    EraseNvram(_efirom.ResetVss, _efirom.ResetSvs);
                }
            }
        }

        private void replaceFsysStoreToolStripMenuItem_Click(object sender, EventArgs e) => WriteFsysStore();

        private void replaceIntelMERegionToolStripMenuItem_Click(object sender, EventArgs e) => WriteIntelMeRegion();

        private void fixFsysChecksumToolStripMenuItem_Click(object sender, EventArgs e) => MaskFsysChecksum();

        private void invalidateEFILockToolStripMenuItem_Click(object sender, EventArgs e) => RemoveEfiLock();
        #endregion

        #region Tools Toolstrip Events
        private void generateFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string model = _efirom.EfiBiosIdSectionData.ModelPart ?? EFISTRINGS.NOMODEL;
            string version = _efirom.FirmwareVersion ?? EFISTRINGS.NOFWVER;
            string serial = _efirom.Fsys.Serial ?? EFISTRINGS.NOSERIAL;

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
                    DIALOGSTRINGS.UNLOAD_FIRMWARE_RESET,
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
                    DIALOGSTRINGS.COULD_NOT_RELOAD,
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
                    DIALOGSTRINGS.WARN_DATA_MATCHES_BUFF,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            OpenBinary(_efirom.LoadedBinaryPath);
        }
        #endregion

        #region Help Toolstrip Events
        private void manualToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.GithubManual);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e) => Logger.OpenLogFile(this);

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
            {
                return;
            }

            // Check if the image is what we're looking for.
            if (!_efirom.IsValidImage(File.ReadAllBytes(filepath)))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.NOT_VALID_EFIROM,
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
            {
                return;
            }

            _efirom.LoadFirmwareBaseData(_efirom.LoadedBinaryBuffer, filepath);

            if (token.IsCancellationRequested)
            {
                return;
            }

            if (this.IsHandleCreated && !token.IsCancellationRequested)
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

            if (!token.IsCancellationRequested)
            {
                _efirom.FirmwareLoaded = true;
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
            UITools.ApplyNestedPanelLabelForeColor(tlpFirmware, Colours.DisabledText);

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

        private void UpdateParseTimeControls() => lblParseTime.Text = $"{_efirom.ParseTime.TotalSeconds:F2}s";

        private void UpdateFileNameControls() => lblFilename.Text = $"{APPSTRINGS.FILE}: '{_efirom.FirmwareInfo.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            long length = _efirom.FirmwareInfo.Length;
            bool validSize = FirmwareFile.IsValidBinSize(length);

            lblFilesize.Text = $"{FileTools.FormatBytesWithCommas(length)} {APPSTRINGS.BYTES} ({length:X}h)";

            if (!validSize)
            {
                lblFilesize.ForeColor = Colours.Error;
                lblFilesize.Text += validSize ? string.Empty : $" ({FirmwareFile.CalculateInvalidSize(length)})";
            }
        }

        private void UpdateFileCrc32Controls() => lblFileCrc32.Text = $"{_efirom.FirmwareInfo.CRC32:X8}";

        private void UpdateFileCreationDateControls() => lblFileCreatedDate.Text = _efirom.FirmwareInfo.CreationTime;

        private void UpdateFileModifiedDateControls() => lblFileModifiedDate.Text = _efirom.FirmwareInfo.LastWriteTime;

        private void UpdateModelControls()
        {
            string identifier = _efirom.EfiBiosIdSectionData.ModelPart;

            if (!string.IsNullOrEmpty(identifier))
            {
                string model = MacTools.ConvertEfiModelCode(_efirom.EfiBiosIdSectionData.ModelPart);
                lblModel.Text = $"{model} ({identifier})" ?? APPSTRINGS.NA;
                modelToolStripMenuItem.Enabled = true;
                return;
            }

            lblModel.Text = APPSTRINGS.NA;
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

            lblConfigCode.Text = APPSTRINGS.CONTACT_SERVER;
            lblConfigCode.ForeColor = Colours.Information;
            GetConfigCodeAsync(_efirom.Fsys.HWC);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configCode = await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configCode))
            {
                _efirom.ConfigCode = configCode;
                lblConfigCode.Text = configCode;
                lblConfigCode.ForeColor = Colours.NormalText;
                configurationToolStripMenuItem.Enabled = true;
                return;
            }

            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.DisabledText;
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
                    lblFsysStore.Text += crcMatch ? $" ({EFISTRINGS.CRC_VALID})" : $" ({EFISTRINGS.CRC_INVALID})";
                    lblFsysStore.ForeColor = crcMatch ? lblFsysStore.ForeColor : Colours.Warning;
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
            lblFsysStore.Text = APPSTRINGS.NA;
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
                    lblSerialNumber.ForeColor = Colours.Warning;
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
            string hwc = _efirom.Fsys.HWC;
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
            string son = _efirom.Fsys.SON;
            lblOrderNumber.Text = son ?? APPSTRINGS.NA;

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
            string boardId = _efirom.PdrSectionData.BoardId;
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
                label.Text = $"{baseposition:X2}h {(isstoreempty ? $"[{EFISTRINGS.EMPTY}]" : $"[{EFISTRINGS.ACTIVE}]")}";
                menuitem.Enabled = true;
            }
            else
            {
                label.Text = APPSTRINGS.NA;
                menuitem.Enabled = false;
            }
        }

        private void UpdateEfiLockControls()
        {
            switch (_efirom.EfiPrimaryLockStatus.LockType)
            {
                case EfiLockType.Locked:
                    lblEfiLock.Text = EFISTRINGS.LOCKED.ToUpper();
                    lblEfiLock.ForeColor = Colours.Warning;
                    break;
                case EfiLockType.Unlocked:
                    lblEfiLock.Text = EFISTRINGS.UNLOCKED.ToUpper();
                    break;
                case EfiLockType.Unknown:
                default:
                    lblEfiLock.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblEfiLock.ForeColor = Colours.Warning;
                    break;
            }
        }

        private void UpdateApfsCapableControls()
        {
            switch (_efirom.IsApfsCapable)
            {
                case ApfsCapableType.Yes:
                    lblApfsCapable.Text = EFISTRINGS.APFS_DRIVER_FOUND;
                    break;
                case ApfsCapableType.No:
                    lblApfsCapable.Text = EFISTRINGS.APFS_DRIVER_NOT_FOUND;
                    lblApfsCapable.ForeColor = Colours.Warning;
                    break;
                case ApfsCapableType.Unknown:
                    lblApfsCapable.Text = APPSTRINGS.UNKNOWN.ToUpper();
                    lblApfsCapable.ForeColor = Colours.Warning;
                    break;
            }
        }

        private void UpdateDescriptorModeControls() => lblDescriptorMode.Text = $"{_efirom.Descriptor.IsDescriptorMode}";

        private void UpdateIntelMeControls()
        {
            string meVersion = _efirom.MeVersion;

            lblMeVersion.Text = meVersion ?? APPSTRINGS.NA;

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

        private void UpdateIntelFitControls() =>
            fitVersionToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_efirom.FitVersion);

        private void UpdateLzmaArchiveControls() =>
            lblLzma.ForeColor = _efirom.LzmaDecompressedBuffer != null ? Colours.GlyphActive : Colours.GlyphDefault;

        private void UpdateFmmEmailControls() =>
            lblFmmEmail.ForeColor = _efirom.MobileMeEmail != null ? Colours.GlyphActive : Colours.GlyphDefault;
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e) => BlurHelper.RemoveBlur(this);

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
                // Logic for enabling menus when controls are enabled
                bool fsysBufferNull = _efirom.Fsys.Buffer != null;
                bool fsysCrcMatch = fsysBufferNull && !string.Equals(_efirom.Fsys.CrcActualString, _efirom.Fsys.CrcString);
                bool allNvramStoresEmpty =
                    _efirom.VssPrimary.IsStoreEmpty &&
                    _efirom.VssSecondary.IsStoreEmpty &&
                    _efirom.SvsPrimary.IsStoreEmpty &&
                    _efirom.SvsSecondary.IsStoreEmpty;

                // Export Menu
                exportFsysStoreToolStripMenuItem.Enabled = fsysBufferNull;
                exportIntelMERegionToolStripMenuItem.Enabled = _efirom.Descriptor.IsDescriptorMode && _efirom.Descriptor.MeBase != 0 && _efirom.Descriptor.MeLimit != 0;
                exportNVRAMVSSStoresToolStripMenuItem.Enabled = !_efirom.VssPrimary.IsStoreEmpty || !_efirom.VssSecondary.IsStoreEmpty;
                exportNVRAMSVSStoresToolStripMenuItem.Enabled = !_efirom.SvsPrimary.IsStoreEmpty || !_efirom.SvsSecondary.IsStoreEmpty;
                exportLZMADXEArchiveToolStripMenuItem.Enabled = _efirom.LzmaDecompressedBuffer != null;
                exportFmmmobilemeEmailTextToolStripMenuItem.Enabled = _efirom.MobileMeEmail != null;

                // Patch Menu
                changeSerialNumberToolStripMenuItem.Enabled = _efirom.Fsys.BaseAddress != -1 && _efirom.Fsys.SerialBase != -1;
                replaceIntelMERegionToolStripMenuItem.Enabled = _efirom.Descriptor.IsDescriptorMode && _efirom.Descriptor.MeBase != 0 && _efirom.Descriptor.MeLimit != 0;
                replaceFsysStoreToolStripMenuItem.Enabled = _efirom.Fsys.BaseAddress != -1;
                eraseNVRAMToolStripMenuItem.Enabled = !allNvramStoresEmpty;
                fixFsysChecksumToolStripMenuItem.Enabled = fsysCrcMatch;
                invalidateEFILockToolStripMenuItem.Enabled = _efirom.EfiPrimaryLockStatus.LockType == EfiLockType.Locked;

                // Options Menu
                viewRomInformationToolStripMenuItem.Enabled = _efirom.AppleRomInfoSectionData.SectionExists;
                lookupSerialNumberToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_efirom.Fsys.Serial);
            }

            // Always enable/disable these controls
            tlpFilename.Enabled = enable;
            tlpFirmware.Enabled = enable;
        }

        private void SetButtonFontAndGlyph()
        {
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.FontSegMdl2Regular12, Text = Program.MDL2_EXIT_CROSS },
                new { Button = cmdOpenInExplorer, Font = Program.FontSegMdl2Regular12, Text = Program.MDL2_FILE_EXPLORER },
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }

        private void SetLabelFontAndGlyph()
        {
            lblLzma.Font = Program.FontSegMdl2Regular10;
            lblLzma.Text = Program.MDL2_REPORT;

            lblFmmEmail.Font = Program.FontSegMdl2Regular10;
            lblFmmEmail.Text = Program.MDL2_ACCOUNT;
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
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableTips))
            {
                Dictionary<object, string> tooltips = new Dictionary<object, string>
                {
                    { cmdMenuOpen, $"{EFISTRINGS.MENU_TIP_OPEN} (CTRL + O)" },
                    { cmdMenuCopy, $"{EFISTRINGS.MENU_TIP_COPY} (CTRL + C)" },
                    { cmdMenuFolders, $"{EFISTRINGS.MENU_TIP_FOLDERS} (CTRL + L)" },
                    { cmdMenuExport, $"{EFISTRINGS.MENU_TIP_EXPORT} (CTRL + E)"},
                    { cmdMenuPatch, $"{EFISTRINGS.MENU_TIP_PATCH} (CTRL + P)"},
                    { cmdMenuTools, $"{EFISTRINGS.MENU_TIP_TOOLS} (CTRL + T)"},
                    { cmdMenuHelp, $"{EFISTRINGS.MENU_TIP_HELP} (CTRL + H)" },
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
            $"{(cbxCensor.Checked ? APPSTRINGS.HIDE : APPSTRINGS.SHOW)} {APPSTRINGS.SERIAL_NUMBER} (CTRL + SHIFT + N)";

        private string lzmaString() =>
            _efirom.LzmaDecompressedBuffer != null ? EFISTRINGS.LZMA_VOL_FOUND : string.Empty;

        private string emailString() =>
            _efirom.MobileMeEmail != null ? EFISTRINGS.FMM_EMAIL_FOUND : string.Empty;

        private void HandleCheckBoxChanged(object sender, EventArgs e)
        {
            if (sender == cbxCensor && cbxCensor.ClientRectangle.Contains(cbxCensor.PointToClient(Cursor.Position)))
            {
                if (!Settings.ReadBoolean(Settings.BooleanKey.DisableTips))
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
            this.Text = _efirom.FirmwareInfo.FileNameExt;
            lblTitle.Text = $"{APPSTRINGS.EFIROM} {Program.MDL2_RIGHT_ARROW} {_efirom.FirmwareInfo.FileNameExt}";
        }
        #endregion

        #region Misc Events
        internal void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(Settings.StringKey.EfiInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory) ? directory : ApplicationPaths.WorkingDirectory;
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
                label.ForeColor = Colours.NormalText;
            }

            // Reset parse time.
            lblParseTime.Text = "0.00s";
            lblLzma.ForeColor = Colours.GlyphDefault;
            lblFmmEmail.ForeColor = Colours.GlyphDefault;

            // Reset window text.
            Text = APPSTRINGS.EFIROM;
            lblTitle.Text = APPSTRINGS.EFIROM;

            // Reset initial directory.
            SetInitialDirectory();

            _efirom.ResetFirmwareBaseData();
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

            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"'{text}' {EFISTRINGS.COPIED_TO_CB_LC}",
                    METPrompt.PType.Information,
                    METPrompt.PButtons.Okay);
            }
        }

        private void ClipboardSetFilename(bool showFileExtension) =>
            SetClipboardText(
                showFileExtension
                ? _efirom.FirmwareInfo.FileNameExt
                : _efirom.FirmwareInfo.FileName);

        private void ClipboardSetFileSize() =>
            SetClipboardText(
                $"{FileTools.FormatBytesWithCommas(_efirom.FirmwareInfo.Length)} " +
                $"{APPSTRINGS.BYTES} ({_efirom.FirmwareInfo.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText($"{_efirom.FirmwareInfo.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(_efirom.FirmwareInfo.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(_efirom.FirmwareInfo.LastWriteTime);

        private void ClipboardSetFirmwareModel() =>
            SetClipboardText(MacTools.ConvertEfiModelCode(_efirom.EfiBiosIdSectionData.ModelPart));

        private void ClipboardSetFirmwareConfigCode() => SetClipboardText(_efirom.ConfigCode);

        private void ClipboardSetFsysBaseAddress() => SetClipboardText($"{_efirom.Fsys.BaseAddress:X2}");

        private void ClipboardSetFirmwareFsysCrc32() => SetClipboardText(_efirom.Fsys.CrcString);

        private void ClipboardSetFirmwareHwc() => SetClipboardText(_efirom.Fsys.HWC);

        private void ClipboardSetFirmwareOrderNumber() => SetClipboardText(_efirom.Fsys.SON);

        private void ClipboardSetFirmwareVersion() => SetClipboardText(_efirom.FirmwareVersion);

        private void ClipboardSetVssBaseAddress() => SetClipboardText($"{_efirom.VssPrimary.StoreBase:X2}");

        private void ClipboardSetSvsBaseAddress() => SetClipboardText($"{_efirom.SvsPrimary.StoreBase:X2}");

        private void ClipboardSetFirmwareBoardId() => SetClipboardText(_efirom.PdrSectionData.BoardId);

        private void ClipboardSetFirmwareFitVersion() => SetClipboardText(_efirom.FitVersion);

        private void ClipboardSetFirmwareMeVersion() => SetClipboardText(_efirom.MeVersion);

        private void ClipboardSetPdrRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {_efirom.Descriptor.PdrBase:X}h, " +
                $"{APPSTRINGS.LIMIT} {_efirom.Descriptor.PdrLimit:X}h, " +
                $"{APPSTRINGS.SIZE} {_efirom.Descriptor.PdrSize:X}h");

        private void ClipboardSetMeRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {_efirom.Descriptor.MeBase:X}h, " +
                $"{APPSTRINGS.LIMIT} {_efirom.Descriptor.MeLimit:X}h, " +
                $"{APPSTRINGS.SIZE} {_efirom.Descriptor.MeSize:X}h");

        private void ClipboardSetBiosRegionOffsets() =>
            SetClipboardText(
                $"{APPSTRINGS.BASE} {_efirom.Descriptor.BiosBase:X}h, " +
                $"{APPSTRINGS.LIMIT} {_efirom.Descriptor.BiosLimit:X}h, " +
                $"{APPSTRINGS.SIZE} {_efirom.Descriptor.BiosSize:X}h");
        #endregion

        #region Write Serial
        private void WriteEfiromSerialNumber(string serial)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Check serial length.
            if (serial.Length != 11 && serial.Length != 12)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SERIAL_LEN_INVALID} ({serial.Length})");
                NotifyPatchingFailure();
                return;
            }

            // Check if the SerialBase exists.
            if (_efirom.Fsys.SerialBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                NotifyPatchingFailure();
                return;
            }

            // Create buffers.
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);
            byte[] newSerialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WriteCallerLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, _efirom.Fsys.SerialBase, newSerialBuffer);

            // Check HWC base and write new HWC.
            bool hwcBasePresent = _efirom.Fsys.HWCBase != -1;
            string newHwc = null;

            if (hwcBasePresent)
            {
                newHwc = serial.Substring(8, _efirom.Fsys.Serial.Length == 11 ? 3 : 4);
                byte[] newHwcBuffer = Encoding.UTF8.GetBytes(newHwc);

                Logger.WriteCallerLine(LOGSTRINGS.HWC_WTB);

                // Write new HWC.
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, _efirom.Fsys.HWCBase, newHwcBuffer);
            }

            Logger.WriteCallerLine(LOGSTRINGS.FSYS_LFB);

            // Load patched fsys from the binary buffer.
            FsysStore fsysStore = _efirom.ParseFsysStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, fsysStore.Serial))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_NOT_WRITTEN}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.SSN_WRITE_SUCCESS);

            // Verify the HWC was written correctly, if applicable.
            if (hwcBasePresent && fsysStore.HWCBase != -1 && !string.Equals(newHwc, fsysStore.HWC))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.HWC_NOT_WRITTEN}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.HWC_WRITE_SUCCESS);

            // Patch fsys checksum in the binary buffer.
            binaryBuffer = _efirom.MakeFsysCrcPatchedBinary(binaryBuffer, fsysStore.BaseAddress, fsysStore.Buffer, fsysStore.CrcActual, fsysStore.Size);

            // Reload fsys store from the binary buffer and verify CRC masking success.
            fsysStore = _efirom.ParseFsysStoreData(binaryBuffer, false);

            if (!string.Equals(fsysStore.CrcString, fsysStore.CrcActualString))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_SUM_MASK_FAIL}");
                NotifyPatchingFailure();
                return;
            }

            // Log success and prompt for saving the patched firmware.
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Erase NVRAM
        private void EraseNvram(bool resetvss, bool resetsvs)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Load current firmware into buffer.
            byte[] binaryBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);

            // Erase NVRAM sections if required
            if (resetvss)
            {
                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_VSS_ERASE);
                CheckEraseStore(nameof(_efirom.VssPrimary), _efirom.VssPrimary, binaryBuffer);
                CheckEraseStore(nameof(_efirom.VssSecondary), _efirom.VssSecondary, binaryBuffer);
            }

            if (resetsvs)
            {
                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_SVS_ERASE);
                CheckEraseStore(nameof(_efirom.SvsPrimary), _efirom.SvsPrimary, binaryBuffer);
                CheckEraseStore(nameof(_efirom.SvsSecondary), _efirom.SvsSecondary, binaryBuffer);
            }

            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }

        private void CheckEraseStore(string storename, NvramStore nvramstore, byte[] buffer)
        {
            if (nvramstore.StoreBase == -1)
            {
                Logger.WriteCallerLine($"{storename} {LOGSTRINGS.NVR_BASE_NOT_FOUND}");
            }
            else if (nvramstore.IsStoreEmpty)
            {
                Logger.WriteCallerLine($"{storename} {LOGSTRINGS.NVR_IS_EMPTY}");
            }
            else if (!GetAndEraseStore(storename, nvramstore, buffer))
            {
                return;
            }
        }

        private bool GetAndEraseStore(string storename, NvramStore nvramstore, byte[] binarybuffer)
        {
            Logger.WriteCallerLine($"{storename} {LOGSTRINGS.AT} {nvramstore.StoreBase:X}h {LOGSTRINGS.NVR_HAS_BODY_ERASING}");

            byte[] erasedBuffer = EraseNvramStore(NvramStoreType.Variable, nvramstore);

            if (erasedBuffer == null)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.NVR_FAIL_ERASE_BODY} ({storename})");
                NotifyPatchingFailure();
                return false;
            }

            BinaryTools.OverwriteBytesAtBase(binarybuffer, nvramstore.StoreBase, erasedBuffer);

            byte[] tempBuffer = BinaryTools.GetBytesBaseLength(binarybuffer, nvramstore.StoreBase, nvramstore.StoreLength);

            if (!BinaryTools.ByteArraysMatch(tempBuffer, erasedBuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.NVR_FAIL_WRITE_VERIFY} ({storename})");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }

        private byte[] EraseNvramStore(NvramStoreType storetype, NvramStore store)
        {
            try
            {
                byte[] storeBuffer = BinaryTools.CloneBuffer(store.StoreBuffer);
                int bodyStart = EFIROM.HDR_SIZE;
                int bodyEnd = store.StoreBuffer.Length - EFIROM.HDR_SIZE;

                // Initialize header.
                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR);
                for (int i = 0x4; i <= 0x7; i++)
                {
                    storeBuffer[i] = 0xFF;
                }

                if (storetype == NvramStoreType.Variable)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR_VSS);
                    for (int i = 0x9; i <= 0xA; i++)
                    {
                        storeBuffer[i] = 0xFF;
                    }
                }

                // Verify that the relevant header bytes have been set to 0xFF.
                if (!VerifyErasedHeader(storeBuffer, storetype))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.NVRAM_INIT_HDR_FAIL}");
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR_SUCCESS);

                // Pull the store body from the buffer.
                byte[] erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                Logger.WriteCallerLine(LOGSTRINGS.NVR_ERASE_BODY);

                // Erase the store body.
                BinaryTools.EraseByteArray(erasedStoreBodyBuffer);

                Logger.WriteCallerLine(LOGSTRINGS.NVR_WRITE_ERASED_BODY);

                // Write the erased store back to the nvram store buffer.
                BinaryTools.OverwriteBytesAtBase(storeBuffer, bodyStart, erasedStoreBodyBuffer);

                // Check the body was erased.
                erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                if (!BinaryTools.IsByteBlockEmpty(erasedStoreBodyBuffer))
                {
                    MessageBox.Show(LOGSTRINGS.NVR_BODY_WRITE_FAIL);
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.NVR_STORE_ERASE_SUCESS);

                return storeBuffer;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(EraseNvramStore), e.GetType(), e.Message);
                return null;
            }
        }

        private static bool VerifyErasedHeader(byte[] storebuffer, NvramStoreType storetype)
        {
            for (int i = 0x4; i <= 0x7; i++)
            {
                if (storebuffer[i] != 0xFF)
                    return false;
            }

            if (storetype == NvramStoreType.Variable)
            {
                for (int i = 0x9; i <= 0xA; i++)
                {
                    if (storebuffer[i] != 0xFF)
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
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateFsysOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_IMPORT_CANCELLED}");
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] fsysBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateFsysStore(fsysBuffer))
                {
                    return;
                }

                FsysStore fsysStore = _efirom.ParseFsysStoreData(fsysBuffer, true);

                if (!ValidateFsysCrc(fsysStore, ref fsysBuffer))
                {
                    return;
                }

                byte[] binaryBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);

                if (!WriteNewFsysStore(binaryBuffer, fsysBuffer))
                {
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareEfirom(binaryBuffer);
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
            }
        }

        private static OpenFileDialog CreateFsysOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.FsysDirectory,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateFsysStore(byte[] fsysBuffer)
        {
            int fsysBase = BinaryTools.GetBaseAddress(fsysBuffer, Signatures.FsysStore.FsysMarker);

            // Fsys store length should equal 800h, 2048 bytes.
            if (fsysBuffer.Length != _efirom.Fsys.Size)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.EXPECTED_STORE_SIZE_NOT} {_efirom.Fsys.Size:X}h ({fsysBuffer.Length:X}h)");
                NotifyPatchingFailure();
                return false;
            }

            // Expect Fsys signature at 0h.
            if (fsysBase != 0)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_SIG_MISALIGNED}");
                NotifyPatchingFailure();
                return false;
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool ValidateFsysCrc(FsysStore fsysstore, ref byte[] fsysbuffer)
        {
            if (!string.Equals(fsysstore.CrcString, fsysstore.CrcActualString))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.FSYS_SUM_INVALID} ({LOGSTRINGS.FOUND} {fsysstore.CrcString}, {LOGSTRINGS.CALCULATED} {fsysstore.CrcActualString})");

                Logger.WriteCallerLine(LOGSTRINGS.MASKING_SUM);

                fsysbuffer = _efirom.PatchFsysCrc(fsysstore.Buffer, fsysstore.CrcActual, fsysstore.Size);
                fsysstore = _efirom.ParseFsysStoreData(fsysbuffer, true);

                if (!string.Equals(fsysstore.CrcString, fsysstore.CrcActualString))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SUM_MASKING_FAIL}");
                    NotifyPatchingFailure();
                    return false;
                }

                Logger.WriteCallerLine(LOGSTRINGS.FSYS_SUM_MASK_SUCCESS);
            }

            return true;
        }

        private bool WriteNewFsysStore(byte[] binaryBuffer, byte[] newFsysBuffer)
        {
            Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, _efirom.Fsys.BaseAddress, newFsysBuffer);
            FsysStore fsysStore = _efirom.ParseFsysStoreData(binaryBuffer, false);

            if (!BinaryTools.ByteArraysMatch(fsysStore.Buffer, newFsysBuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }
        #endregion

        #region Mask Fsys Checksum
        private void MaskFsysChecksum()
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Make binary with patched Fsys crc.
            byte[] binaryBuffer =
                _efirom.MakeFsysCrcPatchedBinary(
                    BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer),
                    _efirom.Fsys.BaseAddress,
                    _efirom.Fsys.Buffer,
                    _efirom.Fsys.CrcActual,
                    _efirom.Fsys.Size);

            if (binaryBuffer == null)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.CRC_BUFFER_EMPTY}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Remove EFI Lock
        private void RemoveEfiLock()
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            // Initialize buffers.
            byte[] binaryBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);

            // Patch the primary store.
            byte[] primaryUnlockedBuffer = PatchPrimaryStore(binaryBuffer);

            // Patch the backup store, if necessary.
            byte[] backupUnlockedBuffer = PatchBackupStore(binaryBuffer);

            // Verify patched stores.
            if (!VerifyPatchedStores(binaryBuffer, primaryUnlockedBuffer, backupUnlockedBuffer))
            {
                NotifyPatchingFailure();
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            // Prompt for saving and export if confirmed.
            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareEfirom(binaryBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }

        private byte[] PatchPrimaryStore(byte[] binarybuffer)
        {
            Logger.WriteCallerLine(LOGSTRINGS.LOCK_PRIMARY_MAC);
            byte[] unlockedBuffer = _efirom.PatchSvsStoreMac(_efirom.SvsPrimary.StoreBuffer, _efirom.EfiPrimaryLockStatus.LockBase);

            Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);
            BinaryTools.OverwriteBytesAtBase(binarybuffer, _efirom.SvsPrimary.StoreBase, unlockedBuffer);

            return unlockedBuffer;
        }

        private byte[] PatchBackupStore(byte[] binarybuffer)
        {
            byte[] unlockedBuffer = null;

            if (_efirom.EfiBackupLockStatus.LockBase != -1)
            {
                Logger.WriteCallerLine(LOGSTRINGS.LOCK_BACKUP_MAC);
                unlockedBuffer = _efirom.PatchSvsStoreMac(_efirom.SvsSecondary.StoreBuffer, _efirom.EfiBackupLockStatus.LockBase);

                Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);
                BinaryTools.OverwriteBytesAtBase(binarybuffer, _efirom.SvsSecondary.StoreBase, unlockedBuffer);
            }

            return unlockedBuffer;
        }

        private bool VerifyPatchedStores(byte[] binarybuffer, byte[] primaryunlockedbuffer, byte[] backupunlockedbuffer)
        {
            Logger.WriteCallerLine(LOGSTRINGS.LOCK_LOAD_SVS);

            int primaryBase = BinaryTools.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, _efirom.NvramBase, _efirom.NvramLimit);
            NvramStore svsPrimary = _efirom.ParseSingleNvramStore(binarybuffer, primaryBase, NvramStoreType.Secure);

            if (!BinaryTools.ByteArraysMatch(svsPrimary.StoreBuffer, primaryunlockedbuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_PRIM_VERIF_FAIL}");
                return false;
            }

            if (backupunlockedbuffer != null)
            {
                int backupBase = BinaryTools.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, primaryBase + EFIROM.HDR_SIZE, _efirom.NvramLimit);
                NvramStore svsBackup = _efirom.ParseSingleNvramStore(binarybuffer, backupBase, NvramStoreType.Secure);

                if (!BinaryTools.ByteArraysMatch(svsBackup.StoreBuffer, backupunlockedbuffer))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_BACK_VERIF_FAIL}");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Write Intel ME
        private void WriteIntelMeRegion()
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateImeOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_IMPORT_CANCELLED}");
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] meBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateMeRegion(meBuffer))
                {
                    return;
                }

                string meVersion = IntelME.GetVersionData(meBuffer, ImeVersionType.ME, _efirom.Descriptor);

                Logger.WriteCallerLine($"{LOGSTRINGS.IME_VERSION} {meVersion ?? APPSTRINGS.NOT_FOUND}");

                byte[] binaryBuffer = BinaryTools.CloneBuffer(_efirom.LoadedBinaryBuffer);

                if (!WriteMeRegion(meBuffer, binaryBuffer))
                {
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareEfirom(binaryBuffer);
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
            }
        }

        private static OpenFileDialog CreateImeOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.IntelMeDirectory,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateMeRegion(byte[] mebuffer)
        {
            int fptBase = BinaryTools.GetBaseAddress(mebuffer, IntelME.FPTMarker);

            if (fptBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_FPT_NOT_FOUND}");
                NotifyPatchingFailure();
                return false;
            }

            if (mebuffer.Length > _efirom.Descriptor.MeSize)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_TOO_LARGE} {mebuffer.Length:X}h > {_efirom.Descriptor.MeSize:X}h");
                NotifyPatchingFailure();
                return false;
            }

            if (mebuffer.Length < _efirom.Descriptor.MeSize)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.IME_TOO_SMALL} {mebuffer.Length:X}h > {_efirom.Descriptor.MeSize:X}h");
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool WriteMeRegion(byte[] mebuffer, byte[] binarybuffer)
        {
            byte[] emptyBuffer = new byte[_efirom.Descriptor.MeSize];
            BinaryTools.EraseByteArray(emptyBuffer);

            Array.Copy(mebuffer, 0, emptyBuffer, 0, mebuffer.Length);
            Array.Copy(emptyBuffer, 0, binarybuffer, _efirom.Descriptor.MeBase, emptyBuffer.Length);

            byte[] patchedMeBuffer = BinaryTools.GetBytesBaseLimit(binarybuffer, (int)_efirom.Descriptor.MeBase, (int)_efirom.Descriptor.MeLimit);

            if (!BinaryTools.ByteArraysMatch(patchedMeBuffer, emptyBuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_BUFFER_MISMATCH}");
                NotifyPatchingFailure();
                return false;
            }

            return true;
        }
        #endregion

        #region Patching IO
        private SaveFileDialog CreateFirmwareSaveFileDialog()
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = _efirom.FirmwareInfo.FileName,
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.BuildsDirectory
            };
        }

        private void SaveOutputFirmwareEfirom(byte[] binarybuffer)
        {
            using (SaveFileDialog dialog = CreateFirmwareSaveFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return;
                }

                if (FileTools.WriteAllBytesEx(dialog.FileName, binarybuffer) && File.Exists(dialog.FileName))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.FILE_SAVE_SUCCESS} {dialog.FileName}");

                    DialogResult result =
                        METPrompt.Show(
                            this,
                            DIALOGSTRINGS.FW_SAVED_SUCCESS_LOAD,
                            METPrompt.PType.Question,
                            METPrompt.PButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        OpenBinary(dialog.FileName);
                    }
                }
            }
        }
        #endregion
    }
}