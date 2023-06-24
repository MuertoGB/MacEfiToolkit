// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// METVersion.cs - Provides a simple version check
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mac_EFI_Toolkit
{

    #region Enum
    public enum VersionCheckResult
    {
        UpToDate,
        NewVersionAvailable,
        Error
    }
    #endregion

    class METVersion
    {
        internal static string strLatestUrl = "https://github.com/MuertoGB/MacEfiToolkit/releases/latest";

        internal static async Task<VersionCheckResult> CheckForNewVersion(string versionUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = await client.DownloadDataTaskAsync(versionUrl);
                    using (MemoryStream stream = new MemoryStream(response))
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);

                        XmlNode node = doc.SelectSingleNode("data/MET/VersionString");
                        if (node == null)
                            return VersionCheckResult.Error;

                        Version remoteVersion = new Version(node.InnerText);
                        Version localVersion = new Version(Application.ProductVersion);

                        return remoteVersion > localVersion ? VersionCheckResult.NewVersionAvailable : VersionCheckResult.UpToDate;
                    }
                }
            }
            catch
            {
                return VersionCheckResult.Error;
            }
        }
    }
}