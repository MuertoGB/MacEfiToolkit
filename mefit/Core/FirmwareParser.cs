// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// FirmwareParser.cs - Handles parsing of firmware data
// Updated 05.05.23 - Gain GetNvramSectionSize()
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Core
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
    };
    #endregion

    class FirmwareParser
    {

        internal static readonly Encoding utf8Enc = Encoding.UTF8;

        #region Flash Header
        internal static bool boolIsValidFlashHeader(byte[] bytesIn)
        {
            byte[] bytesFlashHeader = BinaryUtils.ReadBytesAtOffset(bytesIn, 0, 0x14);
            FlashDescriptor descriptor = Helper.DeserializeHeader<FlashDescriptor>(bytesFlashHeader);
            
            if (descriptor.Signature.SequenceEqual(Filesystem.FLASH_DESC_SIG))
            {
                return true;
            }

            return false;

        }
        #endregion

        #region Fsys Data
        internal static byte[] GetFsysBlock(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FSYS_SIG);
            return (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset, 0x800) : null;
        }

        //internal static string GetFsysCrc32(byte[] bytesIn)
        //{
        //    long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FSYS_SIG);
        //    if (offset == -1) return "Not found";
        //    byte[] byteCsum = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x7FC, 0x4) : null;
        //    byte[] data = (byteCsum != null) ? FileUtils.SwitchCrc32Endianness(byteCsum) : null;
        //    return (data != null) ? BitConverter.ToString(data).Replace("-", "") : "Not found";
        //}

        internal static string GetFsysCrc32(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FSYS_SIG);
            if (offset == -1) return "Not found";
            byte[] byteCsum = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x7FC, 0x4) : null;
            byte[] data = (byteCsum != null) ? FileUtils.SwitchCrc32Endianness(byteCsum) : null;
            return (data != null) ? BitConverter.ToString(data).Replace("-", "") : "Not found";
        }

        internal static string GetFsysSerialNumber(byte[] bytesIn)
        {
            long ssnOffset = BinaryUtils.FindOffset(bytesIn, Filesystem.SSN_SIG);
            if (ssnOffset != -1) ssnOffset += 0x6;
            long ssnEndOffset = BinaryUtils.FindOffset(bytesIn, new byte[] { 0x3 }, ssnOffset);
            byte[] data = (ssnOffset != -1) ? BinaryUtils.ReadBytesBetweenOffsets(bytesIn, ssnOffset, ssnEndOffset) : null;
            return (data != null) ? utf8Enc.GetString(data) : "Not found";
        }

        internal static string GetFsysSon(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.SON_SIG);
            byte[] data = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x6, 0x5) : null;
            return (data != null) ? utf8Enc.GetString(data) : "Not found";
        }
        #endregion

        #region Platform Data Region Data
        internal static string GetPdrBoardId(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.BID_SIG);
            byte[] boardIdBytes = BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x5, 0x8);
            return BitConverter.ToString(boardIdBytes).Replace("-", "").All(c => c == '0') ? "Not found"
                : String.Concat("Mac-", BitConverter.ToString(boardIdBytes).Replace("-", ""));
        }
        #endregion

        #region Apple ROM Section Data
        internal static string GetEfiVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.EFIVER_SIG);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils.ReadBytesAtOffsetByteDelimited(bytesIn, offset + Filesystem.EFIVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }

        internal static string GetBootromVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.ROMVER_SIG);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils.ReadBytesAtOffsetByteDelimited(bytesIn, offset + Filesystem.ROMVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }
        #endregion

        #region NVRAM Data
        private static readonly int HeaderDataSize = 0x6;

        internal static int GetNvramSectionSize(byte[] bytesIn, NVRAMHeaderType HeaderType)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, HeaderType == NVRAMHeaderType.SVS ? Filesystem.SVS_SIG : Filesystem.VSS_SIG);
            if (offset != -1 && BinaryUtils.ReadBytesAtOffset(bytesIn, offset, HeaderDataSize) is byte[] headerBytes)
            {
                NvramSectionHeader header = Helper.DeserializeHeader<NvramSectionHeader>(headerBytes);
                if (header.SizeOfData != 0)
                {
                    return header.SizeOfData;
                }
            }
            return -1;
        }
        #endregion

        #region APFSJumpStart Dxe searcher
        internal static ApfsCompatibleFirmware GetIsApfsCapable(byte[] bytesIn)
        {
            long offsetApfsGuid = BinaryUtils.FindOffset(bytesIn, Filesystem.APFS_DXE_GUID);
            if (offsetApfsGuid != -1) return ApfsCompatibleFirmware.Yes;

            long offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, Filesystem.LZMA_DXE_NEW_GUID);
            if (offsetDxeSectionLzma == -1) offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, Filesystem.LZMA_DXE_OLD_GUID);
            if (offsetDxeSectionLzma != -1)
            {
                offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, new byte[] { 0x5D }, offsetDxeSectionLzma + 0x10);
                long offsetAppleRomInfo = BinaryUtils.FindOffset(bytesIn, Filesystem.ROM_INFO_GUID, offsetDxeSectionLzma);
                if (offsetAppleRomInfo != -1)
                {
                    byte[] compressedSection = BinaryUtils.RemoveTrailingFFPadding(BinaryUtils.ReadBytesBetweenOffsets(bytesIn, offsetDxeSectionLzma, offsetAppleRomInfo));
                    byte[] decompressedSection = LzmaCoder.Decompress(compressedSection);
                    long offsetApfsDecompressed = BinaryUtils.FindOffset(decompressedSection, Filesystem.APFS_DXE_GUID);
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