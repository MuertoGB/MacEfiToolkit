// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Utilities
// EfiUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Utils
{
    class EFIUtils
    {

        /// <summary>
        /// Retrieves the config code string from the Apple server for a given serial number.
        /// </summary>
        /// <param name="serialNumber">The serial number to retrieve a configuration code for.</param>
        /// <returns>The configuration code string, or an error message if an error occurs.</returns>
        internal static async Task<string> GetConfigCodeStringAsync(string serialNumber)
        {
            try
            {
                if (serialNumber.Length != 12)
                {
                    return "Serial No. too short";
                }
                var url = $"http://support-sp.apple.com/sp/product?cc={serialNumber.Substring(8, 4)}";
                if (!NetUtils.IsWebsiteAvailable(url))
                {
                    return "Domain not available";
                }
                var xml = await new WebClient().DownloadStringTaskAsync(url);
                var doc = XDocument.Parse(xml);
                var data = doc.XPathSelectElement("/root/configCode")?.Value;
                return data ?? "Invalid Serial";
            }
            catch
            {
                return "Unknown";
            }
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="sizeIn">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool IsValidSize(int sizeIn)
        {
            int expectedSize = 1048576;
            int maxSize = 16777216;

            while (expectedSize <= maxSize)
            {
                if (sizeIn == expectedSize)
                {
                    return true;
                }
                expectedSize *= 2;
            }
            return false;
        }

        /// <summary>
        /// Checks if a given input string contains only valid characters for a serial number.
        /// </summary>
        /// <param name="input">The serial number string to check.</param>
        /// <returns>True if the input string contains only valid characters, otherwise false.</returns>
        internal static bool IsValidSerialChars(string input)
        {
            return Regex.IsMatch(input, "^[1-9A-Z]+$");
        }

    }
}
