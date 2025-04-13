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
            UpdateStatus(label, "Please wait...");
            Logger.WriteCallerLine("Update started");

            string savePath = Path.Combine(
                ApplicationPaths.WorkingDirectory,
                $"mefit_{NewVersion.Replace(".", string.Empty)}.exe"
            );

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Logger.WriteCallerLine($"Downloading version {NewVersion}");
                    byte[] exeBuffer = await webClient.DownloadDataTaskAsync(ApplicationUrls.LatestBuild);

                    Logger.WriteCallerLine($"Fetched {exeBuffer.Length} bytes");
                    Logger.WriteCallerLine("Verifying sha256 checksum");
                    string hash = FileTools.GetSha256Digest(exeBuffer);

                    Logger.WriteCallerLine($"Expected: {ExpectedSHA256}");
                    Logger.WriteCallerLine($"Actual: {hash}");

                    if (!string.Equals(hash, ExpectedSHA256, StringComparison.OrdinalIgnoreCase))
                    {
                        UpdateStatus(label, "An error occured. See application log.");
                        return;
                    }

                    Program.EnsureDirectoriesExist();

                    Logger.WriteCallerLine($"Saving executable to {savePath}");
                    await Task.Run(() => File.WriteAllBytes(savePath, exeBuffer));

                    if (!File.Exists(savePath))
                    {
                        Logger.WriteCallerLine("File export failed.");
                        return;
                    }

                    Logger.WriteCallerLine("Launching update");
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = savePath,
                        UseShellExecute = true
                    });

                    Logger.WriteCallerLine($"Exiting version {Application.ProductVersion}");
                    await Task.Delay(500);
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(CheckForNewVersion), e.GetType(), e.Message);
                UpdateStatus(label, "An error occured. See application log.");
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