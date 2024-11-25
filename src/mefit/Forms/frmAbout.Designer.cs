
namespace Mac_EFI_Toolkit.Forms
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lnkPaypal = new System.Windows.Forms.LinkLabel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tlpMid = new System.Windows.Forms.TableLayoutPanel();
            this.lblDonationsText = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.pbxMuerto = new System.Windows.Forms.PictureBox();
            this.tlpTopLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuild = new System.Windows.Forms.Label();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tlpMid.SuspendLayout();
            this.tlpImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMuerto)).BeginInit();
            this.tlpTopLabels.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pnlMain.Controls.Add(this.tlpBottom);
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.tlpMid);
            this.pnlMain.Controls.Add(this.tlpImages);
            this.pnlMain.Controls.Add(this.pnlSeperatorTop);
            this.pnlMain.Controls.Add(this.tlpTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(363, 233);
            this.pnlMain.TabIndex = 0;
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpBottom.ColumnCount = 1;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Controls.Add(this.lnkPaypal, 0, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 195);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Size = new System.Drawing.Size(363, 38);
            this.tlpBottom.TabIndex = 89;
            // 
            // lnkPaypal
            // 
            this.lnkPaypal.ActiveLinkColor = System.Drawing.Color.Gainsboro;
            this.lnkPaypal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkPaypal.AutoSize = true;
            this.lnkPaypal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPaypal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPaypal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.lnkPaypal.Location = new System.Drawing.Point(9, 9);
            this.lnkPaypal.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lnkPaypal.Name = "lnkPaypal";
            this.lnkPaypal.Size = new System.Drawing.Size(133, 20);
            this.lnkPaypal.TabIndex = 0;
            this.lnkPaypal.TabStop = true;
            this.lnkPaypal.Text = "Donate via PayPal";
            this.lnkPaypal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPaypal_LinkClicked);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 149);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblInfo.Size = new System.Drawing.Size(363, 46);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Enjoy using my software? Support its growth and future updates with a donation!";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.UseMnemonic = false;
            // 
            // tlpMid
            // 
            this.tlpMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpMid.ColumnCount = 1;
            this.tlpMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMid.Controls.Add(this.lblDonationsText, 0, 0);
            this.tlpMid.Controls.Add(this.pnlSplit, 0, 1);
            this.tlpMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMid.Location = new System.Drawing.Point(0, 115);
            this.tlpMid.Name = "tlpMid";
            this.tlpMid.RowCount = 2;
            this.tlpMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMid.Size = new System.Drawing.Size(363, 34);
            this.tlpMid.TabIndex = 88;
            // 
            // lblDonationsText
            // 
            this.lblDonationsText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonationsText.AutoSize = true;
            this.lblDonationsText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonationsText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDonationsText.Location = new System.Drawing.Point(8, 4);
            this.lblDonationsText.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDonationsText.Name = "lblDonationsText";
            this.lblDonationsText.Size = new System.Drawing.Size(79, 20);
            this.lblDonationsText.TabIndex = 0;
            this.lblDonationsText.Text = "Donations";
            // 
            // pnlSplit
            // 
            this.pnlSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlSplit.Location = new System.Drawing.Point(12, 28);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.pnlSplit.Size = new System.Drawing.Size(339, 1);
            this.pnlSplit.TabIndex = 1;
            // 
            // tlpImages
            // 
            this.tlpImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpImages.ColumnCount = 2;
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.Controls.Add(this.pbxMuerto, 0, 0);
            this.tlpImages.Controls.Add(this.tlpTopLabels, 1, 0);
            this.tlpImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpImages.Location = new System.Drawing.Point(0, 33);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 1;
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.Size = new System.Drawing.Size(363, 82);
            this.tlpImages.TabIndex = 87;
            // 
            // pbxMuerto
            // 
            this.pbxMuerto.BackColor = System.Drawing.Color.Transparent;
            this.pbxMuerto.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.icon64;
            this.pbxMuerto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxMuerto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMuerto.Location = new System.Drawing.Point(0, 0);
            this.pbxMuerto.Margin = new System.Windows.Forms.Padding(0);
            this.pbxMuerto.Name = "pbxMuerto";
            this.pbxMuerto.Size = new System.Drawing.Size(90, 82);
            this.pbxMuerto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxMuerto.TabIndex = 85;
            this.pbxMuerto.TabStop = false;
            // 
            // tlpTopLabels
            // 
            this.tlpTopLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpTopLabels.ColumnCount = 1;
            this.tlpTopLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopLabels.Controls.Add(this.lblBuild, 0, 0);
            this.tlpTopLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopLabels.Location = new System.Drawing.Point(90, 0);
            this.tlpTopLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopLabels.Name = "tlpTopLabels";
            this.tlpTopLabels.RowCount = 1;
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpTopLabels.Size = new System.Drawing.Size(273, 82);
            this.tlpTopLabels.TabIndex = 0;
            // 
            // lblBuild
            // 
            this.lblBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuild.AutoSize = true;
            this.lblBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.lblBuild.Location = new System.Drawing.Point(0, 31);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(21, 20);
            this.lblBuild.TabIndex = 0;
            this.lblBuild.Text = "...";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuild.UseMnemonic = false;
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(0, 32);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(363, 1);
            this.pnlSeperatorTop.TabIndex = 0;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTitle.Controls.Add(this.cmdClose, 1, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(363, 32);
            this.tlpTitle.TabIndex = 86;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(331, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(32, 32);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "x";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(331, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "About";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(365, 235);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(365, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(365, 235);
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.pnlMain.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.tlpMid.ResumeLayout(false);
            this.tlpMid.PerformLayout();
            this.tlpImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMuerto)).EndInit();
            this.tlpTopLabels.ResumeLayout(false);
            this.tlpTopLabels.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTopLabels;
        internal System.Windows.Forms.Label lblBuild;
        internal System.Windows.Forms.PictureBox pbxMuerto;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TableLayoutPanel tlpMid;
        private System.Windows.Forms.Label lblDonationsText;
        private System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.LinkLabel lnkPaypal;
    }
}