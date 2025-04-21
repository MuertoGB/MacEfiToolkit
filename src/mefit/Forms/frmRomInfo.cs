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
        #region Private Members
        private readonly EFIROM _efirom;
        #endregion

        #region Constructor
        public frmRominfo(EFIROM efiromInstance)
        {
            InitializeComponent();

            _efirom = efiromInstance;

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
            lblBiosId.Text = _efirom.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA;

            lblModel.Text = _efirom.AppleRomInfoSectionData.Model != null ?
                $"{_efirom.AppleRomInfoSectionData.Model} ({MacTools.ConvertEfiModelCode(_efirom.AppleRomInfoSectionData.Model)})" : APPSTRINGS.NA;

            lblEfiVersion.Text = _efirom.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA;

            lblBuiltBy.Text = _efirom.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA;

            lblDateStamp.Text = _efirom.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA;

            lblRevision.Text = _efirom.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA;

            lblBootRom.Text = _efirom.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA;

            lblBuildcaveId.Text = _efirom.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA;

            lblBuildType.Text = _efirom.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA;

            lblCompiler.Text = _efirom.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA;

            lblSectionData.Text = $"{APPSTRINGS.BASE.ToUpper()} {_efirom.AppleRomInfoSectionData.SectionBase:X}h" ?? APPSTRINGS.NA;
            lblSectionData.Text += $", {APPSTRINGS.SIZE.ToUpper()} {_efirom.AppleRomInfoSectionData.SectionBytes.Length:X}h" ?? APPSTRINGS.NA;

            UITools.ApplyNestedPanelLabelForeColor(tlpInfo, ApplicationColours.DisabledText);
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
                FileName = $"{APPSTRINGS.ROM_SECTION_INFO}_{_efirom.FirmwareInfo.FileName}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Bios ID:       {_efirom.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA}");
                builder.AppendLine($"Model:         {_efirom.AppleRomInfoSectionData.Model ?? APPSTRINGS.NA}");
                builder.AppendLine($"EFI Version:   {_efirom.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA}");
                builder.AppendLine($"Built By:      {_efirom.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA}");
                builder.AppendLine($"Date Stamp:    {_efirom.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA}");
                builder.AppendLine($"Revision:      {_efirom.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA}");
                builder.AppendLine($"Boot ROM:      {_efirom.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA}");
                builder.AppendLine($"Buildcave ID:  {_efirom.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA}");
                builder.AppendLine($"Built Type:    {_efirom.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA}");
                builder.AppendLine($"Compiler:      {_efirom.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA}");

                File.WriteAllText(dialog.FileName, builder.ToString());

                builder.Clear();

                if (!File.Exists(dialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

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
            cmdClose.Font = Program.SegoeFluentRegular12;
            cmdClose.Text = ApplicationChars.FLUENT_MULTIPLY;
        }
        #endregion
    }
}