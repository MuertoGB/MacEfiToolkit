// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmRomInfo.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware.EFIROM;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmRominfo : FormEx
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

            UITools.ApplyNestedPanelLabelForeColor(tlpInfo, Colours.ClrDisabledText);
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
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_TEXT,
                FileName = $"{APPSTRINGS.ROM_SECTION_INFO}_{EFIROM.FileInfoData.FileName}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder sbRomInfo = new StringBuilder();

                sbRomInfo.AppendLine($"Bios ID:       {EFIROM.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Model:         {EFIROM.AppleRomInfoSectionData.Model ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"EFI Version:   {EFIROM.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Built By:      {EFIROM.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Date Stamp:    {EFIROM.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Revision:      {EFIROM.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Boot ROM:      {EFIROM.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Buildcave ID:  {EFIROM.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Built Type:    {EFIROM.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Compiler:      {EFIROM.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA}");

                File.WriteAllText(saveFileDialog.FileName, sbRomInfo.ToString());

                sbRomInfo.Clear();

                if (!File.Exists(saveFileDialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPromptType.Error,
                        METPromptButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, saveFileDialog.FileName);
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e) => Close();
        #endregion

        #region UI Events
        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FontSegMdl2Regular12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }
        #endregion
    }
}