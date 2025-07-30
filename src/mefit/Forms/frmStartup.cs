// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Windows Forms
// frmStartup.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.Firmware.EFIROM;
using Mac_EFI_Toolkit.Firmware.SOCROM;
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
        public string LoadedFirmware { get; set; }
        #endregion

        #region Private Members
        private readonly EFIROM _efirom = new EFIROM();
        private readonly SOCROM _socrom = new SOCROM();
        private readonly Updater _updater = new Updater();
        private string _initialDirectory = ApplicationPaths.WorkingDirectory;
        private int _firmwareWindowCount = 0;
        #endregion

        #region Constructor
        public frmStartup()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Set button properties.
            SetButtonGlyphAndText();

            //Set label properties.
            SetLabelGlyphAndText();

            // Enable drag.
            WindowManager.EnableFormDrag(this, tlpTitle, lblWindowTitle);
        }
        #endregion

        #region Window Events
        private void frmStartup_Load(object sender, EventArgs e)
        {
            SetInitialDirectory();

            // Set version text.
            lblAppVersion.Text = Application.ProductVersion;

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
                    if (_firmwareWindowCount != 0)
                    {
                        e.Cancel = true;
                        Program.HandleApplicationExit(this, Program.ExitType.Exit);
                    }
                    else
                    {
                        Program.Exit();
                    }
                }
            }
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

        private void frmStartup_DragEnter(object sender, DragEventArgs e)
            => WindowManager.HandleDragEnter(sender, e, ApplyDragEnterColours);

        private void frmStartup_DragLeave(object sender, EventArgs e)
            => ApplyDragLeaveColours();

        private void frmStartup_Deactivate(object sender, EventArgs e)
            => SetControlForeColor(tlpTitle, ApplicationColors.InactiveFormText);

        private void frmStartup_Activated(object sender, EventArgs e)
            => SetControlForeColor(tlpTitle, ApplicationColors.ActiveFormText);
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
        private void cmdMinimize_Click(object sender, EventArgs e)
            => WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (_firmwareWindowCount != 0)
            {
                Program.HandleApplicationExit(this, Program.ExitType.Exit);
                return;
            }

            Program.Exit();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = _initialDirectory,
                Filter = AppStrings.FILTER_STARTUP_WINDOW
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenBinary(dialog.FileName);
                }
            }
        }

        private void cmdOptions_Click(object sender, EventArgs e)
            => WindowManager.ShowContextMenuAtControlPoint(
                sender,
                cmsOptions,
                WindowManager.ContextMenuPosition.BottomLeft);

        private void cmdMenuFolders_Click(object sender, EventArgs e)
            => WindowManager.ShowContextMenuAtControlPoint(
                sender,
                cmsFolders,
                WindowManager.ContextMenuPosition.BottomLeft);

        private void cmdHelp_Click(object sender, EventArgs e)
            => WindowManager.ShowContextMenuAtControlPoint(
                sender,
                cmsHelp,
                WindowManager.ContextMenuPosition.BottomLeft);
        #endregion

        #region Context Menu events
        // Folders Context Menu
        private void openBackupsFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.BackupsDirectory);

        private void openBuildsFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.BuildsDirectory);

        private void openFsysStoresFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.FsysDirectory);

        private void openIntelMEFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.IntelMeDirectory);

        private void openNVRAMFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.NvramDirectory);

        private void openLZMADXEFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.LzmaDirectory);

        private void openSCFGFolderToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.ScfgDirectory);

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
            => UITools.GoToFolderInExplorer(ApplicationPaths.WorkingDirectory);

        // Tools Context Menu
        private void newEFIROMSessionToolStripMenuItem_Click(object sender, EventArgs e)
            => InitializeChildForm(new frmEfiRom(), string.Empty);

        private void newSOCROMSessionToolStripMenuItem_Click(object sender, EventArgs e)
            => InitializeChildForm(new frmSocRom(), string.Empty);

        private void restartApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_firmwareWindowCount != 0)
            {
                Program.HandleApplicationExit(this, Program.ExitType.Restart);
                return;
            }

            Program.Restart();
        }

        //  Help Content Menu
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.Changelog);

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.PaypalDonate);

        private void emailMeToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.Email);

        private void flexBVToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.FlexBv5);

        private void githubIssuesToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.GithubIssues);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.GithubHomepage);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
            => Process.Start(ApplicationUrls.GithubManual);

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurHelper.ApplyBlur(this);

            using (Form form = new frmUpdate(_updater))
            {
                form.Tag = StartupSenderTag.Other;
                form.FormClosed += ChildWindowClosed;
                form.ShowDialog();
            }
        }

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
            => Logger.OpenLogFile(this);

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
            if (!FirmwareAnalyzer.CheckFileSizeWithinRange(filepath, this, FirmwareAnalyzer.MinImageSize, FirmwareAnalyzer.MaxImageSize))
                return;

            byte[] fileBuffer = File.ReadAllBytes(filepath);

            // Identify and open the correct window based on the firmware type.
            Form form = GetChildFormForImage(fileBuffer);

            if (form != null)
            {
                _initialDirectory = Path.GetDirectoryName(filepath);
                InitializeChildForm(form, filepath);
                return;
            }

            METPrompt.Show(
                this,
                DialogStrings.NOT_VALID_FIRMWARE,
                METPrompt.PType.Warning,
                METPrompt.PButtons.Okay);
        }
        #endregion

        #region User Interface
        private void ChildWindowClosed(object sender, EventArgs e)
        {
            if (sender is Form child)
            {
                if (child.Tag is StartupSenderTag formTag && formTag == StartupSenderTag.Firmware)
                {
                    if (_firmwareWindowCount > 0)
                    {
                        _firmwareWindowCount--;
                        UpdateWindowTitle();
                    }
                }
            }

            BlurHelper.RemoveBlur(this);
        }

        private void SetButtonGlyphAndText()
        {
            cmdClose.Font = Program.FluentRegular14;
            cmdClose.Text = ApplicationChars.FLUENT_DISMISS;
        }

        private void SetLabelGlyphAndText()
        {
            lblGlyph.Font = Program.FluentRegular24;
            lblGlyph.Text = ApplicationChars.FLUENT_DOCDOWNARROW;
        }

        private void ApplyDragEnterColours()
            => lblGlyph.ForeColor = ApplicationColors.DragActive;

        private void ApplyDragLeaveColours()
            => lblGlyph.ForeColor = ApplicationColors.DragDefault;

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
            _firmwareWindowCount++;

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
            if (_firmwareWindowCount == 0)
            {
                lblWindowTitle.Text = AppStrings.APPNAME;
                return;
            }

            lblWindowTitle.Text = $"{AppStrings.APPNAME} ({_firmwareWindowCount})";
        }

        internal async void StartupVersionCheck()
        {
            Updater.VersionResult result = await _updater.CheckForNewVersionAsync();

            // If a new version is available update the UI.
            if (result == Updater.VersionResult.NewVersionAvailable)
            {
                cmdHelp.Text += $" {ApplicationChars.SEGUI_DINGBAT1}";
                updateAvailableToolStripMenuItem.Visible = true;
            }
        }
        #endregion

        #region Private Events
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

        private void SetInitialDirectory()
        {
            // Get the initial directory from settings.
            string directory = Settings.ReadString(Settings.StringKey.StartupInitialDirectory);

            // If the path is not empty check if it exists and set it as the initial directory.
            if (!string.IsNullOrEmpty(directory))
            {
                _initialDirectory = Directory.Exists(directory) ? directory : ApplicationPaths.WorkingDirectory;
            }
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

        #region Paint Events
        private void tlpDrop_Paint(object sender, PaintEventArgs e)
        {
            if (!Program.IsDebugMode())
                return;

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
                PointF textPosition =
                    new PointF((
                    labelRectangle.Width - textSize.Width) / 2,
                    labelRectangle.Top + (labelRectangle.Height - textSize.Height) / 2);
                g.DrawString(text, font, brush, textPosition);
            }
        }
        #endregion
    }
}