// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IniFile.cs - Handles INI file read/write
// Released under the GNU GLP v3.0
// IniFile uses code from pinvoke.net, thank you to whoever wrote it (See _getSectionNames)

using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Common
{
    class IniFile
    {
        private readonly string filePath;

        public IniFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string section, string key, string value)
        {
            NativeMethods.WritePrivateProfileString(section, key, value, filePath);
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            var result = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(section, key, defaultValue, result, 255, filePath);
            return result.ToString();
        }

        public void DeleteKey(string section, string key)
        {
            Write(section, key, null);
        }

        public void DeleteSection(string section)
        {
            Write(section, null, null);
        }

        public bool SectionExists(string section)
        {
            string[] sectionnames = _getSectionNames(filePath);
            foreach (string s in sectionnames) if (s == section) return true;
            return false;
        }

        public bool KeyExists(string section, string key)
        {
            string[] keyNames = _getSectionKeys(section, filePath);
            foreach (string s in keyNames) if (s == key) return true;
            return false;
        }

        // _getSectionNames code found on pinvoke.
        // _getSectionKeys I adapted from _getSectionNames, using GetPrivateProfileSection.
        // https://www.pinvoke.net/default.aspx/kernel32/GetPrivateProfileSectionNames.html
        private static string[] _getSectionNames(string path)
        {
            uint MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            uint bytesReturned = NativeMethods.GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, path);
            if (bytesReturned == 0) return null;
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            return local.Substring(0, local.Length - 1).Split('\0');
        }

        private static string[] _getSectionKeys(string sectionName, string path)
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
