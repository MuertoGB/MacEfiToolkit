// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// startupWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
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
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class startupWindow : Form
    {
        #region Public Members
        public string loadedFile = string.Empty;
        #endregion

        #region Private Members
        private static readonly object _lockObject = new object();
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
            lblVersion.MouseClick += lblVersion_MouseClick;

            //
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
            lblVersion.Text = $"Version {Application.ProductVersion}";

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

            TimerCallback callback = new TimerCallback(
                GetPrivateMemoryUsage);

            Program.memoryTimer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
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
                lblWindowTitle,
                tlpMainButtons };

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
            InterfaceUtils.SetHalfOpacity(this);

            using (Form f = new settingsWindow())
            {
                f.FormClosed += ChildWindowClosed;
                f.ShowDialog();
            }
        }

        private void cmdAbout_Click(object sender, System.EventArgs e)
        {
            InterfaceUtils.SetHalfOpacity(this);
            using (Form f = new aboutWindow())
            {
                f.FormClosed += ChildWindowClosed;
                f.ShowDialog();
            }
        }

        private void cmdMore_Click(object sender, EventArgs e) =>
            InterfaceUtils.ShowContextMenuAtControlPoint(
            sender,
            cmsMore,
            MenuPosition.BottomLeft);
        #endregion

        #region Label Events
        private void lblVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(
                    METUrl.LatestGithubRelease);
        }
        #endregion

        #region UI Events
        private void ChildWindowClosed(object sender, EventArgs e) =>
            InterfaceUtils.SetNormalOpacity(this);

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
            tlpDrop.GradientStartColor = Color.FromArgb(80, 80, 80);
            lblGlyph.ForeColor = Color.FromArgb(80, 80, 80);
        }
        #endregion

        #region Context Menu Events
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Changelog);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Homepage);

        private void manualToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(METUrl.Manual);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(METPath.ApplicationLog))
            {
                Logger.ViewLogFile();
                return;
            }

            METMessageBox.Show(
                this,
                AppStrings.AS_INFO,
                DialogStrings.DS_LOG_NOT_CREATED,
                METMessageBoxType.Information,
                METMessageBoxButtons.Okay);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e) =>
            Program.PerformExitAction(this, ExitAction.Restart);
        #endregion

        private void GetPrivateMemoryUsage(object state)
        {
            lock (_lockObject)
            {
                using (Process currentProcess = Process.GetCurrentProcess())
                {
                    lblPrivateMemoryUsage.Invoke((Action)(() => lblPrivateMemoryUsage.Text =
                        $"{Helper.GetBytesReadableSize(currentProcess.PrivateMemorySize64)}"));
                }
            }
        }

        internal async void StartupVersionCheck()
        {
            // Check for a new version using the specified URL.
            VersionResult result =
                await AppUpdate.CheckForNewVersion(
                    METUrl.VersionXml);

            // If a new version is available and update the UI.
            if (result == VersionResult.NewVersionAvailable)
                lblVersion.ForeColor = AppColours.OUTDATED_VERSION;
        }

        private void LoadBinary(string filePath)
        {
            // Check the filesize
            if (!FileUtils.IsValidMinMaxSize(filePath, this))
                return;

            byte[] file = File.ReadAllBytes(filePath);

            // Try process flash descriptor, this is required.
            IFD.ParseRegionData(file);

            Form form = null;

            // Check for valid image types
            if (EFIROM.IsValidImage(file))
            {
                loadedFile = filePath;
                form = new efiWindow();
            }
            else if (T2ROM.IsValidImage(file))
            {
                loadedFile = filePath;
                form = new t2Window();
            }

            if (form != null)
            {
                form.FormClosed += ChildWindowClosed;
                form.Location = new Point(
                    this.Location.X + (this.Width - form.Width) / 2,
                    this.Location.Y + (this.Height - form.Height) / 2);
                form.Owner = this;
                form.Show();
            }

            loadedFile = string.Empty;
        }

    }
}