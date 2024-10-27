namespace Mac_EFI_Toolkit
{
    internal class AppStrings
    {
        #region Strings
        internal const string S_NAME =
            "Mac EFI Toolkit";

        internal const string S_VERSION =
            "Version";

        internal const string S_LZMA_SDK =
            "LZMA SDK";

        internal const string S_EFIROM =
            "EFIROM";

        internal const string S_INFO =
            "Information";

        internal const string S_WARNING =
            "Warning";

        internal const string S_ERROR =
            "Error";

        internal const string S_UNKNOWN =
            "Unknown";

        internal const string S_NA =
            "N/A";

        internal const string S_CONTACT_SERVER =
            "Contacting Apple server...";

        internal const string S_NOT_FOUND =
            "Not Found";

        internal const string S_SUPPORTED_FW_FILTER =
            "UEFI/BIOS Files (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|All Files (*.*)|*.*";

        internal const string S_BIN_FILTER =
            "Binary Files (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|All Files (*.*)|*.*";

        internal const string S_ZIP_FILTER =
            "Zip files (*.zip)|*.zip";

        internal const string S_TXT_FILTER =
            "Text Files (*.txt)|*.txt";
        #endregion
    }

    internal class LogStrings
    {
        #region Strings
        internal const string S_PATCH_STARTED =
            "Patching started:";

        internal const string S_PATCH_ENDED =
            "Patching ended:";

        internal const string S_REPLACE_FSYS =
            "Replace Fsys store";

        internal const string S_FSYS_NOT_PROV =
            "An Fsys store was not provided";

        internal const string S_EXPORT_CANCEL =
            "The file export was cancelled";

        internal const string S_VAL_PASSED =
            "Validation passed";

        internal const string S_CS_MASK_SUCCESS =
            "Checksum masking successful";

        internal const string S_FSYS_W_SUCCESS =
            "Fsys store write successful";

        internal const string S_ERR_LOADING_FSYS =
            "Error loading Fsys store:";

        internal const string S_EXPECTED_SIZE =
            "Expected size is not";

        internal const string S_STORE_SIG_MISALIGN =
            "Store signature misaligned";

        internal const string S_NEW_SERIAL =
            "New serial:";

        internal const string S_NEW_HWC =
            "New HWC:";

        internal const string S_LENGTH =
            "Length";

        internal const string S_STORE_SUM_INVALID =
            "Store checksum is invalid";

        internal const string S_FOUND =
            "Found:";

        internal const string S_CALCULATED =
            "Calculated:";

        internal const string S_MASKING_CSUM =
            "Masking checksum";

        internal const string S_CSUM_MASKING_FAIL =
            "Checksum masking failed";

        internal const string S_STORE_COMP_FAILED =
            "Store comparison check failed";

        internal const string S_SAVE_SUCCESS =
            "File saved successully:";
        #endregion
    }

    internal class DialogStrings
    {
        #region Strings
        internal const string S_UNLOAD_RESET =
            "This will unload the firmware and all associated data, are you sure you want to reset?";

        internal const string S_DATA_NULL =
            "data is null. Cannot continue.";

        internal const string S_RETURNED_FALSE =
            "returned false. Cannot continue.";

        internal const string S_BASE_NOT_FOUND =
            "base address not found. Cannot continue.";

        internal const string S_DATA_EXPORT_FAIL =
            "Data export failed.";

        internal const string S_DATA_EXPORT_SUCCESS =
            "Data export successful.";

        internal const string S_ARCHIVE_CREATE_FAIL =
            "Backup archive creation failed.";

        internal const string S_ARCHIVE_CREATE_SUCCESS =
            "Backup archive created successfully.";

        internal const string S_FILE_NOT_FOUND =
            "The file could not be found, it may have been moved or deleted.";

        internal const string S_DISK_MATCHES_BUFFER =
            "File on disk matches the buffer, data was not refreshed.";

        internal const string S_FSYS_CRC_PATCH_FAIL =
            "Fsys CRC32 patching failed.";

        internal const string S_FSYS_CRC_PATCH_SUCCESS =
            "Fsys CRC32 patched successfully. Would you like to load the new file?";

        internal const string S_FSYS_DIR_FAIL =
            "Failed to create the Fsys Stores directory.";

        internal const string S_SCFG_DIR_FAIL =
            "Failed to create the Scfg Stores directory.";

        internal const string S_FSYS_EXPORT_FAIL =
            "Fsys Store export failed.";

        internal const string S_FSYS_EXPORT_SUCCESS =
            "Fsys Store export successful.";

        internal const string S_INVALIDATING_LOCK_FAIL =
            "Invalidating EFI lock failed.";

        internal const string S_INVALIDATING_LOCK_SUCCESS =
            "Invalidating EFI lock successful.\r\nMake sure to perform an NVRAM reset on first boot.\r\nWould you like to load the new file?";

        internal const string S_ME_BOL_NOT_FOUND =
            "Management Engine base or limit not found.";

        internal const string S_ME_DIR_FAIL =
            "Failed to create the Intel ME region directory.";

        internal const string S_ME_EXPORT_FAIL =
            "Intel ME export failed.";

        internal const string S_ME_EXPORT_SUCCESS =
            "Intel ME export successful.";

        internal const string S_DIR_NOT_CREATED =
            "The directory has not been created yet.";

        internal const string S_LOG_NOT_CREATED =
            "The log file has not been created yet.";

        internal const string S_LOG_CREATION_SUCCESS =
            "Log file created successfully.";

        internal const string S_NOT_VALID_FW =
            "The selected file is not a valid firmware.";

        internal const string S_SCFG_EXPORT_SUCCESS =
            "Scfg Store export successful";

        internal const string S_SCFG_EXPORT_FAIL =
            "Scfg Store export failed.";

        internal const string S_FSYS_PATCH_SUCCESS_SAVE =
            "Fsys patching was successful. Do you want to save the output?";

        internal const string S_FW_SAVED_SUCCESSFULLY =
            "Firmware saved successfully. Would you like to load the new file?";

        internal const string S_PATCH_FAIL_APP_LOG =
            "Patching failed. Would you like to open the application log?";
        #endregion
    }

    internal class StartupWinStrings
    {
        #region Strings
        #endregion
    }

    internal class EfiWinStrings
    {
        #region Strings
        internal const string S_VSS =
            "VSS";

        internal const string S_SVS =
            "SVS";

        internal const string S_FILE =
            "FILE";

        internal const string S_FSYS =
            "FSYS";

        internal const string S_ME_REGION =
            "ME_REGION";

        internal const string S_CRC32 =
            "CRC32";

        internal const string S_CRC_FIXED =
            "CRC_FIXED";

        internal const string S_BACKUP =
            "Backup";

        internal const string S_NOMODEL =
            "NOMODEL";

        internal const string S_NOSERIAL =
            "NOSERIAL";

        internal const string S_NOFWVER =
            "NOFWVER";

        internal const string S_FIRMWARE_INFO =
            "FirmwareInfo";

        internal const string S_UNLOCKED =
            "Unlocked";

        internal const string S_LOCKED =
            "Locked";

        internal const string S_UNKNOWN =
            "Unknown";

        internal const string S_BYTES =
            "bytes";

        internal const string S_APFS_DRIVER_FOUND =
            "YES (DRIVER FOUND)";

        internal const string S_APFS_DRIVER_NOT_FOUND =
            "NO (DRIVER NOT FOUND)";

        internal const string S_LOG_BU_MAKEFSYSPB_NULL =
            "BinaryUtils.MakeFsysCrcPatchedBinary returned null data";

        internal const string S_LOG_FU_WRITEALL_RETURNED_FALSE =
            "FileUtils.WriteAllBytesEx returned false";

        internal const string S_LOG_PS_BUFFER_MISMATCH =
            "Patched primary store bytes do not match the buffer";

        internal const string S_LOG_BS_BUFFER_MISMATCH =
            "Patched backup store does not match buffer";

        internal const string S_MENU_OPEN =
            "Open a Mac EFI/BIOS";

        internal const string S_MENU_RESET =
            "Unload Firmware and Reset Window";

        internal const string S_MENU_COPY =
            "Open the Copy Menu";

        internal const string S_MENU_RELOAD =
            "Reload File from Disk";

        internal const string S_MENU_EXPORT =
            "Open the Export Menu";

        internal const string S_MENU_PATCH =
            "Open the Firmware Patching Menu";

        internal const string S_MENU_OPTIONS =
            "Open the Options Menu";

        internal const string S_NAV_FILE =
            "Open File Location";

        internal const string S_COPIED_TO_CB =
            "copied to clipboard";
        #endregion
    }

    internal class T2WinStrings
    {
        #region Strings
        internal const string S_SCFG =
            "SCFG";
        #endregion
    }
}