<h4 align="center">Mac EFI Toolkit Manual</h4>
<p align="center">
  <a href="#main-window">Main Window</a> •
  <a href="#firmware-patcher">Firmware Patcher</a>
</p>

## Main Window

This section explains the main window and its functionality.

<kbd>
  <img src="files/images/met.png">
</kbd>

The executable and main window of the application support drag and drop functionality for files, however, it's important to note that this feature does not work if the application is run as an administrator, this limitation is due to the way Windows processes drag and drop operations in elevated privileges.

Most labels in the main window can be clicked to copy their respective data to the clipboard.

---

#### Main Buttons:

<kbd>
  <img src="files/manual/mainbuttons.png">
</kbd>

**'Open':**\
Prompts and open file dialog where you can choose and load a UEFI/BIOS file into the application.

**'Reset':**\
Unloads the currently loaded file and clears any buffers and data associated with it.

**'Copy':**\
Opens the copy menu, which enables quick copying of firmware data to the clipboard.

**'Patcher':**\
Opens the firmware patcher window. Alternatively, it can open the terms window, which must be accepted before access to the firmware patcher is granted.

**'Settings':**\
Opens the settings window where you can modify various application settings.

**'About':**\
Opens the about window, providing information about the application and its version.

**'Three dots (More)':**\
Opens the overflow menu with various extra options:

#### Overflow menu:

<kbd>
  <img src="files/manual/overflowmenu.png">
</kbd>

**'Backups Folder':**\
Navigates to the Backups directory. This is the default location where zipped file backups are exported.

**'Builds Folder':**\
Navigates to the Builds directory within the working directory, this is where edited binaries are automatically saved.

**'Fsys Store Folder':**\
Navigates to the Fsys Store directory within the working directory. This is the default location where Fsys Stores are exported.

**'ME Region Folder':**\
Navigates to the ME Region directory within the working directory. This is the default path where ME regions are exported.

**'Working Directory':**\
Opens the current working directory where the executable is located.

**'Changelog':**\
Opens a browser window directly to the application's changelog.

**'Homepage':**\
Opens a browser window to the application landing page.

**'Usage Manual':**\
Opens a browser window here, to the application manual.

**'Create a Debug Log':**\
Generates a debug text log (debug.log) in the working directory, which contains information useful for troubleshooting purposes.

**'View Application Log':**\
Opens the application log, if available, which contains details of any handled errors or relevant issues encountered during runtime.

**'Restart Application':**\
Closes the current instance of the application and launches a new one.

---

#### File:

<kbd>
  <img src="files/manual/file.png">
</kbd>

This section displays the name of the currently loaded file and includes three buttons.

Clicking the 'Explorer' button will open Windows Explorer at the location of the loaded file, with the file being highlighted. The 'Reload' button provides an option to reload the loaded file from disk in case any external changes have been made. Finally, the 'Backup' button triggers a "Save As" dialog, allowing you to create a backup of the loaded firmware as a zip archive.

---

#### Size:

<kbd>
  <img src="files/manual/filesize.png">
</kbd>
<kbd>
  <img src="files/manual/filesizeinvalid.png">
</kbd>

The loaded file's size is displayed in bytes, followed by the hexadecimal representation. If the file size is invalid, the data will be shown in red, and any byte discrepancies will be calculated and appended.

> 🛈 8,388,615 bytes (800007h) (>7) would indicate the given firmware is 7 bytes too large.

---

#### CRC32:

<kbd>
  <img src="files/manual/filecrc.png">
</kbd>

The CRC32 value calculated for the loaded file.

---

#### Created:

<kbd>
  <img src="files/manual/filecreateddate.png">
</kbd>

The creation date of the loaded file.

---

#### Modified:

<kbd>
  <img src="files/manual/filemodifieddate.png">
</kbd>

The last write time of the loaded file.

---

#### Model:

<kbd>
  <img src="files/manual/model.png">
</kbd>

Displays the device model number. The application retrieves the model identifier (e.g., IM161) from the UEFI/BIOS and then converts it into a readable format (e.g., iMac16,1)

---

#### Config Code:

<kbd>
  <img src="files/manual/configcode.png">
</kbd>

Displays the device configuration code if the Hardware Configuration Code (HWC) is available within the firmware.

---

#### Fsys Store:

<kbd>
  <img src="files/manual/fsys.png">
</kbd>
<kbd>
  <img src="files/manual/fsys_invalid.png">
</kbd>
<kbd>
  <img src="files/manual/fsys_forced.png">
</kbd>

This section includes the checksum of the Fsys store and two buttons. If the CRC32 of the Fsys store is valid, the label will appear green and display the valid checksum. If the CRC32 is invalid, the label will appear red and display the invalid checksum. The presence of `[F]` appended to the checksum indicates the Fsys Store was force found by the application, and the firmware may be corrupt.

Clicking the "Wrench" button, which is enabled when the Fsys store checksum is invalid, will prompt a "Save As" dialog to export the binary file with a repaired Fsys CRC32 checksum. The "Save" button allows exporting of the Fsys store.

---

#### Serial:

<kbd>
  <img src="files/manual/serial.png">
</kbd>

This section consists of the System Serial Number (SSN) located in the Fsys store, and one button. Clicking the 'Globe' button will open a browser window to EveryMac and automatically load in the serial number. A valid serial number will consist of either 11 or 12 characters, and will be appended to the end of the serial data.

---

#### HWC:

<kbd>
  <img src="files/manual/hwc.png">
</kbd>

The Hardware Configuration Code (HWC) is located in the Fsys store and is derived from the System Serial Number (SSN). If the Serial Number is 11 characters long, the HWC will be 3 characters. If the Serial Number is 12 characters long, the HWC will be 4 characters.

---

#### Order No:

<kbd>
  <img src="files/manual/son.png">
</kbd>

The System Order Number (SON) is displayed in this section, retrieved from the Fsys store. The order number can be a standard order number such as `MNE92LL/A` or a custom Built to Order (BTO) / Configure to Order (CTO) number.

---

#### EFI Version:

<kbd>
  <img src="files/manual/efiversion.png">
</kbd>

<kbd>
  <img src="files/manual/efiversionalt.png">
</kbd>

This section provides information about the firmware version, and includes one button. Clicking the 'Arrow' button will open the ROM Information window, which displays ROM information retrieved from the `AppleRomInformationSection` GUID found in Apple UEFI only, it was not available in Apple BIOS without a flash descriptor.

---

#### NVRAM:

<kbd>
  <img src="files/manual/nvram.png">
</kbd>
<kbd>
  <img src="files/manual/nvramalt.png">
</kbd>

This section is divided into three items, representing different NVRAM store types, indicating their status. Each store type will appear green when empty, white when data is present, and grey when the store is not found.

---

#### EFI Lock:

<kbd>
  <img src="files/manual/efilockunlocked.png">
</kbd>
<kbd>
  <img src="files/manual/efilocklocked.png">
</kbd>

This section provides information about whether the loaded firmware is password locked with a Message Authentication Code (MAC), commonly known as "EFI Lock", and includes one button. If no 'MAC' is found the text "UNLOCKED" will be shown. If a 'MAC' is found the text "LOCKED" will show in red.

Clicking the "Unlock" button, which is enabled when the firmware is locked  with a password, will prompt a "Save As" dialog to export the binary file with an invalidated Message Authentication Code, thus safely removing the EFI password and retaining the SVS store data.

---

#### Mac Board ID:

<kbd>
  <img src="files/manual/boardid.png">
</kbd>

This section displays the 8-byte hexadecimal board-id obtained from the UEFI Platform Data Region. The Mac board-id is valuable for matching an SMC firmware or identifying a platform's logic board.

---

#### APFS Capable:

<kbd>
  <img src="files/manual/apfsdxe.png">
</kbd>
<kbd>
  <img src="files/manual/apfslzma.png">
</kbd>
<kbd>
  <img src="files/manual/apfsno.png">
</kbd>

The application provides information regarding the presence of the UEFI APFS DXE driver and the firmware's capability to support APFS boot. If the driver is detected, it will display `YES (DXE)` to indicate that an uncompressed driver was found. If the driver is found within an LZMA compressed volume, it will display `YES (LZMA DXE)` to indicate that the driver was located in an LZMA compressed volume.

---

#### Intel ME:

<kbd>
  <img src="files/manual/intelme.png">
</kbd>

This section provides information about the Intel Management Engine (ME). It displays the ME version obtained from the MN2 manifest and indicates the base position of the ME in the UEFI. Additionally, it includes one button. Clicking the 'Save' button allows exporting the entire Management Engine firmware by extracting the portion between the 'MEBase' and 'MELimit' values defined in the Intel Flash Descriptor.

---

#### Status Bar:

<kbd>
  <img src="files/manual/statusbar.png">
</kbd>

Located at the bottom of the main window, the status bar serves multiple purposes. It displays helpful tips when hovering over specific items (this feature can be disabled in the settings). It also shows a loading animation to indicate ongoing processes or operations. Additionally, the status bar provides information about the private memory usage for the application.

---

## Firmware Patcher

This section explains the firmware patcher window and its functionality.

<kbd>
  <img src="files/images/firmware_patcher.png">
</kbd>

---

#### Fsys Store:

<kbd>
  <img src="files/manual/patcher_fsys.png">
</kbd>

This section comprises of two main functions.

When the "Replace Fsys Store" switch is activated, an open file dialog will be prompted, enabling the selection and opening of the new Fsys Store. If you want to choose a different file, simply click the '...' button to reopen the file dialog.

The application will verify the new Fsys Store, if CRC masking is require this will be done automatically at build time.

> 🛈 Only one option is available at a time. If you choose one, the other is disabled.

When the "Replace Serial Number" switch is activated, it will enable the 'SSN' textbox, allowing input of a new serial number. Once a valid serial number is entered, the Hardware Configuration code (HWC) will be automatically determined based on the provided serial number. It is important to note that you cannot change the HWC separately from the serial number. The HWC must match the serial number and the application does not allow independent modification.

The application will automatically enforce the required length of the serial number, allowing for either 11 or 12 characters. It will also provide validation to ensure that only valid characters are entered. This helps to ensure that the serial number input meets the necessary criteria and maintains the expected format.

The patcher will automatically verify and mask the Fsys Store CRC32 after the serial number patching is complete.

---

#### NVRAM:

<kbd>
  <img src="files/manual/patcher_nvram.png">
</kbd>

In this section, you have the option to clear specific NVRAM stores. By selecting 'Clear VSS Store', a general PRAM reset will be performed, similar to using CMD + SHIFT + P + R on the Mac keyboard. This action helps in resetting parameters stored in the VSS Store.

Alternatively, selecting 'Clear SVS Store' will remove the EFI lock in the event that a customer has forgotten their EFI password. This action effectively clears the SVS Store, which contains the Message Authentication Code (MAC) responsible for storing the EFI password.

The NSS store's specific purpose is currently unknown to me. It is included as an option for users who are knowledgeable about its functionality and potential use cases.

---

#### Intel ME:

<kbd>
  <img src="files/manual/patcher_intelme.png">
</kbd>

When the switch is activated, an open file dialog will be prompted, allowing selection of a donor or clean Management Engine (ME) firmware. This feature proves useful for scenarios such as migrating a ME Region from a faulty UEFI to a donor UEFI. Additionally, it can be utilized to write a configured ME Region from a matching clean Apple firmware.

A repository of clean Apple firmware can be found here on [Github](https://github.com/gdbinit/firmware_vault). This repository provides a collection of clean Apple firmware files containing clean and configured ME regions.

It is important for the user to ensure the accurate replacement of the ME Region when utilizing the application. The application allows for the transfer of a dumped or configured region but does not provide a guarantee of accuracy.

For users who require a higher level of certainty and guidance in replacing the ME region, I recommend referring to resources such as the guide available on [Win-Raid](https://winraid.level1techs.com/t/guide-clean-dumped-intel-engine-cs-me-cs-txe-regions-with-data-initialization/31277) written by platomav, or the post on [Logi.wiki](https://www.logi.wiki/index.php/Clean_EFI_ME_Region). These resources provide comprehensive instructions and information on performing a clean replacement of the ME Region while ensuring data integrity and accuracy.

---

#### Output:

<kbd>
  <img src="files/manual/patcher_output.png">
</kbd>

This section includes a single button and the output log. By clicking the 'Save Log' button, a save file dialog will be prompted, allowing you to export the log text to a file of your choice.

The output log serves as a valuable source of information during the validation and build process. It provides necessary details and updates to keep the user informed about the progress and status of these processes.

---

#### Patcher Buttons:

<kbd>
  <img src="files/manual/patcher_buttons.png">
</kbd>

**Reset:**\
When you click the 'Reset' button, it initiates a process that resets the patcher and unloads any loaded files, such as the Fsys store and ME region.

**Builds Folder:**\
Navigates to the Builds directory within the working directory, this is where edited binaries are automatically saved when the 'Build' button is used.

**Show Last Build:**\
Navigates to the latest build in the file explorer and highlights the file.

**Load Last Build:**\
Clicking this button will close the firmware patcher window and load in the last successfully built binary into the main window.

**Build:**\
The 'Build' button generates a new binary file based on the user specified preferences.

---