// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmStartup.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Firmware.SOCROM;
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
            UITools.EnableFormDrag(this, tlpTitle, lblWindowTitle);

            // Set button properties.
            SetButtonGlyphAndText();

            //Set label properties.
            SetLabelGlyphAndText();
        }

        private void WireEventHandlers()
        {
            Load += frmStartup_Load;
            KeyDown += frmStartup_KeyDown;
            FormClosing += frmStartup_FormClosing;
            DragEnter += frmStartup_DragEnter;
            DragDrop += frmStartup_DragDrop;
            DragLeave += frmStartup_DragLeave;
            Deactivate += frmStartup_Deactivate;
            Activated += frmStartup_Activated;
            tlpDrop.Paint += tlpDrop_Paint;
        }
        #endregion

        #region Window Events
        private void frmStartup_Load(object sender, EventArgs e)
        {
            // Set version text.
            lblAppVersion.Text = Application.ProductVersion;

            SetInitialDirectory();

            // Open dragged file is the arg path is ! null or ! empty.
            if (!string.IsNullOrEmpty(Program.draggedFilePath))
            {
                OpenBinary(Program.draggedFilePath);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.draggedFilePath = string.Empty;
            }

            // Check for a new application version.
            if (!Settings.ReadBool(SettingsBoolType.DisableVersionCheck))
            {
                StartupVersionCheck();
            }
        }

        private void frmStartup_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Intercept ALT+F4.
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close if confirmation dialogs are not disabled.
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

        private void frmStartup_DragEnter(object sender, DragEventArgs e)
        {
            ApplyDragEnterColours();
            Program.HandleDragEnter(sender, e);
        }

        private void frmStartup_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string draggedFilename = draggedFiles[0];

            ApplyDragLeaveColours();

            OpenBinary(draggedFilename);
        }

        private void frmStartup_DragLeave(object sender, EventArgs e) => ApplyDragLeaveColours();

        private void frmStartup_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.CLR_INACTIVEFORM);

        private void frmStartup_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, Colours.CLR_ACTIVEFORM);
        #endregion

        #region KeyDown Events
        private void frmStartup_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle individual keys (F1, F2, F12) without modifiers.
            switch (e.KeyCode)
            {
                case Keys.F1:
                    manualToolStripMenuItem.PerformClick();
                    break;
                case Keys.F2:
                    newEFIROMSessionToolStripMenuItem.PerformClick();
                    break;
                case Keys.F3:
                    newSOCROMSessionToolStripMenuItem.PerformClick();
                    break;
                case Keys.F4:
                    settingsToolStripMenuItem.PerformClick();
                    break;
                case Keys.F12:
                    viewApplicationLogToolStripMenuItem.PerformClick();
                    break;
            }

            // Handle control key + other combinations.
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    // Form actions.
                    case Keys.O:
                        cmdBrowse.PerformClick();
                        break;

                    // Main Menu.
                    case Keys.L:
                        cmdMenuFolders.PerformClick();
                        break;
                    case Keys.T:
                        cmdTools.PerformClick();
                        break;
                    case Keys.H:
                        cmdHelp.PerformClick();
                        break;
                }
            }
        }
        #endregion

        #region Button Events
        private void cmdMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (_childWindowCount != 0)
            {
                Program.HandleApplicationExit(this, ExitAction.Exit);
                return;
            }

            Program.Exit();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _strInitialDirectory,
                Filter = APPSTRINGS.FILTER_STARTUP_WINDOW
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdOptions_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsOptions,
                MenuPosition.BottomLeft);

        private void cmdMenuFolders_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsFolders,
                MenuPosition.BottomLeft);

        private void cmdHelp_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
                sender,
                cmsHelp,
                MenuPosition.BottomLeft);
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

        private void openLZMADXEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.LZMA_DIR, this);

        private void openSCFGFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.SCFG_DIR, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(METPath.WORKING_DIR, this);
        #endregion

        #region Tools Context Menu Events
        private void newEFIROMSessionToolStripMenuItem_Click(object sender, EventArgs e) => InitializeChildForm(new frmEfiRom(), string.Empty);

        private void newSOCROMSessionToolStripMenuItem_Click(object sender, EventArgs e) => InitializeChildForm(new frmSocRom(), string.Empty);

        private void restartApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_childWindowCount != 0)
            {
                Program.HandleApplicationExit(this, ExitAction.Restart);
                return;
            }

            Program.Restart();
        }
        #endregion

        #region Help Context Menu Events
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.CHANGELOG);

        private void donateToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.DONATE);

        private void emailMeToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.EMAILME);

        private void githubIssuesToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.GH_ISSUE);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.HOMEPAGE);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.MANUAL);

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(METUrl.GH_LATEST);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e) => Logger.OpenLogFile(this);

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form child = new frmAbout())
            {
                child.Tag = StartupSenderTag.Other;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form child = new frmSettings())
            {
                child.Tag = StartupSenderTag.Other;
                child.FormClosed += ChildWindowClosed;
                child.ShowDialog();
            }
        }
        #endregion

        #region Open Binary
        private void OpenBinary(string filePath)
        {
            if (!FileTools.IsValidMinMaxSize(filePath, this))
            {
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Identify and open the correct window based on the firmware type.
            Form childForm = GetChildFormForImage(fileBytes);

            if (childForm != null)
            {
                _strInitialDirectory = Path.GetDirectoryName(filePath);
                InitializeChildForm(childForm, filePath);
                return;
            }

            METPrompt.Show(
                this,
                DIALOGSTRINGS.NOT_VALID_FIRMWARE,
                METPromptType.Warning,
                METPromptButtons.Okay);
        }

        private Form GetChildFormForImage(byte[] sourceBytes)
        {
            if (EFIROM.IsValidImage(sourceBytes))
            {
                return new frmEfiRom();
            }
            else if (SOCROM.IsValidImage(sourceBytes))
            {
                return new frmSocRom();
            }

            return null;
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is StartupSenderTag formTag && formTag == StartupSenderTag.Firmware)
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

        private void SetButtonGlyphAndText()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.GLYPH_EXIT_CROSS;
        }

        private void SetLabelGlyphAndText()
        {
            lblGlyph.Font = Program.FONT_MDL2_REG_20;
            lblGlyph.Text = Program.GLYPH_DOWN_ARROW;
        }

        private void ApplyDragEnterColours() => lblGlyph.ForeColor = Color.FromArgb(152, 251, 152);

        private void ApplyDragLeaveColours() => lblGlyph.ForeColor = Color.FromArgb(80, 80, 80);

        private void SetControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control control in parentControl.Controls)
            {
                control.ForeColor = foreColor;
            }
        }

        private void InitializeChildForm(Form childForm, string filePath)
        {
            this.loadedFile = filePath;

            // Increment child count and update window text.
            _childWindowCount++;
            UpdateWindowTitle();

            // Configure child.
            childForm.Tag = StartupSenderTag.Firmware;
            childForm.FormClosed += ChildWindowClosed;
            childForm.Location = new Point(this.Location.X + (this.Width - childForm.Width) / 2, this.Location.Y + (this.Height - childForm.Height) / 2);
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

            lblWindowTitle.Text = $"{APPSTRINGS.APPNAME} ({_childWindowCount})";
        }

        internal async void StartupVersionCheck()
        {
            // Check for a new version using the specified URL.
            VersionResult result = await AppVersion.CheckForNewVersion(METUrl.VERSION_MANIFEST);

            // If a new version is available and update the UI.
            if (result == VersionResult.NewVersionAvailable)
            {
                cmdHelp.Text += " (1)";
                updateAvailableToolStripMenuItem.Visible = true;
            }
        }
        #endregion

        #region Misc
        private void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(SettingsStringType.StartupInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory) ? directory : METPath.WORKING_DIR;
            }
        }
        #endregion

        #region Debug Warn
        private void tlpDrop_Paint(object sender, PaintEventArgs e)
        {
            // This is to stop some stupid dumbass releasing debug builds.
            // No idea who that could be.
            // Certainly wasn't me.
            // In would never do such a thing.

            if (Program.IsDebugMode())
            {
                Graphics g = e.Graphics;
                int labelHeight = 20;

                TableLayoutPanel tlp = sender as TableLayoutPanel;

                if (tlp == null)
                {
                    return;
                }

                Rectangle labelRectangle = new Rectangle(2, tlp.Height - labelHeight, tlp.Width - 4, labelHeight - 2);

                using (Brush backgroundBrush = new SolidBrush(Color.Tomato))
                {
                    g.FillRectangle(backgroundBrush, labelRectangle);
                }

                string labelText = "==== Debug Mode - Do not Release ====";
                using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    SizeF textSize = g.MeasureString(labelText, font);
                    PointF textPosition = new PointF((labelRectangle.Width - textSize.Width) / 2, labelRectangle.Top + (labelRectangle.Height - textSize.Height) / 2);
                    g.DrawString(labelText, font, textBrush, textPosition);
                }
            }
        }
        #endregion
    }
}