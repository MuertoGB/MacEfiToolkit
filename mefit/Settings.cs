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
        DisableConfDiag,
        DisableLzmaFsSearch,
        DisableFsysEnforce,
        DisableDescriptorEnforce,
        AcceptedEditingTerms
    }

    public enum SettingsStringType
    {
        InitialDirectory
    }
    #endregion

    class Settings
    {
        internal static string strSettingsFilePath = Path.Combine(Program.strAppPath, "Settings.ini");
        internal static string strDefaultOfdPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        #region Check File Exists
        internal static bool _boolSettingsFileExists()
        {
            return File.Exists(strSettingsFilePath);
        }
        #endregion

        #region Create File
        internal static void _createSettingsFile()
        {
            var ini = new IniFile(strSettingsFilePath);
            ini.Write("Startup", "DisableVersionCheck", "False");
            ini.Write("Application", "DisableFlashingUI", "False");
            ini.Write("Application", "DisableConfDiag", "False");
            ini.Write("Application", "InitialOfdPath", strDefaultOfdPath);
            ini.Write("Firmware", "DisableLzmaFsSearch", "False");
            ini.Write("Firmware", "DisableFsysEnforce", "False");
            ini.Write("Firmware", "DisableDescriptorEnforce", "False");
            ini.Write("Firmware", "AcceptedEditingTerms", "False");
        }
        #endregion

        #region Get Values
        internal static bool _settingsGetBool(SettingsBoolType settingType)
        {
            if (!_boolSettingsFileExists()) return false;

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = "Startup"; key = "DisableVersionCheck";
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = "Application"; key = "DisableFlashingUI";
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = "Application"; key = "DisableConfDiag";
                    break;
                case SettingsBoolType.DisableLzmaFsSearch:
                    section = "Firmware"; key = "DisableLzmaFsSearch";
                    break;
                case SettingsBoolType.DisableFsysEnforce:
                    section = "Firmware"; key = "DisableFsysEnforce";
                    break;
                case SettingsBoolType.DisableDescriptorEnforce:
                    section = "Firmware"; key = "DisableDescriptorEnforce";
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return false;
            }

            var ini = new IniFile(strSettingsFilePath);
            if (!ini.SectionExists(section)) return false;
            if (!ini.KeyExists(section, key)) return false;
            return bool.Parse(ini.Read(section, key));
        }

        internal static string _settingsGetString(SettingsStringType settingType)
        {
            if (!_boolSettingsFileExists()) return string.Empty;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.InitialDirectory:
                    section = "Application"; key = "InitialOfdPath";
                    break;
                default:
                    return string.Empty;
            }

            var ini = new IniFile(strSettingsFilePath);
            if (!ini.SectionExists(section)) return string.Empty;
            if (!ini.KeyExists(section, key)) return string.Empty;
            return ini.Read(section, key);
        }
        #endregion

        #region Set Values
        internal static void _settingsSetBool(SettingsBoolType settingType, bool value)
        {
            if (!_boolSettingsFileExists()) return;

            string section, key;

            switch (settingType)
            {
                case SettingsBoolType.DisableVersionCheck:
                    section = "Startup"; key = "DisableVersionCheck";
                    break;
                case SettingsBoolType.DisableFlashingUI:
                    section = "Application"; key = "DisableFlashingUI";
                    break;
                case SettingsBoolType.DisableConfDiag:
                    section = "Application"; key = "DisableConfDiag";
                    break;
                case SettingsBoolType.DisableLzmaFsSearch:
                    section = "Firmware"; key = "DisableLzmaFsSearch";
                    break;
                case SettingsBoolType.DisableFsysEnforce:
                    section = "Firmware"; key = "DisableFsysEnforce";
                    break;
                case SettingsBoolType.DisableDescriptorEnforce:
                    section = "Firmware"; key = "DisableDescriptorEnforce";
                    break;
                case SettingsBoolType.AcceptedEditingTerms:
                    section = "Firmware"; key = "AcceptedEditingTerms";
                    break;
                default:
                    return;
            }

            var ini = new IniFile(strSettingsFilePath);
            if (ini.SectionExists(section))
            {
                if (ini.KeyExists(section, key))
                {
                    ini.Write(section, key, value.ToString());
                }
                else
                {
                    Logger.Write($"{section} > {key} > Key not found, setting was not written.");
                }
            }

        }

        internal static void _settingsSetString(SettingsStringType settingType, string value)
        {
            if (!_boolSettingsFileExists()) return;

            string section, key;

            switch (settingType)
            {
                case SettingsStringType.InitialDirectory:
                    section = "Application"; key = "InitialOfdPath";
                    break;
                default:
                    return;
            }

            var ini = new IniFile(strSettingsFilePath);
            if (!ini.SectionExists(section)) ini.Write(section, string.Empty, null);
            if (ini.KeyExists(section, key))
            {
                ini.Write(section, key, value);
            }
            else
            {
                Logger.Write($"{section} > {key} > Key not found, setting was not written.");
            }

        }
        #endregion

    }
}