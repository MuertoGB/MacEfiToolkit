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
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourceBytes)
        {
            using (var provider = SHA256.Create())
            {
                var digestBytes = provider.ComputeHash(sourceBytes);
                return BitConverter.ToString(digestBytes).Replace("-", "");
            }
        }
        /// <summary>
        /// Calculates the CRC32 checksum of a byte array. 
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint GetCrc32Digest(byte[] sourceBytes)
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
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="lSize">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        public static string FormatFileSize(long lSize)
        {
            return string.Format("{0:#,##0}", lSize);
        }
    }
}