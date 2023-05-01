<h1 align="center">
Mac EFI Toolkit
</h1>

## About

<img width="600" src="files/images/met.png" alt="MET">

Currently under development, Mac EFI Toolkit is a firmware repair tool designed to aid technicians in repair of a Mac EFIROM (BIOS). Built to be minimal, this software should achieve the following (list not final):-

```
Features:
- Original binaries left untouched, new image built from memory
- Knuth–Morris–Pratt algorithm for searching binary offsets
- Get information such as the PDR board-id when available
- Replace serial with automatic HWC and CRC32 calculation
- Ability to detect and decompress LZMA DXE volumes
- Clear NVRAM and EFI lock with header preservation
- Detect email address in the NVRAM (maybe)
- Detect and fix invalid Fsys checksums
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

```
Requirements:
- Windows 7, 8, 8.1, 10. 32, or 64-bit
- Internet connectivity for version checking (Can be disabled)
```

Incomplete source code will become available over time, then a test build should follow. This way anyone can get involved and ask questions about the work done so far.

> Currently working on: About Window, Refactoring.

## Acknowledgements

This software uses the LZMA v22.01 SDK made by [Igor Pavlov](https://www.7-zip.org/sdk.html)\
This software uses the [Knuth-Morris-Pratt algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
).
