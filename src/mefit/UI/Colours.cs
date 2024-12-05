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
        internal static readonly Color ClrInfo = Color.FromArgb(85, 170, 255);
        internal static readonly Color ClrWarn = Color.Tomato;
        internal static readonly Color ClrError = Color.FromArgb(240, 70, 80);
        internal static readonly Color ClrOkay = Color.FromArgb(128, 255, 128);
        internal static readonly Color ClrActiveFormText = Color.White;
        internal static readonly Color ClrInactiveFormText = Color.FromArgb(100, 100, 100);
        internal static readonly Color ClrDisabledText = Color.FromArgb(140, 140, 140);
        internal static readonly Color ClrNormalText = Color.FromArgb(235, 235, 235);
        internal static readonly Color ClrSettingsDefault = Color.FromArgb(200, 220, 240);
        internal static readonly Color ClrAppBorderDefault = Color.FromArgb(0, 170, 180);
        internal static readonly Color ClrGlyphDefault = Color.FromArgb(100, 100, 100);
        internal static readonly Color ClrGlyphActive = Color.FromArgb(50, 170, 180);
    }
}