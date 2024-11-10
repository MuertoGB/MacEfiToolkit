// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data and text
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public enum LogType
    {
        Application,
        Database
    }

    class Logger
    {
        public static void Write(string logMessage, LogType logType)
        {
            string logFilePath;

            switch (logType)
            {
                case LogType.Application:
                    logFilePath = METPath.APP_LOG;
                    break;
                case LogType.Database:
                    logFilePath = METPath.DATABASE_LOG;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {logMessage}");
            }
        }

        internal static void WriteErrorLine(string methodName, Type exceptionType, string message) =>
            Logger.Write($"{methodName} - {exceptionType.Name}: {message}", LogType.Application);

        internal static void WritePatchLine(string logText, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "") =>
            Logger.Write($"{methodName}: {logText}", LogType.Application);

        internal static void OpenLogFile(Form owner)
        {
            var logPath = METPath.APP_LOG;

            if (!File.Exists(logPath))
            {
                ShowLogFileNotFoundError(owner);
                return;
            }

            Process.Start(logPath);
        }

        private static void ShowLogFileNotFoundError(Form owner) =>
            METPrompt.Show(
                owner,
                DIALOGSTRINGS.LOG_NOT_FOUND,
                METPromptType.Error,
                METPromptButtons.Okay);
    }
}