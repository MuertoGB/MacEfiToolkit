// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Utilities
// BinaryUtils.cs - A collection of functions to handle binary data.
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Linq;

namespace Mac_EFI_Toolkit.Utils
{
    internal class BinaryUtils
    {

        #region Binary Find
        /// <summary>
        /// Finds the offset of a byte pattern within a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <returns>The offset of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        internal static long FindOffset(byte[] sourceBytes, byte[] pattern)
        {
            return FindOffset(sourceBytes, pattern, 0);
        }

        /// <summary>
        /// Finds the offset of a byte pattern within a byte array, starting at a specified base offset.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="baseOffset">The base offset to start the search from.</param>
        /// <returns>The offset of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        internal static long FindOffset(byte[] sourceBytes, byte[] pattern, long baseOffset)
        {
            for (int i = (int)baseOffset; i <= sourceBytes.Length - pattern.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (sourceBytes[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Binary Read
        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given offset.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="offset">The offset in the byte array to read from.</param>
        /// <param name="length">The number of bytes to read.</param>
        /// <returns>The bytes read from the byte array.</returns>
        internal static byte[] ReadBytesAtOffset(byte[] sourceBytes, long offset, int length)
        {
            if (offset < 0 || offset + length > sourceBytes.Length)
            {
                return null;
            }

            byte[] buffer = new byte[length];
            Buffer.BlockCopy(sourceBytes, (int)offset, buffer, 0, length);
            return buffer;
        }

        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given offset.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="startOffset">The starting offset in the byte array to read from.</param>
        /// <param name="endOffset">The ending offset in the byte array to read from.</param>
        /// <returns>The bytes read from the byte array.</returns>
        internal static byte[] ReadBytesBetweenOffsets(byte[] sourceBytes, long startOffset, long endOffset)
        {
            if (endOffset <= startOffset) return new byte[0]; // Nothing to read

            long length = endOffset - startOffset;
            var segment = new ArraySegment<byte>(sourceBytes, (int)startOffset, (int)length);
            return segment.ToArray();
        }

        /// <summary>
        /// Reads bytes from a byte array starting from a specified offset and up to a specified terminating byte.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="offset">The offset in the byte array to start reading from.</param>
        /// <param name="startByte">The starting byte to read from.</param>
        /// <param name="terminationByte">The terminating byte to stop reading at.</param>
        /// <returns>The bytes read from the byte array up to the terminating byte.</returns>
        internal static byte[] ReadBytesAtOffsetByteDelimited(byte[] sourceBytes, long offset, byte startByte, byte terminationByte)
        {
            int startIndex = Array.IndexOf(sourceBytes, startByte, (int)offset);
            if (startIndex < 0 || startIndex == sourceBytes.Length - 1) return null;

            startIndex++; // Skip the start byte
            while (startIndex < sourceBytes.Length && sourceBytes[startIndex] == startByte)
            {
                startIndex++; // Skip any leading bytes
            }

            using (MemoryStream ms = new MemoryStream())
            {
                while (startIndex < sourceBytes.Length && sourceBytes[startIndex] != terminationByte)
                {
                    ms.WriteByte(sourceBytes[startIndex]);
                    startIndex++;
                }

                return ms.ToArray();
            }
        }

        //internal static byte[] ReadBytesAtOffsetByteDelimited(byte[] sourceBytes, long offset, byte startByte, byte terminationByte)
        //{
        //    int startIndex = Array.IndexOf(sourceBytes, startByte, (int)offset);
        //    if (startIndex < 0 || startIndex == sourceBytes.Length - 1) return null;

        //    startIndex++; // Skip the start byte
        //    while (startIndex < sourceBytes.Length && sourceBytes[startIndex] == startByte)
        //    {
        //        startIndex++; // Skip any leading leading bytes
        //    }

        //    List<byte> byteList = new List<byte>();
        //    while (startIndex < sourceBytes.Length && sourceBytes[startIndex] != terminationByte)
        //    {
        //        byteList.Add(sourceBytes[startIndex]);
        //        startIndex++;
        //    }

        //    return byteList.ToArray();
        //}
        #endregion

        #region Binary Edit
        /// <summary>
        /// Overwrites a sequence of bytes in a byte array at a given offset with new bytes.
        /// </summary>
        /// <param name="sourceBytes">The byte array to overwrite.</param>
        /// <param name="offset">The offset in the byte array to overwrite at.</param>
        /// <param name="newBytes">The new bytes to write.</param>
        internal static void OverwriteBytesAtOffset(byte[] sourceBytes, long offset, byte[] newBytes)
        {
            if (offset < 0 || offset + newBytes.Length > sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "Offset is out of range.");
            }

            Buffer.BlockCopy(newBytes, 0, sourceBytes, (int)offset, newBytes.Length);
        }

        /// <summary>
        /// Removes any trailing 0xFF bytes from a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to remove the trailing 0xFF bytes from.</param>
        /// <returns>The byte array with any trailing 0xFF bytes removed.</returns>
        public static byte[] RemoveTrailingFFPadding(byte[] bytes)
        {
            int end = bytes.Length - 1;
            while (end >= 0 && bytes[end] == 0xFF)
            {
                end--;
            }
            if (end < 0)
            {
                return new byte[0];
            }

            byte[] result = new byte[end + 1];
            Array.Copy(bytes, result, end + 1);
            return result;
        }

        #endregion

    }
}