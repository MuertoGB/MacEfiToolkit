// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// infoWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
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
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public infoWindow()
        {
            InitializeComponent();

            lblTitle.MouseMove += infoWindow_MouseMove;
            KeyDown += infoWindow_KeyDown;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;

            lblBiosId.Text = FWBase.ROMInfoData.BiosId ?? "N/A";
            lblModel.Text = FWBase.ROMInfoData.Model ?? "N/A";
            lblEfiVersion.Text = FWBase.ROMInfoData.EfiVersion ?? "N/A";
            lblBuiltBy.Text = FWBase.ROMInfoData.BuiltBy ?? "N/A";
            lblDateStamp.Text = FWBase.ROMInfoData.DateStamp ?? "N/A";
            lblRevision.Text = FWBase.ROMInfoData.Revision ?? "N/A";
            lblBootRom.Text = FWBase.ROMInfoData.RomVersion ?? "N/A";
            lblBuildcaveId.Text = FWBase.ROMInfoData.BuildcaveId ?? "N/A";
            lblBuildType.Text = FWBase.ROMInfoData.BuildType ?? "N/A";
            lblCompiler.Text = FWBase.ROMInfoData.Compiler ?? "N/A";

            lblSectionData.Text = $"Offset: 0x{FWBase.ROMInfoData.SectionOffset:X2}h | Size 0x{FWBase.ROMInfoData.SectionBytes.Length:X2}h" ?? string.Empty;

            foreach (Label label in tlpMain.Controls)
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
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region KeyDown Events
        private void infoWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        #endregion

    }
}