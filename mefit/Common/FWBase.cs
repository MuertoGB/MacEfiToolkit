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

namespace Mac_EFI_Toolkit.Common
{

    #region Structs
    internal struct FileInfoStore
    {
        internal string FileNameWithExt { get; set; }
        internal string FileNameNoExt { get; set; }
        internal string CreationTime { get; set; }
        internal string LastWriteTime { get; set; }
        internal int FileLength { get; set; }
        internal uint CRC32 { get; set; }
    }

    internal struct FsysStore
    {
        internal byte[] FsysBytes { get; set; }
        internal int FsysOffset { get; set; }
        internal string Serial { get; set; }
        internal int SerialOffset { get; set; }
        internal string HWC { get; set; }
        internal int HWCOffset { get; set; }
        internal string SON { get; set; }
        internal string CrcString { get; set; }
        internal string CrcCalcString { get; set; }
        internal uint CRC32CalcInt { get; set; }
    }

    internal struct NvramStore
    {
        internal NvramStoreType StoreType { get; set; }
        internal int PrimaryStoreOffset { get; set; }
        internal int PrimaryStoreLength { get; set; }
        internal byte[] PrimaryStoreBytes { get; set; }
        internal bool IsPrimaryStoreEmpty { get; set; }
        internal int BackupStoreOffset { get; set; }
        internal int BackupStoreLength { get; set; }
        internal byte[] BackupStoreBytes { get; set; }
        internal bool IsBackupStoreEmpty { get; set; }
    }

    internal struct AppleRomInformationSection
    {
        internal bool SectionExists { get; set; }
        internal byte[] SectionBytes { get; set; }
        internal int SectionOffset { get; set; }
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
    internal struct NvramStoreHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal ushort SizeOfData;
    }
    #endregion

    #region FWBase
    internal enum ApfsCapableFirmware
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

    class FWBase
    {
        internal static string LoadedBinaryPath = null;
        internal static string IsApfsCapable = null;
        internal static string FitVersion = null;
        internal static string MeVersion = null;
        internal static byte[] LoadedBinaryBytes = null;

        internal static FileInfoStore FileInfoData;
        internal static PdrSection PDRSectionData;
        internal static NvramStore VssStoreData;
        internal static NvramStore SvsStoreData;
        internal static NvramStore NssStoreData;
        internal static FsysStore FsysStoreData;
        internal static AppleRomInformationSection ROMInfoSectionData;
        internal static EfiSection EFISectionData;

        internal static EfiLockStatus EfiLock = EfiLockStatus.Unknown;

        internal const int MIN_IMAGE_SIZE = 0x100000;  // 1048576
        internal const int MAX_IMAGE_SIZE = 0x2000000; // 33554432
        internal const int FSYS_RGN_SIZE = 0x800;      // 2048
        internal const int FSYS_CRC_POS = 0x7FC;       // 2044

        private const int GUID_LENGTH = 0x10;        // 16
        private const int ZERO_VECTOR_LENGTH = 0x10; // 16

        private const int BID_NUDGE_POS = 0x5;   // 5
        private const int BID_LENGTH = 0x8;      // 8
        private const int SSN_NUDGE_POS = 0x5;   // 5         
        private const int SSN_MAX_LENGTH = 0x0C; // 12
        private const int HWC_NUDGE_POS = 0x6;   // 6
        private const int HWC_LENGTH = 0x4;      // 4
        private const int CRC32_LENGTH = 0x4;    // 4

        private static readonly Encoding _utf8 = Encoding.UTF8;

        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            FileInfoData = GetBinaryFileInfo(fileName);
            PDRSectionData = GetPdrData(sourceBytes);
            VssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.VSS);
            SvsStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.SVS);
            NssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.NSS);
            FsysStoreData = GetFsysStoreData(sourceBytes, false);
            ROMInfoSectionData = GetRomInformationData(sourceBytes);
            EFISectionData = GetEfiSectionData(sourceBytes);

            IsApfsCapable = GetIsApfsCapable(LoadedBinaryBytes).ToString();
            FitVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.FlashImageTool);
            MeVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.ManagementEngine);

            EfiLock = (SvsStoreData.PrimaryStoreOffset != -1 && SvsStoreData.PrimaryStoreBytes != null)
                ? EfiLock = GetIsEfiLocked(SvsStoreData.PrimaryStoreBytes)
                : EfiLockStatus.Unknown;
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBytes = null;
            FileInfoData = default;
            PDRSectionData = default;
            VssStoreData = default;
            SvsStoreData = default;
            NssStoreData = default;
            FsysStoreData = default;
            ROMInfoSectionData = default;
            EFISectionData = default;
            IsApfsCapable = null;
            FitVersion = null;
            MeVersion = null;
            EfiLock = EfiLockStatus.Unknown;
        }

        #region File Information
        private static FileInfoStore GetBinaryFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            return new FileInfoStore
            {
                FileNameWithExt = fileInfo.Name,
                FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                CreationTime = fileInfo.CreationTime.ToString(),
                LastWriteTime = fileInfo.LastWriteTime.ToString(),
                FileLength = (int)fileInfo.Length,
                CRC32 = FileUtils.GetCrc32Digest(LoadedBinaryBytes)
            };
        }
        #endregion 

        #region Platform Data Region
        internal static PdrSection GetPdrData(byte[] sourceBytes)
        {
            // Get the platform data region offset
            int pdrOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.PDR_SECTION_GUID);

            if (pdrOffset == -1)
            {
                // Platform data region not found
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes
            int bidOffset = BinaryUtils.GetOffset(sourceBytes, PDR_BOARD_ID_SIGNATURE, pdrOffset);

            if (bidOffset == -1)
            {
                // Board id signature not found
                return DefaultPdrSection();
            }

            byte[] bidBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, bidOffset + BID_NUDGE_POS, BID_LENGTH);

            if (bidBytes == null)
            {
                return DefaultPdrSection();
            }

            // Return the board id
            return new PdrSection
            {
                MacBoardId = $"Mac-{BitConverter.ToString(bidBytes).Replace("-", "")}"
            };
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
        internal static FsysStore GetFsysStoreData(byte[] sourceBytes, bool isFsysStoreOnly)
        {
            // Will stay at zero if isFsysStoreOnly flag is set
            int fsysOffset = 0;

            // Arg to skip Fsys searching
            if (!isFsysStoreOnly)
            {
                // First we need to locate the NVRAM section GUID
                int nvramOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_SECTION_GUID);

                if (nvramOffset == -1)
                {
                    // NVRAM store was not found so return default data
                    return DefaultFsysRegion();
                }

                int dataLength = 0x4;
                // Get NVRAM section size from header
                byte[] dataLengthBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, nvramOffset + GUID_LENGTH, dataLength);
                // Convert NVRAM section size to int32
                int nvramLength = BitConverter.ToInt32(dataLengthBytes, 0);
                // Search for the Fsys store within bounds of the NVRAM section
                fsysOffset = BinaryUtils.GetOffset(sourceBytes, FSYS_SIG, nvramOffset - ZERO_VECTOR_LENGTH - GUID_LENGTH, nvramLength);

                // Fsys store was not found within scope of the NVRAM section
                if (fsysOffset == -1)
                {
                    return DefaultFsysRegion();
                }
            }

            byte[] fsysStoreBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset, FSYS_RGN_SIZE);

            // Fsys store was not loaded
            if (fsysStoreBytes == null)
            {
                return DefaultFsysRegion();
            }

            // Fsys store was not the correct size
            if (fsysStoreBytes.Length != FSYS_RGN_SIZE)
            {
                return DefaultFsysRegion();
            }

            // Get the Fsys store crc stored at 0x7FC (FSYS_RGN_SIZE - CRC32_LENGTH)
            byte[] crcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysOffset + FSYS_CRC_POS, CRC32_LENGTH);
            byte[] crcBigEndianBytes = crcBytes.Reverse().ToArray(); // We need to flip the bytes from little endian
            string crcString = BitConverter.ToString(crcBigEndianBytes).Replace("-", "");

            // Manually calculate the Fsys store crc
            uint uiCrcCalc = EFIUtils.GetUintFsysCrc32(fsysStoreBytes);
            string crcCalcString = uiCrcCalc.ToString("X8");

            // Parse the serial number
            int serialOffset = BinaryUtils.GetOffset(sourceBytes, SNP_LOWER_SIG, fsysOffset, FSYS_RGN_SIZE);
            if (serialOffset == -1) serialOffset = BinaryUtils.GetOffset(sourceBytes, SSN_UPPER_SIG, fsysOffset, FSYS_RGN_SIZE);
            if (serialOffset == -1) serialOffset = BinaryUtils.GetOffset(sourceBytes, SSN_LOWER_SIG, fsysOffset, FSYS_RGN_SIZE);
            string serialString = ParseFsysSerial(sourceBytes, serialOffset);
            if (serialString == null) serialOffset = -1;

            // Parse the hardware configuration code
            int hwcOffset = BinaryUtils.GetOffset(sourceBytes, HWC_SIG, fsysOffset, FSYS_RGN_SIZE);
            string hwcString = ParseFsysHwc(sourceBytes, hwcOffset);
            if (hwcString == null) hwcOffset = -1;

            // Parse the system order number
            int sonOffset = BinaryUtils.GetOffset(sourceBytes, SON_SIG, fsysOffset, FSYS_RGN_SIZE);
            string sonString = ParseFsysSon(sourceBytes, sonOffset);

            return new FsysStore
            {
                FsysBytes = fsysStoreBytes,
                FsysOffset = fsysOffset,
                Serial = serialString,
                SerialOffset = serialOffset != -1 ? serialOffset + SSN_NUDGE_POS : -1,
                HWC = hwcString,
                HWCOffset = hwcOffset != -1 ? hwcOffset + HWC_NUDGE_POS : -1,
                SON = sonString,
                CrcString = crcString,
                CrcCalcString = crcCalcString,
                CRC32CalcInt = uiCrcCalc
            };
        }

        private static string ParseFsysSerial(byte[] sourceBytes, int serialOffset)
        {
            if (serialOffset == -1)
            {
                return null;
            }

            byte[] ssnBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, serialOffset + SSN_NUDGE_POS, SSN_MAX_LENGTH);

            if (ssnBytes == null)
            {
                return null;
            }

            string ssnString = _utf8.GetString(ssnBytes);
            int trimIndex = ssnString.Length - 1;
            if (trimIndex >= 0 && !char.IsLetterOrDigit(ssnString[trimIndex]))
            {
                ssnString = ssnString.Substring(0, trimIndex);
            }

            if (ssnString.Length != 11 && ssnString.Length != 12)
            {
                return null;
            }

            return ssnString;
        }

        private static string ParseFsysHwc(byte[] sourceBytes, int hwcOffset)
        {
            if (hwcOffset == -1)
            {
                return null;
            }

            byte[] hwcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, hwcOffset + HWC_NUDGE_POS, HWC_LENGTH);

            if (hwcBytes == null)
            {
                return null;
            }

            string hwcString = _utf8.GetString(hwcBytes).Trim();
            hwcString = new string(hwcString.Where(char.IsLetterOrDigit).ToArray());

            return hwcString;
        }

        private static string ParseFsysSon(byte[] sourceBytes, int sonOffset)
        {
            if (sonOffset == -1)
            {
                return null;
            }

            byte indexByte = 0x00;
            byte[] terminationBytes = { 0x03, 0x04, 0x09 };
            byte[] sonBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, sonOffset, indexByte, terminationBytes);

            if (sonBytes == null)
            {
                return null;
            }

            string sonString = _utf8.GetString(sonBytes);

            if (sonString.EndsWith("/")) return sonString.TrimEnd('/');

            return sonString;
        }

        private static FsysStore DefaultFsysRegion()
        {
            return new FsysStore
            {
                FsysBytes = null,
                FsysOffset = -1,
                Serial = null,
                SerialOffset = -1,
                HWC = null,
                HWCOffset = -1,
                SON = null,
                CrcString = null,
                CrcCalcString = null,
                CRC32CalcInt = 0xFFFFFFF
            };
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

        internal static readonly byte[] SNP_LOWER_SIG =
        {
            0x73, 0x6E, 0x70
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
        internal static NvramStore GetNvramStoreData(byte[] sourceBytes, NvramStoreType storeType)
        {
            byte[] nvramSignature = GetNvramSignature(storeType);

            // We must find the NVRAM section GUID first.
            int nvramOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_SECTION_GUID);

            if (nvramOffset == -1)
            {
                // Could not find the NVRAM GUID
                return DefaultNvramStoreData();
            }

            int primaryStoreOffset = BinaryUtils.GetOffset(sourceBytes, nvramSignature, nvramOffset);

            if (primaryStoreOffset == -1)
            {
                // Could not find the primary store signature
                return DefaultNvramStoreData();
            }

            byte[] primaryStoreBytes = null;
            bool isPrimaryStoreEmpty = true;
            int primaryStoreLength = -1;

            if (primaryStoreOffset != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStoreOffset, 0x6) is byte[] primaryHeaderBytes)
            {
                NvramStoreHeader primaryStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(primaryHeaderBytes);

                if (primaryStoreHeader.SizeOfData != 0xFFFF && primaryStoreHeader.SizeOfData != 0)
                {
                    primaryStoreLength = primaryStoreHeader.SizeOfData;
                    primaryStoreBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStoreOffset, primaryStoreLength);

                    if (primaryStoreBytes != null)
                    {
                        byte[] primaryStoreBodyData = BinaryUtils.GetBytesAtOffset(sourceBytes, primaryStoreOffset + GUID_LENGTH, primaryStoreLength - GUID_LENGTH);
                        isPrimaryStoreEmpty = BinaryUtils.IsByteBlockEmpty(primaryStoreBodyData);
                    }
                }
            }

            // Count the padding bytes after the primary store (After the last 0xFF we should have our backup store signature)
            int paddingLength = 0;
            for (int i = (primaryStoreOffset + primaryStoreLength); i < sourceBytes.Length && sourceBytes[i] == 0xFF; i++)
            {
                paddingLength++;
            }

            byte[] backupStoreBytes = null;
            bool isBackupStoreEmpty = true;
            int backupStoreLength = -1;

            int backupStoreOffset = BinaryUtils.GetOffset(sourceBytes, nvramSignature, primaryStoreOffset + primaryStoreLength + paddingLength);

            if (backupStoreOffset != -1 && BinaryUtils.GetBytesAtOffset(sourceBytes, backupStoreOffset, 0x6) is byte[] backupHeaderBytes)
            {
                NvramStoreHeader backupStoreHeader = Helper.DeserializeHeader<NvramStoreHeader>(backupHeaderBytes);

                if (backupStoreHeader.SizeOfData != 0xFFFF)
                {
                    backupStoreLength = backupStoreHeader.SizeOfData;
                    backupStoreBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, backupStoreOffset, backupStoreLength);

                    if (backupStoreBytes != null)
                    {
                        byte[] backupStoreBodyData = BinaryUtils.GetBytesAtOffset(sourceBytes, backupStoreOffset + GUID_LENGTH, backupStoreLength - GUID_LENGTH);
                        isBackupStoreEmpty = BinaryUtils.IsByteBlockEmpty(backupStoreBodyData);
                    }
                }
            }

            return new NvramStore
            {
                StoreType = storeType,
                PrimaryStoreLength = primaryStoreLength,
                PrimaryStoreOffset = primaryStoreOffset,
                PrimaryStoreBytes = primaryStoreBytes,
                IsPrimaryStoreEmpty = isPrimaryStoreEmpty,
                BackupStoreLength = backupStoreLength,
                BackupStoreOffset = backupStoreOffset,
                BackupStoreBytes = backupStoreBytes,
                IsBackupStoreEmpty = isBackupStoreEmpty,
            };
        }

        private static NvramStore DefaultNvramStoreData()
        {
            return new NvramStore
            {
                PrimaryStoreLength = -1,
                PrimaryStoreOffset = -1,
                PrimaryStoreBytes = null,
                IsPrimaryStoreEmpty = true,
                BackupStoreLength = -1,
                BackupStoreOffset = -1,
                BackupStoreBytes = null,
                IsBackupStoreEmpty = true
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
            int lockMarker = BinaryUtils.GetOffset(nvramStoreBytes, EFI_LOCK_MAC_SIG);
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
            Dictionary<byte[], string> romInfoData = new Dictionary<byte[], string>
            {
                { BIOS_ID_SIGNATURE, null },
                { MODEL_SIGNATURE, null },
                { EFI_VERSION_SIGNATURE, null },
                { BUILT_BY_SIGNATURE, null },
                { DATE_SIGNATURE, null },
                { REVISION_SIGNATURE, null },
                { ROM_VERSION_SIGNATURE, null },
                { BUILDCAVE_ID_SIGNATURE, null },
                { BUILD_TYPE_SIGNATURE, null },
                { COMPILER_SIGNATURE, null }
            };

            // Create a separate dictionary to store updated data
            Dictionary<byte[], string> updatedRomInfoData = new Dictionary<byte[], string>(romInfoData);
            // First we need to locate the AppleRomInformation section GUID
            int baseOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID);

            if (baseOffset == -1)
            {
                // AppleRomInformation GUID was not found, so return default data
                return DefaultRomInformationBase();
            }

            // GUID Length (10h) AppleRomInformation section size data length (2h, int16)
            int headerLength = 0x18; int dataLength = 0x2;
            // Read first two bytes after the header
            byte[] dataLengthBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLength, dataLength);
            // Convert first two bytes to an int16 value and get the AppleRomInformation section size
            int sectionLength = BitConverter.ToInt16(dataLengthBytes, 0);
            // Read the entire AppleRomInformation section using sectionLen as the max search length
            byte[] romSectionBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLength, sectionLength);

            if (romSectionBytes == null)
            {
                return DefaultRomInformationBase();
            }

            // Extract data from the romSectionData based on the signature
            foreach (KeyValuePair<byte[], string> kvPair in romInfoData)
            {
                int dataOffset = BinaryUtils.GetOffset(romSectionBytes, kvPair.Key);
                if (dataOffset != -1)
                {
                    int signatureLength = kvPair.Key.Length;
                    // Extract the data using the signature position, signature length, index byte, and termination byte
                    byte[] infoBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(romSectionBytes, dataOffset + signatureLength, indexByte, terminationByte);
                    if (infoBytes != null)
                    {
                        // Convert the extracted byte array to string using UTF-8 encoding
                        updatedRomInfoData[kvPair.Key] = _utf8.GetString(infoBytes);
                    }
                }
            }

            // Update the original romInfoData dictionary with the extracted and updated values
            foreach (KeyValuePair<byte[], string> kvPair in updatedRomInfoData)
            {
                romInfoData[kvPair.Key] = kvPair.Value;
            }

            // Some EFI have this section GUID, however the data is empty
            sectionHasData = romSectionBytes.Length <= 0x18 ? false : true;

            // Create and return an instance of AppleRomInformation with the extracted data
            return new AppleRomInformationSection
            {
                SectionExists = sectionHasData,
                SectionBytes = romSectionBytes,
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
            int guidOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.EFI_BIOS_ID_GUID);

            if (guidOffset == -1)
            {
                return DefaultEfiSection();
            }

            int modelOffset = BinaryUtils.GetOffset(sourceBytes, EFI_SECTION_SIGNATURE);

            if (modelOffset == -1)
            {
                return DefaultEfiSection();
            }

            byte indexByte = 0x20;
            byte terminationByte = 0x2E;
            byte[] modelBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, modelOffset, indexByte, terminationByte);

            if (modelBytes == null)
            {
                return DefaultEfiSection();
            }

            modelBytes = modelBytes.Where(b => b != 0x00 && b != 0x20).ToArray();

            return new EfiSection
            {
                Model = _utf8.GetString(modelBytes)
            };
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
        internal static ApfsCapableFirmware GetIsApfsCapable(byte[] sourceBytes)
        {
            // APFS DXE GUID found
            if (BinaryUtils.GetOffset(sourceBytes, FSGuids.APFS_DXE_GUID) != -1)
            {
                return ApfsCapableFirmware.Yes;
            }

            // Disable compressed DXE searching is enabled (Maybe I should get rid of this?)
            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch))
            {
                return ApfsCapableFirmware.Unknown;
            }

            // Look for a compressed volume GUID
            int lzmaDxeOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.LZMA_DXE_VOLUME_IMAGE_GUID);

            if (lzmaDxeOffset == -1)
            {
                lzmaDxeOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.LZMA_DXE_VOLUME_IMAGE_OLD_GUID);
            }

            // No compressed DXE volume was found
            if (lzmaDxeOffset == -1)
            {
                return ApfsCapableFirmware.No;
            }

            // Get bytes containing section length (0x3)
            byte[] dataLengthBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, lzmaDxeOffset + 0x14, 0x3);
            // Convert section length bytes to int24
            int sectionLength = BitConvert.ToInt24(dataLengthBytes);
            // Determine the end of the lzma guid section
            int endOffset = lzmaDxeOffset + sectionLength;
            // Signature length
            int signatureLength = 0x10;
            // Search for the LZMA signature byte
            lzmaDxeOffset = BinaryUtils.GetOffset(sourceBytes, new byte[] { 0x5D }, lzmaDxeOffset + signatureLength);
            // Decompress the LZMA volume
            byte[] decompressedBytes = LzmaCoder.DecompressBytes(BinaryUtils.GetBytesBetweenOffsets(sourceBytes, lzmaDxeOffset, endOffset));

            // There was an decompressing the volume (Error saved to './mefit.log')
            if (decompressedBytes == null)
            {
                return ApfsCapableFirmware.Unknown;
            }

            // Search the decompressed DXE volume for the APFS DXE GUID
            if (BinaryUtils.GetOffset(decompressedBytes, FSGuids.APFS_DXE_GUID) == -1)
            {
                // The APFS DXE GUID was not found in the compressed volume
                return ApfsCapableFirmware.No;
            }

            // The APFS DXE GUID was present in the compressed volume
            return ApfsCapableFirmware.Yes;
        }
        #endregion

    }
}