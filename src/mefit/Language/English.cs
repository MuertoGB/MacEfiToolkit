// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// English.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit
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

        internal const string EFIROM =
            "EFIROM";

        internal const string SOCROM =
            "SOCROM";

        internal const string UNKNOWN =
            "Unknown";

        internal const string NA =
            "N/A";

        internal const string BYTES =
            "bytes";

        internal const string CONTACT_SERVER =
            "Contacting Server...";

        internal const string NOT_FOUND =
            "Not Found";

        internal const string FILTER_SUPPORT_FIRMWARE =
            "UEFI/BIOS Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*";

        internal const string FILTER_BIN =
            "Binary Files (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|All Files (*.*)|*.*";

        internal const string FILTER_ZIP =
            "Zip files (*.zip)|*.zip";

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
            "Patching started:";

        internal const string PATCH_END =
            "Patching ended:";

        internal const string CREATING_BUFFERS =
            "Creating buffers";

        internal const string FILE_EXPORT_CANCELLED =
            "The file export was cancelled";

        internal const string VALIDATION_PASS =
            "Validation passed";

        internal const string EXPECTED_STORE_SIZE_NOT =
            "Expected store size is not";

        internal const string STORE_SIG_MISALIGNED =
            "Store signature misaligned";

        internal const string NEW_SERIAL =
            "New serial:";

        internal const string NEW_HWC =
            "New HWC:";

        internal const string LENGTH =
            "Length";

        internal const string ERROR_FILE_BYTES =
            "Error loading file bytes:";

        internal const string FSYS_REPLACE =
            "Replace Fsys store";

        internal const string FSYS_IMPORT_CANCELLED =
            "An Fsys store was not provided";

        internal const string FSYS_SUM_MASK_SUCCESS =
            "Fsys checksum masking successful.";

        internal const string FSYS_WRITE_SUCCESS =
            "Fsys store written successfully";

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

        internal const string SSN_REPLACE =
            "Replace system serial number";

        internal const string SSN_BASE_NOT_FOUND =
            "Serial number base address was not found";

        internal const string SSN_NOT_WRITTEN =
            "New serial could not be written";

        internal const string HWC_NOT_WRITTEN =
            "New hardware configuration (HWC) could not be written";

        internal const string SSN_WRITE_SUCCESS =
            "Serial number written successfully";

        internal const string IME_REPLACE =
            "Replace Intel Management Engine";

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

        internal const string IME_WRITE_SUCCESS =
            "IME written successfully";

        internal const string FILE_SAVE_SUCCESS =
            "File saved successully:";

        internal const string NVRAM_ERASE =
            "Erase NVRAM";

        internal const string NVRAM_VSS_ERASE =
            "Erasing NVRAM VSS regions";

        internal const string NVRAM_SVS_ERASE =
            "Erasing NVRAM SVS regions";

        internal const string NVRAM_INIT_HDR =
            "Initializing header bytes 0x4h > 0x7h (0xFF)";

        internal const string NVRAM_INIT_HDR_VSS =
            "Initializing header bytes 0x9h > 0xAh (0xFF)";

        internal const string NVRAM_INIT_HDR_FAIL =
            "Initializing header failed";

        internal const string NVRAM_INIT_HDR_SUCCESS =
            "Initializing header successful";

        internal const string CRC_MASK =
            "Mask fsys checksum";

        internal const string CRC_PATCH =
            "Patching checksum";

        internal const string CRC_WRITE_TO_FW =
            "Write patched store to firmware";

        internal const string CRC_WRITE_FAIL =
            "Write unsuccessful";

        internal const string CRC_WRITE_SUCCESS =
            "Write successful";

        internal const string CRC_BUFFER_EMPTY =
            "Buffer was empty";

        internal const string NVR_HAS_BODY_ERASING =
            "has body data - erasing";

        internal const string NVR_ERASE_BUFFER_EMPTY =
            "erase failed - the returned buffer was empty";

        internal const string NVR_IS_EMPTY =
            "is empty - skipping";

        internal const string NVR_VERIFY_FAIL =
            "Verification failed for";

        internal const string NVR_VERIFY_SUCCESS =
            "Verification succeeded for";

        internal const string AT =
            "at";

        internal const string LOCK_INVALIDATE =
            "Invalidating EFI lock";

        internal const string LOCK_PRIMARY_MAC =
            "Patching primary message authentication code";

        internal const string LOCK_WRITE =
            "Writing patched store to firmware";

        internal const string LOCK_BACKUP_MAC =
            "Patching backup message authentication code";

        internal const string LOCK_LOAD_SVS =
            "Loading NVRAM SVS stores from patched firmware";

        internal const string LOCK_PRIM_VERIF_FAIL =
            "Primary SVS store verification failed";

        internal const string LOCK_BACK_VERIF_FAIL =
            "Backup SVS store verification failed";

        internal const string LOCK_VERIF_SUCCESS =
            "NVRAM SVS verification succeeded";
        #endregion
    }

    internal class DIALOGSTRINGS
    {
        #region Strings
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

        internal const string FILE_NOT_VALID =
            "The selected file is not a valid firmware.";

        internal const string SCFG_EXPORT_FAIL =
            "Scfg Store export failed.";

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

        internal const string FILE =
            "FILE";

        internal const string FSYS =
            "FSYS";

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

        internal const string FIRMWARE_INFO =
            "FirmwareInfo";

        internal const string UNLOCKED =
            "Unlocked";

        internal const string LOCKED =
            "Locked";

        internal const string BASE =
            "Base:";

        internal const string LIMIT =
            "Limit:";

        internal const string SIZE =
            "Size:";

        internal const string PRIMARY_REGION =
            "PRIMARYREGION";

        internal const string BACKUP_REGION =
            "BACKUPREGION";

        internal const string CRC_VALID =
            "CRC VALID";

        internal const string CRC_INVALID =
            "CRC INVALID";

        internal const string EMPTY =
            "Empty";

        internal const string APFS_DRIVER_FOUND =
            "YES (DRIVER FOUND)";

        internal const string APFS_DRIVER_NOT_FOUND =
            "NO (DRIVER NOT FOUND)";

        internal const string MENU_TIP_OPEN =
            "Open a Mac EFI/BIOS";

        internal const string MENU_TIP_RESET =
            "Unload Firmware and Reset Window";

        internal const string MENU_TIP_COPY =
            "Open the Copy Menu";

        internal const string MENU_TIP_FOLDERS =
            "Open the Folders Menu";

        internal const string MENU_TIP_EXPORT =
            "Open the Export Menu";

        internal const string MENU_TIP_PATCH =
            "Open the Firmware Patching Menu";

        internal const string MENU_TIP_OPTIONS =
            "Open the Options Menu";

        internal const string MENU_TIP_OPENFILELOCATION =
            "Open File Location";

        internal const string COPIED_TO_CB_LC =
            "copied to clipboard.";

        internal const string FIRMWARE_MOD_FAILED_LOG =
            "Firmware modification failed. Would you like to view the application log?";

        internal const string FIRMWARE_MOD_SUCCESS_SAVE =
            "Firmware modified successfully. Would you like to save the output?";
        #endregion
    }

    internal class T2STRINGS
    {
        #region Strings
        internal const string SCFG =
            "SCFG";
        #endregion
    }
}