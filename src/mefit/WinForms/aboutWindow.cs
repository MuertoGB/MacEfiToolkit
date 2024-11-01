// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// aboutWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class aboutWindow : Form
    {

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public aboutWindow()
        {
            InitializeComponent();

            Load += aboutWindow_Load;
            KeyDown += aboutWindow_KeyDown;

            this.Click += CloseOnClick;
            RegisterControlClick(this);
        }

        private void RegisterControlClick(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                childControl.Click += CloseOnClick;

                if (childControl.HasChildren)
                    RegisterControlClick(childControl);
            }
        }

        private void CloseOnClick(object sender, EventArgs e) => Close();
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

    }
}