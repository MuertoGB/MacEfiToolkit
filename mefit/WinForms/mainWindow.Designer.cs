
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
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblPrivateMemory = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFilename = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new System.Windows.Forms.Label();
            this.cmdReload = new System.Windows.Forms.Button();
            this.cmdNavigate = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this.tlpFile = new System.Windows.Forms.TableLayoutPanel();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblModified = new System.Windows.Forms.Label();
            this.lblFileChecksum = new System.Windows.Forms.Label();
            this.lblCreatedText = new System.Windows.Forms.Label();
            this.lblFilesizeBytes = new System.Windows.Forms.Label();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.lblSizeBytesText = new System.Windows.Forms.Label();
            this.lblChecksumText = new System.Windows.Forms.Label();
            this.tlpEfi = new System.Windows.Forms.TableLayoutPanel();
            this.lblSon = new System.Windows.Forms.Label();
            this.lblMeVersion = new System.Windows.Forms.Label();
            this.lblSonText = new System.Windows.Forms.Label();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.lblApfsCapable = new System.Windows.Forms.Label();
            this.lblRomVersionText = new System.Windows.Forms.Label();
            this.lblFsysCrcText = new System.Windows.Forms.Label();
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
            this.lblRomVersion = new System.Windows.Forms.Label();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.lblFsysCrc = new System.Windows.Forms.Label();
            this.cmdFixFsysCrc = new System.Windows.Forms.Button();
            this.cmdExportFsysBlock = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.cmdEditEfirom = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdOpenBin = new System.Windows.Forms.Button();
            this.cmsMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.tlpVersionLabel = new System.Windows.Forms.TableLayoutPanel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.tlpMainIcon = new System.Windows.Forms.TableLayoutPanel();
            this.pbxTitleLogo = new System.Windows.Forms.PictureBox();
            this.cmdMin = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmsApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartApplicationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmsFsysMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceFsysBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpFilename.SuspendLayout();
            this.tlpFile.SuspendLayout();
            this.tlpEfi.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.cmsMainMenu.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.tlpVersionLabel.SuspendLayout();
            this.tlpMainIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).BeginInit();
            this.cmsApplication.SuspendLayout();
            this.tlpMenu.SuspendLayout();
            this.cmsFsysMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpBottom);
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Controls.Add(this.pnlSeperator);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 89);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(713, 330);
            this.pnlMain.TabIndex = 2;
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.Controls.Add(this.lblMessage, 0, 0);
            this.tlpBottom.Controls.Add(this.lblPrivateMemory, 2, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 294);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(713, 36);
            this.tlpBottom.TabIndex = 99;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(1);
            this.lblMessage.Size = new System.Drawing.Size(627, 36);
            this.lblMessage.TabIndex = 99;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrivateMemory
            // 
            this.lblPrivateMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblPrivateMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrivateMemory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateMemory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblPrivateMemory.Location = new System.Drawing.Point(628, 0);
            this.lblPrivateMemory.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrivateMemory.Name = "lblPrivateMemory";
            this.lblPrivateMemory.Size = new System.Drawing.Size(85, 36);
            this.lblPrivateMemory.TabIndex = 99;
            this.lblPrivateMemory.Text = "...";
            this.lblPrivateMemory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpFilename, 0, 0);
            this.tlpMain.Controls.Add(this.lblModel, 0, 4);
            this.tlpMain.Controls.Add(this.tlpFile, 0, 2);
            this.tlpMain.Controls.Add(this.tlpEfi, 0, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.tlpMain.Size = new System.Drawing.Size(713, 292);
            this.tlpMain.TabIndex = 3;
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
            this.tlpFilename.Controls.Add(this.lblFilename, 0, 0);
            this.tlpFilename.Controls.Add(this.cmdReload, 4, 0);
            this.tlpFilename.Controls.Add(this.cmdNavigate, 2, 0);
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
            this.lblFilename.AutoEllipsis = true;
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(0, 0);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(639, 36);
            this.lblFilename.TabIndex = 99;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdReload
            // 
            this.cmdReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdReload.FlatAppearance.BorderSize = 0;
            this.cmdReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdReload.Location = new System.Drawing.Point(677, 0);
            this.cmdReload.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Size = new System.Drawing.Size(36, 36);
            this.cmdReload.TabIndex = 5;
            this.cmdReload.Text = "R";
            this.cmdReload.UseVisualStyleBackColor = false;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // cmdNavigate
            // 
            this.cmdNavigate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdNavigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdNavigate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdNavigate.FlatAppearance.BorderSize = 0;
            this.cmdNavigate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdNavigate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.cmdNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNavigate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNavigate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdNavigate.Location = new System.Drawing.Point(640, 0);
            this.cmdNavigate.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNavigate.Name = "cmdNavigate";
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
            this.lblModel.TabIndex = 9;
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
            this.tlpFile.Controls.Add(this.lblCreated, 2, 2);
            this.tlpFile.Controls.Add(this.lblModified, 6, 2);
            this.tlpFile.Controls.Add(this.lblFileChecksum, 6, 0);
            this.tlpFile.Controls.Add(this.lblCreatedText, 0, 2);
            this.tlpFile.Controls.Add(this.lblFilesizeBytes, 2, 0);
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
            this.tlpFile.TabIndex = 1;
            // 
            // lblCreated
            // 
            this.lblCreated.AutoEllipsis = true;
            this.lblCreated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreated.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.ForeColor = System.Drawing.Color.White;
            this.lblCreated.Location = new System.Drawing.Point(131, 31);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCreated.Size = new System.Drawing.Size(225, 30);
            this.lblCreated.TabIndex = 99;
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModified
            // 
            this.lblModified.AutoEllipsis = true;
            this.lblModified.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblModified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModified.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModified.ForeColor = System.Drawing.Color.White;
            this.lblModified.Location = new System.Drawing.Point(488, 31);
            this.lblModified.Margin = new System.Windows.Forms.Padding(0);
            this.lblModified.Name = "lblModified";
            this.lblModified.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModified.Size = new System.Drawing.Size(225, 30);
            this.lblModified.TabIndex = 99;
            this.lblModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileChecksum
            // 
            this.lblFileChecksum.AutoEllipsis = true;
            this.lblFileChecksum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblFileChecksum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileChecksum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileChecksum.ForeColor = System.Drawing.Color.White;
            this.lblFileChecksum.Location = new System.Drawing.Point(488, 0);
            this.lblFileChecksum.Margin = new System.Windows.Forms.Padding(0);
            this.lblFileChecksum.Name = "lblFileChecksum";
            this.lblFileChecksum.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFileChecksum.Size = new System.Drawing.Size(225, 30);
            this.lblFileChecksum.TabIndex = 99;
            this.lblFileChecksum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblCreatedText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblCreatedText.Size = new System.Drawing.Size(130, 30);
            this.lblCreatedText.TabIndex = 99;
            this.lblCreatedText.Text = "Created:";
            this.lblCreatedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesizeBytes
            // 
            this.lblFilesizeBytes.AutoEllipsis = true;
            this.lblFilesizeBytes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblFilesizeBytes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeBytes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeBytes.ForeColor = System.Drawing.Color.White;
            this.lblFilesizeBytes.Location = new System.Drawing.Point(131, 0);
            this.lblFilesizeBytes.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeBytes.Name = "lblFilesizeBytes";
            this.lblFilesizeBytes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesizeBytes.Size = new System.Drawing.Size(225, 30);
            this.lblFilesizeBytes.TabIndex = 99;
            this.lblFilesizeBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblModifiedText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
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
            this.lblSizeBytesText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
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
            this.lblChecksumText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblChecksumText.Size = new System.Drawing.Size(130, 30);
            this.lblChecksumText.TabIndex = 99;
            this.lblChecksumText.Text = "CRC32:";
            this.lblChecksumText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfi
            // 
            this.tlpEfi.ColumnCount = 7;
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEfi.Controls.Add(this.lblSon, 6, 8);
            this.tlpEfi.Controls.Add(this.lblMeVersion, 6, 6);
            this.tlpEfi.Controls.Add(this.lblSonText, 4, 8);
            this.tlpEfi.Controls.Add(this.lblEfiVersion, 2, 4);
            this.tlpEfi.Controls.Add(this.lblApfsCapable, 6, 2);
            this.tlpEfi.Controls.Add(this.lblRomVersionText, 4, 4);
            this.tlpEfi.Controls.Add(this.lblFsysCrcText, 0, 2);
            this.tlpEfi.Controls.Add(this.lblApfsCapableText, 4, 2);
            this.tlpEfi.Controls.Add(this.lblEfiVersionText, 0, 4);
            this.tlpEfi.Controls.Add(this.lblBoardId, 2, 8);
            this.tlpEfi.Controls.Add(this.lblMeVersionText, 4, 6);
            this.tlpEfi.Controls.Add(this.lblFitVersion, 2, 6);
            this.tlpEfi.Controls.Add(this.lblBoardIdText, 0, 8);
            this.tlpEfi.Controls.Add(this.lblFitVersionText, 0, 6);
            this.tlpEfi.Controls.Add(this.lblHwc, 6, 0);
            this.tlpEfi.Controls.Add(this.lblSerialText, 0, 0);
            this.tlpEfi.Controls.Add(this.tlpSerial, 2, 0);
            this.tlpEfi.Controls.Add(this.lblHwcText, 4, 0);
            this.tlpEfi.Controls.Add(this.lblRomVersion, 6, 4);
            this.tlpEfi.Controls.Add(this.tlpFsys, 2, 2);
            this.tlpEfi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfi.Location = new System.Drawing.Point(0, 136);
            this.tlpEfi.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfi.Name = "tlpEfi";
            this.tlpEfi.RowCount = 9;
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEfi.Size = new System.Drawing.Size(713, 154);
            this.tlpEfi.TabIndex = 2;
            // 
            // lblSon
            // 
            this.lblSon.AutoEllipsis = true;
            this.lblSon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.White;
            this.lblSon.Location = new System.Drawing.Point(488, 124);
            this.lblSon.Margin = new System.Windows.Forms.Padding(0);
            this.lblSon.Name = "lblSon";
            this.lblSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSon.Size = new System.Drawing.Size(225, 30);
            this.lblSon.TabIndex = 99;
            this.lblSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMeVersion
            // 
            this.lblMeVersion.AutoEllipsis = true;
            this.lblMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblMeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeVersion.ForeColor = System.Drawing.Color.White;
            this.lblMeVersion.Location = new System.Drawing.Point(488, 93);
            this.lblMeVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeVersion.Name = "lblMeVersion";
            this.lblMeVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMeVersion.Size = new System.Drawing.Size(225, 30);
            this.lblMeVersion.TabIndex = 99;
            this.lblMeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblSonText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblSonText.Size = new System.Drawing.Size(130, 30);
            this.lblSonText.TabIndex = 99;
            this.lblSonText.Text = "Order No:";
            this.lblSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersion.ForeColor = System.Drawing.Color.White;
            this.lblEfiVersion.Location = new System.Drawing.Point(131, 62);
            this.lblEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersion.Name = "lblEfiVersion";
            this.lblEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiVersion.Size = new System.Drawing.Size(225, 30);
            this.lblEfiVersion.TabIndex = 99;
            this.lblEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApfsCapable
            // 
            this.lblApfsCapable.AutoEllipsis = true;
            this.lblApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApfsCapable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApfsCapable.ForeColor = System.Drawing.Color.White;
            this.lblApfsCapable.Location = new System.Drawing.Point(488, 31);
            this.lblApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.lblApfsCapable.Name = "lblApfsCapable";
            this.lblApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblApfsCapable.Size = new System.Drawing.Size(225, 30);
            this.lblApfsCapable.TabIndex = 99;
            this.lblApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRomVersionText
            // 
            this.lblRomVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblRomVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRomVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRomVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblRomVersionText.Location = new System.Drawing.Point(357, 62);
            this.lblRomVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblRomVersionText.Name = "lblRomVersionText";
            this.lblRomVersionText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblRomVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblRomVersionText.TabIndex = 99;
            this.lblRomVersionText.Text = "ROM Version:";
            this.lblRomVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFsysCrcText
            // 
            this.lblFsysCrcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lblFsysCrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysCrcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysCrcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysCrcText.Location = new System.Drawing.Point(0, 31);
            this.lblFsysCrcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysCrcText.Name = "lblFsysCrcText";
            this.lblFsysCrcText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblFsysCrcText.Size = new System.Drawing.Size(130, 30);
            this.lblFsysCrcText.TabIndex = 99;
            this.lblFsysCrcText.Text = "Fsys CRC32:";
            this.lblFsysCrcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblApfsCapableText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
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
            this.lblEfiVersionText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblEfiVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblEfiVersionText.TabIndex = 99;
            this.lblEfiVersionText.Text = "EFI Version:";
            this.lblEfiVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoEllipsis = true;
            this.lblBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBoardId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblMeVersionText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblMeVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblMeVersionText.TabIndex = 99;
            this.lblMeVersionText.Text = "ME Version:";
            this.lblMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFitVersion
            // 
            this.lblFitVersion.AutoEllipsis = true;
            this.lblFitVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFitVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFitVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblBoardIdText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblBoardIdText.Size = new System.Drawing.Size(130, 30);
            this.lblBoardIdText.TabIndex = 99;
            this.lblBoardIdText.Text = "Board-ID:";
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
            this.lblFitVersionText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblFitVersionText.Size = new System.Drawing.Size(130, 30);
            this.lblFitVersionText.TabIndex = 99;
            this.lblFitVersionText.Text = "FIT Version:";
            this.lblFitVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHwc
            // 
            this.lblHwc.AutoEllipsis = true;
            this.lblHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblHwc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHwc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
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
            this.cmdEveryMacSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdEveryMacSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEveryMacSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdEveryMacSearch.FlatAppearance.BorderSize = 0;
            this.cmdEveryMacSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdEveryMacSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.cmdEveryMacSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEveryMacSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEveryMacSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdEveryMacSearch.Location = new System.Drawing.Point(195, 0);
            this.cmdEveryMacSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEveryMacSearch.Name = "cmdEveryMacSearch";
            this.cmdEveryMacSearch.Size = new System.Drawing.Size(30, 30);
            this.cmdEveryMacSearch.TabIndex = 0;
            this.cmdEveryMacSearch.Text = "C";
            this.cmdEveryMacSearch.UseVisualStyleBackColor = false;
            this.cmdEveryMacSearch.Click += new System.EventHandler(this.cmdEveryMacSearch_Click);
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoEllipsis = true;
            this.lblSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblHwcText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblHwcText.Size = new System.Drawing.Size(130, 30);
            this.lblHwcText.TabIndex = 99;
            this.lblHwcText.Text = "Config Code:";
            this.lblHwcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRomVersion
            // 
            this.lblRomVersion.AutoEllipsis = true;
            this.lblRomVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblRomVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRomVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRomVersion.ForeColor = System.Drawing.Color.White;
            this.lblRomVersion.Location = new System.Drawing.Point(488, 62);
            this.lblRomVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblRomVersion.Name = "lblRomVersion";
            this.lblRomVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblRomVersion.Size = new System.Drawing.Size(225, 30);
            this.lblRomVersion.TabIndex = 99;
            this.lblRomVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpFsys.Controls.Add(this.cmdFixFsysCrc, 4, 0);
            this.tlpFsys.Controls.Add(this.cmdExportFsysBlock, 2, 0);
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
            this.lblFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFsysCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysCrc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmdFixFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdFixFsysCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFixFsysCrc.Enabled = false;
            this.cmdFixFsysCrc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdFixFsysCrc.FlatAppearance.BorderSize = 0;
            this.cmdFixFsysCrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdFixFsysCrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.cmdFixFsysCrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFixFsysCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFixFsysCrc.ForeColor = System.Drawing.Color.White;
            this.cmdFixFsysCrc.Location = new System.Drawing.Point(195, 0);
            this.cmdFixFsysCrc.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFixFsysCrc.Name = "cmdFixFsysCrc";
            this.cmdFixFsysCrc.Size = new System.Drawing.Size(30, 30);
            this.cmdFixFsysCrc.TabIndex = 1;
            this.cmdFixFsysCrc.Text = "F";
            this.cmdFixFsysCrc.UseVisualStyleBackColor = false;
            this.cmdFixFsysCrc.Click += new System.EventHandler(this.cmdFixFsysCrc_Click);
            // 
            // cmdExportFsysBlock
            // 
            this.cmdExportFsysBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdExportFsysBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportFsysBlock.Enabled = false;
            this.cmdExportFsysBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.cmdExportFsysBlock.FlatAppearance.BorderSize = 0;
            this.cmdExportFsysBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdExportFsysBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.cmdExportFsysBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportFsysBlock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportFsysBlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdExportFsysBlock.Location = new System.Drawing.Point(164, 0);
            this.cmdExportFsysBlock.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportFsysBlock.Name = "cmdExportFsysBlock";
            this.cmdExportFsysBlock.Size = new System.Drawing.Size(30, 30);
            this.cmdExportFsysBlock.TabIndex = 0;
            this.cmdExportFsysBlock.Text = "E";
            this.cmdExportFsysBlock.UseVisualStyleBackColor = false;
            this.cmdExportFsysBlock.Click += new System.EventHandler(this.cmdExportFsysBlock_Click);
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(0, 0);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(713, 2);
            this.pnlSeperator.TabIndex = 94;
            // 
            // cmdEditEfirom
            // 
            this.cmdEditEfirom.BackColor = System.Drawing.Color.Transparent;
            this.cmdEditEfirom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditEfirom.Enabled = false;
            this.cmdEditEfirom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdEditEfirom.FlatAppearance.BorderSize = 0;
            this.cmdEditEfirom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdEditEfirom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cmdEditEfirom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditEfirom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditEfirom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdEditEfirom.Location = new System.Drawing.Point(162, 0);
            this.cmdEditEfirom.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditEfirom.Name = "cmdEditEfirom";
            this.cmdEditEfirom.Size = new System.Drawing.Size(100, 38);
            this.cmdEditEfirom.TabIndex = 3;
            this.cmdEditEfirom.Text = "EDIT ROM";
            this.cmdEditEfirom.UseVisualStyleBackColor = false;
            this.cmdEditEfirom.Click += new System.EventHandler(this.cmdEditEfirom_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.Transparent;
            this.cmdReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdReset.FlatAppearance.BorderSize = 0;
            this.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdReset.Location = new System.Drawing.Point(81, 0);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(80, 38);
            this.cmdReset.TabIndex = 2;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdResetUnload_Click);
            // 
            // cmdOpenBin
            // 
            this.cmdOpenBin.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpenBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpenBin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdOpenBin.FlatAppearance.BorderSize = 0;
            this.cmdOpenBin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdOpenBin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cmdOpenBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenBin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenBin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.cmdOpenBin.Location = new System.Drawing.Point(0, 0);
            this.cmdOpenBin.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenBin.Name = "cmdOpenBin";
            this.cmdOpenBin.Size = new System.Drawing.Size(80, 38);
            this.cmdOpenBin.TabIndex = 1;
            this.cmdOpenBin.Text = "OPEN";
            this.cmdOpenBin.UseVisualStyleBackColor = false;
            this.cmdOpenBin.Click += new System.EventHandler(this.cmdOpenBin_Click);
            // 
            // cmsMainMenu
            // 
            this.cmsMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsMainMenu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.restartApplicationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.cmsMainMenu.Name = "cmsMainMenu";
            this.cmsMainMenu.ShowImageMargin = false;
            this.cmsMainMenu.Size = new System.Drawing.Size(276, 128);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.ShortcutKeyDisplayString = "Shift + V";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(275, 28);
            this.viewLogToolStripMenuItem.Text = "View Log";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(272, 6);
            // 
            // restartApplicationToolStripMenuItem
            // 
            this.restartApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.restartApplicationToolStripMenuItem.Name = "restartApplicationToolStripMenuItem";
            this.restartApplicationToolStripMenuItem.ShortcutKeyDisplayString = "Shift + R";
            this.restartApplicationToolStripMenuItem.Size = new System.Drawing.Size(275, 28);
            this.restartApplicationToolStripMenuItem.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeyDisplayString = "Shift + S";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(275, 28);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(272, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = "Shift + A";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(275, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pnlTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.pnlTitle.Controls.Add(this.lblWindowTitle);
            this.pnlTitle.Controls.Add(this.tlpVersionLabel);
            this.pnlTitle.Controls.Add(this.cmdMenu);
            this.pnlTitle.Controls.Add(this.tlpMainIcon);
            this.pnlTitle.Controls.Add(this.cmdMin);
            this.pnlTitle.Controls.Add(this.cmdClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(1, 1);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(713, 50);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(45, 0);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(453, 50);
            this.lblWindowTitle.TabIndex = 99;
            this.lblWindowTitle.Text = " Mac EFI Toolkit";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpVersionLabel
            // 
            this.tlpVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.tlpVersionLabel.ColumnCount = 1;
            this.tlpVersionLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVersionLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpVersionLabel.Controls.Add(this.lblVersion, 0, 0);
            this.tlpVersionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpVersionLabel.Location = new System.Drawing.Point(498, 0);
            this.tlpVersionLabel.Margin = new System.Windows.Forms.Padding(2);
            this.tlpVersionLabel.Name = "tlpVersionLabel";
            this.tlpVersionLabel.RowCount = 1;
            this.tlpVersionLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVersionLabel.Size = new System.Drawing.Size(65, 50);
            this.tlpVersionLabel.TabIndex = 99;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(14, 14);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(43, 22);
            this.lblVersion.TabIndex = 99;
            this.lblVersion.Text = "0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdMenu
            // 
            this.cmdMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMenu.FlatAppearance.BorderSize = 0;
            this.cmdMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cmdMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.ForeColor = System.Drawing.Color.White;
            this.cmdMenu.Location = new System.Drawing.Point(563, 0);
            this.cmdMenu.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMenu.Size = new System.Drawing.Size(50, 50);
            this.cmdMenu.TabIndex = 0;
            this.cmdMenu.Text = "S";
            this.cmdMenu.UseVisualStyleBackColor = false;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // tlpMainIcon
            // 
            this.tlpMainIcon.BackColor = System.Drawing.Color.Transparent;
            this.tlpMainIcon.ColumnCount = 1;
            this.tlpMainIcon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 656F));
            this.tlpMainIcon.Controls.Add(this.pbxTitleLogo, 0, 0);
            this.tlpMainIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpMainIcon.Location = new System.Drawing.Point(0, 0);
            this.tlpMainIcon.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainIcon.Name = "tlpMainIcon";
            this.tlpMainIcon.RowCount = 1;
            this.tlpMainIcon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainIcon.Size = new System.Drawing.Size(45, 50);
            this.tlpMainIcon.TabIndex = 99;
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
            // cmdMin
            // 
            this.cmdMin.BackColor = System.Drawing.Color.Transparent;
            this.cmdMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMin.FlatAppearance.BorderSize = 0;
            this.cmdMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.cmdMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
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
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(663, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 99;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "✕";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmsApplication
            // 
            this.cmsApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.resetPositionToolStripMenuItem,
            this.restartApplicationToolStripMenuItem1,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.cmsApplication.Name = "cmsApplication";
            this.cmsApplication.ShowImageMargin = false;
            this.cmsApplication.Size = new System.Drawing.Size(199, 122);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // resetPositionToolStripMenuItem
            // 
            this.resetPositionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPositionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetPositionToolStripMenuItem.Name = "resetPositionToolStripMenuItem";
            this.resetPositionToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.resetPositionToolStripMenuItem.Text = "Reset Position";
            this.resetPositionToolStripMenuItem.Click += new System.EventHandler(this.resetPositionToolStripMenuItem_Click);
            // 
            // restartApplicationToolStripMenuItem1
            // 
            this.restartApplicationToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartApplicationToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.restartApplicationToolStripMenuItem1.Name = "restartApplicationToolStripMenuItem1";
            this.restartApplicationToolStripMenuItem1.Size = new System.Drawing.Size(198, 28);
            this.restartApplicationToolStripMenuItem1.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem1.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpMenu.ColumnCount = 7;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 351F));
            this.tlpMenu.Controls.Add(this.cmdOpenBin, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdEditEfirom, 4, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 51);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(713, 38);
            this.tlpMenu.TabIndex = 1;
            // 
            // cmsFsysMenu
            // 
            this.cmsFsysMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsFsysMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFsysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceFsysBlockToolStripMenuItem});
            this.cmsFsysMenu.Name = "contextMenuStrip1";
            this.cmsFsysMenu.ShowImageMargin = false;
            this.cmsFsysMenu.Size = new System.Drawing.Size(206, 32);
            // 
            // replaceFsysBlockToolStripMenuItem
            // 
            this.replaceFsysBlockToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaceFsysBlockToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.replaceFsysBlockToolStripMenuItem.Name = "replaceFsysBlockToolStripMenuItem";
            this.replaceFsysBlockToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
            this.replaceFsysBlockToolStripMenuItem.Text = "Replace Fsys block...";
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
            this.Controls.Add(this.pnlTitle);
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
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpFilename.ResumeLayout(false);
            this.tlpFile.ResumeLayout(false);
            this.tlpEfi.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpFsys.ResumeLayout(false);
            this.cmsMainMenu.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.tlpVersionLabel.ResumeLayout(false);
            this.tlpVersionLabel.PerformLayout();
            this.tlpMainIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).EndInit();
            this.cmsApplication.ResumeLayout(false);
            this.tlpMenu.ResumeLayout(false);
            this.cmsFsysMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFitVersionText;
        private System.Windows.Forms.Label lblChecksumText;
        private System.Windows.Forms.Label lblSizeBytesText;
        private System.Windows.Forms.Label lblFileChecksum;
        private System.Windows.Forms.Label lblFilesizeBytes;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.Label lblBoardIdText;
        private System.Windows.Forms.Button cmdOpenBin;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdMin;
        internal System.Windows.Forms.TableLayoutPanel tlpMainIcon;
        internal System.Windows.Forms.PictureBox pbxTitleLogo;
        internal System.Windows.Forms.Button cmdMenu;
        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblFsysCrcText;
        private System.Windows.Forms.Label lblSonText;
        private System.Windows.Forms.Label lblFsysCrc;
        private System.Windows.Forms.Label lblApfsCapable;
        private System.Windows.Forms.Label lblApfsCapableText;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.Button cmdEveryMacSearch;
        private System.Windows.Forms.Label lblRomVersion;
        private System.Windows.Forms.Label lblRomVersionText;
        private System.Windows.Forms.Label lblEfiVersionText;
        private System.Windows.Forms.Label lblEfiVersion;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.TableLayoutPanel tlpVersionLabel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button cmdEditEfirom;
        private System.Windows.Forms.ContextMenuStrip cmsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblMeVersion;
        private System.Windows.Forms.Label lblFitVersion;
        private System.Windows.Forms.Label lblMeVersionText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplication;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.ContextMenuStrip cmsFsysMenu;
        private System.Windows.Forms.ToolStripMenuItem replaceFsysBlockToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpFsys;
        private System.Windows.Forms.Button cmdFixFsysCrc;
        private System.Windows.Forms.Button cmdExportFsysBlock;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.Label lblHwc;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblCreatedText;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label lblModifiedText;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblSon;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpFilename;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TableLayoutPanel tlpEfi;
        private System.Windows.Forms.TableLayoutPanel tlpFile;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Label lblPrivateMemory;
        private System.Windows.Forms.Button cmdNavigate;
        private System.Windows.Forms.Label lblModel;
    }
}

