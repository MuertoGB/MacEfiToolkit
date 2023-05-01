// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Program.cs
// Released under the GNU GLP v3.0
// MET uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    static class Program
    {

        internal static string APP_BUILD = $"010523.{Application.ProductVersion.Replace(".", ""):0000}.0223";

        #region Internal Fonts
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        internal static Font FONT_MDL2_REG_14;
        internal static Font FONT_MDL2_REG_9;
        #endregion

        #region Main Entry Point
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Unhandled Exception
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Web Security Protocol
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            // Font Data
            byte[] fontData = Properties.Resources.segmdl2;
            FONT_MDL2_REG_9 = new Font(LoadFontFromResource(fontData, 9.0F), FontStyle.Regular);
            FONT_MDL2_REG_14 = new Font(LoadFontFromResource(fontData, 14.0F), FontStyle.Regular);

            Application.Run(new mainWindow());
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

            DialogResult result = MessageBox.Show(message + "\r\n\r\n" + exception + "\r\n\r\n" + "Quit application?",
                type, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        #endregion

    }
}