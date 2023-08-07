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
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    internal class Debug
    {

        #region Functions
        internal static bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        internal static bool IsRunAsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static string BitnessMode()
        {
            return IntPtr.Size == 8 ? "x64" : "x86";
        }
        #endregion

        internal static string GenerateDebugReport(Exception e)
        {
            StringBuilder builder = new StringBuilder();
            string exePath = Path.Combine(METPath.CurrentDirectory, METPath.FriendlyName);

            try
            {
                byte[] appBytes = File.ReadAllBytes(exePath);

                builder.AppendLine($"# // Mac EFI Toolkit Debug Log - {DateTime.Now}\r\n");

                builder.AppendLine("<-- Application -->\r\n");
                builder.AppendLine($"Name:     {Application.ProductName}");
                builder.AppendLine($"Version:  {Application.ProductVersion}.{METVersion.Build}");
                builder.AppendLine($"Channel:  {METVersion.Channel}");
                builder.AppendLine($"Mode:     {BitnessMode()}");
                builder.AppendLine($"Debug:    {IsDebugMode()}");
                builder.AppendLine($"Elevated: {IsRunAsAdmin()}");
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
            catch (Exception ex)
            {
                Logger.WriteExceptionToAppLog(ex);
                return null;
            }
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
                return "There is no UEFI/BIOS loaded.\r\n";

            StringBuilder builder = new StringBuilder();

            try
            {
                if (Descriptor.DescriptorMode)
                {
                    builder.AppendLine($"  Descriptor ->\r\n");
                    builder.AppendLine($"Des_Mode: {Descriptor.DescriptorMode}");
                    builder.AppendLine($"PDR:      {Descriptor.PdrBase:X2}h, {Descriptor.PdrLimit:X2}h");
                    builder.AppendLine($"ME:       {Descriptor.MeBase:X2}h, {Descriptor.MeLimit:X2}h");
                    builder.AppendLine($"BIOS:     {Descriptor.BiosBase:X2}h, {Descriptor.BiosLimit:X2}h\r\n");
                }

                builder.AppendLine($"  File ->\r\n");
                builder.AppendLine($"File Size: {FWBase.FileInfoData.FileLength:X2}h\r\n");

                builder.AppendLine($"  Fsys Store  ->\r\n");
                builder.AppendLine($"Fsys Base:   {FWBase.FsysStoreData.FsysBase:X2}h");
                builder.AppendLine($"Serial Base: {FWBase.FsysStoreData.SerialBase:X2}h");
                builder.AppendLine($"HWC Base:    {FWBase.FsysStoreData.HWCBase:X2}h\r\n");

                builder.AppendLine($"  NVRAM  ->\r\n");
                builder.AppendLine($"VSS Primary: Base {FWBase.VssStoreData.PrimaryStoreBase:X2}h, Size {FWBase.VssStoreData.PrimaryStoreSize:X2}h");
                builder.AppendLine($"VSS Backup:  Base {FWBase.VssStoreData.BackupStoreBase:X2}h, Size {FWBase.VssStoreData.BackupStoreSize:X2}h");
                builder.AppendLine($"SVS Primary: Base {FWBase.SvsStoreData.PrimaryStoreBase:X2}h, Size {FWBase.SvsStoreData.PrimaryStoreSize:X2}h");
                builder.AppendLine($"SVS Backup:  Base {FWBase.SvsStoreData.BackupStoreBase:X2}h, Size {FWBase.SvsStoreData.BackupStoreSize:X2}h");
                builder.AppendLine($"NSS Primary: Base {FWBase.NssStoreData.PrimaryStoreBase:X2}h, Size {FWBase.NssStoreData.PrimaryStoreSize:X2}h");
                builder.AppendLine($"NSS Backup:  Base {FWBase.NssStoreData.BackupStoreBase:X2}h, Size {FWBase.NssStoreData.BackupStoreSize:X2}h");

                return builder.ToString();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }

        private static string GetProcessModules()
        {
            int moduleNumber = 0;
            StringBuilder builder = new StringBuilder();

            try
            {
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
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }

    }
}