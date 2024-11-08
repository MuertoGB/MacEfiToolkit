<h1 align="center">
<img width="160" src="stream/images/application/icon256.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit V2.0.0
</h1>

<h4 align="center">A tool for analysis of Mac BIOS/UEFI and Intel T2 SOCROM, with limited editing capabilities.</h4>
<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#download">Download</a> •
  <a href="#requirements">Requirements</a> •
  <a href="#acknowledgements">Acknowledgements</a> •
  <a href="#donate">Donate</a>
</p>

## About

Mac EFI Toolkit, or 'mefit', is a valuable tool built to aid technicians in analysing and repairing Mac EFI and Intel based Mac SOCROM firmwares. Designed to be compact, this application provides information gathering capabilities and limited editing functionality.

>🛈 **Access to some features requires accepting the editing terms.**

| EFIROM Window                                    | SOCROM Window |
| ------------------------------------------------ |-----------------------
| ![window](stream/images/application/efi.png)     | ![window](stream/images/application/socrom.png) |

## Features

- **Application**
  - **File Handling**
    - All files are edited in memory preserving the original
    - Backup firmwares to a .zip archive for long-term storage
    - Drag and drop support
  - **Error Handling and Logging**
    - Automatic handling of uncaught exceptions
    - Automatic background logging for errors and key actions
  - **User Interface**
    - Automatic DPI scaling
    - New version notifications
    - Serial numbers are censored by default
  - **Search and Verification**
    - Knuth–Morris–Pratt algorithm for binary data searching
    - Serial number validation rules
    - Check serial numbers on EveryMac
    - View firmware parse time
  - **Misc**
    - No installation required
    - Works with Wine

- **Firmware (EFIROM)**
  - **View firmware details**
    - Binary size (bytes, hex)
    - Checksum
    - Created and modified date
    - EFI version
    - EFI lock status
    - Platform Data Region Board-ID
    - APFS driver status
    - Intel ME version
    - **Model information**
      - System model
      - System config code
      - System serial number
      - Hardware config code
      - System order number
  - Automatic Fsys checksum masking
  - Edit the system serial number
  - Export and replace the Fsys region
  - Export and replace the Intel Management Engine region
  - Export firmware information to a text file
  - Detect invalid binary size
  - Detect and repair invalid Fsys checksums
  - View Apple ROM section information
  - Reset NVRAM stores with proper header configuration
  - Detect and remove EFI passwords (EFI lock)

- **Firmware (T2 SOCROM)**
  - **View firmware details**
    - Binary size (bytes, hex)
    - Checksum
    - Created and modified date
    - iBoot version
    - **Model Information**
      - Scfg store details
      - System serial number
      - System config code
      - System order number
  - Edit the serial number
  - Export and replace the Scfg store
  - Export firmware information to a text file

## Download

| Version| Build | Release Date| Latest | Channel |
|--------|-------|-------------|--------|---------|
|[2.0.0](https://github.com/MuertoGB/MacEfiToolkit/releases/latest)| Not Set | Not Set | Yes | Stable |
|[1.1.5](https://github.com/MuertoGB/MacEfiToolkit/releases/tag/115)| 241018.1450 | 10th October, 2024 | No | Stable |

> 📋 View the full changelog [here](CHANGELOG.md)

## Manual

TODO - The original manual is outdated, and being rewritten.

## Requirements

**Application:**
- Microsoft [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- Windows 7, 8, 8.1, 10 and 11. 32, or 64-bit
- Internet connectivity required for:-
  - Version checking, which can be disabled in the settings.
  - Retrieving configuration codes from the server they're not present in the database.

**Build requirements:**
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), targeting .NET Framework 4.8.

## Acknowledgements

**This software uses the following third party libraries, or resources:-**

LZMA [v24.08 SDK](https://www.7-zip.org/sdk.html), by Igor Pavlov.\
The [Knuth-Morris-Pratt algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm), by Donald Knuth, James H. Morris, and  Vaughan Pratt.\
[MacModelShelf](https://github.com/MagerValp/MacModelShelf) database by MagerValp.\
Application icon by [ADI_ICONS](https://www.flaticon.com/authors/adi-icons) on [FlatIcon](https://www.flaticon.com/free-icon/wrench_17505678?related_id=17505678).

## Donate

All donations go back into improving my software and workspace:

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>