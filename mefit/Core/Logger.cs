// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Core Components
// Logger.cs - Handles logging of data to .txt file
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;

namespace Mac_EFI_Toolkit
{
    class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MEFIT.log");

        internal static void Write(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} : {logMessage}");
            }
        }
        internal static void ViewLog()
        {
            if (File.Exists(logFilePath))
            {
                Process.Start(logFilePath);
            }
        }
    }
}
