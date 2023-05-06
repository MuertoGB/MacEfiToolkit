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
        internal static Color DisabledText = Color.FromArgb(140, 140, 140);
        internal static Color EnabledText = Color.FromArgb(255, 255, 255);
        internal static Color DisabledControl = Color.FromArgb(80, 80, 80);
        internal static Color DiabledClientBackColor = Color.FromArgb(20, 20, 20);

        internal static Color BorderInactive = Color.FromArgb(120, 120, 120);
        internal static Color BorderActive = Color.FromArgb(200, 200, 200);
        internal static Color ClientInactive = Color.FromArgb(10, 10, 10);
        internal static Color ClientActive = Color.FromArgb(30, 30, 30);

        internal static Color Checked = Color.FromArgb(120, 180, 0);

        internal const int A = 100;
    }
}
