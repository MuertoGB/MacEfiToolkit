// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SystemTools.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

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
        internal static string GetName =>
            new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;

        internal static string GetBitness(bool useshortstring = false) =>
            Environment.Is64BitOperatingSystem ? (useshortstring ? "x64" : "64-Bit") : (useshortstring ? "x86" : "32-Bit");

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "kernel32.dll"));

        internal static bool GetIsElevated()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static string GetSystemBitnessMode()
        {
            return IntPtr.Size == 8 ? "x64" : "x86";
        }
    }
}