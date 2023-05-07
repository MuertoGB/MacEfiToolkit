// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Core;
using System;
using System.IO;
using System.Reflection;

namespace Mac_EFI_Toolkit
{
    class Settings
    {
        internal static string settingsFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Settings.ini");

        internal static void CreateSettingsFile()
        {
            var ini = new IniFile(settingsFilePath);
            ini.Write("Startup", "CheckForNewVersion", "0");
            ini.Write("Config", "InitialDirectory", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}