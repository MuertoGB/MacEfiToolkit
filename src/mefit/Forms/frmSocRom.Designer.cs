using Mac_EFI_Toolkit.UI.Controls;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSocRom));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblPagefile = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdMenuOpen = new System.Windows.Forms.Button();
            this.cmdMenuCopy = new System.Windows.Forms.Button();
            this.cmdMenuFolders = new System.Windows.Forms.Button();
            this.cmdMenuExport = new System.Windows.Forms.Button();
            this.cmdMenuPatch = new System.Windows.Forms.Button();
            this.cmdMenuHelp = new System.Windows.Forms.Button();
            this.cmdMenuTools = new System.Windows.Forms.Button();
            this.tlpFirmware = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilesizeText = new System.Windows.Forms.Label();
            this.lblFilesize = new System.Windows.Forms.Label();
            this.lblCrcText = new System.Windows.Forms.Label();
            this.lblCrc = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblCreatedText = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.lblModified = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblScfgText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.lblConfigText = new System.Windows.Forms.Label();
            this.lblConfigCode = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblSonText = new System.Windows.Forms.Label();
            this.lblSon = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.lblIbootText = new System.Windows.Forms.Label();
            this.lbliBoot = new System.Windows.Forms.Label();
            this.lblScfg = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.lblSerial = new Mac_EFI_Toolkit.UI.Controls.METLabel();
            this.tlpSerialSwitch = new System.Windows.Forms.TableLayoutPanel();
            this.cbxCensor = new Mac_EFI_Toolkit.UI.METSwitch();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblStatusBarTip = new System.Windows.Forms.Label();
            this.lblParseTime = new System.Windows.Forms.Label();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.cmdOpenInExplorer = new System.Windows.Forms.Button();
            this.lblFilename = new Mac_EFI_Toolkit.UI.Controls.METLabel();
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
            this.cmsTools = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.lookupSerialNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileFromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPatch = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.changeSerialNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceScfgStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsHelp = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.viewApplicationLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpFirmware.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpSerialSwitch.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.tlpFilename.SuspendLayout();
            this.cmsCopy.SuspendLayout();
            this.cmsFolders.SuspendLayout();
            this.cmsExport.SuspendLayout();
            this.cmsTools.SuspendLayout();
            this.cmsPatch.SuspendLayout();
            this.cmsHelp.SuspendLayout();
            this.SuspendLayout();
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
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 4, 0);
            this.tlpTitle.Controls.Add(this.cmdMinimize, 3, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(608, 50);
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
            this.lblPagefile.Location = new System.Drawing.Point(479, 14);
            this.lblPagefile.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblPagefile.Name = "lblPagefile";
            this.lblPagefile.Size = new System.Drawing.Size(23, 22);
            this.lblPagefile.TabIndex = 101;
            this.lblPagefile.Text = "...";
            this.lblPagefile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPagefile.Visible = false;
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
            this.pbxLogo.TabIndex = 100;
            this.pbxLogo.TabStop = false;
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
            this.lblTitle.Size = new System.Drawing.Size(364, 50);
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
            this.cmdClose.Location = new System.Drawing.Point(558, 0);
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
            this.cmdMinimize.Location = new System.Drawing.Point(508, 0);
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
            this.tlpMenu.Controls.Add(this.cmdMenuCopy, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuFolders, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuExport, 6, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuPatch, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuHelp, 12, 0);
            this.tlpMenu.Controls.Add(this.cmdMenuTools, 10, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 52);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(608, 32);
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
            this.cmdMenuOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuOpen.Location = new System.Drawing.Point(0, 0);
            this.cmdMenuOpen.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuOpen.Name = "cmdMenuOpen";
            this.cmdMenuOpen.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuOpen.TabIndex = 0;
            this.cmdMenuOpen.Text = "OPEN";
            this.cmdMenuOpen.UseVisualStyleBackColor = false;
            this.cmdMenuOpen.Click += new System.EventHandler(this.cmdMenuOpen_Click);
            // 
            // cmdMenuCopy
            // 
            this.cmdMenuCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuCopy.FlatAppearance.BorderSize = 0;
            this.cmdMenuCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuCopy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuCopy.Location = new System.Drawing.Point(174, 0);
            this.cmdMenuCopy.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuCopy.Name = "cmdMenuCopy";
            this.cmdMenuCopy.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuCopy.TabIndex = 2;
            this.cmdMenuCopy.Text = "COPY";
            this.cmdMenuCopy.UseVisualStyleBackColor = false;
            this.cmdMenuCopy.Click += new System.EventHandler(this.cmdMenuCopy_Click);
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
            this.cmdMenuFolders.Location = new System.Drawing.Point(87, 0);
            this.cmdMenuFolders.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuFolders.Name = "cmdMenuFolders";
            this.cmdMenuFolders.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuFolders.TabIndex = 1;
            this.cmdMenuFolders.Text = "FOLDERS";
            this.cmdMenuFolders.UseVisualStyleBackColor = false;
            this.cmdMenuFolders.Click += new System.EventHandler(this.cmdMenuFolders_Click);
            // 
            // cmdMenuExport
            // 
            this.cmdMenuExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuExport.FlatAppearance.BorderSize = 0;
            this.cmdMenuExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuExport.Location = new System.Drawing.Point(261, 0);
            this.cmdMenuExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuExport.Name = "cmdMenuExport";
            this.cmdMenuExport.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuExport.TabIndex = 3;
            this.cmdMenuExport.Text = "EXPORT";
            this.cmdMenuExport.UseVisualStyleBackColor = false;
            this.cmdMenuExport.Click += new System.EventHandler(this.cmdMenuExport_Click);
            // 
            // cmdMenuPatch
            // 
            this.cmdMenuPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuPatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuPatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuPatch.FlatAppearance.BorderSize = 0;
            this.cmdMenuPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuPatch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuPatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuPatch.Location = new System.Drawing.Point(348, 0);
            this.cmdMenuPatch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuPatch.Name = "cmdMenuPatch";
            this.cmdMenuPatch.Size = new System.Drawing.Size(86, 32);
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
            this.cmdMenuHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuHelp.Location = new System.Drawing.Point(522, 0);
            this.cmdMenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuHelp.Name = "cmdMenuHelp";
            this.cmdMenuHelp.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuHelp.TabIndex = 6;
            this.cmdMenuHelp.Text = "HELP";
            this.cmdMenuHelp.UseVisualStyleBackColor = false;
            this.cmdMenuHelp.Click += new System.EventHandler(this.cmdMenuHelp_Click);
            // 
            // cmdMenuTools
            // 
            this.cmdMenuTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMenuTools.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMenuTools.FlatAppearance.BorderSize = 0;
            this.cmdMenuTools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMenuTools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMenuTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenuTools.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenuTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMenuTools.Location = new System.Drawing.Point(435, 0);
            this.cmdMenuTools.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenuTools.Name = "cmdMenuTools";
            this.cmdMenuTools.Size = new System.Drawing.Size(86, 32);
            this.cmdMenuTools.TabIndex = 5;
            this.cmdMenuTools.Text = "TOOLS";
            this.cmdMenuTools.UseVisualStyleBackColor = false;
            this.cmdMenuTools.Click += new System.EventHandler(this.cmdMenuTools_Click);
            // 
            // tlpFirmware
            // 
            this.tlpFirmware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpFirmware.ColumnCount = 3;
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFirmware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFirmware.Controls.Add(this.lblFilesizeText, 0, 0);
            this.tlpFirmware.Controls.Add(this.lblFilesize, 2, 0);
            this.tlpFirmware.Controls.Add(this.lblCrcText, 0, 2);
            this.tlpFirmware.Controls.Add(this.lblCrc, 2, 2);
            this.tlpFirmware.Controls.Add(this.lblCreatedText, 0, 4);
            this.tlpFirmware.Controls.Add(this.lblCreated, 2, 4);
            this.tlpFirmware.Controls.Add(this.lblModifiedText, 0, 6);
            this.tlpFirmware.Controls.Add(this.lblModified, 2, 6);
            this.tlpFirmware.Controls.Add(this.lblScfgText, 0, 10);
            this.tlpFirmware.Controls.Add(this.lblSerialText, 0, 12);
            this.tlpFirmware.Controls.Add(this.lblConfigText, 0, 14);
            this.tlpFirmware.Controls.Add(this.lblConfigCode, 2, 14);
            this.tlpFirmware.Controls.Add(this.lblSonText, 0, 16);
            this.tlpFirmware.Controls.Add(this.lblSon, 2, 16);
            this.tlpFirmware.Controls.Add(this.lblIbootText, 0, 8);
            this.tlpFirmware.Controls.Add(this.lbliBoot, 2, 8);
            this.tlpFirmware.Controls.Add(this.lblScfg, 2, 10);
            this.tlpFirmware.Controls.Add(this.tlpSerial, 2, 12);
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
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFirmware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFirmware.Size = new System.Drawing.Size(608, 332);
            this.tlpFirmware.TabIndex = 2;
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
            // lblFilesize
            // 
            this.lblFilesize.AutoEllipsis = true;
            this.lblFilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblFilesize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesize.ForeColor = System.Drawing.Color.White;
            this.lblFilesize.Location = new System.Drawing.Point(131, 0);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(477, 36);
            this.lblFilesize.TabIndex = 0;
            this.lblFilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrcText
            // 
            this.lblCrcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrcText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCrcText.Location = new System.Drawing.Point(0, 37);
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
            this.lblCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrc.ForeColor = System.Drawing.Color.White;
            this.lblCrc.Location = new System.Drawing.Point(131, 37);
            this.lblCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrc.Name = "lblCrc";
            this.lblCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCrc.Size = new System.Drawing.Size(477, 36);
            this.lblCrc.TabIndex = 0;
            this.lblCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCrc.UseMnemonic = false;
            // 
            // lblCreatedText
            // 
            this.lblCreatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCreatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCreatedText.Location = new System.Drawing.Point(0, 74);
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
            this.lblCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.ForeColor = System.Drawing.Color.White;
            this.lblCreated.Location = new System.Drawing.Point(131, 74);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCreated.Size = new System.Drawing.Size(477, 36);
            this.lblCreated.TabIndex = 0;
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedText
            // 
            this.lblModifiedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblModifiedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModifiedText.Location = new System.Drawing.Point(0, 111);
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
            this.lblModified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModified.ForeColor = System.Drawing.Color.White;
            this.lblModified.Location = new System.Drawing.Point(131, 111);
            this.lblModified.Margin = new System.Windows.Forms.Padding(0);
            this.lblModified.Name = "lblModified";
            this.lblModified.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModified.Size = new System.Drawing.Size(477, 36);
            this.lblModified.TabIndex = 0;
            this.lblModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModified.UseMnemonic = false;
            // 
            // lblScfgText
            // 
            this.lblScfgText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblScfgText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfgText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfgText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblScfgText.Location = new System.Drawing.Point(0, 185);
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
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 222);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 36);
            this.lblSerialText.TabIndex = 0;
            this.lblSerialText.Text = "SERIAL";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigText
            // 
            this.lblConfigText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblConfigText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblConfigText.Location = new System.Drawing.Point(0, 259);
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
            this.lblConfigCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCode.ForeColor = System.Drawing.Color.White;
            this.lblConfigCode.Location = new System.Drawing.Point(131, 259);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(477, 36);
            this.lblConfigCode.TabIndex = 0;
            this.lblConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSonText
            // 
            this.lblSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSonText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSonText.Location = new System.Drawing.Point(0, 296);
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
            this.lblSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.White;
            this.lblSon.Location = new System.Drawing.Point(131, 296);
            this.lblSon.Margin = new System.Windows.Forms.Padding(0);
            this.lblSon.Name = "lblSon";
            this.lblSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSon.Size = new System.Drawing.Size(477, 36);
            this.lblSon.TabIndex = 0;
            this.lblSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSon.UseMnemonic = false;
            // 
            // lblIbootText
            // 
            this.lblIbootText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblIbootText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIbootText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIbootText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblIbootText.Location = new System.Drawing.Point(0, 148);
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
            this.lbliBoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbliBoot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbliBoot.ForeColor = System.Drawing.Color.White;
            this.lbliBoot.Location = new System.Drawing.Point(131, 148);
            this.lbliBoot.Margin = new System.Windows.Forms.Padding(0);
            this.lbliBoot.Name = "lbliBoot";
            this.lbliBoot.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbliBoot.Size = new System.Drawing.Size(477, 36);
            this.lbliBoot.TabIndex = 0;
            this.lbliBoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScfg
            // 
            this.lblScfg.AutoEllipsis = true;
            this.lblScfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblScfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfg.ForeColor = System.Drawing.Color.White;
            this.lblScfg.Location = new System.Drawing.Point(131, 185);
            this.lblScfg.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfg.Name = "lblScfg";
            this.lblScfg.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblScfg.Size = new System.Drawing.Size(477, 36);
            this.lblScfg.TabIndex = 0;
            this.lblScfg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScfg.UseMnemonic = false;
            // 
            // tlpSerial
            // 
            this.tlpSerial.ColumnCount = 3;
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpSerial.Controls.Add(this.lblSerial, 0, 0);
            this.tlpSerial.Controls.Add(this.tlpSerialSwitch, 2, 0);
            this.tlpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerial.Location = new System.Drawing.Point(131, 222);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(477, 36);
            this.tlpSerial.TabIndex = 2;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoEllipsis = true;
            this.lblSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.White;
            this.lblSerial.Location = new System.Drawing.Point(0, 0);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerial.Size = new System.Drawing.Size(440, 36);
            this.lblSerial.TabIndex = 0;
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerial.UseMnemonic = false;
            // 
            // tlpSerialSwitch
            // 
            this.tlpSerialSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(50)))));
            this.tlpSerialSwitch.ColumnCount = 1;
            this.tlpSerialSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSerialSwitch.Controls.Add(this.cbxCensor, 0, 0);
            this.tlpSerialSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialSwitch.Location = new System.Drawing.Point(441, 0);
            this.tlpSerialSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialSwitch.Name = "tlpSerialSwitch";
            this.tlpSerialSwitch.RowCount = 1;
            this.tlpSerialSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpSerialSwitch.Size = new System.Drawing.Size(36, 36);
            this.tlpSerialSwitch.TabIndex = 3;
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
            this.cbxCensor.Name = "cbxCensor";
            this.cbxCensor.Size = new System.Drawing.Size(26, 16);
            this.cbxCensor.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.cbxCensor.TabIndex = 8;
            this.cbxCensor.CheckedChanged += new System.EventHandler(this.cbxCensor_CheckedChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpFirmware, 0, 2);
            this.tlpMain.Controls.Add(this.tlpStatusBar, 0, 4);
            this.tlpMain.Controls.Add(this.tlpFilename, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 85);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(608, 406);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBar.ColumnCount = 3;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.Controls.Add(this.tlpStatusBarImage, 2, 0);
            this.tlpStatusBar.Controls.Add(this.lblStatusBarTip, 1, 0);
            this.tlpStatusBar.Controls.Add(this.lblParseTime, 0, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 370);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(608, 36);
            this.tlpStatusBar.TabIndex = 3;
            // 
            // tlpStatusBarImage
            // 
            this.tlpStatusBarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBarImage.ColumnCount = 1;
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBarImage.Controls.Add(this.pbxLoad, 0, 0);
            this.tlpStatusBarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBarImage.Location = new System.Drawing.Point(572, 0);
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
            this.lblStatusBarTip.Location = new System.Drawing.Point(71, 1);
            this.lblStatusBarTip.Margin = new System.Windows.Forms.Padding(1);
            this.lblStatusBarTip.Name = "lblStatusBarTip";
            this.lblStatusBarTip.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatusBarTip.Size = new System.Drawing.Size(500, 34);
            this.lblStatusBarTip.TabIndex = 0;
            this.lblStatusBarTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParseTime
            // 
            this.lblParseTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblParseTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblParseTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblParseTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParseTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.lblParseTime.Location = new System.Drawing.Point(10, 7);
            this.lblParseTime.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblParseTime.Name = "lblParseTime";
            this.lblParseTime.Size = new System.Drawing.Size(56, 22);
            this.lblParseTime.TabIndex = 0;
            this.lblParseTime.Text = "0.00s";
            this.lblParseTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpFilename
            // 
            this.tlpFilename.ColumnCount = 3;
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilename.Controls.Add(this.cmdOpenInExplorer, 2, 0);
            this.tlpFilename.Controls.Add(this.lblFilename, 0, 0);
            this.tlpFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilename.Location = new System.Drawing.Point(0, 0);
            this.tlpFilename.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFilename.Name = "tlpFilename";
            this.tlpFilename.RowCount = 1;
            this.tlpFilename.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilename.Size = new System.Drawing.Size(608, 36);
            this.tlpFilename.TabIndex = 1;
            this.tlpFilename.TabStop = true;
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
            this.cmdOpenInExplorer.Location = new System.Drawing.Point(572, 0);
            this.cmdOpenInExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenInExplorer.Name = "cmdOpenInExplorer";
            this.cmdOpenInExplorer.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdOpenInExplorer.Size = new System.Drawing.Size(36, 36);
            this.cmdOpenInExplorer.TabIndex = 7;
            this.cmdOpenInExplorer.Text = "N";
            this.cmdOpenInExplorer.UseVisualStyleBackColor = false;
            this.cmdOpenInExplorer.Click += new System.EventHandler(this.cmdOpenInExplorer_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoEllipsis = true;
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(0, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(571, 36);
            this.lblFilename.TabIndex = 3;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFilename.UseMnemonic = false;
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 51);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(608, 1);
            this.pnlSeperatorTop.TabIndex = 102;
            // 
            // pnlSeperatorBottom
            // 
            this.pnlSeperatorBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorBottom.Location = new System.Drawing.Point(1, 84);
            this.pnlSeperatorBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorBottom.Name = "pnlSeperatorBottom";
            this.pnlSeperatorBottom.Size = new System.Drawing.Size(608, 1);
            this.pnlSeperatorBottom.TabIndex = 103;
            // 
            // cmsCopy
            // 
            this.cmsCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
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
            this.cmsCopy.Size = new System.Drawing.Size(202, 374);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // cRC32ToolStripMenuItem
            // 
            this.cRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cRC32ToolStripMenuItem.Name = "cRC32ToolStripMenuItem";
            this.cRC32ToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.cRC32ToolStripMenuItem.Text = "CRC32";
            this.cRC32ToolStripMenuItem.Click += new System.EventHandler(this.cRC32ToolStripMenuItem_Click);
            // 
            // creationDateToolStripMenuItem
            // 
            this.creationDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.creationDateToolStripMenuItem.Name = "creationDateToolStripMenuItem";
            this.creationDateToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.creationDateToolStripMenuItem.Text = "Creation Date";
            this.creationDateToolStripMenuItem.Click += new System.EventHandler(this.creationDateToolStripMenuItem_Click);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.Click += new System.EventHandler(this.modifiedDateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // iBootVersionToolStripMenuItem
            // 
            this.iBootVersionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.iBootVersionToolStripMenuItem.Name = "iBootVersionToolStripMenuItem";
            this.iBootVersionToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.iBootVersionToolStripMenuItem.Text = "iBoot Version";
            this.iBootVersionToolStripMenuItem.Click += new System.EventHandler(this.iBootVersionToolStripMenuItem_Click);
            // 
            // scfgBaseAddressToolStripMenuItem
            // 
            this.scfgBaseAddressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.scfgBaseAddressToolStripMenuItem.Name = "scfgBaseAddressToolStripMenuItem";
            this.scfgBaseAddressToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.scfgBaseAddressToolStripMenuItem.Text = "SCfg Base Address";
            this.scfgBaseAddressToolStripMenuItem.Click += new System.EventHandler(this.scfgBaseAddressToolStripMenuItem_Click);
            // 
            // scfgSizeDecimalToolStripMenuItem
            // 
            this.scfgSizeDecimalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.scfgSizeDecimalToolStripMenuItem.Name = "scfgSizeDecimalToolStripMenuItem";
            this.scfgSizeDecimalToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.scfgSizeDecimalToolStripMenuItem.Text = "SCfg Size (Decimal)";
            this.scfgSizeDecimalToolStripMenuItem.Click += new System.EventHandler(this.scfgSizeDecimalToolStripMenuItem_Click);
            // 
            // scfgSizeHexToolStripMenuItem
            // 
            this.scfgSizeHexToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.scfgSizeHexToolStripMenuItem.Name = "scfgSizeHexToolStripMenuItem";
            this.scfgSizeHexToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.scfgSizeHexToolStripMenuItem.Text = "SCfg Size (Hex)";
            this.scfgSizeHexToolStripMenuItem.Click += new System.EventHandler(this.scfgSizeHexToolStripMenuItem_Click);
            // 
            // scfgCRC32ToolStripMenuItem
            // 
            this.scfgCRC32ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.scfgCRC32ToolStripMenuItem.Name = "scfgCRC32ToolStripMenuItem";
            this.scfgCRC32ToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.scfgCRC32ToolStripMenuItem.Text = "SCfg CRC32";
            this.scfgCRC32ToolStripMenuItem.Click += new System.EventHandler(this.scfgCRC32ToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.serialToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // orderNoToolStripMenuItem
            // 
            this.orderNoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.orderNoToolStripMenuItem.Name = "orderNoToolStripMenuItem";
            this.orderNoToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.orderNoToolStripMenuItem.Text = "Order No";
            this.orderNoToolStripMenuItem.Click += new System.EventHandler(this.orderNoToolStripMenuItem_Click);
            // 
            // cmsFolders
            // 
            this.cmsFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
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
            // openSCFGFolderToolStripMenuItem
            // 
            this.openSCFGFolderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openSCFGFolderToolStripMenuItem.Name = "openSCFGFolderToolStripMenuItem";
            this.openSCFGFolderToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openSCFGFolderToolStripMenuItem.Text = "Open SCFG Folder";
            this.openSCFGFolderToolStripMenuItem.Click += new System.EventHandler(this.openSCFGFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            // 
            // openWorkingDirectoryToolStripMenuItem
            // 
            this.openWorkingDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openWorkingDirectoryToolStripMenuItem.Name = "openWorkingDirectoryToolStripMenuItem";
            this.openWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(239, 28);
            this.openWorkingDirectoryToolStripMenuItem.Text = "Open Working Directory";
            this.openWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirectoryToolStripMenuItem_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
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
            this.exportScfgStoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportScfgStoreToolStripMenuItem.Name = "exportScfgStoreToolStripMenuItem";
            this.exportScfgStoreToolStripMenuItem.Size = new System.Drawing.Size(318, 28);
            this.exportScfgStoreToolStripMenuItem.Text = "Export SCfg Store";
            this.exportScfgStoreToolStripMenuItem.Click += new System.EventHandler(this.exportScfgStoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(315, 6);
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
            // cmsTools
            // 
            this.cmsTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cmsTools.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsTools.ForeColor = System.Drawing.Color.White;
            this.cmsTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookupSerialNumberToolStripMenuItem,
            this.toolStripSeparator4,
            this.resetWindowToolStripMenuItem,
            this.reloadFileFromDiskToolStripMenuItem});
            this.cmsTools.Name = "cmsOptions";
            this.cmsTools.ShowImageMargin = false;
            this.cmsTools.Size = new System.Drawing.Size(245, 94);
            // 
            // lookupSerialNumberToolStripMenuItem
            // 
            this.lookupSerialNumberToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.lookupSerialNumberToolStripMenuItem.Name = "lookupSerialNumberToolStripMenuItem";
            this.lookupSerialNumberToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.lookupSerialNumberToolStripMenuItem.Text = "Lookup Serial Number";
            this.lookupSerialNumberToolStripMenuItem.Click += new System.EventHandler(this.lookupSerialNumberToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // resetWindowToolStripMenuItem
            // 
            this.resetWindowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetWindowToolStripMenuItem.Name = "resetWindowToolStripMenuItem";
            this.resetWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetWindowToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.resetWindowToolStripMenuItem.Text = "Reset Window";
            this.resetWindowToolStripMenuItem.Click += new System.EventHandler(this.resetWindowToolStripMenuItem_Click);
            // 
            // reloadFileFromDiskToolStripMenuItem
            // 
            this.reloadFileFromDiskToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reloadFileFromDiskToolStripMenuItem.Name = "reloadFileFromDiskToolStripMenuItem";
            this.reloadFileFromDiskToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadFileFromDiskToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.reloadFileFromDiskToolStripMenuItem.Text = "Reload File From Disk";
            this.reloadFileFromDiskToolStripMenuItem.Click += new System.EventHandler(this.reloadFileFromDiskToolStripMenuItem_Click);
            // 
            // cmsPatch
            // 
            this.cmsPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cmsPatch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsPatch.ForeColor = System.Drawing.Color.White;
            this.cmsPatch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSerialNumberToolStripMenuItem,
            this.replaceScfgStoreToolStripMenuItem});
            this.cmsPatch.Name = "cmsPatch";
            this.cmsPatch.ShowImageMargin = false;
            this.cmsPatch.Size = new System.Drawing.Size(229, 60);
            // 
            // changeSerialNumberToolStripMenuItem
            // 
            this.changeSerialNumberToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changeSerialNumberToolStripMenuItem.Name = "changeSerialNumberToolStripMenuItem";
            this.changeSerialNumberToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.changeSerialNumberToolStripMenuItem.Text = "Change Serial Number";
            this.changeSerialNumberToolStripMenuItem.Click += new System.EventHandler(this.changeSerialNumberToolStripMenuItem_Click);
            // 
            // replaceScfgStoreToolStripMenuItem
            // 
            this.replaceScfgStoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.replaceScfgStoreToolStripMenuItem.Name = "replaceScfgStoreToolStripMenuItem";
            this.replaceScfgStoreToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.replaceScfgStoreToolStripMenuItem.Text = "Write New SCfg Store";
            this.replaceScfgStoreToolStripMenuItem.Click += new System.EventHandler(this.replaceScfgStoreToolStripMenuItem_Click);
            // 
            // cmsHelp
            // 
            this.cmsHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cmsHelp.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmsHelp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.toolStripSeparator6,
            this.viewApplicationLogToolStripMenuItem,
            this.toolStripSeparator5,
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(248, 6);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(248, 6);
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
            // frmSocRom
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(610, 492);
            this.ControlBox = false;
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
            this.MaximumSize = new System.Drawing.Size(610, 492);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(610, 492);
            this.Name = "frmSocRom";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "T2 SOCROM";
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.tlpFirmware.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpSerialSwitch.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.tlpStatusBar.PerformLayout();
            this.tlpStatusBarImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.tlpFilename.ResumeLayout(false);
            this.cmsCopy.ResumeLayout(false);
            this.cmsFolders.ResumeLayout(false);
            this.cmsExport.ResumeLayout(false);
            this.cmsTools.ResumeLayout(false);
            this.cmsPatch.ResumeLayout(false);
            this.cmsHelp.ResumeLayout(false);
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
        private System.Windows.Forms.Button cmdMenuHelp;
        private System.Windows.Forms.TableLayoutPanel tlpFirmware;
        private System.Windows.Forms.Label lblFilesizeText;
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
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.PictureBox pbxLoad;
        private System.Windows.Forms.Label lblStatusBarTip;
        private System.Windows.Forms.Label lblParseTime;
        private UI.METSwitch cbxCensor;
        private System.Windows.Forms.Button cmdMenuTools;
        private UI.METContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem reloadFileFromDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem lookupSerialNumberToolStripMenuItem;
        private UI.METContextMenuStrip cmsPatch;
        private System.Windows.Forms.ToolStripMenuItem changeSerialNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceScfgStoreToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpFilename;
        private METLabel lblFilename;
        private System.Windows.Forms.Button cmdOpenInExplorer;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.TableLayoutPanel tlpSerialSwitch;
        private System.Windows.Forms.ToolStripMenuItem resetWindowToolStripMenuItem;
        private UI.METContextMenuStrip cmsHelp;
        private System.Windows.Forms.ToolStripMenuItem viewApplicationLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblPagefile;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}