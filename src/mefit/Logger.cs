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
        public static void WriteLine(string message, LogType logtype)
        {
            string strLogPath;

            switch (logtype)
            {
                case LogType.Application:
                    strLogPath = ApplicationPaths.ApplicationLog;
                    break;
                case LogType.Database:
                    strLogPath = ApplicationPaths.DatabaseLog;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logtype), logtype, null);
            }

            using (StreamWriter swLog = new StreamWriter(strLogPath, true))
            {
                swLog.WriteLine($"{DateTime.Now} : {message}");
            }
        }

        internal static void WriteErrorLine(string methodname, Type exceptiontype, string message) =>
            Logger.WriteLine($"{methodname} - {exceptiontype.Name}: {message}", LogType.Application);

        internal static void WriteCallerLine(string logText, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "") =>
            Logger.WriteLine($"{methodName}: {logText}", LogType.Application);

        internal static void OpenLogFile(Form owner)
        {
            string strLogPath = ApplicationPaths.ApplicationLog;

            // Check if the log file exists
            if (!File.Exists(strLogPath))
            {
                ShowLogFileNotFoundError(owner);
                return;
            }

            Process.Start("notepad.exe", strLogPath);
        }

        private static void ShowLogFileNotFoundError(Form owner) =>
            METPrompt.Show(
                owner,
                DIALOGSTRINGS.LOG_NOT_FOUND,
                METPromptType.Error,
                METPromptButtons.Okay);
    }
}