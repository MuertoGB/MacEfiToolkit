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

            UITools.ApplyNestedPanelLabelForeColor(tlpInfo, Colours.DisabledText);
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
                FileName = $"{APPSTRINGS.ROM_SECTION_INFO}_{_efirom.FirmwareInfo.FileName}",
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.WorkingDirectory
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder sbRomInfo = new StringBuilder();

                sbRomInfo.AppendLine($"Bios ID:       {_efirom.AppleRomInfoSectionData.BiosId ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Model:         {_efirom.AppleRomInfoSectionData.Model ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"EFI Version:   {_efirom.AppleRomInfoSectionData.EfiVersion ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Built By:      {_efirom.AppleRomInfoSectionData.BuiltBy ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Date Stamp:    {_efirom.AppleRomInfoSectionData.DateStamp ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Revision:      {_efirom.AppleRomInfoSectionData.Revision ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Boot ROM:      {_efirom.AppleRomInfoSectionData.RomVersion ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Buildcave ID:  {_efirom.AppleRomInfoSectionData.BuildcaveId ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Built Type:    {_efirom.AppleRomInfoSectionData.BuildType ?? APPSTRINGS.NA}");
                sbRomInfo.AppendLine($"Compiler:      {_efirom.AppleRomInfoSectionData.Compiler ?? APPSTRINGS.NA}");

                File.WriteAllText(saveFileDialog.FileName, sbRomInfo.ToString());

                sbRomInfo.Clear();

                if (!File.Exists(saveFileDialog.FileName))
                {
                    METPrompt.Show(
                        this,
                        DIALOGSTRINGS.DATA_EXPORT_FAILED,
                        METPrompt.PType.Error,
                        METPrompt.PButtons.Okay);

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
            cmdClose.Text = Program.MDL2_EXIT_CROSS;
        }
        #endregion
    }
}