﻿// Mac EFI Toolkit
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

            // Set button properties.
            SetButtonGlyphAndText();

            // Enable drag.
            WindowManager.EnableFormDrag(this, lblTitle);
        }
        #endregion

        #region Window Events
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblBuild.Text =
                $"Mac EFI Toolkit v{Application.ProductVersion} by Muerto{Environment.NewLine}" +
                $"Build: {ApplicationVersions.BUILD} ({ApplicationVersions.CHANNEL}){Environment.NewLine}" +
                $"LZMA SDK: v{ApplicationVersions.LZMA_SDK_VERSION}";
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
        private void cmdClose_Click(object sender, EventArgs e)
            => Close();
        #endregion

        #region LinkLabel Events
        private void lnkPaypal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => Process.Start(ApplicationUrls.PaypalDonate);
        #endregion

        #region User Interface
        private void SetButtonGlyphAndText()
        {
            cmdClose.Font = Program.FluentRegular12;
            cmdClose.Text = ApplicationChars.FLUENT_DISMISS;
        }
        #endregion

        #region Private Events
        private void WireEventHandlers()
        {
            Load += frmAbout_Load;
            KeyDown += frmAbout_KeyDown;
        }
        #endregion
    }
}