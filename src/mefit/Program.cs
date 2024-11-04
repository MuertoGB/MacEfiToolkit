// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
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
        internal static readonly string WORKING_DIR = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FRIENDLY_NAME = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string BACKUPS_DIR = Path.Combine(WORKING_DIR, "backups");
        internal static readonly string BUILDS_DIR = Path.Combine(WORKING_DIR, "builds");
        internal static readonly string FSYS_DIR = Path.Combine(WORKING_DIR, "fsys_stores");
        internal static readonly string INTELME_DIR = Path.Combine(WORKING_DIR, "me_regions");
        internal static readonly string NVRAM_DIR = Path.Combine(WORKING_DIR, "nvram_stores");
        internal static readonly string SCFG_DIR = Path.Combine(WORKING_DIR, "scfg_stores");
        internal static readonly string SETTINGS_FILE = Path.Combine(WORKING_DIR, "Settings.ini");
        internal static readonly string DEBUG_LOG = Path.Combine(WORKING_DIR, "debug.log");
        internal static readonly string APP_LOG = Path.Combine(WORKING_DIR, "mefit.log");
        internal static readonly string DATABASE_LOG = Path.Combine(WORKING_DIR, "database.log");
    }

    internal readonly struct METVersion
    {
        internal const string LZMA_SDK = "23.01";
        internal const string APP_BUILD = "241104.0340";
        internal const string APP_CHANNEL = "DEV";
    }

    internal readonly struct METUrl
    {
        internal const string CHANGELOG = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/CHANGELOG.md";
        internal const string DONATE = "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ";
        internal const string EMAILME = "mailto:muertogb@proton.me";
        internal const string HOMEPAGE = "https://github.com/MuertoGB/MacEfiToolkit";
        internal const string GH_ISSUE = "https://github.com/MuertoGB/MacEfiToolkit/issues";
        internal const string GH_LATEST = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";
        internal const string MANUAL = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/MANUAL.md";
        internal const string VERSION_MANIFEST = "https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/stream/manifests/version.xml";

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
        internal static startupWindow MAIN_WINDOW;

        internal const string GLYPH_EXIT_CROSS = "\uE947";
        internal const string GLYPH_FILE_EXPLORER = "\uED25";
        internal const string GLYPH_DOWN_ARROW = "\uE74B";
        internal const string NOWRAP_SPACE = "\u00A0";

        internal static Font FONT_MDL2_REG_9;
        internal static Font FONT_MDL2_REG_10;
        internal static Font FONT_MDL2_REG_12;
        internal static Font FONT_MDL2_REG_20;
        #endregion

        #region Private Members
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
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

            // Debugging
            //Process.Start("unhandledexception.exe");

            // Create the main window instance
            MAIN_WINDOW = new startupWindow();

            // Start the application message loop
            Application.Run(MAIN_WINDOW);
        }
        #endregion

        #region OnExiting
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

            string workingDir = METPath.WORKING_DIR;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string logFileName = $"unhandled_{timestamp}.log";
            string logPath = Path.Combine(workingDir, logFileName);

            File.WriteAllText(
                logPath,
                UnhandledException.GenerateReport(e));

            if (File.Exists(logPath))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {logPath.Replace(" ", Program.NOWRAP_SPACE)}" +
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

            BlurHelper.RemoveBlur(MAIN_WINDOW);
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
                ? $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_RESTART}"
                : $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_EXIT}";

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
                METPrompt.Show(
                    owner,
                    message,
                    METPromptType.Question,
                    METPromptButtons.YesNo);

            return result == DialogResult.Yes;
        }

        internal static void Restart()
        {
            try
            {
                Process.Start(Application.ExecutablePath);
            }
            catch (Win32Exception e)
            {
                Logger.WriteError(nameof(Restart), e.GetType(), e.Message);
                return;
            }
            finally
            {
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
            CreateDirectoryIfNotExists(METPath.BACKUPS_DIR);
            CreateDirectoryIfNotExists(METPath.BUILDS_DIR);
            CreateDirectoryIfNotExists(METPath.FSYS_DIR);
            CreateDirectoryIfNotExists(METPath.INTELME_DIR);
            CreateDirectoryIfNotExists(METPath.NVRAM_DIR);
            CreateDirectoryIfNotExists(METPath.SCFG_DIR);
        }

        private static void CreateDirectoryIfNotExists(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
            }
            catch (Exception e) // Permission error
            {
                Logger.WriteError(nameof(CreateDirectoryIfNotExists), e.GetType(), e.Message);
            }
        }

        private static bool IsSupportedOS()
        {
            FileVersionInfo version =
                SystemTools.GetKernelVersion;

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
            catch (Exception e)
            {
                // Log the error
                Logger.WriteError(nameof(TryLoadCustomFont), e.GetType(), e.Message);
                return false;
            }
        }

        internal static bool GetIsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
        #endregion
    }
}