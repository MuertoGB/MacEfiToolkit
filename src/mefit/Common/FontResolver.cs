// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FontResolver.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{
    public class FontResolver
    {
        public enum FontStatus
        {
            Available,
            Missing,
            Unknown
        }

        private PrivateFontCollection _privateFontCollection = new PrivateFontCollection();

        public FontResolver()
        {
            this._privateFontCollection = new PrivateFontCollection();
        }

        // Method to load a font from a byte array.
        public FontFamily LoadFont(byte[] fontdata)
        {
            // Allocate unmanaged memory to hold the font data.
            IntPtr pFileView = Marshal.AllocCoTaskMem(fontdata.Length);

            // Copy the font data from the byte array to the allocated memory.
            Marshal.Copy(fontdata, 0, pFileView, fontdata.Length);

            try
            {
                uint pNumFonts = 0;

                // Add the font data from the memory to the system's font collection.
                NativeMethods.AddFontMemResourceEx(pFileView, (uint)fontdata.Length, IntPtr.Zero, ref pNumFonts);

                // Add the memory font to a private font collection.
                _privateFontCollection.AddMemoryFont(pFileView, fontdata.Length);

                // Return the last font family added to the private font collection.
                return _privateFontCollection.Families.Last();
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(LoadFont));
                return null;
            }
            finally
            {
                // Ensure that the allocated memory is freed, even if an exception occurs.
                if (pFileView != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pFileView);
                }
            }
        }

        public bool LoadCustomFont(byte[] fontbuffer, out Font[] fonts)
        {
            fonts = null;

            if (fontbuffer == null)
                return false;

            try
            {
                FontFamily resolvedFont = LoadFont(fontbuffer);

                fonts = new[]
                {
                    new Font(resolvedFont, 12.0F, FontStyle.Regular),
                    new Font(resolvedFont, 14.0F, FontStyle.Regular),
                    new Font(resolvedFont, 24.0F, FontStyle.Regular)
                };

                return true;
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(LoadCustomFont));
                return false;
            }
        }
    }
}