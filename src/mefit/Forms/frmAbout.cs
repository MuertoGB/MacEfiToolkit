// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Forms
// frmAbout.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmAbout : METForm
    {
        #region Constructor
        public frmAbout()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Set button properties.
            SetButtonProperties();
        }

        private void WireEventHandlers()
        {
            Load += aboutWindow_Load;
            KeyDown += aboutWindow_KeyDown;
        }
        #endregion

        #region Window Events
        private void aboutWindow_Load(object sender, EventArgs e)
        {
            lblBuild.Text =
                $"{APPSTRINGS.VERSION.ToUpper()} " +
                $"{Application.ProductVersion}.{METVersion.APP_BUILD}";

            lblChannel.Text =
                $"{APPSTRINGS.LZMA_SDK} " +
                $"{METVersion.LZMA_SDK}";
        }
        #endregion

        #region KeyDown Events
        private void aboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_10;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }
        #endregion
    }
}