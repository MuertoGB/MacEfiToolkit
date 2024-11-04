// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MacTools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Tools
{
    class MacTools
    {
        #region Configuation Code
        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier from the internal db. 
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        internal static string GetDeviceConfigCodeLocalLocal(string hwc)
        {
            try
            {
                // Attempt to load the data from the embedded XML db.
                byte[] xmlData =
                    Encoding.UTF8.GetBytes(
                        Properties.Resources.modeldb);

                using (MemoryStream stream = new MemoryStream(xmlData))
                {
                    XDocument xmlDoc =
                        XDocument.Load(
                            stream);

                    string name = xmlDoc.Descendants(
                        "section").FirstOrDefault(e => e.Element(
                            "hwc")?.Value == hwc)?.Element(
                                "configCode")?.Value;

                    if (!string.IsNullOrEmpty(name))
                        return name;
                }

                return null;
            }
            catch (Exception e)
            {
                Logger.WriteError(nameof(GetDeviceConfigCodeLocalLocal), e.GetType(), e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier from Apple's support-sp server.
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        internal static async Task<string> GetDeviceConfigCodeSupportRemote(string hwc)
        {
            try
            {
                // Retrieve data from Apple's server
                string url = $"http://support-sp.apple.com/sp/product?cc={hwc}&lang=en_GB";

                if (!NetworkTools.IsWebsiteAvailable(url))
                    return null;

                string xml = await new WebClient().DownloadStringTaskAsync(url);

                XDocument doc =
                    XDocument.Parse(
                        xml);

                string data =
                    doc.XPathSelectElement(
                        "/root/configCode")?.Value;

                if (!string.IsNullOrEmpty(data))
                    Logger.Write(
                        $"'{hwc}' not present in local db > support-sp server returned: '{data}'", LogType.Database);

                return string.IsNullOrEmpty(data)
                    ? null
                    : data;
            }
            catch (Exception e)
            {
                Logger.WriteError(nameof(GetDeviceConfigCodeSupportRemote), e.GetType(), e.Message);
                return null;
            }
        }
        #endregion

        #region Fsys CRC32 Calculation
        /// <summary>
        /// Calculates an Fsys region CRC32 checksum.
        /// </summary>
        /// /// <param name="fsysStore">The Fsys region to calcuate the CRC32 for.</param>
        /// <returns>The calculated Fsys CRC32 uint</returns>
        internal static uint GetUintFsysCrc32(byte[] fsysStore)
        {
            if (fsysStore.Length < EFIROM.FSYS_RGN_SIZE)
                throw new ArgumentException(
                    nameof(fsysStore),
                    "Given bytes are too small.");

            if (fsysStore.Length > EFIROM.FSYS_RGN_SIZE)
                throw new ArgumentException(
                    nameof(fsysStore),
                    "Given bytes are too large.");

            // Data we calculate is: Fsys Base + Fsys Size - CRC32 length of 4 bytes.
            byte[] bytesTempFsys = new byte[EFIROM.FSYS_RGN_SIZE - EFIROM.CRC32_SIZE];

            if (fsysStore != null)
            {
                Array.Copy(
                    fsysStore,
                    0,
                    bytesTempFsys,
                    0,
                    bytesTempFsys.Length);

                return FileTools.GetCrc32Digest(
                    bytesTempFsys);
            }

            return 0xFFFFFFFF;
        }
        #endregion

        #region EFI Model Code
        /// <summary>
        /// Converts the EFI model code to a full model identifier.
        /// </summary>
        /// <param name="model">The EFI model code.</param>
        /// <returns>The full model identifier representation.</returns>
        internal static string ConvertEfiModelCode(string model)
        {
            // Example MBP121 becomes MacBookPro12,1.
            if (string.IsNullOrEmpty(model))
                return null;

            string letters = new string(
                model.Where(char.IsLetter).ToArray());

            string numbers =
                new string(model.Where(char.IsDigit).ToArray());

            int minLength = 2;
            int maxLength = 3;

            if (letters.Length < minLength || letters.Length > maxLength ||
                numbers.Length < minLength || numbers.Length > maxLength)
                return model;

            if (model.Contains("MBP"))
                letters = "MacBookPro";
            else if (model.Contains("MBA"))
                letters = "MacBookAir";
            else if (model.Contains("MB"))
                letters = "MacBook";
            else if (model.Contains("IM"))
                letters = "iMac";
            else if (model.Contains("IMP"))
                letters = "iMacPro";
            else if (model.Contains("MM"))
                letters = "MacMini";
            else if (model.Contains("MP"))
                letters = "MacPro";
            else if (model.Contains("XS"))
                letters = "Xserve";

            if (numbers.Length == 2)
                numbers = $"{numbers[0]},{numbers[1]}";
            else if (numbers.Length == 3)
                numbers = $"{numbers.Substring(0, 2)},{numbers.Substring(2)}";

            // Return the generated full model, otherwise what was passed in will be returned.
            return $"{letters}{numbers}";
        }
        #endregion

        #region Firmware Version
        internal static string GetFirmwareVersion()
        {
            if (EFIROM.AppleRomInfoSectionData.EfiVersion != null)
                return EFIROM.AppleRomInfoSectionData.EfiVersion;

            string modelPart = EFIROM.EfiBiosIdSectionData.ModelPart;
            string majorPart = EFIROM.EfiBiosIdSectionData.MajorPart;
            string minorPart = EFIROM.EfiBiosIdSectionData.MinorPart;

            string romVersion = EFIROM.AppleRomInfoSectionData.RomVersion;

            string[] ignoredVersions = { "F000_B00", "Official Build" };

            if (!string.IsNullOrWhiteSpace(romVersion) &&
                !ignoredVersions.Contains(romVersion, StringComparer.OrdinalIgnoreCase))
                return $"{modelPart}.{romVersion.Replace("_", ".")}";

            string biosId = EFIROM.AppleRomInfoSectionData.BiosId;

            string notSet = "F000.B00";

            if (!string.IsNullOrWhiteSpace(biosId) &&
                biosId.IndexOf(notSet, StringComparison.OrdinalIgnoreCase) == -1)
            {
                string[] parts = biosId.Split('.');
                if (parts.Length != 5)
                    return GetFormattedEfiVersion(
                        parts[0],
                        parts[2],
                        parts[3]);
            }

            if (!string.IsNullOrWhiteSpace(modelPart) &&
                !string.IsNullOrWhiteSpace(majorPart) &&
                !string.IsNullOrWhiteSpace(minorPart))
                return GetFormattedEfiVersion(
                    modelPart,
                    majorPart,
                    minorPart);

            return null;
        }

        private static string GetFormattedEfiVersion(string modelPart, string majorPart, string minorPart)
        {
            return $"{modelPart}.{majorPart}.{minorPart}";
        }
        #endregion

        #region Serial Validation
        /// <summary>
        /// Checks if a given input string contains only valid characters for a serial number.
        /// </summary>
        /// <param name="serial">The serial number string to check.</param>
        /// <returns>True if the input string contains only valid characters, otherwise false.</returns>
        internal static bool IsValidSerialChars(string serial)
        {
            return Regex.IsMatch(
                serial,
                "^[0-9A-Z]+$");
        }

        // Serial Number Structure:
        //
        // 1. 11-Digit Serial Number Format (AABCCDDDEEE):
        //    - AA   = Factory Code           (2 characters): Identifies the manufacturing facility. 
        //                              Valid codes are stored in the 'factoryCodes' HashSet.
        //    - B    = Year of Manufacture    (1 character): Represents the last digit of the year (0-9).
        //    - CC   = Week of Manufacture    (2 characters): Represents the week number within the year (01-53).
        //    - DDD  = Unique Device Identifier (3 characters): Typically, a unique identifier for the device model.
        //    - EEE  = Hardware Configuration (3 characters): Denotes the hardware configuration or variant.
        //
        // 2. 12-Digit Serial Number Format (AABCDEEEFFFF):
        //    - AA   = Factory Code           (2 characters): Identifies the manufacturing facility. 
        //                              Valid codes are stored in the 'factoryCodes' HashSet.
        //    - B    = Plant-Specific Code    (1 character): Represents a unique code specific to the plant or assembly line.
        //    - C    = Year Code              (1 character): Denotes the manufacturing year using a broader set of codes. 
        //                              Valid codes are stored in the 'yearAndWeekCodes12' HashSet.
        //    - D    = Week Code              (1 character): Indicates the week of manufacture using a broader set of codes.
        //                              Valid codes are stored in the 'yearAndWeekCodes12' HashSet.
        //    - EEE  = Unique Device Identifier (3 characters): Typically, a unique identifier for the device model.
        //    - FFFF = Hardware Configuration (4 characters): Represents the hardware configuration or variant.
        internal static bool IsValidAppleSerial(string serialNumber)
        {
            // Check for valid length (11 or 12 characters)
            if (serialNumber.Length != 11 && serialNumber.Length != 12)
                return false;

            // Validate accepted chars
            if (!IsValidSerialChars(serialNumber))
                return false;

            // Validate factory code
            if (!IsValidCode(serialNumber.Substring(0, 2), factoryCodes))
                return false;

            // Determine and validate the year and week codes based on serial length
            return serialNumber.Length == 11
                ? IsValid11CharSerial(serialNumber)
                : IsValid12CharSerial(serialNumber);
        }

        private static bool IsValid11CharSerial(string serialNumber)
        {
            string yearCode = serialNumber.Substring(2, 1);
            string weekCode = serialNumber.Substring(3, 2);

            return IsValidCode(yearCode, yearCodes11) && IsValidCode(weekCode, weekCodes11);
        }

        private static bool IsValid12CharSerial(string serialNumber)
        {
            string yearCode = serialNumber.Substring(3, 1);
            string weekCode = serialNumber.Substring(4, 1);

            return IsValidCode(yearCode, yearCodes12) && IsValidCode(weekCode, weekCodes12);
        }

        private static bool IsValidCode(string code, HashSet<string> knownCodes)
        {
            return knownCodes.Contains(code);
        }
        #endregion

        #region Hashsets
        // These hashsets were built on information from:
        // https://forums.macrumors.com/threads/decoding-apple-serials-where-when-hardware-was-assembled-1983-2021-and-apple-model-numbers-1977-present.2310423/
        // All credit for the hashsets goes to the author (B S Magnet)
        private static readonly HashSet<string> factoryCodes = new HashSet<string>
        {
            "16", "17", "1B", "1C", "1E", "1G", "1L", "1M", "1O", "1P", "1X", "2A", "2C", "2D", "2O", "2Z",
            "32", "3B", "3K", "41", "44", "4H", "4J", "4R", "4X", "5K", "5P", "5U", "6C", "6F", "6U", "7J",
            "7K", "7L", "7T", "8B", "8H", "8K", "8L", "9C", "9E", "9G", "AH", "AK", "AL", "AM", "AP", "B0",
            "B3", "B4", "BP", "BX", "BY", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA",
            "CC", "CD", "CE", "CF", "CK", "CN", "CP", "CQ", "CS", "CX", "CY", "D0", "D1", "D2", "D3", "D8",
            "DC", "DG", "DK", "DL", "DM", "DN", "DQ", "DT", "DV", "DX", "DY", "DZ", "EC", "EE", "EQ", "EW",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F9", "FC", "FF", "FG", "FH", "FK", "FM", "FS", "FV",
            "FY", "G2", "G6", "G8", "G9", "GA", "GB", "GJ", "GV", "GY", "H0", "H1", "H2", "H3", "H4", "H6",
            "H8", "HC", "HG", "HQ", "HS", "HT", "HX", "HY", "IB", "IH", "IJ", "IV", "IX", "IZ", "J5", "JE",
            "JN", "JQ", "JY", "KA", "KH", "KY", "KZ", "L0", "L1", "L4", "LA", "LI", "LR", "LS", "LT", "LW",
            "M0", "M1", "M2", "M5", "M6", "M7", "MA", "MB", "MF", "MI", "MJ", "MK", "ML", "MN", "MQ", "MV",
            "MW", "N1", "N5", "NC", "NH", "NK", "NL", "NN", "P1", "PA", "PG", "PH", "PJ", "PK", "PT", "PW",
            "Q0", "Q5", "QE", "QF", "QP", "QT", "R8", "RM", "RN", "RR", "RU", "S1", "S2", "S4", "SA", "SF",
            "SG", "SI", "SO", "SQ", "SR", "SS", "T1", "TF", "TG", "TJ", "TL", "TM", "TN", "TS", "TY", "U2",
            "UC", "UM", "UV", "V2", "V4", "V5", "V6", "V7", "VA", "VM", "W0", "W8", "W9", "WC", "WD", "WI",
            "WL", "WQ", "WR", "WV", "XA", "XB", "XC", "Y5", "Y9", "YD", "YH", "YM", "YW", "ZC", "ZH", "ZU",
            "ZX", "ZZ"
        };

        private static readonly HashSet<string> yearCodes11 = new HashSet<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private static readonly HashSet<string> weekCodes11 = new HashSet<string>
        {
            "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16",
            "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32",
            "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48",
            "49", "50", "51", "52", "53"
        };

        private static readonly HashSet<string> yearCodes12 = new HashSet<string>
        {
            "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y",
            "Z"
        };

        private static readonly HashSet<string> weekCodes12 = new HashSet<string>
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N",
            "P", "Q", "R", "T", "V", "W", "X", "Y"
        };
        #endregion
    }
}