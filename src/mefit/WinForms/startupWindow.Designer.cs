﻿namespace Mac_EFI_Toolkit.WinForms
{
    partial class startupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startupWindow));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmdMin = new System.Windows.Forms.Button();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdMore = new System.Windows.Forms.Button();
            this.pnlSeperatorBottom = new System.Windows.Forms.Panel();
            this.tlpDrop = new METTableLayout();
            this.lblDrag = new System.Windows.Forms.Label();
            this.lblGlyph = new System.Windows.Forms.Label();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmsMore = new Mac_EFI_Toolkit.UI.METContextMenuStrip();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewApplicationLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMenu.SuspendLayout();
            this.tlpDrop.SuspendLayout();
            this.cmsMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Controls.Add(this.lblAppVersion, 2, 0);
            this.tlpTitle.Controls.Add(this.lblWindowTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 4, 0);
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdMin, 3, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(433, 50);
            this.tlpTitle.TabIndex = 0;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAppVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppVersion.ForeColor = System.Drawing.Color.White;
            this.lblAppVersion.Location = new System.Drawing.Point(286, 14);
            this.lblAppVersion.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(41, 22);
            this.lblAppVersion.TabIndex = 0;
            this.lblAppVersion.Text = "1.2.0";
            this.lblAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWindowTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(50, 0);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(181, 50);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "Mac EFI Toolkit";
            this.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(383, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(50, 50);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "C";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.logo32px;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 9);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(32, 32);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 1;
            this.pbxLogo.TabStop = false;
            // 
            // cmdMin
            // 
            this.cmdMin.BackColor = System.Drawing.Color.Transparent;
            this.cmdMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdMin.FlatAppearance.BorderSize = 0;
            this.cmdMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmdMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmdMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMin.ForeColor = System.Drawing.Color.White;
            this.cmdMin.Location = new System.Drawing.Point(333, 0);
            this.cmdMin.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMin.Name = "cmdMin";
            this.cmdMin.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.cmdMin.Size = new System.Drawing.Size(50, 50);
            this.cmdMin.TabIndex = 0;
            this.cmdMin.TabStop = false;
            this.cmdMin.Text = "—";
            this.cmdMin.UseVisualStyleBackColor = false;
            this.cmdMin.Click += new System.EventHandler(this.cmdMin_Click);
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 51);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(433, 1);
            this.pnlSeperatorTop.TabIndex = 102;
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
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenu.Controls.Add(this.cmdSettings, 0, 0);
            this.tlpMenu.Controls.Add(this.cmdAbout, 2, 0);
            this.tlpMenu.Controls.Add(this.cmdMore, 4, 0);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMenu.Location = new System.Drawing.Point(1, 52);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 1;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Size = new System.Drawing.Size(433, 32);
            this.tlpMenu.TabIndex = 0;
            // 
            // cmdSettings
            // 
            this.cmdSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSettings.FlatAppearance.BorderSize = 0;
            this.cmdSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdSettings.Location = new System.Drawing.Point(1, 0);
            this.cmdSettings.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(142, 32);
            this.cmdSettings.TabIndex = 6;
            this.cmdSettings.Text = "SETTINGS";
            this.cmdSettings.UseVisualStyleBackColor = false;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdAbout.FlatAppearance.BorderSize = 0;
            this.cmdAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdAbout.Location = new System.Drawing.Point(145, 0);
            this.cmdAbout.Margin = new System.Windows.Forms.Padding(0);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(143, 32);
            this.cmdAbout.TabIndex = 7;
            this.cmdAbout.Text = "ABOUT";
            this.cmdAbout.UseVisualStyleBackColor = false;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdMore
            // 
            this.cmdMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdMore.FlatAppearance.BorderSize = 0;
            this.cmdMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdMore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.cmdMore.Location = new System.Drawing.Point(290, 0);
            this.cmdMore.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMore.Name = "cmdMore";
            this.cmdMore.Size = new System.Drawing.Size(143, 32);
            this.cmdMore.TabIndex = 8;
            this.cmdMore.Text = "MORE";
            this.cmdMore.UseVisualStyleBackColor = false;
            this.cmdMore.Click += new System.EventHandler(this.cmdMore_Click);
            // 
            // pnlSeperatorBottom
            // 
            this.pnlSeperatorBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pnlSeperatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorBottom.Location = new System.Drawing.Point(1, 84);
            this.pnlSeperatorBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorBottom.Name = "pnlSeperatorBottom";
            this.pnlSeperatorBottom.Size = new System.Drawing.Size(433, 1);
            this.pnlSeperatorBottom.TabIndex = 104;
            // 
            // tlpDrop
            // 
            this.tlpDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpDrop.ColumnCount = 1;
            this.tlpDrop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDrop.Controls.Add(this.lblDrag, 0, 1);
            this.tlpDrop.Controls.Add(this.lblGlyph, 0, 0);
            this.tlpDrop.Controls.Add(this.cmdOpen, 0, 2);
            this.tlpDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDrop.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpDrop.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpDrop.Location = new System.Drawing.Point(1, 84);
            this.tlpDrop.Name = "tlpDrop";
            this.tlpDrop.RowCount = 3;
            this.tlpDrop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDrop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpDrop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDrop.Size = new System.Drawing.Size(433, 195);
            this.tlpDrop.TabIndex = 1;
            // 
            // lblDrag
            // 
            this.lblDrag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDrag.AutoSize = true;
            this.lblDrag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDrag.Location = new System.Drawing.Point(121, 77);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(191, 40);
            this.lblDrag.TabIndex = 0;
            this.lblDrag.Text = "Drop a file into the window\r\nor";
            this.lblDrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGlyph
            // 
            this.lblGlyph.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGlyph.AutoSize = true;
            this.lblGlyph.ForeColor = System.Drawing.Color.White;
            this.lblGlyph.Location = new System.Drawing.Point(208, 49);
            this.lblGlyph.Name = "lblGlyph";
            this.lblGlyph.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.lblGlyph.Size = new System.Drawing.Size(17, 24);
            this.lblGlyph.TabIndex = 0;
            this.lblGlyph.Text = "...";
            // 
            // cmdOpen
            // 
            this.cmdOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.ForeColor = System.Drawing.Color.White;
            this.cmdOpen.Location = new System.Drawing.Point(179, 124);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(75, 36);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "Browse";
            this.cmdOpen.UseVisualStyleBackColor = false;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmsMore
            // 
            this.cmsMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmsMore.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmsMore.ForeColor = System.Drawing.Color.White;
            this.cmsMore.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changelogToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.emailMeToolStripMenuItem,
            this.githubIssuesToolStripMenuItem,
            this.homepageToolStripMenuItem,
            this.manualToolStripMenuItem,
            this.toolStripSeparator2,
            this.updateAvailableToolStripMenuItem,
            this.viewApplicationLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.restartApplicationToolStripMenuItem});
            this.cmsMore.Name = "cmsMore";
            this.cmsMore.ShowImageMargin = false;
            this.cmsMore.Size = new System.Drawing.Size(216, 296);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changelogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // githubIssuesToolStripMenuItem
            // 
            this.githubIssuesToolStripMenuItem.Name = "githubIssuesToolStripMenuItem";
            this.githubIssuesToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.githubIssuesToolStripMenuItem.Text = "Github Issues";
            this.githubIssuesToolStripMenuItem.Click += new System.EventHandler(this.githubIssuesToolStripMenuItem_Click);
            // 
            // emailMeToolStripMenuItem
            // 
            this.emailMeToolStripMenuItem.Name = "emailMeToolStripMenuItem";
            this.emailMeToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.emailMeToolStripMenuItem.Text = "Email Me";
            this.emailMeToolStripMenuItem.Click += new System.EventHandler(this.emailMeToolStripMenuItem_Click);
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homepageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.homepageToolStripMenuItem.Text = "Homepage";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // viewApplicationLogToolStripMenuItem
            // 
            this.viewApplicationLogToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewApplicationLogToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewApplicationLogToolStripMenuItem.Name = "viewApplicationLogToolStripMenuItem";
            this.viewApplicationLogToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.viewApplicationLogToolStripMenuItem.Text = "View Application Log";
            this.viewApplicationLogToolStripMenuItem.Click += new System.EventHandler(this.viewApplicationLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // restartApplicationToolStripMenuItem
            // 
            this.restartApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.restartApplicationToolStripMenuItem.Name = "restartApplicationToolStripMenuItem";
            this.restartApplicationToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.restartApplicationToolStripMenuItem.Text = "Restart Application";
            this.restartApplicationToolStripMenuItem.Click += new System.EventHandler(this.restartApplicationToolStripMenuItem_Click);
            // 
            // updateAvailableToolStripMenuItem
            // 
            this.updateAvailableToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.updateAvailableToolStripMenuItem.Name = "updateAvailableToolStripMenuItem";
            this.updateAvailableToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.updateAvailableToolStripMenuItem.Text = "Update Available (1)";
            this.updateAvailableToolStripMenuItem.Visible = false;
            this.updateAvailableToolStripMenuItem.Click += new System.EventHandler(this.updateAvailableToolStripMenuItem_Click);
            // 
            // startupWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(435, 280);
            this.Controls.Add(this.pnlSeperatorBottom);
            this.Controls.Add(this.tlpDrop);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(435, 280);
            this.Name = "startupWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "startupWindow";
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            this.tlpDrop.ResumeLayout(false);
            this.tlpDrop.PerformLayout();
            this.cmsMore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblWindowTitle;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Button cmdMin;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.Label lblGlyph;
        private METTableLayout tlpDrop;
        private System.Windows.Forms.Label lblDrag;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.Button cmdAbout;
        internal System.Windows.Forms.Button cmdMore;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewApplicationLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartApplicationToolStripMenuItem;
        private UI.METContextMenuStrip cmsMore;
        private System.Windows.Forms.Panel pnlSeperatorBottom;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubIssuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAvailableToolStripMenuItem;
    }
}