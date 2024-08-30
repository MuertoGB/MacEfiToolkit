namespace Mac_EFI_Toolkit.T2.Structs
{
    internal struct SCfgData
    {
        internal int StoreBase { get; set; }
        internal int StoreSize { get; set; }
        internal byte[] StoreBytes { get; set; }
        internal string SerialText { get; set; }
        internal string SonText { get; set; }
        internal string RegNumText { get; set; }
    }
}