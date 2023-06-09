﻿
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
            this.cmdOkay = new System.Windows.Forms.Button();
            this.pnlTitleMenuSplit = new System.Windows.Forms.Panel();
            this.lblFirmwareText = new System.Windows.Forms.Label();
            this.tlpDcd = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDisableConfDiag = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblDcdText = new System.Windows.Forms.Label();
            this.tlpDfe = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDisableDescriptorEnforce = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblDdeText = new System.Windows.Forms.Label();
            this.tlpCif = new System.Windows.Forms.TableLayoutPanel();
            this.lnlCifText = new System.Windows.Forms.Label();
            this.cmdEditCustomPath = new System.Windows.Forms.Button();
            this.tlpDvc = new System.Windows.Forms.TableLayoutPanel();
            this.lblDvcText = new System.Windows.Forms.Label();
            this.cbxDisableVersionCheck = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblStartupText = new System.Windows.Forms.Label();
            this.lblApplicationText = new System.Windows.Forms.Label();
            this.tlpDwf = new System.Windows.Forms.TableLayoutPanel();
            this.lblDwfText = new System.Windows.Forms.Label();
            this.cbxDisableFlashingUI = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpDac = new System.Windows.Forms.TableLayoutPanel();
            this.lblDacText = new System.Windows.Forms.Label();
            this.cbxDisableLzmaFsSearch = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblSettingsApplied = new System.Windows.Forms.Label();
            this.tlpDsbt = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDisableTips = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblDsbtText = new System.Windows.Forms.Label();
            this.tlpDisableMessageSounds = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableMessageSounds = new System.Windows.Forms.Label();
            this.cbxDisableMessageSounds = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpButtons.SuspendLayout();
            this.tlpDcd.SuspendLayout();
            this.tlpDfe.SuspendLayout();
            this.tlpCif.SuspendLayout();
            this.tlpDvc.SuspendLayout();
            this.tlpDwf.SuspendLayout();
            this.tlpDac.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpDsbt.SuspendLayout();
            this.tlpDisableMessageSounds.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpButtons.Controls.Add(this.cmdDefaults, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdApply, 3, 0);
            this.tlpButtons.Controls.Add(this.cmdOkay, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 439);
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
            this.cmdDefaults.Location = new System.Drawing.Point(5, 6);
            this.cmdDefaults.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDefaults.Name = "cmdDefaults";
            this.cmdDefaults.Size = new System.Drawing.Size(100, 34);
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
            this.cmdApply.Location = new System.Drawing.Point(303, 6);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(0);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(100, 34);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
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
            this.cmdOkay.Location = new System.Drawing.Point(198, 6);
            this.cmdOkay.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(100, 34);
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
            // lblFirmwareText
            // 
            this.lblFirmwareText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFirmwareText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirmwareText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmwareText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFirmwareText.Location = new System.Drawing.Point(0, 256);
            this.lblFirmwareText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFirmwareText.Name = "lblFirmwareText";
            this.lblFirmwareText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFirmwareText.Size = new System.Drawing.Size(408, 34);
            this.lblFirmwareText.TabIndex = 99;
            this.lblFirmwareText.Text = "Firmware:";
            this.lblFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDcd
            // 
            this.tlpDcd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDcd.ColumnCount = 2;
            this.tlpDcd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDcd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDcd.Controls.Add(this.cbxDisableConfDiag, 1, 0);
            this.tlpDcd.Controls.Add(this.lblDcdText, 0, 0);
            this.tlpDcd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDcd.Location = new System.Drawing.Point(0, 194);
            this.tlpDcd.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDcd.Name = "tlpDcd";
            this.tlpDcd.RowCount = 1;
            this.tlpDcd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDcd.Size = new System.Drawing.Size(408, 30);
            this.tlpDcd.TabIndex = 4;
            // 
            // cbxDisableConfDiag
            // 
            this.cbxDisableConfDiag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableConfDiag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableConfDiag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableConfDiag.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableConfDiag.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableConfDiag.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableConfDiag.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableConfDiag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableConfDiag.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableConfDiag.Name = "cbxDisableConfDiag";
            this.cbxDisableConfDiag.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableConfDiag.TabIndex = 0;
            // 
            // lblDcdText
            // 
            this.lblDcdText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDcdText.AutoSize = true;
            this.lblDcdText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDcdText.ForeColor = System.Drawing.Color.White;
            this.lblDcdText.Location = new System.Drawing.Point(3, 5);
            this.lblDcdText.Name = "lblDcdText";
            this.lblDcdText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDcdText.Size = new System.Drawing.Size(221, 20);
            this.lblDcdText.TabIndex = 99;
            this.lblDcdText.Text = "Disable Confirmation Dialogs:";
            // 
            // tlpDfe
            // 
            this.tlpDfe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDfe.ColumnCount = 2;
            this.tlpDfe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDfe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDfe.Controls.Add(this.cbxDisableDescriptorEnforce, 1, 0);
            this.tlpDfe.Controls.Add(this.lblDdeText, 0, 0);
            this.tlpDfe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDfe.Location = new System.Drawing.Point(0, 322);
            this.tlpDfe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDfe.Name = "tlpDfe";
            this.tlpDfe.RowCount = 1;
            this.tlpDfe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDfe.Size = new System.Drawing.Size(408, 30);
            this.tlpDfe.TabIndex = 7;
            // 
            // cbxDisableDescriptorEnforce
            // 
            this.cbxDisableDescriptorEnforce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableDescriptorEnforce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableDescriptorEnforce.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableDescriptorEnforce.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableDescriptorEnforce.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableDescriptorEnforce.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableDescriptorEnforce.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableDescriptorEnforce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableDescriptorEnforce.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableDescriptorEnforce.Name = "cbxDisableDescriptorEnforce";
            this.cbxDisableDescriptorEnforce.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableDescriptorEnforce.TabIndex = 0;
            // 
            // lblDdeText
            // 
            this.lblDdeText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDdeText.AutoSize = true;
            this.lblDdeText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDdeText.ForeColor = System.Drawing.Color.White;
            this.lblDdeText.Location = new System.Drawing.Point(3, 5);
            this.lblDdeText.Name = "lblDdeText";
            this.lblDdeText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDdeText.Size = new System.Drawing.Size(315, 20);
            this.lblDdeText.TabIndex = 99;
            this.lblDdeText.Text = "Disable Valid Flash Descriptor Enforcement:";
            // 
            // tlpCif
            // 
            this.tlpCif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpCif.ColumnCount = 2;
            this.tlpCif.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCif.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpCif.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCif.Controls.Add(this.lnlCifText, 0, 0);
            this.tlpCif.Controls.Add(this.cmdEditCustomPath, 1, 0);
            this.tlpCif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCif.Location = new System.Drawing.Point(0, 225);
            this.tlpCif.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCif.Name = "tlpCif";
            this.tlpCif.RowCount = 1;
            this.tlpCif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCif.Size = new System.Drawing.Size(408, 30);
            this.tlpCif.TabIndex = 5;
            // 
            // lnlCifText
            // 
            this.lnlCifText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnlCifText.AutoSize = true;
            this.lnlCifText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlCifText.ForeColor = System.Drawing.Color.White;
            this.lnlCifText.Location = new System.Drawing.Point(3, 5);
            this.lnlCifText.Name = "lnlCifText";
            this.lnlCifText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lnlCifText.Size = new System.Drawing.Size(198, 20);
            this.lnlCifText.TabIndex = 99;
            this.lnlCifText.Text = "Custom Initial Folder Path:";
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
            this.cmdEditCustomPath.Size = new System.Drawing.Size(54, 30);
            this.cmdEditCustomPath.TabIndex = 0;
            this.cmdEditCustomPath.Text = "Edit";
            this.cmdEditCustomPath.UseVisualStyleBackColor = false;
            this.cmdEditCustomPath.Click += new System.EventHandler(this.cmdEditCustomPath_Click);
            // 
            // tlpDvc
            // 
            this.tlpDvc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDvc.ColumnCount = 2;
            this.tlpDvc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDvc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDvc.Controls.Add(this.lblDvcText, 0, 0);
            this.tlpDvc.Controls.Add(this.cbxDisableVersionCheck, 1, 0);
            this.tlpDvc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDvc.Location = new System.Drawing.Point(0, 35);
            this.tlpDvc.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDvc.Name = "tlpDvc";
            this.tlpDvc.RowCount = 1;
            this.tlpDvc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDvc.Size = new System.Drawing.Size(408, 30);
            this.tlpDvc.TabIndex = 0;
            // 
            // lblDvcText
            // 
            this.lblDvcText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDvcText.AutoSize = true;
            this.lblDvcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDvcText.ForeColor = System.Drawing.Color.White;
            this.lblDvcText.Location = new System.Drawing.Point(3, 5);
            this.lblDvcText.Name = "lblDvcText";
            this.lblDvcText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDvcText.Size = new System.Drawing.Size(168, 20);
            this.lblDvcText.TabIndex = 99;
            this.lblDvcText.Text = "Disable Version Check";
            // 
            // cbxDisableVersionCheck
            // 
            this.cbxDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableVersionCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableVersionCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableVersionCheck.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableVersionCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableVersionCheck.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableVersionCheck.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableVersionCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableVersionCheck.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableVersionCheck.Name = "cbxDisableVersionCheck";
            this.cbxDisableVersionCheck.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableVersionCheck.TabIndex = 0;
            // 
            // lblStartupText
            // 
            this.lblStartupText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStartupText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartupText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblStartupText.Location = new System.Drawing.Point(0, 0);
            this.lblStartupText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartupText.Name = "lblStartupText";
            this.lblStartupText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblStartupText.Size = new System.Drawing.Size(408, 34);
            this.lblStartupText.TabIndex = 99;
            this.lblStartupText.Text = "Startup:";
            this.lblStartupText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationText
            // 
            this.lblApplicationText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApplicationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplicationText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApplicationText.Location = new System.Drawing.Point(0, 66);
            this.lblApplicationText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApplicationText.Name = "lblApplicationText";
            this.lblApplicationText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApplicationText.Size = new System.Drawing.Size(408, 34);
            this.lblApplicationText.TabIndex = 99;
            this.lblApplicationText.Text = "Application:";
            this.lblApplicationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDwf
            // 
            this.tlpDwf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDwf.ColumnCount = 2;
            this.tlpDwf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDwf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDwf.Controls.Add(this.lblDwfText, 0, 0);
            this.tlpDwf.Controls.Add(this.cbxDisableFlashingUI, 1, 0);
            this.tlpDwf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDwf.Location = new System.Drawing.Point(0, 101);
            this.tlpDwf.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDwf.Name = "tlpDwf";
            this.tlpDwf.RowCount = 1;
            this.tlpDwf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDwf.Size = new System.Drawing.Size(408, 30);
            this.tlpDwf.TabIndex = 1;
            // 
            // lblDwfText
            // 
            this.lblDwfText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDwfText.AutoSize = true;
            this.lblDwfText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDwfText.ForeColor = System.Drawing.Color.White;
            this.lblDwfText.Location = new System.Drawing.Point(3, 5);
            this.lblDwfText.Name = "lblDwfText";
            this.lblDwfText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDwfText.Size = new System.Drawing.Size(217, 20);
            this.lblDwfText.TabIndex = 99;
            this.lblDwfText.Text = "Disable Flashing UI Elements:";
            // 
            // cbxDisableFlashingUI
            // 
            this.cbxDisableFlashingUI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableFlashingUI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableFlashingUI.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableFlashingUI.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableFlashingUI.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableFlashingUI.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableFlashingUI.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableFlashingUI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableFlashingUI.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableFlashingUI.Name = "cbxDisableFlashingUI";
            this.cbxDisableFlashingUI.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableFlashingUI.TabIndex = 0;
            // 
            // tlpDac
            // 
            this.tlpDac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDac.ColumnCount = 2;
            this.tlpDac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDac.Controls.Add(this.lblDacText, 0, 0);
            this.tlpDac.Controls.Add(this.cbxDisableLzmaFsSearch, 1, 0);
            this.tlpDac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDac.Location = new System.Drawing.Point(0, 291);
            this.tlpDac.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDac.Name = "tlpDac";
            this.tlpDac.RowCount = 1;
            this.tlpDac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDac.Size = new System.Drawing.Size(408, 30);
            this.tlpDac.TabIndex = 6;
            // 
            // lblDacText
            // 
            this.lblDacText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDacText.AutoSize = true;
            this.lblDacText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDacText.ForeColor = System.Drawing.Color.White;
            this.lblDacText.Location = new System.Drawing.Point(3, 5);
            this.lblDacText.Name = "lblDacText";
            this.lblDacText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDacText.Size = new System.Drawing.Size(317, 20);
            this.lblDacText.TabIndex = 99;
            this.lblDacText.Text = "Disable DXE Decompression for APFS Check";
            // 
            // cbxDisableLzmaFsSearch
            // 
            this.cbxDisableLzmaFsSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableLzmaFsSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableLzmaFsSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableLzmaFsSearch.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableLzmaFsSearch.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableLzmaFsSearch.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableLzmaFsSearch.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableLzmaFsSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableLzmaFsSearch.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableLzmaFsSearch.Name = "cbxDisableLzmaFsSearch";
            this.cbxDisableLzmaFsSearch.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableLzmaFsSearch.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpDac, 0, 18);
            this.tlpMain.Controls.Add(this.lblApplicationText, 0, 4);
            this.tlpMain.Controls.Add(this.lblSettingsApplied, 0, 22);
            this.tlpMain.Controls.Add(this.lblStartupText, 0, 0);
            this.tlpMain.Controls.Add(this.tlpDvc, 0, 2);
            this.tlpMain.Controls.Add(this.tlpCif, 0, 14);
            this.tlpMain.Controls.Add(this.tlpDfe, 0, 20);
            this.tlpMain.Controls.Add(this.tlpDcd, 0, 12);
            this.tlpMain.Controls.Add(this.lblFirmwareText, 0, 16);
            this.tlpMain.Controls.Add(this.tlpDwf, 0, 6);
            this.tlpMain.Controls.Add(this.tlpDsbt, 0, 10);
            this.tlpMain.Controls.Add(this.tlpDisableMessageSounds, 0, 8);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 43);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 23;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(408, 396);
            this.tlpMain.TabIndex = 0;
            // 
            // lblSettingsApplied
            // 
            this.lblSettingsApplied.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSettingsApplied.AutoSize = true;
            this.lblSettingsApplied.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.lblSettingsApplied.Location = new System.Drawing.Point(134, 363);
            this.lblSettingsApplied.Name = "lblSettingsApplied";
            this.lblSettingsApplied.Size = new System.Drawing.Size(139, 23);
            this.lblSettingsApplied.TabIndex = 12;
            this.lblSettingsApplied.Text = "Settings Applied!";
            // 
            // tlpDsbt
            // 
            this.tlpDsbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDsbt.ColumnCount = 2;
            this.tlpDsbt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDsbt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDsbt.Controls.Add(this.cbxDisableTips, 1, 0);
            this.tlpDsbt.Controls.Add(this.lblDsbtText, 0, 0);
            this.tlpDsbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDsbt.Location = new System.Drawing.Point(0, 163);
            this.tlpDsbt.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDsbt.Name = "tlpDsbt";
            this.tlpDsbt.RowCount = 1;
            this.tlpDsbt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDsbt.Size = new System.Drawing.Size(408, 30);
            this.tlpDsbt.TabIndex = 3;
            // 
            // cbxDisableTips
            // 
            this.cbxDisableTips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableTips.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableTips.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableTips.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableTips.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableTips.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableTips.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableTips.Name = "cbxDisableTips";
            this.cbxDisableTips.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableTips.TabIndex = 0;
            // 
            // lblDsbtText
            // 
            this.lblDsbtText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDsbtText.AutoSize = true;
            this.lblDsbtText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsbtText.ForeColor = System.Drawing.Color.White;
            this.lblDsbtText.Location = new System.Drawing.Point(3, 5);
            this.lblDsbtText.Name = "lblDsbtText";
            this.lblDsbtText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDsbtText.Size = new System.Drawing.Size(175, 20);
            this.lblDsbtText.TabIndex = 99;
            this.lblDsbtText.Text = "Disable Status Bar Tips:";
            // 
            // tlpDisableMessageSounds
            // 
            this.tlpDisableMessageSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableMessageSounds.ColumnCount = 2;
            this.tlpDisableMessageSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableMessageSounds.Controls.Add(this.lblDisableMessageSounds, 0, 0);
            this.tlpDisableMessageSounds.Controls.Add(this.cbxDisableMessageSounds, 1, 0);
            this.tlpDisableMessageSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableMessageSounds.Location = new System.Drawing.Point(0, 132);
            this.tlpDisableMessageSounds.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableMessageSounds.Name = "tlpDisableMessageSounds";
            this.tlpDisableMessageSounds.RowCount = 1;
            this.tlpDisableMessageSounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageSounds.Size = new System.Drawing.Size(408, 30);
            this.tlpDisableMessageSounds.TabIndex = 2;
            // 
            // lblDisableMessageSounds
            // 
            this.lblDisableMessageSounds.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableMessageSounds.AutoSize = true;
            this.lblDisableMessageSounds.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableMessageSounds.ForeColor = System.Drawing.Color.White;
            this.lblDisableMessageSounds.Location = new System.Drawing.Point(3, 5);
            this.lblDisableMessageSounds.Name = "lblDisableMessageSounds";
            this.lblDisableMessageSounds.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDisableMessageSounds.Size = new System.Drawing.Size(245, 20);
            this.lblDisableMessageSounds.TabIndex = 99;
            this.lblDisableMessageSounds.Text = "Disable Message Window Sounds";
            // 
            // cbxDisableMessageSounds
            // 
            this.cbxDisableMessageSounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableMessageSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxDisableMessageSounds.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableMessageSounds.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableMessageSounds.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.cbxDisableMessageSounds.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableMessageSounds.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableMessageSounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableMessageSounds.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableMessageSounds.Name = "cbxDisableMessageSounds";
            this.cbxDisableMessageSounds.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableMessageSounds.TabIndex = 0;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.cmdClose, 1, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(408, 40);
            this.tlpTitle.TabIndex = 99;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(368, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
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
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(368, 40);
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(410, 486);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlTitleMenuSplit);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 486);
            this.Name = "settingsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tlpButtons.ResumeLayout(false);
            this.tlpDcd.ResumeLayout(false);
            this.tlpDcd.PerformLayout();
            this.tlpDfe.ResumeLayout(false);
            this.tlpDfe.PerformLayout();
            this.tlpCif.ResumeLayout(false);
            this.tlpCif.PerformLayout();
            this.tlpDvc.ResumeLayout(false);
            this.tlpDvc.PerformLayout();
            this.tlpDwf.ResumeLayout(false);
            this.tlpDwf.PerformLayout();
            this.tlpDac.ResumeLayout(false);
            this.tlpDac.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpDsbt.ResumeLayout(false);
            this.tlpDsbt.PerformLayout();
            this.tlpDisableMessageSounds.ResumeLayout(false);
            this.tlpDisableMessageSounds.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdDefaults;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdOkay;
        internal System.Windows.Forms.Panel pnlTitleMenuSplit;
        private System.Windows.Forms.Label lblFirmwareText;
        private System.Windows.Forms.TableLayoutPanel tlpDcd;
        private System.Windows.Forms.Label lblDcdText;
        private UI.METCheckbox cbxDisableConfDiag;
        private System.Windows.Forms.TableLayoutPanel tlpDfe;
        private UI.METCheckbox cbxDisableDescriptorEnforce;
        private System.Windows.Forms.Label lblDdeText;
        private System.Windows.Forms.TableLayoutPanel tlpCif;
        private System.Windows.Forms.Label lnlCifText;
        private System.Windows.Forms.Button cmdEditCustomPath;
        private System.Windows.Forms.TableLayoutPanel tlpDvc;
        private System.Windows.Forms.Label lblDvcText;
        private UI.METCheckbox cbxDisableVersionCheck;
        private System.Windows.Forms.Label lblStartupText;
        private System.Windows.Forms.Label lblApplicationText;
        private System.Windows.Forms.TableLayoutPanel tlpDwf;
        private System.Windows.Forms.Label lblDwfText;
        private UI.METCheckbox cbxDisableFlashingUI;
        private System.Windows.Forms.TableLayoutPanel tlpDac;
        private System.Windows.Forms.Label lblDacText;
        private UI.METCheckbox cbxDisableLzmaFsSearch;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblSettingsApplied;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDsbtText;
        private UI.METCheckbox cbxDisableTips;
        private System.Windows.Forms.TableLayoutPanel tlpDsbt;
        private System.Windows.Forms.TableLayoutPanel tlpDisableMessageSounds;
        private System.Windows.Forms.Label lblDisableMessageSounds;
        private UI.METCheckbox cbxDisableMessageSounds;
    }
}