// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWParser.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        internal byte[] RegionBytes { get; set; }
        internal long Offset { get; set; }
    }

    internal struct SystemSerialInfo
    {
        public string Serial { get; set; }
        public long Offset { get; set; }
    }

    internal struct SystemHardwareConfigInfo
    {
        public string ConfigCode { get; set; }
        public long Offset { get; set; }
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
        internal static string strLoadedBinaryFilePath = null;
        internal static string strFilename = null;
        internal static string strFilenameWithoutExt = null;
        internal static string strCreationTime = null;
        internal static string strModifiedTime = null;
        internal static string strModel = null;
        internal static string strModelFallback = null;
        internal static string strSerialNumber = null;
        internal static string strHwc = null;
        internal static string strEfiVersion = null;
        internal static string strBootromVersion = null;
        internal static string strApfsCapable = null;
        internal static string strFsysChecksumInBinary = null;
        internal static string strRealFsysChecksum = null;
        internal static string strFitVersion = null;
        internal static string strMeVersion = null;
        internal static string strBoardId = null;
        internal static string strSon = null;

        internal static byte[] bytesLoadedFile = null;
        internal static byte[] bytesLoadedFsys = null;

        internal static uint uiCrcOfLoadedFile = 0;

        internal static long lLoadedFileSize = 0;
        internal static long lFsysOffset = -1;
        internal static long lSerialOffsetInFsys = -1;
        internal static long lHwcOffsetInFsys = -1;

        internal const int MIN_IMAGE_SIZE = 0x100000;  // 1048576 bytes
        internal const int MAX_IMAGE_SIZE = 0x2000000; // 33554432 bytes
        internal const int FSYS_RGN_SIZE = 0x800;      // 2048 bytes
        #endregion

        #region Private Members
        private static readonly Encoding _utf8 = Encoding.UTF8;
        private static readonly int _maxPaddingBytes = 0x60; // This value may need tweaking.
        #endregion

        #region Parser Function
        internal static void ParseFirmwareData()
        {
            var fileInfo = new FileInfo(strLoadedBinaryFilePath);

            GetFileInfo(fileInfo);

            var fsysData = GetFsysRegionBytes(bytesLoadedFile, true);
            bytesLoadedFsys = fsysData.RegionBytes;
            lFsysOffset = fsysData.Offset;

            if (bytesLoadedFsys != null)
            {
                var serialInfo = GetSystemSerialNumber(bytesLoadedFsys, true);
                strSerialNumber = serialInfo.Serial;
                lSerialOffsetInFsys = serialInfo.Offset;

                var configInfo = GetSystemHardwareConfigCode(bytesLoadedFsys, true);
                strHwc = configInfo.ConfigCode;
                lHwcOffsetInFsys = serialInfo.Offset;
            }
            else
            {
                strSerialNumber = null;
                lSerialOffsetInFsys = -1;
                strHwc = null;
                lHwcOffsetInFsys = -1;
            }

            var task = Task.Run(() =>
            {
                strModel = EFIUtils.GetDeviceConfigCodeAsync(strHwc).ConfigureAwait(false).GetAwaiter().GetResult();
            });

            strModelFallback = GetModelIdentifier(bytesLoadedFile);
            strEfiVersion = GetEfiVersion(bytesLoadedFile);
            strBootromVersion = GetBootromVersion(bytesLoadedFile);
            strFsysChecksumInBinary = GetFsysCrc32(bytesLoadedFile);
            strRealFsysChecksum = bytesLoadedFsys != null ? EFIUtils.GetUintFsysCrc32(bytesLoadedFsys).ToString("X8") : null;
            strApfsCapable = GetIsApfsCapable(bytesLoadedFile).ToString();
            strFitVersion = MEParser.GetVersionData(bytesLoadedFile, HeaderType.FlashImageTool);
            strMeVersion = MEParser.GetVersionData(bytesLoadedFile, HeaderType.ManagementEngine);
            strBoardId = GetBoardId(bytesLoadedFile);
            strSon = bytesLoadedFsys != null ? GetSystemOrderNumber(bytesLoadedFsys) : null;
        }

        private static void GetFileInfo(FileInfo fileInfo)
        {
            strFilename = fileInfo.Name;
            strCreationTime = fileInfo.CreationTime.ToString();
            strModifiedTime = fileInfo.LastWriteTime.ToString();
            lLoadedFileSize = fileInfo.Length;
            uiCrcOfLoadedFile = FileUtils.GetCrc32Digest(bytesLoadedFile);
        }
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
        internal static string GetBoardId(byte[] sourceBytes)
        {
            var pdrOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.PDR_SECTION_BID_GUID);

            if (pdrOffset != -1)
            {
                var bidOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.BID_SIG, pdrOffset);
                if (bidOffset != -1)
                {
                    var bidNudgePos = 0x5;
                    var bidReadLength = 0x8;
                    var bidBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, bidOffset + bidNudgePos, bidReadLength);
                    var bidString = BitConverter.ToString(bidBytes).Replace("-", "");

                    if (!bidString.All(c => c == '0'))
                    {
                        return $"Mac-{bidString}";
                    }
                }
            }

            return null;
        }
        #endregion

        #region Fsys Data
        internal static FsysRegion GetFsysRegionBytes(byte[] sourceBytes, bool outputOffset = false)
        {
            long fsysOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG);
            byte[] fsysBytes = null;

            if (fsysOffset != -1)
            {
                fsysBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset, FSYS_RGN_SIZE);
            }

            return new FsysRegion { RegionBytes = fsysBytes, Offset = outputOffset ? fsysOffset : -1 };
        }

        internal static SystemSerialInfo GetSystemSerialNumber(byte[] sourceBytes, bool outputOffset = false)
        {
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

                    return new SystemSerialInfo
                    {
                        Serial = serialString,
                        Offset = outputOffset ? ssnOffset : -1
                    };
                }
            }

            return new SystemSerialInfo();
        }

        internal static SystemHardwareConfigInfo GetSystemHardwareConfigCode(byte[] sourceBytes, bool outputOffset = false)
        {
            var hwcOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.HWC_SIG);

            if (hwcOffset != -1)
            {
                var hwcNudgePos = 0x06;
                var hwcReadLength = 0x04;
                byte[] hwcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, hwcOffset + hwcNudgePos, hwcReadLength);

                if (hwcBytes != null)
                {
                    string configString = _utf8.GetString(hwcBytes).Trim();
                    configString = new string(configString.Where(Char.IsLetterOrDigit).ToArray());

                    return new SystemHardwareConfigInfo
                    {
                        ConfigCode = configString,
                        Offset = outputOffset ? hwcOffset : -1
                    };
                }
            }

            return new SystemHardwareConfigInfo();
        }

        internal static string GetSystemOrderNumber(byte[] sourceBytes)
        {
            var sonOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SON_SIG);

            if (sonOffset != -1)
            {
                byte indexByte = 0x00;
                byte[] terminationByteArray = { 0x03, 0x04, 0x09 };
                byte[] sonBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, sonOffset, indexByte, terminationByteArray);

                if (sonBytes != null)
                {
                    var sonString = _utf8.GetString(sonBytes);
                    if (sonString.EndsWith("/"))
                    {
                        sonString = sonString.TrimEnd('/');
                    }

                    return sonString;
                }
            }

            return null;
        }

        internal static string GetFsysCrc32(byte[] sourceBytes)
        {
            var fsysOffset = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG);

            if (fsysOffset != -1)
            {
                var crcReadLength = 0x4;
                var crcNudgePos = FSYS_RGN_SIZE - crcReadLength;
                var crcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset + crcNudgePos, crcReadLength);

                if (crcBytes != null)
                {
                    var crcReversedBytes = crcBytes.Reverse().ToArray();
                    return BitConverter.ToString(crcReversedBytes).Replace("-", "");
                }
            }

            return null;
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

            return null;
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

            return null;
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

            return null;
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
            }

            return ApfsCompatibleFirmware.No;
        }
        #endregion

        #region Clear Data
        internal static void ClearBaseData()
        {
            string[] strings =
            {
                strLoadedBinaryFilePath, strFilename, strFilenameWithoutExt, strCreationTime,
                strModifiedTime, strModel, strModelFallback, strSerialNumber, strHwc,
                strEfiVersion, strBootromVersion, strApfsCapable, strFsysChecksumInBinary,
                strRealFsysChecksum, strFitVersion, strMeVersion, strBoardId, strSon
            };
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = null;
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
            lFsysOffset = -1;
            lSerialOffsetInFsys = -1;
            lHwcOffsetInFsys = -1;
        }
        #endregion

    }
}