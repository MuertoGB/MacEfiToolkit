// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Updater.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Tools;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mac_EFI_Toolkit
{
    internal class Updater
    {
        public enum VersionResult
        {
            UpToDate,
            NewVersionAvailable,
            Error
        }

        internal static string NewVersion { get; set; }
        internal static string ExpectedSHA256 { get; set; }

        internal static async Task<VersionResult> CheckForNewVersion()
        {
            string versionManifestUrl = ApplicationUrls.VersionManifest;
            string versionNodeXPath = "data/MET/VersionString";
            string sha256NodeXPath = "data/MET/SHA256";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] bResponseData = await webClient.DownloadDataTaskAsync(versionManifestUrl);

                    using (MemoryStream msResponseData = new MemoryStream(bResponseData))
                    using (XmlReader xmlReader = XmlReader.Create(msResponseData))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(xmlReader);

                        XmlNode xmlVersionNode = xmlDoc.SelectSingleNode(versionNodeXPath);
                        XmlNode xmlSha256Node = xmlDoc.SelectSingleNode(sha256NodeXPath);

                        if (xmlVersionNode == null || xmlSha256Node == null)
                        {
                            return VersionResult.Error;
                        }

                        NewVersion = xmlVersionNode.InnerText;
                        ExpectedSHA256 = xmlSha256Node.InnerText;

                        Console.WriteLine($"{nameof(CheckForNewVersion)} -> {nameof(NewVersion)} '{xmlVersionNode.InnerText}'");
                        Console.WriteLine($"{nameof(CheckForNewVersion)} -> {nameof(ExpectedSHA256)} '{xmlSha256Node.InnerText}'");

                        Version verRemote = new Version(NewVersion);
                        Version verLocal = new Version(Application.ProductVersion);

                        return verRemote > verLocal ? VersionResult.NewVersionAvailable : VersionResult.UpToDate;
                    }
                }
            }
            catch (Exception e)
            {
                if (!Program.IsDebugMode())
                {
                    Logger.WriteErrorLine(nameof(CheckForNewVersion), e.GetType(), e.Message);
                }

                return VersionResult.Error;
            }
        }

        internal static async Task DownloadAsync(Label label)
        {
            string finalPath = Path.Combine(
                ApplicationPaths.WorkingDirectory,
                $"mefit_{NewVersion.Replace(".", string.Empty)}.exe"
            );

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    UpdateStatus(label, "Getting new executable...");
                    byte[] exeBuffer = await webClient.DownloadDataTaskAsync(ApplicationUrls.LatestBuild);

                    UpdateStatus(label, "Verifying checksum...");
                    string hash = FileTools.GetSha256Digest(exeBuffer);

                    if (!string.Equals(hash, ExpectedSHA256))
                    {
                        UpdateStatus(label, "Checksum mismatch.");
                        return;
                    }

                    Program.EnsureDirectoriesExist();

                    UpdateStatus(label, "Saving update...");
                    await Task.Run(() => File.WriteAllBytes(finalPath, exeBuffer));

                    UpdateStatus(label, "Launching new version...");
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = finalPath,
                        UseShellExecute = true
                    });

                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                UpdateStatus(label, "An error occured.");
            }
        }

        private static void UpdateStatus(Label label, string status)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((Action)(() => label.Text = status));
                return;
            }

            label.Text = status;
        }
    }
}