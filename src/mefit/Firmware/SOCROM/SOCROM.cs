// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
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
        public ControllerType Controller { get; private set; }
        public bool FirmwareLoaded { get; set; }
        public string iBootVersion { get; private set; }
        public string ConfigCode { get; set; }
        public string NewSerial { get; set; }
        public FirmwareFile.Information FirmwareInfo { get; private set; }
        public SCfgStore SCfg { get; private set; }

        public TimeSpan ParseTime { get; private set; }
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
            Stopwatch parseTimer = Stopwatch.StartNew();

            // Parse file info.
            FirmwareInfo = FirmwareFile.GetFileInfo(filename);

            // Parse iBoot version.
            iBootVersion = GetiBootVersion(sourcebuffer);

            // Parse Scfg Store data.
            SCfg = ParseSCfgStoreData(sourcebuffer, false);

            // Fetch the Config Code.
            ConfigCode = SCfg.HWC != null ? MacTools.GetDeviceConfigCodeLocal(SCfg.HWC) : null;

            parseTimer.Start();
            ParseTime = parseTimer.Elapsed;
        }

        public bool IsValidImage(byte[] sourcebuffer)
        {
            // Check for ROM signature at 0x0h (T2ROM).
            byte[] signature = BinaryTools.GetBytesBaseLength(sourcebuffer, T2_ROM_BASE, Signatures.SocRom.SocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(signature, Signatures.SocRom.SocRomMarker))
            {
                Controller = ControllerType.AppleT2;
                return true;
            }

            // Check Apple Silicon HUFA signature.
            byte[] hufaSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, T2_ROM_BASE, Signatures.SocRom.AppleSiliconSocRomMarker.Length);

            if (BinaryTools.ByteArraysMatch(hufaSignature, Signatures.SocRom.AppleSiliconSocRomMarker))
            {
                // Check SOCROM marker at a 0x20000h.
                byte[] romSignature = BinaryTools.GetBytesBaseLength(sourcebuffer, SILICON_ROM_BASE, Signatures.SocRom.SocRomMarker.Length);

                if (BinaryTools.ByteArraysMatch(romSignature, Signatures.SocRom.SocRomMarker))
                {
                    Controller = ControllerType.AppleSilicon;
                    return true;
                }
            }

            // No valid signature found.
            return false;
        }

        public void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            iBootVersion = null;
            ConfigCode = null;
            NewSerial = null;
            LoadedBinaryBuffer = null;
            FirmwareLoaded = false;
            FirmwareInfo = new FirmwareFile.Information();
            SCfg = new SCfgStore();
            Controller = new ControllerType();
            ParseTime = TimeSpan.Zero;
        }
        #endregion

        #region IBoot
        public string GetiBootVersion(byte[] sourcebytes)
        {
            int ibootBase = BinaryTools.GetBaseAddress(sourcebytes, Signatures.IBoot.iBootMarker, 0);
            const int dataStart = 0x6;

            if (ibootBase != -1) // Signature found.
            {
                // Get byte containing data length.
                byte[] lengthBuffer = BinaryTools.GetBytesBaseLength(sourcebytes, ibootBase + Signatures.IBoot.iBootMarker.Length + 1, 1);
                // Convert data length to unsigned int8.
                byte length = (byte)lengthBuffer[0];
                // Fix invalid length byte.
                if (length <= 0x0 || length >= 0x20) // Too short / Too long
                {
                    return AppStrings.UNKNOWN;
                }

                byte[] ibootBytes = BinaryTools.GetBytesBaseLength(sourcebytes, ibootBase + dataStart, length);

                return _utf8encoding.GetString(ibootBytes);
            }

            return AppStrings.UNKNOWN;
        }
        #endregion

        #region SCfg Store
        public SCfgStore ParseSCfgStoreData(byte[] sourcebuffer, bool isscfgonly)
        {
            int scfgBase = FindScfgBaseAddress(sourcebuffer, isscfgonly);

            if (scfgBase == -1)
            {
                return DefaultScfgData();
            }

            byte storeLength = BinaryTools.GetBytesBaseLength(sourcebuffer, scfgBase + Signatures.Scfg.HeaderMarker.Length, 1)[0];

            if (storeLength == 0)
            {
                return DefaultScfgData();
            }

            byte[] scfgBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, scfgBase, storeLength);

            if (scfgBuffer == null)
            {
                return DefaultScfgData();
            }

            int serialBase = BinaryTools.GetBaseAddress(sourcebuffer, Signatures.Scfg.SerialMarker) + Signatures.Scfg.SerialMarker.Length;

            string serialString = GetStringFromSig(scfgBuffer, Signatures.Scfg.SerialMarker, SERIAL_LENGTH, out string hwcString);
            string sonString = GetStringFromSigWithLimit(scfgBuffer, Signatures.Scfg.SonMarker, _limitChars);
            string regString = GetStringFromSigWithLimit(scfgBuffer, Signatures.Scfg.RegNoMarker, _limitChars);
            string crcString = $"{Cryptography.GetCrc32Digest(scfgBuffer):X8}";

            return new SCfgStore
            {
                StoreBase = scfgBase,
                StoreLength = storeLength,
                StoreBuffer = scfgBuffer,
                Serial = serialString,
                SerialBase = serialBase,
                HWC = hwcString,
                SON = sonString,
                StoreCRC = crcString,
                MdlC = null,
                RegNum = regString
            };
        }

        private int FindScfgBaseAddress(byte[] sourcebuffer, bool isscfgonly)
        {
            if (isscfgonly)
            {
                return 0;
            }

            return BinaryTools.GetBaseAddress(sourcebuffer, Signatures.Scfg.HeaderMarker);
        }

        private string GetStringFromSig(byte[] sourcebuffer, byte[] marker, int expectedlength, out string hwc)
        {
            hwc = null;

            int markerBase = BinaryTools.GetBaseAddress(sourcebuffer, marker);

            if (markerBase == -1)
            {
                return null;
            }

            byte[] dataBuffer = BinaryTools.GetBytesBaseLength(sourcebuffer, markerBase + marker.Length, expectedlength);

            if (dataBuffer?.Length != expectedlength)
            {
                return null;
            }

            string serialString = _utf8encoding.GetString(dataBuffer);
            hwc = serialString.Length >= 4 ? serialString.Substring(serialString.Length - 4, 4) : null;

            return serialString;
        }

        private string GetStringFromSigWithLimit(byte[] sourcebuffer, byte[] marker, byte[] limitchars)
        {
            int markerBase = BinaryTools.GetBaseAddress(sourcebuffer, marker);

            if (markerBase == -1)
            {
                return null;
            }

            markerBase += marker.Length;

            int markerLimit = BinaryTools.GetBaseAddress(sourcebuffer, limitchars, markerBase);

            if (markerLimit == -1)
            {
                return null;
            }

            byte[] outputBuffer = BinaryTools.GetBytesBaseLimit(sourcebuffer, markerBase, markerLimit);

            return _utf8encoding.GetString(outputBuffer);
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
                RegNum = null
            };
        }
        #endregion
    }
}