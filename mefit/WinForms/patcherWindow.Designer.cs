
namespace Mac_EFI_Toolkit.WinForms
{
    partial class patcherWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patcherWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.tlpNss = new System.Windows.Forms.TableLayoutPanel();
            this.lblNssChevRight = new System.Windows.Forms.Label();
            this.cbxClearNssStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearNssBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpSvs = new System.Windows.Forms.TableLayoutPanel();
            this.cbxClearSvsStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearSvsBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblSvsChevRight = new System.Windows.Forms.Label();
            this.tlpVss = new System.Windows.Forms.TableLayoutPanel();
            this.lblVssChevRight = new System.Windows.Forms.Label();
            this.cbxClearVssBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearVssStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.cmdFsysPath = new System.Windows.Forms.Button();
            this.swReplaceFsysStore = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblReplaceFsysStore = new System.Windows.Forms.Label();
            this.tlpSerialA = new System.Windows.Forms.TableLayoutPanel();
            this.swReplaceSerialNumber = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblReplaceSerialNumber = new System.Windows.Forms.Label();
            this.tlpSerialB = new System.Windows.Forms.TableLayoutPanel();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.lblSsnText = new System.Windows.Forms.Label();
            this.tbxHwc = new System.Windows.Forms.TextBox();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpMeRegion = new System.Windows.Forms.TableLayoutPanel();
            this.cmdMePath = new System.Windows.Forms.Button();
            this.swReplaceMeRegion = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblReplaceMeRegion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tlpOutput = new System.Windows.Forms.TableLayoutPanel();
            this.lblOutputText = new System.Windows.Forms.Label();
            this.cmdSaveLog = new System.Windows.Forms.Button();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdBuild = new System.Windows.Forms.Button();
            this.cmdLoadLastBuild = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdBuildsFolder = new System.Windows.Forms.Button();
            this.cmdShowLastBuild = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.tlpNss.SuspendLayout();
            this.tlpSvs.SuspendLayout();
            this.tlpVss.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.tlpSerialA.SuspendLayout();
            this.tlpSerialB.SuspendLayout();
            this.tlpMeRegion.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.tlpOutput.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 43);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(908, 385);
            this.pnlMain.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpOptions, 0, 0);
            this.tlpMain.Controls.Add(this.tlpLog, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(908, 385);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.TabStop = true;
            // 
            // tlpOptions
            // 
            this.tlpOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpOptions.ColumnCount = 1;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.lblNvramText, 0, 7);
            this.tlpOptions.Controls.Add(this.tlpNss, 0, 13);
            this.tlpOptions.Controls.Add(this.tlpSvs, 0, 11);
            this.tlpOptions.Controls.Add(this.tlpVss, 0, 9);
            this.tlpOptions.Controls.Add(this.tlpFsys, 0, 2);
            this.tlpOptions.Controls.Add(this.tlpSerialA, 0, 4);
            this.tlpOptions.Controls.Add(this.tlpSerialB, 0, 5);
            this.tlpOptions.Controls.Add(this.label1, 0, 0);
            this.tlpOptions.Controls.Add(this.tlpMeRegion, 0, 17);
            this.tlpOptions.Controls.Add(this.label2, 0, 15);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.Location = new System.Drawing.Point(0, 0);
            this.tlpOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 19;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.Size = new System.Drawing.Size(400, 385);
            this.tlpOptions.TabIndex = 0;
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNvramText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNvramText.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNvramText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblNvramText.Location = new System.Drawing.Point(0, 139);
            this.lblNvramText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNvramText.Name = "lblNvramText";
            this.lblNvramText.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblNvramText.Size = new System.Drawing.Size(400, 34);
            this.lblNvramText.TabIndex = 99;
            this.lblNvramText.Text = "NVRAM";
            this.lblNvramText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpNss
            // 
            this.tlpNss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpNss.ColumnCount = 3;
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNss.Controls.Add(this.lblNssChevRight, 0, 0);
            this.tlpNss.Controls.Add(this.cbxClearNssStore, 0, 0);
            this.tlpNss.Controls.Add(this.cbxClearNssBackup, 2, 0);
            this.tlpNss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNss.Location = new System.Drawing.Point(0, 244);
            this.tlpNss.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNss.Name = "tlpNss";
            this.tlpNss.RowCount = 1;
            this.tlpNss.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNss.Size = new System.Drawing.Size(400, 34);
            this.tlpNss.TabIndex = 5;
            // 
            // lblNssChevRight
            // 
            this.lblNssChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNssChevRight.AutoSize = true;
            this.lblNssChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssChevRight.ForeColor = System.Drawing.Color.White;
            this.lblNssChevRight.Location = new System.Drawing.Point(160, 5);
            this.lblNssChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblNssChevRight.Name = "lblNssChevRight";
            this.lblNssChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblNssChevRight.TabIndex = 28;
            this.lblNssChevRight.Text = ".";
            this.lblNssChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClearNssStore
            // 
            this.cbxClearNssStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearNssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cbxClearNssStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearNssStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearNssStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearNssStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearNssStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearNssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearNssStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearNssStore.Location = new System.Drawing.Point(11, 6);
            this.cbxClearNssStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearNssStore.Name = "cbxClearNssStore";
            this.cbxClearNssStore.Size = new System.Drawing.Size(140, 21);
            this.cbxClearNssStore.TabIndex = 0;
            this.cbxClearNssStore.Text = "Clear NSS Store";
            this.cbxClearNssStore.CheckedChanged += new System.EventHandler(this.cbxClearNssStore_CheckedChanged);
            // 
            // cbxClearNssBackup
            // 
            this.cbxClearNssBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearNssBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cbxClearNssBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearNssBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearNssBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearNssBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearNssBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearNssBackup.Enabled = false;
            this.cbxClearNssBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearNssBackup.ForeColor = System.Drawing.Color.White;
            this.cbxClearNssBackup.Location = new System.Drawing.Point(190, 6);
            this.cbxClearNssBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearNssBackup.Name = "cbxClearNssBackup";
            this.cbxClearNssBackup.Size = new System.Drawing.Size(190, 21);
            this.cbxClearNssBackup.TabIndex = 1;
            this.cbxClearNssBackup.Text = "Clear NSS Backup Store";
            // 
            // tlpSvs
            // 
            this.tlpSvs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tlpSvs.ColumnCount = 3;
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvs.Controls.Add(this.cbxClearSvsStore, 0, 0);
            this.tlpSvs.Controls.Add(this.cbxClearSvsBackup, 2, 0);
            this.tlpSvs.Controls.Add(this.lblSvsChevRight, 1, 0);
            this.tlpSvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSvs.Location = new System.Drawing.Point(0, 209);
            this.tlpSvs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSvs.Name = "tlpSvs";
            this.tlpSvs.RowCount = 1;
            this.tlpSvs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvs.Size = new System.Drawing.Size(400, 34);
            this.tlpSvs.TabIndex = 4;
            // 
            // cbxClearSvsStore
            // 
            this.cbxClearSvsStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cbxClearSvsStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearSvsStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearSvsStore.Location = new System.Drawing.Point(11, 6);
            this.cbxClearSvsStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearSvsStore.Name = "cbxClearSvsStore";
            this.cbxClearSvsStore.Size = new System.Drawing.Size(140, 21);
            this.cbxClearSvsStore.TabIndex = 0;
            this.cbxClearSvsStore.Text = "Clear SVS Store";
            this.cbxClearSvsStore.CheckedChanged += new System.EventHandler(this.cbxClearSvsStore_CheckedChanged);
            // 
            // cbxClearSvsBackup
            // 
            this.cbxClearSvsBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cbxClearSvsBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearSvsBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsBackup.Enabled = false;
            this.cbxClearSvsBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsBackup.ForeColor = System.Drawing.Color.White;
            this.cbxClearSvsBackup.Location = new System.Drawing.Point(190, 6);
            this.cbxClearSvsBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearSvsBackup.Name = "cbxClearSvsBackup";
            this.cbxClearSvsBackup.Size = new System.Drawing.Size(190, 21);
            this.cbxClearSvsBackup.TabIndex = 1;
            this.cbxClearSvsBackup.Text = "Clear SVS Backup Store";
            // 
            // lblSvsChevRight
            // 
            this.lblSvsChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSvsChevRight.AutoSize = true;
            this.lblSvsChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsChevRight.ForeColor = System.Drawing.Color.White;
            this.lblSvsChevRight.Location = new System.Drawing.Point(160, 5);
            this.lblSvsChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsChevRight.Name = "lblSvsChevRight";
            this.lblSvsChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblSvsChevRight.TabIndex = 27;
            this.lblSvsChevRight.Text = ".";
            this.lblSvsChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpVss
            // 
            this.tlpVss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpVss.ColumnCount = 3;
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVss.Controls.Add(this.lblVssChevRight, 0, 0);
            this.tlpVss.Controls.Add(this.cbxClearVssBackup, 2, 0);
            this.tlpVss.Controls.Add(this.cbxClearVssStore, 0, 0);
            this.tlpVss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVss.Location = new System.Drawing.Point(0, 174);
            this.tlpVss.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVss.Name = "tlpVss";
            this.tlpVss.RowCount = 1;
            this.tlpVss.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVss.Size = new System.Drawing.Size(400, 34);
            this.tlpVss.TabIndex = 3;
            // 
            // lblVssChevRight
            // 
            this.lblVssChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVssChevRight.AutoSize = true;
            this.lblVssChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssChevRight.ForeColor = System.Drawing.Color.White;
            this.lblVssChevRight.Location = new System.Drawing.Point(160, 5);
            this.lblVssChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssChevRight.Name = "lblVssChevRight";
            this.lblVssChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblVssChevRight.TabIndex = 28;
            this.lblVssChevRight.Text = ".";
            this.lblVssChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClearVssBackup
            // 
            this.cbxClearVssBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cbxClearVssBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearVssBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssBackup.Enabled = false;
            this.cbxClearVssBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssBackup.ForeColor = System.Drawing.Color.White;
            this.cbxClearVssBackup.Location = new System.Drawing.Point(190, 6);
            this.cbxClearVssBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearVssBackup.Name = "cbxClearVssBackup";
            this.cbxClearVssBackup.Size = new System.Drawing.Size(190, 21);
            this.cbxClearVssBackup.TabIndex = 1;
            this.cbxClearVssBackup.Text = "Clear VSS Backup Store";
            // 
            // cbxClearVssStore
            // 
            this.cbxClearVssStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cbxClearVssStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxClearVssStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearVssStore.Location = new System.Drawing.Point(11, 6);
            this.cbxClearVssStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearVssStore.Name = "cbxClearVssStore";
            this.cbxClearVssStore.Size = new System.Drawing.Size(140, 21);
            this.cbxClearVssStore.TabIndex = 0;
            this.cbxClearVssStore.Text = "Clear VSS Store";
            this.cbxClearVssStore.CheckedChanged += new System.EventHandler(this.cbxClearVssStore_CheckedChanged);
            // 
            // tlpFsys
            // 
            this.tlpFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpFsys.ColumnCount = 3;
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFsys.Controls.Add(this.cmdFsysPath, 2, 0);
            this.tlpFsys.Controls.Add(this.swReplaceFsysStore, 0, 0);
            this.tlpFsys.Controls.Add(this.lblReplaceFsysStore, 1, 0);
            this.tlpFsys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFsys.Location = new System.Drawing.Point(0, 35);
            this.tlpFsys.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsys.Name = "tlpFsys";
            this.tlpFsys.RowCount = 1;
            this.tlpFsys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.Size = new System.Drawing.Size(400, 34);
            this.tlpFsys.TabIndex = 0;
            // 
            // cmdFsysPath
            // 
            this.cmdFsysPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdFsysPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFsysPath.Enabled = false;
            this.cmdFsysPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdFsysPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdFsysPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdFsysPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFsysPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFsysPath.ForeColor = System.Drawing.Color.White;
            this.cmdFsysPath.Location = new System.Drawing.Point(360, 0);
            this.cmdFsysPath.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFsysPath.Name = "cmdFsysPath";
            this.cmdFsysPath.Size = new System.Drawing.Size(40, 34);
            this.cmdFsysPath.TabIndex = 1;
            this.cmdFsysPath.Text = "...";
            this.cmdFsysPath.UseVisualStyleBackColor = false;
            this.cmdFsysPath.Click += new System.EventHandler(this.cmdFsysPath_Click);
            // 
            // swReplaceFsysStore
            // 
            this.swReplaceFsysStore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swReplaceFsysStore.BackColor = System.Drawing.Color.Black;
            this.swReplaceFsysStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swReplaceFsysStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swReplaceFsysStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swReplaceFsysStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swReplaceFsysStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swReplaceFsysStore.Location = new System.Drawing.Point(8, 8);
            this.swReplaceFsysStore.Name = "swReplaceFsysStore";
            this.swReplaceFsysStore.Size = new System.Drawing.Size(32, 18);
            this.swReplaceFsysStore.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.swReplaceFsysStore.TabIndex = 0;
            this.swReplaceFsysStore.CheckedChanged += new System.EventHandler(this.swReplaceFsysStore_CheckedChanged);
            // 
            // lblReplaceFsysStore
            // 
            this.lblReplaceFsysStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblReplaceFsysStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplaceFsysStore.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceFsysStore.ForeColor = System.Drawing.Color.White;
            this.lblReplaceFsysStore.Location = new System.Drawing.Point(48, 0);
            this.lblReplaceFsysStore.Margin = new System.Windows.Forms.Padding(0);
            this.lblReplaceFsysStore.Name = "lblReplaceFsysStore";
            this.lblReplaceFsysStore.Size = new System.Drawing.Size(312, 34);
            this.lblReplaceFsysStore.TabIndex = 100;
            this.lblReplaceFsysStore.Text = "Replace Fsys Store";
            this.lblReplaceFsysStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialA
            // 
            this.tlpSerialA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpSerialA.ColumnCount = 2;
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.Controls.Add(this.swReplaceSerialNumber, 0, 0);
            this.tlpSerialA.Controls.Add(this.lblReplaceSerialNumber, 1, 0);
            this.tlpSerialA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialA.Location = new System.Drawing.Point(0, 70);
            this.tlpSerialA.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialA.Name = "tlpSerialA";
            this.tlpSerialA.RowCount = 1;
            this.tlpSerialA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.Size = new System.Drawing.Size(400, 34);
            this.tlpSerialA.TabIndex = 1;
            // 
            // swReplaceSerialNumber
            // 
            this.swReplaceSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swReplaceSerialNumber.BackColor = System.Drawing.Color.Black;
            this.swReplaceSerialNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swReplaceSerialNumber.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swReplaceSerialNumber.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swReplaceSerialNumber.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swReplaceSerialNumber.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swReplaceSerialNumber.Location = new System.Drawing.Point(8, 8);
            this.swReplaceSerialNumber.Name = "swReplaceSerialNumber";
            this.swReplaceSerialNumber.Size = new System.Drawing.Size(32, 18);
            this.swReplaceSerialNumber.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.swReplaceSerialNumber.TabIndex = 0;
            this.swReplaceSerialNumber.CheckedChanged += new System.EventHandler(this.swReplaceSerialNumber_CheckedChanged);
            // 
            // lblReplaceSerialNumber
            // 
            this.lblReplaceSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblReplaceSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplaceSerialNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceSerialNumber.ForeColor = System.Drawing.Color.White;
            this.lblReplaceSerialNumber.Location = new System.Drawing.Point(48, 0);
            this.lblReplaceSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblReplaceSerialNumber.Name = "lblReplaceSerialNumber";
            this.lblReplaceSerialNumber.Size = new System.Drawing.Size(352, 34);
            this.lblReplaceSerialNumber.TabIndex = 100;
            this.lblReplaceSerialNumber.Text = "Replace Serial Number";
            this.lblReplaceSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialB
            // 
            this.tlpSerialB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tlpSerialB.ColumnCount = 4;
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Controls.Add(this.lblHwcText, 2, 0);
            this.tlpSerialB.Controls.Add(this.lblSsnText, 0, 0);
            this.tlpSerialB.Controls.Add(this.tbxHwc, 3, 0);
            this.tlpSerialB.Controls.Add(this.tbxSerialNumber, 1, 0);
            this.tlpSerialB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialB.Enabled = false;
            this.tlpSerialB.Location = new System.Drawing.Point(0, 104);
            this.tlpSerialB.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialB.Name = "tlpSerialB";
            this.tlpSerialB.RowCount = 1;
            this.tlpSerialB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Size = new System.Drawing.Size(400, 34);
            this.tlpSerialB.TabIndex = 2;
            // 
            // lblHwcText
            // 
            this.lblHwcText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHwcText.AutoSize = true;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(255, 7);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Size = new System.Drawing.Size(47, 20);
            this.lblHwcText.TabIndex = 99;
            this.lblHwcText.Text = "HWC:";
            // 
            // lblSsnText
            // 
            this.lblSsnText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSsnText.AutoSize = true;
            this.lblSsnText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSsnText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSsnText.Location = new System.Drawing.Point(9, 7);
            this.lblSsnText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblSsnText.Name = "lblSsnText";
            this.lblSsnText.Size = new System.Drawing.Size(41, 20);
            this.lblSsnText.TabIndex = 99;
            this.lblSsnText.Text = "SSN:";
            // 
            // tbxHwc
            // 
            this.tbxHwc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbxHwc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxHwc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHwc.ForeColor = System.Drawing.Color.White;
            this.tbxHwc.Location = new System.Drawing.Point(305, 2);
            this.tbxHwc.Margin = new System.Windows.Forms.Padding(0);
            this.tbxHwc.MaxLength = 4;
            this.tbxHwc.Name = "tbxHwc";
            this.tbxHwc.ReadOnly = true;
            this.tbxHwc.Size = new System.Drawing.Size(87, 30);
            this.tbxHwc.TabIndex = 1;
            this.tbxHwc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbxSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSerialNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSerialNumber.ForeColor = System.Drawing.Color.White;
            this.tbxSerialNumber.Location = new System.Drawing.Point(55, 2);
            this.tbxSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSerialNumber.MaxLength = 12;
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(188, 30);
            this.tbxSerialNumber.TabIndex = 0;
            this.tbxSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSerialNumber.TextChanged += new System.EventHandler(this.tbxSerialNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(400, 34);
            this.label1.TabIndex = 100;
            this.label1.Text = "FSYS STORE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMeRegion
            // 
            this.tlpMeRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpMeRegion.ColumnCount = 3;
            this.tlpMeRegion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMeRegion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMeRegion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMeRegion.Controls.Add(this.cmdMePath, 2, 0);
            this.tlpMeRegion.Controls.Add(this.swReplaceMeRegion, 0, 0);
            this.tlpMeRegion.Controls.Add(this.lblReplaceMeRegion, 1, 0);
            this.tlpMeRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMeRegion.Location = new System.Drawing.Point(0, 314);
            this.tlpMeRegion.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMeRegion.Name = "tlpMeRegion";
            this.tlpMeRegion.RowCount = 1;
            this.tlpMeRegion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMeRegion.Size = new System.Drawing.Size(400, 34);
            this.tlpMeRegion.TabIndex = 6;
            // 
            // cmdMePath
            // 
            this.cmdMePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMePath.Enabled = false;
            this.cmdMePath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdMePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdMePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMePath.ForeColor = System.Drawing.Color.White;
            this.cmdMePath.Location = new System.Drawing.Point(360, 0);
            this.cmdMePath.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMePath.Name = "cmdMePath";
            this.cmdMePath.Size = new System.Drawing.Size(40, 34);
            this.cmdMePath.TabIndex = 1;
            this.cmdMePath.Text = "...";
            this.cmdMePath.UseVisualStyleBackColor = false;
            this.cmdMePath.Click += new System.EventHandler(this.cmdMePath_Click);
            // 
            // swReplaceMeRegion
            // 
            this.swReplaceMeRegion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swReplaceMeRegion.BackColor = System.Drawing.Color.Black;
            this.swReplaceMeRegion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swReplaceMeRegion.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swReplaceMeRegion.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swReplaceMeRegion.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swReplaceMeRegion.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swReplaceMeRegion.Location = new System.Drawing.Point(8, 8);
            this.swReplaceMeRegion.Name = "swReplaceMeRegion";
            this.swReplaceMeRegion.Size = new System.Drawing.Size(32, 18);
            this.swReplaceMeRegion.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.swReplaceMeRegion.TabIndex = 0;
            this.swReplaceMeRegion.CheckedChanged += new System.EventHandler(this.swReplaceMeRegion_CheckedChanged);
            // 
            // lblReplaceMeRegion
            // 
            this.lblReplaceMeRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblReplaceMeRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReplaceMeRegion.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblReplaceMeRegion.ForeColor = System.Drawing.Color.White;
            this.lblReplaceMeRegion.Location = new System.Drawing.Point(48, 0);
            this.lblReplaceMeRegion.Margin = new System.Windows.Forms.Padding(0);
            this.lblReplaceMeRegion.Name = "lblReplaceMeRegion";
            this.lblReplaceMeRegion.Size = new System.Drawing.Size(312, 34);
            this.lblReplaceMeRegion.TabIndex = 100;
            this.lblReplaceMeRegion.Text = "Replace ME Region";
            this.lblReplaceMeRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(0, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(400, 34);
            this.label2.TabIndex = 101;
            this.label2.Text = "INTEL ME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.Controls.Add(this.pnlLog, 0, 2);
            this.tlpLog.Controls.Add(this.tlpOutput, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(401, 0);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 4;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.Size = new System.Drawing.Size(507, 385);
            this.tlpLog.TabIndex = 1;
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlLog.Controls.Add(this.rtbLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(0, 35);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(4);
            this.pnlLog.Size = new System.Drawing.Size(507, 349);
            this.pnlLog.TabIndex = 3;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(4, 4);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(499, 341);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            // 
            // tlpOutput
            // 
            this.tlpOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpOutput.ColumnCount = 3;
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOutput.Controls.Add(this.lblOutputText, 0, 0);
            this.tlpOutput.Controls.Add(this.cmdSaveLog, 2, 0);
            this.tlpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOutput.Location = new System.Drawing.Point(0, 0);
            this.tlpOutput.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOutput.Name = "tlpOutput";
            this.tlpOutput.RowCount = 1;
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.Size = new System.Drawing.Size(507, 34);
            this.tlpOutput.TabIndex = 6;
            // 
            // lblOutputText
            // 
            this.lblOutputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputText.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOutputText.Location = new System.Drawing.Point(0, 0);
            this.lblOutputText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOutputText.Name = "lblOutputText";
            this.lblOutputText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOutputText.Size = new System.Drawing.Size(416, 34);
            this.lblOutputText.TabIndex = 99;
            this.lblOutputText.Text = "OUTPUT";
            this.lblOutputText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSaveLog
            // 
            this.cmdSaveLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSaveLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdSaveLog.FlatAppearance.BorderSize = 0;
            this.cmdSaveLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdSaveLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveLog.ForeColor = System.Drawing.Color.White;
            this.cmdSaveLog.Location = new System.Drawing.Point(417, 0);
            this.cmdSaveLog.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSaveLog.Name = "cmdSaveLog";
            this.cmdSaveLog.Size = new System.Drawing.Size(90, 34);
            this.cmdSaveLog.TabIndex = 0;
            this.cmdSaveLog.Text = "Save Log";
            this.cmdSaveLog.UseVisualStyleBackColor = false;
            this.cmdSaveLog.Click += new System.EventHandler(this.cmdSaveLog_Click);
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
            this.tlpTitle.Size = new System.Drawing.Size(908, 40);
            this.tlpTitle.TabIndex = 99;
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
            this.lblTitle.Size = new System.Drawing.Size(828, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "Firmware Patcher";
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
            this.cmdClose.Location = new System.Drawing.Point(868, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 99;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(908, 2);
            this.pnlSeperator.TabIndex = 97;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 6;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpButtons.Controls.Add(this.cmdBuild, 5, 0);
            this.tlpButtons.Controls.Add(this.cmdLoadLastBuild, 4, 0);
            this.tlpButtons.Controls.Add(this.cmdReset, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdBuildsFolder, 1, 0);
            this.tlpButtons.Controls.Add(this.cmdShowLastBuild, 3, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 428);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(908, 46);
            this.tlpButtons.TabIndex = 1;
            // 
            // cmdBuild
            // 
            this.cmdBuild.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdBuild.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdBuild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdBuild.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuild.ForeColor = System.Drawing.Color.White;
            this.cmdBuild.Location = new System.Drawing.Point(833, 5);
            this.cmdBuild.Margin = new System.Windows.Forms.Padding(0);
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(70, 36);
            this.cmdBuild.TabIndex = 4;
            this.cmdBuild.Text = "Build";
            this.cmdBuild.UseVisualStyleBackColor = false;
            this.cmdBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // cmdLoadLastBuild
            // 
            this.cmdLoadLastBuild.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdLoadLastBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdLoadLastBuild.Enabled = false;
            this.cmdLoadLastBuild.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdLoadLastBuild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdLoadLastBuild.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdLoadLastBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoadLastBuild.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLoadLastBuild.ForeColor = System.Drawing.Color.White;
            this.cmdLoadLastBuild.Location = new System.Drawing.Point(678, 5);
            this.cmdLoadLastBuild.Margin = new System.Windows.Forms.Padding(0);
            this.cmdLoadLastBuild.Name = "cmdLoadLastBuild";
            this.cmdLoadLastBuild.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdLoadLastBuild.Size = new System.Drawing.Size(150, 36);
            this.cmdLoadLastBuild.TabIndex = 3;
            this.cmdLoadLastBuild.Text = "Load Last Build";
            this.cmdLoadLastBuild.UseVisualStyleBackColor = false;
            this.cmdLoadLastBuild.Click += new System.EventHandler(this.cmdLoadLastBuild_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.White;
            this.cmdReset.Location = new System.Drawing.Point(5, 5);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(0);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdReset.Size = new System.Drawing.Size(70, 36);
            this.cmdReset.TabIndex = 0;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdBuildsFolder
            // 
            this.cmdBuildsFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdBuildsFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdBuildsFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdBuildsFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdBuildsFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdBuildsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBuildsFolder.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuildsFolder.ForeColor = System.Drawing.Color.White;
            this.cmdBuildsFolder.Location = new System.Drawing.Point(80, 5);
            this.cmdBuildsFolder.Margin = new System.Windows.Forms.Padding(0);
            this.cmdBuildsFolder.Name = "cmdBuildsFolder";
            this.cmdBuildsFolder.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdBuildsFolder.Size = new System.Drawing.Size(126, 36);
            this.cmdBuildsFolder.TabIndex = 1;
            this.cmdBuildsFolder.Text = "Builds Folder";
            this.cmdBuildsFolder.UseVisualStyleBackColor = false;
            this.cmdBuildsFolder.Click += new System.EventHandler(this.cmdBuildsFolder_Click);
            // 
            // cmdShowLastBuild
            // 
            this.cmdShowLastBuild.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdShowLastBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdShowLastBuild.Enabled = false;
            this.cmdShowLastBuild.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdShowLastBuild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdShowLastBuild.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdShowLastBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShowLastBuild.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowLastBuild.ForeColor = System.Drawing.Color.White;
            this.cmdShowLastBuild.Location = new System.Drawing.Point(523, 5);
            this.cmdShowLastBuild.Margin = new System.Windows.Forms.Padding(0);
            this.cmdShowLastBuild.Name = "cmdShowLastBuild";
            this.cmdShowLastBuild.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdShowLastBuild.Size = new System.Drawing.Size(150, 36);
            this.cmdShowLastBuild.TabIndex = 2;
            this.cmdShowLastBuild.Text = "Show Last Build";
            this.cmdShowLastBuild.UseVisualStyleBackColor = false;
            this.cmdShowLastBuild.Click += new System.EventHandler(this.cmdShowLastBuild_Click);
            // 
            // patcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(910, 475);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(910, 475);
            this.Name = "patcherWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmware Patcher";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpNss.ResumeLayout(false);
            this.tlpNss.PerformLayout();
            this.tlpSvs.ResumeLayout(false);
            this.tlpSvs.PerformLayout();
            this.tlpVss.ResumeLayout(false);
            this.tlpVss.PerformLayout();
            this.tlpFsys.ResumeLayout(false);
            this.tlpSerialA.ResumeLayout(false);
            this.tlpSerialB.ResumeLayout(false);
            this.tlpSerialB.PerformLayout();
            this.tlpMeRegion.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.tlpOutput.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.TextBox tbxHwc;
        private UI.METCheckbox cbxClearVssStore;
        private UI.METCheckbox cbxClearSvsStore;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private UI.METCheckbox cbxClearVssBackup;
        private UI.METCheckbox cbxClearSvsBackup;
        private System.Windows.Forms.Label lblSsnText;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.TableLayoutPanel tlpSerialA;
        private System.Windows.Forms.TableLayoutPanel tlpSerialB;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblNvramText;
        private System.Windows.Forms.TableLayoutPanel tlpVss;
        private System.Windows.Forms.TableLayoutPanel tlpSvs;
        private System.Windows.Forms.Label lblSvsChevRight;
        private System.Windows.Forms.Label lblVssChevRight;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lblOutputText;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.TableLayoutPanel tlpOutput;
        private System.Windows.Forms.TableLayoutPanel tlpNss;
        private System.Windows.Forms.Label lblNssChevRight;
        private UI.METCheckbox cbxClearNssBackup;
        private UI.METCheckbox cbxClearNssStore;
        private System.Windows.Forms.Button cmdBuild;
        private System.Windows.Forms.Button cmdSaveLog;
        private System.Windows.Forms.Button cmdBuildsFolder;
        private System.Windows.Forms.Button cmdLoadLastBuild;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.TableLayoutPanel tlpMeRegion;
        private System.Windows.Forms.Button cmdMePath;
        private System.Windows.Forms.PictureBox pbxLogo;
        private UI.METSwitch swReplaceMeRegion;
        private System.Windows.Forms.Label lblReplaceMeRegion;
        private System.Windows.Forms.Label lblReplaceSerialNumber;
        private UI.METSwitch swReplaceSerialNumber;
        private System.Windows.Forms.TableLayoutPanel tlpFsys;
        private System.Windows.Forms.Button cmdFsysPath;
        private UI.METSwitch swReplaceFsysStore;
        private System.Windows.Forms.Label lblReplaceFsysStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdShowLastBuild;
    }
}