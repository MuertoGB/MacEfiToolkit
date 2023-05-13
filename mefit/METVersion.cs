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
                var client = new WebClient();
                var response = await client.DownloadDataTaskAsync(versionUrl);
                var stream = new MemoryStream(response);
                var reader = XmlReader.Create(stream);
                var doc = new XmlDocument();
                doc.Load(reader);

                var node = doc.SelectSingleNode("data/MET/VersionString");
                if (node == null) return VersionCheckResult.Error;

                var remoteVersion = new Version(node.InnerText);
                var localVersion = new Version(Application.ProductVersion);

                return remoteVersion > localVersion ? VersionCheckResult.NewVersionAvailable : VersionCheckResult.UpToDate;
            }
            catch
            {
                return VersionCheckResult.Error;
            }
        }
    }
}