
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdRepairFsys = new System.Windows.Forms.Button();
            this.cmdrReplaceFsys = new System.Windows.Forms.Button();
            this.cmdExportFsys = new System.Windows.Forms.Button();
            this.cmdEditEfirom = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdViewLog = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.labOptionsText = new System.Windows.Forms.Label();
            this.cmdOpenBin = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.labFsysCrc = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labMeVersion = new System.Windows.Forms.Label();
            this.labFitcVersion = new System.Windows.Forms.Label();
            this.labMeVersionText = new System.Windows.Forms.Label();
            this.labEfiVerText = new System.Windows.Forms.Label();
            this.tlpEfiRomLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labEfiVersion = new System.Windows.Forms.Label();
            this.labRomVersion = new System.Windows.Forms.Label();
            this.labRomVersionText = new System.Windows.Forms.Label();
            this.labValidText = new System.Windows.Forms.Label();
            this.labBinInfo = new System.Windows.Forms.Label();
            this.labFilenameText = new System.Windows.Forms.Label();
            this.tlpSerial = new System.Windows.Forms.TableLayoutPanel();
            this.cmdSerialCheck = new System.Windows.Forms.Button();
            this.labSerial = new System.Windows.Forms.Label();
            this.labSerialText = new System.Windows.Forms.Label();
            this.tlpBinaryApfsLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labValid = new System.Windows.Forms.Label();
            this.labApfsCapable = new System.Windows.Forms.Label();
            this.labApfsCapableText = new System.Windows.Forms.Label();
            this.labPlatformInfoText = new System.Windows.Forms.Label();
            this.labFsysCrcText = new System.Windows.Forms.Label();
            this.labFilename = new System.Windows.Forms.Label();
            this.labSizeBytesText = new System.Windows.Forms.Label();
            this.tlpSizeCrcLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labChecksum = new System.Windows.Forms.Label();
            this.labSizeBytes = new System.Windows.Forms.Label();
            this.labChecksumText = new System.Windows.Forms.Label();
            this.labConfig = new System.Windows.Forms.Label();
            this.labSon = new System.Windows.Forms.Label();
            this.labSonText = new System.Windows.Forms.Label();
            this.labBoardIdText = new System.Windows.Forms.Label();
            this.labBoardId = new System.Windows.Forms.Label();
            this.pnlTitleMenuSplit = new System.Windows.Forms.Panel();
            this.cmsMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panTitle = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.transparent = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labVersion = new System.Windows.Forms.Label();
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
            this.pnlMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpEfiRomLabels.SuspendLayout();
            this.tlpSerial.SuspendLayout();
            this.tlpBinaryApfsLabels.SuspendLayout();
            this.tlpSizeCrcLabels.SuspendLayout();
            this.cmsMainMenu.SuspendLayout();
            this.panTitle.SuspendLayout();
            this.transparent.SuspendLayout();
            this.tlpMainIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).BeginInit();
            this.cmsApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.cmdRepairFsys);
            this.pnlMain.Controls.Add(this.cmdrReplaceFsys);
            this.pnlMain.Controls.Add(this.cmdExportFsys);
            this.pnlMain.Controls.Add(this.cmdEditEfirom);
            this.pnlMain.Controls.Add(this.cmdReset);
            this.pnlMain.Controls.Add(this.cmdViewLog);
            this.pnlMain.Controls.Add(this.pnlOptions);
            this.pnlMain.Controls.Add(this.cmdOpenBin);
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 51);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMain.Size = new System.Drawing.Size(818, 371);
            this.pnlMain.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Location = new System.Drawing.Point(636, 277);
            this.panel3.Margin = new System.Windows.Forms.Padding(9);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(171, 32);
            this.panel3.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(169, 30);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 30);
            this.label2.TabIndex = 17;
            this.label2.Text = "FIRMWARE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRepairFsys
            // 
            this.cmdRepairFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdRepairFsys.Enabled = false;
            this.cmdRepairFsys.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdRepairFsys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdRepairFsys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRepairFsys.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRepairFsys.ForeColor = System.Drawing.Color.White;
            this.cmdRepairFsys.Location = new System.Drawing.Point(635, 182);
            this.cmdRepairFsys.Name = "cmdRepairFsys";
            this.cmdRepairFsys.Size = new System.Drawing.Size(171, 36);
            this.cmdRepairFsys.TabIndex = 4;
            this.cmdRepairFsys.Text = "REPAIR FSYS";
            this.cmdRepairFsys.UseVisualStyleBackColor = false;
            // 
            // cmdrReplaceFsys
            // 
            this.cmdrReplaceFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdrReplaceFsys.Enabled = false;
            this.cmdrReplaceFsys.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdrReplaceFsys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdrReplaceFsys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdrReplaceFsys.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdrReplaceFsys.ForeColor = System.Drawing.Color.White;
            this.cmdrReplaceFsys.Location = new System.Drawing.Point(635, 140);
            this.cmdrReplaceFsys.Name = "cmdrReplaceFsys";
            this.cmdrReplaceFsys.Size = new System.Drawing.Size(171, 36);
            this.cmdrReplaceFsys.TabIndex = 3;
            this.cmdrReplaceFsys.Text = "REPLACE FSYS BLOCK";
            this.cmdrReplaceFsys.UseVisualStyleBackColor = false;
            // 
            // cmdExportFsys
            // 
            this.cmdExportFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdExportFsys.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdExportFsys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdExportFsys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportFsys.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportFsys.ForeColor = System.Drawing.Color.White;
            this.cmdExportFsys.Location = new System.Drawing.Point(635, 98);
            this.cmdExportFsys.Name = "cmdExportFsys";
            this.cmdExportFsys.Size = new System.Drawing.Size(171, 36);
            this.cmdExportFsys.TabIndex = 2;
            this.cmdExportFsys.Text = "EXPORT FSYS BLOCK";
            this.cmdExportFsys.UseVisualStyleBackColor = false;
            this.cmdExportFsys.Click += new System.EventHandler(this.cmdExportFsys_Click);
            // 
            // cmdEditEfirom
            // 
            this.cmdEditEfirom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdEditEfirom.Enabled = false;
            this.cmdEditEfirom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdEditEfirom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdEditEfirom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditEfirom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditEfirom.ForeColor = System.Drawing.Color.White;
            this.cmdEditEfirom.Location = new System.Drawing.Point(635, 322);
            this.cmdEditEfirom.Name = "cmdEditEfirom";
            this.cmdEditEfirom.Size = new System.Drawing.Size(171, 36);
            this.cmdEditEfirom.TabIndex = 6;
            this.cmdEditEfirom.Text = "EDIT EFIROM";
            this.cmdEditEfirom.UseVisualStyleBackColor = false;
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.White;
            this.cmdReset.Location = new System.Drawing.Point(724, 56);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(82, 36);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdResetUnload_Click);
            // 
            // cmdViewLog
            // 
            this.cmdViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdViewLog.Enabled = false;
            this.cmdViewLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdViewLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdViewLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewLog.ForeColor = System.Drawing.Color.White;
            this.cmdViewLog.Location = new System.Drawing.Point(635, 224);
            this.cmdViewLog.Name = "cmdViewLog";
            this.cmdViewLog.Size = new System.Drawing.Size(171, 36);
            this.cmdViewLog.TabIndex = 5;
            this.cmdViewLog.Text = "VIEW LOG";
            this.cmdViewLog.UseVisualStyleBackColor = false;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.pnlOptions.Controls.Add(this.tlpOptions);
            this.pnlOptions.Location = new System.Drawing.Point(635, 11);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(9);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(1);
            this.pnlOptions.Size = new System.Drawing.Size(171, 32);
            this.pnlOptions.TabIndex = 17;
            // 
            // tlpOptions
            // 
            this.tlpOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlpOptions.ColumnCount = 1;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.labOptionsText, 0, 0);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.Location = new System.Drawing.Point(1, 1);
            this.tlpOptions.Margin = new System.Windows.Forms.Padding(1);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 1;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.Size = new System.Drawing.Size(169, 30);
            this.tlpOptions.TabIndex = 1;
            // 
            // labOptionsText
            // 
            this.labOptionsText.AutoSize = true;
            this.labOptionsText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labOptionsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labOptionsText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOptionsText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.labOptionsText.Location = new System.Drawing.Point(0, 0);
            this.labOptionsText.Margin = new System.Windows.Forms.Padding(0);
            this.labOptionsText.Name = "labOptionsText";
            this.labOptionsText.Size = new System.Drawing.Size(169, 30);
            this.labOptionsText.TabIndex = 17;
            this.labOptionsText.Text = "OPTIONS";
            this.labOptionsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOpenBin
            // 
            this.cmdOpenBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdOpenBin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdOpenBin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdOpenBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenBin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenBin.ForeColor = System.Drawing.Color.White;
            this.cmdOpenBin.Location = new System.Drawing.Point(635, 56);
            this.cmdOpenBin.Name = "cmdOpenBin";
            this.cmdOpenBin.Size = new System.Drawing.Size(82, 36);
            this.cmdOpenBin.TabIndex = 0;
            this.cmdOpenBin.Text = "OPEN";
            this.cmdOpenBin.UseVisualStyleBackColor = false;
            this.cmdOpenBin.Click += new System.EventHandler(this.cmdOpenBin_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.labFsysCrc, 2, 10);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 2, 4);
            this.tlpMain.Controls.Add(this.labEfiVerText, 0, 8);
            this.tlpMain.Controls.Add(this.tlpEfiRomLabels, 2, 8);
            this.tlpMain.Controls.Add(this.labValidText, 0, 6);
            this.tlpMain.Controls.Add(this.labBinInfo, 0, 0);
            this.tlpMain.Controls.Add(this.labFilenameText, 0, 4);
            this.tlpMain.Controls.Add(this.tlpSerial, 2, 15);
            this.tlpMain.Controls.Add(this.labSerialText, 0, 15);
            this.tlpMain.Controls.Add(this.tlpBinaryApfsLabels, 2, 6);
            this.tlpMain.Controls.Add(this.labPlatformInfoText, 0, 13);
            this.tlpMain.Controls.Add(this.labFsysCrcText, 0, 10);
            this.tlpMain.Controls.Add(this.labFilename, 2, 0);
            this.tlpMain.Controls.Add(this.labSizeBytesText, 0, 2);
            this.tlpMain.Controls.Add(this.tlpSizeCrcLabels, 2, 2);
            this.tlpMain.Controls.Add(this.labConfig, 2, 13);
            this.tlpMain.Controls.Add(this.labSon, 2, 19);
            this.tlpMain.Controls.Add(this.labSonText, 0, 19);
            this.tlpMain.Controls.Add(this.labBoardIdText, 0, 17);
            this.tlpMain.Controls.Add(this.labBoardId, 2, 17);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 21;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.Size = new System.Drawing.Size(611, 347);
            this.tlpMain.TabIndex = 4;
            // 
            // labFsysCrc
            // 
            this.labFsysCrc.AutoEllipsis = true;
            this.labFsysCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labFsysCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFsysCrc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFsysCrc.ForeColor = System.Drawing.Color.White;
            this.labFsysCrc.Location = new System.Drawing.Point(151, 165);
            this.labFsysCrc.Margin = new System.Windows.Forms.Padding(0);
            this.labFsysCrc.Name = "labFsysCrc";
            this.labFsysCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labFsysCrc.Size = new System.Drawing.Size(460, 31);
            this.labFsysCrc.TabIndex = 15;
            this.labFsysCrc.Text = "...";
            this.labFsysCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labMeVersion, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labFitcVersion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labMeVersionText, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(151, 72);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 30);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // labMeVersion
            // 
            this.labMeVersion.AutoEllipsis = true;
            this.labMeVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labMeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMeVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMeVersion.ForeColor = System.Drawing.Color.White;
            this.labMeVersion.Location = new System.Drawing.Point(306, 0);
            this.labMeVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labMeVersion.Name = "labMeVersion";
            this.labMeVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labMeVersion.Size = new System.Drawing.Size(154, 30);
            this.labMeVersion.TabIndex = 5;
            this.labMeVersion.Text = "...";
            this.labMeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFitcVersion
            // 
            this.labFitcVersion.AutoEllipsis = true;
            this.labFitcVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labFitcVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFitcVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFitcVersion.ForeColor = System.Drawing.Color.White;
            this.labFitcVersion.Location = new System.Drawing.Point(0, 0);
            this.labFitcVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labFitcVersion.Name = "labFitcVersion";
            this.labFitcVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labFitcVersion.Size = new System.Drawing.Size(154, 30);
            this.labFitcVersion.TabIndex = 6;
            this.labFitcVersion.Text = "...";
            this.labFitcVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labMeVersionText
            // 
            this.labMeVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labMeVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMeVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMeVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labMeVersionText.Location = new System.Drawing.Point(155, 0);
            this.labMeVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.labMeVersionText.Name = "labMeVersionText";
            this.labMeVersionText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labMeVersionText.Size = new System.Drawing.Size(150, 30);
            this.labMeVersionText.TabIndex = 2;
            this.labMeVersionText.Text = "ME Version";
            this.labMeVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labEfiVerText
            // 
            this.labEfiVerText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labEfiVerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labEfiVerText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEfiVerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labEfiVerText.Location = new System.Drawing.Point(0, 134);
            this.labEfiVerText.Margin = new System.Windows.Forms.Padding(0);
            this.labEfiVerText.Name = "labEfiVerText";
            this.labEfiVerText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labEfiVerText.Size = new System.Drawing.Size(150, 30);
            this.labEfiVerText.TabIndex = 19;
            this.labEfiVerText.Text = "EFI Version";
            this.labEfiVerText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpEfiRomLabels
            // 
            this.tlpEfiRomLabels.ColumnCount = 5;
            this.tlpEfiRomLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEfiRomLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfiRomLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpEfiRomLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpEfiRomLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEfiRomLabels.Controls.Add(this.labEfiVersion, 0, 0);
            this.tlpEfiRomLabels.Controls.Add(this.labRomVersion, 4, 0);
            this.tlpEfiRomLabels.Controls.Add(this.labRomVersionText, 2, 0);
            this.tlpEfiRomLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiRomLabels.Location = new System.Drawing.Point(151, 134);
            this.tlpEfiRomLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiRomLabels.Name = "tlpEfiRomLabels";
            this.tlpEfiRomLabels.RowCount = 1;
            this.tlpEfiRomLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiRomLabels.Size = new System.Drawing.Size(460, 30);
            this.tlpEfiRomLabels.TabIndex = 18;
            // 
            // labEfiVersion
            // 
            this.labEfiVersion.AutoEllipsis = true;
            this.labEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labEfiVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEfiVersion.ForeColor = System.Drawing.Color.White;
            this.labEfiVersion.Location = new System.Drawing.Point(0, 0);
            this.labEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labEfiVersion.Name = "labEfiVersion";
            this.labEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labEfiVersion.Size = new System.Drawing.Size(154, 30);
            this.labEfiVersion.TabIndex = 19;
            this.labEfiVersion.Text = "...";
            this.labEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labRomVersion
            // 
            this.labRomVersion.AutoEllipsis = true;
            this.labRomVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labRomVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labRomVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRomVersion.ForeColor = System.Drawing.Color.White;
            this.labRomVersion.Location = new System.Drawing.Point(306, 0);
            this.labRomVersion.Margin = new System.Windows.Forms.Padding(0);
            this.labRomVersion.Name = "labRomVersion";
            this.labRomVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labRomVersion.Size = new System.Drawing.Size(154, 30);
            this.labRomVersion.TabIndex = 18;
            this.labRomVersion.Text = "...";
            this.labRomVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labRomVersionText
            // 
            this.labRomVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labRomVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labRomVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRomVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labRomVersionText.Location = new System.Drawing.Point(155, 0);
            this.labRomVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.labRomVersionText.Name = "labRomVersionText";
            this.labRomVersionText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labRomVersionText.Size = new System.Drawing.Size(150, 30);
            this.labRomVersionText.TabIndex = 18;
            this.labRomVersionText.Text = "ROM Version";
            this.labRomVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labValidText
            // 
            this.labValidText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labValidText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labValidText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labValidText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labValidText.Location = new System.Drawing.Point(0, 103);
            this.labValidText.Margin = new System.Windows.Forms.Padding(0);
            this.labValidText.Name = "labValidText";
            this.labValidText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labValidText.Size = new System.Drawing.Size(150, 30);
            this.labValidText.TabIndex = 7;
            this.labValidText.Text = "Valid Binary";
            this.labValidText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labBinInfo
            // 
            this.labBinInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labBinInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBinInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBinInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labBinInfo.Location = new System.Drawing.Point(0, 0);
            this.labBinInfo.Margin = new System.Windows.Forms.Padding(0);
            this.labBinInfo.Name = "labBinInfo";
            this.labBinInfo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.labBinInfo.Size = new System.Drawing.Size(150, 40);
            this.labBinInfo.TabIndex = 0;
            this.labBinInfo.Text = "ROM INFO";
            this.labBinInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFilenameText
            // 
            this.labFilenameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labFilenameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFilenameText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFilenameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labFilenameText.Location = new System.Drawing.Point(0, 72);
            this.labFilenameText.Margin = new System.Windows.Forms.Padding(0);
            this.labFilenameText.Name = "labFilenameText";
            this.labFilenameText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labFilenameText.Size = new System.Drawing.Size(150, 30);
            this.labFilenameText.TabIndex = 1;
            this.labFilenameText.Text = "FITC Version";
            this.labFilenameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerial
            // 
            this.tlpSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlpSerial.ColumnCount = 3;
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSerial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSerial.Controls.Add(this.cmdSerialCheck, 2, 0);
            this.tlpSerial.Controls.Add(this.labSerial, 0, 0);
            this.tlpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerial.Location = new System.Drawing.Point(151, 254);
            this.tlpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerial.Name = "tlpSerial";
            this.tlpSerial.RowCount = 1;
            this.tlpSerial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerial.Size = new System.Drawing.Size(460, 30);
            this.tlpSerial.TabIndex = 19;
            // 
            // cmdSerialCheck
            // 
            this.cmdSerialCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.cmdSerialCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSerialCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.cmdSerialCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(72)))));
            this.cmdSerialCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSerialCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSerialCheck.ForeColor = System.Drawing.Color.White;
            this.cmdSerialCheck.Location = new System.Drawing.Point(430, 0);
            this.cmdSerialCheck.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSerialCheck.Name = "cmdSerialCheck";
            this.cmdSerialCheck.Size = new System.Drawing.Size(30, 30);
            this.cmdSerialCheck.TabIndex = 7;
            this.cmdSerialCheck.Text = "S";
            this.cmdSerialCheck.UseVisualStyleBackColor = false;
            this.cmdSerialCheck.Click += new System.EventHandler(this.cmdSerialCheck_Click);
            // 
            // labSerial
            // 
            this.labSerial.AutoEllipsis = true;
            this.labSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSerial.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSerial.ForeColor = System.Drawing.Color.White;
            this.labSerial.Location = new System.Drawing.Point(0, 0);
            this.labSerial.Margin = new System.Windows.Forms.Padding(0);
            this.labSerial.Name = "labSerial";
            this.labSerial.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labSerial.Size = new System.Drawing.Size(429, 30);
            this.labSerial.TabIndex = 10;
            this.labSerial.Text = "...";
            this.labSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSerialText
            // 
            this.labSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSerialText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labSerialText.Location = new System.Drawing.Point(0, 254);
            this.labSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.labSerialText.Name = "labSerialText";
            this.labSerialText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labSerialText.Size = new System.Drawing.Size(150, 30);
            this.labSerialText.TabIndex = 9;
            this.labSerialText.Text = "Serial";
            this.labSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpBinaryApfsLabels
            // 
            this.tlpBinaryApfsLabels.ColumnCount = 5;
            this.tlpBinaryApfsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBinaryApfsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpBinaryApfsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpBinaryApfsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpBinaryApfsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBinaryApfsLabels.Controls.Add(this.labValid, 0, 0);
            this.tlpBinaryApfsLabels.Controls.Add(this.labApfsCapable, 4, 0);
            this.tlpBinaryApfsLabels.Controls.Add(this.labApfsCapableText, 2, 0);
            this.tlpBinaryApfsLabels.Location = new System.Drawing.Point(151, 103);
            this.tlpBinaryApfsLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBinaryApfsLabels.Name = "tlpBinaryApfsLabels";
            this.tlpBinaryApfsLabels.RowCount = 1;
            this.tlpBinaryApfsLabels.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBinaryApfsLabels.Size = new System.Drawing.Size(460, 30);
            this.tlpBinaryApfsLabels.TabIndex = 21;
            // 
            // labValid
            // 
            this.labValid.AutoEllipsis = true;
            this.labValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labValid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labValid.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labValid.ForeColor = System.Drawing.Color.White;
            this.labValid.Location = new System.Drawing.Point(0, 0);
            this.labValid.Margin = new System.Windows.Forms.Padding(0);
            this.labValid.Name = "labValid";
            this.labValid.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labValid.Size = new System.Drawing.Size(154, 30);
            this.labValid.TabIndex = 15;
            this.labValid.Text = "...";
            this.labValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labApfsCapable
            // 
            this.labApfsCapable.AutoEllipsis = true;
            this.labApfsCapable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labApfsCapable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labApfsCapable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labApfsCapable.ForeColor = System.Drawing.Color.White;
            this.labApfsCapable.Location = new System.Drawing.Point(306, 0);
            this.labApfsCapable.Margin = new System.Windows.Forms.Padding(0);
            this.labApfsCapable.Name = "labApfsCapable";
            this.labApfsCapable.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labApfsCapable.Size = new System.Drawing.Size(154, 30);
            this.labApfsCapable.TabIndex = 17;
            this.labApfsCapable.Text = "...";
            this.labApfsCapable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labApfsCapableText
            // 
            this.labApfsCapableText.AutoEllipsis = true;
            this.labApfsCapableText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labApfsCapableText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labApfsCapableText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labApfsCapableText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labApfsCapableText.Location = new System.Drawing.Point(155, 0);
            this.labApfsCapableText.Margin = new System.Windows.Forms.Padding(0);
            this.labApfsCapableText.Name = "labApfsCapableText";
            this.labApfsCapableText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labApfsCapableText.Size = new System.Drawing.Size(150, 30);
            this.labApfsCapableText.TabIndex = 16;
            this.labApfsCapableText.Text = "APFS Capable";
            this.labApfsCapableText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labPlatformInfoText
            // 
            this.labPlatformInfoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labPlatformInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPlatformInfoText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlatformInfoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labPlatformInfoText.Location = new System.Drawing.Point(0, 213);
            this.labPlatformInfoText.Margin = new System.Windows.Forms.Padding(0);
            this.labPlatformInfoText.Name = "labPlatformInfoText";
            this.labPlatformInfoText.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.labPlatformInfoText.Size = new System.Drawing.Size(150, 40);
            this.labPlatformInfoText.TabIndex = 9;
            this.labPlatformInfoText.Text = "PLATFORM INFO";
            this.labPlatformInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFsysCrcText
            // 
            this.labFsysCrcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labFsysCrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFsysCrcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFsysCrcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labFsysCrcText.Location = new System.Drawing.Point(0, 165);
            this.labFsysCrcText.Margin = new System.Windows.Forms.Padding(0);
            this.labFsysCrcText.Name = "labFsysCrcText";
            this.labFsysCrcText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labFsysCrcText.Size = new System.Drawing.Size(150, 31);
            this.labFsysCrcText.TabIndex = 13;
            this.labFsysCrcText.Text = "Fsys CRC32";
            this.labFsysCrcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFilename
            // 
            this.labFilename.AutoEllipsis = true;
            this.labFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFilename.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFilename.ForeColor = System.Drawing.Color.White;
            this.labFilename.Location = new System.Drawing.Point(151, 0);
            this.labFilename.Margin = new System.Windows.Forms.Padding(0);
            this.labFilename.Name = "labFilename";
            this.labFilename.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labFilename.Size = new System.Drawing.Size(460, 40);
            this.labFilename.TabIndex = 4;
            this.labFilename.Text = "...";
            this.labFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSizeBytesText
            // 
            this.labSizeBytesText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labSizeBytesText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSizeBytesText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSizeBytesText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labSizeBytesText.Location = new System.Drawing.Point(0, 41);
            this.labSizeBytesText.Margin = new System.Windows.Forms.Padding(0);
            this.labSizeBytesText.Name = "labSizeBytesText";
            this.labSizeBytesText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labSizeBytesText.Size = new System.Drawing.Size(150, 30);
            this.labSizeBytesText.TabIndex = 3;
            this.labSizeBytesText.Text = "Size (Bytes)";
            this.labSizeBytesText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSizeCrcLabels
            // 
            this.tlpSizeCrcLabels.ColumnCount = 5;
            this.tlpSizeCrcLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSizeCrcLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSizeCrcLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpSizeCrcLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpSizeCrcLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSizeCrcLabels.Controls.Add(this.labChecksum, 4, 0);
            this.tlpSizeCrcLabels.Controls.Add(this.labSizeBytes, 0, 0);
            this.tlpSizeCrcLabels.Controls.Add(this.labChecksumText, 2, 0);
            this.tlpSizeCrcLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSizeCrcLabels.Location = new System.Drawing.Point(151, 41);
            this.tlpSizeCrcLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSizeCrcLabels.Name = "tlpSizeCrcLabels";
            this.tlpSizeCrcLabels.RowCount = 1;
            this.tlpSizeCrcLabels.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSizeCrcLabels.Size = new System.Drawing.Size(460, 30);
            this.tlpSizeCrcLabels.TabIndex = 22;
            // 
            // labChecksum
            // 
            this.labChecksum.AutoEllipsis = true;
            this.labChecksum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labChecksum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labChecksum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labChecksum.ForeColor = System.Drawing.Color.White;
            this.labChecksum.Location = new System.Drawing.Point(306, 0);
            this.labChecksum.Margin = new System.Windows.Forms.Padding(0);
            this.labChecksum.Name = "labChecksum";
            this.labChecksum.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labChecksum.Size = new System.Drawing.Size(154, 30);
            this.labChecksum.TabIndex = 5;
            this.labChecksum.Text = "...";
            this.labChecksum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSizeBytes
            // 
            this.labSizeBytes.AutoEllipsis = true;
            this.labSizeBytes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labSizeBytes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSizeBytes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSizeBytes.ForeColor = System.Drawing.Color.White;
            this.labSizeBytes.Location = new System.Drawing.Point(0, 0);
            this.labSizeBytes.Margin = new System.Windows.Forms.Padding(0);
            this.labSizeBytes.Name = "labSizeBytes";
            this.labSizeBytes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labSizeBytes.Size = new System.Drawing.Size(154, 30);
            this.labSizeBytes.TabIndex = 6;
            this.labSizeBytes.Text = "...";
            this.labSizeBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labChecksumText
            // 
            this.labChecksumText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labChecksumText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labChecksumText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labChecksumText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labChecksumText.Location = new System.Drawing.Point(155, 0);
            this.labChecksumText.Margin = new System.Windows.Forms.Padding(0);
            this.labChecksumText.Name = "labChecksumText";
            this.labChecksumText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labChecksumText.Size = new System.Drawing.Size(150, 30);
            this.labChecksumText.TabIndex = 2;
            this.labChecksumText.Text = "CRC32";
            this.labChecksumText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labConfig
            // 
            this.labConfig.AutoEllipsis = true;
            this.labConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labConfig.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConfig.ForeColor = System.Drawing.Color.White;
            this.labConfig.Location = new System.Drawing.Point(151, 213);
            this.labConfig.Margin = new System.Windows.Forms.Padding(0);
            this.labConfig.Name = "labConfig";
            this.labConfig.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labConfig.Size = new System.Drawing.Size(460, 40);
            this.labConfig.TabIndex = 9;
            this.labConfig.Text = "...";
            this.labConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSon
            // 
            this.labSon.AutoEllipsis = true;
            this.labSon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSon.ForeColor = System.Drawing.Color.White;
            this.labSon.Location = new System.Drawing.Point(151, 316);
            this.labSon.Margin = new System.Windows.Forms.Padding(0);
            this.labSon.Name = "labSon";
            this.labSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labSon.Size = new System.Drawing.Size(460, 30);
            this.labSon.TabIndex = 12;
            this.labSon.Text = "...";
            this.labSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSonText
            // 
            this.labSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSonText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labSonText.Location = new System.Drawing.Point(0, 316);
            this.labSonText.Margin = new System.Windows.Forms.Padding(0);
            this.labSonText.Name = "labSonText";
            this.labSonText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labSonText.Size = new System.Drawing.Size(150, 30);
            this.labSonText.TabIndex = 11;
            this.labSonText.Text = "SON";
            this.labSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labBoardIdText
            // 
            this.labBoardIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.labBoardIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBoardIdText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBoardIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.labBoardIdText.Location = new System.Drawing.Point(0, 285);
            this.labBoardIdText.Margin = new System.Windows.Forms.Padding(0);
            this.labBoardIdText.Name = "labBoardIdText";
            this.labBoardIdText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.labBoardIdText.Size = new System.Drawing.Size(150, 30);
            this.labBoardIdText.TabIndex = 10;
            this.labBoardIdText.Text = "Board-ID";
            this.labBoardIdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labBoardId
            // 
            this.labBoardId.AutoEllipsis = true;
            this.labBoardId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBoardId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBoardId.ForeColor = System.Drawing.Color.White;
            this.labBoardId.Location = new System.Drawing.Point(151, 285);
            this.labBoardId.Margin = new System.Windows.Forms.Padding(0);
            this.labBoardId.Name = "labBoardId";
            this.labBoardId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labBoardId.Size = new System.Drawing.Size(460, 30);
            this.labBoardId.TabIndex = 11;
            this.labBoardId.Text = "...";
            this.labBoardId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTitleMenuSplit
            // 
            this.pnlTitleMenuSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlTitleMenuSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleMenuSplit.Location = new System.Drawing.Point(1, 51);
            this.pnlTitleMenuSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitleMenuSplit.Name = "pnlTitleMenuSplit";
            this.pnlTitleMenuSplit.Size = new System.Drawing.Size(818, 2);
            this.pnlTitleMenuSplit.TabIndex = 91;
            // 
            // cmsMainMenu
            // 
            this.cmsMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsMainMenu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartApplicationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.cmsMainMenu.Name = "cmsMainMenu";
            this.cmsMainMenu.ShowImageMargin = false;
            this.cmsMainMenu.Size = new System.Drawing.Size(276, 94);
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
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panTitle.BackgroundImage")));
            this.panTitle.Controls.Add(this.labTitle);
            this.panTitle.Controls.Add(this.transparent);
            this.panTitle.Controls.Add(this.cmdMenu);
            this.panTitle.Controls.Add(this.tlpMainIcon);
            this.panTitle.Controls.Add(this.cmdMin);
            this.panTitle.Controls.Add(this.cmdClose);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(1, 1);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(818, 50);
            this.panTitle.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.BackColor = System.Drawing.Color.Transparent;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.ForeColor = System.Drawing.Color.White;
            this.labTitle.Location = new System.Drawing.Point(45, 0);
            this.labTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(551, 50);
            this.labTitle.TabIndex = 11;
            this.labTitle.Text = "Mac EFI Toolkit";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transparent
            // 
            this.transparent.BackColor = System.Drawing.Color.Transparent;
            this.transparent.ColumnCount = 2;
            this.transparent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.transparent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.transparent.Controls.Add(this.panel2, 1, 0);
            this.transparent.Controls.Add(this.labVersion, 0, 0);
            this.transparent.Dock = System.Windows.Forms.DockStyle.Right;
            this.transparent.Location = new System.Drawing.Point(596, 0);
            this.transparent.Name = "transparent";
            this.transparent.RowCount = 1;
            this.transparent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.transparent.Size = new System.Drawing.Size(72, 50);
            this.transparent.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel2.Location = new System.Drawing.Point(66, 8);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 34);
            this.panel2.TabIndex = 1;
            // 
            // labVersion
            // 
            this.labVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labVersion.AutoSize = true;
            this.labVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.labVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labVersion.ForeColor = System.Drawing.Color.White;
            this.labVersion.Location = new System.Drawing.Point(16, 14);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(43, 22);
            this.labVersion.TabIndex = 2;
            this.labVersion.Text = "0.0.0";
            this.labVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdMenu
            // 
            this.cmdMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.cmdMenu.FlatAppearance.BorderSize = 0;
            this.cmdMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.cmdMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.cmdMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.ForeColor = System.Drawing.Color.White;
            this.cmdMenu.Location = new System.Drawing.Point(668, 0);
            this.cmdMenu.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMenu.Size = new System.Drawing.Size(50, 50);
            this.cmdMenu.TabIndex = 0;
            this.cmdMenu.TabStop = false;
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
            this.tlpMainIcon.TabIndex = 12;
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
            this.cmdMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.cmdMin.FlatAppearance.BorderSize = 0;
            this.cmdMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.cmdMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.cmdMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMin.ForeColor = System.Drawing.Color.White;
            this.cmdMin.Location = new System.Drawing.Point(718, 0);
            this.cmdMin.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMin.Name = "cmdMin";
            this.cmdMin.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMin.Size = new System.Drawing.Size(50, 50);
            this.cmdMin.TabIndex = 0;
            this.cmdMin.TabStop = false;
            this.cmdMin.Text = "—";
            this.cmdMin.UseVisualStyleBackColor = false;
            this.cmdMin.Click += new System.EventHandler(this.cmdMin_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(768, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 0;
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
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.ClientSize = new System.Drawing.Size(820, 423);
            this.Controls.Add(this.pnlTitleMenuSplit);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 423);
            this.MinimumSize = new System.Drawing.Size(820, 423);
            this.Name = "mainWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mac EFI Toolkit";
            this.pnlMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpOptions.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpEfiRomLabels.ResumeLayout(false);
            this.tlpSerial.ResumeLayout(false);
            this.tlpBinaryApfsLabels.ResumeLayout(false);
            this.tlpSizeCrcLabels.ResumeLayout(false);
            this.cmsMainMenu.ResumeLayout(false);
            this.panTitle.ResumeLayout(false);
            this.transparent.ResumeLayout(false);
            this.transparent.PerformLayout();
            this.tlpMainIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitleLogo)).EndInit();
            this.cmsApplication.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.Panel pnlTitleMenuSplit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label labBinInfo;
        private System.Windows.Forms.Label labFilenameText;
        private System.Windows.Forms.Label labChecksumText;
        private System.Windows.Forms.Label labSizeBytesText;
        private System.Windows.Forms.Label labFilename;
        private System.Windows.Forms.Label labChecksum;
        private System.Windows.Forms.Label labSizeBytes;
        private System.Windows.Forms.Label labValidText;
        private System.Windows.Forms.Label labConfig;
        private System.Windows.Forms.Label labPlatformInfoText;
        private System.Windows.Forms.Label labSerial;
        private System.Windows.Forms.Label labSerialText;
        private System.Windows.Forms.Label labBoardId;
        private System.Windows.Forms.Label labBoardIdText;
        private System.Windows.Forms.Button cmdOpenBin;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdMin;
        internal System.Windows.Forms.TableLayoutPanel tlpMainIcon;
        internal System.Windows.Forms.PictureBox pbxTitleLogo;
        internal System.Windows.Forms.Button cmdMenu;
        internal System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label labFsysCrcText;
        private System.Windows.Forms.Label labSon;
        private System.Windows.Forms.Label labSonText;
        private System.Windows.Forms.Label labFsysCrc;
        private System.Windows.Forms.TableLayoutPanel tlpEfiRomLabels;
        private System.Windows.Forms.Label labApfsCapable;
        private System.Windows.Forms.Label labValid;
        private System.Windows.Forms.Label labApfsCapableText;
        private System.Windows.Forms.TableLayoutPanel tlpSerial;
        private System.Windows.Forms.Button cmdSerialCheck;
        private System.Windows.Forms.Label labRomVersion;
        private System.Windows.Forms.Label labRomVersionText;
        private System.Windows.Forms.TableLayoutPanel tlpBinaryApfsLabels;
        private System.Windows.Forms.Label labEfiVerText;
        private System.Windows.Forms.Label labEfiVersion;
        private System.Windows.Forms.TableLayoutPanel tlpSizeCrcLabels;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.TableLayoutPanel transparent;
        private System.Windows.Forms.Label labVersion;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdEditEfirom;
        private System.Windows.Forms.ContextMenuStrip cmsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button cmdViewLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labMeVersion;
        private System.Windows.Forms.Label labFitcVersion;
        private System.Windows.Forms.Label labMeVersionText;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdRepairFsys;
        private System.Windows.Forms.Button cmdrReplaceFsys;
        private System.Windows.Forms.Button cmdExportFsys;
        internal System.Windows.Forms.Panel pnlOptions;
        internal System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.Label labOptionsText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplication;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

