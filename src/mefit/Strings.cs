namespace Mac_EFI_Toolkit
{
    internal class AppStrings
    {
        #region Strings
        internal const string AS_NAME =
            "Mac EFI Toolkit";

        internal const string AS_VERSION =
            "Version";

        internal const string AS_LZMA_SDK =
            "LZMA SDK";

        internal const string AS_INFO =
            "Information";

        internal const string AS_WARNING =
            "Warning";

        internal const string AS_ERROR =
            "Error";

        internal const string AS_UNKNOWN =
            "Unknown";

        internal const string AS_NA =
            "N/A";

        internal const string AS_CONTACT_SERVER =
            "Contacting Apple server...";

        internal const string AS_NOT_FOUND =
            "Not Found";
        #endregion
    }

    internal class DialogStrings
    {
        #region Strings
        internal const string DS_UNLOAD_RESET =
            "This will unload the firmware and all associated data, are you sure you want to reset?";

        internal const string DS_DATA_NULL =
            "data is null. Cannot continue.";

        internal const string DS_RETURNED_FALSE =
            "returned false. Cannot continue.";

        internal const string DS_BASE_NOT_FOUND =
            "base address not found. Cannot continue.";

        internal const string DS_DATA_EXPORT_FAIL =
            "Data export failed.";

        internal const string DS_DATA_EXPORT_SUCCESS =
            "Data export successful.";

        internal const string DS_ARCHIVE_FAIL =
            "Archive creation failed.";

        internal const string DS_ARCHIVE_SUCCESS =
            "Archive created successfully.";

        internal const string DS_FILE_MOVED_OR_DELETED =
            "The file could not be found, it may have been moved or deleted.";

        internal const string DS_DISK_MATCHES_BUFFER =
            "File on disk matches the buffer, data was not refreshed.";

        internal const string DS_FSYS_CRC_PATCH_FAIL =
            "Fsys CRC32 patching failed.";

        internal const string DS_FSYS_CRC_PATCH_SUCCESS =
            "Fsys CRC32 patched successfully. Would you like to load the new file?";

        internal const string DS_FSYS_DIR_FAIL =
            "Failed to create the Fsys Stores directory.";

        internal const string DS_SCFG_DIR_FAIL =
            "Failed to create the Scfg Stores directory.";

        internal const string DS_FSYS_EXPORT_FAIL =
            "Fsys Store export failed.";

        internal const string DS_FSYS_EXPORT_SUCCESS =
            "Fsys Store export successful.";

        internal const string DS_INVALIDATING_LOCK_FAIL =
            "Invalidating EFI lock failed.";

        internal const string DS_INVALIDATING_LOCK_SUCCESS =
            "Invalidating EFI lock successful.\r\nMake sure to perform an NVRAM reset on first boot.\r\nWould you like to load the new file?";

        internal const string DS_ME_BOL_NOT_FOUND =
            "Management Engine base or limit not found.";

        internal const string DS_ME_DIR_FAIL =
            "Failed to create the Intel ME region directory.";

        internal const string DS_ME_EXPORT_FAIL =
            "Intel ME export failed.";

        internal const string DS_ME_EXPORT_SUCCESS =
            "Intel ME export successful.";

        internal const string DS_DIR_NOT_CREATED =
            "The directory has not been created yet.";

        internal const string DS_LOG_NOT_CREATED =
            "The log file has not been created yet.";

        internal const string DS_LOG_CREATION_SUCCESS =
            "Log file created successfully.";

        internal const string DS_NOT_VALID_FW =
            "The selected file is not a valid firmware.";

        internal const string DS_SCFG_EXPORT_SUCCESS =
            "Scfg Store export successful";

        internal const string DS_SCFG_EXPORT_FAIL =
            "Scfg Store export failed.";
        #endregion
    }

    internal class MainWinStrings
    {
        #region Strings
        internal const string MW_VSS =
            "VSS";

        internal const string MW_SVS =
            "SVS";

        internal const string MW_FILE =
            "FILE";

        internal const string MW_FSYS =
            "FSYS";

        internal const string MW_ME_REGION =
            "ME_REGION";

        internal const string MW_CRC32 =
            "CRC32";

        internal const string MW_CRC_FIXED =
            "CRC_FIXED";

        internal const string MW_BACKUP =
            "Backup";

        internal const string MW_NOMODEL =
            "NOMODEL";

        internal const string MW_NOSERIAL =
            "NOSERIAL";

        internal const string MW_NOFWVER =
            "NOFWVER";

        internal const string MW_FW_INFO =
            "FirmwareInfo";

        internal const string MW_UNLOCKED =
            "Unlocked";

        internal const string MW_LOCKED =
            "Locked";

        internal const string MW_UNKNOWN =
            "Unknown";

        internal const string MW_BYTES =
            "bytes";

        internal const string MW_APFS_DRIVER_FOUND =
            "YES (DRIVER FOUND)";

        internal const string MW_APFS_DRIVER_NOT_FOUND =
            "NO (DRIVER NOT FOUND)";

        internal const string MW_LOG_BU_MAKEFSYSPB_NULL =
            "BinaryUtils.MakeFsysCrcPatchedBinary returned null data";

        internal const string MW_LOG_FU_WRITEALL_RETURNED_FALSE =
            "FileUtils.WriteAllBytesEx returned false";

        internal const string MW_LOG_PS_BUFFER_MISMATCH =
            "Patched primary store bytes do not match the buffer";

        internal const string MW_LOG_BS_BUFFER_MISMATCH =
            "Patched backup store does not match buffer";
        #endregion

    }
    internal class ScfgWinStrings
    {
        internal const string SW_SCFG =
            "SCFG";
    }

}