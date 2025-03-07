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

            SOCROM.ResetFirmwareBaseData();
        }

        private void frmSocRom_FormClosed(object sender, FormClosedEventArgs e) => _cancellationToken?.Dispose();

        private void frmSocRom_DragEnter(object sender, DragEventArgs e) => Program.HandleDragEnter(sender, e);

        private void frmSocRom_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] arrDraggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string strFileName = arrDraggedFiles[0];

            // Open the binary file.
            OpenBinary(strFileName);
        }

        private void frmSocRom_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.ClrInactiveFormText);

        private void frmSocRom_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.ClrActiveFormText);
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_SOCROM_SUPPORTED_FIRMWARE
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(openFileDialog.FileName);
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
            bool bOpenEditor = Settings.ReadBool(SettingsBoolType.AcceptedEditingTerms);

            if (!bOpenEditor)
            {
                BlurHelper.ApplyBlur(this);

                using (Form form = new frmTerms())
                {
                    form.FormClosed += ChildWindowClosed;
                    DialogResult result = form.ShowDialog();
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

        private void cmdMenuTools_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsTools,
                MenuPosition.BottomLeft);

        private void cmdOpenInExplorer_Click(object sender, EventArgs e) => UITools.HighlightPathInExplorer(SOCROM.LoadedBinaryPath, this);
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
            string strSerial = SOCROM.SCfgSectionData.Serial;

            if (string.IsNullOrEmpty(strSerial))
            {
                return;
            }

            Clipboard.SetText(strSerial);

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

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = $"{SOCROM.FileInfoData.FileName}_{SOCSTRINGS.SCFG_REGION}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.ScfgDirectory
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Save the Scfg stores bytes to disk.
                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, SOCROM.SCfgSectionData.StoreBuffer))
                {
                    UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.SCFG_EXPORT_FAIL,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }

        private void backupFirmwareZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = ApplicationPaths.BackupsDirectory,
                Filter = APPSTRINGS.FILTER_ZIP,
                FileName = $"{SOCROM.FileInfoData.FileName}_{APPSTRINGS.SOCROM}_{APPSTRINGS.BACKUP}",
                OverwritePrompt = true
            })
            {
                // Action was cancelled
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileTools.BackupFileToZip(SOCROM.LoadedBinaryBuffer, SOCROM.FileInfoData.FileNameExt, saveFileDialog.FileName);

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
                FileName = $"{SOCROM.FileInfoData.FileName}_{APPSTRINGS.FIRMWARE_INFO}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder sbFirmwareInfo = new StringBuilder();

                sbFirmwareInfo.AppendLine("File");
                sbFirmwareInfo.AppendLine("----------------------------------");
                sbFirmwareInfo.AppendLine($"Filename:        {SOCROM.FileInfoData.FileNameExt}");
                sbFirmwareInfo.AppendLine($"Size (Bytes):    {FileTools.FormatBytesWithCommas(SOCROM.FileInfoData.Length)} bytes");
                sbFirmwareInfo.AppendLine($"Size (MB):       {FileTools.FormatBytesToReadableUnit((ulong)SOCROM.FileInfoData.Length)}");
                sbFirmwareInfo.AppendLine($"Size (Hex):      {SOCROM.FileInfoData.Length:X}h");
                sbFirmwareInfo.AppendLine($"CRC32:           {SOCROM.FileInfoData.CRC32:X}");
                sbFirmwareInfo.AppendLine($"Created:         {SOCROM.FileInfoData.CreationTime}");
                sbFirmwareInfo.AppendLine($"Modified:        {SOCROM.FileInfoData.LastWriteTime}\r\n");

                sbFirmwareInfo.AppendLine("SCfg");
                sbFirmwareInfo.AppendLine("----------------------------------");
                sbFirmwareInfo.AppendLine($"Base:            {SOCROM.SCfgSectionData.StoreBase:X}h");
                sbFirmwareInfo.AppendLine($"Size (Bytes):    {SOCROM.SCfgSectionData.StoreLength} bytes");
                sbFirmwareInfo.AppendLine($"Size (Hex):      {SOCROM.SCfgSectionData.StoreLength:X}h");
                sbFirmwareInfo.AppendLine($"CRC32:           {SOCROM.SCfgSectionData.StoreCRC ?? APPSTRINGS.NA}");
                sbFirmwareInfo.AppendLine($"Serial:          {SOCROM.SCfgSectionData.Serial ?? APPSTRINGS.NA}\r\n");

                sbFirmwareInfo.AppendLine("Model");
                sbFirmwareInfo.AppendLine("----------------------------------");
                sbFirmwareInfo.AppendLine($"Config:          {SOCROM.ConfigCode ?? APPSTRINGS.NA}");
                sbFirmwareInfo.AppendLine($"Order No:        {SOCROM.SCfgSectionData.SON ?? APPSTRINGS.NA}");
                sbFirmwareInfo.AppendLine($"Reg No:          {SOCROM.SCfgSectionData.RegNumText ?? APPSTRINGS.NA}\r\n");

                sbFirmwareInfo.AppendLine("Firmware");
                sbFirmwareInfo.AppendLine("----------------------------------");
                sbFirmwareInfo.AppendLine($"iBoot Version:   {SOCROM.iBootVersion ?? APPSTRINGS.NA}");

                File.WriteAllText(saveFileDialog.FileName, sbFirmwareInfo.ToString());

                sbFirmwareInfo.Clear();

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

            using (frmSerialSelect form = new frmSerialSelect())
            {
                form.Tag = SerialSenderTag.SOCROMWindow;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    WriteSocromSerialNumber(SOCROM.NewSerial);
                }
            }
        }

        private void replaceScfgStoreToolStripMenuItem_Click(object sender, EventArgs e) => WriteScfgStore();
        #endregion

        #region Tools Toolstrip Events
        private void lookupSerialNumberToolStripMenuItem_Click(object sender, EventArgs e) =>
            MacTools.LookupSerialOnEveryMac(SOCROM.SCfgSectionData.Serial);

        private void resetWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                ToggleControlEnable(false);
                ResetWindow();
                return;
            }

            DialogResult dlgResult =
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.UNLOAD_FIRMWARE_RESET,
                    METPromptType.Warning,
                    METPromptButtons.YesNo);

            if (dlgResult == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetWindow();
            }
        }

        private void reloadFileFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SOCROM.LoadedBinaryPath))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.COULD_NOT_RELOAD,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return;
            }

            // Load bytes from loaded binary file.
            byte[] bFirmwareBuffer = File.ReadAllBytes(SOCROM.LoadedBinaryPath);

            // Check if the binaries match in size and data.
            if (BinaryTools.ByteArraysMatch(bFirmwareBuffer, SOCROM.LoadedBinaryBuffer))
            {
                // Loaded binaries match.
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.WARN_DATA_MATCHES_BUFF,
                    METPromptType.Warning,
                    METPromptButtons.Okay);

                return;
            }

            OpenBinary(SOCROM.LoadedBinaryPath);
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
            if (!FileTools.IsValidMinMaxSize(filepath, this, FirmwareVars.MIN_IMAGE_SIZE, FirmwareVars.MAX_IMAGE_SIZE))
            {
                return;
            }

            // Check if the image is what we're looking for.
            if (!SOCROM.IsValidImage(File.ReadAllBytes(filepath)))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.NOT_VALID_SOCROM,
                    METPromptType.Warning,
                    METPromptButtons.Okay);

                return;
            }

            // If a firmware is loaded, reset all data.
            if (SOCROM.FirmwareLoaded)
            {
                ResetWindow();
            }

            ToggleControlEnable(false);

            // Set the binary path and load the bytes.
            SOCROM.LoadedBinaryPath = filepath;
            SOCROM.LoadedBinaryBuffer = File.ReadAllBytes(filepath);

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

            SOCROM.LoadFirmwareBaseData(SOCROM.LoadedBinaryBuffer, filePath);

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
                SOCROM.FirmwareLoaded = true;
            }
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e) => BlurHelper.RemoveBlur(this);

        private void UpdateWindowTitle()
        {
            this.Text = SOCROM.FileInfoData.FileNameExt;
            lblTitle.Text = $"{APPSTRINGS.SOCROM} {Program.GLYPH_RIGHT_ARROW} {SOCROM.FileInfoData.FileNameExt}";
        }

        private void SetTipHandlers()
        {
            Button[] arrButtons =
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

            Label[] arrLabels = { lblParseTime };

            CheckBox[] arrCheckboxes = { cbxCensor };

            foreach (Button button in arrButtons)
            {
                button.MouseEnter += HandleMouseEnterTip;
                button.MouseLeave += HandleMouseLeaveTip;
            }

            foreach (Label label in arrLabels)
            {
                label.MouseEnter += HandleMouseEnterTip;
                label.MouseLeave += HandleMouseLeaveTip;
            }

            foreach (CheckBox checkBox in arrCheckboxes)
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
                Dictionary<object, string> dictTooltips = new Dictionary<object, string>
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

                if (dictTooltips.TryGetValue(sender, out string value))
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
                if (!Settings.ReadBool(SettingsBoolType.DisableTips))
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
                new { Button = cmdClose, Font = Program.FontSegMdl2Regular12, Text = Program.GLYPH_EXIT_CROSS },
                new { Button = cmdOpenInExplorer, Font = Program.FontSegMdl2Regular12, Text = Program.GLYPH_FILE_EXPLORER },
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
            string directory = Settings.ReadString(SettingsStringType.SocInitialDirectory);

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
                label.ForeColor = Color.White;
            }

            // Reset parse time.
            lblParseTime.Text = "0.00s";

            // Reset initial directory.
            SetInitialDirectory();

            // Reset window text.
            Text = APPSTRINGS.SOCROM;
            lblTitle.Text = APPSTRINGS.SOCROM;

            SOCROM.ResetFirmwareBaseData();
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
                exportScfgStoreToolStripMenuItem.Enabled = SOCROM.SCfgSectionData.StoreBase != -1;
                lookupSerialNumberToolStripMenuItem.Enabled = !string.IsNullOrEmpty(SOCROM.SCfgSectionData.Serial);

                cmdMenuPatch.Enabled = SOCROM.RomType == SocRomType.AppleT2; // Apple Silicon ROM patching is not supported.
                changeSerialNumberToolStripMenuItem.Enabled = SOCROM.SCfgSectionData.StoreBase != -1;
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
            UITools.ApplyNestedPanelLabelForeColor(tlpFirmware, Colours.ClrDisabledText);

            // Update window title.
            UpdateWindowTitle();

            // Unload image.
            pbxLoad.Image = null;

            // Check and set control enable
            ToggleControlEnable(true);
        }

        private void UpdateParseTimeControls() => lblParseTime.Text = $"{SOCROM.ParseTime.TotalSeconds:F2}s";

        private void UpdateFilenameControls() => lblFilename.Text = $"{APPSTRINGS.FILE}: '{SOCROM.FileInfoData.FileNameExt}'";

        private void UpdateFileSizeControls()
        {
            long lSize = SOCROM.FileInfoData.Length;
            bool bValidSize = FileTools.GetIsValidBinSize(lSize);

            lblFilesize.Text = $"{FileTools.FormatBytesWithCommas(lSize)} {APPSTRINGS.BYTES} ({lSize:X}h)";

            if (!bValidSize)
            {
                lblFilesize.ForeColor = Colours.ClrError;
                lblFilesize.Text += $" ({FileTools.GetSizeDifference(lSize)})";
            }
        }

        private void UpdateFileCrc32Controls() => lblCrc.Text = $"{SOCROM.FileInfoData.CRC32:X8}";

        private void UpdateFileCreationDateControls() => lblCreated.Text = SOCROM.FileInfoData.CreationTime;

        private void UpdateFileModifiedDateControls() => lblModified.Text = SOCROM.FileInfoData.LastWriteTime;

        private void UpdateIbootControls()
        {
            if (!string.IsNullOrEmpty(SOCROM.iBootVersion))
            {
                lbliBoot.Text = $"{SOCROM.iBootVersion} {SOCSTRINGS.ON} {(SOCROM.RomType == 0 ? SOCSTRINGS.T2 : SOCSTRINGS.SILICON)}";
                iBootVersionToolStripMenuItem.Enabled = true;

                return;
            }

            iBootVersionToolStripMenuItem.Enabled = false;
            lbliBoot.Text = APPSTRINGS.NA;
        }

        private void UpdateScfgControls()
        {
            if (SOCROM.SCfgSectionData.StoreBase == -1)
            {
                DisableScfgMenuItems();
                lblScfg.Text = APPSTRINGS.NA;
                return;
            }

            string scfgBase = $"{SOCROM.SCfgSectionData.StoreBase:X}h";
            string crc = SOCROM.SCfgSectionData.StoreCRC;
            int scfgSize = SOCROM.SCfgSectionData.StoreLength;

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
            string strSerial = SOCROM.SCfgSectionData.Serial;

            if (!string.IsNullOrEmpty(strSerial))
            {
                if (cbxCensor.Checked)
                {
                    lblSerial.Text = strSerial;
                }
                else
                {
                    lblSerial.Text = $"{strSerial.Substring(0, 2)}******{strSerial.Substring(8, 4)}";
                }

                if (!Serial.IsValid(strSerial))
                {
                    lblSerial.ForeColor = Colours.ClrWarn;
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
            if (!string.IsNullOrEmpty(SOCROM.ConfigCode))
            {
                lblConfigCode.Text = SOCROM.ConfigCode;
                configToolStripMenuItem.Enabled = true;
                return;
            }

            lblConfigCode.Text = APPSTRINGS.CONTACT_SERVER;
            lblConfigCode.ForeColor = Colours.ClrInfo;

            GetConfigCodeAsync(SOCROM.SCfgSectionData.HWC);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string strConfigCode = await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(strConfigCode))
            {
                SOCROM.ConfigCode = strConfigCode;
                lblConfigCode.Text = strConfigCode;
                lblConfigCode.ForeColor = Colours.ClrNormalText;
                configToolStripMenuItem.Enabled = true;
                return;
            }

            configToolStripMenuItem.Enabled = false;
            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.ClrDisabledText;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(SOCROM.SCfgSectionData.SON))
            {
                lblSon.Text = APPSTRINGS.NA;
                orderNoToolStripMenuItem.Enabled = false;
                return;
            }

            orderNoToolStripMenuItem.Enabled = true;

            lblSon.Text = SOCROM.SCfgSectionData.SON;

            if (!string.IsNullOrEmpty(SOCROM.SCfgSectionData.RegNumText))
            {
                lblSon.Text += SOCROM.SCfgSectionData.RegNumText;
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

            if (!Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                METPrompt.Show(
                    this,
                    $"'{text}' {EFISTRINGS.COPIED_TO_CB_LC}",
                    METPromptType.Information,
                    METPromptButtons.Okay);
            }
        }

        private void ClipboardSetFilename(bool showExtention) =>
            SetClipboardText(showExtention ? SOCROM.FileInfoData.FileNameExt : SOCROM.FileInfoData.FileName);

        private void ClipboardSetFileSize() =>
            SetClipboardText($"{FileTools.FormatBytesWithCommas(SOCROM.FileInfoData.Length)} {APPSTRINGS.BYTES} ({SOCROM.FileInfoData.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText($"{SOCROM.FileInfoData.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(SOCROM.FileInfoData.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(SOCROM.FileInfoData.LastWriteTime);

        private void ClipboardSetIbootVersion() => SetClipboardText(SOCROM.iBootVersion);

        private void ClipboardSetScfgBaseAddress() => SetClipboardText($"{SOCROM.SCfgSectionData.StoreBase:X}");

        private void ClipboardSetScfgSizeDecimal() => SetClipboardText($"{SOCROM.SCfgSectionData.StoreLength} {APPSTRINGS.BYTES}");

        private void ClipboardSetScfgSizeHex() => SetClipboardText($"{SOCROM.SCfgSectionData.StoreLength:X}h");

        private void ClipboardSetScfgCrc32() => SetClipboardText(SOCROM.SCfgSectionData.StoreCRC);

        private void ClipboardSetScfgConfig() => SetClipboardText(SOCROM.ConfigCode);

        private void ClipboardSetScfgOrderNo() => SetClipboardText($"{SOCROM.SCfgSectionData.SON}{SOCROM.SCfgSectionData.RegNumText ?? string.Empty}");
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
            if (SOCROM.SCfgSectionData.SerialBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                NotifyPatchingFailure();
                return;
            }

            // Create buffers.
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] bFirmwareBuffer = BinaryTools.CloneBuffer(SOCROM.LoadedBinaryBuffer);
            byte[] bNewSerial = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WriteCallerLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(bFirmwareBuffer, SOCROM.SCfgSectionData.SerialBase, bNewSerial);

            Logger.WriteCallerLine(LOGSTRINGS.SCFG_LFB);

            // Load patched scfg from the binary buffer.
            SCfgStore scfgStore = SOCROM.GetSCfgData(bFirmwareBuffer, false);

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
                SaveOutputFirmwareSocrom(bFirmwareBuffer);
                return;
            }

            Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
        }
        #endregion

        #region Write Scfg Store
        private void WriteScfgStore()
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog openFileDialog = CreateScfgOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_IMPORT_CANCELLED}");
                    return;
                }

                // Check the SOCROM contains a store, otherwise set the base address.
                int iScfgBase = SOCROM.SCfgSectionData.StoreBase;
                bool isScfgFound = true;

                // Set the Scfg base manually.
                if (iScfgBase == -1)
                {
                    isScfgFound = false;
                    Logger.WriteCallerLine($"{LOGSTRINGS.SCFG_BASE_ADJUST} {SOCROM.SCFG_EXPECTED_BASE:X}h");
                    iScfgBase = SOCROM.SCFG_EXPECTED_BASE;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] bFirmwareBuffer = BinaryTools.CloneBuffer(SOCROM.LoadedBinaryBuffer);
                byte[] bScfgBuffer = File.ReadAllBytes(openFileDialog.FileName);

                if (!ValidateScfgStore(bScfgBuffer))
                {
                    return;
                }

                // Check were not writing over data we shouldn't be.
                if (!isScfgFound)
                {
                    byte[] bWriteBuffer = BinaryTools.GetBytesBaseLength(bFirmwareBuffer, SOCROM.SCFG_EXPECTED_BASE, SOCROM.SCFG_EXPECTED_LENGTH);

                    for (int i = 0; i < bWriteBuffer.Length; i++)
                    {
                        if (bWriteBuffer[i] != 0xFF)
                        {
                            Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_POS_INITIALIZED}");
                            NotifyPatchingFailure();
                            return;
                        }
                    }
                }

                Logger.WriteLine(LOGSTRINGS.WRITE_NEW_DATA, LogType.Application);

                // Overwrite Scfg store in the binary buffer.
                BinaryTools.OverwriteBytesAtBase(bFirmwareBuffer, iScfgBase, bScfgBuffer);

                // Load Scfg store from the binary buffer.
                SCfgStore scfgStore = SOCROM.GetSCfgData(bFirmwareBuffer, false);

                // Check store was written successfully.
                if (!BinaryTools.ByteArraysMatch(scfgStore.StoreBuffer, bScfgBuffer))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                    NotifyPatchingFailure();
                    return;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                if (Prompts.ShowPathSuccessPrompt(this) == DialogResult.Yes)
                {
                    SaveOutputFirmwareSocrom(bFirmwareBuffer);
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

        private bool ValidateScfgStore(byte[] sourcebuffer)
        {
            int iScfgBase = BinaryTools.GetBaseAddress(sourcebuffer, SOCSigs.ScfgHeaderMarker);

            // A serialized Scfg store should be B8h, 184 bytes length.
            if (sourcebuffer.Length != SOCROM.SCFG_EXPECTED_LENGTH)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.EXPECTED_STORE_SIZE_NOT} {SOCROM.SCFG_EXPECTED_LENGTH:X}h ({sourcebuffer.Length:X}h)");

                NotifyPatchingFailure();
                return false;
            }

            // Expect scfg signature at address 0h.
            if (iScfgBase != 0)
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
        private static SaveFileDialog CreateFirmwareSaveFileDialog()
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
                FileName = SOCROM.FileInfoData.FileName,
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.BuildsDirectory
            };
        }

        private void SaveOutputFirmwareSocrom(byte[] binaryBuffer)
        {
            using (SaveFileDialog saveFileDialog = CreateFirmwareSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return;
                }

                if (FileTools.WriteAllBytesEx(saveFileDialog.FileName, binaryBuffer) && File.Exists(saveFileDialog.FileName))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.FILE_SAVE_SUCCESS} {saveFileDialog.FileName}");

                    DialogResult dlgResult =
                        METPrompt.Show(
                            this,
                            DIALOGSTRINGS.FW_SAVED_SUCCESS_LOAD,
                            METPromptType.Question,
                            METPromptButtons.YesNo);

                    if (dlgResult == DialogResult.Yes)
                    {
                        OpenBinary(saveFileDialog.FileName);
                    }
                }
            }
        }
        #endregion
    }
}