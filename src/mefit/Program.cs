// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GPL v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Forms;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utilities;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public static class Program
    {
        public enum ExitType
        {
            Restart,
            Exit
        }

        #region Public Members
        public static string DraggedFile = string.Empty;
        public static frmStartup MainWindow;
        public static Font FluentRegular12;
        public static Font FluentRegular14;
        public static Font FluentRegular24;
        #endregion

        #region Private Members
        private static FontResolver _fontResolver;
        #endregion

        #region Main Entry Point
        [STAThread]
        public static void Main(string[] args)
        {
            // Register application-wide exception handlers.
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            // Catch exceptions on the main thread.
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(
                    ExceptionManager.ThreadException);

            // Catch exceptions from non-UI threads.
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(
                    ExceptionManager.CurrentDomainException);

            // Register application exit handler.
            Application.ApplicationExit += OnExiting;

            // Check if the OS is supported (Windows 10 or later is required).
            if (!SystemUtils.IsSupportedOS())
                return;

            // Set the security protocol to TLS 1.2.
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Standard winforms setup.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load custom fonts into memory.
            _fontResolver = new FontResolver();
            if (!_fontResolver.LoadCustomFont(Properties.Resources.FluentSystemIcons, out Font[] fonts))
            {
                FailFast(ExitCodes.FontImport, DialogStrings.FF_UNABLE_TO_LOAD_FONT);
                return;
            }

            // Assign loaded fonts to corresponding variables.
            FluentRegular12 = fonts[0];
            FluentRegular14 = fonts[1];
            FluentRegular24 = fonts[2];

            // Initialize application settings.
            Settings.Initialize();

            // Retrieve a file path from command-line.
            DraggedFile = GetDraggedFilePath(args);

            // Ensure that required application directories exist; create them if they don't.
            EnsureDirectoriesExist();

            // Create the main window instance.
            MainWindow = new frmStartup();

            // Start the application message loop.
            Application.Run(MainWindow);
        }
        #endregion

        #region OnExiting
        private static void OnExiting(object sender, EventArgs e)
            => HandleOnExitingCleanup();

        public static void HandleOnExitingCleanup()
        {
            // Dispose of memory fonts.
            FluentRegular12?.Dispose();
            FluentRegular14?.Dispose();
            FluentRegular24?.Dispose();
        }
        #endregion

        #region Exit
        public static void HandleApplicationExit(Form owner, ExitType action)
        {
            // Check if confirmation dialogs are disabled
            if (Settings.ReadBoolean(Settings.BooleanKey.DisableConfDiag))
            {
                ExecuteExitAction(action);
                return;
            }

            string title = action ==
                ExitType.Restart ? "Restart" : "Quit";

            string message = action ==
                ExitType.Restart
                    ? $"{AppStrings.FIRMWARE_WINDOWS_OPEN} {AppStrings.QUESTION_RESTART}"
                    : $"{AppStrings.FIRMWARE_WINDOWS_OPEN} {AppStrings.QUESTION_EXIT}";

            if (ShowConfirmationDialog(owner, title, message))
            {
                ExecuteExitAction(action);
            }
        }

        private static void ExecuteExitAction(ExitType action)
        {
            switch (action)
            {
                case ExitType.Restart:
                    Restart();
                    break;
                case ExitType.Exit:
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
                    METPrompt.PType.Question,
                    METPrompt.PButtons.YesNo);

            return result == DialogResult.Yes;
        }

        public static void Restart()
        {
            try
            {
                Process.Start(Application.ExecutablePath);
            }
            catch (Win32Exception e)
            {
                Logger.LogException(e, nameof(Restart));
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
            {
                return args[0];
            }

            return string.Empty;
        }

        public static void EnsureDirectoriesExist()
        {
            CreateDirectoryIfNotExists(ApplicationPaths.BackupsDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.BuildsDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.FsysDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.IntelMeDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.NvramDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.ScfgDirectory);
            CreateDirectoryIfNotExists(ApplicationPaths.LzmaDirectory);
        }

        private static void CreateDirectoryIfNotExists(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(CreateDirectoryIfNotExists));
            }
        }

        public static bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public static string BitnessMode()
        {
            if (Environment.Is64BitProcess)
            {
                return "64-bit Process";
            }
            else
            {
                return "32-bit Process";
            }
        }

        public static void FailFast(
            int exitCode,
            string exitReason = AppStrings.NO_REASON_GIVEN)
        {
            Logger.LogError(
                $"{exitReason} ({nameof(exitCode)} {exitCode})");

            MessageBox.Show(
                $"{exitReason}. {AppStrings.APP_WILL_EXIT}",
                AppStrings.FATAL_ERROR,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            Environment.Exit(exitCode);
        }
        #endregion
    }
}