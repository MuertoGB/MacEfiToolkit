// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FlashDescriptor.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Interop;
using Mac_EFI_Toolkit.Utilities;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    public class FlashDescriptor
    {
        #region Public Members
        public uint BiosBase { get; private set; } = 0;
        public uint BiosLimit { get; private set; } = 0;
        public uint BiosSize { get; private set; } = 0;
        public uint MeBase { get; private set; } = 0;
        public uint MeLimit { get; private set; } = 0;
        public uint MeSize { get; private set; } = 0;
        public uint PdrBase { get; private set; } = 0;
        public uint PdrLimit { get; private set; } = 0;
        public uint PdrSize { get; private set; } = 0;
        public bool IsDescriptorMode { get; private set; } = false;

        public readonly byte[] FlashDecriptorMarker = { 0x5A, 0xA5, 0xF0, 0x0F };
        #endregion

        #region Const Members
        public const uint DESCRIPTOR_BASE = 0; // 0h
        public const uint DESCRIPTOR_LENGTH = 4096; // 1000h
        public const uint IFD_SIG_LENGTH = 4;
        #endregion

        private uint CalculateRegionBase(ushort baseposition)
        {
            // For example:
            // BIOS Base:  LE: 3701h > 137h * 1000h = A bios base of 137000h.
            return baseposition * DESCRIPTOR_LENGTH;
        }

        private uint CalculateRegionSize(ushort baseposition, ushort limitposition)
        {
            // For example:
            // BIOS Size: LE: FF07h > (7FFh + 1) = 800h * 1000h - LE: 3701h > 137h * 1000h = 6C9000h.
            if (limitposition != 0)
            {
                return (uint)(limitposition + 1 - baseposition) * DESCRIPTOR_LENGTH;
            }

            return 0;
        }

        public void ParseRegionData(byte[] sourcebuffer)
        {
            byte[] descriptorBytes = BinaryUtils.GetBytesBaseLength(sourcebuffer, (int)DESCRIPTOR_BASE, (int)DESCRIPTOR_LENGTH);
            DescriptorHeader header = ReadStruct<DescriptorHeader>(descriptorBytes, 0);

            IsDescriptorMode = header.Tag.SequenceEqual(FlashDecriptorMarker);

            if (!IsDescriptorMode)
            {
                uint length = (uint)sourcebuffer.Length;
                BiosLimit = MeLimit = PdrLimit = length;

                return;
            }

            DescriptorMap map = ReadStruct<DescriptorMap>(descriptorBytes, Marshal.SizeOf(typeof(DescriptorHeader)));
            DescriptorRegions regions = ReadStruct<DescriptorRegions>(descriptorBytes, map.RegionBase << 4);

            uint biosBase, biosLimit, biosSize;
            uint meBase, meLimit, meSize;
            uint pdrBase, pdrLimit, pdrSize;

            ParseRegion(regions.BiosBase, regions.BiosLimit, sourcebuffer.Length, out biosBase, out biosLimit, out biosSize);
            ParseRegion(regions.MeBase, regions.MeLimit, sourcebuffer.Length, out meBase, out meLimit, out meSize);
            ParseRegion(regions.PdrBase, regions.PdrLimit, sourcebuffer.Length, out pdrBase, out pdrLimit, out pdrSize);

            BiosBase = biosBase;
            BiosLimit = biosLimit;
            BiosSize = biosSize;

            MeBase = meBase;
            MeLimit = meLimit;
            MeSize = meSize;

            PdrBase = pdrBase;
            PdrLimit = pdrLimit;
            PdrSize = pdrSize;

            return;
        }

        private static T ReadStruct<T>(byte[] source, int offset) where T : struct
        {
            byte[] structBytes = new byte[Marshal.SizeOf(typeof(T))];
            Array.Copy(source, offset, structBytes, 0, structBytes.Length);
            return MarshalHelper.ReadStruct<T>(structBytes);
        }

        private void ParseRegion(ushort baseposition, ushort limitposition, int sourcelength, out uint regionbase, out uint regionlimit, out uint regionlength)
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
    }
}