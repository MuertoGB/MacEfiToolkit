// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IniFile.cs - Handles INI file read/write
// Released under the GNU GLP v3.0
// IniFile uses code from pinvoke.net, thank you to whoever wrote it (See GetSectionNames)

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.Common
{
    class IniFile
    {
        private readonly string _strFilePath;

        internal IniFile(string filePath)
        {
            this._strFilePath = filePath;
        }

        internal void Write(string section, string key, string value)
        {
            NativeMethods.WritePrivateProfileString(section, key, value, _strFilePath);
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            var result = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(section, key, defaultValue, result, 255, _strFilePath);
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
            string[] sectionNames = GetSectionNames(_strFilePath);
            if (sectionNames != null)
            {
                foreach (string s in sectionNames)
                {
                    if (s == section)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool KeyExists(string section, string key)
        {
            string[] keyNames = GetSectionKeys(section, _strFilePath);
            foreach (string s in keyNames) if (s == key) return true;
            return false;
        }

        // GetSectionNames code found on pinvoke.
        // GetSectionKeys I adapted from GetSectionNames using GetPrivateProfileSection.
        // https://www.pinvoke.net/default.aspx/kernel32/GetPrivateProfileSectionNames.html
        internal static string[] GetSectionNames(string path)
        {
            uint MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            uint bytesReturned = NativeMethods.GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, path);
            if (bytesReturned == 0) return null;
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            return local.Substring(0, local.Length - 1).Split('\0');
        }

        internal static string[] GetSectionKeys(string sectionName, string path)
        {
            uint MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            uint bytesReturned = NativeMethods.GetPrivateProfileSection(sectionName, pReturnedString, MAX_BUFFER, path);
            if (bytesReturned == 0) return null;
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            var keys = local.Substring(0, local.Length - 1).Split('\0');
            for (int i = 0; i < keys.Length; i++)
            {
                int separatorIndex = keys[i].IndexOf('=');
                if (separatorIndex != -1)
                    keys[i] = keys[i].Substring(0, separatorIndex);
            }
            return keys;
        }
    }
}
