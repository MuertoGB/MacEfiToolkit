﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MEParser.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{

    #region Structs
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FPTHeader
    {
        internal uint Tag;
        internal uint NumEntries;
        internal byte HeaderVersion;
        internal byte EntryVersion;
        internal byte HeaderLength;
        internal byte HeaderChecksum;
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
    internal struct MN2Manifest
    {
        internal uint Tag;
        internal uint NumEntries;
        internal ushort EngineMajor;
        internal ushort EngineMinor;
        internal ushort EngineHotfix;
        internal ushort EngineBuild;
    }
    #endregion

    #region MEParser
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
            int meBase = (Descriptor.MeBase != 0 ? (int)Descriptor.MeBase : 0);
            int meLimit = (Descriptor.MeLimit != 0 ? (int)Descriptor.MeLimit : FWBase.FileInfoData.FileLength);

            int headerPos = -1;
            int readLen = 0;
            string result = null;

            switch (headerType)
            {
                case HeaderType.FlashImageTool:
                    headerPos = BinaryUtils.GetBasePosition(sourceBytes, FPT_SIGNATURE, meBase, meLimit);
                    readLen = 0x20;
                    break;

                case HeaderType.ManagementEngine:
                    headerPos = BinaryUtils.GetBasePosition(sourceBytes, MN2_SIGNATURE, meBase, meLimit);
                    readLen = 0x10;
                    break;
            }

            if (headerPos != -1)
            {
                byte[] headerBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, headerPos, readLen);
                if (headerBytes != null)
                {
                    if (headerType == HeaderType.FlashImageTool)
                    {
                        FPTHeader fptHeader = Helper.DeserializeHeader<FPTHeader>(headerBytes);
                        result = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                    }
                    else if (headerType == HeaderType.ManagementEngine)
                    {
                        MN2Manifest mn2Header = Helper.DeserializeHeader<MN2Manifest>(headerBytes);
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