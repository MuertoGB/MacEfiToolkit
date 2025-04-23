// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Structs.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    public struct SCfgStore
    {
        internal int StoreBase { get; set; }
        internal int StoreLength { get; set; }
        internal byte[] StoreBuffer { get; set; }
        internal string StoreCRC {  get; set; }
        internal string Serial { get; set; }
        internal int SerialBase { get; set; }
        internal string HWC { get; set; }
        internal string SON { get; set; }
        internal string MdlC { get; set; } // What is this? Model codename?
        internal string RegNum { get; set; }
    }
}