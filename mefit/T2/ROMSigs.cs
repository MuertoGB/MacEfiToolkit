// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// ROMSigs.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.T2
{
    internal class ROMSigs
    {
        internal static readonly byte[] IBOOT_VER_SIG = // iBoot version signature, byte 5 is validity byte?, byte 6 is var size.
        {
            0x69, 0x6C, 0X6C, 0X62
        };

        internal static readonly byte[] SCFG_HEADER_SIG = // Header
        {
            0x67, 0x66, 0x43, 0x53
        };

        internal static readonly byte[] SCFG_SSN_SIG = // System Serial Number
        {
            0x6D, 0x4E, 0x72, 0x53
        };

        internal static readonly byte[] SCFG_SON_SIG = // System Order Number
        {
            0x23, 0x64, 0x6F, 0x4D
        };

        internal static readonly byte[] SCFG_SON_REGN = // Registration Number?
        {
            0x6E, 0x67, 0x65, 0x52
        };
    }
}