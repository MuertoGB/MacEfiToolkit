// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FirmwareFile.cs
// Released under the GNU GPL v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Utilities;
using System.IO;

namespace Mac_EFI_Toolkit.Firmware
{
    public class FirmwareFile
    {
        public string Path { get; }
        public byte[] Data { get; }
        public Information Metadata { get; }

        public FirmwareFile(string filepath)
        {
            Path = filepath;
            Data = File.ReadAllBytes(filepath);
            Metadata = Analyze();
        }

        public struct Information
        {
            public string FileNameExt { get; set; }
            public string FileName { get; set; }
            public string CreationTime { get; set; }
            public string LastWriteTime { get; set; }
            public long Length { get; set; }
            public string SHA256 { get; set; }
            public uint CRC32 { get; set; }
            public double Entropy { get; set; }
        }

        private Information Analyze()
        {
            FileInfo fileInfo = new FileInfo(Path);
            string dateFormat = "MMM dd, yyyy - hh:mm tt";

            return new Information
            {
                FileNameExt = fileInfo.Name,
                FileName = System.IO.Path.GetFileNameWithoutExtension(Path),
                CreationTime = fileInfo.CreationTime.ToString(dateFormat),
                LastWriteTime = fileInfo.LastWriteTime.ToString(dateFormat),
                Length = fileInfo.Length,
                CRC32 = Cryptography.GetCrc32Digest(Data),
                SHA256 = Cryptography.GetSha256Digest(Data),
                Entropy = MathUtils.CalculateShannonEntropy(Data)
            };
        }
    }
}