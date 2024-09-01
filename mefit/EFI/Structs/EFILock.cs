// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EFILock.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.EFI.Enums;

namespace Mac_EFI_Toolkit.EFI.Structs
{
    internal struct EFILock
    {
        internal EfiLockType LockType { get; set; }
        internal int LockCrcBase { get; set; }
    }
}