// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Utilities
// EfiUtils.cs
// Updated 30.04.2023 - Naming, remove unused functions.
// Released under the GNU GLP v3.0

using System.Net;
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
        internal static async Task<string> _stringGetConfigCodeAsync(string serialNumber)
        {
            try
            {
                // Return an error message if the serial number is too short
                if (serialNumber.Length < 11) return "Invalid serial number";

                // Determine the number of digits to take from the serial number
                int digitsToTake = serialNumber.Length == 12 ? 4 : 3;

                // Build the URL to retrieve the configuration code
                var url = $"http://support-sp.apple.com/sp/product?cc={serialNumber.Substring(serialNumber.Length - digitsToTake)}";

                // Check if the website is available
                if (!NetUtils._boolIsWebsiteAvailable(url)) return "Domain not available";

                // Download and parse the XML data to retrieve the configuration code
                var xml = await new WebClient().DownloadStringTaskAsync(url);
                var doc = XDocument.Parse(xml);
                var data = doc.XPathSelectElement("/root/configCode")?.Value;

                // Return the configuration code or an error message
                return data ?? "Invalid serial number";
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
        internal static bool _boolGetIsValidBinarySize(int sizeIn)
        {
            int expectedSize = Program.minRomSize;
            int maxSize = Program.maxRomSize;

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
    }
}