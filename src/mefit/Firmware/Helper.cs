﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Helper.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware
{
    class Helper
    {
        internal static T DeserializeHeader<T>(byte[] binary) where T : struct
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

        public static int ToInt24(byte[] bytes)
        {
            if (bytes.Length != 3)
            {
                throw new ArgumentException("Byte data must be 3 bytes long.", nameof(bytes));
            }

            return (bytes[2] << 16) | (bytes[1] << 8) | bytes[0];
        }

        internal static string GetBytesReadableSize(long size)
        {
            // Define a set of suffixes for file sizes.
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (size == 0)
            {
                return $"{size:N2} {suffixes[0]}";
            }

            // Calculate the appropriate suffix based on the size of the file.
            int suffixIndex = (int)(Math.Log(size) / Math.Log(1024));

            // Calculate the size in the chosen suffix and format it.
            double sizeInSuffix = size / Math.Pow(1024, suffixIndex);

            return $"{sizeInSuffix:N2} {suffixes[suffixIndex]}";
        }
    }
}