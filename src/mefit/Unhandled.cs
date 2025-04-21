// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Unhandled.cs - Unhandled exception debug builder.
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    internal class Unhandled
    {
        internal static string GenerateReport(Exception unhandled)
        {
            StringBuilder builder = new StringBuilder();
            string appPath = Path.Combine(ApplicationPaths.WorkingDirectory, ApplicationPaths.FriendlyName);

            try
            {
                byte[] appBuffer = File.ReadAllBytes(appPath);

                builder.AppendLine($"Mac EFI Toolkit Unhandled Exception: {DateTime.Now}\r\n");
                builder.AppendLine("<== Application ==>\r\n");
                builder.AppendLine($"Name:     {Application.ProductName}");
                builder.AppendLine($"Version:  {Application.ProductVersion}.{ApplicationVersions.BUILD}");
                builder.AppendLine($"LZMA SDK: {ApplicationVersions.LZMA_SDK_VERSION}");
                builder.AppendLine($"Channel:  {ApplicationVersions.CHANNEL}");
                builder.AppendLine($"Mode:     {SystemTools.GetSystemArchitectureMode()}");
                builder.AppendLine($"Debug:    {Program.IsDebugMode()}");
                builder.AppendLine($"Elevated: {SystemTools.IsUserAdmin()}");
                builder.AppendLine($"SHA256:   {Cryptography.GetSha256Digest(appBuffer)}\r\n");
                builder.AppendLine("<== Operating System ==>\r\n");
                builder.AppendLine($"Name:     {SystemTools.GetOperatingSystemName}");
                builder.AppendLine($"Bitness:  {SystemTools.GetOperatingSystemArchitecture()}");
                builder.AppendLine($"Kernel:   {SystemTools.GetKernelVersion.ProductVersion}\r\n");
                builder.AppendLine("<== Fonts ==>\r\n");
                builder.AppendLine($"Segoe UI Reg: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Regular)}");
                builder.AppendLine($"Segoe UI Bol: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Bold)}");
                builder.AppendLine($"Segoe UI Sem: {FontResolver.IsFontStyleAvailable("Segoe UI Semibold", FontStyle.Regular)}");
                builder.AppendLine($"Consolas Reg: {FontResolver.IsFontStyleAvailable("Consolas", FontStyle.Bold)}\r\n");
                builder.AppendLine("<== Exception Data ==>\r\n");
                builder.AppendLine(GetExceptionData(unhandled));
                builder.AppendLine("<== Modules ==>\r\n");
                builder.AppendLine(GetProcessModules());
                builder.AppendLine("// End of file //");

                return builder.ToString();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GenerateReport), e.GetType(), e.Message);
                return null;
            }
        }

        private static string GetExceptionData(Exception e)
        {
            if (e == null)
            {
                return $"Exception data was null.\r\n";
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Message -->");
            builder.AppendLine($"{CensorUsernameInPath(e.Message)}\r\n");
            builder.AppendLine("Exception -->");

            // Process each line of the exception details separately
            foreach (string line in e.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
            {
                builder.AppendLine(CensorUsernameInPath(line));
            }

            return builder.ToString();
        }

        private static string GetProcessModules()
        {
            StringBuilder builder = new StringBuilder();
            int moduleNumber = 0;

            try
            {
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
                {
                    moduleNumber++;

                    string censoredPath = CensorUsernameInPath(module.FileName);

                    builder.AppendLine($"Module {moduleNumber}: --> '{module.ModuleName}'\r\n");
                    builder.AppendLine($" Path:         {censoredPath}");
                    builder.AppendLine($" Version:      {module.FileVersionInfo.FileVersion}");
                    builder.AppendLine($" Description:  {module.FileVersionInfo.FileDescription}");
                    builder.AppendLine($" Size (Bytes): {module.ModuleMemorySize}");
                    builder.AppendLine($" Base Address: {module.BaseAddress}");
                    builder.AppendLine($" Entry Point:  {module.EntryPointAddress}\r\n");
                }

                return builder.ToString();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetProcessModules), e.GetType(), e.Message);
                return null;
            }
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