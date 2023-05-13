// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EfiUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Utils
{
    class EFIUtils
    {
        /// <summary>
        /// Retrieves the config code string from the Apple server for a given HWC indentifier.
        /// </summary>
        /// <param name="strHwc">The HWC identifier to retrieve a configuration data for.</param>
        /// <returns>The configuration data string, or an error message if an error occurs.</returns>
        internal static async Task<string> GetConfigCodeAsync(string strHwc)
        {
            try
            {
                // URL to retrieve the configuration data
                var url = $"http://support-sp.apple.com/sp/product?cc={strHwc}";

                // Check if the website is available
                if (!NetUtils.GetIsWebsiteAvailable(url)) return "Domain not available";

                // Download and parse the XML data to retrieve the configuration data
                var xml = await new WebClient().DownloadStringTaskAsync(url);
                var doc = XDocument.Parse(xml);
                var data = doc.XPathSelectElement("/root/configCode")?.Value;

                // Return the configuration data or an error message
                return data ?? "Invalid HWC?";
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
        internal static bool GetIsValidBinSize(int sizeIn)
        {
            int expectedSize = FirmwareParser.intMinROMSize;
            int maxSize = FirmwareParser.intMaxROMSize;

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