// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Debug.cs - Debug string builder
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.EFI;
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
        internal static bool GetIsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        internal static bool IsElevated()
        {
            return new WindowsPrincipal(
                WindowsIdentity.GetCurrent()).IsInRole(
                    WindowsBuiltInRole.Administrator);
        }

        internal static string GetBitnessMode()
        {
            return IntPtr.Size == 8
                ? "x64"
                : "x86";
        }
        #endregion

        internal static string GenerateDebugReport(Exception e)
        {
            StringBuilder builder = new StringBuilder();

            string exePath =
                Path.Combine(
                    METPath.CurrentDirectory,
                    METPath.FriendlyName);

            try
            {
                byte[] appBytes =
                    File.ReadAllBytes(
                        exePath);

                builder.AppendLine($"# // Mac EFI Toolkit Debug Log - {DateTime.Now}\r\n");

                builder.AppendLine("<-- Application -->\r\n");
                builder.AppendLine($"Name:     {Application.ProductName}");
                builder.AppendLine($"Version:  {Application.ProductVersion}.{METVersion.Build}");
                builder.AppendLine($"LZMA SDK: {METVersion.SDK}");
                builder.AppendLine($"Channel:  {METVersion.Channel}");
                builder.AppendLine($"Mode:     {GetBitnessMode()}");
                builder.AppendLine($"Debug:    {GetIsDebugMode()}");
                builder.AppendLine($"Elevated: {IsElevated()}");
                builder.AppendLine($"SHA256:   {FileUtils.GetSha256Digest(appBytes)}\r\n");

                builder.AppendLine("<-- Operating System -->\r\n");
                builder.AppendLine($"Name:     {OSUtils.GetName}");
                builder.AppendLine($"Bitness:  {OSUtils.GetBitness()}");
                builder.AppendLine($"Kernel:   {OSUtils.GetKernelVersion.ProductVersion}\r\n");

                builder.AppendLine("<-- Fonts -->\r\n");
                builder.AppendLine($"Segoe UI Reg: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Regular)}");
                builder.AppendLine($"Segoe UI Bol: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Bold)}");
                builder.AppendLine($"Segoe UI Sem: {FontResolver.IsFontStyleAvailable("Segoe UI Semibold", FontStyle.Regular)}");
                builder.AppendLine($"Consolas Reg: {FontResolver.IsFontStyleAvailable("Consolas", FontStyle.Bold)}\r\n");

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
            if (!AppleEFI.FirmwareLoaded)
                return "There is no UEFI/BIOS loaded.\r\n";

            StringBuilder builder = new StringBuilder();

            try
            {
                if (IntelFD.IsDescriptorMode)
                {
                    builder.AppendLine($"  Descriptor ->\r\n");
                    builder.AppendLine($"Descriptor Mode: {IntelFD.IsDescriptorMode}\r\n");
                    builder.AppendLine($"PDR Base:  0x{IntelFD.PDR_REGION_BASE:X}h, PDR Limit: 0x{IntelFD.PDR_REGION_LIMIT:X}h");
                    builder.AppendLine($"ME Base:   0x{IntelFD.ME_REGION_BASE:X}h, ME Limit: 0x{IntelFD.ME_REGION_LIMIT:X}h");
                    builder.AppendLine($"BIOS Base: 0x{IntelFD.BIOS_REGION_BASE:X}h, BIOS Limit: 0x{IntelFD.BIOS_REGION_LIMIT:X}h\r\n");
                }

                builder.AppendLine($"  File ->\r\n");
                builder.AppendLine($"File Size: {AppleEFI.FileInfoData.Length:X}h\r\n");

                builder.AppendLine($"  Fsys Store  ->\r\n");
                builder.AppendLine($"Fsys Base:    0x{AppleEFI.FsysStoreData.FsysBase:X}h");
                builder.AppendLine($"Fsys Size:    {AppleEFI.FSYS_RGN_SIZE:X}h");
                builder.AppendLine($"Serial Base:  0x{AppleEFI.FsysStoreData.SerialBase:X}h");
                builder.AppendLine($"HWC Base:     0x{AppleEFI.FsysStoreData.HWCBase:X}h\r\n");

                builder.AppendLine($"  NVRAM  ->\r\n");
                builder.AppendLine($"NVRAM Region:  Base 0x{AppleEFI.NVRAM_BASE:X}h, Size {AppleEFI.NVRAM_SIZE:X}h");
                builder.AppendLine($"VSS Primary:   Base 0x{AppleEFI.VssStoreData.PrimaryStoreBase:X}h, Size {AppleEFI.VssStoreData.PrimaryStoreSize:X}h");
                builder.AppendLine($"VSS Backup:    Base 0x{AppleEFI.VssStoreData.BackupStoreBase:X}h, Size {AppleEFI.VssStoreData.BackupStoreSize:X}h");
                builder.AppendLine($"SVS Primary:   Base 0x{AppleEFI.SvsStoreData.PrimaryStoreBase:X}h, Size {AppleEFI.SvsStoreData.PrimaryStoreSize:X}h");
                builder.AppendLine($"SVS Backup:    Base 0x{AppleEFI.SvsStoreData.BackupStoreBase:X}h, Size {AppleEFI.SvsStoreData.BackupStoreSize:X}h");
                builder.AppendLine($"NSS Primary:   Base 0x{AppleEFI.NssStoreData.PrimaryStoreBase:X}h, Size {AppleEFI.NssStoreData.PrimaryStoreSize:X}h");
                builder.AppendLine($"NSS Backup:    Base 0x{AppleEFI.NssStoreData.BackupStoreBase:X}h, Size {AppleEFI.NssStoreData.BackupStoreSize:X}h");

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