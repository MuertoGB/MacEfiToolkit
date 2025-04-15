// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MacTools.cs
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
        internal static string GetDeviceConfigCodeLocal(string hwc)
        {
            try
            {
                // Load data from the embedded XML database.
                byte[] bXmlBuffer = Encoding.UTF8.GetBytes(Properties.Resources.modeldb);

                using (MemoryStream msBuffer = new MemoryStream(bXmlBuffer))
                {
                    XDocument xDoc = XDocument.Load(msBuffer);

                    string strConfigCode =
                        xDoc.Descendants("section").FirstOrDefault(
                            e => e.Element("hwc")?.Value == hwc)?.Element("configCode")?.Value;

                    return string.IsNullOrEmpty(strConfigCode) ? null : strConfigCode;
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
        internal static async Task<string> GetDeviceConfigCodeSupportRemote(string hwc)
        {
            string strUrlSupportSp = "http://support-sp.apple.com/sp/product?cc=";
            string strLangPart = "&lang=en_GB";
            string xmlNode = "/root/configCode";

            try
            {
                string strFullUrl = $"{strUrlSupportSp}{hwc}{strLangPart}";

                if (!NetworkTools.IsWebsiteAvailable(strFullUrl))
                {
                    return null;
                }

                using (WebClient wClient = new WebClient())
                {
                    string strXmlContent = await wClient.DownloadStringTaskAsync(strFullUrl);
                    string strConfigCode = XDocument.Parse(strXmlContent).XPathSelectElement(xmlNode)?.Value;

                    if (!string.IsNullOrEmpty(strConfigCode))
                    {
                        Logger.WriteLine($"'{hwc}' not present in local db > support-sp server returned: '{strConfigCode}'", LogType.Database);
                    }

                    return strConfigCode;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetDeviceConfigCodeSupportRemote), e.GetType(), e.Message);
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
        internal static string ConvertEfiModelCode(string model)
        {
            // Example MBP121 becomes MacBookPro12,1.
            if (string.IsNullOrEmpty(model))
            {
                return null;
            }

            string strLetters = new string(model.Where(char.IsLetter).ToArray());
            string strNumbers = new string(model.Where(char.IsDigit).ToArray());

            int iMinLength = 2;
            int iMaxLength = 3;

            if (strLetters.Length < iMinLength || strLetters.Length > iMaxLength ||
                strNumbers.Length < iMinLength || strNumbers.Length > iMaxLength)
            {
                return model;
            }

            Dictionary<string, string> dictModelMap = new Dictionary<string, string>
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

            strLetters = dictModelMap.FirstOrDefault(kvPair => model.Contains(kvPair.Key)).Value;

            if (strNumbers.Length == 2)
            {
                strNumbers = $"{strNumbers[0]},{strNumbers[1]}"; // Format X,Y.
            }
            else if (strNumbers.Length == 3)
            {
                strNumbers = $"{strNumbers.Substring(0, 2)},{strNumbers.Substring(2)}"; // Format XX,Y.
            }

            // Return the generated full model, otherwise what was passed in will be returned.
            return $"{strLetters}{strNumbers}";
        }
        #endregion

        #region Serial Lookup
        internal static void LookupSerialOnEveryMac(string serial) =>
            Process.Start($"https://everymac.com/ultimate-mac-lookup/?search_keywords={serial}");
        #endregion
    }
}