namespace Mac_EFI_Toolkit.Forms
{
    partial class frmSerialSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialSelect));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdOkay = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tlpSsn = new System.Windows.Forms.TableLayoutPanel();
            this.tbxSerial = new System.Windows.Forms.TextBox();
            this.lblValidity = new System.Windows.Forms.Label();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pnlSeperatorTip = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpSsn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 2);
            this.tlpMain.Controls.Add(this.tlpSsn, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 34);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(308, 110);
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
            this.tlpButtons.Location = new System.Drawing.Point(0, 78);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(308, 32);
            this.tlpButtons.TabIndex = 1;
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
            this.cmdOkay.TabIndex = 1;
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
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tlpSsn
            // 
            this.tlpSsn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpSsn.ColumnCount = 1;
            this.tlpSsn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSsn.Controls.Add(this.tbxSerial, 0, 0);
            this.tlpSsn.Controls.Add(this.lblValidity, 0, 1);
            this.tlpSsn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSsn.Location = new System.Drawing.Point(0, 0);
            this.tlpSsn.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSsn.Name = "tlpSsn";
            this.tlpSsn.RowCount = 2;
            this.tlpSsn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSsn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpSsn.Size = new System.Drawing.Size(308, 77);
            this.tlpSsn.TabIndex = 2;
            // 
            // tbxSerial
            // 
            this.tbxSerial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbxSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tbxSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSerial.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSerial.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxSerial.Location = new System.Drawing.Point(70, 14);
            this.tbxSerial.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSerial.MaxLength = 12;
            this.tbxSerial.Multiline = true;
            this.tbxSerial.Name = "tbxSerial";
            this.tbxSerial.Size = new System.Drawing.Size(167, 27);
            this.tbxSerial.TabIndex = 0;
            this.tbxSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSerial.TextChanged += new System.EventHandler(this.tbxSerial_TextChanged);
            // 
            // lblValidity
            // 
            this.lblValidity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblValidity.AutoSize = true;
            this.lblValidity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblValidity.Location = new System.Drawing.Point(143, 46);
            this.lblValidity.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblValidity.Name = "lblValidity";
            this.lblValidity.Size = new System.Drawing.Size(21, 20);
            this.lblValidity.TabIndex = 0;
            this.lblValidity.Text = "...";
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
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "Enter Serial Number:";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSeperatorTip
            // 
            this.pnlSeperatorTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTip.Location = new System.Drawing.Point(1, 33);
            this.pnlSeperatorTip.Name = "pnlSeperatorTip";
            this.pnlSeperatorTip.Size = new System.Drawing.Size(308, 1);
            this.pnlSeperatorTip.TabIndex = 1;
            // 
            // frmSerialSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(310, 145);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSeperatorTip);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 145);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 145);
            this.Name = "frmSerialSelect";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Serial Number";
            this.tlpMain.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpSsn.ResumeLayout(false);
            this.tlpSsn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox tbxSerial;
        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdOkay;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel pnlSeperatorTip;
        private System.Windows.Forms.TableLayoutPanel tlpSsn;
        private System.Windows.Forms.Label lblValidity;
    }
}