// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Structs.cs
// Released under the GNU GLP v3.0

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit
{

    #region Application
    internal struct METPath
    {
        internal static string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static string FsysDirectory = Path.Combine(CurrentDirectory, "fsys_stores");
        internal static string BuildsDirectory = Path.Combine(CurrentDirectory, "builds");
        internal static string SettingsFile = Path.Combine(METPath.CurrentDirectory, "Settings.ini");
    }

    internal struct METVersion
    {
        internal static readonly string Build = "230626.2330";
        internal static readonly string Channel = "Release";
    }

    internal struct METUrl
    {
        internal static string LatestGithubRelease = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";
        internal static string VersionXml = "https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml";
    }
    #endregion

    #region FWBase
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
    #endregion

    #region MEParser
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FptHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal byte HeaderVersion;
        internal byte EntryVersion;
        internal byte HeaderLength;
        internal byte Checksum;
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
    internal struct Mn2PartialHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal ushort EngineMajor;
        internal ushort EngineMinor;
        internal ushort EngineHotfix;
        internal ushort EngineBuild;
    }
    #endregion

}