// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Updater.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.Common.Constants;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mac_EFI_Toolkit
{
    public class Updater
    {
        public string NewVersion { get; private set; }
        public string ExpectedSHA256 { get; private set; }
        public string Priority { get; private set; }

        public enum VersionResult
        {
            UpToDate,
            NewVersionAvailable,
            Error
        }

        public async Task<VersionResult> CheckForNewVersionAsync()
        {
            string manifestUrl = ApplicationUrls.VersionManifest;
            const string versionNodeXPath = "data/MET/VersionString";
            const string sha256NodeXPath = "data/MET/SHA256";
            const string priorityNodeXPath = "data/MET/Priority";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] responseBuffer = await webClient.DownloadDataTaskAsync(manifestUrl);

                    using (MemoryStream responseStream = new MemoryStream(responseBuffer))
                    using (XmlReader reader = XmlReader.Create(responseStream))
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(reader);

                        XmlNode versionNode = document.SelectSingleNode(versionNodeXPath);
                        XmlNode shaNode = document.SelectSingleNode(sha256NodeXPath);
                        XmlNode priorityNode = document.SelectSingleNode(priorityNodeXPath);

                        if (versionNode == null || shaNode == null)
                            return VersionResult.Error;

                        this.NewVersion = versionNode.InnerText;
                        this.ExpectedSHA256 = shaNode.InnerText;
                        this.Priority = priorityNode.InnerText;

                        Version remoteVersion = new Version(NewVersion);
                        Version thisVersion = new Version(Application.ProductVersion);

                        return remoteVersion > thisVersion ? VersionResult.NewVersionAvailable : VersionResult.UpToDate;
                    }
                }
            }
            catch (Exception e)
            {
                if (!Program.IsDebugMode())
                {
                    Logger.WriteErrorLine(nameof(CheckForNewVersionAsync), e.GetType(), e.Message);
                }

                return VersionResult.Error;
            }
        }

        public async Task<bool> DownloadAndInstallUpdateAsync(Label label)
        {
            UpdateStatus(label, UpdateWindowStrings.WAIT);
            Logger.WriteCallerLine(UpdateWindowStrings.UPDATE_STARTED);

            string version = NewVersion?.Replace(".", "") ?? "unknown";
            string savePath = Path.Combine(ApplicationPaths.WorkingDirectory, $"mefit_{version}.exe");

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Logger.WriteCallerLine($"{UpdateWindowStrings.DOWNLOADING_VERSION} {NewVersion}");
                    byte[] exeBuffer = await webClient.DownloadDataTaskAsync(ApplicationUrls.LatestBuild);
                    string actualHash = Cryptography.GetSha256Digest(exeBuffer);

                    Logger.WriteCallerLine($"{UpdateWindowStrings.DOWNLOADED} {exeBuffer.Length} {AppStrings.BYTES}");
                    Logger.WriteCallerLine(UpdateWindowStrings.VERIFY_SHA256);

                    if (!string.Equals(actualHash, ExpectedSHA256, StringComparison.OrdinalIgnoreCase))
                    {
                        Logger.WriteCallerLine(UpdateWindowStrings.CHECKSUM_MISMATCH);
                        UpdateStatus(label, UpdateWindowStrings.CHECKSUM_MISMATCH);
                        return false;
                    }

                    Logger.WriteCallerLine($"{UpdateWindowStrings.SAVING_EXE} {savePath}");

                    Program.EnsureDirectoriesExist();
                    await Task.Run(() => File.WriteAllBytes(savePath, exeBuffer));

                    if (!File.Exists(savePath))
                    {
                        Logger.WriteCallerLine(UpdateWindowStrings.SAVE_FAIL);
                        UpdateStatus(label, UpdateWindowStrings.SAVE_FAIL);
                        return false;
                    }

                    Logger.WriteCallerLine($"{UpdateWindowStrings.LAUNCH_VERSION} {FileVersionInfo.GetVersionInfo(savePath).ProductVersion}");

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = savePath,
                        UseShellExecute = true
                    });

                    await Task.Delay(500);
                    Application.Exit();
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DownloadAndInstallUpdateAsync), e.GetType(), e.Message);
                UpdateStatus(label, UpdateWindowStrings.ERROR);
                return false;
            }
        }

        private void UpdateStatus(Label control, string status)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((Action)(() => control.Text = status));
            }
            else
            {
                control.Text = status;
            }
        }
    }
}