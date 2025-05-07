// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Cryptography.cs
// Released under the GNU GLP v3.0

using System;
using System.Security.Cryptography;

namespace Mac_EFI_Toolkit.Common
{
    public static class Cryptography
    {
        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        public static string GetSha256Digest(byte[] sourcebuffer)
        {
            using (SHA256 provider = SHA256.Create())
            {
                byte[] digest = provider.ComputeHash(sourcebuffer);

                return BitConverter.ToString(digest).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Calculates the CRC32 checksum of a byte array. 
        /// </summary>
        public static uint GetCrc32Digest(byte[] sourcebuffer)
        {
            const uint poly = 0xEDB88320;
            uint crc = 0xFFFFFFFF;

            for (int i = 0; i < sourcebuffer.Length; i++)
            {
                crc ^= sourcebuffer[i];
                for (int j = 0; j < 8; j++)
                {
                    crc = (uint)((crc >> 1) ^ (poly & -(crc & 1)));
                }
            }

            return crc ^ 0xFFFFFFFF;
        }
    }
}