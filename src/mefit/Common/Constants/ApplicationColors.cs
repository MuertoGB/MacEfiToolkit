// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// ApplicationColors.cs
// Released under the GNU GLP v3.0

using System.Drawing;

namespace Mac_EFI_Toolkit.Common.Constants
{
    public static class ApplicationColors
    {
        #region Status Colors
        internal static readonly Color Information = Color.FromArgb(128, 200, 255);
        internal static readonly Color Warning = Color.FromArgb(255, 179, 64);
        internal static readonly Color Error = Color.FromArgb(255, 99, 130);
        internal static readonly Color Okay = Color.FromArgb(144, 238, 144);
        #endregion

        #region Text Colors
        internal static readonly Color ActiveFormText = Color.White;
        internal static readonly Color InactiveFormText = Color.FromArgb(100, 100, 100);
        internal static readonly Color DisabledText = Color.FromArgb(100, 95, 90);
        internal static readonly Color NormalText = Color.FromArgb(245, 245, 245);
        #endregion

        #region UI Elements
        internal static readonly Color SettingsDefault = Color.FromArgb(200, 220, 240);
        internal static readonly Color AppBorderDefault = Color.FromArgb(0, 170, 180);
        internal static readonly Color InactiveWindow = Color.FromArgb(100, 110, 120);
        #endregion

        #region Glyphs
        internal static readonly Color DragDefault = NormalText;
        internal static readonly Color DragActive = Okay;
        internal static readonly Color GlyphDefault = Color.FromArgb(160, 160, 160);
        internal static readonly Color GlyphActive = Okay;
        #endregion
    }
}