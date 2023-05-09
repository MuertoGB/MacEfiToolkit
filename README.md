<h1 align="center">
<img width="200" src="files/images/img128px.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit
</h1>

<h4 align="center">A tool for repairing and modifying data in Mac EFI binaries. </h4>

<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#download">Download</a> •
  <a href="#requirements">Requirements</a> •
  <a href="#acknowledgements">Acknowledgements</a> •
  <a href="#donate">Donate</a>
</p>

## About

>🛠 Current Status: Listening to feedback, fixing issues.

Mac EFI Toolkit is a firmware repair tool designed to aid technicians in repair of a Mac EFIROM (BIOS).

This application is currently under development, it is by no means complete, fully functional, or final. There is much more to complete. However basic functionality such as viewing EFIROM info, and dumping the Fsys block is working. It has been uploaded per request, now anyone interested can get involved and ask questions.

<img width="600" src="files/images/met.png" alt="MET">

## Features


| Suggested feature                                          | Status        |
|------------------------------------------------------------|---------------|
| New binary built from memory                               |✅ Completed   |
| Knuth–Morris–Pratt algorithm for searching binary offsets  |✅ Completed   |
| Replace serial with automatic HWC and CRC32 calculation    |❌ In progress |
| Clear NVRAM and EFI lock with header preservation          |❌ In progress |
| Ability to detect and decompress LZMA DXE volumes          |✅ Completed   |
| Detect email address in the NVRAM (maybe)                  |❌ In progress|
| Detect and fix invalid Fsys checksums                      |⚠ Partially complete|
| Check serial number with EveryMac							 |✅ Completed   |
| Dump and replace Fsys block                                |⚠ Partially complete|

Implemented application features:
```
- Automatic handling of uncaught errors
- No installation necessary
- DPI scaling support
- Integrity checking
- Memory Management
- Version checking
```

Plus more, only time will tell.

## Download

| Version| Release Date| Latest | Channel |
|--------|-------------|--------|---------|
| [0.4.5](https://github.com/MuertoGB/MacEfiToolkit/releases/tag/045)  | 9th May 2023 | Yes | BETA |
| [0.4.4](https://github.com/MuertoGB/MacEfiToolkit/releases/tag/044)  | 8th May 2023 | No | BETA |

## Requirements

**Application:**
- MS [.NET Framework 4.5](https://www.microsoft.com/en-GB/download/details.aspx?id=30653)
- Windows 7, 8, 8.1, 10. 32, or 64-bit
- Internet connectivity for version checking (Can be disabled)

**Build requirements:**
- Visual Studio 2019 or higher

## Acknowledgements

This software uses the LZMA v22.01 SDK made by [Igor Pavlov](https://www.7-zip.org/sdk.html)\
This software uses the [Knuth-Morris-Pratt algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
).\
Application icon by [Creatype](https://www.flaticon.com/free-icon/toolkit_6457096?term=toolkit&page=1&position=38&origin=search&related_id=6457096) on [Flaticon](https://www.flaticon.com).

## Donate

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>
