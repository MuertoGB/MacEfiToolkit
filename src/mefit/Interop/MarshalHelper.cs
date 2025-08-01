﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MarshalHelper.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Interop
{
    public static class MarshalHelper
    {
        internal static T ReadStruct<T>(byte[] binary) where T : struct
        {
            // Initialize a pointer to IntPtr with a default value.
            IntPtr ptr = IntPtr.Zero;

            try
            {
                // Determine the size of the structure 'T' in bytes.
                int size = Marshal.SizeOf(typeof(T));

                // Allocate unmanaged memory to hold the binary data.
                ptr = Marshal.AllocHGlobal(size);

                // Copy the binary data from the byte array to the allocated memory.
                Marshal.Copy(binary, 0, ptr, size);

                // Convert the memory back to the original structure type and return it.
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                // Ensure that the allocated memory is freed, even if an exception occurs.
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
        }
    }
}