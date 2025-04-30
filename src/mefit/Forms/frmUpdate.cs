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
        private readonly Updater _updater;

        #region Constructor
        public frmUpdate(Updater updater)
        {
            InitializeComponent();

            _updater = updater;

            WireEventHandlers();

            UITools.EnableFormDrag(this, lblWindowTitle);
        }
        #endregion

        #region Window Events
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            lblNew.Text = _updater.NewVersion;
            lblCurrent.Text = Application.ProductVersion;
            lblPriority.Text = _updater.Priority;
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
        private void cmdCancel_Click(object sender, System.EventArgs e)
            => DialogResult = DialogResult.Cancel;

        private async void cmdUpdate_Click(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            await _updater.DownloadAndInstallUpdateAsync(lblWindowTitle);

            ToggleControlEnable(true);
        }
        #endregion

        #region User Interface
        private void ToggleControlEnable(bool enable)
        {
            cmdCancel.Enabled = enable;
            cmdDownload.Enabled = enable;
        }
        #endregion

        #region Private Events
        private void WireEventHandlers()
        {
            Load += frmUpdate_Load;
            KeyDown += frmUpdate_KeyDown;
        }
        #endregion
    }
}