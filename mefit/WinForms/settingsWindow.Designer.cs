
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
            this.panTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdDefaults = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCloseForm = new System.Windows.Forms.Button();
            this.pnlTitleMenuSplit = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDacText = new System.Windows.Forms.Label();
            this.cbxDisableLzmaFsSearch = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDwfText = new System.Windows.Forms.Label();
            this.cbxDisableFlashingUI = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblApplicationText = new System.Windows.Forms.Label();
            this.lblStartupText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDscText = new System.Windows.Forms.Label();
            this.cbxDisableVersionCheck = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lnlCidText = new System.Windows.Forms.Label();
            this.cmdEditCustomPath = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDfeText = new System.Windows.Forms.Label();
            this.cbxDisableFsysEnforce = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAetText = new System.Windows.Forms.Label();
            this.cbxAcceptedEditingTerms = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cmdEditingTerms = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDdeText = new System.Windows.Forms.Label();
            this.cbxDisableDescriptorEnforce = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDcdText = new System.Windows.Forms.Label();
            this.cbxDisableConfDiag = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblFirmwareText = new System.Windows.Forms.Label();
            this.lblSettingsUpdated = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panTitle.BackgroundImage")));
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Controls.Add(this.cmdClose);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(1, 1);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(408, 40);
            this.panTitle.TabIndex = 1;
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
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmdClose.Location = new System.Drawing.Point(368, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "✕";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.Controls.Add(this.cmdDefaults, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdApply, 3, 0);
            this.tlpButtons.Controls.Add(this.cmdCloseForm, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 443);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(408, 56);
            this.tlpButtons.TabIndex = 2;
            // 
            // cmdDefaults
            // 
            this.cmdDefaults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdDefaults.Enabled = false;
            this.cmdDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDefaults.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefaults.ForeColor = System.Drawing.Color.White;
            this.cmdDefaults.Location = new System.Drawing.Point(10, 11);
            this.cmdDefaults.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDefaults.Name = "cmdDefaults";
            this.cmdDefaults.Size = new System.Drawing.Size(100, 34);
            this.cmdDefaults.TabIndex = 2;
            this.cmdDefaults.Text = "Defaults";
            this.cmdDefaults.UseVisualStyleBackColor = false;
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ForeColor = System.Drawing.Color.White;
            this.cmdApply.Location = new System.Drawing.Point(298, 11);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(0);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(100, 34);
            this.cmdApply.TabIndex = 4;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCloseForm
            // 
            this.cmdCloseForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCloseForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCloseForm.ForeColor = System.Drawing.Color.White;
            this.cmdCloseForm.Location = new System.Drawing.Point(188, 11);
            this.cmdCloseForm.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCloseForm.Name = "cmdCloseForm";
            this.cmdCloseForm.Size = new System.Drawing.Size(100, 34);
            this.cmdCloseForm.TabIndex = 3;
            this.cmdCloseForm.Text = "Close";
            this.cmdCloseForm.UseVisualStyleBackColor = false;
            this.cmdCloseForm.Click += new System.EventHandler(this.cmdCloseForm_Click);
            // 
            // pnlTitleMenuSplit
            // 
            this.pnlTitleMenuSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlTitleMenuSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleMenuSplit.Location = new System.Drawing.Point(1, 41);
            this.pnlTitleMenuSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTitleMenuSplit.Name = "pnlTitleMenuSplit";
            this.pnlTitleMenuSplit.Size = new System.Drawing.Size(408, 2);
            this.pnlTitleMenuSplit.TabIndex = 92;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel4, 0, 14);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tlpMain.Controls.Add(this.lblApplicationText, 0, 4);
            this.tlpMain.Controls.Add(this.lblStartupText, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tlpMain.Controls.Add(this.tableLayoutPanel3, 0, 10);
            this.tlpMain.Controls.Add(this.tableLayoutPanel5, 0, 16);
            this.tlpMain.Controls.Add(this.tableLayoutPanel6, 0, 20);
            this.tlpMain.Controls.Add(this.tableLayoutPanel7, 0, 18);
            this.tlpMain.Controls.Add(this.tableLayoutPanel8, 0, 8);
            this.tlpMain.Controls.Add(this.lblFirmwareText, 0, 12);
            this.tlpMain.Controls.Add(this.lblSettingsUpdated, 0, 22);
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
            this.tlpMain.Size = new System.Drawing.Size(408, 400);
            this.tlpMain.TabIndex = 93;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel4.Controls.Add(this.lblDacText, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbxDisableLzmaFsSearch, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 229);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel4.TabIndex = 6;
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
            this.lblDacText.Size = new System.Drawing.Size(288, 20);
            this.lblDacText.TabIndex = 1;
            this.lblDacText.Text = "Disable APFS check in compressed DXE:";
            // 
            // cbxDisableLzmaFsSearch
            // 
            this.cbxDisableLzmaFsSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableLzmaFsSearch.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableLzmaFsSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableLzmaFsSearch.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableLzmaFsSearch.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableLzmaFsSearch.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableLzmaFsSearch.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableLzmaFsSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableLzmaFsSearch.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableLzmaFsSearch.Name = "cbxDisableLzmaFsSearch";
            this.cbxDisableLzmaFsSearch.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableLzmaFsSearch.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Controls.Add(this.lblDwfText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxDisableFlashingUI, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 101);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel2.TabIndex = 4;
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
            this.lblDwfText.Size = new System.Drawing.Size(214, 20);
            this.lblDwfText.TabIndex = 1;
            this.lblDwfText.Text = "Disable flashing UI elements:";
            // 
            // cbxDisableFlashingUI
            // 
            this.cbxDisableFlashingUI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableFlashingUI.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableFlashingUI.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableFlashingUI.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableFlashingUI.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableFlashingUI.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableFlashingUI.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableFlashingUI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableFlashingUI.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableFlashingUI.Name = "cbxDisableFlashingUI";
            this.cbxDisableFlashingUI.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableFlashingUI.TabIndex = 2;
            // 
            // lblApplicationText
            // 
            this.lblApplicationText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblApplicationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplicationText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApplicationText.Location = new System.Drawing.Point(0, 66);
            this.lblApplicationText.Margin = new System.Windows.Forms.Padding(0);
            this.lblApplicationText.Name = "lblApplicationText";
            this.lblApplicationText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApplicationText.Size = new System.Drawing.Size(408, 34);
            this.lblApplicationText.TabIndex = 3;
            this.lblApplicationText.Text = "Application:";
            this.lblApplicationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartupText
            // 
            this.lblStartupText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblStartupText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartupText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblStartupText.Location = new System.Drawing.Point(0, 0);
            this.lblStartupText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartupText.Name = "lblStartupText";
            this.lblStartupText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblStartupText.Size = new System.Drawing.Size(408, 34);
            this.lblStartupText.TabIndex = 0;
            this.lblStartupText.Text = "Startup:";
            this.lblStartupText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Controls.Add(this.lblDscText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxDisableVersionCheck, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblDscText
            // 
            this.lblDscText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDscText.AutoSize = true;
            this.lblDscText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDscText.ForeColor = System.Drawing.Color.White;
            this.lblDscText.Location = new System.Drawing.Point(3, 5);
            this.lblDscText.Name = "lblDscText";
            this.lblDscText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDscText.Size = new System.Drawing.Size(170, 20);
            this.lblDscText.TabIndex = 1;
            this.lblDscText.Text = "Disable version check:";
            // 
            // cbxDisableVersionCheck
            // 
            this.cbxDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableVersionCheck.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableVersionCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableVersionCheck.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableVersionCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableVersionCheck.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableVersionCheck.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableVersionCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableVersionCheck.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableVersionCheck.Name = "cbxDisableVersionCheck";
            this.cbxDisableVersionCheck.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableVersionCheck.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lnlCidText, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmdEditCustomPath, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 163);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // lnlCidText
            // 
            this.lnlCidText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnlCidText.AutoSize = true;
            this.lnlCidText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlCidText.ForeColor = System.Drawing.Color.White;
            this.lnlCidText.Location = new System.Drawing.Point(3, 5);
            this.lnlCidText.Name = "lnlCidText";
            this.lnlCidText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lnlCidText.Size = new System.Drawing.Size(195, 20);
            this.lnlCidText.TabIndex = 1;
            this.lnlCidText.Text = "Custom initial folder path:";
            // 
            // cmdEditCustomPath
            // 
            this.cmdEditCustomPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdEditCustomPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditCustomPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
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
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel5.Controls.Add(this.lblDfeText, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbxDisableFsysEnforce, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 260);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // lblDfeText
            // 
            this.lblDfeText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDfeText.AutoSize = true;
            this.lblDfeText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDfeText.ForeColor = System.Drawing.Color.White;
            this.lblDfeText.Location = new System.Drawing.Point(3, 5);
            this.lblDfeText.Name = "lblDfeText";
            this.lblDfeText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblDfeText.Size = new System.Drawing.Size(232, 20);
            this.lblDfeText.TabIndex = 1;
            this.lblDfeText.Text = "Disable valid Fsys enforcement:";
            // 
            // cbxDisableFsysEnforce
            // 
            this.cbxDisableFsysEnforce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableFsysEnforce.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableFsysEnforce.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableFsysEnforce.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableFsysEnforce.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableFsysEnforce.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableFsysEnforce.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableFsysEnforce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableFsysEnforce.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableFsysEnforce.Name = "cbxDisableFsysEnforce";
            this.cbxDisableFsysEnforce.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableFsysEnforce.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel6.Controls.Add(this.lblAetText, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxAcceptedEditingTerms, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.cmdEditingTerms, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 322);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // lblAetText
            // 
            this.lblAetText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAetText.AutoSize = true;
            this.lblAetText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAetText.ForeColor = System.Drawing.Color.White;
            this.lblAetText.Location = new System.Drawing.Point(3, 5);
            this.lblAetText.Name = "lblAetText";
            this.lblAetText.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblAetText.Size = new System.Drawing.Size(284, 20);
            this.lblAetText.TabIndex = 1;
            this.lblAetText.Text = "Accept binary editing terms (Disabled):";
            // 
            // cbxAcceptedEditingTerms
            // 
            this.cbxAcceptedEditingTerms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxAcceptedEditingTerms.BackColor = System.Drawing.Color.Transparent;
            this.cbxAcceptedEditingTerms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxAcceptedEditingTerms.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxAcceptedEditingTerms.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxAcceptedEditingTerms.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxAcceptedEditingTerms.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxAcceptedEditingTerms.Enabled = false;
            this.cbxAcceptedEditingTerms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxAcceptedEditingTerms.Location = new System.Drawing.Point(370, 4);
            this.cbxAcceptedEditingTerms.Name = "cbxAcceptedEditingTerms";
            this.cbxAcceptedEditingTerms.Size = new System.Drawing.Size(21, 21);
            this.cbxAcceptedEditingTerms.TabIndex = 2;
            // 
            // cmdEditingTerms
            // 
            this.cmdEditingTerms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdEditingTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEditingTerms.Enabled = false;
            this.cmdEditingTerms.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdEditingTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditingTerms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditingTerms.ForeColor = System.Drawing.Color.White;
            this.cmdEditingTerms.Location = new System.Drawing.Point(300, 0);
            this.cmdEditingTerms.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditingTerms.Name = "cmdEditingTerms";
            this.cmdEditingTerms.Size = new System.Drawing.Size(54, 30);
            this.cmdEditingTerms.TabIndex = 1;
            this.cmdEditingTerms.Text = "View";
            this.cmdEditingTerms.UseVisualStyleBackColor = false;
            this.cmdEditingTerms.Click += new System.EventHandler(this.cmdEditingTerms_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel7.Controls.Add(this.lblDdeText, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cbxDisableDescriptorEnforce, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 291);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel7.TabIndex = 9;
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
            this.lblDdeText.Size = new System.Drawing.Size(273, 20);
            this.lblDdeText.TabIndex = 1;
            this.lblDdeText.Text = "Disable valid descriptor enforcement:";
            // 
            // cbxDisableDescriptorEnforce
            // 
            this.cbxDisableDescriptorEnforce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableDescriptorEnforce.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableDescriptorEnforce.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableDescriptorEnforce.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableDescriptorEnforce.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableDescriptorEnforce.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableDescriptorEnforce.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableDescriptorEnforce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableDescriptorEnforce.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableDescriptorEnforce.Name = "cbxDisableDescriptorEnforce";
            this.cbxDisableDescriptorEnforce.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableDescriptorEnforce.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel8.Controls.Add(this.lblDcdText, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbxDisableConfDiag, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 132);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel8.TabIndex = 10;
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
            this.lblDcdText.Size = new System.Drawing.Size(217, 20);
            this.lblDcdText.TabIndex = 1;
            this.lblDcdText.Text = "Disable confirmation dialogs:";
            // 
            // cbxDisableConfDiag
            // 
            this.cbxDisableConfDiag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDisableConfDiag.BackColor = System.Drawing.Color.Transparent;
            this.cbxDisableConfDiag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxDisableConfDiag.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxDisableConfDiag.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxDisableConfDiag.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxDisableConfDiag.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxDisableConfDiag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxDisableConfDiag.Location = new System.Drawing.Point(370, 4);
            this.cbxDisableConfDiag.Name = "cbxDisableConfDiag";
            this.cbxDisableConfDiag.Size = new System.Drawing.Size(21, 21);
            this.cbxDisableConfDiag.TabIndex = 2;
            // 
            // lblFirmwareText
            // 
            this.lblFirmwareText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblFirmwareText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirmwareText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmwareText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFirmwareText.Location = new System.Drawing.Point(0, 194);
            this.lblFirmwareText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFirmwareText.Name = "lblFirmwareText";
            this.lblFirmwareText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFirmwareText.Size = new System.Drawing.Size(408, 34);
            this.lblFirmwareText.TabIndex = 11;
            this.lblFirmwareText.Text = "Firmware:";
            this.lblFirmwareText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSettingsUpdated
            // 
            this.lblSettingsUpdated.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSettingsUpdated.AutoSize = true;
            this.lblSettingsUpdated.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.lblSettingsUpdated.Location = new System.Drawing.Point(130, 365);
            this.lblSettingsUpdated.Name = "lblSettingsUpdated";
            this.lblSettingsUpdated.Size = new System.Drawing.Size(147, 23);
            this.lblSettingsUpdated.TabIndex = 12;
            this.lblSettingsUpdated.Text = "Settings Updated!";
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(410, 500);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlTitleMenuSplit);
            this.Controls.Add(this.tlpButtons);
            this.Controls.Add(this.panTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 500);
            this.MinimumSize = new System.Drawing.Size(410, 500);
            this.Name = "settingsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panTitle.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdDefaults;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCloseForm;
        internal System.Windows.Forms.Panel pnlTitleMenuSplit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblStartupText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDscText;
        private UI.METCheckbox cbxDisableVersionCheck;
        private System.Windows.Forms.Label lblApplicationText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDwfText;
        private UI.METCheckbox cbxDisableFlashingUI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lnlCidText;
        private System.Windows.Forms.Button cmdEditCustomPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblDacText;
        private UI.METCheckbox cbxDisableLzmaFsSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblDfeText;
        private UI.METCheckbox cbxDisableFsysEnforce;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblAetText;
        private UI.METCheckbox cbxAcceptedEditingTerms;
        private System.Windows.Forms.Button cmdEditingTerms;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblDdeText;
        private UI.METCheckbox cbxDisableDescriptorEnforce;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblDcdText;
        private UI.METCheckbox cbxDisableConfDiag;
        private System.Windows.Forms.Label lblFirmwareText;
        private System.Windows.Forms.Label lblSettingsUpdated;
    }
}