﻿// Mac EFI Toolkit
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
        public enum VersionResult
        {
            UpToDate,
            NewVersionAvailable,
            Error
        }

        public static string NewVersion { get; set; }
        public static string ExpectedSHA256 { get; set; }
        public static string Priority { get; set; }

        public static async Task<VersionResult> CheckForNewVersion()
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

                        XmlNode xmlVersionNode = document.SelectSingleNode(versionNodeXPath);
                        XmlNode xmlSha256Node = document.SelectSingleNode(sha256NodeXPath);
                        XmlNode xmlPriorityNode = document.SelectSingleNode(priorityNodeXPath);

                        if (xmlVersionNode == null || xmlSha256Node == null)
                        {
                            return VersionResult.Error;
                        }

                        NewVersion = xmlVersionNode.InnerText;
                        ExpectedSHA256 = xmlSha256Node.InnerText;
                        Priority = xmlPriorityNode.InnerText;

                        Console.WriteLine($"{nameof(CheckForNewVersion)} -> {nameof(NewVersion)} '{xmlVersionNode.InnerText}'");
                        Console.WriteLine($"{nameof(CheckForNewVersion)} -> {nameof(ExpectedSHA256)} '{xmlSha256Node.InnerText}'");

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
                    Logger.WriteErrorLine(nameof(CheckForNewVersion), e.GetType(), e.Message);
                }

                return VersionResult.Error;
            }
        }

        public static async Task DownloadAsync(Label label)
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
                    string hash = Cryptography.GetSha256Digest(exeBuffer);

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