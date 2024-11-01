// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System;
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
        AcceptedEditingTerms
    }

    public enum SettingsStringType
    {
        StartupInitialDirectory,
        EfiInitialDirectory,
        SocInitialDirectory
    }
    #endregion

    class Settings
    {

        #region Private Members
        private const string SECT_STARTUP = "Startup";
        private const string KEY_DISABLE_VERSION_CHECK = "DisableVersionCheck";

        private const string SECT_APPLICATION = "Application";

        private const string SECT_FIRMWARE = "Firmware";
        #endregion

        #region Initialize
        internal static void Initialize()
        {
            IniFile ini =
                new IniFile(METPath.SETTINGS_FILE);

            WriteSections(ini);

            WriteStartupKeys(ini);

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "DisableFlashingUI"))
            {
                ini.Write("Application", "DisableFlashingUI", "False");
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "DisableMessageSounds"))
            {
                ini.Write("Application", "DisableMessageSounds", "False");
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "DisableTips"))
            {
                ini.Write("Application", "DisableTips", "False");
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "DisableConfDiag"))
            {
                ini.Write("Application", "DisableConfDiag", "False");
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "StartupInitialPath"))
            {
                ini.Write("Application", "StartupInitialPath", METPath.WORKING_DIR);
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "EfiInitialPath"))
            {
                ini.Write("Application", "EfiInitialPath", METPath.WORKING_DIR);
            }

            if (!ini.SectionExists("Application") || !ini.KeyExists("Application", "SocInitialPath"))
            {
                ini.Write("Application", "SocInitialPath", METPath.WORKING_DIR);
            }

            if (!ini.SectionExists("Firmware") || !ini.KeyExists("Firmware", "AcceptedEditingTerms"))
            {
                ini.Write("Firmware", "AcceptedEditingTerms", "False");
            }
        }

        #endregion

        #region Write Sections
        private static void WriteSections(IniFile ini)
        {
            if (!ini.SectionExists(SECT_STARTUP))
                ini.WriteSection(SECT_STARTUP);

            if (!ini.SectionExists(SECT_APPLICATION))
                ini.WriteSection(SECT_APPLICATION);

            if (!ini.SectionExists(SECT_FIRMWARE))
                ini.WriteSection(SECT_FIRMWARE);
        }
        #endregion

        #region Write Keys
        private static void WriteStartupKeys(IniFile ini)
        {
            if (!ini.KeyExists(SECT_STARTUP, KEY_DISABLE_VERSION_CHECK))
                ini.Write(SECT_STARTUP, KEY_DISABLE_VERSION_CHECK, "False");
        }
        #endregion

        #region Read Values
        internal static bool ReadBool(SettingsBoolType settingType)
        {
            if (!SettingsFileExists())
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
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return false;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SETTINGS_FILE);

            if (!settingsIni.SectionExists(section))
            {
                Logger.WriteToAppLog(
                    $"SettingsGetBool: Section '{section}' was missing and created automatically.");

                using (StreamWriter writer = new StreamWriter(METPath.SETTINGS_FILE, true))
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
                Logger.WriteToAppLog(
                    $"ReadBool (Settings): Key '{key}' was missing and created automatically.");

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return false;
            }

            return bool.Parse(settingsIni.Read(section, key));
        }

        internal static string ReadString(SettingsStringType settingType)
        {
            if (!SettingsFileExists())
                return string.Empty;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.StartupInitialDirectory:
                    section = "Application"; key = "StartupInitialPath";
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    section = "Application"; key = "EfiInitialPath";
                    break;
                case SettingsStringType.SocInitialDirectory:
                    section = "Application"; key = "SocInitialPath";
                    break;
                default:
                    return string.Empty;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SETTINGS_FILE);

            if (!settingsIni.SectionExists(section))
            {
                Logger.WriteToAppLog(
                    $"ReadString (Settings): Section '{section}' was missing and created automatically.");

                using (StreamWriter writer = new StreamWriter(METPath.SETTINGS_FILE, true))
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
                Logger.WriteToAppLog(
                    $"ReadString (Settings): Key '{key}' was missing and created automatically.");

                settingsIni.Write(
                    section,
                    key,
                    "False");

                return string.Empty;
            }

            return settingsIni.Read(section, key);
        }
        #endregion

        #region Write Values
        internal static void SetBool(SettingsBoolType settingType, bool value)
        {
            if (!SettingsFileExists())
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
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return;
            }

            IniFile settingsIni =
                new IniFile(
                    METPath.SETTINGS_FILE);

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
                    Logger.WriteToAppLog(
                        $" SetBool (Settings): {section} > {key} > Key not found, setting was not written.");
                }
            }
        }

        internal static void SetString(SettingsStringType settingType, string value)
        {
            if (!SettingsFileExists())
                return;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.StartupInitialDirectory:
                    section = "Application"; key = "StartupInitialPath";
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    section = "Application"; key = "EfiInitialPath";
                    break;
                case SettingsStringType.SocInitialDirectory:
                    section = "Application"; key = "SocInitialPath";
                    break;
                default:
                    return;
            }

            IniFile ini =
                new IniFile(
                    METPath.SETTINGS_FILE);

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
                Logger.WriteToAppLog(
                    $"SetString (Settings): {section} > {key} > Key not found, setting was not written.");
            }

        }
        #endregion

        #region Bools
        private static bool SettingsFileExists()
        {
            return File.Exists(METPath.SETTINGS_FILE);
        }

        internal static bool Delete()
        {
            try
            {
                File.Delete(
                    METPath.SETTINGS_FILE);

                return SettingsFileExists();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);

                return false;
            }
        }
        #endregion

    }
}