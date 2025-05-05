﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Serial.cs
// Released under the GNU GLP v3.0

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mac_EFI_Toolkit.Firmware
{
    public static class Serial
    {
        #region Serial Validation
        /// <summary>
        /// Checks if a given input string contains only valid characters for a serial number.
        /// </summary>
        /// <param name="serial">The serial number string to check.</param>
        /// <returns>True if the input string contains only valid characters, otherwise false.</returns>
        private static bool IsValidChars(string serial)
        {
            return Regex.IsMatch(serial, "^[0-9A-Z]+$");
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
        public static bool IsValid(string serial)
        {
            // Null serial return false.
            if (serial == null)
            {
                return false;
            }

            // Check for valid length (11 or 12 characters).
            if (serial.Length != 11 && serial.Length != 12)
            {
                return false;
            }

            // Validate accepted chars.
            if (!IsValidChars(serial))
            {
                return false;
            }

            // Validate factory code.
            if (!IsValidCode(serial.Substring(0, 2), _hsFactoryCodes))
            {
                return false;
            }

            // Determine and validate the year and week codes based on serial length.
            return serial.Length == 11 ? IsValid11CharSerial(serial) : IsValid12CharSerial(serial);
        }

        private static bool IsValid11CharSerial(string serial)
        {
            // Check if the last three digits are the same.
            if (serial.Substring(8, 3) == new string(serial[8], 3))
            {
                return false;
            }

            string yearCode = serial.Substring(2, 1);
            string weekCode = serial.Substring(3, 2);

            return IsValidCode(yearCode, _hsYearCodes11) && IsValidCode(weekCode, _hsWeekCodes11);
        }

        private static bool IsValid12CharSerial(string serial)
        {
            // Check if the last four digits are the same.
            if (serial.Substring(8, 4) == new string(serial[8], 4))
            {
                return false;
            }

            string yearCode = serial.Substring(3, 1);
            string weekCode = serial.Substring(4, 1);

            return IsValidCode(yearCode, _hsYearCodes12) && IsValidCode(weekCode, _hsWeekCodes12);
        }

        private static bool IsValidCode(string code, HashSet<string> knowncodes)
        {
            return knowncodes.Contains(code);
        }
        #endregion

        #region Hashsets
        // These hashsets were built on information from:
        // https://forums.macrumors.com/threads/decoding-apple-serials-where-when-hardware-was-assembled-1983-2021-and-apple-model-numbers-1977-present.2310423/
        // All credit for the hashsets goes to the author (B S Magnet).
        private static readonly HashSet<string> _hsFactoryCodes = new HashSet<string>
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

        private static readonly HashSet<string> _hsYearCodes11 = new HashSet<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private static readonly HashSet<string> _hsWeekCodes11 = new HashSet<string>
        {
            "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16",
            "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32",
            "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48",
            "49", "50", "51", "52", "53"
        };

        private static readonly HashSet<string> _hsYearCodes12 = new HashSet<string>
        {
            "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y",
            "Z"
        };

        private static readonly HashSet<string> _hsWeekCodes12 = new HashSet<string>
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N",
            "P", "Q", "R", "T", "V", "W", "X", "Y"
        };
        #endregion
    }
}