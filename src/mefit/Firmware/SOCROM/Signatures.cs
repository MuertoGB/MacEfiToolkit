// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Signatures.cs
// Released under the GNU GPL v3.0

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    public static class Signatures
    {
        public static class SocRom
        {
            public static readonly byte[] SocRomMarker = { 0x30, 0x83 };
            public static readonly byte[] AppleSiliconSocRomMarker = { 0x48, 0x55, 0x46, 0x41 };
        }

        public static class IBoot
        {
            public static readonly byte[] iBootMarker = { 0x69, 0x6C, 0x6C, 0x62 };
        }

        public static class Scfg
        {
            public static readonly byte[] HeaderMarker = { 0x67, 0x66, 0x43, 0x53 };
            public static readonly byte[] SerialMarker = { 0x6D, 0x4E, 0x72, 0x53 };
            public static readonly byte[] SonMarker = { 0x23, 0x64, 0x6F, 0x4D };
            public static readonly byte[] RegNoMarker = { 0x6E, 0x67, 0x65, 0x52 };
        }
    }
}
