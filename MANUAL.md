## Application Manual

1. [Useful Notes](#useful-notes)
2. [Startup Window](#startup-window)
    - [Keyboard Shortcuts](#keyboard-shortcuts)
    - [Main Menu](#main-menu)
    - [Options Menu](#options-menu)
3. [EFIROM Window](#efirom-window)
    - [Keyboard Shortcuts](#keyboard-shortcuts-1)
    - [Main Menu](#main-menu-1)
    - [Export Menu](#export-menu)
    - [Patch Menu](#patch-menu)
    - [Tools Menu](#tools-menu)
    - [Status Bar](#status-bar)
4. [SOCROM Window](#socrom-window)
    - [Keyboard Shortcuts](#keyboard-shortcuts-2)
    - [Main Menu](#main-menu-2)
    - [Export Menu](#export-menu-1)
    - [Patch Menu](#patch-menu-1)
    - [Tools Menu](#tools-menu-1)
    - [Status Bar](#status-bar-1)

## Useful Notes

- Mac EFI Toolkit creates its own directories within the working directory to extract and store files. The application is designed to be self-contained, ensuring that all necessary files and data are managed within the application's working environment.
- The Startup, EFIROM, and SOCROM windows all support drag-and-drop functionality. However, when running the application as an administrator, this feature will be disabled due to Windows security mechanisms and the way it handles file access. There is generally no need to run the application as an administrator.
- The EFIROM and SOCROM windows display application memory usage in the title bar, and this data will refresh every four seconds.
- In the event of an unhandled exception, the application will automatically capture the error and generate a log file in the working directory. This log can be uploaded to GitHub issues if needed for troubleshooting.
- In the EFIROM window, the '@' icon in the status bar becomes clickable when an email address is detected within the firmware. Clicking the icon will display the detected email address.

## Startup Window

This section explains the Startup Window and its functionality.

<kbd>
  <img src="stream/images/application/startup.png">
</kbd>

### Keyboard Shortcuts
- **Browse for a Firmware**: `CTRL + O`
- **Open Folders Menu**: `CTRL + L`
- **Open Tools Menu**: `CTRL + T`
- **Open Help Menu**: `CTRL + H`
- **New EFIROM Session**: `F2`
- **New SOCROM Session**: `F3`
- **Open Settings Window**: `F4`
- **Open Manual**: `F1`
- **View Application Log**: `F12`

### Main Menu
| Button     | Description                                                                                           |
|------------|-------------------------------------------------------------------------------------------------------|
| **Folders**| Opens the folders menu for quick access to essential directories.                                     |
| **Options**  | Opens the options menu.                                                          |
| **Help**   | Opens the help menu.                                                                                 |
| **Browse** | Opens a file dialog to load a compatible firmware into the application. |

### Options Menu
- **New EFIROM Session**: Launches a new EFIROM session window.
- **New SOCROM Session**: Launches a new SOCROM session window.
- **Restart Application**: Restarts the application, closing the current session and starting fresh.

## EFIROM Window

This section explains the EFIROM Window and its functionality.

<kbd>
  <img src="stream/images/application/efi.png">
</kbd>

### Keyboard Shortcuts
- **Browse for a Firmware**: `CTRL+ O`
- **Open Folders Menu**: `CTRL + L`
- **Open Copy Menu**: `CTRL + C`
- **Open Export Menu**: `CTRL + E`
- **Open Patch Menu**: `CTRL + P`
- **Open Tools Menu**: `CTRL + T`
- **Open Help Menu**: `CTRL + H`
- **View ROM Information**: `CTRL + I`
- **Reset Window**: `CTRL + R`
- **Reload File from Disk**: `F5`
- **Open Manual**: `F1`
- **View Application Log**: `F12`
- **Open Settings Window**: `F4`
- **Open Loaded File Location**: `CTRL + SHIFT + L`
- **Toggle Serial Number View**: `CTRL + SHIFT + N`
- **Close Window**: `ESC`

### Main Menu
| Button     | Description                                                                                           |
|------------|-------------------------------------------------------------------------------------------------------|
| **Open**   | Opens a file dialog to load a compatible EFI file into the application.                               |
| **Folders**| Opens the folders menu for quick access to essential directories.                                     |
| **Copy**   | Opens the copy menu, allowing you to copy key data to the clipboard.                                   |
| **Export** | Opens the export menu with options to save specific firmware data.                                     |
| **Patch**  | Opens the patching menu, offering options to modify firmware data.                                    |
| **Tools**  | Opens a menu with additional firmware tools.                                                          |
| **Help**   | Opens the help menu.                                                                                 |

### Export Menu
- **Export Fsys Store**: Exports the Fsys Store located within NVRAM.
- **Export Intel ME Region**: Exports the Intel Management Engine region.
- **Export NVRAM VSS Stores**: Exports the VSS (Variable Storage Subsystem) stores within NVRAM.
- **Export NVRAM SVS Stores**: Exports the SVS (Secure Variable Store) within NVRAM.
- **Export LZMA DXE Archive**: Allows exporting of the decompressed LZMA DXE archive, which can be opened with 7-zip.
- **Backup Firmware (ZIP)**: Compresses and saves the loaded firmware as a ZIP archive.
- **Export Firmware Information (Text)**: Saves firmware information to a text file.
- **Export Find My Mac Email (Text)**: Saves the email found in the NVRAM `FindMyMac` token to a text file, if available.

### Patch Menu
> Access to the patching menu requires accepting the editing terms.
- **Change Serial Number**: Opens a window to enter a new System Serial Number.
- **Erase NVRAM**: Opens a window to select and erase the VSS and/or SVS NVRAM stores.
- **Replace Fsys Store**: Allows selection and replacement of the Fsys store within NVRAM.
- **Fix Fsys Checksum (CRC32)**: Automatically corrects an invalid checksum in the Fsys store.
- **Invalidate EFI Lock**: Invalidates the Message Authentication Code in the SVS NVRAM, safely disabling the EFI password.

### Tools Menu
- **Generate Filename**: Generates a structured filename for the firmware and copies it to the clipboard.
- **Lookup Serial Number**: Opens EveryMac in a browser and auto-inserts the System Serial Number for quick lookup (internet connection required).
- **View ROM Information**: Displays details from the firmware’s AppleRomInformation section.
- **Reset Window**: Unloads the firmware data, and resets the window to default.
- **Reload File from Disk**: Reloads the firmware file to reflect any changes made on disk.

### Status Bar
- **Firmware Parse Time**: The leftmost label displays the time taken by the application to process the firmware.
- **File Glyph**: Indicates whether an LZMA DXE archive was found within the firmware.
- **Email Glyph**: Indicates whether a Find My Mac email was detected in the NVRAM.
- **Tooltips**: The status bar shows important messages and keyboard shortcuts.

## SOCROM Window

This section explains the SOCROM Window and its functionality.

<kbd>
  <img src="stream/images/application/socrom.png">
</kbd>

### Keyboard Shortcuts
- **Browse for a Firmware**: `CTRL+ O`
- **Open Folders Menu**: `CTRL + L`
- **Open Copy Menu**: `CTRL + C`
- **Open Export Menu**: `CTRL + E`
- **Open Patch Menu**: `CTRL + P`
- **Open Tools Menu**: `CTRL + T`
- **Open Help Menu**: `CTRL + H`
- **Reset Window**: `CTRL + R`
- **Reload File from Disk**: `F5`
- **Open Manual**: `F1`
- **View Application Log**: `F12`
- **Open Settings Window**: `F4`
- **Open Loaded File Location**: `CTRL + SHIFT + L`
- **Toggle Serial Number View**: `CTRL + SHIFT + N`
- **Close Window**: `ESC`

### Main Menu
| Button     | Description                                                                                           |
|------------|-------------------------------------------------------------------------------------------------------|
| **Open**   | Opens a file dialog to load a compatible T2 SOCROM file into the application.                               |
| **Folders**| Opens the folders menu for quick access to essential directories.                                     |
| **Copy**   | Opens the copy menu, allowing you to copy key data to the clipboard.                                   |
| **Export** | Opens the export menu with options to save specific firmware data.                                     |
| **Patch**  | Opens the patching menu, offering options to modify firmware data.                                    |
| **Tools**  | Opens a menu with additional firmware tools.                                                          |
| **Help**   | Opens the help menu.                                                                                 |

### Export Menu
- **Export Scfg Store**: Exports the Scfg store located in the firmware.
- **Backup Firmware (ZIP)**: Compresses and saves the loaded firmware as a ZIP archive.
- **Export Firmware Information (Text)**: Saves firmware information to a text file.

### Patch Menu
> Access to the patching menu requires accepting the editing terms.
- **Change Serial Number**: Opens a window to enter a new System Serial Number.
- **Write New Scfg Store**: Allows selection and replacement of the Scfg store within firmware.

### Tools Menu
- **Lookup Serial Number**: Opens EveryMac in a browser and auto-inserts the System Serial Number for quick lookup (internet connection required).
- **Reset Window**: Unloads the firmware data, and resets the window to default.
- **Reload File from Disk**: Reloads the firmware file to reflect any changes made on disk.

### Status Bar
- **Firmware Parse Time**: The leftmost label displays the time taken by the application to process the firmware.
- **Tooltips**: The status bar shows important messages and keyboard shortcuts.