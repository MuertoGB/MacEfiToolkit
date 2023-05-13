﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FSGuids.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Common
{
    class FSGuids
    {
        internal static readonly byte[] LZMA_DXE_OLD_GUID =
        {
            0xDB, 0x7F, 0xAD, 0x77,
            0x2A, 0xDF, 0x02, 0x43,
            0x88, 0x98, 0xC7, 0x2E,
            0x4C, 0xDB, 0xD0, 0xF4
        };
        internal static readonly byte[] LZMA_DXE_NEW_GUID =
        {
            0x79, 0xDE, 0xD3, 0x2A,
            0xE9, 0x63, 0x4F, 0x9B,
            0xB6, 0x4F, 0xE7, 0xC6,
            0x18, 0x1B, 0x0C, 0xEC
        };
        internal static readonly byte[] APFS_DXE_GUID =
        {
            0xF4, 0x32, 0xFB, 0xCF,
            0xA8, 0xC2, 0xBB, 0x48,
            0xA0, 0xEB, 0x6C, 0x3C,
            0xCA, 0x3F, 0xE8, 0x47
        };
        internal static readonly byte[] ROM_INFO_GUID =
        {
            0xF6, 0xAB, 0x35, 0xB5,
            0x7D, 0x96, 0xF2, 0x43,
            0xB4, 0x94, 0xA1, 0xEB,
            0x8E, 0x21, 0xA2, 0x8E
        };
        internal static readonly byte[] NV_DATA_GUID =
        {
            0x8D, 0x2B, 0xF1, 0xFF,
            0x96, 0x76, 0x8B, 0x4C,
            0xA9, 0x85, 0x27, 0x47,
            0x07, 0x5B, 0x4F, 0x50
        };
    }
}