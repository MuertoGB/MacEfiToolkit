// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Signatures.cs
// Released under the GNU GPL v3.0

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal static class Signatures
    {
        public static class SocRom
        {
            internal static readonly byte[] SocRomMarker = { 0x30, 0x83 };
            internal static readonly byte[] AppleSiliconSocRomMarker = { 0x48, 0x55, 0x46, 0x41 };
        }

        public static class IBoot
        {
            internal static readonly byte[] iBootMarker = { 0x69, 0x6C, 0x6C, 0x62 };
        }

        public static class Scfg
        {
            internal static readonly byte[] HeaderMarker = { 0x67, 0x66, 0x43, 0x53 };
            internal static readonly byte[] SerialMarker = { 0x6D, 0x4E, 0x72, 0x53 };
            internal static readonly byte[] SonMarker = { 0x23, 0x64, 0x6F, 0x4D };
            internal static readonly byte[] RegNoMarker = { 0x6E, 0x67, 0x65, 0x52 };
        }
    }
}
