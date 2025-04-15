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
        internal static Color GetSystemAccentColor()
        {
            try
            {
                if (NativeMethods.DwmGetColorizationColor(out uint color, out bool opaque) == 0)
                {
                    byte bRed = (byte)((color >> 16) & 0xff);
                    byte bGreen = (byte)((color >> 8) & 0xff);
                    byte bBlue = (byte)(color & 0xff);

                    return Color.FromArgb(bRed, bGreen, bBlue);
                }

                return Colours.AppBorderDefault;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSystemAccentColor), e.GetType(), e.Message);
                return Colours.AppBorderDefault;
            }
        }
    }
}