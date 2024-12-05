// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmSettings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmSettings : METForm
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
            OpenFolderDialog(SettingsStringType.StartupInitialDirectory, ref _strStartupInitialPath);

            if (!string.Equals(_strStartupInitialPath, lblStartupDirectory.Text))
            {
                lblStartupDirectory.Text = $"{Program.GLYPH_RIGHT_ARROW} {_strStartupInitialPath}";
                lblStartupDirectory.ForeColor = Colours.ClrOkay;
            }
        }

        private void cmdEditEfiDir_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(SettingsStringType.EfiInitialDirectory, ref _strEfiInitialPath);

            if (!string.Equals(_strEfiInitialPath, lblEfiDirectory.Text))
            {
                lblEfiDirectory.Text = $"{Program.GLYPH_RIGHT_ARROW} {_strEfiInitialPath}";
                lblEfiDirectory.ForeColor = Colours.ClrOkay;
            }
        }

        private void cmdEditSocDir_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(SettingsStringType.SocInitialDirectory, ref _strSocInitialPath);

            if (!string.Equals(_strSocInitialPath, lblSocDirectory))
            {
                lblSocDirectory.Text = $"{Program.GLYPH_RIGHT_ARROW} {_strSocInitialPath}";
                lblSocDirectory.ForeColor = Colours.ClrOkay;
            }
        }

        private static void OpenFolderDialog(SettingsStringType settingsType, ref string path)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath =
                    string.IsNullOrEmpty(Settings.ReadString(settingsType))
                        ? ApplicationPaths.WorkingDirectory
                        : Settings.ReadString(settingsType);

                dialog.Description = APPSTRINGS.SELECT_FOLDER;
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            }
        }

        private void cmdOkay_Click(object sender, EventArgs e)
        {
            _updateUI = false;
            cmdApply.PerformClick();
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            Settings.SetBool(SettingsBoolType.DisableVersionCheck, swDisableVersionCheck.Checked);
            Settings.SetBool(SettingsBoolType.UseAccentColor, swUseAccentColor.Checked);
            Settings.SetBool(SettingsBoolType.DisableSerialValidation, swDisableSnValidation.Checked);
            Settings.SetBool(SettingsBoolType.DisableFlashingUI, swDisableFlashingUiElements.Checked);
            Settings.SetBool(SettingsBoolType.DisableMessageSounds, swDisableMessageWindowSounds.Checked);
            Settings.SetBool(SettingsBoolType.DisableTips, swDisableStatusBarTips.Checked);
            Settings.SetBool(SettingsBoolType.DisableConfDiag, swDisableConfirmationDialogs.Checked);

            if (_strStartupInitialPath != string.Empty)
            {
                Settings.SetString(SettingsStringType.StartupInitialDirectory, _strStartupInitialPath);
            }

            if (_strEfiInitialPath != string.Empty)
            {
                Settings.SetString(SettingsStringType.EfiInitialDirectory, _strEfiInitialPath);
            }

            if (_strSocInitialPath != string.Empty)
            {
                Settings.SetString(SettingsStringType.SocInitialDirectory, _strSocInitialPath);
            }

            METForm.UpdateAccentColor();

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
                    METPromptType.Warning,
                    METPromptButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }

            Settings.SetBool(SettingsBoolType.DisableVersionCheck, false);
            Settings.SetBool(SettingsBoolType.UseAccentColor, false);
            Settings.SetBool(SettingsBoolType.DisableSerialValidation, false);
            Settings.SetBool(SettingsBoolType.DisableFlashingUI, false);
            Settings.SetBool(SettingsBoolType.DisableMessageSounds, false);
            Settings.SetBool(SettingsBoolType.DisableTips, false);
            Settings.SetBool(SettingsBoolType.DisableConfDiag, false);
            Settings.SetString(SettingsStringType.StartupInitialDirectory, ApplicationPaths.WorkingDirectory);
            Settings.SetString(SettingsStringType.EfiInitialDirectory, ApplicationPaths.WorkingDirectory);
            Settings.SetString(SettingsStringType.SocInitialDirectory, ApplicationPaths.WorkingDirectory);

            METForm.UpdateAccentColor();

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
            swDisableVersionCheck.Checked = Settings.ReadBool(SettingsBoolType.DisableVersionCheck) ? true : false;
            swUseAccentColor.Checked = Settings.ReadBool(SettingsBoolType.UseAccentColor) ? true : false;
            swDisableSnValidation.Checked = Settings.ReadBool(SettingsBoolType.DisableSerialValidation) ? true : false;
            swDisableFlashingUiElements.Checked = Settings.ReadBool(SettingsBoolType.DisableFlashingUI) ? true : false;
            swDisableMessageWindowSounds.Checked = Settings.ReadBool(SettingsBoolType.DisableMessageSounds) ? true : false;
            swDisableStatusBarTips.Checked = Settings.ReadBool(SettingsBoolType.DisableTips) ? true : false;
            swDisableConfirmationDialogs.Checked = Settings.ReadBool(SettingsBoolType.DisableConfDiag) ? true : false;
        }
        #endregion

        #region UI Events
        private void UpdatePathLabel()
        {
            UpdateLabel(lblStartupDirectory, SettingsStringType.StartupInitialDirectory);
            UpdateLabel(lblEfiDirectory, SettingsStringType.EfiInitialDirectory);
            UpdateLabel(lblSocDirectory, SettingsStringType.SocInitialDirectory);
        }

        private static void UpdateLabel(Label control, SettingsStringType setting)
        {
            string strPath = Settings.ReadString(setting);
            control.Text = strPath;
            control.ForeColor = Directory.Exists(strPath) ? Colours.ClrSettingsDefault : Colours.ClrWarn;
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FontSegMdl2Regular12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }
        #endregion
    }
}