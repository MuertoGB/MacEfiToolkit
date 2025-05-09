// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// BinaryUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Linq;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class BinaryUtils
    {
        #region Binary Find
        /// <summary>
        /// Finds the base of a byte pattern within a byte array.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        public static int GetBaseAddress(byte[] sourcebuffer, byte[] pattern)
        {
            // Call the overload that takes a basePos parameter and sets it to 0.
            return GetBaseAddress(sourcebuffer, pattern, 0);
        }

        /// <summary>
        /// Finds the base of a byte pattern within a byte array, starting at a specified base base.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="baseposition">The base to start the search from.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        public static int GetBaseAddress(byte[] sourcebuffer, byte[] pattern, int baseposition)
        {
            // Call the overload that takes a basePosition and maxSearchLength parameters and sets maxSearchLength to the remaining length of the sourceBytes array.
            return GetBaseAddress(sourcebuffer, pattern, baseposition, sourcebuffer.Length - baseposition);
        }

        /// <summary>
        /// Finds the base of a byte pattern within a byte array, starting at a specified base and limiting the search length.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="baseposition">The base to start the search from.</param>
        /// <param name="maxsearchlength">The maximum length of the search within the byte array.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        public static int GetBaseAddress(byte[] sourcebuffer, byte[] pattern, int baseposition, int maxsearchlength)
        {
            return FindPatternBase(sourcebuffer, pattern, baseposition, maxsearchlength);
        }

        /// <summary>
        /// Finds the base of a byte pattern within a byte array, starting at a specified base and limiting the search to the predefined limit address.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="baseposition">The base to start the search from.</param>
        /// <param name="limitposition">The address at which the search is limited.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        public static int GetBaseAddressUpToLimit(byte[] sourcebuffer, byte[] pattern, int baseposition, int limitposition)
        {
            int maxSearchLength = limitposition - baseposition;
            return FindPatternBase(sourcebuffer, pattern, baseposition, maxSearchLength);
        }

        /// <summary>
        /// Common method to find the base of a byte pattern within a byte array, starting at a specified base and limiting the search length.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to search in.</param>
        /// <param name="pattern">The byte pattern to search for.</param>
        /// <param name="baseposition">The base to start the search from.</param>
        /// <param name="maxsearchlength">The maximum length of the search within the byte array.</param>
        /// <returns>The base of the byte pattern within the byte array, or -1 if the pattern is not found.</returns>
        private static int FindPatternBase(byte[] sourcebuffer, byte[] pattern, int baseposition, int maxsearchlength)
        {
            maxsearchlength = Math.Min(maxsearchlength, sourcebuffer.Length - baseposition);
            int[] iPartialMatchTable = BuildPartialMatchTable(pattern);

            int iSourceIndex = baseposition;
            int iPatternIndex = 0;

            while (iSourceIndex < sourcebuffer.Length && iSourceIndex - baseposition < maxsearchlength)
            {
                if (sourcebuffer[iSourceIndex] == pattern[iPatternIndex])
                {
                    iSourceIndex++;
                    iPatternIndex++;

                    if (iPatternIndex == pattern.Length)
                    {
                        return iSourceIndex - iPatternIndex;
                    }
                }
                else if (iPatternIndex > 0)
                {
                    iPatternIndex = iPartialMatchTable[iPatternIndex - 1];
                }
                else
                {
                    iSourceIndex++;
                }
            }

            return -1;
        }

        /// <summary>
        /// Builds the partial match table for a byte pattern using the Knuth-Morris-Pratt algorithm.
        /// </summary>
        /// <param name="pattern">The byte pattern to build the table for.</param>
        /// <returns>An array of integers representing the partial match table.</returns>
        private static int[] BuildPartialMatchTable(byte[] pattern)
        {
            int[] arrTable = new int[pattern.Length];
            int i = 0;
            int j = 1;

            while (j < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    i++;
                    arrTable[j] = i;
                    j++;
                }
                else if (i > 0)
                {
                    i = arrTable[i - 1];
                }
                else
                {
                    arrTable[j] = 0;
                    j++;
                }
            }

            return arrTable;
        }
        #endregion

        #region Binary Read
        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given base.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to read from.</param>
        /// <param name="baseposition">The base in the byte array to read from.</param>
        /// <param name="readlength">The number of bytes to read.</param>
        /// <returns>The bytes read from the byte array.</returns>
        public static byte[] GetBytesBaseLength(byte[] sourcebuffer, int baseposition, int readlength)
        {
            if (baseposition < 0 || baseposition + readlength > sourcebuffer.Length)
            {
                return null;
            }

            byte[] buffer = new byte[readlength];
            Buffer.BlockCopy(sourcebuffer, baseposition, buffer, 0, readlength);

            return buffer;
        }

        /// <summary>
        /// Reads a specified number of bytes from a byte array at a given base.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to read from.</param>
        /// <param name="baseposition">The starting base in the byte array to read from.</param>
        /// <param name="limitposition">The ending base in the byte array to read from.</param>
        /// <returns>The bytes read from the byte array.</returns>
        public static byte[] GetBytesBaseLimit(byte[] sourcebuffer, int baseposition, int limitposition)
        {
            if (limitposition <= baseposition)
            {
                return new byte[0];
            }

            int iLength = limitposition - baseposition;
            ArraySegment<byte> arrBufferSegment = new ArraySegment<byte>(sourcebuffer, baseposition, iLength);

            return arrBufferSegment.ToArray();
        }

        /// <summary>
        /// Reads bytes from a byte array starting from a specified base and up to a specified terminating byte.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to read from.</param>
        /// <param name="baseposition">The base in the byte array to start reading from.</param>
        /// <param name="initialbyte">The starting byte to read from.</param>
        /// <param name="terminationbytes">The terminating byte params to stop reading at.</param>
        /// <returns>The bytes read from the byte array up to the terminating byte.</returns>
        public static byte[] GetBytesDelimited(byte[] sourcebuffer, int baseposition, byte initialbyte, params byte[] terminationbytes)
        {
            int iIndex = Array.IndexOf(sourcebuffer, initialbyte, baseposition);

            if (iIndex < 0 || iIndex == sourcebuffer.Length - 1)
            {
                return null;
            }

            iIndex++;

            while (iIndex < sourcebuffer.Length && sourcebuffer[iIndex] == initialbyte)
            {
                iIndex++;
            }

            using (MemoryStream msBuffer = new MemoryStream())
            {
                while (iIndex < sourcebuffer.Length && !terminationbytes.Contains(sourcebuffer[iIndex]))
                {
                    msBuffer.WriteByte(sourcebuffer[iIndex]);
                    iIndex++;
                }

                return msBuffer.ToArray();
            }
        }

        /// <summary>
        /// Checks if a byte array is empty (0xFF).
        /// </summary>
        /// <param name="sourcebuffer">The byte array to check.</param>
        /// <returns>True if the byte array is empty or contains only 0xFF values; otherwise, false.</returns>
        public static bool IsByteArrayFF(byte[] sourcebuffer)
        {
            if (sourcebuffer == null)
            {
                throw new ArgumentNullException(nameof(sourcebuffer));
            }

            for (int i = 0; i < sourcebuffer.Length; i++)
            {
                if (sourcebuffer[i] != 0xFF)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares two byte arrays to determine if they match in size and content.
        /// </summary>
        /// <param name="array1">The first byte array to compare.</param>
        /// <param name="array2">The second byte array to compare.</param>
        /// <returns>True if the byte arrays have the same size and content, false otherwise.</returns>
        public static bool ByteArraysMatch(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null)
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            return array1.SequenceEqual(array2);
        }
        #endregion

        #region Binary Edit
        /// <summary>
        /// Overwrites a sequence of bytes in a byte array at a given base with new bytes.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to overwrite.</param>
        /// <param name="baseposition">The base in the byte array to overwrite at.</param>
        /// <param name="newbytedata">The new bytes to write.</param>
        public static void OverwriteBytesAtBase(byte[] sourcebuffer, int baseposition, byte[] newbytedata)
        {
            if (baseposition < 0 || baseposition + newbytedata.Length > sourcebuffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(baseposition), "Base position is out of range.");
            }

            Buffer.BlockCopy(newbytedata, 0, sourcebuffer, baseposition, newbytedata.Length);
        }

        /// <summary>
        /// Fills a byte array with 0xFF values.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to fill with 0xFF values.</param>
        public static void EraseByteArray(byte[] sourcebuffer)
        {
            if (sourcebuffer == null)
            {
                throw new ArgumentNullException(nameof(sourcebuffer));
            }

            for (int i = 0; i < sourcebuffer.Length; i++)
            {
                sourcebuffer[i] = 0xFF;
            }
        }

        /// <summary>
        /// Creates a clone of the specified byte array.
        /// </summary>
        /// <param name="sourcebuffer">The byte array to clone.</param>
        /// <returns>A new byte array containing a copy of the elements from the original buffer.</returns>
        public static byte[] CloneBuffer(byte[] sourcebuffer)
        {
            if (sourcebuffer == null)
            {
                throw new ArgumentNullException(nameof(sourcebuffer));
            }

            return (byte[])sourcebuffer.Clone();
        }
        #endregion
    }
}