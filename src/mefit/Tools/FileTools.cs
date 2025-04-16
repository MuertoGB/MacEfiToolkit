// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FileTools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Tools
{
    public class FileTools
    {
        public enum CreationStatus
        {
            SUCCESS,
            FAILED
        }

        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourcebuffer)
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
        /// <param name="sourcebuffer">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint GetCrc32Digest(byte[] sourcebuffer)
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

        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="input">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        internal static string FormatBytesWithCommas(long input)
        {
            return string.Format("{0:#,##0}", input);
        }

        /// <summary>
        /// Converts a byte size into a human-readable format using appropriate units (e.g., KB, MB).
        /// </summary>
        /// <param name="input">The size in bytes to convert.</param>
        /// <returns>A human-readable string representation of the size with the appropriate unit.</returns>
        internal static string FormatBytesToReadableUnit(ulong input)
        {
            // Define a set of suffixes for file sizes.
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (input == 0)
            {
                return $"0 {suffixes[0]}";
            }

            // Calculate the appropriate suffix index based on the size of the input.
            int index = (int)Math.Floor(Math.Log(input, 1024));

            // Ensure the index does not exceed the array bounds (safety measure).
            index = Math.Min(index, suffixes.Length - 1);

            // Calculate the size in the chosen suffix and format it.
            double size = input / Math.Pow(1024, index);

            return $"{size:N2} {suffixes[index]}";
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="size">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool GetIsValidBinSize(long size)
        {
            int minSize = FirmwareVars.MIN_IMAGE_SIZE;
            int maxSize = FirmwareVars.MAX_IMAGE_SIZE;

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
        /// <param name="input">The input size to compare against valid sizes.</param>
        /// <returns>A formatted string indicating whether the size is too large or too small,
        /// along with the byte difference.</returns>
        internal static string GetSizeDifference(long input)
        {
            // Initialize the closest size with the minimum image size
            long closestSize = FirmwareVars.MIN_IMAGE_SIZE;

            // Calculate the initial difference between the input size and the closest size
            long difference = Math.Abs(input - closestSize);

            // Iterate through the valid sizes to find the closest size
            while (closestSize <= FirmwareVars.MAX_IMAGE_SIZE)
            {
                // Calculate the doubled size and its difference from the input size
                long doubledSize = closestSize * 2;

                long doubledDifference = Math.Abs(input - doubledSize);

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
            if (input < closestSize)
            {
                // Return a formatted string indicating the size is too small
                return $"<{difference}";
            }
            // Check if the input size is larger than the closest size
            else if (input > closestSize)
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

        /// <summary>
        /// Writes the specified byte array to the file at the given path and verifies the integrity of the written data.
        /// </summary>
        /// <param name="filepath">The path of the file to write.</param>
        /// <param name="sourcebuffer">The byte array containing the data to be written.</param>
        /// <returns>True if the data was written successfully and integrity is verified; otherwise, false.</returns>
        internal static bool WriteAllBytesEx(string filepath, byte[] sourcebuffer)
        {
            try
            {
                File.WriteAllBytes(filepath, sourcebuffer);

                byte[] fileBuffer = File.ReadAllBytes(filepath);

                return BinaryTools.ByteArraysMatch(sourcebuffer, fileBuffer);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(WriteAllBytesEx), e.GetType(), e.Message);
                return false;
            }
        }

        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="directory">The path of the directory to create.</param>
        /// <returns>
        /// The status of the directory creation operation. Returns <see cref="CreationStatus.SUCCESS"/> if the directory is successfully created,
        /// or <see cref="CreationStatus.FAILED"/> if the creation fails.
        /// </returns>
        public static CreationStatus CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);

            if (Directory.Exists(directory))
            {
                return CreationStatus.SUCCESS;
            }

            return CreationStatus.FAILED;
        }

        /// <summary>
        /// Backs up a byte array to a zip file.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to be backed up.</param>
        /// <param name="entryname">The name of the entry to be created within the zip archive.</param>
        /// <param name="filepath">The path of the zip file to be created.</param>
        internal static void BackupFileToZip(byte[] sourcebuffer, string entryname, string filepath)
        {
            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry archiveEntry = archive.CreateEntry(entryname);

                    using (Stream archiveBuffer = archiveEntry.Open())
                    {
                        archiveBuffer.Write(sourcebuffer, 0, sourcebuffer.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(BackupFileToZip), e.GetType(), e.Message);
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
    }
}