
namespace Mac_EFI_Toolkit.WinForms
{
    partial class aboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdDonate = new System.Windows.Forms.Button();
            this.cmdIssues = new System.Windows.Forms.Button();
            this.cmdEmail = new System.Windows.Forms.Button();
            this.cmdSource = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.tlpTopLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpTopLabels.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.pnlSplit);
            this.pnlMain.Controls.Add(this.tlpTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 41);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(438, 238);
            this.pnlMain.TabIndex = 71;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.cmdDonate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdIssues, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdEmail, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdSource, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmdDonate
            // 
            this.cmdDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDonate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDonate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDonate.FlatAppearance.BorderSize = 0;
            this.cmdDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDonate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDonate.ForeColor = System.Drawing.Color.White;
            this.cmdDonate.Location = new System.Drawing.Point(327, 0);
            this.cmdDonate.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDonate.Name = "cmdDonate";
            this.cmdDonate.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdDonate.Size = new System.Drawing.Size(111, 36);
            this.cmdDonate.TabIndex = 3;
            this.cmdDonate.Text = "DONATE";
            this.cmdDonate.UseVisualStyleBackColor = false;
            this.cmdDonate.Click += new System.EventHandler(this.cmdDonate_Click);
            // 
            // cmdIssues
            // 
            this.cmdIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdIssues.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdIssues.FlatAppearance.BorderSize = 0;
            this.cmdIssues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdIssues.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdIssues.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIssues.ForeColor = System.Drawing.Color.White;
            this.cmdIssues.Location = new System.Drawing.Point(218, 0);
            this.cmdIssues.Margin = new System.Windows.Forms.Padding(0);
            this.cmdIssues.Name = "cmdIssues";
            this.cmdIssues.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdIssues.Size = new System.Drawing.Size(108, 36);
            this.cmdIssues.TabIndex = 2;
            this.cmdIssues.Text = "ISSUES";
            this.cmdIssues.UseVisualStyleBackColor = false;
            this.cmdIssues.Click += new System.EventHandler(this.cmdIssues_Click);
            // 
            // cmdEmail
            // 
            this.cmdEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEmail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEmail.FlatAppearance.BorderSize = 0;
            this.cmdEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmail.ForeColor = System.Drawing.Color.White;
            this.cmdEmail.Location = new System.Drawing.Point(0, 0);
            this.cmdEmail.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEmail.Name = "cmdEmail";
            this.cmdEmail.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdEmail.Size = new System.Drawing.Size(108, 36);
            this.cmdEmail.TabIndex = 0;
            this.cmdEmail.Text = "EMAIL ME";
            this.cmdEmail.UseVisualStyleBackColor = false;
            this.cmdEmail.Click += new System.EventHandler(this.cmdEmail_Click);
            // 
            // cmdSource
            // 
            this.cmdSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSource.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSource.FlatAppearance.BorderSize = 0;
            this.cmdSource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSource.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSource.ForeColor = System.Drawing.Color.White;
            this.cmdSource.Location = new System.Drawing.Point(109, 0);
            this.cmdSource.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSource.Name = "cmdSource";
            this.cmdSource.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdSource.Size = new System.Drawing.Size(108, 36);
            this.cmdSource.TabIndex = 1;
            this.cmdSource.Text = "SOURCE";
            this.cmdSource.UseVisualStyleBackColor = false;
            this.cmdSource.Click += new System.EventHandler(this.cmdSource_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(0, 94);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblInfo.Size = new System.Drawing.Size(438, 93);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "This software was created by, and is the intellectual property of David R, aka Mu" +
    "erto, so don\'t eat it.\r\nThe \'Muerto\' avatar was hand crafted by Hammi.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSplit
            // 
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(0, 93);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(438, 1);
            this.pnlSplit.TabIndex = 88;
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTop.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTop.Controls.Add(this.tlpTopLabels, 1, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(438, 93);
            this.tlpTop.TabIndex = 87;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxLogo.Image = global::Mac_EFI_Toolkit.Properties.Resources.imgmuerto64px;
            this.pbxLogo.Location = new System.Drawing.Point(18, 14);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(64, 64);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 85;
            this.pbxLogo.TabStop = false;
            // 
            // tlpTopLabels
            // 
            this.tlpTopLabels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpTopLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpTopLabels.ColumnCount = 1;
            this.tlpTopLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopLabels.Controls.Add(this.lblBuild, 0, 1);
            this.tlpTopLabels.Controls.Add(this.lblName, 0, 0);
            this.tlpTopLabels.Location = new System.Drawing.Point(100, 20);
            this.tlpTopLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopLabels.Name = "tlpTopLabels";
            this.tlpTopLabels.RowCount = 3;
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.Size = new System.Drawing.Size(316, 52);
            this.tlpTopLabels.TabIndex = 86;
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblBuild.Location = new System.Drawing.Point(0, 26);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(316, 26);
            this.lblBuild.TabIndex = 78;
            this.lblBuild.Text = "...";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(316, 26);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "Mac EFI Toolkit";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 1, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(438, 40);
            this.tlpTitle.TabIndex = 72;
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
            this.lblTitle.Size = new System.Drawing.Size(398, 40);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "About";
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
            this.cmdClose.Location = new System.Drawing.Point(398, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
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
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(438, 2);
            this.pnlSeperator.TabIndex = 94;
            // 
            // aboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(440, 280);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 280);
            this.Name = "aboutWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpTopLabels.ResumeLayout(false);
            this.tlpTopLabels.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.TableLayoutPanel tlpTopLabels;
        internal System.Windows.Forms.Label lblBuild;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cmdDonate;
        private System.Windows.Forms.Button cmdIssues;
        private System.Windows.Forms.Button cmdEmail;
        private System.Windows.Forms.Button cmdSource;
        private System.Windows.Forms.Panel pnlSeperator;
    }
}