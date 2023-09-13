// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
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
    internal struct METPath
    {
        internal static string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static string BackupsDirectory = Path.Combine(CurrentDirectory, "backups");
        internal static string BuildsDirectory = Path.Combine(CurrentDirectory, "builds");
        internal static string FsysDirectory = Path.Combine(CurrentDirectory, "fsys_stores");
        internal static string MeDirectory = Path.Combine(CurrentDirectory, "me_regions");
        internal static string SettingsFile = Path.Combine(CurrentDirectory, "Settings.ini");
        internal static string DebugLog = Path.Combine(CurrentDirectory, "debug.log");
        internal static string UnhandledLog = Path.Combine(CurrentDirectory, "unhandled.log");
    }

    internal struct METVersion
    {
        internal static readonly string Build = "230914.0000";
        internal static readonly string Channel = "Stable";
    }

    internal struct METUrl
    {
        internal static string Changelog = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/CHANGELOG.md";
        internal static string Homepage = "https://github.com/MuertoGB/MacEfiToolkit";
        internal static string LatestGithubRelease = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";
        internal static string Manual = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/MANUAL.md";
        internal static string VersionXml = "https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml";
    }
    #endregion

    #region Enum
    internal enum MetAction
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
        internal static System.Threading.Timer memoryTimer;
        internal static mainWindow mWindow;

        internal static Font FONT_MDL2_REG_20;
        internal static Font FONT_MDL2_REG_14;
        internal static Font FONT_MDL2_REG_12;
        internal static Font FONT_MDL2_REG_10;
        internal static Font FONT_MDL2_REG_9;
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
            // Register exception handler events early
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Default framework stuff.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Web Security Protocol
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Font Data
            byte[] fontData = Properties.Resources.segmdl2;

            if (fontData != null)
            {
                FONT_MDL2_REG_9 = new Font(FontResolver.LoadFontFromResource(fontData), 9.0F, FontStyle.Regular);
                FONT_MDL2_REG_10 = new Font(FontResolver.LoadFontFromResource(fontData), 10.0F, FontStyle.Regular);
                FONT_MDL2_REG_12 = new Font(FontResolver.LoadFontFromResource(fontData), 12.0F, FontStyle.Regular);
                FONT_MDL2_REG_14 = new Font(FontResolver.LoadFontFromResource(fontData), 14.0F, FontStyle.Regular);
                FONT_MDL2_REG_20 = new Font(FontResolver.LoadFontFromResource(fontData), 20.0F, FontStyle.Regular);
            }
            else
            {
                MessageBox.Show("Segoe MDL2 Assets font failed to load, see ./mefit.log for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Settings
            if (!File.Exists(METPath.SettingsFile))
                Settings.SettingsCreateFile();

            // Register application exit event.
            Application.ApplicationExit += OnExiting;

            // Register low level keyboard hook for preventing WinKey+Up.
            KeyboardHookManager.Hook();

            // Get dragged filepath
            draggedFilePath = GetDraggedFilePath(args);

            // Create main window instance
            mWindow = new mainWindow();

            // Run mWindow instance.
            Application.Run(mWindow);
        }

        private static string GetDraggedFilePath(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                return args[0];
            }

            return string.Empty;
        }

        #endregion

        #region OnExit
        private static void OnExiting(object sender, EventArgs e)
        {
            HandleExitCleanup();
        }

        private static void HandleExitCleanup()
        {
            // Dispose fonts
            FONT_MDL2_REG_9.Dispose();
            FONT_MDL2_REG_10.Dispose();
            FONT_MDL2_REG_12.Dispose();
            FONT_MDL2_REG_14.Dispose();
            FONT_MDL2_REG_20.Dispose();

            // Dispose memory stats timer
            memoryTimer.Dispose();

            // Unhook the low level keyboard hook
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

            File.WriteAllText(METPath.UnhandledLog, Debug.GenerateDebugReport(e));

            if (File.Exists(METPath.UnhandledLog))
            {
                result = MessageBox.Show
                   (
                   $"{e.Message}\r\n\r\nDetails were saved to {METPath.UnhandledLog.Replace(" ", Chars.NBSPACE)}'\r\n\r\nForce quit application?",
                   $"MET Exception Handler",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Error
                   );
            }
            else
            {
                result = MessageBox.Show
                    (
                    $"{e.Message}\r\n\r\n{e}\r\n\r\nForce quit application?",
                    $"{e.GetType()}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }

            if (result == DialogResult.Yes)
            {
                HandleExitCleanup(); // We need to clean any necessary objects as OnExit will not fire when Environment.Exit is called.
                Environment.Exit(-1);
            }

            // Fix for mainWindow opacity getting stuck at 0.5
            if (mWindow.Opacity != 1.0)
                mWindow.Opacity = 1.0;
        }
        #endregion

        #region MET Action
        internal static void PerformMetAction(Form owner, MetAction action)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                if (action == MetAction.Restart)
                {
                    Restart();
                }
                else if (action == MetAction.Exit)
                {
                    Application.Exit();
                }
                return;
            }

            string title, message;

            if (action == MetAction.Restart)
            {
                title = "Restart";
                message = "Are you sure you want to restart the application?";
            }
            else if (action == MetAction.Exit)
            {
                title = "Quit";
                message = "Are you sure you want to quit the application?";
            }
            else
            {
                return;
            }

            if (ShowConfirmationDialog(owner, title, message))
            {
                if (action == MetAction.Restart)
                {
                    Restart();
                }
                else if (action == MetAction.Exit)
                {
                    Application.Exit();
                }
            }
        }

        private static bool ShowConfirmationDialog(Form owner, string title, string message)
        {
            DialogResult result = METMessageBox.Show(owner, title, message, METMessageType.Question, METMessageButtons.YesNo);
            return result == DialogResult.Yes;
        }

        private static void Restart()
        {
            try
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            catch (Win32Exception)
            {
                // Do nothing.
                // The application throws an unhandled exception when a user cancels the UAC prompt.
                return;
            }
        }
        #endregion

    }
}