// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class editorWindow : Form
    {

        #region Private Members
        private byte[] _byteNewFsysRegion = null;
        private string _strChevronRight = "\xE76C";

        private long _primaryVssOffset = -1;
        private int _primaryVssSize = -1;
        private long _backupVssOffset = -1;
        private int _backupVssSize = -1;

        private long _primarySvsOffset = -1;
        private int _primarySvsSize = -1;
        private long _backupSvsOffset = -1;
        private int _backupSvsSize = -1;

        private long _primaryNssOffset = -1;
        private int _primaryNssSize = -1;
        private long _backupNssOffset = -1;
        private int _backupNssSize = -1;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public editorWindow()
        {
            InitializeComponent();

            lblTitle.MouseMove += editorWindow_MouseMove;

            var font = Program.FONT_MDL2_REG_9;
            var chevronRight = _strChevronRight;

            lblSvsChevRight.Font = font;
            lblSvsChevRight.Text = chevronRight;
            lblSvsChevRight.Visible = false;

            lblVssChevRight.Font = font;
            lblVssChevRight.Text = chevronRight;
            lblVssChevRight.Visible = false;

            lblNssChevRight.Font = font;
            lblNssChevRight.Text = chevronRight;
            lblNssChevRight.Visible = false;

            tbxSerialNumber.MaxLength = FWParser.strSerialNumber.Length;

            Logger.WriteLogTypeTextToRtb($"{DateTime.Now}", RtbLogPrefix.MET, rtbLog);

            LoadNvramStoreData();
        }
        #endregion

        #region Window Events
        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils.GetDeviceConfigCodeAsync(strHwc);

            if (configCode == "N/A")
            {
                Logger.WriteLogTypeTextToRtb($"Config: HWC could not be matched.", RtbLogPrefix.Error, rtbLog);
            }
            else
            {
                Logger.WriteLogTypeTextToRtb($"Config: {configCode}", RtbLogPrefix.Info, rtbLog);
            }
        }
        #endregion

        #region Mouse Events
        private void editorWindow_MouseMove(object sender, MouseEventArgs e)
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
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = Program.strRememberPath,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceFsysRgn.Checked = false;
                    return;
                }

                Logger.WriteLogTypeTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.MET, rtbLog);
                _byteNewFsysRegion = File.ReadAllBytes(dialog.FileName);
                bool isValid = ValidateNewFsysRegion(_byteNewFsysRegion);
                if (!isValid) cbxReplaceFsysRgn.Checked = false;
            }
        }
        #endregion

        #region Checkbox Events

        private void cbxClearVssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupVssOffset != -1)
            {
                lblVssChevRight.Visible = cb.Checked;
                cbxClearVssBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupSvsOffset != -1)
            {
                lblSvsChevRight.Visible = cb.Checked;
                cbxClearSvsBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupNssOffset != -1)
            {
                lblNssChevRight.Visible = cb.Checked;
                cbxClearNssBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysRgn_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            cmdFsysPath.Enabled = isChecked;
            tlpFsysB.Enabled = isChecked;
            tlpSerialA.Enabled = !isChecked;

            if (isChecked)
            {
                cmdFsysPath.PerformClick();
            }
            else
            {
                cbxMaskCrc.Checked = false;
            }
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            tlpSerialB.Enabled = isChecked;
            tlpFsysA.Enabled = !isChecked;

            if (!isChecked)
            {
                tbxSerialNumber.Text = string.Empty;
                tbxHwc.Text = string.Empty;
            }
        }
        #endregion

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textLength = tb.Text.Length;

            if (textLength == FWParser.strSerialNumber.Length)
            {
                if (EFIUtils.GetIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.clrGood);
                    Logger.WriteLogTypeTextToRtb("Valid serial characters entered.", RtbLogPrefix.Info, rtbLog);
                    if (FWParser.strSerialNumber.Length == 11)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 3));
                    }
                    if (FWParser.strSerialNumber.Length == 12)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 4));
                    }

                    string strHwc = tbxHwc.Text.ToUpper();
                    CheckHwcAsync(strHwc);

                }
                else
                {
                    UpdateTextBoxColor(tb, Colours.clrError);
                    Logger.WriteLogTypeTextToRtb("Invalid serial characters entered.", RtbLogPrefix.Error, rtbLog);
                    UpdateHwcTextBoxText(string.Empty);
                }
            }
            else
            {
                UpdateTextBoxColor(tb, Color.White);
                UpdateHwcTextBoxText(string.Empty);
            }
        }

        private void UpdateTextBoxColor(TextBox textBox, Color color)
        {
            textBox.ForeColor = color;
        }

        private void UpdateHwcTextBoxText(string text)
        {
            tbxHwc.Text = text;
        }
        #endregion

        #region Validation
        private bool ValidateNewFsysRegion(byte[] bytesIn)
        {
            Logger.WriteLogTypeTextToRtb("Validating donor Fsys region...", RtbLogPrefix.MET, rtbLog);

            if (bytesIn.Length != FWParser.intFsysRegionSize)
            {
                Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            long lSigPos = BinaryUtils.GetOffset(bytesIn, FSSignatures.FSYS_SIG);
            if (lSigPos == -1 || lSigPos != 0)
            {
                Logger.WriteLogTypeTextToRtb(lSigPos == -1 ? "Fsys signature not found." : $"Fsys signature misaligned at {lSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            string strSerial = FWParser.GetFsysSerialNumber(bytesIn);
            int lenSerial = strSerial.Length;
            string strHwc = lenSerial == 11 ? strSerial.Substring(strSerial.Length - 3).ToUpper() : lenSerial == 12 ? strSerial.Substring(strSerial.Length - 4).ToUpper() : string.Empty;

            Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"Fsys sig found at {lSigPos:X2}h.", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"Serial: {strSerial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"HWC: {strHwc}", RtbLogPrefix.Info, rtbLog);
            CheckHwcAsync(strHwc);

            string strCrcInFile = FWParser.GetFsysCrc32(bytesIn);
            string strCrcCalculated = EFIUtils.GetUintFsysCrc32(bytesIn).ToString("X8");

            Logger.WriteLogTypeTextToRtb($"CRC in Fsys: {strCrcInFile}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"CRC Calc:    {strCrcCalculated}h", RtbLogPrefix.Info, rtbLog);

            if (strCrcInFile == strCrcCalculated)
            {
                Logger.WriteLogTypeTextToRtb("Fsys CRC32 is valid.", RtbLogPrefix.MET, rtbLog);
                cbxMaskCrc.Checked = false;
            }
            else
            {
                Logger.WriteLogTypeTextToRtb("Fsys CRC32 is invalid, 'Mask CRC32' option selected.", RtbLogPrefix.Warn, rtbLog);
                cbxMaskCrc.Checked = true;
            }

            Logger.WriteLogTypeTextToRtb("Validation complete.", RtbLogPrefix.MET, rtbLog);
            return true;
        }

        private void LoadNvramStoreData()
        {
            Logger.WriteLogTypeTextToRtb($"Detect NVRAM stores...", RtbLogPrefix.MET, rtbLog);

            NvramStoreData vssStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.VSS);
            if (vssStore.PrimaryStoreOffset != -1)
            {
                _primaryVssOffset = vssStore.PrimaryStoreOffset;
                _primaryVssSize = vssStore.PrimaryStoreSize;
                Logger.WriteLogTypeTextToRtb($"VSS Store:-  Offset {_primaryVssOffset:X2}h, Size {_primaryVssSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearVssStore.Enabled = false;
            }

            if (vssStore.BackupStoreOffset != -1)
            {
                _backupVssOffset = vssStore.BackupStoreOffset;
                _backupVssSize = vssStore.BackupStoreSize;
                Logger.WriteLogTypeTextToRtb($"VSS Backup:- Offset {_backupVssOffset:X2}h, Size {_backupVssSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearVssBackup.Enabled = false;
                lblVssChevRight.Visible = false;
            }

            NvramStoreData svsStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.SVS);
            if (svsStore.PrimaryStoreOffset != -1)
            {
                _primarySvsOffset = svsStore.PrimaryStoreOffset;
                _primarySvsSize = svsStore.PrimaryStoreSize;
                Logger.WriteLogTypeTextToRtb($"SVS Store:-  Offset {_primarySvsOffset:X2}h, Size {_primarySvsSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearSvsStore.Enabled = false;
            }

            if (svsStore.BackupStoreOffset != -1)
            {
                _backupSvsOffset = svsStore.BackupStoreOffset;
                _backupSvsSize = svsStore.BackupStoreSize;
                Logger.WriteLogTypeTextToRtb($"SVS Backup:- Offset {_backupSvsOffset:X2}h, Size {_backupSvsSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearSvsBackup.Enabled = false;
                lblSvsChevRight.Visible = false;
            }

            NvramStoreData nssStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.NSS);

            if (nssStore.PrimaryStoreOffset != -1)
            {
                _primaryNssOffset = nssStore.PrimaryStoreOffset;
                _primaryNssSize = nssStore.PrimaryStoreSize;
                Logger.WriteLogTypeTextToRtb($"NSS Store:-  Offset {_primaryNssOffset:X2}h, Size {_primaryNssSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearNssStore.Enabled = false;
            }

            if (nssStore.BackupStoreOffset != -1)
            {
                _backupNssOffset = nssStore.BackupStoreOffset;
                _backupNssSize = nssStore.BackupStoreSize;
                Logger.WriteLogTypeTextToRtb($"NSS Backup:- Offset {_backupNssOffset:X2}h, Size {_backupNssSize:X2}h", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                cbxClearNssBackup.Enabled = false;
                lblNssChevRight.Visible = false;
            }

            Logger.WriteLogTypeTextToRtb($"Detect NVRAM stores complete...", RtbLogPrefix.MET, rtbLog);
        }
        #endregion

    }
}