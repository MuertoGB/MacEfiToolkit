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
            string strPath = GetLogFilePath(logType);

            using (StreamWriter writer = new StreamWriter(strPath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} : {logMessage}");
            }
        }

        internal static void ViewLogFile(LogType logType)
        {
            string strPath = GetLogFilePath(logType);

            if (File.Exists(strPath)) Process.Start(strPath);
        }

        private static string GetLogFilePath(LogType logType)
        {
            string logFilePath;

            switch (logType)
            {
                case LogType.Application:
                    logFilePath = strLogFilePath;
                    break;
                case LogType.Database:
                    logFilePath = strDbReportPath;
                    break;
                default:
                    logFilePath = strLogFilePath;
                    break;
            }

            return logFilePath;
        }

        public static void WriteLogTypeTextToRtb(string text, RtbLogPrefix prefix, RichTextBox richTextBox)
        {
            Color prefixColor;
            string logTypeText = string.Empty;

            switch (prefix)
            {
                case RtbLogPrefix.MET:
                    logTypeText = $"[MET]: ";
                    prefixColor = Color.FromArgb(0, 200, 0); // Green
                    break;
                case RtbLogPrefix.Info:
                    logTypeText = $"[INF]: ";
                    prefixColor = Color.FromArgb(0, 122, 204); // Blue
                    break;
                case RtbLogPrefix.Warn:
                    logTypeText = $"[WRN]: ";
                    prefixColor = Color.FromArgb(255, 165, 0); // Orange
                    break;
                case RtbLogPrefix.Error:
                    logTypeText = $"[ERR]: ";
                    prefixColor = Color.FromArgb(255, 51, 51); // Red
                    break;
                default:
                    logTypeText = $"[INF]: ";
                    prefixColor = Color.White;
                    break;
            }

            richTextBox.AppendText(logTypeText);
            richTextBox.Select(richTextBox.TextLength - logTypeText.Length, logTypeText.Length - 1);
            richTextBox.SelectionColor = prefixColor;
            richTextBox.AppendText(text + Environment.NewLine);
            richTextBox.ScrollToCaret();
        }

    }
}
