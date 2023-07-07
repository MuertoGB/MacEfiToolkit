// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Debug.cs - Debug string builder
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    internal class Debug
    {
        internal static string GenerateDebugReport(Exception e)
        {
            StringBuilder builder = new StringBuilder();
            byte[] appBytes = File.ReadAllBytes(METPath.FriendlyName);

            builder.AppendLine($"# // Mac EFI Toolkit Debug Log - {DateTime.Now}\r\n");

            builder.AppendLine("<-- Application -->\r\n");
            builder.AppendLine($"Name:     {Application.ProductName}");
            builder.AppendLine($"Version:  {Application.ProductVersion}.{METVersion.Build}");
            builder.AppendLine($"Channel:  {METVersion.Channel}");
            builder.AppendLine($"Mode:     {Program.BitnessMode()}");
            builder.AppendLine($"Debug:    {Program.IsDebugMode()}");
            builder.AppendLine($"Elevated: {Program.IsRunAsAdmin()}");
            builder.AppendLine($"SHA256:   {FileUtils.GetSha256Digest(appBytes)}\r\n");

            builder.AppendLine("<-- Operating System -->\r\n");
            builder.AppendLine($"Name:     {OSUtils.GetName}");
            builder.AppendLine($"Bitness:  {OSUtils.GetBitness()}");
            builder.AppendLine($"Kernel:   {OSUtils.GetKernelVersion.ProductVersion}\r\n");

            builder.AppendLine("<-- Fonts -->\r\n");
            builder.AppendLine($"Segoe UI Reg: {OSUtils.IsFontStyleAvailable("Segoe UI", FontStyle.Regular)}");
            builder.AppendLine($"Segoe UI Bol: {OSUtils.IsFontStyleAvailable("Segoe UI", FontStyle.Bold)}");
            builder.AppendLine($"Segoe UI Sem: {OSUtils.IsFontStyleAvailable("Segoe UI Semibold", FontStyle.Regular)}");
            builder.AppendLine($"Consolas Reg: {OSUtils.IsFontStyleAvailable("Consolas", FontStyle.Bold)}\r\n");

            builder.AppendLine("<-- Exception Data -->\r\n");
            builder.AppendLine(GetExceptionData(e));

            builder.AppendLine("<-- Firmware -->\r\n");
            builder.AppendLine(GetFirmwareData());

            builder.AppendLine("<-- Modules -->\r\n");
            builder.AppendLine(GetProcessModules());
            builder.AppendLine("# // End of file");

            return builder.ToString();
        }

        private static string GetExceptionData(Exception e)
        {
            if (e == null)
                return $"Exception data was null.\r\n";

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"  Message ->\r\n");
            builder.AppendLine($"{e.Message}\r\n");
            builder.AppendLine($"  Exception ->\r\n");
            builder.AppendLine($"{e}");

            return builder.ToString();
        }

        private static string GetFirmwareData()
        {
            if (!FWBase.FirmwareLoaded)
                return "There is no UEFI/BIOS loaded..\r\n";

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Des_Mode: {Descriptor.DescriptorMode}");

            if (Descriptor.DescriptorMode)
            {
                builder.AppendLine($"PDR:      {Descriptor.PdrBase:X2}h, {Descriptor.PdrLimit:X2}h");
                builder.AppendLine($"ME:       {Descriptor.MeBase:X2}h, {Descriptor.MeLimit:X2}h");
                builder.AppendLine($"BIOS:     {Descriptor.BiosBase:X2}h, {Descriptor.BiosLimit:X2}h");
            }

            return builder.ToString();
        }

        private static string GetProcessModules()
        {
            int moduleNumber = 0;
            StringBuilder builder = new StringBuilder();

            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                moduleNumber++;

                builder.AppendLine($"  Module #{moduleNumber} -> '{module.ModuleName}'\r\n");
                builder.AppendLine($"Path:         {module.FileName}");
                builder.AppendLine($"Version:      {module.FileVersionInfo.FileVersion}");
                builder.AppendLine($"Description:  {module.FileVersionInfo.FileDescription}");
                builder.AppendLine($"Size (Bytes): {module.ModuleMemorySize}");
                builder.AppendLine($"Base Address: {module.BaseAddress}");
                builder.AppendLine($"Entry Point:  {module.EntryPointAddress}\r\n");
            }

            return builder.ToString();
        }

    }
}