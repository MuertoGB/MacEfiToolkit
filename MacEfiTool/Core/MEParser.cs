// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// MEParser.cs - Handles parsing of ME region data
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;

using Mac_EFI_Toolkit.Utils;

namespace Mac_EFI_Toolkit.Core
{
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
        internal ushort Major;
        internal ushort Minor;
        internal ushort Hotfix;
        internal ushort Build;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Mn2Header
    {
        // Right now we don't care about the pre-signature stuff, only the ME Version.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal char[] Signature;
        internal uint NumEntries;
        internal ushort Major;
        internal ushort Minor;
        internal ushort Hotfix;
        internal ushort Build;
    }

    class MEParser
    {
        internal static T DeserializeHeader<T>(byte[] binary) where T : struct
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(binary, 0, ptr, size);

                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr);
            }
        }
        internal static string GetFitcVersion(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.FPT_HEADER_SIG);
            if (offset != -1)
            {
                byte[] headerBytes = BinaryUtils.ReadBytesAtOffset(bytesIn, offset, 0x20);
                if (headerBytes != null)
                {
                    FptHeader header = MEParser.DeserializeHeader<FptHeader>(headerBytes);
                    return $"{header.Major}.{header.Minor}.{header.Hotfix}.{header.Build}";
                }
            }
            return "Not found";
        }
        internal static string GetMeVersion(byte[] bytesIn)
        {
            long offset = BinaryUtils.FindOffset(bytesIn, Filesystem.MN2_SIG);
            if (offset != -1)
            {
                byte[] headerBytes = BinaryUtils.ReadBytesAtOffset(bytesIn, offset, 0x10);
                if (headerBytes != null)
                {
                    Mn2Header header = MEParser.DeserializeHeader<Mn2Header>(headerBytes);
                    return $"{header.Major}.{header.Minor}.{header.Hotfix}.{header.Build}";
                }
            }
            return "Not found";
        }
    }
}
