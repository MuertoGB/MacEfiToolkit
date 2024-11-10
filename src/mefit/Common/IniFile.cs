// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IniFile.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.Common
{
    class IniFile
    {
        private readonly string _strFilePath;
        private const int MAX_BUFFER = 32767;

        internal IniFile(string filePath) => this._strFilePath = filePath;

        internal void Write(string section, string key, string value) => NativeMethods.WritePrivateProfileString(section, key, value, _strFilePath);

        internal void WriteSection(string section)
        {
            using (StreamWriter writer = new StreamWriter(_strFilePath, true))
            {
                writer.WriteLine($"[{section}]");
            }
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder stringBuilder = new StringBuilder(255);

            NativeMethods.GetPrivateProfileString(section, key, defaultValue, stringBuilder, 255, _strFilePath);

            return stringBuilder.ToString();
        }

        internal void DeleteSection(string section) => Write(section, null, null);

        internal void DeleteKey(string section, string key) => Write(section, key, null);

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

            if (keyNames == null)
            {
                return false;
            }

            foreach (string s in keyNames)
            {
                if (s == key)
                {
                    return true;
                }
            }

            return false;
        }

        internal static string[] GetSectionNames(string lpFileName)
        {
            IntPtr lpszReturnBuffer = IntPtr.Zero;

            try
            {
                lpszReturnBuffer = Marshal.AllocCoTaskMem(MAX_BUFFER);

                uint data = NativeMethods.GetPrivateProfileSectionNames(lpszReturnBuffer, MAX_BUFFER, lpFileName);

                if (data == 0)
                {
                    return null;
                }

                string unicodeString = Marshal.PtrToStringUni(lpszReturnBuffer, (int)data);

                return unicodeString.Substring(0, unicodeString.Length - 1).Split('\0');
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSectionNames), e.GetType(), e.Message);
                return null;
            }
            finally
            {
                if (lpszReturnBuffer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(lpszReturnBuffer);
                }
            }
        }

        internal static string[] GetSectionKeys(string lpAppName, string lpFileName)
        {
            IntPtr lpReturnedString = IntPtr.Zero;

            try
            {
                lpReturnedString = Marshal.AllocCoTaskMem(MAX_BUFFER);

                uint data = NativeMethods.GetPrivateProfileSection(lpAppName, lpReturnedString, MAX_BUFFER, lpFileName);

                if (data == 0)
                {
                    return null;
                }

                string unicodeString = Marshal.PtrToStringUni(lpReturnedString, (int)data);

                string[] keys = unicodeString.Substring(0, unicodeString.Length - 1).Split('\0');

                for (int i = 0; i < keys.Length; i++)
                {
                    int separatorIndex = keys[i].IndexOf('=');

                    if (separatorIndex != -1)
                    {
                        keys[i] = keys[i].Substring(0, separatorIndex);
                    }
                }

                return keys;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSectionKeys), e.GetType(), e.Message);
                return null;
            }
            finally
            {
                if (lpReturnedString != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(lpReturnedString);
                }
            }
        }
    }
}