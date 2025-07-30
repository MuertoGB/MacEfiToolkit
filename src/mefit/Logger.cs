// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public static class Logger
    {
        private static readonly object _lockObject = new object();
        private static readonly string _logFile = ApplicationPaths.LogFile;
        private static readonly string _logDirectory = Path.GetDirectoryName(_logFile);

        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            Exception,
            Debug
        }

        public static void WriteToLog(string message, LogLevel level)
        {
            if (!string.IsNullOrEmpty(_logDirectory))
                Directory.CreateDirectory(_logDirectory);

            lock (_lockObject)
            {
                using (StreamWriter streamWriter = new StreamWriter(_logFile, true))
                {
                    string stamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                    streamWriter.WriteLine($"{stamp} [{level}]: {message}");
                }
            }
        }

        public static void LogException(Exception ex, [CallerMemberName] string methodName = "")
            => WriteToLog($"{methodName} - Exception: {ex}", LogLevel.Exception);

        public static void LogError(string logText, [CallerMemberName] string methodName = "")
            => WriteToLog($"{methodName}: {logText}", LogLevel.Error);

        public static void LogWarning(string logText, [CallerMemberName] string methodName = "")
            => WriteToLog($"{methodName}: {logText}", LogLevel.Warning);

        public static void LogInfo(string logText, [CallerMemberName] string methodName = "")
            => WriteToLog($"{methodName}: {logText}", LogLevel.Info);

        public static void OpenLogFile(Form owner)
        {
            // Check if the log file exists.
            if (!File.Exists(_logFile))
                return;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c start notepad.exe \"{_logFile}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            Process.Start(startInfo);
        }
    }
}