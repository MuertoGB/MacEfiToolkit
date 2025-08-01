﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MacUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class MacUtils
    {
        #region Configuation Code
        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier from the internal db. 
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        public static string GetDeviceConfigCodeLocal(string hwc)
        {
            try
            {
                // Load data from the embedded XML database.
                byte[] xmlBuffer = Encoding.UTF8.GetBytes(Properties.Resources.modeldb);

                using (MemoryStream stream = new MemoryStream(xmlBuffer))
                {
                    XDocument document = XDocument.Load(stream);

                    string configCode =
                        document.Descendants("section").FirstOrDefault(
                            e => e.Element("hwc")?.Value == hwc)?.Element("configCode")?.Value;

                    return string.IsNullOrEmpty(configCode) ? null : configCode;
                }
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(GetDeviceConfigCodeLocal));
                return null;
            }
        }

        /// <summary>
        /// Retrieves the configuration model string for a given HWC identifier from Apple's support-sp server.
        /// </summary>
        /// <param name="hwc">The HWC identifier to retrieve a model string for.</param>
        /// <returns>The model string.</returns>
        public static async Task<string> GetDeviceConfigCodeRemote(string hwc)
        {
            string supportUrl = "http://support-sp.apple.com/sp/product?cc=";
            string langPart = "&lang=en_GB";
            string xmlNode = "/root/configCode";
            string fullUrl = $"{supportUrl}{hwc}{langPart}";

            try
            {
                if (!NetworkUtils.IsWebsiteAvailable(fullUrl))
                    return null;

                using (WebClient webClient = new WebClient())
                {
                    string xmlContent = await webClient.DownloadStringTaskAsync(fullUrl);
                    string configCode = XDocument.Parse(xmlContent).XPathSelectElement(xmlNode)?.Value;

                    if (!string.IsNullOrEmpty(configCode))
                    {
                        Logger.LogWarning($"'{hwc}' not present in local db > support-sp server returned: '{configCode}'", nameof(GetDeviceConfigCodeRemote));
                    }

                    return configCode;
                }
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(GetDeviceConfigCodeRemote));
                return null;
            }
        }
        #endregion

        #region EFI Model Code
        /// <summary>
        /// Converts the EFI model code to a full model identifier.
        /// </summary>
        /// <param name="model">The EFI model code.</param>
        /// <returns>The full model identifier representation.</returns>
        public static string ConvertEfiModelCode(string model)
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
            {
                // Return the string arg received.
                return model;
            }

            Dictionary<string, string> modelDict = new Dictionary<string, string>
            {
                { "MBP", "MacBookPro" },
                { "MBA", "MacBookAir" },
                { "MB", "MacBook" },
                { "IM", "iMac" },
                { "IMP", "iMacPro" },
                { "MM", "MacMini" },
                { "MP", "MacPro" },
                { "XS", "Xserve" }
            };

            letters = modelDict.FirstOrDefault(kvPair => model.Contains(kvPair.Key)).Value;

            if (numbers.Length == 2)
            {
                numbers = $"{numbers[0]},{numbers[1]}"; // Format X,Y.
            }
            else if (numbers.Length == 3)
            {
                numbers = $"{numbers.Substring(0, 2)},{numbers.Substring(2)}"; // Format XX,Y.
            }

            return $"{letters}{numbers}";
        }
        #endregion

        #region Serial Lookup
        public static void LookupSerialOnEveryMac(string serial)
            => Process.Start($"https://everymac.com/ultimate-mac-lookup/?search_keywords={serial}");
        #endregion
    }
}