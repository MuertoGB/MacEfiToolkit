// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
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
        #region Const Members
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
            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);
            WriteSections(iniFile);
            WriteStartupKeys(iniFile);
            WriteApplicationKeys(iniFile);
            WriteFirmwareKeys(iniFile);
        }

        #endregion

        #region Write Sections
        private static void WriteSections(IniFile inifile)
        {
            if (!inifile.SectionExists(SEC_STARTUP))
            {
                inifile.WriteSection(SEC_STARTUP);
            }

            if (!inifile.SectionExists(SEC_APPLICATION))
            {
                inifile.WriteSection(SEC_APPLICATION);
            }

            if (!inifile.SectionExists(SEC_FIRMWARE))
            {
                inifile.WriteSection(SEC_FIRMWARE);
            }
        }
        #endregion

        #region Write Keys
        private static void WriteStartupKeys(IniFile inifile)
        {
            if (!inifile.KeyExists(SEC_STARTUP, KEY_DISABLE_VERSION_CHECK))
            {
                inifile.Write(SEC_STARTUP, KEY_DISABLE_VERSION_CHECK, "False");
            }
        }

        private static void WriteApplicationKeys(IniFile inifile)
        {
            string strDefaultPath = ApplicationPaths.WorkingDirectory;

            // Define default values for application settings.
            Dictionary<string, string> dictDefaults = new Dictionary<string, string>
            {
                { KEY_USE_ACCENT_COLOR, "False" },
                { KEY_DISABLE_FLASHING_UI, "False" },
                { KEY_DISABLE_MESSAGE_SOUNDS, "False" },
                { KEY_DISABLE_TIPS, "False" },
                { KEY_DISABLE_CONF_DIAG, "False" },
                { KEY_DISABLE_SN_VALIDATION, "False"},
                { KEY_STARTUP_INIT_DIR, strDefaultPath },
                { KEY_EFI_INIT_DIR, strDefaultPath },
                { KEY_SOC_INIT_DIR, strDefaultPath }
            };

            // Apply application defaults.
            EnsureKeysWithDefaults(inifile, SEC_APPLICATION, dictDefaults);
        }

        private static void EnsureKeysWithDefaults(IniFile inifile, string section, Dictionary<string, string> dictdefault)
        {
            foreach (KeyValuePair<string, string> kvpDefaultEntry in dictdefault)
            {
                if (!inifile.KeyExists(section, kvpDefaultEntry.Key))
                {
                    inifile.Write(section, kvpDefaultEntry.Key, kvpDefaultEntry.Value);
                }
            }
        }

        private static void WriteFirmwareKeys(IniFile inifile)
        {
            if (!inifile.SectionExists(SEC_FIRMWARE) || !inifile.KeyExists(SEC_FIRMWARE, KEY_ACCEPTED_TERMS))
            {
                inifile.Write(SEC_FIRMWARE, KEY_ACCEPTED_TERMS, "False");
            }
        }
        #endregion

        #region Read Values
        internal static bool ReadBool(SettingsBoolType settingtype)
        {
            if (!SettingsFileExists())
            {
                return false;
            }

            string strSection, strKey;

            switch (settingtype)
            {
                case SettingsBoolType.DisableVersionCheck:
                    strSection = SEC_STARTUP; strKey = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_FLASHING_UI;
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case SettingsBoolType.DisableTips:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_TIPS;
                    break;
                case SettingsBoolType.DisableConfDiag:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_CONF_DIAG;
                    break;
                case SettingsBoolType.UseAccentColor:
                    strSection = SEC_APPLICATION; strKey = KEY_USE_ACCENT_COLOR;
                    break;
                case SettingsBoolType.DisableSerialValidation:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_SN_VALIDATION;
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    strSection = SEC_FIRMWARE; strKey = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return false;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(strSection))
            {
                Logger.WriteCallerLine($"{nameof(ReadBool)} Section '{strSection}' was missing and created automatically.");

                using (StreamWriter swSection = new StreamWriter(ApplicationPaths.SettingsFile, true))
                {
                    swSection.WriteLine($"[{strSection}]");
                }

                iniFile.Write(strSection, strKey, "False");

                return false;
            }

            if (!iniFile.KeyExists(strSection, strKey))
            {
                Logger.WriteCallerLine($"{nameof(ReadBool)} Key '{strKey}' was missing and created automatically.");

                iniFile.Write(strSection, strKey, "False");

                return false;
            }

            return bool.Parse(iniFile.Read(strSection, strKey));
        }

        internal static string ReadString(SettingsStringType settingType)
        {
            if (!SettingsFileExists())
            {
                return string.Empty;
            }

            string strSection, strKey;

            switch (settingType)
            {
                case SettingsStringType.StartupInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_STARTUP_INIT_DIR;
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_EFI_INIT_DIR;
                    break;
                case SettingsStringType.SocInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return string.Empty;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(strSection))
            {
                Logger.WriteCallerLine($"{nameof(ReadString)} Section '{strSection}' was missing and created automatically.");

                using (StreamWriter swSection = new StreamWriter(ApplicationPaths.SettingsFile, true))
                {
                    swSection.WriteLine($"[{strSection}]");
                }

                iniFile.Write(strSection, strKey, "False");

                return string.Empty;
            }

            if (!iniFile.KeyExists(strSection, strKey))
            {
                Logger.WriteCallerLine($"{nameof(ReadString)} Key '{strKey}' was missing and created automatically.");

                iniFile.Write(strSection, strKey, "False");

                return string.Empty;
            }

            return iniFile.Read(strSection, strKey);
        }
        #endregion

        #region Write Values
        internal static void SetBool(SettingsBoolType settingtype, bool value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string strSection, strKey;

            switch (settingtype)
            {
                case SettingsBoolType.DisableVersionCheck:
                    strSection = SEC_STARTUP; strKey = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_FLASHING_UI;
                    break;
                case SettingsBoolType.DisableMessageSounds:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case SettingsBoolType.DisableTips:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_TIPS;
                    break;
                case SettingsBoolType.DisableConfDiag:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_CONF_DIAG;
                    break;
                case SettingsBoolType.UseAccentColor:
                    strSection = SEC_APPLICATION; strKey = KEY_USE_ACCENT_COLOR;
                    break;
                case SettingsBoolType.DisableSerialValidation:
                    strSection = SEC_APPLICATION; strKey = KEY_DISABLE_SN_VALIDATION;
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    strSection = SEC_FIRMWARE; strKey = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (iniFile.SectionExists(strSection))
            {
                if (iniFile.KeyExists(strSection, strKey))
                {
                    iniFile.Write(strSection, strKey, value.ToString());
                }
                else
                {
                    Logger.WriteCallerLine($"{nameof(SetBool)} {strSection} > {strKey} > Key not found, setting was not written.");
                }
            }
        }

        internal static void SetString(SettingsStringType settingtype, string value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string strSection, strKey;

            switch (settingtype)
            {
                case SettingsStringType.StartupInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_STARTUP_INIT_DIR;
                    break;
                case SettingsStringType.EfiInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_EFI_INIT_DIR;
                    break;
                case SettingsStringType.SocInitialDirectory:
                    strSection = SEC_APPLICATION; strKey = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(strSection))
            {
                iniFile.Write(strSection, string.Empty, null);
            }

            if (iniFile.KeyExists(strSection, strKey))
            {
                iniFile.Write(strSection, strKey, value);
            }
            else
            {
                Logger.WriteCallerLine($"{nameof(SetString)} {strSection} > {strKey} > Key not found, setting was not written.");
            }
        }
        #endregion

        #region Bools
        private static bool SettingsFileExists()
        {
            return File.Exists(ApplicationPaths.SettingsFile);
        }

        internal static bool DeleteSettings()
        {
            try
            {
                File.Delete(ApplicationPaths.SettingsFile);
                return SettingsFileExists();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DeleteSettings), e.GetType(), e.Message);
                return false;
            }
        }
        #endregion

        #region Functions
        internal static Color GetBorderColorValue()
        {
            if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
            {
                return AccentColorHelper.GetSystemAccentColor();
            }

            return Colours.AppBorderDefault;
        }
        #endregion
    }
}