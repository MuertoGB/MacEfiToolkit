<h4 align="center">Version History</h4>
<p align="center">
  <a href="#version-100">V1.0.0</a> •
  <a href="#version-101">V1.0.1</a> •
  <a href="#version-102">V1.0.2</a> •
  <a href="#version-103">V1.0.3</a> •
  <a href="#version-110">V1.1.0</a> •
  <a href="#version-111">V1.1.1</a> •
  <a href="#version-112">V1.1.2</a> •
  <a href="#version-113">V1.1.3</a> •
  <a href="#version-114">V1.1.4</a>
</p>

## Version 1.1.4

#### Enhancements:
- Implemented single-click functionality for most main window labels, enabling users to instantly copy text to the clipboard.
- Updated the main window copy menu to include all respective descriptor region offsets, expanding the copying functionality to better cover PDR, ME, and BIOS region data stored in the flash descriptor.
- Introduced an export button in the ROM Information window, enabling users to export the AppleRomSectionInformation data displayed in the window.
- Added '0x' prefix to the beginning of region base data to better represent it as an address.
- Improvements to the AppleEFI firmware parser.
- Added NVRAM base address and size to the debug log.

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