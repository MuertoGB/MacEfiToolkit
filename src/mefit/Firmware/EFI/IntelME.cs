// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IntelME.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Tools;

namespace Mac_EFI_Toolkit.Firmware
{
    class IntelME
    {
        #region Internal Members
        internal static readonly byte[] FPTMarker = { 0x24, 0x46, 0x50, 0x54 };
        internal static readonly byte[] MN2Marker = { 0x00, 0x00, 0x24, 0x4D, 0x4E, 0x32 };
        #endregion

        #region Private Members
        private static string _default = "0.0.0.0";
        #endregion

        internal static string GetVersionData(byte[] sourcebytes, ImeVersionType versiontype)
        {
            int iHeaderPosition = -1;
            int iLength = 0;
            string strVersion = null;

            switch (versiontype)
            {
                case ImeVersionType.FlashImageTool:
                    iHeaderPosition = BinaryTools.GetBaseAddress(sourcebytes, FPTMarker, (int)FlashDescriptor.MeBase, (int)FlashDescriptor.MeSize);
                    iLength = 0x20;
                    break;

                case ImeVersionType.ManagementEngine:
                    iHeaderPosition = BinaryTools.GetBaseAddress(sourcebytes, MN2Marker, (int)FlashDescriptor.MeBase, (int)FlashDescriptor.MeSize);
                    iLength = 0x10;
                    break;
            }

            if (iHeaderPosition != -1)
            {
                if (versiontype == ImeVersionType.ManagementEngine)
                {
                    iHeaderPosition += 2;
                }

                byte[] bHeaderData = BinaryTools.GetBytesBaseLength(sourcebytes, iHeaderPosition, iLength);

                if (bHeaderData != null)
                {
                    if (versiontype == ImeVersionType.FlashImageTool)
                    {
                        FPTHeader fptHeader = Helper.DeserializeHeader<FPTHeader>(bHeaderData);
                        strVersion = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                    }
                    else if (versiontype == ImeVersionType.ManagementEngine)
                    {
                        MN2Manifest mn2Header = Helper.DeserializeHeader<MN2Manifest>(bHeaderData);
                        strVersion = $"{mn2Header.EngineMajor}.{mn2Header.EngineMinor}.{mn2Header.EngineHotfix}.{mn2Header.EngineBuild}";
                    }
                }
            }

            if (string.IsNullOrEmpty(strVersion) || strVersion == _default)
            {
                return null;
            }

            return strVersion;
        }
    }
}