// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class editorWindow : Form
    {

        #region Private Members
        private byte[] _byteNewFsysRegion = null;
        private readonly string _strChevronRight = "\xE76C";

        private long _primaryVssOffset = -1;
        private int _primaryVssSize = -1;
        private long _backupVssOffset = -1;
        private int _backupVssSize = -1;

        private long _primarySvsOffset = -1;
        private int _primarySvsSize = -1;
        private long _backupSvsOffset = -1;
        private int _backupSvsSize = -1;

        private long _primaryNssOffset = -1;
        private int _primaryNssSize = -1;
        private long _backupNssOffset = -1;
        private int _backupNssSize = -1;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public editorWindow()
        {
            InitializeComponent();

            lblTitle.MouseMove += editorWindow_MouseMove;

            var font = Program.FONT_MDL2_REG_9;
            var chevronRight = _strChevronRight;

            SetLabelProperties(lblSvsChevRight, font, chevronRight);
            SetLabelProperties(lblVssChevRight, font, chevronRight);
            SetLabelProperties(lblNssChevRight, font, chevronRight);

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.closeChar;

            tbxSerialNumber.MaxLength = FWParser.strSerialNumber.Length;

            Logger.WriteLogTextToRtb($"{DateTime.Now}", RtbLogPrefix.MET, rtbLog);

            LogLoadedBinarySize();

            LogFsysData();

            ValidateNvramStoreData();
            LogNvramData();

            Logger.WriteLogTextToRtb($"Checks complete.", RtbLogPrefix.Good, rtbLog);
        }
        #endregion

        #region Window Events
        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils.GetDeviceConfigCodeAsync(strHwc);

            if (configCode == "N/A")
            {
                Logger.WriteLogTextToRtb($"Config: HWC could not be matched.", RtbLogPrefix.Error, rtbLog);
            }
            else
            {
                Logger.WriteLogTextToRtb($"Config: {configCode}", RtbLogPrefix.Info, rtbLog);
            }
        }
        #endregion

        #region Mouse Events
        private void editorWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region Button Events

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = Program.appDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceFsysRgn.Checked = false;
                    return;
                }

                Logger.WriteLogTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.MET, rtbLog);
                _byteNewFsysRegion = File.ReadAllBytes(dialog.FileName);
                bool isValid = ValidateNewFsysRegion(_byteNewFsysRegion);
                if (!isValid) cbxReplaceFsysRgn.Checked = false;
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            if (cbxReplaceFsysRgn.Checked)
            {
                Logger.WriteLogTextToRtb($"Replacing Fsys Data...", RtbLogPrefix.MET, rtbLog);
            }

            if (cbxReplaceSerial.Checked)
            {
                Logger.WriteLogTextToRtb($"Replacing serial number...", RtbLogPrefix.MET, rtbLog);
            }

            if (cbxClearVssStore.Checked)
            {
                Logger.WriteLogTextToRtb($"Clearing VSS store...", RtbLogPrefix.MET, rtbLog);
            }

            if (cbxClearSvsStore.Checked)
            {
                Logger.WriteLogTextToRtb($"Clearing VSS store...", RtbLogPrefix.MET, rtbLog);
            }

            if (cbxClearNssStore.Checked)
            {
                Logger.WriteLogTextToRtb($"Clearing VSS store...", RtbLogPrefix.MET, rtbLog);
            }

            ToggleControlEnable(true);
        }
        #endregion

        #region Checkbox Events

        private void cbxClearVssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupVssOffset != -1)
            {
                lblVssChevRight.Visible = cb.Checked;
                cbxClearVssBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupSvsOffset != -1)
            {
                lblSvsChevRight.Visible = cb.Checked;
                cbxClearSvsBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

            if (_backupNssOffset != -1)
            {
                lblNssChevRight.Visible = cb.Checked;
                cbxClearNssBackup.Enabled = cb.Checked;
            }

            if (!cb.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysRgn_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            cmdFsysPath.Enabled = isChecked;
            tlpFsysB.Enabled = isChecked;
            tlpSerialA.Enabled = !isChecked;

            if (isChecked)
            {
                cmdFsysPath.PerformClick();
            }
            else
            {
                cbxMaskCrc.Checked = false;
            }
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            tlpSerialB.Enabled = isChecked;
            tlpFsysA.Enabled = !isChecked;

            if (!isChecked)
            {
                tbxSerialNumber.Text = string.Empty;
                tbxHwc.Text = string.Empty;
            }
        }
        #endregion

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textLength = tb.Text.Length;

            if (textLength == FWParser.strSerialNumber.Length)
            {
                if (EFIUtils.GetIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.clrGood);
                    Logger.WriteLogTextToRtb("Valid serial characters entered.", RtbLogPrefix.Info, rtbLog);
                    if (FWParser.strSerialNumber.Length == 11)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 3));
                    }
                    if (FWParser.strSerialNumber.Length == 12)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 4));
                    }

                    string strHwc = tbxHwc.Text.ToUpper();
                    CheckHwcAsync(strHwc);

                }
                else
                {
                    UpdateTextBoxColor(tb, Colours.clrError);
                    Logger.WriteLogTextToRtb("Invalid serial characters entered.", RtbLogPrefix.Error, rtbLog);
                    UpdateHwcTextBoxText(string.Empty);
                }
            }
            else
            {
                UpdateTextBoxColor(tb, Color.White);
                UpdateHwcTextBoxText(string.Empty);
            }
        }
        #endregion

        #region Validation
        private bool ValidateNewFsysRegion(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb("Validating donor Fsys region...", RtbLogPrefix.MET, rtbLog);

            if (sourceBytes.Length != FWParser.FSYS_RGN_SIZE)
            {
                Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            long lSigPos = BinaryUtils.GetOffset(sourceBytes, FSSignatures.FSYS_SIG);
            if (lSigPos == -1 || lSigPos != 0)
            {
                Logger.WriteLogTextToRtb(lSigPos == -1 ? "Fsys signature not found." : $"Fsys signature misaligned at {lSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            //string strSerial = FWParser.GetSystemSerialNumber(sourceBytes);
            //int lenSerial = strSerial.Length;
            //string strHwc = lenSerial == 11 ? strSerial.Substring(strSerial.Length - 3).ToUpper() : lenSerial == 12 ? strSerial.Substring(strSerial.Length - 4).ToUpper() : string.Empty;

            //Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            //Logger.WriteLogTextToRtb($"Fsys sig found at {lSigPos:X2}h.", RtbLogPrefix.Info, rtbLog);
            //Logger.WriteLogTextToRtb($"Serial: {strSerial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            //Logger.WriteLogTextToRtb($"HWC: {strHwc}", RtbLogPrefix.Info, rtbLog);
            //CheckHwcAsync(strHwc);

            string strCrcInFile = FWParser.GetFsysCrc32(sourceBytes);
            string strCrcCalculated = EFIUtils.GetUintFsysCrc32(sourceBytes).ToString("X8");

            Logger.WriteLogTextToRtb($"CRC in Fsys: {strCrcInFile}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"CRC Calc:    {strCrcCalculated}h", RtbLogPrefix.Info, rtbLog);

            if (strCrcInFile == strCrcCalculated)
            {
                Logger.WriteLogTextToRtb("Fsys CRC32 is valid.", RtbLogPrefix.MET, rtbLog);
                cbxMaskCrc.Checked = false;
            }
            else
            {
                Logger.WriteLogTextToRtb("Fsys CRC32 is invalid, 'Mask CRC32' option selected.", RtbLogPrefix.Warn, rtbLog);
                cbxMaskCrc.Checked = true;
            }

            Logger.WriteLogTextToRtb("Validation complete.", RtbLogPrefix.MET, rtbLog);

            return true;
        }

        private void ValidateNvramStoreData()
        {
            NvramStoreData vssStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.VSS);
            if (vssStore.PrimaryStoreOffset != -1)
            {
                _primaryVssOffset = vssStore.PrimaryStoreOffset;
                _primaryVssSize = vssStore.PrimaryStoreSize;

            }
            else
            {
                cbxClearVssStore.Enabled = false;
            }

            if (vssStore.BackupStoreOffset != -1)
            {
                _backupVssOffset = vssStore.BackupStoreOffset;
                _backupVssSize = vssStore.BackupStoreSize;

            }
            else
            {
                cbxClearVssBackup.Enabled = false;
                lblVssChevRight.Visible = false;
            }

            NvramStoreData svsStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.SVS);
            if (svsStore.PrimaryStoreOffset != -1)
            {
                _primarySvsOffset = svsStore.PrimaryStoreOffset;
                _primarySvsSize = svsStore.PrimaryStoreSize;
            }
            else
            {
                cbxClearSvsStore.Enabled = false;
            }
            if (svsStore.BackupStoreOffset != -1)
            {
                _backupSvsOffset = svsStore.BackupStoreOffset;
                _backupSvsSize = svsStore.BackupStoreSize;
            }
            else
            {
                cbxClearSvsBackup.Enabled = false;
                lblSvsChevRight.Visible = false;
            }

            NvramStoreData nssStore = FWParser.GetNvramStoreData(FWParser.bytesLoadedFile, NvramStoreType.NSS);
            if (nssStore.PrimaryStoreOffset != -1)
            {
                _primaryNssOffset = nssStore.PrimaryStoreOffset;
                _primaryNssSize = nssStore.PrimaryStoreSize;
            }
            else
            {
                cbxClearNssStore.Enabled = false;
            }
            if (nssStore.BackupStoreOffset != -1)
            {
                _backupNssOffset = nssStore.BackupStoreOffset;
                _backupNssSize = nssStore.BackupStoreSize;
            }
            else
            {
                cbxClearNssBackup.Enabled = false;
                lblNssChevRight.Visible = false;
            }
        }
        #endregion

        #region Misc Events
        private void UpdateTextBoxColor(TextBox textBox, Color color)
        {
            textBox.ForeColor = color;
        }

        private void UpdateHwcTextBoxText(string text)
        {
            tbxHwc.Text = text;
        }

        private void SetLabelProperties(Label label, Font font, string text)
        {
            label.Font = font;
            label.Text = text;
            label.Visible = false;
        }

        private void ToggleControlEnable(bool enable)
        {
            cmdClose.Enabled = enable;
            cmdCloseForm.Enabled = enable;
            tlpOptions.Enabled = enable;
        }
        #endregion

        #region Logging
        private void LogFsysData()
        {
            if (FWParser.lFsysOffset != 0)
            {
                Logger.WriteLogTextToRtb("Get Fsys data...", RtbLogPrefix.MET, rtbLog);
                Logger.WriteLogTextToRtb($"Fsys Region:- Offset {FWParser.lFsysOffset:X2}h, Size {FWParser.FSYS_RGN_SIZE:X2}h", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void LogLoadedBinarySize()
        {
            if (!EFIUtils.GetIsValidBinSize((int)FWParser.lLoadedFileSize))
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWParser.lLoadedFileSize:X2}h is invalid. It should not be used as a donor.", RtbLogPrefix.Error, rtbLog);
            }
            else
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWParser.lLoadedFileSize:X2}h is valid.", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void LogNvramData()
        {
            Logger.WriteLogTextToRtb($"Get NVRAM store data...", RtbLogPrefix.MET, rtbLog);

            if (_primaryVssOffset != -1)
            {
                Logger.WriteLogTextToRtb($"VSS Store:-  Offset {_primaryVssOffset:X2}h, Size {_primaryVssSize:X2}h", RtbLogPrefix.Info, rtbLog);

                if (_backupVssOffset != -1)
                {
                    Logger.WriteLogTextToRtb($"VSS Backup:- Offset {_backupVssOffset:X2}h, Size {_backupVssSize:X2}h", RtbLogPrefix.Info, rtbLog);
                }
            }

            if (_primarySvsOffset != -1)
            {
                Logger.WriteLogTextToRtb($"SVS Store:-  Offset {_primarySvsOffset:X2}h, Size {_primarySvsSize:X2}h", RtbLogPrefix.Info, rtbLog);

                if (_backupSvsOffset != -1)
                {
                    Logger.WriteLogTextToRtb($"SVS Backup:- Offset {_backupSvsOffset:X2}h, Size {_backupSvsSize:X2}h", RtbLogPrefix.Info, rtbLog);
                }
            }

            if (_primaryNssOffset != -1)
            {
                Logger.WriteLogTextToRtb($"NSS Store:-  Offset {_primaryNssOffset:X2}h, Size {_primaryNssSize:X2}h", RtbLogPrefix.Info, rtbLog);

                if (_backupNssOffset != -1)
                {
                    Logger.WriteLogTextToRtb($"NSS Backup:- Offset {_backupNssOffset:X2}h, Size {_backupNssSize:X2}h", RtbLogPrefix.Info, rtbLog);
                }
            }    
        }
        #endregion

    }
}