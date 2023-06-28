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

    #region Enums
    internal enum LogType
    {
        Application,
        Database
    }

    public enum RtbLogPrefix
    {
        Complete,
        Info,
        Warning,
        Error
    }
    #endregion

    class Logger
    {
        internal static string strLogFilePath = Path.Combine(METPath.CurrentDirectory, "mefit.log");
        internal static string strDbReportPath = Path.Combine(METPath.CurrentDirectory, "dbreport.log");

        internal static void WriteToLogFile(string logMessage, LogType logType)
        {
            string pathString = GetLogFilePath(logType);

            using (StreamWriter writer = new StreamWriter(pathString, true))
            {
                writer.WriteLine($"{DateTime.Now} : {logMessage}");
            }
        }

        internal static void ViewLogFile(LogType logType)
        {
            string pathString = GetLogFilePath(logType);

            if (File.Exists(pathString))
            {
                Process.Start(pathString);
            }
        }

        private static string GetLogFilePath(LogType logType)
        {
            string pathString;

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

        internal static void WriteLogTextToRtb(string messageString, RtbLogPrefix logPrefix, RichTextBox richTextBox)
        {
            Color prefixColor;
            string timestamp = $"{DateTime.Now:HH:mm:ss}: ";

            switch (logPrefix)
            {
                case RtbLogPrefix.Complete:
                    prefixColor = Color.FromArgb(0, 200, 0);
                    break;
                case RtbLogPrefix.Info:
                    prefixColor = Color.FromArgb(0, 122, 204);
                    break;
                case RtbLogPrefix.Warning:
                    prefixColor = Color.FromArgb(255, 165, 0);
                    break;
                case RtbLogPrefix.Error:
                    prefixColor = Color.FromArgb(255, 51, 51);
                    break;
                default:
                    prefixColor = Color.White;
                    break;
            }

            richTextBox.AppendText(timestamp);
            richTextBox.Select(richTextBox.TextLength - timestamp.Length, timestamp.Length - 1);
            richTextBox.SelectionColor = prefixColor;
            richTextBox.AppendText(messageString + Environment.NewLine);
            richTextBox.ScrollToCaret();
        }

        internal static void WriteExceptionToAppLog(Exception e)
        {
            WriteToLogFile($"{e.GetType().Name}:- {e.Message}\r\n\r\n{e}\r\n\r\n -------------------", LogType.Application);
        }

    }
}