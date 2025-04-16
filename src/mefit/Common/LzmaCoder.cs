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
        internal static byte[] DecompressBytes(byte[] sourcebuffer)
        {
            // Create a new instance of the Decoder class.
            SevenZip.Compression.LZMA.Decoder lzmaDecoder = new SevenZip.Compression.LZMA.Decoder();

            // Create a memory stream to store the decompressed data.
            MemoryStream streamBuffer = new MemoryStream();

            try
            {
                // Create a memory stream to hold the compressed input data.
                using (MemoryStream streamInput = new MemoryStream(sourcebuffer))
                {
                    // Read the first 5 bytes which contain decoder property data.
                    byte[] propertyBytes = new byte[5];

                    streamInput.Read(propertyBytes, 0, 5);

                    // Read the next 8 bytes which represent the decompressed data length.
                    byte[] decompressedLength = new byte[8];
                    streamInput.Read(decompressedLength, 0, 8);

                    // Convert the 8-byte array to a long, representing the total file length.
                    long fileLength = BitConverter.ToInt64(decompressedLength, 0);

                    // Set the decoder properties using the propertyBytes.
                    lzmaDecoder.SetDecoderProperties(propertyBytes);

                    // Decode the compressed input stream and write the result to decoderStream.
                    lzmaDecoder.Code(streamInput, streamBuffer, streamInput.Length, fileLength, null);

                    // Validate the decompressed length.
                    if (streamBuffer.Length != fileLength)
                    {
                        Logger.WriteLine($"Decompressed length mismatch. Expected: {fileLength}, Actual: {streamBuffer.Length}", Logger.LogType.Application);
                    }
                }

                // Return the decompressed data as a byte array.
                return streamBuffer.ToArray();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DecompressBytes), e.GetType(), e.Message);
                return null;
            }
        }

        internal static bool IsValidLzmaHeader(byte[] sourcebuffer)
        {
            if (sourcebuffer.Length < 5)
            {
                // Header is too short to be valid.
                return false;
            }

            byte properties = sourcebuffer[0];
            int lc = properties % 9;        // Literal context bits
            int remainder = properties / 9;
            int lp = remainder % 5;         // Literal position bits.
            int pb = remainder / 5;         // Position bits.

            if (lc < 0 || lc > 8 || lp < 0 || lp > 4 || pb < 0 || pb > 4)
            {
                // Invalid properties byte.
                Console.WriteLine($"{nameof(IsValidLzmaHeader)}: Invalid properties byte: lc={lc}, lp={lp}, pb={pb}");
                return false;
            }

            int dictSize = BitConverter.ToInt32(sourcebuffer, 1);

            bool IsPow2(int i)
            {
                return (i > 0) && ((i & (i - 1)) == 0);
            }

            if (dictSize <= 0 || !IsPow2(dictSize))
            {
                // Invalid dictionary size <= 0 or not a power of 2.
                Console.WriteLine($"{nameof(IsValidLzmaHeader)}: Invalid dictionary size: {dictSize}");
                return false;
            }

            return true;
        }
    }
}