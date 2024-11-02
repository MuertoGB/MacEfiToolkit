namespace Mac_EFI_Toolkit.WinForms
{
    partial class t2Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(t2Window));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdCopyMenu = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdPatch = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
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
            this.tlpStatusBarImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblStatusBarTip = new System.Windows.Forms.Label();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.pnlSeperatorBottom = new System.Windows.Forms.Panel();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpFirmware.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.tlpStatusBarImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
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
            this.tlpTitle.Size = new System.Drawing.Size(483, 50);
            this.tlpTitle.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.logo24px;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Image = global::Mac_EFI_Toolkit.Properties.Resources.logo32px;
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
            this.lblTitle.Size = new System.Drawing.Size(333, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "T2 SOCROM";
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
            this.cmdClose.Location = new System.Drawing.Point(433, 0);
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
            this.cmdMinimize.Location = new System.Drawing.Point(383, 0);
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
            this.tlpMenu.ColumnCount = 9;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMenu.Controls.Add(this.cmdCopyMenu, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdReset, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdPatch, 8, 0);
            this.tlpMenu.Controls.Add(this.cmdExport, 6, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 52);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(483, 32);
            this.tlpMenu.TabIndex = 0;
            // 
            // cmdCopyMenu
            // 
            this.cmdCopyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdCopyMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCopyMenu.Enabled = false;
            this.cmdCopyMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdCopyMenu.FlatAppearance.BorderSize = 0;
            this.cmdCopyMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdCopyMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdCopyMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCopyMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCopyMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdCopyMenu.Location = new System.Drawing.Point(192, 0);
            this.cmdCopyMenu.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCopyMenu.Name = "cmdCopyMenu";
            this.cmdCopyMenu.Size = new System.Drawing.Size(95, 32);
            this.cmdCopyMenu.TabIndex = 2;
            this.cmdCopyMenu.Text = "COPY";
            this.cmdCopyMenu.UseVisualStyleBackColor = false;
            // 
            // cmdOpen
            // 
            this.cmdOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOpen.FlatAppearance.BorderSize = 0;
            this.cmdOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdOpen.Location = new System.Drawing.Point(0, 0);
            this.cmdOpen.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(95, 32);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "OPEN";
            this.cmdOpen.UseVisualStyleBackColor = false;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdReset.Enabled = false;
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReset.FlatAppearance.BorderSize = 0;
            this.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdReset.Location = new System.Drawing.Point(96, 0);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(95, 32);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdPatch
            // 
            this.cmdPatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdPatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdPatch.Enabled = false;
            this.cmdPatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdPatch.FlatAppearance.BorderSize = 0;
            this.cmdPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPatch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdPatch.Location = new System.Drawing.Point(384, 0);
            this.cmdPatch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdPatch.Name = "cmdPatch";
            this.cmdPatch.Size = new System.Drawing.Size(99, 32);
            this.cmdPatch.TabIndex = 3;
            this.cmdPatch.Text = "PATCH";
            this.cmdPatch.UseVisualStyleBackColor = false;
            // 
            // cmdExport
            // 
            this.cmdExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExport.Enabled = false;
            this.cmdExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExport.FlatAppearance.BorderSize = 0;
            this.cmdExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdExport.Location = new System.Drawing.Point(288, 0);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(95, 32);
            this.cmdExport.TabIndex = 4;
            this.cmdExport.Text = "EXPORT";
            this.cmdExport.UseVisualStyleBackColor = false;
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
            this.tlpFirmware.Size = new System.Drawing.Size(483, 360);
            this.tlpFirmware.TabIndex = 0;
            // 
            // lblFilesizeText
            // 
            this.lblFilesizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFilesizeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesizeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilesizeText.Location = new System.Drawing.Point(0, 36);
            this.lblFilesizeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeText.Name = "lblFilesizeText";
            this.lblFilesizeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilesizeText.Size = new System.Drawing.Size(130, 35);
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
            this.lblFilenameText.Size = new System.Drawing.Size(130, 35);
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
            this.lblFilename.Size = new System.Drawing.Size(352, 35);
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
            this.lblFilesize.Location = new System.Drawing.Point(131, 36);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(352, 35);
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
            this.lblCrcText.Location = new System.Drawing.Point(0, 72);
            this.lblCrcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrcText.Name = "lblCrcText";
            this.lblCrcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCrcText.Size = new System.Drawing.Size(130, 35);
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
            this.lblCrc.Location = new System.Drawing.Point(131, 72);
            this.lblCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrc.Name = "lblCrc";
            this.lblCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCrc.Size = new System.Drawing.Size(352, 35);
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
            this.lblCreatedText.Location = new System.Drawing.Point(0, 108);
            this.lblCreatedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreatedText.Name = "lblCreatedText";
            this.lblCreatedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCreatedText.Size = new System.Drawing.Size(130, 35);
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
            this.lblCreated.Location = new System.Drawing.Point(131, 108);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCreated.Size = new System.Drawing.Size(352, 35);
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
            this.lblModifiedText.Location = new System.Drawing.Point(0, 144);
            this.lblModifiedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModifiedText.Name = "lblModifiedText";
            this.lblModifiedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModifiedText.Size = new System.Drawing.Size(130, 35);
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
            this.lblModified.Location = new System.Drawing.Point(131, 144);
            this.lblModified.Margin = new System.Windows.Forms.Padding(0);
            this.lblModified.Name = "lblModified";
            this.lblModified.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModified.Size = new System.Drawing.Size(352, 35);
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
            this.lblScfgText.Location = new System.Drawing.Point(0, 216);
            this.lblScfgText.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfgText.Name = "lblScfgText";
            this.lblScfgText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblScfgText.Size = new System.Drawing.Size(130, 35);
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
            this.lblSerialText.Location = new System.Drawing.Point(0, 252);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 35);
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
            this.lblSerial.Location = new System.Drawing.Point(131, 252);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerial.Size = new System.Drawing.Size(352, 35);
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
            this.lblConfigText.Location = new System.Drawing.Point(0, 288);
            this.lblConfigText.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigText.Name = "lblConfigText";
            this.lblConfigText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblConfigText.Size = new System.Drawing.Size(130, 35);
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
            this.lblConfigCode.Location = new System.Drawing.Point(131, 288);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(352, 35);
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
            this.lblSonText.Location = new System.Drawing.Point(0, 324);
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
            this.lblSon.Location = new System.Drawing.Point(131, 324);
            this.lblSon.Margin = new System.Windows.Forms.Padding(0);
            this.lblSon.Name = "lblSon";
            this.lblSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSon.Size = new System.Drawing.Size(352, 36);
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
            this.lblIbootText.Location = new System.Drawing.Point(0, 180);
            this.lblIbootText.Margin = new System.Windows.Forms.Padding(0);
            this.lblIbootText.Name = "lblIbootText";
            this.lblIbootText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblIbootText.Size = new System.Drawing.Size(130, 35);
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
            this.lbliBoot.Location = new System.Drawing.Point(131, 180);
            this.lbliBoot.Margin = new System.Windows.Forms.Padding(0);
            this.lbliBoot.Name = "lbliBoot";
            this.lbliBoot.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbliBoot.Size = new System.Drawing.Size(352, 35);
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
            this.lblScfg.Location = new System.Drawing.Point(131, 216);
            this.lblScfg.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfg.Name = "lblScfg";
            this.lblScfg.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblScfg.Size = new System.Drawing.Size(352, 35);
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(483, 397);
            this.tlpMain.TabIndex = 101;
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
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 361);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(483, 36);
            this.tlpStatusBar.TabIndex = 100;
            // 
            // tlpStatusBarImage
            // 
            this.tlpStatusBarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpStatusBarImage.ColumnCount = 1;
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBarImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBarImage.Controls.Add(this.pbxLoad, 0, 0);
            this.tlpStatusBarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatusBarImage.Location = new System.Drawing.Point(447, 0);
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
            this.lblStatusBarTip.Size = new System.Drawing.Size(447, 36);
            this.lblStatusBarTip.TabIndex = 99;
            this.lblStatusBarTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 51);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(483, 1);
            this.pnlSeperatorTop.TabIndex = 102;
            // 
            // pnlSeperatorBottom
            // 
            this.pnlSeperatorBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorBottom.Location = new System.Drawing.Point(1, 84);
            this.pnlSeperatorBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorBottom.Name = "pnlSeperatorBottom";
            this.pnlSeperatorBottom.Size = new System.Drawing.Size(483, 1);
            this.pnlSeperatorBottom.TabIndex = 103;
            // 
            // t2Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(485, 483);
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
            this.MinimumSize = new System.Drawing.Size(485, 483);
            this.Name = "t2Window";
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
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Button cmdCopyMenu;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Button cmdReset;
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
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBarImage;
        private System.Windows.Forms.PictureBox pbxLoad;
        private System.Windows.Forms.Label lblStatusBarTip;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.Panel pnlSeperatorBottom;
        private System.Windows.Forms.Button cmdPatch;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Label lblScfg;
        internal System.Windows.Forms.Button cmdMinimize;
    }
}