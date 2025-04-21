// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// AccentColorHelper.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
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
                    byte r = (byte)((color >> 16) & 0xff);
                    byte g = (byte)((color >> 8) & 0xff);
                    byte b = (byte)(color & 0xff);

                    return Color.FromArgb(r, g, b);
                }

                return ApplicationColours.AppBorderDefault;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(GetSystemAccentColor), e.GetType(), e.Message);
                return ApplicationColours.AppBorderDefault;
            }
        }
    }
}