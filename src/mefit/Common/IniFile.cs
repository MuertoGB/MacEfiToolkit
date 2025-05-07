// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IniFile.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.Common
{
    public class IniFile
    {
        private readonly string _strFilepath;
        private const int MAX_BUFFER = 32767;

        public IniFile(string filepath)
        {
            this._strFilepath = filepath;
        }

        public void Write(string section, string key, string value)
            => NativeMethods.WritePrivateProfileString(section, key, value, _strFilepath);

        public void WriteSection(string section)
        {
            using (StreamWriter writer = new StreamWriter(_strFilepath, true))
            {
                writer.WriteLine($"[{section}]");
            }
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder builder = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(section, key, defaultValue, builder, 255, _strFilepath);
            return builder.ToString();
        }

        public void DeleteSection(string section)
            => Write(section, null, null);

        public void DeleteKey(string section, string key)
            => Write(section, key, null);

        public bool SectionExists(string section)
            => GetSectionNames()?.Contains(section) ?? false;

        public bool KeyExists(string section, string key)
            => GetSectionKeys(section)?.Contains(key) ?? false;

        public string[] GetSectionNames()
        {
            try
            {
                string unicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSectionNames(buffer, MAX_BUFFER, _strFilepath));
                if (unicode == null)
                {
                    Logger.LogInfo(nameof(GetSectionNames), "No section names found");
                    return null;
                }
                return unicode.Substring(0, unicode.Length - 1).Split('\0');
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(GetSectionNames));
                return null;
            }
        }

        public string[] GetSectionKeys(string section)
        {
            try
            {
                string unicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSection(section, buffer, MAX_BUFFER, _strFilepath));
                if (unicode == null)
                {
                    Logger.LogInfo(nameof(GetSectionKeys), "No section keys found");
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
                Logger.LogException(e, nameof(GetSectionKeys));
                return null;
            }
        }

        private string ReadBuffer(Func<IntPtr, uint> nativemethod)
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