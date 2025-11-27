<h1 align="center">
<img width="160" src="stream/images/application/icon256.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit
This project is now end of life, and shall receive no more updates by the developer. Issues will no longer be responded to.
</h1>

<p align="center" width="100%">
    <img width="75%" src="stream/images/application/efi.png">
</p>

## Table of Contents
1. [Intoduction](#introduction)
2. [System Requirements](#system-requirements)
3. [Getting Started](#getting-started)
4. [Application Manual](#application-manual)
5. [Wine Instructions](#wine-instructions)
6. [Support](#support)
7. [Changelog](#changelog)
8. [Features](#features)
9. [Donate](#donate)

## Introduction

**Mac EFI Toolkit** (also known as **mefit**) is designed to aid technicians in repair and analysis of Mac EFI and SOCROM firmwares. Designed to be compact, this application provides information gathering capabilities and limited patching functionality.

## System Requirements

- **Operating System:**
  - Windows 11 (64-bit)
  - Windows 10 (32/64-bit)
  - **mefit** is compatible with [Wine](https://www.winehq.org/)

- **Internet Connectivity** (optional, only required for specific features):
  - Receiving notifications about new versions (can be disabled in settings).
  - Downloading automatic updates.
  - Fetching device configuration data from Apple’s server if not available in the internal database.
  - Checking serial numbers on EveryMac.

- **Build Requirements:**
  - [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), targeting .NET Framework 4.8.

## Getting Started

1. Ensure your system has [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) installed.
2. Download the [latest version](https://github.com/MuertoGB/MacEfiToolkit/releases/latest) of **mefit**.
3. If needed, create a dump of your Mac firmware using an SPIROM programmer.
4. Launch the software (**no installation required**) and open your firmware.

## Application Manual

> 📋 View the application manual [here](MANUAL.md#application-manual).

## Wine Instructions

To run **Mac EFI Toolkit** on Linux or macOS using Wine, follow these steps:

1. **Install [Wine](https://gitlab.winehq.org/wine/wine/-/wikis/home)** to your Operating System.
2. Open the terminal and run the command `winecfg`. This will open the Wine configuration window. Then, navigate to the **'Graphics'** tab and change the **'Screen resolution'** to **120 dpi**.
3. Download the font pack archive from [here](stream/fonts). After downloading, navigate to `Home\.wine\drive_c\windows\Fonts`. Extract the downloaded font pack archive and copy the fonts into this folder.

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
    - Open multiple firmwares simultaneously
  - **Error Handling and Logging**
    - Automatic handling of uncaught exceptions
    - Automatic background logging for errors and key actions
  - **User Interface**
    - Automatic DPI scaling
    - New version notifications with automatic updates
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

- **Firmware (SOCROM)**
  - **View firmware details**
    - Binary size (bytes, hex)
    - Checksum
    - Created and modified date
    - iBoot version
    - View SoC type
    - **Model Information**
      - SCfg store details
      - System serial number
      - System config code
      - System order number
  - Edit the serial number
  - Export and replace the SCfg store
  - Export firmware information to a text file

## Donate

All donations go back into improving my software and workspace:

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>
