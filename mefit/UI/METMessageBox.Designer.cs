
namespace Mac_EFI_Toolkit.UI
{
    partial class METMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(METMessageBox));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdNo = new System.Windows.Forms.Button();
            this.cmdYes = new System.Windows.Forms.Button();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpMessage = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessageIcon = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(490, 248);
            this.pnlMain.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 2);
            this.tlpMain.Controls.Add(this.tlpTitle, 0, 0);
            this.tlpMain.Controls.Add(this.tlpMessage, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpMain.Size = new System.Drawing.Size(490, 248);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.Controls.Add(this.cmdCancel, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdNo, 3, 0);
            this.tlpButtons.Controls.Add(this.cmdYes, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 192);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(490, 56);
            this.tlpButtons.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.White;
            this.cmdCancel.Location = new System.Drawing.Point(10, 11);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 34);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Okay";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNo.ForeColor = System.Drawing.Color.White;
            this.cmdNo.Location = new System.Drawing.Point(380, 11);
            this.cmdNo.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 34);
            this.cmdNo.TabIndex = 2;
            this.cmdNo.Text = "No";
            this.cmdNo.UseVisualStyleBackColor = false;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdYes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdYes.ForeColor = System.Drawing.Color.White;
            this.cmdYes.Location = new System.Drawing.Point(270, 11);
            this.cmdYes.Margin = new System.Windows.Forms.Padding(0);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 34);
            this.cmdYes.TabIndex = 1;
            this.cmdYes.Text = "Yes";
            this.cmdYes.UseVisualStyleBackColor = false;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.Controls.Add(this.cmdClose, 0, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(490, 40);
            this.tlpTitle.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(450, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "x";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(450, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "...";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMessage
            // 
            this.tlpMessage.ColumnCount = 2;
            this.tlpMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessage.Controls.Add(this.lblMessageIcon, 0, 0);
            this.tlpMessage.Controls.Add(this.lblMessage, 1, 0);
            this.tlpMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMessage.Location = new System.Drawing.Point(0, 40);
            this.tlpMessage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMessage.Name = "tlpMessage";
            this.tlpMessage.RowCount = 1;
            this.tlpMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessage.Size = new System.Drawing.Size(490, 152);
            this.tlpMessage.TabIndex = 2;
            // 
            // lblMessageIcon
            // 
            this.lblMessageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageIcon.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageIcon.ForeColor = System.Drawing.Color.White;
            this.lblMessageIcon.Location = new System.Drawing.Point(3, 0);
            this.lblMessageIcon.Name = "lblMessageIcon";
            this.lblMessageIcon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblMessageIcon.Size = new System.Drawing.Size(55, 152);
            this.lblMessageIcon.TabIndex = 1;
            this.lblMessageIcon.Text = "...";
            this.lblMessageIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(64, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(3);
            this.lblMessage.Size = new System.Drawing.Size(423, 152);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // METMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(492, 250);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(492, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(492, 250);
            this.Name = "METMessageBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.Text = "`";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdNo;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdYes;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMessage;
        private System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblMessageIcon;
    }
}