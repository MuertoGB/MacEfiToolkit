
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
            this.lnkUrls = new System.Windows.Forms.LinkLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tlpLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlMain.Controls.Add(this.labInfo);
            this.pnlMain.Controls.Add(this.lnkUrls);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 91);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(422, 188);
            this.pnlMain.TabIndex = 71;
            // 
            // lnkUrls
            // 
            this.lnkUrls.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkUrls.BackColor = System.Drawing.Color.Transparent;
            this.lnkUrls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnkUrls.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUrls.ForeColor = System.Drawing.Color.White;
            this.lnkUrls.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkUrls.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUrls.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.lnkUrls.Location = new System.Drawing.Point(0, 127);
            this.lnkUrls.Margin = new System.Windows.Forms.Padding(0);
            this.lnkUrls.Name = "lnkUrls";
            this.lnkUrls.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lnkUrls.Size = new System.Drawing.Size(422, 61);
            this.lnkUrls.TabIndex = 10;
            this.lnkUrls.Text = "Contact Me · Source Code · Donate";
            this.lnkUrls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkUrls.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUrls_LinkClicked);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Controls.Add(this.cmdClose, 2, 0);
            this.tlpMain.Controls.Add(this.tlpLabels, 1, 0);
            this.tlpMain.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(1, 1);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(422, 90);
            this.tlpMain.TabIndex = 72;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(382, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "✕";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tlpLabels
            // 
            this.tlpLabels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpLabels.BackColor = System.Drawing.Color.Transparent;
            this.tlpLabels.ColumnCount = 1;
            this.tlpLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLabels.Controls.Add(this.lblBuild, 0, 1);
            this.tlpLabels.Controls.Add(this.lblName, 0, 0);
            this.tlpLabels.Location = new System.Drawing.Point(96, 19);
            this.tlpLabels.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.tlpLabels.Name = "tlpLabels";
            this.tlpLabels.RowCount = 2;
            this.tlpLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpLabels.Size = new System.Drawing.Size(219, 52);
            this.tlpLabels.TabIndex = 86;
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.BackColor = System.Drawing.Color.Transparent;
            this.lblBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.ForeColor = System.Drawing.Color.White;
            this.lblBuild.Location = new System.Drawing.Point(0, 26);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(219, 26);
            this.lblBuild.TabIndex = 78;
            this.lblBuild.Text = "...";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(219, 26);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "Mac EFI Toolkit";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxLogo.Image = global::Mac_EFI_Toolkit.Properties.Resources.imgmuerto64px;
            this.pbxLogo.Location = new System.Drawing.Point(13, 13);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(64, 64);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 85;
            this.pbxLogo.TabStop = false;
            // 
            // labInfo
            // 
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.ForeColor = System.Drawing.Color.White;
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labInfo.Size = new System.Drawing.Size(422, 127);
            this.labInfo.TabIndex = 11;
            this.labInfo.Text = "This software was created by, and is the intellectual property of David R, aka Mu" +
    "erto, so don\'t eat it. The \'Muerto\' avatar was hand crafted by Hammi.";
            this.labInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(424, 280);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(424, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(424, 280);
            this.Name = "aboutWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpLabels.ResumeLayout(false);
            this.tlpLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.LinkLabel lnkUrls;
        internal System.Windows.Forms.TableLayoutPanel tlpMain;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.TableLayoutPanel tlpLabels;
        internal System.Windows.Forms.Label lblBuild;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label labInfo;
    }
}