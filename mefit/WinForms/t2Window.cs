// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// t2Window.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.T2;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class t2Window : Form
    {

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

            KeyDown += t2Window_KeyDown;

            pbxLogo.MouseMove += t2Window_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += t2Window_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;

            cmdTransfer.Font = Program.FONT_MDL2_REG_10;
            cmdTransfer.Text = Chars.FLOW;

            cmdExportScfg.Font = Program.FONT_MDL2_REG_10;
            cmdExportScfg.Text = Chars.SAVE;
        }
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

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "T2ROM Files (*.bin, *.rom)|*.bin;*.rom|All Files (*.*)|*.*"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    OpenBinary(ofd.FileName);
            }
        }
        #endregion

        #region Open Binary
        private void OpenBinary(string filePath)
        {
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
                    AppStrings.AS_ERROR,
                    "The selected file is not a valid T2ROM.",
                    METMessageBoxType.Error,
                    METMessageBoxButtons.Okay);

                return; // Break out of code
            }

            // Parse T2 ROM data.
            T2ROM.LoadFirmwareBaseData(
                T2ROM.LoadedBinaryBytes,
                T2ROM.LoadedBinaryPath);

            // Update the User Interface.
            Invoke((MethodInvoker)UpdateUI);
        }
        #endregion

        #region Update UI
        internal void UpdateUI()
        {
            UpdateFilenameControls();
            UpdateFileSizeControls();
            UpdateFileCrc32Controls();
            UpdateFileCreationDateControls();
            UpdateFileModifiedDateControls();
            UpdateIbootControls();
            UpdateScfgControls();
            UpdateSerialControls();
            UpdateConfigCodeControls();
            UpdateModelControls();
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
                $"{FileUtils.FormatFileSize(fsDecimal)}" +
                $"{MainWinStrings.MW_BYTES} ({fsDecimal:X}h)";

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

            lbliBoot.Text = AppStrings.AS_NA;
        }

        private void UpdateScfgControls()
        {
            if (T2ROM.ScfgSectionData.StoreBase == -1)
            {
                lblScfg.Text = "Not Found";
                return;
            }

            string scfgBase = $"{T2ROM.ScfgSectionData.StoreBase:X}h";
            int scfgSize = T2ROM.ScfgSectionData.StoreSize;

            lblScfg.Text =
                $"{scfgBase} " +
                $"({scfgSize:X}h, " +
                $"{scfgSize} bytes)";
        }

        private void UpdateSerialControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ScfgSectionData.SerialText))
            {
                lblSerial.Text = AppStrings.AS_NA;
                return;
            }

            lblSerial.Text = T2ROM.ScfgSectionData.SerialText;
        }

        private void UpdateConfigCodeControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ConfigCode))
            {
                lblConfigCode.Text = AppStrings.AS_CONTACT_SERVER;
                GetConfigCodeAsync(T2ROM.ScfgSectionData.HWC);
            }
        }

        internal async void GetConfigCodeAsync(string hwc)
        {
            string configcode =
                await MacUtils.GetDeviceConfigCodeSupportRemote(hwc);

            if (string.IsNullOrEmpty(configcode))
            {
                lblConfigCode.Text = AppStrings.AS_NA;
                return;
            }

            T2ROM.ConfigCode = configcode;
            lblConfigCode.Text = configcode;
        }

        private void UpdateModelControls()
        {
            if (string.IsNullOrEmpty(T2ROM.ScfgSectionData.SonText))
            {
                lblSon.Text = AppStrings.AS_NA;
                return;
            }

            lblSon.Text = T2ROM.ScfgSectionData.SonText;

            if (!string.IsNullOrEmpty(T2ROM.ScfgSectionData.RegNumText))
                lblSon.Text += T2ROM.ScfgSectionData.RegNumText;
        }
        #endregion

    }
}
