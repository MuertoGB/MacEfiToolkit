// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FirmwareAnalyzer.cs
// Released under the GNU GPL v3.0

using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Firmware
{
    public static class FirmwareAnalyzer
    {
        public const int MinImageSize = 2 * 1024 * 1024;    // 2 MB
        public const int MaxImageSize = 32 * 1024 * 1024;   // 32 MB

        /// <summary>
        /// Checks if the given size matches any valid firmware image size (power of 2 between min and max).
        /// </summary>
        public static bool IsValidBinSize(long size)
        {
            for (long validSize = MinImageSize; validSize <= MaxImageSize; validSize *= 2)
            {
                if (size == validSize)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates the difference between the given size and the closest valid image size.
        /// Returns a string indicating how far off it is, e.g., "<1024", ">512", or "Valid".
        /// </summary>
        public static string CalculateInvalidSize(long size)
        {
            long closest = MinImageSize;
            long bestDiff = Math.Abs(size - closest);

            for (long s = MinImageSize * 2; s <= MaxImageSize; s *= 2)
            {
                long diff = Math.Abs(size - s);
                if (diff < bestDiff)
                {
                    closest = s;
                    bestDiff = diff;
                }
                else
                {
                    break;
                }
            }

            if (size < closest) return $"<{bestDiff}";
            if (size > closest) return $">{bestDiff}";
            return "Valid";
        }

        /// <summary>
        /// Checks whether a file's size is within the provided min/max size range.
        /// Shows an error prompt if invalid. Returns true if valid.
        /// </summary>
        public static bool CheckFileSizeWithinRange(string filepath, Form owner, int minSize, int maxSize)
        {
            long size = new FileInfo(filepath).Length;

            if (size < minSize || size > maxSize)
            {
                string message = GenerateSizeWarning(size, minSize, maxSize);
                METPrompt.Show(owner, message, METPrompt.PType.Error, METPrompt.PButtons.Okay);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Generates a warning message based on file size validation.
        /// </summary>
        private static string GenerateSizeWarning(long size, int minSize, int maxSize)
        {
            return size < minSize
                ? $"The selected file does not meet the minimum size requirement of {minSize:X}h."
                : $"The selected file exceeds the maximum size limit of {maxSize:X}h.";
        }
    }
}
