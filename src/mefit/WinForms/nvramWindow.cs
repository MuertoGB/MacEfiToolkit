// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// nvramWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class nvramWindow : METForm
    {
        #region Contructor
        public nvramWindow()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();
        }

        private void WireEventHandlers() =>
            KeyDown += nvramWindow_KeyDown;
        #endregion

        #region Window Events
        private void nvramWindow_KeyDown(object sender, KeyEventArgs e)
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
            EFIROM.bResetVss = cbxResetVss.Checked;
            EFIROM.bResetSvs = cbxResetSvs.Checked;

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region CheckBox Events
        private void cbxResetVss_CheckedChanged(object sender, EventArgs e) =>
            SetButtonEnable();

        private void cbxResetSvs_CheckedChanged(object sender, EventArgs e) =>
            SetButtonEnable();

        private void SetButtonEnable()
        {
            if (!cbxResetSvs.Checked && !cbxResetVss.Checked)
            {
                cmdOkay.Enabled = false;
                return;
            }

            cmdOkay.Enabled = true;
        }
        #endregion
    }
}