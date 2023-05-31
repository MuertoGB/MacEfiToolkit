// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// settingsWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class settingsWindow : Form
    {

        #region Private Members
        private static string _strNewOfdInitialPath = string.Empty;
        private Timer _timer;
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

            lblTitle.MouseMove += settingsWindow_MouseMove;
            Load += settingsWindow_Load;
            KeyDown += aboutWindow_KeyDown;
        }
        #endregion

        #region Window Events
        private void settingsWindow_Load(object sender, EventArgs e)
        {
            lblSettingsApplied.Hide();
            _updateControls();
        }

        private void _updateControls()
        {
            cbxDisableVersionCheck.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableVersionCheck)) ? true : false;
            cbxDisableFlashingUI.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableFlashingUI)) ? true : false;
            cbxDisableConfDiag.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag)) ? true : false;
            cbxDisableLzmaFsSearch.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch)) ? true : false;
            cbxDisableFsysEnforce.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableFsysEnforce)) ? true : false;
            cbxDisableDescriptorEnforce.Checked = (Settings.SettingsGetBool(SettingsBoolType.DisableDescriptorEnforce)) ? true : false;
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
            if (e.KeyCode == Keys.Escape) Close();
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
                fbd.SelectedPath = (Settings.SettingsGetString(SettingsStringType.InitialDirectory) == string.Empty) ? Settings.strDefaultOfdPath : Settings.SettingsGetString(SettingsStringType.InitialDirectory);
                fbd.Description = "Select a folder";
                fbd.ShowNewFolderButton = false;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _strNewOfdInitialPath = fbd.SelectedPath;
                }
            }
        }

        private void cmdCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, cbxDisableVersionCheck.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, cbxDisableFlashingUI.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, cbxDisableConfDiag.Checked);
            if (_strNewOfdInitialPath != string.Empty) Settings.SettingsSetString(SettingsStringType.InitialDirectory, _strNewOfdInitialPath);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, cbxDisableLzmaFsSearch.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableFsysEnforce, cbxDisableFsysEnforce.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableDescriptorEnforce, cbxDisableDescriptorEnforce.Checked);
            _showSettingsAppliedLabel();
        }

        private void cmdDefaults_Click(object sender, EventArgs e)
        {
            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, false);
            if (_strNewOfdInitialPath != string.Empty) Settings.SettingsSetString(SettingsStringType.InitialDirectory, Settings.strDefaultOfdPath);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableFsysEnforce, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableDescriptorEnforce, false);
            _updateControls();
            _showSettingsAppliedLabel();
        }
        #endregion

        #region Label Events
        private void _showSettingsAppliedLabel()
        {
            lblSettingsApplied.Show();

            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            _timer = new Timer();
            _timer.Interval = 2000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSettingsApplied.Hide();
            _timer.Stop();
            _timer.Dispose();
        }
        #endregion

    }
}