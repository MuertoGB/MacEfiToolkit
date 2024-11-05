// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSocRom.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.SOCROM;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmSocRom : METForm
    {
        #region Private Members
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        #endregion

        #region Constructor
        public frmSocRom()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(
                this,
                tlpTitle,
                lblTitle);

            // Set tip handlers for controls
            SetTipHandlers();

            // Set button properties (font and text)
            SetButtonProperties();
        }

        private void WireEventHandlers()
        {
            Load += t2Window_Load;
            FormClosing += t2Window_FormClosing;
            FormClosed += t2Window_FormClosed;
            KeyDown += t2Window_KeyDown;
            DragEnter += t2Window_DragEnter;
            DragDrop += t2Window_DragDrop;
            Deactivate += t2Window_Deactivate;
            Activated += t2Window_Activated;
        }
        #endregion

        #region Window Events
        private void t2Window_Load(object sender, EventArgs e)
        {
            _cancellationToken =
                new CancellationTokenSource();

            OpenBinary(Program.MAIN_WINDOW.loadedFile);
        }

        private void t2Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
                _cancellationToken.Cancel();
        }

        private void t2Window_FormClosed(object sender, FormClosedEventArgs e) =>
            _cancellationToken?.Dispose();

        private void t2Window_DragEnter(object sender, DragEventArgs e) =>
            Program.HandleDragEnter(sender, e);

        private void t2Window_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            // Open the binary file.
            OpenBinary(draggedFilename);
        }

        private void t2Window_Deactivate(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.DEACTIVATED_TEXT);

        private void t2Window_Activated(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.WHITE_TEXT);
        #endregion

        #region KeyDown Events
        private void t2Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void cmdMinimize_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdMenuOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "T2 SOCROM Files (*.bin, *.rom)|*.bin;*.rom|All Files (*.*)|*.*"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    OpenBinary(openFileDialog.FileName);
            }
        }

        private void cmdMenuReset_Click(object sender, EventArgs e)
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

        private void cmdMenuCopy_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsCopy,
                MenuPosition.BottomLeft);

        private void cmdExportScfg_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"{T2STRINGS.SCFG}_{SOCROM.ScfgSectionData.SerialText}",
                OverwritePrompt = true,
                InitialDirectory = METPath.SCFG_DIR
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                // Save the Scfg stores bytes to disk.
                if (FileTools.WriteAllBytesEx(
                    dialog.FileName,
                    SOCROM.ScfgSectionData.ScfgBytes))
                {
                    UITools.ShowExplorerFileHighlightPrompt(
                        this,
                        dialog.FileName);

                    return;
                }

                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.SCFG_EXPORT_FAIL,
                    METPromptType.Error,
                    METPromptButtons.Okay);
            }
        }
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

        private void serialToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgSerial();

        private void configToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgConfig();

        private void orderNoToolStripMenuItem_Click(object sender, EventArgs e) =>
            ClipboardSetScfgOrderNo();
        #endregion

        #region Open Binary
        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            if (SOCROM.FirmwareLoaded)
                ResetWindow();

            // Check filesize
            if (!FileTools.IsValidMinMaxSize(filePath, this))
                return;

            // Set the binary path and load the bytes.
            SOCROM.LoadedBinaryPath = filePath;

            SOCROM.LoadedBinaryBytes =
                File.ReadAllBytes(
                    filePath);

            // Check if the image is what we're looking for.
            if (!SOCROM.IsValidImage(SOCROM.LoadedBinaryBytes))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.FILE_NOT_VALID,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return;
            }

            pbxLoad.Image = Properties.Resources.loading;

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

            SOCROM.LoadFirmwareBaseData(
                SOCROM.LoadedBinaryBytes,
                filePath);

            if (cancellationToken.IsCancellationRequested)
                return;

            if (IsHandleCreated && !cancellationToken.IsCancellationRequested)
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
                SOCROM.FirmwareLoaded = true;
        }
        #endregion

        #region UI Events
        private void UpdateWindowTitle()
        {
            string title =
                $"{APPSTRINGS.SOCROM} {Program.GLYPH_RIGHT_ARROW} " +
                $"{SOCROM.FileInfoData.FileNameExt}";

            this.Text = SOCROM.FileInfoData.FileNameExt;
            lblTitle.Text = title;
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdMenuOpen,
                cmdMenuReset,
                cmdMenuCopy,
            };

            foreach (Button button in buttons)
            {
                button.MouseEnter += HandleMouseEnterTip;
                button.MouseLeave += HandleMouseLeaveTip;
            }
        }

        private void HandleMouseEnterTip(object sender, EventArgs e)
        {
            if (!Settings.ReadBool(SettingsBoolType.DisableTips))
            {
                Dictionary<object, string> tooltips = new Dictionary<object, string>
                {
                    { cmdMenuOpen, "Open a T2SOCROM (CTRL + O)" },
                    { cmdMenuReset, "Reset Window Data (CTRL + R)"},
                    { cmdMenuCopy, "Open the Clipboard Copy Menu (CTRL + C)" },
                };

                if (tooltips.ContainsKey(sender))
                    lblStatusBarTip.Text = tooltips[sender];
            }
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e) =>
            lblStatusBarTip.Text = string.Empty;

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }

        private void SetControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control ctrl in parentControl.Controls)
                ctrl.ForeColor = foreColor;
        }

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
        #endregion

        #region Misc Events
        private void ResetWindow()
        {
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

            // Reset window text.
            Text = APPSTRINGS.SOCROM;
            lblTitle.Text = APPSTRINGS.SOCROM;

            SOCROM.ResetFirmwareBaseData();
        }

        private void ToggleControlEnable(bool enable)
        {
            Button[] standardButtons =
            {
                cmdMenuReset,
                cmdMenuCopy,
            };

            void EnableButtons(params Button[] buttons)
            {
                foreach (var button in buttons)
                    button.Enabled = enable;
            }

            if (!enable)
            {
                EnableButtons(standardButtons);
            }
            else
            {
                EnableButtons(standardButtons);

                bool scfgStoreExists = SOCROM.ScfgSectionData.ScfgBytes != null;
            }

            tlpFirmware.Enabled = enable;
        }
        #endregion

        #region Update Window
        internal void UpdateUI()
        {
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

            ApplyNestedPanelLabelForeColor(
                tlpFirmware,
                AppColours.DISABLED_TEXT);

            // Update window title.
            UpdateWindowTitle();

            // Unload image
            pbxLoad.Image = null;

            // Check and set control enable
            ToggleControlEnable(true);
        }

        private void UpdateFilenameControls() =>
            lblFilename.Text = SOCROM.FileInfoData.FileNameExt;

        private void UpdateFileSizeControls()
        {
            int fsDecimal =
                SOCROM.FileInfoData.Length;

            bool isValidSize =
                FileTools.GetIsValidBinSize(
                    fsDecimal);

            lblFilesize.Text =
                $"{FileTools.FormatFileSize(fsDecimal)} " +
                $"{APPSTRINGS.BYTES} ({fsDecimal:X}h)";

            if (!isValidSize)
            {
                lblFilesize.ForeColor =
                    AppColours.ERROR;

                lblFilesize.Text +=
                    $" ({FileTools.GetSizeDifference(fsDecimal)})";
            }
        }

        private void UpdateFileCrc32Controls() =>
            lblCrc.Text = $"{SOCROM.FileInfoData.CRC32:X8}";

        private void UpdateFileCreationDateControls() =>
            lblCreated.Text = SOCROM.FileInfoData.CreationTime;

        private void UpdateFileModifiedDateControls() =>
            lblModified.Text = SOCROM.FileInfoData.LastWriteTime;

        private void UpdateIbootControls()
        {
            if (!string.IsNullOrEmpty(SOCROM.iBootVersion))
            {
                lbliBoot.Text = SOCROM.iBootVersion;

                iBootVersionToolStripMenuItem.Enabled = true;

                return;
            }

            iBootVersionToolStripMenuItem.Enabled = false;
            lbliBoot.Text = APPSTRINGS.NA;
        }

        private void UpdateScfgControls()
        {
            // Check if ScfgSectionData is null to avoid NullReferenceException
            if (SOCROM.ScfgSectionData.StoreBase == -1)
            {
                DisableScfgMenuItems();
                lblScfg.Text = APPSTRINGS.NA;
                return;
            }

            // Check if StoreBase is -1, indicating SCFG not found
            if (SOCROM.ScfgSectionData.StoreBase == -1)
            {
                DisableScfgMenuItems();
                lblScfg.Text = APPSTRINGS.NA;
                return;
            }

            // Fetch data and update the label
            string scfgBase = $"{SOCROM.ScfgSectionData.StoreBase:X}h";
            string crc = SOCROM.ScfgSectionData.ScfgCrc;
            int scfgSize = SOCROM.ScfgSectionData.StoreSize;

            lblScfg.Text = $"{scfgBase}, {scfgSize:X}h ({scfgSize} bytes), {crc}";

            // Enable menu items
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
            if (string.IsNullOrEmpty(SOCROM.ScfgSectionData.SerialText))
            {
                lblSerial.Text = APPSTRINGS.NA;

                serialToolStripMenuItem.Enabled = false;

                return;
            }

            serialToolStripMenuItem.Enabled = true;

            lblSerial.Text = SOCROM.ScfgSectionData.SerialText;
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
            lblConfigCode.ForeColor = Colours.INFO_BOX;

            GetConfigCodeAsync(SOCROM.ConfigCode);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configcode =
                await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configcode))
            {
                SOCROM.ConfigCode = configcode;

                lblConfigCode.Text = configcode;
                lblConfigCode.ForeColor = AppColours.NORMAL_INFO_TEXT;

                configToolStripMenuItem.Enabled = true;

                return;
            }

            configToolStripMenuItem.Enabled = false;

            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.CONTROL_DISABLED_TEXT;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(SOCROM.ScfgSectionData.SonText))
            {
                lblSon.Text = APPSTRINGS.NA;

                orderNoToolStripMenuItem.Enabled = false;

                return;
            }

            orderNoToolStripMenuItem.Enabled = true;

            lblSon.Text = SOCROM.ScfgSectionData.SonText;

            if (!string.IsNullOrEmpty(SOCROM.ScfgSectionData.RegNumText))
                lblSon.Text += SOCROM.ScfgSectionData.RegNumText;
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
                METPrompt.Show(
                    this,
                    $"'{text}' {EFISTRINGS.COPIED_TO_CB_LC}",
                    METPromptType.Information,
                    METPromptButtons.Okay);
            }
        }

        private void ClipboardSetFilename(bool showExtention) => SetClipboardText(
            showExtention
            ? SOCROM.FileInfoData.FileNameExt
            : SOCROM.FileInfoData.FileName);

        private void ClipboardSetFileSize() => SetClipboardText(
            $"{FileTools.FormatFileSize(SOCROM.FileInfoData.Length)} " +
            $"{APPSTRINGS.BYTES} ({SOCROM.FileInfoData.Length:X}h)");

        private void ClipboardSetFileCrc32() => SetClipboardText(
            $"{SOCROM.FileInfoData.CRC32:X8}");

        private void ClipboardSetFileCreationTime() => SetClipboardText(
            SOCROM.FileInfoData.CreationTime);

        private void ClipboardSetFileModifiedTime() => SetClipboardText(
            SOCROM.FileInfoData.LastWriteTime);

        private void ClipboardSetIbootVersion() => SetClipboardText(
            SOCROM.iBootVersion);

        private void ClipboardSetScfgBaseAddress() => SetClipboardText(
            $"{SOCROM.ScfgSectionData.StoreBase:X}h");

        private void ClipboardSetScfgSizeDecimal() => SetClipboardText(
            $"{SOCROM.ScfgSectionData.StoreSize} {APPSTRINGS.BYTES}");

        private void ClipboardSetScfgSizeHex() => SetClipboardText(
            $"{SOCROM.ScfgSectionData.StoreSize:X}h");

        private void ClipboardSetScfgCrc32() => SetClipboardText(
            SOCROM.ScfgSectionData.ScfgCrc);

        private void ClipboardSetScfgSerial() => SetClipboardText(
            SOCROM.ScfgSectionData.SerialText);

        private void ClipboardSetScfgConfig() => SetClipboardText(
            SOCROM.ConfigCode);

        private void ClipboardSetScfgOrderNo() =>
            SetClipboardText(
                $"{SOCROM.ScfgSectionData.SonText}" +
                $"{SOCROM.ScfgSectionData.RegNumText ?? string.Empty}");
        #endregion
    }
}