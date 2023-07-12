
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrivateMemory = new System.Windows.Forms.Label();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.cmdReload = new System.Windows.Forms.Button();
            this.cmdNavigate = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
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
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblSonText = new System.Windows.Forms.Label();
            this.lblApfsCapable = new System.Windows.Forms.Label();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.lblFsysStoreText = new System.Windows.Forms.Label();
            this.lblApfsCapableText = new System.Windows.Forms.Label();
            this.lblEfiVersionText = new System.Windows.Forms.Label();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.lblMeVersionText = new System.Windows.Forms.Label();
            this.lblFitVersion = new System.Windows.Forms.Label();
            this.lblBoardIdText = new System.Windows.Forms.Label();
            this.lblFitVersionText = new System.Windows.Forms.Label();
            this.lblHwc = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEveryMacSearch = new System.Windows.Forms.Button();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.lblFsysCrc = new System.Windows.Forms.Label();
            this.cmdFixFsysCrc = new System.Windows.Forms.Button();
            this.cmdExportFsys = new System.Windows.Forms.Button();
            this.tlpEfiVer = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.cmdAppleRomInfo = new System.Windows.Forms.Button();
            this.tlpNvram = new System.Windows.Forms.TableLayoutPanel();
            this.lblEfiLock = new System.Windows.Forms.Label();
            this.lblNssStore = new System.Windows.Forms.Label();
            this.lblSvsStore = new System.Windows.Forms.Label();
            this.lblVssStore = new System.Windows.Forms.Label();
            this.tlpIntelMe = new System.Windows.Forms.TableLayoutPanel();
            this.lblMeVersion = new System.Windows.Forms.Label();
            this.cmdExportMe = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdOpenBin = new System.Windows.Forms.Button();
            this.cmsMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openLocalFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBuildsDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFsysStoresDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMeRegionDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createADebugLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pbxTitleLogo = new System.Windows.Forms.PictureBox();
            this.cmsApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmsCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crc32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hwcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsysCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efiVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdMin = new System.Windows.Forms.Button();
            this.tlpVersionLabel = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new METLabel();
            this.pnlMain.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpFilename.SuspendLayout();
            this.tlpFile.SuspendLayout();
            this.tlpRom.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.tlpEfiVer.SuspendLayout();
            this.tlpNvram.SuspendLayout();
            this.tlpIntelMe.SuspendLayout();
            this.cmsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).BeginInit();
            this.cmsApplication.SuspendLayout();
            this.tlpMenu.SuspendLayout();
            this.cmsCopy.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpVersionLabel.SuspendLayout();
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
            this.tlpMain.Controls.Add(this.lblModel, 0, 4);
            this.tlpMain.Controls.Add(this.tlpFile, 0, 2);
            this.tlpMain.Controls.Add(this.tlpRom, 0, 6);
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
            this.tlpFilename.ColumnCount = 5;
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.Controls.Add(this.cmdReload, 4, 0);
            this.tlpFilename.Controls.Add(this.cmdNavigate, 2, 0);
            this.tlpFilename.Controls.Add(this.lblFilename, 0, 0);
            this.tlpFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilename.Location = new System.Drawing.Point(0, 0);
            this.tlpFilename.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFilename.Name = "tlpFilename";
            this.tlpFilename.RowCount = 1;
            this.tlpFilename.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.Size = new System.Drawing.Size(713, 36);
            this.tlpFilename.TabIndex = 0;
            // 
            // cmdReload
            // 
            this.cmdReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReload.Enabled = false;
            this.cmdReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdReload.Location = new System.Drawing.Point(677, 0);
            this.cmdReload.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdReload.Size = new System.Drawing.Size(36, 36);
            this.cmdReload.TabIndex = 5;
            this.cmdReload.Text = "R";
            this.cmdReload.UseVisualStyleBackColor = false;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // cmdNavigate
            // 
            this.cmdNavigate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdNavigate.Enabled = false;
            this.cmdNavigate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdNavigate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNavigate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNavigate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdNavigate.Location = new System.Drawing.Point(640, 0);
            this.cmdNavigate.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNavigate.Name = "cmdNavigate";
            this.cmdNavigate.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdNavigate.Size = new System.Drawing.Size(36, 36);
            this.cmdNavigate.TabIndex = 4;
            this.cmdNavigate.Text = "N";
            this.cmdNavigate.UseVisualStyleBackColor = false;
            this.cmdNavigate.Click += new System.EventHandler(this.cmdNavigate_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoEllipsis = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.White;
            this.lblModel.Location = new System.Drawing.Point(0, 99);
            this.lblModel.Margin = new System.Windows.Forms.Padding(0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblModel.Size = new System.Drawing.Size(713, 36);
            this.lblModel.TabIndex = 99;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpFile
            // 
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
            this.lblFileCreatedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
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
            this.lblFileModifiedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
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
            this.lblFileCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
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
            this.lblCreatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            this.lblFileSizeBytes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
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
            this.lblModifiedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            this.lblSizeBytesText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            this.lblChecksumText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            this.tlpRom.ColumnCount = 7;
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRom.Controls.Add(this.lblOrderNo, 6, 8);
            this.tlpRom.Controls.Add(this.lblSonText, 4, 8);
            this.tlpRom.Controls.Add(this.lblApfsCapable, 6, 2);
            this.tlpRom.Controls.Add(this.lblNvramText, 4, 4);
            this.tlpRom.Controls.Add(this.lblFsysStoreText, 0, 2);
            this.tlpRom.Controls.Add(this.lblApfsCapableText, 4, 2);
            this.tlpRom.Controls.Add(this.lblEfiVersionText, 0, 4);
            this.tlpRom.Controls.Add(this.lblBoardId, 2, 8);
            this.tlpRom.Controls.Add(this.lblMeVersionText, 4, 6);
            this.tlpRom.Controls.Add(this.lblFitVersion, 2, 6);
            this.tlpRom.Controls.Add(this.lblBoardIdText, 0, 8);
            this.tlpRom.Controls.Add(this.lblFitVersionText, 0, 6);
            this.tlpRom.Controls.Add(this.lblHwc, 6, 0);
            this.tlpRom.Controls.Add(this.lblSerialText, 0, 0);
            this.tlpRom.Controls.Add(this.tlpSerial, 2, 0);
            this.tlpRom.Controls.Add(this.lblHwcText, 4, 0);
            this.tlpRom.Controls.Add(this.tlpFsys, 2, 2);
            this.tlpRom.Controls.Add(this.tlpEfiVer, 2, 4);
            this.tlpRom.Controls.Add(this.tlpNvram, 6, 4);
            this.tlpRom.Controls.Add(this.tlpIntelMe, 6, 6);
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
            // lblOrderNo
            // 
            this.lblOrderNo.AutoEllipsis = true;
            this.lblOrderNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.White;
            this.lblOrderNo.Location = new System.Drawing.Point(488, 124);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOrderNo.Size = new System.Drawing.Size(225, 30);
            this.lblOrderNo.TabIndex = 99;
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSonText
            // 
            this.lblSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSonText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSonText.Location = new System.Drawing.Point(357, 124);
            this.lblSonText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSonText.Name = "lblSonText";
            this.lblSonText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSonText.Size = new System.Drawing.Size(130, 30);
            this.lblSonText.TabIndex = 99;
            this.lblSonText.Text = "Order No:";
            this.lblSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapable
            // 
            this.lblApfsCapable.AutoEllipsis = true;
            this.lblApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapable.ForeColor = System.Drawing.Color.White;
            this.lblApfsCapable.Location = new System.Drawing.Point(488, 31);
            this.lblApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapable.Name = "lblApfsCapable";
            this.lblApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblApfsCapable.Size = new System.Drawing.Size(225, 30);
            this.lblApfsCapable.TabIndex = 99;
            this.lblApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            // lblFsysStoreText
            // 
            this.lblFsysStoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblFsysStoreText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysStoreText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysStoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysStoreText.Location = new System.Drawing.Point(0, 31);
            this.lblFsysStoreText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysStoreText.Name = "lblFsysStoreText";
            this.lblFsysStoreText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysStoreText.Size = new System.Drawing.Size(130, 30);
            this.lblFsysStoreText.TabIndex = 99;
            this.lblFsysStoreText.Text = "Fsys Store:";
            this.lblFsysStoreText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapableText
            // 
            this.lblApfsCapableText.AutoEllipsis = true;
            this.lblApfsCapableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblApfsCapableText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapableText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapableText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApfsCapableText.Location = new System.Drawing.Point(357, 31);
            this.lblApfsCapableText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapableText.Name = "lblApfsCapableText";
            this.lblApfsCapableText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApfsCapableText.Size = new System.Drawing.Size(130, 30);
            this.lblApfsCapableText.TabIndex = 99;
            this.lblApfsCapableText.Text = "APFS Capable:";
            this.lblApfsCapableText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiVersionText
            // 
            this.lblEfiVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
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
            // lblBoardId
            // 
            this.lblBoardId.AutoEllipsis = true;
            this.lblBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.White;
            this.lblBoardId.Location = new System.Drawing.Point(131, 124);
            this.lblBoardId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBoardId.Size = new System.Drawing.Size(225, 30);
            this.lblBoardId.TabIndex = 99;
            this.lblBoardId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMeVersionText
            // 
            this.lblMeVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblMeVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblMeVersionText.Location = new System.Drawing.Point(357, 93);
            this.lblMeVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersionText.Name = "lblMeVersionText";
            this.lblMeVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblMeVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblMeVersionText.TabIndex = 99;
            this.lblMeVersionText.Text = "Intel ME:";
            this.lblMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFitVersion
            // 
            this.lblFitVersion.AutoEllipsis = true;
            this.lblFitVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblFitVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFitVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFitVersion.ForeColor = System.Drawing.Color.White;
            this.lblFitVersion.Location = new System.Drawing.Point(131, 93);
            this.lblFitVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblFitVersion.Name = "lblFitVersion";
            this.lblFitVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFitVersion.Size = new System.Drawing.Size(225, 30);
            this.lblFitVersion.TabIndex = 99;
            this.lblFitVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoardIdText
            // 
            this.lblBoardIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblBoardIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardIdText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBoardIdText.Location = new System.Drawing.Point(0, 124);
            this.lblBoardIdText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoardIdText.Name = "lblBoardIdText";
            this.lblBoardIdText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBoardIdText.Size = new System.Drawing.Size(130, 30);
            this.lblBoardIdText.TabIndex = 99;
            this.lblBoardIdText.Text = "Mac Board ID:";
            this.lblBoardIdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFitVersionText
            // 
            this.lblFitVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblFitVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFitVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFitVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFitVersionText.Location = new System.Drawing.Point(0, 93);
            this.lblFitVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFitVersionText.Name = "lblFitVersionText";
            this.lblFitVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFitVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblFitVersionText.TabIndex = 99;
            this.lblFitVersionText.Text = "FIT Version:";
            this.lblFitVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwc
            // 
            this.lblHwc.AutoEllipsis = true;
            this.lblHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblHwc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwc.ForeColor = System.Drawing.Color.White;
            this.lblHwc.Location = new System.Drawing.Point(488, 0);
            this.lblHwc.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwc.Name = "lblHwc";
            this.lblHwc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblHwc.Size = new System.Drawing.Size(225, 30);
            this.lblHwc.TabIndex = 99;
            this.lblHwc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 0);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 30);
            this.lblSerialText.TabIndex = 99;
            this.lblSerialText.Text = "Serial:";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpSerial.Location = new System.Drawing.Point(131, 0);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(225, 30);
            this.tlpSerial.TabIndex = 0;
            // 
            // cmdEveryMacSearch
            // 
            this.cmdEveryMacSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEveryMacSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEveryMacSearch.Enabled = false;
            this.cmdEveryMacSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
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
            this.lblSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
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
            // lblHwcText
            // 
            this.lblHwcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblHwcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(357, 0);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblHwcText.Size = new System.Drawing.Size(130, 30);
            this.lblHwcText.TabIndex = 99;
            this.lblHwcText.Text = "HWC:";
            this.lblHwcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpFsys.Location = new System.Drawing.Point(131, 31);
            this.tlpFsys.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsys.Name = "tlpFsys";
            this.tlpFsys.RowCount = 1;
            this.tlpFsys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.Size = new System.Drawing.Size(225, 30);
            this.tlpFsys.TabIndex = 1;
            // 
            // lblFsysCrc
            // 
            this.lblFsysCrc.AutoEllipsis = true;
            this.lblFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
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
            this.tlpEfiVer.TabIndex = 2;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
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
            // tlpNvram
            // 
            this.tlpNvram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpNvram.ColumnCount = 7;
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpNvram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpNvram.Controls.Add(this.lblEfiLock, 6, 0);
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
            // lblEfiLock
            // 
            this.lblEfiLock.AutoEllipsis = true;
            this.lblEfiLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblEfiLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiLock.ForeColor = System.Drawing.Color.White;
            this.lblEfiLock.Location = new System.Drawing.Point(195, 0);
            this.lblEfiLock.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiLock.Name = "lblEfiLock";
            this.lblEfiLock.Size = new System.Drawing.Size(30, 30);
            this.lblEfiLock.TabIndex = 99;
            this.lblEfiLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNssStore
            // 
            this.lblNssStore.AutoEllipsis = true;
            this.lblNssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblNssStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssStore.ForeColor = System.Drawing.Color.White;
            this.lblNssStore.Location = new System.Drawing.Point(130, 0);
            this.lblNssStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblNssStore.Name = "lblNssStore";
            this.lblNssStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblNssStore.Size = new System.Drawing.Size(64, 30);
            this.lblNssStore.TabIndex = 100;
            this.lblNssStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSvsStore
            // 
            this.lblSvsStore.AutoEllipsis = true;
            this.lblSvsStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblSvsStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvsStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsStore.ForeColor = System.Drawing.Color.White;
            this.lblSvsStore.Location = new System.Drawing.Point(65, 0);
            this.lblSvsStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsStore.Name = "lblSvsStore";
            this.lblSvsStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSvsStore.Size = new System.Drawing.Size(64, 30);
            this.lblSvsStore.TabIndex = 100;
            this.lblSvsStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVssStore
            // 
            this.lblVssStore.AutoEllipsis = true;
            this.lblVssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblVssStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssStore.ForeColor = System.Drawing.Color.White;
            this.lblVssStore.Location = new System.Drawing.Point(0, 0);
            this.lblVssStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssStore.Name = "lblVssStore";
            this.lblVssStore.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblVssStore.Size = new System.Drawing.Size(64, 30);
            this.lblVssStore.TabIndex = 99;
            this.lblVssStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpIntelMe.Location = new System.Drawing.Point(488, 93);
            this.tlpIntelMe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIntelMe.Name = "tlpIntelMe";
            this.tlpIntelMe.RowCount = 1;
            this.tlpIntelMe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIntelMe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpIntelMe.Size = new System.Drawing.Size(225, 30);
            this.tlpIntelMe.TabIndex = 100;
            // 
            // lblMeVersion
            // 
            this.lblMeVersion.AutoEllipsis = true;
            this.lblMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
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
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblVersion.Location = new System.Drawing.Point(32, 14);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(23, 22);
            this.lblVersion.TabIndex = 99;
            this.lblVersion.Text = "...";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackColor = System.Drawing.Color.Transparent;
            this.cmdEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEdit.Enabled = false;
            this.cmdEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdEdit.FlatAppearance.BorderSize = 0;
            this.cmdEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdEdit.Location = new System.Drawing.Point(162, 0);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(80, 38);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.UseVisualStyleBackColor = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
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
            this.cmdReset.Location = new System.Drawing.Point(81, 0);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(80, 38);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdOpenBin
            // 
            this.cmdOpenBin.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpenBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpenBin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdOpenBin.FlatAppearance.BorderSize = 0;
            this.cmdOpenBin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdOpenBin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdOpenBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenBin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenBin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdOpenBin.Location = new System.Drawing.Point(0, 0);
            this.cmdOpenBin.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenBin.Name = "cmdOpenBin";
            this.cmdOpenBin.Size = new System.Drawing.Size(80, 38);
            this.cmdOpenBin.TabIndex = 0;
            this.cmdOpenBin.Text = "OPEN";
            this.cmdOpenBin.UseVisualStyleBackColor = false;
            this.cmdOpenBin.Click += new System.EventHandler(this.cmdOpenBin_Click);
            // 
            // cmsMainMenu
            // 
            this.cmsMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsMainMenu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalFolderToolStripMenuItem,
            this.openBuildsDirectoryToolStripMenuItem,
            this.openFsysStoresDirectoryToolStripMenuItem,
            this.openMeRegionDirectoryToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.createADebugLogToolStripMenuItem,
            this.restartApplicationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.cmsMainMenu.Name = "cmsMainMenu";
            this.cmsMainMenu.ShowImageMargin = false;
            this.cmsMainMenu.Size = new System.Drawing.Size(247, 274);
            // 
            // openLocalFolderToolStripMenuItem
            // 
            this.openLocalFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLocalFolderToolStripMenuItem.Name = "openLocalFolderToolStripMenuItem";
            this.openLocalFolderToolStripMenuItem.ShortcutKeyDisplayString = "(L)";
            this.openLocalFolderToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.openLocalFolderToolStripMenuItem.Text = "Local Directory";
            this.openLocalFolderToolStripMenuItem.Click += new System.EventHandler(this.openLocalFolderToolStripMenuItem_Click);
            // 
            // openBuildsDirectoryToolStripMenuItem
            // 
            this.openBuildsDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openBuildsDirectoryToolStripMenuItem.Name = "openBuildsDirectoryToolStripMenuItem";
            this.openBuildsDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "(B)";
            this.openBuildsDirectoryToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.openBuildsDirectoryToolStripMenuItem.Text = "Builds Directory";
            this.openBuildsDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openBuildsDirectoryToolStripMenuItem_Click);
            // 
            // openFsysStoresDirectoryToolStripMenuItem
            // 
            this.openFsysStoresDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openFsysStoresDirectoryToolStripMenuItem.Name = "openFsysStoresDirectoryToolStripMenuItem";
            this.openFsysStoresDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "(F)";
            this.openFsysStoresDirectoryToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.openFsysStoresDirectoryToolStripMenuItem.Text = "Fsys Store Directory";
            this.openFsysStoresDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openFsysDirectoryToolStripMenuItem_Click);
            // 
            // openMeRegionDirectoryToolStripMenuItem
            // 
            this.openMeRegionDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openMeRegionDirectoryToolStripMenuItem.Name = "openMeRegionDirectoryToolStripMenuItem";
            this.openMeRegionDirectoryToolStripMenuItem.ShortcutKeyDisplayString = "(M)";
            this.openMeRegionDirectoryToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.openMeRegionDirectoryToolStripMenuItem.Text = "ME Region Directory";
            this.openMeRegionDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openMeRegionDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(243, 6);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.ShortcutKeyDisplayString = "(V)";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.viewLogToolStripMenuItem.Text = "View Application Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // createADebugLogToolStripMenuItem
            // 
            this.createADebugLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createADebugLogToolStripMenuItem.Name = "createADebugLogToolStripMenuItem";
            this.createADebugLogToolStripMenuItem.ShortcutKeyDisplayString = "(C)";
            this.createADebugLogToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.createADebugLogToolStripMenuItem.Text = "Create a Debug Log";
            this.createADebugLogToolStripMenuItem.Click += new System.EventHandler(this.createADebugLogToolStripMenuItem_Click);
            // 
            // restartApplicationToolStripMenuItem
            // 
            this.restartApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.restartApplicationToolStripMenuItem.Name = "restartApplicationToolStripMenuItem";
            this.restartApplicationToolStripMenuItem.ShortcutKeyDisplayString = "(R)";
            this.restartApplicationToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.restartApplicationToolStripMenuItem.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeyDisplayString = "(S)";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = "(A)";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.lblWindowTitle.Size = new System.Drawing.Size(453, 50);
            this.lblWindowTitle.TabIndex = 99;
            this.lblWindowTitle.Text = "Mac EFI Toolkit";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpMenu.ColumnCount = 8;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.Controls.Add(this.cmdOpenBin, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdEdit, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdCopy, 6, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 51);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(713, 38);
            this.tlpMenu.TabIndex = 0;
            // 
            // cmdCopy
            // 
            this.cmdCopy.BackColor = System.Drawing.Color.Transparent;
            this.cmdCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCopy.Enabled = false;
            this.cmdCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdCopy.FlatAppearance.BorderSize = 0;
            this.cmdCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCopy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdCopy.Location = new System.Drawing.Point(243, 0);
            this.cmdCopy.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(80, 38);
            this.cmdCopy.TabIndex = 3;
            this.cmdCopy.Text = "COPY";
            this.cmdCopy.UseVisualStyleBackColor = false;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmsCopy
            // 
            this.cmsCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsCopy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCopy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem,
            this.crc32ToolStripMenuItem,
            this.createdDateToolStripMenuItem,
            this.modifiedDateToolStripMenuItem,
            this.toolStripSeparator5,
            this.serialToolStripMenuItem,
            this.hwcToolStripMenuItem,
            this.fsysCRC32ToolStripMenuItem,
            this.efiVersionToolStripMenuItem,
            this.fitVersionToolStripMenuItem,
            this.meVersionToolStripMenuItem,
            this.boardIDToolStripMenuItem,
            this.orderNoToolStripMenuItem});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.ShowImageMargin = false;
            this.cmsCopy.Size = new System.Drawing.Size(186, 374);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // crc32ToolStripMenuItem
            // 
            this.crc32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.crc32ToolStripMenuItem.Name = "crc32ToolStripMenuItem";
            this.crc32ToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.crc32ToolStripMenuItem.Text = "CRC32";
            this.crc32ToolStripMenuItem.Click += new System.EventHandler(this.crc32ToolStripMenuItem_Click);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.createdDateToolStripMenuItem.Text = "Created Date";
            this.createdDateToolStripMenuItem.Click += new System.EventHandler(this.createdDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // hwcToolStripMenuItem
            // 
            this.hwcToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hwcToolStripMenuItem.Name = "hwcToolStripMenuItem";
            this.hwcToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.hwcToolStripMenuItem.Text = "HWC";
            this.hwcToolStripMenuItem.Click += new System.EventHandler(this.hwcToolStripMenuItem_Click);
            // 
            // fsysCRC32ToolStripMenuItem
            // 
            this.fsysCRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fsysCRC32ToolStripMenuItem.Name = "fsysCRC32ToolStripMenuItem";
            this.fsysCRC32ToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.fsysCRC32ToolStripMenuItem.Text = "Fsys CRC32";
            this.fsysCRC32ToolStripMenuItem.Click += new System.EventHandler(this.fsysCRC32ToolStripMenuItem_Click);
            // 
            // efiVersionToolStripMenuItem
            // 
            this.efiVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.efiVersionToolStripMenuItem.Name = "efiVersionToolStripMenuItem";
            this.efiVersionToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.efiVersionToolStripMenuItem.Text = "EFI Version";
            this.efiVersionToolStripMenuItem.Click += new System.EventHandler(this.efiVersionToolStripMenuItem_Click);
            // 
            // fitVersionToolStripMenuItem
            // 
            this.fitVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fitVersionToolStripMenuItem.Name = "fitVersionToolStripMenuItem";
            this.fitVersionToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.fitVersionToolStripMenuItem.Text = "FIT Version";
            this.fitVersionToolStripMenuItem.Click += new System.EventHandler(this.fitVersionToolStripMenuItem_Click);
            // 
            // meVersionToolStripMenuItem
            // 
            this.meVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.meVersionToolStripMenuItem.Name = "meVersionToolStripMenuItem";
            this.meVersionToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.meVersionToolStripMenuItem.Text = "ME Version";
            this.meVersionToolStripMenuItem.Click += new System.EventHandler(this.meVersionToolStripMenuItem_Click);
            // 
            // boardIDToolStripMenuItem
            // 
            this.boardIDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.boardIDToolStripMenuItem.Name = "boardIDToolStripMenuItem";
            this.boardIDToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.boardIDToolStripMenuItem.Text = "Board-ID";
            this.boardIDToolStripMenuItem.Click += new System.EventHandler(this.boardIDToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 6;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Controls.Add(this.lblWindowTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 5, 0);
            this.tlpTitle.Controls.Add(this.pbxTitleLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdMenu, 3, 0);
            this.tlpTitle.Controls.Add(this.cmdMin, 4, 0);
            this.tlpTitle.Controls.Add(this.tlpVersionLabel, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(713, 50);
            this.tlpTitle.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
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
            // cmdMenu
            // 
            this.cmdMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMenu.FlatAppearance.BorderSize = 0;
            this.cmdMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.ForeColor = System.Drawing.Color.White;
            this.cmdMenu.Location = new System.Drawing.Point(563, 0);
            this.cmdMenu.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMenu.Size = new System.Drawing.Size(50, 50);
            this.cmdMenu.TabIndex = 0;
            this.cmdMenu.Text = "M";
            this.cmdMenu.UseVisualStyleBackColor = false;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
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
            this.cmdMin.Padding = new System.Windows.Forms.Padding(2, 10, 0, 1);
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
            this.tlpVersionLabel.Location = new System.Drawing.Point(503, 0);
            this.tlpVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVersionLabel.Name = "tlpVersionLabel";
            this.tlpVersionLabel.RowCount = 1;
            this.tlpVersionLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersionLabel.Size = new System.Drawing.Size(60, 50);
            this.tlpVersionLabel.TabIndex = 100;
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
            this.lblFilename.Size = new System.Drawing.Size(639, 36);
            this.lblFilename.TabIndex = 6;
            // 
            // mainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
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
            this.tlpSerial.ResumeLayout(false);
            this.tlpFsys.ResumeLayout(false);
            this.tlpEfiVer.ResumeLayout(false);
            this.tlpNvram.ResumeLayout(false);
            this.tlpIntelMe.ResumeLayout(false);
            this.cmsMainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).EndInit();
            this.cmsApplication.ResumeLayout(false);
            this.tlpMenu.ResumeLayout(false);
            this.cmsCopy.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpVersionLabel.ResumeLayout(false);
            this.tlpVersionLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFitVersionText;
        private System.Windows.Forms.Label lblChecksumText;
        private System.Windows.Forms.Label lblSizeBytesText;
        private System.Windows.Forms.Label lblFileCrc;
        private System.Windows.Forms.Label lblFileSizeBytes;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.Label lblBoardIdText;
        private System.Windows.Forms.Button cmdOpenBin;
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
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.ContextMenuStrip cmsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblFitVersion;
        private System.Windows.Forms.Label lblMeVersionText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplication;
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
        private System.Windows.Forms.Label lblEfiLock;
        private System.Windows.Forms.ToolStripMenuItem openBuildsDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFsysStoresDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.ContextMenuStrip cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crc32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createdDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
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
        internal System.Windows.Forms.Button cmdMenu;
        internal System.Windows.Forms.Button cmdMin;
        private System.Windows.Forms.TableLayoutPanel tlpVersionLabel;
    }
}