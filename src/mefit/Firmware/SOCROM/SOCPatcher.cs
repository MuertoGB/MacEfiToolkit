// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCPatcher.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Utilities;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    public class SOCPatcher
    {
        #region Serial Number
        public byte[] WriteNewSerial(string serial, SOCROM socrom)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            // Check serial length.
            if (serial.Length != SOCROM.SERIAL_LENGTH)
            {
                Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.SERIAL_LEN_INVALID} ({serial.Length})");
                return null;
            }

            // Check if the serial base address exists.
            if (socrom.SCfg.SerialBase == -1)
            {
                Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.SSN_BASE_NOT_FOUND}");
                return null;
            }

            // Create buffers.
            Logger.LogInfo(LogStrings.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryUtils.CloneBuffer(socrom.LoadedBinaryBuffer);
            byte[] serialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.LogInfo(LogStrings.SSN_WTB);

            BinaryUtils.OverwriteBytesAtBase(
                binaryBuffer,
                socrom.SCfg.SerialBase,
                serialBuffer);

            Logger.LogInfo(LogStrings.SCFG_LFB);

            // Load patched scfg from the binary buffer.
            SCfgStore scfgStore = socrom.ParseSCfgStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, scfgStore.Serial))
            {
                Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.SSN_NOT_WRITTEN}");
                return null;
            }

            Logger.LogInfo(LogStrings.SSN_WRITE_SUCCESS);

            // Log success and prompt for saving the patched firmware.
            Logger.LogInfo(LogStrings.PATCH_SUCCESS);

            return binaryBuffer;
        }
        #endregion

        #region SCfg Store
        public byte[] WriteScfgStore(SOCROM socrom)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            using (OpenFileDialog dialog = CreateScfgOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.SCFG_IMPORT_CANCELLED}");
                    return null;
                }

                // Check the SOCROM contains a store, otherwise set the base address.
                int scfgBase = socrom.SCfg.StoreBase;
                bool scfgExists = true;

                // Set the Scfg base manually.
                if (scfgBase == -1)
                {
                    scfgExists = false;
                    Logger.LogWarning($"{LogStrings.SCFG_BASE_ADJUST} {SOCROM.SCFG_EXPECTED_BASE:X}h");
                    scfgBase = SOCROM.SCFG_EXPECTED_BASE;
                }

                Logger.LogInfo(LogStrings.CREATING_BUFFERS);

                byte[] binaryBuffer = BinaryUtils.CloneBuffer(socrom.LoadedBinaryBuffer);
                byte[] scfgBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateScfgStore(scfgBuffer))
                {
                    return null;
                }

                // Check were not writing over data we shouldn't be.
                if (!scfgExists)
                {
                    byte[] emptyBuffer = BinaryUtils.GetBytesBaseLength(binaryBuffer, SOCROM.SCFG_EXPECTED_BASE, scfgBuffer.Length);

                    for (int i = 0; i < emptyBuffer.Length; i++)
                    {
                        if (emptyBuffer[i] != 0xFF)
                        {
                            Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.SCFG_POS_INITIALIZED}");
                            return null;
                        }
                    }
                }

                Logger.LogInfo(LogStrings.WRITE_NEW_DATA, nameof(WriteScfgStore));

                // 0xFF the original store from base + store length, so we don't leave behind parts of an old store.
                if (scfgExists)
                {
                    Logger.LogInfo(LogStrings.ERASE_OLD_STORE);
                    byte[] tempBuffer = new byte[socrom.SCfg.StoreLength];
                    BinaryUtils.EraseByteArray(tempBuffer);
                    BinaryUtils.OverwriteBytesAtBase(binaryBuffer, scfgBase, tempBuffer);

                    // TODO: We need to verify store was erased.
                }

                // Overwrite Scfg store in the binary buffer.
                BinaryUtils.OverwriteBytesAtBase(binaryBuffer, scfgBase, scfgBuffer);

                // Load Scfg store from the binary buffer.
                SCfgStore scfg = socrom.ParseSCfgStoreData(binaryBuffer, false);

                // Check store was written successfully.
                if (!BinaryUtils.ByteArraysMatch(scfg.StoreBuffer, scfgBuffer))
                {
                    Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.STORE_COMP_FAILED}");
                    return null;
                }

                Logger.LogInfo(LogStrings.PATCH_SUCCESS);

                return binaryBuffer;
            }
        }

        private bool ValidateScfgStore(byte[] scfgbuffer)
        {
            int scfgBase = BinaryUtils.GetBaseAddress(scfgbuffer, Signatures.Scfg.HeaderMarker);

            // Expect scfg signature at address 0h.
            if (scfgBase != 0)
            {
                Logger.LogError($"{LogStrings.PATCH_FAIL} {LogStrings.STORE_SIG_MISALIGNED}");
                return false;
            }

            Logger.LogInfo(LogStrings.VALIDATION_PASS);

            return true;
        }
        #endregion

        #region I/O
        private static OpenFileDialog CreateScfgOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.ScfgDirectory,
                Filter = AppStrings.FILTER_BIN
            };
        }

        private SaveFileDialog CreateFirmwareSaveFileDialog(SOCROM socrom)
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = AppStrings.FILTER_BIN,
                FileName = socrom.FirmwareInfo.FileName,
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.BuildsDirectory
            };
        }

        public string SaveOutputFirmware(byte[] buffer, SOCROM socrom)
        {
            using (SaveFileDialog dialog = CreateFirmwareSaveFileDialog(socrom))
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.LogWarning(LogStrings.FILE_EXPORT_CANCELLED);
                    return string.Empty;
                }

                if (FileUtils.WriteAllBytesEx(dialog.FileName, buffer) && File.Exists(dialog.FileName))
                {
                    Logger.LogInfo($"{LogStrings.FILE_SAVE_SUCCESS} {dialog.FileName}");
                    return dialog.FileName;
                }
            }

            return string.Empty;
        }
        #endregion
    }
}