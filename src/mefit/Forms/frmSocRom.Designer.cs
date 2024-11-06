namespace Mac_EFI_Toolkit.Forms
{
    partial class frmSocRom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSocRom));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new METLabel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdMenuCopy = new System.Windows.Forms.Button();
            this.cmdMenuOpen = new System.Windows.Forms.Button();
            this.cmdMenuReset = new System.Windows.Forms.Button();
            this.cmdMenuPatch = new System.Windows.Forms.Button();
            this.cmdMenuExport = new System.Windows.Forms.Button();
            this.cmdMenuFolders = new System.Windows.Forms.Button();
            this.tlpFirmware = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilesizeText = new System.Windows.Forms.Label();
            this.lblFilenameText = new System.Windows.Forms.Label();
            this.lblFilename = new METLabel();
            this.lblFilesize = new System.Windows.Forms.Label();
            this.lblCrcText = new System.Windows.Forms.Label();
            this.lblCrc = new METLabel();
            this.lblCreatedText = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.lblModified = new METLabel();
            this.lblScfgText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.lblSerial = new METLabel();
            this.lblConfigText = new System.Windows.Forms.Label();
            this.lblConfigCode = new METLabel();
            this.lblSonText = new System.Windows.Forms.Label();
            this.lblSon = new METLabel();
            this.lblIbootText = new System.Windows.Forms.Label();
            this.lbliBoot = new System.Windows.Forms.Label();
            this.lblScfg = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSplit1 = new System.Windows.Forms.Panel();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblStatusBarTip = new System.Windows.Forms.Label();
            this.lblParseTime = new System.Windows.Forms.Label();
            this.pnlSplit0 = new System.Windows.Forms.Panel();
            this.lblView = new System.Windows.Forms.Label();
            this.cbxCensor = new Mac_EFI_Toolkit.UI.METSwitch();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.pnlSeperatorBottom = new System.Windows.Forms.Panel();
            this.cmsCopy = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.filenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.iBootVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scfgBaseAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scfgSizeDecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scfgSizeHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scfgCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolders = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.openBackupsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBuildsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSCFGFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.exportScfgStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.backupFirmwareZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFirmwareInformationTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpFirmware.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.cmsCopy.SuspendLayout();
            this.cmsFolders.SuspendLayout();
            this.cmsExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 4;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 3, 0);
            this.tlpTitle.Controls.Add(this.cmdMinimize, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(528, 50);
            this.tlpTitle.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.icon32;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 9);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(32, 32);
            this.pbxLogo.TabIndex = 100;
            this.pbxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(50, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(378, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SOCROM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(478, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            this.cmdMinimize.Location = new System.Drawing.Point(428, 0);
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
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.ColumnCount = 11;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpMenu.Controls.Add(this.cmdMenuCopy, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuPatch, 10, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuExport, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuFolders, 6, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 52);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(528, 32);
            this.tlpMenu.TabIndex = 0;
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
            this.cmdMenuCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuCopy.Location = new System.Drawing.Point(176, 0);
            this.cmdMenuCopy.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuCopy.Name = "cmdMenuCopy";
            this.cmdMenuCopy.Size = new System.Drawing.Size(87, 32);
            this.cmdMenuCopy.TabIndex = 2;
            this.cmdMenuCopy.Text = "COPY";
            this.cmdMenuCopy.UseVisualStyleBackColor = false;
            this.cmdMenuCopy.Click += new System.EventHandler(this.cmdMenuCopy_Click);
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
            this.cmdMenuOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuOpen.Location = new System.Drawing.Point(0, 0);
            this.cmdMenuOpen.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuOpen.Name = "cmdMenuOpen";
            this.cmdMenuOpen.Size = new System.Drawing.Size(87, 32);
            this.cmdMenuOpen.TabIndex = 0;
            this.cmdMenuOpen.Text = "OPEN";
            this.cmdMenuOpen.UseVisualStyleBackColor = false;
            this.cmdMenuOpen.Click += new System.EventHandler(this.cmdMenuOpen_Click);
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
            this.cmdMenuReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuReset.Location = new System.Drawing.Point(88, 0);
            this.cmdMenuReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuReset.Name = "cmdMenuReset";
            this.cmdMenuReset.Size = new System.Drawing.Size(87, 32);
            this.cmdMenuReset.TabIndex = 1;
            this.cmdMenuReset.Text = "RESET";
            this.cmdMenuReset.UseVisualStyleBackColor = false;
            this.cmdMenuReset.Click += new System.EventHandler(this.cmdMenuReset_Click);
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
            this.cmdMenuPatch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuPatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuPatch.Location = new System.Drawing.Point(440, 0);
            this.cmdMenuPatch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuPatch.Name = "cmdMenuPatch";
            this.cmdMenuPatch.Size = new System.Drawing.Size(88, 32);
            this.cmdMenuPatch.TabIndex = 5;
            this.cmdMenuPatch.Text = "PATCH";
            this.cmdMenuPatch.UseVisualStyleBackColor = false;
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
            this.cmdMenuExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuExport.Location = new System.Drawing.Point(352, 0);
            this.cmdMenuExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuExport.Name = "cmdMenuExport";
            this.cmdMenuExport.Size = new System.Drawing.Size(87, 32);
            this.cmdMenuExport.TabIndex = 4;
            this.cmdMenuExport.Text = "EXPORT";
            this.cmdMenuExport.UseVisualStyleBackColor = false;
            this.cmdMenuExport.Click += new System.EventHandler(this.cmdMenuExport_Click);
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
            this.cmdMenuFolders.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuFolders.Location = new System.Drawing.Point(264, 0);
            this.cmdMenuFolders.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuFolders.Name = "cmdMenuFolders";
            this.cmdMenuFolders.Size = new System.Drawing.Size(87, 32);
            this.cmdMenuFolders.TabIndex = 3;
            this.cmdMenuFolders.Text = "FOLDERS";
            this.cmdMenuFolders.UseVisualStyleBackColor = false;
            this.cmdMenuFolders.Click += new System.EventHandler(this.cmdMenuFolders_Click);
            // 
            // tlpFirmware
            // 
            this.tlpFirmware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpFirmware.ColumnCount = 3;
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFirmware.Controls.Add(this.lblFilesizeText, 0, 2);
            this.tlpFirmware.Controls.Add(this.lblFilenameText, 0, 0);
            this.tlpFirmware.Controls.Add(this.lblFilename, 2, 0);
            this.tlpFirmware.Controls.Add(this.lblFilesize, 2, 2);
            this.tlpFirmware.Controls.Add(this.lblCrcText, 0, 4);
            this.tlpFirmware.Controls.Add(this.lblCrc, 2, 4);
            this.tlpFirmware.Controls.Add(this.lblCreatedText, 0, 6);
            this.tlpFirmware.Controls.Add(this.lblCreated, 2, 6);
            this.tlpFirmware.Controls.Add(this.lblModifiedText, 0, 8);
            this.tlpFirmware.Controls.Add(this.lblModified, 2, 8);
            this.tlpFirmware.Controls.Add(this.lblScfgText, 0, 12);
            this.tlpFirmware.Controls.Add(this.lblSerialText, 0, 14);
            this.tlpFirmware.Controls.Add(this.lblSerial, 2, 14);
            this.tlpFirmware.Controls.Add(this.lblConfigText, 0, 16);
            this.tlpFirmware.Controls.Add(this.lblConfigCode, 2, 16);
            this.tlpFirmware.Controls.Add(this.lblSonText, 0, 18);
            this.tlpFirmware.Controls.Add(this.lblSon, 2, 18);
            this.tlpFirmware.Controls.Add(this.lblIbootText, 0, 10);
            this.tlpFirmware.Controls.Add(this.lbliBoot, 2, 10);
            this.tlpFirmware.Controls.Add(this.lblScfg, 2, 12);
            this.tlpFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFirmware.Enabled = false;
            this.tlpFirmware.Location = new System.Drawing.Point(0, 0);
            this.tlpFirmware.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFirmware.Name = "tlpFirmware";
            this.tlpFirmware.RowCount = 19;
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFirmware.Size = new System.Drawing.Size(528, 369);
            this.tlpFirmware.TabIndex = 0;
            // 
            // lblFilesizeText
            // 
            this.lblFilesizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilesizeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesizeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilesizeText.Location = new System.Drawing.Point(0, 37);
            this.lblFilesizeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeText.Name = "lblFilesizeText";
            this.lblFilesizeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilesizeText.Size = new System.Drawing.Size(130, 36);
            this.lblFilesizeText.TabIndex = 0;
            this.lblFilesizeText.Text = "SIZE";
            this.lblFilesizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilenameText
            // 
            this.lblFilenameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilenameText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilenameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilenameText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilenameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilenameText.Location = new System.Drawing.Point(0, 0);
            this.lblFilenameText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilenameText.Name = "lblFilenameText";
            this.lblFilenameText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilenameText.Size = new System.Drawing.Size(130, 36);
            this.lblFilenameText.TabIndex = 0;
            this.lblFilenameText.Text = "FILENAME";
            this.lblFilenameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoEllipsis = true;
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblFilename.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(131, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(397, 36);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFilename.UseMnemonic = false;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoEllipsis = true;
            this.lblFilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblFilesize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesize.ForeColor = System.Drawing.Color.White;
            this.lblFilesize.Location = new System.Drawing.Point(131, 37);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(397, 36);
            this.lblFilesize.TabIndex = 0;
            this.lblFilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrcText
            // 
            this.lblCrcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCrcText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrcText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCrcText.Location = new System.Drawing.Point(0, 74);
            this.lblCrcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrcText.Name = "lblCrcText";
            this.lblCrcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCrcText.Size = new System.Drawing.Size(130, 36);
            this.lblCrcText.TabIndex = 0;
            this.lblCrcText.Text = "CRC32";
            this.lblCrcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrc
            // 
            this.lblCrc.AutoEllipsis = true;
            this.lblCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblCrc.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrc.ForeColor = System.Drawing.Color.White;
            this.lblCrc.Location = new System.Drawing.Point(131, 74);
            this.lblCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrc.Name = "lblCrc";
            this.lblCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCrc.Size = new System.Drawing.Size(397, 36);
            this.lblCrc.TabIndex = 0;
            this.lblCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCrc.UseMnemonic = false;
            // 
            // lblCreatedText
            // 
            this.lblCreatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCreatedText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCreatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCreatedText.Location = new System.Drawing.Point(0, 111);
            this.lblCreatedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreatedText.Name = "lblCreatedText";
            this.lblCreatedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCreatedText.Size = new System.Drawing.Size(130, 36);
            this.lblCreatedText.TabIndex = 0;
            this.lblCreatedText.Text = "CREATED";
            this.lblCreatedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreated
            // 
            this.lblCreated.AutoEllipsis = true;
            this.lblCreated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblCreated.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.ForeColor = System.Drawing.Color.White;
            this.lblCreated.Location = new System.Drawing.Point(131, 111);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCreated.Size = new System.Drawing.Size(397, 36);
            this.lblCreated.TabIndex = 0;
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedText
            // 
            this.lblModifiedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblModifiedText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModifiedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModifiedText.Location = new System.Drawing.Point(0, 148);
            this.lblModifiedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModifiedText.Name = "lblModifiedText";
            this.lblModifiedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModifiedText.Size = new System.Drawing.Size(130, 36);
            this.lblModifiedText.TabIndex = 0;
            this.lblModifiedText.Text = "MODIFIED";
            this.lblModifiedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModified
            // 
            this.lblModified.AutoEllipsis = true;
            this.lblModified.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblModified.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModified.ForeColor = System.Drawing.Color.White;
            this.lblModified.Location = new System.Drawing.Point(131, 148);
            this.lblModified.Margin = new System.Windows.Forms.Padding(0);
            this.lblModified.Name = "lblModified";
            this.lblModified.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModified.Size = new System.Drawing.Size(397, 36);
            this.lblModified.TabIndex = 0;
            this.lblModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModified.UseMnemonic = false;
            // 
            // lblScfgText
            // 
            this.lblScfgText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblScfgText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblScfgText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfgText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfgText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblScfgText.Location = new System.Drawing.Point(0, 222);
            this.lblScfgText.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfgText.Name = "lblScfgText";
            this.lblScfgText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblScfgText.Size = new System.Drawing.Size(130, 36);
            this.lblScfgText.TabIndex = 0;
            this.lblScfgText.Text = "SCFG STORE";
            this.lblScfgText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSerialText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 259);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 36);
            this.lblSerialText.TabIndex = 0;
            this.lblSerialText.Text = "SERIAL";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoEllipsis = true;
            this.lblSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblSerial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.White;
            this.lblSerial.Location = new System.Drawing.Point(131, 259);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerial.Size = new System.Drawing.Size(397, 36);
            this.lblSerial.TabIndex = 0;
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerial.UseMnemonic = false;
            // 
            // lblConfigText
            // 
            this.lblConfigText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblConfigText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfigText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblConfigText.Location = new System.Drawing.Point(0, 296);
            this.lblConfigText.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigText.Name = "lblConfigText";
            this.lblConfigText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblConfigText.Size = new System.Drawing.Size(130, 36);
            this.lblConfigText.TabIndex = 0;
            this.lblConfigText.Text = "CONFIG";
            this.lblConfigText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigCode
            // 
            this.lblConfigCode.AutoEllipsis = true;
            this.lblConfigCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblConfigCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfigCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCode.ForeColor = System.Drawing.Color.White;
            this.lblConfigCode.Location = new System.Drawing.Point(131, 296);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(397, 36);
            this.lblConfigCode.TabIndex = 0;
            this.lblConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSonText
            // 
            this.lblSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSonText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSonText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSonText.Location = new System.Drawing.Point(0, 333);
            this.lblSonText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSonText.Name = "lblSonText";
            this.lblSonText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSonText.Size = new System.Drawing.Size(130, 36);
            this.lblSonText.TabIndex = 0;
            this.lblSonText.Text = "ORDER NO";
            this.lblSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSon
            // 
            this.lblSon.AutoEllipsis = true;
            this.lblSon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblSon.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.White;
            this.lblSon.Location = new System.Drawing.Point(131, 333);
            this.lblSon.Margin = new System.Windows.Forms.Padding(0);
            this.lblSon.Name = "lblSon";
            this.lblSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSon.Size = new System.Drawing.Size(397, 36);
            this.lblSon.TabIndex = 0;
            this.lblSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSon.UseMnemonic = false;
            // 
            // lblIbootText
            // 
            this.lblIbootText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblIbootText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblIbootText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIbootText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIbootText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblIbootText.Location = new System.Drawing.Point(0, 185);
            this.lblIbootText.Margin = new System.Windows.Forms.Padding(0);
            this.lblIbootText.Name = "lblIbootText";
            this.lblIbootText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblIbootText.Size = new System.Drawing.Size(130, 36);
            this.lblIbootText.TabIndex = 0;
            this.lblIbootText.Text = "IBOOT";
            this.lblIbootText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbliBoot
            // 
            this.lbliBoot.AutoEllipsis = true;
            this.lbliBoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lbliBoot.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbliBoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbliBoot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbliBoot.ForeColor = System.Drawing.Color.White;
            this.lbliBoot.Location = new System.Drawing.Point(131, 185);
            this.lbliBoot.Margin = new System.Windows.Forms.Padding(0);
            this.lbliBoot.Name = "lbliBoot";
            this.lbliBoot.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbliBoot.Size = new System.Drawing.Size(397, 36);
            this.lbliBoot.TabIndex = 0;
            this.lbliBoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScfg
            // 
            this.lblScfg.AutoEllipsis = true;
            this.lblScfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblScfg.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblScfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfg.ForeColor = System.Drawing.Color.White;
            this.lblScfg.Location = new System.Drawing.Point(131, 222);
            this.lblScfg.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfg.Name = "lblScfg";
            this.lblScfg.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblScfg.Size = new System.Drawing.Size(397, 36);
            this.lblScfg.TabIndex = 0;
            this.lblScfg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScfg.UseMnemonic = false;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpFirmware, 0, 0);
            this.tlpMain.Controls.Add(this.tlpStatusBar, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 85);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(528, 406);
            this.tlpMain.TabIndex = 101;
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBar.ColumnCount = 7;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.Controls.Add(this.pnlSplit1, 4, 0);
            this.tlpStatusBar.Controls.Add(this.tlpStatusBarImage, 6, 0);
            this.tlpStatusBar.Controls.Add(this.lblStatusBarTip, 5, 0);
            this.tlpStatusBar.Controls.Add(this.lblParseTime, 0, 0);
            this.tlpStatusBar.Controls.Add(this.pnlSplit0, 1, 0);
            this.tlpStatusBar.Controls.Add(this.lblView, 3, 0);
            this.tlpStatusBar.Controls.Add(this.cbxCensor, 2, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 370);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(528, 36);
            this.tlpStatusBar.TabIndex = 1;
            // 
            // pnlSplit1
            // 
            this.pnlSplit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSplit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlSplit1.Location = new System.Drawing.Point(138, 7);
            this.pnlSplit1.Name = "pnlSplit1";
            this.pnlSplit1.Size = new System.Drawing.Size(1, 22);
            this.pnlSplit1.TabIndex = 101;
            // 
            // tlpStatusBarImage
            // 
            this.tlpStatusBarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBarImage.ColumnCount = 1;
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBarImage.Controls.Add(this.pbxLoad, 0, 0);
            this.tlpStatusBarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBarImage.Location = new System.Drawing.Point(492, 0);
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
            this.lblStatusBarTip.Location = new System.Drawing.Point(141, 1);
            this.lblStatusBarTip.Margin = new System.Windows.Forms.Padding(1);
            this.lblStatusBarTip.Name = "lblStatusBarTip";
            this.lblStatusBarTip.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblStatusBarTip.Size = new System.Drawing.Size(350, 34);
            this.lblStatusBarTip.TabIndex = 0;
            this.lblStatusBarTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParseTime
            // 
            this.lblParseTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParseTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblParseTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParseTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
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
            this.pnlSplit0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlSplit0.Location = new System.Drawing.Point(73, 7);
            this.pnlSplit0.Name = "pnlSplit0";
            this.pnlSplit0.Size = new System.Drawing.Size(1, 22);
            this.pnlSplit0.TabIndex = 0;
            // 
            // lblView
            // 
            this.lblView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblView.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblView.Location = new System.Drawing.Point(111, 0);
            this.lblView.Margin = new System.Windows.Forms.Padding(0);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(24, 36);
            this.lblView.TabIndex = 0;
            this.lblView.Text = "...";
            this.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbxCensor.Location = new System.Drawing.Point(80, 10);
            this.cbxCensor.Name = "cbxCensor";
            this.cbxCensor.Size = new System.Drawing.Size(26, 16);
            this.cbxCensor.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.cbxCensor.TabIndex = 9;
            this.cbxCensor.CheckedChanged += new System.EventHandler(this.cbxCensor_CheckedChanged);
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 51);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(528, 1);
            this.pnlSeperatorTop.TabIndex = 102;
            // 
            // pnlSeperatorBottom
            // 
            this.pnlSeperatorBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorBottom.Location = new System.Drawing.Point(1, 84);
            this.pnlSeperatorBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorBottom.Name = "pnlSeperatorBottom";
            this.pnlSeperatorBottom.Size = new System.Drawing.Size(528, 1);
            this.pnlSeperatorBottom.TabIndex = 103;
            // 
            // cmsCopy
            // 
            this.cmsCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsCopy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsCopy.ForeColor = System.Drawing.Color.White;
            this.cmsCopy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenameToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.cRC32ToolStripMenuItem,
            this.creationDateToolStripMenuItem,
            this.modifiedDateToolStripMenuItem,
            this.toolStripSeparator1,
            this.iBootVersionToolStripMenuItem,
            this.scfgBaseAddressToolStripMenuItem,
            this.scfgSizeDecimalToolStripMenuItem,
            this.scfgSizeHexToolStripMenuItem,
            this.scfgCRC32ToolStripMenuItem,
            this.serialToolStripMenuItem,
            this.configToolStripMenuItem,
            this.orderNoToolStripMenuItem});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.ShowImageMargin = false;
            this.cmsCopy.Size = new System.Drawing.Size(199, 374);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // cRC32ToolStripMenuItem
            // 
            this.cRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cRC32ToolStripMenuItem.Name = "cRC32ToolStripMenuItem";
            this.cRC32ToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.cRC32ToolStripMenuItem.Text = "CRC32";
            this.cRC32ToolStripMenuItem.Click += new System.EventHandler(this.cRC32ToolStripMenuItem_Click);
            // 
            // creationDateToolStripMenuItem
            // 
            this.creationDateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.creationDateToolStripMenuItem.Name = "creationDateToolStripMenuItem";
            this.creationDateToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.creationDateToolStripMenuItem.Text = "Creation Date";
            this.creationDateToolStripMenuItem.Click += new System.EventHandler(this.creationDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // iBootVersionToolStripMenuItem
            // 
            this.iBootVersionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.iBootVersionToolStripMenuItem.Name = "iBootVersionToolStripMenuItem";
            this.iBootVersionToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.iBootVersionToolStripMenuItem.Text = "iBoot Version";
            this.iBootVersionToolStripMenuItem.Click += new System.EventHandler(this.iBootVersionToolStripMenuItem_Click);
            // 
            // scfgBaseAddressToolStripMenuItem
            // 
            this.scfgBaseAddressToolStripMenuItem.Name = "scfgBaseAddressToolStripMenuItem";
            this.scfgBaseAddressToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.scfgBaseAddressToolStripMenuItem.Text = "Scfg Base Address";
            this.scfgBaseAddressToolStripMenuItem.Click += new System.EventHandler(this.scfgBaseAddressToolStripMenuItem_Click);
            // 
            // scfgSizeDecimalToolStripMenuItem
            // 
            this.scfgSizeDecimalToolStripMenuItem.Name = "scfgSizeDecimalToolStripMenuItem";
            this.scfgSizeDecimalToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.scfgSizeDecimalToolStripMenuItem.Text = "Scfg Size (Decimal)";
            this.scfgSizeDecimalToolStripMenuItem.Click += new System.EventHandler(this.scfgSizeDecimalToolStripMenuItem_Click);
            // 
            // scfgSizeHexToolStripMenuItem
            // 
            this.scfgSizeHexToolStripMenuItem.Name = "scfgSizeHexToolStripMenuItem";
            this.scfgSizeHexToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.scfgSizeHexToolStripMenuItem.Text = "Scfg Size (Hex)";
            this.scfgSizeHexToolStripMenuItem.Click += new System.EventHandler(this.scfgSizeHexToolStripMenuItem_Click);
            // 
            // scfgCRC32ToolStripMenuItem
            // 
            this.scfgCRC32ToolStripMenuItem.Name = "scfgCRC32ToolStripMenuItem";
            this.scfgCRC32ToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.scfgCRC32ToolStripMenuItem.Text = "Scfg CRC32";
            this.scfgCRC32ToolStripMenuItem.Click += new System.EventHandler(this.scfgCRC32ToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
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
            this.openSCFGFolderToolStripMenuItem,
            this.toolStripSeparator3,
            this.openWorkingDirectoryToolStripMenuItem});
            this.cmsFolders.Name = "cmsFolders";
            this.cmsFolders.ShowImageMargin = false;
            this.cmsFolders.Size = new System.Drawing.Size(240, 122);
            // 
            // openBackupsFolderToolStripMenuItem
            // 
            this.openBackupsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.openBackupsFolderToolStripMenuItem.Name = "openBackupsFolderToolStripMenuItem";
            this.openBackupsFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openBackupsFolderToolStripMenuItem.Text = "Open Backups Folder";
            this.openBackupsFolderToolStripMenuItem.Click += new System.EventHandler(this.openBackupsFolderToolStripMenuItem_Click);
            // 
            // openBuildsFolderToolStripMenuItem
            // 
            this.openBuildsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.openBuildsFolderToolStripMenuItem.Name = "openBuildsFolderToolStripMenuItem";
            this.openBuildsFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openBuildsFolderToolStripMenuItem.Text = "Open Builds Folder";
            this.openBuildsFolderToolStripMenuItem.Click += new System.EventHandler(this.openBuildsFolderToolStripMenuItem_Click);
            // 
            // openSCFGFolderToolStripMenuItem
            // 
            this.openSCFGFolderToolStripMenuItem.Name = "openSCFGFolderToolStripMenuItem";
            this.openSCFGFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openSCFGFolderToolStripMenuItem.Text = "Open SCFG Folder";
            this.openSCFGFolderToolStripMenuItem.Click += new System.EventHandler(this.openSCFGFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            // 
            // openWorkingDirectoryToolStripMenuItem
            // 
            this.openWorkingDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.openWorkingDirectoryToolStripMenuItem.Name = "openWorkingDirectoryToolStripMenuItem";
            this.openWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openWorkingDirectoryToolStripMenuItem.Text = "Open Working Directory";
            this.openWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirectoryToolStripMenuItem_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsExport.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsExport.ForeColor = System.Drawing.Color.White;
            this.cmsExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportScfgStoreToolStripMenuItem,
            this.toolStripSeparator2,
            this.backupFirmwareZIPToolStripMenuItem,
            this.exportFirmwareInformationTextToolStripMenuItem});
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.ShowImageMargin = false;
            this.cmsExport.Size = new System.Drawing.Size(319, 94);
            // 
            // exportScfgStoreToolStripMenuItem
            // 
            this.exportScfgStoreToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.exportScfgStoreToolStripMenuItem.Name = "exportScfgStoreToolStripMenuItem";
            this.exportScfgStoreToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportScfgStoreToolStripMenuItem.Text = "Export Scfg Store";
            this.exportScfgStoreToolStripMenuItem.Click += new System.EventHandler(this.exportScfgStoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(315, 6);
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
            // frmSocRom
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(530, 492);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSeperatorBottom);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 492);
            this.Name = "frmSocRom";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "T2 SOCROM";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.tlpFirmware.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.tlpStatusBar.PerformLayout();
            this.tlpStatusBarImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.cmsCopy.ResumeLayout(false);
            this.cmsFolders.ResumeLayout(false);
            this.cmsExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        internal METLabel lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Button cmdMenuCopy;
        private System.Windows.Forms.Button cmdMenuOpen;
        private System.Windows.Forms.Button cmdMenuReset;
        private System.Windows.Forms.TableLayoutPanel tlpFirmware;
        private System.Windows.Forms.Label lblFilesizeText;
        private System.Windows.Forms.Label lblFilenameText;
        private METLabel lblFilename;
        private System.Windows.Forms.Label lblCrcText;
        private METLabel lblCrc;
        private System.Windows.Forms.Label lblCreatedText;
        private System.Windows.Forms.Label lblModifiedText;
        private METLabel lblModified;
        private System.Windows.Forms.Label lblScfgText;
        private System.Windows.Forms.Label lblSerialText;
        private METLabel lblSerial;
        private System.Windows.Forms.Label lblConfigText;
        private System.Windows.Forms.Label lblSonText;
        private METLabel lblSon;
        private METLabel lblConfigCode;
        private System.Windows.Forms.Label lblFilesize;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblIbootText;
        private System.Windows.Forms.Label lbliBoot;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.Panel pnlSeperatorBottom;
        private System.Windows.Forms.Button cmdMenuPatch;
        private System.Windows.Forms.Button cmdMenuExport;
        private System.Windows.Forms.Label lblScfg;
        internal System.Windows.Forms.Button cmdMinimize;
        private System.Windows.Forms.Button cmdMenuFolders;
        private UI.METContextMenuStrip cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem filenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem iBootVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scfgBaseAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scfgSizeDecimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scfgSizeHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scfgCRC32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderNoToolStripMenuItem;
        private UI.METContextMenuStrip cmsFolders;
        private System.Windows.Forms.ToolStripMenuItem openBackupsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBuildsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSCFGFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDirectoryToolStripMenuItem;
        private UI.METContextMenuStrip cmsExport;
        private System.Windows.Forms.ToolStripMenuItem exportScfgStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem backupFirmwareZIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFirmwareInformationTextToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.Panel pnlSplit1;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.PictureBox pbxLoad;
        private System.Windows.Forms.Label lblStatusBarTip;
        private System.Windows.Forms.Label lblParseTime;
        private System.Windows.Forms.Panel pnlSplit0;
        private System.Windows.Forms.Label lblView;
        private UI.METSwitch cbxCensor;
    }
}