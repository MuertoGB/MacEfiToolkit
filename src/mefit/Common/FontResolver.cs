﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FontResolver.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mac_EFI_Toolkit.Common
{
    internal class FontResolver
    {
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();

        internal static FontFamily LoadFont(byte[] fontData)
        {
            // Allocate unmanaged memory to hold the font data.
            IntPtr pFileView = Marshal.AllocCoTaskMem(fontData.Length);

            // Copy the font data from the byte array to the allocated memory.
            Marshal.Copy(fontData, 0, pFileView, fontData.Length);

            try
            {
                uint pNumFonts = 0;

                // Add the font data from the memory to the system's font collection.
                NativeMethods.AddFontMemResourceEx(pFileView, (uint)fontData.Length, IntPtr.Zero, ref pNumFonts);

                // Add the memory font to a private font collection.
                _privateFontCollection.AddMemoryFont(pFileView, fontData.Length);

                // Return the last font family added to the private font collection.
                return _privateFontCollection.Families.Last();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(LoadFont), e.GetType(), e.Message);
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

        internal static FontStatus IsFontStyleAvailable(string fontFamily, FontStyle fontStyle)
        {
            try
            {
                using (FontFamily fFamily = new FontFamily(fontFamily))
                {
                    if (fFamily.IsStyleAvailable(fontStyle))
                    {
                        return FontStatus.Available;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(IsFontStyleAvailable), e.GetType(), e.Message);
                return FontStatus.Unknown;
            }

            return FontStatus.Missing;
        }

        internal static bool LoadCustomFont(byte[] fontbuffer, out Font[] fonts)
        {
            fonts = null;

            if (fontbuffer == null)
            {
                return false;
            }

            try
            {
                FontFamily ffLoadFont = FontResolver.LoadFont(fontbuffer);

                fonts = new[]
                {
                    new Font(ffLoadFont, 10.0F, FontStyle.Regular),
                    new Font(ffLoadFont, 12.0F, FontStyle.Regular),
                    new Font(ffLoadFont, 20.0F, FontStyle.Regular)
                };

                return true;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(LoadCustomFont), e.GetType(), e.Message);
                return false;
            }
        }

    }
}