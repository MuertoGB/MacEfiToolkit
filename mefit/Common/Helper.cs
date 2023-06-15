// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Helper.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.Common
{
    class Helper
    {
        internal static T DeserializeHeader<T>(byte[] binary) where T : struct
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(binary, 0, ptr, size);

                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr);
            }
        }

        internal static byte[] ConvertStringToByteArray(string sourceString, Encoding encodingType)
        {
            return encodingType.GetBytes(sourceString);
        }

        internal static string GetBytesReadableSize(ulong size)
        {
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (size == 0)
                return $"{size:N2} {suffixes[0]}";

            int suffixIndex = (int)(Math.Log(size) / Math.Log(1024));
            double sizeInSuffix = (double)size / Math.Pow(1024, suffixIndex);

            return $"{sizeInSuffix:N2} {suffixes[suffixIndex]}";
        }

    }
}