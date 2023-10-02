// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// infoWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class infoWindow : Form
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
        public infoWindow()
        {
            InitializeComponent();

            Load += infoWindow_Load;
            KeyDown += infoWindow_KeyDown;

            pbxLogo.MouseMove += infoWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += infoWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void infoWindow_Load(object sender, EventArgs e)
        {
            lblBiosId.Text = AppleEFI.AppleRomInfoSectionData.BiosId
                ?? "N/A";
            lblModel.Text = AppleEFI.AppleRomInfoSectionData.Model != null
                ? $"{AppleEFI.AppleRomInfoSectionData.Model} ({MacUtils.ConvertEfiModelCode(AppleEFI.AppleRomInfoSectionData.Model)})"
                : "N/A";
            lblEfiVersion.Text =
                AppleEFI.AppleRomInfoSectionData.EfiVersion
                ?? "N/A";
            lblBuiltBy.Text =
                AppleEFI.AppleRomInfoSectionData.BuiltBy
                ?? "N/A";
            lblDateStamp.Text =
                AppleEFI.AppleRomInfoSectionData.DateStamp
                ?? "N/A";
            lblRevision.Text =
                AppleEFI.AppleRomInfoSectionData.Revision
                ?? "N/A";
            lblBootRom.Text =
                AppleEFI.AppleRomInfoSectionData.RomVersion
                ?? "N/A";
            lblBuildcaveId.Text =
                AppleEFI.AppleRomInfoSectionData.BuildcaveId
                ?? "N/A";
            lblBuildType.Text =
                AppleEFI.AppleRomInfoSectionData.BuildType
                ?? "N/A";
            lblCompiler.Text =
                AppleEFI.AppleRomInfoSectionData.Compiler
                ?? "N/A";
            lblSectionData.Text =
                $"Base: {AppleEFI.AppleRomInfoSectionData.SectionBase:X2}h, " +
                $"Size: {AppleEFI.AppleRomInfoSectionData.SectionBytes.Length:X2}h"
                ?? string.Empty;

            foreach (Label label in tlpInfo.Controls)
            {
                if (label.Text == "N/A")
                {
                    label.ForeColor = Colours.DISABLED_TEXT;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void infoWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }
        #endregion

        #region KeyDown Events
        private void infoWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            Close();
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