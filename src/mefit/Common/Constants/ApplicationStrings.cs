// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// ApplicationStrings.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit.Common.Constants
{
    internal class APPSTRINGS
    {
        #region Strings
        internal const string APPNAME =
            "Mac EFI Toolkit";

        internal const string VERSION =
            "Version";

        internal const string LZMA_SDK =
            "LZMA SDK";

        internal const string BACKUP =
            "BACKUP";

        internal const string EFIROM =
            "EFIROM";

        internal const string SOCROM =
            "SOCROM";

        internal const string FILE =
            "FILE";

        internal const string UNKNOWN =
            "Unknown";

        internal const string NA =
            "N/A";

        internal const string BYTES =
            "bytes";

        internal const string SERIAL_NUMBER =
            "Serial Number";

        internal const string FW_PARSE_TIME =
            "Firmware Parse Time";

        internal const string HIDE =
            "Hide";

        internal const string SHOW =
            "Show";

        internal const string INVALID =
            "Invalid";

        internal const string CONTACT_SERVER =
            "Contacting Server...";

        internal const string NOT_FOUND =
            "Not Found";

        internal const string FIRMWARE_INFO =
            "FirmwareInfo";

        internal const string ROM_SECTION_INFO =
            "AppleRomInformation";

        internal const string BASE =
            "Base:";

        internal const string LIMIT =
            "Limit:";

        internal const string SIZE =
            "Size:";

        internal const string FILTER_STARTUP_WINDOW =
            "Firmware Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*";

        internal const string FILTER_EFI_SUPPORTED_FIRMWARE =
            "Apple EFI/BIOS (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*";

        internal const string FILTER_SOCROM_SUPPORTED_FIRMWARE =
            "Apple SOCROM (*.bin, *.rom)|*.bin;*.rom|All Files (*.*)|*.*";

        internal const string FILTER_BIN =
            "Binary Files (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|All Files (*.*)|*.*";

        internal const string FILTER_ZIP =
            "Zip files (*.zip)|*.zip";

        internal const string FILTER_LZMA =
            "LZMA Files (*.lzma)|*.lzma|All Files (*.*)|*.*";

        internal const string FILTER_TEXT =
            "Text Files (*.txt)|*.txt";

        internal const string FIRMWARE_WINDOWS_OPEN =
            "There are firmware windows open.";

        internal const string QUESTION_RESTART =
            "Are you sure you want to restart the application?";

        internal const string QUESTION_EXIT =
            "Are you sure you want to exit the application?";

        internal const string SELECT_FOLDER =
            "Select a folder";

        internal const string RESET_SETTINGS_DEFAULT =
            "This will reset all settings to default. Are you sure you want to set default settings?";

        internal const string FILES_SAVE_SUCCESS_NAV =
            "Files saved successfully. Would you like to open the folder?";

        internal const string FILE_SAVE_SUCCESS_NAV =
            "File saved successfully. Would you like to open the file location?";
        #endregion
    }

    internal class LOGSTRINGS
    {
        #region Strings
        internal const string PATCH_START =
            "Patch started";

        internal const string PATCH_FAIL =
            "Patch failed -";

        internal const string PATCH_SUCCESS =
            "Patch successful";

        internal const string CREATING_BUFFERS =
            "Creating buffers";

        internal const string FILE_EXPORT_CANCELLED =
            "The file export was cancelled";

        internal const string VALIDATION_PASS =
            "Validation passed";

        internal const string EXPECTED_STORE_SIZE_NOT =
            "Expected store size is not";

        internal const string STORE_SIG_MISALIGNED =
            "Store signature misaligned or not found";

        internal const string FSYS_IMPORT_CANCELLED =
            "An Fsys store was not provided";

        internal const string FSYS_SUM_MASK_SUCCESS =
            "Fsys checksum masking successful.";

        internal const string FSYS_SUM_INVALID =
            "Fsys checksum is invalid";

        internal const string FSYS_SUM_MASK_FAIL =
            "Fsys CRC32 checksum masking failed";

        internal const string FOUND =
            "Found:";

        internal const string CALCULATED =
            "Calculated:";

        internal const string MASKING_SUM =
            "Masking checksum";

        internal const string SUM_MASKING_FAIL =
            "Checksum masking failed";

        internal const string STORE_COMP_FAILED =
            "Store comparison check failed";

        internal const string SSN_BASE_NOT_FOUND =
            "Serial number base address was not found";

        internal const string SSN_WTB =
            "Write new SSN to firmware buffer";

        internal const string HWC_WTB =
            "Write new HWC to firmware buffer";

        internal const string FSYS_LFB =
            "Loading Fsys store from firmware buffer";

        internal const string SSN_WRITE_SUCCESS =
            "SSN written successfully";

        internal const string HWC_WRITE_SUCCESS =
            "HWC written successfully";

        internal const string SSN_NOT_WRITTEN =
            "New SSN could not be written";

        internal const string HWC_NOT_WRITTEN =
            "New HWC could not be written";

        internal const string IME_IMPORT_CANCELLED =
            "An Intel ME region was not provided";

        internal const string IME_FPT_NOT_FOUND =
            "FPT signature not found";

        internal const string IME_TOO_LARGE =
            "New IME is too large:";

        internal const string IME_TOO_SMALL =
            "New IME is smaller and will be adjusted automatically:";

        internal const string IME_VERSION =
            "IME Version:";

        internal const string IME_BUFFER_MISMATCH =
            "IME buffers do not match";

        internal const string FILE_SAVE_SUCCESS =
            "File saved successfully -";

        internal const string NVRAM_VSS_ERASE =
            "Erasing Variable Storage Subsystem ($VSS) stores";

        internal const string NVRAM_SVS_ERASE =
            "Erasing Secure Variable stores ($SVS)";

        internal const string NVRAM_INIT_HDR =
            "Initializing header bytes 0x4h > 0x7h (0xFF)";

        internal const string NVRAM_INIT_HDR_VSS =
            "Initializing header bytes 0x9h > 0xAh (0xFF)";

        internal const string NVRAM_INIT_HDR_FAIL =
            "Initializing header failed";

        internal const string NVRAM_INIT_HDR_SUCCESS =
            "Initializing header successful";

        internal const string CRC_PATCH =
            "Patch CRC32 checksum";

        internal const string CRC_WRITE_TO_FW =
            "Write patched store to firmware buffer";

        internal const string CRC_WRITE_FAIL =
            "Write unsuccessful";

        internal const string CRC_WRITE_SUCCESS =
            "Write successful";

        internal const string CRC_BUFFER_EMPTY =
            "Buffer was empty";

        internal const string NVR_BASE_NOT_FOUND =
            "base not found - skipping";

        internal const string NVR_HAS_BODY_ERASING =
            "has body data - erasing";

        internal const string NVR_IS_EMPTY =
            "is empty - skipping";

        internal const string NVR_FAIL_ERASE_BODY =
            "Failed to erase body";

        internal const string NVR_FAIL_WRITE_VERIFY =
            "Write verification failed";

        internal const string NVR_ERASE_BODY =
            "Erasing store body data";

        internal const string NVR_WRITE_ERASED_BODY =
            "Writing erased body back to store";

        internal const string NVR_BODY_WRITE_FAIL =
            "New store body write unsuccessful";

        internal const string NVR_STORE_ERASE_SUCESS =
            "Store erase successful";

        internal const string AT =
            "at";

        internal const string LOCK_INVALIDATE =
            "Invalidating EFI lock";

        internal const string LOCK_PRIMARY_MAC =
            "Patching primary message authentication code";

        internal const string WRITE_NEW_DATA =
            "Writing new data to firmware";

        internal const string LOCK_BACKUP_MAC =
            "Patching backup message authentication code";

        internal const string LOCK_LOAD_SVS =
            "Loading NVRAM SVS stores from patched firmware";

        internal const string LOCK_PRIM_VERIF_FAIL =
            "Primary SVS store verification failed";

        internal const string LOCK_BACK_VERIF_FAIL =
            "Backup SVS store verification failed";

        internal const string SCFG_IMPORT_CANCELLED =
            "An SCfg store was not provided";

        internal const string SERIAL_LEN_INVALID =
            "Serial length invalid";

        internal const string SCFG_REPLACE =
            "Replace SCfg store";

        internal const string SCFG_BASE_ADJUST =
            "SCfg base not found - adjusted to";

        internal const string SCFG_LFB =
            "Loading SCfg store from firmware buffer";

        internal const string SCFG_POS_INITIALIZED =
            "Cannot write to 0x28A000h (Length B8h) because initialized data is present";

        internal const string ERASE_OLD_STORE =
            "Wiping existing SCfg store area with 0xFF pattern";

        internal const string MAIN_FLUENT_NOTLOADED =
            "Could not load embedded font resource: Resources.SegoeIcons.ttf";
        #endregion
    }

    internal class DIALOGSTRINGS
    {
        #region Strings
        internal const string REQUIRES_WIN_10 =
            "This application requires Windows 10 or later to run. The application will now quit.";

        internal const string UNSUPPORTED_OS =
            "Unsupported Operating Sytem";

        internal const string UNLOAD_FIRMWARE_RESET =
            "This will unload the firmware and all associated data. Are you sure you want to reset?";

        internal const string COULD_NOT_RELOAD =
            "Could not reload the file from disk as it was not found. It may have been moved or deleted.";

        internal const string DATA_EXPORT_FAILED =
            "Data export failed.";

        internal const string ARCHIVE_CREATE_FAILED =
            "Backup archive creation failed.";

        internal const string WARN_DATA_MATCHES_BUFF =
            "File on disk matches the buffer. Data was not refreshed.";

        internal const string FSYS_SUM_PATCH_FAILED =
            "Fsys checksum patching failed.";

        internal const string FSYS_SUM_PATCH_SUCCESS =
            "Fsys checksum patched successfully. Would you like to load the new file?";

        internal const string FSYS_EXPORT_FAIL =
            "Fsys Store export failed.";

        internal const string FSYS_SUM_MASK_FAIL =
            "Checksum masking failed.";

        internal const string EFI_LOCK_FAIL =
            "Invalidating EFI lock failed.";

        internal const string EFI_LOCK_SUCCESS =
            "Invalidating EFI lock successful. Make sure to perform an NVRAM reset on first boot.\r\nWould you like to load the new file?";

        internal const string IME_BASE_LIM_NOT_FOUND =
            "Management Engine base or limit not found.";

        internal const string S_ME_DIR_FAIL =
            "Failed to create the Intel ME region directory.";

        internal const string IME_EXPORT_FAIL =
            "Intel ME export failed.";

        internal const string LOG_NOT_FOUND =
            "The log file does not exist.";

        internal const string NOT_VALID_FIRMWARE =
            "The provided file was not a valid firmware.";

        internal const string NOT_VALID_EFIROM =
            "The provided file was not a valid EFIROM.";

        internal const string NOT_VALID_SOCROM =
            "The provided file was not a valid SOCROM.";

        internal const string SCFG_EXPORT_FAIL =
            "SCfg Store export failed.";

        internal const string ARCHIVE_EXPORT_FAIL =
            "Archive export failed.";

        internal const string FSYS_PATCH_SUCCESS_SAVE =
            "Fsys patching was successful. Do you want to save the output?";

        internal const string FW_SAVED_SUCCESS_LOAD =
            "Firmware saved successfully. Would you like to load the new file?";

        internal const string PATCH_FAIL_APP_LOG =
            "Patching failed. Would you like to open the application log?";

        internal const string IME_PATCH_SUCCESS_SAVE =
            "IME patching was successful. Do you want to save the output?";
        #endregion
    }

    internal class STARTUPSTRINGS
    {
        #region Strings
        #endregion
    }

    internal class EFISTRINGS
    {
        #region Strings
        internal const string VSS =
            "VSS";

        internal const string SVS =
            "SVS";

        internal const string FSYS_REGION =
            "FSYS_REGION";

        internal const string ME_REGION =
            "ME_REGION";

        internal const string CRC32 =
            "CRC32";

        internal const string CRC_FIXED =
            "CRC_FIXED";

        internal const string PRIMARY =
            "Primary";

        internal const string BACKUP =
            "Backup";

        internal const string NOMODEL =
            "NOMODEL";

        internal const string NOSERIAL =
            "SERIALNUMBER";

        internal const string NOFWVER =
            "NOFWVER";

        internal const string UNLOCKED =
            "Unlocked";

        internal const string LOCKED =
            "Locked";

        internal const string PRIMARY_REGION =
            "PRIMARYREGION";

        internal const string BACKUP_REGION =
            "BACKUPREGION";

        internal const string CRC_VALID =
            "CRC VALID";

        internal const string CRC_INVALID =
            "CRC INVALID";

        internal const string DXE_ARCHIVE =
            "DXE_ARCHIVE";

        internal const string EMPTY =
            "Empty";

        internal const string ACTIVE =
            "Active";

        internal const string APFS_DRIVER_FOUND =
            "YES (DRIVER FOUND)";

        internal const string APFS_DRIVER_NOT_FOUND =
            "NO (DRIVER NOT FOUND)";

        internal const string MENU_TIP_OPEN =
            "Open a Mac EFI/BIOS";

        internal const string MENU_TIP_COPY =
            "Open the Copy Menu";

        internal const string MENU_TIP_FOLDERS =
            "Open the Folders Menu";

        internal const string MENU_TIP_EXPORT =
            "Open the Export Menu";

        internal const string MENU_TIP_PATCH =
            "Open the Patch Menu";

        internal const string MENU_TIP_TOOLS =
            "Open the Tools Menu";

        internal const string MENU_TIP_HELP =
            "Open the Help Menu";

        internal const string MENU_TIP_OPENFILELOCATION =
            "Open File Location";

        internal const string COPIED_TO_CB_LC =
            "copied to clipboard.";

        internal const string FIRMWARE_MOD_FAILED_LOG =
            "Firmware modification failed. Would you like to view the application log?";

        internal const string FIRMWARE_MOD_SUCCESS_SAVE =
            "Firmware modified successfully. Would you like to save the output?";

        internal const string LZMA_VOL_FOUND =
            "LZMA DXE Archive Detected in Firmware";

        internal const string FMM_EMAIL_FOUND =
            "Find My Mac Email Detected in NVRAM (Click to view)";

        internal const string FMM_EMAIL =
            "FindMyMac_Email";
        #endregion
    }

    internal class SOCSTRINGS
    {
        #region Strings
        internal const string SCFG_REGION =
            "SCFG_REGION";

        internal const string MENU_TIP_OPEN =
           "Open a Mac SOCROM";

        internal const string MENU_TIP_COPY =
            "Open the Copy Menu";

        internal const string MENU_TIP_FOLDERS =
            "Open the Folders Menu";

        internal const string MENU_TIP_EXPORT =
            "Open the Export Menu";

        internal const string MENU_TIP_PATCH =
            "Open the Patch Menu";

        internal const string MENU_TIP_TOOLS =
            "Open the Tools Menu";

        internal const string MENU_TIP_HELP =
            "Open the Help Menu";

        internal const string MENU_TIP_OPENFILELOCATION =
            "Open File Location";

        internal const string ON =
            "on";

        internal const string T2 =
            "Apple T2";

        internal const string SILICON =
            "Apple Silicon";
        #endregion
    }

    internal class UPDATSTRINGS
    {
        #region Strings
        internal const string WAIT =
            "Please wait...";

        internal const string UPD_STARTED =
            "Update started";

        internal const string DOWNLOADING_VERSION =
            "Downloading version";

        internal const string DOWNLOADED =
            "Downloaded";

        internal const string VERIFY_SHA256 =
            "Verifying sha256 checksum";

        internal const string EXPECTED =
            "Expected";

        internal const string ACTUAL =
            "Actual";

        internal const string CHECKSUM_MISMATCH =
            "Checksum mismatch. Cannot continue.";

        internal const string SAVING_EXE =
            "Saving executable to";

        internal const string SAVE_FAIL =
            "File save failed. Cannot continue.";

        internal const string LAUNCH_VERSION =
            "Launching version";

        internal const string EXITING =
            "Exiting version";

        internal const string ERROR =
            "An error occured. See application log.";
        #endregion
    }
}