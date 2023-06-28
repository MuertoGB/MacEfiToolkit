// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Descriptor.cs
// Released under the GNU GLP v3.0
// This code is a work in progress.

using Mac_EFI_Toolkit.Utils;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{

    #region Structs
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FlashDescriptor
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        internal byte[] ReservedVector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4)]
        internal byte[] Signature;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x2C)]
        internal byte[] Unknown;  // We do not need this chunk of data
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
    }
    #endregion

    class Descriptor
    {

        #region Internal Members
        internal const uint DESCRIPTOR_BASE = 0x0;
        internal const uint DESCRIPTOR_LENGTH = 0x1000;

        internal static uint DescriptorBase;
        internal static uint DescriptorLimit;
        internal static uint DescriptorSize;
        internal static uint BiosBase;
        internal static uint BiosLimit;
        internal static uint BiosSize;
        internal static uint MeBase;
        internal static uint MeLimit;
        internal static uint MeSize;
        internal static uint PdrBase;
        internal static uint PdrLimit;
        internal static uint PdrSize;

        internal static bool IsValid;
        #endregion

        internal static uint CalculateRegionBase(ushort basePos)
        {
            if (basePos == 0x7FFF)
                return 0;
            if (basePos == 0x0FFF)
                return 0;
            if (basePos == 0xFFFF)
                return 0;
            // For example:
            // BIOS Base:  LE: 3701h > 137h * 1000h = A bios base of 137000h
            return (basePos * DESCRIPTOR_LENGTH);
        }

        internal static uint CalculateRegionSize(ushort basePos, ushort limitPos)
        {
            if (limitPos != 0)
            {
                return (uint)((limitPos + 0x1 - basePos) * DESCRIPTOR_LENGTH);
            }
            // For example:
            // BIOS Size: LE: FF07h > (7FFh + 1) = 800h * 1000h - LE: 3701h > 137h * 1000h = 6C9000h
            return 0;
        }

        internal static void Parse(byte[] sourceBytes)
        {
            // Read in the flash descriptor
            byte[] fdRegionBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, (int)DESCRIPTOR_BASE, (int)DESCRIPTOR_LENGTH);
            // Deserialize the descriptor
            FlashDescriptor descriptor = Helper.DeserializeHeader<FlashDescriptor>(fdRegionBytes);

            // Match flash descriptor tag (5AA5F00F)
            if (!descriptor.Signature.SequenceEqual(FLASH_DESC_SIGNATURE))
            {
                // Signature mismatch
                IsValid = false;
                return;
            }

            // Signature match
            IsValid = true;

            // Descriptor base, size, limit
            DescriptorBase = CalculateRegionBase(descriptor.DescriptorBase);
            DescriptorSize = CalculateRegionSize(descriptor.DescriptorBase, descriptor.DescriptorLimit);
            DescriptorLimit = DescriptorBase + DescriptorSize;

            // BIOS base, size, limit
            BiosBase = CalculateRegionBase(descriptor.BiosBase);
            BiosSize = CalculateRegionSize(descriptor.BiosBase, descriptor.BiosLimit);
            BiosLimit = BiosBase + BiosSize;

            // Management Engine base, size, limit
            MeBase = CalculateRegionBase(descriptor.MeBase);
            MeSize = CalculateRegionSize(descriptor.MeBase, descriptor.MeLimit);
            MeLimit = MeBase + MeSize;

            // Platform Data Region base, size, limit
            PdrBase = CalculateRegionBase(descriptor.PdrBase);
            PdrSize = CalculateRegionSize(descriptor.PdrBase, descriptor.PdrLimit);
            PdrLimit = PdrBase + PdrSize;
        }

        internal static readonly byte[] FLASH_DESC_SIGNATURE =
        {
            0x5A, 0xA5, 0xF0, 0x0F
        };

    }
}