// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// BlurHelper.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit;
using Mac_EFI_Toolkit.UI;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class BlurHelper
{
    [DllImport("dwmapi.dll")]
    private static extern int DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);

    [StructLayout(LayoutKind.Sequential)]
    private struct DWM_BLURBEHIND
    {
        public DwmBlurBehindFlags dwFlags;
        public bool fEnable;
        public IntPtr hRgnBlur;
        public bool fTransitionOnMaximized;
    }

    [Flags]
    private enum DwmBlurBehindFlags : uint
    {
        DWM_BB_ENABLE = 0x1,
        DWM_BB_BLURREGION = 0x2,
        DWM_BB_TRANSITIONONMAXIMIZED = 0x4
    }

    public static void ApplyBlur(Form form)
    {
        DWM_BLURBEHIND blurBehind = new DWM_BLURBEHIND
        {
            dwFlags = DwmBlurBehindFlags.DWM_BB_ENABLE,
            fEnable = true,
            hRgnBlur = IntPtr.Zero
        };

        DwmEnableBlurBehindWindow(form.Handle, ref blurBehind);

        form.AllowTransparency = true;
        form.BackColor = System.Drawing.Color.Green;
        form.TransparencyKey = System.Drawing.Color.Green;

        // Flip the border back to normal.
        if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
        {
            form.BackColor = AccentColorHelper.GetWindowsAccentColor();
            return;
        }

        form.BackColor = AppColours.DEFAULT_APP_BORDER;
    }

    public static void RemoveBlur(Form form)
    {
        DWM_BLURBEHIND blurBehind = new DWM_BLURBEHIND
        {
            dwFlags = DwmBlurBehindFlags.DWM_BB_ENABLE,
            fEnable = false
        };

        DwmEnableBlurBehindWindow(form.Handle, ref blurBehind);

        form.AllowTransparency = false;
    }
}
