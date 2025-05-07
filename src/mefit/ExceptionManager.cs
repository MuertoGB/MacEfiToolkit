// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// ExceptionManager.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utilities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public static class ExceptionManager
    {
        public static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e != null)
                HandleException(e.Exception);
        }

        public static void CurrentDomainException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception =
                (Exception)e.ExceptionObject;

            if (exception != null)
                HandleException(exception);
        }

        private static void HandleException(Exception e)
        {
            DialogResult result;

            string workingDirectory = ApplicationPaths.WorkingDirectory;
            string dateStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"unhandled_{dateStamp}.log";
            string fullPath = Path.Combine(workingDirectory, fileName);

            File.WriteAllText(fullPath, ExceptionManager.GenerateExceptionReport(e));

            if (File.Exists(fullPath))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {fullPath.Replace(" ", ApplicationChars.SEGUI_NOBREAKSPACE)}" +
                        $"'\r\n\r\nForce quit application?",
                        $"Exception Handler",
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

            Finalize(result);
        }

        private static void Finalize(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                // We need to clean any necessary objects as OnExit will not fire when Environment.Exit is called.
                Program.HandleOnExitingCleanup();
                Environment.Exit(-1);
            }

            // Fix to stop blur becoming stuck.
            Form mainWindow = Program.MainWindow;
            if (mainWindow != null)
            {
                BlurHelper.RemoveBlur(mainWindow);
            }
        }

        public static string GenerateExceptionReport(Exception exception)
        {
            StringBuilder builder = new StringBuilder();

            string appPath = Path.Combine(ApplicationPaths.WorkingDirectory, ApplicationPaths.FriendlyName);
            string sha256 = "Unavailable";

            try
            {
                byte[] appBuffer = File.ReadAllBytes(appPath);
                sha256 = Cryptography.GetSha256Digest(appBuffer);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, nameof(GenerateExceptionReport));
            }

            try
            {
                builder.AppendLine($"Mac EFI Toolkit Unhandled Exception Report");
                builder.AppendLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss zzz}\r\n");

                builder.AppendLine("--- Application Info ---\r\n");
                builder.AppendLine($"Name:     {Application.ProductName}");
                builder.AppendLine($"Version:  {Application.ProductVersion}.{ApplicationVersions.BUILD}");
                builder.AppendLine($"LZMA SDK: {ApplicationVersions.LZMA_SDK_VERSION}");
                builder.AppendLine($"Channel:  {ApplicationVersions.CHANNEL}");
                builder.AppendLine($"Mode:     {Program.BitnessMode()}");
                builder.AppendLine($"Debug:    {Program.IsDebugMode()}");
                builder.AppendLine($"Elevated: {SystemUtils.IsUserAdmin()}");
                builder.AppendLine($"SHA256:   {sha256}\r\n");

                builder.AppendLine("--- Operating System ---\r\n");
                builder.AppendLine($"Name:     {SystemUtils.GetOperatingSystemName()}");
                builder.AppendLine($"Edition:  {SystemUtils.GetWindowsEditionFromRegistry()}");
                builder.AppendLine($"Version:  {SystemUtils.GetOperatingSystemVersion()}");
                builder.AppendLine($"Bitness:  {SystemUtils.GetOperatingSystemArchitecture()}");
                builder.AppendLine($"Kernel:   {SystemUtils.GetKernelVersion.ProductVersion}");
                builder.AppendLine($"Locale:   {SystemUtils.GetSystemLocale()}\r\n");

                builder.AppendLine("--- Exception Data ---\r\n");
                builder.AppendLine(GetExceptionData(exception));

                builder.AppendLine("--- Loaded Modules ---\r\n");
                builder.AppendLine(GetProcessModuleData());

                builder.AppendLine("EOF");

                return builder.ToString();
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(GenerateExceptionReport));
                return null;
            }
        }

        private static string GetExceptionData(Exception e)
        {
            if (e == null)
                return "Exception data was null.\r\n";

            StringBuilder stringBuilder = new StringBuilder();
            int depth = 0;

            while (e != null)
            {
                string indent = depth == 0 ? "" : new string(' ', depth * 2);
                stringBuilder.AppendLine($"{indent}Exception Type: {e.GetType().FullName}");
                stringBuilder.AppendLine($"{indent}Message -->");
                stringBuilder.AppendLine($"{indent}{CensorUsernameInPath(e.Message)}");
                stringBuilder.AppendLine($"{indent}Stack Trace -->");

                foreach (string line in e.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
                {
                    stringBuilder.AppendLine($"{indent}{CensorUsernameInPath(line)}");
                }

                if (e.Data?.Count > 0)
                {
                    stringBuilder.AppendLine($"{indent}Data -->");
                    foreach (var key in e.Data.Keys)
                    {
                        stringBuilder.AppendLine($"{indent}  {key}: {e.Data[key]}");
                    }
                }

                e = e.InnerException;
                depth++;
                if (e != null)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine($"{indent}--- Inner Exception ---");
                }
            }

            return stringBuilder.ToString();
        }

        private static string GetProcessModuleData()
        {
            Process thisProcess = Process.GetCurrentProcess();
            StringBuilder stringBuilder = new StringBuilder();
            int moduleCount = 0;

            foreach (ProcessModule module in thisProcess.Modules)
            {
                try
                {
                    moduleCount++;

                    string censoredPath = CensorUsernameInPath(module.FileName);
                    string version = module.FileVersionInfo?.FileVersion ?? AppStrings.NA;
                    string description = module.FileVersionInfo?.FileDescription ?? AppStrings.NA;
                    string baseAddressHex = module.BaseAddress.ToInt64().ToString("X16");
                    string entryPointHex = module.EntryPointAddress.ToInt64().ToString("X16");

                    stringBuilder.AppendLine($"Module {moduleCount}: --> '{module.ModuleName}'");
                    stringBuilder.AppendLine($" Path:         {censoredPath}");
                    stringBuilder.AppendLine($" Version:      {version}");
                    stringBuilder.AppendLine($" Description:  {description}");
                    stringBuilder.AppendLine($" Size (Bytes): {module.ModuleMemorySize}");
                    stringBuilder.AppendLine($" Base Address: 0x{baseAddressHex}h");
                    stringBuilder.AppendLine($" Entry Point:  0x{entryPointHex}h\r\n");
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine($"[!] Failed to read module info: {ex.Message}\r\n");
                }
            }

            return stringBuilder.ToString();
        }

        private static string CensorUsernameInPath(string path)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string driveLetter = Regex.Escape(userPath.Substring(0, userPath.IndexOf("\\Users\\") + 1));
            string pattern = $@"({driveLetter}Users\\)([^\\]+)";

            return Regex.Replace(path, pattern, @"$1****", RegexOptions.IgnoreCase);
        }
    }
}