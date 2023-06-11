// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWBase.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0
// This is an unreferenced prototype / work-in-progress, I'm entirely unhappy
// with how FWParser.cs is going, this will replace it.

using Mac_EFI_Toolkit.Utils;
using System;
using System.Linq;
using System.Text;

#region Structs
internal struct FsysRegionBase
{
    internal byte[] FsysBytes { get; set; }
    internal long FsysOffset { get; set; }
    internal string FsysSerial { get; set; }
    internal long SerialOffset { get; set; }
    internal string FsysHWC { get; set; }
    internal long HWCOffset { get; set; }
    internal string FsysSON { get; set; }
    internal long SONOffset { get; set; }
}

internal struct RomInformationBase
{
    internal string AppledRomVersion { get; set; }
    internal string BiosId { get; set; }
    internal string BuiltBy { get; set; }
    internal string DateStamp { get; set; }
    internal string Revision { get; set; }
    internal string BuildcaveId { get; set; }
    internal string RomVersion { get; set; }
}

internal struct PlatformDataRegionBase
{
    internal string BoardId { get; set; }
}
#endregion

namespace Mac_EFI_Toolkit.Common
{
    class FWBase
    {

        #region Internal Members
        internal static FsysRegionBase fsysStore;
        internal static byte[] loadedFileBytes = null;
        #endregion

        #region Private Members
        private const int _fsysMaxSize = 0x800;
        #endregion

        internal static void LoadFirmwareBaseData(byte[] sourceBytes)
        {
            fsysStore = GetFsysRegionData(sourceBytes);
        }

        #region Fsys Base
        internal static FsysRegionBase GetFsysRegionData(byte[] sourceBytes)
        {
            var utf8 = Encoding.UTF8;
            string ssnString = null; long ssnPos = -1;
            string hwcString = null; long hwcPos = -1;
            string sonString = null; long sonPos = -1;

            // First we need to locate the NVRAM section GUID.
            long nvramPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_DATA_GUID);
            if (nvramPos == -1)
            {
                // NVRAM store was not found so no point to continue
                return DefaultFsysRegionBase();
            }

            // Zero Vector length (10h) Signature length (10h) NVRAM section length (4h)
            int zeroVecLen = 0x10; int sigGuidLen = 0x10; int dataLen = 0x4;
            // Get NVRAM section size from header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, nvramPos + sigGuidLen, dataLen);
            // Convert NVRAM section size to int32
            int nvramLen = BitConverter.ToInt32(dataLenBytes, 0); // NOTE: What if this value if 0xFF??
            // Search for the Fsys store within bounds of the NVRAM section
            long fsysPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG, nvramPos - zeroVecLen - sigGuidLen, nvramLen);

            // Fsys store was not found within scope of the NVRAM section
            if (fsysPos == -1)
            {
                return DefaultFsysRegionBase();
            }

            // Get Fsys store bytes
            byte[] fsysData = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysPos, _fsysMaxSize);

            // Serial + Offset
            ssnPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SSN_UPPER_SIG);
            if (ssnPos == -1)
            {
                // Find lower case ssn signature
                ssnPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SSN_LOWER_SIG);
            }
            if (ssnPos != -1)
            {
                int dataStartPos = 0x05; int ssnDatLen = 0x0C;
                byte[] ssnData = BinaryUtils.GetBytesAtOffset(sourceBytes, ssnPos + dataStartPos, ssnDatLen);
                if (ssnData != null)
                {
                    ssnString = utf8.GetString(ssnData).Trim();
                    ssnString = new string(ssnString.Where(char.IsLetterOrDigit).ToArray());
                }
            }

            // Hardware Config + Offset
            hwcPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.HWC_SIG);
            if (hwcPos != -1)
            {
                var hwcStartPos = 0x06; var hwcReadLen = 0x04;
                byte[] hwcBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, hwcPos + hwcStartPos, hwcReadLen);

                if (hwcBytes != null)
                {
                    hwcString = utf8.GetString(hwcBytes).Trim();
                    hwcString = new string(hwcString.Where(char.IsLetterOrDigit).ToArray());
                }
            }

            // System order number + Offset
            sonPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.SON_SIG);
            if (sonPos != -1)
            {
                byte indexByte = 0x00;
                byte[] terminationBytes = { 0x03, 0x04, 0x09 };
                byte[] sonBytes = BinaryUtils.GetBytesAtOffsetByteDelimited(sourceBytes, sonPos, indexByte, terminationBytes);

                if (sonBytes != null)
                {
                    sonString = utf8.GetString(sonBytes);
                    if (sonString.EndsWith("/")) sonString = sonString.TrimEnd('/');
                }
            }

            return new FsysRegionBase
            {
                FsysBytes = fsysData,
                FsysOffset = fsysPos,
                FsysSerial = ssnString,
                SerialOffset = ssnPos,
                FsysHWC = hwcString,
                HWCOffset = hwcPos,
                FsysSON = sonString,
                SONOffset = sonPos
            };
        }

        internal static FsysRegionBase DefaultFsysRegionBase()
        {
            return new FsysRegionBase
            {
                FsysBytes = null,
                FsysOffset = -1,
                FsysSerial = null,
                SerialOffset = -1,
                FsysHWC = null,
                HWCOffset = -1,
                FsysSON = null,
                SONOffset = -1
            };
        }
        #endregion

    }
}