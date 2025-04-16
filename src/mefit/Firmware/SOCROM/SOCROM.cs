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
    public class SOCROM
    {
        #region Public Members
        public string LoadedBinaryPath { get; set; }
        public byte[] LoadedBinaryBuffer { get; set; }
        public SocRomType RomType { get; set; }
        public bool FirmwareLoaded { get; set; }
        public string iBootVersion { get; set; }
        public string ConfigCode { get; set; }
        public string NewSerial { get; set; }
        public FileInfoStore FileInfoData { get; set; }
        public SCfgStore SCfgSectionData { get; set; }

        public static TimeSpan ParseTime { get; private set; }
        #endregion

        #region Const Members
        public const int SCFG_EXPECTED_BASE = 0x28A000;
        public const int SERIAL_LENGTH = 12;
        public const int T2_ROM_BASE = 0x0;
        public const int SILICON_ROM_BASE = 0x20000;
        #endregion

        #region Private Members
        private static readonly byte[] _limitChars = new byte[] { 0x00, 0x00, 0x00 };
        private static readonly Encoding _utf8encoding = Encoding.UTF8;
        #endregion

        #region Parse Fimware
        public void LoadFirmwareBaseData(byte[] sourcebuffer, string filename)
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

        public bool IsValidImage(byte[] sourcebuffer)
        {
            // Check for ROM signature at 0x0h (T2ROM).
            byte[] bT2RomSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, T2_ROM_BASE, SOCSigs.SocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(bT2RomSignature, SOCSigs.SocRomMarker))
            {
                RomType = SocRomType.AppleT2;
                return true;
            }

            // Check Apple Silicon HUFA signature.
            byte[] bAppleSiliconHufaSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, T2_ROM_BASE, SOCSigs.AppleSiliconSocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(bAppleSiliconHufaSignature, SOCSigs.AppleSiliconSocRomMarker))
            {
                // Check SOCROM marker at a 0x20000h.
                byte[] bSocRomSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, SILICON_ROM_BASE, SOCSigs.SocRomMarker.Length);
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
        public string GetIbootVersion(byte[] sourcebytes)
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

                // Fix invalid length byte.
                if (iLength <= 0x0 || iLength >= 0x20) // Too short / Too long
                {
                    return APPSTRINGS.UNKNOWN;
                }

                byte[] strIboot = BinaryTools.GetBytesBaseLength(sourcebytes, iIbootBase + iDataStart, iLength);

                return _utf8encoding.GetString(strIboot);
            }

            return APPSTRINGS.UNKNOWN;
        }
        #endregion

        #region SCfg Store
        public SCfgStore GetSCfgData(byte[] sourcebuffer, bool isscfgonly)
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

            string strSerial = GetStringFromSig(bScfgBuffer, SOCSigs.ScfgSerialMarker, SERIAL_LENGTH, out string hwc);
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

        private int FindScfgBaseAddress(byte[] sourcebuffer, bool isscfgonly)
        {
            if (isscfgonly)
            {
                return 0;
            }

            return BinaryTools.GetBaseAddress(sourcebuffer, SOCSigs.ScfgHeaderMarker);
        }

        private string GetStringFromSig(byte[] sourcebuffer, byte[] marker, int expectedlength, out string hwc)
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

        private string GetStringFromSigWithLimit(byte[] sourcebuffer, byte[] marker, byte[] limitchars)
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

        private SCfgStore DefaultScfgData()
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