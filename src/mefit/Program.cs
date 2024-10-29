// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{

    #region Struct
    internal readonly struct METPath
    {
        internal static readonly string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string BackupsDirectory = Path.Combine(WorkingDirectory, "backups");
        internal static readonly string BuildsDirectory = Path.Combine(WorkingDirectory, "builds");
        internal static readonly string FsysDirectory = Path.Combine(WorkingDirectory, "fsys_stores");
        internal static readonly string MeDirectory = Path.Combine(WorkingDirectory, "me_regions");
        internal static readonly string ScfgDirectory = Path.Combine(WorkingDirectory, "scfg_stores");
        internal static readonly string SettingsFile = Path.Combine(WorkingDirectory, "Settings.ini");
        internal static readonly string DebugLog = Path.Combine(WorkingDirectory, "debug.log");
        internal static readonly string UnhandledLog = Path.Combine(WorkingDirectory, "unhandled.log");
        internal static readonly string ApplicationLog = Path.Combine(WorkingDirectory, "mefit.log");
        internal static readonly string DatabaseLog = Path.Combine(WorkingDirectory, "database.log");
    }

    internal readonly struct METVersion
    {
        internal const string SDK = "23.01";
        internal const string Build = "241029.2025";
        internal const string Channel = "DEV";
    }

    internal readonly struct METUrl
    {
        internal const string Changelog = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/CHANGELOG.md";
        internal const string Donate = "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ";
        internal const string Email = "mailto:muertogb@proton.me";
        internal const string Homepage = "https://github.com/MuertoGB/MacEfiToolkit";
        internal const string GithubIssues = "https://github.com/MuertoGB/MacEfiToolkit/issues";
        internal const string GithubLatest = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";
        internal const string Manual = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/MANUAL.md";
        internal const string VersionXml = "https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/stream/manifests/version.xml";

    }
    #endregion

    #region Enum
    internal enum ExitAction
    {
        Restart,
        Exit
    }
    #endregion

    static class Program
    {

        #region Internal Members
        internal static string draggedFilePath = string.Empty;
        internal static string lastBuildPath = string.Empty;
        internal static bool openLastBuild = false;
        internal static startupWindow MAIN_WINDOW;

        internal static Font FONT_MDL2_REG_9;
        internal static Font FONT_MDL2_REG_10;
        internal static Font FONT_MDL2_REG_12;
        internal static Font FONT_MDL2_REG_20;
        #endregion

        #region Const Members
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        internal const int WS_MINIMIZEBOX = 0x20000;
        internal const int CS_DBLCLKS = 0x8;
        internal const int CS_DROP = 0x20000;
        #endregion

        #region Main Entry Point
        [STAThread]
        static void Main(string[] args)
        {
            // Check if the OS is supported (Windows 7 or later is required)
            if (!IsSupportedOS())
                return;

            // Register application-wide exception handlers
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Catch exceptions on the main thread
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Catch exceptions from non-UI threads
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Register application exit handler
            Application.ApplicationExit += OnExiting;

            // Set the security protocol to TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Standard winforms setup
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load custom fonts into memory
            if (!TryLoadCustomFont(Properties.Resources.segmdl2, out Font[] fonts))
                return;

            // Assign loaded fonts to corresponding variables
            FONT_MDL2_REG_9 = fonts[0];
            FONT_MDL2_REG_10 = fonts[1];
            FONT_MDL2_REG_12 = fonts[2];
            FONT_MDL2_REG_20 = fonts[3];

            // Initialize application settings
            Settings.Initialize();

            // Retrieve a file path from command-line
            draggedFilePath = GetDraggedFilePath(args);

            // Register a low-level keyboard hook to disable Win+Up
            KeyboardHookManager.Hook();

            // Ensure that required application directories exist; create them if they don't
            EnsureDirectoriesExist();

            // Create the main window instance
            MAIN_WINDOW = new startupWindow();

            // Start the application message loop
            Application.Run(MAIN_WINDOW);
        }

        #endregion

        #region OnExit
        private static void OnExiting(object sender, EventArgs e) =>
            HandleOnExitingCleanup();

        private static void HandleOnExitingCleanup()
        {
            // Dispose of memory fonts.
            FONT_MDL2_REG_9?.Dispose();
            FONT_MDL2_REG_10?.Dispose();
            FONT_MDL2_REG_12?.Dispose();
            FONT_MDL2_REG_20?.Dispose();

            // Unhook the low level keyboard hook.
            KeyboardHookManager.Unhook();
        }
        #endregion

        #region Exception Handler
        internal static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e != null)
                ExceptionHandler(e.Exception);
        }

        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            if (ex != null)
                ExceptionHandler(ex);
        }

        internal static void ExceptionHandler(Exception e)
        {
            DialogResult result;

            File.WriteAllText(
                METPath.UnhandledLog,
                Unhandled.GenerateUnhandledReport(e));

            if (File.Exists(METPath.UnhandledLog))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {METPath.UnhandledLog.Replace(" ", Chars.NB_SPACE)}" +
                        $"'\r\n\r\nForce quit application?",
                        $"MET Exception Handler",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }
            else
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{e}\r\n\r\nForce quit application?",
                        $"{e.GetType()}",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }

            if (result == DialogResult.Yes)
            {
                // We need to clean any necessary objects as OnExit will not fire
                // when Environment.Exit is called.
                HandleOnExitingCleanup();

                Environment.Exit(-1);
            }

            // Fix for mainWindow opacity getting stuck at 0.5.
            if (MAIN_WINDOW != null)
                if (MAIN_WINDOW.Opacity != 1.0)
                    MAIN_WINDOW.Opacity = 1.0;
        }
        #endregion

        #region Exit Action
        internal static void HandleApplicationExit(Form owner, ExitAction action)
        {
            // Check if confirmation dialogs are disabled
            if (Settings.ReadBool(SettingsBoolType.DisableConfDiag))
            {
                ExecuteExitAction(action);
                return;
            }

            string title = action == ExitAction.Restart ? "Restart" : "Quit";
            string message = action == ExitAction.Restart
                ? $"{AppStrings.S_FW_WIN_OPEN} {AppStrings.S_HAE_RESTART}"
                : $"{AppStrings.S_FW_WIN_OPEN} {AppStrings.S_HAE_EXIT}";

            if (ShowConfirmationDialog(owner, title, message))
            {
                ExecuteExitAction(action);
            }
        }

        // Execute the exit action based on the given type
        private static void ExecuteExitAction(ExitAction action)
        {
            switch (action)
            {
                case ExitAction.Restart:
                    Restart();
                    break;
                case ExitAction.Exit:
                    Program.Exit();
                    break;
            }
        }

        private static bool ShowConfirmationDialog(Form owner, string title, string message)
        {
            DialogResult result =
                METMessageBox.Show(
                    owner,
                    message,
                    METMessageBoxType.Question,
                    METMessageBoxButtons.YesNo);

            return result == DialogResult.Yes;
        }

        internal static void Restart()
        {
            try
            {
                // Start a new instance of the application
                Process.Start(Application.ExecutablePath);
            }
            catch (Win32Exception e)
            {
                Logger.WriteToAppLog(e.Message);
                return;
            }
            finally
            {
                // Ensure the current instance exits
                Exit();
            }
        }

        internal static void Exit() => Application.Exit();
        #endregion

        #region Functions
        private static string GetDraggedFilePath(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
                return args[0];

            return string.Empty;
        }

        internal static void EnsureDirectoriesExist()
        {
            CreateDirectoryIfNotExists(METPath.BackupsDirectory);
            CreateDirectoryIfNotExists(METPath.BuildsDirectory);
            CreateDirectoryIfNotExists(METPath.FsysDirectory);
            CreateDirectoryIfNotExists(METPath.MeDirectory);
            CreateDirectoryIfNotExists(METPath.ScfgDirectory);
        }

        private static void CreateDirectoryIfNotExists(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
            }
            catch (UnauthorizedAccessException ex) // Permission error
            {
                Logger.WriteToAppLog($"Warning: Could not create directory '{directoryPath}'. Access is denied. Exception: {ex.Message}");
            }
            catch (IOException ex) // IO error
            {
                Logger.WriteToAppLog($"Warning: Could not create directory '{directoryPath}' due to an I/O error. Exception: {ex.Message}");
            }
            catch (Exception ex) // Misc error
            {
                Logger.WriteToAppLog($"Warning: Could not create directory '{directoryPath}'. Exception: {ex.Message}");
            }
        }

        private static bool IsSupportedOS()
        {
            FileVersionInfo version =
                OSUtils.GetKernelVersion;

            // Check for Windows 7 (6.1) or later (Windows 8, 8.1, 10, and 11)
            if (version.ProductMajorPart > 6 || (version.ProductMajorPart == 6 && version.ProductMinorPart >= 1))
                return true;

            MessageBox.Show("This application requires Windows 7 or later to run.",
                            "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private static bool TryLoadCustomFont(byte[] fontData, out Font[] fonts)
        {
            fonts = null;

            if (fontData == null)
                return false;

            try
            {
                var loadedFont =
                    FontResolver.LoadFontFromResource(fontData);

                fonts = new[]
                {
                    new Font(loadedFont, 9.0F, FontStyle.Regular),
                    new Font(loadedFont, 10.0F, FontStyle.Regular),
                    new Font(loadedFont, 12.0F, FontStyle.Regular),
                    new Font(loadedFont, 20.0F, FontStyle.Regular)
                };
                return true;
            }
            catch (Exception ex)
            {
                // Log the error
                Logger.WriteToAppLog($"{nameof(TryLoadCustomFont)} failed: {ex.Message}");

                // Display an error message to the user
                MessageBox.Show("Segoe MDL2 Assets font failed to load. See the log for more details.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

    }
}