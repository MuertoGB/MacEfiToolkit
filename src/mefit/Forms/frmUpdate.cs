// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmUpdate.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmUpdate : FormEx
    {
        #region Constructor
        public frmUpdate()
        {
            InitializeComponent();

            WireEventHandlers();

            UITools.EnableFormDrag(this, lblWindowTitle);
        }

        private void WireEventHandlers()
        {
            Load += frmUpdate_Load;
            KeyDown += frmUpdate_KeyDown;
        }
        #endregion

        #region Window Events
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            lblNew.Text = Updater.NewVersion;
            lblCurrent.Text = Application.ProductVersion;
            lblPriority.Text = Updater.Priority;
        }
        #endregion

        #region KeyDown Events
        private void frmUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, System.EventArgs e) => DialogResult = DialogResult.Cancel;

        private async void cmdUpdate_Click(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            await Updater.DownloadAsync(lblStatus);

            ToggleControlEnable(true);
        }
        #endregion

        #region Private
        private void ToggleControlEnable(bool enable)
        {
            cmdCancel.Enabled = enable;
            cmdDownload.Enabled = enable;
        }
        #endregion
    }
}