// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FirmwareParser.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.Common
{

    #region Struct
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NvramSectionHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal ushort SizeOfData;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FlashDescriptor
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        internal byte[] ReservedVector; // 0xFF
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal byte[] Signature; // 0x5AA5FOOF
    }

    internal struct FsysBlock
    {
        public byte[] BlockBytes { get; set; }
        public long Offset { get; set; }
    }
    #endregion

    #region Enum
    public enum ApfsCompatibleFirmware
    {
        Unknown,
        Yes,
        No
    }

    public enum NVRAMHeaderType
    {
        SVS,
        VSS
    }
    #endregion

    class FirmwareParser
    {
        internal static readonly Encoding encUtf8 = Encoding.UTF8;
        internal static readonly int intMinROMSize = 1048576;
        internal static readonly int intMaxROMSize = 33554432;
        internal static readonly int intFsysRegionSize = 0x800;

        #region Flash Header
        internal static bool GetIsValidFlashHeader(byte[] bytesIn)
        {
            byte[] bytesHeader = BinaryUtils.GetBytesAtOffset(bytesIn, 0, 0x14);
            FlashDescriptor flDescriptor = Helper.DeserializeHeader<FlashDescriptor>(bytesHeader);

            if (flDescriptor.Signature.SequenceEqual(FSSignatures.FLASH_DESC_SIG))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Platform Data Region Data
        internal static string GetBoardId(byte[] bytesIn)
        {
            var offsetPdr = BinaryUtils.GetLongOffset(bytesIn, FSGuids.PDR_SECTION_BID_GUID);
            if (offsetPdr == -1) return "Not found";

            var offsetBid = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.BID_SIG, offsetPdr);
            if (offsetBid == -1) return "Not found";

            var bytesBoardId = BinaryUtils.GetBytesAtOffset(bytesIn, offsetBid + 0x5, 0x8);
            var boardId = BitConverter.ToString(bytesBoardId).Replace("-", "");
            return boardId.All(c => c == '0') ? "Not found" : $"Mac-{boardId}";
        }

        #endregion

        #region Fsys Data
        internal static FsysBlock GetFsysRegionBytes(byte[] bytesIn, bool outputOffset = false)
        {
            long offsetFsysRgn = -1; // default value if calculate_offset is false
            offsetFsysRgn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);
            byte[] bytesFsysRgn = (offsetFsysRgn != -1) ? BinaryUtils.GetBytesAtOffset(bytesIn, offsetFsysRgn, 0x800) : null;
            return new FsysBlock { BlockBytes = bytesFsysRgn, Offset = outputOffset ? offsetFsysRgn : -1 };
        }

        internal static string GetFsysRegionCRC32(byte[] bytesIn)
        {
            var offsetFsysCrc = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);
            byte[] bytesCrc32 = BinaryUtils.GetBytesAtOffset(bytesIn, offsetFsysCrc + 0x7FC, 0x4);
            byte[] bytesOrdered = (bytesCrc32 != null) ? bytesCrc32.Reverse().ToArray() : null;
            return (bytesOrdered != null) ? BitConverter.ToString(bytesOrdered).Replace("-", "") : "Not found";
        }

        internal static string GetFsysRegionSerialNumber(byte[] bytesIn)
        {
            var offsetSsn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SSN_UPPER_SIG);
            if (offsetSsn == -1) offsetSsn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SSN_LOWER_SIG);
            if (offsetSsn == -1) return "Not found";

            byte[] bytesSsnData = BinaryUtils.GetBytesAtOffset(bytesIn, offsetSsn + 0x05, 0x0C);

            if (bytesSsnData != null)
            {
                // Remove any non-alphanumeric characters from the serial number
                var strSerial = encUtf8.GetString(bytesSsnData).Trim();
                strSerial = new string(strSerial.Where(Char.IsLetterOrDigit).ToArray());
                return strSerial;
            }
            else
            {
                return "Not found";
            }
        }

        internal static string GetFsysRegionSon(byte[] bytesIn)
        {
            var offsetSon = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SON_SIG);
            byte[] bytesSon = (offsetSon != -1) ? BinaryUtils.GetBytesAtOffset(bytesIn, offsetSon + 0x6, 0x5) : null;
            return (bytesSon != null) ? encUtf8.GetString(bytesSon) : "Not found";
        }

        internal static string GetFsysRegionHwc(byte[] bytesIn)
        {
            var offsetHwc = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.HWC_SIG);
            if (offsetHwc != -1)
            {
                byte[] bytesHwc = BinaryUtils.GetBytesAtOffset(bytesIn, offsetHwc + 0x6, 0x4);

                if (bytesHwc != null)
                {
                    string strHwc = encUtf8.GetString(bytesHwc).Trim();
                    strHwc = new string(strHwc.Where(Char.IsLetterOrDigit).ToArray());
                    return strHwc;
                }
            }
            return "Not found";
        }

        #endregion

        #region Apple ROM Section Data
        internal static string GetRomSectionEFIVersion(byte[] bytesIn)
        {
            var offsetEfiVer = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.EFIVER_SIG);
            return (offsetEfiVer != -1) ? encUtf8.GetString(BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetEfiVer + FSSignatures.EFIVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }

        internal static string GetRomSectionBootROMVersion(byte[] bytesIn)
        {
            var offsetRomVer = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.ROMVER_SIG);
            return (offsetRomVer != -1) ? encUtf8.GetString(BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetRomVer + FSSignatures.ROMVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }
        #endregion

        #region NVRAM Data

        internal static int GetNVRAMSectionSize(byte[] bytesIn, NVRAMHeaderType HeaderType)
        {
            var offsetNvSectSizeData = BinaryUtils.GetLongOffset(bytesIn, HeaderType == NVRAMHeaderType.SVS ? FSSignatures.SVS_SIG : FSSignatures.VSS_SIG);
            if (offsetNvSectSizeData != -1 && BinaryUtils.GetBytesAtOffset(bytesIn, offsetNvSectSizeData, 0x6) is byte[] bytesHeader)
            {
                NvramSectionHeader nvHeader = Helper.DeserializeHeader<NvramSectionHeader>(bytesHeader);
                if (nvHeader.SizeOfData != 0)
                {
                    return nvHeader.SizeOfData;
                }
            }
            return -1;
        }
        #endregion

        #region APFSJumpStart Dxe searcher
        internal static ApfsCompatibleFirmware GetIsApfsCapableBool(byte[] bytesIn)
        {
            long offsetApfsGuid = BinaryUtils.GetLongOffset(bytesIn, FSGuids.APFS_DXE_GUID);
            if (offsetApfsGuid != -1) return ApfsCompatibleFirmware.Yes;

            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch)) return ApfsCompatibleFirmware.Unknown;

            long offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, FSGuids.LZMA_DXE_NEW_GUID);
            if (offsetLzmaSection == -1) offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, FSGuids.LZMA_DXE_OLD_GUID);
            if (offsetLzmaSection != -1)
            {
                offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, new byte[] { 0x5D }, offsetLzmaSection + 0x10);
                long offsetEndOfLzma = BinaryUtils.GetLongOffset(bytesIn, FSGuids.ROM_INFO_GUID, offsetLzmaSection);
                if (offsetEndOfLzma != -1)
                {
                    byte[] byteCompressedVol = BinaryUtils.RemoveTrailingFFPadding(BinaryUtils.GetBytesBetweenOffsets(bytesIn, offsetLzmaSection, offsetEndOfLzma));
                    byte[] byteDecompressedVol = LzmaCoder.Decompress(byteCompressedVol);
                    long offsetApfsDecompressed = BinaryUtils.GetLongOffset(byteDecompressedVol, FSGuids.APFS_DXE_GUID);
                    return (offsetApfsDecompressed != -1) ? ApfsCompatibleFirmware.Yes : ApfsCompatibleFirmware.No;
                }
                else
                {
                    return ApfsCompatibleFirmware.Unknown;
                }
            }
            return ApfsCompatibleFirmware.No;
        }
        #endregion

    }
}