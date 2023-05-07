// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WIN32 Interop
// NativeMethods.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace Mac_EFI_Toolkit.WIN32
{
    class NativeMethods
    {
        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasecapture
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern bool ReleaseCapture(
            HandleRef hWnd);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern IntPtr SendMessage(
            HandleRef hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool AddFontMemResourceEx(
            IntPtr pFileView,
            uint cjSize,
            IntPtr pvReserved,
            [In] ref uint pNumFonts);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilestring
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFilename);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprivateprofilestringa
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern long WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFilename);
    }
}
