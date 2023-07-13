// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// BinaryUtils.cs - A collection of functions to handle binary data.
// This code uses the Knuth-Morris-Pratt algorithm for pattern matching and string searching, developed by Donald Knuth, Vaughan Pratt, and James Morris.
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System;
using System.IO;
using System.Linq;

namespace Mac_EFI_Toolkit.Utils
{
    internal class BinaryUtils
    {

        #region Binary Find
        /// <summary>
        /// Finds the base of a byte pattern within a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        internal static int GetBasePosition(byte[] sourceBytes, byte[] pattern)
        {
            // Call the overload that takes a basePos parameter and sets it to 0.
            return GetBasePosition(sourceBytes, pattern, 0);
        }

        /// <summary>
        /// Finds the base of a byte pattern within a byte array, starting at a specified base base.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="basePosition">The base to start the search from.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        internal static int GetBasePosition(byte[] sourceBytes, byte[] pattern, int basePosition)
        {
            // Call the overload that takes a basePosition and maxSearchLength parameters and sets maxSearchLength to the remaining length of the sourceBytes array.
            return GetBasePosition(sourceBytes, pattern, basePosition, sourceBytes.Length - basePosition);
        }

        /// <summary>
        /// Finds the base of a byte pattern within a byte array, starting at a specified base and limiting the search length.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search in.</param>
        /// <param name="patternBytes">The byte pattern to search for.</param>
        /// <param name="basePosition">The base to start the search from.</param>
        /// <param name="maxSearchLength">The maximum length of the search within the byte array.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        internal static int GetBasePosition(byte[] sourceBytes, byte[] patternBytes, int basePosition, int maxSearchLength)
        {
            // Ensure that maxSearchLength is within the bounds of the sourceBytes array.
            maxSearchLength = Math.Min(maxSearchLength, sourceBytes.Length - basePosition);

            // Build the partial match table for the pattern using the Knuth-Morris-Pratt algorithm.
            int[] partialMatchTable = BuildPartialMatchTable(patternBytes);

            // Initialize the source and pattern indices.
            int sourceIndex = basePosition;
            int patternIndex = 0;

            // Iterate over the source bytes until the end or until the pattern is found or the maximum search length is reached.
            while (sourceIndex < sourceBytes.Length && sourceIndex - basePosition < maxSearchLength)
            {
                if (sourceBytes[sourceIndex] == patternBytes[patternIndex])
                {
                    // If the source byte matches the pattern byte, increment the indices.
                    sourceIndex++;
                    patternIndex++;

                    // If the pattern has been fully matched, return the base.
                    if (patternIndex == patternBytes.Length)
                    {
                        return sourceIndex - patternIndex;
                    }
                }
                else if (patternIndex > 0)
                {
                    // If the source byte does not match and we have partially matched the pattern, backtrack the pattern index.
                    patternIndex = partialMatchTable[patternIndex - 1];
                }
                else
                {
                    // If the source byte does not match and we have not partially matched the pattern, increment the source index.
                    sourceIndex++;
                }
            }

            // If the pattern is not found within the maximum search length, return -1.
            return -1;
        }

        /// <summary>
        /// Builds the partial match table for a byte pattern using the Knuth-Morris-Pratt algorithm.
        /// </summary>
        /// <param name="patternBytes">The byte pattern to build the table for.</param>
        /// <returns>An array of integers representing the partial match table.</returns>
        private static int[] BuildPartialMatchTable(byte[] patternBytes)
        {
            int[] table = new int[patternBytes.Length];
            int i = 0;
            int j = 1;
            while (j < patternBytes.Length)
            {
                if (patternBytes[i] == patternBytes[j])
                {
                    i++;
                    table[j] = i;
                    j++;
                }
                else if (i > 0)
                {
                    i = table[i - 1];
                }
                else
                {
                    table[j] = 0;
                    j++;
                }
            }
            return table;
        }
        #endregion

        #region Binary Read
        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given base.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="basePosition">The base in the byte array to read from.</param>
        /// <param name="length">The number of bytes to read.</param>
        /// <returns>The bytes read from the byte array.</returns>
        internal static byte[] GetBytesBaseLength(byte[] sourceBytes, int basePosition, int length)
        {
            if (basePosition < 0 || basePosition + length > sourceBytes.Length) return null;

            byte[] buffer = new byte[length];
            Buffer.BlockCopy(sourceBytes, basePosition, buffer, 0, length);
            return buffer;
        }

        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given base.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="basePosition">The starting base in the byte array to read from.</param>
        /// <param name="limitPosition">The ending base in the byte array to read from.</param>
        /// <returns>The bytes read from the byte array.</returns>
        internal static byte[] GetBytesBaseLimit(byte[] sourceBytes, int basePosition, int limitPosition)
        {
            if (limitPosition <= basePosition) return new byte[0]; // Nothing to read

            int length = limitPosition - basePosition;
            ArraySegment<byte> segment = new ArraySegment<byte>(sourceBytes, basePosition, length);
            return segment.ToArray();
        }

        /// <summary>
        /// Reads bytes from a byte array starting from a specified base and up to a specified terminating byte.
        /// </summary>
        /// <param name="sourceBytes">The byte array to read from.</param>
        /// <param name="basePosition">The base in the byte array to start reading from.</param>
        /// <param name="startByte">The starting byte to read from.</param>
        /// <param name="terminationBytes">The terminating byte params to stop reading at.</param>
        /// <returns>The bytes read from the byte array up to the terminating byte.</returns>
        internal static byte[] GetBytesDelimited(byte[] sourceBytes, int basePosition, byte startByte, params byte[] terminationBytes)
        {
            int startIndex = Array.IndexOf(sourceBytes, startByte, basePosition);
            if (startIndex < 0 || startIndex == sourceBytes.Length - 1)
                return null;

            startIndex++;
            while (startIndex < sourceBytes.Length && sourceBytes[startIndex] == startByte)
            {
                startIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                while (startIndex < sourceBytes.Length && !terminationBytes.Contains(sourceBytes[startIndex]))
                {
                    ms.WriteByte(sourceBytes[startIndex]);
                    startIndex++;
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Checks if a byte array is empty (0xFF).
        /// </summary>
        /// <param name="sourceBytes">The byte array to check.</param>
        /// <returns>True if the byte array is empty or contains only 0xFF values; otherwise, false.</returns>
        internal static bool IsByteBlockEmpty(byte[] sourceBytes)
        {
            if (sourceBytes == null)
            {
                throw new ArgumentNullException(nameof(sourceBytes));
            }

            for (int i = 0; i < sourceBytes.Length; i++)
            {
                if (sourceBytes[i] != 0xFF)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Compares two byte arrays to determine if they match in size and content.
        /// </summary>
        /// <param name="array1">The first byte array to compare.</param>
        /// <param name="array2">The second byte array to compare.</param>
        /// <returns>True if the byte arrays have the same size and content, false otherwise.</returns>
        internal static bool ByteArraysMatch(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            return array1.SequenceEqual(array2);
        }
        #endregion

        #region Binary Edit
        /// <summary>
        /// Overwrites a sequence of bytes in a byte array at a given base with new bytes.
        /// </summary>
        /// <param name="sourceBytes">The byte array to overwrite.</param>
        /// <param name="basePosition">The base in the byte array to overwrite at.</param>
        /// <param name="newBytes">The new bytes to write.</param>
        internal static void OverwriteBytesAtBase(byte[] sourceBytes, int basePosition, byte[] newBytes)
        {
            if (basePosition < 0 || basePosition + newBytes.Length > sourceBytes.Length)
                throw new ArgumentOutOfRangeException(nameof(basePosition), "Base position is out of range.");

            Buffer.BlockCopy(newBytes, 0, sourceBytes, basePosition, newBytes.Length);
        }

        /// <summary>
        /// Removes any trailing padding bytes from a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to remove the trailing padding bytes from.</param>
        /// <param name="paddingByte">The padding byte to remove.</param>
        /// <returns>The byte array with any trailing padding bytes removed.</returns>
        internal static byte[] RemovePadding(byte[] sourceBytes, byte paddingByte)
        {
            if (sourceBytes == null)
                throw new ArgumentNullException(nameof(sourceBytes));

            int end = sourceBytes.Length - 1;

            // Find the index of the last non-padding byte
            while (end >= 0 && sourceBytes[end] == paddingByte)
            {
                end--;
            }

            // If all bytes are padding, return an empty byte array
            if (end < 0)
            {
                return new byte[0];
            }

            // Create a new byte array without the trailing padding bytes
            byte[] result = new byte[end + 1];
            Array.Copy(sourceBytes, result, end + 1);
            return result;
        }

        /// <summary>
        /// Fills a byte array with 0xFF values.
        /// </summary>
        /// <param name="sourceBytes">The byte array to fill with 0xFF values.</param>
        internal static void EraseByteArray(byte[] sourceBytes, byte eraseByte)
        {
            if (sourceBytes == null)
                throw new ArgumentNullException(nameof(sourceBytes));

            for (int i = 0; i < sourceBytes.Length; i++)
            {
                sourceBytes[i] = eraseByte;
            }
        }

        /// <summary>
        /// Patches the given Fsys store byte array with a new CRC value.
        /// </summary>
        /// <param name="fsysStore">The byte array representing the Fsys store.</param>
        /// <param name="newCrc">The new CRC value to be patched.</param>
        /// <returns>The patched Fsys store byte array.</returns>
        internal static byte[] PatchFsysCrc(byte[] fsysStore, uint newCrc)
        {
            // Check if the size of the byte array is valid
            if (fsysStore.Length < FWBase.FSYS_RGN_SIZE)
                throw new ArgumentException(nameof(fsysStore), "Given bytes are too small.");

            if (fsysStore.Length > FWBase.FSYS_RGN_SIZE)
                throw new ArgumentException(nameof(fsysStore), "Given bytes are too large.");

            // Convert the new CRC value to bytes
            byte[] newCrcBytes = BitConverter.GetBytes(newCrc);

            // Write the new bytes back to the Fsys store at the appropriate base
            OverwriteBytesAtBase(fsysStore, FWBase.FSYS_CRC_POS, newCrcBytes);

            // Return the patched data
            return fsysStore;
        }

        /// <summary>
        /// Patches a binaries Fsys store with the correct crc value.
        /// </summary>
        /// <param name="sourceBytes">The byte array representing the source binary file.</param>
        /// <param name="fsysBase">The base of the Fsys store within the binary file.</param>
        /// <param name="fsysStore">The byte array representing the Fsys store.</param>
        /// <param name="uiNewCrc">The new CRC value to be patched in the Fsys store.</param>
        /// <returns>The patched file byte array, or null if the new calculated crc does not match the crc in the Fsys store.</returns>
        internal static byte[] MakeFsysCrcPatchedBinary(byte[] sourceBytes, int fsysBase, byte[] fsysStore, uint uiNewCrc)

        {
            // Create a new byte array to hold the patched binary
            byte[] patchedBytes = new byte[sourceBytes.Length];
            Array.Copy(sourceBytes, patchedBytes, sourceBytes.Length);

            // Patch the Fsys store crc
            byte[] patchedStore = PatchFsysCrc(fsysStore, uiNewCrc);

            // Overwrite the loaded Fsys crc32 with the newly calculated crc32
            OverwriteBytesAtBase(patchedBytes, fsysBase, patchedStore);

            // Load the Fsys store from the new binary
            FsysStore newBinaryFsys = FWBase.GetFsysStoreData(patchedBytes, false);

            // Compare the new checksums
            if (newBinaryFsys.CrcString != newBinaryFsys.CrcCalcString)
            {
                return null;
            }

            return patchedBytes;
        }
        #endregion

    }
}