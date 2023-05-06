using System;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Core
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
    }
}