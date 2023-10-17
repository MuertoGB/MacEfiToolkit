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
        internal static readonly Color CONTROL_DISABLED_TEXT = Color.FromArgb(140, 140, 140);
        internal static readonly Color CONTROL_WHITE_TEXT = Color.FromArgb(255, 255, 255);
        internal static readonly Color DISABLED_CONTROL = Color.FromArgb(80, 80, 80);
        internal static readonly Color BORDER_INACTIVE = Color.FromArgb(120, 120, 120);
        internal static readonly Color BORDER_ACTIVE = Color.FromArgb(200, 200, 200);
        internal static readonly Color CLIENT_INACTIVE = Color.FromArgb(10, 10, 10);
        internal static readonly Color CLIENT_ACTIVE = Color.FromArgb(30, 30, 30);
        internal static readonly Color CHECKED = Color.FromArgb(85, 170, 255);
        internal static readonly Color WARNING_BOX = Color.Tomato;
        internal static readonly Color ERROR_BOX = Color.FromArgb(240, 70, 80);
        internal static readonly Color INFO_BOX = Color.FromArgb(85, 170, 255);
        internal static readonly Color SWITCH_HEAD_DISABLED = Color.FromArgb(100, 100, 100);
        internal static readonly Color SWITCH_HEAD_ENABLED = Color.FromArgb(170, 170, 170);
        internal static readonly Color FOCUS_RECTANGLE = Color.FromArgb(150, 150, 150);
    }
}