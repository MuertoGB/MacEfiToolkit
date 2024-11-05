// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmTerms.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmTerms : METForm
    {
        #region Constructor
        public frmTerms()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(
                this,
                tlpTitle,
                lblTitle);

            // Set button properties.
            SetButtonProperties();
        }

        private void WireEventHandlers()
        {
            Load += frmTerms_Load;
            KeyDown += frmTerms_KeyDown;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
        }
        #endregion

        #region Window Events
        private void frmTerms_Load(object sender, EventArgs e) =>
            tbxTermsText.Text = Properties.Resources.editorterms;
        #endregion

        #region Button Events
        private void cmdDecline_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Settings.SetBool(
                SettingsBoolType.AcceptedEditingTerms,
                true);

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }
        #endregion

        #region KeyDown Events
        private void frmTerms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion
    }
}