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
    public class EFIROM
    {
        #region Public Members
        public string LoadedBinaryPath { get; set; }
        public byte[] LoadedBinaryBuffer { get; set; }
        public byte[] LzmaDecompressedBuffer { get; set; }
        public bool FirmwareLoaded { get; set; }
        public string FirmwareVersion { get; private set; }
        public string ConfigCode { get; set; }
        public bool ForceFoundFsys { get; private set; }
        public string FitVersion { get; private set; }
        public string MeVersion { get; private set; }
        public bool ResetVss { get; set; }
        public bool ResetSvs { get; set; }
        public string NewSerial { get; set; }
        public string FmmEmail { get; private set; }

        public FileInfoStore FileInfoData { get; private set; }
        public PdrSection PdrSectionData { get; private set; }
        public NvramStore VssPrimary { get; private set; }
        public NvramStore VssSecondary { get; private set; }
        public NvramStore SvsPrimary { get; private set; }
        public NvramStore SvsSecondary { get; private set; }
        public EFILock EfiPrimaryLockData { get; private set; }
        public EFILock EfiBackupLockData { get; private set; }
        public FsysStore FsysStoreData { get; private set; }
        public AppleRomInformationSection AppleRomInfoSectionData { get; private set; }
        public EfiBiosIdSection EfiBiosIdSectionData { get; private set; }

        public ApfsCapableType IsApfsCapable { get; private set; } = ApfsCapableType.Unknown;

        public int FsysRegionSize { get; private set; } = 0;
        public int NvramBase { get; private set; } = -1;
        public int NvramSize { get; private set; } = -1;
        public int NvramLimit { get; private set; } = -1;

        public FlashDescriptor Descriptor { get; private set; } = new FlashDescriptor();

        public TimeSpan ParseTime { get; private set; }
        #endregion

        #region Const Members
        public const int GUID_SIZE = 16;         // 10h
        public const int RSVD_SIZE = 16;         // 10h
        public const int HDR_SIZE = 16;          // 10h
        public const int ZERO_VECTOR_SIZE = 16;  // 10h
        public const int LITERAL_POS = 2;        // 2h
        public const int CRC32_SIZE = 4;         // 4h
        #endregion

        #region Private Members
        private static readonly Encoding _utf8Encoding = Encoding.UTF8;
        #endregion

        #region Parse Firmware
        public void LoadFirmwareBaseData(byte[] sourcebuffer, string filename)
        {
            // Start bench.
            Stopwatch parseTimer = Stopwatch.StartNew();

            // Try processing flash descriptor.
            Descriptor.ParseRegionData(sourcebuffer);

            // Parse file info.
            FileInfoData = FileTools.GetBinaryFileInfo(filename);

            // Parse Platform Data Region.
            PdrSectionData = GetPdrData(sourcebuffer);

            // Find the NVRAM base address.
            NvramBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.NvramSectionGuid, (int)Descriptor.BiosBase, (int)Descriptor.BiosLimit) - ZERO_VECTOR_SIZE;

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

            // Get Find my Mac email.
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
            FirmwareVersion = GetFirmwareVersion();

            // Get the Intel ME Flash Image Tool version.
            FitVersion = IntelME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.FIT, Descriptor);

            // Get the Intel ME version.
            MeVersion = IntelME.GetVersionData(LoadedBinaryBuffer, ImeVersionType.ME, Descriptor);

            parseTimer.Stop();
            ParseTime = parseTimer.Elapsed;
        }

        public bool IsValidImage(byte[] sourcebuffer)
        {
            byte[] descriptorSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, RSVD_SIZE, (int)FlashDescriptor.IFD_SIG_LENGTH);

            if (!BinaryTools.ByteArraysMatch(descriptorSignature, Descriptor.FlashDecriptorMarker))
            {
                int dxeCoreBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.EfiFirmwareFsGuid, RSVD_SIZE, GUID_SIZE);

                if (dxeCoreBase == -1)
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
            byte[] fvMainSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, RSVD_SIZE, GUID_SIZE);

            if (BinaryTools.ByteArraysMatch(fvMainSignature, Guids.FvMainGuid))
            {
                int smcDxeBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.AppleSmcDxeGuid);

                if (smcDxeBase != -1)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion 

        #region Platform Data Region
        public PdrSection GetPdrData(byte[] sourcebuffer)
        {
            // Descriptor mode not set.
            if (!Descriptor.IsDescriptorMode)
            {
                return DefaultPdrSection();
            }

            // Platform data region is not present.
            if (Descriptor.PdrBase == 0)
            {
                return DefaultPdrSection();
            }

            // Look for the board id signature bytes.
            int boardIdBase = BinaryTools.GetBaseAddress(sourcebuffer, Signatures.PlatformData.PdrBoardIdMarker, (int)Descriptor.PdrBase, (int)Descriptor.PdrSize);

            // Board id signature not found.
            if (boardIdBase == -1)
            {
                return DefaultPdrSection();
            }

            int position = 5;
            int length = 8;

            byte[] dataBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, boardIdBase + position, length);

            if (dataBuffer == null)
            {
                return DefaultPdrSection();
            }

            // Return the board id.
            return new PdrSection
            {
                BoardIdBase = boardIdBase,
                BoardId = $"Mac-{BitConverter.ToString(dataBuffer).Replace("-", "")}"
            };
        }

        private PdrSection DefaultPdrSection()
        {
            return new PdrSection
            {
                BoardIdBase = -1,
                BoardId = null
            };
        }
        #endregion

        #region NVRAM / EFI Lock
        public void GetNvramStores(byte[] sourcebuffer)
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

            int vssPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, Signatures.Nvram.VssStoreMarker, NvramBase, NvramLimit);

            // Check if the primary VSS store was found
            if (vssPrimaryBase != -1)
            {
                VssPrimary = ParseNvramStore(sourcebuffer, vssPrimaryBase, NvramStoreType.Variable);

                // Look for the secondary VSS store only if the primary was found
                int vssSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, Signatures.Nvram.VssStoreMarker, vssPrimaryBase + HDR_SIZE, NvramLimit);

                VssSecondary = vssSecondaryBase != -1
                    ? ParseNvramStore(sourcebuffer, vssSecondaryBase, NvramStoreType.Variable)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary VSS store is not found, set both to default
                VssPrimary = DefaultNvramSection();
                VssSecondary = DefaultNvramSection();
            }

            // Repeat similar logic for the SVS store
            int svsPrimaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, Signatures.Nvram.SvsStoreMarker, NvramBase, NvramLimit);

            // Check if the primary SVS store was found
            if (svsPrimaryBase != -1)
            {
                SvsPrimary = ParseNvramStore(sourcebuffer, svsPrimaryBase, NvramStoreType.Secure);

                // Look for the secondary SVS store only if the primary was found
                int svsSecondaryBase = BinaryTools.GetBaseAddressUpToLimit(sourcebuffer, Signatures.Nvram.SvsStoreMarker, svsPrimaryBase + HDR_SIZE, NvramLimit);

                SvsSecondary = svsSecondaryBase != -1
                    ? ParseNvramStore(sourcebuffer, svsSecondaryBase, NvramStoreType.Secure)
                    : DefaultNvramSection(); // Set to default if secondary not found
            }
            else
            {
                // If the primary SVS store is not found, set both to default
                SvsPrimary = DefaultNvramSection();
                SvsSecondary = DefaultNvramSection();
            }

        }

        public NvramStore ParseNvramStore(byte[] sourcebuffer, int baseposition, NvramStoreType nvramstoretype)
        {
            int storeLength = -1;
            byte format = 0xFF;
            byte state = 0xFF;
            byte[] storeBuffer = null;
            int bodyBase = -1;
            int bodyLength = -1;
            bool isStoreEmpty = true;

            byte[] headerBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, HDR_SIZE);

            NvramStoreHeader nvramHeader = Helper.DeserializeHeader<NvramStoreHeader>(headerBuffer);

            if (nvramHeader.StoreLength != 0xFFFF && nvramHeader.StoreLength != 0)
            {
                bodyBase = baseposition + HDR_SIZE;
                storeLength = nvramHeader.StoreLength;
                format = nvramHeader.Format;
                state = nvramHeader.State;

                storeBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, storeLength);

                if (storeBuffer != null)
                {
                    bodyLength = storeLength - HDR_SIZE;

                    byte[] bBodyBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, bodyBase, bodyLength);
                    isStoreEmpty = BinaryTools.IsByteBlockEmpty(bBodyBuffer);
                }
            }

            Console.WriteLine($"NVRAM Store - Base: {baseposition:X}h, Size: {storeLength:X}h, Type: {nvramstoretype}, Empty: {isStoreEmpty}, Format: {format:X}h, State: {state:X}h");

            return new NvramStore
            {
                StoreType = nvramstoretype,
                StoreBase = baseposition,
                StoreLength = storeLength,
                StoreBuffer = storeBuffer,
                StoreFormat = format,
                StoreState = state,
                BodyBase = bodyBase,
                BodyLength = bodyLength,
                IsStoreEmpty = isStoreEmpty
            };
        }

        private NvramStore DefaultNvramSection()
        {
            return new NvramStore
            {
                StoreType = NvramStoreType.None,
                StoreBase = -1,
                StoreLength = -1,
                StoreBuffer = null,
                StoreFormat = 0xFF,
                StoreState = 0xFF,
                BodyBase = -1,
                BodyLength = -1,
                IsStoreEmpty = true
            };
        }

        public EFILock GetIsEfiLocked(byte[] sourcebuffer)
        {
            // NVRAM store is empty.
            if (sourcebuffer == null)
            {
                return DefaultEfiLockStatus();
            }

            // Search store for Message Authentication Code.
            int lockBase = BinaryTools.GetBaseAddress(sourcebuffer, Signatures.Nvram.EfiLockMarker);

            // No Message Authentication Code was found.
            if (lockBase == -1)
            {
                return DefaultEfiLockStatus();
            }

            // Message Auth Code present
            return new EFILock
            {
                LockType = EfiLockType.Locked,
                LockBase = lockBase
            };
        }

        private EFILock DefaultEfiLockStatus()
        {
            return new EFILock
            {
                LockType = EfiLockType.Unlocked,
                LockBase = -1,
            };
        }
        #endregion

        #region fmm-mobileme-token-FMM
        public string GetFmmMobilemeEmail()
        {
            if (VssPrimary.IsStoreEmpty)
            {
                return null; // If the VSS is empty, there will be no token.
            }

            byte[] vssBuffer = VssPrimary.StoreBuffer;

            // Find the token in the buffer.
            int tokenBase = FindTokenBase(vssBuffer, Signatures.Nvram.FmmMarker);

            if (tokenBase == -1)
            {
                return null; // Token not found.
            }

            int limitAddress = FindTokenLimit(vssBuffer, tokenBase);

            if (limitAddress == -1)
            {
                return null; // Limit not found.
            }

            return ExtractEmailFromBuffer(vssBuffer, tokenBase, limitAddress);
        }

        private int FindTokenBase(byte[] sourcebuffer, byte[] token)
        {
            return BinaryTools.GetBaseAddress(sourcebuffer, token);
        }

        private int FindTokenLimit(byte[] sourcebuffer, int tokenbase)
        {
            byte[] limitBytes = new byte[] { 0xAA, 0x55 };
            return BinaryTools.GetBaseAddress(sourcebuffer, limitBytes, tokenbase);
        }

        private string ExtractEmailFromBuffer(byte[] buffer, int tokenbase, int tokenlimit)
        {
            // Step back 1 byte to ensure we're inside the bounds of the NVAR.
            tokenlimit -= 1;

            for (int i = tokenbase; i < tokenlimit;)
            {
                if (IsValidEmailBlock(buffer, i, out string stringData))
                {
                    Console.WriteLine($"Email found: {stringData}");
                    return stringData;
                }

                // Move the pointer to the next block.
                i++;
            }

            return null; // No valid email found.
        }

        private bool IsValidEmailBlock(byte[] sourcebuffer, int index, out string emailstring)
        {
            emailstring = string.Empty;

            // Check for the signature (0x5F, 0x10).
            if (sourcebuffer[index] == 0x5F && sourcebuffer[index + 1] == 0x10)
            {
                int size = sourcebuffer[index + 2];
                byte[] data = new byte[size];
                Array.Copy(sourcebuffer, index + 3, data, 0, size);

                emailstring = System.Text.Encoding.UTF8.GetString(data);

                // Check if the data contains '@' and '.' (basic email validation).
                return emailstring.Contains("@") && emailstring.Contains(".");
            }

            return false;
        }
        #endregion

        #region Fsys Store
        // Fsys resides in the NVRAM at either base: 0x20000h, or 0x22000h.
        internal FsysStore GetFsysStoreData(byte[] sourcebuffer, bool isfsysonly, bool forcefind = false)
        {
            // Find the base position of Fsys Store.
            int fsysBase = FindFsysBaseAddress(sourcebuffer, isfsysonly, forcefind);

            // If Fsys Store base is not found, return default data.
            if (fsysBase == -1)
            {
                return DefaultFsysRegion();
            }

            // Retrieve FsysStore bytes.
            byte[] fsysBuffer = GetFsysStoreBytes(sourcebuffer, fsysBase);

            // If FsysStore is invalid, return default data.
            if (!IsValidFsysStore(fsysBuffer))
            {
                return DefaultFsysRegion();
            }

            // Retrieve CRC bytes and calculate CRC values.
            byte[] crcBuffer = GetCrcBytes(sourcebuffer, fsysBase);
            string crcString = GetFlippedCrcString(crcBuffer);
            uint crcActualBuffer = GetUintFsysCrc32(fsysBuffer);
            string crcActualString = $"{crcActualBuffer:X8}";

            // Find and parse various signatures within FsysStore.
            int serialBase = FindSignatureAddress(
                sourcebuffer,
                fsysBase,
                FsysRegionSize,
                Signatures.FsysStore.SerialUpperMarker,
                Signatures.FsysStore.SerialLowerMarker,
                Signatures.FsysStore.SerialPLowerMarker);
            string serialString = ParseFsysString(sourcebuffer, serialBase);

            int hwcBase = FindSignatureAddress(sourcebuffer, fsysBase, FsysRegionSize, Signatures.FsysStore.HwcLowerMarker, Signatures.FsysStore.HwcUpperMarker);
            string hwcString = ParseFsysString(sourcebuffer, hwcBase);

            int sonBase = FindSignatureAddress(sourcebuffer, fsysBase, FsysRegionSize, Signatures.FsysStore.SonLowerMarker, Signatures.FsysStore.SonUpperMarker);
            string sonString = ParseFsysString(sourcebuffer, sonBase);

            // Trim trailing '/' from SON string if present.
            if (sonString != null && sonString.EndsWith("/"))
            {
                sonString = sonString.TrimEnd('/');
            }

            // Create and return FsysStore object.
            return new FsysStore
            {
                FsysBytes = fsysBuffer,
                FsysBase = fsysBase,
                Serial = serialString,
                SerialBase = serialBase != -1 ? serialBase + LITERAL_POS : -1,
                HWC = hwcString,
                HWCBase = hwcBase != -1 ? hwcBase + LITERAL_POS : -1,
                SON = sonString,
                CrcString = crcString,
                CrcActualString = crcActualString,
                CrcActual = crcActualBuffer
            };
        }

        private string ParseFsysString(byte[] sourcebuffer, int baseposition)
        {
            // Return null if base position is invalid or data size is zero.
            if (baseposition == -1 || sourcebuffer[baseposition] == 0)
            {
                return null;
            }

            // Read size of the indicated variable.
            int size = sourcebuffer[baseposition];

            // Return null if data size is invalid.
            if (size == 0)
            {
                return null;
            }

            // Read the variable bytes.
            byte[] stringBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + LITERAL_POS, size);

            // Return null if bytes are invalid or exceed the data size.
            if (stringBuffer == null || stringBuffer.Length != size)
            {
                return null;
            }

            // Return string data.
            return _utf8Encoding.GetString(stringBuffer);
        }

        private int FindFsysBaseAddress(byte[] sourcebuffer, bool isfsysonly, bool forcefind)
        {
            if (isfsysonly)
            {
                return 0;
            }

            if (forcefind)
            {
                return BinaryTools.GetBaseAddress(sourcebuffer, Signatures.FsysStore.FsysMarker, (int)Descriptor.BiosBase, (int)Descriptor.BiosLimit);
            }

            if (NvramBase == -1)
            {
                return -1;
            }

            if (NvramSize == -1)
            {
                return -1;
            }

            return BinaryTools.GetBaseAddress(sourcebuffer, Signatures.FsysStore.FsysMarker, NvramBase, NvramSize);
        }

        private bool IsValidFsysStore(byte[] sourcebuffer)
        {
            return sourcebuffer != null && sourcebuffer.Length == FsysRegionSize;
        }

        private string GetFlippedCrcString(byte[] sourcebuffer)
        {
            byte[] buffer = sourcebuffer.Reverse().ToArray();
            return BitConverter.ToString(buffer).Replace("-", "");
        }

        private int FindSignatureAddress(byte[] sourcebuffer, int baseposition, int maxsearchlength, params byte[][] signatures)
        {
            foreach (byte[] signature in signatures)
            {
                int signatureBase = BinaryTools.GetBaseAddress(sourcebuffer, signature, baseposition, maxsearchlength);

                if (signatureBase != -1)
                {
                    return signatureBase + signature.Length;
                }
            }

            return -1;
        }

        private byte[] GetFsysStoreBytes(byte[] sourcebuffer, int baseposition)
        {
            // Get Fsys Store size bytes - fsys base + 0x09, length 2 bytes (int16).
            byte[] size = BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + 9, 2);

            // Convert size to int16 value.
            FsysRegionSize = BitConverter.ToInt16(size, 0);

            // Min Fsys rgn size.
            if (FsysRegionSize < 2048)
            {
                Logger.WriteLine($"Fsys Store size was less than the min expected size: {FsysRegionSize}", LogType.Application);

                return null;
            }

            return BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition, FsysRegionSize);
        }

        private byte[] GetCrcBytes(byte[] sourcebuffer, int baseposition)
        {
            return BinaryTools.GetBytesBaseLength(sourcebuffer, baseposition + (FsysRegionSize - CRC32_SIZE), CRC32_SIZE);
        }

        private FsysStore DefaultFsysRegion()
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
        internal AppleRomInformationSection GetRomInformationData(byte[] sourcebuffer)
        {
            // Define constants for index and termination bytes.
            const byte indexByte = 0x20;
            const byte terminationByte = 0x0A;

            // Initialize signature-data dictionary.
            Dictionary<byte[], string> sectionEntries = new Dictionary<byte[], string>
            {
                { Signatures.AppleRom.BiosIdMarker, null },
                { Signatures.AppleRom.ModelMarker, null },
                { Signatures.AppleRom.EfiVersionMarker, null },
                { Signatures.AppleRom.BuiltByMarker, null },
                { Signatures.AppleRom.DateMarker, null },
                { Signatures.AppleRom.RevisionMarker, null },
                { Signatures.AppleRom.RomVersionMarker, null },
                { Signatures.AppleRom.BuildCaveIdMarker, null },
                { Signatures.AppleRom.BuildTypeMarker, null },
                { Signatures.AppleRom.CompilerMarker, null }
            };

            // Find all GUID locations.
            List<int> baseAddresses = GetRomSectionBaseAddresses(sourcebuffer);

            // Return default if no AppleRomInformation GUID was found.
            if (baseAddresses.Count == 0)
            {
                return DefaultRomInformationBase();
            }

            // Process each AppleRomInformation section.
            foreach (int baseAdrress in baseAddresses)
            {
                byte[] sectionBuffer = ExtractSectionBytes(sourcebuffer, baseAdrress);

                if (sectionBuffer == null)
                {
                    return DefaultRomInformationBase();
                }

                // Extract information based on each signature.
                foreach (byte[] signature in sectionEntries.Keys.ToList())
                {
                    int dataBase = BinaryTools.GetBaseAddress(sectionBuffer, signature);

                    if (dataBase != -1)
                    {
                        byte[] value = BinaryTools.GetBytesDelimited(sectionBuffer, dataBase + signature.Length, indexByte, terminationByte);

                        if (value != null)
                        {
                            sectionEntries[signature] = _utf8Encoding.GetString(value);
                        }
                    }
                }

                return new AppleRomInformationSection
                {
                    SectionExists = true,
                    SectionBytes = sectionBuffer,
                    SectionBase = baseAdrress,
                    BiosId = sectionEntries[Signatures.AppleRom.BiosIdMarker],
                    Model = sectionEntries[Signatures.AppleRom.ModelMarker],
                    EfiVersion = sectionEntries[Signatures.AppleRom.EfiVersionMarker],
                    BuiltBy = sectionEntries[Signatures.AppleRom.BuiltByMarker],
                    DateStamp = sectionEntries[Signatures.AppleRom.DateMarker],
                    Revision = sectionEntries[Signatures.AppleRom.RevisionMarker],
                    RomVersion = sectionEntries[Signatures.AppleRom.RomVersionMarker],
                    BuildcaveId = sectionEntries[Signatures.AppleRom.BuildCaveIdMarker],
                    BuildType = sectionEntries[Signatures.AppleRom.BuildTypeMarker],
                    Compiler = sectionEntries[Signatures.AppleRom.CompilerMarker]
                };
            }

            // Return default if no valid section was processed.
            return DefaultRomInformationBase();

            // Local function to locate all AppleRomInformation section GUIDs.
            List<int> GetRomSectionBaseAddresses(byte[] bytes)
            {
                List<int> addresses = new List<int>();
                int romInfoBase = BinaryTools.GetBaseAddress(bytes, Guids.AppleRomInformationGuid, (int)Descriptor.BiosBase, (int)Descriptor.BiosLimit);

                while (romInfoBase != -1)
                {
                    addresses.Add(romInfoBase);
                    romInfoBase = BinaryTools.GetBaseAddress(bytes, Guids.AppleRomInformationGuid, romInfoBase + 1, (int)Descriptor.BiosLimit);
                }

                return addresses;
            }

            // Local function to extract the section bytes.
            byte[] ExtractSectionBytes(byte[] sectionbuffer, int baseposition)
            {
                int headerLength = 24; // 18h
                int dataLength = 2; // 2h

                byte[] sizeBuffer = BinaryTools.GetBytesBaseLength(sectionbuffer, baseposition + headerLength, dataLength);
                int sectionSize = BitConverter.ToInt16(sizeBuffer, 0);

                return sectionSize > 6 ? BinaryTools.GetBytesBaseLength(sectionbuffer, baseposition + headerLength, sectionSize) : null;
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
        internal EfiBiosIdSection GetEfiBiosIdSectionData(byte[] sourcebuffer)
        {
            int biosIdBase = BinaryTools.GetBaseAddress(sourcebuffer, Guids.EfiBiosIdGuid, (int)Descriptor.BiosBase, (int)Descriptor.BiosLimit);

            if (biosIdBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int markerBase = BinaryTools.GetBaseAddress(sourcebuffer, Signatures.EfiBios.EfiBiosIdMarker, biosIdBase);

            if (markerBase == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            int markerLimit = BinaryTools.GetBaseAddress(sourcebuffer, new byte[] { 0x00, 0x00, 0x00 }, markerBase);

            if (markerLimit == -1)
            {
                return DefaultEfiBiosIdSection();
            }

            byte[] dataBuffer = BinaryTools.GetBytesBaseLimit(sourcebuffer, markerBase + Signatures.EfiBios.EfiBiosIdMarker.Length, markerLimit);

            if (dataBuffer == null)
            {
                return DefaultEfiBiosIdSection();
            }

            dataBuffer = dataBuffer.Where(b => b != 0x00 && b != 0x20).ToArray();
            string biosIdString = _utf8Encoding.GetString(dataBuffer);
            string[] biosIdParts = biosIdString.Split((char)0x2E);

            if (biosIdParts.Length != 5)
            {
                return DefaultEfiBiosIdSection();
            }

            return new EfiBiosIdSection
            {
                ModelPart = biosIdParts[0],
                ZzPart = biosIdParts[1],
                MajorPart = biosIdParts[2],
                MinorPart = biosIdParts[3],
                DatePart = biosIdParts[4],
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
        internal ApfsCapableType GetIsApfsCapable(byte[] sourcebuffer)
        {
            // APFS DXE GUID found.
            if (BinaryTools.GetBaseAddress(sourcebuffer, Guids.ApfsDxeGuid, (int)Descriptor.BiosBase, (int)Descriptor.BiosLimit) != -1)
            {
                Console.Write(" > Standard LZMA GUID found");
                return ApfsCapableType.Yes;
            }

            Console.WriteLine(" > Looking for a compressed LZMA DXE GUID");

            // Look for a compressed volume GUID.
            int lzmaBase = FindLzmaBase(
                sourcebuffer,
                new[] { Guids.DxeCoreLzmaVolumeGuid, Guids.DxeMainLzmaVolumeGuid },
                (int)Descriptor.BiosBase,
                (int)Descriptor.BiosLimit
            );

            // No compressed DXE volume was found.
            if (lzmaBase == -1)
            {
                Console.WriteLine(" > No compressed LZMA DXE GUID was found");
                return ApfsCapableType.No;
            }

            // Get bytes containing section length (0x3).
            byte[] lengthBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, lzmaBase + 20, 3);

            // Convert section length bytes to int24.
            int lzmaLength = Helper.ToInt24(lengthBuffer);

            // Determine the end of the LZMA GUID section.
            int lzmaLimit = lzmaBase + lzmaLength;

            Console.WriteLine(" > Looking for a valid LZMA header");

            // Search for a valid LZMA header (with 3 attempts).
            int lzmaSignatureBase = FindValidLzmaHeader(sourcebuffer, lzmaBase, lzmaLimit, maxattempts: 3);

            if (lzmaSignatureBase == -1)
            {
                Console.WriteLine(" > Valid LZMA header not found");
                // Couldn't locate a valid LZMA header.
                return ApfsCapableType.No;
            }

            Console.WriteLine(" > Decompressing LZMA DXE archive");

            // Decompress the LZMA volume.
            byte[] decompressedBuffer = LzmaCoder.DecompressBytes(
                BinaryTools.GetBytesBaseLimit(sourcebuffer, lzmaSignatureBase, lzmaLimit));

            // There was an issue decompressing the volume (Error saved to './mefit.log').
            if (decompressedBuffer == null)
            {
                Console.WriteLine(" > bDecompressed was empty.");
                return ApfsCapableType.Unknown;
            }

            // May as well store the archive buffer here.
            LzmaDecompressedBuffer = decompressedBuffer;

            // Search the decompressed volume for the APFS DXE GUID.
            if (BinaryTools.GetBaseAddress(decompressedBuffer, Guids.ApfsDxeGuid) == -1)
            {
                Console.WriteLine(" > No APFS GUID found in decompressed archive");
                // The APFS DXE GUID was not found in the compressed volume.
                return ApfsCapableType.No;
            }

            Console.WriteLine(" > An APFS GUID was found in the decompressed archive");
            // The APFS DXE GUID was present in the compressed volume.
            return ApfsCapableType.Yes;
        }

        private static int FindValidLzmaHeader(byte[] sourcebuffer, int lzmabase, int lzmalimit, int maxattempts)
        {
            int attempts = 0;
            int current = lzmabase;

            while (attempts < maxattempts)
            {
                // Search for the next occurrence of the LZMA signature (0x5D).
                current = BinaryTools.GetBaseAddress(sourcebuffer, new byte[] { 0x5D }, current + 1);

                if (current == -1 || current >= lzmalimit)
                {
                    // No more valid positions or out of bounds.
                    return -1;
                }

                // Validate the potential LZMA header.
                byte[] headerBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, current, 5);

                if (LzmaCoder.IsValidLzmaHeader(headerBuffer))
                {
                    // Found a valid header.
                    return current;
                }

                // Increment attempts if the header isn't valid.
                attempts++;
            }

            // Failed to find a valid header within the allowed attempts.
            return -1;
        }

        private static int FindLzmaBase(byte[] sourcebuffer, byte[][] possibleguids, int searchbase, int searchlimit)
        {
            foreach (byte[] guid in possibleguids)
            {
                int lzmaBase = BinaryTools.GetBaseAddress(sourcebuffer, guid, searchbase, searchlimit);

                if (lzmaBase != -1)
                {
                    return lzmaBase; // Return the first matching address.
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
        internal byte[] PatchFsysCrc(byte[] sourcebuffer, uint newcrc)
        {
            // Convert the new CRC value to bytes
            byte[] crcBuffer = BitConverter.GetBytes(newcrc);

            // Write the new bytes back to the Fsys store at the appropriate base
            BinaryTools.OverwriteBytesAtBase(sourcebuffer, FsysRegionSize - CRC32_SIZE, crcBuffer);

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
        internal byte[] MakeFsysCrcPatchedBinary(byte[] sourcebuffer, int baseposition, byte[] fsysbuffer, uint newcrc)
        {
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            // Create a new byte array to hold the patched binary.
            byte[] patchedSource = new byte[sourcebuffer.Length];

            Array.Copy(sourcebuffer, patchedSource, sourcebuffer.Length);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_PATCH);

            // Patch the Fsys store crc.
            byte[] patchedBuffer = PatchFsysCrc(fsysbuffer, newcrc);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_TO_FW);

            // Overwrite the loaded Fsys crc32 with the newly calculated crc32.
            BinaryTools.OverwriteBytesAtBase(patchedSource, baseposition, patchedBuffer);

            // Load the Fsys store from the new binary.
            FsysStore fsysStore = GetFsysStoreData(patchedSource, false);

            // Compare the new checksums.
            if (fsysStore.CrcString != fsysStore.CrcActualString)
            {
                Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_FAIL);

                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_SUCCESS);

            return patchedSource;
        }

        /// <summary>
        /// Invalidates an SVS store Message Authentication Code, removing EFI Lock.
        /// </summary>
        /// <param name="sourcebuffer">The SVS store to unlock.</param>
        /// <param name="lockposition">The Message Authentication Code base address.</param>
        internal byte[] PatchSvsStoreMac(byte[] sourcebuffer, int lockposition)
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

        internal string GetFirmwareVersion()
        {
            if (AppleRomInfoSectionData.EfiVersion != null)
            {
                return AppleRomInfoSectionData.EfiVersion;
            }

            string modelPart = EfiBiosIdSectionData.ModelPart;
            string majorPart = EfiBiosIdSectionData.MajorPart;
            string minorPart = EfiBiosIdSectionData.MinorPart;
            string romVersion = AppleRomInfoSectionData.RomVersion;
            string biosId = AppleRomInfoSectionData.BiosId;

            string notSet = "F000.B00";
            string[] ignoredStrings = { notSet, "Official Build" };

            if (!string.IsNullOrWhiteSpace(romVersion) && !ignoredStrings.Contains(romVersion, StringComparer.OrdinalIgnoreCase))
            {
                return $"{modelPart}.{romVersion.Replace("_", ".")}";
            }

            if (!string.IsNullOrWhiteSpace(biosId) && biosId.IndexOf(notSet, StringComparison.OrdinalIgnoreCase) == -1)
            {
                string[] parts = biosId.Split('.');

                if (parts.Length != 5)
                {
                    return GetFormattedEfiVersion(parts[0], parts[2], parts[3]);
                }
            }

            if (!string.IsNullOrWhiteSpace(modelPart) && !string.IsNullOrWhiteSpace(majorPart) && !string.IsNullOrWhiteSpace(minorPart))
            {
                return GetFormattedEfiVersion(modelPart, majorPart, minorPart);
            }

            return null;
        }

        private static string GetFormattedEfiVersion(string modelpart, string majorpart, string minorpart)
        {
            return $"{modelpart}.{majorpart}.{minorpart}";
        }

        /// <summary>
        /// Calculates an Fsys region CRC32 checksum.
        /// </summary>
        /// /// <param name="sourcebuffer">The Fsys region to calcuate the CRC32 for.</param>
        /// <returns>The calculated Fsys CRC32 uint</returns>
        internal uint GetUintFsysCrc32(byte[] sourcebuffer)
        {
            if (sourcebuffer.Length < FsysRegionSize)
            {
                throw new ArgumentException(nameof(sourcebuffer), "Given bytes are too small.");
            }

            if (sourcebuffer.Length > FsysRegionSize)
            {
                throw new ArgumentException(nameof(sourcebuffer), "Given bytes are too large.");
            }

            // Data we calculate is: Fsys Base + Fsys Size - CRC32 length of 4 bytes.
            byte[] fsysBuffer = new byte[FsysRegionSize - EFIROM.CRC32_SIZE];

            if (sourcebuffer != null)
            {
                Array.Copy(sourcebuffer, 0, fsysBuffer, 0, fsysBuffer.Length);

                return FileTools.GetCrc32Digest(fsysBuffer);
            }

            return 0xFFFFFFFF;
        }
        #endregion
    }
}