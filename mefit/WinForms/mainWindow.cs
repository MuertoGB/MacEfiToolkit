// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// mainWindow.cs
// Updated 04.05.23 - Remember strInitialDirectory last sucessful path
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Core;
using Mac_EFI_Toolkit.Interop;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.UI.Renderers;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class mainWindow : Form
    {
        private readonly Color clrUnknown = Color.Tomato;
        private readonly Color clrError = Color.FromArgb(255, 70, 50);
        private readonly Color clrGood = Color.FromArgb(128, 255, 128);

        internal static byte[] bytesLoadedFile;
        internal static byte[] bytesFsys;
        internal byte[] bytesDxeCompressed;
        internal static int intChecksum;
        internal static bool ValidBinaryLoaded = false;

        #region Strings
        internal static string strInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        internal static string strLoadedBinaryFilePath;
        internal static string strRememberPath = string.Empty;
        internal static string strChecksumBytesInBinary;
        internal static string strFilename;
        internal static long lngFilesize;
        internal static uint uintCrc;
        internal static string strFitcVersion;
        internal static string strMeVersion;
        internal static string strSerialNumber;
        internal static string strSon;
        internal static string strBoardId;
        internal static string strEfiVer;
        internal static string strBootrom;
        internal static string strApfsCapable;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.Style |= Program.WS_MINIMIZEBOX;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Startup Events
        public mainWindow()
        {
            InitializeComponent();

            Load += new EventHandler(mainWindow_Load);

            tlpMain.MouseMove += new MouseEventHandler(Move_Form);
            tlpMainIcon.MouseMove += new MouseEventHandler(Move_Form);
            labTitle.MouseMove += new MouseEventHandler(Move_Form);

            cmsMainMenu.Renderer = new METMenuRenderer();

            cmdMenu.Font = Program.FONT_MDL2_REG_14;
            cmdMenu.Text = "\xEDE3";
            cmdSerialCheck.Font = Program.FONT_MDL2_REG_9;
            cmdSerialCheck.Text = "\xF6FA";
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            ToggleControlEnable(false);
#if DEBUG
            labTitle.Text += $" ({Program.APP_BUILD})";
#endif
            labVersion.Text = Application.ProductVersion;

            // Setting to disable incoming
            CheckForNewVersion();
        }

        internal async void CheckForNewVersion()
        {
            var result = await METVersion.CheckForUpdate("https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml");

            if (result == VersionCheckResult.NewVersionAvailable)
            {
                labVersion.ForeColor = Color.Tomato;
                labVersion.Cursor = Cursors.Hand;
            }
        }

        #endregion

        #region Mouse Events
        private void Move_Form(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Program.ExitMet(this);
        }

        private void cmdMin_Click(object sender, EventArgs e)
        {
            // Minimizes application
            WindowState = FormWindowState.Minimized;
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(-1, ((Button)sender).Height + 2);
            ptLowerLeft = ((Button)sender).PointToScreen(ptLowerLeft);
            cmsMainMenu.Show(ptLowerLeft);
        }

        private void cmdOpenBin_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofDialog = new OpenFileDialog())
            {
                ofDialog.InitialDirectory = strInitialDirectory;
                ofDialog.Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*";

                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    strLoadedBinaryFilePath = ofDialog.FileName; // Get filepath for binary
                    bytesLoadedFile = File.ReadAllBytes(strLoadedBinaryFilePath); // Load new binary bytes into array
                    if (boolIsValidFirmware() == true)
                    {
                        strInitialDirectory = strLoadedBinaryFilePath;
                        LoadEfiData();
                    }
                    else
                    {
                        strLoadedBinaryFilePath = string.Empty;
                        bytesLoadedFile = null;
                    }
                }
            }
        }

        private void cmdResetUnload_Click(object sender, EventArgs e)
        {
            DialogResult result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", MsgType.Warning, MsgButton.YesNoCancel);

            switch (result)
            {
                case DialogResult.Yes:
                    ResetClear();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void cmdExportFsys_Click(object sender, EventArgs e)
        {
            if (bytesFsys != null)
            {
                using (SaveFileDialog sfDialog = new SaveFileDialog())
                {
                    sfDialog.Filter = "Binary Files (*.bin)|*.bin";
                    sfDialog.Title = "Export Fsys block data...";
                    sfDialog.FileName = string.Concat("Fsys_", strSerialNumber, ".bin");
                    sfDialog.InitialDirectory = strInitialDirectory;

                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllBytes(sfDialog.FileName, bytesFsys);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fsys block bytes[] empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSerialCheck_Click(object sender, EventArgs e)
        {
            // Opens a browser window to EveryMac, and automatically loads in the serial.
            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", strSerialNumber));
        }
        #endregion

        #region Toolstrip Events
        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            METMessageBox.Show(this, "Information", "This settings dialog is not enabled yet.", MsgType.Information, MsgButton.Okay);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new aboutWindow())
            {
                frm.ShowDialog();
            }
        }
        #endregion

        #region Firmware Parsing

        internal static bool boolIsValidFirmware()
        {
            FileInfo fInfo = new FileInfo(strLoadedBinaryFilePath);
            // Binary too small? Potential bug here.
            if (fInfo.Length < Program.minRomSize) // 1048576 bytes
            {
                MessageBox.Show("File too small, ignored.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            // Binary too large, no Mac EFI is this big.
            if (fInfo.Length > Program.maxRomSize) // 33554432 bytes
            {
                MessageBox.Show("File too large, ignored.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!FirmwareParser.boolIsValidFlashHeader(bytesLoadedFile))
            {
                MessageBox.Show("Invalid flash descriptor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        internal void LoadEfiData()
        {
            // Filename
            strFilename = Path.GetFileName(strLoadedBinaryFilePath);
            // Size
            lngFilesize = FileUtils.GetFileSizeBytes(strLoadedBinaryFilePath);
            // CRC32
            uintCrc = FileUtils.CalculateCrc32(bytesLoadedFile);
            // FITC
            strFitcVersion = MEParser.GetFitcVersion(bytesLoadedFile);
            //ME
            strMeVersion = MEParser.GetMeVersion(bytesLoadedFile);
            // EFI Version
            strEfiVer = FirmwareParser.GetEfiVersionFromAppleRomSection(bytesLoadedFile);
            // ROM version
            strBootrom = FirmwareParser.GetBootromVersionFromAppleRomSection(bytesLoadedFile);
            // Fsys
            bytesFsys = FirmwareParser.GetFsysBlock(bytesLoadedFile);
            if (bytesFsys != null)
            {
                ValidBinaryLoaded = true;

                // Define new byte array and copy 0x7FC len of bytes into new array
                byte[] bytesFsysRaw = new byte[0x7FC];
                Array.Copy(bytesFsys, 0, bytesFsysRaw, 0, bytesFsysRaw.Length);

                // Calculate the Fsys CRC32 checksum from the byte array to get the actual Fsys checksum, not what is stored in the binary.
                intChecksum = (int)FileUtils.CalculateCrc32(bytesFsysRaw);

                // Calculate Fsys CRC32 checksum from original binary with length of 0X7FC.
                strChecksumBytesInBinary = FirmwareParser.GetFsysCrc32(bytesLoadedFile);

                // Check if the CRC32 is valid in the original binary, and handle accordingly.
                ToggleControlEnable(true);
            }
            else
            {
                cmdReset.Enabled = true;
            }

            // APFSJumpStart
            strApfsCapable = FirmwareParser.GetIsApfsCapable(bytesLoadedFile).ToString();
            // Serial number
            strSerialNumber = FirmwareParser.GetFsysSerialNumber(bytesFsys);
            // Config code
            CheckHwcAsync(strSerialNumber);
            // SON
            strSon = FirmwareParser.GetFsysSon(bytesFsys);
            // Get the BoardId
            strBoardId = FirmwareParser.GetPdrBoardId(bytesLoadedFile);

            UpdateControls();
        }

        internal void UpdateControls()
        {
            labFilename.Text = $"> {strFilename}";
            labSizeBytes.ForeColor = EFIUtils.IsValidSize((int)lngFilesize) ? clrGood : clrUnknown;
            labSizeBytes.Text = FileUtils.FormatBytesWithCommas(FileUtils.GetFileSizeBytes(strLoadedBinaryFilePath));
            labChecksum.Text = uintCrc.ToString("X2");
            labFitcVersion.Text = strFitcVersion;
            labMeVersion.Text = strMeVersion;
            labEfiVersion.Text = strEfiVer;
            labRomVersion.Text = strBootrom;
            labApfsCapable.Text = strApfsCapable;

            if (string.Equals(intChecksum.ToString("X2"), strChecksumBytesInBinary))
            {
                labFsysCrc.ForeColor = clrGood;
                labFsysCrc.Text = $"{ strChecksumBytesInBinary }h";
            }
            else
            {
                labFsysCrc.ForeColor = clrError;
                labFsysCrc.Text = $"{strChecksumBytesInBinary}h, should be {intChecksum.ToString("X2")}h";
            }

            labValid.Text = ValidBinaryLoaded ? "Yes" : "No";
            labSerial.Text = strSerialNumber;
            labSon.Text = strSon;
            labBoardId.Text = strBoardId;
        }

        internal async void CheckHwcAsync(string serialNumber)
        {
            var configCode = await EFIUtils.GetConfigCodeStringAsync(serialNumber);
            labConfig.Text = $"> {configCode}";

        }
        #endregion

        #region Reset
        private void ResetClear()
        {
            // Reset labels
            Label[] labels = { labFilename, labSizeBytes, labChecksum, labValid, labFitcVersion,
                labMeVersion, labApfsCapable,  labEfiVersion, labFsysCrc, labRomVersion, labConfig, labSerial, labSon, labBoardId };
            Color defaultColor = Color.White;
            foreach (Label label in labels)
            {
                label.Text = "...";
                label.ForeColor = defaultColor;
            }

            ToggleControlEnable(false);

            // Clear loaded binary data
            bytesLoadedFile = null;
            bytesFsys = null;
            bytesDxeCompressed = null;

            //Reset boolean
            ValidBinaryLoaded = false;

            // Clear the large object heap
            GC.Collect();
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                if (GC.WaitForFullGCComplete() == GCNotificationStatus.Succeeded)
                {
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        private void ToggleControlEnable(bool Enable)
        {
            Button[] buttons = { cmdReset, cmdExportFsys, cmdSerialCheck };
            // cmdReplaceFsys, cmdRepairFsys, cmdEditEfirom
            foreach (Button button in buttons)
            {
                button.Enabled = (Enable) ? true : false;
            }
        }
        #endregion

    }
}