// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSerialSelect.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFIROM;
using Mac_EFI_Toolkit.Firmware.SOCROM;
using Mac_EFI_Toolkit.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmSerialSelect : FormEx
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
            tbxSerial.Select();
        }

        private void SetSerialLength()
        {
            if (Tag is SerialSenderTag.EFIROMWindow)
            {
                tbxSerial.MaxLength = EFIROM.FsysStoreData.Serial.Length;
                return;
            }
            else if (Tag is SerialSenderTag.SOCROMWindow)
            {
                tbxSerial.MaxLength = SOCROM.SERIAL_LENGTH;
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
            if (Tag is SerialSenderTag.EFIROMWindow)
            {
                EFIROM.NewSerial = tbxSerial.Text;
            }
            else if (Tag is SerialSenderTag.SOCROMWindow)
            {
                SOCROM.NewSerial = tbxSerial.Text;
            }

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region TextBox Events
        private void tbxSerial_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int nCharCount = textBox.Text.Length;

            // Update the validity label each time the text changes
            UpdateValidityLabel();

            if (Settings.ReadBool(SettingsBoolType.DisableSerialValidation))
            {
                if (nCharCount == textBox.MaxLength)
                {
                    cmdOkay.Enabled = true;
                    return;
                }
            }

            // Check if the character length matches the expected serial length
            if (nCharCount == textBox.MaxLength)
            {
                if (Serial.IsValid(textBox.Text))
                {
                    UpdateTextBoxColour(textBox, Colours.Okay);
                    cmdOkay.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColour(textBox, Colours.Error);
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
            lblValidity.Text = $"{tbxSerial.Text.Length}/{tbxSerial.MaxLength}";
        }
        #endregion
    }
}