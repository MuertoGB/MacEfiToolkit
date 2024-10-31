using Mac_EFI_Toolkit.Firmware.EFI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class nvramWindow : Form
    {
        public nvramWindow()
        {
            InitializeComponent();

            KeyDown += nvramWindow_KeyDown;
        }

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

        private void OkayButtonState()
        {
            if (!cbxResetSvs.Checked && !cbxResetVss.Checked)
            {
                cmdOkay.Enabled = false;
                return;
            }

            cmdOkay.Enabled = true;
        }

        private void cbxResetVss_CheckedChanged(object sender, EventArgs e)
        {
            OkayButtonState();
        }

        private void cbxResetSvs_CheckedChanged(object sender, EventArgs e)
        {
            OkayButtonState();
        }
    }
}
