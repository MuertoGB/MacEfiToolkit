// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FirmwareVars.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware
{
    internal class FirmwareVars
    {
        internal const int MIN_IMAGE_SIZE = 2097152;  // 200000h (2 MB image)
        internal const int MAX_IMAGE_SIZE = 33554432; // 2000000h (32 MB image)
    }
}