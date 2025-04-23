// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GPL v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Forms;
using Mac_EFI_Toolkit.Tools;
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
    static class Program
    {
        internal enum ExitType
        {
            Restart,
            Exit
        }

        #region Internal Members
        internal static string DraggedFile = string.Empty;
        internal static frmStartup MainWindow;
        internal static Font FluentRegular10;
        internal static Font FluentRegular12;
        internal static Font FluentRegular20;
        #endregion

        #region Main Entry Point
        [STAThread]
        static void Main(string[] args)
        {
            // Register application-wide exception handlers.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Catch exceptions on the main thread.
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Catch exceptions from non-UI threads.
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Register application exit handler.
            Application.ApplicationExit += OnExiting;

            // Check if the OS is supported (Windows 7 or later is required).
            if (!SystemTools.IsSupportedOS())
            {
                return;
            }

            // Set the security protocol to TLS 1.2.
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Standard winforms setup.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load custom fonts into memory.
            if (!FontResolver.LoadCustomFont(Properties.Resources.FluentSystemIcons, out Font[] fonts))
            {
                Logger.WriteCallerLine(LOGSTRINGS.MAIN_FLUENT_NOTLOADED);
                return;
            }

            // Assign loaded fonts to corresponding variables.
            FluentRegular10 = fonts[0];
            FluentRegular12 = fonts[1];
            FluentRegular20 = fonts[2];

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
        private static void OnExiting(object sender, EventArgs e) => HandleOnExitingCleanup();

        private static void HandleOnExitingCleanup()
        {
            // Dispose of memory fonts.
            FluentRegular10?.Dispose();
            FluentRegular12?.Dispose();
            FluentRegular20?.Dispose();
        }
        #endregion

        #region Exception Handler
        internal static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e != null)
            {
                ExceptionHandler(e.Exception);
            }
        }

        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;

            if (exception != null)
            {
                ExceptionHandler(exception);
            }
        }

        internal static void ExceptionHandler(Exception e)
        {
            DialogResult result;

            string workingDirectory = ApplicationPaths.WorkingDirectory;
            string dateStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"unhandled_{dateStamp}.log";
            string fullPath = Path.Combine(workingDirectory, fileName);

            File.WriteAllText(fullPath, Unhandled.GenerateReport(e));

            if (File.Exists(fullPath))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {fullPath.Replace(" ", ApplicationChars.SEGUI_NOBREAKSPACE)}" +
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
                // We need to clean any necessary objects as OnExit will not fire when Environment.Exit is called.
                HandleOnExitingCleanup();
                Environment.Exit(-1);
            }

            BlurHelper.RemoveBlur(MainWindow);
        }
        #endregion

        #region Exit
        internal static void HandleApplicationExit(Form owner, ExitType action)
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
                    ? $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_RESTART}"
                    : $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_EXIT}";

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

        internal static void Restart()
        {
            try
            {
                Process.Start(Application.ExecutablePath);
            }
            catch (Win32Exception e)
            {
                Logger.WriteErrorLine(nameof(Restart), e.GetType(), e.Message);
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

        internal static void EnsureDirectoriesExist()
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
                Logger.WriteErrorLine(nameof(CreateDirectoryIfNotExists), e.GetType(), e.Message);
            }
        }

        public static void HandleDragEnter(object sender, DragEventArgs e, Action applycolor)
        {
            // Check if the dragged data is a file.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged.
                if (draggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder.
                    string file = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(file);

                    // If it's a file (not a folder) then allow the copy operation.
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        applycolor?.Invoke();
                        return;
                    }
                }
            }

            // Disable the drop operation.
            e.Effect = DragDropEffects.None;
        }

        internal static bool IsDebugMode()
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