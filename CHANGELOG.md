<h4 align="center">Version History</h4>
<p align="center">
  <a href="#version-061">V0.6.1</a> •
  <a href="#version-060">V0.6.0</a> •
  <a href="#version-052">V0.5.2</a> •
  <a href="#version-051">V0.5.1</a> •
  <a href="#version-050">V0.5.0</a> •
  <a href="#version-046">V0.4.6</a> •
  <a href="#version-045">V0.4.5</a> •
  <a href="#version-044">V0.4.4</a> •
  <a href="#version-034">V0.3.4</a>
</p>

## Version 0.6.1

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

#### Bugs:
- Fixed an issue where the colour of the version label in the main window was not being set correctly when the form was activated and an update was available.
- Fixed an issue when a file is dragged onto the executable and restarting does not clear the argument path.
- Resolved a scenario where the application could fail to accurately determine the length of a serial number if the serial number had been previously edited and contained invalid characters outside the range of A-Z and 0-9.
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
