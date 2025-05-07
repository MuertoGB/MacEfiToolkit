// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FileUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class FileUtils
    {
        public enum DirectoryCreationStatus
        {
            Success,
            Failed
        }

        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="input">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        public static string FormatBytesWithCommas(long input)
        {
            return string.Format("{0:#,##0}", input);
        }

        /// <summary>
        /// Converts a byte size into a human-readable format using appropriate units (e.g., KB, MB).
        /// The size is rounded to one decimal place and always shows one decimal place.
        /// </summary>
        /// <param name="input">The size in bytes to convert.</param>
        /// <returns>A human-readable string representation of the size with the appropriate unit.</returns>
        public static string FormatBytesToReadableUnit(ulong input)
        {
            // Define a set of suffixes for file sizes.
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (input == 0)
                return $"0 {suffixes[0]}";

            // Calculate the appropriate suffix index based on the size of the input.
            int index = (int)Math.Floor(Math.Log(input, 1024));

            // Ensure the index does not exceed the array bounds (safety measure).
            index = Math.Min(index, suffixes.Length - 1);

            // Calculate the size in the chosen suffix and format it.
            double size = input / Math.Pow(1024, index);

            // Always format the result with one decimal place, even if it's a whole number.
            return $"{size:F1} {suffixes[index]}";
        }

        /// <summary>
        /// Writes the specified byte array to the file at the given path and verifies the integrity of the written data.
        /// </summary>
        /// <param name="filepath">The path of the file to write.</param>
        /// <param name="sourcebuffer">The byte array containing the data to be written.</param>
        /// <returns>True if the data was written successfully and integrity is verified; otherwise, false.</returns>
        public static bool WriteAllBytesEx(string filepath, byte[] sourcebuffer)
        {
            try
            {
                File.WriteAllBytes(filepath, sourcebuffer);

                byte[] fileBuffer = File.ReadAllBytes(filepath);

                return BinaryUtils.ByteArraysMatch(sourcebuffer, fileBuffer);
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(WriteAllBytesEx));
                return false;
            }
        }

        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="directory">The path of the directory to create.</param>
        /// <returns>
        /// The status of the directory creation operation. Returns <see cref="DirectoryCreationStatus.Success"/> if the directory is successfully created,
        /// or <see cref="DirectoryCreationStatus.Failed"/> if the creation fails.
        /// </returns>
        public static DirectoryCreationStatus CreateDirectory(string directory)
        {
            try
            {
                Directory.CreateDirectory(directory);

                return Directory.Exists(directory)
                    ? DirectoryCreationStatus.Success
                    : DirectoryCreationStatus.Failed;
            }
            catch
            {
                return DirectoryCreationStatus.Failed;
            }
        }

        /// <summary>
        /// Backs up a byte array to a zip file.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to be backed up.</param>
        /// <param name="entryname">The name of the entry to be created within the zip archive.</param>
        /// <param name="filepath">The path of the zip file to be created.</param>
        public static void BackupFileToZip(byte[] sourcebuffer, string entryname, string filepath)
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
                Logger.LogException(e, nameof(BackupFileToZip));
            }
        }
    }
}