// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EFIPatcher.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Utilities;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Firmware.EFIROM
{
    public class EFIPatcher
    {
        #region Serial Number
        public byte[] WriteNewSerial(string serial, EFIROM efirom)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            // Check input serial length.
            if (serial.Length != 11 && serial.Length != 12)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.SERIAL_LEN_INVALID} ({serial.Length})");
                return null;
            }

            // Check if the SerialBase exists.
            if (efirom.Fsys.SerialBase == -1)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.SSN_BASE_NOT_FOUND}");
                return null;
            }

            // Create buffers.
            Logger.LogInfo(LogStrings.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryUtils.CloneBuffer(efirom.LoadedBinaryBuffer);
            byte[] serialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.LogInfo(LogStrings.SSN_WTB);

            BinaryUtils.OverwriteBytesAtBase(binaryBuffer, efirom.Fsys.SerialBase, serialBuffer);

            // Check HWC base and write new HWC.
            bool hwcBasePresent = efirom.Fsys.HWCBase != -1;
            string newHwc = null;

            if (hwcBasePresent)
            {
                newHwc = serial.Substring(8, efirom.Fsys.Serial.Length == 11 ? 3 : 4);
                byte[] newHwcBuffer = Encoding.UTF8.GetBytes(newHwc);

                Logger.LogInfo(LogStrings.HWC_WTB);

                // Write new HWC.
                BinaryUtils.OverwriteBytesAtBase(binaryBuffer, efirom.Fsys.HWCBase, newHwcBuffer);
            }

            Logger.LogInfo(LogStrings.FSYS_LFB);

            // Load patched fsys from the binary buffer.
            FsysStore fsys = efirom.ParseFsysStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, fsys.Serial))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.SSN_NOT_WRITTEN}");
                return null;
            }

            Logger.LogInfo(LogStrings.SSN_WRITE_SUCCESS);

            // Verify the HWC was written correctly, if applicable.
            if (hwcBasePresent && fsys.HWCBase != -1 && !string.Equals(newHwc, fsys.HWC))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.HWC_NOT_WRITTEN}");
                return null;
            }

            Logger.LogInfo(LogStrings.HWC_WRITE_SUCCESS);

            // Patch fsys checksum in the binary buffer.
            binaryBuffer = MakeFsysCrcPatchedBinary(binaryBuffer, fsys.BaseAddress, fsys.Buffer, fsys.CrcActual, fsys.Size, efirom);

            // Reload fsys store from the binary buffer and verify CRC masking success.
            fsys = efirom.ParseFsysStoreData(binaryBuffer, false);

            if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.FSYS_SUM_MASK_FAIL}");
                return null;
            }

            // Log success.
            Logger.LogInfo(LogStrings.PATCH_SUCCESS);

            return binaryBuffer;
        }
        #endregion

        #region Fsys Store
        public byte[] WriteNewFsysStore(EFIROM efiromInstance)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            using (OpenFileDialog dialog = CreateFsysOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.FSYS_IMPORT_CANCELLED}");
                    return null;
                }

                Logger.LogInfo(LogStrings.CREATING_BUFFERS);

                byte[] fsysBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateFsysStore(fsysBuffer, efiromInstance))
                {
                    return null;
                }

                FsysStore fsys = efiromInstance.ParseFsysStoreData(fsysBuffer, true);

                if (!ValidateFsysCrc(fsys, ref fsysBuffer, efiromInstance))
                {
                    return null;
                }

                byte[] binaryBuffer = BinaryUtils.CloneBuffer(efiromInstance.LoadedBinaryBuffer);

                if (!WriteFsysStore(binaryBuffer, fsysBuffer, efiromInstance))
                {
                    return null;
                }

                return binaryBuffer;
            }
        }

        private bool ValidateFsysStore(byte[] fsysbuffer, EFIROM efiromInstance)
        {
            int fsysBase = BinaryUtils.GetBaseAddress(fsysbuffer, Signatures.FsysStore.FsysMarker);

            if (fsysbuffer.Length != efiromInstance.Fsys.Size)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.EXPECTED_STORE_SIZE_NOT} {efiromInstance.Fsys.Size:X}h ({fsysbuffer.Length:X}h)");
                return false;
            }

            // Expect Fsys signature at 0h.
            if (fsysBase != 0)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.STORE_SIG_MISALIGNED}");
                return false;
            }

            Logger.LogInfo(LogStrings.VALIDATION_PASS);

            return true;
        }

        private bool ValidateFsysCrc(FsysStore fsys, ref byte[] fsysbuffer, EFIROM efiromInstance)
        {
            if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
            {
                Logger.LogInfo($"{LogStrings.FSYS_SUM_INVALID} ({LogStrings.FOUND} {fsys.CrcString}, {LogStrings.CALCULATED} {fsys.CrcActualString})");

                Logger.LogInfo(LogStrings.MASKING_SUM);

                fsysbuffer = PatchFsysStoreCrc(fsys.Buffer, fsys.CrcActual, fsys.Size);
                fsys = efiromInstance.ParseFsysStoreData(fsysbuffer, true);

                if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
                {
                    Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.SUM_MASKING_FAIL}");
                    return false;
                }

                Logger.LogInfo(LogStrings.FSYS_SUM_MASK_SUCCESS);
            }

            return true;
        }

        private bool WriteFsysStore(byte[] binarybuffer, byte[] fsysbuffer, EFIROM efiromInstance)
        {
            Logger.LogInfo(LogStrings.WRITE_NEW_DATA);

            BinaryUtils.OverwriteBytesAtBase(binarybuffer, efiromInstance.Fsys.BaseAddress, fsysbuffer);
            FsysStore fsys = efiromInstance.ParseFsysStoreData(binarybuffer, false);

            if (!BinaryUtils.ByteArraysMatch(fsys.Buffer, fsysbuffer))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.STORE_COMP_FAILED}");
                return false;
            }

            return true;
        }
        #endregion

        #region EFI Lock
        public byte[] RemoveEfiLock(EFIROM efiromInstance)
        {
            Logger.LogInfo(LogStrings.PATCH_START);
            Logger.LogInfo(LogStrings.CREATING_BUFFERS);

            // Initialize buffers.
            byte[] binaryBuffer = BinaryUtils.CloneBuffer(efiromInstance.LoadedBinaryBuffer);

            // Patch the primary store.
            byte[] primaryUnlockedBuffer = PatchPrimaryStore(binaryBuffer, efiromInstance);

            // Patch the backup store, if necessary.
            byte[] backupUnlockedBuffer = PatchBackupStore(binaryBuffer, efiromInstance);

            // Verify patched stores.
            if (!VerifyPatchedStores(binaryBuffer, primaryUnlockedBuffer, backupUnlockedBuffer, efiromInstance))
            {
                return null;
            }

            Logger.LogInfo(LogStrings.PATCH_SUCCESS);

            return binaryBuffer;
        }

        private byte[] PatchPrimaryStore(byte[] binarybuffer, EFIROM efiromInstance)
        {
            Logger.LogInfo(LogStrings.LOCK_PRIMARY_MAC);
            byte[] unlockedBuffer = PatchSvsStoreMac(efiromInstance.SvsPrimary.StoreBuffer, efiromInstance.EfiPrimaryLockStatus.LockBase);

            Logger.LogInfo(LogStrings.WRITE_NEW_DATA);
            BinaryUtils.OverwriteBytesAtBase(binarybuffer, efiromInstance.SvsPrimary.StoreBase, unlockedBuffer);

            return unlockedBuffer;
        }

        private byte[] PatchBackupStore(byte[] binarybuffer, EFIROM efiromInstance)
        {
            byte[] unlockedBuffer = null;

            if (efiromInstance.EfiBackupLockStatus.LockBase != -1)
            {
                Logger.LogInfo(LogStrings.LOCK_BACKUP_MAC);
                unlockedBuffer = PatchSvsStoreMac(efiromInstance.SvsSecondary.StoreBuffer, efiromInstance.EfiBackupLockStatus.LockBase);

                Logger.LogInfo(LogStrings.WRITE_NEW_DATA);
                BinaryUtils.OverwriteBytesAtBase(binarybuffer, efiromInstance.SvsSecondary.StoreBase, unlockedBuffer);
            }

            return unlockedBuffer;
        }

        private bool VerifyPatchedStores(byte[] binarybuffer, byte[] punlockedbuffer, byte[] bunlockedbuffer, EFIROM efiromInstance)
        {
            Logger.LogInfo(LogStrings.LOCK_LOAD_SVS);

            int primaryBase = BinaryUtils.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, efiromInstance.NvramBase, efiromInstance.NvramLimit);
            NvramStore svsPrimary = efiromInstance.ParseSingleNvramStore(binarybuffer, primaryBase, NvramStoreType.Secure);

            if (!BinaryUtils.ByteArraysMatch(svsPrimary.StoreBuffer, punlockedbuffer))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.LOCK_PRIM_VERIF_FAIL}");
                return false;
            }

            if (bunlockedbuffer != null)
            {
                int backupBase = BinaryUtils.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, primaryBase + EFIROM.HDR_SIZE, efiromInstance.NvramLimit);
                NvramStore svsBackup = efiromInstance.ParseSingleNvramStore(binarybuffer, backupBase, NvramStoreType.Secure);

                if (!BinaryUtils.ByteArraysMatch(svsBackup.StoreBuffer, bunlockedbuffer))
                {
                    Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.LOCK_BACK_VERIF_FAIL}");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Intel Management Engine
        public byte[] WriteNewIntelMeRegion(EFIROM efirom)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            using (OpenFileDialog dialog = CreateImeOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.IME_IMPORT_CANCELLED}");
                    return null;
                }

                Logger.LogInfo(LogStrings.CREATING_BUFFERS);

                byte[] imeBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateMeRegion(imeBuffer, efirom))
                {
                    return null;
                }

                string meVersion = IntelME.GetVersionData(imeBuffer, ImeVersionType.ME, efirom.Descriptor);

                Logger.LogInfo($"{LogStrings.IME_VERSION} {meVersion ?? AppStrings.NOT_FOUND}");

                byte[] binaryBuffer = BinaryUtils.CloneBuffer(efirom.LoadedBinaryBuffer);

                if (!WriteMeRegion(imeBuffer, binaryBuffer, efirom))
                {
                    return null;
                }

                Logger.LogInfo(LogStrings.PATCH_SUCCESS);

                return binaryBuffer;
            }
        }

        private bool ValidateMeRegion(byte[] mebuffer, EFIROM efirom)
        {
            int fptBase = BinaryUtils.GetBaseAddress(mebuffer, IntelME.FPTMarker);

            if (fptBase == -1)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.IME_FPT_NOT_FOUND}");
                return false;
            }

            if (mebuffer.Length > efirom.Descriptor.MeSize)
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.IME_TOO_LARGE} {mebuffer.Length:X}h > {efirom.Descriptor.MeSize:X}h");
                return false;
            }

            if (mebuffer.Length < efirom.Descriptor.MeSize)
            {
                Logger.LogInfo($"{LogStrings.IME_TOO_SMALL} {mebuffer.Length:X}h > {efirom.Descriptor.MeSize:X}h");
            }

            Logger.LogInfo(LogStrings.VALIDATION_PASS);

            return true;
        }

        private bool WriteMeRegion(byte[] mebuffer, byte[] binarybuffer, EFIROM efirom)
        {
            byte[] emptyBuffer = new byte[efirom.Descriptor.MeSize];
            BinaryUtils.EraseByteArray(emptyBuffer);

            Array.Copy(mebuffer, 0, emptyBuffer, 0, mebuffer.Length);
            Array.Copy(emptyBuffer, 0, binarybuffer, efirom.Descriptor.MeBase, emptyBuffer.Length);

            byte[] patchedMeBuffer = BinaryUtils.GetBytesBaseLimit(binarybuffer, (int)efirom.Descriptor.MeBase, (int)efirom.Descriptor.MeLimit);

            if (!BinaryUtils.ByteArraysMatch(patchedMeBuffer, emptyBuffer))
            {
                Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.IME_BUFFER_MISMATCH}");
                return false;
            }

            return true;
        }
        #endregion

        #region NVRAM
        public void CheckEraseStore(string storename, NvramStore nvramstore, byte[] buffer)
        {
            if (nvramstore.StoreBase == -1)
            {
                Logger.LogInfo($"{storename} {LogStrings.NVR_BASE_NOT_FOUND}");
            }
            else if (nvramstore.IsStoreEmpty)
            {
                Logger.LogInfo($"{storename} {LogStrings.NVR_IS_EMPTY}");
            }
            else if (!GetAndEraseStore(storename, nvramstore, buffer))
            {
                return;
            }
        }

        private bool GetAndEraseStore(string storename, NvramStore nvramstore, byte[] binarybuffer)
        {
            Logger.LogInfo($"{storename} {LogStrings.AT} {nvramstore.StoreBase:X}h {LogStrings.NVR_HAS_BODY_ERASING}");

            byte[] erasedBuffer = EraseNvramStore(NvramStoreType.Variable, nvramstore);

            if (erasedBuffer == null)
            {
                Logger.LogInfo($"{LogStrings.NVR_FAIL_ERASE_BODY} ({storename})");
                return false;
            }

            BinaryUtils.OverwriteBytesAtBase(binarybuffer, nvramstore.StoreBase, erasedBuffer);

            byte[] tempBuffer = BinaryUtils.GetBytesBaseLength(binarybuffer, nvramstore.StoreBase, nvramstore.StoreLength);

            if (!BinaryUtils.ByteArraysMatch(tempBuffer, erasedBuffer))
            {
                Logger.LogInfo($"{LogStrings.NVR_FAIL_WRITE_VERIFY} ({storename})");
                return false;
            }

            return true;
        }

        private byte[] EraseNvramStore(NvramStoreType nvramstoretype, NvramStore nvramstore)
        {
            try
            {
                byte[] storeBuffer = BinaryUtils.CloneBuffer(nvramstore.StoreBuffer);
                int bodyStart = EFIROM.HDR_SIZE;
                int bodyEnd = nvramstore.StoreBuffer.Length - EFIROM.HDR_SIZE;

                // Initialize header.
                Logger.LogInfo(LogStrings.NVRAM_INIT_HDR);
                for (int i = 0x4; i <= 0x7; i++)
                {
                    storeBuffer[i] = 0xFF;
                }

                if (nvramstoretype == NvramStoreType.Variable)
                {
                    Logger.LogInfo(LogStrings.NVRAM_INIT_HDR_VSS);
                    for (int i = 0x9; i <= 0xA; i++)
                    {
                        storeBuffer[i] = 0xFF;
                    }
                }

                // Verify that the relevant header bytes have been set to 0xFF.
                if (!VerifyErasedNvramHeader(storeBuffer, nvramstoretype))
                {
                    Logger.LogInfo($"{LogStrings.PATCH_FAIL} {LogStrings.NVRAM_INIT_HDR_FAIL}");
                    return null;
                }

                Logger.LogInfo(LogStrings.NVRAM_INIT_HDR_SUCCESS);

                // Pull the store body from the buffer.
                byte[] erasedStoreBodyBuffer = BinaryUtils.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                Logger.LogInfo(LogStrings.NVR_ERASE_BODY);

                // Erase the store body.
                BinaryUtils.EraseByteArray(erasedStoreBodyBuffer);

                Logger.LogInfo(LogStrings.NVR_WRITE_ERASED_BODY);

                // Write the erased store back to the nvram store buffer.
                BinaryUtils.OverwriteBytesAtBase(storeBuffer, bodyStart, erasedStoreBodyBuffer);

                // Check the body was erased.
                erasedStoreBodyBuffer = BinaryUtils.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                if (!BinaryUtils.IsByteBlockEmpty(erasedStoreBodyBuffer))
                {
                    Logger.LogInfo(LogStrings.NVR_BODY_WRITE_FAIL);
                    return null;
                }

                Logger.LogInfo(LogStrings.NVR_STORE_ERASE_SUCESS);

                return storeBuffer;
            }
            catch (Exception e)
            {
                Logger.LogException(e, nameof(EraseNvramStore)); ;
                return null;
            }
        }

        private static bool VerifyErasedNvramHeader(byte[] storebuffer, NvramStoreType storetype)
        {
            for (int i = 0x4; i <= 0x7; i++)
            {
                if (storebuffer[i] != 0xFF)
                    return false;
            }

            if (storetype == NvramStoreType.Variable)
            {
                for (int i = 0x9; i <= 0xA; i++)
                {
                    if (storebuffer[i] != 0xFF)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Patches the given Fsys store byte array with a new CRC value.
        /// </summary>
        /// <param name="sourcebuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched.</param>
        /// <returns>The patched Fsys store byte array.</returns>
        internal byte[] PatchFsysStoreCrc(byte[] sourcebuffer, uint newcrc, int fsyssize)
        {
            // Convert the new CRC value to bytes
            byte[] crcBuffer = BitConverter.GetBytes(newcrc);

            // Write the new bytes back to the Fsys store at the appropriate base
            BinaryUtils.OverwriteBytesAtBase(sourcebuffer, fsyssize - EFIROM.CRC32_SIZE, crcBuffer);

            // Return the patched data
            return sourcebuffer;
        }

        /// <summary>
        /// Patches a binaries Fsys store with the correct crc value.
        /// </summary>
        /// <param name="sourcebuffer">The byte array representing the source binary file.</param>
        /// <param name="baseposition">The base of the Fsys store within the binary file.</param>
        /// <param name="fsysbuffer">The byte array representing the Fsys store.</param>
        /// <param name="newcrc">The new CRC value to be patched in the Fsys store.</param>
        /// <returns>The patched file byte array, or null if the new calculated crc does not match the crc in the Fsys store.</returns>
        internal byte[] MakeFsysCrcPatchedBinary(byte[] sourcebuffer, int baseposition, byte[] fsysbuffer, uint newcrc, int fsyssize, EFIROM efirom)
        {
            Logger.LogInfo(LogStrings.PATCH_START);

            Logger.LogInfo(LogStrings.CREATING_BUFFERS);

            // Create a new byte array to hold the patched binary.
            byte[] patchedSource = new byte[sourcebuffer.Length];

            Array.Copy(sourcebuffer, patchedSource, sourcebuffer.Length);

            Logger.LogInfo(LogStrings.CRC_PATCH);

            // Patch the Fsys store crc.
            byte[] patchedBuffer = PatchFsysStoreCrc(fsysbuffer, newcrc, fsyssize);

            Logger.LogInfo(LogStrings.CRC_WRITE_TO_FW);

            // Overwrite the loaded Fsys crc32 with the newly calculated crc32.
            BinaryUtils.OverwriteBytesAtBase(patchedSource, baseposition, patchedBuffer);

            // Load the Fsys store from the new binary.
            FsysStore fsys = efirom.ParseFsysStoreData(patchedSource, false);

            // Compare the new checksums.
            if (fsys.CrcString != fsys.CrcActualString)
            {
                Logger.LogInfo(LogStrings.CRC_WRITE_FAIL);
                return null;
            }

            Logger.LogInfo(LogStrings.PATCH_SUCCESS);

            return patchedSource;
        }

        /// <summary>
        /// Invalidates an SVS store Message Authentication Code, removing EFI Lock.
        /// </summary>
        /// <param name="sourcebuffer">The SVS store to unlock.</param>
        /// <param name="lockposition">The Message Authentication Code base address.</param>
        internal byte[] PatchSvsStoreMac(byte[] sourcebuffer, int lockposition)
        {
            // Some sanity checks.
            if (sourcebuffer == null || sourcebuffer.Length < 16)
            {
                return null;
            }

            // Write 0xFh length zeros over the MAC CRC from lockBase
            BinaryUtils.OverwriteBytesAtBase(sourcebuffer, lockposition, new byte[0x0F]);

            // Returned the unlocked store
            return sourcebuffer;
        }
        #endregion

        #region I/O
        private SaveFileDialog CreateFirmwareSaveFileDialog(EFIROM efirom)
        {
            Program.EnsureDirectoriesExist();

            return new SaveFileDialog
            {
                Filter = AppStrings.FILTER_BIN,
                FileName = efirom.FirmwareInfo.FileName,
                OverwritePrompt = true,
                InitialDirectory = ApplicationPaths.BuildsDirectory
            };
        }

        private OpenFileDialog CreateFsysOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.FsysDirectory,
                Filter = AppStrings.FILTER_BIN
            };
        }

        private OpenFileDialog CreateImeOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.IntelMeDirectory,
                Filter = AppStrings.FILTER_BIN
            };
        }

        public string SaveOutputFirmware(byte[] binarybuffer, EFIROM efirom)
        {
            using (SaveFileDialog dialog = CreateFirmwareSaveFileDialog(efirom))
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.LogInfo(LogStrings.FILE_EXPORT_CANCELLED);
                    return string.Empty;
                }

                if (FileUtils.WriteAllBytesEx(dialog.FileName, binarybuffer) && File.Exists(dialog.FileName))
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