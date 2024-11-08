// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Mac_EFI_Toolkit
{
    #region Enum
    public enum SettingsBoolType
    {
        DisableVersionCheck,
        UseAccentColor,
        DisableFlashingUI,
        DisableMessageSounds,
        DisableTips,
        DisableConfDiag,
        DisableSerialValidation,
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
        private const string SEC_STARTUP = "Startup";
        private const string KEY_DISABLE_VERSION_CHECK = "DisableVersionCheck";

        private const string SEC_APPLICATION = "Application";
        private const string KEY_USE_ACCENT_COLOR = "UseAccentColor";
        private const string KEY_DISABLE_FLASHING_UI = "DisableFlashingUI";
        private const string KEY_DISABLE_MESSAGE_SOUNDS = "DisableMessageSounds";
        private const string KEY_DISABLE_TIPS = "DisableTips";
        private const string KEY_DISABLE_CONF_DIAG = "DisableConfDiag";
        private const string KEY_DISABLE_SN_VALIDATION = "DisableSerialValidation";
        private const string KEY_STARTUP_INIT_DIR = "StartupInitialPath";
        private const string KEY_EFI_INIT_DIR = "EfiInitialPath";
        private const string KEY_SOC_INIT_DIR = "SocInitialPath";

        private const string SEC_FIRMWARE = "Firmware";
        private const string KEY_ACCEPTED_TERMS = "AcceptedEditingTerms";
        #endregion

        #region Initialize
        internal static void Initialize()
        {
            IniFile ini = new IniFile(METPath.SETTINGS_FILE);

            WriteSections(ini);
            WriteStartupKeys(ini);
            WriteApplicationKeys(ini);
            WriteFirmwareKeys(ini);
        }

        #endregion

        #region Write Sections
        private static void WriteSections(IniFile ini)
        {
            if (!ini.SectionExists(SEC_STARTUP))
            {
                ini.WriteSection(SEC_STARTUP);
            }
            if (!ini.SectionExists(SEC_APPLICATION))
            {
                ini.WriteSection(SEC_APPLICATION);
            }
            if (!ini.SectionExists(SEC_FIRMWARE))
            {
                ini.WriteSection(SEC_FIRMWARE);
            }
        }
        #endregion

        #region Write Keys
        private static void WriteStartupKeys(IniFile ini)
        {
            if (!ini.KeyExists(SEC_STARTUP, KEY_DISABLE_VERSION_CHECK))
            {
                ini.Write(SEC_STARTUP, KEY_DISABLE_VERSION_CHECK, "False");
            }
        }

        private static void WriteApplicationKeys(IniFile ini)
        {
            string defaultPath = METPath.WORKING_DIR;

            // Define default values for application settings.
            var applicationDefaults = new Dictionary<string, string>
            {
                { KEY_USE_ACCENT_COLOR, "False" },
                { KEY_DISABLE_FLASHING_UI, "False" },
                { KEY_DISABLE_MESSAGE_SOUNDS, "False" },
                { KEY_DISABLE_TIPS, "False" },
                { KEY_DISABLE_CONF_DIAG, "False" },
                { KEY_DISABLE_SN_VALIDATION, "False"},
                { KEY_STARTUP_INIT_DIR, defaultPath },
                { KEY_EFI_INIT_DIR, defaultPath },
                { KEY_SOC_INIT_DIR, defaultPath }
            };

            // Apply application defaults.
            EnsureKeysWithDefaults(ini, SEC_APPLICATION, applicationDefaults);
        }

        private static void EnsureKeysWithDefaults(IniFile ini, string section, Dictionary<string, string> defaults)
        {
            foreach (var entry in defaults)
            {
                if (!ini.KeyExists(section, entry.Key))
                {
                    ini.Write(section, entry.Key, entry.Value);
                }
            }
        }

        private static void WriteFirmwareKeys(IniFile ini)
        {
            if (!ini.SectionExists(SEC_FIRMWARE) || !ini.KeyExists(SEC_FIRMWARE, KEY_ACCEPTED_TERMS))
            {
                ini.Write(SEC_FIRMWARE, KEY_ACCEPTED_TERMS, "False");
            }
        }
        #endregion

        #region Read Values
        internal static bool ReadBool(SettingsBoolType settingType)
        {
            if (!SettingsFileExists())
            {
                return false;
            }

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = SEC_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = SEC_APPLICATION; key = KEY_DISABLE_FLASHING_UI;
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    section = SEC_APPLICATION; key = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case SettingsBoolType.DisableTips:
                    section = SEC_APPLICATION; key = KEY_DISABLE_TIPS;
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = SEC_APPLICATION; key = KEY_DISABLE_CONF_DIAG;
                    break;
                case SettingsBoolType.UseAccentColor:
                    section = SEC_APPLICATION; key = KEY_USE_ACCENT_COLOR;
                    break;
                case SettingsBoolType.DisableSerialValidation:
                    section = SEC_APPLICATION; key = KEY_DISABLE_SN_VALIDATION;
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = SEC_FIRMWARE; key = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return false;
            }

            IniFile settingsIni = new IniFile(METPath.SETTINGS_FILE);

            if (!settingsIni.SectionExists(section))
            {
                Logger.Write(
                    $"SettingsGetBool: Section '{section}' was missing and created automatically.",
                    LogType.Application);

                using (StreamWriter writer = new StreamWriter(METPath.SETTINGS_FILE, true))
                {
                    writer.WriteLine($"[{section}]");
                }

                settingsIni.Write(section, key, "False");

                return false;
            }

            if (!settingsIni.KeyExists(section, key))
            {
                Logger.Write(
                    $"ReadBool (Settings): Key '{key}' was missing and created automatically.",
                    LogType.Application);

                settingsIni.Write(section, key, "False");

                return false;
            }

            return bool.Parse(settingsIni.Read(section, key));
        }

        internal static string ReadString(SettingsStringType settingType)
        {
            if (!SettingsFileExists())
            {
                return string.Empty;
            }

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.StartupInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_STARTUP_INIT_DIR;
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_EFI_INIT_DIR;
                    break;
                case SettingsStringType.SocInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return string.Empty;
            }

            IniFile settingsIni = new IniFile(METPath.SETTINGS_FILE);

            if (!settingsIni.SectionExists(section))
            {
                Logger.Write(
                    $"ReadString (Settings): Section '{section}' was missing and created automatically.",
                    LogType.Application);

                using (StreamWriter writer = new StreamWriter(METPath.SETTINGS_FILE, true))
                {
                    writer.WriteLine($"[{section}]");
                }

                settingsIni.Write(section, key, "False");

                return string.Empty;
            }

            if (!settingsIni.KeyExists(section, key))
            {
                Logger.Write(
                    $"ReadString (Settings): Key '{key}' was missing and created automatically.",
                    LogType.Application);

                settingsIni.Write(section, key, "False");

                return string.Empty;
            }

            return settingsIni.Read(section, key);
        }
        #endregion

        #region Write Values
        internal static void SetBool(SettingsBoolType settingType, bool value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = SEC_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = SEC_APPLICATION; key = KEY_DISABLE_FLASHING_UI;
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    section = SEC_APPLICATION; key = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case SettingsBoolType.DisableTips:
                    section = SEC_APPLICATION; key = KEY_DISABLE_TIPS;
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = SEC_APPLICATION; key = KEY_DISABLE_CONF_DIAG;
                    break;
                case SettingsBoolType.UseAccentColor:
                    section = SEC_APPLICATION; key = KEY_USE_ACCENT_COLOR;
                    break;
                case SettingsBoolType.DisableSerialValidation:
                    section = SEC_APPLICATION; key = KEY_DISABLE_SN_VALIDATION;
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = SEC_FIRMWARE; key = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return;
            }

            IniFile settingsIni = new IniFile(METPath.SETTINGS_FILE);

            if (settingsIni.SectionExists(section))
            {
                if (settingsIni.KeyExists(section, key))
                {
                    settingsIni.Write(section, key, value.ToString());
                }
                else
                {
                    Logger.Write(
                        $" SetBool (Settings): {section} > {key} > Key not found, setting was not written.",
                        LogType.Application);
                }
            }
        }

        internal static void SetString(SettingsStringType settingType, string value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.StartupInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_STARTUP_INIT_DIR;
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_EFI_INIT_DIR;
                    break;
                case SettingsStringType.SocInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return;
            }

            IniFile ini = new IniFile(METPath.SETTINGS_FILE);

            if (!ini.SectionExists(section))
            {
                ini.Write(section, string.Empty, null);
            }

            if (ini.KeyExists(section, key))
            {
                ini.Write(section, key, value);
            }
            else
            {
                Logger.Write(
                    $"SetString (Settings): {section} > {key} > Key not found, setting was not written.",
                    LogType.Application);
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
                File.Delete(METPath.SETTINGS_FILE);
                return SettingsFileExists();
            }
            catch (Exception e)
            {
                Logger.WriteError(nameof(Delete), e.GetType(), e.Message);
                return false;
            }
        }
        #endregion

        #region Functions
        internal static Color GetBorderColor()
        {
            if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
            {
                return AccentColorHelper.GetWindowsAccentColor();
            }

            return AppColours.DEFAULT_APP_BORDER;
        }
        #endregion
    }
}