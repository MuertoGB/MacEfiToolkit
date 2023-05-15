<h4 align="center">Version History</h4>
<p align="center">
  <a href="#version-051">V0.5.1</a> •
  <a href="#version-050">V0.5.0</a> •
  <a href="#version-046">V0.4.6</a> •
  <a href="#version-045">V0.4.5</a> •
  <a href="#version-044">V0.4.4</a> •
  <a href="#version-034">V0.3.4</a>
</p>

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
