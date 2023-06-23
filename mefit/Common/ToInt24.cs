using System;

namespace Mac_EFI_Toolkit.Common
{
    public class BitConvert
    {
        public static int ToInt24(byte[] bytes)
        {
            if (bytes.Length != 3)
            {
                throw new ArgumentException("Byte array must be 3 bytes long.", nameof(bytes));
            }

            return (bytes[2] << 16) | (bytes[1] << 8) | bytes[0];
        }
    }
}