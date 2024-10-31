// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// t2Window.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.T2;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class t2Window : Form
    {

        #region Private Members
        private Thread _tLoadFirmware = null;
        private CancellationTokenSource _cancellationToken;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public t2Window()
        {
            InitializeComponent();

            // Attach event handlers
            Load += t2Window_Load;
            FormClosing += t2Window_FormClosing;
            FormClosed += t2Window_FormClosed;
            KeyDown += t2Window_KeyDown;
            pbxLogo.MouseMove += t2Window_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += t2Window_MouseMove;

            // Set tip handlers for controls
            SetTipHandlers();

            // Set button properties (font and text)
            SetButtonProperties();
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

        #region Mouse Events
        private void t2Window_MouseMove(object sender, MouseEventArgs e)
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
                METMessageBox.Show(
                    this,
                    DialogStrings.S_UNLOAD_RESET,
                    METMessageBoxType.Warning,
                    METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ToggleControlEnable(false);
                ResetWindow();
            }
        }

        private void cmdExportScfg_Click(object sender, EventArgs e)
        {
            if (T2ROM.ScfgSectionData.ScfgBytes == null)
            {
                METMessageBox.Show(
                this,
                $"ScfgSectionData.ScfgBytes() {DialogStrings.S_DATA_NULL}",
                METMessageBoxType.Error,
                METMessageBoxButtons.Okay);

                return;
            }

            Program.EnsureDirectoriesExist();

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
                FileName = $"{T2WinStrings.S_SCFG}_{T2ROM.ScfgSectionData.SerialText}",
                OverwritePrompt = true,
                InitialDirectory = METPath.ScfgDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                // Save the Scfg stores bytes to disk.
                if (FileUtils.WriteAllBytesEx(
                    dialog.FileName,
                    T2ROM.ScfgSectionData.ScfgBytes))
                {
                    UITools.ShowExplorerNavigationPrompt(
                        this,
                        DialogStrings.S_SCFG_EXPORT_SUCCESS,
                        dialog.FileName);

                    return;
                }

                METMessageBox.Show(
                    this,
                    DialogStrings.S_SCFG_EXPORT_FAIL,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);
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
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
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
                METMessageBox.Show(
                    this,
                    DialogStrings.S_NOT_VALID_FW,
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

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
                FileUtils.GetIsValidBinSize(
                    fsDecimal);

            lblFilesize.Text =
                $"{FileUtils.FormatFileSize(fsDecimal)} " +
                $"{EfiWinStrings.S_BYTES} ({fsDecimal:X}h)";

            if (!isValidSize)
            {
                lblFilesize.ForeColor =
                    AppColours.ERROR;

                lblFilesize.Text +=
                    $" ({FileUtils.GetSizeDifference(fsDecimal)})";
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

            lbliBoot.Text = AppStrings.S_NA;
        }

        private void UpdateScfgControls()
        {
            if (T2ROM.ScfgSectionData.StoreBase == -1)
            {
                lblScfg.Text = AppStrings.S_NOT_FOUND;
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
                lblSerial.Text = AppStrings.S_NA;
                return;
            }

            lblSerial.Text = T2ROM.ScfgSectionData.SerialText;
        }

        private void UpdateConfigCodeControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ConfigCode))
            {
                lblConfigCode.Text = AppStrings.S_CONTACT_SERVER;
                GetConfigCodeAsync(T2ROM.ScfgSectionData.HWC);
            }
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configcode =
                await MacUtils.GetDeviceConfigCodeSupportRemote(hwc);

            if (string.IsNullOrEmpty(configcode))
            {
                lblConfigCode.Text = AppStrings.S_NA;
                return;
            }

            T2ROM.ConfigCode = configcode;
            lblConfigCode.Text = configcode;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ScfgSectionData.SonText))
            {
                lblSon.Text = AppStrings.S_NA;
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
            var buttons = new[]
            {
                new { Button = cmdClose, Font = Program.FONT_MDL2_REG_12, Text = Chars.EXIT_CROSS},
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }
        #endregion

        #region Misc
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

    }
}