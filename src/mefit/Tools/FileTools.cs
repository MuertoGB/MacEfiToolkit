// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FileTools.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.IO.Compression;

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
        /// The size is rounded to one decimal place and always shows one decimal place.
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

            // Always format the result with one decimal place, even if it's a whole number.
            return $"{size:F1} {suffixes[index]}";
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
    }
}