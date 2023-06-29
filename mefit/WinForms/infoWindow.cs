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

            lblBiosId.Text = FWBase.ROMInfoSectionData.BiosId ?? "N/A";
            lblModel.Text = FWBase.ROMInfoSectionData.Model != null
                ? $"{FWBase.ROMInfoSectionData.Model} ({EFIUtils.ConvertEfiModelCode(FWBase.ROMInfoSectionData.Model)})"
                : "N/A";
            lblEfiVersion.Text = FWBase.ROMInfoSectionData.EfiVersion ?? "N/A";
            lblBuiltBy.Text = FWBase.ROMInfoSectionData.BuiltBy ?? "N/A";
            lblDateStamp.Text = FWBase.ROMInfoSectionData.DateStamp ?? "N/A";
            lblRevision.Text = FWBase.ROMInfoSectionData.Revision ?? "N/A";
            lblBootRom.Text = FWBase.ROMInfoSectionData.RomVersion ?? "N/A";
            lblBuildcaveId.Text = FWBase.ROMInfoSectionData.BuildcaveId ?? "N/A";
            lblBuildType.Text = FWBase.ROMInfoSectionData.BuildType ?? "N/A";
            lblCompiler.Text = FWBase.ROMInfoSectionData.Compiler ?? "N/A";

            lblSectionData.Text = $"Offset: 0x{FWBase.ROMInfoSectionData.SectionOffset:X2}h | Size 0x{FWBase.ROMInfoSectionData.SectionBytes.Length:X2}h" ?? string.Empty;

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