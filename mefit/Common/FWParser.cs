// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWParser.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Common
{

    #region Struct
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NvramStoreHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal ushort SizeOfData;
    }

    internal struct NvramStoreData
    {
        internal int PrimaryStoreSize { get; set; }
        internal long PrimaryStoreOffset { get; set; }
        internal int BackupStoreSize { get; set; }
        internal long BackupStoreOffset { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FlashDescriptor
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        internal byte[] ReservedVector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal byte[] Signature;
    }

    internal struct FsysRegion
    {
        internal byte[] BlockBytes { get; set; }
        internal long Offset { get; set; }
    }

    #endregion

    #region Enum
    public enum ApfsCompatibleFirmware
    {
        Unknown,
        Yes,
        No
    }

    public enum NVRAMStoreType
    {
        VSS,
        SVS,
        NSS
    }
    #endregion

    class FWParser
    {

        #region Internal Members
        internal static string strLoadedBinaryFilePath = string.Empty;
        internal static string strFilenameWithoutExt = string.Empty;
        internal static string strCreationTime = string.Empty;
        internal static string strModifiedTime = string.Empty;
        internal static string strFilename = string.Empty;
        internal static string strSerialNumber = string.Empty;
        internal static string strHwc = string.Empty;
        internal static string strEfiVersion = string.Empty;
        internal static string strBootromVersion = string.Empty;
        internal static string strApfsCapable = string.Empty;
        internal static string strFsysChecksumInBinary = string.Empty;
        internal static string strRealFsysChecksum = string.Empty;
        internal static string strFitcVersion = string.Empty;
        internal static string strMeVersion = string.Empty;
        internal static string strBoardId = string.Empty;
        internal static string strSon = string.Empty;

        internal static byte[] bytesLoadedFile = null;
        internal static byte[] bytesLoadedFsys = null;

        internal static uint uiCrcOfLoadedFile = 0;

        internal static long lFilesize = 0;
        internal static long lFsysOffset = 0;

        internal static readonly int intMinROMSize = 1048576;
        internal static readonly int intMaxROMSize = 33554432;
        internal static readonly int intFsysRegionExactSize = 0x800;
        #endregion

        #region Private Members
        private static readonly Encoding _utf8Encoding = Encoding.UTF8;
        private static readonly int _maxPaddingBytes = 0x60; // This value may need tweaking.
        #endregion

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
            var result = "N/A";

            if (offsetPdr != -1)
            {
                var offsetBid = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.BID_SIG, offsetPdr);
                if (offsetBid != -1)
                {
                    var bytesBoardId = BinaryUtils.GetBytesAtOffset(bytesIn, offsetBid + 0x5, 0x8);
                    var boardId = BitConverter.ToString(bytesBoardId).Replace("-", "");

                    if (!boardId.All(c => c == '0'))
                    {
                        result = $"Mac-{boardId}";
                    }
                }
            }

            return result;
        }
        #endregion

        #region Fsys Data
        internal static FsysRegion GetFsysRegionBytes(byte[] bytesIn, bool outputOffset = false)
        {
            long offsetFsysRgn = -1;
            offsetFsysRgn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);

            byte[] bytesFsysRgn = null;
            if (offsetFsysRgn != -1)
            {
                bytesFsysRgn = BinaryUtils.GetBytesAtOffset(bytesIn, offsetFsysRgn, 0x800);
            }

            if (outputOffset)
            {
                return new FsysRegion { BlockBytes = bytesFsysRgn, Offset = offsetFsysRgn };
            }
            else
            {
                return new FsysRegion { BlockBytes = bytesFsysRgn, Offset = -1 };
            }
        }

        internal static string GetFsysRegionCRC32(byte[] bytesIn)
        {
            var offsetFsysCrc = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.FSYS_SIG);

            byte[] bytesCrc32 = null;
            if (offsetFsysCrc != -1)
            {
                bytesCrc32 = BinaryUtils.GetBytesAtOffset(bytesIn, offsetFsysCrc + 0x7FC, 0x4);
            }

            byte[] bytesOrdered = null;
            if (bytesCrc32 != null)
            {
                bytesOrdered = bytesCrc32.Reverse().ToArray();
            }

            if (bytesOrdered != null)
            {
                return BitConverter.ToString(bytesOrdered).Replace("-", "");
            }
            else
            {
                return "N/A";
            }
        }

        internal static string GetFsysRegionSerialNumber(byte[] bytesIn)
        {
            var offsetSsn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SSN_UPPER_SIG);
            var result = "N/A";

            if (offsetSsn == -1)
            {
                offsetSsn = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SSN_LOWER_SIG);
            }

            if (offsetSsn != -1)
            {
                byte[] bytesSsnData = BinaryUtils.GetBytesAtOffset(bytesIn, offsetSsn + 0x05, 0x0C);

                if (bytesSsnData != null)
                {
                    // Remove any non-alphanumeric characters from the serial number
                    var strSerial = _utf8Encoding.GetString(bytesSsnData).Trim();
                    strSerial = new string(strSerial.Where(Char.IsLetterOrDigit).ToArray());
                    result = strSerial;
                }
            }

            return result;
        }


        internal static string GetFsysRegionSon(byte[] bytesIn)
        {
            var offsetSon = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.SON_SIG);

            if (offsetSon != -1)
            {
                byte[] bytesSon = BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetSon, 0x00, 0x03, 0x04, 0x09);

                if (bytesSon != null)
                {
                    return _utf8Encoding.GetString(bytesSon);
                }
            }

            return "N/A";
        }

        internal static string GetFsysRegionHwc(byte[] bytesIn)
        {
            var offsetHwc = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.HWC_SIG);

            if (offsetHwc != -1)
            {
                byte[] bytesHwc = BinaryUtils.GetBytesAtOffset(bytesIn, offsetHwc + 0x6, 0x4);

                if (bytesHwc != null)
                {
                    string strHwc = _utf8Encoding.GetString(bytesHwc).Trim();
                    strHwc = new string(strHwc.Where(Char.IsLetterOrDigit).ToArray());
                    return strHwc;
                }
            }

            return "N/A";
        }
        #endregion

        #region Apple ROM Section Data
        internal static string GetRomSectionEFIVersion(byte[] bytesIn)
        {
            var offsetEfiVer = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.EFIVER_SIG);

            if (offsetEfiVer != -1)
            {
                byte[] bytesEfiVer = BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetEfiVer + FSSignatures.EFIVER_SIG.Length, 0x20, 0x0A);

                if (bytesEfiVer != null)
                {
                    return _utf8Encoding.GetString(bytesEfiVer);
                }
            }

            return "N/A";
        }

        internal static string GetRomSectionBootROMVersion(byte[] bytesIn)
        {
            var offsetRomVer = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.ROMVER_SIG);

            if (offsetRomVer != -1)
            {
                byte[] bytesRomVer = BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetRomVer + FSSignatures.ROMVER_SIG.Length, 0x20, 0x0A);

                if (bytesRomVer != null)
                {
                    return _utf8Encoding.GetString(bytesRomVer);
                }
            }

            return "N/A";
        }

        internal static string GetEfiSectionModelIdentifier(byte[] bytesIn)
        {
            var offsetGuid = BinaryUtils.GetLongOffset(bytesIn, FSGuids.EFI_BIOS_ID_GUID);

            if (offsetGuid != -1)
            {
                var offsetSection = BinaryUtils.GetLongOffset(bytesIn, FSSignatures.IBIOSI_SIG);

                if (offsetSection != -1)
                {
                    byte[] bytesData = BinaryUtils.GetBytesAtOffsetByteDelimited(bytesIn, offsetSection, 0x20, 0x2E);

                    if (bytesData != null)
                    {
                        bytesData = bytesData.Where(b => b != 0x00 && b != 0x20).ToArray();
                        return Encoding.UTF8.GetString(bytesData);
                    }
                }
            }

            return "N/A";
        }

        #endregion

        #region NVRAM Data
        internal static NvramStoreData GetNvramStoreInfo(byte[] bytesIn, NVRAMStoreType headerType)
        {
            var nvStoreSig = GetSignature(headerType);
            var offsetNvStore = BinaryUtils.GetLongOffset(bytesIn, nvStoreSig);
            var primaryStoreSize = -1;
            long primaryStoreOffset = -1;

            if (offsetNvStore != -1 && BinaryUtils.GetBytesAtOffset(bytesIn, offsetNvStore, 0x6) is byte[] bytesPrimaryHeader)
            {
                NvramStoreHeader nvPrimaryStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesPrimaryHeader);
                if (nvPrimaryStoreHeader.SizeOfData != 0)
                {
                    primaryStoreSize = nvPrimaryStoreHeader.SizeOfData;
                    primaryStoreOffset = offsetNvStore;

                }
            }

            var backupStoreSize = -1;
            long backupStoreOffset = -1;

            if (primaryStoreOffset != -1) // If we did not find the primary store, why would we be looking for the backup store?
            {
                // We're looking for the backup store within a certain max padding length from the end of the primary store,
                // if we don't find the signature within the maxSearchLength, we abort.
                var offsetNvBackup = BinaryUtils.GetLongOffset(bytesIn, nvStoreSig, offsetNvStore + primaryStoreSize, _maxPaddingBytes);

                if (offsetNvBackup != -1 && BinaryUtils.GetBytesAtOffset(bytesIn, offsetNvStore, 0x6) is byte[] bytesBackupHeader)
                {
                    NvramStoreHeader nvBackupStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesBackupHeader);
                    if (nvBackupStoreHeader.SizeOfData != 0)
                    {
                        backupStoreSize = nvBackupStoreHeader.SizeOfData;
                        backupStoreOffset = offsetNvBackup;
                    }
                }
            }

            return new NvramStoreData
            {
                PrimaryStoreSize = primaryStoreSize,
                PrimaryStoreOffset = primaryStoreOffset,
                BackupStoreSize = backupStoreSize,
                BackupStoreOffset = backupStoreOffset
            };

        }

        private static byte[] GetSignature(NVRAMStoreType headerType)
        {
            switch (headerType)
            {
                case NVRAMStoreType.SVS:
                    return FSSignatures.NVRAM_SVS_SIG;
                case NVRAMStoreType.VSS:
                    return FSSignatures.NVRAM_VSS_SIG;
                case NVRAMStoreType.NSS:
                    return FSSignatures.NVRAM_NSS_SIG;
                default:
                    throw new ArgumentException("Invalid NVRAM header type.");
            }
        }
        #endregion

        #region APFSJumpStart Dxe searcher
        internal static ApfsCompatibleFirmware GetIsApfsCapableBool(byte[] bytesIn)
        {
            long offsetApfsGuid = BinaryUtils.GetLongOffset(bytesIn, FSGuids.APFS_DXE_GUID);
            if (offsetApfsGuid != -1)
            {
                return ApfsCompatibleFirmware.Yes;
            }

            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch))
            {
                return ApfsCompatibleFirmware.Unknown;
            }

            long offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, FSGuids.LZMA_DXE_NEW_GUID);
            if (offsetLzmaSection == -1)
            {
                offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, FSGuids.LZMA_DXE_OLD_GUID);
            }

            if (offsetLzmaSection != -1)
            {
                offsetLzmaSection = BinaryUtils.GetLongOffset(bytesIn, new byte[] { 0x5D }, offsetLzmaSection + 0x10);
                long offsetEndOfLzma = BinaryUtils.GetLongOffset(bytesIn, FSGuids.ROM_INFO_GUID, offsetLzmaSection);

                if (offsetEndOfLzma != -1)
                {
                    byte[] byteCompressedVol = BinaryUtils.RemoveTrailingFFPadding(BinaryUtils.GetBytesBetweenOffsets(bytesIn, offsetLzmaSection, offsetEndOfLzma));
                    byte[] byteDecompressedVol = LzmaCoder.Decompress(byteCompressedVol);
                    long offsetApfsDecompressed = BinaryUtils.GetLongOffset(byteDecompressedVol, FSGuids.APFS_DXE_GUID);

                    if (offsetApfsDecompressed != -1)
                    {
                        return ApfsCompatibleFirmware.Yes;
                    }
                    else
                    {
                        return ApfsCompatibleFirmware.No;
                    }
                }
                else
                {
                    return ApfsCompatibleFirmware.Unknown;
                }
            }

            return ApfsCompatibleFirmware.No;
        }

        #endregion

        #region Clear Data
        internal static void ClearData()
        {
            string[] strFields =
            {
                strLoadedBinaryFilePath, strFilenameWithoutExt, strCreationTime, strModifiedTime,
                strFilename, strSerialNumber, strHwc, strEfiVersion, strBootromVersion,
                strApfsCapable, strFsysChecksumInBinary, strRealFsysChecksum, strFitcVersion,
                strMeVersion, strBoardId, strSon
            };
            for (int i = 0; i < strFields.Length; i++)
            {
                strFields[i] = string.Empty;
            }

            byte[][] byteFields =
{
                bytesLoadedFile, bytesLoadedFsys
            };
            for (int i = 0; i < byteFields.Length; i++)
            {
                byteFields[i] = null;
            }

            uiCrcOfLoadedFile = 0;
            lFilesize = 0;
            lFsysOffset = 0;
        }
        #endregion

    }
}