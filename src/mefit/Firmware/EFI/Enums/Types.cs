// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Types.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.EFI
{
    internal enum ApfsCapable
    {
        Yes,
        No,
        Unknown
    }

    internal enum EfiLockType
    {
        Locked,
        Unlocked,
        Unknown
    }

    internal enum NvramStoreType
    {
        VSS,
        SVS
    }
}