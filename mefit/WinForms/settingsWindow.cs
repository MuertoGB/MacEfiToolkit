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
        private bool _bIsTimerRunning = false;
        #endregion

        #region Overrides Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                // Params.Style |= Program.WS_MINIMIZEBOX; (Not necessary, window cannot be minimized)
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
            lblSettingsUpdated.Hide();
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
            cbxAcceptedEditingTerms.Enabled = (Settings.SettingsGetBool(SettingsBoolType.AcceptedEditingTerms)) ? true : false;
            cbxAcceptedEditingTerms.Checked = (Settings.SettingsGetBool(SettingsBoolType.AcceptedEditingTerms)) ? true : false;
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

        private void cmdEditingTerms_Click(object sender, EventArgs e)
        {
            // User accepts terms
            cbxAcceptedEditingTerms.Enabled = true;
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
            // Here we are simply using the bool value from a checkboxes state. Nice and simple.
            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, cbxDisableVersionCheck.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, cbxDisableFlashingUI.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, cbxDisableConfDiag.Checked);
            if (_strNewOfdInitialPath != string.Empty) Settings.SettingsSetString(SettingsStringType.InitialDirectory, _strNewOfdInitialPath);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, cbxDisableLzmaFsSearch.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableFsysEnforce, cbxDisableFsysEnforce.Checked);
            Settings.SettingsSetBool(SettingsBoolType.DisableDescriptorEnforce, cbxDisableDescriptorEnforce.Checked);
            //Settings._settingsSetBool(SettingsBoolType.AcceptedEditingTerms, cbxAcceptedEditingTerms.Checked); // Not used yet.
            _showSettingsUpdatedLabel();
        }

        private void cmdDefaults_Click(object sender, EventArgs e)
        {
            // Here we are simply using the bool value from a checkboxes state. Nice and simple.
            Settings.SettingsSetBool(SettingsBoolType.DisableVersionCheck, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableFlashingUI, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableConfDiag, false);
            if (_strNewOfdInitialPath != string.Empty) Settings.SettingsSetString(SettingsStringType.InitialDirectory, Settings.strDefaultOfdPath);
            Settings.SettingsSetBool(SettingsBoolType.DisableLzmaFsSearch, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableFsysEnforce, false);
            Settings.SettingsSetBool(SettingsBoolType.DisableDescriptorEnforce, false);
            //Settings._settingsSetBool(SettingsBoolType.AcceptedEditingTerms, cbxAcceptedEditingTerms.Checked); // Not used yet.
            _updateControls();
            _showSettingsUpdatedLabel();
        }

        private void _showSettingsUpdatedLabel()
        {
            if (!_bIsTimerRunning)
            {
                lblSettingsUpdated.Show();
                //InterfaceUtils.FlashForecolor(lblSettingsUpdated);

                var timer = new System.Windows.Forms.Timer();

                timer.Interval = 2000;
                timer.Tick += (sender, e) =>
                {
                    lblSettingsUpdated.Hide();
                    timer.Stop();
                    timer.Dispose();
                    _bIsTimerRunning = false;
                };

                timer.Start();
                _bIsTimerRunning = true;
            }
        }
        #endregion

    }
}