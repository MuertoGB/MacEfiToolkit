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
        internal ushort FitMajor;
        internal ushort FitMinor;
        internal ushort FitHotfix;
        internal ushort FitBuild;
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

    #region Enum
    internal enum HeaderType
    {
        FlashImageTool,
        ManagementEngine
    }
    #endregion

    class MEParser
    {
        internal static string GetVersionData(byte[] sourceBytes, HeaderType headerType)
        {
            long headerOffset;
            int readLength;
            string versionString = "N/A";

            switch (headerType)
            {
                case HeaderType.FlashImageTool:
                    headerOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FPT_HEADER_SIG);
                    readLength = 0x20;
                    if (headerOffset != -1)
                    {
                        var headerBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, headerOffset, readLength);
                        if (headerBytes != null)
                        {
                            var fptHeader = Helper.DeserializeHeader<FptHeader>(headerBytes);
                            versionString = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                        }
                    }
                    break;

                case HeaderType.ManagementEngine:
                    headerOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.MN2_SIG);
                    readLength = 0x10;
                    if (headerOffset != -1)
                    {
                        var headerBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, headerOffset, readLength);
                        if (headerBytes != null)
                        {
                            var mn2Header = Helper.DeserializeHeader<Mn2PartialHeader>(headerBytes);
                            versionString = $"{mn2Header.EngineMajor}.{mn2Header.EngineMinor}.{mn2Header.EngineHotfix}.{mn2Header.EngineBuild}";
                        }
                    }
                    break;
            }

            return versionString;
        }
    }
}
