// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EFIROM.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mac_EFI_Toolkit.Firmware.EFI
{
    class EFIROM
    {
        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBuffer = null;
        internal static byte[] LzmaDecompressedBuffer = null;
        internal static bool FirmwareLoaded = false;
        internal static string FirmwareVersion = null;
        internal static string ConfigCode = null;
        internal static bool ForceFoundFsys = false;
        internal static string FitVersion = null;
        internal static string MeVersion = null;
        internal static bool ResetVss = false;
        internal static bool ResetSvs = false;
        internal static string NewSerial = null;
        internal static string FmmEmail = null;

        internal static FileInfoStore FileInfoData;
        internal static PdrSection PdrSectionData;
        internal static NvramStore VssPrimary;
        internal static NvramStore VssSecondary;
        internal static NvramStore SvsPrimary;
        internal static NvramStore SvsSecondary;
        internal static EFILock EfiPrimaryLockData;
        internal static EFILock EfiBackupLockData;
        internal static FsysStore FsysStoreData;
        internal static AppleRomInformationSection AppleRomInfoSectionData;
        internal static EfiBiosIdSection EfiBiosIdSectionData;

        internal static ApfsCapable IsApfsCapable = ApfsCapable.Unknown;

        internal static int FsysRegionSize = 0;
        internal static int NvramBase = -1;
        internal static int NvramSize = -1;
        internal static int NvramLimit = -1;

        internal static TimeSpan ParseTime { get; private set; }
        #endregion

        #region Const Members
        internal const int GUID_SIZE = 16;         // 10h
        internal const int RSVD_SIZE = 16;         // 10h
        internal const int HDR_SIZE = 16;          // 10h
        internal const int ZERO_VECTOR_SIZE = 16;  // 10h
        internal const int LITERAL_POS = 2;        // 2h
        internal const int CRC32_SIZE = 4;         // 4h
        #endregion

        #region Private Members
        private static readonly Encoding _utf8Encoding = Encoding.UTF8;
        #endregion

        #region Parse Firmware
        internal static void LoadFirmwareBaseData(byte[] sourcebytes, string filename)
        {
            // Start bench.
            Stopwatch swParseTime = Stopwatch.StartNew();

            // Try processing flash descriptor.
            IFD.ParseRegionData(sourcebytes);

            // Parse file info.
            FileInfoData = FileTools.GetBinaryFileInfo(filename);

            // Parse Platform Data Region.
            PdrSectionData = GetPdrData(sourcebytes);

            // Find the NVRAM base address.
            NvramBase = BinaryTools.GetBaseAddress(sourcebytes, Guids.NVRAM_SECTION_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit) - ZERO_VECTOR_SIZE;

            if (NvramBase < 0 || NvramBase > FileInfoData.Length)
            {
                Logger.WriteLine($"Invalid NVRAM base address: {NvramBase}", LogType.Application);
                NvramBase = -1;
            }

            // Determine size of the NVRAM section.
            // Int32 value is stored at NVRAM_BASE + 0x20 (32 decimal).
            NvramSize = BitConverter.ToInt32(BinaryTools.GetBytesBaseLength(
                sourcebytes, NvramBase + (ZERO_VECTOR_SIZE + GUID_SIZE), 4), 0);

            if (NvramSize < 0 || NvramSize > FileInfoData.Length)
            {
                Logger.WriteLine($"Invalid NVRAM size: {NvramSize}", LogType.Application);
                NvramSize = -1;
            }

            // Parse NVRAM stores.
            GetNvramStores(sourcebytes);

            // Search both NVRAM SVS stores for a Message Authentication Code.
            EfiPrimaryLockData = GetIsEfiLocked(SvsPrimary.StoreBuffer);
            EfiBackupLockData = GetIsEfiLocked(SvsSecondary.StoreBuffer);

            FmmEmail = GetFmmMobilemeEmail();

            // Parse Fsys Store data.
            FsysStoreData = GetFsysStoreData(sourcebytes, false);

            // Try to force find the Fsys store if it wasn't found in the first pass.
            if (FsysStoreData.FsysBytes == null)
            {
                FsysStoreData = GetFsysStoreData(sourcebytes, false, true);

                if (FsysStoreData.FsysBytes != null)
                {
                    ForceFoundFsys = true;

                    Logger.WriteLine($"Force found Fsys Store at {FsysStoreData.FsysBase:X}h. " +
                        $"The image may be misaligned or corrupt ({FileInfoData.FileNameExt}).", LogType.Application
                    );
                }
            }

            // Fetch the Config Code
            ConfigCode = FsysStoreData.HWC != null ? MacTools.GetDeviceConfigCodeLocal(FsysStoreData.HWC) : null;

            // Parse AppleRomSectionInformation region data.
            AppleRomInfoSectionData = GetRomInformationData(sourcebytes);

            // Parse EfiBiosId section data.
            EfiBiosIdSectionData = GetEfiBiosIdSectionData(sourcebytes);

            // Check if the firmware is APFS capable.
            IsApfsCapable = GetIsApfsCapable(LoadedBinaryBuffer);

            // Generate a proper EFI version string.
            FirmwareVersion = MacTools.GetFirmwareVersion();

            // Get the Intel ME Flash Image Tool version.
            FitVersion = IME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.FlashImageTool);

            // Get the Intel ME version.
            MeVersion = IME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.ManagementEngine);

            swParseTime.Stop();
            ParseTime = swParseTime.Elapsed;
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBuffer = null;
            LzmaDecompressedBuffer = null;
            FirmwareLoaded = false;
            FirmwareVersion = null;
            ConfigCode = null;
            ForceFoundFsys = false;
            FitVersion = null;
            MeVersion = null;
            ResetVss = false;
            ResetSvs = false;
            NewSerial = null;
            FmmEmail = null;
            FileInfoData = default;
            PdrSectionData = default;
            VssPrimary = default;
            VssSecondary = default;
            SvsPrimary = default;
            SvsSecondary = default;
            EfiPrimaryLockData = default;
            EfiBackupLockData = default;
            FsysStoreData = default;
            AppleRomInfoSectionData = default;
            EfiBiosIdSectionData = default;
            IsApfsCapable = ApfsCapable.Unknown;

            FsysRegionSize = 0;
            NvramBase = -1;
            NvramSize = -1;
            NvramLimit = -1;
        }

        internal static bool IsValidImage(byte[] sourceBytes)
        {
            int iDxeCoreBase = BinaryTools.GetBaseAddress(sourceBytes, Guids.DXE_CORE, RSVD_SIZE, GUID_SIZE);
            byte[] bDescriptorSignature = BinaryTools.GetBytesBaseLength(sourceBytes, RSVD_SIZE, (int)IFD.IFD_SIG_LENGTH);

            if (!BinaryTools.ByteArraysMatch(bDescriptorSignature, IFD.FlashDecriptorMarker))
            {
                if (iDxeCoreBase == -1)
                {
                    return false;
                }
            }

            byte[][] arrGuids = new[]
            {
                Guids.APPLE_IMMUTABLE_FV_GUID,
                Guids.APPLE_AUTH_FV_GUID,
                Guids.APPLE_IMC_GUID
            };

            // Check if any of the Apple GUIDs are found within the firmware.
            return arrGuids.Any(guid => BinaryTools.GetBaseAddress(sourceBytes, guid, 0, sourceBytes.Length) != -1);
        }
        #endregion 

        #region Platform Data Region
        internal static PdrSection GetPdrData(byte[] sourcebytes)
        {
            // Descriptor mode not set.
            if (!IFD.IsDescriptorMode)
            {
                return DefaultPdrSection();
            }

            // Platform data region is not present.
            if (IFD.PdrBase == 0)
            {
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes.
            int iBoardIdBase = BinaryTools.GetBaseAddress(sourcebytes, EFISigs.PdrBoardIdMarker, (int)IFD.PdrBase, (int)IFD.PdrSize);

            // Board id signature not found.
            if (iBoardIdBase == -1)
            {
                return DefaultPdrSection();
            }

            int iPosition = 5;
            int iLength = 8;

            byte[] bData = BinaryTools.GetBytesBaseLength(sourcebytes, iBoardIdBase + iPosition, iLength);

            if (bData == null)
            {
                return DefaultPdrSection();
            }

            // Return the board id.
            return new PdrSection
            {
                BoardIdBase = iBoardIdBase,
                BoardId = $"Mac-{BitConverter.ToString(bData).Replace("-", "")}"
            };
        }

        private static PdrSection DefaultPdrSection()
        {
            return new PdrSection
            {
                BoardIdBase = -1,
                BoardId = null
            };
        }
        #endregion

        #region NVRAM / EFI Lock
        internal static void GetNvramStores(byte[] sourcebytes)
        {
            if (NvramBase == -1 || NvramSize == -1)
            {
                VssPrimary = DefaultNvramSection();
                VssSecondary = DefaultNvramSection();
                SvsPrimary = DefaultNvramSection();
                SvsSecondary = DefaultNvramSection();

                return;
            }

            NvramLimit = NvramBase + NvramSize - 1;

            Console.WriteLine($"NVRAM - Base: {NvramBase:X}h, Size: {NvramSize:X}h, Limit: {NvramLimit:X}h");

            int iVssPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebytes, EFISigs.VssStoreMarker, NvramBase, NvramLimit);

            // Check if the primary VSS store was found
            if (iVssPrimaryBase != -1)
            {
                VssPrimary = ParseNvramStore(sourcebytes, iVssPrimaryBase, NvramStoreType.Variable);

                // Look for the secondary VSS store only if the primary was found
                int iVssSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebytes, EFISigs.VssStoreMarker, iVssPrimaryBase + HDR_SIZE, NvramLimit);
                VssSecondary = iVssSecondaryBase != -1
                    ? ParseNvramStore(sourcebytes, iVssSecondaryBase, NvramStoreType.Variable)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary VSS store is not found, set both to default
                VssPrimary = DefaultNvramSection();
                VssSecondary = DefaultNvramSection();
            }

            // Repeat similar logic for the SVS store
            int iSvsPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebytes, EFISigs.SvsStoreMarker, NvramBase, NvramLimit);

            // Check if the primary SVS store was found
            if (iSvsPrimaryBase != -1)
            {
                SvsPrimary = ParseNvramStore(sourcebytes, iSvsPrimaryBase, NvramStoreType.Secure);

                // Look for the secondary SVS store only if the primary was found
                int iSvsSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebytes, EFISigs.SvsStoreMarker, iSvsPrimaryBase + HDR_SIZE, NvramLimit);
                SvsSecondary = iSvsSecondaryBase != -1
                    ? ParseNvramStore(sourcebytes, iSvsSecondaryBase, NvramStoreType.Secure)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary SVS store is not found, set both to default
                SvsPrimary = DefaultNvramSection();
                SvsSecondary = DefaultNvramSection();
            }

        }

        internal static NvramStore ParseNvramStore(byte[] buffer, int baseaddress, NvramStoreType storetype)
        {
            int iStoreLength = -1;
            byte bFormat = 0xFF;
            byte bState = 0xFF;
            byte[] bStoreBuffer = null;
            int iBodyBase = -1;
            int iBodyLength = -1;
            bool isEmpty = true;

            byte[] bHdrBuffer = BinaryTools.GetBytesBaseLength(buffer, baseaddress, HDR_SIZE);

            NvramStoreHeader nvrHeader = Helper.DeserializeHeader<NvramStoreHeader>(bHdrBuffer);

            if (nvrHeader.StoreLength != 0xFFFF && nvrHeader.StoreLength != 0)
            {
                iBodyBase = baseaddress + HDR_SIZE;
                iStoreLength = nvrHeader.StoreLength;
                bFormat = nvrHeader.Format;
                bState = nvrHeader.State;

                bStoreBuffer = BinaryTools.GetBytesBaseLength(buffer, baseaddress, iStoreLength);

                if (bStoreBuffer != null)
                {
                    iBodyLength = iStoreLength - HDR_SIZE;

                    byte[] storeBodyBuffer = BinaryTools.GetBytesBaseLength(buffer, iBodyBase, iBodyLength);
                    isEmpty = BinaryTools.IsByteBlockEmpty(storeBodyBuffer);
                }
            }

            Console.WriteLine($"NVRAM Store - Base: {baseaddress:X}h, Size: {iStoreLength:X}h, Type: {storetype}, Empty: {isEmpty}, Format: {bFormat:X}h, State: {bState:X}h");

            return new NvramStore
            {
                StoreType = storetype,
                StoreBase = baseaddress,
                StoreLength = iStoreLength,
                StoreBuffer = bStoreBuffer,
                StoreFormat = bFormat,
                StoreState = bState,
                BodyStart = iBodyBase,
                BodyLength = iBodyLength,
                IsStoreEmpty = isEmpty
            };
        }

        private static NvramStore DefaultNvramSection()
        {
            return new NvramStore
            {
                StoreType = NvramStoreType.None,
                StoreBase = -1,
                StoreLength = -1,
                StoreBuffer = null,
                StoreFormat = 0xFF,
                StoreState = 0xFF,
                BodyStart = -1,
                BodyLength = -1,
                IsStoreEmpty = true
            };
        }

        internal static EFILock GetIsEfiLocked(byte[] storebuffer)
        {
            // NVRAM store is empty.
            if (storebuffer == null)
            {
                return DefaultEfiLockStatus();
            }

            // Search store for Message Authentication Code.
            int iBaseAddress = BinaryTools.GetBaseAddress(storebuffer, EFISigs.EfiLockMarker);

            // No Message Authentication Code was found.
            if (iBaseAddress == -1)
            {
                return DefaultEfiLockStatus();
            }

            // MAC present
            return new EFILock
            {
                LockType = EfiLockType.Locked,
                LockCrcBase = iBaseAddress
            };
        }

        private static EFILock DefaultEfiLockStatus()
        {
            return new EFILock
            {
                LockType = EfiLockType.Unlocked,
                LockCrcBase = -1,
            };
        }
        #endregion

        #region fmm-mobileme-token-FMM
        internal static string GetFmmMobilemeEmail()
        {
            if (VssPrimary.IsStoreEmpty)
            {
                return null; // If the VSS is empty, there will be no token.
            }

            byte[] bBuffer = VssPrimary.StoreBuffer;

            // Find the token in the buffer.
            int iBaseAddress = FindTokenBase(bBuffer, EFISigs.FmmMarker);
            if (iBaseAddress == -1)
            {
                return null; // Token not found.
            }

            int iLimitAddress = FindTokenLimit(bBuffer, iBaseAddress);
            if (iLimitAddress == -1)
            {
                return null; // Limit not found.
            }

            return ExtractEmailFromBuffer(bBuffer, iBaseAddress, iLimitAddress);
        }

        private static int FindTokenBase(byte[] buffer, byte[] token)
        {
            return BinaryTools.GetBaseAddress(buffer, token);
        }

        private static int FindTokenLimit(byte[] buffer, int tokenbase)
        {
            byte[] bLimitBytes = new byte[] { 0xAA, 0x55 };
            return BinaryTools.GetBaseAddress(buffer, bLimitBytes, tokenbase);
        }

        private static string ExtractEmailFromBuffer(byte[] buffer, int tokenbase, int tokenlimit)
        {
            // Step back 1 byte to ensure we're inside the bounds of the NVAR.
            tokenlimit -= 1;

            for (int i = tokenbase; i < tokenlimit;)
            {
                if (IsValidEmailBlock(buffer, i, out string strData))
                {
                    Console.WriteLine($"Email found: {strData}");
                    return strData;
                }

                // Move the pointer to the next block.
                i++;
            }

            return null; // No valid email found.
        }

        private static bool IsValidEmailBlock(byte[] buffer, int index, out string emailstring)
        {
            emailstring = string.Empty;

            // Check for the signature (0x5F, 0x10).
            if (buffer[index] == 0x5F && buffer[index + 1] == 0x10)
            {
                int iSize = buffer[index + 2];
                byte[] bData = new byte[iSize];
                Array.Copy(buffer, index + 3, bData, 0, iSize);

                emailstring = System.Text.Encoding.UTF8.GetString(bData);

                // Check if the data contains '@' and '.' (basic email validation).
                return emailstring.Contains("@") && emailstring.Contains(".");
            }

            return false;
        }
        #endregion

        #region Fsys Store
        // Fsys resides in the NVRAM at either base: 0x20000h, or 0x22000h.
        internal static FsysStore GetFsysStoreData(byte[] sourcebytes, bool isfsysonly, bool forcefind = false)
        {
            // Find the base position of Fsys Store.
            int iBaseAddress = FindFsysBaseAddress(sourcebytes, isfsysonly, forcefind);

            // If Fsys Store base is not found, return default data.
            if (iBaseAddress == -1)
            {
                return DefaultFsysRegion();
            }

            // Retrieve FsysStore bytes.
            byte[] bFsysBuffer = GetFsysStoreBytes(sourcebytes, iBaseAddress);

            // If FsysStore is invalid, return default data.
            if (!IsValidFsysStore(bFsysBuffer))
            {
                return DefaultFsysRegion();
            }

            // Retrieve CRC bytes and calculate CRC values.
            byte[] bCrcData = GetCrcBytes(sourcebytes, iBaseAddress);

            string strCrcString = GetFlippedCrcString(bCrcData);

            uint uiActualCrc = CalculateFsysCrc(bFsysBuffer);

            string strActualCrc = $"{uiActualCrc:X8}";

            // Find and parse various signatures within FsysStore.
            int iSerialBase = FindSignatureAddress(sourcebytes, iBaseAddress, FsysRegionSize, EFISigs.SerialUpperMarker, EFISigs.SerialLowerMarker, EFISigs.SerialPLowerMarker);
            string strSerial = ParseFsysString(sourcebytes, iSerialBase);

            int iHwcBase = FindSignatureAddress(sourcebytes, iBaseAddress, FsysRegionSize, EFISigs.HwcLowerMarker, EFISigs.HwcUpperMarker);
            string strHwc = ParseFsysString(sourcebytes, iHwcBase);

            int iSonBase = FindSignatureAddress(sourcebytes, iBaseAddress, FsysRegionSize, EFISigs.SonLowerMarker, EFISigs.SonUpperMarker);
            string strSon = ParseFsysString(sourcebytes, iSonBase);

            // Trim trailing '/' from SON string if present.
            if (strSon != null && strSon.EndsWith("/"))
            {
                strSon = strSon.TrimEnd('/');
            }

            // Create and return FsysStore object.
            return new FsysStore
            {
                FsysBytes = bFsysBuffer,
                FsysBase = iBaseAddress,
                Serial = strSerial,
                SerialBase = iSerialBase != -1 ? iSerialBase + LITERAL_POS : -1,
                HWC = strHwc,
                HWCBase = iHwcBase != -1 ? iHwcBase + LITERAL_POS : -1,
                SON = strSon,
                CrcString = strCrcString,
                CrcActualString = strActualCrc,
                CrcActual = uiActualCrc
            };
        }

        private static string ParseFsysString(byte[] sourcebytes, int baseaddress)
        {
            // Return null if base position is invalid or data size is zero.
            if (baseaddress == -1 || sourcebytes[baseaddress] == 0)
            {
                return null;
            }

            // Read size of the indicated variable.
            int dataSizeByte = sourcebytes[baseaddress];

            // Return null if data size is invalid.
            if (dataSizeByte == 0)
            {
                return null;
            }

            // Read the variable bytes.
            byte[] bStringData = BinaryTools.GetBytesBaseLength(sourcebytes, baseaddress + LITERAL_POS, dataSizeByte);

            // Return null if bytes are invalid or exceed the data size.
            if (bStringData == null || bStringData.Length != dataSizeByte)
            {
                return null;
            }

            // Return string data.
            return _utf8Encoding.GetString(bStringData);
        }

        private static int FindFsysBaseAddress(byte[] sourcebytes, bool isfsysonly, bool forcefind)
        {
            if (isfsysonly)
            {
                return 0;
            }

            if (forcefind)
            {
                return BinaryTools.GetBaseAddress(sourcebytes, EFISigs.FsysMarker, (int)IFD.BiosBase, (int)IFD.BiosLimit);
            }

            if (NvramBase == -1)
            {
                return -1;
            }

            if (NvramSize == -1)
            {
                return -1;
            }

            return BinaryTools.GetBaseAddress(sourcebytes, EFISigs.FsysMarker, NvramBase, NvramSize);
        }

        private static bool IsValidFsysStore(byte[] storebytes)
        {
            return storebytes != null && storebytes.Length == FsysRegionSize;
        }

        private static string GetFlippedCrcString(byte[] crcbytes)
        {
            byte[] bData = crcbytes.Reverse().ToArray();
            return BitConverter.ToString(bData).Replace("-", "");
        }

        private static uint CalculateFsysCrc(byte[] storebytes)
        {
            return MacTools.GetUintFsysCrc32(storebytes);
        }

        private static int FindSignatureAddress(byte[] sourcebytes, int baseaddress, int maxsearchlength, params byte[][] signatures)
        {
            foreach (byte[] signature in signatures)
            {
                int iBaseAddress = BinaryTools.GetBaseAddress(sourcebytes, signature, baseaddress, maxsearchlength);

                if (iBaseAddress != -1)
                {
                    return iBaseAddress + signature.Length;
                }
            }

            return -1;
        }

        private static byte[] GetFsysStoreBytes(byte[] sourcebytes, int fsysbaseaddress)
        {
            // Get Fsys Store size bytes - fsys base + 0x09, length 2 bytes (int16).
            byte[] bSize = BinaryTools.GetBytesBaseLength(sourcebytes, fsysbaseaddress + 9, 2);

            // Convert size to int16 value.
            FsysRegionSize = BitConverter.ToInt16(bSize, 0);

            // Min Fsys rgn size.
            if (FsysRegionSize < 2048)
            {
                Logger.WriteLine($"Fsys Store size was less than the min expected size: {FsysRegionSize}", LogType.Application);

                return null;
            }

            return BinaryTools.GetBytesBaseLength(sourcebytes, fsysbaseaddress, FsysRegionSize);
        }

        private static byte[] GetCrcBytes(byte[] sourcebytes, int fsysbaseaddress)
        {
            return BinaryTools.GetBytesBaseLength(sourcebytes, fsysbaseaddress + (FsysRegionSize - CRC32_SIZE), CRC32_SIZE);
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
                CrcActualString = null,
                CrcActual = 0xFFFFFFF
            };
        }
        #endregion

        #region Apple ROM Information Section
        internal static AppleRomInformationSection GetRomInformationData(byte[] sourcebytes)
        {
            // Define constants for index and termination bytes.
            const byte bIndex = 0x20;
            const byte bTermination = 0x0A;

            // Initialize signature-data dictionary.
            Dictionary<byte[], string> dictSectionEntires = new Dictionary<byte[], string>
            {
                { EFISigs.BiosIdMarker, null },
                { EFISigs.ModelMarker, null },
                { EFISigs.EfiVersionMarker, null },
                { EFISigs.BuiltByMarker, null },
                { EFISigs.DateMarker, null },
                { EFISigs.RevisionMarker, null },
                { EFISigs.RomVersionMarker, null },
                { EFISigs.BuildCaveIdMarker, null },
                { EFISigs.BuildTypeMarker, null },
                { EFISigs.CompilerMarker, null }
            };

            // Find all GUID locations.
            List<int> lstBaseAddresses = GetRomSectionBaseAddresses(sourcebytes);

            // Return default if no AppleRomInformation GUID was found.
            if (lstBaseAddresses.Count == 0)
            {
                return DefaultRomInformationBase();
            }

            // Process each AppleRomInformation section.
            foreach (int iBaseAddress in lstBaseAddresses)
            {
                byte[] bSectionBuffer = ExtractSectionBytes(sourcebytes, iBaseAddress);

                if (bSectionBuffer == null)
                {
                    return DefaultRomInformationBase();
                }

                // Extract information based on each signature.
                foreach (byte[] bSignature in dictSectionEntires.Keys.ToList())
                {
                    int iDataBaseAddress = BinaryTools.GetBaseAddress(bSectionBuffer, bSignature);

                    if (iDataBaseAddress != -1)
                    {
                        int iKeyLength = bSignature.Length;

                        byte[] bValue = BinaryTools.GetBytesDelimited(bSectionBuffer, iDataBaseAddress + iKeyLength, bIndex, bTermination);

                        if (bValue != null)
                        {
                            dictSectionEntires[bSignature] = _utf8Encoding.GetString(bValue);
                        }
                    }
                }

                return new AppleRomInformationSection
                {
                    SectionExists = true,
                    SectionBytes = bSectionBuffer,
                    SectionBase = iBaseAddress,
                    BiosId = dictSectionEntires[EFISigs.BiosIdMarker],
                    Model = dictSectionEntires[EFISigs.ModelMarker],
                    EfiVersion = dictSectionEntires[EFISigs.EfiVersionMarker],
                    BuiltBy = dictSectionEntires[EFISigs.BuiltByMarker],
                    DateStamp = dictSectionEntires[EFISigs.DateMarker],
                    Revision = dictSectionEntires[EFISigs.RevisionMarker],
                    RomVersion = dictSectionEntires[EFISigs.RomVersionMarker],
                    BuildcaveId = dictSectionEntires[EFISigs.BuildCaveIdMarker],
                    BuildType = dictSectionEntires[EFISigs.BuildTypeMarker],
                    Compiler = dictSectionEntires[EFISigs.CompilerMarker]
                };
            }

            // Return default if no valid section was processed.
            return DefaultRomInformationBase();

            // Local function to locate all AppleRomInformation section GUIDs.
            List<int> GetRomSectionBaseAddresses(byte[] bytes)
            {
                List<int> lstAddresses = new List<int>();
                int iAddress = BinaryTools.GetBaseAddress(bytes, Guids.APPLE_ROM_INFO_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit);

                while (iAddress != -1)
                {
                    lstAddresses.Add(iAddress);
                    iAddress = BinaryTools.GetBaseAddress(bytes, Guids.APPLE_ROM_INFO_GUID, iAddress + 1, (int)IFD.BiosLimit);
                }

                return lstAddresses;
            }

            // Local function to extract the section bytes.
            byte[] ExtractSectionBytes(byte[] bytes, int baseaddress)
            {
                int iHdrLength = 24; // 18h
                int iDataLength = 2; // 2h

                byte[] sectionSizeBytes = BinaryTools.GetBytesBaseLength(bytes, baseaddress + iHdrLength, iDataLength);

                int iSize = BitConverter.ToInt16(sectionSizeBytes, 0);

                return iSize > 6 ? BinaryTools.GetBytesBaseLength(bytes, baseaddress + iHdrLength, iSize) : null;
            }
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
        #endregion

        #region EFI BIOS ID Section
        internal static EfiBiosIdSection GetEfiBiosIdSectionData(byte[] sourceBytes)
        {
            int iBaseAddress = BinaryTools.GetBaseAddress(sourceBytes, Guids.EFI_BIOS_ID_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit);

            if (iBaseAddress == -1)
            {
                return DefaultEfiBiosIdSection();
            }


            int iEfiBiosIdBase = BinaryTools.GetBaseAddress(sourceBytes, EFISigs.EfiBiosIdMarker, iBaseAddress);

            if (iEfiBiosIdBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int iEfiBiosIdLimit = BinaryTools.GetBaseAddress(sourceBytes, new byte[] { 0x00, 0x00, 0x00 }, iEfiBiosIdBase);

            byte[] bEfiBiosIdData = BinaryTools.GetBytesBaseLimit(sourceBytes, iEfiBiosIdBase + EFISigs.EfiBiosIdMarker.Length, iEfiBiosIdLimit);

            if (bEfiBiosIdData == null)
            {
                return DefaultEfiBiosIdSection();
            }

            bEfiBiosIdData = bEfiBiosIdData.Where(b => b != 0x00 && b != 0x20).ToArray();
            string strEfiBiosId = _utf8Encoding.GetString(bEfiBiosIdData);
            string[] arrEfiBiosIdParts = strEfiBiosId.Split((char)0x2E);

            if (arrEfiBiosIdParts.Length != 5)
            {
                return DefaultEfiBiosIdSection();
            }

            return new EfiBiosIdSection
            {
                ModelPart = arrEfiBiosIdParts[0],
                ZzPart = arrEfiBiosIdParts[1],
                MajorPart = arrEfiBiosIdParts[2],
                MinorPart = arrEfiBiosIdParts[3],
                DatePart = arrEfiBiosIdParts[4],
            };
        }

        private static EfiBiosIdSection DefaultEfiBiosIdSection()
        {
            return new EfiBiosIdSection
            {
                ModelPart = null,
                ZzPart = null,
                MajorPart = null,
                MinorPart = null,
                DatePart = null,
            };
        }
        #endregion

        #region APFSJumpStart
        internal static ApfsCapable GetIsApfsCapable(byte[] sourcebytes)
        {
            // APFS DXE GUID found.
            if (BinaryTools.GetBaseAddress(
                sourcebytes, Guids.APFS_DXE_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit) != -1)
            {
                return ApfsCapable.Yes;
            }

            // Look for a compressed volume GUID.
            int iLzmaDxeBase = BinaryTools.GetBaseAddress(
                sourcebytes, Guids.LZMA_DXE_VOLUME_IMAGE_1_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit);

            if (iLzmaDxeBase == -1)
            {
                iLzmaDxeBase = BinaryTools.GetBaseAddress(
                    sourcebytes, Guids.LZMA_DXE_VOLUME_IMAGE_0_GUID, (int)IFD.BiosBase, (int)IFD.BiosLimit);
            }

            // No compressed DXE volume was found.
            if (iLzmaDxeBase == -1)
            {
                return ApfsCapable.No;
            }

            // Get bytes containing section length (0x3).
            byte[] bSectionLength = BinaryTools.GetBytesBaseLength(sourcebytes, iLzmaDxeBase + 20, 3);

            // Convert section length bytes to int24.
            int iSectionLength = Helper.ToInt24(bSectionLength);

            // Determine the end of the lzma guid section.
            int iLzmaDxeLimit = iLzmaDxeBase + iSectionLength;

            // Search for the LZMA signature byte.
            iLzmaDxeBase = BinaryTools.GetBaseAddress(sourcebytes, new byte[] { 0x5D }, iLzmaDxeBase + GUID_SIZE);

            // Decompress the LZMA volume.
            byte[] dDecompressed = LzmaCoder.DecompressBytes(BinaryTools.GetBytesBaseLimit(sourcebytes, iLzmaDxeBase, iLzmaDxeLimit));

            // There was an issue decompressing the volume (Error saved to './mefit.log').
            if (dDecompressed == null)
            {
                return ApfsCapable.Unknown;
            }

            // May as well store the archive buffer here.
            LzmaDecompressedBuffer = dDecompressed;

            // Search the decompressed volume for the APFS DXE GUID.
            if (BinaryTools.GetBaseAddress(dDecompressed, Guids.APFS_DXE_GUID) == -1)
            {
                // The APFS DXE GUID was not found in the compressed volume.
                return ApfsCapable.No;
            }

            // The APFS DXE GUID was present in the compressed volume.
            return ApfsCapable.Yes;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Patches the given Fsys store byte array with a new CRC value.
        /// </summary>
        /// <param name="fsysbuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched.</param>
        /// <returns>The patched Fsys store byte array.</returns>
        internal static byte[] PatchFsysCrc(byte[] fsysbuffer, uint newcrc)
        {
            // Convert the new CRC value to bytes
            byte[] bCrc = BitConverter.GetBytes(newcrc);

            // Write the new bytes back to the Fsys store at the appropriate base
            BinaryTools.OverwriteBytesAtBase(fsysbuffer, FsysRegionSize - CRC32_SIZE, bCrc);

            // Return the patched data
            return fsysbuffer;
        }

        /// <summary>
        /// Patches a binaries Fsys store with the correct crc value.
        /// </summary>
        /// <param name="sourcebuffer">The byte array representing the source binary file.</param>
        /// <param name="fsysbase">The base of the Fsys store within the binary file.</param>
        /// <param name="fsysbuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched in the Fsys store.</param>
        /// <returns>The patched file byte array, or null if the new calculated crc does not match the crc in the Fsys store.</returns>
        internal static byte[] MakeFsysCrcPatchedBinary(byte[] sourcebuffer, int fsysbase, byte[] fsysbuffer, uint newcrc)
        {
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            // Create a new byte array to hold the patched binary.
            byte[] bPatchedSource = new byte[sourcebuffer.Length];

            Array.Copy(sourcebuffer, bPatchedSource, sourcebuffer.Length);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_PATCH);

            // Patch the Fsys store crc.
            byte[] bPatchedFsys = PatchFsysCrc(fsysbuffer, newcrc);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_TO_FW);

            // Overwrite the loaded Fsys crc32 with the newly calculated crc32.
            BinaryTools.OverwriteBytesAtBase(bPatchedSource, fsysbase, bPatchedFsys);

            // Load the Fsys store from the new binary.
            FsysStore fssNewBinary = GetFsysStoreData(bPatchedSource, false);

            // Compare the new checksums.
            if (fssNewBinary.CrcString != fssNewBinary.CrcActualString)
            {
                Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_FAIL);

                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_SUCCESS);

            return bPatchedSource;
        }

        /// <summary>
        /// Invalidates an SVS store Message Authentication Code, removing EFI Lock.
        /// </summary>
        /// <param name="svsstorebuffer">The SVS store to unlock.</param>
        /// <param name="lockbase">The Message Authentication Code base</param>
        internal static byte[] PatchSvsStoreMac(byte[] svsstorebuffer, int lockbase)
        {
            // Some sanity checks.
            if (svsstorebuffer == null || svsstorebuffer.Length < 16)
            {
                return null;
            }

            // Write 0xFh length zeros over the MAC CRC from lockBase
            BinaryTools.OverwriteBytesAtBase(svsstorebuffer, lockbase, new byte[0x0F]);

            // Returned the unlocked store
            return svsstorebuffer;
        }
        #endregion
    }
}