// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// FirmwareParser.cs - Handles parsing of firmware data
// Updated 05.05.23 - Naming
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
        internal static bool _boolIsValidFlashHeader(byte[] bytesIn)
        {
            byte[] bytesFlashHeader = BinaryUtils._byteReadAtOffset(bytesIn, 0, 0x14);
            FlashDescriptor descriptor = Helper.DeserializeHeader<FlashDescriptor>(bytesFlashHeader);

            if (descriptor.Signature.SequenceEqual(Filesystem.FLASH_DESC_SIG))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Fsys Data
        internal static byte[] _byteGetFsysBlock(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.FSYS_SIG);
            return (offset != -1) ? BinaryUtils._byteReadAtOffset(bytesIn, offset, 0x800) : null;
        }

        internal static string _stringGetFsysCrc32(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.FSYS_SIG);
            byte[] byteCsum = BinaryUtils._byteReadAtOffset(bytesIn, offset + 0x7FC, 0x4);
            byte[] data = (byteCsum != null) ? byteCsum.Reverse().ToArray() : null;
            return (data != null) ? BitConverter.ToString(data).Replace("-", "") : "Not found";
        }

        // Okay we're back to the serial number bollocks again, as the last fix was not enough.
        // Thinking about it, a serial always starts with the upper or lower SSN, then bytes {0x0C, 0x00}.
        // After we get the 12 SN bytes, the only thing we have to worry about is an 11 digit SN,
        // as there will be a stray char on the end, so now we're just trimming any invalid char.
        internal static string _stringGetFsysSerialNumber(byte[] bytesIn)
        {
            long ssnOffset = BinaryUtils._longFindOffset(bytesIn, Filesystem.SSN_UPPER_SIG);
            if (ssnOffset == -1) ssnOffset = BinaryUtils._longFindOffset(bytesIn, Filesystem.SSN_LOWER_SIG);
            if (ssnOffset == -1) return "Not found";

            byte[] snData = BinaryUtils._byteReadAtOffset(bytesIn, ssnOffset + 0x05, 0x0C);

            if (snData != null)
            {
                // Remove any non-alphanumeric characters from the serial number
                string serialNumber = utf8Enc.GetString(snData).Trim();
                serialNumber = new string(serialNumber.Where(c => Char.IsLetterOrDigit(c)).ToArray());
                return serialNumber;
            }
            else
            {
                return "Not found";
            }
        }

        internal static string _stringGetFsysSon(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.SON_SIG);
            byte[] data = (offset != -1) ? BinaryUtils._byteReadAtOffset(bytesIn, offset + 0x6, 0x5) : null;
            return (data != null) ? utf8Enc.GetString(data) : "Not found";
        }
        #endregion

        #region Platform Data Region Data
        internal static string _stringGetPdrBoardId(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.BID_SIG);
            byte[] boardIdBytes = BinaryUtils._byteReadAtOffset(bytesIn, offset + 0x5, 0x8);
            return BitConverter.ToString(boardIdBytes).Replace("-", "").All(c => c == '0') ? "Not found"
                : String.Concat("Mac-", BitConverter.ToString(boardIdBytes).Replace("-", ""));
        }
        #endregion

        #region Apple ROM Section Data
        internal static string _stingGetEfiVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.EFIVER_SIG);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils._byteReadAtOffsetByteDelimited(bytesIn, offset + Filesystem.EFIVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }

        internal static string _stringGetBootromVersionFromAppleRomSection(byte[] bytesIn)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, Filesystem.ROMVER_SIG);
            return (offset != -1) ? utf8Enc.GetString(BinaryUtils._byteReadAtOffsetByteDelimited(bytesIn, offset + Filesystem.ROMVER_SIG.Length, 0x20, 0x0A)) : "Not found";
        }
        #endregion

        #region NVRAM Data
        private static readonly int HeaderDataSize = 0x6;

        internal static int _intGetNvramSectionSize(byte[] bytesIn, NVRAMHeaderType HeaderType)
        {
            long offset = BinaryUtils._longFindOffset(bytesIn, HeaderType == NVRAMHeaderType.SVS ? Filesystem.SVS_SIG : Filesystem.VSS_SIG);
            if (offset != -1 && BinaryUtils._byteReadAtOffset(bytesIn, offset, HeaderDataSize) is byte[] headerBytes)
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
        internal static ApfsCompatibleFirmware _getIsApfsCapable(byte[] bytesIn)
        {
            long offsetApfsGuid = BinaryUtils._longFindOffset(bytesIn, Filesystem.APFS_DXE_GUID);
            if (offsetApfsGuid != -1) return ApfsCompatibleFirmware.Yes;

            //TODO: Is this really the best place for this?
            if (Settings._settingsGetBool(SettingsBoolType.DisableLzmaFsSearch)) return ApfsCompatibleFirmware.Unknown;

            long offsetDxeSectionLzma = BinaryUtils._longFindOffset(bytesIn, Filesystem.LZMA_DXE_NEW_GUID);
            if (offsetDxeSectionLzma == -1) offsetDxeSectionLzma = BinaryUtils._longFindOffset(bytesIn, Filesystem.LZMA_DXE_OLD_GUID);
            if (offsetDxeSectionLzma != -1)
            {
                offsetDxeSectionLzma = BinaryUtils._longFindOffset(bytesIn, new byte[] { 0x5D }, offsetDxeSectionLzma + 0x10);
                long offsetAppleRomInfo = BinaryUtils._longFindOffset(bytesIn, Filesystem.ROM_INFO_GUID, offsetDxeSectionLzma);
                if (offsetAppleRomInfo != -1)
                {
                    byte[] compressedSection = BinaryUtils.RemoveTrailingFFPadding(BinaryUtils._byteReadBetweenOffsets(bytesIn, offsetDxeSectionLzma, offsetAppleRomInfo));
                    byte[] decompressedSection = LzmaCoder.Decompress(compressedSection);
                    long offsetApfsDecompressed = BinaryUtils._longFindOffset(decompressedSection, Filesystem.APFS_DXE_GUID);
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