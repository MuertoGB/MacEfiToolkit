// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWBase.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

#region Structs
internal struct FileInfoData
{
    internal string FileNameWithExt { get; set; }
    internal string FileNameNoExt { get; set; }
    internal string CreationTime { get; set; }
    internal string LastWriteTime { get; set; }
    internal long FileLength { get; set; }
    internal string CRC32 { get; set; }
}

internal struct FsysStoreSection
{
    internal byte[] FsysBytes { get; set; }
    internal long FsysOffset { get; set; }
    internal string Serial { get; set; }
    internal long SerialOffset { get; set; }
    internal string HWC { get; set; }
    internal long HWCOffset { get; set; }
    internal string SON { get; set; }
    internal string CrcString { get; set; }
    internal long CrcOffset { get; set; }
    internal string CrcCalcString { get; set; }
    internal uint CRC32CalcInt { get; set; }
}

internal struct AppleRomInformationSection
{
    internal bool SectionExists { get; set; }
    internal byte[] SectionBytes { get; set; }
    internal long SectionOffset { get; set; }
    internal string BiosId { get; set; }
    internal string Model { get; set; }
    internal string EfiVersion { get; set; }
    internal string BuiltBy { get; set; }
    internal string DateStamp { get; set; }
    internal string Revision { get; set; }
    internal string RomVersion { get; set; }
    internal string BuildcaveId { get; set; }
    internal string BuildType { get; set; }
    internal string Compiler { get; set; }
}

internal struct PdrSection
{
    internal string MacBoardId { get; set; }
}

internal struct EfiSection
{
    internal string Model { get; set; }
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct FlashDescriptorHeader
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    internal byte[] ReservedVector;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    internal byte[] Signature;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct NvramStoreHeader
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    internal char[] Signature;
    internal ushort SizeOfData;
}

internal struct NvramStoreSection
{
    internal NvramStoreType StoreType { get; set; }
    internal long PrimaryStoreOffset { get; set; }
    internal int PrimaryStoreLength { get; set; }
    internal byte[] PrimaryStoreBytes { get; set; }
    internal bool IsPrimaryStoreEmpty { get; set; }
    internal long BackupStoreOffset { get; set; }
    internal int BackupStoreLength { get; set; }
    internal byte[] BackupStoreBytes { get; set; }
    internal bool IsBackupStoreEmpty { get; set; }
    internal int PaddingLength { get; set; }
}
#endregion

#region Enums
internal enum ApfsCompatibleFirmware
{
    Unknown,
    Yes,
    No
}

internal enum EfiLockStatus
{
    Locked,
    Unlocked,
    Unknown
}

internal enum NvramStoreType
{
    VSS,
    SVS,
    NSS
}
#endregion

namespace Mac_EFI_Toolkit.Common
{
    class FWBase
    {
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBytes = null;

        internal static FileInfoData FileInfoData;
        internal static PdrSection PDRSectionData;
        internal static NvramStoreSection VssStoreData;
        internal static NvramStoreSection SvsStoreData;
        internal static NvramStoreSection NssStoreData;
        internal static FsysStoreSection FsysSectionData;
        internal static AppleRomInformationSection ROMInfoData;
        internal static EfiSection EFISectionStore;

        internal static string IsApfsCapable = null;
        internal static string FitVersion = null;
        internal static string MeVersion = null;
        internal static EfiLockStatus EfiLock = EfiLockStatus.Unknown;

        internal const int MIN_IMAGE_SIZE = 0x100000;  // 1048576 bytes
        internal const int MAX_IMAGE_SIZE = 0x2000000; // 33554432 bytes
        internal const int FSYS_RGN_SIZE = 0x800;      // 2048 bytes
        internal const int FSYS_CRC_POS = 0x7FC;

        private static readonly Encoding _utf8 = Encoding.UTF8;

        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            FileInfoData = GetBinaryFileInfo(fileName);
            PDRSectionData = GetPdrData(sourceBytes);
            VssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.VSS);
            SvsStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.SVS);
            NssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.NSS);
            FsysSectionData = GetFsysStoreData(sourceBytes);
            ROMInfoData = GetRomInformationData(sourceBytes);
            EFISectionStore = GetEfiSectionData(sourceBytes);

            IsApfsCapable = GetIsApfsCapable(LoadedBinaryBytes).ToString();
            FitVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.FlashImageTool);
            MeVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.ManagementEngine);

            EfiLock = (SvsStoreData.PrimaryStoreOffset != -1 && SvsStoreData.PrimaryStoreBytes != null)
                ? EfiLock = GetIsEfiLocked(SvsStoreData.PrimaryStoreBytes)
                : EfiLockStatus.Unknown;
        }

        internal static void ResetFirmwareBaseData()
        {
            PDRSectionData = default;
            VssStoreData = default;
            SvsStoreData = default;
            NssStoreData = default;
            FsysSectionData = default;
            ROMInfoData = default;
            EFISectionStore = default;
            IsApfsCapable = null;
            FitVersion = null;
            MeVersion = null;
            EfiLock = EfiLockStatus.Unknown;
        }

        #region File Information
        private static FileInfoData GetBinaryFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            return new FileInfoData
            {
                FileNameWithExt = fileInfo.Name,
                FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                CreationTime = fileInfo.CreationTime.ToString(),
                LastWriteTime = fileInfo.LastWriteTime.ToString(),
                FileLength = fileInfo.Length,
                CRC32 = FileUtils.GetCrc32Digest(LoadedBinaryBytes).ToString("X8")
            };
        }
        #endregion 

        #region Flash Descriptor
        internal static bool GetIsValidFlashHeader(byte[] sourceBytes)
        {
            byte[] headerData = BinaryUtils.GetBytesAtOffset(sourceBytes, 0, 0x14);
            FlashDescriptorHeader header = Helper.DeserializeHeader<FlashDescriptorHeader>(headerData);

            if (header.Signature.SequenceEqual(FLASH_DESC_SIGNATURE))
            {
                return true;
            }

            return false;
        }

        internal static readonly byte[] FLASH_DESC_SIGNATURE =
        {
            0x5A, 0xA5, 0xF0, 0x0F
        };
        #endregion

        #region Platform Data Region
        internal static PdrSection GetPdrData(byte[] sourceBytes)
        {
            long pdrPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.PDR_SECTION_GUID);

            if (pdrPos != -1)
            {
                var bidPos = BinaryUtils.GetOffset(sourceBytes, PDR_BOARD_ID_SIGNATURE, pdrPos);
                if (bidPos != -1)
                {
                    var bidNudgePos = 0x5; var bidReadLength = 0x8;
                    var bidBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, bidPos + bidNudgePos, bidReadLength);
                    var bidString = BitConverter.ToString(bidBytes).Replace("-", "");

                    if (!bidString.All(c => c == '0'))
                    {
                        return new PdrSection
                        {
                            MacBoardId = $"Mac-{bidString}"
                        };
                    }
                }
            }

            return DefaultPdrSection();
        }

        private static PdrSection DefaultPdrSection()
        {
            return new PdrSection
            {
                MacBoardId = null
            };
        }

        internal static readonly byte[] PDR_BOARD_ID_SIGNATURE =
        {
            0xF8, 0x7C, 0x00, 0x00,
            0x19
        };
        #endregion

        #region Fsys Store
        internal static FsysStoreSection GetFsysStoreData(byte[] sourceBytes)
        {
            string ssnString = null; long ssnPos = -1;
            string hwcString = null; long hwcPos = -1;
            string sonString = null;
            string crcString = null;
            string crcCalcString = null;
            uint uiCrcCalc = 0xFFFFFFFF;

            var ssnStartPos = 0x5;
            var hwcStartPos = 0x6;
            var crcLength = 0x4;

            // First we need to locate the NVRAM section GUID.
            long nvramPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_SECTION_GUID);

            if (nvramPos == -1)
            {
                // NVRAM store was not found so return default data
                return DefaultFsysRegionBase();
            }

            // Zero Vector length (10h) GUID length (10h) NVRAM section size data length (4h, int32)
            int zeroVecLen = 0x10; int guidLen = 0x10; int dataLen = 0x4;
            // Get NVRAM section size from header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, nvramPos + guidLen, dataLen);
            // Convert NVRAM section size to int32
            int nvramLen = BitConverter.ToInt32(dataLenBytes, 0); // NOTE: What if this value if 0xFF??
            // Search for the Fsys store within bounds of the NVRAM section
            long fsysPos = BinaryUtils.GetOffset(sourceBytes, FSYS_SIG, nvramPos - zeroVecLen - guidLen, nvramLen);

            // Fsys store was not found within scope of the NVRAM section
            if (fsysPos == -1)
            {
                return DefaultFsysRegionBase();
            }

            // Get Fsys store bytes
            byte[] fsysData = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysPos, FSYS_RGN_SIZE);

            if (fsysData != null && fsysData.Length == FSYS_RGN_SIZE)
            {
                // Calculate Fsys CRC32 from fsysData
                uiCrcCalc = EFIUtils.GetUintFsysCrc32(fsysData);
                crcCalcString = uiCrcCalc.ToString("X8");

                // Fsys store CRC32
                var crcNudgePos = FSYS_RGN_SIZE - crcLength;
                var crcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysPos + crcNudgePos, crcLength);

                if (crcBytes != null)
                {
                    var crcReversedBytes = crcBytes.Reverse().ToArray();
                    crcString = BitConverter.ToString(crcReversedBytes).Replace("-", "");
                }

                // Serial + Offset
                ssnPos = BinaryUtils.GetOffset(sourceBytes, SSN_UPPER_SIG, fsysPos, FSYS_RGN_SIZE);
                if (ssnPos == -1) ssnPos = BinaryUtils.GetOffset(sourceBytes, SSN_LOWER_SIG, fsysPos, FSYS_RGN_SIZE);
                if (ssnPos != -1)
                {
                    int ssnDatLen = 0x0C;
                    byte[] ssnData = BinaryUtils.GetBytesAtOffset(sourceBytes, ssnPos + ssnStartPos, ssnDatLen);
                    if (ssnData != null)
                    {
                        ssnString = _utf8.GetString(ssnData).TrimEnd();
                        int trimIndex = ssnString.Length - 1;
                        if (trimIndex >= 0 && !char.IsLetterOrDigit(ssnString[trimIndex]))
                        {
                            ssnString = ssnString.Substring(0, trimIndex);
                        }
                    }
                }

                // Hardware Config + Offset
                hwcPos = BinaryUtils.GetOffset(sourceBytes, HWC_SIG, fsysPos, FSYS_RGN_SIZE);

                if (hwcPos != -1)
                {
                    var hwcReadLen = 0x4;
                    byte[] hwcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, hwcPos + hwcStartPos, hwcReadLen);

                    if (hwcBytes != null)
                    {
                        hwcString = _utf8.GetString(hwcBytes).Trim();
                        hwcString = new string(hwcString.Where(char.IsLetterOrDigit).ToArray());
                    }
                }

                // System order number + Offset
                long sonPos = BinaryUtils.GetOffset(sourceBytes, SON_SIG, fsysPos, FSYS_RGN_SIZE);

                if (sonPos != -1)
                {
                    byte indexByte = 0x00;
                    byte[] terminationBytes = { 0x03, 0x04, 0x09 };
                    byte[] sonBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, sonPos, indexByte, terminationBytes);

                    if (sonBytes != null)
                    {
                        sonString = _utf8.GetString(sonBytes);
                        if (sonString.EndsWith("/")) sonString = sonString.TrimEnd('/');
                    }
                }
            }

            return new FsysStoreSection
            {
                FsysBytes = fsysData,
                FsysOffset = fsysPos,
                Serial = ssnString,
                SerialOffset = ssnPos != -1 ? ssnPos + ssnStartPos : -1,
                HWC = hwcString,
                HWCOffset = hwcPos != -1 ? hwcPos + hwcStartPos : -1,
                SON = sonString,
                CrcString = crcString,
                CrcOffset = fsysPos - crcLength,
                CrcCalcString = crcCalcString,
                CRC32CalcInt = uiCrcCalc
            };
        }

        private static FsysStoreSection DefaultFsysRegionBase()
        {
            return new FsysStoreSection
            {
                FsysBytes = null,
                FsysOffset = -1,
                Serial = null,
                SerialOffset = -1,
                HWC = null,
                HWCOffset = -1,
                SON = null,
                CrcString = null,
                CrcOffset = -1,
                CrcCalcString = null,
                CRC32CalcInt = 0xFFFFFFF
            };
        }

        internal static string GetCrcStringFromFsys(byte[] sourceBytes)
        {
            // Fsys store CRC32
            var crcLength = 0x4;
            var crcNudgePos = FSYS_RGN_SIZE - crcLength;
            var crcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, crcNudgePos, crcLength);

            if (crcBytes != null)
            {
                var crcReversedBytes = crcBytes.Reverse().ToArray();
                return BitConverter.ToString(crcReversedBytes).Replace("-", "");
            }

            return null;
        }

        internal static readonly byte[] FSYS_SIG =
        {
            0x46, 0x73, 0x79, 0x73,
            0x01
        };

        internal static readonly byte[] SSN_LOWER_SIG =
        {
            0x73, 0x73, 0x6E
        };

        internal static readonly byte[] SSN_UPPER_SIG =
        {
            0x53, 0x53, 0x4E
        };

        internal static readonly byte[] SON_SIG =
        {
            0x03, 0x73, 0x6F, 0x6E
        };

        internal static readonly byte[] HWC_SIG =
        {
            0x03, 0x68, 0x77,  0x63
        };
        #endregion

        #region NVRAM Section
        internal static NvramStoreSection GetNvramStoreData(byte[] sourceBytes, NvramStoreType storeType)
        {
            var nvramSig = GetNvramSignature(storeType);
            var headerLen = 0x10;
            var paddingLen = 0;

            // We must find the NVRAM section GUID first.
            long nvramPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_SECTION_GUID);

            if (nvramPos == -1)
            {
                return DefaultNvramStoreData();
            }

            var primaryStoreHeaderPos = BinaryUtils.GetOffset(sourceBytes, nvramSig, nvramPos);

            var primaryStoreLen = -1; long primaryStorePos = -1; byte[] primaryStoreData = null; bool isPrimaryStoreEmpty = true;

            if (primaryStoreHeaderPos != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStoreHeaderPos, 0x6) is byte[] bytesPrimaryHeader)
            {
                NvramStoreHeader psHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesPrimaryHeader);
                if (psHeader.SizeOfData != 0)
                {
                    primaryStoreLen = psHeader.SizeOfData;
                    primaryStorePos = primaryStoreHeaderPos;
                    primaryStoreData = BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStorePos, primaryStoreLen);

                    if (primaryStoreData != null)
                    {
                        byte[] primaryStoreBodyData = BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStorePos + headerLen, primaryStoreLen - headerLen);
                        isPrimaryStoreEmpty = BinaryUtils.IsByteBlockEmpty(primaryStoreBodyData);
                    }

                    // Count the number of 0xFF values in the padding
                    for (int i = (int)(primaryStorePos + primaryStoreLen); i < sourceBytes.Length && sourceBytes[i] == 0xFF; i++)
                    {
                        paddingLen++;
                    }
                }
            }

            var backupStoreLen = -1; long backupStorePos = -1; byte[] backupStoreData = null; bool isBackupStoreEmpty = true;

            if (primaryStorePos != -1)
            {
                var backupStoreHeaderPos = BinaryUtils.GetOffset(sourceBytes, nvramSig, primaryStorePos + primaryStoreLen + paddingLen);

                if (backupStoreHeaderPos != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, backupStoreHeaderPos, 0x6) is byte[] bytesBackupHeader)
                {
                    NvramStoreHeader bsHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesBackupHeader);
                    if (bsHeader.SizeOfData != 0)
                    {
                        backupStoreLen = bsHeader.SizeOfData;
                        backupStorePos = backupStoreHeaderPos;
                        backupStoreData = BinaryUtils.GetBytesAtOffset(sourceBytes, backupStorePos, backupStoreLen);

                        if (backupStoreData != null)
                        {
                            byte[] bsBodyData = BinaryUtils.GetBytesAtOffset(sourceBytes, backupStorePos + headerLen, backupStoreLen - headerLen);
                            isBackupStoreEmpty = BinaryUtils.IsByteBlockEmpty(bsBodyData);
                        }
                    }
                }
            }

            return new NvramStoreSection
            {
                StoreType = storeType,
                PrimaryStoreLength = primaryStoreLen,
                PrimaryStoreOffset = primaryStorePos,
                PrimaryStoreBytes = primaryStoreData,
                IsPrimaryStoreEmpty = isPrimaryStoreEmpty,
                BackupStoreLength = backupStoreLen,
                BackupStoreOffset = backupStorePos,
                BackupStoreBytes = backupStoreData,
                IsBackupStoreEmpty = isBackupStoreEmpty,
                PaddingLength = paddingLen
            };
        }

        private static NvramStoreSection DefaultNvramStoreData()
        {
            return new NvramStoreSection
            {
                PrimaryStoreLength = -1,
                PrimaryStoreOffset = -1,
                PrimaryStoreBytes = null,
                IsPrimaryStoreEmpty = true,
                BackupStoreLength = -1,
                BackupStoreOffset = -1,
                BackupStoreBytes = null,
                IsBackupStoreEmpty = true,
                PaddingLength = 0
            };
        }

        private static byte[] GetNvramSignature(NvramStoreType storeType)
        {
            switch (storeType)
            {
                case NvramStoreType.SVS:
                    return SVS_STORE_SIG;
                case NvramStoreType.VSS:
                    return VSS_STORE_SIG;
                case NvramStoreType.NSS:
                    return NSS_STORE_SIGNATURE;
                default:
                    throw new ArgumentException("Invalid NVRAM header type.");
            }
        }

        internal static EfiLockStatus GetIsEfiLocked(byte[] nvramStoreBytes)
        {
            var lockMarker = BinaryUtils.GetOffset(nvramStoreBytes, EFI_LOCK_MAC_SIG);
            // Message Authentication Code was found
            if (lockMarker != -1) return EfiLockStatus.Locked;

            return EfiLockStatus.Unlocked;
        }

        internal static readonly byte[] EFI_LOCK_MAC_SIG =
        {
            0x43, 0x00, 0x42, 0x00,
            0x46, 0x00, 0x32, 0x00,
            0x43, 0x00, 0x43, 0x00,
            0x33, 0x00, 0x32
        };

        internal static readonly byte[] VSS_STORE_SIG =
        {
            0x24, 0x56, 0x53, 0x53
        };

        internal static readonly byte[] SVS_STORE_SIG =
        {
            0x24, 0x53, 0x56, 0x53
        };

        internal static readonly byte[] NSS_STORE_SIGNATURE =
        {
            0x24, 0x4E, 0x53, 0x53
        };
        #endregion

        #region ROM Section
        internal static AppleRomInformationSection GetRomInformationData(byte[] sourceBytes)
        {
            // Define index and termination bytes for data extraction
            byte indexByte = 0x20;
            byte terminationByte = 0x0A;
            bool sectionHasData = false;

            // Create a dictionary to hold signature-data pairs
            var romInfoData = new Dictionary<byte[], string>
            {
                { BIOS_ID_SIGNATURE, null },
                { MODEL_SIGNATURE, null },
                { EFI_VERSION_SIGNATURE, null },
                { BUILT_BY_SIGNATURE, null },
                { DATE_SIGNATURE, null },
                { REVISION_SIGNATURE, null },
                { ROM_VERSION_SIGNATURE, null},
                { BUILDCAVE_ID_SIGNATURE, null},
                { BUILD_TYPE_SIGNATURE, null},
                { COMPILER_SIGNATURE, null}
            };

            // Create a separate dictionary to store updated data
            var updatedRomInfoData = new Dictionary<byte[], string>(romInfoData);
            // First we need to locate the AppleRomInformation section GUID
            long baseOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID);

            if (baseOffset == -1)
            {
                // AppleRomInformation GUID was not found, so return default data
                return DefaultRomInformationBase();
            }

            // GUID Length (10h) AppleRomInformation section size data length (2h, int16)
            int headerLen = 0x18; int dataLen = 0x2;
            // Read first two bytes after the header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLen, dataLen);
            // Convert first two bytes to an int16 value and get the AppleRomInformation section size
            int sectionLen = BitConverter.ToInt16(dataLenBytes, 0);
            // Read the entire AppleRomInformation section using sectionLen as the max search length
            byte[] romSectionData = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLen, sectionLen);

            if (romSectionData != null)
            {
                // Extract data from the romSectionData based on the signature
                foreach (var kvPair in romInfoData)
                {
                    long dataPos = BinaryUtils.GetOffset(romSectionData, kvPair.Key);
                    if (dataPos != -1)
                    {
                        int sigLength = kvPair.Key.Length;
                        // Extract the data using the signature position, signature length, index byte, and termination byte
                        byte[] infoData = BinaryUtils.GetBytesAtOffsetByteDelimited(romSectionData, dataPos + sigLength, indexByte, terminationByte);
                        if (infoData != null)
                        {
                            // Convert the extracted byte array to string using UTF-8 encoding
                            updatedRomInfoData[kvPair.Key] = _utf8.GetString(infoData);
                        }
                    }
                }

                // Update the original romInfoData dictionary with the extracted and updated values
                foreach (var kvPair in updatedRomInfoData)
                {
                    romInfoData[kvPair.Key] = kvPair.Value;
                }

                // Some EFI have this section GUID, however the data is empty
                sectionHasData = romSectionData.Length <= 0x18 ? false : true;
            }

            // Create and return an instance of AppleRomInformation with the extracted data
            return new AppleRomInformationSection
            {
                SectionExists = sectionHasData,
                SectionBytes = romSectionData,
                SectionOffset = baseOffset,
                BiosId = romInfoData[BIOS_ID_SIGNATURE],
                Model = romInfoData[MODEL_SIGNATURE],
                EfiVersion = romInfoData[EFI_VERSION_SIGNATURE],
                BuiltBy = romInfoData[BUILT_BY_SIGNATURE],
                DateStamp = romInfoData[DATE_SIGNATURE],
                Revision = romInfoData[REVISION_SIGNATURE],
                RomVersion = romInfoData[ROM_VERSION_SIGNATURE],
                BuildcaveId = romInfoData[BUILDCAVE_ID_SIGNATURE],
                BuildType = romInfoData[BUILD_TYPE_SIGNATURE],
                Compiler = romInfoData[COMPILER_SIGNATURE]
            };
        }

        internal static AppleRomInformationSection DefaultRomInformationBase()
        {
            return new AppleRomInformationSection
            {
                SectionExists = false,
                SectionBytes = null,
                SectionOffset = -1,
                BiosId = null,
                Model = null,
                EfiVersion = null,
                BuiltBy = null,
                DateStamp = null,
                Revision = null,
                RomVersion = null,
                BuildcaveId = null,
                BuildType = null,
                Compiler = null
            };
        }

        internal static readonly byte[] BIOS_ID_SIGNATURE =
        {
            0x42, 0x49, 0x4F, 0x53,
            0x20, 0x49, 0x44, 0x3A
        };

        internal static readonly byte[] MODEL_SIGNATURE =
        {
            0x4D, 0x6F, 0x64, 0x65,
            0x6C, 0x3A
        };

        internal static readonly byte[] EFI_VERSION_SIGNATURE =
        {
            0x45, 0x46, 0x49, 0x20,
            0x56, 0x65, 0x72, 0x73,
            0x69, 0x6F, 0x6E, 0x3A
        };

        internal static readonly byte[] BUILT_BY_SIGNATURE =
        {
            0x42, 0x75, 0x69, 0x6C,
            0x74, 0x20, 0x62, 0x79,
            0x3A
        };

        internal static readonly byte[] DATE_SIGNATURE =
        {
            0x44, 0x61, 0x74, 0x65,
            0x3A
        };

        internal static readonly byte[] REVISION_SIGNATURE =
        {
            0x52, 0x65, 0x76, 0x69,
            0x73, 0x69, 0x6F, 0x6E,
            0x3A
        };

        internal static readonly byte[] ROM_VERSION_SIGNATURE =
        {
            0x52, 0x4F, 0x4D, 0x20,
            0x56, 0x65, 0x72, 0x73,
            0x69, 0x6F, 0x6E, 0x3A
        };

        internal static readonly byte[] BUILDCAVE_ID_SIGNATURE =
        {
            0x42, 0x75, 0x69, 0x6C,
            0x64, 0x63, 0x61, 0x76,
            0x65, 0x20, 0x49, 0x44,
            0x3A
        };

        internal static readonly byte[] BUILD_TYPE_SIGNATURE =
        {
            0x42, 0x75, 0x69, 0x6C,
            0x64, 0x20, 0x54, 0x79,
            0x70, 0x65, 0x3A
        };

        internal static readonly byte[] COMPILER_SIGNATURE =
        {
            0x43, 0x6F, 0x6D, 0x70,
            0x69, 0x6C, 0x65, 0x72,
            0x3A
        };
        #endregion

        #region EFI Section

        internal static EfiSection GetEfiSectionData(byte[] sourceBytes)
        {
            var guidOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.EFI_BIOS_ID_GUID);

            if (guidOffset != -1)
            {
                var modelOffset = BinaryUtils.GetOffset(sourceBytes, EFI_SECTION_SIGNATURE);

                if (modelOffset != -1)
                {
                    byte indexByte = 0x20;
                    byte terminationByte = 0x2E;
                    byte[] modelBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, modelOffset, indexByte, terminationByte);

                    if (modelBytes != null)
                    {
                        modelBytes = modelBytes.Where(b => b != 0x00 && b != 0x20).ToArray();
                        return new EfiSection
                        {
                            Model = _utf8.GetString(modelBytes)
                        };
                    }
                }
            }

            return DefaultEfiSection();
        }

        private static EfiSection DefaultEfiSection()
        {
            return new EfiSection
            {
                Model = null
            };
        }

        internal static readonly byte[] EFI_SECTION_SIGNATURE =
        {
            0x24, 0x49, 0x42, 0x49,
            0x4F, 0x53, 0x49, 0x24
        };
        #endregion

        #region APFSJumpStart
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
                long lzmaEndOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID, lzmaOffset);

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

    }
}