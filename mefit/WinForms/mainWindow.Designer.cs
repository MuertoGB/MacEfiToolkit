
using Mac_EFI_Toolkit.UI;

namespace Mac_EFI_Toolkit
{
    partial class mainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrivateMemory = new System.Windows.Forms.Label();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new METLabel();
            this.cmdNavigate = new System.Windows.Forms.Button();
            this.cmdReload = new System.Windows.Forms.Button();
            this.cmdBackupToZip = new System.Windows.Forms.Button();
            this.tlpFile = new System.Windows.Forms.TableLayoutPanel();
            this.lblFileCreatedDate = new System.Windows.Forms.Label();
            this.lblFileModifiedDate = new System.Windows.Forms.Label();
            this.lblFileCrc = new System.Windows.Forms.Label();
            this.lblCreatedText = new System.Windows.Forms.Label();
            this.lblFileSizeBytes = new System.Windows.Forms.Label();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.lblSizeBytesText = new System.Windows.Forms.Label();
            this.lblChecksumText = new System.Windows.Forms.Label();
            this.tlpRom = new System.Windows.Forms.TableLayoutPanel();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.lblEfiVersionText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.tlpEfiVer = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.cmdAppleRomInfo = new System.Windows.Forms.Button();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.lblFsysCrc = new System.Windows.Forms.Label();
            this.cmdFixFsysCrc = new System.Windows.Forms.Button();
            this.cmdExportFsys = new System.Windows.Forms.Button();
            this.tlpNvram = new System.Windows.Forms.TableLayoutPanel();
            this.lblNssStore = new System.Windows.Forms.Label();
            this.lblSvsStore = new System.Windows.Forms.Label();
            this.lblVssStore = new System.Windows.Forms.Label();
            this.lblSonText = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblMeVersionText = new System.Windows.Forms.Label();
            this.tlpIntelMe = new System.Windows.Forms.TableLayoutPanel();
            this.lblMeVersion = new System.Windows.Forms.Label();
            this.cmdExportMe = new System.Windows.Forms.Button();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.lblBoardIdText = new System.Windows.Forms.Label();
            this.lblEfiLockText = new System.Windows.Forms.Label();
            this.lblApfsCapable = new System.Windows.Forms.Label();
            this.lblApfsCapableText = new System.Windows.Forms.Label();
            this.tlpEfiLock = new System.Windows.Forms.TableLayoutPanel();
            this.cmdInvalidateEfiLock = new System.Windows.Forms.Button();
            this.lblEfiLockStatus = new System.Windows.Forms.Label();
            this.lblHwc = new System.Windows.Forms.Label();
            this.lblFsysStoreText = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEveryMacSearch = new System.Windows.Forms.Button();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.tlpModel = new System.Windows.Forms.TableLayoutPanel();
            this.lblModel = new System.Windows.Forms.Label();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cmdPatch = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pbxTitleLogo = new System.Windows.Forms.PictureBox();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenuSeperator1 = new System.Windows.Forms.Panel();
            this.cmdCopyMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdMore = new System.Windows.Forms.Button();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMin = new System.Windows.Forms.Button();
            this.tlpVersionLabel = new System.Windows.Forms.TableLayoutPanel();
            this.cmsMainMenu = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.openLocalFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupsDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBuildsDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFsysStoresDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMeRegionDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createADebugLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsApplication = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsClipboard = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.filenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crc32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hwcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsysCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efiVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pdrBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biosBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpFilename.SuspendLayout();
            this.tlpFile.SuspendLayout();
            this.tlpRom.SuspendLayout();
            this.tlpEfiVer.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.tlpNvram.SuspendLayout();
            this.tlpIntelMe.SuspendLayout();
            this.tlpEfiLock.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpVersionLabel.SuspendLayout();
            this.cmsMainMenu.SuspendLayout();
            this.cmsApplication.SuspendLayout();
            this.cmsClipboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpStatusBar);
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Controls.Add(this.pnlSeperator);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 89);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(713, 330);
            this.pnlMain.TabIndex = 2;
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpStatusBar.ColumnCount = 4;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpStatusBar.Controls.Add(this.lblPrivateMemory, 3, 0);
            this.tlpStatusBar.Controls.Add(this.tlpStatusBarImage, 1, 0);
            this.tlpStatusBar.Controls.Add(this.lblMessage, 0, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 294);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(713, 36);
            this.tlpStatusBar.TabIndex = 99;
            // 
            // lblPrivateMemory
            // 
            this.lblPrivateMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPrivateMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrivateMemory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateMemory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblPrivateMemory.Location = new System.Drawing.Point(623, 0);
            this.lblPrivateMemory.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrivateMemory.Name = "lblPrivateMemory";
            this.lblPrivateMemory.Size = new System.Drawing.Size(90, 36);
            this.lblPrivateMemory.TabIndex = 99;
            this.lblPrivateMemory.Text = "...";
            this.lblPrivateMemory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpStatusBarImage
            // 
            this.tlpStatusBarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBarImage.ColumnCount = 1;
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBarImage.Controls.Add(this.pbxLoad, 0, 0);
            this.tlpStatusBarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBarImage.Location = new System.Drawing.Point(586, 0);
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
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblMessage.Size = new System.Drawing.Size(586, 36);
            this.lblMessage.TabIndex = 99;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpFilename, 0, 0);
            this.tlpMain.Controls.Add(this.tlpFile, 0, 2);
            this.tlpMain.Controls.Add(this.tlpRom, 0, 6);
            this.tlpMain.Controls.Add(this.tlpModel, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Enabled = false;
            this.tlpMain.Location = new System.Drawing.Point(0, 2);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 8;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(713, 292);
            this.tlpMain.TabIndex = 2;
            // 
            // tlpFilename
            // 
            this.tlpFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpFilename.ColumnCount = 7;
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.Controls.Add(this.lblFilename, 0, 0);
            this.tlpFilename.Controls.Add(this.cmdNavigate, 2, 0);
            this.tlpFilename.Controls.Add(this.cmdReload, 4, 0);
            this.tlpFilename.Controls.Add(this.cmdBackupToZip, 6, 0);
            this.tlpFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilename.Location = new System.Drawing.Point(0, 0);
            this.tlpFilename.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFilename.Name = "tlpFilename";
            this.tlpFilename.RowCount = 1;
            this.tlpFilename.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.Size = new System.Drawing.Size(713, 36);
            this.tlpFilename.TabIndex = 0;
            // 
            // lblFilename
            // 
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(0, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(602, 36);
            this.lblFilename.TabIndex = 6;
            // 
            // cmdNavigate
            // 
            this.cmdNavigate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdNavigate.Enabled = false;
            this.cmdNavigate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.FlatAppearance.BorderSize = 2;
            this.cmdNavigate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNavigate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNavigate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdNavigate.Location = new System.Drawing.Point(603, 0);
            this.cmdNavigate.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNavigate.Name = "cmdNavigate";
            this.cmdNavigate.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdNavigate.Size = new System.Drawing.Size(36, 36);
            this.cmdNavigate.TabIndex = 0;
            this.cmdNavigate.Text = "N";
            this.cmdNavigate.UseVisualStyleBackColor = false;
            this.cmdNavigate.Click += new System.EventHandler(this.cmdNavigate_Click);
            // 
            // cmdReload
            // 
            this.cmdReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReload.Enabled = false;
            this.cmdReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.FlatAppearance.BorderSize = 2;
            this.cmdReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdReload.Location = new System.Drawing.Point(640, 0);
            this.cmdReload.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdReload.Size = new System.Drawing.Size(36, 36);
            this.cmdReload.TabIndex = 1;
            this.cmdReload.Text = "R";
            this.cmdReload.UseVisualStyleBackColor = false;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // cmdBackupToZip
            // 
            this.cmdBackupToZip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdBackupToZip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdBackupToZip.Enabled = false;
            this.cmdBackupToZip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdBackupToZip.FlatAppearance.BorderSize = 2;
            this.cmdBackupToZip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdBackupToZip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdBackupToZip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBackupToZip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBackupToZip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdBackupToZip.Location = new System.Drawing.Point(677, 0);
            this.cmdBackupToZip.Margin = new System.Windows.Forms.Padding(0);
            this.cmdBackupToZip.Name = "cmdBackupToZip";
            this.cmdBackupToZip.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cmdBackupToZip.Size = new System.Drawing.Size(36, 36);
            this.cmdBackupToZip.TabIndex = 2;
            this.cmdBackupToZip.Text = "A";
            this.cmdBackupToZip.UseVisualStyleBackColor = false;
            this.cmdBackupToZip.Click += new System.EventHandler(this.cmdBackupToZip_Click);
            // 
            // tlpFile
            // 
            this.tlpFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpFile.ColumnCount = 7;
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFile.Controls.Add(this.lblFileCreatedDate, 2, 2);
            this.tlpFile.Controls.Add(this.lblFileModifiedDate, 6, 2);
            this.tlpFile.Controls.Add(this.lblFileCrc, 6, 0);
            this.tlpFile.Controls.Add(this.lblCreatedText, 0, 2);
            this.tlpFile.Controls.Add(this.lblFileSizeBytes, 2, 0);
            this.tlpFile.Controls.Add(this.lblModifiedText, 4, 2);
            this.tlpFile.Controls.Add(this.lblSizeBytesText, 0, 0);
            this.tlpFile.Controls.Add(this.lblChecksumText, 4, 0);
            this.tlpFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFile.Location = new System.Drawing.Point(0, 37);
            this.tlpFile.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFile.Name = "tlpFile";
            this.tlpFile.RowCount = 3;
            this.tlpFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFile.Size = new System.Drawing.Size(713, 61);
            this.tlpFile.TabIndex = 99;
            // 
            // lblFileCreatedDate
            // 
            this.lblFileCreatedDate.AutoEllipsis = true;
            this.lblFileCreatedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFileCreatedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCreatedDate.ForeColor = System.Drawing.Color.White;
            this.lblFileCreatedDate.Location = new System.Drawing.Point(131, 31);
            this.lblFileCreatedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCreatedDate.Name = "lblFileCreatedDate";
            this.lblFileCreatedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCreatedDate.Size = new System.Drawing.Size(225, 30);
            this.lblFileCreatedDate.TabIndex = 99;
            this.lblFileCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileModifiedDate
            // 
            this.lblFileModifiedDate.AutoEllipsis = true;
            this.lblFileModifiedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFileModifiedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileModifiedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileModifiedDate.ForeColor = System.Drawing.Color.White;
            this.lblFileModifiedDate.Location = new System.Drawing.Point(488, 31);
            this.lblFileModifiedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileModifiedDate.Name = "lblFileModifiedDate";
            this.lblFileModifiedDate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileModifiedDate.Size = new System.Drawing.Size(225, 30);
            this.lblFileModifiedDate.TabIndex = 99;
            this.lblFileModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileCrc
            // 
            this.lblFileCrc.AutoEllipsis = true;
            this.lblFileCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFileCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCrc.ForeColor = System.Drawing.Color.White;
            this.lblFileCrc.Location = new System.Drawing.Point(488, 0);
            this.lblFileCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileCrc.Name = "lblFileCrc";
            this.lblFileCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileCrc.Size = new System.Drawing.Size(225, 30);
            this.lblFileCrc.TabIndex = 99;
            this.lblFileCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedText
            // 
            this.lblCreatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblCreatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCreatedText.Location = new System.Drawing.Point(0, 31);
            this.lblCreatedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreatedText.Name = "lblCreatedText";
            this.lblCreatedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCreatedText.Size = new System.Drawing.Size(130, 30);
            this.lblCreatedText.TabIndex = 99;
            this.lblCreatedText.Text = "Created:";
            this.lblCreatedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileSizeBytes
            // 
            this.lblFileSizeBytes.AutoEllipsis = true;
            this.lblFileSizeBytes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFileSizeBytes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileSizeBytes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSizeBytes.ForeColor = System.Drawing.Color.White;
            this.lblFileSizeBytes.Location = new System.Drawing.Point(131, 0);
            this.lblFileSizeBytes.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileSizeBytes.Name = "lblFileSizeBytes";
            this.lblFileSizeBytes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileSizeBytes.Size = new System.Drawing.Size(225, 30);
            this.lblFileSizeBytes.TabIndex = 99;
            this.lblFileSizeBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedText
            // 
            this.lblModifiedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblModifiedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModifiedText.Location = new System.Drawing.Point(357, 31);
            this.lblModifiedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModifiedText.Name = "lblModifiedText";
            this.lblModifiedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModifiedText.Size = new System.Drawing.Size(130, 30);
            this.lblModifiedText.TabIndex = 99;
            this.lblModifiedText.Text = "Modified:";
            this.lblModifiedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSizeBytesText
            // 
            this.lblSizeBytesText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSizeBytesText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSizeBytesText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeBytesText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSizeBytesText.Location = new System.Drawing.Point(0, 0);
            this.lblSizeBytesText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSizeBytesText.Name = "lblSizeBytesText";
            this.lblSizeBytesText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSizeBytesText.Size = new System.Drawing.Size(130, 30);
            this.lblSizeBytesText.TabIndex = 99;
            this.lblSizeBytesText.Text = "Size (Bytes):";
            this.lblSizeBytesText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChecksumText
            // 
            this.lblChecksumText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblChecksumText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChecksumText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecksumText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblChecksumText.Location = new System.Drawing.Point(357, 0);
            this.lblChecksumText.Margin = new System.Windows.Forms.Padding(0);
            this.lblChecksumText.Name = "lblChecksumText";
            this.lblChecksumText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblChecksumText.Size = new System.Drawing.Size(130, 30);
            this.lblChecksumText.TabIndex = 99;
            this.lblChecksumText.Text = "CRC32:";
            this.lblChecksumText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpRom
            // 
            this.tlpRom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpRom.ColumnCount = 7;
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRom.Controls.Add(this.lblNvramText, 4, 4);
            this.tlpRom.Controls.Add(this.lblEfiVersionText, 0, 4);
            this.tlpRom.Controls.Add(this.lblSerialText, 4, 0);
            this.tlpRom.Controls.Add(this.lblHwcText, 0, 2);
            this.tlpRom.Controls.Add(this.tlpEfiVer, 2, 4);
            this.tlpRom.Controls.Add(this.tlpFsys, 2, 0);
            this.tlpRom.Controls.Add(this.tlpNvram, 6, 4);
            this.tlpRom.Controls.Add(this.lblSonText, 4, 2);
            this.tlpRom.Controls.Add(this.lblOrderNo, 6, 2);
            this.tlpRom.Controls.Add(this.lblMeVersionText, 4, 8);
            this.tlpRom.Controls.Add(this.tlpIntelMe, 6, 8);
            this.tlpRom.Controls.Add(this.lblBoardId, 6, 6);
            this.tlpRom.Controls.Add(this.lblBoardIdText, 4, 6);
            this.tlpRom.Controls.Add(this.lblEfiLockText, 0, 6);
            this.tlpRom.Controls.Add(this.lblApfsCapable, 2, 8);
            this.tlpRom.Controls.Add(this.lblApfsCapableText, 0, 8);
            this.tlpRom.Controls.Add(this.tlpEfiLock, 2, 6);
            this.tlpRom.Controls.Add(this.lblHwc, 2, 2);
            this.tlpRom.Controls.Add(this.lblFsysStoreText, 0, 0);
            this.tlpRom.Controls.Add(this.tlpSerial, 6, 0);
            this.tlpRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRom.Location = new System.Drawing.Point(0, 136);
            this.tlpRom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRom.Name = "tlpRom";
            this.tlpRom.RowCount = 9;
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRom.Size = new System.Drawing.Size(713, 154);
            this.tlpRom.TabIndex = 2;
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblNvramText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNvramText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNvramText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblNvramText.Location = new System.Drawing.Point(357, 62);
            this.lblNvramText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNvramText.Name = "lblNvramText";
            this.lblNvramText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblNvramText.Size = new System.Drawing.Size(130, 30);
            this.lblNvramText.TabIndex = 99;
            this.lblNvramText.Text = "NVRAM:";
            this.lblNvramText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiVersionText
            // 
            this.lblEfiVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblEfiVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiVersionText.Location = new System.Drawing.Point(0, 62);
            this.lblEfiVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersionText.Name = "lblEfiVersionText";
            this.lblEfiVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblEfiVersionText.TabIndex = 99;
            this.lblEfiVersionText.Text = "EFI Version:";
            this.lblEfiVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(357, 0);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 30);
            this.lblSerialText.TabIndex = 99;
            this.lblSerialText.Text = "Serial:";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwcText
            // 
            this.lblHwcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblHwcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(0, 31);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblHwcText.Size = new System.Drawing.Size(130, 30);
            this.lblHwcText.TabIndex = 99;
            this.lblHwcText.Text = "HWC:";
            this.lblHwcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfiVer
            // 
            this.tlpEfiVer.ColumnCount = 3;
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfiVer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEfiVer.Controls.Add(this.lblEfiVersion, 0, 0);
            this.tlpEfiVer.Controls.Add(this.cmdAppleRomInfo, 2, 0);
            this.tlpEfiVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiVer.Location = new System.Drawing.Point(131, 62);
            this.tlpEfiVer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiVer.Name = "tlpEfiVer";
            this.tlpEfiVer.RowCount = 1;
            this.tlpEfiVer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiVer.Size = new System.Drawing.Size(225, 30);
            this.tlpEfiVer.TabIndex = 1;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersion.ForeColor = System.Drawing.Color.White;
            this.lblEfiVersion.Location = new System.Drawing.Point(0, 0);
            this.lblEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersion.Name = "lblEfiVersion";
            this.lblEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiVersion.Size = new System.Drawing.Size(194, 30);
            this.lblEfiVersion.TabIndex = 100;
            this.lblEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdAppleRomInfo
            // 
            this.cmdAppleRomInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdAppleRomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAppleRomInfo.Enabled = false;
            this.cmdAppleRomInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdAppleRomInfo.FlatAppearance.BorderSize = 2;
            this.cmdAppleRomInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdAppleRomInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdAppleRomInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAppleRomInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAppleRomInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdAppleRomInfo.Location = new System.Drawing.Point(195, 0);
            this.cmdAppleRomInfo.Margin = new System.Windows.Forms.Padding(0);
            this.cmdAppleRomInfo.Name = "cmdAppleRomInfo";
            this.cmdAppleRomInfo.Size = new System.Drawing.Size(30, 30);
            this.cmdAppleRomInfo.TabIndex = 0;
            this.cmdAppleRomInfo.Text = "I";
            this.cmdAppleRomInfo.UseVisualStyleBackColor = false;
            this.cmdAppleRomInfo.Click += new System.EventHandler(this.cmdAppleRomInfo_Click);
            // 
            // tlpFsys
            // 
            this.tlpFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpFsys.ColumnCount = 5;
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFsys.Controls.Add(this.lblFsysCrc, 0, 0);
            this.tlpFsys.Controls.Add(this.cmdFixFsysCrc, 2, 0);
            this.tlpFsys.Controls.Add(this.cmdExportFsys, 4, 0);
            this.tlpFsys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFsys.Location = new System.Drawing.Point(131, 0);
            this.tlpFsys.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsys.Name = "tlpFsys";
            this.tlpFsys.RowCount = 1;
            this.tlpFsys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.Size = new System.Drawing.Size(225, 30);
            this.tlpFsys.TabIndex = 0;
            // 
            // lblFsysCrc
            // 
            this.lblFsysCrc.AutoEllipsis = true;
            this.lblFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFsysCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysCrc.ForeColor = System.Drawing.Color.White;
            this.lblFsysCrc.Location = new System.Drawing.Point(0, 0);
            this.lblFsysCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysCrc.Name = "lblFsysCrc";
            this.lblFsysCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFsysCrc.Size = new System.Drawing.Size(163, 30);
            this.lblFsysCrc.TabIndex = 15;
            this.lblFsysCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdFixFsysCrc
            // 
            this.cmdFixFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdFixFsysCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFixFsysCrc.Enabled = false;
            this.cmdFixFsysCrc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdFixFsysCrc.FlatAppearance.BorderSize = 2;
            this.cmdFixFsysCrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdFixFsysCrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdFixFsysCrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFixFsysCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFixFsysCrc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdFixFsysCrc.Location = new System.Drawing.Point(164, 0);
            this.cmdFixFsysCrc.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFixFsysCrc.Name = "cmdFixFsysCrc";
            this.cmdFixFsysCrc.Size = new System.Drawing.Size(30, 30);
            this.cmdFixFsysCrc.TabIndex = 0;
            this.cmdFixFsysCrc.Text = "F";
            this.cmdFixFsysCrc.UseVisualStyleBackColor = false;
            this.cmdFixFsysCrc.Click += new System.EventHandler(this.cmdFixFsysCrc_Click);
            // 
            // cmdExportFsys
            // 
            this.cmdExportFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportFsys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportFsys.Enabled = false;
            this.cmdExportFsys.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportFsys.FlatAppearance.BorderSize = 2;
            this.cmdExportFsys.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportFsys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdExportFsys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportFsys.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportFsys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdExportFsys.Location = new System.Drawing.Point(195, 0);
            this.cmdExportFsys.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportFsys.Name = "cmdExportFsys";
            this.cmdExportFsys.Size = new System.Drawing.Size(30, 30);
            this.cmdExportFsys.TabIndex = 1;
            this.cmdExportFsys.Text = "E";
            this.cmdExportFsys.UseVisualStyleBackColor = false;
            this.cmdExportFsys.Click += new System.EventHandler(this.cmdExportFsys_Click);
            // 
            // tlpNvram
            // 
            this.tlpNvram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpNvram.ColumnCount = 5;
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNvram.Controls.Add(this.lblNssStore, 4, 0);
            this.tlpNvram.Controls.Add(this.lblSvsStore, 2, 0);
            this.tlpNvram.Controls.Add(this.lblVssStore, 0, 0);
            this.tlpNvram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNvram.Location = new System.Drawing.Point(488, 62);
            this.tlpNvram.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNvram.Name = "tlpNvram";
            this.tlpNvram.RowCount = 1;
            this.tlpNvram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNvram.Size = new System.Drawing.Size(225, 30);
            this.tlpNvram.TabIndex = 3;
            // 
            // lblNssStore
            // 
            this.lblNssStore.AutoEllipsis = true;
            this.lblNssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblNssStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssStore.ForeColor = System.Drawing.Color.White;
            this.lblNssStore.Location = new System.Drawing.Point(150, 0);
            this.lblNssStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblNssStore.Name = "lblNssStore";
            this.lblNssStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblNssStore.Size = new System.Drawing.Size(75, 30);
            this.lblNssStore.TabIndex = 100;
            this.lblNssStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSvsStore
            // 
            this.lblSvsStore.AutoEllipsis = true;
            this.lblSvsStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblSvsStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvsStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsStore.ForeColor = System.Drawing.Color.White;
            this.lblSvsStore.Location = new System.Drawing.Point(75, 0);
            this.lblSvsStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsStore.Name = "lblSvsStore";
            this.lblSvsStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSvsStore.Size = new System.Drawing.Size(74, 30);
            this.lblSvsStore.TabIndex = 100;
            this.lblSvsStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVssStore
            // 
            this.lblVssStore.AutoEllipsis = true;
            this.lblVssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblVssStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssStore.ForeColor = System.Drawing.Color.White;
            this.lblVssStore.Location = new System.Drawing.Point(0, 0);
            this.lblVssStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssStore.Name = "lblVssStore";
            this.lblVssStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblVssStore.Size = new System.Drawing.Size(74, 30);
            this.lblVssStore.TabIndex = 99;
            this.lblVssStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSonText
            // 
            this.lblSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSonText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSonText.Location = new System.Drawing.Point(357, 31);
            this.lblSonText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSonText.Name = "lblSonText";
            this.lblSonText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSonText.Size = new System.Drawing.Size(130, 30);
            this.lblSonText.TabIndex = 99;
            this.lblSonText.Text = "Order No:";
            this.lblSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoEllipsis = true;
            this.lblOrderNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(488, 31);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOrderNo.Size = new System.Drawing.Size(225, 30);
            this.lblOrderNo.TabIndex = 99;
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMeVersionText
            // 
            this.lblMeVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblMeVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblMeVersionText.Location = new System.Drawing.Point(357, 124);
            this.lblMeVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersionText.Name = "lblMeVersionText";
            this.lblMeVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblMeVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblMeVersionText.TabIndex = 99;
            this.lblMeVersionText.Text = "Intel ME:";
            this.lblMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpIntelMe
            // 
            this.tlpIntelMe.ColumnCount = 3;
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpIntelMe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpIntelMe.Controls.Add(this.lblMeVersion, 0, 0);
            this.tlpIntelMe.Controls.Add(this.cmdExportMe, 2, 0);
            this.tlpIntelMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIntelMe.Location = new System.Drawing.Point(488, 124);
            this.tlpIntelMe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIntelMe.Name = "tlpIntelMe";
            this.tlpIntelMe.RowCount = 1;
            this.tlpIntelMe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIntelMe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpIntelMe.Size = new System.Drawing.Size(225, 30);
            this.tlpIntelMe.TabIndex = 5;
            // 
            // lblMeVersion
            // 
            this.lblMeVersion.AutoEllipsis = true;
            this.lblMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblMeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersion.ForeColor = System.Drawing.Color.White;
            this.lblMeVersion.Location = new System.Drawing.Point(0, 0);
            this.lblMeVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersion.Name = "lblMeVersion";
            this.lblMeVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMeVersion.Size = new System.Drawing.Size(194, 30);
            this.lblMeVersion.TabIndex = 100;
            this.lblMeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdExportMe
            // 
            this.cmdExportMe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportMe.Enabled = false;
            this.cmdExportMe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportMe.FlatAppearance.BorderSize = 2;
            this.cmdExportMe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportMe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdExportMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportMe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdExportMe.Location = new System.Drawing.Point(195, 0);
            this.cmdExportMe.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportMe.Name = "cmdExportMe";
            this.cmdExportMe.Size = new System.Drawing.Size(30, 30);
            this.cmdExportMe.TabIndex = 101;
            this.cmdExportMe.Text = "M";
            this.cmdExportMe.UseVisualStyleBackColor = false;
            this.cmdExportMe.Click += new System.EventHandler(this.cmdExportMe_Click);
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoEllipsis = true;
            this.lblBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.White;
            this.lblBoardId.Location = new System.Drawing.Point(488, 93);
            this.lblBoardId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBoardId.Size = new System.Drawing.Size(225, 30);
            this.lblBoardId.TabIndex = 99;
            this.lblBoardId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoardIdText
            // 
            this.lblBoardIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblBoardIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardIdText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBoardIdText.Location = new System.Drawing.Point(357, 93);
            this.lblBoardIdText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardIdText.Name = "lblBoardIdText";
            this.lblBoardIdText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBoardIdText.Size = new System.Drawing.Size(130, 30);
            this.lblBoardIdText.TabIndex = 99;
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
            this.lblEfiLockText.Location = new System.Drawing.Point(0, 93);
            this.lblEfiLockText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLockText.Name = "lblEfiLockText";
            this.lblEfiLockText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiLockText.Size = new System.Drawing.Size(130, 30);
            this.lblEfiLockText.TabIndex = 102;
            this.lblEfiLockText.Text = "EFI Lock:";
            this.lblEfiLockText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapable
            // 
            this.lblApfsCapable.AutoEllipsis = true;
            this.lblApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapable.ForeColor = System.Drawing.Color.White;
            this.lblApfsCapable.Location = new System.Drawing.Point(131, 124);
            this.lblApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapable.Name = "lblApfsCapable";
            this.lblApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblApfsCapable.Size = new System.Drawing.Size(225, 30);
            this.lblApfsCapable.TabIndex = 99;
            this.lblApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapableText
            // 
            this.lblApfsCapableText.AutoEllipsis = true;
            this.lblApfsCapableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblApfsCapableText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapableText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapableText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApfsCapableText.Location = new System.Drawing.Point(0, 124);
            this.lblApfsCapableText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapableText.Name = "lblApfsCapableText";
            this.lblApfsCapableText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApfsCapableText.Size = new System.Drawing.Size(130, 30);
            this.lblApfsCapableText.TabIndex = 99;
            this.lblApfsCapableText.Text = "APFS Capable:";
            this.lblApfsCapableText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfiLock
            // 
            this.tlpEfiLock.ColumnCount = 3;
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpEfiLock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiLock.Controls.Add(this.cmdInvalidateEfiLock, 2, 0);
            this.tlpEfiLock.Controls.Add(this.lblEfiLockStatus, 0, 0);
            this.tlpEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiLock.Location = new System.Drawing.Point(131, 93);
            this.tlpEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiLock.Name = "tlpEfiLock";
            this.tlpEfiLock.RowCount = 1;
            this.tlpEfiLock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiLock.Size = new System.Drawing.Size(225, 30);
            this.tlpEfiLock.TabIndex = 3;
            // 
            // cmdInvalidateEfiLock
            // 
            this.cmdInvalidateEfiLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdInvalidateEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdInvalidateEfiLock.Enabled = false;
            this.cmdInvalidateEfiLock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdInvalidateEfiLock.FlatAppearance.BorderSize = 2;
            this.cmdInvalidateEfiLock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdInvalidateEfiLock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdInvalidateEfiLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInvalidateEfiLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInvalidateEfiLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdInvalidateEfiLock.Location = new System.Drawing.Point(195, 0);
            this.cmdInvalidateEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.cmdInvalidateEfiLock.Name = "cmdInvalidateEfiLock";
            this.cmdInvalidateEfiLock.Size = new System.Drawing.Size(30, 30);
            this.cmdInvalidateEfiLock.TabIndex = 0;
            this.cmdInvalidateEfiLock.Text = "K";
            this.cmdInvalidateEfiLock.UseVisualStyleBackColor = false;
            this.cmdInvalidateEfiLock.Click += new System.EventHandler(this.cmdInvalidateEfiLock_Click);
            // 
            // lblEfiLockStatus
            // 
            this.lblEfiLockStatus.AutoEllipsis = true;
            this.lblEfiLockStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblEfiLockStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLockStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLockStatus.ForeColor = System.Drawing.Color.White;
            this.lblEfiLockStatus.Location = new System.Drawing.Point(0, 0);
            this.lblEfiLockStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLockStatus.Name = "lblEfiLockStatus";
            this.lblEfiLockStatus.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiLockStatus.Size = new System.Drawing.Size(194, 30);
            this.lblEfiLockStatus.TabIndex = 99;
            this.lblEfiLockStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwc
            // 
            this.lblHwc.AutoEllipsis = true;
            this.lblHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblHwc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwc.ForeColor = System.Drawing.Color.White;
            this.lblHwc.Location = new System.Drawing.Point(131, 31);
            this.lblHwc.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwc.Name = "lblHwc";
            this.lblHwc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblHwc.Size = new System.Drawing.Size(225, 30);
            this.lblHwc.TabIndex = 99;
            this.lblHwc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFsysStoreText
            // 
            this.lblFsysStoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFsysStoreText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysStoreText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysStoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysStoreText.Location = new System.Drawing.Point(0, 0);
            this.lblFsysStoreText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysStoreText.Name = "lblFsysStoreText";
            this.lblFsysStoreText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysStoreText.Size = new System.Drawing.Size(130, 30);
            this.lblFsysStoreText.TabIndex = 99;
            this.lblFsysStoreText.Text = "Fsys Store:";
            this.lblFsysStoreText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerial
            // 
            this.tlpSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpSerial.ColumnCount = 3;
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSerial.Controls.Add(this.cmdEveryMacSearch, 2, 0);
            this.tlpSerial.Controls.Add(this.lblSerialNumber, 0, 0);
            this.tlpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerial.Location = new System.Drawing.Point(488, 0);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(225, 30);
            this.tlpSerial.TabIndex = 4;
            // 
            // cmdEveryMacSearch
            // 
            this.cmdEveryMacSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEveryMacSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEveryMacSearch.Enabled = false;
            this.cmdEveryMacSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEveryMacSearch.FlatAppearance.BorderSize = 2;
            this.cmdEveryMacSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEveryMacSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdEveryMacSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEveryMacSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEveryMacSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdEveryMacSearch.Location = new System.Drawing.Point(195, 0);
            this.cmdEveryMacSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEveryMacSearch.Name = "cmdEveryMacSearch";
            this.cmdEveryMacSearch.Size = new System.Drawing.Size(30, 30);
            this.cmdEveryMacSearch.TabIndex = 0;
            this.cmdEveryMacSearch.Text = "S";
            this.cmdEveryMacSearch.UseVisualStyleBackColor = false;
            this.cmdEveryMacSearch.Click += new System.EventHandler(this.cmdEveryMacSearch_Click);
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoEllipsis = true;
            this.lblSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.ForeColor = System.Drawing.Color.White;
            this.lblSerialNumber.Location = new System.Drawing.Point(0, 0);
            this.lblSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerialNumber.Size = new System.Drawing.Size(194, 30);
            this.lblSerialNumber.TabIndex = 99;
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpModel
            // 
            this.tlpModel.ColumnCount = 1;
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpModel.Controls.Add(this.lblModel, 0, 0);
            this.tlpModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpModel.Location = new System.Drawing.Point(0, 99);
            this.tlpModel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpModel.Name = "tlpModel";
            this.tlpModel.RowCount = 1;
            this.tlpModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModel.Size = new System.Drawing.Size(713, 36);
            this.tlpModel.TabIndex = 100;
            // 
            // lblModel
            // 
            this.lblModel.AutoEllipsis = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.White;
            this.lblModel.Location = new System.Drawing.Point(0, 0);
            this.lblModel.Margin = new System.Windows.Forms.Padding(0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblModel.Size = new System.Drawing.Size(713, 36);
            this.lblModel.TabIndex = 99;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(0, 0);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(713, 2);
            this.pnlSeperator.TabIndex = 94;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(103, 14);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(23, 22);
            this.lblVersion.TabIndex = 99;
            this.lblVersion.Text = "...";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdPatch
            // 
            this.cmdPatch.BackColor = System.Drawing.Color.Transparent;
            this.cmdPatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdPatch.Enabled = false;
            this.cmdPatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdPatch.FlatAppearance.BorderSize = 0;
            this.cmdPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPatch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdPatch.Location = new System.Drawing.Point(200, 1);
            this.cmdPatch.Margin = new System.Windows.Forms.Padding(1);
            this.cmdPatch.Name = "cmdPatch";
            this.cmdPatch.Size = new System.Drawing.Size(78, 36);
            this.cmdPatch.TabIndex = 3;
            this.cmdPatch.Text = "PATCHER";
            this.cmdPatch.UseVisualStyleBackColor = false;
            this.cmdPatch.Click += new System.EventHandler(this.cmdPatch_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.Transparent;
            this.cmdReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReset.Enabled = false;
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdReset.FlatAppearance.BorderSize = 0;
            this.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdReset.Location = new System.Drawing.Point(66, 1);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(1);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(62, 36);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdOpen.FlatAppearance.BorderSize = 0;
            this.cmdOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdOpen.Location = new System.Drawing.Point(1, 1);
            this.cmdOpen.Margin = new System.Windows.Forms.Padding(1);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(62, 36);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "OPEN";
            this.cmdOpen.UseVisualStyleBackColor = false;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(50, 0);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(432, 50);
            this.lblWindowTitle.TabIndex = 99;
            this.lblWindowTitle.Text = "Mac EFI Toolkit";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWindowTitle.Click += new System.EventHandler(this.lblWindowTitle_Click);
            // 
            // pbxTitleLogo
            // 
            this.pbxTitleLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxTitleLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxTitleLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxTitleLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxTitleLogo.Image")));
            this.pbxTitleLogo.Location = new System.Drawing.Point(8, 9);
            this.pbxTitleLogo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pbxTitleLogo.Name = "pbxTitleLogo";
            this.pbxTitleLogo.Size = new System.Drawing.Size(32, 32);
            this.pbxTitleLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxTitleLogo.TabIndex = 1;
            this.pbxTitleLogo.TabStop = false;
            this.pbxTitleLogo.Click += new System.EventHandler(this.pbxTitleLogo_Click);
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpMenu.ColumnCount = 14;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Controls.Add(this.pnlMenuSeperator1, 5, 0);
            this.tlpMenu.Controls.Add(this.cmdCopyMenu, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdPatch, 6, 0);
            this.tlpMenu.Controls.Add(this.panel1, 7, 0);
            this.tlpMenu.Controls.Add(this.cmdSettings, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdAbout, 10, 0);
            this.tlpMenu.Controls.Add(this.cmdMore, 12, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 51);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(713, 38);
            this.tlpMenu.TabIndex = 0;
            // 
            // pnlMenuSeperator1
            // 
            this.pnlMenuSeperator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMenuSeperator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlMenuSeperator1.Location = new System.Drawing.Point(196, 11);
            this.pnlMenuSeperator1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuSeperator1.Name = "pnlMenuSeperator1";
            this.pnlMenuSeperator1.Size = new System.Drawing.Size(1, 16);
            this.pnlMenuSeperator1.TabIndex = 8;
            // 
            // cmdCopyMenu
            // 
            this.cmdCopyMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdCopyMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCopyMenu.Enabled = false;
            this.cmdCopyMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdCopyMenu.FlatAppearance.BorderSize = 0;
            this.cmdCopyMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdCopyMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdCopyMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCopyMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCopyMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdCopyMenu.Location = new System.Drawing.Point(131, 1);
            this.cmdCopyMenu.Margin = new System.Windows.Forms.Padding(1);
            this.cmdCopyMenu.Name = "cmdCopyMenu";
            this.cmdCopyMenu.Size = new System.Drawing.Size(62, 36);
            this.cmdCopyMenu.TabIndex = 2;
            this.cmdCopyMenu.Text = "COPY";
            this.cmdCopyMenu.UseVisualStyleBackColor = false;
            this.cmdCopyMenu.Click += new System.EventHandler(this.cmdCopyMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(281, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 16);
            this.panel1.TabIndex = 10;
            // 
            // cmdSettings
            // 
            this.cmdSettings.BackColor = System.Drawing.Color.Transparent;
            this.cmdSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdSettings.FlatAppearance.BorderSize = 0;
            this.cmdSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdSettings.Location = new System.Drawing.Point(285, 1);
            this.cmdSettings.Margin = new System.Windows.Forms.Padding(1);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(84, 36);
            this.cmdSettings.TabIndex = 4;
            this.cmdSettings.Text = "SETTINGS";
            this.cmdSettings.UseVisualStyleBackColor = false;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackColor = System.Drawing.Color.Transparent;
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdAbout.FlatAppearance.BorderSize = 0;
            this.cmdAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdAbout.Location = new System.Drawing.Point(372, 1);
            this.cmdAbout.Margin = new System.Windows.Forms.Padding(1);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(68, 36);
            this.cmdAbout.TabIndex = 5;
            this.cmdAbout.Text = "ABOUT";
            this.cmdAbout.UseVisualStyleBackColor = false;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdMore
            // 
            this.cmdMore.BackColor = System.Drawing.Color.Transparent;
            this.cmdMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMore.FlatAppearance.BorderSize = 0;
            this.cmdMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMore.ForeColor = System.Drawing.Color.White;
            this.cmdMore.Location = new System.Drawing.Point(443, 1);
            this.cmdMore.Margin = new System.Windows.Forms.Padding(1);
            this.cmdMore.Name = "cmdMore";
            this.cmdMore.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdMore.Size = new System.Drawing.Size(36, 36);
            this.cmdMore.TabIndex = 6;
            this.cmdMore.Text = "...";
            this.cmdMore.UseVisualStyleBackColor = false;
            this.cmdMore.Click += new System.EventHandler(this.cmdMore_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.lblWindowTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 4, 0);
            this.tlpTitle.Controls.Add(this.pbxTitleLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdMin, 3, 0);
            this.tlpTitle.Controls.Add(this.tlpVersionLabel, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(713, 50);
            this.tlpTitle.TabIndex = 99;
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
            this.cmdClose.Location = new System.Drawing.Point(663, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 99;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "C";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdMin
            // 
            this.cmdMin.BackColor = System.Drawing.Color.Transparent;
            this.cmdMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMin.FlatAppearance.BorderSize = 0;
            this.cmdMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMin.ForeColor = System.Drawing.Color.White;
            this.cmdMin.Location = new System.Drawing.Point(613, 0);
            this.cmdMin.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMin.Name = "cmdMin";
            this.cmdMin.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMin.Size = new System.Drawing.Size(50, 50);
            this.cmdMin.TabIndex = 99;
            this.cmdMin.TabStop = false;
            this.cmdMin.Text = "—";
            this.cmdMin.UseVisualStyleBackColor = false;
            this.cmdMin.Click += new System.EventHandler(this.cmdMin_Click);
            // 
            // tlpVersionLabel
            // 
            this.tlpVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlpVersionLabel.ColumnCount = 1;
            this.tlpVersionLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersionLabel.Controls.Add(this.lblVersion, 0, 0);
            this.tlpVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVersionLabel.Location = new System.Drawing.Point(482, 0);
            this.tlpVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVersionLabel.Name = "tlpVersionLabel";
            this.tlpVersionLabel.RowCount = 1;
            this.tlpVersionLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersionLabel.Size = new System.Drawing.Size(131, 50);
            this.tlpVersionLabel.TabIndex = 100;
            this.tlpVersionLabel.Click += new System.EventHandler(this.tlpVersionLabel_Click);
            // 
            // cmsMainMenu
            // 
            this.cmsMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsMainMenu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalFolderToolStripMenuItem,
            this.backupsDirectoryToolStripMenuItem,
            this.openBuildsDirectoryToolStripMenuItem,
            this.openFsysStoresDirectoryToolStripMenuItem,
            this.openMeRegionDirectoryToolStripMenuItem,
            this.toolStripSeparator4,
            this.changelogToolStripMenuItem,
            this.homepageToolStripMenuItem,
            this.usageManualToolStripMenuItem,
            this.toolStripSeparator2,
            this.createADebugLogToolStripMenuItem,
            this.viewLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.restartApplicationToolStripMenuItem});
            this.cmsMainMenu.Name = "cmsMainMenu";
            this.cmsMainMenu.Size = new System.Drawing.Size(245, 330);
            // 
            // openLocalFolderToolStripMenuItem
            // 
            this.openLocalFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLocalFolderToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.folder;
            this.openLocalFolderToolStripMenuItem.Name = "openLocalFolderToolStripMenuItem";
            this.openLocalFolderToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openLocalFolderToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.openLocalFolderToolStripMenuItem.Text = "Local Directory";
            this.openLocalFolderToolStripMenuItem.Click += new System.EventHandler(this.openLocalFolderToolStripMenuItem_Click);
            // 
            // backupsDirectoryToolStripMenuItem
            // 
            this.backupsDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.backupsDirectoryToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.folder;
            this.backupsDirectoryToolStripMenuItem.Name = "backupsDirectoryToolStripMenuItem";
            this.backupsDirectoryToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.backupsDirectoryToolStripMenuItem.Text = "Backups Directory";
            this.backupsDirectoryToolStripMenuItem.Click += new System.EventHandler(this.backupsDirectoryToolStripMenuItem_Click);
            // 
            // openBuildsDirectoryToolStripMenuItem
            // 
            this.openBuildsDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openBuildsDirectoryToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.folder;
            this.openBuildsDirectoryToolStripMenuItem.Name = "openBuildsDirectoryToolStripMenuItem";
            this.openBuildsDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openBuildsDirectoryToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.openBuildsDirectoryToolStripMenuItem.Text = "Builds Directory";
            this.openBuildsDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openBuildsDirectoryToolStripMenuItem_Click);
            // 
            // openFsysStoresDirectoryToolStripMenuItem
            // 
            this.openFsysStoresDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openFsysStoresDirectoryToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.folder;
            this.openFsysStoresDirectoryToolStripMenuItem.Name = "openFsysStoresDirectoryToolStripMenuItem";
            this.openFsysStoresDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openFsysStoresDirectoryToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.openFsysStoresDirectoryToolStripMenuItem.Text = "Fsys Store Directory";
            this.openFsysStoresDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openFsysDirectoryToolStripMenuItem_Click);
            // 
            // openMeRegionDirectoryToolStripMenuItem
            // 
            this.openMeRegionDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openMeRegionDirectoryToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.folder;
            this.openMeRegionDirectoryToolStripMenuItem.Name = "openMeRegionDirectoryToolStripMenuItem";
            this.openMeRegionDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openMeRegionDirectoryToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.openMeRegionDirectoryToolStripMenuItem.Text = "ME Region Directory";
            this.openMeRegionDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openMeRegionDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changelogToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.changelog;
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.homepageToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.home;
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.homepageToolStripMenuItem.Text = "Homepage";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // usageManualToolStripMenuItem
            // 
            this.usageManualToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usageManualToolStripMenuItem.Image = global::Mac_EFI_Toolkit.Properties.Resources.manual;
            this.usageManualToolStripMenuItem.Name = "usageManualToolStripMenuItem";
            this.usageManualToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.usageManualToolStripMenuItem.Text = "Usage Manual";
            this.usageManualToolStripMenuItem.Click += new System.EventHandler(this.usageManualToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // createADebugLogToolStripMenuItem
            // 
            this.createADebugLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createADebugLogToolStripMenuItem.Name = "createADebugLogToolStripMenuItem";
            this.createADebugLogToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.createADebugLogToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.createADebugLogToolStripMenuItem.Text = "Create a Debug Log";
            this.createADebugLogToolStripMenuItem.Click += new System.EventHandler(this.createADebugLogToolStripMenuItem_Click);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.viewLogToolStripMenuItem.Text = "View Application Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // restartApplicationToolStripMenuItem
            // 
            this.restartApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.restartApplicationToolStripMenuItem.Name = "restartApplicationToolStripMenuItem";
            this.restartApplicationToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.restartApplicationToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.restartApplicationToolStripMenuItem.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem_Click);
            // 
            // cmsApplication
            // 
            this.cmsApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.resetPositionToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.cmsApplication.Name = "cmsApplication";
            this.cmsApplication.ShowImageMargin = false;
            this.cmsApplication.Size = new System.Drawing.Size(191, 94);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.ShortcutKeyDisplayString = "(M)";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // resetPositionToolStripMenuItem
            // 
            this.resetPositionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPositionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetPositionToolStripMenuItem.Name = "resetPositionToolStripMenuItem";
            this.resetPositionToolStripMenuItem.ShortcutKeyDisplayString = "(R)";
            this.resetPositionToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.resetPositionToolStripMenuItem.Text = "Reset Position";
            this.resetPositionToolStripMenuItem.Click += new System.EventHandler(this.resetPositionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cmsClipboard
            // 
            this.cmsClipboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsClipboard.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsClipboard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsClipboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenameToolStripMenuItem,
            this.sizeBytesToolStripMenuItem,
            this.sizeHexToolStripMenuItem,
            this.crc32ToolStripMenuItem,
            this.createdDateToolStripMenuItem,
            this.modifiedDateToolStripMenuItem,
            this.toolStripSeparator6,
            this.modelToolStripMenuItem,
            this.configCodeToolStripMenuItem,
            this.serialToolStripMenuItem,
            this.hwcToolStripMenuItem,
            this.fsysCRC32ToolStripMenuItem,
            this.orderNoToolStripMenuItem,
            this.efiVersionToolStripMenuItem,
            this.boardIDToolStripMenuItem,
            this.fitVersionToolStripMenuItem,
            this.meVersionToolStripMenuItem,
            this.toolStripSeparator5,
            this.pdrBaseToolStripMenuItem,
            this.meBaseToolStripMenuItem,
            this.biosBaseToolStripMenuItem});
            this.cmsClipboard.Name = "cmsCopy";
            this.cmsClipboard.ShowImageMargin = false;
            this.cmsClipboard.Size = new System.Drawing.Size(164, 548);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // sizeBytesToolStripMenuItem
            // 
            this.sizeBytesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeBytesToolStripMenuItem.Name = "sizeBytesToolStripMenuItem";
            this.sizeBytesToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.sizeBytesToolStripMenuItem.Text = "Size (Bytes)";
            this.sizeBytesToolStripMenuItem.Click += new System.EventHandler(this.sizeBytesToolStripMenuItem_Click);
            // 
            // sizeHexToolStripMenuItem
            // 
            this.sizeHexToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeHexToolStripMenuItem.Name = "sizeHexToolStripMenuItem";
            this.sizeHexToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.sizeHexToolStripMenuItem.Text = "Size (Hex)";
            this.sizeHexToolStripMenuItem.Click += new System.EventHandler(this.sizeHexToolStripMenuItem_Click);
            // 
            // crc32ToolStripMenuItem
            // 
            this.crc32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.crc32ToolStripMenuItem.Name = "crc32ToolStripMenuItem";
            this.crc32ToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.crc32ToolStripMenuItem.Text = "CRC32";
            this.crc32ToolStripMenuItem.Click += new System.EventHandler(this.crc32ToolStripMenuItem_Click);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.createdDateToolStripMenuItem.Text = "Created Date";
            this.createdDateToolStripMenuItem.Click += new System.EventHandler(this.createdDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(160, 6);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // configCodeToolStripMenuItem
            // 
            this.configCodeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.configCodeToolStripMenuItem.Name = "configCodeToolStripMenuItem";
            this.configCodeToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.configCodeToolStripMenuItem.Text = "Config Code";
            this.configCodeToolStripMenuItem.Click += new System.EventHandler(this.configCodeToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // hwcToolStripMenuItem
            // 
            this.hwcToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hwcToolStripMenuItem.Name = "hwcToolStripMenuItem";
            this.hwcToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.hwcToolStripMenuItem.Text = "HWC";
            this.hwcToolStripMenuItem.Click += new System.EventHandler(this.hwcToolStripMenuItem_Click);
            // 
            // fsysCRC32ToolStripMenuItem
            // 
            this.fsysCRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fsysCRC32ToolStripMenuItem.Name = "fsysCRC32ToolStripMenuItem";
            this.fsysCRC32ToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.fsysCRC32ToolStripMenuItem.Text = "Fsys CRC32";
            this.fsysCRC32ToolStripMenuItem.Click += new System.EventHandler(this.fsysCRC32ToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
            // 
            // efiVersionToolStripMenuItem
            // 
            this.efiVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.efiVersionToolStripMenuItem.Name = "efiVersionToolStripMenuItem";
            this.efiVersionToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.efiVersionToolStripMenuItem.Text = "EFI Version";
            this.efiVersionToolStripMenuItem.Click += new System.EventHandler(this.efiVersionToolStripMenuItem_Click);
            // 
            // boardIDToolStripMenuItem
            // 
            this.boardIDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.boardIDToolStripMenuItem.Name = "boardIDToolStripMenuItem";
            this.boardIDToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.boardIDToolStripMenuItem.Text = "Board ID";
            this.boardIDToolStripMenuItem.Click += new System.EventHandler(this.boardIDToolStripMenuItem_Click);
            // 
            // fitVersionToolStripMenuItem
            // 
            this.fitVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fitVersionToolStripMenuItem.Name = "fitVersionToolStripMenuItem";
            this.fitVersionToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.fitVersionToolStripMenuItem.Text = "FIT Version";
            this.fitVersionToolStripMenuItem.Click += new System.EventHandler(this.fitVersionToolStripMenuItem_Click);
            // 
            // meVersionToolStripMenuItem
            // 
            this.meVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meVersionToolStripMenuItem.Name = "meVersionToolStripMenuItem";
            this.meVersionToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.meVersionToolStripMenuItem.Text = "ME Version";
            this.meVersionToolStripMenuItem.Click += new System.EventHandler(this.meVersionToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // pdrBaseToolStripMenuItem
            // 
            this.pdrBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pdrBaseToolStripMenuItem.Name = "pdrBaseToolStripMenuItem";
            this.pdrBaseToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.pdrBaseToolStripMenuItem.Text = "PDR Base";
            this.pdrBaseToolStripMenuItem.Click += new System.EventHandler(this.pdrBaseToolStripMenuItem_Click);
            // 
            // meBaseToolStripMenuItem
            // 
            this.meBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meBaseToolStripMenuItem.Name = "meBaseToolStripMenuItem";
            this.meBaseToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.meBaseToolStripMenuItem.Text = "ME Base";
            this.meBaseToolStripMenuItem.Click += new System.EventHandler(this.meBaseToolStripMenuItem_Click);
            // 
            // biosBaseToolStripMenuItem
            // 
            this.biosBaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.biosBaseToolStripMenuItem.Name = "biosBaseToolStripMenuItem";
            this.biosBaseToolStripMenuItem.Size = new System.Drawing.Size(163, 28);
            this.biosBaseToolStripMenuItem.Text = "BIOS Base";
            this.biosBaseToolStripMenuItem.Click += new System.EventHandler(this.biosBaseToolStripMenuItem_Click);
            // 
            // mainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(715, 420);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.tlpTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(715, 420);
            this.Name = "mainWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mac EFI Toolkit";
            this.pnlMain.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.tlpStatusBar.PerformLayout();
            this.tlpStatusBarImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpFilename.ResumeLayout(false);
            this.tlpFile.ResumeLayout(false);
            this.tlpRom.ResumeLayout(false);
            this.tlpEfiVer.ResumeLayout(false);
            this.tlpFsys.ResumeLayout(false);
            this.tlpNvram.ResumeLayout(false);
            this.tlpIntelMe.ResumeLayout(false);
            this.tlpEfiLock.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpVersionLabel.ResumeLayout(false);
            this.tlpVersionLabel.PerformLayout();
            this.cmsMainMenu.ResumeLayout(false);
            this.cmsApplication.ResumeLayout(false);
            this.cmsClipboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblChecksumText;
        private System.Windows.Forms.Label lblSizeBytesText;
        private System.Windows.Forms.Label lblFileCrc;
        private System.Windows.Forms.Label lblFileSizeBytes;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.Label lblBoardIdText;
        private System.Windows.Forms.Button cmdOpen;
        internal System.Windows.Forms.PictureBox pbxTitleLogo;
        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Label lblFsysStoreText;
        private System.Windows.Forms.Label lblSonText;
        private System.Windows.Forms.Label lblFsysCrc;
        private System.Windows.Forms.Label lblApfsCapable;
        private System.Windows.Forms.Label lblApfsCapableText;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.Button cmdEveryMacSearch;
        private System.Windows.Forms.Label lblVssStore;
        private System.Windows.Forms.Label lblNvramText;
        private System.Windows.Forms.Label lblEfiVersionText;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button cmdPatch;
        private System.Windows.Forms.Label lblMeVersionText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.TableLayoutPanel tlpFsys;
        private System.Windows.Forms.Button cmdFixFsysCrc;
        private System.Windows.Forms.Button cmdExportFsys;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.Label lblHwc;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblCreatedText;
        private System.Windows.Forms.Label lblFileModifiedDate;
        private System.Windows.Forms.Label lblModifiedText;
        private System.Windows.Forms.Label lblFileCreatedDate;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpFilename;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.TableLayoutPanel tlpRom;
        private System.Windows.Forms.TableLayoutPanel tlpFile;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.Button cmdNavigate;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblPrivateMemory;
        private System.Windows.Forms.TableLayoutPanel tlpEfiVer;
        private System.Windows.Forms.Label lblEfiVersion;
        private System.Windows.Forms.Button cmdAppleRomInfo;
        private System.Windows.Forms.PictureBox pbxLoad;
        private METLabel lblFilename;
        private System.Windows.Forms.Label lblMeVersion;
        private System.Windows.Forms.TableLayoutPanel tlpNvram;
        private System.Windows.Forms.Label lblNssStore;
        private System.Windows.Forms.Label lblSvsStore;
        private System.Windows.Forms.ToolStripMenuItem openBuildsDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFsysStoresDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hwcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsysCRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efiVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderNoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpIntelMe;
        private System.Windows.Forms.Button cmdExportMe;
        private System.Windows.Forms.ToolStripMenuItem openMeRegionDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createADebugLogToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdMore;
        internal System.Windows.Forms.Button cmdMin;
        private System.Windows.Forms.TableLayoutPanel tlpVersionLabel;
        private METContextMenuStrip cmsMainMenu;
        private METContextMenuStrip cmsApplication;
        private METContextMenuStrip cmsClipboard;
        private System.Windows.Forms.Panel pnlMenuSeperator1;
        private System.Windows.Forms.ToolStripMenuItem usageManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpModel;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configCodeToolStripMenuItem;
        private System.Windows.Forms.Label lblEfiLockText;
        private System.Windows.Forms.TableLayoutPanel tlpEfiLock;
        private System.Windows.Forms.Button cmdInvalidateEfiLock;
        private System.Windows.Forms.Label lblEfiLockStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem pdrBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biosBaseToolStripMenuItem;
        private System.Windows.Forms.Button cmdCopyMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem filenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crc32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createdDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeHexToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBackupToZip;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.ToolStripMenuItem backupsDirectoryToolStripMenuItem;
    }
}