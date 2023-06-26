// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// aboutWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public aboutWindow()
        {
            InitializeComponent();

            Load += new EventHandler(aboutWindow_Load);
            lblTitle.MouseMove += new MouseEventHandler(aboutWindow_MouseMove);
            KeyDown += new KeyEventHandler(aboutWindow_KeyDown);

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void aboutWindow_Load(object sender, EventArgs e)
        {
            lblBuild.Text = $"{Application.ProductVersion}-{METVersion.Build}, {METVersion.Channel}";
            FormatLinks();
        }
        #endregion

        #region Mouse Events
        private void aboutWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region KeyDown Events
        private void aboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region LinkLabel Events
        private void FormatLinks()
        {
            lnkUrls.Links.Clear();
            lnkUrls.Links.Add(0, 10, "mailto:muertogb@proton.me");
            lnkUrls.Links.Add(13, 11, "https://github.com/MuertoGB/MacEfiToolkit");
            lnkUrls.Links.Add(27, 6, "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ");
        }
        private void lnkUrls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
        #endregion

    }
}