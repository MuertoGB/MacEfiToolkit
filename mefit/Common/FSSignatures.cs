// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FSSignatures.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Common
{
    class FSSignatures
    {
        internal static readonly byte[] NVRAM_VSS_SIG =
        {
            0x24, 0x56, 0x53, 0x53
        };

        internal static readonly byte[] NVRAM_SVS_SIG =
        {
            0x24, 0x53, 0x56, 0x53
        };

        internal static readonly byte[] NVRAM_NSS_SIG =
        {
            0x24, 0x4E, 0x53, 0x53
        };

        internal static readonly byte[] IBIOSI_SIG =
        {
            0x24, 0x49, 0x42, 0x49,
            0x4F, 0x53, 0x49, 0x24
        };

    }
}