// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FirmwareFile.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Firmware
{
    public class FirmwareFile
    {
        public struct Information
        {
            internal string FileNameExt { get; set; }
            internal string FileName { get; set; }
            internal string CreationTime { get; set; }
            internal string LastWriteTime { get; set; }
            internal long Length { get; set; }
            internal string SHA256 { get; set; }
            internal uint CRC32 { get; set; }
            internal double Entropy { get; set; }
        }

        internal const int MIN_IMAGE_SIZE = 2097152;  // 200000h (2 MB image)
        internal const int MAX_IMAGE_SIZE = 33554432; // 2000000h (32 MB image)

        /// <summary>
        /// Retrieves file information and calculates the CRC32 checksum of a specified file.
        /// </summary>
        /// <param name="filename">The full path to the file to be analyzed.</param>
        /// <returns>
        /// A Binary object containing the file's name, name without extension, creation time, last write time, file length, and CRC32 checksum.
        /// </returns>
        internal static Information GetFileInfo(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            byte[] fileBuffer = File.ReadAllBytes(fileInfo.FullName);
            string dateFormat = "MMM dd, yyyy - hh:mm tt";

            return new Information
            {
                FileNameExt = fileInfo.Name,
                FileName = Path.GetFileNameWithoutExtension(filename),
                CreationTime = fileInfo.CreationTime.ToString(dateFormat),
                LastWriteTime = fileInfo.LastWriteTime.ToString(dateFormat),
                Length = fileInfo.Length,
                CRC32 = Cryptography.GetCrc32Digest(fileBuffer),
                SHA256 = Cryptography.GetSha256Digest(fileBuffer),
                Entropy = CalculateShannonEntropy(fileBuffer)
            };
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="size">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool IsValidBinSize(long size)
        {
            int minSize = FirmwareFile.MIN_IMAGE_SIZE;
            int maxSize = FirmwareFile.MAX_IMAGE_SIZE;

            while (minSize <= maxSize)
            {
                if (size == minSize)
                {
                    return true;
                }

                minSize *= 2;
            }

            return false;
        }

        /// <summary>
        /// Calculates the difference between the input size and the closest valid size,
        /// and returns a formatted string indicating whether the size is too large or too small,
        /// along with the byte difference.
        /// </summary>
        /// <param name="size">The input size to compare against valid sizes.</param>
        /// <returns>A formatted string indicating whether the size is too large or too small,
        /// along with the byte difference.</returns>
        internal static string CalculateInvalidSize(long size)
        {
            // Initialize the closest size with the minimum image size
            long closestSize = MIN_IMAGE_SIZE;

            // Calculate the initial difference between the input size and the closest size
            long difference = Math.Abs(size - closestSize);

            // Iterate through the valid sizes to find the closest size
            while (closestSize <= MAX_IMAGE_SIZE)
            {
                // Calculate the doubled size and its difference from the input size
                long doubledSize = closestSize * 2;

                long doubledDifference = Math.Abs(size - doubledSize);

                // If the doubled difference is smaller, update the closest size and difference
                if (doubledDifference < difference)
                {
                    closestSize = doubledSize;
                    difference = doubledDifference;
                }
                else
                {
                    // Exit the loop if the doubled difference becomes larger
                    break;
                }
            }

            // Check if the input size is smaller than the closest size
            if (size < closestSize)
            {
                // Return a formatted string indicating the size is too small
                return $"<{difference}";
            }
            // Check if the input size is larger than the closest size
            else if (size > closestSize)
            {
                // Return a formatted string indicating the size is too large
                return $">{difference}";
            }
            else
            {
                // Return a string indicating an exact match
                return "Valid";
            }
        }

        internal static bool IsValidMinMaxSize(string filepath, Form owner, int minsize, int maxsize)
        {
            long size = new FileInfo(filepath).Length;

            if (size < minsize || size > maxsize)
            {
                string message = size < minsize
                    ? $"The selected file does not meet the minimum size requirement of {minsize:X}h."
                    : $"The selected file exceeds the maximum size limit of {maxsize:X}h.";

                METPrompt.Show(
                    owner,
                    message,
                    METPrompt.PType.Error,
                    METPrompt.PButtons.Okay);

                return false;
            }

            return true;
        }

        internal static double CalculateShannonEntropy(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return 0.0;
            }
                
            int[] frequencies = new int[256];

            foreach (byte b in data)
            {
                frequencies[b]++;
            }

            double entropy = 0.0;
            int dataLength = data.Length;

            for (int i = 0; i < 256; i++)
            {
                if (frequencies[i] > 0)
                {
                    double probability = (double)frequencies[i] / dataLength;
                    entropy -= probability * Math.Log(probability, 2);
                }
            }

            return entropy;
        }
    }
}
