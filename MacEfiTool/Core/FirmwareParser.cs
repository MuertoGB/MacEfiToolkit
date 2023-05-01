// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// FirmwareParser.cs - Handles parsing of firmware data
// Updated 30.04.2023 - Support 11 char serial numbers.
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

        #region Signatures
        internal static readonly byte[] SIG_FSYS =
            { 0x46, 0x73, 0x79, 0x73, 0x01 };
        internal static readonly byte[] SIG_SSN =
            { 0x03, 0x73, 0x73, 0x6E };
        internal static readonly byte[] SIG_SON =
            { 0x03, 0x73, 0x6F, 0x6E };
        internal static readonly byte[] SIG_SVS =
            { 0x24, 0x53, 0x56, 0x53, 0xB0, 0x1F, 0x00, 0x00, 0x5A, 0xFE, 0xFE };
        internal static readonly byte[] SIG_BID =
            { 0xF8, 0x7C, 0x00, 0x00, 0x19 };
        internal static readonly byte[] SIG_ABIOS =
            { 0x41, 0x70, 0x70, 0x6C, 0x65, 0x20, 0x52, 0x4F, 0x4D };
        internal static readonly byte[] SIG_IBIOS =
            { 0x24, 0x49, 0x42, 0x49, 0x4F, 0x53, 0x49, 0x24 };
        internal static readonly byte[] SIG_EFIVER =
            { 0x45, 0x46, 0x49, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3A };
        internal static readonly byte[] SIG_ROMVER =
            { 0x52, 0x4F, 0x4D, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3A };
        #endregion

        #region GUIDs
        internal static readonly byte[] LZMA_DXE_OLD_GUID =
            { 0xDB, 0x7F, 0xAD, 0x77, 0x2A, 0xDF, 0x02, 0x43, 0x88, 0x98, 0xC7, 0x2E, 0x4C, 0xDB, 0xD0, 0xF4 };
        internal static readonly byte[] LZMA_DXE_NEW_GUID =
            { 0x79, 0xDE, 0xD3, 0x2A, 0xE9, 0x63, 0x4F, 0x9B, 0xB6, 0x4F, 0xE7, 0xC6, 0x18, 0x1B, 0x0C, 0xEC };
        internal static readonly byte[] APFS_DXE_GUID =
            { 0xF4, 0x32, 0xFB, 0xCF, 0xA8, 0xC2, 0xBB, 0x48, 0xA0, 0xEB, 0x6C, 0x3C, 0xCA, 0x3F, 0xE8, 0x47 };
        internal static readonly byte[] APPLE_ROM_INFO_GUID =
            { 0xF6, 0xAB, 0x35, 0xB5, 0x7D, 0x96, 0xF2, 0x43, 0xB4, 0x94, 0xA1, 0xEB, 0x8E, 0x21, 0xA2, 0x8E };
        #endregion

        #region Fsys Data
        internal static byte[] GetFsysBlock(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_FSYS);
            return (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset, 0x800) : null;
        }

        internal static string GetFsysCrc32(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_FSYS);
            byte[] byteCsum = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x7FC, 0x4) : null;
            byte[] data = (byteCsum != null) ? FileUtils.SwitchCrc32Endianness(byteCsum) : null;
            return (data != null) ? BitConverter.ToString(data).Replace("-", "") : "Not found";
        }

        internal static string GetFsysSerialNumber(byte[] bytesIn)
        {
            long ssnOffset = BinaryUtils.FindOffset(bytesIn, SIG_SSN) + 0x6;
            long ssnEndOffset = BinaryUtils.FindOffset(bytesIn, new byte[] { 0x3 }, ssnOffset);
            byte[] data = (ssnOffset != -1) ? BinaryUtils.ReadBytesBetweenOffsets(bytesIn, ssnOffset, ssnEndOffset) : null;
            return (data != null) ? utf8Enc.GetString(data) : "Not found";
        }

        internal static string GetFsysSon(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_SON);
            byte[] data = (offset != -1) ? BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x6, 0x5) : null;
            return (data != null) ? utf8Enc.GetString(data) : "Not found";
        }
        #endregion

        #region Platform Data Region Data
        internal static string GetPdrBoardId(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_BID);
            return (offset != -1) ? String.Concat("Mac-", BitConverter.ToString(BinaryUtils.ReadBytesAtOffset(bytesIn, offset + 0x5, 0x8)).Replace("-", "")) : "Not found";
        }
        #endregion

        #region Apple ROM Section Data
        internal static string GetEfiVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_EFIVER);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils.ReadBytesAtOffsetByteDelimited(bytesIn, offset + SIG_EFIVER.Length, 0x20, 0x0A)) : "Not found";
        }

        internal static string GetBootromVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, SIG_ROMVER);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils.ReadBytesAtOffsetByteDelimited(bytesIn, offset + SIG_ROMVER.Length, 0x20, 0x0A)) : "Not found";
        }
        #endregion

        #region APFSJumpStart Dxe searcher
        internal static ApfsCompatibleFirmware GetIsApfsCapable(byte[] bytesIn)
        {
            long offsetApfsGuid = BinaryUtils.FindOffset(bytesIn, APFS_DXE_GUID);
            if (offsetApfsGuid != -1) return ApfsCompatibleFirmware.Yes;

            long offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, LZMA_DXE_NEW_GUID);
            if (offsetDxeSectionLzma == -1) offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, LZMA_DXE_OLD_GUID);
            if (offsetDxeSectionLzma != -1)
            {
                offsetDxeSectionLzma = BinaryUtils.FindOffset(bytesIn, new byte[] { 0x5D }, offsetDxeSectionLzma + 0x10);
                long offsetAppleRomInfo = BinaryUtils.FindOffset(bytesIn, APPLE_ROM_INFO_GUID, offsetDxeSectionLzma);
                if (offsetAppleRomInfo != -1)
                {
                    byte[] compressedSection = BinaryUtils.RemoveTrailingFFPadding(BinaryUtils.ReadBytesBetweenOffsets(bytesIn, offsetDxeSectionLzma, offsetAppleRomInfo));
                    byte[] decompressedSection = LzmaCoder.Decompress(compressedSection);
                    long offsetApfsDecompressed = BinaryUtils.FindOffset(decompressedSection, APFS_DXE_GUID);
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
