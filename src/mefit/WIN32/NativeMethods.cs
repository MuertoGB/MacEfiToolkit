// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

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
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            HandleRef hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern IntPtr AddFontMemResourceEx(
            IntPtr pFileView,
            uint cjSize,
            IntPtr pvReserved,
            [In] ref uint pNumFonts);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilestring
        [DllImport("kernel32.dll")]
        internal static extern bool GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFilename);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprivateprofilestringa
        [DllImport("kernel32.dll")]
        internal static extern bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFilename);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilesectionnames
        [DllImport("kernel32.dll")]
        internal static extern uint GetPrivateProfileSectionNames(
            IntPtr lpszReturnBuffer,
            uint nSize,
            string lpFileName);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilesection
        [DllImport("kernel32.dll")]
        internal static extern uint GetPrivateProfileSection(
            string lpAppName,
            IntPtr lpReturnedString,
            uint nSize,
            string lpFileName);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookExA(
            int idHook,
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        // Low level keyboard hook delegate
        internal delegate IntPtr LowLevelKeyboardProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(
            IntPtr hhk);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callnexthookex
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern short GetKeyState(
            int nVirtKey);

        // https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlea
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandleA(
            string lpModuleName);

        // https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetcolorizationcolor
        [DllImport("dwmapi.dll", EntryPoint = "DwmGetColorizationColor")]
        internal static extern int DwmGetColorizationColor(out uint color, out bool opaque);
    }
}