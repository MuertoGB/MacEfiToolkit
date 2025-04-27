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

namespace Mac_EFI_Toolkit.Tools
{
    #region Enum
    enum FontStatus
    {
        Available,
        Missing,
        Unknown
    }
    #endregion

    internal class SystemTools
    {
        internal static string GetOperatingSystemName =>
            new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;

        internal static string GetOperatingSystemArchitecture(bool useshortstring = false) =>
            Environment.Is64BitOperatingSystem ? (useshortstring ? "x64" : "64-Bit") : (useshortstring ? "x86" : "32-Bit");

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "kernel32.dll"));

        internal static bool IsUserAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static string GetSystemArchitectureMode()
        {
            return IntPtr.Size == 8 ? "x64" : "x86";
        }

        internal static bool IsSupportedOS()
        {
            if (SystemTools.GetKernelVersion.ProductMajorPart >= 10)
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

        internal static bool IsRunningUnderWine()
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