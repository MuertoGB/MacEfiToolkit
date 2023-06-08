<h4 align="center">Version History</h4>
<p align="center">
  <a href="#version-060">V0.6.0</a> •
  <a href="#version-052">V0.5.2</a> •
  <a href="#version-051">V0.5.1</a> •
  <a href="#version-050">V0.5.0</a> •
  <a href="#version-046">V0.4.6</a> •
  <a href="#version-045">V0.4.5</a> •
  <a href="#version-044">V0.4.4</a> •
  <a href="#version-034">V0.3.4</a>
</p>

## Version 0.6.0

#### New:
- Added firmware-editor window, which includes the following features:-
> - Ability to replace the entire Fsys block with a donor dump.
> - Ability to replace the serial number with automatic HWC and CRC32 masking.
> - Ability to clear the NVRAM (SVS, VSS, NSS) sections while preserving section headers.
- Added a status bar to bottom of the main window:-
> - Displays pertinent model identifier for determining the firmware's counterpart device.
> - Displays the amount of private memory used.
> - Moved pup-up tips to the status bar.
- Added editor terms window.
- New models added to the internal database.
- Added button to reload the currently open file, in case external changes are made.
- Added button to navigate to the currently open file in explorer.
- Added setting to disable dark messagebox sounds.
- Added setting to disable tips.

#### Enhancements:
- UI improvements.
- Enhanced parsing of SON data from the Fsys region.
- Implemented model-identifier fallback if the HWC is not present.
- Switched drag and drop support to accept all file types (.) instead of specific file formats.
- Changed the default initial directory to the application directory.
- Application will now calculate and display any file size discrepancy bytes in the main window.

#### Bugs:
- Fixed an issue with the form minimize state in the About window.
- Fixed the font resolver failing to load embedded resources on some systems.
- Fixed stability issues that occurred when the Fsys region was not found and the 'Disable valid Fsys enforcement' option was enabled.
> - Please note that you cannot use the firmware editor when a valid Fsys region is not found.
- Fixed the initial directory not being set when a file is dragged onto the main window or the application executable file.
- Fixed broken shortcut keys (CTRL+A, CTRL+S).
- Fixed an error condition related to opening files larger than 2.00GB.

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
