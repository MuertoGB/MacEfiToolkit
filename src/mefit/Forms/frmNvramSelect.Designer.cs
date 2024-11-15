namespace Mac_EFI_Toolkit.Forms
{
    partial class frmNvramSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNvramSelect));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdOkay = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tlpStores = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxResetVss = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblEraseVss = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEraseSvs = new System.Windows.Forms.Label();
            this.cbxResetSvs = new Mac_EFI_Toolkit.UI.METSwitch();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpStores.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 2);
            this.tlpMain.Controls.Add(this.tlpStores, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 33);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.Size = new System.Drawing.Size(308, 111);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.cmdOkay, 2, 0);
            this.tlpButtons.Controls.Add(this.cmdCancel, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 79);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(308, 32);
            this.tlpButtons.TabIndex = 2;
            // 
            // cmdOkay
            // 
            this.cmdOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdOkay.Enabled = false;
            this.cmdOkay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOkay.FlatAppearance.BorderSize = 0;
            this.cmdOkay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOkay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOkay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOkay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOkay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdOkay.Location = new System.Drawing.Point(154, 0);
            this.cmdOkay.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(154, 32);
            this.cmdOkay.TabIndex = 2;
            this.cmdOkay.Text = "OKAY";
            this.cmdOkay.UseVisualStyleBackColor = false;
            this.cmdOkay.Click += new System.EventHandler(this.cmdOkay_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(153, 32);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tlpStores
            // 
            this.tlpStores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpStores.ColumnCount = 1;
            this.tlpStores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStores.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpStores.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tlpStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStores.Location = new System.Drawing.Point(0, 0);
            this.tlpStores.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStores.Name = "tlpStores";
            this.tlpStores.RowCount = 4;
            this.tlpStores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpStores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpStores.Size = new System.Drawing.Size(308, 78);
            this.tlpStores.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbxResetVss, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEraseVss, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(302, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxResetVss
            // 
            this.cbxResetVss.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbxResetVss.BackColor = System.Drawing.Color.Black;
            this.cbxResetVss.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cbxResetVss.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxResetVss.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.cbxResetVss.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxResetVss.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxResetVss.Location = new System.Drawing.Point(10, 4);
            this.cbxResetVss.Margin = new System.Windows.Forms.Padding(0);
            this.cbxResetVss.Name = "cbxResetVss";
            this.cbxResetVss.Size = new System.Drawing.Size(32, 18);
            this.cbxResetVss.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxResetVss.TabIndex = 0;
            this.cbxResetVss.CheckedChanged += new System.EventHandler(this.cbxResetVss_CheckedChanged);
            // 
            // lblEraseVss
            // 
            this.lblEraseVss.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEraseVss.AutoSize = true;
            this.lblEraseVss.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEraseVss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEraseVss.Location = new System.Drawing.Point(45, 3);
            this.lblEraseVss.Name = "lblEraseVss";
            this.lblEraseVss.Size = new System.Drawing.Size(73, 20);
            this.lblEraseVss.TabIndex = 1;
            this.lblEraseVss.Text = "Erase VSS";
            this.lblEraseVss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblEraseSvs, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxResetSvs, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(302, 27);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblEraseSvs
            // 
            this.lblEraseSvs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEraseSvs.AutoSize = true;
            this.lblEraseSvs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEraseSvs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEraseSvs.Location = new System.Drawing.Point(45, 3);
            this.lblEraseSvs.Name = "lblEraseSvs";
            this.lblEraseSvs.Size = new System.Drawing.Size(217, 20);
            this.lblEraseSvs.TabIndex = 3;
            this.lblEraseSvs.Text = "Erase SVS (Not Recommended)";
            this.lblEraseSvs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxResetSvs
            // 
            this.cbxResetSvs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbxResetSvs.BackColor = System.Drawing.Color.Black;
            this.cbxResetSvs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cbxResetSvs.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxResetSvs.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.cbxResetSvs.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxResetSvs.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbxResetSvs.Location = new System.Drawing.Point(10, 4);
            this.cbxResetSvs.Margin = new System.Windows.Forms.Padding(0);
            this.cbxResetSvs.Name = "cbxResetSvs";
            this.cbxResetSvs.Size = new System.Drawing.Size(32, 18);
            this.cbxResetSvs.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxResetSvs.TabIndex = 1;
            this.cbxResetSvs.CheckedChanged += new System.EventHandler(this.cbxResetSvs_CheckedChanged);
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblWindowTitle.Location = new System.Drawing.Point(1, 1);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(308, 32);
            this.lblWindowTitle.TabIndex = 1;
            this.lblWindowTitle.Text = "Select NVRAM Stores:";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 33);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(308, 1);
            this.pnlSeperatorTop.TabIndex = 2;
            // 
            // frmNvramSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(310, 145);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 145);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 145);
            this.Name = "frmNvramSelect";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reset NVRAM";
            this.tlpMain.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpStores.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdOkay;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TableLayoutPanel tlpStores;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UI.METSwitch cbxResetVss;
        private UI.METSwitch cbxResetSvs;
        private System.Windows.Forms.Label lblEraseVss;
        private System.Windows.Forms.Label lblEraseSvs;
    }
}