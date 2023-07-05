// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Descriptor.cs
// Released under the GNU GLP v3.0
// This code is a work in progress.

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{

    #region Structs
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DescriptorHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] // 10h
        internal byte[] ReservedVector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 4h
        internal byte[] Tag;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DescriptorMap
    {
        internal byte ComponentBase;
        internal byte NumOfFlashChips;
        internal byte RegionBase;
        internal byte NumOfRegions;
        internal byte MasterBase;
        internal byte NumOfMasters;
        internal byte PchStrapsBase;
        internal byte NumOfPchStraps;
        internal byte ProcStrapsBase;
        internal byte NumOfProcStraps;
        internal ushort DescriptorVersion;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DescriptorRegions
    {
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
        internal ushort DevExp1Base;
        internal ushort DevExp1Limit;
        internal ushort Bios2Base;
        internal ushort Bios2Limit;
        internal ushort MicrocodeBase;
        internal ushort MicrocodeLimit;
        internal ushort EcBase;
        internal ushort EcLimit;
        internal ushort DevExp2Base;
        internal ushort DevExp2Limit;
        internal ushort IeBase;
        internal ushort IeLimit;
        internal ushort Tgbe1Base;
        internal ushort Tgbe1Limit;
        internal ushort Tgbe2Base;
        internal ushort Tgbe2Limit;
        internal ushort Reserved1Base;
        internal ushort Reserved1Limit;
        internal ushort Reserved2Base;
        internal ushort Reserved2Limit;
        internal ushort PttBase;
        internal ushort PttLimit;
    }
    #endregion

    class Descriptor
    {

        #region Internal Members
        internal const uint DESCRIPTOR_BASE = 0; // 0h
        internal const uint DESCRIPTOR_LENGTH = 4096; // 1000h

        internal static DescriptorHeader Header;
        internal static DescriptorMap Map;
        internal static DescriptorRegions Regions;

        internal static uint BiosBase = 0;
        internal static uint BiosLimit = 0;
        internal static uint BiosSize = 0;
        internal static uint MeBase = 0;
        internal static uint MeLimit = 0;
        internal static uint MeSize = 0;
        internal static uint PdrBase = 0;
        internal static uint PdrLimit = 0;
        internal static uint PdrSize = 0;

        internal static bool DescriptorMode = false;
        #endregion

        internal static uint CalculateRegionBase(ushort basePosition)
        {
            // For example:
            // BIOS Base:  LE: 3701h > 137h * 1000h = A bios base of 137000h
            return basePosition * DESCRIPTOR_LENGTH;
        }

        internal static uint CalculateRegionSize(ushort basePosition, ushort limitPosition)
        {
            if (limitPosition != 0)
                return (uint)(limitPosition + 1 - basePosition) * DESCRIPTOR_LENGTH;

            // For example:
            // BIOS Size: LE: FF07h > (7FFh + 1) = 800h * 1000h - LE: 3701h > 137h * 1000h = 6C9000h
            return 0;
        }

        internal static void Parse(byte[] sourceBytes)
        {
            // Read in the flash descriptor
            byte[] DescriptorBytes = BinaryUtils.GetBytesBaseLength(sourceBytes, (int)DESCRIPTOR_BASE, (int)DESCRIPTOR_LENGTH);

            // Deserialize the header
            byte[] HeaderBytes = new byte[Marshal.SizeOf(typeof(DescriptorHeader))];
            Array.Copy(DescriptorBytes, 0, HeaderBytes, 0, Marshal.SizeOf(typeof(DescriptorHeader)));
            Header = Helper.DeserializeHeader<DescriptorHeader>(HeaderBytes);

            // Deserialize the flash map
            byte[] MapBytes = new byte[Marshal.SizeOf(typeof(DescriptorMap))];
            Array.Copy(DescriptorBytes, Marshal.SizeOf(typeof(DescriptorHeader)), MapBytes, 0, Marshal.SizeOf(typeof(DescriptorMap)));
            Map = Helper.DeserializeHeader<DescriptorMap>(MapBytes);

            // Deserialize the regions data
            byte[] RegionBytes = new byte[Marshal.SizeOf(typeof(DescriptorRegions))];
            int RegionBase = Map.RegionBase << 4; // Left shift right four bits: Example: 04h: 0000 0100 << 40h: 0100 0000
            Array.Copy(DescriptorBytes, RegionBase, RegionBytes, 0, Marshal.SizeOf(typeof(DescriptorRegions)));
            Regions = Helper.DeserializeHeader<DescriptorRegions>(RegionBytes);

            // Match flash descriptor tag (5AA5F00F)
            DescriptorMode = Header.Tag.SequenceEqual(FLASH_DESC_SIGNATURE);

            // Descriptor mode
            if (DescriptorMode)
            {
                // BIOS base, size, limit
                BiosBase = CalculateRegionBase(Regions.BiosBase);
                if (BiosBase > sourceBytes.Length) BiosBase = 0;
                BiosSize = CalculateRegionSize(Regions.BiosBase, Regions.BiosLimit);
                BiosLimit = BiosBase + BiosSize;

                // Management Engine base, size, limit
                MeBase = CalculateRegionBase(Regions.MeBase);
                if (MeBase > sourceBytes.Length) MeBase = 0;
                MeSize = CalculateRegionSize(Regions.MeBase, Regions.MeLimit);
                MeLimit = MeBase + MeSize;

                // Platform Data Region base, size, limit
                PdrBase = CalculateRegionBase(Regions.PdrBase);
                if (PdrBase > sourceBytes.Length) PdrBase = 0;
                PdrSize = CalculateRegionSize(Regions.PdrBase, Regions.PdrLimit);
                PdrLimit = PdrBase + PdrSize;
            }
        }

        internal static void ResetValues()
        {
            Header = default;
            Map = default;
            Regions = default;

            BiosBase = 0;
            BiosLimit = 0;
            BiosSize = 0;
            MeBase = 0;
            MeLimit = 0;
            MeSize = 0;
            PdrBase = 0;
            PdrLimit = 0;
            PdrSize = 0;

            DescriptorMode = false;
        }

        internal static readonly byte[] FLASH_DESC_SIGNATURE =
        {
            0x5A, 0xA5, 0xF0, 0x0F
        };

    }
}