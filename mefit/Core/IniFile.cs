// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// IniFile.cs - Handles INI file read/write
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System.Collections.Generic;
using System.Text;

namespace Mac_EFI_Toolkit.Core
{
    class IniFile
    {
        private readonly string filePath;

        internal IniFile(string filePath)
        {
            this.filePath = filePath;
        }

        internal void Write(string section, string key, string value)
        {
            NativeMethods.WritePrivateProfileString(section, key, value, filePath);
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            var result = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(section, key, defaultValue, result, 255, filePath);
            return result.ToString();
        }

        internal void DeleteKey(string section, string key)
        {
            Write(section, key, null);
        }

        internal void DeleteSection(string section)
        {
            Write(section, null, null);
        }

        internal bool SectionExists(string section)
        {
            return ReadSections().Contains(section);
        }

        internal List<string> ReadSections()
        {
            var result = new List<string>();
            var buffer = new StringBuilder(2048);
            NativeMethods.GetPrivateProfileString(null, null, null, buffer, buffer.Length, filePath);
            var encoding = Encoding.ASCII;
            var bytes = encoding.GetBytes(buffer.ToString());
            var sections = encoding.GetString(bytes).TrimEnd('\0').Split('\0');
            result.AddRange(sections);
            return result;
        }

        internal List<string> ReadKeys(string section)
        {
            var result = new List<string>();
            var buffer = new StringBuilder(2048);
            NativeMethods.GetPrivateProfileString(section, null, null, buffer, buffer.Length, filePath);
            var encoding = Encoding.ASCII;
            var bytes = encoding.GetBytes(buffer.ToString());
            var keys = encoding.GetString(bytes).TrimEnd('\0').Split('\0');
            result.AddRange(keys);
            return result;
        }
    }
}