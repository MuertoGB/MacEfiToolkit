// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FlashDescriptor.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    class FlashDescriptor
    {
        #region Internal Members
        internal const uint DESCRIPTOR_BASE = 0; // 0h
        internal const uint DESCRIPTOR_LENGTH = 4096; // 1000h
        internal const uint IFD_SIG_LENGTH = 4;
        internal static uint BiosBase, BiosLimit, BiosSize = 0;
        internal static uint MeBase, MeLimit, MeSize = 0;
        internal static uint PdrBase, PdrLimit, PdrSize = 0;
        internal static bool IsDescriptorMode = false;
        internal static readonly byte[] FlashDecriptorMarker = { 0x5A, 0xA5, 0xF0, 0x0F };
        #endregion

        internal static uint CalculateRegionBase(ushort baseposition)
        {
            // For example:
            // BIOS Base:  LE: 3701h > 137h * 1000h = A bios base of 137000h.
            return baseposition * DESCRIPTOR_LENGTH;
        }

        internal static uint CalculateRegionSize(ushort baseposition, ushort limitposition)
        {
            // For example:
            // BIOS Size: LE: FF07h > (7FFh + 1) = 800h * 1000h - LE: 3701h > 137h * 1000h = 6C9000h.
            if (limitposition != 0)
            {
                return (uint)(limitposition + 1 - baseposition) * DESCRIPTOR_LENGTH;
            }

            return 0;
        }

        internal static void ParseRegionData(byte[] sourcebuffer)
        {
            byte[] bDescriptor = BinaryTools.GetBytesBaseLength(sourcebuffer, (int)DESCRIPTOR_BASE, (int)DESCRIPTOR_LENGTH);
            DescriptorHeader desHeader = DeserializeStruct<DescriptorHeader>(bDescriptor, 0);

            IsDescriptorMode = desHeader.Tag.SequenceEqual(FlashDecriptorMarker);

            if (IsDescriptorMode)
            {
                DescriptorMap desMap = DeserializeStruct<DescriptorMap>(bDescriptor, Marshal.SizeOf(typeof(DescriptorHeader)));
                DescriptorRegions desRegions = DeserializeStruct<DescriptorRegions>(bDescriptor, desMap.RegionBase << 4);

                ParseRegion(desRegions.BiosBase, desRegions.BiosLimit, sourcebuffer.Length, out BiosBase, out BiosLimit, out BiosSize);
                ParseRegion(desRegions.MeBase, desRegions.MeLimit, sourcebuffer.Length, out MeBase, out MeLimit, out MeSize);
                ParseRegion(desRegions.PdrBase, desRegions.PdrLimit, sourcebuffer.Length, out PdrBase, out PdrLimit, out PdrSize);

                return;
            }

            BiosLimit = (uint)sourcebuffer.Length;
            MeLimit = (uint)sourcebuffer.Length;
            PdrLimit = (uint)sourcebuffer.Length;
        }

        private static T DeserializeStruct<T>(byte[] source, int offset) where T : struct
        {
            byte[] structBytes = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(source, offset, structBytes, 0, structBytes.Length);
            return Helper.DeserializeHeader<T>(structBytes);
        }

        private static void ParseRegion(ushort baseposition, ushort limitposition, int sourcelength, out uint regionbase, out uint regionlimit, out uint regionlength)
        {
            regionbase = CalculateRegionBase(baseposition);

            if (regionbase > sourcelength)
            {
                regionbase = 0;
            }

            if (limitposition == 0 || limitposition > sourcelength)
            {
                regionlimit = (uint)sourcelength;
                regionlength = 0;
            }
            else
            {
                regionlength = CalculateRegionSize(baseposition, limitposition);
                regionlimit = regionbase + regionlength;
            }
        }

        internal static void ClearRegionData()
        {
            BiosBase = 0; BiosLimit = 0; BiosSize = 0;
            MeBase = 0; MeLimit = 0; MeSize = 0;
            PdrBase = 0; PdrLimit = 0; PdrSize = 0;

            IsDescriptorMode = false;
        }
    }
}