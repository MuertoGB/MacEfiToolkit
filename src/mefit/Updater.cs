// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Updater.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Tools;
using System;
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
            const string versionNodeXPath = "data/MET/VersionString";
            const string sha256NodeXPath = "data/MET/SHA256";

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
            UpdateStatus(label, UPDATSTRINGS.WAIT);
            Logger.WriteCallerLine(UPDATSTRINGS.UPD_STARTED);

            string version = string.IsNullOrEmpty(NewVersion) ? string.Empty : NewVersion.Replace(".", string.Empty);
            string savePath = Path.Combine(ApplicationPaths.WorkingDirectory, $"mefit_{version}.exe");

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Logger.WriteCallerLine($"{UPDATSTRINGS.DOWNLOADING_VERSION} {NewVersion}");
                    byte[] exeBuffer = await webClient.DownloadDataTaskAsync(ApplicationUrls.LatestBuild);

                    Logger.WriteCallerLine($"{UPDATSTRINGS.DOWNLOADED} {exeBuffer.Length} {APPSTRINGS.BYTES}");

                    Logger.WriteCallerLine(UPDATSTRINGS.VERIFY_SHA256);
                    string hash = FileTools.GetSha256Digest(exeBuffer);

                    Logger.WriteCallerLine($"{UPDATSTRINGS.EXPECTED}: {ExpectedSHA256}");
                    Logger.WriteCallerLine($"{UPDATSTRINGS.ACTUAL}: {hash}");

                    if (!string.Equals(hash, ExpectedSHA256, StringComparison.OrdinalIgnoreCase))
                    {
                        // Destroy the buffer data.
                        exeBuffer = null;
                        Logger.WriteCallerLine(UPDATSTRINGS.CHECKSUM_MISMATCH);
                        UpdateStatus(label, UPDATSTRINGS.CHECKSUM_MISMATCH);
                        return;
                    }

                    Program.EnsureDirectoriesExist();

                    Logger.WriteCallerLine($"{UPDATSTRINGS.SAVING_EXE} {savePath}");
                    await Task.Run(() => File.WriteAllBytes(savePath, exeBuffer));

                    // Check file exists.
                    if (!File.Exists(savePath))
                    {
                        Logger.WriteCallerLine(UPDATSTRINGS.SAVE_FAIL);
                        UpdateStatus(label, UPDATSTRINGS.SAVE_FAIL);
                        return;
                    }

                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(savePath);
                    Logger.WriteCallerLine($"{UPDATSTRINGS.LAUNCH_VERSION} {fileVersionInfo.ProductVersion}");

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = savePath,
                        UseShellExecute = true
                    });

                    Logger.WriteCallerLine($"{UPDATSTRINGS.EXITING} {Application.ProductVersion}");
                    await Task.Delay(500);
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DownloadAsync), e.GetType(), e.Message);
                UpdateStatus(label, UPDATSTRINGS.ERROR);
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