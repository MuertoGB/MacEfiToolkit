// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// ApplicationPaths.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;

namespace Mac_EFI_Toolkit.Common.Constants
{
    public static class ApplicationPaths
    {
        internal static readonly string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string BackupsDirectory = Path.Combine(WorkingDirectory, "backups");
        internal static readonly string BuildsDirectory = Path.Combine(WorkingDirectory, "builds");
        internal static readonly string FsysDirectory = Path.Combine(WorkingDirectory, "fsys_stores");
        internal static readonly string IntelMeDirectory = Path.Combine(WorkingDirectory, "me_regions");
        internal static readonly string NvramDirectory = Path.Combine(WorkingDirectory, "nvram_stores");
        internal static readonly string ScfgDirectory = Path.Combine(WorkingDirectory, "scfg_stores");
        internal static readonly string LzmaDirectory = Path.Combine(WorkingDirectory, "lzma_archives");
        internal static readonly string SettingsFile = Path.Combine(WorkingDirectory, "Settings.ini");
        internal static readonly string ApplicationLog = Path.Combine(WorkingDirectory, "application.log");
        internal static readonly string DatabaseLog = Path.Combine(WorkingDirectory, "database.log");
    }
}