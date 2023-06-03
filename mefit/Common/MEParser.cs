// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MEParser.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{

    #region Struct
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FptHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal byte HeaderVersion;
        internal byte EntryVersion;
        internal byte HeaderLength;
        internal byte Checksum;
        internal ushort FlashCycleLife;
        internal ushort FlashCycleLimit;
        internal uint UmaSize;
        internal uint Flags;
        internal ushort Major;
        internal ushort Minor;
        internal ushort Hotfix;
        internal ushort Build;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Mn2PartialHeader
    {
        // Right now we don't care about the pre-signature stuff, only the ME Version.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal ushort Major;
        internal ushort Minor;
        internal ushort Hotfix;
        internal ushort Build;
    }
    #endregion

    class MEParser
    {
        internal static string GetFITCVersion(byte[] bytesIn)
        {
            var offset = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FPT_HEADER_SIG);
            if (offset == -1) return "N/A";
            var headerBytes = BinaryUtils.GetBytesAtOffset(bytesIn, offset, 0x20);
            if (headerBytes == null) return "N/A";
            var header = Helper.DeserializeHeader<FptHeader>(headerBytes);
            return $"{header.Major}.{header.Minor}.{header.Hotfix}.{header.Build}";
        }
        internal static string GetMEVersion(byte[] bytesIn)
        {
            var offset = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.MN2_SIG);
            if (offset == -1) return "N/A";
            var headerBytes = BinaryUtils.GetBytesAtOffset(bytesIn, offset, 0x10);
            if (headerBytes == null) return "N/A";
            var header = Helper.DeserializeHeader<Mn2PartialHeader>(headerBytes);
            return $"{header.Major}.{header.Minor}.{header.Hotfix}.{header.Build}";
        }
    }
}
