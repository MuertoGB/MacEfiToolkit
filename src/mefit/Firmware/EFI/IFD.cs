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
    class IFD
    {
        #region Internal Members
        internal const uint DESCRIPTOR_BASE = 0; // 0h
        internal const uint DESCRIPTOR_LENGTH = 4096; // 1000h
        internal const int IFD_SIG_LENGTH = 4;

        internal static uint BIOS_REGION_BASE, BIOS_REGION_LIMIT, BIOS_REGION_SIZE = 0;
        internal static uint ME_REGION_BASE, ME_REGION_LIMIT, ME_REGION_SIZE = 0;
        internal static uint PDR_REGION_BASE, PDR_REGION_LIMIT, PDR_REGION_SIZE = 0;

        internal static bool IsDescriptorMode = false;

        internal static readonly byte[] FLASH_DESC_SIGNATURE = { 0x5A, 0xA5, 0xF0, 0x0F };
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
            {
                return (uint)(limitPosition + 1 - basePosition) * DESCRIPTOR_LENGTH;
            }

            return 0;
        }

        internal static void ParseRegionData(byte[] sourceBytes)
        {
            byte[] descriptorBytes = BinaryTools.GetBytesBaseLength(sourceBytes, (int)DESCRIPTOR_BASE, (int)DESCRIPTOR_LENGTH);
            DescriptorHeader header = DeserializeStruct<DescriptorHeader>(descriptorBytes, 0);

            IsDescriptorMode = header.Tag.SequenceEqual(FLASH_DESC_SIGNATURE);

            if (IsDescriptorMode)
            {
                DescriptorMap map = DeserializeStruct<DescriptorMap>(descriptorBytes, Marshal.SizeOf(typeof(DescriptorHeader)));
                DescriptorRegions regions = DeserializeStruct<DescriptorRegions>(descriptorBytes, map.RegionBase << 4);

                ParseRegion(regions.BiosBase, regions.BiosLimit, sourceBytes.Length, out BIOS_REGION_BASE, out BIOS_REGION_LIMIT, out BIOS_REGION_SIZE);
                ParseRegion(regions.MeBase, regions.MeLimit, sourceBytes.Length, out ME_REGION_BASE, out ME_REGION_LIMIT, out ME_REGION_SIZE);
                ParseRegion(regions.PdrBase, regions.PdrLimit, sourceBytes.Length, out PDR_REGION_BASE, out PDR_REGION_LIMIT, out PDR_REGION_SIZE);

                return;
            }

            BIOS_REGION_LIMIT = (uint)sourceBytes.Length;
            ME_REGION_LIMIT = (uint)sourceBytes.Length;
            PDR_REGION_LIMIT = (uint)sourceBytes.Length;
        }

        private static T DeserializeStruct<T>(byte[] source, int offset) where T : struct
        {
            byte[] structBytes = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(source, offset, structBytes, 0, structBytes.Length);
            return Helper.DeserializeHeader<T>(structBytes);
        }

        private static void ParseRegion(ushort basePosition, ushort limitPosition, int sourceLength, out uint regionBase, out uint regionLimit, out uint regionSize)
        {
            regionBase = CalculateRegionBase(basePosition);

            if (regionBase > sourceLength)
            {
                regionBase = 0;
            }

            if (limitPosition == 0 || limitPosition > sourceLength)
            {
                regionLimit = (uint)sourceLength;
                regionSize = 0;
            }
            else
            {
                regionSize = CalculateRegionSize(basePosition, limitPosition);
                regionLimit = regionBase + regionSize;
            }
        }

        internal static void ClearRegionData()
        {
            BIOS_REGION_BASE = 0; BIOS_REGION_LIMIT = 0; BIOS_REGION_SIZE = 0;
            ME_REGION_BASE = 0; ME_REGION_LIMIT = 0; ME_REGION_SIZE = 0;
            PDR_REGION_BASE = 0; PDR_REGION_LIMIT = 0; PDR_REGION_SIZE = 0;

            IsDescriptorMode = false;
        }
    }
}