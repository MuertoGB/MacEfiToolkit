// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// Updated 11.5.23 - Prevent keybook hook being destroyed by the garbage collector. Naughty garbage collector.
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    static class Program
    {
        internal static string strAppBuild = $"{Application.ProductVersion}-130523-ms4";
        internal static string strAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static string strAppName = Assembly.GetExecutingAssembly().Location;

        #region Private Members
        private static NativeMethods.LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookId = IntPtr.Zero;
        private static GCHandle _hookHandle;
        #endregion

        #region Const Members
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        internal const int WS_MINIMIZEBOX = 0x20000;
        internal const int CS_DBLCLKS = 0x8;
        internal const int CS_DROP = 0x20000;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_UP = 0x26;
        private const int VK_LWIN = 0x5B;
        private const int KEY_PRESSED = 0x8000;
        #endregion

        #region Internal Fonts
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        internal static Font FONT_MDL2_REG_20;
        internal static Font FONT_MDL2_REG_14;
        internal static Font FONT_MDL2_REG_9;
        #endregion

        #region Main Entry Point
        [STAThread]
        static void Main(string[] args)
        {
            // Verify integrity of application to ensure it's not corrupt.
            if (!AssemblyVerifier.VerifyAssemblyStrongNameSignature(strAppName))
            {
                MessageBox.Show("The assembly signature is invalid, or cannot be verified!\r\nYou should discard of, and reacquire the file.",
                    "Signature Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Default framework stuff.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Register exception handler events.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Web Security Protocol
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Font Data
            byte[] fontData = Properties.Resources.segmdl2;
            FONT_MDL2_REG_9 = new Font(LoadFontFromResource(fontData, 9.0F), FontStyle.Regular);
            FONT_MDL2_REG_14 = new Font(LoadFontFromResource(fontData, 14.0F), FontStyle.Regular);
            FONT_MDL2_REG_20 = new Font(LoadFontFromResource(fontData, 20.0F), FontStyle.Regular);

            // Settings
            if (!File.Exists(Settings.strSettingsFilePath)) Settings.SettingsCreateFile();
            // We will grab settings on the fly. Thanks Kyle and Daz. I will blame if anything goes sideways. Peace out.

            // Register application exit event.
            Application.ApplicationExit += OnExiting;

            // Register low level keyboard hook for preventing WinKey+Up.
            hookKeyboard();

            // Run mainWindow.
            Application.Run(new mainWindow());
        }

        private static void OnExiting(object sender, EventArgs e)
        {
            // Unhook the keyboard hook before exiting the application.
            unhookKeyboard();
        }
        #endregion

        #region Hooks
        // Register the keyboard hook.
        internal static IntPtr SetHook(NativeMethods.LowLevelKeyboardProc proc)
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                return NativeMethods.SetWindowsHookExA(WH_KEYBOARD_LL, proc, NativeMethods.GetModuleHandleA(module.ModuleName), 0);
            }
        }

        // Define the keyboard hook callback function
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == VK_UP && (NativeMethods.GetKeyState(VK_LWIN) & KEY_PRESSED) != 0)
                {
                    // Disable the Windows+Up shortcut by not passing it to the operating system
                    return (IntPtr)1;
                }
            }
            return NativeMethods.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private static void hookKeyboard()
        {
            _proc = HookCallback;
            _hookHandle = GCHandle.Alloc(_proc);
            _hookId = SetHook(_proc);
        }

        private static void unhookKeyboard()
        {
            NativeMethods.UnhookWindowsHookEx(_hookId);
            _hookHandle.Free();
        }
        #endregion

        #region Font Resolver

        public static Font LoadFontFromResource(byte[] fontData, float fontSize)
        {
            // Pin the font data so we can get a pointer to it
            GCHandle handle = GCHandle.Alloc(fontData, GCHandleType.Pinned);
            IntPtr pointer = handle.AddrOfPinnedObject();

            // Add the font to PrivateFontCollection
            _privateFontCollection.AddMemoryFont(pointer, fontData.Length);

            // Create a font object from the font family and font size
            FontFamily fontFamily = _privateFontCollection.Families[_privateFontCollection.Families.Length - 1];
            Font font = new Font(fontFamily, fontSize);

            // Free the pinned handle
            handle.Free();

            // Return the loaded font
            return font;
        }
        #endregion

        #region Exception Handler
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e != null) METCatchUnhandledException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            if (ex != null) METCatchUnhandledException(ex);
        }

        static void METCatchUnhandledException(Exception e)
        {
            string type = e.GetType().Name;
            string message = e.Message.ToString();
            string exception = e.ToString();

            Logger.writeLogFile($"{type}:- {message}\r\n\r\n{exception}\r\n\r\n -------------------");

            DialogResult result = MessageBox.Show(message + "\r\n\r\n" + exception + "\r\n\r\n" + "Quit application?",
                type, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            switch (result)
            {
                case DialogResult.Yes:
                    unhookKeyboard(); // Unhook keyboard as the OnExit event will not fire when using Environment.Exit.
                    Environment.Exit(-1);
                    break;
                case DialogResult.No:
                    break;
            }
        }
        #endregion

        #region Restart
        internal static void RestartMet(Form owner)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                Application.Restart();
            }
            else
            {
                DialogResult result = METMessageBox.Show(owner, "Restart application", "Are you sure you want to restart the application?", MsgType.Question, MsgButton.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }
        #endregion

        #region Exit
        internal static void ExitMet(Form owner)
        {
            if (Settings.SettingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                Application.Exit();
            }
            else
            {
                DialogResult result = METMessageBox.Show(owner, "Exit application", "Are you sure you want to quit the application?", MsgType.Question, MsgButton.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
        #endregion

    }
}