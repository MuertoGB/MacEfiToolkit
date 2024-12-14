// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Forms;
using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mac_EFI_Toolkit
{
    #region Struct
    internal readonly struct ApplicationPaths
    {
        internal static readonly string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string BackupsDirectory = Path.Combine(WorkingDirectory, "backups");
        internal static readonly string BuildsDirectory = Path.Combine(WorkingDirectory, "builds");
        internal static readonly string FsysDirectory = Path.Combine(WorkingDirectory, "fsys_stores");
        internal static readonly string IntelMeDirectory = Path.Combine(WorkingDirectory, "me_regions");
        internal static readonly string NvramDirectory = Path.Combine(WorkingDirectory, "nvram_stores");
        internal static readonly string ScfgDirectory = Path.Combine(WorkingDirectory, "scfg_stores");
        internal static readonly string LzmaDirectory = Path.Combine(WorkingDirectory, "lzma_archives");
        internal static readonly string SettingsFile = Path.Combine(WorkingDirectory, "Settings.ini");
        internal static readonly string ApplicationLog = Path.Combine(WorkingDirectory, "application.log");
        internal static readonly string DatabaseLog = Path.Combine(WorkingDirectory, "database.log");
    }

    internal readonly struct ApplicationUrls
    {
        internal const string Changelog = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/CHANGELOG.md";
        internal const string PaypalDonate = "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ";
        internal const string Email = "mailto:muertogb@proton.me";
        internal const string FlexBv5 = "https://pldaniels.com/flexbv5/";
        internal const string GithubHomepage = "https://github.com/MuertoGB/MacEfiToolkit";
        internal const string GithubManual = "https://github.com/MuertoGB/MacEfiToolkit/blob/main/MANUAL.md#application-manual";
        internal const string GithubIssues = "https://github.com/MuertoGB/MacEfiToolkit/issues";
        internal const string GithubLatestVersion = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";
        internal const string VersionManifest = "https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/stream/manifests/version.xml";

    }

    internal readonly struct ApplicationVersions
    {
        internal const string LZMA_SDK_VERSION = "24.08";
        internal const string CURRENT_BUILD = "241214.2050";
        internal const string CURRENT_CHANNEL = "Stable";
    }
    #endregion

    #region Enum
    internal enum ExitAction
    {
        Restart,
        Exit
    }

    public enum VersionResult
    {
        UpToDate,
        NewVersionAvailable,
        Error
    }
    #endregion

    static class Program
    {
        #region Internal Members
        internal static string DraggedFile = string.Empty;
        internal static frmStartup MainWindow;
        internal static Font FontSegMdl2Regular10;
        internal static Font FontSegMdl2Regular12;
        internal static Font FontSegMdl2Regular20;

        internal const string GLYPH_EXIT_CROSS = "\uE947";
        internal const string GLYPH_FILE_EXPLORER = "\uED25";
        internal const string GLYPH_DOWN_ARROW = "\uE74B";
        internal const string GLYPH_RIGHT_ARROW = "\u2192";
        internal const string GLYPH_REPORT = "\uE9F9";
        internal const string GLYPH_ACCOUNT = "\uE910";
        internal const string NOWRAP_SPACE = "\u00A0";
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
            if (!IsSupportedOS())
            {
                return;
            }

            // Set the security protocol to TLS 1.2.
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Standard winforms setup.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load custom fonts into memory.
            if (!TryLoadCustomFont(Properties.Resources.segmdl2, out Font[] fonts))
            {
                return;
            }

            // Assign loaded fonts to corresponding variables.
            FontSegMdl2Regular10 = fonts[0];
            FontSegMdl2Regular12 = fonts[1];
            FontSegMdl2Regular20 = fonts[2];

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
            FontSegMdl2Regular10?.Dispose();
            FontSegMdl2Regular12?.Dispose();
            FontSegMdl2Regular20?.Dispose();
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
            Exception ex = (Exception)e.ExceptionObject;

            if (ex != null)
            {
                ExceptionHandler(ex);
            }
        }

        internal static void ExceptionHandler(Exception e)
        {
            DialogResult dlgResult;

            string strWorkingDirectory = ApplicationPaths.WorkingDirectory;
            string strDatestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string strFilename = $"unhandled_{strDatestamp}.log";
            string strFinalPath = Path.Combine(strWorkingDirectory, strFilename);

            File.WriteAllText(strFinalPath, Unhandled.GenerateReport(e));

            if (File.Exists(strFinalPath))
            {
                dlgResult =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {strFinalPath.Replace(" ", Program.NOWRAP_SPACE)}" +
                        $"'\r\n\r\nForce quit application?",
                        $"MET Exception Handler",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }
            else
            {
                dlgResult =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{e}\r\n\r\nForce quit application?",
                        $"{e.GetType()}",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }

            if (dlgResult == DialogResult.Yes)
            {
                // We need to clean any necessary objects as OnExit will not fire when Environment.Exit is called.
                HandleOnExitingCleanup();
                Environment.Exit(-1);
            }

            BlurHelper.RemoveBlur(MainWindow);
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

            string strTitle = action ==
                ExitAction.Restart ? "Restart" : "Quit";

            string strMessage = action ==
                ExitAction.Restart
                    ? $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_RESTART}"
                    : $"{APPSTRINGS.FIRMWARE_WINDOWS_OPEN} {APPSTRINGS.QUESTION_EXIT}";

            if (ShowConfirmationDialog(owner, strTitle, strMessage))
            {
                ExecuteExitAction(action);
            }
        }

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
            DialogResult dlgResult =
                METPrompt.Show(
                    owner,
                    message,
                    METPromptType.Question,
                    METPromptButtons.YesNo);

            return dlgResult == DialogResult.Yes;
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

        private static bool IsSupportedOS()
        {
            if (SystemTools.GetKernelVersion.ProductMajorPart >= 10)
            {
                return true;
            }

            MessageBox.Show(
                DIALOGSTRINGS.REQUIRES_WIN_10,
                DIALOGSTRINGS.UNSUPPORTED_OS,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }

        private static bool TryLoadCustomFont(byte[] fontbuffer, out Font[] fonts)
        {
            fonts = null;

            if (fontbuffer == null)
            {
                return false;
            }

            try
            {
                FontFamily ffLoadFont = FontResolver.LoadFont(fontbuffer);

                fonts = new[]
                {
                    new Font(ffLoadFont, 10.0F, FontStyle.Regular),
                    new Font(ffLoadFont, 12.0F, FontStyle.Regular),
                    new Font(ffLoadFont, 20.0F, FontStyle.Regular)
                };

                return true;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(TryLoadCustomFont), e.GetType(), e.Message);
                return false;
            }
        }

        public static void HandleDragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] arrDraggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged.
                if (arrDraggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder.
                    string strFile = arrDraggedFiles[0];
                    FileAttributes fAttribues = File.GetAttributes(strFile);

                    // If it's a file (not a folder) then allow the copy operation.
                    if ((fAttribues & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            // Disable the drop operation.
            e.Effect = DragDropEffects.None;
        }

        internal static bool IsRunningUnderWine()
        {
            string strNtdll = "ntdll.dll";
            string strWineGetVersion = "wine_get_version";

            IntPtr ptrHandle = NativeMethods.LoadLibrary(strNtdll);
            if (ptrHandle == IntPtr.Zero)
            {
                return false;
            }

            IntPtr ptrWineHandle = NativeMethods.GetProcAddress(ptrHandle, strWineGetVersion);
            return ptrWineHandle != IntPtr.Zero; // If this function exists, we're running under Wine.
        }

        internal static async Task<VersionResult> CheckForNewVersion()
        {
            string strVersionManifest = ApplicationUrls.VersionManifest;
            string strNode = "data/MET/VersionString";

            try
            {
                using (WebClient wClient = new WebClient())
                {
                    byte[] bResponseData = await wClient.DownloadDataTaskAsync(strVersionManifest);

                    using (MemoryStream msResponseData = new MemoryStream(bResponseData))
                    using (XmlReader xmlReader = XmlReader.Create(msResponseData))
                    {
                        XmlDocument xmlDoc = new XmlDocument();

                        xmlDoc.Load(xmlReader);

                        XmlNode xmlNode = xmlDoc.SelectSingleNode(strNode);

                        if (xmlNode == null)
                        {
                            return VersionResult.Error;
                        }

                        Version verRemote = new Version(xmlNode.InnerText);
                        Version verLocal = new Version(Application.ProductVersion);

                        return verRemote > verLocal ? VersionResult.NewVersionAvailable : VersionResult.UpToDate;
                    }
                }
            }
            catch (Exception e)
            {
                if (!Program.IsDebugMode())
                {
                    Logger.WriteErrorLine(nameof(CheckForNewVersion), e.GetType(), e.Message);
                }

                return VersionResult.Error;
            }
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