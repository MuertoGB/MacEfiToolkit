
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
            this.cmdDefaults = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.lblSettingsSaved = new System.Windows.Forms.Label();
            this.cmdOkay = new System.Windows.Forms.Button();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.tlpDisableConfirmationDialogs = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableConfirmationDialogs = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableConfirmationDialogs = new System.Windows.Forms.Label();
            this.tlpEfiDir = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEditEfiDir = new System.Windows.Forms.Button();
            this.lblEfiDefaultDir = new System.Windows.Forms.Label();
            this.tlpDisableVersionCheck = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableVersionCheck = new System.Windows.Forms.Label();
            this.swDisableVersionCheck = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblStartup = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.tlpDisableFlashingUiElements = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableFlashingUiElements = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableFlashingUiElements = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisableStatusBarTips = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableStatusBarTips = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableStatusBarTips = new System.Windows.Forms.Label();
            this.tlpDisableMessageWindowSounds = new System.Windows.Forms.TableLayoutPanel();
            this.swDisableMessageWindowSounds = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblDisableMessageWindowSounds = new System.Windows.Forms.Label();
            this.lblEfiDirectory = new METLabel();
            this.tlpStartupDir = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEditStartupDir = new System.Windows.Forms.Button();
            this.lblStartupDefaultDir = new System.Windows.Forms.Label();
            this.lblStartupDirectory = new METLabel();
            this.tlpSocDir = new System.Windows.Forms.TableLayoutPanel();
            this.cmdEditSocDir = new System.Windows.Forms.Button();
            this.lblSocDefaultDir = new System.Windows.Forms.Label();
            this.lblSocDirectory = new METLabel();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpDisableConfirmationDialogs.SuspendLayout();
            this.tlpEfiDir.SuspendLayout();
            this.tlpDisableVersionCheck.SuspendLayout();
            this.tlpDisableFlashingUiElements.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.tlpDisableStatusBarTips.SuspendLayout();
            this.tlpDisableMessageWindowSounds.SuspendLayout();
            this.tlpStartupDir.SuspendLayout();
            this.tlpSocDir.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDefaults
            // 
            this.cmdDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDefaults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDefaults.FlatAppearance.BorderSize = 0;
            this.cmdDefaults.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdDefaults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDefaults.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefaults.ForeColor = System.Drawing.Color.White;
            this.cmdDefaults.Location = new System.Drawing.Point(290, 0);
            this.cmdDefaults.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDefaults.Name = "cmdDefaults";
            this.cmdDefaults.Size = new System.Drawing.Size(143, 32);
            this.cmdDefaults.TabIndex = 2;
            this.cmdDefaults.Text = "RESET SETTINGS";
            this.cmdDefaults.UseVisualStyleBackColor = false;
            this.cmdDefaults.Click += new System.EventHandler(this.cmdDefaults_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdApply.FlatAppearance.BorderSize = 0;
            this.cmdApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ForeColor = System.Drawing.Color.White;
            this.cmdApply.Location = new System.Drawing.Point(145, 0);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(0);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(143, 32);
            this.cmdApply.TabIndex = 1;
            this.cmdApply.Text = "SAVE";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // lblSettingsSaved
            // 
            this.lblSettingsSaved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblSettingsSaved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSettingsSaved.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsSaved.ForeColor = System.Drawing.Color.White;
            this.lblSettingsSaved.Location = new System.Drawing.Point(0, 0);
            this.lblSettingsSaved.Margin = new System.Windows.Forms.Padding(0);
            this.lblSettingsSaved.Name = "lblSettingsSaved";
            this.lblSettingsSaved.Size = new System.Drawing.Size(433, 32);
            this.lblSettingsSaved.TabIndex = 0;
            this.lblSettingsSaved.Text = "SETTINGS SAVED";
            this.lblSettingsSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOkay
            // 
            this.cmdOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOkay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOkay.FlatAppearance.BorderSize = 0;
            this.cmdOkay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOkay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOkay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOkay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOkay.ForeColor = System.Drawing.Color.White;
            this.cmdOkay.Location = new System.Drawing.Point(0, 0);
            this.cmdOkay.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(143, 32);
            this.cmdOkay.TabIndex = 0;
            this.cmdOkay.Text = "SAVE && CLOSE";
            this.cmdOkay.UseVisualStyleBackColor = false;
            this.cmdOkay.Click += new System.EventHandler(this.cmdOkay_Click);
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(433, 1);
            this.pnlSeperatorTop.TabIndex = 92;
            // 
            // tlpDisableConfirmationDialogs
            // 
            this.tlpDisableConfirmationDialogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tlpDisableConfirmationDialogs.ColumnCount = 2;
            this.tlpDisableConfirmationDialogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableConfirmationDialogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableConfirmationDialogs.Controls.Add(this.swDisableConfirmationDialogs, 0, 0);
            this.tlpDisableConfirmationDialogs.Controls.Add(this.lblDisableConfirmationDialogs, 0, 0);
            this.tlpDisableConfirmationDialogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableConfirmationDialogs.Location = new System.Drawing.Point(0, 198);
            this.tlpDisableConfirmationDialogs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableConfirmationDialogs.Name = "tlpDisableConfirmationDialogs";
            this.tlpDisableConfirmationDialogs.RowCount = 1;
            this.tlpDisableConfirmationDialogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableConfirmationDialogs.Size = new System.Drawing.Size(433, 34);
            this.tlpDisableConfirmationDialogs.TabIndex = 4;
            // 
            // swDisableConfirmationDialogs
            // 
            this.swDisableConfirmationDialogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableConfirmationDialogs.BackColor = System.Drawing.Color.Black;
            this.swDisableConfirmationDialogs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swDisableConfirmationDialogs.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableConfirmationDialogs.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableConfirmationDialogs.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableConfirmationDialogs.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swDisableConfirmationDialogs.Location = new System.Drawing.Point(390, 8);
            this.swDisableConfirmationDialogs.Name = "swDisableConfirmationDialogs";
            this.swDisableConfirmationDialogs.Size = new System.Drawing.Size(32, 18);
            this.swDisableConfirmationDialogs.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableConfirmationDialogs.TabIndex = 0;
            // 
            // lblDisableConfirmationDialogs
            // 
            this.lblDisableConfirmationDialogs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableConfirmationDialogs.AutoSize = true;
            this.lblDisableConfirmationDialogs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableConfirmationDialogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDisableConfirmationDialogs.Location = new System.Drawing.Point(2, 7);
            this.lblDisableConfirmationDialogs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableConfirmationDialogs.Name = "lblDisableConfirmationDialogs";
            this.lblDisableConfirmationDialogs.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableConfirmationDialogs.Size = new System.Drawing.Size(213, 20);
            this.lblDisableConfirmationDialogs.TabIndex = 0;
            this.lblDisableConfirmationDialogs.Text = "Disable Confirmation Dialogs";
            // 
            // tlpEfiDir
            // 
            this.tlpEfiDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tlpEfiDir.ColumnCount = 2;
            this.tlpEfiDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpEfiDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEfiDir.Controls.Add(this.cmdEditEfiDir, 1, 0);
            this.tlpEfiDir.Controls.Add(this.lblEfiDefaultDir, 0, 0);
            this.tlpEfiDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEfiDir.Location = new System.Drawing.Point(0, 294);
            this.tlpEfiDir.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEfiDir.Name = "tlpEfiDir";
            this.tlpEfiDir.RowCount = 1;
            this.tlpEfiDir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEfiDir.Size = new System.Drawing.Size(433, 32);
            this.tlpEfiDir.TabIndex = 6;
            // 
            // cmdEditEfiDir
            // 
            this.cmdEditEfiDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEditEfiDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditEfiDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdEditEfiDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdEditEfiDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdEditEfiDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditEfiDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditEfiDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cmdEditEfiDir.Location = new System.Drawing.Point(379, 0);
            this.cmdEditEfiDir.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditEfiDir.Name = "cmdEditEfiDir";
            this.cmdEditEfiDir.Size = new System.Drawing.Size(54, 32);
            this.cmdEditEfiDir.TabIndex = 0;
            this.cmdEditEfiDir.Text = "EDIT";
            this.cmdEditEfiDir.UseVisualStyleBackColor = false;
            this.cmdEditEfiDir.Click += new System.EventHandler(this.cmdEditEfiDir_Click);
            // 
            // lblEfiDefaultDir
            // 
            this.lblEfiDefaultDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEfiDefaultDir.AutoSize = true;
            this.lblEfiDefaultDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiDefaultDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiDefaultDir.Location = new System.Drawing.Point(2, 6);
            this.lblEfiDefaultDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEfiDefaultDir.Name = "lblEfiDefaultDir";
            this.lblEfiDefaultDir.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiDefaultDir.Size = new System.Drawing.Size(213, 20);
            this.lblEfiDefaultDir.TabIndex = 0;
            this.lblEfiDefaultDir.Text = "EFI Window Default Directory";
            // 
            // tlpDisableVersionCheck
            // 
            this.tlpDisableVersionCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.tlpDisableVersionCheck.ColumnCount = 2;
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableVersionCheck.Controls.Add(this.lblDisableVersionCheck, 0, 0);
            this.tlpDisableVersionCheck.Controls.Add(this.swDisableVersionCheck, 1, 0);
            this.tlpDisableVersionCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableVersionCheck.Location = new System.Drawing.Point(0, 33);
            this.tlpDisableVersionCheck.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableVersionCheck.Name = "tlpDisableVersionCheck";
            this.tlpDisableVersionCheck.RowCount = 1;
            this.tlpDisableVersionCheck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.Size = new System.Drawing.Size(433, 32);
            this.tlpDisableVersionCheck.TabIndex = 0;
            // 
            // lblDisableVersionCheck
            // 
            this.lblDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableVersionCheck.AutoSize = true;
            this.lblDisableVersionCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableVersionCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDisableVersionCheck.Location = new System.Drawing.Point(2, 6);
            this.lblDisableVersionCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableVersionCheck.Name = "lblDisableVersionCheck";
            this.lblDisableVersionCheck.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableVersionCheck.Size = new System.Drawing.Size(162, 20);
            this.lblDisableVersionCheck.TabIndex = 0;
            this.lblDisableVersionCheck.Text = "Disable Version Check";
            // 
            // swDisableVersionCheck
            // 
            this.swDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableVersionCheck.BackColor = System.Drawing.Color.Black;
            this.swDisableVersionCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swDisableVersionCheck.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableVersionCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableVersionCheck.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableVersionCheck.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swDisableVersionCheck.Location = new System.Drawing.Point(390, 7);
            this.swDisableVersionCheck.Name = "swDisableVersionCheck";
            this.swDisableVersionCheck.Size = new System.Drawing.Size(32, 18);
            this.swDisableVersionCheck.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableVersionCheck.TabIndex = 0;
            // 
            // lblStartup
            // 
            this.lblStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblStartup.Location = new System.Drawing.Point(0, 0);
            this.lblStartup.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartup.Name = "lblStartup";
            this.lblStartup.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblStartup.Size = new System.Drawing.Size(433, 32);
            this.lblStartup.TabIndex = 0;
            this.lblStartup.Text = "STARTUP";
            this.lblStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplication
            // 
            this.lblApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApplication.Location = new System.Drawing.Point(0, 66);
            this.lblApplication.Margin = new System.Windows.Forms.Padding(0);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblApplication.Size = new System.Drawing.Size(433, 32);
            this.lblApplication.TabIndex = 0;
            this.lblApplication.Text = "APPLICATION";
            this.lblApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDisableFlashingUiElements
            // 
            this.tlpDisableFlashingUiElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.tlpDisableFlashingUiElements.ColumnCount = 2;
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableFlashingUiElements.Controls.Add(this.swDisableFlashingUiElements, 0, 0);
            this.tlpDisableFlashingUiElements.Controls.Add(this.lblDisableFlashingUiElements, 0, 0);
            this.tlpDisableFlashingUiElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableFlashingUiElements.Location = new System.Drawing.Point(0, 99);
            this.tlpDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableFlashingUiElements.Name = "tlpDisableFlashingUiElements";
            this.tlpDisableFlashingUiElements.RowCount = 1;
            this.tlpDisableFlashingUiElements.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisableFlashingUiElements.Size = new System.Drawing.Size(433, 32);
            this.tlpDisableFlashingUiElements.TabIndex = 1;
            // 
            // swDisableFlashingUiElements
            // 
            this.swDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableFlashingUiElements.BackColor = System.Drawing.Color.Black;
            this.swDisableFlashingUiElements.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swDisableFlashingUiElements.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableFlashingUiElements.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableFlashingUiElements.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableFlashingUiElements.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swDisableFlashingUiElements.Location = new System.Drawing.Point(390, 7);
            this.swDisableFlashingUiElements.Name = "swDisableFlashingUiElements";
            this.swDisableFlashingUiElements.Size = new System.Drawing.Size(32, 18);
            this.swDisableFlashingUiElements.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableFlashingUiElements.TabIndex = 0;
            // 
            // lblDisableFlashingUiElements
            // 
            this.lblDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableFlashingUiElements.AutoSize = true;
            this.lblDisableFlashingUiElements.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableFlashingUiElements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDisableFlashingUiElements.Location = new System.Drawing.Point(2, 6);
            this.lblDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableFlashingUiElements.Name = "lblDisableFlashingUiElements";
            this.lblDisableFlashingUiElements.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableFlashingUiElements.Size = new System.Drawing.Size(207, 20);
            this.lblDisableFlashingUiElements.TabIndex = 0;
            this.lblDisableFlashingUiElements.Text = "Disable Flashing UI Elements";
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblApplication, 0, 4);
            this.tlpMain.Controls.Add(this.tlpStatus, 0, 23);
            this.tlpMain.Controls.Add(this.lblStartup, 0, 0);
            this.tlpMain.Controls.Add(this.tlpDisableVersionCheck, 0, 2);
            this.tlpMain.Controls.Add(this.tlpDisableConfirmationDialogs, 0, 12);
            this.tlpMain.Controls.Add(this.tlpDisableFlashingUiElements, 0, 6);
            this.tlpMain.Controls.Add(this.tlpDisableStatusBarTips, 0, 10);
            this.tlpMain.Controls.Add(this.tlpDisableMessageWindowSounds, 0, 8);
            this.tlpMain.Controls.Add(this.lblEfiDirectory, 0, 18);
            this.tlpMain.Controls.Add(this.tlpEfiDir, 0, 17);
            this.tlpMain.Controls.Add(this.tlpStartupDir, 0, 14);
            this.tlpMain.Controls.Add(this.lblStartupDirectory, 0, 15);
            this.tlpMain.Controls.Add(this.tlpSocDir, 0, 20);
            this.tlpMain.Controls.Add(this.lblSocDirectory, 0, 21);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 75);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 24;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(433, 448);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpStatus
            // 
            this.tlpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpStatus.ColumnCount = 1;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Controls.Add(this.lblSettingsSaved, 0, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(0, 416);
            this.tlpStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 1;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Size = new System.Drawing.Size(433, 32);
            this.tlpStatus.TabIndex = 0;
            // 
            // tlpDisableStatusBarTips
            // 
            this.tlpDisableStatusBarTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.tlpDisableStatusBarTips.ColumnCount = 2;
            this.tlpDisableStatusBarTips.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableStatusBarTips.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableStatusBarTips.Controls.Add(this.swDisableStatusBarTips, 0, 0);
            this.tlpDisableStatusBarTips.Controls.Add(this.lblDisableStatusBarTips, 0, 0);
            this.tlpDisableStatusBarTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableStatusBarTips.Location = new System.Drawing.Point(0, 165);
            this.tlpDisableStatusBarTips.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableStatusBarTips.Name = "tlpDisableStatusBarTips";
            this.tlpDisableStatusBarTips.RowCount = 1;
            this.tlpDisableStatusBarTips.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableStatusBarTips.Size = new System.Drawing.Size(433, 32);
            this.tlpDisableStatusBarTips.TabIndex = 3;
            // 
            // swDisableStatusBarTips
            // 
            this.swDisableStatusBarTips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableStatusBarTips.BackColor = System.Drawing.Color.Black;
            this.swDisableStatusBarTips.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swDisableStatusBarTips.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableStatusBarTips.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableStatusBarTips.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableStatusBarTips.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swDisableStatusBarTips.Location = new System.Drawing.Point(390, 7);
            this.swDisableStatusBarTips.Name = "swDisableStatusBarTips";
            this.swDisableStatusBarTips.Size = new System.Drawing.Size(32, 18);
            this.swDisableStatusBarTips.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableStatusBarTips.TabIndex = 0;
            // 
            // lblDisableStatusBarTips
            // 
            this.lblDisableStatusBarTips.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableStatusBarTips.AutoSize = true;
            this.lblDisableStatusBarTips.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableStatusBarTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDisableStatusBarTips.Location = new System.Drawing.Point(2, 6);
            this.lblDisableStatusBarTips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableStatusBarTips.Name = "lblDisableStatusBarTips";
            this.lblDisableStatusBarTips.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableStatusBarTips.Size = new System.Drawing.Size(168, 20);
            this.lblDisableStatusBarTips.TabIndex = 0;
            this.lblDisableStatusBarTips.Text = "Disable Status Bar Tips";
            // 
            // tlpDisableMessageWindowSounds
            // 
            this.tlpDisableMessageWindowSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tlpDisableMessageWindowSounds.ColumnCount = 2;
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableMessageWindowSounds.Controls.Add(this.swDisableMessageWindowSounds, 0, 0);
            this.tlpDisableMessageWindowSounds.Controls.Add(this.lblDisableMessageWindowSounds, 0, 0);
            this.tlpDisableMessageWindowSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableMessageWindowSounds.Location = new System.Drawing.Point(0, 132);
            this.tlpDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableMessageWindowSounds.Name = "tlpDisableMessageWindowSounds";
            this.tlpDisableMessageWindowSounds.RowCount = 1;
            this.tlpDisableMessageWindowSounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.Size = new System.Drawing.Size(433, 32);
            this.tlpDisableMessageWindowSounds.TabIndex = 2;
            // 
            // swDisableMessageWindowSounds
            // 
            this.swDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableMessageWindowSounds.BackColor = System.Drawing.Color.Black;
            this.swDisableMessageWindowSounds.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.swDisableMessageWindowSounds.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableMessageWindowSounds.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableMessageWindowSounds.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableMessageWindowSounds.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.swDisableMessageWindowSounds.Location = new System.Drawing.Point(390, 7);
            this.swDisableMessageWindowSounds.Name = "swDisableMessageWindowSounds";
            this.swDisableMessageWindowSounds.Size = new System.Drawing.Size(32, 18);
            this.swDisableMessageWindowSounds.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableMessageWindowSounds.TabIndex = 0;
            // 
            // lblDisableMessageWindowSounds
            // 
            this.lblDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableMessageWindowSounds.AutoSize = true;
            this.lblDisableMessageWindowSounds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableMessageWindowSounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDisableMessageWindowSounds.Location = new System.Drawing.Point(2, 6);
            this.lblDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableMessageWindowSounds.Name = "lblDisableMessageWindowSounds";
            this.lblDisableMessageWindowSounds.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableMessageWindowSounds.Size = new System.Drawing.Size(240, 20);
            this.lblDisableMessageWindowSounds.TabIndex = 0;
            this.lblDisableMessageWindowSounds.Text = "Disable Message Window Sounds";
            // 
            // lblEfiDirectory
            // 
            this.lblEfiDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblEfiDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiDirectory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEfiDirectory.Location = new System.Drawing.Point(0, 326);
            this.lblEfiDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiDirectory.Name = "lblEfiDirectory";
            this.lblEfiDirectory.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblEfiDirectory.Size = new System.Drawing.Size(433, 28);
            this.lblEfiDirectory.TabIndex = 0;
            this.lblEfiDirectory.Text = "...";
            // 
            // tlpStartupDir
            // 
            this.tlpStartupDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.tlpStartupDir.ColumnCount = 2;
            this.tlpStartupDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartupDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpStartupDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStartupDir.Controls.Add(this.cmdEditStartupDir, 1, 0);
            this.tlpStartupDir.Controls.Add(this.lblStartupDefaultDir, 0, 0);
            this.tlpStartupDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStartupDir.Location = new System.Drawing.Point(0, 233);
            this.tlpStartupDir.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStartupDir.Name = "tlpStartupDir";
            this.tlpStartupDir.RowCount = 1;
            this.tlpStartupDir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartupDir.Size = new System.Drawing.Size(433, 32);
            this.tlpStartupDir.TabIndex = 5;
            // 
            // cmdEditStartupDir
            // 
            this.cmdEditStartupDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEditStartupDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditStartupDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdEditStartupDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdEditStartupDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdEditStartupDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditStartupDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditStartupDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cmdEditStartupDir.Location = new System.Drawing.Point(379, 0);
            this.cmdEditStartupDir.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditStartupDir.Name = "cmdEditStartupDir";
            this.cmdEditStartupDir.Size = new System.Drawing.Size(54, 32);
            this.cmdEditStartupDir.TabIndex = 0;
            this.cmdEditStartupDir.Text = "EDIT";
            this.cmdEditStartupDir.UseVisualStyleBackColor = false;
            this.cmdEditStartupDir.Click += new System.EventHandler(this.cmdEditStartupDir_Click);
            // 
            // lblStartupDefaultDir
            // 
            this.lblStartupDefaultDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStartupDefaultDir.AutoSize = true;
            this.lblStartupDefaultDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupDefaultDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblStartupDefaultDir.Location = new System.Drawing.Point(2, 6);
            this.lblStartupDefaultDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartupDefaultDir.Name = "lblStartupDefaultDir";
            this.lblStartupDefaultDir.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblStartupDefaultDir.Size = new System.Drawing.Size(242, 20);
            this.lblStartupDefaultDir.TabIndex = 0;
            this.lblStartupDefaultDir.Text = "Startup Window Default Directory";
            // 
            // lblStartupDirectory
            // 
            this.lblStartupDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblStartupDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartupDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupDirectory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStartupDirectory.Location = new System.Drawing.Point(0, 265);
            this.lblStartupDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartupDirectory.Name = "lblStartupDirectory";
            this.lblStartupDirectory.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblStartupDirectory.Size = new System.Drawing.Size(433, 28);
            this.lblStartupDirectory.TabIndex = 102;
            this.lblStartupDirectory.Text = "...";
            // 
            // tlpSocDir
            // 
            this.tlpSocDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.tlpSocDir.ColumnCount = 2;
            this.tlpSocDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSocDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpSocDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSocDir.Controls.Add(this.cmdEditSocDir, 1, 0);
            this.tlpSocDir.Controls.Add(this.lblSocDefaultDir, 0, 0);
            this.tlpSocDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSocDir.Location = new System.Drawing.Point(0, 355);
            this.tlpSocDir.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSocDir.Name = "tlpSocDir";
            this.tlpSocDir.RowCount = 1;
            this.tlpSocDir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSocDir.Size = new System.Drawing.Size(433, 32);
            this.tlpSocDir.TabIndex = 7;
            // 
            // cmdEditSocDir
            // 
            this.cmdEditSocDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEditSocDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditSocDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdEditSocDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdEditSocDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdEditSocDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditSocDir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditSocDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cmdEditSocDir.Location = new System.Drawing.Point(379, 0);
            this.cmdEditSocDir.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditSocDir.Name = "cmdEditSocDir";
            this.cmdEditSocDir.Size = new System.Drawing.Size(54, 32);
            this.cmdEditSocDir.TabIndex = 0;
            this.cmdEditSocDir.Text = "EDIT";
            this.cmdEditSocDir.UseVisualStyleBackColor = false;
            this.cmdEditSocDir.Click += new System.EventHandler(this.cmdEditSocDir_Click);
            // 
            // lblSocDefaultDir
            // 
            this.lblSocDefaultDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocDefaultDir.AutoSize = true;
            this.lblSocDefaultDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocDefaultDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblSocDefaultDir.Location = new System.Drawing.Point(2, 6);
            this.lblSocDefaultDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSocDefaultDir.Name = "lblSocDefaultDir";
            this.lblSocDefaultDir.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSocDefaultDir.Size = new System.Drawing.Size(275, 20);
            this.lblSocDefaultDir.TabIndex = 0;
            this.lblSocDefaultDir.Text = "T2 SOCROM Window Default Directory";
            // 
            // lblSocDirectory
            // 
            this.lblSocDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblSocDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSocDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocDirectory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSocDirectory.Location = new System.Drawing.Point(0, 387);
            this.lblSocDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.lblSocDirectory.Name = "lblSocDirectory";
            this.lblSocDirectory.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblSocDirectory.Size = new System.Drawing.Size(433, 28);
            this.lblSocDirectory.TabIndex = 0;
            this.lblSocDirectory.Text = "...";
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
            this.tlpTitle.Size = new System.Drawing.Size(433, 40);
            this.tlpTitle.TabIndex = 0;
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
            this.cmdClose.Location = new System.Drawing.Point(393, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
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
            this.lblTitle.Size = new System.Drawing.Size(353, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMenu.ColumnCount = 5;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMenu.Controls.Add(this.cmdDefaults, 4, 0);
            this.tlpMenu.Controls.Add(this.cmdOkay, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdApply, 2, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 42);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(433, 32);
            this.tlpMenu.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 1);
            this.panel1.TabIndex = 101;
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(435, 524);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 524);
            this.Name = "settingsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tlpDisableConfirmationDialogs.ResumeLayout(false);
            this.tlpDisableConfirmationDialogs.PerformLayout();
            this.tlpEfiDir.ResumeLayout(false);
            this.tlpEfiDir.PerformLayout();
            this.tlpDisableVersionCheck.ResumeLayout(false);
            this.tlpDisableVersionCheck.PerformLayout();
            this.tlpDisableFlashingUiElements.ResumeLayout(false);
            this.tlpDisableFlashingUiElements.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.tlpDisableStatusBarTips.ResumeLayout(false);
            this.tlpDisableStatusBarTips.PerformLayout();
            this.tlpDisableMessageWindowSounds.ResumeLayout(false);
            this.tlpDisableMessageWindowSounds.PerformLayout();
            this.tlpStartupDir.ResumeLayout(false);
            this.tlpStartupDir.PerformLayout();
            this.tlpSocDir.ResumeLayout(false);
            this.tlpSocDir.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdDefaults;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdOkay;
        internal System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.TableLayoutPanel tlpDisableConfirmationDialogs;
        private System.Windows.Forms.Label lblDisableConfirmationDialogs;
        private System.Windows.Forms.TableLayoutPanel tlpEfiDir;
        private System.Windows.Forms.Label lblEfiDefaultDir;
        private System.Windows.Forms.Button cmdEditEfiDir;
        private System.Windows.Forms.TableLayoutPanel tlpDisableVersionCheck;
        private System.Windows.Forms.Label lblDisableVersionCheck;
        private System.Windows.Forms.Label lblStartup;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.TableLayoutPanel tlpDisableFlashingUiElements;
        private System.Windows.Forms.Label lblDisableFlashingUiElements;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblSettingsSaved;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDisableStatusBarTips;
        private System.Windows.Forms.TableLayoutPanel tlpDisableStatusBarTips;
        private System.Windows.Forms.TableLayoutPanel tlpDisableMessageWindowSounds;
        private System.Windows.Forms.Label lblDisableMessageWindowSounds;
        private METLabel lblEfiDirectory;
        private System.Windows.Forms.PictureBox pbxLogo;
        private UI.METSwitch swDisableVersionCheck;
        private UI.METSwitch swDisableFlashingUiElements;
        private UI.METSwitch swDisableMessageWindowSounds;
        private UI.METSwitch swDisableStatusBarTips;
        private UI.METSwitch swDisableConfirmationDialogs;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.TableLayoutPanel tlpStartupDir;
        private System.Windows.Forms.Button cmdEditStartupDir;
        private System.Windows.Forms.Label lblStartupDefaultDir;
        private METLabel lblStartupDirectory;
        private System.Windows.Forms.TableLayoutPanel tlpSocDir;
        private System.Windows.Forms.Button cmdEditSocDir;
        private System.Windows.Forms.Label lblSocDefaultDir;
        private METLabel lblSocDirectory;
    }
}