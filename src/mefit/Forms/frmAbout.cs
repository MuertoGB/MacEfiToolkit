// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Forms
// frmAbout.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmAbout : FormEx
    {
        #region Constructor
        public frmAbout()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(this, lblTitle);

            // Set button properties.
            SetButtonGlyphAndText();
        }

        private void WireEventHandlers()
        {
            Load += frmAbout_Load;
            KeyDown += frmAbout_KeyDown;
        }
        #endregion

        #region Window Events
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblBuild.Text =
                $"Mac EFI Toolkit v{Application.ProductVersion} by Muerto{Environment.NewLine}" +
                $"Build {ApplicationVersions.CURRENT_BUILD} ({ApplicationVersions.CURRENT_CHANNEL}){Environment.NewLine}" +
                $"LZMA SDK {ApplicationVersions.LZMA_SDK_VERSION}";
        }
        #endregion

        #region KeyDown Events
        private void frmAbout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) => Close();
        #endregion

        #region LinkLabel Events
        private void lnkPaypal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(ApplicationUrls.PaypalDonate);
        #endregion

        #region UI Events
        private void SetButtonGlyphAndText()
        {
            cmdClose.Font = Program.FontSegMdl2Regular10;
            cmdClose.Text = Program.MDL2_EXIT_CROSS;
        }
        #endregion
    }
}