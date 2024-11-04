// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// t2Window.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.T2;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class t2Window : METForm
    {
        #region Private Members
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        #endregion

        #region Constructor
        public t2Window()
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
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
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
        #endregion

        #region KeyDown Events
        private void t2Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
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
                Filter = "T2 SOCROM Files (*.bin, *.rom)|*.bin;*.rom|All Files (*.*)|*.*"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    OpenBinary(openFileDialog.FileName);
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

        private void cmdExportScfg_Click(object sender, EventArgs e)
        {
            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"{T2STRINGS.SCFG}_{T2ROM.ScfgSectionData.SerialText}",
                OverwritePrompt = true,
                InitialDirectory = METPath.SCFG_DIR
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                // Save the Scfg stores bytes to disk.
                if (FileTools.WriteAllBytesEx(
                    dialog.FileName,
                    T2ROM.ScfgSectionData.ScfgBytes))
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

        #region Open Binary
        private void OpenBinary(string filePath)
        {
            ToggleControlEnable(false);

            if (T2ROM.FirmwareLoaded)
                ResetWindow();

            // Check filesize
            if (!FileTools.IsValidMinMaxSize(filePath, this))
            {
                // reset all data
                return;
            }

            // Set the binary path and load the bytes.
            T2ROM.LoadedBinaryPath = filePath;

            T2ROM.LoadedBinaryBytes =
                File.ReadAllBytes(
                    filePath);

            // Check if the image is what we're looking for.
            if (!T2ROM.IsValidImage(T2ROM.LoadedBinaryBytes))
            {
                METPrompt.Show(
                    this,
                    DIALOGSTRINGS.FILE_NOT_VALID,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return; // Break out of code
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

            T2ROM.LoadFirmwareBaseData(
                T2ROM.LoadedBinaryBytes,
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
                T2ROM.FirmwareLoaded = true;
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

            T2ROM.ResetFirmwareBaseData();
        }

        private void ToggleControlEnable(bool enable)
        {
            Button[] standardButtons =
            {
                cmdReset,
                cmdCopyMenu,
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

                bool scfgStoreExists = T2ROM.ScfgSectionData.ScfgBytes != null;
            }

            tlpFirmware.Enabled = enable;
        }
        #endregion

        #region UI Events
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

            // Unload image
            pbxLoad.Image = null;

            // Check and set control enable
            ToggleControlEnable(true);
        }

        private void UpdateFilenameControls() =>
            lblFilename.Text = T2ROM.FileInfoData.FileNameExt;

        private void UpdateFileSizeControls()
        {
            int fsDecimal =
                T2ROM.FileInfoData.Length;

            bool isValidSize =
                FileTools.GetIsValidBinSize(
                    fsDecimal);

            lblFilesize.Text =
                $"{FileTools.FormatFileSize(fsDecimal)} " +
                $"{EFISTRINGS.BYTES} ({fsDecimal:X}h)";

            if (!isValidSize)
            {
                lblFilesize.ForeColor =
                    AppColours.ERROR;

                lblFilesize.Text +=
                    $" ({FileTools.GetSizeDifference(fsDecimal)})";
            }
        }

        private void UpdateFileCrc32Controls() =>
            lblCrc.Text = $"{T2ROM.FileInfoData.CRC32:X8}";

        private void UpdateFileCreationDateControls() =>
            lblCreated.Text = T2ROM.FileInfoData.CreationTime;

        private void UpdateFileModifiedDateControls() =>
            lblModified.Text = T2ROM.FileInfoData.LastWriteTime;

        private void UpdateIbootControls()
        {
            if (!string.IsNullOrEmpty(T2ROM.iBootVersion))
            {
                lbliBoot.Text = T2ROM.iBootVersion;
                return;
            }

            lbliBoot.Text = APPSTRINGS.NA;
        }

        private void UpdateScfgControls()
        {
            if (T2ROM.ScfgSectionData.StoreBase == -1)
            {
                lblScfg.Text = APPSTRINGS.NOT_FOUND;
                return;
            }

            string scfgBase = $"{T2ROM.ScfgSectionData.StoreBase:X}h";
            int scfgSize = T2ROM.ScfgSectionData.StoreSize;
            string crc = T2ROM.ScfgSectionData.ScfgCrc;

            lblScfg.Text =
                $"{scfgBase} " +
                $"({scfgSize:X}h, " +
                $"{scfgSize} bytes) | " +
                $"{crc}";
        }

        private void UpdateSerialControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ScfgSectionData.SerialText))
            {
                lblSerial.Text = APPSTRINGS.NA;
                return;
            }

            lblSerial.Text = T2ROM.ScfgSectionData.SerialText;
        }

        private void UpdateConfigCodeControls()
        {

            if (!string.IsNullOrEmpty(T2ROM.ConfigCode))
            {
                lblConfigCode.Text = T2ROM.ConfigCode;
                return;
            }

            lblConfigCode.Text = APPSTRINGS.CONTACT_SERVER;
            lblConfigCode.ForeColor = Colours.INFO_BOX;

            GetConfigCodeAsync(T2ROM.ConfigCode);
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configcode =
                await MacTools.GetDeviceConfigCodeSupportRemote(hwc);

            if (!string.IsNullOrEmpty(configcode))
            {
                T2ROM.ConfigCode = configcode;

                lblConfigCode.Text = configcode;
                lblConfigCode.ForeColor = AppColours.NORMAL_INFO_TEXT;
                return;
            }

            lblConfigCode.Text = APPSTRINGS.NA;
            lblConfigCode.ForeColor = Colours.CONTROL_DISABLED_TEXT;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ScfgSectionData.SonText))
            {
                lblSon.Text = APPSTRINGS.NA;
                return;
            }

            lblSon.Text = T2ROM.ScfgSectionData.SonText;

            if (!string.IsNullOrEmpty(T2ROM.ScfgSectionData.RegNumText))
                lblSon.Text += T2ROM.ScfgSectionData.RegNumText;
        }

        private void SetTipHandlers()
        {
            Button[] buttons =
            {
                cmdOpen,
                cmdReset,
                cmdCopyMenu,
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
                    { cmdOpen, "Open a T2ROM (CTRL + O)" },
                    { cmdReset, "Reset Window Data (CTRL + R)"},
                    { cmdCopyMenu, "Open the Clipboard Copy Menu (CTRL + C)" },
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
        #endregion
    }
}