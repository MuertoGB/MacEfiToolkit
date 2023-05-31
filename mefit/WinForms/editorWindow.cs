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
        private bool _bIsNewFsysValid = false;
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

            lblSvsChevRight.Font = Program.FONT_MDL2_REG_9;
            lblSvsChevRight.Text = _strChevronRight;

            lblVssChevRight.Font = Program.FONT_MDL2_REG_9;
            lblVssChevRight.Text = _strChevronRight;

            lblSvsChevRight.Visible = false;
            lblVssChevRight.Visible = false;

            tbxSerialNumber.MaxLength = FWParser.strSerialNumber.Length;

            Logger.WriteLogTypeTextToRtb($"{DateTime.Now}", RtbLogPrefix.MET, rtbLog);
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

        private void cbxReplaceFsysRgn_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            cmdFsysPath.Enabled = cb.Checked;
            tlpSerialA.Enabled = !cb.Checked;
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            tlpSerialB.Enabled = cb.Checked;
            tlpSerialC.Enabled = cb.Checked;
            tlpFsys.Enabled = !cb.Checked;

            if (!cb.Checked)
            {
                cbxMaskFsysCrc.Checked = false;
                cbxOverwriteHwc.Checked = false;
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

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = Program.strRememberPath,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Logger.WriteLogTypeTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.Info, rtbLog);
                    _byteNewFsysRegion = File.ReadAllBytes(dialog.FileName);
                    _bIsNewFsysValid = ValidateNewFsysRegion(_byteNewFsysRegion);

                }
            }
        }

        private bool ValidateNewFsysRegion(byte[] bytesIn)
        {

            Logger.WriteLogTypeTextToRtb($"Validating donor Fsys region...", RtbLogPrefix.MET, rtbLog);

            // Check length of bytes is 800h
            if (bytesIn.Length != FWParser.intFsysRegionExactSize)
            {
                Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length.ToString("X2")}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                cbxReplaceFsysRgn.Checked = false;
                return false;
            }

            // Look for Fsys signature at pos 00h.
            long lSigPos = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);
            if (lSigPos == -1)
            {
                Logger.WriteLogTypeTextToRtb($"Fsys signature not found", RtbLogPrefix.Error, rtbLog);
                cbxReplaceFsysRgn.Checked = false;
                return false;
            }
            else
            {
                if (lSigPos != 0)
                {
                    Logger.WriteLogTypeTextToRtb($"Fsys signature misaligned: {lSigPos.ToString("X2")}h", RtbLogPrefix.Error, rtbLog);
                    cbxReplaceFsysRgn.Checked = false;
                    return false;
                }
            }

            string strHwc = string.Empty;
            string strSerial = FWParser.GetFsysRegionSerialNumber(bytesIn);
            int lenSerial = strSerial.Length;

            switch (lenSerial)
            {
                case 11:
                    strHwc = strSerial.Substring(strSerial.Length - 3);
                    break;
                case 12:
                    strHwc = strSerial.Substring(strSerial.Length - 4);
                    break;
            }

            Logger.WriteLogTypeTextToRtb($"Filesize: {bytesIn.Length.ToString("X2")}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"Fsys sig found: {lSigPos.ToString("X2")}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"  Serial: {strSerial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTypeTextToRtb($"  HWC: {strHwc}", RtbLogPrefix.Info, rtbLog);

            if (strHwc != null)
            {
                CheckHwcAsync(strHwc);
                if (strHwc != FWParser.strHwc)
                {
                    Logger.WriteLogTypeTextToRtb($"Fsys config does not match the original binary, this may cause software issues.", RtbLogPrefix.Warn, rtbLog);
                }
                else
                {
                    Logger.WriteLogTypeTextToRtb($"Fsys config matches original", RtbLogPrefix.Info, rtbLog);
                }
            }

            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils.GetStringConfigCodeAsync(strHwc);
            Logger.WriteLogTypeTextToRtb($"  Config: {configCode}", RtbLogPrefix.Info, rtbLog);
        }
    }
}