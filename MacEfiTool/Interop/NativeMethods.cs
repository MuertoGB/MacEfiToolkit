// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Mac_EFI_Toolkit.Interop
{
    class nativemethods
    {

        // https://www.pinvoke.net/default.aspx/user32.ReleaseCapture
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern bool ReleaseCapture(HandleRef hWnd);

        // https://www.pinvoke.net/default.aspx/user32.SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr Pvd, [In] ref uint pcFonts);

    }
}
