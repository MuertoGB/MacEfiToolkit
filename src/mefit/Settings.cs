// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Settings.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Mac_EFI_Toolkit
{
    public static class Settings
    {
        #region Enums
        public enum BooleanKey
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

        public enum StringKey
        {
            StartupInitialDirectory,
            EfiInitialDirectory,
            SocInitialDirectory
        }
        #endregion

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
        public static void Initialize()
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
            string defaultPath = ApplicationPaths.WorkingDirectory;

            // Define default values for application settings.
            Dictionary<string, string> defaultsValues = new Dictionary<string, string>
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
            EnsureKeysWithDefaults(inifile, SEC_APPLICATION, defaultsValues);
        }

        private static void EnsureKeysWithDefaults(IniFile inifile, string section, Dictionary<string, string> defaultValues)
        {
            foreach (KeyValuePair<string, string> defaultEntry in defaultValues)
            {
                if (!inifile.KeyExists(section, defaultEntry.Key))
                {
                    inifile.Write(section, defaultEntry.Key, defaultEntry.Value);
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
        public static bool ReadBoolean(BooleanKey booleanKey)
        {
            if (!SettingsFileExists())
            {
                return false;
            }

            string section, key;

            switch (booleanKey)
            {
                case BooleanKey.DisableVersionCheck:
                    section = SEC_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case BooleanKey.DisableFlashingUI:
                    section = SEC_APPLICATION; key = KEY_DISABLE_FLASHING_UI;
                    break;
                case BooleanKey.DisableMessageSounds:
                    section = SEC_APPLICATION; key = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case BooleanKey.DisableTips:
                    section = SEC_APPLICATION; key = KEY_DISABLE_TIPS;
                    break;
                case BooleanKey.DisableConfDiag:
                    section = SEC_APPLICATION; key = KEY_DISABLE_CONF_DIAG;
                    break;
                case BooleanKey.UseAccentColor:
                    section = SEC_APPLICATION; key = KEY_USE_ACCENT_COLOR;
                    break;
                case BooleanKey.DisableSerialValidation:
                    section = SEC_APPLICATION; key = KEY_DISABLE_SN_VALIDATION;
                    break;
                case BooleanKey.AcceptedEditingTerms:
                    section = SEC_FIRMWARE; key = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return false;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(section))
            {
                Logger.LogInfo($"{nameof(ReadBoolean)} Section '{section}' was missing and created automatically.");

                using (StreamWriter writer = new StreamWriter(ApplicationPaths.SettingsFile, true))
                {
                    writer.WriteLine($"[{section}]");
                }

                iniFile.Write(section, key, "False");

                return false;
            }

            if (!iniFile.KeyExists(section, key))
            {
                Logger.LogInfo($"{nameof(ReadBoolean)} Key '{key}' was missing and created automatically.");

                iniFile.Write(section, key, "False");

                return false;
            }

            return bool.Parse(iniFile.Read(section, key));
        }

        public static string ReadString(StringKey stringKey)
        {
            if (!SettingsFileExists())
            {
                return string.Empty;
            }

            string section, key;

            switch (stringKey)
            {
                case StringKey.StartupInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_STARTUP_INIT_DIR;
                    break;
                case StringKey.EfiInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_EFI_INIT_DIR;
                    break;
                case StringKey.SocInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return string.Empty;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(section))
            {
                Logger.LogInfo($"{nameof(ReadString)} Section '{section}' was missing and created automatically.");

                using (StreamWriter writer = new StreamWriter(ApplicationPaths.SettingsFile, true))
                {
                    writer.WriteLine($"[{section}]");
                }

                iniFile.Write(section, key, "False");

                return string.Empty;
            }

            if (!iniFile.KeyExists(section, key))
            {
                Logger.LogInfo($"{nameof(ReadString)} Key '{key}' was missing and created automatically.");

                iniFile.Write(section, key, "False");

                return string.Empty;
            }

            return iniFile.Read(section, key);
        }
        #endregion

        #region Write Values
        public static void SetBool(BooleanKey booleanKey, bool value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string section, key;

            switch (booleanKey)
            {
                case BooleanKey.DisableVersionCheck:
                    section = SEC_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case BooleanKey.DisableFlashingUI:
                    section = SEC_APPLICATION; key = KEY_DISABLE_FLASHING_UI;
                    break;
                case BooleanKey.DisableMessageSounds:
                    section = SEC_APPLICATION; key = KEY_DISABLE_MESSAGE_SOUNDS;
                    break;
                case BooleanKey.DisableTips:
                    section = SEC_APPLICATION; key = KEY_DISABLE_TIPS;
                    break;
                case BooleanKey.DisableConfDiag:
                    section = SEC_APPLICATION; key = KEY_DISABLE_CONF_DIAG;
                    break;
                case BooleanKey.UseAccentColor:
                    section = SEC_APPLICATION; key = KEY_USE_ACCENT_COLOR;
                    break;
                case BooleanKey.DisableSerialValidation:
                    section = SEC_APPLICATION; key = KEY_DISABLE_SN_VALIDATION;
                    break;
                case BooleanKey.AcceptedEditingTerms:
                    section = SEC_FIRMWARE; key = KEY_ACCEPTED_TERMS;
                    break;
                default:
                    return;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (iniFile.SectionExists(section))
            {
                if (iniFile.KeyExists(section, key))
                {
                    iniFile.Write(section, key, value.ToString());
                }
                else
                {
                    Logger.LogInfo($"{nameof(SetBool)} {section} > {key} > Key not found, setting was not written.");
                }
            }
        }

        public static void SetString(StringKey stringKey, string value)
        {
            if (!SettingsFileExists())
            {
                return;
            }

            string section, key;

            switch (stringKey)
            {
                case StringKey.StartupInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_STARTUP_INIT_DIR;
                    break;
                case StringKey.EfiInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_EFI_INIT_DIR;
                    break;
                case StringKey.SocInitialDirectory:
                    section = SEC_APPLICATION; key = KEY_SOC_INIT_DIR;
                    break;
                default:
                    return;
            }

            IniFile iniFile = new IniFile(ApplicationPaths.SettingsFile);

            if (!iniFile.SectionExists(section))
            {
                iniFile.Write(section, string.Empty, null);
            }

            if (iniFile.KeyExists(section, key))
            {
                iniFile.Write(section, key, value);
            }
            else
            {
                Logger.LogInfo($"{nameof(SetString)} {section} > {key} > Key not found, setting was not written.");
            }
        }
        #endregion

        #region Bools
        private static bool SettingsFileExists()
        {
            return File.Exists(ApplicationPaths.SettingsFile);
        }

        public static bool DeleteSettings()
        {
            try
            {
                File.Delete(ApplicationPaths.SettingsFile);
                return SettingsFileExists();
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(DeleteSettings));
                return false;
            }
        }
        #endregion
    }
}