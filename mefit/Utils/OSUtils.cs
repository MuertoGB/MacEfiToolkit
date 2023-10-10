// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// OSUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Mac_EFI_Toolkit.Utils
{

    #region Enum
    enum FontStatus
    {
        Available,
        Missing,
        Unknown
    }
    #endregion

    internal class OSUtils
    {

        internal static string GetName =>
            new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;

        internal static string GetBitness(bool shortString = false) =>
            Environment.Is64BitOperatingSystem
            ? (shortString ? "x64" : "64-Bit")
            : (shortString ? "x86" : "32-Bit");

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(
                Path.Combine(
                    Environment.SystemDirectory,
                    "kernel32.dll"));

        internal static FontStatus IsFontStyleAvailable(string fontFamily, FontStyle fontStyle)
        {
            try
            {
                using (FontFamily family = new FontFamily(fontFamily))
                    if (family.IsStyleAvailable(fontStyle))
                        return FontStatus.Available;
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return FontStatus.Unknown;
            }

            return FontStatus.Missing;
        }
    }
}