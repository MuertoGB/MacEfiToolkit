// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// AccentColorHelper.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;

namespace Mac_EFI_Toolkit.UI
{
    internal class AccentColorHelper
    {
        internal static Color GetWindowsAccentColor()
        {
            try
            {
                if (NativeMethods.DwmGetColorizationColor(out uint color, out bool opaque) == 0)
                {
                    byte red = (byte)((color >> 16) & 0xff);
                    byte green = (byte)((color >> 8) & 0xff);
                    byte blue = (byte)(color & 0xff);

                    return Color.FromArgb(red, green, blue);
                }

                return AppColours.DEFAULT_APP_BORDER;
            }
            catch (Exception e)
            {
                Logger.WriteError(nameof(NativeMethods.DwmGetColorizationColor), e.GetType(), e.Message);
                return AppColours.DEFAULT_APP_BORDER;
            }
        }
    }
}