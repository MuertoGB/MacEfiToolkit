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
            // Create a new instance of the Decoder class.
            Decoder decoder = new Decoder();

            // Create a memory stream to store the decompressed data.
            MemoryStream decoderStream = new MemoryStream();

            try
            {
                // Create a memory stream to hold the compressed input data.
                using (MemoryStream compressedInput = new MemoryStream(sourceBytes))
                {
                    // Read the first 5 bytes which contain decoder property data.
                    byte[] propertyBytes = new byte[5];

                    compressedInput.Read(propertyBytes, 0, 5);

                    // Read the next 8 bytes which represent the decompressed data length.
                    byte[] decompressedLength = new byte[8];

                    compressedInput.Read(decompressedLength, 0, 8);

                    // Convert the 8-byte array to a long, representing the total file length.
                    long fileLength = BitConverter.ToInt64(decompressedLength, 0);

                    // Set the decoder properties using the propertyBytes.
                    decoder.SetDecoderProperties(propertyBytes);

                    // Decode the compressed input stream and write the result to decoderStream.
                    decoder.Code(compressedInput, decoderStream, compressedInput.Length, fileLength, null);
                }

                // Return the decompressed data as a byte array.
                return decoderStream.ToArray();
            }
            catch (Exception e)
            {
                Logger.WriteError(nameof(DecompressBytes), e.GetType(), e.Message);
                return null;
            }
        }
    }
}