// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data and text
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public static class Logger
    {
        public enum LogType
        {
            Application,
            Database
        }

        public static void WriteLine(string message, LogType logtype)
        {
            string logPath;

            switch (logtype)
            {
                case LogType.Application:
                    logPath = ApplicationPaths.ApplicationLog;
                    break;
                case LogType.Database:
                    logPath = ApplicationPaths.DatabaseLog;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logtype), logtype, null);
            }

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }

        public static void WriteErrorLine(string methodname, Type exceptiontype, string message)
            => WriteLine($"{methodname} - {exceptiontype.Name}: {message}", LogType.Application);

        public static void WriteCallerLine(string logText, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
            => WriteLine($"{methodName}: {logText}", LogType.Application);

        public static void OpenLogFile(Form owner)
        {
            string logPath = ApplicationPaths.ApplicationLog;

            // Check if the log file exists
            if (!File.Exists(logPath))
            {
                ShowLogFileNotFoundError(owner);
                return;
            }

            Process.Start("notepad.exe", logPath);
        }

        private static void ShowLogFileNotFoundError(Form owner)
            => METPrompt.Show(
                owner,
                DialogStrings.LOG_NOT_FOUND,
                METPrompt.PType.Error,
                METPrompt.PButtons.Okay);
    }
}