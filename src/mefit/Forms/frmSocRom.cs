// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSocRom.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.SOCROM;
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
    public partial class frmSocRom : FormEx
    {
        #region Private Members
        private SOCROM _socrom = new SOCROM();

        private string _strInitialDirectory = ApplicationPaths.WorkingDirectory;
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        private Button[] _menuButtons;
        private ContextMenuStrip[] _contextMenus;
        #endregion

        #region Constructor
        public frmSocRom()
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

            // Get and disable menu items.
            GetAndDisableMenuItems();
        }

        private void WireEventHandlers()
        {
            Load += frmSocRom_Load;
            FormClosing += frmSocRom_FormClosing;
            FormClosed += frmSocRom_FormClosed;
            KeyDown += frmSocRom_KeyDown;
            DragEnter += frmSocRom_DragEnter;
            DragDrop += frmSocRom_DragDrop;
            Deactivate += frmSocRom_Deactivate;
            Activated += frmSocRom_Activated;
        }

        private void GetAndDisableMenuItems()
        {
            _menuButtons = new Button[]
            {
                cmdMenuCopy,
                cmdMenuExport,
                cmdMenuPatch,
                cmdMenuTools,
                cmdOpenInExplorer
            };

            _contextMenus = new ContextMenuStrip[]
            {
                cmsCopy, cmsExport, cmsPatch, cmsTools,
            };

            EnableButtons(false, _menuButtons);
            EnableMenus(false, _contextMenus);
        }
        #endregion

        #region Window Events
        private void frmSocRom_Load(object sender, EventArgs e)
        {
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

        private void frmSocRom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.Cancel();
            }

            MemoryTracker.Instance.OnMemoryUsageUpdated -= MemoryTracker_OnMemoryUsageUpdated;

            _socrom = null;
        }

        private void frmSocRom_FormClosed(object sender, FormClosedEventArgs e) => _cancellationToken?.Dispose();

        private void frmSocRom_DragEnter(object sender, DragEventArgs e) => Program.HandleDragEnter(sender, e, null);

        private void frmSocRom_DragDrop(object sender, DragEventArgs e)
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

        private void frmSocRom_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, ApplicationColours.InactiveFormText);

        private void frmSocRom_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, ApplicationColours.ActiveFormText);
        #endregion

        #region KeyDown Events
        private void frmSocRom_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.R:
                        resetWindowToolStripMenuItem.PerformClick();
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

        private void cmdMenuOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_SOCROM_SUPPORTED_FIRMWARE
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdMenuHelp_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsHelp,
                MenuPosition.BottomLeft);

        private void cmdMenuCopy_Click(object sender, EventArgs e) =>
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
                    DialogResult result = form.ShowDialog();
                    openEditor = (result != DialogResult.No);
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

        private void cmdOpenInExplorer_Click(object sender, EventArgs e) => UITools.HighlightPathInExplorer(_socrom.LoadedBinaryPath, this);
        #endregion

        #region Switch Events
        private void cbxCensor_CheckedChanged(object sender, EventArgs e) => UpdateSerialControls();
        #endregion

        #region Copy Toolstrip Events
        private void filenameToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFilename(true);

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileSize();

        private void cRC32ToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileCrc32();

        private void creationDateToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileCreationTime();

        private void modifiedDateToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetFileModifiedTime();

        private void iBootVersionToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetIbootVersion();

        private void scfgBaseAddressToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgBaseAddress();

        private void scfgSizeDecimalToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgSizeDecimal();

        private void scfgSizeHexToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgSizeHex();

        private void scfgCRC32ToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgCrc32();

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string serial = _socrom.SCfgStoreData.Serial;

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

        private void configToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgConfig();

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgOrderNo();
        #endregion

        #region Folders Toolstrip Events
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.BackupsDirectory, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.BuildsDirectory, this);

        private void openSCFGFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.ScfgDirectory, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.WorkingDirectory, this);
        #endregion

        #region Export Toolstrip Events
        private void exportScfgStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{_socrom.FirmwareInfo.FileName}_{SOCSTRINGS.SCFG_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.ScfgDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Save the Scfg stores bytes to disk.
                if (FileTools.WriteAllBytesEx(dialog.FileName, _socrom.SCfgStoreData.StoreBuffer))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.SCFG_EXPORT_FAIL,
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
                FileName = $"{_socrom.FirmwareInfo.FileName}_{APPSTRINGS.SOCROM}_{APPSTRINGS.BACKUP}",
                OverwritePrompt = true
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileTools.BackupFileToZip(_socrom.LoadedBinaryBuffer, _socrom.FirmwareInfo.FileNameExt, dialog.FileName);

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
                FileName = $"{_socrom.FirmwareInfo.FileName}_{APPSTRINGS.FIRMWARE_INFO}",
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
                builder.AppendLine($"Filename:        {_socrom.FirmwareInfo.FileNameExt}");
                builder.AppendLine($"Size (Bytes):    {FileTools.FormatBytesWithCommas(_socrom.FirmwareInfo.Length)} bytes");
                builder.AppendLine($"Size (MB):       {FileTools.FormatBytesToReadableUnit((ulong)_socrom.FirmwareInfo.Length)}");
                builder.AppendLine($"Size (Hex):      {_socrom.FirmwareInfo.Length:X}h");
                builder.AppendLine($"Entropy:         {_socrom.FirmwareInfo.Entropy}");
                builder.AppendLine($"SHA256:          {_socrom.FirmwareInfo.SHA256}");
                builder.AppendLine($"CRC32:           {_socrom.FirmwareInfo.CRC32:X8}"); ;
                builder.AppendLine($"Created:         {_socrom.FirmwareInfo.CreationTime}");
                builder.AppendLine($"Modified:        {_socrom.FirmwareInfo.LastWriteTime}\r\n");

                builder.AppendLine("Controller");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"Type:            {_socrom.Controller}\r\n");

                if (_socrom.SCfgStoreData.StoreBase != -1)
                {
                    builder.AppendLine("SCfg");
                    builder.AppendLine("----------------------------------");
                    builder.AppendLine($"Base:            {_socrom.SCfgStoreData.StoreBase:X}h");
                    builder.AppendLine($"Size (Bytes):    {_socrom.SCfgStoreData.StoreLength} bytes");
                    builder.AppendLine($"Size (Hex):      {_socrom.SCfgStoreData.StoreLength:X}h");
                    builder.AppendLine($"CRC32:           {_socrom.SCfgStoreData.StoreCRC ?? APPSTRINGS.NA}");
                    builder.AppendLine($"Serial:          {_socrom.SCfgStoreData.Serial ?? APPSTRINGS.NA}\r\n");

                    builder.AppendLine("Model");
                    builder.AppendLine("----------------------------------");
                    builder.AppendLine($"Config:          {_socrom.ConfigCode ?? APPSTRINGS.NA}");
                    builder.AppendLine($"Order No:        {_socrom.SCfgStoreData.SON ?? APPSTRINGS.NA}");
                    builder.AppendLine($"Reg No:          {_socrom.SCfgStoreData.RegNum ?? APPSTRINGS.NA}\r\n");
                }
                else
                {
                    builder.AppendLine("SCfg");
                    builder.AppendLine("----------------------------------");
                    builder.AppendLine($"Not found\r\n");

                    builder.AppendLine("Model");
                    builder.AppendLine("----------------------------------");
                    builder.AppendLine($"Not found\r\n");
                }

                builder.AppendLine("Firmware");
                builder.AppendLine("----------------------------------");
                builder.AppendLine($"iBoot Version:   {_socrom.iBootVersion ?? APPSTRINGS.NA}");

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

            using (frmSerialSelect form = new frmSerialSelect(_socrom))
            {
                form.Tag = SerialSenderTag.SOCROMWindow;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    WriteSocromSerialNumber(_socrom.NewSerial);
                }
            }
        }

        private void replaceScfgStoreToolStripMenuItem_Click(object sender, EventArgs e) => WriteScfgStore();
        #endregion

        #region Tools Toolstrip Events
        private void lookupSerialNumberToolStripMenuItem_Click(object sender, EventArgs e) =>
            MacTools.LookupSerialOnEveryMac(_socrom.SCfgStoreData.Serial);

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
            if (!File.Exists(_socrom.LoadedBinaryPath))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.COULD_NOT_RELOAD,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file.
            byte[] binaryBuffer = File.ReadAllBytes(_socrom.LoadedBinaryPath);

            // Check if the binaries match in size and data.
            if (BinaryTools.ByteArraysMatch(binaryBuffer, _socrom.LoadedBinaryBuffer))
            {
                // Loaded binaries match.
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.WARN_DATA_MATCHES_BUFF,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            OpenBinary(_socrom.LoadedBinaryPath);
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

        #region Open Binary
        private void OpenBinary(string filepath)
        {
            // Check filesize.
            if (!FirmwareFile.IsValidMinMaxSize(filepath, this, FirmwareFile.MIN_IMAGE_SIZE, FirmwareFile.MAX_IMAGE_SIZE))
            {
                return;
            }

            // Check if the image is what we're looking for.
            if (!_socrom.IsValidImage(File.ReadAllBytes(filepath)))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.NOT_VALID_SOCROM,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            // If a firmware is loaded, reset all data.
            if (_socrom.FirmwareLoaded)
            {
                ResetWindow();
            }

            ToggleControlEnable(false);

            // Set the binary path and load the bytes.
            _socrom.LoadedBinaryPath = filepath;
            _socrom.LoadedBinaryBuffer = File.ReadAllBytes(filepath);

            // Set the current directory.
            _strInitialDirectory = Path.GetDirectoryName(filepath);

            // Show loading bar.
            pbxLoad.Image = Properties.Resources.loading;

            _tLoadFirmware = new Thread(() => LoadFirmwareBase(filepath, _cancellationToken.Token)) { IsBackground = true };
            _tLoadFirmware.Start();
        }

        private void LoadFirmwareBase(string filePath, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            _socrom.LoadFirmwareBaseData(_socrom.LoadedBinaryBuffer, filePath);

            if (token.IsCancellationRequested)
            {
                return;
            }

            if (IsHandleCreated && !token.IsCancellationRequested)
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
                _socrom.FirmwareLoaded = true;
            }
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e) => BlurHelper.RemoveBlur(this);

        private void UpdateWindowTitle()
        {
            this.Text = _socrom.FirmwareInfo.FileNameExt;
            lblTitle.Text = $"{APPSTRINGS.SOCROM} {ApplicationChars.SEGUI_RIGHTWARDSARROW} {_socrom.FirmwareInfo.FileNameExt}";
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdMenuOpen,
                cmdMenuFolders,
                cmdMenuCopy,
                cmdMenuExport,
                cmdMenuTools,
                cmdMenuPatch,
                cmdMenuHelp,
                cmdOpenInExplorer
            };

            Label[] labels = { lblParseTime };

            CheckBox[] checkboxes = { cbxCensor };

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

            foreach (CheckBox checkBox in checkboxes)
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
                    { cmdMenuOpen, $"{SOCSTRINGS.MENU_TIP_OPEN} (CTRL + O)" },
                    { cmdMenuCopy, $"{SOCSTRINGS.MENU_TIP_COPY} (CTRL + C)" },
                    { cmdMenuFolders, $"{SOCSTRINGS.MENU_TIP_FOLDERS} (CTRL + L)" },
                    { cmdMenuExport, $"{SOCSTRINGS.MENU_TIP_EXPORT} (CTRL + E)"},
                    { cmdMenuPatch, $"{SOCSTRINGS.MENU_TIP_PATCH} (CTRL + P)"},
                    { cmdMenuTools, $"{SOCSTRINGS.MENU_TIP_TOOLS} (CTRL + T)"},
                    { cmdMenuHelp, $"{SOCSTRINGS.MENU_TIP_HELP} (CTRL + H)"},
                    { cmdOpenInExplorer, $"{SOCSTRINGS.MENU_TIP_OPENFILELOCATION} (CTRL + SHIFT + L)"},
                    { lblParseTime, APPSTRINGS.FW_PARSE_TIME},
                    { cbxCensor, cbxCensorTipString() }
                };

                if (tooltips.TryGetValue(sender, out string value))
                {
                    lblStatusBarTip.Text = value;
                }
            }
        }

        private string cbxCensorTipString() =>
            $"{(cbxCensor.Checked ? APPSTRINGS.HIDE : APPSTRINGS.SHOW)} {APPSTRINGS.SERIAL_NUMBER} (CTRL + SHIFT + N)";

        private void HandleCheckBoxChanged(object sender, EventArgs e)
        {
            if (sender == cbxCensor && cbxCensor.ClientRectangle.Contains(cbxCensor.PointToClient(Cursor.Position)))
            {
                if (!Settings.ReadBoolean(Settings.BooleanKey.DisableTips))
                {
                    lblStatusBarTip.Text = cbxCensorTipString();
                }
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e) => lblStatusBarTip.Text = string.Empty;

        private void SetButtonFontAndGlyph()
        {
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.SegoeFluentRegular12, Text = ApplicationChars.FLUENT_MULTIPLY },
                new { Button = cmdOpenInExplorer, Font = Program.SegoeFluentRegular12, Text = ApplicationChars.FLUENT_OPENFOLDERHORIZ },
            };

            foreach (var property in buttons)
            {
                property.Button.Font = property.Font;
                property.Button.Text = property.Text;
            }
        }

        private static void SetControlForeColor(Control parentcontrol, Color forecolor)
        {
            foreach (Control control in parentcontrol.Controls)
            {
                control.ForeColor = forecolor;
            }
        }

        private void NotifyPatchingFailure()
        {
            if (Prompts.ShowPatchFailedPrompt(this) == DialogResult.Yes)
            {
                Logger.OpenLogFile(this);
            }
        }
        #endregion

        #region Misc Events
        internal void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(Settings.StringKey.SocInitialDirectory);

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

            // Reset labels.
            Label[] labels =
            {
                lblFilename,
                lblFilesize,
                lblCrc,
                lblCreated,
                lblModified,
                lbliBoot,
                lblScfg,
                lblSerial,
                lblConfigCode,
                lblSon
            };

            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = ApplicationColours.NormalText;
            }

            // Reset parse time.
            lblParseTime.Text = "0.00s";

            // Reset initial directory.
            SetInitialDirectory();

            // Reset window text.
            Text = APPSTRINGS.SOCROM;
            lblTitle.Text = APPSTRINGS.SOCROM;

            _socrom.ResetFirmwareBaseData();
        }

        private void EnableButtons(bool enable, params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = enable;
            }
        }

        private void EnableMenus(bool enable, params ContextMenuStrip[] contextMenus)
        {
            foreach (ContextMenuStrip contextMenuStrip in contextMenus)
            {
                contextMenuStrip.Enabled = enable;
            }
        }

        private void ToggleControlEnable(bool enable)
        {
            EnableButtons(enable, _menuButtons);
            EnableMenus(enable, _contextMenus);

            if (enable)
            {
                exportScfgStoreToolStripMenuItem.Enabled = _socrom.SCfgStoreData.StoreBase != -1;
                lookupSerialNumberToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_socrom.SCfgStoreData.Serial);

                cmdMenuPatch.Enabled = _socrom.Controller == ControllerType.AppleT2; // Apple Silicon ROM patching is not supported.
                changeSerialNumberToolStripMenuItem.Enabled = _socrom.SCfgStoreData.StoreBase != -1;
            }

            tlpFirmware.Enabled = enable;
        }
        #endregion

        #region Update Window
        internal void UpdateUI()
        {
            // Parse time.
            UpdateParseTimeControls();

            // File information
            UpdateFilenameControls();
            UpdateFileSizeControls();
            UpdateFileCrc32Controls();
            UpdateFileCreationDateControls();
            UpdateFileModifiedDateControls();

            // Firmware data
            UpdateIbootControls();
            UpdateScfgControls();
            UpdateSerialControls();
            UpdateConfigCodeControls();
            UpdateModelControls();

            // Apply DISABLED_TEXT to N/A labels.
            UITools.ApplyNestedPanelLabelForeColor(tlpFirmware, ApplicationColours.DisabledText);

            // Update window title.
            UpdateWindowTitle();

            // Unload image.
            pbxLoad.Image = null;

            // Check and set control enable
            ToggleControlEnable(true);
        }

        private void UpdateParseTimeControls() => lblParseTime.Text = $"{_socrom.ParseTime.TotalSeconds:F2}s";

        private void UpdateFilenameControls() => lblFilename.Text = $"{APPSTRINGS.FILE}: '{_socrom.FirmwareInfo.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            long length = _socrom.FirmwareInfo.Length;
            bool validSize = FirmwareFile.IsValidBinSize(length);

            lblFilesize.Text = $"{FileTools.FormatBytesWithCommas(length)} {APPSTRINGS.BYTES} ({length:X}h)";

            if (!validSize)
            {
                lblFilesize.ForeColor = ApplicationColours.Error;
                lblFilesize.Text += $" ({FirmwareFile.CalculateInvalidSize(length)})";
            }
        }

        private void UpdateFileCrc32Controls() => lblCrc.Text = $"{_socrom.FirmwareInfo.CRC32:X8}";

        private void UpdateFileCreationDateControls() => lblCreated.Text = _socrom.FirmwareInfo.CreationTime;

        private void UpdateFileModifiedDateControls() => lblModified.Text = _socrom.FirmwareInfo.LastWriteTime;

        private void UpdateIbootControls()
        {
            if (!string.IsNullOrEmpty(_socrom.iBootVersion))
            {
                lbliBoot.Text = $"{_socrom.iBootVersion} {SOCSTRINGS.ON} {(_socrom.Controller == 0 ? SOCSTRINGS.T2 : SOCSTRINGS.SILICON)}";
                iBootVersionToolStripMenuItem.Enabled = true;
                return;
            }

            iBootVersionToolStripMenuItem.Enabled = false;
            lbliBoot.Text = APPSTRINGS.NA;
        }

        private void UpdateScfgControls()
        {
            if (_socrom.SCfgStoreData.StoreBase == -1)
            {
                DisableScfgMenuItems();
                lblScfg.Text = APPSTRINGS.NA;
                return;
            }

            string scfgBase = $"{_socrom.SCfgStoreData.StoreBase:X}h";
            string crc = _socrom.SCfgStoreData.StoreCRC;
            int scfgSize = _socrom.SCfgStoreData.StoreLength;

            lblScfg.Text = $"{scfgBase}, {scfgSize:X}h ({scfgSize} bytes), {crc}";

            EnableScfgMenuItems();
        }

        private void DisableScfgMenuItems()
        {
            scfgBaseAddressToolStripMenuItem.Enabled = false;
            scfgSizeDecimalToolStripMenuItem.Enabled = false;
            scfgSizeHexToolStripMenuItem.Enabled = false;
            scfgCRC32ToolStripMenuItem.Enabled = false;
        }

        private void EnableScfgMenuItems()
        {
            scfgBaseAddressToolStripMenuItem.Enabled = true;
            scfgSizeDecimalToolStripMenuItem.Enabled = true;
            scfgSizeHexToolStripMenuItem.Enabled = true;
            scfgCRC32ToolStripMenuItem.Enabled = true;
        }

        private void UpdateSerialControls()
        {
            string serial = _socrom.SCfgStoreData.Serial;

            if (!string.IsNullOrEmpty(serial))
            {
                if (cbxCensor.Checked)
                {
                    lblSerial.Text = serial;
                }
                else
                {
                    lblSerial.Text = $"{serial.Substring(0, 2)}******{serial.Substring(8, 4)}";
                }

                if (!Serial.IsValid(serial))
                {
                    lblSerial.ForeColor = ApplicationColours.Warning;
                }

                cbxCensor.Enabled = true;
                serialToolStripMenuItem.Enabled = true;
            }
            else
            {
                lblSerial.Text = APPSTRINGS.NA;
                cbxCensor.Enabled = false;
                serialToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateConfigCodeControls()
        {
            if (!string.IsNullOrEmpty(_socrom.ConfigCode))
            {
                lblConfigCode.Text = _socrom.ConfigCode;
                configToolStripMenuItem.Enabled = true;
                return;
            }

            lblConfigCode.Text = APPSTRINGS.CONTACT_SERVER;
            lblConfigCode.ForeColor = ApplicationColours.Information;

            GetConfigCodeAsync(_socrom.SCfgStoreData.HWC);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configCode = await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configCode))
            {
                _socrom.ConfigCode = configCode;
                lblConfigCode.Text = configCode;
                lblConfigCode.ForeColor = ApplicationColours.NormalText;
                configToolStripMenuItem.Enabled = true;
                return;
            }

            configToolStripMenuItem.Enabled = false;
            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = ApplicationColours.DisabledText;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(_socrom.SCfgStoreData.SON))
            {
                lblSon.Text = APPSTRINGS.NA;
                orderNoToolStripMenuItem.Enabled = false;
                return;
            }

            orderNoToolStripMenuItem.Enabled = true;

            lblSon.Text = _socrom.SCfgStoreData.SON;

            if (!string.IsNullOrEmpty(_socrom.SCfgStoreData.RegNum))
            {
                lblSon.Text += $" ({_socrom.SCfgStoreData.RegNum})";
            }
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

        private void ClipboardSetFilename(bool showExtention) =>
            SetClipboardText(showExtention ? _socrom.FirmwareInfo.FileNameExt : _socrom.FirmwareInfo.FileName);

        private void ClipboardSetFileSize() =>
            SetClipboardText($"{FileTools.FormatBytesWithCommas(_socrom.FirmwareInfo.Length)} {APPSTRINGS.BYTES} ({_socrom.FirmwareInfo.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText($"{_socrom.FirmwareInfo.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(_socrom.FirmwareInfo.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(_socrom.FirmwareInfo.LastWriteTime);

        private void ClipboardSetIbootVersion() => SetClipboardText(_socrom.iBootVersion);

        private void ClipboardSetScfgBaseAddress() => SetClipboardText($"{_socrom.SCfgStoreData.StoreBase:X}");

        private void ClipboardSetScfgSizeDecimal() => SetClipboardText($"{_socrom.SCfgStoreData.StoreLength} {APPSTRINGS.BYTES}");

        private void ClipboardSetScfgSizeHex() => SetClipboardText($"{_socrom.SCfgStoreData.StoreLength:X}h");

        private void ClipboardSetScfgCrc32() => SetClipboardText(_socrom.SCfgStoreData.StoreCRC);

        private void ClipboardSetScfgConfig() => SetClipboardText(_socrom.ConfigCode);

        private void ClipboardSetScfgOrderNo() => SetClipboardText($"{_socrom.SCfgStoreData.SON}{_socrom.SCfgStoreData.RegNum ?? string.Empty}");
        #endregion

        #region Write Serial
        private void WriteSocromSerialNumber(string serial)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Check serial length.
            if (serial.Length != SOCROM.SERIAL_LENGTH)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SERIAL_LEN_INVALID} ({serial.Length})");
                NotifyPatchingFailure();
                return;
            }

            // Check if the SerialBase exists.
            if (_socrom.SCfgStoreData.SerialBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                NotifyPatchingFailure();
                return;
            }

            // Create buffers.
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryTools.CloneBuffer(_socrom.LoadedBinaryBuffer);
            byte[] serialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WriteCallerLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, _socrom.SCfgStoreData.SerialBase, serialBuffer);

            Logger.WriteCallerLine(LOGSTRINGS.SCFG_LFB);

            // Load patched scfg from the binary buffer.
            SCfgStore scfgStore = _socrom.ParseSCfgStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, scfgStore.Serial))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_NOT_WRITTEN}");
                NotifyPatchingFailure();
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.SSN_WRITE_SUCCESS);

            // Log success and prompt for saving the patched firmware.
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
            {
                SaveOutputFirmwareSocrom(binaryBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Write Scfg Store
        private void WriteScfgStore()
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateScfgOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_IMPORT_CANCELLED}");
                    return;
                }

                // Check the SOCROM contains a store, otherwise set the base address.
                int scfgBase = _socrom.SCfgStoreData.StoreBase;
                bool scfgExists = true;

                // Set the Scfg base manually.
                if (scfgBase == -1)
                {
                    scfgExists = false;
                    Logger.WriteCallerLine($"{LOGSTRINGS.SCFG_BASE_ADJUST} {SOCROM.SCFG_EXPECTED_BASE:X}h");
                    scfgBase = SOCROM.SCFG_EXPECTED_BASE;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] binaryBuffer = BinaryTools.CloneBuffer(_socrom.LoadedBinaryBuffer);
                byte[] scfgBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateScfgStore(scfgBuffer))
                {
                    return;
                }

                // Check were not writing over data we shouldn't be.
                if (!scfgExists)
                {
                    byte[] emptyBuffer = BinaryTools.GetBytesBaseLength(binaryBuffer, SOCROM.SCFG_EXPECTED_BASE, scfgBuffer.Length);

                    for (int i = 0; i < emptyBuffer.Length; i++)
                    {
                        if (emptyBuffer[i] != 0xFF)
                        {
                            Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_POS_INITIALIZED}");
                            NotifyPatchingFailure();
                            return;
                        }
                    }
                }

                Logger.WriteLine(LOGSTRINGS.WRITE_NEW_DATA, Logger.LogType.Application);

                // 0xFF the original store from base + store length, so we don't leave behind parts of an old store.
                if (scfgExists)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.ERASE_OLD_STORE);
                    byte[] tempBuffer = new byte[_socrom.SCfgStoreData.StoreLength];
                    BinaryTools.EraseByteArray(tempBuffer);
                    BinaryTools.OverwriteBytesAtBase(binaryBuffer, scfgBase, tempBuffer);
                }

                // Overwrite Scfg store in the binary buffer.
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, scfgBase, scfgBuffer);

                // Load Scfg store from the binary buffer.
                SCfgStore scfgStore = _socrom.ParseSCfgStoreData(binaryBuffer, false);

                // Check store was written successfully.
                if (!BinaryTools.ByteArraysMatch(scfgStore.StoreBuffer, scfgBuffer))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                    NotifyPatchingFailure();
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareSocrom(binaryBuffer);
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
            }
        }

        private static OpenFileDialog CreateScfgOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.ScfgDirectory,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private bool ValidateScfgStore(byte[] scfgbuffer)
        {
            int scfgBase = BinaryTools.GetBaseAddress(scfgbuffer, Signatures.Scfg.HeaderMarker);

            // Expect scfg signature at address 0h.
            if (scfgBase != 0)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_SIG_MISALIGNED}");
                NotifyPatchingFailure();
                return false;
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

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
                FileName = _socrom.FirmwareInfo.FileName,
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.BuildsDirectory
            };
        }

        private void SaveOutputFirmwareSocrom(byte[] binaryBuffer)
        {
            using (SaveFileDialog dialog = CreateFirmwareSaveFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return;
                }

                if (FileTools.WriteAllBytesEx(dialog.FileName, binaryBuffer) && File.Exists(dialog.FileName))
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