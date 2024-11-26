// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCSigs.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal class SOCSigs
    {
        internal static readonly byte[] T2RomMarker = { 0x30, 0x83 };
        internal static readonly byte[] iBootMarker = { 0x69, 0x6C, 0X6C, 0X62 };
        internal static readonly byte[] ScfgHeaderMarker = { 0x67, 0x66, 0x43, 0x53 };
        internal static readonly byte[] ScfgSerialMarker = { 0x6D, 0x4E, 0x72, 0x53 };
        internal static readonly byte[] ScfgSonMarker = { 0x23, 0x64, 0x6F, 0x4D };
        internal static readonly byte[] ScfgRegnMarker = { 0x6E, 0x67, 0x65, 0x52 };
    }
}