// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System.IO;

namespace Mac_EFI_Toolkit
{

    #region Enum
    public enum SettingsBoolType
    {
        DisableVersionCheck,
        DisableFlashingUI,
        DisableMessageSounds,
        DisableTips,
        DisableConfDiag,
        DisableLzmaFsSearch,
        AcceptedEditingTerms
    }

    public enum SettingsStringType
    {
        InitialDirectory
    }
    #endregion

    class Settings
    {

        #region Check File Exists
        private static bool GetSettingsFileExists()
        {
            return File.Exists(METPath.SettingsFile);
        }
        #endregion

        #region Create File
        internal static void SettingsCreateFile()
        {
            IniFile settingsIni =
                new IniFile
                (METPath.SettingsFile);

            settingsIni.Write(
                "Startup",
                "DisableVersionCheck",
                "False");

            settingsIni.Write(
                "Application",
                "DisableFlashingUI",
                "False");

            settingsIni.Write(
                "Application",
                "DisableMessageSounds",
                "False");

            settingsIni.Write(
                "Application",
                "DisableTips",
                "False");

            settingsIni.Write(
                "Application",
                "DisableConfDiag",
                "False");

            settingsIni.Write(
                "Application",
                "InitialOfdPath",
                METPath.CurrentDirectory);

            settingsIni.Write(
                "Firmware",
                "DisableLzmaFsSearch",
                "False");

            settingsIni.Write(
                "Firmware",
                "AcceptedEditingTerms",
                "False");
        }
        #endregion

        #region Get Values
        internal static bool SettingsGetBool(SettingsBoolType settingType)
        {
            if (!GetSettingsFileExists())
                return false;

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = "Startup"; key = "DisableVersionCheck";
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = "Application"; key = "DisableFlashingUI";
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    section = "Application"; key = "DisableMessageSounds";
                    break;
                case SettingsBoolType.DisableTips:
                    section = "Application"; key = "DisableTips";
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = "Application"; key = "DisableConfDiag";
                    break;
                case SettingsBoolType.DisableLzmaFsSearch:
                    section = "Firmware"; key = "DisableLzmaFsSearch";
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return false;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SettingsFile);

            if (!settingsIni.SectionExists(section))
            {
                Logger.WriteToLogFile(
                    $"SettingsGetBool: Section '{section}' was missing and created automatically.",
                    LogType.Application);

                using (StreamWriter writer = new StreamWriter(METPath.SettingsFile, true))
                    writer.WriteLine(
                        $"[{section}]");

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return false;
            }

            if (!settingsIni.KeyExists(section, key))
            {
                Logger.WriteToLogFile(
                    $"SettingsGetBool: Key '{key}' was missing and created automatically.",
                    LogType.Application);

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return false;
            }

            return bool.Parse(settingsIni.Read(section, key));
        }

        internal static string SettingsGetString(SettingsStringType settingType)
        {
            if (!GetSettingsFileExists())
                return string.Empty;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.InitialDirectory:
                    section = "Application"; key = "InitialOfdPath";
                    break;
                default:
                    return string.Empty;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SettingsFile);

            if (!settingsIni.SectionExists(section))
            {
                Logger.WriteToLogFile(
                    $"SettingsGetString: Section '{section}' was missing and created automatically.",
                    LogType.Application);

                using (StreamWriter writer = new StreamWriter(METPath.SettingsFile, true))
                {
                    writer.WriteLine(
                        $"[{section}]");
                }

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return string.Empty;
            }

            if (!settingsIni.KeyExists(section, key))
            {
                Logger.WriteToLogFile(
                    $"SettingsGetString: Key '{key}' was missing and created automatically.",
                    LogType.Application);

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return string.Empty;
            }

            return settingsIni.Read(section, key);
        }
        #endregion

        #region Set Values
        internal static void SettingsSetBool(SettingsBoolType settingType, bool value)
        {
            if (!GetSettingsFileExists())
                return;

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = "Startup"; key = "DisableVersionCheck";
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = "Application"; key = "DisableFlashingUI";
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    section = "Application"; key = "DisableMessageSounds";
                    break;
                case SettingsBoolType.DisableTips:
                    section = "Application"; key = "DisableTips";
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = "Application"; key = "DisableConfDiag";
                    break;
                case SettingsBoolType.DisableLzmaFsSearch:
                    section = "Firmware"; key = "DisableLzmaFsSearch";
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SettingsFile);

            if (settingsIni.SectionExists(section))
            {
                if (settingsIni.KeyExists(section, key))
                {
                    settingsIni.Write(
                        section,
                        key,
                        value.ToString());
                }
                else
                {
                    Logger.WriteToLogFile(
                        $"{section} > {key} > Key not found, setting was not written.",
                        LogType.Application);
                }
            }
        }

        internal static void SettingsSetString(SettingsStringType settingType, string value)
        {
            if (!GetSettingsFileExists())
                return;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.InitialDirectory:
                    section = "Application"; key = "InitialOfdPath";
                    break;
                default:
                    return;
            }

            IniFile ini =
                new IniFile(
                    METPath.SettingsFile);

            if (!ini.SectionExists(section))
                ini.Write(
                    section,
                    string.Empty,
                    null);

            if (ini.KeyExists(section, key))
            {
                ini.Write(
                    section,
                    key,
                    value);
            }
            else
            {
                Logger.WriteToLogFile(
                    $"{section} > {key} > Key not found, setting was not written.",
                    LogType.Application);
            }

        }
        #endregion

    }
}