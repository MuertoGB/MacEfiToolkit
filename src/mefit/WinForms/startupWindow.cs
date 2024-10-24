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
            DragEnter += startupWindow_DragEnter;
            DragDrop += startupWindow_DragDrop;
            DragLeave += startupWindow_DragLeave;

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
                LoadBinary(Program.draggedFilePath);
                // Clear the path so restarting does not cause the initially dragged file to be loaded.
                Program.draggedFilePath = string.Empty;
            }

            // Check for a new application version
            if (!Settings.ReadBool(SettingsBoolType.DisableVersionCheck))
                StartupVersionCheck();
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

            LoadBinary(draggedFilename);
        }

        private void startupWindow_DragLeave(object sender, EventArgs e) =>
            ApplyDragLeaveColours();

        internal async void StartupVersionCheck()
        {
            // Check for a new version using the specified URL.
            VersionResult result =
                await AppUpdate.CheckForNewVersion(
                    METUrl.VersionXml);

            // If a new version is available and update the UI.
            if (result == VersionResult.NewVersionAvailable)
            {
                cmdMore.Text += " (1)";
                updateAvailableToolStripMenuItem.Visible = true;
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
        private void cmdMin_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e) =>
            Application.Exit();

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

        private void cmdMore_Click(object sender, EventArgs e) =>
            UITools.ShowContextMenuAtControlPoint(
            sender,
            cmsMore,
            MenuPosition.BottomLeft);

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                // InitialDirectory == need set
                Filter = "Firmware Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    LoadBinary(dialog.FileName);
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

        #region Context Menu Events
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
                DialogStrings.DS_LOG_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e) =>
            Program.PerformExitAction(this, ExitAction.Restart);
        #endregion

        #region Misc Events
        private void LoadBinary(string filePath)
        {
            // Check the filesize
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
                return;

            byte[] file = File.ReadAllBytes(filePath);

            // Try process flash descriptor, this is required.
            IFD.ParseRegionData(file);

            Form child = null;

            // Check for valid image types
            if (EFIROM.IsValidImage(file))
            {
                loadedFile = filePath;
                child = new efiWindow();
            }
            else if (T2ROM.IsValidImage(file))
            {
                loadedFile = filePath;
                child = new t2Window();
            }

            if (child != null)
            {
                child.Tag = FormTag.Firmware;

                // Increment the child window counter
                _childWindowCount++;

                // Update window title
                UpdateWindowTitle();

                // Attach the FormClosed event to handle when the form is closed
                child.FormClosed += ChildWindowClosed;

                // Set the location of the child window relative to the main window
                child.Location = new Point(
                    this.Location.X + (this.Width - child.Width) / 2,
                    this.Location.Y + (this.Height - child.Height) / 2);

                // Set the owner of the child form
                child.Owner = this;

                // Show the child form
                child.Show();
            }

            loadedFile = string.Empty;
        }

        private void UpdateWindowTitle()
        {
            if (_childWindowCount == 0)
            {
                lblWindowTitle.Text = AppStrings.AS_NAME;
                return;
            }

            lblWindowTitle.Text =
                $"{AppStrings.AS_NAME} ({_childWindowCount})";
        }
        #endregion

    }
}