// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// T2ROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.Tools.Structs;
using System;
using System.Diagnostics;
using System.Text;

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal class SOCROM
    {
        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBytes = null;
        internal static bool FirmwareLoaded = false;

        internal static string iBootVersion = null;
        internal static string ConfigCode = null;
        internal static Binary FileInfoData;
        internal static ScfgStore ScfgSectionData;

        internal const int SCFG_EXPECTED_BASE = 0x28A000;

        internal static TimeSpan tsParseTime { get; private set; }
        #endregion

        #region Private Members
        const int _serialLength = 12;
        private static readonly byte[] _limitChars = new byte[] { 0x00, 0x00, 0x00 };
        private static readonly Encoding _utf8 = Encoding.UTF8;
        #endregion

        #region Parse Fimware
        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            // Start bench.
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Parse file info.
            FileInfoData =
                FileTools.GetBinaryFileInfo
                (fileName);

            // Parse iBoot version.
            iBootVersion = GetIbootVersion(sourceBytes);

            // Parse Scfg Store data.
            ScfgSectionData = GetSCfgData(sourceBytes);

            // Fetch the Config Code.
            ConfigCode = ScfgSectionData.HWC != null
                ? MacTools.GetDeviceConfigCodeLocalLocal(ScfgSectionData.HWC)
                : null;

            stopwatch.Start();
            tsParseTime = stopwatch.Elapsed;
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
                BinaryTools.GetBaseAddress(
                    source,
                    IBOOT_VER_SIG,
                    0);

            return (ibootSig != -1);
        }
        #endregion

        #region IBoot
        internal static string GetIbootVersion(byte[] source)
        {
            int ibootSig =
                BinaryTools.GetBaseAddress(
                    source,
                    IBOOT_VER_SIG, 0);

            if (ibootSig != -1) // Signature found
            {
                // Get byte containing data length
                byte[] lByte =
                    BinaryTools.GetBytesBaseLength(
                    source,
                    ibootSig + IBOOT_VER_SIG.Length + 1,
                    1);

                // Convert data length to unsigned int8
                byte dataSize = (byte)lByte[0];

                // Get iboot version data bytes
                byte[] stringData =
                    BinaryTools.GetBytesBaseLength(
                        source,
                        ibootSig + 0x6,
                        dataSize);

                return _utf8.GetString(stringData);
            }

            return APPSTRINGS.UNKNOWN;
        }
        #endregion

        #region SCfg
        internal static ScfgStore GetSCfgData(byte[] source)
        {
            int scfgBase =
                BinaryTools.GetBaseAddress(
                    source,
                    SCFG_HEADER_SIG);

            if (scfgBase == -1)
                return DefaultScfgData();

            byte dataSize =
                BinaryTools.GetBytesBaseLength(
                    source,
                    scfgBase + SCFG_HEADER_SIG.Length, 1)[0];

            if (dataSize == 0)
                return DefaultScfgData();

            byte[] scfgBytes =
                BinaryTools.GetBytesBaseLength(
                    source,
                    scfgBase,
                    dataSize);

            if (scfgBytes == null)
                return DefaultScfgData();

            string crc =
                $"{FileTools.GetCrc32Digest(scfgBytes):X8}";

            string serial =
                GetStringFromSig(
                    scfgBytes,
                    SCFG_SSN_SIG,
                    _serialLength,
                    out string hwc);

            string son =
                GetStringFromSigWithLimit(
                    scfgBytes,
                    SCFG_SON_SIG,
                    _limitChars);

            string regno =
                GetStringFromSigWithLimit(
                    scfgBytes,
                    SCFG_SON_REGN,
                    _limitChars);

            return new ScfgStore
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
                BinaryTools.GetBaseAddress(
                    scfgBytes,
                    sig);

            if (baseAddress == -1)
                return null;

            byte[] bytes =
                BinaryTools.GetBytesBaseLength(
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
                BinaryTools.GetBaseAddress(
                    scfgBytes,
                    sig);

            if (baseAddress == -1)
                return null;

            baseAddress += sig.Length;

            int limit =
                BinaryTools.GetBaseAddress
                (scfgBytes,
                limitChars,
                baseAddress);

            if (limit == -1)
                return null;

            byte[] bytes =
                BinaryTools.GetBytesBaseLimit(
                    scfgBytes,
                    baseAddress,
                    limit);

            return _utf8.GetString(bytes);
        }

        private static ScfgStore DefaultScfgData()
        {
            return new ScfgStore
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

        internal static readonly byte[] IBOOT_VER_SIG = // iBoot version signature, byte 5 is validity byte?, byte 6 is var size.
{
            0x69, 0x6C, 0X6C, 0X62
        };

        internal static readonly byte[] SCFG_HEADER_SIG = // Header
        {
            0x67, 0x66, 0x43, 0x53
        };

        internal static readonly byte[] SCFG_SSN_SIG = // System Serial Number
        {
            0x6D, 0x4E, 0x72, 0x53
        };

        internal static readonly byte[] SCFG_SON_SIG = // System Order Number
        {
            0x23, 0x64, 0x6F, 0x4D
        };

        internal static readonly byte[] SCFG_SON_REGN = // Registration Number?
        {
            0x6E, 0x67, 0x65, 0x52
        };
        #endregion
    }
}