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
        private readonly string _strFilepath;
        private const int MAX_BUFFER = 32767;

        internal IniFile(string filepath) => this._strFilepath = filepath;

        internal void Write(string section, string key, string value) => NativeMethods.WritePrivateProfileString(section, key, value, _strFilepath);

        internal void WriteSection(string section)
        {
            using (StreamWriter writer = new StreamWriter(_strFilepath, true))
            {
                writer.WriteLine($"[{section}]");
            }
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder builder = new StringBuilder(255);

            NativeMethods.GetPrivateProfileString(section, key, defaultValue, builder, 255, _strFilepath);

            return builder.ToString();
        }

        internal void DeleteSection(string section) => Write(section, null, null);

        internal void DeleteKey(string section, string key) => Write(section, key, null);

        internal bool SectionExists(string section)
        {
            string[] sectionNames = GetSectionNames(_strFilepath);

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
            string[] keyNames = GetSectionKeys(section, _strFilepath);

            if (keyNames == null)
            {
                return false;
            }

            foreach (string k in keyNames)
            {
                if (k == key)
                {
                    return true;
                }
            }

            return false;
        }

        internal static string[] GetSectionNames(string lpFileName)
        {
            try
            {
                string unicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSectionNames(buffer, MAX_BUFFER, lpFileName));

                if (unicode == null)
                {
                    Logger.WriteCallerLine(nameof(GetSectionNames), "No section names found");
                    return null;
                }

                return unicode.Substring(0, unicode.Length - 1).Split('\0');
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSectionNames), e.GetType(), e.Message);
                return null;
            }
        }

        internal static string[] GetSectionKeys(string lpAppName, string lpFileName)
        {
            try
            {
                string unicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSection(lpAppName, buffer, MAX_BUFFER, lpFileName));

                if (unicode == null)
                {
                    Logger.WriteCallerLine(nameof(GetSectionKeys), "No section keys found");
                    return null;
                }

                string[] keys = unicode.Substring(0, unicode.Length - 1).Split('\0');

                for (int i = 0; i < keys.Length; i++)
                {
                    int index = keys[i].IndexOf('=');
                    keys[i] = index != -1 ? keys[i].Substring(0, index) : keys[i];
                }

                return keys;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSectionKeys), e.GetType(), e.Message);
                return null;
            }
        }

        private static string ReadBuffer(Func<IntPtr, uint> nativemethod)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.AllocCoTaskMem(MAX_BUFFER);
                uint data = nativemethod(ptr);

                if (data == 0)
                {
                    return null;
                }

                return Marshal.PtrToStringUni(ptr, (int)data);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(ptr);
                }
            }
        }
    }
}