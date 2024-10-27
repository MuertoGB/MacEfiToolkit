// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// T2ROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.Utils.Structs;
using System.Text;

namespace Mac_EFI_Toolkit.Firmware.T2
{
    internal class T2ROM
    {

        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBytes = null;
        internal static bool FirmwareLoaded = false;

        internal static string iBootVersion = null;
        internal static string ConfigCode = null;
        internal static Binary FileInfoData;
        internal static SCfgData ScfgSectionData;
        #endregion

        #region Private Members
        const int _serialLength = 12;
        private static readonly byte[] _limitChars = new byte[] { 0x00, 0x00, 0x00 };
        private static readonly Encoding _utf8 = Encoding.UTF8;
        #endregion

        #region Parse Fimware
        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            // Parse file info
            FileInfoData =
                FileUtils.GetBinaryFileInfo
                (fileName);

            // Parse iBoot version
            iBootVersion = GetIbootVersion(sourceBytes);

            // Parse Scfg Store data
            ScfgSectionData = GetSCfgData(sourceBytes);

            // Fetch the Config Code
            ConfigCode = ScfgSectionData.HWC != null
                ? MacUtils.GetDeviceConfigCodeLocalLocal(ScfgSectionData.HWC)
                : null;
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBytes = null;
            FirmwareLoaded = false;
            FileInfoData = default;
            iBootVersion = null;
            ConfigCode = null;
            ScfgSectionData = default;
        }

        internal static bool IsValidImage(byte[] source)
        {
            int ibootSig =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.IBOOT_VER_SIG,
                    0);

            return (ibootSig != -1);
        }
        #endregion

        #region IBoot
        internal static string GetIbootVersion(byte[] source)
        {
            int ibootSig =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.IBOOT_VER_SIG, 0);

            if (ibootSig != -1) // Signature found
            {
                // Get byte containing data length
                byte[] lByte =
                    BinaryUtils.GetBytesBaseLength(
                    source,
                    ibootSig + ROMSigs.IBOOT_VER_SIG.Length + 1,
                    1);

                // Convert data length to unsigned int8
                byte dataSize = (byte)lByte[0];

                // Get iboot version data bytes
                byte[] stringData =
                    BinaryUtils.GetBytesBaseLength(
                        source,
                        ibootSig + 0x6,
                        dataSize);

                return _utf8.GetString(stringData);
            }

            return AppStrings.S_UNKNOWN;
        }
        #endregion

        #region SCfg
        internal static SCfgData GetSCfgData(byte[] source)
        {
            int scfgBase =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.SCFG_HEADER_SIG);

            if (scfgBase == -1)
                return DefaultScfgData();

            byte dataSize =
                BinaryUtils.GetBytesBaseLength(
                    source,
                    scfgBase + ROMSigs.SCFG_HEADER_SIG.Length, 1)[0];

            if (dataSize == 0)
                return DefaultScfgData();

            byte[] scfgBytes =
                BinaryUtils.GetBytesBaseLength(
                    source,
                    scfgBase,
                    dataSize);

            if (scfgBytes == null)
                return DefaultScfgData();

            string crc =
                $"{FileUtils.GetCrc32Digest(scfgBytes):X8}";

            string serial =
                GetStringFromSig(
                    scfgBytes,
                    ROMSigs.SCFG_SSN_SIG,
                    _serialLength,
                    out string hwc);

            string son =
                GetStringFromSigWithLimit(
                    scfgBytes,
                    ROMSigs.SCFG_SON_SIG,
                    _limitChars);

            string regno =
                GetStringFromSigWithLimit(
                    scfgBytes,
                    ROMSigs.SCFG_SON_REGN,
                    _limitChars);

            return new SCfgData
            {
                StoreBase = scfgBase,
                StoreSize = dataSize,
                ScfgBytes = scfgBytes,
                ScfgCrc = crc,
                SerialText = serial,
                HWC = hwc,
                SonText = son,
                MdlC = null,
                RegNumText = regno
            };
        }

        private static string GetStringFromSig(byte[] scfgBytes, byte[] sig, int expectedLength, out string hwc)
        {
            hwc = null;

            int baseAddress =
                BinaryUtils.GetBaseAddress(
                    scfgBytes,
                    sig);

            if (baseAddress == -1)
                return null;

            byte[] bytes =
                BinaryUtils.GetBytesBaseLength(
                    scfgBytes,
                    baseAddress + sig.Length,
                    expectedLength);

            if (bytes?.Length != expectedLength)
                return null;

            string serial =
                _utf8.GetString(bytes);

            hwc =
                serial.Length >= 4 ?
                serial.Substring(serial.Length - 4, 4)
                : null;

            return serial;
        }

        private static string GetStringFromSigWithLimit(byte[] scfgBytes, byte[] sig, byte[] limitChars)
        {
            int baseAddress =
                BinaryUtils.GetBaseAddress(
                    scfgBytes,
                    sig);

            if (baseAddress == -1)
                return null;

            baseAddress += sig.Length;

            int limit =
                BinaryUtils.GetBaseAddress
                (scfgBytes,
                limitChars,
                baseAddress);

            if (limit == -1)
                return null;

            byte[] bytes =
                BinaryUtils.GetBytesBaseLimit(
                    scfgBytes,
                    baseAddress,
                    limit);

            return _utf8.GetString(bytes);
        }

        private static SCfgData DefaultScfgData()
        {
            return new SCfgData
            {
                StoreBase = -1,
                StoreSize = 0,
                ScfgBytes = null,
                ScfgCrc = null,
                SerialText = null,
                HWC = null,
                SonText = null,
                MdlC = null,
                RegNumText = null
            };
        }
        #endregion

    }
}