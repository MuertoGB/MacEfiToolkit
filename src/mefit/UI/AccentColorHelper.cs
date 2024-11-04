// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// AccentColorHelper.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.UI
{
    internal class AccentColorHelper
    {
        [DllImport("dwmapi.dll", EntryPoint = "DwmGetColorizationColor")]
        private static extern int DwmGetColorizationColor(out uint color, out bool opaque);

        internal static Color GetWindowsAccentColor()
        {
            try
            {
                if (DwmGetColorizationColor(out uint color, out bool opaque) == 0)
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
                Logger.WriteError(nameof(DwmGetColorizationColor), e.GetType(), e.Message);
                return AppColours.DEFAULT_APP_BORDER;
            }
        }
    }
}
