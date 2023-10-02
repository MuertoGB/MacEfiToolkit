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

    internal struct PdrSection
    {
        internal string BoardId { get; set; }
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

    internal struct EfiLock
    {
        internal EfiLockStatus LockStatus { get; set; }
        internal int LockCrcBase { get; set; }
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

    internal struct EfiBiosIdSection
    {
        internal string ModelPart { get; set; }
        internal string zzPart { get; set; }
        internal string MajorPart { get; set; }
        internal string MinorPart { get; set; }
        internal string DatePart { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NvramStoreHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal ushort SizeOfData;
    }
    #endregion

    #region Enums
    internal enum ApfsCapable
    {
        Guid,
        Lzma,
        No,
        Unknown
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

    class AppleEFI
    {

        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBytes = null;
        internal static bool FirmwareLoaded = false;
        internal static string FirmwareVersion = null;
        internal static bool ForceFoundFsys = false;
        internal static string FitVersion = null;
        internal static string MeVersion = null;

        internal static FileInfoStore FileInfoData;
        internal static PdrSection PdrSectionData;
        internal static NvramStore VssStoreData;
        internal static NvramStore SvsStoreData;
        internal static NvramStore NssStoreData;
        internal static EfiLock EfiPrimaryLockData = DefaultEfiLockStatus();
        internal static EfiLock EfiBackupLockData = DefaultEfiLockStatus();
        internal static FsysStore FsysStoreData;
        internal static AppleRomInformationSection AppleRomInfoSectionData;
        internal static EfiBiosIdSection EfiBiosIdSectionData;

        internal static ApfsCapable IsApfsCapable = ApfsCapable.Unknown;

        internal static int FSYS_RGN_SIZE = 0;

        internal const int MIN_IMAGE_SIZE = 1048576;  // 100000h
        internal const int MAX_IMAGE_SIZE = 33554432; // 2000000h
        internal const int CRC32_SIZE = 4;            // 4h
        #endregion

        #region Private Members
        private const int GUID_LENGTH = 16;          // 10h
        private const int ZERO_VECTOR_LENGTH = 16;   // 10h
        private const int LITERAL_POS = 2;           // 2h
        private static readonly Encoding _utf8 = Encoding.UTF8;
        #endregion

        #region Process Firmware
        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            FileInfoData = GetBinaryFileInfo(fileName);
            PdrSectionData = GetPdrData(sourceBytes);
            VssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.VSS);
            SvsStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.SVS);
            NssStoreData = GetNvramStoreData(sourceBytes, NvramStoreType.NSS);

            EfiPrimaryLockData = GetIsEfiLocked(SvsStoreData.PrimaryStoreBytes);
            EfiBackupLockData = GetIsEfiLocked(SvsStoreData.BackupStoreBytes);

            FsysStoreData = GetFsysStoreData(sourceBytes, false);
            AppleRomInfoSectionData = GetRomInformationData(sourceBytes);
            EfiBiosIdSectionData = GetEfiBiosIdSectionData(sourceBytes);

            IsApfsCapable = GetIsApfsCapable(LoadedBinaryBytes);
            FirmwareVersion = MacUtils.GetFirmwareVersion();
            FitVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.FlashImageTool);
            MeVersion = MEParser.GetVersionData(LoadedBinaryBytes, HeaderType.ManagementEngine);

            if (FsysStoreData.FsysBytes == null)
            {
                FsysStoreData = GetFsysStoreData(sourceBytes, false, true);

                if (FsysStoreData.FsysBytes != null)
                {
                    ForceFoundFsys = true;
                    Logger.WriteToLogFile($"Force found Fsys Store at {FsysStoreData.FsysBase:X}h." +
                        $" The image may be misaligned or corrupt ({FileInfoData.FileNameWithExt}).", LogType.Application);
                }
            }
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBytes = null;
            FirmwareLoaded = false;
            FirmwareVersion = null;
            ForceFoundFsys = false;
            FitVersion = null;
            MeVersion = null;

            FileInfoData = default;
            PdrSectionData = default;
            VssStoreData = default;
            SvsStoreData = default;
            NssStoreData = default;
            EfiPrimaryLockData = default;
            EfiBackupLockData = default;
            FsysStoreData = default;
            AppleRomInfoSectionData = default;
            EfiBiosIdSectionData = default;
            IsApfsCapable = ApfsCapable.Unknown;

            FSYS_RGN_SIZE = 0;
        }

        internal static bool IsValidImage(byte[] sourceBytes)
        {
            int dxeCore = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.DXE_CORE,
                16,
                16);

            if (!Descriptor.DescriptorMode)
            {
                if (dxeCore == -1)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

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
            int guidBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.PDR_SECTION_GUID,
                (int)Descriptor.PDR_REGION_BASE,
                (int)Descriptor.PDR_REGION_LIMIT);

            if (guidBase == -1)
            {
                // Platform data region not found
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes
            int bidBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                PDR_BOARD_ID_SIGNATURE,
                guidBase);

            if (bidBase == -1)
            {
                // Board id signature not found
                return DefaultPdrSection();
            }

            int boardIdLength = 8;
            int dataStartPosition = 5;
            byte[] bidBytes = BinaryUtils.GetBytesBaseLength(
                sourceBytes,
                bidBase + dataStartPosition,
                boardIdLength);

            if (bidBytes == null)
            {
                return DefaultPdrSection();
            }

            // Return the board id
            return new PdrSection
            {
                BoardId = $"Mac-{BitConverter.ToString(bidBytes).Replace("-", "")}"
            };
        }

        private static PdrSection DefaultPdrSection()
        {
            return new PdrSection
            {
                BoardId = null
            };
        }

        internal static readonly byte[] PDR_BOARD_ID_SIGNATURE =
        {
            0xF8, 0x7C, 0x00, 0x00,
            0x19
        };
        #endregion

        #region NVRAM Section
        internal static NvramStore GetNvramStoreData(byte[] sourceBytes, NvramStoreType storeType)
        {
            byte[] nvramSig = GetNvramSignature(storeType);

            int nvramPos = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.NVRAM_SECTION_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT);

            int paddingLen = 0;

            if (nvramPos == -1)
            {
                return DefaultNvramStoreData();
            }

            int primaryStoreSize = -1;
            int primaryStoreBase = -1;
            byte[] primaryStoreData = null;
            bool isPrimaryStoreEmpty = true;

            int primaryStoreHeaderBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                nvramSig,
                nvramPos);

            if (primaryStoreHeaderBase != -1 && BinaryUtils.GetBytesBaseLength(
                sourceBytes, primaryStoreHeaderBase, 6) is byte[] bytesPrimaryHeader)
            {
                NvramStoreHeader primaryStoreHeader =
                    Helper.DeserializeHeader<NvramStoreHeader>(bytesPrimaryHeader);

                if (primaryStoreHeader.SizeOfData != 0xFFFF && primaryStoreHeader.SizeOfData != 0)
                {
                    primaryStoreSize = primaryStoreHeader.SizeOfData;
                    primaryStoreBase = primaryStoreHeaderBase;
                    primaryStoreData = BinaryUtils.GetBytesBaseLength(
                        sourceBytes,
                        primaryStoreBase,
                        primaryStoreSize);

                    if (primaryStoreData != null)
                    {
                        byte[] primaryStoreBodyData = BinaryUtils.GetBytesBaseLength(
                            sourceBytes,
                            primaryStoreBase + GUID_LENGTH,
                            primaryStoreSize - GUID_LENGTH);

                        isPrimaryStoreEmpty =
                            BinaryUtils.IsByteBlockEmpty(primaryStoreBodyData);
                    }

                    for (int i = primaryStoreBase + primaryStoreSize;
                        i < sourceBytes.Length && sourceBytes[i] == 0xFF; i++)
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
                int backupStoreHeaderBase = BinaryUtils.GetBasePosition(
                    sourceBytes,
                    nvramSig,
                    primaryStoreBase + primaryStoreSize + paddingLen);

                if (backupStoreHeaderBase != -1 && BinaryUtils.GetBytesBaseLength(
                    sourceBytes, backupStoreHeaderBase, 6) is byte[] bytesBackupHeader)
                {
                    NvramStoreHeader backupStoreHeader =
                        Helper.DeserializeHeader<NvramStoreHeader>(bytesBackupHeader);

                    if (backupStoreHeader.SizeOfData != 0xFFFF && backupStoreHeader.SizeOfData != 0)
                    {
                        backupStoreSize = backupStoreHeader.SizeOfData;
                        backupStoreBase = backupStoreHeaderBase;
                        backupStoreData = BinaryUtils.GetBytesBaseLength(
                            sourceBytes,
                            backupStoreBase,
                            backupStoreSize);

                        if (backupStoreData != null)
                        {
                            byte[] bsBodyData = BinaryUtils.GetBytesBaseLength(
                                sourceBytes,
                                backupStoreBase + GUID_LENGTH,
                                backupStoreSize - GUID_LENGTH);

                            isBackupStoreEmpty =
                                BinaryUtils.IsByteBlockEmpty(bsBodyData);
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

        internal static EfiLock GetIsEfiLocked(byte[] nvramStoreBytes)
        {
            // NVRAM store is empty
            if (nvramStoreBytes == null)
                return DefaultEfiLockStatus();

            // Search store for Message Authentication Code
            int lockCrcBase =
                BinaryUtils.GetBasePosition(nvramStoreBytes, EFI_LOCK_MAC_SIG);

            // No Message Authentication Code was found
            if (lockCrcBase == -1)
                return DefaultEfiLockStatus();

            // lockBase was set
            return new EfiLock
            {
                LockStatus = EfiLockStatus.Locked,
                LockCrcBase = lockCrcBase
            };
        }

        private static EfiLock DefaultEfiLockStatus()
        {
            return new EfiLock
            {
                LockStatus = EfiLockStatus.Unlocked,
                LockCrcBase = -1,
            };
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

        #region Fsys Store
        // Fsys resides in the NVRAM at either base: 20000h, or 22000h.
        internal static FsysStore GetFsysStoreData(byte[] sourceBytes, bool isFsysStoreOnly, bool forceFind = false)
        {
            // Find the base position of Fsys Store
            int fsysBase =
                FindFsysBase(sourceBytes, isFsysStoreOnly, forceFind);

            // If Fsys Store base is not found, return default data
            if (fsysBase == -1)
                return DefaultFsysRegion();

            // Retrieve FsysStore bytes
            byte[] fsysStoreBytes =
                GetFsysStoreBytes(sourceBytes, fsysBase);

            // If FsysStore is invalid, return default data
            if (!IsValidFsysStore(fsysStoreBytes))
                return DefaultFsysRegion();

            // Retrieve CRC bytes and calculate CRC values
            byte[] crcBytes = GetCrcBytes(sourceBytes, fsysBase);
            string crcString = GetFlippedCrcString(crcBytes);
            uint uiCrcCalc = CalculateFsysCrc(fsysStoreBytes);
            string crcCalcString = uiCrcCalc.ToString("X8");

            // Find and parse various signatures within FsysStore
            int snDataStart = FindSignaturePosition
                (sourceBytes,
                fsysBase,
                FSYS_RGN_SIZE,
                SSN_LOWER_SIG,
                SSN_UPPER_SIG,
                SSNP_LOWER_SIG);
            string serialString =
                ParseFsysString(sourceBytes, snDataStart);

            int hwcDataStart = FindSignaturePosition(
                sourceBytes,
                fsysBase,
                FSYS_RGN_SIZE,
                HWC_LOWER_SIG,
                HWC_UPPER_SIG);
            string hwcString =
                ParseFsysString(sourceBytes, hwcDataStart);

            int sonDataStart = FindSignaturePosition(
                sourceBytes,
                fsysBase,
                FSYS_RGN_SIZE,
                SON_LOWER_SIG,
                SON_UPPER_SIG);
            string sonString =
                ParseFsysString(sourceBytes, sonDataStart);

            // Trim trailing '/' from SON string if present
            if (sonString != null && sonString.EndsWith("/"))
                sonString = sonString.TrimEnd('/');

            // Create and return FsysStore object
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
            // Return null if base position is invalid or data size is zero
            if (basePos == -1 || sourceBytes[basePos] == 0)
                return null;

            // Read size of the indicated variable
            int dataSize = sourceBytes[basePos];

            // Return null if data size is invalid
            if (dataSize == 0)
                return null;

            // Read the variable bytes
            byte[] dataBytes = BinaryUtils.GetBytesBaseLength(
                sourceBytes,
                basePos + LITERAL_POS,
                dataSize);

            // Return null if bytes are invalid or exceed the data size
            if (dataBytes == null || dataBytes.Length != dataSize)
                return null;

            // Return string data
            return _utf8.GetString(dataBytes);
        }

        private static int FindFsysBase(byte[] sourceBytes, bool isFsysStoreOnly, bool forceFind)
        {
            if (isFsysStoreOnly)
                return 0;

            if (forceFind)
                return BinaryUtils.GetBasePosition(
                    sourceBytes,
                    FSYS_SIG,
                    (int)Descriptor.BIOS_REGION_BASE,
                    (int)Descriptor.BIOS_REGION_LIMIT);

            int guidBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.NVRAM_SECTION_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT);

            if (guidBase == -1)
                return -1;

            int nvramLength = BitConverter.ToInt32(
                BinaryUtils.GetBytesBaseLength(
                    sourceBytes, guidBase + GUID_LENGTH, 4), 0);

            return BinaryUtils.GetBasePosition(
                sourceBytes,
                FSYS_SIG,
                guidBase - ZERO_VECTOR_LENGTH - GUID_LENGTH,
                nvramLength);
        }

        private static bool IsValidFsysStore(byte[] fsysStoreBytes)
        {
            return fsysStoreBytes != null && fsysStoreBytes.Length == FSYS_RGN_SIZE;
        }

        private static string GetFlippedCrcString(byte[] crcBytes)
        {
            byte[] crcEndianBytes = crcBytes.Reverse().ToArray();
            return BitConverter.ToString(crcEndianBytes).Replace("-", "");
        }

        private static uint CalculateFsysCrc(byte[] fsysStoreBytes)
        {
            return MacUtils.GetUintFsysCrc32(fsysStoreBytes);
        }

        private static int FindSignaturePosition(byte[] sourceBytes, int start, int limit, params byte[][] signatures)
        {
            foreach (byte[] sig in signatures)
            {
                int dataStart = BinaryUtils.GetBasePosition(
                    sourceBytes,
                    sig,
                    start,
                    limit);

                if (dataStart != -1)
                    return dataStart + sig.Length;
            }

            return -1;
        }

        private static byte[] GetFsysStoreBytes(byte[] sourceBytes, int fsysBase)
        {

            // Get Fsys Store size bytes - fsys base + 0x09, length 2 bytes (int16)
            byte[] sizeData = BinaryUtils.GetBytesBaseLength(
                sourceBytes,
                fsysBase + 9, 2);

            // Convert size to int16 value
            FSYS_RGN_SIZE = BitConverter.ToInt16(sizeData, 0);

            // Min Fsys rgn size
            if (FSYS_RGN_SIZE < 2048)
            {
                Logger.WriteToLogFile(
                    $"Fsys Store size was less than the min expected size: {FSYS_RGN_SIZE}",
                    LogType.Application);

                return null;
            }

            return BinaryUtils.GetBytesBaseLength(
                sourceBytes,
                fsysBase,
                FSYS_RGN_SIZE);
        }

        private static byte[] GetCrcBytes(byte[] sourceBytes, int fsysBase)
        {
            return BinaryUtils.GetBytesBaseLength(
                sourceBytes,
                fsysBase + FSYS_RGN_SIZE - CRC32_SIZE,
                CRC32_SIZE);
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

        #region ROM Section
        internal static AppleRomInformationSection GetRomInformationData(byte[] sourceBytes)
        {
            // Define index and termination bytes for data extraction
            byte indexByte = 0x20;
            byte terminationByte = 0x0A;

            // Create a dictionary to hold signature-data pairs
            Dictionary<byte[], string> romInfoData =
                new Dictionary<byte[], string>
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

            // First we need to locate the AppleRomInformation section GUID
            List<int> romSectionBases = new List<int>();

            int guidPosition = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.APPLE_ROM_INFO_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT);

            // Seach all GUIDs
            while (guidPosition != -1)
            {
                // Store the base position of the AppleRomInformation section
                romSectionBases.Add(guidPosition);

                // Move the search position to the next occurrence of the GUID
                guidPosition = BinaryUtils.GetBasePosition(
                    sourceBytes,
                    Guids.APPLE_ROM_INFO_GUID,
                    guidPosition + 1,
                    (int)Descriptor.BIOS_REGION_LIMIT);
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
                byte[] dataLengthBytes = BinaryUtils.GetBytesBaseLength(
                    sourceBytes,
                    sectionBase + headerLength,
                    dataLength);

                // Convert first two bytes to an int16 value and get the AppleRomInformation section size
                int sectionLength =
                    BitConverter.ToInt16(dataLengthBytes, 0);

                if (sectionLength <= 6)
                {
                    // Skip reading the section if the length is under 6
                    continue;
                }

                // Read the entire AppleRomInformation section using sectionLength as the max search length
                romSectionBytes = BinaryUtils.GetBytesBaseLength(
                    sourceBytes,
                    sectionBase + headerLength,
                    sectionLength);

                if (romSectionBytes == null)
                {
                    return DefaultRomInformationBase();
                }

                // Extract data from the romSectionBytes based on the signature
                Dictionary<byte[], string> updatedRomInfoData =
                    new Dictionary<byte[], string>(romInfoData);

                foreach (KeyValuePair<byte[], string> kvPair in romInfoData)
                {
                    int dataBase = BinaryUtils.GetBasePosition(romSectionBytes, kvPair.Key);

                    if (dataBase != -1)
                    {
                        int keyLength = kvPair.Key.Length;
                        // Extract the data using the signature position, signature length, index byte, and termination byte
                        byte[] infoBytes = BinaryUtils.GetBytesDelimited(
                            romSectionBytes,
                            dataBase + keyLength,
                            indexByte,
                            terminationByte);

                        if (infoBytes != null)
                        {
                            // Convert the extracted byte array to string using UTF-8 encoding
                            updatedRomInfoData[kvPair.Key] =
                                _utf8.GetString(infoBytes);
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

        #region EFI BIOS ID Section

        internal static EfiBiosIdSection GetEfiBiosIdSectionData(byte[] sourceBytes)
        {
            int guidBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.EFI_BIOS_ID_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT);

            if (guidBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int efiBiosIdBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                EFI_BIOS_ID_SIGNATURE,
                guidBase);

            if (efiBiosIdBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int efiBiosIdLimit = BinaryUtils.GetBasePosition(
                sourceBytes,
                new byte[] { 0x00, 0x00, 0x00 },
                efiBiosIdBase);

            byte[] efiBiosIdBytes = BinaryUtils.GetBytesBaseLimit(
                sourceBytes,
                efiBiosIdBase + EFI_BIOS_ID_SIGNATURE.Length,
                efiBiosIdLimit);

            if (efiBiosIdBytes == null)
            {
                return DefaultEfiBiosIdSection();
            }

            efiBiosIdBytes = efiBiosIdBytes.Where(b => b != 0x00 && b != 0x20).ToArray();
            string efiBiosId = _utf8.GetString(efiBiosIdBytes);
            string[] parts = efiBiosId.Split((char)0x2E);

            if (parts.Length != 5)
            {
                return DefaultEfiBiosIdSection();
            }

            return new EfiBiosIdSection
            {
                ModelPart = parts[0],
                zzPart = parts[1],
                MajorPart = parts[2],
                MinorPart = parts[3],
                DatePart = parts[4],
            };
        }

        private static EfiBiosIdSection DefaultEfiBiosIdSection()
        {
            return new EfiBiosIdSection
            {
                ModelPart = null,
                zzPart = null,
                MajorPart = null,
                MinorPart = null,
                DatePart = null,
            };
        }

        internal static readonly byte[] EFI_BIOS_ID_SIGNATURE =
        {
            0x24, 0x49, 0x42, 0x49,
            0x4F, 0x53, 0x49, 0x24
        };
        #endregion

        #region APFSJumpStart
        internal static ApfsCapable GetIsApfsCapable(byte[] sourceBytes)
        {
            // APFS DXE GUID found
            if (BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.APFS_DXE_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT) != -1)
            {
                return ApfsCapable.Guid;
            }

            // Disable compressed DXE searching is enabled (Maybe I should get rid of this?)
            if (Settings.SettingsGetBool(SettingsBoolType.DisableLzmaFsSearch))
            {
                return ApfsCapable.Unknown;
            }

            // Look for a compressed volume GUID
            int lzmaDxeBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                Guids.LZMA_DXE_VOLUME_IMAGE_GUID,
                (int)Descriptor.BIOS_REGION_BASE,
                (int)Descriptor.BIOS_REGION_LIMIT);

            if (lzmaDxeBase == -1)
            {
                lzmaDxeBase = BinaryUtils.GetBasePosition(
                    sourceBytes,
                    Guids.LZMA_DXE_VOLUME_IMAGE_OLD_GUID,
                    (int)Descriptor.BIOS_REGION_BASE,
                    (int)Descriptor.BIOS_REGION_LIMIT);
            }

            // No compressed DXE volume was found
            if (lzmaDxeBase == -1)
            {
                return ApfsCapable.No;
            }

            // Get bytes containing section length (0x3)
            byte[] dataLengthBytes =
                BinaryUtils.GetBytesBaseLength(
                    sourceBytes, lzmaDxeBase + 20, 3);

            // Convert section length bytes to int24
            int sectionLength =
                BitConvert.ToInt24(dataLengthBytes);

            // Determine the end of the lzma guid section
            int lzmaDxeLimit = lzmaDxeBase + sectionLength;

            // Search for the LZMA signature byte
            lzmaDxeBase = BinaryUtils.GetBasePosition(
                sourceBytes,
                new byte[] { 0x5D },
                lzmaDxeBase + GUID_LENGTH);

            // Decompress the LZMA volume
            byte[] decompressedBytes = LzmaCoder.DecompressBytes(
                BinaryUtils.GetBytesBaseLimit(
                    sourceBytes,
                    lzmaDxeBase,
                    lzmaDxeLimit));

            // There was an issue decompressing the volume (Error saved to './mefit.log')
            if (decompressedBytes == null)
            {
                return ApfsCapable.Unknown;
            }

            // Search the decompressed DXE volume for the APFS DXE GUID
            if (BinaryUtils.GetBasePosition(
                decompressedBytes,
                Guids.APFS_DXE_GUID) == -1)
            {
                // The APFS DXE GUID was not found in the compressed volume
                return ApfsCapable.No;
            }

            // The APFS DXE GUID was present in the compressed volume
            return ApfsCapable.Lzma;
        }
        #endregion

    }
}