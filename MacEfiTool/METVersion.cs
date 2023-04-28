using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mac_EFI_Toolkit
{

    public enum VersionCheckResult
    {
        UpToDate,
        NewVersionAvailable,
        Error
    }

    class METVersion
    {

        #region Version Check
        internal static async Task<VersionCheckResult> CheckForUpdate(string versionUrl)
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
                if (node == null)
                {
                    return VersionCheckResult.Error;
                }

                var remoteVersion = new Version(node.InnerText);
                var localVersion = new Version(Application.ProductVersion);

                if (remoteVersion > localVersion)
                {
                    return VersionCheckResult.NewVersionAvailable;
                }
                else
                {
                    return VersionCheckResult.UpToDate;
                }
            }
            catch
            {
                return VersionCheckResult.Error;
            }
        }
        #endregion

    }
}