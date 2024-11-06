// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IFD.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware.EFI
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

    class IFD
    {

        #region Internal Members
        internal const uint DESCRIPTOR_BASE = 0; // 0h
        internal const uint DESCRIPTOR_LENGTH = 4096; // 1000h

        internal static uint
            BIOS_REGION_BASE,
            BIOS_REGION_LIMIT,
            BIOS_REGION_SIZE = 0;

        internal static uint
            ME_REGION_BASE,
            ME_REGION_LIMIT,
            ME_REGION_SIZE = 0;

        internal static uint
            PDR_REGION_BASE,
            PDR_REGION_LIMIT,
            PDR_REGION_SIZE = 0;

        internal static DescriptorHeader Header;
        internal static DescriptorMap Map;
        internal static DescriptorRegions Regions;

        internal static bool IsDescriptorMode = false;
        #endregion

        internal static uint CalculateRegionBase(ushort basePosition)
        {
            // For example:
            // BIOS Base:  LE: 3701h > 137h * 1000h = A bios base of 137000h.
            return basePosition * DESCRIPTOR_LENGTH;
        }

        internal static uint CalculateRegionSize(ushort basePosition, ushort limitPosition)
        {
            // For example:
            // BIOS Size: LE: FF07h > (7FFh + 1) = 800h * 1000h - LE: 3701h > 137h * 1000h = 6C9000h.
            if (limitPosition != 0)
                return (uint)(limitPosition + 1 - basePosition) * DESCRIPTOR_LENGTH;

            return 0;
        }

        internal static void ParseRegionData(byte[] sourceBytes)
        {
            // Read in the flash descriptor.
            byte[] DescriptorBytes =
                BinaryTools.GetBytesBaseLength(
                    sourceBytes,
                    (int)DESCRIPTOR_BASE,
                    (int)DESCRIPTOR_LENGTH);

            // Deserialize the header
            byte[] HeaderBytes =
                new byte[Marshal.SizeOf(typeof(DescriptorHeader))];

            Array.Copy(
                DescriptorBytes,
                0,
                HeaderBytes,
                0,
                Marshal.SizeOf(typeof(DescriptorHeader)));

            Header =
                Helper.DeserializeHeader<DescriptorHeader>(
                    HeaderBytes);

            // Match flash descriptor tag (5AA5F00F).
            IsDescriptorMode =
                Header.Tag.SequenceEqual(
                    FLASH_DESC_SIGNATURE);

            // Descriptor mode.
            if (IsDescriptorMode)
            {
                // Deserialize the flash map.
                byte[] MapBytes =
                    new byte[Marshal.SizeOf(typeof(DescriptorMap))];

                Array.Copy(
                    DescriptorBytes,
                    Marshal.SizeOf(typeof(DescriptorHeader)),
                    MapBytes,
                    0,
                    Marshal.SizeOf(typeof(DescriptorMap)));

                Map =
                    Helper.DeserializeHeader<DescriptorMap>(
                        MapBytes);

                // Deserialize the regions data.
                byte[] RegionBytes =
                    new byte[Marshal.SizeOf(typeof(DescriptorRegions))];

                // Left shift right four bits: Example: 04h: 0000 0100 << 40h: 0100 0000.
                int RegionBase = Map.RegionBase << 4;

                Array.Copy(
                    DescriptorBytes,
                    RegionBase,
                    RegionBytes,
                    0,
                    Marshal.SizeOf(typeof(DescriptorRegions)));

                Regions =
                    Helper.DeserializeHeader<DescriptorRegions>(
                        RegionBytes);

                // Parse BIOS Region base, limit and size.
                BIOS_REGION_BASE =
                    CalculateRegionBase(
                        Regions.BiosBase);

                if (BIOS_REGION_BASE > sourceBytes.Length) BIOS_REGION_BASE = 0;

                if (Regions.BiosLimit == 0 || Regions.BiosLimit > sourceBytes.Length)
                {
                    BIOS_REGION_LIMIT = (uint)sourceBytes.Length; BIOS_REGION_SIZE = 0;
                }
                else
                {
                    BIOS_REGION_SIZE = CalculateRegionSize(Regions.BiosBase, Regions.BiosLimit);
                    BIOS_REGION_LIMIT = BIOS_REGION_BASE + BIOS_REGION_SIZE;
                }

                // Parse Management Engine Region base, limit and size.
                ME_REGION_BASE =
                    CalculateRegionBase(
                        Regions.MeBase);

                if (ME_REGION_BASE > sourceBytes.Length) ME_REGION_BASE = 0;

                if (Regions.MeLimit == 0 || Regions.MeLimit > sourceBytes.Length)
                {
                    ME_REGION_LIMIT = (uint)sourceBytes.Length; ; ME_REGION_SIZE = 0;
                }
                else
                {
                    ME_REGION_SIZE = CalculateRegionSize(Regions.MeBase, Regions.MeLimit);
                    ME_REGION_LIMIT = ME_REGION_BASE + ME_REGION_SIZE;
                }

                // Parse Platform Data Region base, limit and size.
                PDR_REGION_BASE =
                    CalculateRegionBase(
                        Regions.PdrBase);

                if (PDR_REGION_BASE > sourceBytes.Length) PDR_REGION_BASE = 0;

                if (Regions.BiosLimit == 0 || Regions.BiosLimit > sourceBytes.Length)
                {
                    ME_REGION_LIMIT = (uint)sourceBytes.Length; ME_REGION_SIZE = 0;
                }
                else
                {
                    PDR_REGION_SIZE = CalculateRegionSize(Regions.PdrBase, Regions.PdrLimit);
                    PDR_REGION_LIMIT = PDR_REGION_BASE + PDR_REGION_SIZE;
                }

                // We end execution here when descriptor mode is set.
                return;
            }

            // Base/Size data is already set to zero, we need to set region limits
            // as the file length when descriptor mode is not set.
            PDR_REGION_LIMIT = (uint)sourceBytes.Length;
            ME_REGION_LIMIT = (uint)sourceBytes.Length;
            BIOS_REGION_LIMIT = (uint)sourceBytes.Length;
        }

        internal static void ClearRegionData()
        {
            Header = default;
            Map = default;
            Regions = default;

            BIOS_REGION_BASE = 0; BIOS_REGION_LIMIT = 0; BIOS_REGION_SIZE = 0;
            ME_REGION_BASE = 0; ME_REGION_LIMIT = 0; ME_REGION_SIZE = 0;
            PDR_REGION_BASE = 0; PDR_REGION_LIMIT = 0; PDR_REGION_SIZE = 0;

            IsDescriptorMode = false;
        }

        internal static readonly byte[] FLASH_DESC_SIGNATURE =
        {
            0x5A, 0xA5, 0xF0, 0x0F
        };

    }
}