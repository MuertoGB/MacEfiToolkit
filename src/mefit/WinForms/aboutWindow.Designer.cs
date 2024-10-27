
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.tlpTopLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.pbxMuerto = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpTopLabels.SuspendLayout();
            this.tlpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.tlpTopLabels);
            this.pnlMain.Controls.Add(this.tlpTop);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(288, 238);
            this.pnlMain.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 158);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(288, 80);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "This software was created by, and is the intellectual property of David R, aka Mu" +
    "erto, so don\'t eat it.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.UseMnemonic = false;
            // 
            // tlpTopLabels
            // 
            this.tlpTopLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tlpTopLabels.ColumnCount = 1;
            this.tlpTopLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopLabels.Controls.Add(this.lblBuild, 0, 0);
            this.tlpTopLabels.Controls.Add(this.lblChannel, 0, 1);
            this.tlpTopLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTopLabels.Location = new System.Drawing.Point(0, 106);
            this.tlpTopLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopLabels.Name = "tlpTopLabels";
            this.tlpTopLabels.RowCount = 3;
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTopLabels.Size = new System.Drawing.Size(288, 52);
            this.tlpTopLabels.TabIndex = 0;
            // 
            // lblBuild
            // 
            this.lblBuild.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBuild.AutoSize = true;
            this.lblBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblBuild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblBuild.Location = new System.Drawing.Point(133, 2);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(23, 22);
            this.lblBuild.TabIndex = 0;
            this.lblBuild.Text = "...";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuild.UseMnemonic = false;
            // 
            // lblChannel
            // 
            this.lblChannel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChannel.AutoSize = true;
            this.lblChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChannel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblChannel.Location = new System.Drawing.Point(133, 28);
            this.lblChannel.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(23, 22);
            this.lblChannel.TabIndex = 0;
            this.lblChannel.Text = "...";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChannel.UseMnemonic = false;
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlpTop.ColumnCount = 1;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Controls.Add(this.pbxMuerto, 0, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTop.Location = new System.Drawing.Point(0, 32);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(288, 74);
            this.tlpTop.TabIndex = 0;
            // 
            // pbxMuerto
            // 
            this.pbxMuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pbxMuerto.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgmuerto64px;
            this.pbxMuerto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxMuerto.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxMuerto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMuerto.Location = new System.Drawing.Point(0, 0);
            this.pbxMuerto.Margin = new System.Windows.Forms.Padding(0);
            this.pbxMuerto.Name = "pbxMuerto";
            this.pbxMuerto.Size = new System.Drawing.Size(288, 74);
            this.pbxMuerto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMuerto.TabIndex = 85;
            this.pbxMuerto.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Mac EFI Toolkit";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(290, 240);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 240);
            this.Name = "aboutWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.pnlMain.ResumeLayout(false);
            this.tlpTopLabels.ResumeLayout(false);
            this.tlpTopLabels.PerformLayout();
            this.tlpTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMuerto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTopLabels;
        internal System.Windows.Forms.Label lblBuild;
        internal System.Windows.Forms.PictureBox pbxMuerto;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        internal System.Windows.Forms.Label lblChannel;
        internal System.Windows.Forms.Label lblTitle;
    }
}