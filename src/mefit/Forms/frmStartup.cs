// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmStartup.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Firmware.T2;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public partial class frmStartup : METForm
    {
        #region Enums
        private enum FormTag
        {
            Firmware,
            Other
        }
        #endregion

        #region Public Members
        public string loadedFile = string.Empty;
        #endregion

        #region Private Members
        private string _strInitialDirectory = METPath.WORKING_DIR;
        private int _childWindowCount = 0;
        #endregion

        #region Constructor
        public frmStartup()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(
                this,
                tlpTitle,
                lblWindowTitle);

            // Set button properties.
            SetButtonProperties();

            //Set label properties.
            SetLabelProperties();
        }

        private void WireEventHandlers()
        {
            Load += startupWindow_Load;
            KeyDown += startupWindow_KeyDown;
            FormClosing += startupWindow_FormClosing;
            DragEnter += startupWindow_DragEnter;
            DragDrop += startupWindow_DragDrop;
            DragLeave += startupWindow_DragLeave;
            Deactivate += startupWindow_Deactivate;
            Activated += startupWindow_Activated;

            tlpDrop.Paint += tlpDrop_Paint;
        }
        #endregion

        #region Window Events
        private void startupWindow_Load(object sender, EventArgs e)
        {
            // Set version text.
            lblAppVersion.Text =
                Application.ProductVersion;

            SetInitialDirectory();

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
                    METUrl.VERSION_MANIFEST);

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
            BlurHelper.ApplyBlur(this);

            using (Form child = new frmSettings())
            {
                child.Tag = FormTag.Other;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();
            }
        }

        private void cmdAbout_Click(object sender, System.EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form child = new frmAbout())
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
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_SUPPORT_FIRMWARE
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    OpenBinary(dialog.FileName);
            }
        }
        #endregion

        #region Folders Context Menu Events
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.BACKUPS_DIR, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.BUILDS_DIR, this);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.FSYS_DIR, this);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.INTELME_DIR, this);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.NVRAM_DIR, this);

        private void openSCFGFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.SCFG_DIR, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.WORKING_DIR, this);
        #endregion

        #region More Context Menu Events
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.CHANGELOG);

        private void donateToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.DONATE);

        private void emailMeToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.EMAILME);

        private void githubIssuesToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.GH_ISSUE);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.HOMEPAGE);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.MANUAL);

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.GH_LATEST);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.OpenLogFile(this);
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

            BlurHelper.RemoveBlur(this);
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }

        private void SetLabelProperties()
        {
            lblGlyph.Font = Program.FONT_MDL2_REG_20;
            lblGlyph.Text = Program.GLYPH_DOWN_ARROW;
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

        #region Misc Events
        private void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory =
                Settings.ReadString(SettingsStringType.StartupInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory)
                    ? directory
                    : METPath.WORKING_DIR;
            }
        }

        private void OpenBinary(string filePath)
        {
            if (!FileTools.IsValidMinMaxSize(filePath, this))
                return;

            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Identify and open the correct window based on the image type
            Form childForm = GetChildFormForImage(fileBytes);

            if (childForm != null)
            {
                _strInitialDirectory = Path.GetDirectoryName(filePath);
                InitializeChildForm(childForm, filePath);
                return;
            }

            METPrompt.Show(
                this,
                "The provided file was not a supported firmware.",
                METPromptType.Error,
                METPromptButtons.Okay);
        }

        private Form GetChildFormForImage(byte[] sourceBytes)
        {
            if (EFIROM.IsValidImage(sourceBytes))
                return new frmEfiRom();
            else if (T2ROM.IsValidImage(sourceBytes))
                return new frmSocRom();

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
                lblWindowTitle.Text = APPSTRINGS.APPNAME;
                return;
            }

            lblWindowTitle.Text =
                $"{APPSTRINGS.APPNAME} ({_childWindowCount})";
        }
        #endregion

        #region Debug Warn
        private void tlpDrop_Paint(object sender, PaintEventArgs e)
        {
            // This is to stop some stupid dumbass releasing debug builds.
            // No idea who that could be.
            // Certinaly wasn't me.
            // In would never do such a thing.

            if (Program.GetIsDebugMode())
            {
                var g = e.Graphics;

                TableLayoutPanel tlp = sender as TableLayoutPanel;
                if (tlp == null) return;

                int labelHeight = 20;
                Rectangle labelRectangle = new Rectangle(
                    0,
                    tlp.Height - labelHeight,
                    tlp.Width,
                    labelHeight
                );

                using (Brush backgroundBrush = new SolidBrush(Color.Tomato))
                {
                    g.FillRectangle(backgroundBrush, labelRectangle);
                }

                string labelText = "== Debug Mode - Do not Release Tit Face ==";
                using (Font font = new Font("Arial", 9, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    SizeF textSize = g.MeasureString(labelText, font);
                    PointF textPosition = new PointF(
                        (labelRectangle.Width - textSize.Width) / 2,
                        labelRectangle.Top + (labelRectangle.Height - textSize.Height) / 2
                    );

                    g.DrawString(labelText, font, textBrush, textPosition);
                }
            }
        }
        #endregion
    }
}