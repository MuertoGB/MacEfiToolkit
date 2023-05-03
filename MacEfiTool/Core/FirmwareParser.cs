// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// FirmwareParser.cs - Handles parsing of firmware data
// Updated 03.05.23 - Moved guids and signatures to /Filesystem.cs
// Released under the GNU GLP v3.0

using System;
using System.Text;
using System.Windows.Forms;

using Mac_EFI_Toolkit.Utils;

namespace Mac_EFI_Toolkit.Core
{
    class FirmwareParser
    {
        internal static readonly Encoding utf8Enc = Encoding.UTF8;

        #region Fsys Data
        internal static byte[] GetFsysBlock(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FSYS_SIG);
            return (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset, 0x800) : null;
        }

        internal static string GetFsysCrc32(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FSYS_SIG);
            byte[] byteCsum = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x7FC, 0x4) : null;
            byte[] data = (byteCsum != null) ? FileUtils.SwitchCrc32Endianness(byteCsum) : null;
            return (data != null) ? BitConverter.ToString(data).Replace("-", "") : "Not found";
        }

        internal static string GetFsysSerialNumber(byte[] bytesIn)
        {
            long ssnOffset = BinaryUtils.FindOffset(bytesIn, Filesystem.SSN_SIG) + 0x6;
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
            return (offset != -1) ? String.Concat("Mac-", BitConverter.ToString(BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x5, 0x8)).Replace("-", "")) : "Not found";
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

namespace Mac_EFI_Toolkit
{
    public enum ApfsCompatibleFirmware
    {
        Unknown,
        Yes,
        No
    }
}