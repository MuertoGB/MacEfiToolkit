// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Enums.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit
{

    #region Application
    public enum VersionCheckResult
    {
        UpToDate,
        NewVersionAvailable,
        Error
    }

    internal enum LogType
    {
        Application,
        Database
    }

    public enum RtbLogPrefix
    {
        Complete,
        Info,
        Warning,
        Error
    }

    public enum METMessageType
    {
        Error, Warning, Information, Question
    }

    public enum METMessageButtons
    {
        Okay, YesNo
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

    #region MEParser
    internal enum HeaderType
    {
        FlashImageTool,
        ManagementEngine
    }
    #endregion

}