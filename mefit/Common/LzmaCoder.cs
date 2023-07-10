// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// LzmaCoder.cs - Handles LZMA decompression
// Released under the GNU GLP v3.0

using SevenZip.Compression.LZMA;
using System;
using System.IO;

namespace Mac_EFI_Toolkit
{
    class LzmaCoder
    {
        internal static byte[] DecompressBytes(byte[] sourceBytes)
        {
            Decoder decoder = new Decoder();
            MemoryStream decoderStream = new MemoryStream();

            try
            {
                using (MemoryStream compressedInput = new MemoryStream(sourceBytes))
                {
                    byte[] propertyBytes = new byte[5];
                    compressedInput.Read(propertyBytes, 0, 5);

                    byte[] decompressedLength = new byte[8];
                    compressedInput.Read(decompressedLength, 0, 8);
                    long fileLength = BitConverter.ToInt64(decompressedLength, 0);

                    decoder.SetDecoderProperties(propertyBytes);
                    decoder.Code(compressedInput, decoderStream, compressedInput.Length, fileLength, null);
                }

                return decoderStream.ToArray();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }
    }
}