// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmTerms.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmTerms : FormEx
    {
        #region Constructor
        public frmTerms()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Set button properties.
            SetButtonGlyphAndText();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);
        }
        #endregion

        #region Window Events
        private void frmTerms_Load(object sender, EventArgs e)
            => tbxTermsText.Text = Properties.Resources.editorterms;
        #endregion

        #region Button Events
        private void cmdDecline_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Settings.SetBool(Settings.BooleanKey.AcceptedEditingTerms, true);

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
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

        #region User Interface
        private void SetButtonGlyphAndText()
        {
            cmdClose.Font = Program.FluentRegular14;
            cmdClose.Text = ApplicationChars.FLUENT_DISMISS;
        }
        #endregion

        #region Private Events
        private void WireEventHandlers()
        {
            Load += frmTerms_Load;
            KeyDown += frmTerms_KeyDown;
        }
        #endregion
    }
}