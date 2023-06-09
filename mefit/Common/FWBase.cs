// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWBase.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0
// This is an unreferenced prototype / work-in-progress, I'm entirely unhappy
// with how FWParser.cs is going, this will replace it.

using Mac_EFI_Toolkit.Utils;
using System;

internal struct FsysRegionBase
{
    internal byte[] FsysBytes { get; set; }
    internal long FsysOffset { get; set; }
    internal string Serial { get; set; }
    internal long SerialOffset { get; set; }
    internal string HWC { get; set; }
    internal long HWCOffset { get; set; }
    internal string SON { get; set; }
    internal long SONOffset { get; set; }
}

namespace Mac_EFI_Toolkit.Common
{
    class FWBase
    {
        private const int _fsysMaxSize = 0x800;

        internal static FsysRegionBase GetFsysRegionData(byte[] sourceBytes)
        {
            // First we need to locate the NVRAM section GUID.
            long lNvramPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_DATA_GUID);

            // NVRAM section was not located
            if (lNvramPos == -1)
            {
                return DefaultFsysRegionBase();
            }

            // Zero Vector length (10h) Signature length (10h) NVRAM section length (4h)
            int zeroVecLen = 0x10; int sigGuidLen = 0x10; int dataLen = 0x4;
            // Get NVRAM section size from header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, lNvramPos + sigGuidLen, dataLen);
            // Convert NVRAM section size to int32
            int nvramLen = BitConverter.ToInt32(dataLenBytes, 0); // NOTE: What if this value if 0xFF??
            // Search for the Fsys store within bounds of the NVRAM section
            long lFsysPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG, lNvramPos - zeroVecLen - sigGuidLen, nvramLen);

            // Fsys store was not found within scope of the NVRAM section
            if (lFsysPos == -1)
            {
                return DefaultFsysRegionBase();
            }

            // Get data
            byte[] fsysStore = BinaryUtils.GetBytesAtOffset(sourceBytes, lFsysPos, _fsysMaxSize);

            // Fetch other data

            return new FsysRegionBase
            {
                FsysBytes = fsysStore,
                FsysOffset = lFsysPos
                // Fetch other data 
            };
        }

        internal static FsysRegionBase DefaultFsysRegionBase()
        {
            return new FsysRegionBase
            {
                FsysBytes = null,
                FsysOffset = -1,
                Serial = null,
                SerialOffset = -1,
                HWC = null,
                HWCOffset = -1,
                SON = null,
                SONOffset = -1
            };
        }

    }
}
