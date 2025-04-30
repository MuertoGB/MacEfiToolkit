// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// MathUtils.cs
// Released under the GNU GLP v3.0

using System;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class MathUtils
    {
        public static int ToInt24(byte[] inputbytes)
        {
            if (inputbytes.Length != 3)
            {
                throw new ArgumentException("Byte data must be 3 bytes long.", nameof(inputbytes));
            }

            return (inputbytes[2] << 16) | (inputbytes[1] << 8) | inputbytes[0];
        }

        public static bool IsPowerOfTwo(int number)
        {
            return (number > 0) && ((number & (number - 1)) == 0);
        }

        public static double CalculateShannonEntropy(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return 0.0;
            }

            int[] frequencies = new int[256];

            foreach (byte b in data)
            {
                frequencies[b]++;
            }

            double entropy = 0.0;
            int dataLength = data.Length;

            for (int i = 0; i < 256; i++)
            {
                if (frequencies[i] > 0)
                {
                    double probability = (double)frequencies[i] / dataLength;
                    entropy -= probability * Math.Log(probability, 2);
                }
            }

            return entropy;
        }
    }
}