// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SystemTools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class SystemUtils
    {
        public static string GetOperatingSystemName
            => new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;

        public static string GetOperatingSystemArchitecture(bool useshortstring = false)
            => Environment.Is64BitOperatingSystem
            ? (useshortstring ? "x64" : "64-Bit")
            : (useshortstring ? "x86" : "32-Bit");

        public static FileVersionInfo GetKernelVersion
            => FileVersionInfo.GetVersionInfo(
                Path.Combine(Environment.SystemDirectory, "kernel32.dll"));

        public static bool IsUserAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static string GetSystemArchitectureMode()
        {
            return IntPtr.Size == 8 ? "x64" : "x86";
        }

        public static bool IsSupportedOS()
        {
            if (SystemUtils.GetKernelVersion.ProductMajorPart >= 10)
            {
                return true;
            }

            MessageBox.Show(
                DialogStrings.REQUIRES_WIN_10,
                DialogStrings.UNSUPPORTED_OS,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }

        public static bool IsRunningUnderWine()
        {
            string ntDll = "ntdll.dll";
            string wineGetVersion = "wine_get_version";
            IntPtr ptr = NativeMethods.LoadLibrary(ntDll);

            if (ptr == IntPtr.Zero)
            {
                return false;
            }

            IntPtr winePtr = NativeMethods.GetProcAddress(ptr, wineGetVersion);
            return winePtr != IntPtr.Zero; // If this function exists, we're running under Wine.
        }
    }
}