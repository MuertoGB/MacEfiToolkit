// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmRomInfo.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware.EFIROM;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utilities;
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

            // Set button propeties.
            SetButtonProperties();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);
        }
        #endregion

        #region Window Events
        private void frmRominfo_Load(object sender, EventArgs e)
            => UpdateUIControls();
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
                Filter = AppStrings.FILTER_TEXT,
                FileName = $"{AppStrings.ROM_SECTION_INFO}_{_efirom.FirmwareInfo.FileName}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Bios ID:       {_efirom.AppleRomInfoSectionData.BiosId ?? AppStrings.NA}");
                builder.AppendLine($"Model:         {_efirom.AppleRomInfoSectionData.Model ?? AppStrings.NA}");
                builder.AppendLine($"EFI Version:   {_efirom.AppleRomInfoSectionData.EfiVersion ?? AppStrings.NA}");
                builder.AppendLine($"Built By:      {_efirom.AppleRomInfoSectionData.BuiltBy ?? AppStrings.NA}");
                builder.AppendLine($"Date Stamp:    {_efirom.AppleRomInfoSectionData.DateStamp ?? AppStrings.NA}");
                builder.AppendLine($"Revision:      {_efirom.AppleRomInfoSectionData.Revision ?? AppStrings.NA}");
                builder.AppendLine($"Boot ROM:      {_efirom.AppleRomInfoSectionData.RomVersion ?? AppStrings.NA}");
                builder.AppendLine($"Buildcave ID:  {_efirom.AppleRomInfoSectionData.BuildcaveId ?? AppStrings.NA}");
                builder.AppendLine($"Built Type:    {_efirom.AppleRomInfoSectionData.BuildType ?? AppStrings.NA}");
                builder.AppendLine($"Compiler:      {_efirom.AppleRomInfoSectionData.Compiler ?? AppStrings.NA}");

                File.WriteAllText(dialog.FileName, builder.ToString());

                builder.Clear();

                if (!File.Exists(dialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DialogStrings.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

                    return;
                }

                UITools.ShowExplorerFileHighlightPrompt(this, dialog.FileName);
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e) => Close();
        #endregion

        #region User Interface
        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FluentRegular14;
            cmdClose.Text = ApplicationChars.FLUENT_DISMISS;
        }

        private void UpdateUIControls()
        {
            lblBiosId.Text = _efirom.AppleRomInfoSectionData.BiosId ?? AppStrings.NA;
            lblModel.Text = _efirom.AppleRomInfoSectionData.Model != null
                ? $"{_efirom.AppleRomInfoSectionData.Model} ({MacUtils.ConvertEfiModelCode(_efirom.AppleRomInfoSectionData.Model)})"
                : AppStrings.NA;
            lblEfiVersion.Text = _efirom.AppleRomInfoSectionData.EfiVersion ?? AppStrings.NA;
            lblBuiltBy.Text = _efirom.AppleRomInfoSectionData.BuiltBy ?? AppStrings.NA;
            lblDateStamp.Text = _efirom.AppleRomInfoSectionData.DateStamp ?? AppStrings.NA;
            lblRevision.Text = _efirom.AppleRomInfoSectionData.Revision ?? AppStrings.NA;
            lblBootRom.Text = _efirom.AppleRomInfoSectionData.RomVersion ?? AppStrings.NA;
            lblBuildcaveId.Text = _efirom.AppleRomInfoSectionData.BuildcaveId ?? AppStrings.NA;
            lblBuildType.Text = _efirom.AppleRomInfoSectionData.BuildType ?? AppStrings.NA;
            lblCompiler.Text = _efirom.AppleRomInfoSectionData.Compiler ?? AppStrings.NA;
            lblSectionData.Text = $"{AppStrings.BASE.ToUpper()} {_efirom.AppleRomInfoSectionData.SectionBase:X}h" ?? AppStrings.NA;
            lblSectionData.Text += $", {AppStrings.SIZE.ToUpper()} {_efirom.AppleRomInfoSectionData.SectionBytes.Length:X}h" ?? AppStrings.NA;

            UITools.ApplyNestedPanelLabelForeColor(tlpInfo, ApplicationColours.DisabledText);
        }
        #endregion

        #region Private Events
        private void WireEventHandlers()
        {
            Load += frmRominfo_Load;
            KeyDown += frmRominfo_KeyDown;
        }
        #endregion
    }
}