using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.UI.Controls;

namespace Mac_EFI_Toolkit.Forms
{
    partial class frmEfiRom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cancellationToken != null)
                {
                    _cancellationToken.Dispose();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEfiRom));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.cmdOpenInExplorer = new System.Windows.Forms.Button();
            this.tlpFirmware = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.lblConfigCodeText = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblModelText = new System.Windows.Forms.Label();
            this.lblFileModifiedDate = new System.Windows.Forms.Label();
            this.lblFileModifiedDataText = new System.Windows.Forms.Label();
            this.lblFileCreatedDateText = new System.Windows.Forms.Label();
            this.lblFileCrc32 = new System.Windows.Forms.Label();
            this.lblSerialNumberText = new System.Windows.Forms.Label();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.lblFileCrc32Text = new System.Windows.Forms.Label();
            this.lblOrderNumberText = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblMeVersionText = new System.Windows.Forms.Label();
            this.lblEfiLockText = new System.Windows.Forms.Label();
            this.lblHwc = new System.Windows.Forms.Label();
            this.lblFsysStoreText = new System.Windows.Forms.Label();
            this.lblFilesizeText = new System.Windows.Forms.Label();
            this.lblFileCreatedDate = new System.Windows.Forms.Label();
            this.lblConfigCode = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblFilesize = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblEfiVersionText = new System.Windows.Forms.Label();
            this.lblVssText = new System.Windows.Forms.Label();
            this.lblSvs = new System.Windows.Forms.Label();
            this.lblSvsText = new System.Windows.Forms.Label();
            this.lblBoardIdText = new System.Windows.Forms.Label();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.lblDescriptorMode = new System.Windows.Forms.Label();
            this.lblApfsCapable = new System.Windows.Forms.Label();
            this.lblDescriptorModeText = new System.Windows.Forms.Label();
            this.lblApfsCapableText = new System.Windows.Forms.Label();
            this.lblFsysStore = new System.Windows.Forms.Label();
            this.lblVss = new System.Windows.Forms.Label();
            this.lblEfiLock = new System.Windows.Forms.Label();
            this.lblMeVersion = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.tlpSerialSwitch = new System.Windows.Forms.TableLayoutPanel();
            this.cbxCensor = new Mac_EFI_Toolkit.UI.METSwitch();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSplit1 = new System.Windows.Forms.Panel();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblStatusBarTip = new System.Windows.Forms.Label();
            this.lblParseTime = new System.Windows.Forms.Label();
            this.pnlSplit0 = new System.Windows.Forms.Panel();
            this.lblLzma = new System.Windows.Forms.Label();
            this.lblFmmEmail = new System.Windows.Forms.Label();
            this.pnlTopSplitMain = new System.Windows.Forms.Panel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdMenuOpen = new System.Windows.Forms.Button();
            this.cmdMenuFolders = new System.Windows.Forms.Button();
            this.cmdMenuCopy = new System.Windows.Forms.Button();
            this.cmdMenuExport = new System.Windows.Forms.Button();
            this.cmdMenuPatch = new System.Windows.Forms.Button();
            this.cmdMenuHelp = new System.Windows.Forms.Button();
            this.cmdMenuTools = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.lblTitle = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblPagefile = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.helloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopy = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.filenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crc32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsysCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hwcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efiVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fsysBaseAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSSBaseAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVSBaseAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdrBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biosBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTools = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.generateFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookupSerialNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRomInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileFromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.exportFsysStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIntelMERegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNVRAMVSSStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNVRAMSVSStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLZMADXEArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.backupFirmwareZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFirmwareInformationTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFmmmobilemeEmailTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPatch = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.changeSerialNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseNVRAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceFsysStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceIntelMERegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fixFsysChecksumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidateEFILockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolders = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.openBackupsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBuildsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFsysStoresFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIntelMEFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNVRAMFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLZMADXEFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsHelp = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.viewApplicationLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpFilename.SuspendLayout();
            this.tlpFirmware.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpSerialSwitch.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.tlpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpTitle.SuspendLayout();
            this.cmsCopy.SuspendLayout();
            this.cmsTools.SuspendLayout();
            this.cmsExport.SuspendLayout();
            this.cmsPatch.SuspendLayout();
            this.cmsFolders.SuspendLayout();
            this.cmsHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Controls.Add(this.pnlTopSplitMain);
            this.pnlMain.Controls.Add(this.tlpMenu);
            this.pnlMain.Controls.Add(this.pnlSeperator);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 51);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(761, 440);
            this.pnlMain.TabIndex = 2;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpFilename, 0, 0);
            this.tlpMain.Controls.Add(this.tlpFirmware, 0, 2);
            this.tlpMain.Controls.Add(this.tlpStatusBar, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 34);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.Size = new System.Drawing.Size(761, 406);
            this.tlpMain.TabIndex = 1;
            // 
            // tlpFilename
            // 
            this.tlpFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpFilename.ColumnCount = 3;
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFilename.Controls.Add(this.lblFilename, 0, 0);
            this.tlpFilename.Controls.Add(this.cmdOpenInExplorer, 2, 0);
            this.tlpFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilename.Enabled = false;
            this.tlpFilename.Location = new System.Drawing.Point(0, 0);
            this.tlpFilename.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFilename.Name = "tlpFilename";
            this.tlpFilename.RowCount = 1;
            this.tlpFilename.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.Size = new System.Drawing.Size(761, 36);
            this.tlpFilename.TabIndex = 1;
            // 
            // lblFilename
            // 
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFilename.Location = new System.Drawing.Point(0, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(724, 36);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdOpenInExplorer
            // 
            this.cmdOpenInExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOpenInExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpenInExplorer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.cmdOpenInExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOpenInExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOpenInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenInExplorer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenInExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cmdOpenInExplorer.Location = new System.Drawing.Point(725, 0);
            this.cmdOpenInExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenInExplorer.Name = "cmdOpenInExplorer";
            this.cmdOpenInExplorer.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdOpenInExplorer.Size = new System.Drawing.Size(36, 36);
            this.cmdOpenInExplorer.TabIndex = 7;
            this.cmdOpenInExplorer.Text = "N";
            this.cmdOpenInExplorer.UseVisualStyleBackColor = false;
            this.cmdOpenInExplorer.Click += new System.EventHandler(this.cmdOpenInExplorer_Click);
            // 
            // tlpFirmware
            // 
            this.tlpFirmware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpFirmware.ColumnCount = 7;
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFirmware.Controls.Add(this.lblEfiVersion, 2, 10);
            this.tlpFirmware.Controls.Add(this.lblConfigCodeText, 4, 4);
            this.tlpFirmware.Controls.Add(this.lblModel, 2, 4);
            this.tlpFirmware.Controls.Add(this.lblModelText, 0, 4);
            this.tlpFirmware.Controls.Add(this.lblFileModifiedDate, 6, 2);
            this.tlpFirmware.Controls.Add(this.lblFileModifiedDataText, 4, 2);
            this.tlpFirmware.Controls.Add(this.lblFileCreatedDateText, 0, 2);
            this.tlpFirmware.Controls.Add(this.lblFileCrc32, 6, 0);
            this.tlpFirmware.Controls.Add(this.lblSerialNumberText, 4, 6);
            this.tlpFirmware.Controls.Add(this.lblHwcText, 0, 8);
            this.tlpFirmware.Controls.Add(this.lblFileCrc32Text, 4, 0);
            this.tlpFirmware.Controls.Add(this.lblOrderNumberText, 4, 8);
            this.tlpFirmware.Controls.Add(this.lblOrderNumber, 6, 8);
            this.tlpFirmware.Controls.Add(this.lblMeVersionText, 4, 16);
            this.tlpFirmware.Controls.Add(this.lblEfiLockText, 0, 14);
            this.tlpFirmware.Controls.Add(this.lblHwc, 2, 8);
            this.tlpFirmware.Controls.Add(this.lblFsysStoreText, 0, 6);
            this.tlpFirmware.Controls.Add(this.lblFilesizeText, 0, 0);
            this.tlpFirmware.Controls.Add(this.lblFileCreatedDate, 2, 2);
            this.tlpFirmware.Controls.Add(this.lblConfigCode, 6, 4);
            this.tlpFirmware.Controls.Add(this.lblFilesize, 2, 0);
            this.tlpFirmware.Controls.Add(this.lblEfiVersionText, 0, 10);
            this.tlpFirmware.Controls.Add(this.lblVssText, 0, 12);
            this.tlpFirmware.Controls.Add(this.lblSvs, 6, 12);
            this.tlpFirmware.Controls.Add(this.lblSvsText, 4, 12);
            this.tlpFirmware.Controls.Add(this.lblBoardIdText, 4, 10);
            this.tlpFirmware.Controls.Add(this.lblBoardId, 6, 10);
            this.tlpFirmware.Controls.Add(this.lblDescriptorMode, 2, 16);
            this.tlpFirmware.Controls.Add(this.lblApfsCapable, 6, 14);
            this.tlpFirmware.Controls.Add(this.lblDescriptorModeText, 0, 16);
            this.tlpFirmware.Controls.Add(this.lblApfsCapableText, 4, 14);
            this.tlpFirmware.Controls.Add(this.lblFsysStore, 2, 6);
            this.tlpFirmware.Controls.Add(this.lblVss, 2, 12);
            this.tlpFirmware.Controls.Add(this.lblEfiLock, 2, 14);
            this.tlpFirmware.Controls.Add(this.lblMeVersion, 6, 16);
            this.tlpFirmware.Controls.Add(this.tlpSerial, 6, 6);
            this.tlpFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFirmware.Enabled = false;
            this.tlpFirmware.Location = new System.Drawing.Point(0, 37);
            this.tlpFirmware.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFirmware.Name = "tlpFirmware";
            this.tlpFirmware.RowCount = 17;
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpFirmware.Size = new System.Drawing.Size(761, 332);
            this.tlpFirmware.TabIndex = 2;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiVersion.Location = new System.Drawing.Point(131, 185);
            this.lblEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersion.Name = "lblEfiVersion";
            this.lblEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiVersion.Size = new System.Drawing.Size(249, 36);
            this.lblEfiVersion.TabIndex = 0;
            this.lblEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfiVersion.UseMnemonic = false;
            // 
            // lblConfigCodeText
            // 
            this.lblConfigCodeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblConfigCodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCodeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCodeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblConfigCodeText.Location = new System.Drawing.Point(381, 74);
            this.lblConfigCodeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCodeText.Name = "lblConfigCodeText";
            this.lblConfigCodeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblConfigCodeText.Size = new System.Drawing.Size(130, 36);
            this.lblConfigCodeText.TabIndex = 0;
            this.lblConfigCodeText.Text = "CONFIG";
            this.lblConfigCodeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModel
            // 
            this.lblModel.AutoEllipsis = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblModel.Location = new System.Drawing.Point(131, 74);
            this.lblModel.Margin = new System.Windows.Forms.Padding(0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModel.Size = new System.Drawing.Size(249, 36);
            this.lblModel.TabIndex = 0;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelText
            // 
            this.lblModelText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblModelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModelText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModelText.Location = new System.Drawing.Point(0, 74);
            this.lblModelText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModelText.Size = new System.Drawing.Size(130, 36);
            this.lblModelText.TabIndex = 0;
            this.lblModelText.Text = "MODEL";
            this.lblModelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileModifiedDate
            // 
            this.lblFileModifiedDate.AutoEllipsis = true;
            this.lblFileModifiedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblFileModifiedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileModifiedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileModifiedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileModifiedDate.Location = new System.Drawing.Point(512, 37);
            this.lblFileModifiedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileModifiedDate.Name = "lblFileModifiedDate";
            this.lblFileModifiedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileModifiedDate.Size = new System.Drawing.Size(249, 36);
            this.lblFileModifiedDate.TabIndex = 0;
            this.lblFileModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileModifiedDate.UseMnemonic = false;
            // 
            // lblFileModifiedDataText
            // 
            this.lblFileModifiedDataText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFileModifiedDataText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileModifiedDataText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileModifiedDataText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileModifiedDataText.Location = new System.Drawing.Point(381, 37);
            this.lblFileModifiedDataText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileModifiedDataText.Name = "lblFileModifiedDataText";
            this.lblFileModifiedDataText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileModifiedDataText.Size = new System.Drawing.Size(130, 36);
            this.lblFileModifiedDataText.TabIndex = 0;
            this.lblFileModifiedDataText.Text = "MODIFIED";
            this.lblFileModifiedDataText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCreatedDateText
            // 
            this.lblFileCreatedDateText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFileCreatedDateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCreatedDateText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCreatedDateText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileCreatedDateText.Location = new System.Drawing.Point(0, 37);
            this.lblFileCreatedDateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCreatedDateText.Name = "lblFileCreatedDateText";
            this.lblFileCreatedDateText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileCreatedDateText.Size = new System.Drawing.Size(130, 36);
            this.lblFileCreatedDateText.TabIndex = 0;
            this.lblFileCreatedDateText.Text = "CREATED";
            this.lblFileCreatedDateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCrc32
            // 
            this.lblFileCrc32.AutoEllipsis = true;
            this.lblFileCrc32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblFileCrc32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCrc32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCrc32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileCrc32.Location = new System.Drawing.Point(512, 0);
            this.lblFileCrc32.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCrc32.Name = "lblFileCrc32";
            this.lblFileCrc32.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCrc32.Size = new System.Drawing.Size(249, 36);
            this.lblFileCrc32.TabIndex = 0;
            this.lblFileCrc32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileCrc32.UseMnemonic = false;
            // 
            // lblSerialNumberText
            // 
            this.lblSerialNumberText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSerialNumberText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumberText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumberText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialNumberText.Location = new System.Drawing.Point(381, 111);
            this.lblSerialNumberText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumberText.Name = "lblSerialNumberText";
            this.lblSerialNumberText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialNumberText.Size = new System.Drawing.Size(130, 36);
            this.lblSerialNumberText.TabIndex = 0;
            this.lblSerialNumberText.Text = "SERIAL";
            this.lblSerialNumberText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwcText
            // 
            this.lblHwcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblHwcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(0, 148);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblHwcText.Size = new System.Drawing.Size(130, 36);
            this.lblHwcText.TabIndex = 0;
            this.lblHwcText.Text = "HWC";
            this.lblHwcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCrc32Text
            // 
            this.lblFileCrc32Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFileCrc32Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCrc32Text.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCrc32Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileCrc32Text.Location = new System.Drawing.Point(381, 0);
            this.lblFileCrc32Text.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCrc32Text.Name = "lblFileCrc32Text";
            this.lblFileCrc32Text.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileCrc32Text.Size = new System.Drawing.Size(130, 36);
            this.lblFileCrc32Text.TabIndex = 0;
            this.lblFileCrc32Text.Text = "CRC32";
            this.lblFileCrc32Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNumberText
            // 
            this.lblOrderNumberText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblOrderNumberText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNumberText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumberText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOrderNumberText.Location = new System.Drawing.Point(381, 148);
            this.lblOrderNumberText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNumberText.Name = "lblOrderNumberText";
            this.lblOrderNumberText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOrderNumberText.Size = new System.Drawing.Size(130, 36);
            this.lblOrderNumberText.TabIndex = 0;
            this.lblOrderNumberText.Text = "ORDER NO";
            this.lblOrderNumberText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoEllipsis = true;
            this.lblOrderNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblOrderNumber.Location = new System.Drawing.Point(512, 148);
            this.lblOrderNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOrderNumber.Size = new System.Drawing.Size(249, 36);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOrderNumber.UseMnemonic = false;
            // 
            // lblMeVersionText
            // 
            this.lblMeVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblMeVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersionText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblMeVersionText.Location = new System.Drawing.Point(381, 296);
            this.lblMeVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersionText.Name = "lblMeVersionText";
            this.lblMeVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblMeVersionText.Size = new System.Drawing.Size(130, 36);
            this.lblMeVersionText.TabIndex = 0;
            this.lblMeVersionText.Text = "INTEL ME";
            this.lblMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiLockText
            // 
            this.lblEfiLockText.AutoEllipsis = true;
            this.lblEfiLockText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblEfiLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLockText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLockText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiLockText.Location = new System.Drawing.Point(0, 259);
            this.lblEfiLockText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLockText.Name = "lblEfiLockText";
            this.lblEfiLockText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiLockText.Size = new System.Drawing.Size(130, 36);
            this.lblEfiLockText.TabIndex = 0;
            this.lblEfiLockText.Text = "EFI LOCK";
            this.lblEfiLockText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwc
            // 
            this.lblHwc.AutoEllipsis = true;
            this.lblHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblHwc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblHwc.Location = new System.Drawing.Point(131, 148);
            this.lblHwc.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwc.Name = "lblHwc";
            this.lblHwc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblHwc.Size = new System.Drawing.Size(249, 36);
            this.lblHwc.TabIndex = 0;
            this.lblHwc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHwc.UseMnemonic = false;
            // 
            // lblFsysStoreText
            // 
            this.lblFsysStoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFsysStoreText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysStoreText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysStoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysStoreText.Location = new System.Drawing.Point(0, 111);
            this.lblFsysStoreText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysStoreText.Name = "lblFsysStoreText";
            this.lblFsysStoreText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysStoreText.Size = new System.Drawing.Size(130, 36);
            this.lblFsysStoreText.TabIndex = 0;
            this.lblFsysStoreText.Text = "FSYS STORE";
            this.lblFsysStoreText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesizeText
            // 
            this.lblFilesizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilesizeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilesizeText.Location = new System.Drawing.Point(0, 0);
            this.lblFilesizeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeText.Name = "lblFilesizeText";
            this.lblFilesizeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilesizeText.Size = new System.Drawing.Size(130, 36);
            this.lblFilesizeText.TabIndex = 0;
            this.lblFilesizeText.Text = "SIZE";
            this.lblFilesizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCreatedDate
            // 
            this.lblFileCreatedDate.AutoEllipsis = true;
            this.lblFileCreatedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblFileCreatedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileCreatedDate.Location = new System.Drawing.Point(131, 37);
            this.lblFileCreatedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCreatedDate.Name = "lblFileCreatedDate";
            this.lblFileCreatedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCreatedDate.Size = new System.Drawing.Size(249, 36);
            this.lblFileCreatedDate.TabIndex = 0;
            this.lblFileCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigCode
            // 
            this.lblConfigCode.AutoEllipsis = true;
            this.lblConfigCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblConfigCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblConfigCode.Location = new System.Drawing.Point(512, 74);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(249, 36);
            this.lblConfigCode.TabIndex = 0;
            this.lblConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoEllipsis = true;
            this.lblFilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblFilesize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFilesize.Location = new System.Drawing.Point(131, 0);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(249, 36);
            this.lblFilesize.TabIndex = 0;
            this.lblFilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFilesize.UseMnemonic = false;
            // 
            // lblEfiVersionText
            // 
            this.lblEfiVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblEfiVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersionText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiVersionText.Location = new System.Drawing.Point(0, 185);
            this.lblEfiVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersionText.Name = "lblEfiVersionText";
            this.lblEfiVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiVersionText.Size = new System.Drawing.Size(130, 36);
            this.lblEfiVersionText.TabIndex = 0;
            this.lblEfiVersionText.Text = "EFI VERSION";
            this.lblEfiVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVssText
            // 
            this.lblVssText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblVssText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVssText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblVssText.Location = new System.Drawing.Point(0, 222);
            this.lblVssText.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssText.Name = "lblVssText";
            this.lblVssText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblVssText.Size = new System.Drawing.Size(130, 36);
            this.lblVssText.TabIndex = 0;
            this.lblVssText.Text = "VSS NVRAM";
            this.lblVssText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSvs
            // 
            this.lblSvs.AutoEllipsis = true;
            this.lblSvs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblSvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblSvs.Location = new System.Drawing.Point(512, 222);
            this.lblSvs.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvs.Name = "lblSvs";
            this.lblSvs.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSvs.Size = new System.Drawing.Size(249, 36);
            this.lblSvs.TabIndex = 0;
            this.lblSvs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSvs.UseMnemonic = false;
            // 
            // lblSvsText
            // 
            this.lblSvsText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSvsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvsText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSvsText.Location = new System.Drawing.Point(381, 222);
            this.lblSvsText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsText.Name = "lblSvsText";
            this.lblSvsText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSvsText.Size = new System.Drawing.Size(130, 36);
            this.lblSvsText.TabIndex = 8;
            this.lblSvsText.Text = "SVS NVRAM";
            this.lblSvsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoardIdText
            // 
            this.lblBoardIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBoardIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardIdText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBoardIdText.Location = new System.Drawing.Point(381, 185);
            this.lblBoardIdText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardIdText.Name = "lblBoardIdText";
            this.lblBoardIdText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBoardIdText.Size = new System.Drawing.Size(130, 36);
            this.lblBoardIdText.TabIndex = 0;
            this.lblBoardIdText.Text = "BOARD ID";
            this.lblBoardIdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoEllipsis = true;
            this.lblBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBoardId.Location = new System.Drawing.Point(512, 185);
            this.lblBoardId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBoardId.Size = new System.Drawing.Size(249, 36);
            this.lblBoardId.TabIndex = 0;
            this.lblBoardId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBoardId.UseMnemonic = false;
            // 
            // lblDescriptorMode
            // 
            this.lblDescriptorMode.AutoEllipsis = true;
            this.lblDescriptorMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblDescriptorMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescriptorMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptorMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDescriptorMode.Location = new System.Drawing.Point(131, 296);
            this.lblDescriptorMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescriptorMode.Name = "lblDescriptorMode";
            this.lblDescriptorMode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblDescriptorMode.Size = new System.Drawing.Size(249, 36);
            this.lblDescriptorMode.TabIndex = 7;
            this.lblDescriptorMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescriptorMode.UseMnemonic = false;
            // 
            // lblApfsCapable
            // 
            this.lblApfsCapable.AutoEllipsis = true;
            this.lblApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblApfsCapable.Location = new System.Drawing.Point(512, 259);
            this.lblApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapable.Name = "lblApfsCapable";
            this.lblApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblApfsCapable.Size = new System.Drawing.Size(249, 36);
            this.lblApfsCapable.TabIndex = 0;
            this.lblApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApfsCapable.UseMnemonic = false;
            // 
            // lblDescriptorModeText
            // 
            this.lblDescriptorModeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblDescriptorModeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescriptorModeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptorModeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblDescriptorModeText.Location = new System.Drawing.Point(0, 296);
            this.lblDescriptorModeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescriptorModeText.Name = "lblDescriptorModeText";
            this.lblDescriptorModeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDescriptorModeText.Size = new System.Drawing.Size(130, 36);
            this.lblDescriptorModeText.TabIndex = 6;
            this.lblDescriptorModeText.Text = "DESCRIPTOR";
            this.lblDescriptorModeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapableText
            // 
            this.lblApfsCapableText.AutoEllipsis = true;
            this.lblApfsCapableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblApfsCapableText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapableText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapableText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApfsCapableText.Location = new System.Drawing.Point(381, 259);
            this.lblApfsCapableText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapableText.Name = "lblApfsCapableText";
            this.lblApfsCapableText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApfsCapableText.Size = new System.Drawing.Size(130, 36);
            this.lblApfsCapableText.TabIndex = 0;
            this.lblApfsCapableText.Text = "APFS";
            this.lblApfsCapableText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFsysStore
            // 
            this.lblFsysStore.AutoEllipsis = true;
            this.lblFsysStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblFsysStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFsysStore.Location = new System.Drawing.Point(131, 111);
            this.lblFsysStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysStore.Name = "lblFsysStore";
            this.lblFsysStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFsysStore.Size = new System.Drawing.Size(249, 36);
            this.lblFsysStore.TabIndex = 0;
            this.lblFsysStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFsysStore.UseMnemonic = false;
            // 
            // lblVss
            // 
            this.lblVss.AutoEllipsis = true;
            this.lblVss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblVss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVss.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblVss.Location = new System.Drawing.Point(131, 222);
            this.lblVss.Margin = new System.Windows.Forms.Padding(0);
            this.lblVss.Name = "lblVss";
            this.lblVss.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblVss.Size = new System.Drawing.Size(249, 36);
            this.lblVss.TabIndex = 0;
            this.lblVss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVss.UseMnemonic = false;
            // 
            // lblEfiLock
            // 
            this.lblEfiLock.AutoEllipsis = true;
            this.lblEfiLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiLock.Location = new System.Drawing.Point(131, 259);
            this.lblEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLock.Name = "lblEfiLock";
            this.lblEfiLock.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiLock.Size = new System.Drawing.Size(249, 36);
            this.lblEfiLock.TabIndex = 9;
            this.lblEfiLock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfiLock.UseMnemonic = false;
            // 
            // lblMeVersion
            // 
            this.lblMeVersion.AutoEllipsis = true;
            this.lblMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblMeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblMeVersion.Location = new System.Drawing.Point(512, 296);
            this.lblMeVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersion.Name = "lblMeVersion";
            this.lblMeVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMeVersion.Size = new System.Drawing.Size(249, 36);
            this.lblMeVersion.TabIndex = 11;
            this.lblMeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeVersion.UseMnemonic = false;
            // 
            // tlpSerial
            // 
            this.tlpSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpSerial.ColumnCount = 3;
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpSerial.Controls.Add(this.lblSerialNumber, 0, 0);
            this.tlpSerial.Controls.Add(this.tlpSerialSwitch, 2, 0);
            this.tlpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerial.Location = new System.Drawing.Point(512, 111);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(249, 36);
            this.tlpSerial.TabIndex = 2;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoEllipsis = true;
            this.lblSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblSerialNumber.Location = new System.Drawing.Point(0, 0);
            this.lblSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerialNumber.Size = new System.Drawing.Size(212, 36);
            this.lblSerialNumber.TabIndex = 1;
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerialNumber.UseMnemonic = false;
            // 
            // tlpSerialSwitch
            // 
            this.tlpSerialSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(50)))));
            this.tlpSerialSwitch.ColumnCount = 1;
            this.tlpSerialSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSerialSwitch.Controls.Add(this.cbxCensor, 0, 0);
            this.tlpSerialSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialSwitch.Location = new System.Drawing.Point(213, 0);
            this.tlpSerialSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialSwitch.Name = "tlpSerialSwitch";
            this.tlpSerialSwitch.RowCount = 1;
            this.tlpSerialSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSerialSwitch.Size = new System.Drawing.Size(36, 36);
            this.tlpSerialSwitch.TabIndex = 2;
            // 
            // cbxCensor
            // 
            this.cbxCensor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxCensor.BackColor = System.Drawing.Color.Black;
            this.cbxCensor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cbxCensor.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxCensor.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.cbxCensor.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxCensor.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbxCensor.Enabled = false;
            this.cbxCensor.Location = new System.Drawing.Point(5, 10);
            this.cbxCensor.Margin = new System.Windows.Forms.Padding(0);
            this.cbxCensor.Name = "cbxCensor";
            this.cbxCensor.Size = new System.Drawing.Size(26, 16);
            this.cbxCensor.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.cbxCensor.TabIndex = 8;
            this.cbxCensor.CheckedChanged += new System.EventHandler(this.cbxCensor_CheckedChanged);
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBar.ColumnCount = 7;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.Controls.Add(this.pnlSplit1, 4, 0);
            this.tlpStatusBar.Controls.Add(this.tlpStatusBarImage, 6, 0);
            this.tlpStatusBar.Controls.Add(this.lblStatusBarTip, 5, 0);
            this.tlpStatusBar.Controls.Add(this.lblParseTime, 0, 0);
            this.tlpStatusBar.Controls.Add(this.pnlSplit0, 1, 0);
            this.tlpStatusBar.Controls.Add(this.lblLzma, 2, 0);
            this.tlpStatusBar.Controls.Add(this.lblFmmEmail, 3, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 370);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(761, 36);
            this.tlpStatusBar.TabIndex = 0;
            // 
            // pnlSplit1
            // 
            this.pnlSplit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSplit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlSplit1.Location = new System.Drawing.Point(130, 7);
            this.pnlSplit1.Name = "pnlSplit1";
            this.pnlSplit1.Size = new System.Drawing.Size(1, 22);
            this.pnlSplit1.TabIndex = 0;
            // 
            // tlpStatusBarImage
            // 
            this.tlpStatusBarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBarImage.ColumnCount = 1;
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBarImage.Controls.Add(this.pbxLoad, 0, 0);
            this.tlpStatusBarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBarImage.Location = new System.Drawing.Point(725, 0);
            this.tlpStatusBarImage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBarImage.Name = "tlpStatusBarImage";
            this.tlpStatusBarImage.RowCount = 1;
            this.tlpStatusBarImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.Size = new System.Drawing.Size(36, 36);
            this.tlpStatusBarImage.TabIndex = 99;
            // 
            // pbxLoad
            // 
            this.pbxLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLoad.BackColor = System.Drawing.Color.Transparent;
            this.pbxLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxLoad.Location = new System.Drawing.Point(6, 6);
            this.pbxLoad.Margin = new System.Windows.Forms.Padding(0);
            this.pbxLoad.Name = "pbxLoad";
            this.pbxLoad.Size = new System.Drawing.Size(24, 24);
            this.pbxLoad.TabIndex = 100;
            this.pbxLoad.TabStop = false;
            // 
            // lblStatusBarTip
            // 
            this.lblStatusBarTip.AutoSize = true;
            this.lblStatusBarTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblStatusBarTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusBarTip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBarTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblStatusBarTip.Location = new System.Drawing.Point(133, 1);
            this.lblStatusBarTip.Margin = new System.Windows.Forms.Padding(1);
            this.lblStatusBarTip.Name = "lblStatusBarTip";
            this.lblStatusBarTip.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatusBarTip.Size = new System.Drawing.Size(591, 34);
            this.lblStatusBarTip.TabIndex = 0;
            this.lblStatusBarTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParseTime
            // 
            this.lblParseTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParseTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblParseTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParseTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblParseTime.Location = new System.Drawing.Point(10, 7);
            this.lblParseTime.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblParseTime.Name = "lblParseTime";
            this.lblParseTime.Size = new System.Drawing.Size(56, 22);
            this.lblParseTime.TabIndex = 0;
            this.lblParseTime.Text = "0.00s";
            this.lblParseTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSplit0
            // 
            this.pnlSplit0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSplit0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlSplit0.Location = new System.Drawing.Point(73, 7);
            this.pnlSplit0.Name = "pnlSplit0";
            this.pnlSplit0.Size = new System.Drawing.Size(1, 22);
            this.pnlSplit0.TabIndex = 0;
            // 
            // lblLzma
            // 
            this.lblLzma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLzma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLzma.Location = new System.Drawing.Point(78, 0);
            this.lblLzma.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblLzma.Name = "lblLzma";
            this.lblLzma.Size = new System.Drawing.Size(23, 36);
            this.lblLzma.TabIndex = 0;
            this.lblLzma.Text = "...";
            this.lblLzma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFmmEmail
            // 
            this.lblFmmEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFmmEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblFmmEmail.Location = new System.Drawing.Point(104, 0);
            this.lblFmmEmail.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblFmmEmail.Name = "lblFmmEmail";
            this.lblFmmEmail.Size = new System.Drawing.Size(23, 36);
            this.lblFmmEmail.TabIndex = 0;
            this.lblFmmEmail.Text = "...";
            this.lblFmmEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFmmEmail.Click += new System.EventHandler(this.lblFmmEmail_Click);
            // 
            // pnlTopSplitMain
            // 
            this.pnlTopSplitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlTopSplitMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSplitMain.Location = new System.Drawing.Point(0, 33);
            this.pnlTopSplitMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTopSplitMain.Name = "pnlTopSplitMain";
            this.pnlTopSplitMain.Size = new System.Drawing.Size(761, 1);
            this.pnlTopSplitMain.TabIndex = 0;
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpMenu.ColumnCount = 13;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.Controls.Add(this.cmdMenuOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuFolders, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuCopy, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuExport, 6, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuPatch, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuHelp, 12, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuTools, 10, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(0, 1);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(761, 32);
            this.tlpMenu.TabIndex = 0;
            // 
            // cmdMenuOpen
            // 
            this.cmdMenuOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuOpen.FlatAppearance.BorderSize = 0;
            this.cmdMenuOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuOpen.Location = new System.Drawing.Point(0, 0);
            this.cmdMenuOpen.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuOpen.Name = "cmdMenuOpen";
            this.cmdMenuOpen.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuOpen.TabIndex = 0;
            this.cmdMenuOpen.Text = "OPEN";
            this.cmdMenuOpen.UseVisualStyleBackColor = false;
            this.cmdMenuOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdMenuFolders
            // 
            this.cmdMenuFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuFolders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuFolders.FlatAppearance.BorderSize = 0;
            this.cmdMenuFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuFolders.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuFolders.Location = new System.Drawing.Point(108, 0);
            this.cmdMenuFolders.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuFolders.Name = "cmdMenuFolders";
            this.cmdMenuFolders.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdMenuFolders.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuFolders.TabIndex = 1;
            this.cmdMenuFolders.Text = "FOLDERS";
            this.cmdMenuFolders.UseVisualStyleBackColor = false;
            this.cmdMenuFolders.Click += new System.EventHandler(this.cmdMenuFolders_Click);
            // 
            // cmdMenuCopy
            // 
            this.cmdMenuCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuCopy.Enabled = false;
            this.cmdMenuCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuCopy.FlatAppearance.BorderSize = 0;
            this.cmdMenuCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuCopy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuCopy.Location = new System.Drawing.Point(216, 0);
            this.cmdMenuCopy.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuCopy.Name = "cmdMenuCopy";
            this.cmdMenuCopy.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuCopy.TabIndex = 2;
            this.cmdMenuCopy.Text = "COPY";
            this.cmdMenuCopy.UseVisualStyleBackColor = false;
            this.cmdMenuCopy.Click += new System.EventHandler(this.cmdCopyMenu_Click);
            // 
            // cmdMenuExport
            // 
            this.cmdMenuExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuExport.Enabled = false;
            this.cmdMenuExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuExport.FlatAppearance.BorderSize = 0;
            this.cmdMenuExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuExport.Location = new System.Drawing.Point(324, 0);
            this.cmdMenuExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuExport.Name = "cmdMenuExport";
            this.cmdMenuExport.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuExport.TabIndex = 3;
            this.cmdMenuExport.Text = "EXPORT";
            this.cmdMenuExport.UseVisualStyleBackColor = false;
            this.cmdMenuExport.Click += new System.EventHandler(this.cmdMenuExport_Click);
            // 
            // cmdMenuPatch
            // 
            this.cmdMenuPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuPatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuPatch.Enabled = false;
            this.cmdMenuPatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuPatch.FlatAppearance.BorderSize = 0;
            this.cmdMenuPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuPatch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuPatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuPatch.Location = new System.Drawing.Point(432, 0);
            this.cmdMenuPatch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuPatch.Name = "cmdMenuPatch";
            this.cmdMenuPatch.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuPatch.TabIndex = 4;
            this.cmdMenuPatch.Text = "PATCH";
            this.cmdMenuPatch.UseVisualStyleBackColor = false;
            this.cmdMenuPatch.Click += new System.EventHandler(this.cmdMenuPatch_Click);
            // 
            // cmdMenuHelp
            // 
            this.cmdMenuHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuHelp.FlatAppearance.BorderSize = 0;
            this.cmdMenuHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuHelp.Location = new System.Drawing.Point(648, 0);
            this.cmdMenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuHelp.Name = "cmdMenuHelp";
            this.cmdMenuHelp.Size = new System.Drawing.Size(113, 32);
            this.cmdMenuHelp.TabIndex = 6;
            this.cmdMenuHelp.Text = "HELP";
            this.cmdMenuHelp.UseVisualStyleBackColor = false;
            this.cmdMenuHelp.Click += new System.EventHandler(this.cmdMenuHelp_Click);
            // 
            // cmdMenuTools
            // 
            this.cmdMenuTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuTools.Enabled = false;
            this.cmdMenuTools.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuTools.FlatAppearance.BorderSize = 0;
            this.cmdMenuTools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuTools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuTools.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuTools.Location = new System.Drawing.Point(540, 0);
            this.cmdMenuTools.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuTools.Name = "cmdMenuTools";
            this.cmdMenuTools.Size = new System.Drawing.Size(107, 32);
            this.cmdMenuTools.TabIndex = 5;
            this.cmdMenuTools.Text = "TOOLS";
            this.cmdMenuTools.UseVisualStyleBackColor = false;
            this.cmdMenuTools.Click += new System.EventHandler(this.cmdMenuTools_Click);
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(0, 0);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(761, 1);
            this.pnlSeperator.TabIndex = 94;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(44, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(517, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EFIROM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.icon32;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(10, 10);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(30, 30);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 1;
            this.pbxLogo.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Controls.Add(this.lblPagefile, 2, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 4, 0);
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdMinimize, 3, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(761, 50);
            this.tlpTitle.TabIndex = 0;
            // 
            // lblPagefile
            // 
            this.lblPagefile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPagefile.AutoSize = true;
            this.lblPagefile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPagefile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagefile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagefile.ForeColor = System.Drawing.Color.White;
            this.lblPagefile.Location = new System.Drawing.Point(632, 14);
            this.lblPagefile.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblPagefile.Name = "lblPagefile";
            this.lblPagefile.Size = new System.Drawing.Size(23, 22);
            this.lblPagefile.TabIndex = 2;
            this.lblPagefile.Text = "...";
            this.lblPagefile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPagefile.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(711, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "C";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdMinimize
            // 
            this.cmdMinimize.BackColor = System.Drawing.Color.Transparent;
            this.cmdMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMinimize.FlatAppearance.BorderSize = 0;
            this.cmdMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMinimize.ForeColor = System.Drawing.Color.White;
            this.cmdMinimize.Location = new System.Drawing.Point(661, 0);
            this.cmdMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMinimize.Name = "cmdMinimize";
            this.cmdMinimize.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMinimize.Size = new System.Drawing.Size(50, 50);
            this.cmdMinimize.TabIndex = 0;
            this.cmdMinimize.TabStop = false;
            this.cmdMinimize.Text = "—";
            this.cmdMinimize.UseVisualStyleBackColor = false;
            this.cmdMinimize.Click += new System.EventHandler(this.cmdMinimize_Click);
            // 
            // helloToolStripMenuItem
            // 
            this.helloToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helloToolStripMenuItem.Name = "helloToolStripMenuItem";
            this.helloToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.helloToolStripMenuItem.Text = "OPEN";
            // 
            // rESETToolStripMenuItem
            // 
            this.rESETToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helloToolStripMenuItem1,
            this.testringToolStripMenuItem});
            this.rESETToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rESETToolStripMenuItem.Name = "rESETToolStripMenuItem";
            this.rESETToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.rESETToolStripMenuItem.Text = "RESET";
            // 
            // helloToolStripMenuItem1
            // 
            this.helloToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.helloToolStripMenuItem1.Name = "helloToolStripMenuItem1";
            this.helloToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.helloToolStripMenuItem1.Text = "Hello";
            // 
            // testringToolStripMenuItem
            // 
            this.testringToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.testringToolStripMenuItem.Name = "testringToolStripMenuItem";
            this.testringToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.testringToolStripMenuItem.Text = "Testring";
            // 
            // cmsCopy
            // 
            this.cmsCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsCopy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCopy.ForeColor = System.Drawing.Color.White;
            this.cmsCopy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenameToolStripMenuItem,
            this.sizeBytesToolStripMenuItem,
            this.crc32ToolStripMenuItem,
            this.createdDateToolStripMenuItem,
            this.modifiedDateToolStripMenuItem,
            this.toolStripSeparator6,
            this.modelToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.fsysCRC32ToolStripMenuItem,
            this.serialToolStripMenuItem,
            this.hwcToolStripMenuItem,
            this.orderNoToolStripMenuItem,
            this.efiVersionToolStripMenuItem,
            this.boardIDToolStripMenuItem,
            this.fitVersionToolStripMenuItem,
            this.meVersionToolStripMenuItem,
            this.toolStripSeparator5,
            this.fsysBaseAddressToolStripMenuItem,
            this.vSSBaseAddressToolStripMenuItem,
            this.sVSBaseAddressToolStripMenuItem,
            this.pdrBaseToolStripMenuItem,
            this.meBaseToolStripMenuItem,
            this.biosBaseToolStripMenuItem});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.ShowImageMargin = false;
            this.cmsCopy.Size = new System.Drawing.Size(207, 604);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // sizeBytesToolStripMenuItem
            // 
            this.sizeBytesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeBytesToolStripMenuItem.Name = "sizeBytesToolStripMenuItem";
            this.sizeBytesToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.sizeBytesToolStripMenuItem.Text = "Size";
            this.sizeBytesToolStripMenuItem.Click += new System.EventHandler(this.sizeBytesToolStripMenuItem_Click);
            // 
            // crc32ToolStripMenuItem
            // 
            this.crc32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.crc32ToolStripMenuItem.Name = "crc32ToolStripMenuItem";
            this.crc32ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.crc32ToolStripMenuItem.Text = "CRC32";
            this.crc32ToolStripMenuItem.Click += new System.EventHandler(this.crc32ToolStripMenuItem_Click);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.createdDateToolStripMenuItem.Text = "Creation Date";
            this.createdDateToolStripMenuItem.Click += new System.EventHandler(this.createdDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(203, 6);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.configurationToolStripMenuItem.Text = "Config";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // fsysCRC32ToolStripMenuItem
            // 
            this.fsysCRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fsysCRC32ToolStripMenuItem.Name = "fsysCRC32ToolStripMenuItem";
            this.fsysCRC32ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.fsysCRC32ToolStripMenuItem.Text = "Fsys CRC32";
            this.fsysCRC32ToolStripMenuItem.Click += new System.EventHandler(this.fsysCRC32ToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // hwcToolStripMenuItem
            // 
            this.hwcToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hwcToolStripMenuItem.Name = "hwcToolStripMenuItem";
            this.hwcToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.hwcToolStripMenuItem.Text = "HWC";
            this.hwcToolStripMenuItem.Click += new System.EventHandler(this.hwcToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
            // 
            // efiVersionToolStripMenuItem
            // 
            this.efiVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.efiVersionToolStripMenuItem.Name = "efiVersionToolStripMenuItem";
            this.efiVersionToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.efiVersionToolStripMenuItem.Text = "EFI Version";
            this.efiVersionToolStripMenuItem.Click += new System.EventHandler(this.efiVersionToolStripMenuItem_Click);
            // 
            // boardIDToolStripMenuItem
            // 
            this.boardIDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.boardIDToolStripMenuItem.Name = "boardIDToolStripMenuItem";
            this.boardIDToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.boardIDToolStripMenuItem.Text = "Board ID";
            this.boardIDToolStripMenuItem.Click += new System.EventHandler(this.boardIDToolStripMenuItem_Click);
            // 
            // fitVersionToolStripMenuItem
            // 
            this.fitVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fitVersionToolStripMenuItem.Name = "fitVersionToolStripMenuItem";
            this.fitVersionToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.fitVersionToolStripMenuItem.Text = "Intel FIT Version";
            this.fitVersionToolStripMenuItem.Click += new System.EventHandler(this.fitVersionToolStripMenuItem_Click);
            // 
            // meVersionToolStripMenuItem
            // 
            this.meVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meVersionToolStripMenuItem.Name = "meVersionToolStripMenuItem";
            this.meVersionToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.meVersionToolStripMenuItem.Text = "Intel ME Version";
            this.meVersionToolStripMenuItem.Click += new System.EventHandler(this.meVersionToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(203, 6);
            // 
            // fsysBaseAddressToolStripMenuItem
            // 
            this.fsysBaseAddressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fsysBaseAddressToolStripMenuItem.Name = "fsysBaseAddressToolStripMenuItem";
            this.fsysBaseAddressToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.fsysBaseAddressToolStripMenuItem.Text = "Fsys Base Address";
            this.fsysBaseAddressToolStripMenuItem.Click += new System.EventHandler(this.fsysBaseAddressToolStripMenuItem_Click);
            // 
            // vSSBaseAddressToolStripMenuItem
            // 
            this.vSSBaseAddressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.vSSBaseAddressToolStripMenuItem.Name = "vSSBaseAddressToolStripMenuItem";
            this.vSSBaseAddressToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.vSSBaseAddressToolStripMenuItem.Text = "VSS Base Address";
            this.vSSBaseAddressToolStripMenuItem.Click += new System.EventHandler(this.vSSBaseAddressToolStripMenuItem_Click);
            // 
            // sVSBaseAddressToolStripMenuItem
            // 
            this.sVSBaseAddressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sVSBaseAddressToolStripMenuItem.Name = "sVSBaseAddressToolStripMenuItem";
            this.sVSBaseAddressToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.sVSBaseAddressToolStripMenuItem.Text = "SVS Base Address";
            this.sVSBaseAddressToolStripMenuItem.Click += new System.EventHandler(this.sVSBaseAddressToolStripMenuItem_Click);
            // 
            // pdrBaseToolStripMenuItem
            // 
            this.pdrBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pdrBaseToolStripMenuItem.Name = "pdrBaseToolStripMenuItem";
            this.pdrBaseToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.pdrBaseToolStripMenuItem.Text = "PDR Region Details";
            this.pdrBaseToolStripMenuItem.Click += new System.EventHandler(this.pdrBaseToolStripMenuItem_Click);
            // 
            // meBaseToolStripMenuItem
            // 
            this.meBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meBaseToolStripMenuItem.Name = "meBaseToolStripMenuItem";
            this.meBaseToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.meBaseToolStripMenuItem.Text = "ME Region Details";
            this.meBaseToolStripMenuItem.Click += new System.EventHandler(this.meBaseToolStripMenuItem_Click);
            // 
            // biosBaseToolStripMenuItem
            // 
            this.biosBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.biosBaseToolStripMenuItem.Name = "biosBaseToolStripMenuItem";
            this.biosBaseToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.biosBaseToolStripMenuItem.Text = "BIOS Region Details";
            this.biosBaseToolStripMenuItem.Click += new System.EventHandler(this.biosBaseToolStripMenuItem_Click);
            // 
            // cmsTools
            // 
            this.cmsTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsTools.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsTools.ForeColor = System.Drawing.Color.White;
            this.cmsTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateFilenameToolStripMenuItem,
            this.lookupSerialNumberToolStripMenuItem,
            this.viewRomInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetWindowToolStripMenuItem,
            this.reloadFileFromDiskToolStripMenuItem});
            this.cmsTools.Name = "cmdOptions";
            this.cmsTools.ShowImageMargin = false;
            this.cmsTools.Size = new System.Drawing.Size(284, 150);
            // 
            // generateFilenameToolStripMenuItem
            // 
            this.generateFilenameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generateFilenameToolStripMenuItem.Name = "generateFilenameToolStripMenuItem";
            this.generateFilenameToolStripMenuItem.Size = new System.Drawing.Size(283, 28);
            this.generateFilenameToolStripMenuItem.Text = "Generate Filename";
            this.generateFilenameToolStripMenuItem.Click += new System.EventHandler(this.generateFilenameToolStripMenuItem_Click);
            // 
            // lookupSerialNumberToolStripMenuItem
            // 
            this.lookupSerialNumberToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.lookupSerialNumberToolStripMenuItem.Name = "lookupSerialNumberToolStripMenuItem";
            this.lookupSerialNumberToolStripMenuItem.Size = new System.Drawing.Size(283, 28);
            this.lookupSerialNumberToolStripMenuItem.Text = "Lookup Serial Number";
            this.lookupSerialNumberToolStripMenuItem.Click += new System.EventHandler(this.lookupSerialNumberToolStripMenuItem_Click);
            // 
            // viewRomInformationToolStripMenuItem
            // 
            this.viewRomInformationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewRomInformationToolStripMenuItem.Name = "viewRomInformationToolStripMenuItem";
            this.viewRomInformationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.viewRomInformationToolStripMenuItem.Size = new System.Drawing.Size(283, 28);
            this.viewRomInformationToolStripMenuItem.Text = "View ROM Information";
            this.viewRomInformationToolStripMenuItem.Click += new System.EventHandler(this.viewRomInformationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(280, 6);
            // 
            // resetWindowToolStripMenuItem
            // 
            this.resetWindowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetWindowToolStripMenuItem.Name = "resetWindowToolStripMenuItem";
            this.resetWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetWindowToolStripMenuItem.Size = new System.Drawing.Size(283, 28);
            this.resetWindowToolStripMenuItem.Text = "Reset Window";
            this.resetWindowToolStripMenuItem.Click += new System.EventHandler(this.resetWindowToolStripMenuItem_Click);
            // 
            // reloadFileFromDiskToolStripMenuItem
            // 
            this.reloadFileFromDiskToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reloadFileFromDiskToolStripMenuItem.Name = "reloadFileFromDiskToolStripMenuItem";
            this.reloadFileFromDiskToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadFileFromDiskToolStripMenuItem.Size = new System.Drawing.Size(283, 28);
            this.reloadFileFromDiskToolStripMenuItem.Text = "Reload File from Disk";
            this.reloadFileFromDiskToolStripMenuItem.Click += new System.EventHandler(this.reloadFileFromDiskToolStripMenuItem_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsExport.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsExport.ForeColor = System.Drawing.Color.White;
            this.cmsExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFsysStoreToolStripMenuItem,
            this.exportIntelMERegionToolStripMenuItem,
            this.exportNVRAMVSSStoresToolStripMenuItem,
            this.exportNVRAMSVSStoresToolStripMenuItem,
            this.exportLZMADXEArchiveToolStripMenuItem,
            this.toolStripSeparator3,
            this.backupFirmwareZIPToolStripMenuItem,
            this.exportFirmwareInformationTextToolStripMenuItem,
            this.exportFmmmobilemeEmailTextToolStripMenuItem});
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.ShowImageMargin = false;
            this.cmsExport.Size = new System.Drawing.Size(319, 234);
            // 
            // exportFsysStoreToolStripMenuItem
            // 
            this.exportFsysStoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportFsysStoreToolStripMenuItem.Name = "exportFsysStoreToolStripMenuItem";
            this.exportFsysStoreToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportFsysStoreToolStripMenuItem.Text = "Export Fsys Store";
            this.exportFsysStoreToolStripMenuItem.Click += new System.EventHandler(this.exportFsysStoreToolStripMenuItem_Click);
            // 
            // exportIntelMERegionToolStripMenuItem
            // 
            this.exportIntelMERegionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportIntelMERegionToolStripMenuItem.Name = "exportIntelMERegionToolStripMenuItem";
            this.exportIntelMERegionToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportIntelMERegionToolStripMenuItem.Text = "Export Intel ME Region";
            this.exportIntelMERegionToolStripMenuItem.Click += new System.EventHandler(this.exportIntelMERegionToolStripMenuItem_Click);
            // 
            // exportNVRAMVSSStoresToolStripMenuItem
            // 
            this.exportNVRAMVSSStoresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportNVRAMVSSStoresToolStripMenuItem.Name = "exportNVRAMVSSStoresToolStripMenuItem";
            this.exportNVRAMVSSStoresToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportNVRAMVSSStoresToolStripMenuItem.Text = "Export NVRAM VSS Stores";
            this.exportNVRAMVSSStoresToolStripMenuItem.Click += new System.EventHandler(this.exportNVRAMVSSStoresToolStripMenuItem_Click);
            // 
            // exportNVRAMSVSStoresToolStripMenuItem
            // 
            this.exportNVRAMSVSStoresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportNVRAMSVSStoresToolStripMenuItem.Name = "exportNVRAMSVSStoresToolStripMenuItem";
            this.exportNVRAMSVSStoresToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportNVRAMSVSStoresToolStripMenuItem.Text = "Export NVRAM SVS Stores";
            this.exportNVRAMSVSStoresToolStripMenuItem.Click += new System.EventHandler(this.exportNVRAMSVSStoresToolStripMenuItem_Click);
            // 
            // exportLZMADXEArchiveToolStripMenuItem
            // 
            this.exportLZMADXEArchiveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportLZMADXEArchiveToolStripMenuItem.Name = "exportLZMADXEArchiveToolStripMenuItem";
            this.exportLZMADXEArchiveToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportLZMADXEArchiveToolStripMenuItem.Text = "Export LZMA DXE Archive";
            this.exportLZMADXEArchiveToolStripMenuItem.Click += new System.EventHandler(this.exportLZMADXEArchiveToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(315, 6);
            // 
            // backupFirmwareZIPToolStripMenuItem
            // 
            this.backupFirmwareZIPToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.backupFirmwareZIPToolStripMenuItem.Name = "backupFirmwareZIPToolStripMenuItem";
            this.backupFirmwareZIPToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.backupFirmwareZIPToolStripMenuItem.Text = "Backup Firmware (ZIP)";
            this.backupFirmwareZIPToolStripMenuItem.Click += new System.EventHandler(this.backupFirmwareZIPToolStripMenuItem_Click);
            // 
            // exportFirmwareInformationTextToolStripMenuItem
            // 
            this.exportFirmwareInformationTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportFirmwareInformationTextToolStripMenuItem.Name = "exportFirmwareInformationTextToolStripMenuItem";
            this.exportFirmwareInformationTextToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportFirmwareInformationTextToolStripMenuItem.Text = "Export Firmware Information (Text)";
            this.exportFirmwareInformationTextToolStripMenuItem.Click += new System.EventHandler(this.exportFirmwareInformationTextToolStripMenuItem_Click);
            // 
            // exportFmmmobilemeEmailTextToolStripMenuItem
            // 
            this.exportFmmmobilemeEmailTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportFmmmobilemeEmailTextToolStripMenuItem.Name = "exportFmmmobilemeEmailTextToolStripMenuItem";
            this.exportFmmmobilemeEmailTextToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportFmmmobilemeEmailTextToolStripMenuItem.Text = "Export Find My Mac Email (Text)";
            this.exportFmmmobilemeEmailTextToolStripMenuItem.Click += new System.EventHandler(this.exportFmmmobilemeEmailTextToolStripMenuItem_Click);
            // 
            // cmsPatch
            // 
            this.cmsPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsPatch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsPatch.ForeColor = System.Drawing.Color.White;
            this.cmsPatch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSerialNumberToolStripMenuItem,
            this.eraseNVRAMToolStripMenuItem,
            this.replaceFsysStoreToolStripMenuItem,
            this.replaceIntelMERegionToolStripMenuItem,
            this.toolStripSeparator2,
            this.fixFsysChecksumToolStripMenuItem,
            this.invalidateEFILockToolStripMenuItem});
            this.cmsPatch.Name = "cmsPatch";
            this.cmsPatch.ShowImageMargin = false;
            this.cmsPatch.Size = new System.Drawing.Size(241, 206);
            // 
            // changeSerialNumberToolStripMenuItem
            // 
            this.changeSerialNumberToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changeSerialNumberToolStripMenuItem.Name = "changeSerialNumberToolStripMenuItem";
            this.changeSerialNumberToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.changeSerialNumberToolStripMenuItem.Text = "Change Serial Number";
            this.changeSerialNumberToolStripMenuItem.Click += new System.EventHandler(this.changeSerialNumberToolStripMenuItem_Click);
            // 
            // eraseNVRAMToolStripMenuItem
            // 
            this.eraseNVRAMToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eraseNVRAMToolStripMenuItem.Name = "eraseNVRAMToolStripMenuItem";
            this.eraseNVRAMToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.eraseNVRAMToolStripMenuItem.Text = "Erase NVRAM";
            this.eraseNVRAMToolStripMenuItem.Click += new System.EventHandler(this.eraseNvramToolStripMenuItem_Click);
            // 
            // replaceFsysStoreToolStripMenuItem
            // 
            this.replaceFsysStoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.replaceFsysStoreToolStripMenuItem.Name = "replaceFsysStoreToolStripMenuItem";
            this.replaceFsysStoreToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.replaceFsysStoreToolStripMenuItem.Text = "Replace Fsys Store";
            this.replaceFsysStoreToolStripMenuItem.Click += new System.EventHandler(this.replaceFsysStoreToolStripMenuItem_Click);
            // 
            // replaceIntelMERegionToolStripMenuItem
            // 
            this.replaceIntelMERegionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.replaceIntelMERegionToolStripMenuItem.Name = "replaceIntelMERegionToolStripMenuItem";
            this.replaceIntelMERegionToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.replaceIntelMERegionToolStripMenuItem.Text = "Replace Intel ME Region";
            this.replaceIntelMERegionToolStripMenuItem.Click += new System.EventHandler(this.replaceIntelMERegionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // fixFsysChecksumToolStripMenuItem
            // 
            this.fixFsysChecksumToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fixFsysChecksumToolStripMenuItem.Name = "fixFsysChecksumToolStripMenuItem";
            this.fixFsysChecksumToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.fixFsysChecksumToolStripMenuItem.Text = "Fix Fsys Checksum";
            this.fixFsysChecksumToolStripMenuItem.Click += new System.EventHandler(this.fixFsysChecksumToolStripMenuItem_Click);
            // 
            // invalidateEFILockToolStripMenuItem
            // 
            this.invalidateEFILockToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.invalidateEFILockToolStripMenuItem.Name = "invalidateEFILockToolStripMenuItem";
            this.invalidateEFILockToolStripMenuItem.Size = new System.Drawing.Size(240, 28);
            this.invalidateEFILockToolStripMenuItem.Text = "Invalidate EFI Lock";
            this.invalidateEFILockToolStripMenuItem.Click += new System.EventHandler(this.invalidateEFILockToolStripMenuItem_Click);
            // 
            // cmsFolders
            // 
            this.cmsFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsFolders.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsFolders.ForeColor = System.Drawing.Color.White;
            this.cmsFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBackupsFolderToolStripMenuItem,
            this.openBuildsFolderToolStripMenuItem,
            this.openFsysStoresFolderToolStripMenuItem,
            this.openIntelMEFolderToolStripMenuItem,
            this.openNVRAMFolderToolStripMenuItem,
            this.openLZMADXEFolderToolStripMenuItem,
            this.toolStripSeparator4,
            this.openWorkingDirectoryToolStripMenuItem});
            this.cmsFolders.Name = "cmsFolders";
            this.cmsFolders.ShowImageMargin = false;
            this.cmsFolders.Size = new System.Drawing.Size(240, 206);
            // 
            // openBackupsFolderToolStripMenuItem
            // 
            this.openBackupsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openBackupsFolderToolStripMenuItem.Name = "openBackupsFolderToolStripMenuItem";
            this.openBackupsFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openBackupsFolderToolStripMenuItem.Text = "Open Backups Folder";
            this.openBackupsFolderToolStripMenuItem.Click += new System.EventHandler(this.openBackupsFolderToolStripMenuItem_Click);
            // 
            // openBuildsFolderToolStripMenuItem
            // 
            this.openBuildsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openBuildsFolderToolStripMenuItem.Name = "openBuildsFolderToolStripMenuItem";
            this.openBuildsFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openBuildsFolderToolStripMenuItem.Text = "Open Builds Folder";
            this.openBuildsFolderToolStripMenuItem.Click += new System.EventHandler(this.openBuildsFolderToolStripMenuItem_Click);
            // 
            // openFsysStoresFolderToolStripMenuItem
            // 
            this.openFsysStoresFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openFsysStoresFolderToolStripMenuItem.Name = "openFsysStoresFolderToolStripMenuItem";
            this.openFsysStoresFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openFsysStoresFolderToolStripMenuItem.Text = "Open Fsys Stores Folder";
            this.openFsysStoresFolderToolStripMenuItem.Click += new System.EventHandler(this.openFsysStoresFolderToolStripMenuItem_Click);
            // 
            // openIntelMEFolderToolStripMenuItem
            // 
            this.openIntelMEFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openIntelMEFolderToolStripMenuItem.Name = "openIntelMEFolderToolStripMenuItem";
            this.openIntelMEFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openIntelMEFolderToolStripMenuItem.Text = "Open Intel ME Folder";
            this.openIntelMEFolderToolStripMenuItem.Click += new System.EventHandler(this.openIntelMEFolderToolStripMenuItem_Click);
            // 
            // openNVRAMFolderToolStripMenuItem
            // 
            this.openNVRAMFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openNVRAMFolderToolStripMenuItem.Name = "openNVRAMFolderToolStripMenuItem";
            this.openNVRAMFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openNVRAMFolderToolStripMenuItem.Text = "Open NVRAM Folder";
            this.openNVRAMFolderToolStripMenuItem.Click += new System.EventHandler(this.openNVRAMFolderToolStripMenuItem_Click);
            // 
            // openLZMADXEFolderToolStripMenuItem
            // 
            this.openLZMADXEFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLZMADXEFolderToolStripMenuItem.Name = "openLZMADXEFolderToolStripMenuItem";
            this.openLZMADXEFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openLZMADXEFolderToolStripMenuItem.Text = "Open LZMA DXE Folder";
            this.openLZMADXEFolderToolStripMenuItem.Click += new System.EventHandler(this.openLZMADXEFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(236, 6);
            // 
            // openWorkingDirectoryToolStripMenuItem
            // 
            this.openWorkingDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openWorkingDirectoryToolStripMenuItem.Name = "openWorkingDirectoryToolStripMenuItem";
            this.openWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openWorkingDirectoryToolStripMenuItem.Text = "Open Working Directory";
            this.openWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirectoryToolStripMenuItem_Click);
            // 
            // cmsHelp
            // 
            this.cmsHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsHelp.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmsHelp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.toolStripSeparator8,
            this.viewApplicationLogToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.cmsHelp.Name = "cmsHelp";
            this.cmsHelp.ShowImageMargin = false;
            this.cmsHelp.Size = new System.Drawing.Size(252, 128);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(251, 28);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(248, 6);
            // 
            // viewApplicationLogToolStripMenuItem
            // 
            this.viewApplicationLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewApplicationLogToolStripMenuItem.Name = "viewApplicationLogToolStripMenuItem";
            this.viewApplicationLogToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.viewApplicationLogToolStripMenuItem.Size = new System.Drawing.Size(251, 28);
            this.viewApplicationLogToolStripMenuItem.Text = "View Application Log";
            this.viewApplicationLogToolStripMenuItem.Click += new System.EventHandler(this.viewApplicationLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(248, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(251, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(251, 28);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // frmEfiRom
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(763, 492);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(763, 492);
            this.MinimumSize = new System.Drawing.Size(763, 492);
            this.Name = "frmEfiRom";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EFIROM";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpFilename.ResumeLayout(false);
            this.tlpFirmware.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpSerialSwitch.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.tlpStatusBar.PerformLayout();
            this.tlpStatusBarImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.cmsCopy.ResumeLayout(false);
            this.cmsTools.ResumeLayout(false);
            this.cmsExport.ResumeLayout(false);
            this.cmsPatch.ResumeLayout(false);
            this.cmsFolders.ResumeLayout(false);
            this.cmsHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFileCrc32Text;
        private System.Windows.Forms.Label lblFilesizeText;
        private METLabel lblFilesize;
        private System.Windows.Forms.Label lblSerialNumberText;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.Label lblBoardIdText;
        private System.Windows.Forms.Button cmdMenuOpen;
        internal System.Windows.Forms.PictureBox pbxLogo;
        internal METLabel lblTitle;
        private System.Windows.Forms.Label lblFsysStoreText;
        private System.Windows.Forms.Label lblOrderNumberText;
        private System.Windows.Forms.Label lblApfsCapable;
        private System.Windows.Forms.Label lblApfsCapableText;
        private System.Windows.Forms.Label lblVssText;
        private System.Windows.Forms.Label lblEfiVersionText;
        private System.Windows.Forms.Button cmdMenuHelp;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.Label lblMeVersionText;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Label lblStatusBarTip;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.Label lblHwc;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblFileCreatedDateText;
        private System.Windows.Forms.Label lblFileModifiedDate;
        private System.Windows.Forms.Label lblFileModifiedDataText;
        private System.Windows.Forms.Label lblFileCreatedDate;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpFilename;
        private System.Windows.Forms.Button cmdMenuFolders;
        private System.Windows.Forms.TableLayoutPanel tlpFirmware;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.Button cmdOpenInExplorer;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblEfiVersion;
        private System.Windows.Forms.PictureBox pbxLoad;
        private METLabel lblFilename;
        private System.Windows.Forms.Label lblSvs;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hwcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsysCRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efiVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderNoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdMinimize;
        private METContextMenuStrip cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.Label lblEfiLockText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem pdrBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biosBaseToolStripMenuItem;
        private System.Windows.Forms.Button cmdMenuCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem filenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crc32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createdDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedDateToolStripMenuItem;
        private System.Windows.Forms.Label lblConfigCodeText;
        private System.Windows.Forms.Label lblModelText;
        private METLabel lblConfigCode;
        private System.Windows.Forms.ToolStripMenuItem helloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helloToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testringToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTopSplitMain;
        internal System.Windows.Forms.Button cmdMenuTools;
        internal System.Windows.Forms.Button cmdMenuExport;
        private METContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem generateFilenameToolStripMenuItem;
        internal System.Windows.Forms.Button cmdMenuPatch;
        private METContextMenuStrip cmsExport;
        private System.Windows.Forms.ToolStripMenuItem exportFsysStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportIntelMERegionToolStripMenuItem;
        private METContextMenuStrip cmsPatch;
        private System.Windows.Forms.ToolStripMenuItem replaceFsysStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lookupSerialNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSerialNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eraseNVRAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRomInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fixFsysChecksumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invalidateEFILockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNVRAMSVSStoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNVRAMVSSStoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportFirmwareInformationTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupFirmwareZIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceIntelMERegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsysBaseAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vSSBaseAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVSBaseAddressToolStripMenuItem;
        private System.Windows.Forms.Label lblDescriptorModeText;
        private System.Windows.Forms.Label lblDescriptorMode;
        private System.Windows.Forms.Label lblSvsText;
        private System.Windows.Forms.ToolStripMenuItem reloadFileFromDiskToolStripMenuItem;
        private METContextMenuStrip cmsFolders;
        private System.Windows.Forms.ToolStripMenuItem openBackupsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBuildsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFsysStoresFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIntelMEFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNVRAMFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.Label lblParseTime;
        private System.Windows.Forms.Panel pnlSplit0;
        private System.Windows.Forms.Panel pnlSplit1;
        private METSwitch cbxCensor;
        private System.Windows.Forms.Label lblFsysStore;
        private System.Windows.Forms.Label lblVss;
        private System.Windows.Forms.Label lblEfiLock;
        private System.Windows.Forms.Label lblFileCrc32;
        private System.Windows.Forms.Label lblMeVersion;
        private System.Windows.Forms.ToolStripMenuItem exportLZMADXEArchiveToolStripMenuItem;
        private System.Windows.Forms.Label lblLzma;
        private System.Windows.Forms.Label lblFmmEmail;
        private System.Windows.Forms.ToolStripMenuItem exportFmmmobilemeEmailTextToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TableLayoutPanel tlpSerialSwitch;
        private System.Windows.Forms.ToolStripMenuItem openLZMADXEFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetWindowToolStripMenuItem;
        private METContextMenuStrip cmsHelp;
        private System.Windows.Forms.ToolStripMenuItem viewApplicationLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblPagefile;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}