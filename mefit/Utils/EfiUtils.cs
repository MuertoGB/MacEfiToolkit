// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EfiUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Utils
{
    class EFIUtils
    {
        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier. 
        /// Prioritizes retrieving data from the embedded XML db. 
        /// Falls back to retrieving data from the Apple server if not found in the XML resource.
        /// </summary>
        /// <param name="strHwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        internal static async Task<string> GetConfigCodeAsync(string strHwc)
        {
            try
            {
                // Attempt to load the data from the embedded XML db
                var xmlData = Encoding.UTF8.GetBytes(Mac_EFI_Toolkit.Properties.Resources.modeldb);
                using (var stream = new MemoryStream(xmlData))
                {
                    var xmlDoc = XDocument.Load(stream);
                    var name = xmlDoc.Descendants("section")
                        .FirstOrDefault(e => e.Element("cfgCode")?.Value == strHwc)
                        ?.Element("model")?.Value;

                    if (!string.IsNullOrEmpty(name))
                    {
                        return name;
                    }
                }

                // Retrieve data from the Apple server
                var url = $"http://support-sp.apple.com/sp/product?cc={strHwc}";
                if (!NetUtils.GetIsWebsiteAvailable(url))
                {
                    return "Unvailable";
                }

                var xml = await new WebClient().DownloadStringTaskAsync(url);
                var doc = XDocument.Parse(xml);
                var data = doc.XPathSelectElement("/root/configCode")?.Value;

                if (data != null)
                {
                    Logger.writeLogFile($"'{strHwc}' not present in local db > Server returned: '{data}'", LogType.Database);
                }

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