// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MacTools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        internal static string GetDeviceConfigCodeLocal(string hardwareCode)
        {
            try
            {
                // Load data from the embedded XML database.
                byte[] xmlData = Encoding.UTF8.GetBytes(Properties.Resources.modeldb);

                using (MemoryStream stream = new MemoryStream(xmlData))
                {
                    XDocument xmlDoc = XDocument.Load(stream);

                    string configCode = xmlDoc.Descendants("section")
                                           .FirstOrDefault(e => e.Element("hwc")?.Value == hardwareCode)?
                                           .Element("configCode")?.Value;

                    return string.IsNullOrEmpty(configCode) ? null : configCode;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetDeviceConfigCodeLocal), e.GetType(), e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier from Apple's support-sp server.
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        internal static async Task<string> GetDeviceConfigCodeSupportRemote(string hwConfig)
        {
            try
            {
                string supportSp = $"http://support-sp.apple.com/sp/product?cc={hwConfig}&lang=en_GB";

                if (!NetworkTools.IsWebsiteAvailable(supportSp))
                    return null;

                using (WebClient client = new WebClient())
                {
                    string xmlContent = await client.DownloadStringTaskAsync(supportSp);
                    string configCode = XDocument.Parse(xmlContent).XPathSelectElement("/root/configCode")?.Value;

                    if (!string.IsNullOrEmpty(configCode))
                    {
                        Logger.WriteLine(
                            $"'{hwConfig}' not present in local db > support-sp server returned: '{configCode}'",
                            LogType.Database
                        );
                    }

                    return configCode;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetDeviceConfigCodeSupportRemote), e.GetType(), e.Message);
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
            byte[] fsysTempBuffer = new byte[EFIROM.FSYS_RGN_SIZE - EFIROM.CRC32_SIZE];

            if (fsysStore != null)
            {
                Array.Copy(fsysStore, 0, fsysTempBuffer, 0, fsysTempBuffer.Length);

                return FileTools.GetCrc32Digest(fsysTempBuffer);
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

            string letters = new string(model.Where(char.IsLetter).ToArray());

            string numbers = new string(model.Where(char.IsDigit).ToArray());

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

        #region Serial Lookup
        internal static void LookupSerialOnEveryMac(string serial) =>
            Process.Start($"https://everymac.com/ultimate-mac-lookup/?search_keywords={serial}");
        #endregion
    }
}