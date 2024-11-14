// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IME.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Tools;

namespace Mac_EFI_Toolkit.Firmware
{
    class IME
    {
        #region Internal Members
        internal static readonly byte[] FPT_SIGNATURE = { 0x24, 0x46, 0x50, 0x54 };
        internal static readonly byte[] MN2_SIGNATURE = { 0x00, 0x00, 0x24, 0x4D, 0x4E, 0x32 };
        #endregion

        #region Private Members
        private static string _default = "0.0.0.0";
        #endregion

        internal static string GetVersionData(byte[] sourceBytes, ImeVersionType versionType)
        {
            int headerPos = -1;
            int dataLength = 0;
            string version = null;

            switch (versionType)
            {
                case ImeVersionType.FlashImageTool:
                    headerPos = BinaryTools.GetBaseAddress(sourceBytes, FPT_SIGNATURE, (int)IFD.ME_REGION_BASE, (int)IFD.ME_REGION_SIZE);
                    dataLength = 0x20;
                    break;

                case ImeVersionType.ManagementEngine:
                    headerPos = BinaryTools.GetBaseAddress(sourceBytes, MN2_SIGNATURE, (int)IFD.ME_REGION_BASE, (int)IFD.ME_REGION_SIZE);
                    dataLength = 0x10;
                    break;
            }

            if (headerPos != -1)
            {
                if (versionType == ImeVersionType.ManagementEngine)
                {
                    headerPos += 2;
                }

                byte[] headerBytes = BinaryTools.GetBytesBaseLength(sourceBytes, headerPos, dataLength);

                if (headerBytes != null)
                {
                    if (versionType == ImeVersionType.FlashImageTool)
                    {
                        FPTHeader fptHeader = Helper.DeserializeHeader<FPTHeader>(headerBytes);
                        version = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                    }
                    else if (versionType == ImeVersionType.ManagementEngine)
                    {
                        MN2Manifest mn2Header = Helper.DeserializeHeader<MN2Manifest>(headerBytes);
                        version = $"{mn2Header.EngineMajor}.{mn2Header.EngineMinor}.{mn2Header.EngineHotfix}.{mn2Header.EngineBuild}";
                    }
                }
            }

            if (string.IsNullOrEmpty(version) || version == _default)
            {
                return null;
            }

            return version;
        }
    }
}