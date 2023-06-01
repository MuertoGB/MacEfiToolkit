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

            InitLogBox();
        }
        #endregion

        #region Window Events
        private void InitLogBox()
        {
            rtbLog.Clear();
            Logger.WriteLogTypeTextToRtb($"{DateTime.Now}", RtbLogPrefix.MET, rtbLog);
        }

        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils.GetStringConfigCodeAsync(strHwc);
            Logger.WriteLogTypeTextToRtb($"Config:      {configCode}", RtbLogPrefix.Info, rtbLog);
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
        private void cbxClearSvsRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            lblSvsChevRight.Visible = cb.Checked;
            cbxClearSvsBackup.Enabled = cb.Checked;
            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearVssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            lblVssChevRight.Visible = cb.Checked;
            cbxClearVssBackup.Enabled = cb.Checked;
            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearNssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            lblNssChevRight.Visible = cb.Checked;
            cbxClearNssBackup.Enabled = cb.Checked;
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
                if (EFIUtils.GetBoolIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.clrGood);
                    Logger.WriteLogTypeTextToRtb("Valid serial number entered", RtbLogPrefix.Info, rtbLog);
                    UpdateHwcTextBoxText(tb.Text.Substring(textLength - 4));
                }
                else
                {
                    UpdateTextBoxColor(tb, Colours.clrError);
                    Logger.WriteLogTypeTextToRtb("Invalid serial number entered", RtbLogPrefix.Error, rtbLog);
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

        #region Fsys validation
        private bool ValidateNewFsysRegion(byte[] bytesIn)
        {
            Logger.WriteLogTypeTextToRtb("Validating donor Fsys region...", RtbLogPrefix.MET, rtbLog);

            if (bytesIn.Length != FWParser.intFsysRegionExactSize)
            {
                Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            long lSigPos = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);
            if (lSigPos == -1 || lSigPos != 0)
            {
                Logger.WriteLogTypeTextToRtb(lSigPos == -1 ? "Fsys signature not found." : $"Fsys signature misaligned at {lSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            string strSerial = FWParser.GetFsysRegionSerialNumber(bytesIn);
            int lenSerial = strSerial.Length;
            string strHwc = lenSerial == 11 ? strSerial.Substring(strSerial.Length - 3).ToUpper() : lenSerial == 12 ? strSerial.Substring(strSerial.Length - 4).ToUpper() : string.Empty;

            Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"Fsys sig found at {lSigPos:X2}h.", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"Serial:      {strSerial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"HWC:         {strHwc}", RtbLogPrefix.Info, rtbLog);
            CheckHwcAsync(strHwc);

            string strCrcInFile = FWParser.GetFsysRegionCRC32(bytesIn);
            string strCrcCalculated = EFIUtils.GetUintCalculateFsysCrc32(bytesIn).ToString("X8");

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
        //private bool ValidateNewFsysRegion(byte[] bytesIn)
        //{
        //    Logger.WriteLogTypeTextToRtb($"Validating donor Fsys region...", RtbLogPrefix.MET, rtbLog);

        //    // Check length of bytes is 800h
        //    if (bytesIn.Length != FWParser.intFsysRegionExactSize)
        //    {
        //        Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length.ToString("X2")}h, expected 800h", RtbLogPrefix.Error, rtbLog);
        //        return false;
        //    }

        //    // Look for Fsys signature at pos 00h.
        //    long lSigPos = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);
        //    if (lSigPos == -1)
        //    {
        //        Logger.WriteLogTypeTextToRtb($"Fsys signature not found.", RtbLogPrefix.Error, rtbLog);
        //        return false;
        //    }
        //    else
        //    {
        //        if (lSigPos != 0)
        //        {
        //            Logger.WriteLogTypeTextToRtb($"Fsys signature misaligned at {lSigPos.ToString("X2")}h", RtbLogPrefix.Error, rtbLog);
        //            return false;
        //        }
        //    }

        //    string strHwc = string.Empty;
        //    string strSerial = FWParser.GetFsysRegionSerialNumber(bytesIn);
        //    int lenSerial = strSerial.Length;

        //    switch (lenSerial)
        //    {
        //        case 11:
        //            strHwc = strSerial.Substring(strSerial.Length - 3).ToUpper();
        //            break;
        //        case 12:
        //            strHwc = strSerial.Substring(strSerial.Length - 4).ToUpper();
        //            break;
        //    }

        //    Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length.ToString("X2")}h", RtbLogPrefix.Info, rtbLog);
        //    Logger.WriteLogTypeTextToRtb($"Fsys sig found at {lSigPos.ToString("X2")}h.", RtbLogPrefix.Info, rtbLog);
        //    Logger.WriteLogTypeTextToRtb($"Serial:      {strSerial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
        //    Logger.WriteLogTypeTextToRtb($"HWC:         {strHwc}", RtbLogPrefix.Info, rtbLog);
        //    CheckHwcAsync(strHwc);

        //    string strCrcInFile = FWParser.GetFsysRegionCRC32(bytesIn);
        //    string strCrcCalculated = EFIUtils.GetUintCalculateFsysCrc32(bytesIn).ToString("X8");

        //    Logger.WriteLogTypeTextToRtb($"CRC in Fsys: {strCrcInFile}h", RtbLogPrefix.Info, rtbLog);
        //    Logger.WriteLogTypeTextToRtb($"CRC Calc:    {strCrcCalculated}h", RtbLogPrefix.Info, rtbLog);

        //    if (string.Equals(strCrcInFile, strCrcCalculated))
        //    {
        //        Logger.WriteLogTypeTextToRtb($"Fsys CRC32 is valid.", RtbLogPrefix.MET, rtbLog);
        //    }
        //    else
        //    {
        //        Logger.WriteLogTypeTextToRtb($"Fsys CRC32 is invalid, 'Mask CRC32' option selected.", RtbLogPrefix.Warn, rtbLog);
        //        cbxMaskCrc.Checked = true;
        //    }

        //    return true;
        //}
        #endregion

        private void cmdClear_Click(object sender, EventArgs e)
        {
            InitLogBox();
        }

    }
}