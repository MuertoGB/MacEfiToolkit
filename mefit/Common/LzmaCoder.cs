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
            var lzmaDecoder = new LzmaDecoder();
            var decompressedStream = new MemoryStream();

            using (var compressedInput = new MemoryStream(sourceBytes))
            {
                var propertyBytes = new byte[5];
                compressedInput.Read(propertyBytes, 0, 5);

                var decompressedLength = new byte[8];
                compressedInput.Read(decompressedLength, 0, 8);
                var fileLength = BitConverter.ToInt64(decompressedLength, 0);

                lzmaDecoder.SetDecoderProperties(propertyBytes);
                lzmaDecoder.Code(compressedInput, decompressedStream, compressedInput.Length, fileLength, null);
            }

            return decompressedStream.ToArray();
        }
    }
}