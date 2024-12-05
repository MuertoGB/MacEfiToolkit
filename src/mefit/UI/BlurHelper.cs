// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// BlurHelper.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Windows.Forms;

public static class BlurHelper
{
    public static void ApplyBlur(Form form)
    {
        NativeMethods.DWM_BLURBEHIND dwmBlurBehind = new NativeMethods.DWM_BLURBEHIND
        {
            dwFlags = NativeMethods.DwmBlurBehindFlags.DWM_BB_ENABLE,
            fEnable = true,
            hRgnBlur = IntPtr.Zero
        };

        NativeMethods.DwmEnableBlurBehindWindow(form.Handle, ref dwmBlurBehind);

        form.AllowTransparency = true;
        form.BackColor = System.Drawing.Color.Green;
        form.TransparencyKey = System.Drawing.Color.Green;

        if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
        {
            form.BackColor = AccentColorHelper.GetWindowsAccentColor();
            return;
        }

        form.BackColor = Colours.ClrAppBorderDefault;
    }

    public static void RemoveBlur(Form form)
    {
        NativeMethods.DWM_BLURBEHIND dwmBlurBehind = new NativeMethods.DWM_BLURBEHIND
        {
            dwFlags = NativeMethods.DwmBlurBehindFlags.DWM_BB_ENABLE,
            fEnable = false
        };

        NativeMethods.DwmEnableBlurBehindWindow(form.Handle, ref dwmBlurBehind);

        form.AllowTransparency = false;
    }
}