// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// LzmaCoder.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utilities;
using SevenZip.Compression.LZMA;
using System;
using System.IO;

namespace Mac_EFI_Toolkit.Common
{
    public static class LzmaCoder
    {
        public static byte[] DecompressLzmaArchive(byte[] sourcebuffer)
        {
            try
            {
                using (MemoryStream streamInput = new MemoryStream(sourcebuffer))
                using (MemoryStream streamBuffer = new MemoryStream())
                {
                    // Create LZMA decoder instance.
                    Decoder lzmaCoder = new Decoder();

                    // Read decoder properties and the decompressed data length.
                    byte[] propertyBytes = new byte[5];
                    byte[] decompressedLength = new byte[8];
                    streamInput.Read(propertyBytes, 0, 5);
                    streamInput.Read(decompressedLength, 0, 8);

                    long fileLength = BitConverter.ToInt64(decompressedLength, 0);

                    // Set the decoder properties and decode the stream.
                    lzmaCoder.SetDecoderProperties(propertyBytes);
                    lzmaCoder.Code(streamInput, streamBuffer, streamInput.Length, fileLength, null);

                    // Check the decompressed length matches the expected file length.
                    if (streamBuffer.Length != fileLength)
                    {
                        Logger.WriteLine($"Decompressed length mismatch. Expected: {fileLength}, Actual: {streamBuffer.Length}", Logger.LogType.Application);
                    }

                    return streamBuffer.ToArray();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(DecompressLzmaArchive), e.GetType(), e.Message);
                return null;
            }
        }

        public static bool IsValidLzmaHeader(byte[] sourcebuffer)
        {
            // Ensure the buffer has enough length.
            if (sourcebuffer.Length < 5) return false;

            byte properties = sourcebuffer[0];
            int lc = properties % 9;  // Literal context bits.
            int lp = (properties / 9) % 5;  // Literal position bits.
            int pb = (properties / 9) / 5;  // Position bits.

            // Validate the properties byte.
            if (lc < 0 || lc > 8 || lp < 0 || lp > 4 || pb < 0 || pb > 4)
            {
                Logger.WriteLine($"{nameof(IsValidLzmaHeader)}: Invalid properties byte: lc={lc}, lp={lp}, pb={pb}", Logger.LogType.Application);
                return false;
            }

            // Check dictionary size.
            int dictSize = BitConverter.ToInt32(sourcebuffer, 1);

            if (dictSize <= 0 || !MathUtils.IsPowerOfTwo(dictSize))
            {
                Logger.WriteLine($"{nameof(IsValidLzmaHeader)}: Invalid dictionary size: {dictSize}", Logger.LogType.Application);
                return false;
            }

            return true;
        }
    }
}