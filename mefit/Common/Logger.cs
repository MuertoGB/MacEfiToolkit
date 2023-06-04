// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data to .txt file
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{

    #region Enum
    internal enum LogType
    {
        Application,
        Database
    }

    public enum RtbLogPrefix
    {
        MET,
        Info,
        Warn,
        Error
    }
    #endregion

    class Logger
    {
        internal static readonly string strLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mefit.log");
        internal static readonly string strDbReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbreport.log");

        internal static void writeLogFile(string logMessage, LogType logType)
        {
            var pathString = GetLogFilePath(logType);

            using (var writer = new StreamWriter(pathString, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} : {logMessage}");
            }
        }

        internal static void ViewLogFile(LogType logType)
        {
            var pathString = GetLogFilePath(logType);

            if (File.Exists(pathString))
            {
                Process.Start(pathString);
            }
        }

        private static string GetLogFilePath(LogType logType)
        {
            var pathString = string.Empty;

            switch (logType)
            {
                case LogType.Application:
                    pathString = strLogFilePath;
                    break;
                case LogType.Database:
                    pathString = strDbReportPath;
                    break;
                default:
                    pathString = strLogFilePath;
                    break;
            }

            return pathString;
        }

        internal static void WriteLogTypeTextToRtb(string logText, RtbLogPrefix prefixType, RichTextBox richTextBox)
        {
            Color prefixColor;
            string prefixString = string.Empty;

            switch (prefixType)
            {
                case RtbLogPrefix.MET:
                    prefixString = $"[MET]: ";
                    prefixColor = Color.FromArgb(0, 200, 0); // Green
                    break;
                case RtbLogPrefix.Info:
                    prefixString = $"[INF]: ";
                    prefixColor = Color.FromArgb(0, 122, 204); // Blue
                    break;
                case RtbLogPrefix.Warn:
                    prefixString = $"[WRN]: ";
                    prefixColor = Color.FromArgb(255, 165, 0); // Orange
                    break;
                case RtbLogPrefix.Error:
                    prefixString = $"[ERR]: ";
                    prefixColor = Color.FromArgb(255, 51, 51); // Red
                    break;
                default:
                    prefixString = $"[INF]: ";
                    prefixColor = Color.White;
                    break;
            }

            richTextBox.AppendText(prefixString);
            richTextBox.Select(richTextBox.TextLength - prefixString.Length, prefixString.Length - 1);
            richTextBox.SelectionColor = prefixColor;
            richTextBox.AppendText(logText + Environment.NewLine);
            richTextBox.ScrollToCaret();
        }

    }
}
