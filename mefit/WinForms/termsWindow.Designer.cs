
namespace Mac_EFI_Toolkit.WinForms
{
    partial class termsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(termsWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbxTermsText = new System.Windows.Forms.TextBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdDecline = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlMain.Controls.Add(this.tbxTermsText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 41);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(4);
            this.pnlMain.Size = new System.Drawing.Size(578, 257);
            this.pnlMain.TabIndex = 95;
            // 
            // tbxTermsText
            // 
            this.tbxTermsText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbxTermsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTermsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTermsText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTermsText.ForeColor = System.Drawing.Color.White;
            this.tbxTermsText.Location = new System.Drawing.Point(4, 4);
            this.tbxTermsText.Margin = new System.Windows.Forms.Padding(0);
            this.tbxTermsText.MaxLength = 5000;
            this.tbxTermsText.Multiline = true;
            this.tbxTermsText.Name = "tbxTermsText";
            this.tbxTermsText.ReadOnly = true;
            this.tbxTermsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTermsText.Size = new System.Drawing.Size(570, 249);
            this.tbxTermsText.TabIndex = 0;
            this.tbxTermsText.TabStop = false;
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.Controls.Add(this.cmdClose, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(578, 40);
            this.tlpTitle.TabIndex = 96;
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
            this.cmdClose.Location = new System.Drawing.Point(538, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(538, 40);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Firmware Editor Terms of Use";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(578, 2);
            this.pnlSeperator.TabIndex = 97;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpButtons.Controls.Add(this.cmdAccept, 2, 0);
            this.tlpButtons.Controls.Add(this.cmdDecline, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 298);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(578, 46);
            this.tlpButtons.TabIndex = 1;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAccept.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.ForeColor = System.Drawing.Color.White;
            this.cmdAccept.Location = new System.Drawing.Point(473, 6);
            this.cmdAccept.Margin = new System.Windows.Forms.Padding(0);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(100, 34);
            this.cmdAccept.TabIndex = 1;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = false;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdDecline
            // 
            this.cmdDecline.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdDecline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdDecline.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdDecline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.cmdDecline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDecline.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDecline.ForeColor = System.Drawing.Color.White;
            this.cmdDecline.Location = new System.Drawing.Point(368, 6);
            this.cmdDecline.Margin = new System.Windows.Forms.Padding(0);
            this.cmdDecline.Name = "cmdDecline";
            this.cmdDecline.Size = new System.Drawing.Size(100, 34);
            this.cmdDecline.TabIndex = 0;
            this.cmdDecline.Text = "Decline";
            this.cmdDecline.UseVisualStyleBackColor = false;
            this.cmdDecline.Click += new System.EventHandler(this.cmdDecline_Click);
            // 
            // termsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(580, 345);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(580, 345);
            this.Name = "termsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Terms";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.TextBox tbxTermsText;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdDecline;
        internal System.Windows.Forms.Button cmdClose;
    }
}