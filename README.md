<h1 align="center">
Mac EFI Toolkit
</h1>

## About

Currently under development, Mac EFI Toolkit is a firmware repair tool designed to aid technicians in repair of a Mac EFIROM (BIOS). Designed to be minimal, this software currently achieves the following:-

```
Features:
- Original binaries left untouched, new image built from memory
- Get information such as the PDR board-id when available
- Replace serial with automatic HWC and CRC32 calculation
- Ability to detect and decompress lzma DXE volumes
- Clear NVRAM and EFI lock with header preservation
- Detects and fixes invalid Fsys checksums
- Check serial number with EveryMac
- Dump and replace Fsys block
- Mac EFI signature detection
```

```
Application:
- Automatic handling of uncaught errors
- No installation necessary
- DPI scaling support
- Memory Management
- Version checking
```

Some features have been purposely left out as I'm not ready to talk about them yet, or they're just not stable. This software's source code will be released under the GLP 3.0. Application written in C# .NET4.5.

Updates will be added as I progress further, beta source code will be available when I feel it's ready to view. Currently I'm working on acquiring various LMZA compressed DXE volume GUIDs so they can be extracted into memory, and checked for others necessary markers.

<img width="600" src="files/images/met.png" alt="MET">

## Acknowledgements

MacEfiTool utilises the 7z LZMA v22.01 SDK:\
https://www.7-zip.org/sdk.html

