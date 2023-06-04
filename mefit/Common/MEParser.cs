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
        internal ushort FitcMajor;
        internal ushort FitcMinor;
        internal ushort FitcHotfix;
        internal ushort FitcBuild;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Mn2PartialHeader
    {
        // Right now we only care about the ME version.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal ushort EngineMajor;
        internal ushort EngineMinor;
        internal ushort EngineHotfix;
        internal ushort EngineBuild;
    }
    #endregion

    class MEParser
    {
        internal static string GetFitcVersion(byte[] bytesIn)
        {
            var fptOffset = BinaryUtils.GetOffset(bytesIn, FSSignatures.FPT_HEADER_SIG);
            if (fptOffset == -1) return "N/A";
            var readLength = 0x20;
            var headerBytes = BinaryUtils.GetBytesAtOffset(bytesIn, fptOffset, readLength);
            if (headerBytes == null) return "N/A";
            var fptHeader = Helper.DeserializeHeader<FptHeader>(headerBytes);
            return $"{fptHeader.FitcMajor}.{fptHeader.FitcMinor}.{fptHeader.FitcHotfix}.{fptHeader.FitcBuild}";
        }
        internal static string GetManagementEngineVersion(byte[] bytesIn)
        {
            var mn2Offset = BinaryUtils.GetOffset(bytesIn, FSSignatures.MN2_SIG);
            if (mn2Offset == -1) return "N/A";
            var readLength = 0x10;
            var headerBytes = BinaryUtils.GetBytesAtOffset(bytesIn, mn2Offset, readLength);
            if (headerBytes == null) return "N/A";
            var mn2Header = Helper.DeserializeHeader<Mn2PartialHeader>(headerBytes);
            return $"{mn2Header.EngineMajor}.{mn2Header.EngineMinor}.{mn2Header.EngineHotfix}.{mn2Header.EngineBuild}";
        }
    }
}
