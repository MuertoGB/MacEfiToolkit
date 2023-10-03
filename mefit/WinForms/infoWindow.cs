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
                AppleEFI.AppleRomInfoSectionData.Revision.Replace("&", "&&")
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
        private void cmdExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"AppleRomSectionInformation_{AppleEFI.FsysStoreData.Serial}",
                OverwritePrompt = true,
                InitialDirectory = METPath.CurrentDirectory
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Bios ID:       {(AppleEFI.AppleRomInfoSectionData.BiosId ?? "N/A")}");
                builder.AppendLine($"Model:         {(AppleEFI.AppleRomInfoSectionData.Model ?? "N/A")}");
                builder.AppendLine($"EFI Version:   {(AppleEFI.AppleRomInfoSectionData.EfiVersion ?? "N/A")}");
                builder.AppendLine($"Built By:      {(AppleEFI.AppleRomInfoSectionData.BuiltBy ?? "N/A")}");
                builder.AppendLine($"Date Stamp:    {(AppleEFI.AppleRomInfoSectionData.DateStamp ?? "N/A")}");
                builder.AppendLine($"Revision:      {(AppleEFI.AppleRomInfoSectionData.Revision ?? "N/A")}");
                builder.AppendLine($"Boot ROM:      {(AppleEFI.AppleRomInfoSectionData.RomVersion ?? "N/A")}");
                builder.AppendLine($"Buildcave ID:  {(AppleEFI.AppleRomInfoSectionData.BuildcaveId ?? "N/A")}");
                builder.AppendLine($"Built Type:    {(AppleEFI.AppleRomInfoSectionData.BuildType ?? "N/A")}");
                builder.AppendLine($"Compiler:      {(AppleEFI.AppleRomInfoSectionData.Compiler ?? "N/A")}");

                File.WriteAllText(dialog.FileName, builder.ToString());

                if (!File.Exists(dialog.FileName))
                {
                    METMessageBox.Show(
                        this,
                        "Error",
                        "Fsys export failed.",
                        METMessageType.Error,
                        METMessageButtons.Okay);

                    return;
                }

                InterfaceUtils.ShowExplorerNavigationPrompt(
                 this,
                 "Data exported successfully.",
                 dialog.FileName);
            }
        }

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