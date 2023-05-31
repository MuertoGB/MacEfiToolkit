// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

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
        internal static string GetStringMd5FromBytes(byte[] sourceBytes)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
        // Updated _uintGetCrc32FromBytes
        // Note that this version of the code uses the two's complement trick to conditionally XOR
        // the polynomial with the current value of the CRC32 register, the original code explicitly
        // initializes a lookup table for the CRC32 calculation; there may be a performance hit?
        /// <summary>
        /// Calculates the CRC32 checksum of a byte array. 
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint GetUintCrc32FromBytes(byte[] sourceBytes)
        {
            const uint polynomial = 0xEDB88320;
            uint crc = 0xFFFFFFFF;
            for (int i = 0; i < sourceBytes.Length; i++)
            {
                crc ^= sourceBytes[i];
                for (int j = 0; j < 8; j++)
                {
                    crc = (uint)((crc >> 1) ^ (polynomial & -(crc & 1)));
                }
            }
            return crc ^ 0xFFFFFFFF;
        }
        /// <summary>
        /// Returns the size of a file in bytes.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>The size of the file in bytes.</returns>
        internal static long GetLongFileSizeBytes(string filePath)
        {
            FileInfo fInfo = new FileInfo(filePath);
            return fInfo.Length;
        }
        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="number">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        public static string FormatStringFileSizeBytesWithCommas(long number)
        {
            return string.Format("{0:#,##0}", number);
        }
    }
}