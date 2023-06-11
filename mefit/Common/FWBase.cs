// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FWBase.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0
// This is an unreferenced prototype / work-in-progress, I'm entirely unhappy
// with how FWParser.cs is going, this will replace it.

using Mac_EFI_Toolkit.Utils;
using System;
using System.Collections.Generic;
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

internal struct AppleRomInformationBase
{
    internal byte[] SectionBytes { get; set; }
    internal long SectionOffset { get; set; }
    internal string BiosId { get; set; }
    internal string Model { get; set; }
    internal string EfiVersion { get; set; }
    internal string BuiltBy { get; set; }
    internal string DateStamp { get; set; }
    internal string Revision { get; set; }
    internal string RomVersion { get; set; }
    internal string BuildcaveId { get; set; }
    internal string BuildType { get; set; }
    internal string Compiler { get; set; }

}
#endregion

namespace Mac_EFI_Toolkit.Common
{
    class FWBase
    {

        #region Internal Members
        internal static FsysRegionBase fsysStore;
        internal static AppleRomInformationBase romInfoStore;
        internal static byte[] loadedFileBytes = null;
        #endregion

        #region Private Members
        private const int _fsysMaxSize = 0x800;
        private static Encoding _utf8 = Encoding.UTF8;
        #endregion

        internal static void LoadFirmwareBaseData(byte[] sourceBytes)
        {
            fsysStore = GetFsysRegionData(sourceBytes);
            romInfoStore = GetRomInformationData(sourceBytes);
        }

        #region Fsys Region
        internal static FsysRegionBase GetFsysRegionData(byte[] sourceBytes)
        {
            string ssnString = null; long ssnPos = -1;
            string hwcString = null; long hwcPos = -1;
            string sonString = null; long sonPos = -1;

            // First we need to locate the NVRAM section GUID.
            long nvramPos = BinaryUtils.GetOffset(sourceBytes, FSGuids.NVRAM_DATA_GUID);
            if (nvramPos == -1)
            {
                // NVRAM store was not found so return default data
                return DefaultFsysRegionBase();
            }

            // Zero Vector length (10h) GUID length (10h) NVRAM section size data length (4h, int32)
            int zeroVecLen = 0x10; int guidLen = 0x10; int dataLen = 0x4;
            // Get NVRAM section size from header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, nvramPos + guidLen, dataLen);
            // Convert NVRAM section size to int32
            int nvramLen = BitConverter.ToInt32(dataLenBytes, 0); // NOTE: What if this value if 0xFF??
            // Search for the Fsys store within bounds of the NVRAM section
            long fsysPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG, nvramPos - zeroVecLen - guidLen, nvramLen);

            // Fsys store was not found within scope of the NVRAM section
            if (fsysPos == -1)
            {
                return DefaultFsysRegionBase();
            }

            // Get Fsys store bytes
            byte[] fsysData = BinaryUtils.GetBytesAtOffset(sourceBytes, fsysPos, _fsysMaxSize);

            if (fsysData != null && fsysData.Length == _fsysMaxSize)
            {
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
                        ssnString = _utf8.GetString(ssnData).Trim();
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
                        hwcString = _utf8.GetString(hwcBytes).Trim();
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
                        sonString = _utf8.GetString(sonBytes);
                        if (sonString.EndsWith("/")) sonString = sonString.TrimEnd('/');
                    }
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

        #region Apple ROM Information
        internal static AppleRomInformationBase GetRomInformationData(byte[] sourceBytes)
        {
            // Define index and termination bytes for data extraction
            byte indexByte = 0x20;
            byte terminationByte = 0x0A;

            // First we need to locate the AppleRomInformation section GUID
            long baseOffset = BinaryUtils.GetOffset(sourceBytes, FSGuids.APPLE_ROM_INFO_GUID);
            if (baseOffset == -1)
            {
                // AppleRomInformation GUID was not found, so return default data
                return DefaultRomInformationBase();
            }

            // GUID Length (10h) AppleRomInformation section size data length (2h, int16)
            int headerLen = 0x18; int dataLen = 0x2;
            // Read first two bytes after the header
            byte[] dataLenBytes = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLen, dataLen);
            // Convert first two bytes to an int16 value and get the AppleRomInformation section size
            int sectionLen = BitConverter.ToInt16(dataLenBytes, 0);
            // Read the entire AppleRomInformation section using sectionLen as the max search length
            byte[] romSectionData = BinaryUtils.GetBytesAtOffset(sourceBytes, baseOffset + headerLen, sectionLen);

            // Create a dictionary to hold signature-data pairs
            var romInfoData = new Dictionary<byte[], string>
            {
                { FSSignatures.BIOS_ID_SIGNATURE, null },
                { FSSignatures.MODEL_SIGNATURE, null },
                { FSSignatures.EFI_VERSION_SIGNATURE, null },
                { FSSignatures.BUILT_BY_SIGNATURE, null },
                { FSSignatures.DATE_SIGNATURE, null }
            };

            // Create a separate dictionary to store updated data
            var updatedRomInfoData = new Dictionary<byte[], string>(romInfoData);

            // Extract data from the romSectionData based on the signature
            foreach (var kvPair in romInfoData)
            {
                long dataPos = BinaryUtils.GetOffset(romSectionData, kvPair.Key);
                if (dataPos != -1)
                {
                    int sigLength = kvPair.Key.Length;
                    // Extract the data using the signature position, signature length, index byte, and termination byte
                    byte[] infoData = BinaryUtils.GetBytesAtOffsetByteDelimited(romSectionData, dataPos + sigLength, indexByte, terminationByte);
                    if (infoData != null)
                    {
                        // Convert the extracted byte array to string using UTF-8 encoding
                        updatedRomInfoData[kvPair.Key] = _utf8.GetString(infoData);
                    }
                }
            }

            // Update the original romInfoData dictionary with the extracted and updated values
            foreach (var kvPair in updatedRomInfoData)
            {
                romInfoData[kvPair.Key] = kvPair.Value;
            }

            // Create and return an instance of AppleRomInformationBase with the extracted data
            return new AppleRomInformationBase
            {
                SectionBytes = romSectionData,
                SectionOffset = baseOffset,
                BiosId = romInfoData[FSSignatures.BIOS_ID_SIGNATURE],
                Model = romInfoData[FSSignatures.MODEL_SIGNATURE],
                EfiVersion = romInfoData[FSSignatures.EFI_VERSION_SIGNATURE],
                BuiltBy = romInfoData[FSSignatures.BUILT_BY_SIGNATURE],
                DateStamp = romInfoData[FSSignatures.DATE_SIGNATURE]
                // TODO - Revision, Buildcave, BuildType, Compiler
            };
        }

        internal static AppleRomInformationBase DefaultRomInformationBase()
        {
            return new AppleRomInformationBase
            {
                SectionBytes = null,
                SectionOffset = -1,
                BiosId = null,
                Model = null,
                EfiVersion = null,
                BuiltBy = null,
                DateStamp = null,
                Revision = null,
                RomVersion = null,
                BuildcaveId = null,
                BuildType = null,
                Compiler = null
            };
        }
        #endregion

    }
}