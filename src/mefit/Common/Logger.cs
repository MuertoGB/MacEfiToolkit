// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data and text
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{

    #region Enums
    public enum RtbLogPrefix
    {
        Start,
        Complete,
        Info,
        Warning,
        Error
    }
    #endregion

    class Logger
    {
        internal static void WriteToAppLog(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(METPath.ApplicationLog, true))
                writer.WriteLine($"{DateTime.Now} : {logMessage}");
        }

        internal static void WriteToDbLog(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(METPath.DatabaseLog, true))
                writer.WriteLine($"{DateTime.Now} : {logMessage}");
        }

        internal static void WriteExceptionToAppLog(Exception e)
        {
            WriteToAppLog(
                $"{e.GetType().Name}:- {e.Message}\r\n\r\n{e}\r\n\r\n -------------------");
        }

        internal static void ViewLogFile()
        {
            if (File.Exists(METPath.ApplicationLog))
            {
                Process.Start(METPath.ApplicationLog);
                return;
            }

            MessageBox.Show(
                "The application log has not been created.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        internal static void WriteLogTextToRtb(string messageString, RtbLogPrefix logPrefix, RichTextBox richTextBox)
        {
            Color prefixColor;

            string timestamp = $"{DateTime.Now:HH:mm:ss}: ";

            switch (logPrefix)
            {
                case RtbLogPrefix.Start:
                    prefixColor = Color.FromArgb(193, 0, 255);
                    break;
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

            richTextBox.Select(
                richTextBox.TextLength - timestamp.Length,
                timestamp.Length - 1);

            richTextBox.SelectionColor = prefixColor;

            richTextBox.AppendText(
                messageString + Environment.NewLine);

            richTextBox.ScrollToCaret();
        }
    }
}