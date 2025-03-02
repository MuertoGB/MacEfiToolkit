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

namespace Mac_EFI_Toolkit.Firmware.EFIROM
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
        internal static void LoadFirmwareBaseData(byte[] sourcebuffer, string filename)
        {
            // Start bench.
            Stopwatch swParseTime = Stopwatch.StartNew();

            // Try processing flash descriptor.
            FlashDescriptor.ParseRegionData(sourcebuffer);

            // Parse file info.
            FileInfoData = FileTools.GetBinaryFileInfo(filename);

            // Parse Platform Data Region.
            PdrSectionData = GetPdrData(sourcebuffer);

            // Find the NVRAM base address.
            NvramBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.NvramSectionGuid, (int)FlashDescriptor.BiosBase, (int)FlashDescriptor.BiosLimit) - ZERO_VECTOR_SIZE;

            if (NvramBase < 0 || NvramBase > FileInfoData.Length)
            {
                Logger.WriteLine($"Invalid NVRAM base address: {NvramBase}", LogType.Application);
                NvramBase = -1;
            }

            // Determine size of the NVRAM section.
            // Int32 value is stored at NVRAM_BASE + 0x20 (32 decimal).
            NvramSize = BitConverter.ToInt32(BinaryTools.GetBytesBaseLength(
                sourcebuffer, NvramBase + (ZERO_VECTOR_SIZE + GUID_SIZE), 4), 0);

            if (NvramSize < 0 || NvramSize > FileInfoData.Length)
            {
                Logger.WriteLine($"Invalid NVRAM size: {NvramSize}", LogType.Application);
                NvramSize = -1;
            }

            // Parse NVRAM stores.
            GetNvramStores(sourcebuffer);

            // Search both NVRAM SVS stores for a Message Authentication Code.
            EfiPrimaryLockData = GetIsEfiLocked(SvsPrimary.StoreBuffer);
            EfiBackupLockData = GetIsEfiLocked(SvsSecondary.StoreBuffer);

            FmmEmail = GetFmmMobilemeEmail();

            // Parse Fsys Store data.
            FsysStoreData = GetFsysStoreData(sourcebuffer, false);

            // Try to force find the Fsys store if it wasn't found in the first pass.
            if (FsysStoreData.FsysBytes == null)
            {
                FsysStoreData = GetFsysStoreData(sourcebuffer, false, true);

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
            AppleRomInfoSectionData = GetRomInformationData(sourcebuffer);

            // Parse EfiBiosId section data.
            EfiBiosIdSectionData = GetEfiBiosIdSectionData(sourcebuffer);

            // Check if the firmware is APFS capable.
            IsApfsCapable = GetIsApfsCapable(LoadedBinaryBuffer);

            // Generate a proper EFI version string.
            FirmwareVersion = MacTools.GetFirmwareVersion();

            // Get the Intel ME Flash Image Tool version.
            FitVersion = IntelME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.FlashImageTool);

            // Get the Intel ME version.
            MeVersion = IntelME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.ManagementEngine);

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

        internal static bool IsValidImage(byte[] sourcebuffer)
        {
            byte[] bDescriptorSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, RSVD_SIZE, (int)FlashDescriptor.IFD_SIG_LENGTH);

            if (!BinaryTools.ByteArraysMatch(bDescriptorSignature, FlashDescriptor.FlashDecriptorMarker))
            {
                int iDxeCoreBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.EfiFirmwareFsGuid, RSVD_SIZE, GUID_SIZE);

                if (iDxeCoreBase == -1)
                {
                    return false;
                }
            }

            byte[][] arrGuids = new[]
            {
                Guids.AppleImmutableFvGuid,
                Guids.AppleAuthFvGuid,
                Guids.AppleImcGuid
            };

            // Check if any of the Apple GUIDs are found within the firmware.
            if (arrGuids.Any(guid => BinaryTools.GetBaseAddress(sourcebuffer, guid, 0, sourcebuffer.Length) != -1))
            {
                return true;
            }

            // Check for old 2MB image.
            byte[] bFvMainSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, RSVD_SIZE, GUID_SIZE);

            if (BinaryTools.ByteArraysMatch(bFvMainSignature, Guids.FvMainGuid))
            {
                int iSmcDxeBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.AppleSmcDxeGuid);

                if (iSmcDxeBase != -1)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion 

        #region Platform Data Region
        internal static PdrSection GetPdrData(byte[] sourcebuffer)
        {
            // Descriptor mode not set.
            if (!FlashDescriptor.IsDescriptorMode)
            {
                return DefaultPdrSection();
            }

            // Platform data region is not present.
            if (FlashDescriptor.PdrBase == 0)
            {
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes.
            int iBoardIdBase = BinaryTools.GetBaseAddress(sourcebuffer, EFISigs.PdrBoardIdMarker, (int)FlashDescriptor.PdrBase, (int)FlashDescriptor.PdrSize);

            // Board id signature not found.
            if (iBoardIdBase == -1)
            {
                return DefaultPdrSection();
            }

            int iPosition = 5;
            int iLength = 8;

            byte[] bDataBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, iBoardIdBase + iPosition, iLength);

            if (bDataBuffer == null)
            {
                return DefaultPdrSection();
            }

            // Return the board id.
            return new PdrSection
            {
                BoardIdBase = iBoardIdBase,
                BoardId = $"Mac-{BitConverter.ToString(bDataBuffer).Replace("-", "")}"
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
        internal static void GetNvramStores(byte[] sourcebuffer)
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

            int iVssPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, EFISigs.VssStoreMarker, NvramBase, NvramLimit);

            // Check if the primary VSS store was found
            if (iVssPrimaryBase != -1)
            {
                VssPrimary = ParseNvramStore(sourcebuffer, iVssPrimaryBase, NvramStoreType.Variable);

                // Look for the secondary VSS store only if the primary was found
                int iVssSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, EFISigs.VssStoreMarker, iVssPrimaryBase + HDR_SIZE, NvramLimit);

                VssSecondary = iVssSecondaryBase != -1
                    ? ParseNvramStore(sourcebuffer, iVssSecondaryBase, NvramStoreType.Variable)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary VSS store is not found, set both to default
                VssPrimary = DefaultNvramSection();
                VssSecondary = DefaultNvramSection();
            }

            // Repeat similar logic for the SVS store
            int iSvsPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, EFISigs.SvsStoreMarker, NvramBase, NvramLimit);

            // Check if the primary SVS store was found
            if (iSvsPrimaryBase != -1)
            {
                SvsPrimary = ParseNvramStore(sourcebuffer, iSvsPrimaryBase, NvramStoreType.Secure);

                // Look for the secondary SVS store only if the primary was found
                int iSvsSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, EFISigs.SvsStoreMarker, iSvsPrimaryBase + HDR_SIZE, NvramLimit);

                SvsSecondary = iSvsSecondaryBase != -1
                    ? ParseNvramStore(sourcebuffer, iSvsSecondaryBase, NvramStoreType.Secure)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary SVS store is not found, set both to default
                SvsPrimary = DefaultNvramSection();
                SvsSecondary = DefaultNvramSection();
            }

        }

        internal static NvramStore ParseNvramStore(byte[] sourcebuffer, int baseposition, NvramStoreType nvramstoretype)
        {
            int iStoreLength = -1;
            byte bFormat = 0xFF;
            byte bState = 0xFF;
            byte[] bStoreBuffer = null;
            int iBodyBase = -1;
            int iBodyLength = -1;
            bool isEmpty = true;

            byte[] bHdrBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, HDR_SIZE);

            NvramStoreHeader nvrHeader = Helper.DeserializeHeader<NvramStoreHeader>(bHdrBuffer);

            if (nvrHeader.StoreLength != 0xFFFF && nvrHeader.StoreLength != 0)
            {
                iBodyBase = baseposition + HDR_SIZE;
                iStoreLength = nvrHeader.StoreLength;
                bFormat = nvrHeader.Format;
                bState = nvrHeader.State;

                bStoreBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, iStoreLength);

                if (bStoreBuffer != null)
                {
                    iBodyLength = iStoreLength - HDR_SIZE;

                    byte[] bBodyBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, iBodyBase, iBodyLength);
                    isEmpty = BinaryTools.IsByteBlockEmpty(bBodyBuffer);
                }
            }

            Console.WriteLine($"NVRAM Store - Base: {baseposition:X}h, Size: {iStoreLength:X}h, Type: {nvramstoretype}, Empty: {isEmpty}, Format: {bFormat:X}h, State: {bState:X}h");

            return new NvramStore
            {
                StoreType = nvramstoretype,
                StoreBase = baseposition,
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

        internal static EFILock GetIsEfiLocked(byte[] sourcebuffer)
        {
            // NVRAM store is empty.
            if (sourcebuffer == null)
            {
                return DefaultEfiLockStatus();
            }

            // Search store for Message Authentication Code.
            int iBaseAddress = BinaryTools.GetBaseAddress(sourcebuffer, EFISigs.EfiLockMarker);

            // No Message Authentication Code was found.
            if (iBaseAddress == -1)
            {
                return DefaultEfiLockStatus();
            }

            // MAC present
            return new EFILock
            {
                LockType = EfiLockType.Locked,
                LockBase = iBaseAddress
            };
        }

        private static EFILock DefaultEfiLockStatus()
        {
            return new EFILock
            {
                LockType = EfiLockType.Unlocked,
                LockBase = -1,
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

            byte[] bVssBuffer = VssPrimary.StoreBuffer;

            // Find the token in the buffer.
            int iBaseAddress = FindTokenBase(bVssBuffer, EFISigs.FmmMarker);

            if (iBaseAddress == -1)
            {
                return null; // Token not found.
            }

            int iLimitAddress = FindTokenLimit(bVssBuffer, iBaseAddress);

            if (iLimitAddress == -1)
            {
                return null; // Limit not found.
            }

            return ExtractEmailFromBuffer(bVssBuffer, iBaseAddress, iLimitAddress);
        }

        private static int FindTokenBase(byte[] sourcebuffer, byte[] token)
        {
            return BinaryTools.GetBaseAddress(sourcebuffer, token);
        }

        private static int FindTokenLimit(byte[] sourcebuffer, int tokenbase)
        {
            byte[] bLimitBytes = new byte[] { 0xAA, 0x55 };
            return BinaryTools.GetBaseAddress(sourcebuffer, bLimitBytes, tokenbase);
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

        private static bool IsValidEmailBlock(byte[] sourcebuffer, int index, out string emailstring)
        {
            emailstring = string.Empty;

            // Check for the signature (0x5F, 0x10).
            if (sourcebuffer[index] == 0x5F && sourcebuffer[index + 1] == 0x10)
            {
                int iSize = sourcebuffer[index + 2];
                byte[] bData = new byte[iSize];
                Array.Copy(sourcebuffer, index + 3, bData, 0, iSize);

                emailstring = System.Text.Encoding.UTF8.GetString(bData);

                // Check if the data contains '@' and '.' (basic email validation).
                return emailstring.Contains("@") && emailstring.Contains(".");
            }

            return false;
        }
        #endregion

        #region Fsys Store
        // Fsys resides in the NVRAM at either base: 0x20000h, or 0x22000h.
        internal static FsysStore GetFsysStoreData(byte[] sourcebuffer, bool isfsysonly, bool forcefind = false)
        {
            // Find the base position of Fsys Store.
            int iFsysBase = FindFsysBaseAddress(sourcebuffer, isfsysonly, forcefind);

            // If Fsys Store base is not found, return default data.
            if (iFsysBase == -1)
            {
                return DefaultFsysRegion();
            }

            // Retrieve FsysStore bytes.
            byte[] bFsysBuffer = GetFsysStoreBytes(sourcebuffer, iFsysBase);

            // If FsysStore is invalid, return default data.
            if (!IsValidFsysStore(bFsysBuffer))
            {
                return DefaultFsysRegion();
            }

            // Retrieve CRC bytes and calculate CRC values.
            byte[] bCrcData = GetCrcBytes(sourcebuffer, iFsysBase);
            string strCrcString = GetFlippedCrcString(bCrcData);
            uint uiActualCrc = CalculateFsysCrc(bFsysBuffer);
            string strActualCrc = $"{uiActualCrc:X8}";

            // Find and parse various signatures within FsysStore.
            int iSerialBase = FindSignatureAddress(sourcebuffer, iFsysBase, FsysRegionSize, EFISigs.SerialUpperMarker, EFISigs.SerialLowerMarker, EFISigs.SerialPLowerMarker);
            string strSerial = ParseFsysString(sourcebuffer, iSerialBase);

            int iHwcBase = FindSignatureAddress(sourcebuffer, iFsysBase, FsysRegionSize, EFISigs.HwcLowerMarker, EFISigs.HwcUpperMarker);
            string strHwc = ParseFsysString(sourcebuffer, iHwcBase);

            int iSonBase = FindSignatureAddress(sourcebuffer, iFsysBase, FsysRegionSize, EFISigs.SonLowerMarker, EFISigs.SonUpperMarker);
            string strSon = ParseFsysString(sourcebuffer, iSonBase);

            // Trim trailing '/' from SON string if present.
            if (strSon != null && strSon.EndsWith("/"))
            {
                strSon = strSon.TrimEnd('/');
            }

            // Create and return FsysStore object.
            return new FsysStore
            {
                FsysBytes = bFsysBuffer,
                FsysBase = iFsysBase,
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

        private static string ParseFsysString(byte[] sourcebuffer, int baseposition)
        {
            // Return null if base position is invalid or data size is zero.
            if (baseposition == -1 || sourcebuffer[baseposition] == 0)
            {
                return null;
            }

            // Read size of the indicated variable.
            int iDataSize = sourcebuffer[baseposition];

            // Return null if data size is invalid.
            if (iDataSize == 0)
            {
                return null;
            }

            // Read the variable bytes.
            byte[] bStringData = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + LITERAL_POS, iDataSize);

            // Return null if bytes are invalid or exceed the data size.
            if (bStringData == null || bStringData.Length != iDataSize)
            {
                return null;
            }

            // Return string data.
            return _utf8Encoding.GetString(bStringData);
        }

        private static int FindFsysBaseAddress(byte[] sourcebuffer, bool isfsysonly, bool forcefind)
        {
            if (isfsysonly)
            {
                return 0;
            }

            if (forcefind)
            {
                return BinaryTools.GetBaseAddress(sourcebuffer, EFISigs.FsysMarker, (int)FlashDescriptor.BiosBase, (int)FlashDescriptor.BiosLimit);
            }

            if (NvramBase == -1)
            {
                return -1;
            }

            if (NvramSize == -1)
            {
                return -1;
            }

            return BinaryTools.GetBaseAddress(sourcebuffer, EFISigs.FsysMarker, NvramBase, NvramSize);
        }

        private static bool IsValidFsysStore(byte[] sourcebuffer)
        {
            return sourcebuffer != null && sourcebuffer.Length == FsysRegionSize;
        }

        private static string GetFlippedCrcString(byte[] sourcebuffer)
        {
            byte[] bData = sourcebuffer.Reverse().ToArray();
            return BitConverter.ToString(bData).Replace("-", "");
        }

        private static uint CalculateFsysCrc(byte[] sourcebuffer)
        {
            return MacTools.GetUintFsysCrc32(sourcebuffer);
        }

        private static int FindSignatureAddress(byte[] sourcebuffer, int baseposition, int maxsearchlength, params byte[][] signatures)
        {
            foreach (byte[] bSignature in signatures)
            {
                int iSignatureBase = BinaryTools.GetBaseAddress(sourcebuffer, bSignature, baseposition, maxsearchlength);

                if (iSignatureBase != -1)
                {
                    return iSignatureBase + bSignature.Length;
                }
            }

            return -1;
        }

        private static byte[] GetFsysStoreBytes(byte[] sourcebuffer, int baseposition)
        {
            // Get Fsys Store size bytes - fsys base + 0x09, length 2 bytes (int16).
            byte[] bSize = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + 9, 2);

            // Convert size to int16 value.
            FsysRegionSize = BitConverter.ToInt16(bSize, 0);

            // Min Fsys rgn size.
            if (FsysRegionSize < 2048)
            {
                Logger.WriteLine($"Fsys Store size was less than the min expected size: {FsysRegionSize}", LogType.Application);

                return null;
            }

            return BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, FsysRegionSize);
        }

        private static byte[] GetCrcBytes(byte[] sourcebuffer, int baseposition)
        {
            return BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + (FsysRegionSize - CRC32_SIZE), CRC32_SIZE);
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
        internal static AppleRomInformationSection GetRomInformationData(byte[] sourcebuffer)
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
            List<int> lstBaseAddresses = GetRomSectionBaseAddresses(sourcebuffer);

            // Return default if no AppleRomInformation GUID was found.
            if (lstBaseAddresses.Count == 0)
            {
                return DefaultRomInformationBase();
            }

            // Process each AppleRomInformation section.
            foreach (int iBaseAddress in lstBaseAddresses)
            {
                byte[] bSectionBuffer = ExtractSectionBytes(sourcebuffer, iBaseAddress);

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
                int iRomInfoBase = BinaryTools.GetBaseAddress(bytes, Guids.AppleRomInformationGuid, (int)FlashDescriptor.BiosBase, (int)FlashDescriptor.BiosLimit);

                while (iRomInfoBase != -1)
                {
                    lstAddresses.Add(iRomInfoBase);
                    iRomInfoBase = BinaryTools.GetBaseAddress(bytes, Guids.AppleRomInformationGuid, iRomInfoBase + 1, (int)FlashDescriptor.BiosLimit);
                }

                return lstAddresses;
            }

            // Local function to extract the section bytes.
            byte[] ExtractSectionBytes(byte[] sectionbuffer, int baseposition)
            {
                int iHdrLength = 24; // 18h
                int iDataLength = 2; // 2h

                byte[] bSectionSize = BinaryTools.GetBytesBaseLength(sectionbuffer, baseposition + iHdrLength, iDataLength);

                int iSectionSize = BitConverter.ToInt16(bSectionSize, 0);

                return iSectionSize > 6 ? BinaryTools.GetBytesBaseLength(sectionbuffer, baseposition + iHdrLength, iSectionSize) : null;
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
        internal static EfiBiosIdSection GetEfiBiosIdSectionData(byte[] sourcebuffer)
        {
            int iGuidBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.EfiBiosIdGuid, (int)FlashDescriptor.BiosBase, (int)FlashDescriptor.BiosLimit);

            if (iGuidBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int iMarkerBase = BinaryTools.GetBaseAddress(sourcebuffer, EFISigs.EfiBiosIdMarker, iGuidBase);

            if (iMarkerBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int iMarkerLimit = BinaryTools.GetBaseAddress(sourcebuffer, new byte[] { 0x00, 0x00, 0x00 }, iMarkerBase);

            if (iMarkerLimit == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            byte[] bDataBuffer = BinaryTools.GetBytesBaseLimit(sourcebuffer, iMarkerBase + EFISigs.EfiBiosIdMarker.Length, iMarkerLimit);

            if (bDataBuffer == null)
            {
                return DefaultEfiBiosIdSection();
            }

            bDataBuffer = bDataBuffer.Where(b => b != 0x00 && b != 0x20).ToArray();
            string strEfiBiosId = _utf8Encoding.GetString(bDataBuffer);
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
        internal static ApfsCapable GetIsApfsCapable(byte[] sourcebuffer)
        {
            // APFS DXE GUID found.
            if (BinaryTools.GetBaseAddress(
                sourcebuffer, Guids.ApfsDxeGuid, (int)FlashDescriptor.BiosBase, (int)FlashDescriptor.BiosLimit) != -1)
            {
                Console.Write(" > Standard LZMA GUID found");
                return ApfsCapable.Yes;
            }

            Console.WriteLine(" > Looking for a compressed LZMA DXE GUID");

            // Look for a compressed volume GUID.
            int iLzmaBase = FindLzmaBase(
                sourcebuffer,
                new[] { Guids.DxeCoreLzmaVolumeGuid, Guids.DxeMainLzmaVolumeGuid },
                (int)FlashDescriptor.BiosBase,
                (int)FlashDescriptor.BiosLimit
            );

            // No compressed DXE volume was found.
            if (iLzmaBase == -1)
            {
                Console.WriteLine(" > No compressed LZMA DXE GUID was found");
                return ApfsCapable.No;
            }

            // Get bytes containing section length (0x3).
            byte[] bLength = BinaryTools.GetBytesBaseLength(sourcebuffer, iLzmaBase + 20, 3);

            // Convert section length bytes to int24.
            int iLength = Helper.ToInt24(bLength);

            // Determine the end of the LZMA GUID section.
            int iLzmaLimit = iLzmaBase + iLength;

            Console.WriteLine(" > Looking for a valid LZMA header");

            // Search for a valid LZMA header (with 3 attempts).
            int iLzmaSignatureBase = FindValidLzmaHeader(sourcebuffer, iLzmaBase, iLzmaLimit, maxattempts: 3);

            if (iLzmaSignatureBase == -1)
            {
                Console.WriteLine(" > Valid LZMA header not found");
                // Couldn't locate a valid LZMA header.
                return ApfsCapable.No;
            }

            Console.WriteLine(" > Decompressing LZMA DXE archive");

            // Decompress the LZMA volume.
            byte[] dDecompressed = LzmaCoder.DecompressBytes(
                BinaryTools.GetBytesBaseLimit(sourcebuffer, iLzmaSignatureBase, iLzmaLimit));

            // There was an issue decompressing the volume (Error saved to './mefit.log').
            if (dDecompressed == null)
            {
                Console.WriteLine(" > bDecompressed was empty.");
                return ApfsCapable.Unknown;
            }

            // May as well store the archive buffer here.
            LzmaDecompressedBuffer = dDecompressed;

            // Search the decompressed volume for the APFS DXE GUID.
            if (BinaryTools.GetBaseAddress(dDecompressed, Guids.ApfsDxeGuid) == -1)
            {
                Console.WriteLine(" > No APFS GUID found in decompressed archive");
                // The APFS DXE GUID was not found in the compressed volume.
                return ApfsCapable.No;
            }

            Console.WriteLine(" > An APFS GUID was found in the decompressed archive");
            // The APFS DXE GUID was present in the compressed volume.
            return ApfsCapable.Yes;
        }

        private static int FindValidLzmaHeader(byte[] sourcebuffer, int lzmabase, int lzmalimit, int maxattempts)
        {
            int nAttempts = 0;
            int iCurrent = lzmabase;

            while (nAttempts < maxattempts)
            {
                // Search for the next occurrence of the LZMA signature (0x5D).
                iCurrent = BinaryTools.GetBaseAddress(sourcebuffer, new byte[] { 0x5D }, iCurrent + 1);

                if (iCurrent == -1 || iCurrent >= lzmalimit)
                {
                    // No more valid positions or out of bounds.
                    return -1;
                }

                // Validate the potential LZMA header.
                byte[] bBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, iCurrent, 5);

                if (LzmaCoder.IsValidLzmaHeader(bBuffer))
                {
                    // Found a valid header.
                    return iCurrent;
                }

                // Increment attempts if the header isn't valid.
                nAttempts++;
            }

            // Failed to find a valid header within the allowed attempts.
            return -1;
        }

        private static int FindLzmaBase(byte[] sourcebuffer, byte[][] possibleguids, int searchbase, int searchlimit)
        {
            foreach (byte[] guid in possibleguids)
            {
                int iBase = BinaryTools.GetBaseAddress(sourcebuffer, guid, searchbase, searchlimit);
                if (iBase != -1)
                {
                    return iBase; // Return the first matching address.
                }
            }
            return -1; // No GUID matched.
        }
        #endregion

        #region Functions
        /// <summary>
        /// Patches the given Fsys store byte array with a new CRC value.
        /// </summary>
        /// <param name="sourcebuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched.</param>
        /// <returns>The patched Fsys store byte array.</returns>
        internal static byte[] PatchFsysCrc(byte[] sourcebuffer, uint newcrc)
        {
            // Convert the new CRC value to bytes
            byte[] bCrc = BitConverter.GetBytes(newcrc);

            // Write the new bytes back to the Fsys store at the appropriate base
            BinaryTools.OverwriteBytesAtBase(sourcebuffer, FsysRegionSize - CRC32_SIZE, bCrc);

            // Return the patched data
            return sourcebuffer;
        }

        /// <summary>
        /// Patches a binaries Fsys store with the correct crc value.
        /// </summary>
        /// <param name="sourcebuffer">The byte array representing the source binary file.</param>
        /// <param name="baseposition">The base of the Fsys store within the binary file.</param>
        /// <param name="fsysbuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched in the Fsys store.</param>
        /// <returns>The patched file byte array, or null if the new calculated crc does not match the crc in the Fsys store.</returns>
        internal static byte[] MakeFsysCrcPatchedBinary(byte[] sourcebuffer, int baseposition, byte[] fsysbuffer, uint newcrc)
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
            BinaryTools.OverwriteBytesAtBase(bPatchedSource, baseposition, bPatchedFsys);

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
        /// <param name="sourcebuffer">The SVS store to unlock.</param>
        /// <param name="lockposition">The Message Authentication Code base address.</param>
        internal static byte[] PatchSvsStoreMac(byte[] sourcebuffer, int lockposition)
        {
            // Some sanity checks.
            if (sourcebuffer == null || sourcebuffer.Length < 16)
            {
                return null;
            }

            // Write 0xFh length zeros over the MAC CRC from lockBase
            BinaryTools.OverwriteBytesAtBase(sourcebuffer, lockposition, new byte[0x0F]);

            // Returned the unlocked store
            return sourcebuffer;
        }
        #endregion
    }
}