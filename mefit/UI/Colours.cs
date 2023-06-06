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
        internal static readonly Color clrDisabledText = Color.FromArgb(140, 140, 140);
        internal static readonly Color clrEnabledText = Color.FromArgb(255, 255, 255);
        internal static readonly Color clrDisabledControl = Color.FromArgb(80, 80, 80);
        internal static readonly Color clrBorderInactive = Color.FromArgb(120, 120, 120);
        internal static readonly Color clrBorderActive = Color.FromArgb(200, 200, 200);
        internal static readonly Color clrClientInactive = Color.FromArgb(10, 10, 10);
        internal static readonly Color clrClientActive = Color.FromArgb(30, 30, 30);
        internal static readonly Color clrChecked = Color.FromArgb(120, 180, 0);
        internal static readonly Color clrUnknown = Color.Tomato;
        internal static readonly Color clrError = Color.FromArgb(255, 50, 50);
        internal static readonly Color clrGood = Color.FromArgb(128, 255, 128);
        internal static readonly Color clrInfo = Color.FromArgb(0, 120, 180);
    }
}