# Mac EFI Toolkit Manual

## Table of Contents
1. [Intoduction](#introduction)
2. [System Requirements](#system-requirements)
3. [Getting Started](#getting-started)
4. [EFIROM Window](#efirom-window)
5. [SOCROM Window](#socrom-window)

## Introduction

Welcome to the **Mac EFI Toolkit** (also known as **mefit**). This application is designed to assist technicians in retrieving information from Mac firmware files and provides limited patching capabilities.

## System Requirements

- **Operating System**: 
  - Windows 11 (32/64-bit)
  - Windows 10 (32/64-bit)
  - Windows 8/8.1 (32/64-bit)
  - Windows 7 (32/64-bit)
  - **mefit** is compatible with Wine

- **Internet Connectivity** (required for specific features):
  - Receiving notifications about new versions (can be disabled in settings).
  - Fetching device configuration data from Apple’s server if not available in the internal database.
  - Checking serial numbers on EveryMac.

## Getting Started

1. Ensure your system has [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) installed.
2. Download the [latest version](https://github.com/MuertoGB/MacEfiToolkit/releases/latest) of **mefit**.
3. If needed, create a dump of your Mac firmware using an SPIROM programmer.

## EFIROM Window

This section explains the EFIROM Window and its functionality.

<kbd>
  <img src="stream/images/application/efi.png">
</kbd>

### Main Menu

| Button     | Description                                                                                           |
|------------|-------------------------------------------------------------------------------------------------------|
| **Open**   | Opens a file dialog to load a compatible EFI file into the application.                               |
| **Reset**  | Clears all firmware data and resets the window to its default view.                                   |
| **Copy**   | Opens the copy menu, allowing you to copy key data to the clipboard.                                  |
| **Folders**| Opens the folders menu for quick access to essential directories.                                     |
| **Export** | Opens the export menu with options to save firmware data in different formats.                        |
| **Patch**  | Opens the patching menu, offering tools to modify and customize firmware data.                        |
| **Options**| Opens a menu with additional firmware tools, like serial number lookup.   |

- **Export Menu:**
  - **Export Fsys Store**: Exports the Fsys Store located within NVRAM.
  - **Export Intel ME Region**: Exports the Intel Management Engine region.
  - **Export NVRAM VSS Stores**: Exports the VSS (Variable Storage Subsystem) stores within NVRAM.
  - **Export NVRAM SVS Stores**: Exports the SVS (Secure Variable Store) within NVRAM.
  - **Backup Firmware (ZIP)**: Compresses and saves the loaded firmware as a ZIP archive.
  - **Export Firmware Information (Text)**: Saves firmware information to a text file.

- **Patch Menu:**
  - **Change Serial Number**: Edits the System Serial Number (SSN) within the Fsys Store.
  - **Erase NVRAM**: Opens a window to select and erase the VSS and/or SVS NVRAM stores.
  - **Replace Fsys Store**: Allows selection and replacement of the Fsys store within NVRAM.
  - **Fix Fsys Checksum (CRC32)**: Automatically corrects an invalid checksum in the Fsys store.
  - **Invalidate EFI Lock**: Invalidates the Message Authentication Code in the SVS NVRAM, safely disabling the EFI password.

- **Options Menu:**
  - **Automatic Filename Generation**: Generates a structured filename for the firmware and copies it to the clipboard.
  - **Reload File from Disk**: Reloads the firmware file to reflect any changes made on disk.
  - **View Application Log**: Opens the application log file.
  - **View ROM Information**: Displays details from the firmware’s AppleRomInformation section `{B535ABF6-967D-43F2-B494-A1EB8E21A28E}`.
  - **Lookup Serial Number**: Opens EveryMac in a browser and auto-inserts the System Serial Number for quick lookup.

## SOCROM Window

This section explains the SOCROM Window and its functionality.

<kbd>
  <img src="stream/images/application/socrom.png">
</kbd>

### Main Menu

| Button     | Description                                                                                           |
|------------|-------------------------------------------------------------------------------------------------------|
| **Open**   | Opens a file dialog to load a compatible Intel T2 SOCROM firmware into the application.                               |
| **Reset**  | Clears all firmware data and resets the window to its default view.                                   |
| **Copy**   | Opens the copy menu, allowing you to copy key data to the clipboard.                                  |
| **Folders**| Opens the folders menu for quick access to essential directories.                                     |
| **Export** | Opens the export menu with options to save firmware data in different formats.                        |
| **Patch**  | Opens the patching menu, offering tools to modify and customize firmware data.                        |
| **Options**| Opens a menu with additional firmware tools, like serial number lookup.   |