namespace Mac_EFI_Toolkit.Forms
{
    partial class frmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate));
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdDownload = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.pnlSeperatorBottom = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.tlpVersions = new System.Windows.Forms.TableLayoutPanel();
            this.lblNewVersionText = new System.Windows.Forms.Label();
            this.lblCurrentVersionText = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.tlpButtons.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(1, 1);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(308, 32);
            this.lblWindowTitle.TabIndex = 2;
            this.lblWindowTitle.Text = "Update Available";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.cmdDownload, 2, 0);
            this.tlpButtons.Controls.Add(this.cmdCancel, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 233);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(308, 32);
            this.tlpButtons.TabIndex = 3;
            // 
            // cmdDownload
            // 
            this.cmdDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDownload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDownload.FlatAppearance.BorderSize = 0;
            this.cmdDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDownload.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDownload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdDownload.Location = new System.Drawing.Point(154, 0);
            this.cmdDownload.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(154, 32);
            this.cmdDownload.TabIndex = 1;
            this.cmdDownload.Text = "UPDATE";
            this.cmdDownload.UseVisualStyleBackColor = false;
            this.cmdDownload.Click += new System.EventHandler(this.cmdUpdate_Click);
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
            this.cmdCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(153, 32);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 33);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(308, 1);
            this.pnlSeperatorTop.TabIndex = 4;
            // 
            // pnlSeperatorBottom
            // 
            this.pnlSeperatorBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeperatorBottom.Location = new System.Drawing.Point(1, 232);
            this.pnlSeperatorBottom.Name = "pnlSeperatorBottom";
            this.pnlSeperatorBottom.Size = new System.Drawing.Size(308, 1);
            this.pnlSeperatorBottom.TabIndex = 5;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblStatus, 0, 2);
            this.tlpMain.Controls.Add(this.lblText, 0, 1);
            this.tlpMain.Controls.Add(this.tlpVersions, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 34);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.Size = new System.Drawing.Size(308, 198);
            this.tlpMain.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblStatus.Location = new System.Drawing.Point(154, 171);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblText.Location = new System.Drawing.Point(9, 74);
            this.lblText.Margin = new System.Windows.Forms.Padding(0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(290, 80);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "The update will be downloaded and launched automatically. Please save any edits, " +
    "as the program will close during the update process.";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpVersions
            // 
            this.tlpVersions.ColumnCount = 3;
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.Controls.Add(this.lblNewVersionText, 0, 0);
            this.tlpVersions.Controls.Add(this.lblCurrentVersionText, 0, 2);
            this.tlpVersions.Controls.Add(this.lblNew, 2, 0);
            this.tlpVersions.Controls.Add(this.lblCurrent, 2, 2);
            this.tlpVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVersions.Location = new System.Drawing.Point(0, 0);
            this.tlpVersions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVersions.Name = "tlpVersions";
            this.tlpVersions.RowCount = 3;
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.Size = new System.Drawing.Size(308, 65);
            this.tlpVersions.TabIndex = 3;
            // 
            // lblNewVersionText
            // 
            this.lblNewVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblNewVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewVersionText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNewVersionText.Location = new System.Drawing.Point(0, 0);
            this.lblNewVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNewVersionText.Name = "lblNewVersionText";
            this.lblNewVersionText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblNewVersionText.Size = new System.Drawing.Size(153, 32);
            this.lblNewVersionText.TabIndex = 0;
            this.lblNewVersionText.Text = "New Version";
            this.lblNewVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentVersionText
            // 
            this.lblCurrentVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblCurrentVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentVersionText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentVersionText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentVersionText.Location = new System.Drawing.Point(0, 33);
            this.lblCurrentVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentVersionText.Name = "lblCurrentVersionText";
            this.lblCurrentVersionText.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblCurrentVersionText.Size = new System.Drawing.Size(153, 32);
            this.lblCurrentVersionText.TabIndex = 1;
            this.lblCurrentVersionText.Text = "Current Version:";
            this.lblCurrentVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNew
            // 
            this.lblNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNew.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblNew.Location = new System.Drawing.Point(154, 0);
            this.lblNew.Margin = new System.Windows.Forms.Padding(0);
            this.lblNew.Name = "lblNew";
            this.lblNew.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblNew.Size = new System.Drawing.Size(154, 32);
            this.lblNew.TabIndex = 2;
            this.lblNew.Text = "...";
            this.lblNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrent
            // 
            this.lblCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblCurrent.Location = new System.Drawing.Point(154, 33);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCurrent.Size = new System.Drawing.Size(154, 32);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "...";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(310, 266);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSeperatorBottom);
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpButtons);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(310, 266);
            this.MinimumSize = new System.Drawing.Size(310, 266);
            this.Name = "frmUpdate";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Available";
            this.tlpButtons.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpVersions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdDownload;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.Panel pnlSeperatorBottom;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel tlpVersions;
        private System.Windows.Forms.Label lblNewVersionText;
        private System.Windows.Forms.Label lblCurrentVersionText;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblCurrent;
    }
}