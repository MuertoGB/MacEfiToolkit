// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// T2ROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.T2.Structs;
using Mac_EFI_Toolkit.Utils;
using System.Text;

namespace Mac_EFI_Toolkit.T2
{
    internal class T2ROM
    {

        #region Internal Members
        internal static string iBootVersion = null;
        internal static SCfgData ScfgSectionData;
        #endregion

        #region Private Members
        private static readonly Encoding _utf8 = Encoding.UTF8;
        #endregion

        #region Parse Fimware
        internal static void LoadFirmwareBaseData(byte[] sourceBytes)
        {
            iBootVersion = GetIbootVersion(sourceBytes);
            ScfgSectionData = GetSCfgData(sourceBytes);
        }

        internal static void ResetFirmwareBaseData()
        {
            iBootVersion = null;
            ScfgSectionData = default;
        }

        internal static bool IsValidImage(byte[] source)
        {
            int ibootSig =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.IBOOT_VER_SIG,
                    0);

            return (ibootSig != -1);
        }
        #endregion

        #region IBoot
        internal static string GetIbootVersion(byte[] source)
        {
            int ibootSig =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.IBOOT_VER_SIG, 0);

            if (ibootSig != -1) // Signature found
            {
                // Get byte containing data length
                byte[] lByte =
                    BinaryUtils.GetBytesBaseLength(
                    source,
                    ibootSig + 0x5,
                    1);

                // Convert data length to unsigned int8
                byte dataSize = (byte)lByte[0];

                // Get iboot version data bytes
                byte[] stringData =
                    BinaryUtils.GetBytesBaseLength(
                        source,
                        ibootSig + 0x6,
                        dataSize);

                return _utf8.GetString(stringData);
            }

            return AppStrings.AS_UNKNOWN;
        }
        #endregion

        #region SCfg
        internal static SCfgData GetSCfgData(byte[] source)
        {
            int scfgBase =
                BinaryUtils.GetBaseAddress(
                    source,
                    ROMSigs.SCFG_HEADER_SIG);

            if (scfgBase == -1)
                return DefaultScfgData();

            // Get byte containing scfg store length
            byte[] lByte =
                BinaryUtils.GetBytesBaseLength(
                    source,
                    scfgBase + 0x4,
                    1);

            // Convert data length to unsigned int8
            byte dataSize = (byte)lByte[0];

            if (dataSize == 0)
                return DefaultScfgData();

            // Extract Scfg store into buffer
            byte[] scfgBytes =
                BinaryUtils.GetBytesBaseLength(
                    source,
                    scfgBase,
                    dataSize);

            //* Left off here *//

            return new SCfgData
            {
                StoreBase = scfgBase,
                StoreSize = dataSize,
                StoreBytes = scfgBytes
            };
        }

        private static SCfgData DefaultScfgData()
        {
            return new SCfgData
            {
                StoreBase = -1,
                StoreSize = 0,
                StoreBytes = null
            };
        }
        #endregion

    }
}