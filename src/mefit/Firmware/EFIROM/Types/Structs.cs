// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Structs.cs
// Released under the GNU GLP v3.0

using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    #region EfiLock
    public struct EFILock
    {
        internal EfiLockType LockType { get; set; }
        internal int LockBase { get; set; }
    }
    #endregion

    #region PdrSection
    public struct PdrSection
    {
        internal int BoardIdBase { get; set; }
        internal string BoardId { get; set; }
    }
    #endregion

    #region AppleRomInformationSection
    public struct AppleRomInformationSection
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
    #endregion

    #region EfiBiosIdSection
    public struct EfiBiosIdSection
    {
        internal string ModelPart { get; set; }
        internal string ZzPart { get; set; }
        internal string MajorPart { get; set; }
        internal string MinorPart { get; set; }
        internal string DatePart { get; set; }
    }
    #endregion

    #region NvramStore
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NvramStoreHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal ushort StoreLength;
        internal ushort Unknown;
        internal byte Format;
        internal byte State;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Reserved;
    }

    public struct NvramStore
    {
        internal NvramStoreType StoreType { get; set; }
        internal int StoreBase { get; set; }
        internal int StoreLength { get; set; }
        internal byte[] StoreBuffer { get; set; }
        internal byte StoreFormat { get; set; }
        internal byte StoreState { get; set; }
        internal int BodyBase { get; set; }
        internal int BodyLength { get; set; }
        internal bool IsStoreEmpty { get; set; }
    }
    #endregion

    #region FsysStore
    public struct FsysStore
    {
        internal byte[] FsysBytes { get; set; }
        internal int FsysBase { get; set; }
        internal string Serial { get; set; }
        internal int SerialBase { get; set; }
        internal string HWC { get; set; }
        internal int HWCBase { get; set; }
        internal string SON { get; set; }
        internal string CrcString { get; set; }
        internal string CrcActualString { get; set; }
        internal uint CrcActual { get; set; }
    }
    #endregion

    #region Flash Descriptor
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DescriptorHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] // 10h
        internal byte[] ReservedVector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 4h
        internal byte[] Tag;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DescriptorMap
    {
        internal byte ComponentBase;
        internal byte NumOfFlashChips;
        internal byte RegionBase;
        internal byte NumOfRegions;
        internal byte MasterBase;
        internal byte NumOfMasters;
        internal byte PchStrapsBase;
        internal byte NumOfPchStraps;
        internal byte ProcStrapsBase;
        internal byte NumOfProcStraps;
        internal ushort DescriptorVersion;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DescriptorRegions
    {
        internal ushort DescriptorBase;
        internal ushort DescriptorLimit;
        internal ushort BiosBase;
        internal ushort BiosLimit;
        internal ushort MeBase;
        internal ushort MeLimit;
        internal ushort GbeBase;
        internal ushort GbeLimit;
        internal ushort PdrBase;
        internal ushort PdrLimit;
        internal ushort DevExp1Base;
        internal ushort DevExp1Limit;
        internal ushort Bios2Base;
        internal ushort Bios2Limit;
        internal ushort MicrocodeBase;
        internal ushort MicrocodeLimit;
        internal ushort EcBase;
        internal ushort EcLimit;
        internal ushort DevExp2Base;
        internal ushort DevExp2Limit;
        internal ushort IeBase;
        internal ushort IeLimit;
        internal ushort Tgbe1Base;
        internal ushort Tgbe1Limit;
        internal ushort Tgbe2Base;
        internal ushort Tgbe2Limit;
        internal ushort Reserved1Base;
        internal ushort Reserved1Limit;
        internal ushort Reserved2Base;
        internal ushort Reserved2Limit;
        internal ushort PttBase;
        internal ushort PttLimit;
    }
    #endregion

    #region Management Engine
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FPTHeader
    {
        internal uint Tag;
        internal uint NumEntries;
        internal byte HeaderVersion;
        internal byte EntryVersion;
        internal byte HeaderLength;
        internal byte HeaderChecksum;
        internal ushort FlashCycleLife;
        internal ushort FlashCycleLimit;
        internal uint UmaSize;
        internal uint Flags;
        internal ushort FitMajor;
        internal ushort FitMinor;
        internal ushort FitHotfix;
        internal ushort FitBuild;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MN2Header
    {
        internal uint Tag;
        internal uint NumEntries;
        internal ushort EngineMajor;
        internal ushort EngineMinor;
        internal ushort EngineHotfix;
        internal ushort EngineBuild;
    }
    #endregion
}