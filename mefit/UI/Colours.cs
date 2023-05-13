// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// Colours.cs
// Released under the GNU GLP v3.0

using System.Drawing;

namespace Mac_EFI_Toolkit.UI
{
    class Colours
    {
        internal static Color clrDisabledText = Color.FromArgb(140, 140, 140);
        internal static Color clrEnabledText = Color.FromArgb(255, 255, 255);
        internal static Color clrDisabledControl = Color.FromArgb(80, 80, 80);
        internal static Color clrDisabledClientBackColor = Color.FromArgb(20, 20, 20);
        internal static Color clrBorderInactive = Color.FromArgb(120, 120, 120);
        internal static Color clrBorderActive = Color.FromArgb(200, 200, 200);
        internal static Color clrClientInactive = Color.FromArgb(10, 10, 10);
        internal static Color clrClientActive = Color.FromArgb(30, 30, 30);
        internal static Color clrChecked = Color.FromArgb(120, 180, 0);
        internal static Color clrUnknown = Color.Tomato;
        internal static Color clrError = Color.FromArgb(255, 50, 50);
        internal static Color clrGood = Color.FromArgb(128, 255, 128);
        internal static Color clrInfo = Color.FromArgb(0, 120, 180);
        internal const int A = 100;
    }
}