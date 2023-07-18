// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MacUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Utils
{
    class MacUtils
    {

        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier. 
        /// Prioritizes retrieving data from the embedded XML db. 
        /// Falls back to retrieving data from the Apple server if not found in the XML resource.
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        internal static async Task<string> GetDeviceConfigCodeAsync(string hwc)
        {
            try
            {
                // Attempt to load the data from the embedded XML db
                byte[] xmlData = Encoding.UTF8.GetBytes(Properties.Resources.modeldb);
                using (MemoryStream stream = new MemoryStream(xmlData))
                {
                    XDocument xmlDoc = XDocument.Load(stream);
                    string name = xmlDoc.Descendants("section")
                        .FirstOrDefault(e => e.Element("cfgCode")?.Value == hwc)
                        ?.Element("model")?.Value;

                    if (!string.IsNullOrEmpty(name))
                    {
                        return name;
                    }
                }

                // Retrieve data from the Apple server
                string url = $"http://support-sp.apple.com/sp/product?cc={hwc}";
                if (!NetUtils.GetIsWebsiteAvailable(url))
                {
                    return null;
                }

                string xml = await new WebClient().DownloadStringTaskAsync(url);
                XDocument doc = XDocument.Parse(xml);
                string data = doc.XPathSelectElement("/root/configCode")?.Value;

                if (!string.IsNullOrEmpty(data))
                {
                    Logger.WriteToLogFile($"'{hwc}' not present in local db > Server returned: '{data}'", LogType.Database);
                }

                return string.IsNullOrEmpty(data) ? null : data;
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }

        /// <summary>
        /// Checks if a given input string contains only valid characters for a serial number.
        /// </summary>
        /// <param name="serial">The serial number string to check.</param>
        /// <returns>True if the input string contains only valid characters, otherwise false.</returns>
        internal static bool GetIsValidSerialChars(string serial)
        {
            return Regex.IsMatch(serial, "^[0-9A-Z]+$");
        }

        /// <summary>
        /// Calculates an Fsys region CRC32 checksum.
        /// </summary>
        /// /// <param name="fsysStore">The Fsys region to calcuate the CRC32 for.</param>
        /// <returns>The calculated Fsys CRC32 uint</returns>
        internal static uint GetUintFsysCrc32(byte[] fsysStore)
        {
            if (fsysStore.Length < FWBase.FSYS_RGN_SIZE)
                throw new ArgumentException(nameof(fsysStore), "Given bytes are too small.");

            if (fsysStore.Length > FWBase.FSYS_RGN_SIZE)
                throw new ArgumentException(nameof(fsysStore), "Given bytes are too large.");

            // Data we calculate is: Sig base + 0x800h - crc len of 0x4h = 7FCh
            byte[] bytesTempFsys = new byte[FWBase.FSYS_CRC_POS];

            if (fsysStore != null)
            {
                Array.Copy(fsysStore, 0, bytesTempFsys, 0, bytesTempFsys.Length);
                return FileUtils.GetCrc32Digest(bytesTempFsys);
            }

            return 0xFFFFFFFF;
        }

        /// <summary>
        /// Converts the EFI model code to a full model identifier.
        /// </summary>
        /// <param name="model">The EFI model code.</param>
        /// <returns>The full model identifier representation.</returns>
        internal static string ConvertEfiModelCode(string model)
        {
            // Example MPB121 becomes MacBookPro12,1
            if (string.IsNullOrEmpty(model))
                return null;

            string letters = new string(model.Where(char.IsLetter).ToArray());
            string numbers = new string(model.Where(char.IsDigit).ToArray());

            int minLength = 2;
            int maxLength = 3;

            if (letters.Length < minLength || letters.Length > maxLength ||
                numbers.Length < minLength || numbers.Length > maxLength)
            {
                return model;
            }

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

        internal static string GetFirmwareVersion()
        {
            if (FWBase.ROMInfoSectionData.EfiVersion != null)
            {
                return FWBase.ROMInfoSectionData.EfiVersion;
            }

            string modelPart = FWBase.EFISectionData.ModelPart;
            string majorPart = FWBase.EFISectionData.MajorPart;
            string minorPart = FWBase.EFISectionData.MinorPart;

            string romVersion = FWBase.ROMInfoSectionData.RomVersion;
            string[] ignoredVersions = { "F000_B00", "Official Build" };

            if (!string.IsNullOrWhiteSpace(romVersion) && !ignoredVersions.Contains(romVersion, StringComparer.OrdinalIgnoreCase))
            {
                return $"{modelPart}.{romVersion.Replace("_", ".")}";
            }

            string biosId = FWBase.ROMInfoSectionData.BiosId;
            string notSet = "F000.B00";

            if (!string.IsNullOrWhiteSpace(biosId) && biosId.IndexOf(notSet, StringComparison.OrdinalIgnoreCase) == -1)
            {
                string[] parts = biosId.Split('.');
                if (parts.Length != 5)
                {
                    return GetFormattedEfiVersion(parts[0], parts[2], parts[3]);
                }
            }

            if (!string.IsNullOrWhiteSpace(modelPart) && !string.IsNullOrWhiteSpace(majorPart) && !string.IsNullOrWhiteSpace(minorPart))
            {
                return GetFormattedEfiVersion(modelPart, majorPart, minorPart);
            }

            return null;
        }

        private static string GetFormattedEfiVersion(string modelPart, string majorPart, string minorPart)
        {
            return $"{modelPart}.{majorPart}.{minorPart}";
        }

    }
}