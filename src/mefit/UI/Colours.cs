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
        internal static readonly Color CLR_INFO = Color.FromArgb(85, 170, 255);
        internal static readonly Color CLR_WARNING = Color.Tomato;
        internal static readonly Color CLR_ERROR = Color.FromArgb(240, 70, 80);
        internal static readonly Color CLR_GOOD = Color.FromArgb(128, 255, 128);
        internal static readonly Color CLR_ACTIVEFORM = Color.White;
        internal static readonly Color CLR_INACTIVEFORM = Color.FromArgb(100, 100, 100);
        internal static readonly Color CLR_NATEXT = Color.FromArgb(140, 140, 140);
        internal static readonly Color CLR_DISABLEDTEXT = Color.FromArgb(140, 140, 140);
        internal static readonly Color CLR_NORMALTEXT = Color.FromArgb(235, 235, 235);
        internal static readonly Color CLR_SETTINGSPATHTEXT = Color.FromArgb(200, 220, 240);
        internal static readonly Color CLR_DEFAULTBORDER = Color.FromArgb(0, 170, 180);
        internal static readonly Color CLR_SB_DEFAULT = Color.FromArgb(100, 100, 100);
        internal static readonly Color CLR_SB_FOUND = Color.FromArgb(50, 170, 180);
    }
}