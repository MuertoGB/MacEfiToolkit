### Version History

| Major 1.x     | Major 2.x     |
|---------------|---------------|
| [V1.0.0](#version-100) | [V2.0.0](#version-200) |
| [V1.0.1](#version-101) | [V2.0.1](#version-201) |
| [V1.0.2](#version-102) | [V2.0.2](#version-202) |
| [V1.0.3](#version-103) | [V2.0.3](#version-203) |
| [V1.1.0](#version-110) | [V2.0.4](#version-204) |
| [V1.1.1](#version-111) | [V2.1.0](#version-210) |
| [V1.1.2](#version-112) | [V2.1.1](#version-211) |
| [V1.1.3](#version-113) | [V2.1.2](#version-212) |
| [V1.1.4](#version-114) |               |
| [V1.1.5](#version-115) |               |


## Version 2.1.2

### Enhancements
- User interface improvements.
- Minor string adjustments.
- Updated CREATED and MODIFIED timestamps to use a consistent, simplified format for improved readability.
- Updated the layout of the output text file when exporting SOCROM firmware information, specifically for cases where the SCfg store is not present.
- Included SHA-256 checksum in firmware information export data.
- Updated the internal database.
- Added fallback for missing HWC during Fsys parsing: now derived from the last 3–4 characters of the serial when unavailable in firmware. Helps address instances of missing config data.


### Bugs
- **Reworked firmware parser architecture:** Replaced the hotfix from version 2.1.1 with a permanent solution. Firmware parsing logic is now fully decoupled from form UI logic. Each window now operates on its own parser instance, preventing shared state issues when multiple windows are opened or closed. Support for using multiple firmware windows simultaneously has been restored.
- Fixed an issue in the Settings window where an empty path could be displayed if the folder selection dialog was cancelled. The UI now only updates when a valid path is selected.

## Version 2.1.1

### Hotfix
- Temporarily disabled opening multiple firmware windows to prevent shared state conflicts present since version 2.0.0. **Users still on older versions should avoid opening more than one EFIROM or SOCROM window at a time**, as doing so may result in incorrect values being written to firmware files. A permanent fix is in progress.

## Version 2.1.0

### New
- Introduced an updater to automatically download new application versions.

### Enhancements
- Improved formatting of the Order No. string in the SOCROM window.
- Updated the internal database.
- Added SoC controller type to the SOCROM window export information.

### Bugs
- Fixed memory usage displaying as 0 bytes on Windows by addressing memory mapping issues in PROCESS_MEMORY_COUNTERS.
- Fixed a bug where the SOCROM parser assumed all SCfg stores had a length of B8h, causing failed store writes when the data length differed.

## Version 2.0.4

### Enhancements
- Enabled support for opening Apple Silicon SOCROM firmware.
- Added SoC type to the SOCROM window iBoot version label.

### Bugs
- Older 2MB EFI files now open correctly instead of being incorrectly flagged as invalid.
- EFIROM window model text now correctly displays a comma when the string contains only two numeric digits at the end.
- Fixed an issue where the SOCROM iBoot version label displayed invalid data when the length byte was incorrect or corrupt.

### Misc
- Updated Segoe MDL2 font resource to version 1.86 for improved compatibility and appearance.

## Version 2.0.3

### Bugs
- Resolved an issue where pressing `Alt + F4` would incorrectly open the settings window before closing the application or active window as expected.
- Resolved an issue where certain APFS capable firmware incorrectly reported the driver as not found. This was caused by an oversight in LZMA header verification logic (thanks reformatt @ badcaps).

## Version 2.0.2

### Enhancements
- User interface improvements.
- Updated the internal database with more models.
- Improved reliability when detecting LZMA DXE archives.

### Bugs
- Fixed a bug where the SOCROM window failed to fetch config codes from the server. This issue occurred as incorrect parameter value was being passed to the GetConfigCodeAsync() function.

## Version 2.0.1

### Enhancements
- User interface improvements.
- Reintroduced memory usage monitoring in the application.
- Reintroduced the manual file (see [MANUAL.md](MANUAL.md#application-manual)).
- Reorganized menu items across the application.
  - 'Folders' menu buttons will no longer be disabled when no firmware is loaded.
- Updated shortcut keys throughout the application.
  - Menus now display available shortcuts where applicable.
  - Available window shortcuts can be viewed in the manual.
- Improved consistency of file names when exporting data.

### Misc
- Added missing menu item **'Open LZMA DXE Folder'** to the Startup and EFIROM windows.

## Version 2.0.0

#### New
- User interface redesigned for improved usability, with a new application icon.
- Added capability to open multiple firmwares simultaneously.
- The application now supports T2 SOCROM firmware.
- Startup Window: Introduced a new startup window where users can drag and drop or browse for a compatible EFIROM or T2 SOCROM. The main window is now dedicated to EFIROM, with some functions moved to the startup window.
- EFI Window Updates:
  - Patcher Relocation: Removed the firmware patcher window; all patching features are now consolidated in the EFI window.
  - Structured File Naming: Added an option to automatically generate a structured file name for the loaded firmware and copy it to the clipboard.
  - Firmware Export Options: Users can now export firmware information to a text file, as well as export NVRAM stores.
  - Address Copying: Added options to copy the Fsys store base address and NVRAM VSS and SVS base addresses.
  - NVRAM Data: The window now displays base addresses of primary stores and whether they are empty, or active.
  - Fsys Store: The window now displays the store's base address and indicates whether the store checksum is valid or invalid.
  - Intel Flash Descriptor: The windows now indicates if the firmware includes an Intel Flash descriptor.
  - Added an icon to the status bar which will indicate if a compressed LZMA DXE archive was found within the firmware.
  - Added an icon to the status bar which indicates whether an email was found in the 'fmm-mobileme-token-FMM' NVRAM variable.
  - Added an option to the export menu to export decompressed LZMA DXE archives, which can be extracted using 7-Zip.
  - Added an option to the export menu to save an email address if present in the 'fmm-mobileme-token-FMM' NVRAM variable.
- Added new settings:
  - "Use Windows Accent Colour for Borders": Allows form borders to match the system's accent color for a more integrated appearance.
  - "Disable Serial Number Validation": Disables the validation process when entering a new serial number for the firmware.
- Added firmware parse time to status bars.
- Serial numbers are now censored by default. They can be uncensored by toggling the switch next to the serial number data.
- Serial numbers will no longer be displayed in the "Copied to Clipboard" dialogs. Instead, a default message "Serial Number copied to clipboard" will be shown.
- Updated LZMA SDK to version 24.08.
- Unhandled exception reports now use regular expressions (regex) to sanitize usernames from exception messages and file paths, where possible. However, there may still be some cases where this data could appear. Please review the reports carefully before uploading them to GitHub issues.
- The EFIROM NVRAM parser was rewritten, enhancing functionality and performance.

#### Enhancements
- Restricted non-Apple EFI files from being opened.
- Enhanced NVRAM reset functionality to simulate an uninitialized factory firmware state.
- Improved validation process for serial numbers.
- Updated the internal database with more models.
- Modified default file name for exporting information in the ROM Information window.
- Enabled "Make New Folder" in directory selection dialogs.
- Removed unnecessary confirmation dialogs in various windows.
- Modified shortcut keys in the EFI window for improved accessibility.
- When 'Disable Confirmation Dialogs' is enabled, the EFI window will no longer display a "copied to clipboard" message.
- Redesigned the logging system to consolidate all entries into a single log file, streamlining log management and improving readability.
- Changed the application log filename from 'mefit.log' to 'application.log'.
- If a firmware is loaded (EFIROM, SOCROM) and an incompatible file is opened, the window will no longer reset unnecessarily.

#### Bugs
- Added missing icon in the ROM Information window.
- Fixed broken Flash Image Tool version strings.
- Fixed a logic error causing the internal database to be skipped when the Fsys Store was force-found, which led to misleading "not present" messages in the database log.
- Fixed an issue where the application could not open the log file when running under Wine.
- Fixed an issue with NVRAM limit calculation.
- When an NVRAM store base address is found but the size is invalid (0xFFFF), the parser will now treat the store as empty, rather than incorrectly indicating that the store is missing.

#### Miscellaneous
- Some settings have been restructured; users will need to reselect the 'EFI Window Default Directory' in settings.
- Discontinued support for Windows 8.1 and earlier operating systems. The application will no longer launch on unsupported operating systems.
- EFI Window Adjustments:
  - Removed single-click copy functionality for labels and reset their cursors to default to better align with UI design best practices.
  - Removed display of private memory usage to improve compatibility with Wine.
  - Removed NSS store details and NVRAM store tips.
- Settings Adjustments:
  - Removed option to disable LZMA decompression, as it is required for APFS compatibility detection.

## Version 1.1.5

#### Bugs:
- Fixed a bug introduced in the previous version where the NVRAM store type was not set when parsing store data, this could lead to a 'no post' scenario.
- Mitigated rare occurrences of malformed Intel ME version numbers.
- Fixed a UI bug related to the METLabel, where the ForeColor property could be overridden even when the control was disabled.

## Version 1.1.4

#### Enhancements:
- Implemented single-click functionality for most main window labels, enabling users to instantly copy text to the clipboard.
- Updated the main window copy menu to include all respective descriptor region offsets when copying PDR, ME, and BIOS region data stored in the flash descriptor.
- Introduced an export button in the ROM Information window, enabling users to export the AppleRomSectionInformation data displayed in the window.
- Added '0x' prefix to the beginning of region base data to better represent it as an address.
- Improvements to the AppleEFI firmware parser.
- Added NVRAM base address and size to the debug log.
- User Interface layout changes.

#### Bugs:
- Resolved an issue where the ampersand '&' symbol was not correctly displayed in specific UI elements. This issue was caused by the 'Use Mnemonic' property being set to true.

## Version 1.1.3

#### Enhancements:
- Added hexadecimal format to the main window file size data.
- Enabled the 'All Files' option, and modified the default filename when exporting Fsys Store or ME Region binary data in the main window.
- The patcher window now triggers a 'Save As' dialog upon clicking the 'Build' button, allowing users to choose the desired save location and filename.
- Introduced button 'Show Last Build' in the patcher window that opens file explorer and highlights the last build when clicked.
- User Interface layout changes.
- Added LZMA SDK version to the debug log, and about window.

#### Bugs:
- Fixed a malformed string in the debug log navigation prompt.
- Fixed inaccurate main window tooltip stating both designated NVRAM stores were 'empty' when only the backup store contained data.

## Version 1.1.2

#### Enhancements:
- User Interface improvements.
- Altered the functionality of export dialogues. Rather than displaying the export path, users will now be prompted to decide whether they want to navigate to the file directly in an explorer window.

#### Bugs:
- Fixed image and text display issues when the Operating System UI scaling is set to 100% size.
- Fixed the custom initial directory setting not being reflected immediately when a firmware is not loaded, and a user changes the path.

## Version 1.1.1

#### New:
- Added a new feature to the main window, allowing users to automatically create a backup of the loaded firmware as a zip archive (ALT + B). This feature offers users a convenient way to compress their firmware files for long term storage.

#### Enhancements:
- The settings window will now display the initial folder path.
- Added application icon to tool windows. These icons can be double-clicked to reset the position of the window, centring it to the main window.
- User Interface improvements.

#### Bugs:
- Fixed an issue where part of the main window's title area was unresponsive when attempting to drag the window.

## Version 1.1.0

#### New:
- Introduced a new option in the main window that allows users to remove EFI Lock without clearing the SVS NVRAM store (ALT + L). This method offers a safer approach as it retains the SVS NVRAM data whilst only invalidating the Message Authentication Code (Use of this feature will require acceptance of the editing terms).
- Added dialog when text is copied via the main window copy menu.

#### Enhancements:
- Improved the Fsys parser by implementing dynamic reading of the Fsys store size. This improvement replaces the previous static approach of reading a hardcoded size of 0x800h (2048 bytes).
- Expanded functionality of the main window copy menu by introducing new options to copy the following data: File Size (Hex), Config Code, PDR base, ME base, and BIOS base.
- Reorganized some data in the main window user interface by relocating EFI Lock information to its own dedicated section.
- The main window will now display the length of a system serial number.
- Improved user interaction by enabling access to the main window application menu through a right-click action on the title area.
- Debug logs will now show the detected Fsys store size if a firmware is loaded and the Fsys store is present.
- Minor UI improvements.

#### Misc:
- Omitted display of the Intel Flash Image Tool version from the main window, while retaining its presence within the clipboard copy menu.
- Removed setting "Enable valid flash descriptor enforcement" from the application, as it is no longer required or relevant.

## Version 1.0.3

#### New:
- Updated the firmware parser with a new feature that attempts to force find the Fsys Store if it was not initially located within the NVRAM on the first pass. This change makes the application more reliable at extracting Fsys data from corrupt firmware.

#### Enhancements:
- Implemented a visual colour change in the presentation of NVRAM store labels in the main window. The manual has been updated to reflect this change.
- Improved the image validation logic.
- User interface improvements.

#### Bugs:
- Fixed a scenario that caused a crash when dragging and dropping a file onto the application executable and subsequently clicking "Create a Debug Log." This issue was caused by a malformed file path in specific scenarios, and was resolved by dynamically constructing the executable file path when necessary.

## Version 1.0.2

#### Enhancements:
- Reverted the main buttons back to text-based buttons, restoring their original form without the use of icons.
- Other User Interface improvements.

#### Bugs:
- Resolved an issue that caused the application to become unresponsive when attempting to open large files.
- Resolved an issue that allowed copying the EFI version when the string value was null.

## Version 1.0.1

#### New:
- Implemented a new functionality where the application verifies if a valid firmware image is being loaded. If the loaded file is not recognized as a valid firmware image, the application will reject the file. 
- Implemented the addition of links to the Github changelog, homepage, and manual within the main menu of the application's main window.

#### Enhancements:
- Revised the method for determining the 'EFI Version' data in the main window. If the `AppleRomInformationSection` does not provide an EFI Version, the application will now generate a version number that closely resembles the one displayed in the MacOS 'Hardware Overview' System Firmware Version.
- User Interface and text improvements. Some elements in the main window have been reorganized.
- Improved Xserve support.

#### Bugs:
- Resolved an oversight where the application attempted to read the flash descriptor even when no descriptor signature was found. This issue led to specific files triggering an unhandled exception.
- Addressed an extremely rare issue where the EfiBiosId was not being read correctly.

## Version 1.0.0

#### New:
- Added option in the main window to export the Intel ME Region (ALT + M).
- Added option in the editor window to replace the ME Region.
- Added menu in the main window which enables quick copying of text fields (CTRL + C).
- Unhandled exceptions will now output a debug log to './unhandled.log'.
- Added option to create a debug log 'Main Window > Menu > Create a Debug Log'.
- The application will now parse the flash descriptor (where available) for base and limit offsets of UEFI regions.
- Updated LZMA SDK to version 23.01.

#### Enhancements:
- UI improvements.
- The EFI model code is now automatically converted and displayed as a model identifier in the main window and rom information window.
- The main window APFS capability status will now display DXE type.
- Added more files types when opening a firmware image (*.fd, *.bio).
- The Fsys parser will now dynamically read variable size.
- Modified context menu shortcut keys.
- Adjusted tab index ordering.

#### Bugs:
- Fixed an issue where the main window private memory usage label would stop updating if the user closes the window with ALT + F4 then cancels the action.
- Fixed an issue that caused a handled exception to appear when a thread attempted to refresh a control before its handles were fully initialized.
- Fixed the editor window 'Open Builds Directory' button opening the wrong path.
- Fixed invalidated (0x83) serial numbers being read.
- Fixed ROM information not being found if the GUID exists, but the section is empty.
- Fixed application restart option being unreliable on Windows 7.

## Version 0.7.0

#### New:
- Added new features to the editor window:
> - Implemented the option to clear firmware NVRAM stores.
> - Implemented the option to replace the firmware serial number.
> - Included a button to load the last successful build.
> - Included a button to reset the window and all data.
- Included an option in the main window menu to navigate to the builds directory.
- Included an option in the main window menu to navigate to the Fsys stores directory.

#### Enhancements:
- UI improvements.
- Improved EFI lock status
- Improved integrity checks when saving and editing binary files.
- Modified default file naming for editor output files.
- Added confirmation dialog when reverting to default settings in the settings window.
- Enabled escape key to close message dialogs.
- Enabled escape key to close the editor window.
- Added confirmation dialog when closing the editor window.
- Added a new serial number signature.

#### Bugs:
- Fixed an issue where the colour of the version label in the main window was not being set correctly when the form was activated and an update was available.
- Fixed an issue when a file is dragged onto the executable and restarting does not clear the argument path.
- Fixed an issue when the main window reset button is clicked but the UI will not reset properly if setting 'Disable Confirmation Dialogs' is enabled.
- Fixed an issue where a handled exception could cause the main window to become stuck at half opacity if the user chooses not to force quit.
- Resolved a scenario where the application could fail to accurately determine the length of a serial number if the serial number had been previously edited and contained invalid characters outside the range of A-Z and 0-9.
- Resolved a scenario where the NVRAM store parser would incorrectly determine section size when the header size data is blank (0xFFFF).
- Resolved a scenario where the application could return an inaccurate serial string.
- Resolved an oversight in the editor window Fsys validation causing the wrong Fsys store to be validated.
- Added missing keyboard shortcut to open the rom information window (ALT + I)

## Version 0.6.0

#### New:
- Added firmware-editor window, which includes the following features:-
> - Ability to replace the Fsys store with a donor.
- Added a status bar to bottom of the main window:-
> - Displays the amount of private memory used.
> - Displays loading animation.
> - Moved pop-up tips to the status bar.
- Added editor terms window.
- Added rom information window.
- New models added to the internal database.
- Added button to reload the currently open file, in case external changes are made.
- Added button to navigate to the currently open file in explorer.
- Added setting to disable dark messagebox sounds.
- Added setting to disable tips.
- Added detected NVRAM stores to the main window.
- Application can now detect EFI lock.

#### Enhancements:
- UI improvements.
- Enhanced parsing of SON data from the Fsys region.
- Changed how model data is displayed in the main window.
- Switched drag and drop support to accept all file types (.) instead of specific file formats.
- Changed the default initial directory to the application directory.
- Application will now calculate and display any file size discrepancy bytes in the main window.
- Addressed redundancy for the underlying settings system.
- Changed default initial directory for Fsys binary files.
- Replaced the close button in the settings window with an OK button for saving and closing.

#### Bugs:
- Fixed an issue with the form minimize state in the about window.
- Fixed the font resolver failing to load embedded resources on some systems.
- Fixed stability issues that occur when the Fsys region is not found.
- Fixed the initial directory not being set when a file is dragged onto the main window or the application executable file.
- Fixed broken shortcut keys (CTRL+A, CTRL+S).

#### Misc:
- Removed strong name verification due to wine compatibility. Will revisit in the future.
- Removed valid Fsys enforcement, and counterpart setting.

## Version 0.5.2

#### New:
- Config data is now loaded from a local database, defaults to the server if not found.
> Missing database entries are written to ./dbreport.log and can be emailed to me.

#### Enhancements:
- UI improvements.

## Version 0.5.1

#### New:
- Added drag and drop support for EFIROM (*.bin) files.

#### Enhancements:
- Toned down window flashing.
- Main window 'Open' button no longer unnecessarily flashes.
- About window now follows the application theme.
- Dark messagebox can now be moved.

#### Bugs:
- Settings window tab order fixed.
- Custom checkbox control now has visual feedback when tabbed.

## Version 0.5.0

#### New:
- User interface revamped.
- Added option to repair an invalid Fsys CRC32 checksum.
- Added file creation time, modified time, and HWC data to main window.

#### Enhancements:
- Config details are now generated from HWC, instead of the serial number.
- Delayed main window control enable until data has finished loading.
- Unhandled exceptions are now written to a log file.
- Modified default file name when exporting the Fsys region.

#### Bugs:
- Prevented crash caused by disposed object being passed to unmanaged code.
- Fixed Board-ID false detections.
- Fixed CRC32 format specifier.

## Version 0.4.6

#### Bugs:
- Fixed integrity check fault relating to wrong api import.

## Version 0.4.5

#### New:
- Main window version text now clickable when an update is available.
- Settings window 'reset' option now available.

#### Enhancements:
- Disabled unnecessary WinKey+Up shortcut with low level hook.
- Changed build text format to version-date-type.
- Removed build text from main window title.
- Signed the assembly, and added verification.

#### Bugs:
- Fixed broken initial directory path.

## Version 0.4.4

#### New:
- Added descriptor signature check when loading a binary.
- Added Fsys signature check when loading a binary.
- Added dark style messagebox to match the application theme.
- Added context menu on main form title bar icon click.
- Added settings system, and settings UI.
- Added confirmation dialog when closing the application.
- Added options to restart the application.
- Added main window shortcuts.

#### Enhancements:
- UI improvements.
- Enabled 'All Files' option when opening a binary.
- About section links are now enabled.
- About section keydown enabled, form can be closed with 'Esc'.
- Modified load order when parsing data.
- Other small unnotable changes.

#### Bugs:
- Fixed cases of malformed serial numbers.
- Fixed control tab indexing.

### Version 0.3.4

- Initial private version handed out to keen individuals.