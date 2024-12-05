// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Unhandled.cs - Unhandled exception debug builder.
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
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
            StringBuilder sbReport = new StringBuilder();
            string strAppPath = Path.Combine(ApplicationPaths.WorkingDirectory, ApplicationPaths.FriendlyName);

            try
            {
                byte[] appBytes = File.ReadAllBytes(strAppPath);

                sbReport.AppendLine($"Mac EFI Toolkit Unhandled Exception: {DateTime.Now}\r\n");
                sbReport.AppendLine("<== Application ==>\r\n");
                sbReport.AppendLine($"Name:     {Application.ProductName}");
                sbReport.AppendLine($"Version:  {Application.ProductVersion}.{ApplicationVersions.CURRENT_BUILD}");
                sbReport.AppendLine($"LZMA SDK: {ApplicationVersions.LZMA_SDK_VERSION}");
                sbReport.AppendLine($"Channel:  {ApplicationVersions.CURRENT_CHANNEL}");
                sbReport.AppendLine($"Mode:     {SystemTools.GetSystemArchitectureMode()}");
                sbReport.AppendLine($"Debug:    {Program.IsDebugMode()}");
                sbReport.AppendLine($"Elevated: {SystemTools.IsUserAdmin()}");
                sbReport.AppendLine($"SHA256:   {FileTools.GetSha256Digest(appBytes)}\r\n");
                sbReport.AppendLine("<== Operating System ==>\r\n");
                sbReport.AppendLine($"Name:     {SystemTools.GetOperatingSystemName}");
                sbReport.AppendLine($"Bitness:  {SystemTools.GetOperatingSystemArchitecture()}");
                sbReport.AppendLine($"Kernel:   {SystemTools.GetKernelVersion.ProductVersion}\r\n");
                sbReport.AppendLine("<== Fonts ==>\r\n");
                sbReport.AppendLine($"Segoe UI Reg: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Regular)}");
                sbReport.AppendLine($"Segoe UI Bol: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Bold)}");
                sbReport.AppendLine($"Segoe UI Sem: {FontResolver.IsFontStyleAvailable("Segoe UI Semibold", FontStyle.Regular)}");
                sbReport.AppendLine($"Consolas Reg: {FontResolver.IsFontStyleAvailable("Consolas", FontStyle.Bold)}\r\n");
                sbReport.AppendLine("<== Exception Data ==>\r\n");
                sbReport.AppendLine(GetExceptionData(unhandled));
                sbReport.AppendLine("<== Modules ==>\r\n");
                sbReport.AppendLine(GetProcessModules());
                sbReport.AppendLine("// End of file //");

                return sbReport.ToString();
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

            StringBuilder sbException = new StringBuilder();
            sbException.AppendLine("Message -->");
            sbException.AppendLine($"{CensorUsernameInPath(e.Message)}\r\n");
            sbException.AppendLine("Exception -->");

            // Process each line of the exception details separately
            foreach (string strLine in e.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
            {
                sbException.AppendLine(CensorUsernameInPath(strLine));
            }

            return sbException.ToString();
        }

        private static string GetProcessModules()
        {
            StringBuilder sbModules = new StringBuilder();
            int iModule = 0;

            try
            {
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
                {
                    iModule++;

                    string strCensoredPath = CensorUsernameInPath(module.FileName);

                    sbModules.AppendLine($"Module {iModule}: --> '{module.ModuleName}'\r\n");
                    sbModules.AppendLine($" Path:         {strCensoredPath}");
                    sbModules.AppendLine($" Version:      {module.FileVersionInfo.FileVersion}");
                    sbModules.AppendLine($" Description:  {module.FileVersionInfo.FileDescription}");
                    sbModules.AppendLine($" Size (Bytes): {module.ModuleMemorySize}");
                    sbModules.AppendLine($" Base Address: {module.BaseAddress}");
                    sbModules.AppendLine($" Entry Point:  {module.EntryPointAddress}\r\n");
                }

                return sbModules.ToString();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetProcessModules), e.GetType(), e.Message);
                return null;
            }
        }

        private static string CensorUsernameInPath(string path)
        {
            string strUserProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string strDriveLetter = Regex.Escape(strUserProfilePath.Substring(0, strUserProfilePath.IndexOf("\\Users\\") + 1));
            string strPathPattern = $@"({strDriveLetter}Users\\)([^\\]+)";

            return Regex.Replace(path, strPathPattern, @"$1****", RegexOptions.IgnoreCase);
        }
    }
}