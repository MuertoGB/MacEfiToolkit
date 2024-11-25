// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// LzmaCoder.cs - Handles LZMA decompression
// Released under the GNU GLP v3.0

using System;
using System.IO;

namespace Mac_EFI_Toolkit.Common
{
    class LzmaCoder
    {
        internal static byte[] DecompressBytes(byte[] sourceBytes)
        {
            // Create a new instance of the Decoder class.
            SevenZip.Compression.LZMA.Decoder lzmaDecoder = new SevenZip.Compression.LZMA.Decoder();

            // Create a memory stream to store the decompressed data.
            MemoryStream msBuffer = new MemoryStream();

            try
            {
                // Create a memory stream to hold the compressed input data.
                using (MemoryStream msInput = new MemoryStream(sourceBytes))
                {
                    // Read the first 5 bytes which contain decoder property data.
                    byte[] bProperties = new byte[5];

                    msInput.Read(bProperties, 0, 5);

                    // Read the next 8 bytes which represent the decompressed data length.
                    byte[] bDecompressedLength = new byte[8];
                    msInput.Read(bDecompressedLength, 0, 8);

                    // Convert the 8-byte array to a long, representing the total file length.
                    long lFileLength = BitConverter.ToInt64(bDecompressedLength, 0);

                    // Set the decoder properties using the propertyBytes.
                    lzmaDecoder.SetDecoderProperties(bProperties);

                    // Decode the compressed input stream and write the result to decoderStream.
                    lzmaDecoder.Code(msInput, msBuffer, msInput.Length, lFileLength, null);

                    // Validate the decompressed length.
                    if (msBuffer.Length != lFileLength)
                    {
                        Logger.WriteLine($"Decompressed length mismatch. Expected: {lFileLength}, Actual: {msBuffer.Length}", LogType.Application);
                    }
                }

                // Return the decompressed data as a byte array.
                return msBuffer.ToArray();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DecompressBytes), e.GetType(), e.Message);
                return null;
            }
        }
    }
}