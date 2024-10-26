
using Mac_EFI_Toolkit.UI;

namespace Mac_EFI_Toolkit
{
    partial class efiWindow
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(efiWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new METLabel();
            this.cmdOpenInExplorer = new System.Windows.Forms.Button();
            this.tlpFirmware = new System.Windows.Forms.TableLayoutPanel();
            this.lblConfigCodeText = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblModelText = new System.Windows.Forms.Label();
            this.lblFileModifiedDate = new System.Windows.Forms.Label();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.lblFileModifiedDataText = new System.Windows.Forms.Label();
            this.lblEfiVersionText = new System.Windows.Forms.Label();
            this.lblFileCreatedDateText = new System.Windows.Forms.Label();
            this.lblFileCrc32 = new System.Windows.Forms.Label();
            this.lblSerialNumberText = new System.Windows.Forms.Label();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.lblFileCrc32Text = new System.Windows.Forms.Label();
            this.tlpEfiVer = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.lblFsysCrc32 = new System.Windows.Forms.Label();
            this.tlpNvram = new System.Windows.Forms.TableLayoutPanel();
            this.lblSvsStore = new System.Windows.Forms.Label();
            this.lblVssStore = new System.Windows.Forms.Label();
            this.lblOrderNumberText = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblMeVersionText = new System.Windows.Forms.Label();
            this.tlpIntelMe = new System.Windows.Forms.TableLayoutPanel();
            this.lblMeVersion = new System.Windows.Forms.Label();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.lblBoardIdText = new System.Windows.Forms.Label();
            this.lblEfiLockText = new System.Windows.Forms.Label();
            this.lblApfsCapable = new System.Windows.Forms.Label();
            this.lblApfsCapableText = new System.Windows.Forms.Label();
            this.tlpEfiLock = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiLock = new System.Windows.Forms.Label();
            this.lblHwc = new System.Windows.Forms.Label();
            this.lblFsysStoreText = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblFilesizeText = new System.Windows.Forms.Label();
            this.lblFileCreatedDate = new System.Windows.Forms.Label();
            this.lblConfigCode = new METLabel();
            this.lblFilesize = new METLabel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblStatusBarTip = new System.Windows.Forms.Label();
            this.pnlTopSplitMain = new System.Windows.Forms.Panel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdMenuOpen = new System.Windows.Forms.Button();
            this.cmdMenuReset = new System.Windows.Forms.Button();
            this.cmdMenuCopy = new System.Windows.Forms.Button();
            this.cmdMenuExport = new System.Windows.Forms.Button();
            this.cmdMenuOptions = new System.Windows.Forms.Button();
            this.cmdMenuPatch = new System.Windows.Forms.Button();
            this.cmdMenuReload = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
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
            this.configCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsysCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hwcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efiVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pdrBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biosBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOptions = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.automaticFilenameGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRomInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lookupSerialNumberOnEveryMacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.exportFsysStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIntelMERegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNVRAMSVSStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNVRAMVSSStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.backupFirmwareZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFirmwareInformationTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPatch = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.changeSerialNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceFsysStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetNVRAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fixFsysChecksumCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidateEFILockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpFilename.SuspendLayout();
            this.tlpFirmware.SuspendLayout();
            this.tlpEfiVer.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.tlpNvram.SuspendLayout();
            this.tlpIntelMe.SuspendLayout();
            this.tlpEfiLock.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.tlpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpTitle.SuspendLayout();
            this.cmsCopy.SuspendLayout();
            this.cmsOptions.SuspendLayout();
            this.cmsExport.SuspendLayout();
            this.cmsPatch.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(761, 395);
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.Size = new System.Drawing.Size(761, 361);
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
            this.tlpFilename.TabIndex = 0;
            // 
            // lblFilename
            // 
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFilename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFilename.Location = new System.Drawing.Point(0, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(724, 36);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdOpenInExplorer
            // 
            this.cmdOpenInExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOpenInExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpenInExplorer.Enabled = false;
            this.cmdOpenInExplorer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.cmdOpenInExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOpenInExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOpenInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenInExplorer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenInExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdOpenInExplorer.Location = new System.Drawing.Point(725, 0);
            this.cmdOpenInExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenInExplorer.Name = "cmdOpenInExplorer";
            this.cmdOpenInExplorer.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdOpenInExplorer.Size = new System.Drawing.Size(36, 36);
            this.cmdOpenInExplorer.TabIndex = 3;
            this.cmdOpenInExplorer.Text = "N";
            this.cmdOpenInExplorer.UseVisualStyleBackColor = false;
            this.cmdOpenInExplorer.Click += new System.EventHandler(this.cmdNavigate_Click);
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
            this.tlpFirmware.Controls.Add(this.lblConfigCodeText, 4, 4);
            this.tlpFirmware.Controls.Add(this.lblModel, 2, 4);
            this.tlpFirmware.Controls.Add(this.lblModelText, 0, 4);
            this.tlpFirmware.Controls.Add(this.lblFileModifiedDate, 6, 2);
            this.tlpFirmware.Controls.Add(this.lblNvramText, 4, 10);
            this.tlpFirmware.Controls.Add(this.lblFileModifiedDataText, 4, 2);
            this.tlpFirmware.Controls.Add(this.lblEfiVersionText, 0, 10);
            this.tlpFirmware.Controls.Add(this.lblFileCreatedDateText, 0, 2);
            this.tlpFirmware.Controls.Add(this.lblFileCrc32, 6, 0);
            this.tlpFirmware.Controls.Add(this.lblSerialNumberText, 4, 6);
            this.tlpFirmware.Controls.Add(this.lblHwcText, 0, 8);
            this.tlpFirmware.Controls.Add(this.lblFileCrc32Text, 4, 0);
            this.tlpFirmware.Controls.Add(this.tlpEfiVer, 2, 10);
            this.tlpFirmware.Controls.Add(this.tlpFsys, 2, 6);
            this.tlpFirmware.Controls.Add(this.tlpNvram, 6, 10);
            this.tlpFirmware.Controls.Add(this.lblOrderNumberText, 4, 8);
            this.tlpFirmware.Controls.Add(this.lblOrderNumber, 6, 8);
            this.tlpFirmware.Controls.Add(this.lblMeVersionText, 4, 14);
            this.tlpFirmware.Controls.Add(this.tlpIntelMe, 6, 14);
            this.tlpFirmware.Controls.Add(this.lblBoardId, 6, 12);
            this.tlpFirmware.Controls.Add(this.lblBoardIdText, 4, 12);
            this.tlpFirmware.Controls.Add(this.lblEfiLockText, 0, 12);
            this.tlpFirmware.Controls.Add(this.lblApfsCapable, 2, 14);
            this.tlpFirmware.Controls.Add(this.lblApfsCapableText, 0, 14);
            this.tlpFirmware.Controls.Add(this.tlpEfiLock, 2, 12);
            this.tlpFirmware.Controls.Add(this.lblHwc, 2, 8);
            this.tlpFirmware.Controls.Add(this.lblFsysStoreText, 0, 6);
            this.tlpFirmware.Controls.Add(this.tlpSerial, 6, 6);
            this.tlpFirmware.Controls.Add(this.lblFilesizeText, 0, 0);
            this.tlpFirmware.Controls.Add(this.lblFileCreatedDate, 2, 2);
            this.tlpFirmware.Controls.Add(this.lblConfigCode, 6, 4);
            this.tlpFirmware.Controls.Add(this.lblFilesize, 2, 0);
            this.tlpFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFirmware.Enabled = false;
            this.tlpFirmware.Location = new System.Drawing.Point(0, 37);
            this.tlpFirmware.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFirmware.Name = "tlpFirmware";
            this.tlpFirmware.RowCount = 15;
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpFirmware.Size = new System.Drawing.Size(761, 287);
            this.tlpFirmware.TabIndex = 2;
            // 
            // lblConfigCodeText
            // 
            this.lblConfigCodeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblConfigCodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCodeText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCodeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblConfigCodeText.Location = new System.Drawing.Point(381, 72);
            this.lblConfigCodeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCodeText.Name = "lblConfigCodeText";
            this.lblConfigCodeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblConfigCodeText.Size = new System.Drawing.Size(130, 35);
            this.lblConfigCodeText.TabIndex = 0;
            this.lblConfigCodeText.Text = "Config Code:";
            this.lblConfigCodeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModel
            // 
            this.lblModel.AutoEllipsis = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblModel.Location = new System.Drawing.Point(131, 72);
            this.lblModel.Margin = new System.Windows.Forms.Padding(0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModel.Size = new System.Drawing.Size(249, 35);
            this.lblModel.TabIndex = 0;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelText
            // 
            this.lblModelText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblModelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModelText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModelText.Location = new System.Drawing.Point(0, 72);
            this.lblModelText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModelText.Size = new System.Drawing.Size(130, 35);
            this.lblModelText.TabIndex = 0;
            this.lblModelText.Text = "Model:";
            this.lblModelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileModifiedDate
            // 
            this.lblFileModifiedDate.AutoEllipsis = true;
            this.lblFileModifiedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFileModifiedDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileModifiedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileModifiedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileModifiedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileModifiedDate.Location = new System.Drawing.Point(512, 36);
            this.lblFileModifiedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileModifiedDate.Name = "lblFileModifiedDate";
            this.lblFileModifiedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileModifiedDate.Size = new System.Drawing.Size(249, 35);
            this.lblFileModifiedDate.TabIndex = 0;
            this.lblFileModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileModifiedDate.UseMnemonic = false;
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblNvramText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNvramText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNvramText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblNvramText.Location = new System.Drawing.Point(381, 180);
            this.lblNvramText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNvramText.Name = "lblNvramText";
            this.lblNvramText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblNvramText.Size = new System.Drawing.Size(130, 35);
            this.lblNvramText.TabIndex = 0;
            this.lblNvramText.Text = "NVRAM:";
            this.lblNvramText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileModifiedDataText
            // 
            this.lblFileModifiedDataText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFileModifiedDataText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileModifiedDataText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileModifiedDataText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileModifiedDataText.Location = new System.Drawing.Point(381, 36);
            this.lblFileModifiedDataText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileModifiedDataText.Name = "lblFileModifiedDataText";
            this.lblFileModifiedDataText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileModifiedDataText.Size = new System.Drawing.Size(130, 35);
            this.lblFileModifiedDataText.TabIndex = 0;
            this.lblFileModifiedDataText.Text = "Modified:";
            this.lblFileModifiedDataText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiVersionText
            // 
            this.lblEfiVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblEfiVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiVersionText.Location = new System.Drawing.Point(0, 180);
            this.lblEfiVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersionText.Name = "lblEfiVersionText";
            this.lblEfiVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiVersionText.Size = new System.Drawing.Size(130, 35);
            this.lblEfiVersionText.TabIndex = 0;
            this.lblEfiVersionText.Text = "EFI Version:";
            this.lblEfiVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCreatedDateText
            // 
            this.lblFileCreatedDateText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFileCreatedDateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCreatedDateText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCreatedDateText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileCreatedDateText.Location = new System.Drawing.Point(0, 36);
            this.lblFileCreatedDateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCreatedDateText.Name = "lblFileCreatedDateText";
            this.lblFileCreatedDateText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileCreatedDateText.Size = new System.Drawing.Size(130, 35);
            this.lblFileCreatedDateText.TabIndex = 0;
            this.lblFileCreatedDateText.Text = "Created:";
            this.lblFileCreatedDateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCrc32
            // 
            this.lblFileCrc32.AutoEllipsis = true;
            this.lblFileCrc32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFileCrc32.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileCrc32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCrc32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCrc32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileCrc32.Location = new System.Drawing.Point(512, 0);
            this.lblFileCrc32.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCrc32.Name = "lblFileCrc32";
            this.lblFileCrc32.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCrc32.Size = new System.Drawing.Size(249, 35);
            this.lblFileCrc32.TabIndex = 0;
            this.lblFileCrc32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileCrc32.UseMnemonic = false;
            // 
            // lblSerialNumberText
            // 
            this.lblSerialNumberText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSerialNumberText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumberText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumberText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialNumberText.Location = new System.Drawing.Point(381, 108);
            this.lblSerialNumberText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumberText.Name = "lblSerialNumberText";
            this.lblSerialNumberText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialNumberText.Size = new System.Drawing.Size(130, 35);
            this.lblSerialNumberText.TabIndex = 0;
            this.lblSerialNumberText.Text = "Serial:";
            this.lblSerialNumberText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwcText
            // 
            this.lblHwcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblHwcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(0, 144);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblHwcText.Size = new System.Drawing.Size(130, 35);
            this.lblHwcText.TabIndex = 0;
            this.lblHwcText.Text = "HWC:";
            this.lblHwcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCrc32Text
            // 
            this.lblFileCrc32Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFileCrc32Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCrc32Text.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCrc32Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFileCrc32Text.Location = new System.Drawing.Point(381, 0);
            this.lblFileCrc32Text.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCrc32Text.Name = "lblFileCrc32Text";
            this.lblFileCrc32Text.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFileCrc32Text.Size = new System.Drawing.Size(130, 35);
            this.lblFileCrc32Text.TabIndex = 0;
            this.lblFileCrc32Text.Text = "CRC32:";
            this.lblFileCrc32Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfiVer
            // 
            this.tlpEfiVer.ColumnCount = 1;
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiVer.Controls.Add(this.lblEfiVersion, 0, 0);
            this.tlpEfiVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiVer.Location = new System.Drawing.Point(131, 180);
            this.tlpEfiVer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiVer.Name = "tlpEfiVer";
            this.tlpEfiVer.RowCount = 1;
            this.tlpEfiVer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiVer.Size = new System.Drawing.Size(249, 35);
            this.tlpEfiVer.TabIndex = 1;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblEfiVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiVersion.Location = new System.Drawing.Point(0, 0);
            this.lblEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersion.Name = "lblEfiVersion";
            this.lblEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiVersion.Size = new System.Drawing.Size(249, 35);
            this.lblEfiVersion.TabIndex = 0;
            this.lblEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfiVersion.UseMnemonic = false;
            // 
            // tlpFsys
            // 
            this.tlpFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpFsys.ColumnCount = 1;
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFsys.Controls.Add(this.lblFsysCrc32, 0, 0);
            this.tlpFsys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFsys.Location = new System.Drawing.Point(131, 108);
            this.tlpFsys.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsys.Name = "tlpFsys";
            this.tlpFsys.RowCount = 1;
            this.tlpFsys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.Size = new System.Drawing.Size(249, 35);
            this.tlpFsys.TabIndex = 0;
            // 
            // lblFsysCrc32
            // 
            this.lblFsysCrc32.AutoEllipsis = true;
            this.lblFsysCrc32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFsysCrc32.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFsysCrc32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysCrc32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysCrc32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFsysCrc32.Location = new System.Drawing.Point(0, 0);
            this.lblFsysCrc32.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysCrc32.Name = "lblFsysCrc32";
            this.lblFsysCrc32.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFsysCrc32.Size = new System.Drawing.Size(249, 35);
            this.lblFsysCrc32.TabIndex = 0;
            this.lblFsysCrc32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFsysCrc32.UseMnemonic = false;
            // 
            // tlpNvram
            // 
            this.tlpNvram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpNvram.ColumnCount = 3;
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNvram.Controls.Add(this.lblSvsStore, 2, 0);
            this.tlpNvram.Controls.Add(this.lblVssStore, 0, 0);
            this.tlpNvram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNvram.Location = new System.Drawing.Point(512, 180);
            this.tlpNvram.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNvram.Name = "tlpNvram";
            this.tlpNvram.RowCount = 1;
            this.tlpNvram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNvram.Size = new System.Drawing.Size(249, 35);
            this.tlpNvram.TabIndex = 3;
            // 
            // lblSvsStore
            // 
            this.lblSvsStore.AutoEllipsis = true;
            this.lblSvsStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSvsStore.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSvsStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvsStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblSvsStore.Location = new System.Drawing.Point(125, 0);
            this.lblSvsStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsStore.Name = "lblSvsStore";
            this.lblSvsStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSvsStore.Size = new System.Drawing.Size(124, 35);
            this.lblSvsStore.TabIndex = 0;
            this.lblSvsStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSvsStore.UseMnemonic = false;
            // 
            // lblVssStore
            // 
            this.lblVssStore.AutoEllipsis = true;
            this.lblVssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblVssStore.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVssStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblVssStore.Location = new System.Drawing.Point(0, 0);
            this.lblVssStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssStore.Name = "lblVssStore";
            this.lblVssStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblVssStore.Size = new System.Drawing.Size(124, 35);
            this.lblVssStore.TabIndex = 0;
            this.lblVssStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVssStore.UseMnemonic = false;
            // 
            // lblOrderNumberText
            // 
            this.lblOrderNumberText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblOrderNumberText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNumberText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumberText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOrderNumberText.Location = new System.Drawing.Point(381, 144);
            this.lblOrderNumberText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNumberText.Name = "lblOrderNumberText";
            this.lblOrderNumberText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOrderNumberText.Size = new System.Drawing.Size(130, 35);
            this.lblOrderNumberText.TabIndex = 0;
            this.lblOrderNumberText.Text = "Order No:";
            this.lblOrderNumberText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoEllipsis = true;
            this.lblOrderNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblOrderNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblOrderNumber.Location = new System.Drawing.Point(512, 144);
            this.lblOrderNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOrderNumber.Size = new System.Drawing.Size(249, 35);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOrderNumber.UseMnemonic = false;
            // 
            // lblMeVersionText
            // 
            this.lblMeVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblMeVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblMeVersionText.Location = new System.Drawing.Point(381, 252);
            this.lblMeVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersionText.Name = "lblMeVersionText";
            this.lblMeVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblMeVersionText.Size = new System.Drawing.Size(130, 35);
            this.lblMeVersionText.TabIndex = 0;
            this.lblMeVersionText.Text = "Intel ME:";
            this.lblMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpIntelMe
            // 
            this.tlpIntelMe.ColumnCount = 1;
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpIntelMe.Controls.Add(this.lblMeVersion, 0, 0);
            this.tlpIntelMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIntelMe.Location = new System.Drawing.Point(512, 252);
            this.tlpIntelMe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIntelMe.Name = "tlpIntelMe";
            this.tlpIntelMe.RowCount = 1;
            this.tlpIntelMe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIntelMe.Size = new System.Drawing.Size(249, 35);
            this.tlpIntelMe.TabIndex = 5;
            // 
            // lblMeVersion
            // 
            this.lblMeVersion.AutoEllipsis = true;
            this.lblMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblMeVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblMeVersion.Location = new System.Drawing.Point(0, 0);
            this.lblMeVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersion.Name = "lblMeVersion";
            this.lblMeVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMeVersion.Size = new System.Drawing.Size(249, 35);
            this.lblMeVersion.TabIndex = 0;
            this.lblMeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeVersion.UseMnemonic = false;
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoEllipsis = true;
            this.lblBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBoardId.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBoardId.Location = new System.Drawing.Point(512, 216);
            this.lblBoardId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBoardId.Size = new System.Drawing.Size(249, 35);
            this.lblBoardId.TabIndex = 0;
            this.lblBoardId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBoardId.UseMnemonic = false;
            // 
            // lblBoardIdText
            // 
            this.lblBoardIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblBoardIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardIdText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBoardIdText.Location = new System.Drawing.Point(381, 216);
            this.lblBoardIdText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardIdText.Name = "lblBoardIdText";
            this.lblBoardIdText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBoardIdText.Size = new System.Drawing.Size(130, 35);
            this.lblBoardIdText.TabIndex = 0;
            this.lblBoardIdText.Text = "Board ID:";
            this.lblBoardIdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiLockText
            // 
            this.lblEfiLockText.AutoEllipsis = true;
            this.lblEfiLockText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblEfiLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLockText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLockText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiLockText.Location = new System.Drawing.Point(0, 216);
            this.lblEfiLockText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLockText.Name = "lblEfiLockText";
            this.lblEfiLockText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiLockText.Size = new System.Drawing.Size(130, 35);
            this.lblEfiLockText.TabIndex = 0;
            this.lblEfiLockText.Text = "EFI Lock:";
            this.lblEfiLockText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapable
            // 
            this.lblApfsCapable.AutoEllipsis = true;
            this.lblApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblApfsCapable.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblApfsCapable.Location = new System.Drawing.Point(131, 252);
            this.lblApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapable.Name = "lblApfsCapable";
            this.lblApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblApfsCapable.Size = new System.Drawing.Size(249, 35);
            this.lblApfsCapable.TabIndex = 0;
            this.lblApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApfsCapable.UseMnemonic = false;
            // 
            // lblApfsCapableText
            // 
            this.lblApfsCapableText.AutoEllipsis = true;
            this.lblApfsCapableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblApfsCapableText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapableText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapableText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApfsCapableText.Location = new System.Drawing.Point(0, 252);
            this.lblApfsCapableText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapableText.Name = "lblApfsCapableText";
            this.lblApfsCapableText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApfsCapableText.Size = new System.Drawing.Size(130, 35);
            this.lblApfsCapableText.TabIndex = 0;
            this.lblApfsCapableText.Text = "APFS Capable:";
            this.lblApfsCapableText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfiLock
            // 
            this.tlpEfiLock.ColumnCount = 1;
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiLock.Controls.Add(this.lblEfiLock, 0, 0);
            this.tlpEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiLock.Location = new System.Drawing.Point(131, 216);
            this.tlpEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiLock.Name = "tlpEfiLock";
            this.tlpEfiLock.RowCount = 1;
            this.tlpEfiLock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiLock.Size = new System.Drawing.Size(249, 35);
            this.tlpEfiLock.TabIndex = 3;
            // 
            // lblEfiLock
            // 
            this.lblEfiLock.AutoEllipsis = true;
            this.lblEfiLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblEfiLock.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiLock.Location = new System.Drawing.Point(0, 0);
            this.lblEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLock.Name = "lblEfiLock";
            this.lblEfiLock.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiLock.Size = new System.Drawing.Size(249, 35);
            this.lblEfiLock.TabIndex = 0;
            this.lblEfiLock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfiLock.UseMnemonic = false;
            // 
            // lblHwc
            // 
            this.lblHwc.AutoEllipsis = true;
            this.lblHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblHwc.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblHwc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblHwc.Location = new System.Drawing.Point(131, 144);
            this.lblHwc.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwc.Name = "lblHwc";
            this.lblHwc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblHwc.Size = new System.Drawing.Size(249, 35);
            this.lblHwc.TabIndex = 0;
            this.lblHwc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHwc.UseMnemonic = false;
            // 
            // lblFsysStoreText
            // 
            this.lblFsysStoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFsysStoreText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysStoreText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysStoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysStoreText.Location = new System.Drawing.Point(0, 108);
            this.lblFsysStoreText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysStoreText.Name = "lblFsysStoreText";
            this.lblFsysStoreText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysStoreText.Size = new System.Drawing.Size(130, 35);
            this.lblFsysStoreText.TabIndex = 0;
            this.lblFsysStoreText.Text = "Fsys Store:";
            this.lblFsysStoreText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerial
            // 
            this.tlpSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpSerial.ColumnCount = 1;
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSerial.Controls.Add(this.lblSerialNumber, 0, 0);
            this.tlpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerial.Location = new System.Drawing.Point(512, 108);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(249, 35);
            this.tlpSerial.TabIndex = 4;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoEllipsis = true;
            this.lblSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSerialNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblSerialNumber.Location = new System.Drawing.Point(0, 0);
            this.lblSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerialNumber.Size = new System.Drawing.Size(249, 35);
            this.lblSerialNumber.TabIndex = 0;
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerialNumber.UseMnemonic = false;
            // 
            // lblFilesizeText
            // 
            this.lblFilesizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFilesizeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilesizeText.Location = new System.Drawing.Point(0, 0);
            this.lblFilesizeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeText.Name = "lblFilesizeText";
            this.lblFilesizeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilesizeText.Size = new System.Drawing.Size(130, 35);
            this.lblFilesizeText.TabIndex = 0;
            this.lblFilesizeText.Text = "Size:";
            this.lblFilesizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCreatedDate
            // 
            this.lblFileCreatedDate.AutoEllipsis = true;
            this.lblFileCreatedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFileCreatedDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileCreatedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFileCreatedDate.Location = new System.Drawing.Point(131, 36);
            this.lblFileCreatedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCreatedDate.Name = "lblFileCreatedDate";
            this.lblFileCreatedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCreatedDate.Size = new System.Drawing.Size(249, 35);
            this.lblFileCreatedDate.TabIndex = 0;
            this.lblFileCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigCode
            // 
            this.lblConfigCode.AutoEllipsis = true;
            this.lblConfigCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblConfigCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfigCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfigCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblConfigCode.Location = new System.Drawing.Point(512, 72);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(249, 35);
            this.lblConfigCode.TabIndex = 0;
            this.lblConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoEllipsis = true;
            this.lblFilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFilesize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblFilesize.Location = new System.Drawing.Point(131, 0);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(249, 35);
            this.lblFilesize.TabIndex = 0;
            this.lblFilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFilesize.UseMnemonic = false;
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpStatusBar.ColumnCount = 2;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.Controls.Add(this.tlpStatusBarImage, 1, 0);
            this.tlpStatusBar.Controls.Add(this.lblStatusBarTip, 0, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 325);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(761, 36);
            this.tlpStatusBar.TabIndex = 0;
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
            this.lblStatusBarTip.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBarTip.ForeColor = System.Drawing.Color.White;
            this.lblStatusBarTip.Location = new System.Drawing.Point(0, 0);
            this.lblStatusBarTip.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusBarTip.Name = "lblStatusBarTip";
            this.lblStatusBarTip.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblStatusBarTip.Size = new System.Drawing.Size(725, 36);
            this.lblStatusBarTip.TabIndex = 0;
            this.lblStatusBarTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTopSplitMain
            // 
            this.pnlTopSplitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
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
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.Controls.Add(this.cmdMenuOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuCopy, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuExport, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuOptions, 12, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuPatch, 10, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuReload, 6, 0);
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
            this.cmdMenuOpen.Size = new System.Drawing.Size(106, 32);
            this.cmdMenuOpen.TabIndex = 0;
            this.cmdMenuOpen.Text = "OPEN";
            this.cmdMenuOpen.UseVisualStyleBackColor = false;
            this.cmdMenuOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdMenuReset
            // 
            this.cmdMenuReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuReset.Enabled = false;
            this.cmdMenuReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuReset.FlatAppearance.BorderSize = 0;
            this.cmdMenuReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuReset.Location = new System.Drawing.Point(108, 0);
            this.cmdMenuReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuReset.Name = "cmdMenuReset";
            this.cmdMenuReset.Size = new System.Drawing.Size(106, 32);
            this.cmdMenuReset.TabIndex = 1;
            this.cmdMenuReset.Text = "RESET";
            this.cmdMenuReset.UseVisualStyleBackColor = false;
            this.cmdMenuReset.Click += new System.EventHandler(this.cmdReset_Click);
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
            this.cmdMenuCopy.Size = new System.Drawing.Size(106, 32);
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
            this.cmdMenuExport.Location = new System.Drawing.Point(432, 0);
            this.cmdMenuExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuExport.Name = "cmdMenuExport";
            this.cmdMenuExport.Size = new System.Drawing.Size(106, 32);
            this.cmdMenuExport.TabIndex = 6;
            this.cmdMenuExport.Text = "EXPORT";
            this.cmdMenuExport.UseVisualStyleBackColor = false;
            this.cmdMenuExport.Click += new System.EventHandler(this.cmdMenuExport_Click);
            // 
            // cmdMenuOptions
            // 
            this.cmdMenuOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuOptions.Enabled = false;
            this.cmdMenuOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuOptions.FlatAppearance.BorderSize = 0;
            this.cmdMenuOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuOptions.Location = new System.Drawing.Point(648, 0);
            this.cmdMenuOptions.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuOptions.Name = "cmdMenuOptions";
            this.cmdMenuOptions.Size = new System.Drawing.Size(113, 32);
            this.cmdMenuOptions.TabIndex = 8;
            this.cmdMenuOptions.Text = "OPTIONS";
            this.cmdMenuOptions.UseVisualStyleBackColor = false;
            this.cmdMenuOptions.Click += new System.EventHandler(this.cmdMenuOptions_Click);
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
            this.cmdMenuPatch.Location = new System.Drawing.Point(540, 0);
            this.cmdMenuPatch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuPatch.Name = "cmdMenuPatch";
            this.cmdMenuPatch.Size = new System.Drawing.Size(106, 32);
            this.cmdMenuPatch.TabIndex = 7;
            this.cmdMenuPatch.Text = "PATCH";
            this.cmdMenuPatch.UseVisualStyleBackColor = false;
            this.cmdMenuPatch.Click += new System.EventHandler(this.cmdMenuPatch_Click);
            // 
            // cmdMenuReload
            // 
            this.cmdMenuReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuReload.Enabled = false;
            this.cmdMenuReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuReload.FlatAppearance.BorderSize = 0;
            this.cmdMenuReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuReload.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMenuReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdMenuReload.Location = new System.Drawing.Point(324, 0);
            this.cmdMenuReload.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuReload.Name = "cmdMenuReload";
            this.cmdMenuReload.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdMenuReload.Size = new System.Drawing.Size(106, 32);
            this.cmdMenuReload.TabIndex = 4;
            this.cmdMenuReload.Text = "RELOAD";
            this.cmdMenuReload.UseVisualStyleBackColor = false;
            this.cmdMenuReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(0, 0);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(761, 1);
            this.pnlSeperator.TabIndex = 94;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(50, 0);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(611, 50);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "EFIROM";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.logo32px;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 9);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(32, 32);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 1;
            this.pbxLogo.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.ColumnCount = 4;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.lblWindowTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 3, 0);
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdMinimize, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(761, 50);
            this.tlpTitle.TabIndex = 0;
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
            this.cmsCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
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
            this.configCodeToolStripMenuItem,
            this.fsysCRC32ToolStripMenuItem,
            this.serialToolStripMenuItem,
            this.hwcToolStripMenuItem,
            this.orderNoToolStripMenuItem,
            this.efiVersionToolStripMenuItem,
            this.boardIDToolStripMenuItem,
            this.fitVersionToolStripMenuItem,
            this.meVersionToolStripMenuItem,
            this.toolStripSeparator5,
            this.pdrBaseToolStripMenuItem,
            this.meBaseToolStripMenuItem,
            this.biosBaseToolStripMenuItem});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.ShowImageMargin = false;
            this.cmsCopy.Size = new System.Drawing.Size(208, 520);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // sizeBytesToolStripMenuItem
            // 
            this.sizeBytesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeBytesToolStripMenuItem.Name = "sizeBytesToolStripMenuItem";
            this.sizeBytesToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.sizeBytesToolStripMenuItem.Text = "Size";
            this.sizeBytesToolStripMenuItem.Click += new System.EventHandler(this.sizeBytesToolStripMenuItem_Click);
            // 
            // crc32ToolStripMenuItem
            // 
            this.crc32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.crc32ToolStripMenuItem.Name = "crc32ToolStripMenuItem";
            this.crc32ToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.crc32ToolStripMenuItem.Text = "CRC32";
            this.crc32ToolStripMenuItem.Click += new System.EventHandler(this.crc32ToolStripMenuItem_Click);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.createdDateToolStripMenuItem.Text = "Creation Date";
            this.createdDateToolStripMenuItem.Click += new System.EventHandler(this.createdDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(204, 6);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // configCodeToolStripMenuItem
            // 
            this.configCodeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.configCodeToolStripMenuItem.Name = "configCodeToolStripMenuItem";
            this.configCodeToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.configCodeToolStripMenuItem.Text = "Config Code";
            this.configCodeToolStripMenuItem.Click += new System.EventHandler(this.configCodeToolStripMenuItem_Click);
            // 
            // fsysCRC32ToolStripMenuItem
            // 
            this.fsysCRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fsysCRC32ToolStripMenuItem.Name = "fsysCRC32ToolStripMenuItem";
            this.fsysCRC32ToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.fsysCRC32ToolStripMenuItem.Text = "Fsys CRC32";
            this.fsysCRC32ToolStripMenuItem.Click += new System.EventHandler(this.fsysCRC32ToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // hwcToolStripMenuItem
            // 
            this.hwcToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hwcToolStripMenuItem.Name = "hwcToolStripMenuItem";
            this.hwcToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.hwcToolStripMenuItem.Text = "HWC";
            this.hwcToolStripMenuItem.Click += new System.EventHandler(this.hwcToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
            // 
            // efiVersionToolStripMenuItem
            // 
            this.efiVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.efiVersionToolStripMenuItem.Name = "efiVersionToolStripMenuItem";
            this.efiVersionToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.efiVersionToolStripMenuItem.Text = "EFI Version";
            this.efiVersionToolStripMenuItem.Click += new System.EventHandler(this.efiVersionToolStripMenuItem_Click);
            // 
            // boardIDToolStripMenuItem
            // 
            this.boardIDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.boardIDToolStripMenuItem.Name = "boardIDToolStripMenuItem";
            this.boardIDToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.boardIDToolStripMenuItem.Text = "Board ID";
            this.boardIDToolStripMenuItem.Click += new System.EventHandler(this.boardIDToolStripMenuItem_Click);
            // 
            // fitVersionToolStripMenuItem
            // 
            this.fitVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fitVersionToolStripMenuItem.Name = "fitVersionToolStripMenuItem";
            this.fitVersionToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.fitVersionToolStripMenuItem.Text = "FIT Version";
            this.fitVersionToolStripMenuItem.Click += new System.EventHandler(this.fitVersionToolStripMenuItem_Click);
            // 
            // meVersionToolStripMenuItem
            // 
            this.meVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meVersionToolStripMenuItem.Name = "meVersionToolStripMenuItem";
            this.meVersionToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.meVersionToolStripMenuItem.Text = "ME Version";
            this.meVersionToolStripMenuItem.Click += new System.EventHandler(this.meVersionToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(204, 6);
            // 
            // pdrBaseToolStripMenuItem
            // 
            this.pdrBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pdrBaseToolStripMenuItem.Name = "pdrBaseToolStripMenuItem";
            this.pdrBaseToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.pdrBaseToolStripMenuItem.Text = "PDR Region Offsets";
            this.pdrBaseToolStripMenuItem.Click += new System.EventHandler(this.pdrBaseToolStripMenuItem_Click);
            // 
            // meBaseToolStripMenuItem
            // 
            this.meBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meBaseToolStripMenuItem.Name = "meBaseToolStripMenuItem";
            this.meBaseToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.meBaseToolStripMenuItem.Text = "ME Region Offsets";
            this.meBaseToolStripMenuItem.Click += new System.EventHandler(this.meBaseToolStripMenuItem_Click);
            // 
            // biosBaseToolStripMenuItem
            // 
            this.biosBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.biosBaseToolStripMenuItem.Name = "biosBaseToolStripMenuItem";
            this.biosBaseToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.biosBaseToolStripMenuItem.Text = "BIOS Region Offsets";
            this.biosBaseToolStripMenuItem.Click += new System.EventHandler(this.biosBaseToolStripMenuItem_Click);
            // 
            // cmsOptions
            // 
            this.cmsOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmsOptions.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsOptions.ForeColor = System.Drawing.Color.White;
            this.cmsOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticFilenameGenerationToolStripMenuItem,
            this.viewRomInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.lookupSerialNumberOnEveryMacToolStripMenuItem});
            this.cmsOptions.Name = "cmdOptions";
            this.cmsOptions.ShowImageMargin = false;
            this.cmsOptions.Size = new System.Drawing.Size(313, 94);
            // 
            // automaticFilenameGenerationToolStripMenuItem
            // 
            this.automaticFilenameGenerationToolStripMenuItem.Name = "automaticFilenameGenerationToolStripMenuItem";
            this.automaticFilenameGenerationToolStripMenuItem.Size = new System.Drawing.Size(312, 28);
            this.automaticFilenameGenerationToolStripMenuItem.Text = "Automatic Filename Generation";
            this.automaticFilenameGenerationToolStripMenuItem.Click += new System.EventHandler(this.automaticFilenameGenerationToolStripMenuItem_Click);
            // 
            // viewRomInformationToolStripMenuItem
            // 
            this.viewRomInformationToolStripMenuItem.Name = "viewRomInformationToolStripMenuItem";
            this.viewRomInformationToolStripMenuItem.Size = new System.Drawing.Size(312, 28);
            this.viewRomInformationToolStripMenuItem.Text = "View ROM Information";
            this.viewRomInformationToolStripMenuItem.Click += new System.EventHandler(this.viewRomInformationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(309, 6);
            // 
            // lookupSerialNumberOnEveryMacToolStripMenuItem
            // 
            this.lookupSerialNumberOnEveryMacToolStripMenuItem.Name = "lookupSerialNumberOnEveryMacToolStripMenuItem";
            this.lookupSerialNumberOnEveryMacToolStripMenuItem.Size = new System.Drawing.Size(312, 28);
            this.lookupSerialNumberOnEveryMacToolStripMenuItem.Text = "Lookup Serial Number (EveryMac)";
            this.lookupSerialNumberOnEveryMacToolStripMenuItem.Click += new System.EventHandler(this.lookupSerialNumberOnEveryMacToolStripMenuItem_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmsExport.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsExport.ForeColor = System.Drawing.Color.White;
            this.cmsExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFsysStoreToolStripMenuItem,
            this.exportIntelMERegionToolStripMenuItem,
            this.exportNVRAMSVSStoresToolStripMenuItem,
            this.exportNVRAMVSSStoresToolStripMenuItem,
            this.toolStripSeparator3,
            this.backupFirmwareZIPToolStripMenuItem,
            this.exportFirmwareInformationTextToolStripMenuItem});
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.ShowImageMargin = false;
            this.cmsExport.Size = new System.Drawing.Size(319, 178);
            // 
            // exportFsysStoreToolStripMenuItem
            // 
            this.exportFsysStoreToolStripMenuItem.Name = "exportFsysStoreToolStripMenuItem";
            this.exportFsysStoreToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportFsysStoreToolStripMenuItem.Text = "Export Fsys Store";
            this.exportFsysStoreToolStripMenuItem.Click += new System.EventHandler(this.exportFsysStoreToolStripMenuItem_Click);
            // 
            // exportIntelMERegionToolStripMenuItem
            // 
            this.exportIntelMERegionToolStripMenuItem.Name = "exportIntelMERegionToolStripMenuItem";
            this.exportIntelMERegionToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportIntelMERegionToolStripMenuItem.Text = "Export Intel ME Region";
            this.exportIntelMERegionToolStripMenuItem.Click += new System.EventHandler(this.exportIntelMERegionToolStripMenuItem_Click);
            // 
            // exportNVRAMSVSStoresToolStripMenuItem
            // 
            this.exportNVRAMSVSStoresToolStripMenuItem.Name = "exportNVRAMSVSStoresToolStripMenuItem";
            this.exportNVRAMSVSStoresToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportNVRAMSVSStoresToolStripMenuItem.Text = "Export NVRAM SVS Stores";
            // 
            // exportNVRAMVSSStoresToolStripMenuItem
            // 
            this.exportNVRAMVSSStoresToolStripMenuItem.Name = "exportNVRAMVSSStoresToolStripMenuItem";
            this.exportNVRAMVSSStoresToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportNVRAMVSSStoresToolStripMenuItem.Text = "Export NVRAM VSS Stores";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(315, 6);
            // 
            // backupFirmwareZIPToolStripMenuItem
            // 
            this.backupFirmwareZIPToolStripMenuItem.Name = "backupFirmwareZIPToolStripMenuItem";
            this.backupFirmwareZIPToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.backupFirmwareZIPToolStripMenuItem.Text = "Backup Firmware (ZIP)";
            this.backupFirmwareZIPToolStripMenuItem.Click += new System.EventHandler(this.backupFirmwareZIPToolStripMenuItem_Click);
            // 
            // exportFirmwareInformationTextToolStripMenuItem
            // 
            this.exportFirmwareInformationTextToolStripMenuItem.Name = "exportFirmwareInformationTextToolStripMenuItem";
            this.exportFirmwareInformationTextToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportFirmwareInformationTextToolStripMenuItem.Text = "Export Firmware Information (Text)";
            this.exportFirmwareInformationTextToolStripMenuItem.Click += new System.EventHandler(this.exportFirmwareInformationTextToolStripMenuItem_Click);
            // 
            // cmsPatch
            // 
            this.cmsPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmsPatch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsPatch.ForeColor = System.Drawing.Color.White;
            this.cmsPatch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSerialNumberToolStripMenuItem,
            this.replaceFsysStoreToolStripMenuItem,
            this.resetNVRAMToolStripMenuItem,
            this.toolStripSeparator2,
            this.fixFsysChecksumCRC32ToolStripMenuItem,
            this.invalidateEFILockToolStripMenuItem});
            this.cmsPatch.Name = "cmsPatch";
            this.cmsPatch.ShowImageMargin = false;
            this.cmsPatch.Size = new System.Drawing.Size(259, 150);
            // 
            // changeSerialNumberToolStripMenuItem
            // 
            this.changeSerialNumberToolStripMenuItem.Name = "changeSerialNumberToolStripMenuItem";
            this.changeSerialNumberToolStripMenuItem.Size = new System.Drawing.Size(258, 28);
            this.changeSerialNumberToolStripMenuItem.Text = "Change Serial Number";
            // 
            // replaceFsysStoreToolStripMenuItem
            // 
            this.replaceFsysStoreToolStripMenuItem.Name = "replaceFsysStoreToolStripMenuItem";
            this.replaceFsysStoreToolStripMenuItem.Size = new System.Drawing.Size(258, 28);
            this.replaceFsysStoreToolStripMenuItem.Text = "Replace Fsys Store";
            // 
            // resetNVRAMToolStripMenuItem
            // 
            this.resetNVRAMToolStripMenuItem.Name = "resetNVRAMToolStripMenuItem";
            this.resetNVRAMToolStripMenuItem.Size = new System.Drawing.Size(258, 28);
            this.resetNVRAMToolStripMenuItem.Text = "Reset NVRAM";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // fixFsysChecksumCRC32ToolStripMenuItem
            // 
            this.fixFsysChecksumCRC32ToolStripMenuItem.Name = "fixFsysChecksumCRC32ToolStripMenuItem";
            this.fixFsysChecksumCRC32ToolStripMenuItem.Size = new System.Drawing.Size(258, 28);
            this.fixFsysChecksumCRC32ToolStripMenuItem.Text = "Fix Fsys Checksum (CRC32)";
            this.fixFsysChecksumCRC32ToolStripMenuItem.Click += new System.EventHandler(this.fixFsysChecksumCRC32ToolStripMenuItem_Click);
            // 
            // invalidateEFILockToolStripMenuItem
            // 
            this.invalidateEFILockToolStripMenuItem.Name = "invalidateEFILockToolStripMenuItem";
            this.invalidateEFILockToolStripMenuItem.Size = new System.Drawing.Size(258, 28);
            this.invalidateEFILockToolStripMenuItem.Text = "Invalidate EFI Lock";
            this.invalidateEFILockToolStripMenuItem.Click += new System.EventHandler(this.invalidateEFILockToolStripMenuItem_Click);
            // 
            // efiWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(763, 447);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(763, 447);
            this.Name = "efiWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EFIROM";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpFilename.ResumeLayout(false);
            this.tlpFirmware.ResumeLayout(false);
            this.tlpEfiVer.ResumeLayout(false);
            this.tlpFsys.ResumeLayout(false);
            this.tlpNvram.ResumeLayout(false);
            this.tlpIntelMe.ResumeLayout(false);
            this.tlpEfiLock.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.tlpStatusBar.PerformLayout();
            this.tlpStatusBarImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpTitle.ResumeLayout(false);
            this.cmsCopy.ResumeLayout(false);
            this.cmsOptions.ResumeLayout(false);
            this.cmsExport.ResumeLayout(false);
            this.cmsPatch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFileCrc32Text;
        private System.Windows.Forms.Label lblFilesizeText;
        private System.Windows.Forms.Label lblFileCrc32;
        private METLabel lblFilesize;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblSerialNumberText;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.Label lblBoardIdText;
        private System.Windows.Forms.Button cmdMenuOpen;
        internal System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Label lblFsysStoreText;
        private System.Windows.Forms.Label lblOrderNumberText;
        private System.Windows.Forms.Label lblFsysCrc32;
        private System.Windows.Forms.Label lblApfsCapable;
        private System.Windows.Forms.Label lblApfsCapableText;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.Label lblVssStore;
        private System.Windows.Forms.Label lblNvramText;
        private System.Windows.Forms.Label lblEfiVersionText;
        private System.Windows.Forms.Button cmdMenuReset;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.Label lblMeVersionText;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.TableLayoutPanel tlpFsys;
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
        private System.Windows.Forms.Button cmdMenuReload;
        private System.Windows.Forms.TableLayoutPanel tlpFirmware;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.Button cmdOpenInExplorer;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TableLayoutPanel tlpEfiVer;
        private System.Windows.Forms.Label lblEfiVersion;
        private System.Windows.Forms.PictureBox pbxLoad;
        private METLabel lblFilename;
        private System.Windows.Forms.Label lblMeVersion;
        private System.Windows.Forms.TableLayoutPanel tlpNvram;
        private System.Windows.Forms.Label lblSvsStore;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hwcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsysCRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efiVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderNoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpIntelMe;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdMinimize;
        private METContextMenuStrip cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configCodeToolStripMenuItem;
        private System.Windows.Forms.Label lblEfiLockText;
        private System.Windows.Forms.TableLayoutPanel tlpEfiLock;
        private System.Windows.Forms.Label lblEfiLock;
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
        internal System.Windows.Forms.Button cmdMenuOptions;
        internal System.Windows.Forms.Button cmdMenuExport;
        private METContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem automaticFilenameGenerationToolStripMenuItem;
        internal System.Windows.Forms.Button cmdMenuPatch;
        private METContextMenuStrip cmsExport;
        private System.Windows.Forms.ToolStripMenuItem exportFsysStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportIntelMERegionToolStripMenuItem;
        private METContextMenuStrip cmsPatch;
        private System.Windows.Forms.ToolStripMenuItem replaceFsysStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lookupSerialNumberOnEveryMacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSerialNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetNVRAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRomInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fixFsysChecksumCRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invalidateEFILockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNVRAMSVSStoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNVRAMVSSStoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportFirmwareInformationTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupFirmwareZIPToolStripMenuItem;
    }
}