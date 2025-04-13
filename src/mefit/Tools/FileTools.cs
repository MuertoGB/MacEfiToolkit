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
    #region Enum
    enum DirectoryStatus
    {
        SUCCESS,
        FAILED
    }
    #endregion

    class FileTools
    {
        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourcebuffer)
        {
            using (SHA256 shaProvider = SHA256.Create())
            {
                byte[] bDigest = shaProvider.ComputeHash(sourcebuffer);

                return BitConverter.ToString(bDigest).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Calculates the CRC32 checksum of a byte array. 
        /// </summary>
        /// <param name="sourcebuffer">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint GetCrc32Digest(byte[] sourcebuffer)
        {
            const uint uiPolynomial = 0xEDB88320;
            uint uiCrc = 0xFFFFFFFF;

            for (int i = 0; i < sourcebuffer.Length; i++)
            {
                uiCrc ^= sourcebuffer[i];

                for (int j = 0; j < 8; j++)
                {
                    uiCrc = (uint)((uiCrc >> 1) ^ (uiPolynomial & -(uiCrc & 1)));
                }
            }

            return uiCrc ^ 0xFFFFFFFF;
        }

        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="size">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        internal static string FormatBytesWithCommas(long size)
        {
            return string.Format("{0:#,##0}", size);
        }

        /// <summary>
        /// Converts a byte size into a human-readable format using appropriate units (e.g., KB, MB).
        /// </summary>
        /// <param name="size">The size in bytes to convert.</param>
        /// <returns>A human-readable string representation of the size with the appropriate unit.</returns>
        internal static string FormatBytesToReadableUnit(ulong size)
        {
            // Define a set of suffixes for file sizes.
            string[] arrSuffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (size == 0)
            {
                return $"0 {arrSuffixes[0]}";
            }

            // Calculate the appropriate suffix index based on the size of the input.
            int iIndex = (int)Math.Floor(Math.Log(size, 1024));

            // Ensure the index does not exceed the array bounds (safety measure).
            iIndex = Math.Min(iIndex, arrSuffixes.Length - 1);

            // Calculate the size in the chosen suffix and format it.
            double dblSize = size / Math.Pow(1024, iIndex);

            return $"{dblSize:N2} {arrSuffixes[iIndex]}";
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="size">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool GetIsValidBinSize(long size)
        {
            int iExpectedSize = FirmwareVars.MIN_IMAGE_SIZE;
            int iMaxSize = FirmwareVars.MAX_IMAGE_SIZE;

            while (iExpectedSize <= iMaxSize)
            {
                if (size == iExpectedSize)
                {
                    return true;
                }

                iExpectedSize *= 2;
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
        internal static string GetSizeDifference(long size)
        {
            // Initialize the closest size with the minimum image size
            long lClosestSize = FirmwareVars.MIN_IMAGE_SIZE;

            // Calculate the initial difference between the input size and the closest size
            long lDifference = Math.Abs(size - lClosestSize);

            // Iterate through the valid sizes to find the closest size
            while (lClosestSize <= FirmwareVars.MAX_IMAGE_SIZE)
            {
                // Calculate the doubled size and its difference from the input size
                long lDoubledSize = lClosestSize * 2;

                long lDoubledDifference = Math.Abs(size - lDoubledSize);

                // If the doubled difference is smaller, update the closest size and difference
                if (lDoubledDifference < lDifference)
                {
                    lClosestSize = lDoubledSize;
                    lDifference = lDoubledDifference;
                }
                else
                {
                    // Exit the loop if the doubled difference becomes larger
                    break;
                }
            }

            // Check if the input size is smaller than the closest size
            if (size < lClosestSize)
            {
                // Return a formatted string indicating the size is too small
                return $"<{lDifference}";
            }
            // Check if the input size is larger than the closest size
            else if (size > lClosestSize)
            {
                // Return a formatted string indicating the size is too large
                return $">{lDifference}";
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

                byte[] bFileBytes = File.ReadAllBytes(filepath);

                return BinaryTools.ByteArraysMatch(sourcebuffer, bFileBytes);
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
        /// The status of the directory creation operation. Returns <see cref="DirectoryStatus.SUCCESS"/> if the directory is successfully created,
        /// or <see cref="DirectoryStatus.FAILED"/> if the creation fails.
        /// </returns>
        internal static DirectoryStatus CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);

            if (Directory.Exists(directory))
            {
                return DirectoryStatus.SUCCESS;
            }

            return DirectoryStatus.FAILED;
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
                using (FileStream fsZipFile = new FileStream(filepath, FileMode.Create))
                using (ZipArchive zipArchive = new ZipArchive(fsZipFile, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry fileEntry = zipArchive.CreateEntry(entryname);

                    using (Stream streamBuffer = fileEntry.Open())
                    {
                        streamBuffer.Write(sourcebuffer, 0, sourcebuffer.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(BackupFileToZip), e.GetType(), e.Message);
            }
        }

        /// <summary>
        /// Retrieves file information and calculates the CRC32 checksum of a specified file.
        /// </summary>
        /// <param name="filename">The full path to the file to be analyzed.</param>
        /// <returns>
        /// A Binary object containing the file's name, name without extension, creation time, last write time, file length, and CRC32 checksum.
        /// </returns>
        internal static FileInfoStore GetBinaryFileInfo(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            byte[] bFileBytes = File.ReadAllBytes(fileInfo.FullName);

            return new FileInfoStore
            {
                FileNameExt = fileInfo.Name,
                FileName = Path.GetFileNameWithoutExtension(filename),
                CreationTime = fileInfo.CreationTime.ToString(),
                LastWriteTime = fileInfo.LastWriteTime.ToString(),
                Length = fileInfo.Length,
                CRC32 = GetCrc32Digest(bFileBytes)
            };
        }

        internal static bool IsValidMinMaxSize(string filepath, Form owner, int minsize, int maxsize)
        {
            long lSize = new FileInfo(filepath).Length;

            if (lSize < minsize || lSize > maxsize)
            {
                string message = lSize < minsize
                    ? $"The selected file does not meet the minimum size requirement of {minsize:X}h."
                    : $"The selected file exceeds the maximum size limit of {maxsize:X}h.";

                METPrompt.Show(
                    owner,
                    message,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return false;
            }

            return true;
        }
    }
}