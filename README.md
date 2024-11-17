<h1 align="center">
<img width="160" src="stream/images/application/icon256.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit (V2.0.1)
</h1>

## Table of Contents
1. [Intoduction](#introduction)
2. [System Requirements](#system-requirements)
3. [Getting Started](#getting-started)
4. [Wine Instructions](#wine-instructions)
5. [Support](#support)
6. [Changelog](#changelog)
7. [Features](#features)
8. [Acknowledgements](#acknowledgements)
9. [Donate](#donate)

## Introduction

**Mac EFI Toolkit** (also known as **mefit**) is designed to aid technicians in repair and analysis of Mac EFI and Intel based Mac SOCROM firmwares. Designed to be compact, this application provides information gathering capabilities and limited patching functionality.

## System Requirements

- **Operating System:**
  - Windows 11 (64-bit)
  - Windows 10 (32/64-bit)
  - **mefit** is compatible with [Wine](https://www.winehq.org/)

- **Internet Connectivity** (optional, only required for specific features):
  - Receiving notifications about new versions (can be disabled in settings).
  - Fetching device configuration data from Apple’s server if not available in the internal database.
  - Checking serial numbers on EveryMac.

- **Build Requirements:**
  - [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), targeting .NET Framework 4.8.

## Getting Started

1. Ensure your system has [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) installed.
2. Download the [latest version](https://github.com/MuertoGB/MacEfiToolkit/releases/latest) of **mefit**.
3. If needed, create a dump of your Mac firmware using an SPIROM programmer.
4. Launch the software (**no installation required**) and open your firmware.

## Wine Instructions

To run **Mac EFI Toolkit** on Linux or macOS using Wine, follow these steps:

1. **Install [Wine](https://gitlab.winehq.org/wine/wine/-/wikis/home)** to your Operating System.
2. Open the terminal and run the command `winecfg`. This will open the Wine configuration window. Then, navigate to the **'Graphics'** tab and change the **'Screen resolution'** to **120 dpi**.
3. Download all four required fonts from [here](stream/fonts). After downloading, navigate to `Home\.wine\drive_c\windows\Fonts` and copy the downloaded fonts into this folder.

Once these steps are completed, you should be able to run **Mac EFI Toolkit** under Wine.

## Support

If you encounter any issues or need assistance, here are a few ways you can get help:

#### 1. **GitHub Issues**
If you're experiencing a bug or issue, please check the [open issues](https://github.com/MuertoGB/MacEfiToolkit/issues) on GitHub. If your problem has not been reported, feel free to create a new issue. Be sure to include as much detail as possible, including:
 - Application build (Can be found in the about window).
 - A clear description of the problem.
 - Steps to reproduce the issue.
 - Screenshots or logs (if applicable).
 - Firmware files (if applicable).

#### 2. **Email Me**
For more direct support, you can contact me via [email](mailto:muertogb@proton.me).


## Changelog

> 📋 View the full changelog [here](CHANGELOG.md).

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
  - Detect and export decompressed LZMA DXE archives
  - Detect and export the Find My Mac email address

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

## Acknowledgements

This software uses the following third-party libraries and resources:

- LZMA [v24.08 SDK](https://www.7-zip.org/sdk.html), by Igor Pavlov.
- [Knuth-Morris-Pratt algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm), by Donald Knuth, James H. Morris, and Vaughan Pratt.
- [MacModelShelf](https://github.com/MagerValp/MacModelShelf) database by MagerValp.
- Application icon by [ADI_ICONS](https://www.flaticon.com/authors/adi-icons) on [FlatIcon](https://www.flaticon.com/free-icon/wrench_17505678?related_id=17505678).

## Donate

All donations go back into improving my software and workspace:

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>