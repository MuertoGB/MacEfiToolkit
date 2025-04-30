// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// IntelME.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Interop;
using Mac_EFI_Toolkit.Utilities;

namespace Mac_EFI_Toolkit.Firmware.EFIROM
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

        internal static string GetVersionData(byte[] sourcebytes, ImeVersionType versiontype, FlashDescriptor flashDescriptor)
        {
            int headerBase = -1;
            int length = 0;
            string version = null;

            switch (versiontype)
            {
                case ImeVersionType.FIT:
                    headerBase = BinaryUtils.GetBaseAddress(sourcebytes, FPTMarker, (int)flashDescriptor.MeBase, (int)flashDescriptor.MeSize);
                    length = 0x20;
                    break;

                case ImeVersionType.ME:
                    headerBase = BinaryUtils.GetBaseAddress(sourcebytes, MN2Marker, (int)flashDescriptor.MeBase, (int)flashDescriptor.MeSize);
                    length = 0x10;
                    break;
            }

            if (headerBase != -1)
            {
                if (versiontype == ImeVersionType.ME)
                {
                    headerBase += 2;
                }

                byte[] headerBuffer = BinaryUtils.GetBytesBaseLength(sourcebytes, headerBase, length);

                if (headerBuffer != null)
                {
                    if (versiontype == ImeVersionType.FIT)
                    {
                        FPTHeader fptHeader = MarshalHelper.ReadStruct<FPTHeader>(headerBuffer);
                        version = $"{fptHeader.FitMajor}.{fptHeader.FitMinor}.{fptHeader.FitHotfix}.{fptHeader.FitBuild}";
                    }
                    else if (versiontype == ImeVersionType.ME)
                    {
                        MN2Header mn2Header = MarshalHelper.ReadStruct<MN2Header>(headerBuffer);
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