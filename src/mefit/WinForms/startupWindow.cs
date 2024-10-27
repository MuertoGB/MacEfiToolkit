// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// startupWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Firmware.T2;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class startupWindow : Form
    {
        enum FormTag
        {
            Firmware,
            Other
        }

        #region Public Members
        public string loadedFile = string.Empty;
        #endregion

        #region Private Members
        private int _childWindowCount = 0;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.Style |= Program.WS_MINIMIZEBOX;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public startupWindow()
        {
            InitializeComponent();

            // Attach event handlers.
            Load += startupWindow_Load;
            KeyDown += startupWindow_KeyDown;
            FormClosing += startupWindow_FormClosing;
            DragEnter += startupWindow_DragEnter;
            DragDrop += startupWindow_DragDrop;
            DragLeave += startupWindow_DragLeave;
            Deactivate += startupWindow_Deactivate;
            Activated += startupWindow_Activated;

            // Set mouse event handlers.
            SetMouseMoveEventHandlers();

            // Set button properties.
            SetButtonProperties();

            //Set label properties.
            SetLabelProperties();
        }
        #endregion

        #region Window Events
        private void startupWindow_Load(object sender, EventArgs e)
        {
            // Set version text.
            lblAppVersion.Text =
                Application.ProductVersion;

            // Open dragged file is the arg path is ! null or ! empty.
            if (!string.IsNullOrEmpty(Program.draggedFilePath))
            {
                OpenBinary(Program.draggedFilePath);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.draggedFilePath = string.Empty;
            }

            // Check for a new application version
            if (!Settings.ReadBool(SettingsBoolType.DisableVersionCheck))
                StartupVersionCheck();
        }

        private void startupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Intercept ALT+F4
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close if confirmation dialogs are not disabled
                if (!Settings.ReadBool(SettingsBoolType.DisableConfDiag))
                {
                    if (_childWindowCount != 0)
                    {
                        e.Cancel = true;
                        Program.HandleApplicationExit(this, ExitAction.Exit);
                    }
                    else
                    {
                        Program.Exit();
                    }
                }
            }
        }

        private void startupWindow_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged.
                if (draggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder.
                    string draggedFile = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(draggedFile);

                    // If it's a file (not a folder) then allow the copy operation.
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        ApplyDragEnterColours();
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            // Disable the drop operation.
            e.Effect = DragDropEffects.None;
        }

        private void startupWindow_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            ApplyDragLeaveColours();

            OpenBinary(draggedFilename);
        }

        private void startupWindow_DragLeave(object sender, EventArgs e) =>
            ApplyDragLeaveColours();

        internal async void StartupVersionCheck()
        {
            // Check for a new version using the specified URL.
            VersionResult result =
                await AppVersion.CheckForNewVersion(
                    METUrl.VersionXml);

            // If a new version is available and update the UI.
            if (result == VersionResult.UpToDate)
            {
                cmdMore.Text += " (1)";
                updateAvailableToolStripMenuItem.Visible = true;
            }
        }

        private void startupWindow_Deactivate(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.DEACTIVATED_TEXT);

        private void startupWindow_Activated(object sender, EventArgs e) =>
            SetControlForeColor(tlpTitle, AppColours.WHITE_TEXT);

        private void SetControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control control in parentControl.Controls)
                control.ForeColor = foreColor;
        }
        #endregion

        #region KeyDown Events
        private void startupWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                    case Keys.B:
                        cmdBrowse.PerformClick();
                        break;
                    case Keys.S:
                        cmdSettings.PerformClick();
                        break;
                    case Keys.A:
                        cmdAbout.PerformClick();
                        break;
                    case Keys.E:
                        cmdMenuFolders.PerformClick();
                        break;
                    case Keys.M:
                        cmdMore.PerformClick();
                        break;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void mainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }

        private void SetMouseMoveEventHandlers()
        {
            Control[] controls = {
                tlpTitle,
                lblWindowTitle
            };

            foreach (Control control in controls)
                control.MouseMove += mainWindow_MouseMove;
        }
        #endregion

        #region Button Events
        private void cmdMinimize_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (_childWindowCount != 0)
            {
                Program.HandleApplicationExit(this, ExitAction.Exit);
                return;
            }

            Program.Exit();
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            UITools.SetHalfOpacity(this);

            using (Form child = new settingsWindow())
            {
                child.Tag = FormTag.Other;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();
            }
        }

        private void cmdAbout_Click(object sender, System.EventArgs e)
        {
            UITools.SetHalfOpacity(this);
            using (Form child = new aboutWindow())
            {
                child.Tag = FormTag.Other;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();
            }
        }

        private void cmdMenuFolders_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsFolders,
                MenuPosition.BottomLeft);

        private void cmdMore_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsMore,
                MenuPosition.BottomLeft);

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                // InitialDirectory == need set
                Filter = "Firmware Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    OpenBinary(dialog.FileName);
            }
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is FormTag formTag
                    && formTag == FormTag.Firmware)
                {
                    if (_childWindowCount > 0)
                    {
                        _childWindowCount--;
                        UpdateWindowTitle();
                    }
                }
            }

            UITools.SetNormalOpacity(this);
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }

        private void SetLabelProperties()
        {
            lblGlyph.Font = Program.FONT_MDL2_REG_20;
            lblGlyph.Text = Chars.DOWN;
        }

        private void ApplyDragEnterColours()
        {
            tlpDrop.GradientStartColor = Color.FromArgb(152, 251, 152);
            lblGlyph.ForeColor = Color.FromArgb(152, 251, 152);
        }

        private void ApplyDragLeaveColours()
        {
            tlpDrop.GradientStartColor = Color.FromArgb(30, 30, 30);
            tlpDrop.GradientEndColor = Color.FromArgb(30, 30, 30);
            lblGlyph.ForeColor = Color.FromArgb(80, 80, 80);
        }
        #endregion

        #region Folders Context Menu Events
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.BackupsDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.BackupsDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                DialogStrings.S_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.BuildsDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.BuildsDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                DialogStrings.S_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.FsysDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.FsysDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                DialogStrings.S_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(METPath.MeDirectory))
            {
                Process.Start(
                    "explorer.exe",
                    METPath.MeDirectory);

                return;
            }

            METMessageBox.Show(
                this,
                DialogStrings.S_DIR_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start("explorer.exe", METPath.CurrentDirectory);
        #endregion

        #region More Context Menu Events
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Changelog);

        private void donateToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Donate);

        private void emailMeToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Email);

        private void githubIssuesToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.GithubIssues);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Homepage);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Manual);

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.GithubLatest);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(METPath.ApplicationLog))
            {
                Logger.ViewLogFile();
                return;
            }

            METMessageBox.Show(
                this,
                DialogStrings.S_LOG_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_childWindowCount != 0)
            {
                Program.HandleApplicationExit(this, ExitAction.Restart);
                return;
            }

            Program.Restart();
        }
        #endregion

        #region Misc Events
        private void OpenBinary(string filePath)
        {
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
                return;

            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Try processing flash descriptor
            IFD.ParseRegionData(fileBytes);

            // Identify and open the correct window based on the image type
            Form childForm = GetChildFormForImage(fileBytes);

            if (childForm != null)
            {
                InitializeChildForm(childForm, filePath);
                return;
            }

            METMessageBox.Show(
                this,
                "The provided file was not a supported firmware.",
                METMessageBoxType.Error,
                METMessageBoxButtons.Okay);
        }

        private Form GetChildFormForImage(byte[] fileBytes)
        {
            if (EFIROM.IsValidImage(fileBytes))
                return new efiWindow();
            else if (T2ROM.IsValidImage(fileBytes))
                return new t2Window();

            return null;
        }

        private void InitializeChildForm(Form childForm, string filePath)
        {
            this.loadedFile = filePath;
            childForm.Tag = FormTag.Firmware;

            _childWindowCount++;
            UpdateWindowTitle();

            // Attach event handler for child form closure
            childForm.FormClosed += ChildWindowClosed;

            // Center child form relative to the main window
            childForm.Location = new Point(
                this.Location.X + (this.Width - childForm.Width) / 2,
                this.Location.Y + (this.Height - childForm.Height) / 2);

            childForm.Owner = this;
            childForm.Show();
        }


        private void UpdateWindowTitle()
        {
            if (_childWindowCount == 0)
            {
                lblWindowTitle.Text = AppStrings.S_NAME;
                return;
            }

            lblWindowTitle.Text =
                $"{AppStrings.S_NAME} ({_childWindowCount})";
        }
        #endregion

    }
}