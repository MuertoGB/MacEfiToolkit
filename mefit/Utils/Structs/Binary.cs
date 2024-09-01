// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Binary.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Utils.Structs
{
    internal struct Binary
    {
        internal string FileNameExt { get; set; }
        internal string FileName { get; set; }
        internal string CreationTime { get; set; }
        internal string LastWriteTime { get; set; }
        internal int Length { get; set; }
        internal uint CRC32 { get; set; }
    }
}