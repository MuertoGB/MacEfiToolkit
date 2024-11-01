// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// ssnWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class ssnWindow : Form
    {
        #region Constructor
        public ssnWindow()
        {
            InitializeComponent();

            Load += ssnWindow_Load;
            KeyDown += ssnWindow_KeyDown;
        }
        #endregion

        #region Window Events
        private void ssnWindow_Load(object sender, EventArgs e)
        {
            tbSsn.MaxLength = EFIROM.FsysStoreData.Serial.Length;
            tbSsn.Select();
        }
        #endregion

        #region KeyDown Events
        private void ssnWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.Cancel;

        private void cmdOkay_Click(object sender, EventArgs e)
        {
            // Please ensure new SSN is validated
            EFIROM.NewSSN = tbSsn.Text;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region TextBox Events
        private void tbSsn_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int charLength = textBox.Text.Length;

            if (charLength == EFIROM.FsysStoreData.Serial.Length)
            {
                if (MacUtils.IsValidAppleSerial(textBox.Text))
                {
                    UpdateTextBoxColour(textBox, AppColours.COMPLETE);
                    cmdOkay.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColour(textBox, AppColours.ERROR);
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
        private void UpdateTextBoxColour(TextBox control, Color color) =>
            control.ForeColor = color;
        #endregion
    }
}