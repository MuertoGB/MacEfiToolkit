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
        internal int FsysBase { get; set; }
        internal string Serial { get; set; }
        internal int SerialBase { get; set; }
        internal string HWC { get; set; }
        internal int HWCBase { get; set; }
        internal string SON { get; set; }
        internal string CrcString { get; set; }
        internal string CrcCalcString { get; set; }
        internal uint CRC32CalcInt { get; set; }
    }

    internal struct NvramStore
    {
        internal NvramStoreType StoreType { get; set; }
        internal int PrimaryStoreBase { get; set; }
        internal int PrimaryStoreSize { get; set; }
        internal byte[] PrimaryStoreBytes { get; set; }
        internal bool IsPrimaryStoreEmpty { get; set; }
        internal int BackupStoreBase { get; set; }
        internal int BackupStoreSize { get; set; }
        internal byte[] BackupStoreBytes { get; set; }
        internal bool IsBackupStoreEmpty { get; set; }
    }

    internal struct AppleRomInformationSection
    {
        internal bool SectionExists { get; set; }
        internal byte[] SectionBytes { get; set; }
        internal int SectionBase { get; set; }
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
        internal static bool FirmwareLoaded = false;

        internal static FileInfoStore FileInfoData;
        internal static PdrSection PDRSectionData;
        internal static NvramStore VssStoreData;
        internal static NvramStore SvsStoreData;
        internal static NvramStore NssStoreData;
        internal static FsysStore FsysStoreData;
        internal static AppleRomInformationSection ROMInfoSectionData;
        internal static EfiSection EFISectionData;

        internal static EfiLockStatus EfiLock = EfiLockStatus.Unknown;

        internal const int MIN_IMAGE_SIZE = 1048576;  // 100000h
        internal const int MAX_IMAGE_SIZE = 33554432; // 2000000h
        internal const int FSYS_RGN_SIZE = 2048;      // 800h
        internal const int FSYS_CRC_POS = 2044;       // 7FCh

        private const int GUID_LENGTH = 16;          // 10h
        private const int ZERO_VECTOR_LENGTH = 16;   // 10h
        private const int LITERAL_POS = 2;           // 2h
        private const int CRC32_LENGTH = 4;          // 4h

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

            EfiLock = (SvsStoreData.PrimaryStoreBase != -1 && SvsStoreData.PrimaryStoreBytes != null)
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
            int pdrBase = (Descriptor.PdrBase != 0 ? (int)Descriptor.PdrBase : 0);
            int pdrLimit = (Descriptor.PdrLimit != 0 ? (int)Descriptor.PdrLimit : FileInfoData.FileLength);

            int guidBase = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.PDR_SECTION_GUID, pdrBase, pdrLimit);

            if (guidBase == -1)
            {
                // Platform data region not found
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes
            int bidBase = BinaryUtils.GetBasePosition(sourceBytes, PDR_BOARD_ID_SIGNATURE, guidBase);

            if (bidBase == -1)
            {
                // Board id signature not found
                return DefaultPdrSection();
            }

            int boardIdLength = 8;
            int dataStartPosition = 5;
            byte[] bidBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, bidBase + dataStartPosition, boardIdLength);

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
            // Base should be zero if the isFsysStoreOnly flag is set
            int fsysBase = 0;

            // Arg to skip Fsys searching
            if (!isFsysStoreOnly)
            {
                // Check the descriptor for bios base + limit
                int biosBase = Descriptor.BiosBase != 0 ? (int)Descriptor.BiosBase : 0;
                int biosLimit = Descriptor.BiosLimit != 0 ? (int)Descriptor.BiosLimit : FileInfoData.FileLength;

                // First we need to locate the NVRAM section GUID
                int guidBase = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.NVRAM_SECTION_GUID, biosBase, biosLimit);

                if (guidBase == -1)
                {
                    // NVRAM store was not found so return default data
                    return DefaultFsysRegion();
                }

                // Get NVRAM section size from header
                byte[] sectionLengthBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, guidBase + GUID_LENGTH, 4);
                // Convert NVRAM section size to int32
                int nvramLength = BitConverter.ToInt32(sectionLengthBytes, 0);
                // Search for the Fsys store within bounds of the NVRAM section
                fsysBase = BinaryUtils.GetBasePosition(sourceBytes, FSYS_SIG, guidBase - ZERO_VECTOR_LENGTH - GUID_LENGTH, nvramLength);

                // Fsys store was not found within scope of the NVRAM section
                if (fsysBase == -1)
                {
                    return DefaultFsysRegion();
                }
            }

            byte[] fsysStoreBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, fsysBase, FSYS_RGN_SIZE);

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
            byte[] crcBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, fsysBase + FSYS_CRC_POS, CRC32_LENGTH);
            byte[] crcEndianBytes = crcBytes.Reverse().ToArray(); // We need to flip the bytes from little endian
            string crcString = BitConverter.ToString(crcEndianBytes).Replace("-", "");

            // Manually calculate the Fsys store crc
            uint uiCrcCalc = MacUtils.GetUintFsysCrc32(fsysStoreBytes);
            string crcCalcString = uiCrcCalc.ToString("X8");

            // Parse the serial number
            int snDataStart = -1;

            // Look for the lower case system serial number signature
            if ((snDataStart = BinaryUtils.GetBasePosition(sourceBytes, SSN_LOWER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                snDataStart += SSN_LOWER_SIG.Length;

            // Look for the upper case system serial number signature
            if (snDataStart == -1)
            {
                if ((snDataStart = BinaryUtils.GetBasePosition(sourceBytes, SSN_UPPER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                    snDataStart += SSN_UPPER_SIG.Length;
            }

            // Look for other ssn signatures
            if (snDataStart == -1)
            {
                if ((snDataStart = BinaryUtils.GetBasePosition(sourceBytes, SSNP_LOWER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                    snDataStart += SSNP_LOWER_SIG.Length;
            }

            string serialString = ParseFsysString(sourceBytes, snDataStart);
            if (serialString == null) snDataStart = -1;

            // Parse the hardware configuration code
            int hwcDataStart = -1;

            // Look for the hardware configuration lower case signature
            if ((hwcDataStart = BinaryUtils.GetBasePosition(sourceBytes, HWC_LOWER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                hwcDataStart += HWC_LOWER_SIG.Length;

            // Look for the hardware configuration upper case signature
            if (hwcDataStart == -1)
            {
                if ((hwcDataStart = BinaryUtils.GetBasePosition(sourceBytes, HWC_UPPER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                    hwcDataStart += HWC_UPPER_SIG.Length;
            }

            string hwcString = ParseFsysString(sourceBytes, hwcDataStart);
            if (hwcString == null) hwcDataStart = -1;

            // Parse the system order number
            int sonDataStart = -1;

            // Look for the system order number lower case signature
            if ((sonDataStart = BinaryUtils.GetBasePosition(sourceBytes, SON_LOWER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
            {
                sonDataStart += SON_LOWER_SIG.Length;
            }

            // Look for the system order number upper case signature
            if (sonDataStart == -1)
            {
                if ((sonDataStart = BinaryUtils.GetBasePosition(sourceBytes, SON_UPPER_SIG, fsysBase, FSYS_RGN_SIZE)) != -1)
                {
                    sonDataStart += SON_UPPER_SIG.Length;
                }
            }

            string sonString = ParseFsysString(sourceBytes, sonDataStart);
            if (sonString != null && sonString.EndsWith("/"))
            {
                sonString = sonString.TrimEnd('/');
            }

            return new FsysStore
            {
                FsysBytes = fsysStoreBytes,
                FsysBase = fsysBase,
                Serial = serialString,
                SerialBase = snDataStart != -1 ? snDataStart + LITERAL_POS : -1,
                HWC = hwcString,
                HWCBase = hwcDataStart != -1 ? hwcDataStart + LITERAL_POS : -1,
                SON = sonString,
                CrcString = crcString,
                CrcCalcString = crcCalcString,
                CRC32CalcInt = uiCrcCalc
            };
        }

        private static string ParseFsysString(byte[] sourceBytes, int basePos)
        {
            // If the base is -1 return null
            if (basePos == -1)
            {
                return null;
            }

            // Read size of the indicated variable
            int dataSize = sourceBytes[basePos];

            // Invalid data size
            if (dataSize == 0)
            {
                return null;
            }

            // Read the variable bytes
            byte[] dataBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, basePos + LITERAL_POS, dataSize);

            // Invalid bytes
            if (dataBytes == null || dataBytes.Length > dataSize)
            {
                return null;
            }

            // Return string data
            return _utf8.GetString(dataBytes);
        }

        private static FsysStore DefaultFsysRegion()
        {
            return new FsysStore
            {
                FsysBytes = null,
                FsysBase = -1,
                Serial = null,
                SerialBase = -1,
                HWC = null,
                HWCBase = -1,
                SON = null,
                CrcString = null,
                CrcCalcString = null,
                CRC32CalcInt = 0xFFFFFFF
            };
        }

        // Fsys resides in the NVRAM at either base: 20000h, or 22000h.
        internal static readonly byte[] FSYS_SIG =
        {
            0x46, 0x73, 0x79, 0x73,
            0x01
        };

        internal static readonly byte[] SSN_LOWER_SIG =
        {
            0x03, 0x73, 0x73, 0x6E
        };

        internal static readonly byte[] SSN_UPPER_SIG =
        {
            0x03, 0x53, 0x53, 0x4E
        };

        internal static readonly byte[] SSNP_LOWER_SIG =
        {
             0x04, 0x73, 0x73, 0x6E, 0x70
        };

        internal static readonly byte[] HWC_LOWER_SIG =
        {
            0x03, 0x68, 0x77, 0x63
        };

        internal static readonly byte[] HWC_UPPER_SIG =
        {
            0x03, 0x53, 0x53, 0x4E
        };

        internal static readonly byte[] SON_LOWER_SIG =
        {
            0x03, 0x73, 0x6F, 0x6E
        };

        internal static readonly byte[] SON_UPPER_SIG =
        {
            0x03, 0x53, 0x4F, 0x4E
        };
        #endregion

        #region NVRAM Section
        internal static NvramStore GetNvramStoreData(byte[] sourceBytes, NvramStoreType storeType)
        {
            byte[] nvramSig = GetNvramSignature(storeType);
            int biosBase = Descriptor.BiosBase != 0 ? (int)Descriptor.BiosBase : 0;
            int biosLimit = Descriptor.BiosLimit != 0 ? (int)Descriptor.BiosLimit : FileInfoData.FileLength;
            int nvramPos = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.NVRAM_SECTION_GUID, biosBase, biosLimit);
            int paddingLen = 0;

            if (nvramPos == -1)
            {
                return DefaultNvramStoreData();
            }

            int primaryStoreSize = -1;
            int primaryStoreBase = -1;
            byte[] primaryStoreData = null;
            bool isPrimaryStoreEmpty = true;

            int psHeaderBase = BinaryUtils.GetBasePosition(sourceBytes, nvramSig, nvramPos);

            if (psHeaderBase != -1 && BinaryUtils.GetBytesBaseLength(sourceBytes, psHeaderBase, 6) is byte[] bytesPrimaryHeader)
            {
                NvramStoreHeader psHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesPrimaryHeader);

                if (psHeader.SizeOfData != 0xFFFF && psHeader.SizeOfData != 0)
                {
                    primaryStoreSize = psHeader.SizeOfData;
                    primaryStoreBase = psHeaderBase;
                    primaryStoreData = BinaryUtils.GetBytesBaseLength(sourceBytes, primaryStoreBase, primaryStoreSize);

                    if (primaryStoreData != null)
                    {
                        byte[] primaryStoreBodyData = BinaryUtils.GetBytesBaseLength(sourceBytes, primaryStoreBase + GUID_LENGTH, primaryStoreSize - GUID_LENGTH);
                        isPrimaryStoreEmpty = BinaryUtils.IsByteBlockEmpty(primaryStoreBodyData);
                    }

                    for (int i = primaryStoreBase + primaryStoreSize; i < sourceBytes.Length && sourceBytes[i] == 0xFF; i++)
                    {
                        paddingLen++;
                    }
                }
            }

            int backupStoreSize = -1;
            int backupStoreBase = -1;
            byte[] backupStoreData = null;
            bool isBackupStoreEmpty = true;

            if (primaryStoreBase != -1)
            {
                int bsHeaderBase = BinaryUtils.GetBasePosition(sourceBytes, nvramSig, primaryStoreBase + primaryStoreSize + paddingLen);

                if (bsHeaderBase != -1 && BinaryUtils.GetBytesBaseLength(sourceBytes, bsHeaderBase, 6) is byte[] bytesBackupHeader)
                {
                    NvramStoreHeader bsHeader = Helper.DeserializeHeader<NvramStoreHeader>(bytesBackupHeader);

                    if (bsHeader.SizeOfData != 0xFFFF && bsHeader.SizeOfData != 0)
                    {
                        backupStoreSize = bsHeader.SizeOfData;
                        backupStoreBase = bsHeaderBase;
                        backupStoreData = BinaryUtils.GetBytesBaseLength(sourceBytes, backupStoreBase, backupStoreSize);

                        if (backupStoreData != null)
                        {
                            byte[] bsBodyData = BinaryUtils.GetBytesBaseLength(sourceBytes, backupStoreBase + GUID_LENGTH, backupStoreSize - GUID_LENGTH);
                            isBackupStoreEmpty = BinaryUtils.IsByteBlockEmpty(bsBodyData);
                        }
                    }
                }
            }

            return new NvramStore
            {
                StoreType = storeType,
                PrimaryStoreSize = primaryStoreSize,
                PrimaryStoreBase = primaryStoreBase,
                PrimaryStoreBytes = primaryStoreData,
                IsPrimaryStoreEmpty = isPrimaryStoreEmpty,
                BackupStoreSize = backupStoreSize,
                BackupStoreBase = backupStoreBase,
                BackupStoreBytes = backupStoreData,
                IsBackupStoreEmpty = isBackupStoreEmpty,
            };
        }

        private static NvramStore DefaultNvramStoreData()
        {
            return new NvramStore
            {
                PrimaryStoreSize = -1,
                PrimaryStoreBase = -1,
                PrimaryStoreBytes = null,
                IsPrimaryStoreEmpty = true,
                BackupStoreSize = -1,
                BackupStoreBase = -1,
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
            int lockMarker = BinaryUtils.GetBasePosition(nvramStoreBytes, EFI_LOCK_MAC_SIG);
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

            // Check the descriptor for bios base + limit
            int biosBase = Descriptor.BiosBase != 0 ? (int)Descriptor.BiosBase : 0;
            int biosLimit = Descriptor.BiosLimit != 0 ? (int)Descriptor.BiosLimit : FileInfoData.FileLength;

            // First we need to locate the AppleRomInformation section GUID
            List<int> romSectionBases = new List<int>();

            int guidPosition = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID, biosBase, biosLimit);

            // Seach all GUIDs
            while (guidPosition != -1)
            {
                // Store the base position of the AppleRomInformation section
                romSectionBases.Add(guidPosition);

                // Move the search position to the next occurrence of the GUID
                guidPosition = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID, guidPosition + 1, biosLimit);
            }

            if (romSectionBases.Count == 0)
            {
                // AppleRomInformation GUID was not found, so return default data
                return DefaultRomInformationBase();
            }

            // Declare the variables outside the loop to ensure accessibility
            byte[] romSectionBytes = null;

            // Process each AppleRomInformation section
            foreach (int sectionBase in romSectionBases)
            {
                // Header Length (18h) AppleRomInformation section size (2h, int16)
                int headerLength = 24; // 18h
                int dataLength = 2; // 2h

                // Read first two bytes after the header
                byte[] dataLengthBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, sectionBase + headerLength, dataLength);

                // Convert first two bytes to an int16 value and get the AppleRomInformation section size
                int sectionLength = BitConverter.ToInt16(dataLengthBytes, 0);

                if (sectionLength <= 6)
                {
                    // Skip reading the section if the length is under 6
                    continue;
                }

                // Read the entire AppleRomInformation section using sectionLength as the max search length
                romSectionBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, sectionBase + headerLength, sectionLength);

                if (romSectionBytes == null)
                {
                    return DefaultRomInformationBase();
                }

                // Extract data from the romSectionBytes based on the signature
                Dictionary<byte[], string> updatedRomInfoData = new Dictionary<byte[], string>(romInfoData);

                foreach (KeyValuePair<byte[], string> kvPair in romInfoData)
                {
                    int dataBase = BinaryUtils.GetBasePosition(romSectionBytes, kvPair.Key);

                    if (dataBase != -1)
                    {
                        int keyLength = kvPair.Key.Length;
                        // Extract the data using the signature position, signature length, index byte, and termination byte
                        byte[] infoBytes = BinaryUtils.GetBytesDelimited(romSectionBytes, dataBase + keyLength, indexByte, terminationByte);

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

                // Create and return an instance of AppleRomInformation with the extracted data
                return new AppleRomInformationSection
                {
                    SectionExists = sectionLength > 6,
                    SectionBytes = romSectionBytes,
                    SectionBase = sectionBase,
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

            // If no valid AppleRomInformation section is found, return default data
            return DefaultRomInformationBase();
        }

        internal static AppleRomInformationSection DefaultRomInformationBase()
        {
            return new AppleRomInformationSection
            {
                SectionExists = false,
                SectionBytes = null,
                SectionBase = -1,
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
            // Check the descriptor for bios base + limit
            int biosBase = Descriptor.BiosBase != 0 ? (int)Descriptor.BiosBase : 0;
            int biosLimit = Descriptor.BiosLimit != 0 ? (int)Descriptor.BiosLimit : FileInfoData.FileLength;

            int guidBase = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.EFI_BIOS_ID_GUID, biosBase, biosLimit);

            if (guidBase == -1)
            {
                return DefaultEfiSection();
            }

            int modelBase = BinaryUtils.GetBasePosition(sourceBytes, EFI_SECTION_SIGNATURE, guidBase);

            if (modelBase == -1)
            {
                return DefaultEfiSection();
            }

            byte indexByte = 0x20;
            byte terminationByte = 0x2E;
            byte[] modelBytes = BinaryUtils.GetBytesDelimited(sourceBytes, modelBase, indexByte, terminationByte);

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
            // Check the descriptor for bios base + limit
            int biosBase = Descriptor.BiosBase != 0 ? (int)Descriptor.BiosBase : 0;
            int biosLimit = Descriptor.BiosLimit != 0 ? (int)Descriptor.BiosLimit : FileInfoData.FileLength;

            // APFS DXE GUID found
            if (BinaryUtils.GetBasePosition(sourceBytes, FSGuids.APFS_DXE_GUID, biosBase, biosLimit) != -1)
            {
                return ApfsCapableFirmware.Yes;
            }

            // Disable compressed DXE searching is enabled (Maybe I should get rid of this?)
            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch))
            {
                return ApfsCapableFirmware.Unknown;
            }

            // Look for a compressed volume GUID
            int lzmaDxeBase = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.LZMA_DXE_VOLUME_IMAGE_GUID, biosBase, biosLimit);

            if (lzmaDxeBase == -1)
            {
                lzmaDxeBase = BinaryUtils.GetBasePosition(sourceBytes, FSGuids.LZMA_DXE_VOLUME_IMAGE_OLD_GUID, biosBase, biosLimit);
            }

            // No compressed DXE volume was found
            if (lzmaDxeBase == -1)
            {
                return ApfsCapableFirmware.No;
            }

            // Get bytes containing section length (0x3)
            byte[] dataLengthBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, lzmaDxeBase + 20, 3);
            // Convert section length bytes to int24
            int sectionLength = BitConvert.ToInt24(dataLengthBytes);
            // Determine the end of the lzma guid section
            int lzmaDxeLimit = lzmaDxeBase + sectionLength;
            // Search for the LZMA signature byte
            lzmaDxeBase = BinaryUtils.GetBasePosition(sourceBytes, new byte[] { 0x5D }, lzmaDxeBase + GUID_LENGTH);
            // Decompress the LZMA volume
            byte[] decompressedBytes = LzmaCoder.DecompressBytes(BinaryUtils.GetBytesBaseLimit(sourceBytes, lzmaDxeBase, lzmaDxeLimit));

            // There was an issue decompressing the volume (Error saved to './mefit.log')
            if (decompressedBytes == null)
            {
                return ApfsCapableFirmware.Unknown;
            }

            // Search the decompressed DXE volume for the APFS DXE GUID
            if (BinaryUtils.GetBasePosition(decompressedBytes, FSGuids.APFS_DXE_GUID) == -1)
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