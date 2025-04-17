// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSettings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmSettings : FormEx
    {
        #region Private Members
        private static string _strStartupInitialPath = string.Empty;
        private static string _strEfiInitialPath = string.Empty;
        private static string _strSocInitialPath = string.Empty;
        private Timer _timer;
        private bool _updateUI = true;
        #endregion

        #region Contructor
        public frmSettings()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(this, tlpTitle, lblTitle);

            // Set button properties
            SetButtonProperties();
        }

        private void WireEventHandlers()
        {
            Load += frmSettings_Load;
            KeyDown += frmSettings_KeyDown;
        }
        #endregion

        #region Window Events
        private void frmSettings_Load(object sender, EventArgs e)
        {
            lblSettingsSaved.Hide();
            UpdateCheckBoxControls();
            UpdatePathLabel();
        }
        #endregion

        #region KeyDown Events
        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void cmdEditStartupDir_Click(object sender, EventArgs e)
        {
            EditDirectory(Settings.StringKey.StartupInitialDirectory, ref _strStartupInitialPath, lblStartupDirectory);
        }

        private void cmdEditEfiDir_Click(object sender, EventArgs e)
        {
            EditDirectory(Settings.StringKey.EfiInitialDirectory, ref _strEfiInitialPath, lblEfiDirectory);
        }

        private void cmdEditSocDir_Click(object sender, EventArgs e)
        {
            EditDirectory(Settings.StringKey.SocInitialDirectory, ref _strSocInitialPath, lblSocDirectory);
        }

        private void EditDirectory(Settings.StringKey settingsKey, ref string pathField, Label labelToUpdate)
        {
            if (OpenFolderDialog(settingsKey, ref pathField))
            {
                labelToUpdate.Text = $"{Program.MDL2_RIGHT_ARROW} {pathField}";
                labelToUpdate.ForeColor = Colours.Okay;
            }
        }

        private static bool OpenFolderDialog(Settings.StringKey settingsType, ref string path)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath =
                    string.IsNullOrEmpty(Settings.ReadString(settingsType))
                        ? ApplicationPaths.WorkingDirectory
                        : Settings.ReadString(settingsType);

                dialog.Description = APPSTRINGS.SELECT_FOLDER;
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    path = dialog.SelectedPath;
                    return true;
                }
            }

            return false;
        }

        private void cmdOkay_Click(object sender, EventArgs e)
        {
            _updateUI = false;
            cmdApply.PerformClick();
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            Settings.SetBool(Settings.BooleanKey.DisableVersionCheck, swDisableVersionCheck.Checked);
            Settings.SetBool(Settings.BooleanKey.UseAccentColor, swUseAccentColor.Checked);
            Settings.SetBool(Settings.BooleanKey.DisableSerialValidation, swDisableSnValidation.Checked);
            Settings.SetBool(Settings.BooleanKey.DisableFlashingUI, swDisableFlashingUiElements.Checked);
            Settings.SetBool(Settings.BooleanKey.DisableMessageSounds, swDisableMessageWindowSounds.Checked);
            Settings.SetBool(Settings.BooleanKey.DisableTips, swDisableStatusBarTips.Checked);
            Settings.SetBool(Settings.BooleanKey.DisableConfDiag, swDisableConfirmationDialogs.Checked);

            if (_strStartupInitialPath != string.Empty)
            {
                Settings.SetString(Settings.StringKey.StartupInitialDirectory, _strStartupInitialPath);
            }

            if (_strEfiInitialPath != string.Empty)
            {
                Settings.SetString(Settings.StringKey.EfiInitialDirectory, _strEfiInitialPath);
            }

            if (_strSocInitialPath != string.Empty)
            {
                Settings.SetString(Settings.StringKey.SocInitialDirectory, _strSocInitialPath);
            }

            FormEx.UpdateAccentColor();

            if (_updateUI)
            {
                ShowSettingsAppliedLabel();
                UpdatePathLabel();
            }
        }

        private void cmdDefaults_Click(object sender, EventArgs e)
        {
            DialogResult result =
                METPrompt.Show(
                    this,
                    APPSTRINGS.RESET_SETTINGS_DEFAULT,
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }

            Settings.SetBool(Settings.BooleanKey.DisableVersionCheck, false);
            Settings.SetBool(Settings.BooleanKey.UseAccentColor, false);
            Settings.SetBool(Settings.BooleanKey.DisableSerialValidation, false);
            Settings.SetBool(Settings.BooleanKey.DisableFlashingUI, false);
            Settings.SetBool(Settings.BooleanKey.DisableMessageSounds, false);
            Settings.SetBool(Settings.BooleanKey.DisableTips, false);
            Settings.SetBool(Settings.BooleanKey.DisableConfDiag, false);
            Settings.SetString(Settings.StringKey.StartupInitialDirectory, ApplicationPaths.WorkingDirectory);
            Settings.SetString(Settings.StringKey.EfiInitialDirectory, ApplicationPaths.WorkingDirectory);
            Settings.SetString(Settings.StringKey.SocInitialDirectory, ApplicationPaths.WorkingDirectory);

            FormEx.UpdateAccentColor();

            UpdateCheckBoxControls();
            UpdatePathLabel();
            ShowSettingsAppliedLabel();
        }
        #endregion

        #region Label Events
        private void ShowSettingsAppliedLabel()
        {
            lblSettingsSaved.Show();

            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            _timer = new Timer
            {
                Interval = 2000
            };

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSettingsSaved.Hide();
            _timer.Stop();
            _timer.Dispose();
        }
        #endregion

        #region METSwitch Events
        private void UpdateCheckBoxControls()
        {
            swDisableVersionCheck.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableVersionCheck) ? true : false;
            swUseAccentColor.Checked = Settings.ReadBoolean(Settings.BooleanKey.UseAccentColor) ? true : false;
            swDisableSnValidation.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableSerialValidation) ? true : false;
            swDisableFlashingUiElements.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableFlashingUI) ? true : false;
            swDisableMessageWindowSounds.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableMessageSounds) ? true : false;
            swDisableStatusBarTips.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableTips) ? true : false;
            swDisableConfirmationDialogs.Checked = Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag) ? true : false;
        }
        #endregion

        #region UI Events
        private void UpdatePathLabel()
        {
            UpdateLabel(lblStartupDirectory, Settings.StringKey.StartupInitialDirectory);
            UpdateLabel(lblEfiDirectory, Settings.StringKey.EfiInitialDirectory);
            UpdateLabel(lblSocDirectory, Settings.StringKey.SocInitialDirectory);
        }

        private static void UpdateLabel(Label control, Settings.StringKey setting)
        {
            string strDirectory = Settings.ReadString(setting);
            control.Text = strDirectory;
            control.ForeColor = Directory.Exists(strDirectory) ? Colours.SettingsDefault : Colours.Warning;
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FontSegMdl2Regular12;
            cmdClose.Text = Program.MDL2_EXIT_CROSS;
        }
        #endregion
    }
}