// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// EFIPatcher.cs - Handles patching of EFIROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Tools;
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
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            // Check input serial length.
            if (serial.Length != 11 && serial.Length != 12)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SERIAL_LEN_INVALID} ({serial.Length})");
                return null;
            }

            // Check if the SerialBase exists.
            if (efirom.Fsys.SerialBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_BASE_NOT_FOUND}");
                return null;
            }

            // Create buffers.
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            byte[] binaryBuffer = BinaryTools.CloneBuffer(efirom.LoadedBinaryBuffer);
            byte[] serialBuffer = Encoding.UTF8.GetBytes(serial);

            // Overwrite serial in the binary buffer.
            Logger.WriteCallerLine(LOGSTRINGS.SSN_WTB);

            BinaryTools.OverwriteBytesAtBase(binaryBuffer, efirom.Fsys.SerialBase, serialBuffer);

            // Check HWC base and write new HWC.
            bool hwcBasePresent = efirom.Fsys.HWCBase != -1;
            string newHwc = null;

            if (hwcBasePresent)
            {
                newHwc = serial.Substring(8, efirom.Fsys.Serial.Length == 11 ? 3 : 4);
                byte[] newHwcBuffer = Encoding.UTF8.GetBytes(newHwc);

                Logger.WriteCallerLine(LOGSTRINGS.HWC_WTB);

                // Write new HWC.
                BinaryTools.OverwriteBytesAtBase(binaryBuffer, efirom.Fsys.HWCBase, newHwcBuffer);
            }

            Logger.WriteCallerLine(LOGSTRINGS.FSYS_LFB);

            // Load patched fsys from the binary buffer.
            FsysStore fsys = efirom.ParseFsysStoreData(binaryBuffer, false);

            // Verify the serial was written correctly.
            if (!string.Equals(serial, fsys.Serial))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SSN_NOT_WRITTEN}");
                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.SSN_WRITE_SUCCESS);

            // Verify the HWC was written correctly, if applicable.
            if (hwcBasePresent && fsys.HWCBase != -1 && !string.Equals(newHwc, fsys.HWC))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.HWC_NOT_WRITTEN}");
                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.HWC_WRITE_SUCCESS);

            // Patch fsys checksum in the binary buffer.
            binaryBuffer = MakeFsysCrcPatchedBinary(binaryBuffer, fsys.BaseAddress, fsys.Buffer, fsys.CrcActual, fsys.Size, efirom);

            // Reload fsys store from the binary buffer and verify CRC masking success.
            fsys = efirom.ParseFsysStoreData(binaryBuffer, false);

            if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_SUM_MASK_FAIL}");
                return null;
            }

            // Log success.
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            return binaryBuffer;
        }
        #endregion

        #region Fsys Store
        public byte[] WriteNewFsysStore(EFIROM efiromInstance)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateFsysOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.FSYS_IMPORT_CANCELLED}");
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

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

                byte[] binaryBuffer = BinaryTools.CloneBuffer(efiromInstance.LoadedBinaryBuffer);

                if (!WriteFsysStore(binaryBuffer, fsysBuffer, efiromInstance))
                {
                    return null;
                }

                return binaryBuffer;
            }
        }

        private bool ValidateFsysStore(byte[] fsysbuffer, EFIROM efiromInstance)
        {
            int fsysBase = BinaryTools.GetBaseAddress(fsysbuffer, Signatures.FsysStore.FsysMarker);

            if (fsysbuffer.Length != efiromInstance.Fsys.Size)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.EXPECTED_STORE_SIZE_NOT} {efiromInstance.Fsys.Size:X}h ({fsysbuffer.Length:X}h)");
                return false;
            }

            // Expect Fsys signature at 0h.
            if (fsysBase != 0)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_SIG_MISALIGNED}");
                return false;
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool ValidateFsysCrc(FsysStore fsys, ref byte[] fsysbuffer, EFIROM efiromInstance)
        {
            if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.FSYS_SUM_INVALID} ({LOGSTRINGS.FOUND} {fsys.CrcString}, {LOGSTRINGS.CALCULATED} {fsys.CrcActualString})");

                Logger.WriteCallerLine(LOGSTRINGS.MASKING_SUM);

                fsysbuffer = PatchFsysStoreCrc(fsys.Buffer, fsys.CrcActual, fsys.Size);
                fsys = efiromInstance.ParseFsysStoreData(fsysbuffer, true);

                if (!string.Equals(fsys.CrcString, fsys.CrcActualString))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.SUM_MASKING_FAIL}");
                    return false;
                }

                Logger.WriteCallerLine(LOGSTRINGS.FSYS_SUM_MASK_SUCCESS);
            }

            return true;
        }

        private bool WriteFsysStore(byte[] binarybuffer, byte[] fsysbuffer, EFIROM efiromInstance)
        {
            Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);

            BinaryTools.OverwriteBytesAtBase(binarybuffer, efiromInstance.Fsys.BaseAddress, fsysbuffer);
            FsysStore fsys = efiromInstance.ParseFsysStoreData(binarybuffer, false);

            if (!BinaryTools.ByteArraysMatch(fsys.Buffer, fsysbuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.STORE_COMP_FAILED}");
                return false;
            }

            return true;
        }
        #endregion

        #region EFI Lock
        public byte[] RemoveEfiLock(EFIROM efiromInstance)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);
            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            // Initialize buffers.
            byte[] binaryBuffer = BinaryTools.CloneBuffer(efiromInstance.LoadedBinaryBuffer);

            // Patch the primary store.
            byte[] primaryUnlockedBuffer = PatchPrimaryStore(binaryBuffer, efiromInstance);

            // Patch the backup store, if necessary.
            byte[] backupUnlockedBuffer = PatchBackupStore(binaryBuffer, efiromInstance);

            // Verify patched stores.
            if (!VerifyPatchedStores(binaryBuffer, primaryUnlockedBuffer, backupUnlockedBuffer, efiromInstance))
            {
                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

            return binaryBuffer;
        }

        private byte[] PatchPrimaryStore(byte[] binarybuffer, EFIROM efiromInstance)
        {
            Logger.WriteCallerLine(LOGSTRINGS.LOCK_PRIMARY_MAC);
            byte[] unlockedBuffer = PatchSvsStoreMac(efiromInstance.SvsPrimary.StoreBuffer, efiromInstance.EfiPrimaryLockStatus.LockBase);

            Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);
            BinaryTools.OverwriteBytesAtBase(binarybuffer, efiromInstance.SvsPrimary.StoreBase, unlockedBuffer);

            return unlockedBuffer;
        }

        private byte[] PatchBackupStore(byte[] binarybuffer, EFIROM efiromInstance)
        {
            byte[] unlockedBuffer = null;

            if (efiromInstance.EfiBackupLockStatus.LockBase != -1)
            {
                Logger.WriteCallerLine(LOGSTRINGS.LOCK_BACKUP_MAC);
                unlockedBuffer = PatchSvsStoreMac(efiromInstance.SvsSecondary.StoreBuffer, efiromInstance.EfiBackupLockStatus.LockBase);

                Logger.WriteCallerLine(LOGSTRINGS.WRITE_NEW_DATA);
                BinaryTools.OverwriteBytesAtBase(binarybuffer, efiromInstance.SvsSecondary.StoreBase, unlockedBuffer);
            }

            return unlockedBuffer;
        }

        private bool VerifyPatchedStores(byte[] binarybuffer, byte[] punlockedbuffer, byte[] bunlockedbuffer, EFIROM efiromInstance)
        {
            Logger.WriteCallerLine(LOGSTRINGS.LOCK_LOAD_SVS);

            int primaryBase = BinaryTools.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, efiromInstance.NvramBase, efiromInstance.NvramLimit);
            NvramStore svsPrimary = efiromInstance.ParseSingleNvramStore(binarybuffer, primaryBase, NvramStoreType.Secure);

            if (!BinaryTools.ByteArraysMatch(svsPrimary.StoreBuffer, punlockedbuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_PRIM_VERIF_FAIL}");
                return false;
            }

            if (bunlockedbuffer != null)
            {
                int backupBase = BinaryTools.GetBaseAddressUpToLimit(binarybuffer, Signatures.Nvram.SvsStoreMarker, primaryBase + EFIROM.HDR_SIZE, efiromInstance.NvramLimit);
                NvramStore svsBackup = efiromInstance.ParseSingleNvramStore(binarybuffer, backupBase, NvramStoreType.Secure);

                if (!BinaryTools.ByteArraysMatch(svsBackup.StoreBuffer, bunlockedbuffer))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.LOCK_BACK_VERIF_FAIL}");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Intel Management Engine
        public byte[] WriteNewIntelMeRegion(EFIROM efirom)
        {
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            using (OpenFileDialog dialog = CreateImeOpenFileDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_IMPORT_CANCELLED}");
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

                byte[] imeBuffer = File.ReadAllBytes(dialog.FileName);

                if (!ValidateMeRegion(imeBuffer, efirom))
                {
                    return null;
                }

                string meVersion = IntelME.GetVersionData(imeBuffer, ImeVersionType.ME, efirom.Descriptor);

                Logger.WriteCallerLine($"{LOGSTRINGS.IME_VERSION} {meVersion ?? APPSTRINGS.NOT_FOUND}");

                byte[] binaryBuffer = BinaryTools.CloneBuffer(efirom.LoadedBinaryBuffer);

                if (!WriteMeRegion(imeBuffer, binaryBuffer, efirom))
                {
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

                return binaryBuffer;
            }
        }

        private bool ValidateMeRegion(byte[] mebuffer, EFIROM efirom)
        {
            int fptBase = BinaryTools.GetBaseAddress(mebuffer, IntelME.FPTMarker);

            if (fptBase == -1)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_FPT_NOT_FOUND}");
                return false;
            }

            if (mebuffer.Length > efirom.Descriptor.MeSize)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_TOO_LARGE} {mebuffer.Length:X}h > {efirom.Descriptor.MeSize:X}h");
                return false;
            }

            if (mebuffer.Length < efirom.Descriptor.MeSize)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.IME_TOO_SMALL} {mebuffer.Length:X}h > {efirom.Descriptor.MeSize:X}h");
            }

            Logger.WriteCallerLine(LOGSTRINGS.VALIDATION_PASS);

            return true;
        }

        private bool WriteMeRegion(byte[] mebuffer, byte[] binarybuffer, EFIROM efirom)
        {
            byte[] emptyBuffer = new byte[efirom.Descriptor.MeSize];
            BinaryTools.EraseByteArray(emptyBuffer);

            Array.Copy(mebuffer, 0, emptyBuffer, 0, mebuffer.Length);
            Array.Copy(emptyBuffer, 0, binarybuffer, efirom.Descriptor.MeBase, emptyBuffer.Length);

            byte[] patchedMeBuffer = BinaryTools.GetBytesBaseLimit(binarybuffer, (int)efirom.Descriptor.MeBase, (int)efirom.Descriptor.MeLimit);

            if (!BinaryTools.ByteArraysMatch(patchedMeBuffer, emptyBuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.IME_BUFFER_MISMATCH}");
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
                Logger.WriteCallerLine($"{storename} {LOGSTRINGS.NVR_BASE_NOT_FOUND}");
            }
            else if (nvramstore.IsStoreEmpty)
            {
                Logger.WriteCallerLine($"{storename} {LOGSTRINGS.NVR_IS_EMPTY}");
            }
            else if (!GetAndEraseStore(storename, nvramstore, buffer))
            {
                return;
            }
        }

        private bool GetAndEraseStore(string storename, NvramStore nvramstore, byte[] binarybuffer)
        {
            Logger.WriteCallerLine($"{storename} {LOGSTRINGS.AT} {nvramstore.StoreBase:X}h {LOGSTRINGS.NVR_HAS_BODY_ERASING}");

            byte[] erasedBuffer = EraseNvramStore(NvramStoreType.Variable, nvramstore);

            if (erasedBuffer == null)
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.NVR_FAIL_ERASE_BODY} ({storename})");
                return false;
            }

            BinaryTools.OverwriteBytesAtBase(binarybuffer, nvramstore.StoreBase, erasedBuffer);

            byte[] tempBuffer = BinaryTools.GetBytesBaseLength(binarybuffer, nvramstore.StoreBase, nvramstore.StoreLength);

            if (!BinaryTools.ByteArraysMatch(tempBuffer, erasedBuffer))
            {
                Logger.WriteCallerLine($"{LOGSTRINGS.NVR_FAIL_WRITE_VERIFY} ({storename})");
                return false;
            }

            return true;
        }

        private byte[] EraseNvramStore(NvramStoreType nvramstoretype, NvramStore nvramstore)
        {
            try
            {
                byte[] storeBuffer = BinaryTools.CloneBuffer(nvramstore.StoreBuffer);
                int bodyStart = EFIROM.HDR_SIZE;
                int bodyEnd = nvramstore.StoreBuffer.Length - EFIROM.HDR_SIZE;

                // Initialize header.
                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR);
                for (int i = 0x4; i <= 0x7; i++)
                {
                    storeBuffer[i] = 0xFF;
                }

                if (nvramstoretype == NvramStoreType.Variable)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR_VSS);
                    for (int i = 0x9; i <= 0xA; i++)
                    {
                        storeBuffer[i] = 0xFF;
                    }
                }

                // Verify that the relevant header bytes have been set to 0xFF.
                if (!VerifyErasedNvramHeader(storeBuffer, nvramstoretype))
                {
                    Logger.WriteCallerLine($"{LOGSTRINGS.PATCH_FAIL} {LOGSTRINGS.NVRAM_INIT_HDR_FAIL}");
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.NVRAM_INIT_HDR_SUCCESS);

                // Pull the store body from the buffer.
                byte[] erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                Logger.WriteCallerLine(LOGSTRINGS.NVR_ERASE_BODY);

                // Erase the store body.
                BinaryTools.EraseByteArray(erasedStoreBodyBuffer);

                Logger.WriteCallerLine(LOGSTRINGS.NVR_WRITE_ERASED_BODY);

                // Write the erased store back to the nvram store buffer.
                BinaryTools.OverwriteBytesAtBase(storeBuffer, bodyStart, erasedStoreBodyBuffer);

                // Check the body was erased.
                erasedStoreBodyBuffer = BinaryTools.GetBytesBaseLength(storeBuffer, bodyStart, bodyEnd);

                if (!BinaryTools.IsByteBlockEmpty(erasedStoreBodyBuffer))
                {
                    Logger.WriteCallerLine(LOGSTRINGS.NVR_BODY_WRITE_FAIL);
                    return null;
                }

                Logger.WriteCallerLine(LOGSTRINGS.NVR_STORE_ERASE_SUCESS);

                return storeBuffer;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(EraseNvramStore), e.GetType(), e.Message);
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
            BinaryTools.OverwriteBytesAtBase(sourcebuffer, fsyssize - EFIROM.CRC32_SIZE, crcBuffer);

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
            Logger.WriteCallerLine(LOGSTRINGS.PATCH_START);

            Logger.WriteCallerLine(LOGSTRINGS.CREATING_BUFFERS);

            // Create a new byte array to hold the patched binary.
            byte[] patchedSource = new byte[sourcebuffer.Length];

            Array.Copy(sourcebuffer, patchedSource, sourcebuffer.Length);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_PATCH);

            // Patch the Fsys store crc.
            byte[] patchedBuffer = PatchFsysStoreCrc(fsysbuffer, newcrc, fsyssize);

            Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_TO_FW);

            // Overwrite the loaded Fsys crc32 with the newly calculated crc32.
            BinaryTools.OverwriteBytesAtBase(patchedSource, baseposition, patchedBuffer);

            // Load the Fsys store from the new binary.
            FsysStore fsys = efirom.ParseFsysStoreData(patchedSource, false);

            // Compare the new checksums.
            if (fsys.CrcString != fsys.CrcActualString)
            {
                Logger.WriteCallerLine(LOGSTRINGS.CRC_WRITE_FAIL);
                return null;
            }

            Logger.WriteCallerLine(LOGSTRINGS.PATCH_SUCCESS);

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
            BinaryTools.OverwriteBytesAtBase(sourcebuffer, lockposition, new byte[0x0F]);

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
                Filter = APPSTRINGS.FILTER_BIN,
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
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        private OpenFileDialog CreateImeOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = ApplicationPaths.IntelMeDirectory,
                Filter = APPSTRINGS.FILTER_BIN
            };
        }

        public string SaveOutputFirmware(byte[] binarybuffer, EFIROM efirom)
        {
            using (SaveFileDialog dialog = CreateFirmwareSaveFileDialog(efirom))
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteCallerLine(LOGSTRINGS.FILE_EXPORT_CANCELLED);
                    return string.Empty;
                }

                if (FileTools.WriteAllBytesEx(dialog.FileName, binarybuffer) && File.Exists(dialog.FileName))
                {
                    
                }
            }

            return string.Empty;
        }
        #endregion
    }
}