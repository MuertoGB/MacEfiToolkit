
namespace Mac_EFI_Toolkit.Forms
{
    partial class frmRominfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRominfo));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlSeperatorTop = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSeperatorBtm = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblSectionData = new System.Windows.Forms.Label();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblBiosIdText = new System.Windows.Forms.Label();
            this.lblModelText = new System.Windows.Forms.Label();
            this.lblEfiVersionText = new System.Windows.Forms.Label();
            this.lblBuiltByText = new System.Windows.Forms.Label();
            this.lblDateStamptext = new System.Windows.Forms.Label();
            this.lblRevisionText = new System.Windows.Forms.Label();
            this.lblBootromText = new System.Windows.Forms.Label();
            this.lblBuildcaveText = new System.Windows.Forms.Label();
            this.lblBuildTypeText = new System.Windows.Forms.Label();
            this.lblCompilerText = new System.Windows.Forms.Label();
            this.lblBiosId = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblEfiVersion = new System.Windows.Forms.Label();
            this.lblBuiltBy = new System.Windows.Forms.Label();
            this.lblDateStamp = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.lblBootRom = new System.Windows.Forms.Label();
            this.lblBuildcaveId = new System.Windows.Forms.Label();
            this.lblBuildType = new System.Windows.Forms.Label();
            this.lblCompiler = new METLabel();
            this.tlpStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.cmdExport = new System.Windows.Forms.Button();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.tlpStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 3;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(418, 40);
            this.tlpTitle.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.icon24;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 8);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(24, 24);
            this.pbxLogo.TabIndex = 14;
            this.pbxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(338, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ROM Information";
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
            this.cmdClose.Location = new System.Drawing.Point(378, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pnlSeperatorTop
            // 
            this.pnlSeperatorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorTop.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperatorTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorTop.Name = "pnlSeperatorTop";
            this.pnlSeperatorTop.Size = new System.Drawing.Size(418, 1);
            this.pnlSeperatorTop.TabIndex = 999;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.pnlSeperatorBtm);
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Controls.Add(this.tlpStatusBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 42);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(418, 406);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlSeperatorBtm
            // 
            this.pnlSeperatorBtm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pnlSeperatorBtm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperatorBtm.Location = new System.Drawing.Point(0, 32);
            this.pnlSeperatorBtm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperatorBtm.Name = "pnlSeperatorBtm";
            this.pnlSeperatorBtm.Size = new System.Drawing.Size(418, 1);
            this.pnlSeperatorBtm.TabIndex = 1000;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblSectionData, 0, 2);
            this.tlpMain.Controls.Add(this.tlpInfo, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 32);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(418, 374);
            this.tlpMain.TabIndex = 0;
            // 
            // lblSectionData
            // 
            this.lblSectionData.AutoEllipsis = true;
            this.lblSectionData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblSectionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSectionData.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSectionData.ForeColor = System.Drawing.Color.White;
            this.lblSectionData.Location = new System.Drawing.Point(0, 340);
            this.lblSectionData.Margin = new System.Windows.Forms.Padding(0);
            this.lblSectionData.Name = "lblSectionData";
            this.lblSectionData.Size = new System.Drawing.Size(418, 34);
            this.lblSectionData.TabIndex = 0;
            this.lblSectionData.Text = "...";
            this.lblSectionData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 3;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Controls.Add(this.lblBiosIdText, 0, 0);
            this.tlpInfo.Controls.Add(this.lblModelText, 0, 2);
            this.tlpInfo.Controls.Add(this.lblEfiVersionText, 0, 4);
            this.tlpInfo.Controls.Add(this.lblBuiltByText, 0, 6);
            this.tlpInfo.Controls.Add(this.lblDateStamptext, 0, 8);
            this.tlpInfo.Controls.Add(this.lblRevisionText, 0, 10);
            this.tlpInfo.Controls.Add(this.lblBootromText, 0, 12);
            this.tlpInfo.Controls.Add(this.lblBuildcaveText, 0, 14);
            this.tlpInfo.Controls.Add(this.lblBuildTypeText, 0, 16);
            this.tlpInfo.Controls.Add(this.lblCompilerText, 0, 18);
            this.tlpInfo.Controls.Add(this.lblBiosId, 2, 0);
            this.tlpInfo.Controls.Add(this.lblModel, 2, 2);
            this.tlpInfo.Controls.Add(this.lblEfiVersion, 2, 4);
            this.tlpInfo.Controls.Add(this.lblBuiltBy, 2, 6);
            this.tlpInfo.Controls.Add(this.lblDateStamp, 2, 8);
            this.tlpInfo.Controls.Add(this.lblRevision, 2, 10);
            this.tlpInfo.Controls.Add(this.lblBootRom, 2, 12);
            this.tlpInfo.Controls.Add(this.lblBuildcaveId, 2, 14);
            this.tlpInfo.Controls.Add(this.lblBuildType, 2, 16);
            this.tlpInfo.Controls.Add(this.lblCompiler, 2, 18);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(0, 0);
            this.tlpInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 19;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpInfo.Size = new System.Drawing.Size(418, 339);
            this.tlpInfo.TabIndex = 0;
            // 
            // lblBiosIdText
            // 
            this.lblBiosIdText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBiosIdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBiosIdText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiosIdText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBiosIdText.Location = new System.Drawing.Point(0, 0);
            this.lblBiosIdText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBiosIdText.Name = "lblBiosIdText";
            this.lblBiosIdText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBiosIdText.Size = new System.Drawing.Size(130, 33);
            this.lblBiosIdText.TabIndex = 0;
            this.lblBiosIdText.Text = "BIOS ID";
            this.lblBiosIdText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelText
            // 
            this.lblModelText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblModelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModelText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblModelText.Location = new System.Drawing.Point(0, 34);
            this.lblModelText.Margin = new System.Windows.Forms.Padding(0);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblModelText.Size = new System.Drawing.Size(130, 33);
            this.lblModelText.TabIndex = 0;
            this.lblModelText.Text = "MODEL";
            this.lblModelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfiVersionText
            // 
            this.lblEfiVersionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblEfiVersionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersionText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblEfiVersionText.Location = new System.Drawing.Point(0, 68);
            this.lblEfiVersionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersionText.Name = "lblEfiVersionText";
            this.lblEfiVersionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEfiVersionText.Size = new System.Drawing.Size(130, 33);
            this.lblEfiVersionText.TabIndex = 0;
            this.lblEfiVersionText.Text = "EFI VERSION";
            this.lblEfiVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuiltByText
            // 
            this.lblBuiltByText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBuiltByText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuiltByText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuiltByText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBuiltByText.Location = new System.Drawing.Point(0, 102);
            this.lblBuiltByText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuiltByText.Name = "lblBuiltByText";
            this.lblBuiltByText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBuiltByText.Size = new System.Drawing.Size(130, 33);
            this.lblBuiltByText.TabIndex = 0;
            this.lblBuiltByText.Text = "BUILT BY";
            this.lblBuiltByText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateStamptext
            // 
            this.lblDateStamptext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblDateStamptext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateStamptext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateStamptext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblDateStamptext.Location = new System.Drawing.Point(0, 136);
            this.lblDateStamptext.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateStamptext.Name = "lblDateStamptext";
            this.lblDateStamptext.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDateStamptext.Size = new System.Drawing.Size(130, 33);
            this.lblDateStamptext.TabIndex = 0;
            this.lblDateStamptext.Text = "DATE STAMP";
            this.lblDateStamptext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevisionText
            // 
            this.lblRevisionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblRevisionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevisionText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblRevisionText.Location = new System.Drawing.Point(0, 170);
            this.lblRevisionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblRevisionText.Name = "lblRevisionText";
            this.lblRevisionText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblRevisionText.Size = new System.Drawing.Size(130, 33);
            this.lblRevisionText.TabIndex = 0;
            this.lblRevisionText.Text = "REVISION";
            this.lblRevisionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBootromText
            // 
            this.lblBootromText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBootromText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBootromText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBootromText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBootromText.Location = new System.Drawing.Point(0, 204);
            this.lblBootromText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBootromText.Name = "lblBootromText";
            this.lblBootromText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBootromText.Size = new System.Drawing.Size(130, 33);
            this.lblBootromText.TabIndex = 0;
            this.lblBootromText.Text = "BOOTROM";
            this.lblBootromText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuildcaveText
            // 
            this.lblBuildcaveText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBuildcaveText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuildcaveText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildcaveText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBuildcaveText.Location = new System.Drawing.Point(0, 238);
            this.lblBuildcaveText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuildcaveText.Name = "lblBuildcaveText";
            this.lblBuildcaveText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBuildcaveText.Size = new System.Drawing.Size(130, 33);
            this.lblBuildcaveText.TabIndex = 0;
            this.lblBuildcaveText.Text = "BUILDCAVE ID";
            this.lblBuildcaveText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuildTypeText
            // 
            this.lblBuildTypeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBuildTypeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuildTypeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildTypeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblBuildTypeText.Location = new System.Drawing.Point(0, 272);
            this.lblBuildTypeText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuildTypeText.Name = "lblBuildTypeText";
            this.lblBuildTypeText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBuildTypeText.Size = new System.Drawing.Size(130, 33);
            this.lblBuildTypeText.TabIndex = 0;
            this.lblBuildTypeText.Text = "BUILD TYPE";
            this.lblBuildTypeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompilerText
            // 
            this.lblCompilerText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCompilerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompilerText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompilerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblCompilerText.Location = new System.Drawing.Point(0, 306);
            this.lblCompilerText.Margin = new System.Windows.Forms.Padding(0);
            this.lblCompilerText.Name = "lblCompilerText";
            this.lblCompilerText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblCompilerText.Size = new System.Drawing.Size(130, 33);
            this.lblCompilerText.TabIndex = 0;
            this.lblCompilerText.Text = "COMPILER";
            this.lblCompilerText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBiosId
            // 
            this.lblBiosId.AutoEllipsis = true;
            this.lblBiosId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblBiosId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBiosId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiosId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBiosId.Location = new System.Drawing.Point(131, 0);
            this.lblBiosId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBiosId.Name = "lblBiosId";
            this.lblBiosId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBiosId.Size = new System.Drawing.Size(287, 33);
            this.lblBiosId.TabIndex = 0;
            this.lblBiosId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBiosId.UseMnemonic = false;
            // 
            // lblModel
            // 
            this.lblModel.AutoEllipsis = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblModel.Location = new System.Drawing.Point(131, 34);
            this.lblModel.Margin = new System.Windows.Forms.Padding(0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblModel.Size = new System.Drawing.Size(287, 33);
            this.lblModel.TabIndex = 0;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModel.UseMnemonic = false;
            // 
            // lblEfiVersion
            // 
            this.lblEfiVersion.AutoEllipsis = true;
            this.lblEfiVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblEfiVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEfiVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfiVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblEfiVersion.Location = new System.Drawing.Point(131, 68);
            this.lblEfiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEfiVersion.Name = "lblEfiVersion";
            this.lblEfiVersion.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEfiVersion.Size = new System.Drawing.Size(287, 33);
            this.lblEfiVersion.TabIndex = 0;
            this.lblEfiVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEfiVersion.UseMnemonic = false;
            // 
            // lblBuiltBy
            // 
            this.lblBuiltBy.AutoEllipsis = true;
            this.lblBuiltBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblBuiltBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuiltBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuiltBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBuiltBy.Location = new System.Drawing.Point(131, 102);
            this.lblBuiltBy.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuiltBy.Name = "lblBuiltBy";
            this.lblBuiltBy.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBuiltBy.Size = new System.Drawing.Size(287, 33);
            this.lblBuiltBy.TabIndex = 0;
            this.lblBuiltBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuiltBy.UseMnemonic = false;
            // 
            // lblDateStamp
            // 
            this.lblDateStamp.AutoEllipsis = true;
            this.lblDateStamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblDateStamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateStamp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateStamp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblDateStamp.Location = new System.Drawing.Point(131, 136);
            this.lblDateStamp.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateStamp.Name = "lblDateStamp";
            this.lblDateStamp.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblDateStamp.Size = new System.Drawing.Size(287, 33);
            this.lblDateStamp.TabIndex = 0;
            this.lblDateStamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateStamp.UseMnemonic = false;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoEllipsis = true;
            this.lblRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevision.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblRevision.Location = new System.Drawing.Point(131, 170);
            this.lblRevision.Margin = new System.Windows.Forms.Padding(0);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblRevision.Size = new System.Drawing.Size(287, 33);
            this.lblRevision.TabIndex = 0;
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRevision.UseMnemonic = false;
            // 
            // lblBootRom
            // 
            this.lblBootRom.AutoEllipsis = true;
            this.lblBootRom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblBootRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBootRom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBootRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBootRom.Location = new System.Drawing.Point(131, 204);
            this.lblBootRom.Margin = new System.Windows.Forms.Padding(0);
            this.lblBootRom.Name = "lblBootRom";
            this.lblBootRom.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBootRom.Size = new System.Drawing.Size(287, 33);
            this.lblBootRom.TabIndex = 0;
            this.lblBootRom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBootRom.UseMnemonic = false;
            // 
            // lblBuildcaveId
            // 
            this.lblBuildcaveId.AutoEllipsis = true;
            this.lblBuildcaveId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblBuildcaveId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuildcaveId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildcaveId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBuildcaveId.Location = new System.Drawing.Point(131, 238);
            this.lblBuildcaveId.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuildcaveId.Name = "lblBuildcaveId";
            this.lblBuildcaveId.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBuildcaveId.Size = new System.Drawing.Size(287, 33);
            this.lblBuildcaveId.TabIndex = 0;
            this.lblBuildcaveId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuildcaveId.UseMnemonic = false;
            // 
            // lblBuildType
            // 
            this.lblBuildType.AutoEllipsis = true;
            this.lblBuildType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.lblBuildType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuildType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblBuildType.Location = new System.Drawing.Point(131, 272);
            this.lblBuildType.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuildType.Name = "lblBuildType";
            this.lblBuildType.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblBuildType.Size = new System.Drawing.Size(287, 33);
            this.lblBuildType.TabIndex = 0;
            this.lblBuildType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuildType.UseMnemonic = false;
            // 
            // lblCompiler
            // 
            this.lblCompiler.AutoEllipsis = true;
            this.lblCompiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.lblCompiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompiler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblCompiler.Location = new System.Drawing.Point(131, 306);
            this.lblCompiler.Margin = new System.Windows.Forms.Padding(0);
            this.lblCompiler.Name = "lblCompiler";
            this.lblCompiler.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCompiler.Size = new System.Drawing.Size(287, 33);
            this.lblCompiler.TabIndex = 0;
            this.lblCompiler.UseMnemonic = false;
            // 
            // tlpStatusBar
            // 
            this.tlpStatusBar.ColumnCount = 1;
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatusBar.Controls.Add(this.cmdExport, 0, 0);
            this.tlpStatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpStatusBar.Location = new System.Drawing.Point(0, 0);
            this.tlpStatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatusBar.Name = "tlpStatusBar";
            this.tlpStatusBar.RowCount = 1;
            this.tlpStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatusBar.Size = new System.Drawing.Size(418, 32);
            this.tlpStatusBar.TabIndex = 1;
            // 
            // cmdExport
            // 
            this.cmdExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExport.FlatAppearance.BorderSize = 0;
            this.cmdExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.cmdExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cmdExport.Location = new System.Drawing.Point(0, 0);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(418, 32);
            this.cmdExport.TabIndex = 0;
            this.cmdExport.Text = "EXPORT INFORMATION TO TEXT FILE";
            this.cmdExport.UseVisualStyleBackColor = false;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // frmRominfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(420, 449);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSeperatorTop);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 449);
            this.Name = "frmRominfo";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROM Information";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpStatusBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Panel pnlSeperatorTop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblBiosIdText;
        private System.Windows.Forms.Label lblModelText;
        private System.Windows.Forms.Label lblEfiVersionText;
        private System.Windows.Forms.Label lblBuiltByText;
        private System.Windows.Forms.Label lblDateStamptext;
        private System.Windows.Forms.Label lblRevisionText;
        private System.Windows.Forms.Label lblBootromText;
        private System.Windows.Forms.Label lblBuildcaveText;
        private System.Windows.Forms.Label lblBuildTypeText;
        private System.Windows.Forms.Label lblCompilerText;
        private System.Windows.Forms.Label lblSectionData;
        private System.Windows.Forms.Label lblBiosId;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblEfiVersion;
        private System.Windows.Forms.Label lblBuiltBy;
        private System.Windows.Forms.Label lblDateStamp;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label lblBootRom;
        private System.Windows.Forms.Label lblBuildcaveId;
        private System.Windows.Forms.Label lblBuildType;
        private METLabel lblCompiler;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpStatusBar;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Panel pnlSeperatorBtm;
    }
}