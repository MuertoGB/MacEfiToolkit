using Mac_EFI_Toolkit.Tools;
using System.IO;

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
            internal uint CRC32 { get; set; }
        }

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
                CRC32 = FileTools.GetCrc32Digest(fileBuffer)
            };
        }
    }
}
