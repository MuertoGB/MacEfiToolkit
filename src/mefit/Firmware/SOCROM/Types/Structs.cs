// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Structs.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal struct ScfgStore
    {
        internal int StoreBase { get; set; }
        internal int StoreSize { get; set; }
        internal byte[] ScfgBytes { get; set; }
        internal string ScfgCrc {  get; set; }
        internal string SerialText { get; set; }
        internal string HWC { get; set; }
        internal string SonText { get; set; }
        internal string MdlC { get; set; } // What is this? Model codename?
        internal string RegNumText { get; set; }
    }
}