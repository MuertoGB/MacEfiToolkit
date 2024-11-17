// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// NativeMethods.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Mac_EFI_Toolkit.WIN32
{
    class NativeMethods
    {
        #region Types
        // https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ns-dwmapi-dwm_blurbehind
        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            public DwmBlurBehindFlags dwFlags;
            public bool fEnable;
            public IntPtr hRgnBlur;
            public bool fTransitionOnMaximized;
        }

        [Flags]
        public enum DwmBlurBehindFlags : uint
        {
            DWM_BB_ENABLE = 0x1,
            DWM_BB_BLURREGION = 0x2,
            DWM_BB_TRANSITIONONMAXIMIZED = 0x4
        }

        // https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-process_memory_counters
        [StructLayout(LayoutKind.Sequential, Size = 40)]
        internal struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;
            public uint PageFaultCount;
            public ulong PeakWorkingSetSize;
            public ulong WorkingSetSize;
            public ulong QuotaPeakPagedPoolUsage;
            public ulong QuotaPagedPoolUsage;
            public ulong QuotaPeakNonPagedPoolUsage;
            public ulong QuotaNonPagedPoolUsage;
            public ulong PagefileUsage;
            public ulong PeakPagefileUsage;
        }
        #endregion

        #region API
        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasecapture
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            HandleRef hWnd,
            int Msg,
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFilename);

        // https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprivateprofilestringa
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFilename);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern uint GetPrivateProfileSectionNames(
            IntPtr lpszReturnBuffer,
            uint nSize,
            string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern uint GetPrivateProfileSection(
            string lpAppName,
            IntPtr lpReturnedString,
            uint nSize,
            string lpFileName);

        // https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmenableblurbehindwindow
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableBlurBehindWindow(
            IntPtr hWnd,
            ref DWM_BLURBEHIND pBlurBehind);

        // https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetcolorizationcolor
        [DllImport("dwmapi.dll", EntryPoint = "DwmGetColorizationColor")]
        internal static extern int DwmGetColorizationColor(
            out uint pcrColorization,
            out bool pfOpaqueBlend);

        // https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getcurrentprocess
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        // https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-process_memory_counters
        [DllImport("psapi.dll", SetLastError = true)]
        internal static extern bool GetProcessMemoryInfo(
            IntPtr Process,
            out PROCESS_MEMORY_COUNTERS ppsmemCounters,
            uint cb);
        #endregion
    }
}