﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// Colours.cs
// Released under the GNU GLP v3.0

using System.Drawing;

namespace Mac_EFI_Toolkit.UI
{
    internal static class Colours
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
        internal static readonly Color DisabledText = Color.FromArgb(140, 140, 140);
        internal static readonly Color NormalText = Color.FromArgb(245, 245, 245);
        #endregion

        #region UI Elements
        internal static readonly Color SettingsDefault = Color.FromArgb(200, 220, 240);
        internal static readonly Color AppBorderDefault = Color.FromArgb(0, 170, 180);
        internal static readonly Color InactiveWindow = Color.FromArgb(100, 110, 120);
        #endregion

        #region Glyphs
        internal static readonly Color GlyphDefault = Color.FromArgb(100, 100, 100);
        internal static readonly Color GlyphActive = Color.FromArgb(144, 238, 144);
        #endregion
    }
}