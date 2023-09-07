
namespace Mac_EFI_Toolkit.WinForms
{
    partial class settingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsWindow));
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdDefaults = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.lblSettingsSaved = new System.Windows.Forms.Label();
            this.cmdOkay = new System.Windows.Forms.Button();
            this.pnlTitleMenuSplit = new System.Windows.Forms.Panel();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.tlpDisableConfirmationDialogs = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableConfirmationDialogs = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableConfirmationDialogs = new System.Windows.Forms.Label();
            this.tlpCustomInitialFolderPath = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEditCustomPath = new System.Windows.Forms.Button();
            this.lblCustomInitialFolderPath = new System.Windows.Forms.Label();
            this.tlpDisableVersionCheck = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableVersionCheck = new System.Windows.Forms.Label();
            this.swDisableVersionCheck = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblStartup = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.tlpDisableFlashingUiElements = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableFlashingUiElements = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableFlashingUiElements = new System.Windows.Forms.Label();
            this.tlpDisableLzmaDecompression = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableLzmaDecompression = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableLzmaDecompression = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisableStatusBarTips = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableStatusBarTips = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableStatusBarTips = new System.Windows.Forms.Label();
            this.tlpDisableMessageWindowSounds = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableMessageWindowSounds = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableMessageWindowSounds = new System.Windows.Forms.Label();
            this.lblPath = new METLabel();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpButtons.SuspendLayout();
            this.tlpDisableConfirmationDialogs.SuspendLayout();
            this.tlpCustomInitialFolderPath.SuspendLayout();
            this.tlpDisableVersionCheck.SuspendLayout();
            this.tlpDisableFlashingUiElements.SuspendLayout();
            this.tlpDisableLzmaDecompression.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpDisableStatusBarTips.SuspendLayout();
            this.tlpDisableMessageWindowSounds.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpButtons.Controls.Add(this.cmdDefaults, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdApply, 3, 0);
            this.tlpButtons.Controls.Add(this.lblSettingsSaved, 1, 0);
            this.tlpButtons.Controls.Add(this.cmdOkay, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 448);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(408, 46);
            this.tlpButtons.TabIndex = 1;
            // 
            // cmdDefaults
            // 
            this.cmdDefaults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdDefaults.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdDefaults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDefaults.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefaults.ForeColor = System.Drawing.Color.White;
            this.cmdDefaults.Location = new System.Drawing.Point(5, 5);
            this.cmdDefaults.Margin = new System.Windows.Forms.Padding(1);
            this.cmdDefaults.Name = "cmdDefaults";
            this.cmdDefaults.Size = new System.Drawing.Size(88, 36);
            this.cmdDefaults.TabIndex = 0;
            this.cmdDefaults.Text = "Reset";
            this.cmdDefaults.UseVisualStyleBackColor = false;
            this.cmdDefaults.Click += new System.EventHandler(this.cmdDefaults_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ForeColor = System.Drawing.Color.White;
            this.cmdApply.Location = new System.Drawing.Point(315, 5);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(1);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(88, 36);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // lblSettingsSaved
            // 
            this.lblSettingsSaved.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSettingsSaved.AutoSize = true;
            this.lblSettingsSaved.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsSaved.ForeColor = System.Drawing.Color.White;
            this.lblSettingsSaved.Location = new System.Drawing.Point(129, 11);
            this.lblSettingsSaved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSettingsSaved.Name = "lblSettingsSaved";
            this.lblSettingsSaved.Size = new System.Drawing.Size(61, 23);
            this.lblSettingsSaved.TabIndex = 12;
            this.lblSettingsSaved.Text = "Saved!";
            // 
            // cmdOkay
            // 
            this.cmdOkay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOkay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdOkay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdOkay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdOkay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOkay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOkay.ForeColor = System.Drawing.Color.White;
            this.cmdOkay.Location = new System.Drawing.Point(224, 5);
            this.cmdOkay.Margin = new System.Windows.Forms.Padding(1);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(85, 36);
            this.cmdOkay.TabIndex = 1;
            this.cmdOkay.Text = "Okay";
            this.cmdOkay.UseVisualStyleBackColor = false;
            this.cmdOkay.Click += new System.EventHandler(this.cmdOkay_Click);
            // 
            // pnlTitleMenuSplit
            // 
            this.pnlTitleMenuSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlTitleMenuSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleMenuSplit.Location = new System.Drawing.Point(1, 41);
            this.pnlTitleMenuSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitleMenuSplit.Name = "pnlTitleMenuSplit";
            this.pnlTitleMenuSplit.Size = new System.Drawing.Size(408, 2);
            this.pnlTitleMenuSplit.TabIndex = 92;
            // 
            // lblFirmware
            // 
            this.lblFirmware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirmware.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmware.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFirmware.Location = new System.Drawing.Point(0, 322);
            this.lblFirmware.Margin = new System.Windows.Forms.Padding(0);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblFirmware.Size = new System.Drawing.Size(408, 38);
            this.lblFirmware.TabIndex = 99;
            this.lblFirmware.Text = "Firmware";
            this.lblFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDisableConfirmationDialogs
            // 
            this.tlpDisableConfirmationDialogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableConfirmationDialogs.ColumnCount = 2;
            this.tlpDisableConfirmationDialogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableConfirmationDialogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableConfirmationDialogs.Controls.Add(this.swDisableConfirmationDialogs, 0, 0);
            this.tlpDisableConfirmationDialogs.Controls.Add(this.lblDisableConfirmationDialogs, 0, 0);
            this.tlpDisableConfirmationDialogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableConfirmationDialogs.Location = new System.Drawing.Point(0, 218);
            this.tlpDisableConfirmationDialogs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableConfirmationDialogs.Name = "tlpDisableConfirmationDialogs";
            this.tlpDisableConfirmationDialogs.RowCount = 1;
            this.tlpDisableConfirmationDialogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableConfirmationDialogs.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableConfirmationDialogs.TabIndex = 4;
            // 
            // swDisableConfirmationDialogs
            // 
            this.swDisableConfirmationDialogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableConfirmationDialogs.BackColor = System.Drawing.Color.Black;
            this.swDisableConfirmationDialogs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableConfirmationDialogs.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableConfirmationDialogs.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableConfirmationDialogs.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableConfirmationDialogs.Location = new System.Drawing.Point(365, 8);
            this.swDisableConfirmationDialogs.Name = "swDisableConfirmationDialogs";
            this.swDisableConfirmationDialogs.Size = new System.Drawing.Size(32, 18);
            this.swDisableConfirmationDialogs.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableConfirmationDialogs.TabIndex = 0;
            // 
            // lblDisableConfirmationDialogs
            // 
            this.lblDisableConfirmationDialogs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableConfirmationDialogs.AutoSize = true;
            this.lblDisableConfirmationDialogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableConfirmationDialogs.ForeColor = System.Drawing.Color.White;
            this.lblDisableConfirmationDialogs.Location = new System.Drawing.Point(2, 7);
            this.lblDisableConfirmationDialogs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableConfirmationDialogs.Name = "lblDisableConfirmationDialogs";
            this.lblDisableConfirmationDialogs.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableConfirmationDialogs.Size = new System.Drawing.Size(216, 20);
            this.lblDisableConfirmationDialogs.TabIndex = 99;
            this.lblDisableConfirmationDialogs.Text = "Disable Confirmation Dialogs";
            // 
            // tlpCustomInitialFolderPath
            // 
            this.tlpCustomInitialFolderPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpCustomInitialFolderPath.ColumnCount = 2;
            this.tlpCustomInitialFolderPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCustomInitialFolderPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpCustomInitialFolderPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCustomInitialFolderPath.Controls.Add(this.cmdEditCustomPath, 1, 0);
            this.tlpCustomInitialFolderPath.Controls.Add(this.lblCustomInitialFolderPath, 0, 0);
            this.tlpCustomInitialFolderPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCustomInitialFolderPath.Location = new System.Drawing.Point(0, 253);
            this.tlpCustomInitialFolderPath.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCustomInitialFolderPath.Name = "tlpCustomInitialFolderPath";
            this.tlpCustomInitialFolderPath.RowCount = 1;
            this.tlpCustomInitialFolderPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCustomInitialFolderPath.Size = new System.Drawing.Size(408, 34);
            this.tlpCustomInitialFolderPath.TabIndex = 5;
            // 
            // cmdEditCustomPath
            // 
            this.cmdEditCustomPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdEditCustomPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditCustomPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdEditCustomPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdEditCustomPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdEditCustomPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditCustomPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditCustomPath.ForeColor = System.Drawing.Color.White;
            this.cmdEditCustomPath.Location = new System.Drawing.Point(354, 0);
            this.cmdEditCustomPath.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditCustomPath.Name = "cmdEditCustomPath";
            this.cmdEditCustomPath.Size = new System.Drawing.Size(54, 34);
            this.cmdEditCustomPath.TabIndex = 0;
            this.cmdEditCustomPath.Text = "EDIT";
            this.cmdEditCustomPath.UseVisualStyleBackColor = false;
            this.cmdEditCustomPath.Click += new System.EventHandler(this.cmdEditCustomPath_Click);
            // 
            // lblCustomInitialFolderPath
            // 
            this.lblCustomInitialFolderPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomInitialFolderPath.AutoSize = true;
            this.lblCustomInitialFolderPath.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomInitialFolderPath.ForeColor = System.Drawing.Color.White;
            this.lblCustomInitialFolderPath.Location = new System.Drawing.Point(2, 7);
            this.lblCustomInitialFolderPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomInitialFolderPath.Name = "lblCustomInitialFolderPath";
            this.lblCustomInitialFolderPath.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCustomInitialFolderPath.Size = new System.Drawing.Size(193, 20);
            this.lblCustomInitialFolderPath.TabIndex = 99;
            this.lblCustomInitialFolderPath.Text = "Custom Initial Folder Path";
            // 
            // tlpDisableVersionCheck
            // 
            this.tlpDisableVersionCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableVersionCheck.ColumnCount = 2;
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableVersionCheck.Controls.Add(this.lblDisableVersionCheck, 0, 0);
            this.tlpDisableVersionCheck.Controls.Add(this.swDisableVersionCheck, 1, 0);
            this.tlpDisableVersionCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableVersionCheck.Location = new System.Drawing.Point(0, 39);
            this.tlpDisableVersionCheck.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableVersionCheck.Name = "tlpDisableVersionCheck";
            this.tlpDisableVersionCheck.RowCount = 1;
            this.tlpDisableVersionCheck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableVersionCheck.TabIndex = 0;
            // 
            // lblDisableVersionCheck
            // 
            this.lblDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableVersionCheck.AutoSize = true;
            this.lblDisableVersionCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableVersionCheck.ForeColor = System.Drawing.Color.White;
            this.lblDisableVersionCheck.Location = new System.Drawing.Point(2, 7);
            this.lblDisableVersionCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableVersionCheck.Name = "lblDisableVersionCheck";
            this.lblDisableVersionCheck.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableVersionCheck.Size = new System.Drawing.Size(167, 20);
            this.lblDisableVersionCheck.TabIndex = 99;
            this.lblDisableVersionCheck.Text = "Disable Version Check";
            // 
            // swDisableVersionCheck
            // 
            this.swDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableVersionCheck.BackColor = System.Drawing.Color.Black;
            this.swDisableVersionCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableVersionCheck.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableVersionCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableVersionCheck.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableVersionCheck.Location = new System.Drawing.Point(365, 8);
            this.swDisableVersionCheck.Name = "swDisableVersionCheck";
            this.swDisableVersionCheck.Size = new System.Drawing.Size(32, 18);
            this.swDisableVersionCheck.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableVersionCheck.TabIndex = 0;
            // 
            // lblStartup
            // 
            this.lblStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblStartup.Location = new System.Drawing.Point(0, 0);
            this.lblStartup.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartup.Name = "lblStartup";
            this.lblStartup.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblStartup.Size = new System.Drawing.Size(408, 38);
            this.lblStartup.TabIndex = 99;
            this.lblStartup.Text = "Startup";
            this.lblStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplication
            // 
            this.lblApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApplication.Location = new System.Drawing.Point(0, 74);
            this.lblApplication.Margin = new System.Windows.Forms.Padding(0);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblApplication.Size = new System.Drawing.Size(408, 38);
            this.lblApplication.TabIndex = 99;
            this.lblApplication.Text = "Application";
            this.lblApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDisableFlashingUiElements
            // 
            this.tlpDisableFlashingUiElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableFlashingUiElements.ColumnCount = 2;
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableFlashingUiElements.Controls.Add(this.swDisableFlashingUiElements, 0, 0);
            this.tlpDisableFlashingUiElements.Controls.Add(this.lblDisableFlashingUiElements, 0, 0);
            this.tlpDisableFlashingUiElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableFlashingUiElements.Location = new System.Drawing.Point(0, 113);
            this.tlpDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableFlashingUiElements.Name = "tlpDisableFlashingUiElements";
            this.tlpDisableFlashingUiElements.RowCount = 1;
            this.tlpDisableFlashingUiElements.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableFlashingUiElements.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableFlashingUiElements.TabIndex = 1;
            // 
            // swDisableFlashingUiElements
            // 
            this.swDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableFlashingUiElements.BackColor = System.Drawing.Color.Black;
            this.swDisableFlashingUiElements.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableFlashingUiElements.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableFlashingUiElements.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableFlashingUiElements.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableFlashingUiElements.Location = new System.Drawing.Point(365, 8);
            this.swDisableFlashingUiElements.Name = "swDisableFlashingUiElements";
            this.swDisableFlashingUiElements.Size = new System.Drawing.Size(32, 18);
            this.swDisableFlashingUiElements.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableFlashingUiElements.TabIndex = 0;
            // 
            // lblDisableFlashingUiElements
            // 
            this.lblDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableFlashingUiElements.AutoSize = true;
            this.lblDisableFlashingUiElements.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableFlashingUiElements.ForeColor = System.Drawing.Color.White;
            this.lblDisableFlashingUiElements.Location = new System.Drawing.Point(2, 7);
            this.lblDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableFlashingUiElements.Name = "lblDisableFlashingUiElements";
            this.lblDisableFlashingUiElements.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableFlashingUiElements.Size = new System.Drawing.Size(212, 20);
            this.lblDisableFlashingUiElements.TabIndex = 99;
            this.lblDisableFlashingUiElements.Text = "Disable Flashing UI Elements";
            // 
            // tlpDisableLzmaDecompression
            // 
            this.tlpDisableLzmaDecompression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableLzmaDecompression.ColumnCount = 2;
            this.tlpDisableLzmaDecompression.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableLzmaDecompression.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableLzmaDecompression.Controls.Add(this.swDisableLzmaDecompression, 0, 0);
            this.tlpDisableLzmaDecompression.Controls.Add(this.lblDisableLzmaDecompression, 0, 0);
            this.tlpDisableLzmaDecompression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableLzmaDecompression.Location = new System.Drawing.Point(0, 361);
            this.tlpDisableLzmaDecompression.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableLzmaDecompression.Name = "tlpDisableLzmaDecompression";
            this.tlpDisableLzmaDecompression.RowCount = 1;
            this.tlpDisableLzmaDecompression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableLzmaDecompression.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableLzmaDecompression.TabIndex = 6;
            // 
            // swDisableLzmaDecompression
            // 
            this.swDisableLzmaDecompression.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableLzmaDecompression.BackColor = System.Drawing.Color.Black;
            this.swDisableLzmaDecompression.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableLzmaDecompression.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableLzmaDecompression.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableLzmaDecompression.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableLzmaDecompression.Location = new System.Drawing.Point(365, 8);
            this.swDisableLzmaDecompression.Name = "swDisableLzmaDecompression";
            this.swDisableLzmaDecompression.Size = new System.Drawing.Size(32, 18);
            this.swDisableLzmaDecompression.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableLzmaDecompression.TabIndex = 0;
            // 
            // lblDisableLzmaDecompression
            // 
            this.lblDisableLzmaDecompression.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableLzmaDecompression.AutoSize = true;
            this.lblDisableLzmaDecompression.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableLzmaDecompression.ForeColor = System.Drawing.Color.White;
            this.lblDisableLzmaDecompression.Location = new System.Drawing.Point(2, 7);
            this.lblDisableLzmaDecompression.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableLzmaDecompression.Name = "lblDisableLzmaDecompression";
            this.lblDisableLzmaDecompression.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableLzmaDecompression.Size = new System.Drawing.Size(220, 20);
            this.lblDisableLzmaDecompression.TabIndex = 99;
            this.lblDisableLzmaDecompression.Text = "Disable LZMA Decompression";
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpDisableLzmaDecompression, 0, 19);
            this.tlpMain.Controls.Add(this.lblApplication, 0, 4);
            this.tlpMain.Controls.Add(this.lblStartup, 0, 0);
            this.tlpMain.Controls.Add(this.tlpDisableVersionCheck, 0, 2);
            this.tlpMain.Controls.Add(this.tlpCustomInitialFolderPath, 0, 14);
            this.tlpMain.Controls.Add(this.tlpDisableConfirmationDialogs, 0, 12);
            this.tlpMain.Controls.Add(this.lblFirmware, 0, 17);
            this.tlpMain.Controls.Add(this.tlpDisableFlashingUiElements, 0, 6);
            this.tlpMain.Controls.Add(this.tlpDisableStatusBarTips, 0, 10);
            this.tlpMain.Controls.Add(this.tlpDisableMessageWindowSounds, 0, 8);
            this.tlpMain.Controls.Add(this.lblPath, 0, 15);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 43);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 22;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(408, 405);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpDisableStatusBarTips
            // 
            this.tlpDisableStatusBarTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableStatusBarTips.ColumnCount = 2;
            this.tlpDisableStatusBarTips.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableStatusBarTips.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableStatusBarTips.Controls.Add(this.swDisableStatusBarTips, 0, 0);
            this.tlpDisableStatusBarTips.Controls.Add(this.lblDisableStatusBarTips, 0, 0);
            this.tlpDisableStatusBarTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableStatusBarTips.Location = new System.Drawing.Point(0, 183);
            this.tlpDisableStatusBarTips.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableStatusBarTips.Name = "tlpDisableStatusBarTips";
            this.tlpDisableStatusBarTips.RowCount = 1;
            this.tlpDisableStatusBarTips.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableStatusBarTips.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableStatusBarTips.TabIndex = 3;
            // 
            // swDisableStatusBarTips
            // 
            this.swDisableStatusBarTips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableStatusBarTips.BackColor = System.Drawing.Color.Black;
            this.swDisableStatusBarTips.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableStatusBarTips.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableStatusBarTips.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableStatusBarTips.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableStatusBarTips.Location = new System.Drawing.Point(365, 8);
            this.swDisableStatusBarTips.Name = "swDisableStatusBarTips";
            this.swDisableStatusBarTips.Size = new System.Drawing.Size(32, 18);
            this.swDisableStatusBarTips.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableStatusBarTips.TabIndex = 0;
            // 
            // lblDisableStatusBarTips
            // 
            this.lblDisableStatusBarTips.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableStatusBarTips.AutoSize = true;
            this.lblDisableStatusBarTips.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableStatusBarTips.ForeColor = System.Drawing.Color.White;
            this.lblDisableStatusBarTips.Location = new System.Drawing.Point(2, 7);
            this.lblDisableStatusBarTips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableStatusBarTips.Name = "lblDisableStatusBarTips";
            this.lblDisableStatusBarTips.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableStatusBarTips.Size = new System.Drawing.Size(170, 20);
            this.lblDisableStatusBarTips.TabIndex = 99;
            this.lblDisableStatusBarTips.Text = "Disable Status Bar Tips";
            // 
            // tlpDisableMessageWindowSounds
            // 
            this.tlpDisableMessageWindowSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableMessageWindowSounds.ColumnCount = 2;
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableMessageWindowSounds.Controls.Add(this.swDisableMessageWindowSounds, 0, 0);
            this.tlpDisableMessageWindowSounds.Controls.Add(this.lblDisableMessageWindowSounds, 0, 0);
            this.tlpDisableMessageWindowSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableMessageWindowSounds.Location = new System.Drawing.Point(0, 148);
            this.tlpDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableMessageWindowSounds.Name = "tlpDisableMessageWindowSounds";
            this.tlpDisableMessageWindowSounds.RowCount = 1;
            this.tlpDisableMessageWindowSounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.Size = new System.Drawing.Size(408, 34);
            this.tlpDisableMessageWindowSounds.TabIndex = 2;
            // 
            // swDisableMessageWindowSounds
            // 
            this.swDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableMessageWindowSounds.BackColor = System.Drawing.Color.Black;
            this.swDisableMessageWindowSounds.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableMessageWindowSounds.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableMessageWindowSounds.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableMessageWindowSounds.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableMessageWindowSounds.Location = new System.Drawing.Point(365, 8);
            this.swDisableMessageWindowSounds.Name = "swDisableMessageWindowSounds";
            this.swDisableMessageWindowSounds.Size = new System.Drawing.Size(32, 18);
            this.swDisableMessageWindowSounds.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableMessageWindowSounds.TabIndex = 0;
            // 
            // lblDisableMessageWindowSounds
            // 
            this.lblDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableMessageWindowSounds.AutoSize = true;
            this.lblDisableMessageWindowSounds.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableMessageWindowSounds.ForeColor = System.Drawing.Color.White;
            this.lblDisableMessageWindowSounds.Location = new System.Drawing.Point(2, 7);
            this.lblDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableMessageWindowSounds.Name = "lblDisableMessageWindowSounds";
            this.lblDisableMessageWindowSounds.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableMessageWindowSounds.Size = new System.Drawing.Size(244, 20);
            this.lblDisableMessageWindowSounds.TabIndex = 99;
            this.lblDisableMessageWindowSounds.Text = "Disable Message Window Sounds";
            // 
            // lblPath
            // 
            this.lblPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPath.Location = new System.Drawing.Point(0, 287);
            this.lblPath.Margin = new System.Windows.Forms.Padding(0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblPath.Size = new System.Drawing.Size(408, 34);
            this.lblPath.TabIndex = 100;
            this.lblPath.Text = "...";
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
            this.tlpTitle.Controls.Add(this.cmdClose, 2, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(408, 40);
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
            this.cmdClose.Location = new System.Drawing.Point(368, 0);
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(328, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(410, 495);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlTitleMenuSplit);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 495);
            this.Name = "settingsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.tlpDisableConfirmationDialogs.ResumeLayout(false);
            this.tlpDisableConfirmationDialogs.PerformLayout();
            this.tlpCustomInitialFolderPath.ResumeLayout(false);
            this.tlpCustomInitialFolderPath.PerformLayout();
            this.tlpDisableVersionCheck.ResumeLayout(false);
            this.tlpDisableVersionCheck.PerformLayout();
            this.tlpDisableFlashingUiElements.ResumeLayout(false);
            this.tlpDisableFlashingUiElements.PerformLayout();
            this.tlpDisableLzmaDecompression.ResumeLayout(false);
            this.tlpDisableLzmaDecompression.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpDisableStatusBarTips.ResumeLayout(false);
            this.tlpDisableStatusBarTips.PerformLayout();
            this.tlpDisableMessageWindowSounds.ResumeLayout(false);
            this.tlpDisableMessageWindowSounds.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdDefaults;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdOkay;
        internal System.Windows.Forms.Panel pnlTitleMenuSplit;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.TableLayoutPanel tlpDisableConfirmationDialogs;
        private System.Windows.Forms.Label lblDisableConfirmationDialogs;
        private System.Windows.Forms.TableLayoutPanel tlpCustomInitialFolderPath;
        private System.Windows.Forms.Label lblCustomInitialFolderPath;
        private System.Windows.Forms.Button cmdEditCustomPath;
        private System.Windows.Forms.TableLayoutPanel tlpDisableVersionCheck;
        private System.Windows.Forms.Label lblDisableVersionCheck;
        private System.Windows.Forms.Label lblStartup;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.TableLayoutPanel tlpDisableFlashingUiElements;
        private System.Windows.Forms.Label lblDisableFlashingUiElements;
        private System.Windows.Forms.TableLayoutPanel tlpDisableLzmaDecompression;
        private System.Windows.Forms.Label lblDisableLzmaDecompression;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblSettingsSaved;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDisableStatusBarTips;
        private System.Windows.Forms.TableLayoutPanel tlpDisableStatusBarTips;
        private System.Windows.Forms.TableLayoutPanel tlpDisableMessageWindowSounds;
        private System.Windows.Forms.Label lblDisableMessageWindowSounds;
        private METLabel lblPath;
        private System.Windows.Forms.PictureBox pbxLogo;
        private UI.METSwitch swDisableVersionCheck;
        private UI.METSwitch swDisableFlashingUiElements;
        private UI.METSwitch swDisableMessageWindowSounds;
        private UI.METSwitch swDisableStatusBarTips;
        private UI.METSwitch swDisableConfirmationDialogs;
        private UI.METSwitch swDisableLzmaDecompression;
    }
}