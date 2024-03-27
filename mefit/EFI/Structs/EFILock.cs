using Mac_EFI_Toolkit.EFI.Enums;

namespace Mac_EFI_Toolkit.EFI.Structs
{
    internal struct EFILock
    {
        internal EfiLockType LockType { get; set; }
        internal int LockCrcBase { get; set; }
    }
}