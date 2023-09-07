// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// settingsWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class settingsWindow : Form
    {

        #region Private Members
        private static string _strNewOfdInitialPath = string.Empty;
        private Timer _timer;
        private bool _updateUI = true;
        #endregion

        #region Overrides Properties
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

        #region Contructor
        public settingsWindow()
        {
            InitializeComponent();

            Load += settingsWindow_Load;
            KeyDown += aboutWindow_KeyDown;

            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            pbxLogo.MouseMove += settingsWindow_MouseMove;
            lblTitle.MouseMove += settingsWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void settingsWindow_Load(object sender, EventArgs e)
        {
            lblSettingsSaved.Hide();
            UpdateCheckBoxControls();
            UpdatePathLabel();
        }

        private void UpdatePathLabel()
        {
            string path =
                Settings.SettingsGetString(SettingsStringType.InitialDirectory);

            lblPath.Text =
              path;

            lblPath.ForeColor = Directory.Exists(path)
                ? Colours.DIM_TEXT
                : Colours.WARNING_ORANGE;

        }
        #endregion

        #region Mouse Events
        private void settingsWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region KeyDown Events
        private void aboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdEditCustomPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = (Settings.SettingsGetString(SettingsStringType.InitialDirectory) == string.Empty)
                    ? METPath.CurrentDirectory
                    : Settings.SettingsGetString(SettingsStringType.InitialDirectory);
                fbd.Description = "Select a folder";
                fbd.ShowNewFolderButton = false;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _strNewOfdInitialPath = fbd.SelectedPath;
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
            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, swDisableVersionCheck.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, swDisableFlashingUiElements.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableMessageSounds, swDisableMessageWindowSounds.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableTips, swDisableStatusBarTips.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, swDisableConfirmationDialogs.Checked);
            if (_strNewOfdInitialPath != string.Empty)
                Settings.SettingsSetString(SettingsStringType.InitialDirectory, _strNewOfdInitialPath);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, swDisableLzmaDecompression.Checked);

            if (!FWBase.FirmwareLoaded)
                Program.mWindow.SetPrimaryInitialDirectory();

            if (_updateUI)
            {
                _showSettingsAppliedLabel();
                UpdatePathLabel();
            }
        }

        private void cmdDefaults_Click(object sender, EventArgs e)
        {
            DialogResult result =
                METMessageBox.Show(this, "Settings", "This will revert all settings to default, " +
                "are you sure you want to set default settings?", METMessageType.Warning, METMessageButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }

            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableMessageSounds, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableTips, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, false);
            Settings.SettingsSetString(SettingsStringType.InitialDirectory, METPath.CurrentDirectory);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, false);

            UpdateCheckBoxControls();
            UpdatePathLabel();
            _showSettingsAppliedLabel();
        }
        #endregion

        #region Label Events
        private void _showSettingsAppliedLabel()
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

        #region Checkbox Events
        private void UpdateCheckBoxControls()
        {
            swDisableVersionCheck.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck) ? true : false;
            swDisableFlashingUiElements.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableFlashingUI) ? true : false;
            swDisableMessageWindowSounds.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableMessageSounds) ? true : false;
            swDisableStatusBarTips.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableTips) ? true : false;
            swDisableConfirmationDialogs.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag) ? true : false;
            swDisableLzmaDecompression.Checked = Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch) ? true : false;
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