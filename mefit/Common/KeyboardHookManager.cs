// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// KeyboardHookManager.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{
    internal class KeyboardHookManager
    {

        #region Const Members
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_UP = 0x26;
        private const int VK_LWIN = 0x5B;
        private const int KEY_PRESSED = 0x8000;
        #endregion

        #region Private Members
        private static NativeMethods.LowLevelKeyboardProc _kbProc = HookCallback;
        private static IntPtr _hookId = IntPtr.Zero;
        private static GCHandle _hookHandle;
        #endregion

        // Register the keyboard hook.
        private static IntPtr SetHook(NativeMethods.LowLevelKeyboardProc kbProc)
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                return NativeMethods.SetWindowsHookExA(
                    WH_KEYBOARD_LL,
                    kbProc,
                    NativeMethods.GetModuleHandleA(module.ModuleName),
                    0);
            }
        }

        // Define the keyboard hook callback function
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode =
                    Marshal.ReadInt32(
                        lParam);

                // Disable the Windows+Up shortcut by not passing it to the operating system
                if (vkCode == VK_UP && (NativeMethods.GetKeyState(VK_LWIN) & KEY_PRESSED) != 0)
                    return (IntPtr)1;
            }

            return NativeMethods.CallNextHookEx(
                _hookId,
                nCode,
                wParam,
                lParam);
        }

        internal static void Hook()
        {
            _kbProc = HookCallback;
            _hookHandle = GCHandle.Alloc(_kbProc);
            _hookId = SetHook(_kbProc);
        }

        internal static void Unhook()
        {
            NativeMethods.UnhookWindowsHookEx(_hookId);
            _hookHandle.Free();
        }

    }
}