// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Sections.cs - Handles parsing of firmware data
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.EFI.Structs
{
    internal struct PdrSection
    {
        internal string BoardId { get; set; }
    }

    internal struct AppleRomInformationSection
    {
        internal bool SectionExists { get; set; }
        internal byte[] SectionBytes { get; set; }
        internal int SectionBase { get; set; }
        internal string BiosId { get; set; }
        internal string Model { get; set; }
        internal string EfiVersion { get; set; }
        internal string BuiltBy { get; set; }
        internal string DateStamp { get; set; }
        internal string Revision { get; set; }
        internal string RomVersion { get; set; }
        internal string BuildcaveId { get; set; }
        internal string BuildType { get; set; }
        internal string Compiler { get; set; }
    }

    internal struct EfiBiosIdSection
    {
        internal string ModelPart { get; set; }
        internal string zzPart { get; set; }
        internal string MajorPart { get; set; }
        internal string MinorPart { get; set; }
        internal string DatePart { get; set; }
    }
}