// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Enums.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    public enum ApfsCapableType
    {
        Yes, No, Unknown
    }

    public enum EfiLockType
    {
        Locked, Unlocked, Unknown
    }

    public enum NvramStoreType
    {
        Variable, Secure, None
    }

    public enum ImeVersionType
    {
        FIT, ME
    }
}