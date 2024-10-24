// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EFILock.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.EFI
{
    internal struct EFILock
    {
        internal EfiLockType LockType { get; set; }
        internal int LockCrcBase { get; set; }
    }
}