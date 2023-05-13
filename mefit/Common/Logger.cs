// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data to .txt file
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;

namespace Mac_EFI_Toolkit
{
    class Logger
    {
        internal static readonly string strLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mefit.log");

        internal static void writeLogFile(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(strLogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} : {logMessage}");
            }
        }
        internal static void viewLogFile()
        {
            if (File.Exists(strLogFilePath))
            {
                Process.Start(strLogFilePath);
            }
        }
    }
}
