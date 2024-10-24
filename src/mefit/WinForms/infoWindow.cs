// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// infoWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
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
            lblBiosId.Text = EFIROM.AppleRomInfoSectionData.BiosId
                ?? "N/A";
            lblModel.Text = EFIROM.AppleRomInfoSectionData.Model != null
                ? $"{EFIROM.AppleRomInfoSectionData.Model} " +
                $"({MacUtils.ConvertEfiModelCode(EFIROM.AppleRomInfoSectionData.Model)})"
                : "N/A";
            lblEfiVersion.Text =
                EFIROM.AppleRomInfoSectionData.EfiVersion
                ?? "N/A";
            lblBuiltBy.Text =
                EFIROM.AppleRomInfoSectionData.BuiltBy
                ?? "N/A";
            lblDateStamp.Text =
                EFIROM.AppleRomInfoSectionData.DateStamp
                ?? "N/A";
            lblRevision.Text =
                EFIROM.AppleRomInfoSectionData.Revision
                ?? "N/A";
            lblBootRom.Text =
                EFIROM.AppleRomInfoSectionData.RomVersion
                ?? "N/A";
            lblBuildcaveId.Text =
                EFIROM.AppleRomInfoSectionData.BuildcaveId
                ?? "N/A";
            lblBuildType.Text =
                EFIROM.AppleRomInfoSectionData.BuildType
                ?? "N/A";
            lblCompiler.Text =
                EFIROM.AppleRomInfoSectionData.Compiler
                ?? "N/A";
            lblSectionData.Text =
                $"BASE 0x{EFIROM.AppleRomInfoSectionData.SectionBase:X}h, " +
                $"SIZE {EFIROM.AppleRomInfoSectionData.SectionBytes.Length:X}h"
                ?? string.Empty;

            foreach (Label label in tlpInfo.Controls)
                if (label.Text == "N/A")
                    label.ForeColor = AppColours.DISABLED_TEXT;
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
        private void cmdExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"AppleRomSectionInformation_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = METPath.CurrentDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Bios ID:       {EFIROM.AppleRomInfoSectionData.BiosId ?? "N/A"}");
                builder.AppendLine($"Model:         {EFIROM.AppleRomInfoSectionData.Model ?? "N/A"}");
                builder.AppendLine($"EFI Version:   {EFIROM.AppleRomInfoSectionData.EfiVersion ?? "N/A"}");
                builder.AppendLine($"Built By:      {EFIROM.AppleRomInfoSectionData.BuiltBy ?? "N/A"}");
                builder.AppendLine($"Date Stamp:    {EFIROM.AppleRomInfoSectionData.DateStamp ?? "N/A"}");
                builder.AppendLine($"Revision:      {EFIROM.AppleRomInfoSectionData.Revision ?? "N/A"}");
                builder.AppendLine($"Boot ROM:      {EFIROM.AppleRomInfoSectionData.RomVersion ?? "N/A"}");
                builder.AppendLine($"Buildcave ID:  {EFIROM.AppleRomInfoSectionData.BuildcaveId ?? "N/A"}");
                builder.AppendLine($"Built Type:    {EFIROM.AppleRomInfoSectionData.BuildType ?? "N/A"}");
                builder.AppendLine($"Compiler:      {EFIROM.AppleRomInfoSectionData.Compiler ?? "N/A"}");

                File.WriteAllText(
                    dialog.FileName,
                    builder.ToString());

                if (!File.Exists(dialog.FileName))
                {
                    METMessageBox.Show(
                        this,
                        "Data export failed.",
                        METMessageBoxType.Error,
                        METMessageBoxButtons.Okay);

                    return;
                }

                UITools.ShowExplorerNavigationPrompt(
                 this,
                 "Data exported successfully.",
                 dialog.FileName);
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e) =>
            Close();
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