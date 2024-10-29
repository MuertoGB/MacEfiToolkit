// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IntelME.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Utils;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware.EFI
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

    #region Enums
    internal enum VersionType
    {
        FlashImageTool,
        ManagementEngine
    }
    #endregion

    class IME
    {
        private static string _default = "0.0.0.0";

        internal static string GetVersionData(byte[] sourceBytes, VersionType versionType)
        {
            int headerPos = -1;
            int dataLength = 0;
            string version = null;

            switch (versionType)
            {
                case VersionType.FlashImageTool:
                    headerPos = BinaryUtils.GetBaseAddress(
                        sourceBytes,
                        FPT_SIGNATURE,
                        (int)IFD.ME_REGION_BASE,
                        (int)IFD.ME_REGION_SIZE);
                    dataLength = 0x20;
                    break;

                case VersionType.ManagementEngine:
                    headerPos = BinaryUtils.GetBaseAddress(
                        sourceBytes,
                        MN2_SIGNATURE,
                        (int)IFD.ME_REGION_BASE,
                        (int)IFD.ME_REGION_SIZE);
                    dataLength = 0x10;
                    break;
            }

            if (headerPos != -1)
            {
                byte[] headerBytes = BinaryUtils.GetBytesBaseLength(
                    sourceBytes,
                    headerPos + 2,
                    dataLength);

                if (headerBytes != null)
                {
                    if (versionType == VersionType.FlashImageTool)
                    {
                        FPTHeader fptHeader =
                            Helper.DeserializeHeader<FPTHeader>(
                                headerBytes);

                        version =
                            $"{fptHeader.FitMajor}." +
                            $"{fptHeader.FitMinor}." +
                            $"{fptHeader.FitHotfix}." +
                            $"{fptHeader.FitBuild}";
                    }
                    else if (versionType == VersionType.ManagementEngine)
                    {
                        MN2Manifest mn2Header =
                            Helper.DeserializeHeader<MN2Manifest>(
                                headerBytes);

                        version =
                            $"{mn2Header.EngineMajor}." +
                            $"{mn2Header.EngineMinor}." +
                            $"{mn2Header.EngineHotfix}." +
                            $"{mn2Header.EngineBuild}";
                    }
                }
            }

            if (string.IsNullOrEmpty(version) || version == _default)
                return null;

            return version;
        }

        internal static readonly byte[] FPT_SIGNATURE =
        {
            0x24, 0x46, 0x50, 0x54
        };

        internal static readonly byte[] MN2_SIGNATURE =
        {
            0x00, 0x00, 0x24,
            0x4D, 0x4E, 0x32
        };
    }
}