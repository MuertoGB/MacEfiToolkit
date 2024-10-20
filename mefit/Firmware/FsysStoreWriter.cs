using Mac_EFI_Toolkit.Firmware.EFI;
using Mac_EFI_Toolkit.Utils;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Firmware
{
    internal class FsysStoreWriter
    {
        private byte[] _bytesNewFsysStore;
        private byte[] _bytesNewBinary;
        private bool _maskCrc;
        private readonly ILogger _logger;

        public FsysStoreWriter(byte[] bytesNewFsysStore, byte[] bytesNewBinary, bool maskCrc, ILogger logger)
        {
            _bytesNewFsysStore = bytesNewFsysStore;
            _bytesNewBinary = bytesNewBinary;
            _maskCrc = maskCrc;
            _logger = logger;
        }

        public bool WriteNewFsysStore(RichTextBox rtbLog)
        {
            // Mask Fsys CRC
            if (_maskCrc)
            {
                _logger.WriteLog(rtbLog, "Masking Fsys store CRC", RtbLogPrefix.Info);

                // Load the new Fsys store
                FsysStore fsysNew = EFIROM.GetFsysStoreData(_bytesNewFsysStore, true);

                // Load the new Fsys store bytes and patch the crc
                _bytesNewFsysStore = BinaryUtils.PatchFsysCrc(fsysNew.FsysBytes, fsysNew.CRC32CalcInt);

                // Load the patched store
                fsysNew = EFIROM.GetFsysStoreData(_bytesNewFsysStore, true);

                // Check CRC32 masking was successful
                if (!string.Equals(fsysNew.CrcString, fsysNew.CrcCalcString))
                {
                    _logger.WriteLog(rtbLog, "CRC masking failed", RtbLogPrefix.Error);
                    return false;
                }

                _logger.WriteLog(rtbLog, "CRC masking successful", RtbLogPrefix.Info);
            }

            // Write new Fsys to the output file
            BinaryUtils.OverwriteBytesAtBase(_bytesNewBinary, EFIROM.FsysStoreData.FsysBase, _bytesNewFsysStore);

            // Load the Fsys from the new binary
            FsysStore fsysNewBinary = EFIROM.GetFsysStoreData(_bytesNewBinary, false);

            // Validate new Fsys was written
            if (!BinaryUtils.ByteArraysMatch(fsysNewBinary.FsysBytes, _bytesNewFsysStore))
            {
                _logger.WriteLog(rtbLog, "ByteArraysMatch: Fsys comparison check failed", RtbLogPrefix.Error);
                return false;
            }

            _logger.WriteLog(rtbLog, "Fsys comparison check passed", RtbLogPrefix.Info);
            _logger.WriteLog(rtbLog, "Data written successfully", RtbLogPrefix.Complete);

            return true;
        }
    }
}
