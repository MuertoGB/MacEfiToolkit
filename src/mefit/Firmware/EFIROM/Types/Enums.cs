// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Enums.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    internal enum ApfsCapable
    {
        Yes, No, Unknown
    }

    internal enum EfiLockType
    {
        Locked, Unlocked, Unknown
    }

    internal enum NvramStoreType
    {
        Variable, Secure, None
    }

    internal enum ImeVersionType
    {
        FlashImageTool, ManagementEngine
    }
}