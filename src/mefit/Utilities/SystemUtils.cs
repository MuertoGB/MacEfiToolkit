// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SystemUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.WIN32;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class SystemUtils
    {
        public static string GetOperatingSystemName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Environment.OSVersion.Version.Major == 10)
                {
                    if (Environment.OSVersion.Version.Build >= 22000)
                    {
                        return "Windows 11";
                    }
                    else
                    {
                        return "Windows 10";
                    }
                }
                else
                {
                    return "Windows (Other)";
                }
            }
            else
            {
                return "Non-Windows OS";
            }
        }

        public static string GetOperatingSystemVersion()
        {
            Version version = Environment.OSVersion.Version;
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public static string GetWindowsEditionFromRegistry()
        {
            string unknownEdition = "Unknown Edition";

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        object editionId = key.GetValue("EditionID");

                        if (editionId != null)
                        {
                            return editionId.ToString();
                        }

                        object productName = key.GetValue("ProductName");

                        if (productName != null)
                        {
                            return productName.ToString();
                        }
                    }
                }
            }
            catch
            {
                return unknownEdition;
            }

            return unknownEdition;
        }

        public static string GetSystemLocale()
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            return cultureInfo.Name;
        }

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