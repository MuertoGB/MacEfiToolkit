// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data to .txt file
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;

namespace Mac_EFI_Toolkit
{

    internal enum LogType
    {
        Application,
        Database
    }

    class Logger
    {
        internal static readonly string strLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mefit.log");
        internal static readonly string strDbReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbreport.log");

        internal static void writeLogFile(string logMessage, LogType logType)
        {
            string logFilePath = GetLogFilePath(logType);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} : {logMessage}");
            }
        }

        internal static void viewLogFile(LogType logType)
        {
            string logFilePath = GetLogFilePath(logType);

            if (File.Exists(logFilePath))
            {
                Process.Start(logFilePath);
            }
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


    }
}
