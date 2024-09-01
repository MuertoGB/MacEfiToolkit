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
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdCopyMenu = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilesizeText = new System.Windows.Forms.Label();
            this.lblFilenameText = new System.Windows.Forms.Label();
            this.lblFilesize = new System.Windows.Forms.Label();
            this.lblCrcText = new System.Windows.Forms.Label();
            this.lblCreatedText = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.lblScfgText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.lblConfigText = new System.Windows.Forms.Label();
            this.lblSonText = new System.Windows.Forms.Label();
            this.tlpScfgStore = new System.Windows.Forms.TableLayoutPanel();
            this.lblScfg = new System.Windows.Forms.Label();
            this.cmdExportScfg = new System.Windows.Forms.Button();
            this.cmdTransfer = new System.Windows.Forms.Button();
            this.lblIbootText = new System.Windows.Forms.Label();
            this.lbliBoot = new System.Windows.Forms.Label();
            this.lblFilename = new METLabel();
            this.lblCrc = new METLabel();
            this.lblModified = new METLabel();
            this.lblSerial = new METLabel();
            this.lblConfigCode = new METLabel();
            this.lblSon = new METLabel();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpScfgStore.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 3;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(448, 40);
            this.tlpTitle.TabIndex = 100;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.logo24px;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 8);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(24, 24);
            this.pbxLogo.TabIndex = 100;
            this.pbxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 40);
            this.lblTitle.TabIndex = 100;
            this.lblTitle.Text = "T2ROM";
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
            this.cmdClose.Location = new System.Drawing.Point(408, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 100;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpMenu.ColumnCount = 6;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.Controls.Add(this.cmdCopyMenu, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdOpen, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdReset, 2, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 41);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(448, 38);
            this.tlpMenu.TabIndex = 0;
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
            this.cmdCopyMenu.Location = new System.Drawing.Point(139, 1);
            this.cmdCopyMenu.Margin = new System.Windows.Forms.Padding(1);
            this.cmdCopyMenu.Name = "cmdCopyMenu";
            this.cmdCopyMenu.Size = new System.Drawing.Size(66, 36);
            this.cmdCopyMenu.TabIndex = 2;
            this.cmdCopyMenu.Text = "COPY";
            this.cmdCopyMenu.UseVisualStyleBackColor = false;
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
            this.cmdOpen.Size = new System.Drawing.Size(66, 36);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "OPEN";
            this.cmdOpen.UseVisualStyleBackColor = false;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
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
            this.cmdReset.Location = new System.Drawing.Point(70, 1);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(1);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(66, 36);
            this.cmdReset.TabIndex = 1;
            this.cmdReset.Text = "RESET";
            this.cmdReset.UseVisualStyleBackColor = false;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblFilesizeText, 0, 3);
            this.tlpMain.Controls.Add(this.lblFilenameText, 0, 1);
            this.tlpMain.Controls.Add(this.lblFilename, 2, 1);
            this.tlpMain.Controls.Add(this.lblFilesize, 2, 3);
            this.tlpMain.Controls.Add(this.lblCrcText, 0, 5);
            this.tlpMain.Controls.Add(this.lblCrc, 2, 5);
            this.tlpMain.Controls.Add(this.lblCreatedText, 0, 7);
            this.tlpMain.Controls.Add(this.lblCreated, 2, 7);
            this.tlpMain.Controls.Add(this.lblModifiedText, 0, 9);
            this.tlpMain.Controls.Add(this.lblModified, 2, 9);
            this.tlpMain.Controls.Add(this.lblScfgText, 0, 13);
            this.tlpMain.Controls.Add(this.lblSerialText, 0, 15);
            this.tlpMain.Controls.Add(this.lblSerial, 2, 15);
            this.tlpMain.Controls.Add(this.lblConfigText, 0, 17);
            this.tlpMain.Controls.Add(this.lblConfigCode, 2, 17);
            this.tlpMain.Controls.Add(this.lblSonText, 0, 19);
            this.tlpMain.Controls.Add(this.lblSon, 2, 19);
            this.tlpMain.Controls.Add(this.tlpScfgStore, 2, 13);
            this.tlpMain.Controls.Add(this.lblIbootText, 0, 11);
            this.tlpMain.Controls.Add(this.lbliBoot, 2, 11);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 79);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 20;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.Size = new System.Drawing.Size(448, 370);
            this.tlpMain.TabIndex = 1;
            // 
            // lblFilesizeText
            // 
            this.lblFilesizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFilesizeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesizeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesizeText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesizeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilesizeText.Location = new System.Drawing.Point(0, 38);
            this.lblFilesizeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesizeText.Name = "lblFilesizeText";
            this.lblFilesizeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilesizeText.Size = new System.Drawing.Size(130, 36);
            this.lblFilesizeText.TabIndex = 100;
            this.lblFilesizeText.Text = "Size:";
            this.lblFilesizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilenameText
            // 
            this.lblFilenameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFilenameText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilenameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilenameText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilenameText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFilenameText.Location = new System.Drawing.Point(0, 1);
            this.lblFilenameText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilenameText.Name = "lblFilenameText";
            this.lblFilenameText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFilenameText.Size = new System.Drawing.Size(130, 36);
            this.lblFilenameText.TabIndex = 100;
            this.lblFilenameText.Text = "Filename:";
            this.lblFilenameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoEllipsis = true;
            this.lblFilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblFilesize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilesize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesize.ForeColor = System.Drawing.Color.White;
            this.lblFilesize.Location = new System.Drawing.Point(131, 38);
            this.lblFilesize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilesize.Size = new System.Drawing.Size(317, 36);
            this.lblFilesize.TabIndex = 100;
            this.lblFilesize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrcText
            // 
            this.lblCrcText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblCrcText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCrcText.Location = new System.Drawing.Point(0, 75);
            this.lblCrcText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrcText.Name = "lblCrcText";
            this.lblCrcText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCrcText.Size = new System.Drawing.Size(130, 36);
            this.lblCrcText.TabIndex = 100;
            this.lblCrcText.Text = "CRC32:";
            this.lblCrcText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedText
            // 
            this.lblCreatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblCreatedText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCreatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCreatedText.Location = new System.Drawing.Point(0, 112);
            this.lblCreatedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreatedText.Name = "lblCreatedText";
            this.lblCreatedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCreatedText.Size = new System.Drawing.Size(130, 36);
            this.lblCreatedText.TabIndex = 100;
            this.lblCreatedText.Text = "Created:";
            this.lblCreatedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreated
            // 
            this.lblCreated.AutoEllipsis = true;
            this.lblCreated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblCreated.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.ForeColor = System.Drawing.Color.White;
            this.lblCreated.Location = new System.Drawing.Point(131, 112);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCreated.Size = new System.Drawing.Size(317, 36);
            this.lblCreated.TabIndex = 100;
            this.lblCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedText
            // 
            this.lblModifiedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblModifiedText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModifiedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModifiedText.Location = new System.Drawing.Point(0, 149);
            this.lblModifiedText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModifiedText.Name = "lblModifiedText";
            this.lblModifiedText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModifiedText.Size = new System.Drawing.Size(130, 36);
            this.lblModifiedText.TabIndex = 100;
            this.lblModifiedText.Text = "Modified:";
            this.lblModifiedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScfgText
            // 
            this.lblScfgText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblScfgText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblScfgText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfgText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfgText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblScfgText.Location = new System.Drawing.Point(0, 223);
            this.lblScfgText.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfgText.Name = "lblScfgText";
            this.lblScfgText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblScfgText.Size = new System.Drawing.Size(130, 36);
            this.lblScfgText.TabIndex = 100;
            this.lblScfgText.Text = "SCFG Store:";
            this.lblScfgText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSerialText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 260);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(130, 36);
            this.lblSerialText.TabIndex = 100;
            this.lblSerialText.Text = "Serial:";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigText
            // 
            this.lblConfigText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblConfigText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfigText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblConfigText.Location = new System.Drawing.Point(0, 297);
            this.lblConfigText.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigText.Name = "lblConfigText";
            this.lblConfigText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblConfigText.Size = new System.Drawing.Size(130, 36);
            this.lblConfigText.TabIndex = 100;
            this.lblConfigText.Text = "Config Code:";
            this.lblConfigText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSonText
            // 
            this.lblSonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSonText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSonText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSonText.Location = new System.Drawing.Point(0, 334);
            this.lblSonText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSonText.Name = "lblSonText";
            this.lblSonText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSonText.Size = new System.Drawing.Size(130, 36);
            this.lblSonText.TabIndex = 100;
            this.lblSonText.Text = "Order No:";
            this.lblSonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpScfgStore
            // 
            this.tlpScfgStore.ColumnCount = 5;
            this.tlpScfgStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScfgStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpScfgStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpScfgStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpScfgStore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpScfgStore.Controls.Add(this.lblScfg, 0, 0);
            this.tlpScfgStore.Controls.Add(this.cmdExportScfg, 4, 0);
            this.tlpScfgStore.Controls.Add(this.cmdTransfer, 2, 0);
            this.tlpScfgStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScfgStore.Location = new System.Drawing.Point(131, 223);
            this.tlpScfgStore.Margin = new System.Windows.Forms.Padding(0);
            this.tlpScfgStore.Name = "tlpScfgStore";
            this.tlpScfgStore.RowCount = 1;
            this.tlpScfgStore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScfgStore.Size = new System.Drawing.Size(317, 36);
            this.tlpScfgStore.TabIndex = 0;
            // 
            // lblScfg
            // 
            this.lblScfg.AutoEllipsis = true;
            this.lblScfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblScfg.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblScfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScfg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScfg.ForeColor = System.Drawing.Color.White;
            this.lblScfg.Location = new System.Drawing.Point(0, 0);
            this.lblScfg.Margin = new System.Windows.Forms.Padding(0);
            this.lblScfg.Name = "lblScfg";
            this.lblScfg.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblScfg.Size = new System.Drawing.Size(243, 36);
            this.lblScfg.TabIndex = 100;
            this.lblScfg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScfg.UseMnemonic = false;
            // 
            // cmdExportScfg
            // 
            this.cmdExportScfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportScfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportScfg.Enabled = false;
            this.cmdExportScfg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportScfg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportScfg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdExportScfg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportScfg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportScfg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdExportScfg.Location = new System.Drawing.Point(281, 0);
            this.cmdExportScfg.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportScfg.Name = "cmdExportScfg";
            this.cmdExportScfg.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdExportScfg.Size = new System.Drawing.Size(36, 36);
            this.cmdExportScfg.TabIndex = 1;
            this.cmdExportScfg.Text = "E";
            this.cmdExportScfg.UseVisualStyleBackColor = false;
            // 
            // cmdTransfer
            // 
            this.cmdTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTransfer.Enabled = false;
            this.cmdTransfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdTransfer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdTransfer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdTransfer.Location = new System.Drawing.Point(244, 0);
            this.cmdTransfer.Margin = new System.Windows.Forms.Padding(0);
            this.cmdTransfer.Name = "cmdTransfer";
            this.cmdTransfer.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdTransfer.Size = new System.Drawing.Size(36, 36);
            this.cmdTransfer.TabIndex = 0;
            this.cmdTransfer.Text = "T";
            this.cmdTransfer.UseVisualStyleBackColor = false;
            // 
            // lblIbootText
            // 
            this.lblIbootText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblIbootText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblIbootText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIbootText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIbootText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblIbootText.Location = new System.Drawing.Point(0, 186);
            this.lblIbootText.Margin = new System.Windows.Forms.Padding(0);
            this.lblIbootText.Name = "lblIbootText";
            this.lblIbootText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblIbootText.Size = new System.Drawing.Size(130, 36);
            this.lblIbootText.TabIndex = 101;
            this.lblIbootText.Text = "iBoot:";
            this.lblIbootText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbliBoot
            // 
            this.lbliBoot.AutoEllipsis = true;
            this.lbliBoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lbliBoot.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbliBoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbliBoot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbliBoot.ForeColor = System.Drawing.Color.White;
            this.lbliBoot.Location = new System.Drawing.Point(131, 186);
            this.lbliBoot.Margin = new System.Windows.Forms.Padding(0);
            this.lbliBoot.Name = "lbliBoot";
            this.lbliBoot.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbliBoot.Size = new System.Drawing.Size(317, 36);
            this.lbliBoot.TabIndex = 102;
            this.lbliBoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoEllipsis = true;
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFilename.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Location = new System.Drawing.Point(131, 1);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilename.Size = new System.Drawing.Size(317, 36);
            this.lblFilename.TabIndex = 100;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFilename.UseMnemonic = false;
            // 
            // lblCrc
            // 
            this.lblCrc.AutoEllipsis = true;
            this.lblCrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCrc.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrc.ForeColor = System.Drawing.Color.White;
            this.lblCrc.Location = new System.Drawing.Point(131, 75);
            this.lblCrc.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrc.Name = "lblCrc";
            this.lblCrc.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCrc.Size = new System.Drawing.Size(317, 36);
            this.lblCrc.TabIndex = 100;
            this.lblCrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCrc.UseMnemonic = false;
            // 
            // lblModified
            // 
            this.lblModified.AutoEllipsis = true;
            this.lblModified.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblModified.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModified.ForeColor = System.Drawing.Color.White;
            this.lblModified.Location = new System.Drawing.Point(131, 149);
            this.lblModified.Margin = new System.Windows.Forms.Padding(0);
            this.lblModified.Name = "lblModified";
            this.lblModified.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModified.Size = new System.Drawing.Size(317, 36);
            this.lblModified.TabIndex = 100;
            this.lblModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModified.UseMnemonic = false;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoEllipsis = true;
            this.lblSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblSerial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.White;
            this.lblSerial.Location = new System.Drawing.Point(131, 260);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSerial.Size = new System.Drawing.Size(317, 36);
            this.lblSerial.TabIndex = 100;
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerial.UseMnemonic = false;
            // 
            // lblConfigCode
            // 
            this.lblConfigCode.AutoEllipsis = true;
            this.lblConfigCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblConfigCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfigCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfigCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigCode.ForeColor = System.Drawing.Color.White;
            this.lblConfigCode.Location = new System.Drawing.Point(131, 297);
            this.lblConfigCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfigCode.Name = "lblConfigCode";
            this.lblConfigCode.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblConfigCode.Size = new System.Drawing.Size(317, 36);
            this.lblConfigCode.TabIndex = 100;
            this.lblConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSon
            // 
            this.lblSon.AutoEllipsis = true;
            this.lblSon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblSon.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.White;
            this.lblSon.Location = new System.Drawing.Point(131, 334);
            this.lblSon.Margin = new System.Windows.Forms.Padding(0);
            this.lblSon.Name = "lblSon";
            this.lblSon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblSon.Size = new System.Drawing.Size(317, 36);
            this.lblSon.TabIndex = 100;
            this.lblSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSon.UseMnemonic = false;
            // 
            // t2Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "t2Window";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "T2ROM";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpScfgStore.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tlpMain;
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
        private System.Windows.Forms.TableLayoutPanel tlpScfgStore;
        private System.Windows.Forms.Button cmdExportScfg;
        private METLabel lblConfigCode;
        private System.Windows.Forms.Button cmdTransfer;
        private System.Windows.Forms.Label lblFilesize;
        private System.Windows.Forms.Label lblScfg;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblIbootText;
        private System.Windows.Forms.Label lbliBoot;
    }
}