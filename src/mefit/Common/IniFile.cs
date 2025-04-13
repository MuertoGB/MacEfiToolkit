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
            using (StreamWriter streamWriter = new StreamWriter(_strFilepath, true))
            {
                streamWriter.WriteLine($"[{section}]");
            }
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder stringBuilder = new StringBuilder(255);

            NativeMethods.GetPrivateProfileString(section, key, defaultValue, stringBuilder, 255, _strFilepath);

            return stringBuilder.ToString();
        }

        internal void DeleteSection(string section) => Write(section, null, null);

        internal void DeleteKey(string section, string key) => Write(section, key, null);

        internal bool SectionExists(string section)
        {
            string[] arrSectionNames = GetSectionNames(_strFilepath);

            if (arrSectionNames != null)
            {
                foreach (string strSection in arrSectionNames)
                {
                    if (strSection == section)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal bool KeyExists(string section, string key)
        {
            string[] arrKeyNames = GetSectionKeys(section, _strFilepath);

            if (arrKeyNames == null)
            {
                return false;
            }

            foreach (string strKey in arrKeyNames)
            {
                if (strKey == key)
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
                string strUnicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSectionNames(buffer, MAX_BUFFER, lpFileName));

                if (strUnicode == null)
                {
                    Logger.WriteCallerLine(nameof(GetSectionNames), "No section names found");
                    return null;
                }

                return strUnicode.Substring(0, strUnicode.Length - 1).Split('\0');
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
                string strUnicode = ReadBuffer(buffer => NativeMethods.GetPrivateProfileSection(lpAppName, buffer, MAX_BUFFER, lpFileName));

                if (strUnicode == null)
                {
                    Logger.WriteCallerLine(nameof(GetSectionKeys), "No section keys found");
                    return null;
                }

                string[] arrKeys = strUnicode.Substring(0, strUnicode.Length - 1).Split('\0');

                for (int i = 0; i < arrKeys.Length; i++)
                {
                    int iIndex = arrKeys[i].IndexOf('=');
                    arrKeys[i] = iIndex != -1 ? arrKeys[i].Substring(0, iIndex) : arrKeys[i];
                }

                return arrKeys;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSectionKeys), e.GetType(), e.Message);
                return null;
            }
        }

        private static string ReadBuffer(Func<IntPtr, uint> nativeMethod)
        {
            IntPtr buffer = IntPtr.Zero;

            try
            {
                buffer = Marshal.AllocCoTaskMem(MAX_BUFFER);
                uint uiData = nativeMethod(buffer);

                if (uiData == 0)
                {
                    return null;
                }

                return Marshal.PtrToStringUni(buffer, (int)uiData);
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(buffer);
                }
            }
        }
    }
}