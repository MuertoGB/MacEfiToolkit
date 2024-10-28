﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.Common;
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
        internal const string Build = "241028.0055";
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
            // Register exception handler events early.
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Register application exit event.
            Application.ApplicationExit += OnExiting;

            // Set Web Security Protocol.
            ServicePointManager.SecurityProtocol =
                (SecurityProtocolType)3072;

            // Default framework stuff.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load fonts into memory.
            byte[] fontData = Properties.Resources.segmdl2;

            if (fontData != null)
            {
                FONT_MDL2_REG_9 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        9.0F,
                        FontStyle.Regular);
                FONT_MDL2_REG_10 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        10.0F,
                        FontStyle.Regular);
                FONT_MDL2_REG_12 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        12.0F,
                        FontStyle.Regular);
                FONT_MDL2_REG_20 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        20.0F,
                        FontStyle.Regular);
            }
            else
            {
                MessageBox.Show(
                    "Segoe MDL2 Assets font failed to load, see ./mefit.log for more details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Initialize settings.
            Settings.Initialize();

            // Get dragged filepath.
            draggedFilePath = GetDraggedFilePath(args);

            // Register low level keyboard hook that disables Win+Up.
            KeyboardHookManager.Hook();

            // Ensure program directories exist.
            EnsureDirectoriesExist();

            // Create main window instance.
            MAIN_WINDOW = new startupWindow();

            // Run mWindow instance.
            Application.Run(MAIN_WINDOW);
        }

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

    }
}