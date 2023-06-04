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
    internal struct FlashDescriptor
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
    internal enum ApfsCompatibleFirmware
    {
        Unknown,
        Yes,
        No
    }

    internal enum NvramStoreType
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

        internal static long lLoadedFileSize = 0;
        internal static long lFsysOffset = 0;

        internal static readonly int intMinROMSize = 1048576;
        internal static readonly int intMaxROMSize = 33554432;
        internal static readonly int intFsysRegionSize = 0x800;
        #endregion

        #region Private Members
        private static readonly Encoding _utf8 = Encoding.UTF8;
        private static readonly int _maxPaddingBytes = 0x60; // This value may need tweaking.
        #endregion

        #region Flash Header
        internal static bool GetIsValidFlashHeader(byte[] sourceBytes)
        {
            byte[] headerBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, 0, 0x14);
            FlashDescriptor descriptor = Helper.DeserializeHeader<FlashDescriptor>(headerBytes);

            if (descriptor.Signature.SequenceEqual(FSSignatures.FLASH_DESC_SIG))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Platform Data Region Data
        internal static string GetBoardId(byte[] bytesIn)
        {
            var result = "N/A";
            var pdrOffset = BinaryUtils.GetOffset(bytesIn, FSGuids.PDR_SECTION_BID_GUID);

            if (pdrOffset != -1)
            {
                var bidOffset = BinaryUtils.GetOffset(bytesIn, FSSignatures.BID_SIG, pdrOffset);
                if (bidOffset != -1)
                {
                    var bidNudgePos = 0x5;
                    var bidReadLength = 0x8;
                    var bidBytes = BinaryUtils.GetBytesAtOffset(bytesIn, bidOffset + bidNudgePos, bidReadLength);
                    var bidString = BitConverter.ToString(bidBytes).Replace("-", "");

                    if (!bidString.All(c => c == '0'))
                    {
                        result = $"Mac-{bidString}";
                    }
                }
            }

            return result;
        }
        #endregion

        #region Fsys Data
        internal static FsysRegion GetFsysRegionBytes(byte[] sourceBytes, bool outputOffset = false)
        {
            long fsysOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG);
            byte[] fsysBytes = null;

            if (fsysOffset != -1)
            {
                fsysBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset, intFsysRegionSize);
            }

            return new FsysRegion { BlockBytes = fsysBytes, Offset = outputOffset ? fsysOffset : -1 };
        }

        internal static string GetFsysCrc32(byte[] sourceBytes)
        {
            var fsysOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG);

            if (fsysOffset != -1)
            {
                var crcReadLength = 0x4;
                var crcNudgePos = intFsysRegionSize - crcReadLength;
                var crcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset + crcNudgePos, crcReadLength);

                if (crcBytes != null)
                {
                    var crcReversedBytes = crcBytes.Reverse().ToArray();
                    return BitConverter.ToString(crcReversedBytes).Replace("-", "");
                }
            }

            return "N/A";
        }

        internal static string GetFsysSerialNumber(byte[] sourceBytes)
        {
            var result = "N/A";
            var ssnOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SSN_UPPER_SIG);

            if (ssnOffset == -1)
            {
                ssnOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SSN_LOWER_SIG);
            }

            if (ssnOffset != -1)
            {
                var ssnNudgePos = 0x05;
                var ssnReadLength = 0x0C;
                byte[] ssnBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, ssnOffset + ssnNudgePos, ssnReadLength);

                if (ssnBytes != null)
                {
                    var serialString = _utf8.GetString(ssnBytes).Trim();
                    serialString = new string(serialString.Where(Char.IsLetterOrDigit).ToArray());
                    result = serialString;
                }
            }

            return result;
        }

        internal static string GetFsysSon(byte[] sourceBytes)
        {
            var sonOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SON_SIG);

            if (sonOffset != -1)
            {
                byte indexByte = 0x00;
                byte[] terminationByteArray = { 0x03, 0x04, 0x09 };
                byte[] sonBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, sonOffset, indexByte, terminationByteArray);

                if (sonBytes != null)
                {
                    return _utf8.GetString(sonBytes);
                }
            }

            return "N/A";
        }

        internal static string GetFsysHwc(byte[] sourceBytes)
        {
            var hwcOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.HWC_SIG);

            if (hwcOffset != -1)
            {
                var hwcNudgePos = 0x06;
                var hwcReadLength = 0x04;
                byte[] hwcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, hwcOffset + hwcNudgePos, hwcReadLength);

                if (hwcBytes != null)
                {
                    string hwcString = _utf8.GetString(hwcBytes).Trim();
                    hwcString = new string(hwcString.Where(Char.IsLetterOrDigit).ToArray());
                    return hwcString;
                }
            }

            return "N/A";
        }
        #endregion

        #region Apple ROM Section Data
        internal static string GetEfiVersion(byte[] sourceBytes)
        {
            var versionOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.EFIVER_SIG);

            if (versionOffset != -1)
            {
                byte indexByte = 0x20;
                byte terminationByte = 0x0A;
                var versionNudgePos = FSSignatures.EFIVER_SIG.Length;
                byte[] versionBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, versionOffset + versionNudgePos, indexByte, terminationByte);

                if (versionBytes != null)
                {
                    return _utf8.GetString(versionBytes);
                }
            }

            return "N/A";
        }

        internal static string GetBootromVersion(byte[] sourceBytes)
        {
            var versionOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.ROMVER_SIG);

            if (versionOffset != -1)
            {
                byte indexByte = 0x20;
                byte terminationByte = 0x0A;
                var versionNudgePos = FSSignatures.ROMVER_SIG.Length;
                byte[] versionBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, versionOffset + versionNudgePos, indexByte, terminationByte);

                if (versionBytes != null)
                {
                    return _utf8.GetString(versionBytes);
                }
            }

            return "N/A";
        }

        internal static string GetModelIdentifier(byte[] sourceBytes)
        {
            var guidOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.EFI_BIOS_ID_GUID);

            if (guidOffset != -1)
            {
                var modelOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.IBIOSI_SIG);

                if (modelOffset != -1)
                {
                    byte indexByte = 0x20;
                    byte terminationByte = 0x2E;
                    byte[] modelBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, modelOffset, indexByte, terminationByte);

                    if (modelBytes != null)
                    {
                        modelBytes = modelBytes.Where(b => b != 0x00 && b != 0x20).ToArray();
                        return _utf8.GetString(modelBytes);
                    }
                }
            }

            return "N/A";
        }
        #endregion

        #region NVRAM Data
        internal static NvramStoreData GetNvramStoreData(byte[] sourceBytes, NvramStoreType headerType)
        {
            var nvStoreSig = GetNvramSignature(headerType);
            var storeOffset = BinaryUtils.GetOffset(sourceBytes, nvStoreSig);

            var primaryStoreSize = -1;
            long primaryStoreOffset = -1;

            if (storeOffset != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, storeOffset, 0x6) is byte[] bytesPrimaryHeader)
            {
                NvramStoreHeader primaryStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesPrimaryHeader);
                if (primaryStoreHeader.SizeOfData != 0)
                {
                    primaryStoreSize = primaryStoreHeader.SizeOfData;
                    primaryStoreOffset = storeOffset;

                }
            }

            var backupStoreSize = -1;
            long backupStoreOffset = -1;

            if (primaryStoreOffset != -1) // If we did not find the primary store, why would we be looking for the backup store?
            {
                // We're looking for the backup store within a certain max padding length from the end of the primary store,
                // if we don't find the signature within the maxSearchLength, we abort.
                var backupOffset = BinaryUtils.GetOffset(sourceBytes, nvStoreSig, storeOffset + primaryStoreSize, _maxPaddingBytes);

                if (backupOffset != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, storeOffset, 0x6) is byte[] bytesBackupHeader)
                {
                    NvramStoreHeader backupStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesBackupHeader);
                    if (backupStoreHeader.SizeOfData != 0)
                    {
                        backupStoreSize = backupStoreHeader.SizeOfData;
                        backupStoreOffset = backupOffset;
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

        private static byte[] GetNvramSignature(NvramStoreType headerType)
        {
            switch (headerType)
            {
                case NvramStoreType.SVS:
                    return FSSignatures.NVRAM_SVS_SIG;
                case NvramStoreType.VSS:
                    return FSSignatures.NVRAM_VSS_SIG;
                case NvramStoreType.NSS:
                    return FSSignatures.NVRAM_NSS_SIG;
                default:
                    throw new ArgumentException("Invalid NVRAM header type.");
            }
        }
        #endregion

        #region APFSJumpStart Dxe searcher
        internal static ApfsCompatibleFirmware GetIsApfsCapable(byte[] sourceBytes)
        {
            long guidOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.APFS_DXE_GUID);

            if (guidOffset != -1)
            {
                return ApfsCompatibleFirmware.Yes;
            }

            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch))
            {
                return ApfsCompatibleFirmware.Unknown;
            }

            long lzmaOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.LZMA_DXE_NEW_GUID);
            if (lzmaOffset == -1)
            {
                lzmaOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.LZMA_DXE_OLD_GUID);
            }

            if (lzmaOffset != -1)
            {
                var lzmaNudgePos = 0x10;
                lzmaOffset = BinaryUtils.GetOffset(sourceBytes, new byte[] { 0x5D }, lzmaOffset + lzmaNudgePos);
                long lzmaEndOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.ROM_INFO_GUID, lzmaOffset);

                if (lzmaEndOffset != -1)
                {
                    byte[] decompressedBytes = LzmaCoder.DecompressBytes(BinaryUtils.RemoveTrailingFFPadding(BinaryUtils.GetBytesBetweenOffsets(sourceBytes, lzmaOffset, lzmaEndOffset)));

                    guidOffset = BinaryUtils.GetOffset(decompressedBytes, FSGuids.APFS_DXE_GUID);
                    return (guidOffset != -1) ? ApfsCompatibleFirmware.Yes : ApfsCompatibleFirmware.No;
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
        internal static void ClearBaseData()
        {
            string[] strings =
            {
                strLoadedBinaryFilePath, strFilenameWithoutExt, strCreationTime, strModifiedTime,
                strFilename, strSerialNumber, strHwc, strEfiVersion, strBootromVersion,
                strApfsCapable, strFsysChecksumInBinary, strRealFsysChecksum, strFitcVersion,
                strMeVersion, strBoardId, strSon
            };
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = string.Empty;
            }

            byte[][] byteArrays =
{
                bytesLoadedFile, bytesLoadedFsys
            };
            for (int i = 0; i < byteArrays.Length; i++)
            {
                byteArrays[i] = null;
            }

            uiCrcOfLoadedFile = 0;
            lLoadedFileSize = 0;
            lFsysOffset = 0;
        }
        #endregion

    }
}