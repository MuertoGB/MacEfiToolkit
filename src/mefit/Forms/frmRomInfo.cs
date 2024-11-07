// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmRomInfo.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmRominfo : METForm
    {
        #region Constructor
        public frmRominfo()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);

            // Set button propeties.
            SetButtonProperties();
        }

        private void WireEventHandlers()
        {
            Load += frmRominfo_Load;
            KeyDown += frmRominfo_KeyDown;
        }
        #endregion

        #region Window Events
        private void frmRominfo_Load(object sender, EventArgs e) => LoadRomInformation();

        private void LoadRomInformation()
        {
            lblBiosId.Text = EFIROM.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA;

            lblModel.Text = EFIROM.AppleRomInfoSectionData.Model != null ?
                $"{EFIROM.AppleRomInfoSectionData.Model} ({MacTools.ConvertEfiModelCode(EFIROM.AppleRomInfoSectionData.Model)})" : APPSTRINGS.NA;

            lblEfiVersion.Text = EFIROM.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA;

            lblBuiltBy.Text = EFIROM.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA;

            lblDateStamp.Text = EFIROM.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA;

            lblRevision.Text = EFIROM.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA;

            lblBootRom.Text = EFIROM.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA;

            lblBuildcaveId.Text = EFIROM.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA;

            lblBuildType.Text = EFIROM.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA;

            lblCompiler.Text = EFIROM.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA;

            lblSectionData.Text = $"{APPSTRINGS.BASE.ToUpper()} {EFIROM.AppleRomInfoSectionData.SectionBase:X}h" ?? APPSTRINGS.NA;
            lblSectionData.Text += $", {APPSTRINGS.SIZE.ToUpper()} {EFIROM.AppleRomInfoSectionData.SectionBytes.Length:X}h" ?? APPSTRINGS.NA;

            UITools.ApplyNestedPanelLabelForeColor(tlpInfo, AppColours.DISABLED_TEXT);
        }
        #endregion

        #region KeyDown Events
        private void frmRominfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{APPSTRINGS.ROM_SECTION_INFO}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = METPath.WORKING_DIR
            })
            {
                // Action was cancelled
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Bios ID:       {EFIROM.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA}");
                builder.AppendLine($"Model:         {EFIROM.AppleRomInfoSectionData.Model ?? APPSTRINGS.NA}");
                builder.AppendLine($"EFI Version:   {EFIROM.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA}");
                builder.AppendLine($"Built By:      {EFIROM.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA}");
                builder.AppendLine($"Date Stamp:    {EFIROM.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA}");
                builder.AppendLine($"Revision:      {EFIROM.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA}");
                builder.AppendLine($"Boot ROM:      {EFIROM.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA}");
                builder.AppendLine($"Buildcave ID:  {EFIROM.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA}");
                builder.AppendLine($"Built Type:    {EFIROM.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA}");
                builder.AppendLine($"Compiler:      {EFIROM.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA}");

                File.WriteAllText(dialog.FileName, builder.ToString());

                builder.Clear();

                if (!File.Exists(dialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPromptType.Error,
                        METPromptButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e) => Close();
        #endregion

        #region UI Events
        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }
        #endregion
    }
}