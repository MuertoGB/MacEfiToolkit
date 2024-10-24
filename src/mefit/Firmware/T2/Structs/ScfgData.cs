// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// ScfgData.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Firmware.T2
{
    internal struct SCfgData
    {
        internal int StoreBase { get; set; }
        internal int StoreSize { get; set; }
        internal byte[] ScfgBytes { get; set; }
        internal string ScfgCrc {  get; set; }
        internal string SerialText { get; set; }
        internal string HWC { get; set; }
        internal string SonText { get; set; }
        internal string MdlC { get; set; } // unused as of yet, not sure what it is, modelcodename?
        internal string RegNumText { get; set; }
    }
}