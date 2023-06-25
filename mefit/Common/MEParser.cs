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
            int headerPos = -1; int readLen = 0; string result = null;

            switch (headerType)
            {
                case HeaderType.FlashImageTool:
                    headerPos = BinaryUtils.GetOffset(sourceBytes, FPT_SIGNATURE);
                    readLen = 0x20;
                    break;

                case HeaderType.ManagementEngine:
                    headerPos = BinaryUtils.GetOffset(sourceBytes, MN2_SIGNATURE);
                    readLen = 0x10;
                    break;
            }

            if (headerPos != -1)
            {
                byte[] headerBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, headerPos, readLen);
                if (headerBytes != null)
                {
                    if (headerType == HeaderType.FlashImageTool)
                    {
                        FptHeader fptHeader = Helper.DeserializeHeader<FptHeader>(headerBytes);
                        result = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                    }
                    else if (headerType == HeaderType.ManagementEngine)
                    {
                        Mn2PartialHeader mn2Header = Helper.DeserializeHeader<Mn2PartialHeader>(headerBytes);
                        result = $"{mn2Header.EngineMajor}.{mn2Header.EngineMinor}.{mn2Header.EngineHotfix}.{mn2Header.EngineBuild}";
                    }
                }
            }

            if (result == "0.0.0.0") return null;

            return result;
        }


        internal static readonly byte[] FPT_SIGNATURE =
        {
            0x24, 0x46, 0x50, 0x54
        };

        internal static readonly byte[] MN2_SIGNATURE =
        {
            0x24, 0x4D, 0x4E, 0x32
        };

    }
}