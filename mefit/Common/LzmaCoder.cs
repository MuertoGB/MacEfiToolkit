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
        internal static byte[] Decompress(byte[] sourceBytes)
        {
            var decoder = new LzmaDecoder();
            var msOutput = new MemoryStream();

            using (var msInput = new MemoryStream(sourceBytes))
            {
                var lzmaProp = new byte[5];
                msInput.Read(lzmaProp, 0, 5); // Sig + Dict Size

                var decompLength = new byte[8];
                msInput.Read(decompLength, 0, 8);
                var fileLength = BitConverter.ToInt64(decompLength, 0); // Decompressed Size

                decoder.SetDecoderProperties(lzmaProp);
                decoder.Code(msInput, msOutput, msInput.Length, fileLength, null);
            }

            return msOutput.ToArray();
        }
    }
}