// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// AppColours.cs
// Released under the GNU GLP v3.0

using System.Drawing;

namespace Mac_EFI_Toolkit
{
    internal class AppColours
    {
        internal static readonly Color WARNING = Color.Tomato;
        internal static readonly Color ERROR = Color.FromArgb(240, 70, 80);
        internal static readonly Color INFO = Color.FromArgb(85, 170, 255);
        internal static readonly Color COMPLETE = Color.FromArgb(128, 255, 128);

        internal static readonly Color DIMMED_TEXT = Color.FromArgb(220, 220, 220);
        internal static readonly Color NORMAL_INFO_TEXT = Color.FromArgb(235, 235, 235);
        internal static readonly Color DEACTIVATED_TEXT = Color.FromArgb(100, 100, 100);
        internal static readonly Color DISABLED_TEXT = Color.FromArgb(140, 140, 140);
        internal static readonly Color WHITE_TEXT = Color.White;
        internal static readonly Color OUTDATED = Color.FromArgb(255, 128, 128);
        internal static readonly Color SETTINGS_PATH_OKAY = Color.FromArgb(200, 220, 240);
    }
}