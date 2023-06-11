// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FSSignatures.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Common
{
    class FSSignatures
    {

        internal static readonly byte[] FSYS_SIG =
        {
            0x46, 0x73, 0x79, 0x73,
            0x01
        };

        internal static readonly byte[] SSN_LOWER_SIG =
        {
            0x73, 0x73, 0x6E
        };

        internal static readonly byte[] SSN_UPPER_SIG =
        {
            0x53, 0x53, 0x4E
        };

        internal static readonly byte[] SON_SIG =
        {
            0x03, 0x73, 0x6F, 0x6E
        };

        internal static readonly byte[] HWC_SIG =
        {
            0x03, 0x68, 0x77,  0x63
        };

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

        internal static readonly byte[] PDR_BOARD_ID_SIG =
        {
            0xF8, 0x7C, 0x00, 0x00,
            0x19
        };

        internal static readonly byte[] BIOS_ID_SIGNATURE =
        {
            0x42, 0x49, 0x4F, 0x53,
            0x20, 0x49, 0x44, 0x3A
        };

        internal static readonly byte[] MODEL_SIGNATURE =
        {
            0x4D, 0x6F, 0x64, 0x65, 
            0x6C, 0x3A
        };

        internal static readonly byte[] EFI_VERSION_SIGNATURE =
        {
            0x45, 0x46, 0x49, 0x20,
            0x56, 0x65, 0x72, 0x73,
            0x69, 0x6F, 0x6E, 0x3A
        };

        internal static readonly byte[] BUILT_BY_SIGNATURE =
        {
            0x42, 0x75, 0x69, 0x6C,
            0x74, 0x20, 0x62, 0x79,
            0x3A
        };

        internal static readonly byte[] DATE_SIGNATURE =
        {
            0x44, 0x61, 0x74, 0x65,
            0x3A
        };

        internal static readonly byte[] ROM_VERSION_SIGNATURE =
        {
            0x52, 0x4F, 0x4D, 0x20,
            0x56, 0x65, 0x72, 0x73,
            0x69, 0x6F, 0x6E, 0x3A
        };

        internal static readonly byte[] FPT_HEADER_SIG =
{
            0x24, 0x46, 0x50, 0x54
        };

        internal static readonly byte[] MN2_SIG =
        {
            0x24, 0x4D, 0x4E, 0x32
        };

        internal static readonly byte[] FLASH_DESC_SIG =
        {
            0x5A, 0xA5, 0xF0, 0x0F
        };

        internal static readonly byte[] IBIOSI_SIG =
        {
            0x24, 0x49, 0x42, 0x49,
            0x4F, 0x53, 0x49, 0x24
        };

    }
}