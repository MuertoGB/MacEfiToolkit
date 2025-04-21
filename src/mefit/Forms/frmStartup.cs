﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmStartup.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFIROM;
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
    public partial class frmStartup : FormEx
    {
        #region Public Members
        public string LoadedFirmware = string.Empty;
        #endregion

        #region Private Members
        private readonly EFIROM _efirom = new EFIROM();
        private readonly SOCROM _socrom = new SOCROM();

        private string _strInitialDirectory = ApplicationPaths.WorkingDirectory;
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
            if (!string.IsNullOrEmpty(Program.DraggedFile))
            {
                OpenBinary(Program.DraggedFile);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.DraggedFile = string.Empty;
            }

            // Check for a new application version.
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableVersionCheck))
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
                if (!Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
                {
                    if (_childWindowCount != 0)
                    {
                        e.Cancel = true;
                        Program.HandleApplicationExit(this, ExitType.Exit);
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
            Program.HandleDragEnter(sender, e, ApplyDragEnterColours);
        }

        private void frmStartup_DragDrop(object sender, DragEventArgs e)
        {
            // Get the path of the dragged file.
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = draggedFiles[0];

            ApplyDragLeaveColours();

            this.BeginInvoke(new Action(() =>
            {
                OpenBinary(file);
            }));
        }

        private void frmStartup_DragLeave(object sender, EventArgs e) => ApplyDragLeaveColours();

        private void frmStartup_Deactivate(object sender, EventArgs e) => SetControlForeColor(tlpTitle, ApplicationColours.InactiveFormText);

        private void frmStartup_Activated(object sender, EventArgs e) => SetControlForeColor(tlpTitle, ApplicationColours.ActiveFormText);
        #endregion

        #region KeyDown Events
        private void frmStartup_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Alt key is pressed
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                // Let the system handle Alt+F4 to close the window
                e.Handled = false;
                return;
            }

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
                Program.HandleApplicationExit(this, ExitType.Exit);
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
            UITools.OpenFolderInExplorer(ApplicationPaths.BackupsDirectory, this);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.BuildsDirectory, this);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.FsysDirectory, this);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.IntelMeDirectory, this);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.NvramDirectory, this);

        private void openLZMADXEFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.LzmaDirectory, this);

        private void openSCFGFolderToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.ScfgDirectory, this);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            UITools.OpenFolderInExplorer(ApplicationPaths.WorkingDirectory, this);
        #endregion

        #region Tools Context Menu Events
        private void newEFIROMSessionToolStripMenuItem_Click(object sender, EventArgs e) => InitializeChildForm(new frmEfiRom(), string.Empty);

        private void newSOCROMSessionToolStripMenuItem_Click(object sender, EventArgs e) => InitializeChildForm(new frmSocRom(), string.Empty);

        private void restartApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_childWindowCount != 0)
            {
                Program.HandleApplicationExit(this, ExitType.Restart);
                return;
            }

            Program.Restart();
        }
        #endregion

        #region Help Context Menu Events
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.Changelog);

        private void donateToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.PaypalDonate);

        private void emailMeToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.Email);

        private void flexBVToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.FlexBv5);

        private void githubIssuesToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.GithubIssues);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.GithubHomepage);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(ApplicationUrls.GithubManual);

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmUpdate())
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e) => Logger.OpenLogFile(this);

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmAbout())
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmSettings())
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }
        #endregion

        #region Open Binary
        private void OpenBinary(string filepath)
        {
            if (!FirmwareFile.IsValidMinMaxSize(filepath, this, FirmwareFile.MIN_IMAGE_SIZE, FirmwareFile.MAX_IMAGE_SIZE))
            {
                return;
            }

            byte[] fileBuffer = File.ReadAllBytes(filepath);

            // Identify and open the correct window based on the firmware type.
            Form form = GetChildFormForImage(fileBuffer);

            if (form != null)
            {
                _strInitialDirectory = Path.GetDirectoryName(filepath);
                InitializeChildForm(form, filepath);
                return;
            }

            METPrompt.Show(
                this,
                DIALOGSTRINGS.NOT_VALID_FIRMWARE,
                METPrompt.PType.Warning,
                METPrompt.PButtons.Okay);
        }

        private Form GetChildFormForImage(byte[] sourceBytes)
        {
            if (_efirom.IsValidImage(sourceBytes))
            {
                return new frmEfiRom();
            }
            else if (_socrom.IsValidImage(sourceBytes))
            {
                return new frmSocRom();
            }

            return null;
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            if (sender is Form child)
            {
                if (child.Tag is StartupSenderTag formTag && formTag == StartupSenderTag.Firmware)
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
            cmdClose.Font = Program.SegoeFluentRegular12;
            cmdClose.Text = ApplicationChars.FLUENT_MULTIPLY;
        }

        private void SetLabelGlyphAndText()
        {
            lblGlyph.Font = Program.SegoeFluentRegular20;
            lblGlyph.Text = ApplicationChars.FLUENT_OPENLOCAL;
        }

        private void ApplyDragEnterColours() => lblGlyph.ForeColor = ApplicationColours.GlyphActive;

        private void ApplyDragLeaveColours() => lblGlyph.ForeColor = ApplicationColours.GlyphDefault;

        private void SetControlForeColor(Control parentcontrol, Color forecolor)
        {
            foreach (Control control in parentcontrol.Controls)
            {
                control.ForeColor = forecolor;
            }
        }

        private void InitializeChildForm(Form child, string filepath)
        {
            // Set the loaded firmware path.
            this.LoadedFirmware = filepath;

            // Increment child count and update window text.
            _childWindowCount++;

            // Update window title.
            UpdateWindowTitle();

            // Configure child.         
            child.Tag = StartupSenderTag.Firmware;
            child.FormClosed += ChildWindowClosed;
            child.Location = new Point(this.Location.X + (this.Width - child.Width) / 2, this.Location.Y + (this.Height - child.Height) / 2);
            child.Owner = this;
            child.Show();
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
            // Check for a new version.
            Updater.VersionResult result = await Updater.CheckForNewVersion();

            // If a new version is available update the UI.
            if (result == Updater.VersionResult.NewVersionAvailable)
            {
                cmdHelp.Text += $" {ApplicationChars.SEGUI_DINGBAT1}";
                updateAvailableToolStripMenuItem.Visible = true;
            }
        }
        #endregion

        #region Misc
        private void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(Settings.StringKey.StartupInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _strInitialDirectory = Directory.Exists(directory) ? directory : ApplicationPaths.WorkingDirectory;
            }
        }
        #endregion

        #region Debug Warn
        private void tlpDrop_Paint(object sender, PaintEventArgs e)
        {
            if (!Program.IsDebugMode())
            {
                return;
            }

            Graphics g = e.Graphics;
            int labelHeight = 20;

            TableLayoutPanel tlp = sender as TableLayoutPanel;

            if (tlp == null) return;

            Rectangle labelRectangle = new Rectangle(2, tlp.Height - labelHeight, tlp.Width - 4, labelHeight - 2);

            using (Brush brush = new SolidBrush(Color.Tomato))
            {
                g.FillRectangle(brush, labelRectangle);
            }

            string text = "==== Debug Mode ====";
            using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                SizeF textSize = g.MeasureString(text, font);
                PointF textPosition = new PointF((labelRectangle.Width - textSize.Width) / 2, labelRectangle.Top + (labelRectangle.Height - textSize.Height) / 2);
                g.DrawString(text, font, brush, textPosition);
            }
        }
        #endregion
    }
}