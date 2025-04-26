// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCPatcher.cs - Handles patching of SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Tools;
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
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Check serial length.
            if (serial.Length != SOCROM.SERIAL_LENGTH)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SERIAL_LEN_INVALID} ({serial.Length})");
                return null;
            }

            // Check if the SerialBase exists.
            if (socrom.SCfg.SerialBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                return null;
            }

            // Create buffers.
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryTools.CloneBuffer(socrom.LoadedBinaryBuffer);
            byte[] serialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WriteCallerLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, socrom.SCfg.SerialBase, serialBuffer);

            Logger.WriteCallerLine(LOGSTRINGS.SCFG_LFB);

            // Load patched scfg from the binary buffer.
            SCfgStore scfgStore = socrom.ParseSCfgStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, scfgStore.Serial))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_NOT_WRITTEN}");
                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.SSN_WRITE_SUCCESS);

            // Log success and prompt for saving the patched firmware.
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            return binaryBuffer;
        }
        #endregion

        #region SCfg Store
        public byte[] WriteScfgStore(SOCROM socrom)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateScfgOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_IMPORT_CANCELLED}");
                    return null;
                }

                // Check the SOCROM contains a store, otherwise set the base address.
                int scfgBase = socrom.SCfg.StoreBase;
                bool scfgExists = true;

                // Set the Scfg base manually.
                if (scfgBase == -1)
                {
                    scfgExists = false;
                    Logger.WriteCallerLine($"{LOGSTRINGS.SCFG_BASE_ADJUST} {SOCROM.SCFG_EXPECTED_BASE:X}h");
                    scfgBase = SOCROM.SCFG_EXPECTED_BASE;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] binaryBuffer = BinaryTools.CloneBuffer(socrom.LoadedBinaryBuffer);
                byte[] scfgBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateScfgStore(scfgBuffer))
                {
                    return null;
                }

                // Check were not writing over data we shouldn't be.
                if (!scfgExists)
                {
                    byte[] emptyBuffer = BinaryTools.GetBytesBaseLength(binaryBuffer, SOCROM.SCFG_EXPECTED_BASE, scfgBuffer.Length);

                    for (int i = 0; i < emptyBuffer.Length; i++)
                    {
                        if (emptyBuffer[i] != 0xFF)
                        {
                            Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SCFG_POS_INITIALIZED}");
                            return null;
                        }
                    }
                }

                Logger.WriteLine(LOGSTRINGS.WRITE_NEW_DATA, Logger.LogType.Application);

                // 0xFF the original store from base + store length, so we don't leave behind parts of an old store.
                if (scfgExists)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.ERASE_OLD_STORE);
                    byte[] tempBuffer = new byte[socrom.SCfg.StoreLength];
                    BinaryTools.EraseByteArray(tempBuffer);
                    BinaryTools.OverwriteBytesAtBase(binaryBuffer, scfgBase, tempBuffer);
                }

                // Overwrite Scfg store in the binary buffer.
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, scfgBase, scfgBuffer);

                // Load Scfg store from the binary buffer.
                SCfgStore scfg = socrom.ParseSCfgStoreData(binaryBuffer, false);

                // Check store was written successfully.
                if (!BinaryTools.ByteArraysMatch(scfg.StoreBuffer, scfgBuffer))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                return binaryBuffer;
            }
        }

        private bool ValidateScfgStore(byte[] scfgbuffer)
        {
            int scfgBase = BinaryTools.GetBaseAddress(scfgbuffer, Signatures.Scfg.HeaderMarker);

            // Expect scfg signature at address 0h.
            if (scfgBase != 0)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_SIG_MISALIGNED}");
                return false;
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }
        #endregion

        #region I/O
        private static OpenFileDialog CreateScfgOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.ScfgDirectory,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private SaveFileDialog CreateFirmwareSaveFileDialog(SOCROM socrom)
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = APPSTRINGS.FILTER_BIN,
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
                    Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return string.Empty;
                }

                if (FileTools.WriteAllBytesEx(dialog.FileName, buffer) && File.Exists(dialog.FileName))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.FILE_SAVE_SUCCESS} {dialog.FileName}");
                    return dialog.FileName;
                }
            }

            return string.Empty;
        }
        #endregion
    }
}