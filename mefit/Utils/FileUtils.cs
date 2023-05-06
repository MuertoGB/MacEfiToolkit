// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Utilities
// FileUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Security.Cryptography;

namespace Mac_EFI_Toolkit.Utils
{
    class FileUtils
    {

        /// <summary>
        /// Calculates the MD5 hash of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the hash for.</param>
        /// <returns>The MD5 hash of the byte array.</returns>
        internal static string CalculateMd5(byte[] sourceBytes)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        /// <summary>
        /// Calculates the CRC32 checksum of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint CalculateCrc32(byte[] sourceBytes)
        {
            uint[] table = new uint[256];

            const uint polynomial = 0xEDB88320;
            uint initialValue = 0xFFFFFFFF;

            for (uint i = 0; i < 256; i++)
            {
                uint entry = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                    {
                        entry = (entry >> 1) ^ polynomial;
                    }
                    else
                    {
                        entry >>= 1;
                    }
                }
                table[i] = entry;
            }
            uint crc = initialValue;
            for (int i = 0; i < sourceBytes.Length; i++)
            {
                byte index = (byte)(crc ^ sourceBytes[i]);
                crc = (crc >> 8) ^ table[index];
            }
            return crc ^ initialValue;
        }

        /// <summary>
        /// Reverses the order of bytes in a given byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to reverse.</param>
        /// <returns>A new byte array with the bytes in reversed order.</returns>
        internal static byte[] SwitchCrc32Endianness(byte[] sourceBytes)
        {
            int len = sourceBytes.Length;
            byte[] reversedBytes = new byte[len];

            for (int i = 0; i < len; i++)
            {
                reversedBytes[len - i - 1] = sourceBytes[i];
            }

            return reversedBytes;
        }

        /// <summary>
        /// Returns the size of a file in bytes.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>The size of the file in bytes.</returns>
        internal static long GetFileSizeBytes(string filePath)
        {
            FileInfo fInfo = new FileInfo(filePath);
            return fInfo.Length;
        }

        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="number">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        public static string FormatBytesWithCommas(long number)
        {
            return string.Format("{0:#,##0}", number);
        }

    }
}