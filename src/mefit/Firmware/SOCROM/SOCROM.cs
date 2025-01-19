// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using System;
using System.Diagnostics;
using System.Text;

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal class SOCROM
    {
        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBuffer = null;
        internal static SocRomType RomType;
        internal static bool FirmwareLoaded = false;
        internal static string iBootVersion = null;
        internal static string ConfigCode = null;
        internal static string NewSerial = null;

        internal static FileInfoStore FileInfoData;
        internal static SCfgStore SCfgSectionData;

        internal const int SCFG_EXPECTED_BASE = 0x28A000;
        internal const int SCFG_EXPECTED_LENGTH = 0xB8;
        internal const int SERIAL_LENGTH = 12;

        internal static TimeSpan ParseTime { get; private set; }
        #endregion

        #region Private Members
        private static readonly byte[] _limitChars = new byte[] { 0x00, 0x00, 0x00 };
        private static readonly Encoding _utf8encoding = Encoding.UTF8;
        internal const int _serialLength = 12;
        internal const int _absoluteRomBase = 0x0;
        internal const int _siliconRomBase = 0x20000;
        #endregion

        #region Parse Fimware
        internal static void LoadFirmwareBaseData(byte[] sourcebuffer, string filename)
        {
            // Start bench.
            Stopwatch swParseTime = Stopwatch.StartNew();

            // Parse file info.
            FileInfoData = FileTools.GetBinaryFileInfo(filename);

            // Parse iBoot version.
            iBootVersion = GetIbootVersion(sourcebuffer);

            // Parse Scfg Store data.
            SCfgSectionData = GetSCfgData(sourcebuffer, false);

            // Fetch the Config Code.
            ConfigCode = SCfgSectionData.HWC != null ? MacTools.GetDeviceConfigCodeLocal(SCfgSectionData.HWC) : null;

            swParseTime.Start();
            ParseTime = swParseTime.Elapsed;
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBuffer = null;
            RomType = default;
            FirmwareLoaded = false;
            FileInfoData = default;
            iBootVersion = null;
            ConfigCode = null;
            NewSerial = null;
            SCfgSectionData = default;
        }

        internal static bool IsValidImage(byte[] sourceBuffer)
        {
            // Check for ROM signature at 0x0h (T2ROM).
            byte[] bT2RomSignature = BinaryTools.GetBytesBaseLength(sourceBuffer, _absoluteRomBase, SOCSigs.SocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(bT2RomSignature, SOCSigs.SocRomMarker))
            {
                RomType = SocRomType.T2;
                return true;
            }

            // Check Apple Silicon HUFA signature.
            byte[] bAppleSiliconHufaSignature = BinaryTools.GetBytesBaseLength(sourceBuffer, _absoluteRomBase, SOCSigs.AppleSiliconSocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(bAppleSiliconHufaSignature, SOCSigs.AppleSiliconSocRomMarker))
            {
                // Check SOCROM marker at a 0x20000h.
                byte[] bSocRomSignature = BinaryTools.GetBytesBaseLength(sourceBuffer, _siliconRomBase, SOCSigs.SocRomMarker.Length);
                if (BinaryTools.ByteArraysMatch(bSocRomSignature, SOCSigs.SocRomMarker))
                {
                    RomType = SocRomType.AppleSilicon;
                    return true;
                }
            }

            // No valid signature found.
            return false;
        }
        #endregion

        #region IBoot
        internal static string GetIbootVersion(byte[] sourcebytes)
        {
            int iIbootBase = BinaryTools.GetBaseAddress(sourcebytes, SOCSigs.iBootMarker, 0);
            int iDataStart = 0x6;

            if (iIbootBase != -1) // Signature found.
            {
                // Get byte containing data length.
                byte[] bLength = BinaryTools.GetBytesBaseLength(sourcebytes, iIbootBase + SOCSigs.iBootMarker.Length + 1, 1);
                // Convert data length to unsigned int8.
                byte iLength = (byte)bLength[0];
                // Get iboot version data bytes.
                byte[] strIboot = BinaryTools.GetBytesBaseLength(sourcebytes, iIbootBase + iDataStart, iLength);

                return _utf8encoding.GetString(strIboot);
            }

            return APPSTRINGS.UNKNOWN;
        }
        #endregion

        #region SCfg Store
        internal static SCfgStore GetSCfgData(byte[] sourcebuffer, bool isscfgonly)
        {
            int iScfgBase = FindScfgBaseAddress(sourcebuffer, isscfgonly);

            if (iScfgBase == -1)
            {
                return DefaultScfgData();
            }

            byte bLength = BinaryTools.GetBytesBaseLength(sourcebuffer, iScfgBase + SOCSigs.ScfgHeaderMarker.Length, 1)[0];

            if (bLength == 0)
            {
                return DefaultScfgData();
            }

            byte[] bScfgBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, iScfgBase, bLength);

            if (bScfgBuffer == null)
            {
                return DefaultScfgData();
            }

            int iSerialBase = BinaryTools.GetBaseAddress(sourcebuffer, SOCSigs.ScfgSerialMarker) + SOCSigs.ScfgSerialMarker.Length;

            string strSerial = GetStringFromSig(bScfgBuffer, SOCSigs.ScfgSerialMarker, _serialLength, out string hwc);
            string strSystemOrderNumber = GetStringFromSigWithLimit(bScfgBuffer, SOCSigs.ScfgSonMarker, _limitChars);
            string strRegistrationNumber = GetStringFromSigWithLimit(bScfgBuffer, SOCSigs.ScfgRegnMarker, _limitChars);
            string strCrc32 = $"{FileTools.GetCrc32Digest(bScfgBuffer):X8}";

            return new SCfgStore
            {
                StoreBase = iScfgBase,
                StoreLength = bLength,
                StoreBuffer = bScfgBuffer,
                Serial = strSerial,
                SerialBase = iSerialBase,
                HWC = hwc,
                SON = strSystemOrderNumber,
                StoreCRC = strCrc32,
                MdlC = null,
                RegNumText = strRegistrationNumber
            };
        }

        private static int FindScfgBaseAddress(byte[] sourcebuffer, bool isscfgonly)
        {
            if (isscfgonly)
            {
                return 0;
            }

            return BinaryTools.GetBaseAddress(sourcebuffer, SOCSigs.ScfgHeaderMarker);
        }

        private static string GetStringFromSig(byte[] sourcebuffer, byte[] marker, int expectedlength, out string hwc)
        {
            hwc = null;

            int iBase = BinaryTools.GetBaseAddress(sourcebuffer, marker);

            if (iBase == -1)
            {
                return null;
            }

            byte[] bDataBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, iBase + marker.Length, expectedlength);

            if (bDataBuffer?.Length != expectedlength)
            {
                return null;
            }

            string strSerial = _utf8encoding.GetString(bDataBuffer);

            hwc = strSerial.Length >= 4 ? strSerial.Substring(strSerial.Length - 4, 4) : null;

            return strSerial;
        }

        private static string GetStringFromSigWithLimit(byte[] sourcebuffer, byte[] marker, byte[] limitchars)
        {
            int iBase = BinaryTools.GetBaseAddress(sourcebuffer, marker);

            if (iBase == -1)
            {
                return null;
            }

            iBase += marker.Length;

            int iLimit = BinaryTools.GetBaseAddress(sourcebuffer, limitchars, iBase);

            if (iLimit == -1)
            {
                return null;
            }

            byte[] bOutput = BinaryTools.GetBytesBaseLimit(sourcebuffer, iBase, iLimit);

            return _utf8encoding.GetString(bOutput);
        }

        private static SCfgStore DefaultScfgData()
        {
            return new SCfgStore
            {
                StoreBase = -1,
                StoreLength = 0,
                StoreBuffer = null,
                StoreCRC = null,
                Serial = null,
                HWC = null,
                SON = null,
                MdlC = null,
                RegNumText = null
            };
        }
        #endregion
    }
}