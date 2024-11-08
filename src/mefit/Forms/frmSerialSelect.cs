// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSerialSelect.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Firmware.SOCROM;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmSerialSelect : METForm
    {
        #region Constructor
        public frmSerialSelect()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();
        }

        private void WireEventHandlers()
        {
            Load += frmSerialSelect_Load;
            KeyDown += frmSerialSelect_KeyDown;
        }
        #endregion

        #region Window Events
        private void frmSerialSelect_Load(object sender, EventArgs e)
        {
            SetSerialLength();
            UpdateValidityLabel();
            tbSsn.Select();
        }

        private void SetSerialLength()
        {
            if (Tag is SerialSenderTag.EFIROM)
            {
                tbSsn.MaxLength = EFIROM.FsysStoreData.Serial.Length;
                return;
            }

            if (Tag is SerialSenderTag.SOCROM)
            {
                tbSsn.MaxLength = SOCROM.SERIAL_LEN;
                return;
            }
        }
        #endregion

        #region KeyDown Events
        private void frmSerialSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void cmdOkay_Click(object sender, EventArgs e)
        {
            if (Tag is SerialSenderTag.EFIROM)
            {
                EFIROM.NewSerial = tbSsn.Text;
            }
            else if (Tag is SerialSenderTag.SOCROM)
            {
                SOCROM.NewSerial = tbSsn.Text;
            }

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region TextBox Events
        private void tbSsn_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int charLength = textBox.Text.Length;

            // Update the validity label each time the text changes
            UpdateValidityLabel();

            // Check if the character length matches the expected serial length
            if (charLength == tbSsn.MaxLength)
            {
                if (Serial.IsValid(textBox.Text))
                {
                    UpdateTextBoxColour(textBox, AppColours.COMPLETE);
                    cmdOkay.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColour(textBox, AppColours.ERROR);
                    lblValidity.Text += $" - {APPSTRINGS.INVALID}";
                    cmdOkay.Enabled = false;
                }
            }
            else
            {
                UpdateTextBoxColour(textBox, Color.FromArgb(235, 235, 235));
                cmdOkay.Enabled = false;
            }
        }
        #endregion

        #region UI Events
        private void UpdateTextBoxColour(TextBox control, Color color) => control.ForeColor = color;

        private void UpdateValidityLabel()
        {
            lblValidity.Text = $"{tbSsn.Text.Length}/{tbSsn.MaxLength}";
        }
        #endregion
    }
}