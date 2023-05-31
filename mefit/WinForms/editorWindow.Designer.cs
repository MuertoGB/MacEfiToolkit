
namespace Mac_EFI_Toolkit.WinForms
{
    partial class editorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editorWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.tlpVssOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblVssChevRight = new System.Windows.Forms.Label();
            this.cbxClearVssBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearVssRegion = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.tlpSerialA = new System.Windows.Forms.TableLayoutPanel();
            this.cmdReplaceSerial = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpFsys = new System.Windows.Forms.TableLayoutPanel();
            this.cbxReplaceFsysRgn = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cmdFsysPath = new System.Windows.Forms.Button();
            this.lblFsysText = new System.Windows.Forms.Label();
            this.tlpSerialB = new System.Windows.Forms.TableLayoutPanel();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.lblSsnText = new System.Windows.Forms.Label();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.tbxHwc = new System.Windows.Forms.TextBox();
            this.tlpSerialC = new System.Windows.Forms.TableLayoutPanel();
            this.cbxMaskFsysCrc = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxOverwriteHwc = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpSvsOptions = new System.Windows.Forms.TableLayoutPanel();
            this.cbxClearSvsRegion = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearSvsBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblSvsChevRight = new System.Windows.Forms.Label();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tlpOutput = new System.Windows.Forms.TableLayoutPanel();
            this.lnkUrls = new System.Windows.Forms.LinkLabel();
            this.lblOutputText = new System.Windows.Forms.Label();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.tlpVssOptions.SuspendLayout();
            this.tlpSerialA.SuspendLayout();
            this.tlpFsys.SuspendLayout();
            this.tlpSerialB.SuspendLayout();
            this.tlpSerialC.SuspendLayout();
            this.tlpSvsOptions.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.tlpOutput.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 43);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(948, 436);
            this.pnlMain.TabIndex = 95;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpOptions, 0, 0);
            this.tlpMain.Controls.Add(this.tlpLog, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(948, 436);
            this.tlpMain.TabIndex = 20;
            // 
            // tlpOptions
            // 
            this.tlpOptions.ColumnCount = 1;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.tlpVssOptions, 0, 14);
            this.tlpOptions.Controls.Add(this.lblNvramText, 0, 10);
            this.tlpOptions.Controls.Add(this.lblSerialText, 0, 4);
            this.tlpOptions.Controls.Add(this.tlpSerialA, 0, 6);
            this.tlpOptions.Controls.Add(this.tlpFsys, 0, 2);
            this.tlpOptions.Controls.Add(this.lblFsysText, 0, 0);
            this.tlpOptions.Controls.Add(this.tlpSerialB, 0, 7);
            this.tlpOptions.Controls.Add(this.tlpSerialC, 0, 8);
            this.tlpOptions.Controls.Add(this.tlpSvsOptions, 0, 12);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.Location = new System.Drawing.Point(0, 0);
            this.tlpOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 16;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.Size = new System.Drawing.Size(400, 436);
            this.tlpOptions.TabIndex = 1;
            // 
            // tlpVssOptions
            // 
            this.tlpVssOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpVssOptions.ColumnCount = 3;
            this.tlpVssOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpVssOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpVssOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVssOptions.Controls.Add(this.lblVssChevRight, 0, 0);
            this.tlpVssOptions.Controls.Add(this.cbxClearVssBackup, 2, 0);
            this.tlpVssOptions.Controls.Add(this.cbxClearVssRegion, 0, 0);
            this.tlpVssOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVssOptions.Location = new System.Drawing.Point(0, 258);
            this.tlpVssOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVssOptions.Name = "tlpVssOptions";
            this.tlpVssOptions.RowCount = 1;
            this.tlpVssOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVssOptions.Size = new System.Drawing.Size(400, 30);
            this.tlpVssOptions.TabIndex = 6;
            // 
            // lblVssChevRight
            // 
            this.lblVssChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVssChevRight.AutoSize = true;
            this.lblVssChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssChevRight.ForeColor = System.Drawing.Color.White;
            this.lblVssChevRight.Location = new System.Drawing.Point(160, 3);
            this.lblVssChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssChevRight.Name = "lblVssChevRight";
            this.lblVssChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblVssChevRight.TabIndex = 28;
            this.lblVssChevRight.Text = ".";
            this.lblVssChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClearVssBackup
            // 
            this.cbxClearVssBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssBackup.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearVssBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearVssBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssBackup.Enabled = false;
            this.cbxClearVssBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxClearVssBackup.Location = new System.Drawing.Point(190, 4);
            this.cbxClearVssBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearVssBackup.Name = "cbxClearVssBackup";
            this.cbxClearVssBackup.Size = new System.Drawing.Size(210, 21);
            this.cbxClearVssBackup.TabIndex = 11;
            this.cbxClearVssBackup.Text = "Clear VSS Backup Region";
            // 
            // cbxClearVssRegion
            // 
            this.cbxClearVssRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssRegion.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearVssRegion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssRegion.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssRegion.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearVssRegion.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssRegion.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssRegion.ForeColor = System.Drawing.Color.White;
            this.cbxClearVssRegion.Location = new System.Drawing.Point(11, 4);
            this.cbxClearVssRegion.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearVssRegion.Name = "cbxClearVssRegion";
            this.cbxClearVssRegion.Size = new System.Drawing.Size(149, 21);
            this.cbxClearVssRegion.TabIndex = 10;
            this.cbxClearVssRegion.Text = "Clear VSS Region";
            this.cbxClearVssRegion.CheckedChanged += new System.EventHandler(this.cbxClearVssRegion_CheckedChanged);
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNvramText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNvramText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNvramText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblNvramText.Location = new System.Drawing.Point(0, 192);
            this.lblNvramText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNvramText.Name = "lblNvramText";
            this.lblNvramText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblNvramText.Size = new System.Drawing.Size(400, 34);
            this.lblNvramText.TabIndex = 22;
            this.lblNvramText.Text = "NVRAM";
            this.lblNvramText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 66);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(400, 34);
            this.lblSerialText.TabIndex = 21;
            this.lblSerialText.Text = "Serial Number";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialA
            // 
            this.tlpSerialA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSerialA.ColumnCount = 1;
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSerialA.Controls.Add(this.cmdReplaceSerial, 0, 0);
            this.tlpSerialA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialA.Location = new System.Drawing.Point(0, 101);
            this.tlpSerialA.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialA.Name = "tlpSerialA";
            this.tlpSerialA.RowCount = 1;
            this.tlpSerialA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.Size = new System.Drawing.Size(400, 30);
            this.tlpSerialA.TabIndex = 2;
            // 
            // cmdReplaceSerial
            // 
            this.cmdReplaceSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdReplaceSerial.BackColor = System.Drawing.Color.Transparent;
            this.cmdReplaceSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cmdReplaceSerial.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmdReplaceSerial.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cmdReplaceSerial.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cmdReplaceSerial.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmdReplaceSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReplaceSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdReplaceSerial.Location = new System.Drawing.Point(11, 4);
            this.cmdReplaceSerial.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cmdReplaceSerial.Name = "cmdReplaceSerial";
            this.cmdReplaceSerial.Size = new System.Drawing.Size(241, 21);
            this.cmdReplaceSerial.TabIndex = 3;
            this.cmdReplaceSerial.Text = "Replace Serial Number";
            this.cmdReplaceSerial.CheckedChanged += new System.EventHandler(this.cmdReplaceSerial_CheckedChanged);
            // 
            // tlpFsys
            // 
            this.tlpFsys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpFsys.ColumnCount = 2;
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpFsys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFsys.Controls.Add(this.cbxReplaceFsysRgn, 0, 0);
            this.tlpFsys.Controls.Add(this.cmdFsysPath, 1, 0);
            this.tlpFsys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFsys.Location = new System.Drawing.Point(0, 35);
            this.tlpFsys.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsys.Name = "tlpFsys";
            this.tlpFsys.RowCount = 1;
            this.tlpFsys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsys.Size = new System.Drawing.Size(400, 30);
            this.tlpFsys.TabIndex = 1;
            // 
            // cbxReplaceFsysRgn
            // 
            this.cbxReplaceFsysRgn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxReplaceFsysRgn.BackColor = System.Drawing.Color.Transparent;
            this.cbxReplaceFsysRgn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxReplaceFsysRgn.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxReplaceFsysRgn.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxReplaceFsysRgn.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxReplaceFsysRgn.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxReplaceFsysRgn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReplaceFsysRgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxReplaceFsysRgn.Location = new System.Drawing.Point(11, 4);
            this.cbxReplaceFsysRgn.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxReplaceFsysRgn.Name = "cbxReplaceFsysRgn";
            this.cbxReplaceFsysRgn.Size = new System.Drawing.Size(257, 21);
            this.cbxReplaceFsysRgn.TabIndex = 1;
            this.cbxReplaceFsysRgn.Text = "Replace Fsys region with donor";
            this.cbxReplaceFsysRgn.CheckedChanged += new System.EventHandler(this.cbxReplaceFsysRgn_CheckedChanged);
            // 
            // cmdFsysPath
            // 
            this.cmdFsysPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdFsysPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFsysPath.Enabled = false;
            this.cmdFsysPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdFsysPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFsysPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFsysPath.ForeColor = System.Drawing.Color.White;
            this.cmdFsysPath.Location = new System.Drawing.Point(346, 0);
            this.cmdFsysPath.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFsysPath.Name = "cmdFsysPath";
            this.cmdFsysPath.Size = new System.Drawing.Size(54, 30);
            this.cmdFsysPath.TabIndex = 2;
            this.cmdFsysPath.Text = "...";
            this.cmdFsysPath.UseVisualStyleBackColor = false;
            this.cmdFsysPath.Click += new System.EventHandler(this.cmdFsysPath_Click);
            // 
            // lblFsysText
            // 
            this.lblFsysText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFsysText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysText.Location = new System.Drawing.Point(0, 0);
            this.lblFsysText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysText.Name = "lblFsysText";
            this.lblFsysText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysText.Size = new System.Drawing.Size(400, 34);
            this.lblFsysText.TabIndex = 1;
            this.lblFsysText.Text = "Fsys Region";
            this.lblFsysText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialB
            // 
            this.tlpSerialB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSerialB.ColumnCount = 4;
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Controls.Add(this.lblHwcText, 2, 0);
            this.tlpSerialB.Controls.Add(this.lblSsnText, 0, 0);
            this.tlpSerialB.Controls.Add(this.tbxSerialNumber, 1, 0);
            this.tlpSerialB.Controls.Add(this.tbxHwc, 3, 0);
            this.tlpSerialB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialB.Enabled = false;
            this.tlpSerialB.Location = new System.Drawing.Point(0, 131);
            this.tlpSerialB.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialB.Name = "tlpSerialB";
            this.tlpSerialB.RowCount = 1;
            this.tlpSerialB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Size = new System.Drawing.Size(400, 30);
            this.tlpSerialB.TabIndex = 3;
            // 
            // lblHwcText
            // 
            this.lblHwcText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHwcText.AutoSize = true;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(255, 5);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Size = new System.Drawing.Size(47, 20);
            this.lblHwcText.TabIndex = 21;
            this.lblHwcText.Text = "HWC:";
            // 
            // lblSsnText
            // 
            this.lblSsnText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSsnText.AutoSize = true;
            this.lblSsnText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSsnText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSsnText.Location = new System.Drawing.Point(9, 5);
            this.lblSsnText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblSsnText.Name = "lblSsnText";
            this.lblSsnText.Size = new System.Drawing.Size(41, 20);
            this.lblSsnText.TabIndex = 18;
            this.lblSsnText.Text = "SSN:";
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSerialNumber.ForeColor = System.Drawing.Color.White;
            this.tbxSerialNumber.Location = new System.Drawing.Point(55, 1);
            this.tbxSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSerialNumber.MaxLength = 12;
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(188, 27);
            this.tbxSerialNumber.TabIndex = 4;
            this.tbxSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSerialNumber.TextChanged += new System.EventHandler(this.tbxSerialNumber_TextChanged);
            // 
            // tbxHwc
            // 
            this.tbxHwc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxHwc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHwc.ForeColor = System.Drawing.Color.White;
            this.tbxHwc.Location = new System.Drawing.Point(305, 1);
            this.tbxHwc.Margin = new System.Windows.Forms.Padding(0);
            this.tbxHwc.MaxLength = 4;
            this.tbxHwc.Name = "tbxHwc";
            this.tbxHwc.ReadOnly = true;
            this.tbxHwc.Size = new System.Drawing.Size(78, 27);
            this.tbxHwc.TabIndex = 5;
            this.tbxHwc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpSerialC
            // 
            this.tlpSerialC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSerialC.ColumnCount = 2;
            this.tlpSerialC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpSerialC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialC.Controls.Add(this.cbxMaskFsysCrc, 0, 0);
            this.tlpSerialC.Controls.Add(this.cbxOverwriteHwc, 1, 0);
            this.tlpSerialC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialC.Enabled = false;
            this.tlpSerialC.Location = new System.Drawing.Point(0, 161);
            this.tlpSerialC.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialC.Name = "tlpSerialC";
            this.tlpSerialC.RowCount = 1;
            this.tlpSerialC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialC.Size = new System.Drawing.Size(400, 30);
            this.tlpSerialC.TabIndex = 4;
            // 
            // cbxMaskFsysCrc
            // 
            this.cbxMaskFsysCrc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxMaskFsysCrc.BackColor = System.Drawing.Color.Transparent;
            this.cbxMaskFsysCrc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxMaskFsysCrc.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxMaskFsysCrc.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxMaskFsysCrc.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxMaskFsysCrc.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxMaskFsysCrc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaskFsysCrc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxMaskFsysCrc.Location = new System.Drawing.Point(11, 4);
            this.cbxMaskFsysCrc.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxMaskFsysCrc.Name = "cbxMaskFsysCrc";
            this.cbxMaskFsysCrc.Size = new System.Drawing.Size(153, 21);
            this.cbxMaskFsysCrc.TabIndex = 6;
            this.cbxMaskFsysCrc.Text = "Mask Fsys CRC32\r\n";
            // 
            // cbxOverwriteHwc
            // 
            this.cbxOverwriteHwc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxOverwriteHwc.BackColor = System.Drawing.Color.Transparent;
            this.cbxOverwriteHwc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxOverwriteHwc.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxOverwriteHwc.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxOverwriteHwc.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxOverwriteHwc.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxOverwriteHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOverwriteHwc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxOverwriteHwc.Location = new System.Drawing.Point(170, 4);
            this.cbxOverwriteHwc.Margin = new System.Windows.Forms.Padding(0);
            this.cbxOverwriteHwc.Name = "cbxOverwriteHwc";
            this.cbxOverwriteHwc.Size = new System.Drawing.Size(230, 21);
            this.cbxOverwriteHwc.TabIndex = 7;
            this.cbxOverwriteHwc.Text = "Overwrite HWC";
            // 
            // tlpSvsOptions
            // 
            this.tlpSvsOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSvsOptions.ColumnCount = 3;
            this.tlpSvsOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpSvsOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSvsOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvsOptions.Controls.Add(this.cbxClearSvsRegion, 0, 0);
            this.tlpSvsOptions.Controls.Add(this.cbxClearSvsBackup, 2, 0);
            this.tlpSvsOptions.Controls.Add(this.lblSvsChevRight, 1, 0);
            this.tlpSvsOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSvsOptions.Location = new System.Drawing.Point(0, 227);
            this.tlpSvsOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSvsOptions.Name = "tlpSvsOptions";
            this.tlpSvsOptions.RowCount = 1;
            this.tlpSvsOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvsOptions.Size = new System.Drawing.Size(400, 30);
            this.tlpSvsOptions.TabIndex = 5;
            // 
            // cbxClearSvsRegion
            // 
            this.cbxClearSvsRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsRegion.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearSvsRegion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsRegion.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsRegion.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearSvsRegion.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsRegion.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsRegion.ForeColor = System.Drawing.Color.White;
            this.cbxClearSvsRegion.Location = new System.Drawing.Point(11, 4);
            this.cbxClearSvsRegion.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearSvsRegion.Name = "cbxClearSvsRegion";
            this.cbxClearSvsRegion.Size = new System.Drawing.Size(149, 21);
            this.cbxClearSvsRegion.TabIndex = 8;
            this.cbxClearSvsRegion.Text = "Clear SVS Region";
            this.cbxClearSvsRegion.CheckedChanged += new System.EventHandler(this.cbxClearSvsRegion_CheckedChanged);
            // 
            // cbxClearSvsBackup
            // 
            this.cbxClearSvsBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsBackup.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearSvsBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearSvsBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsBackup.Enabled = false;
            this.cbxClearSvsBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxClearSvsBackup.Location = new System.Drawing.Point(190, 4);
            this.cbxClearSvsBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearSvsBackup.Name = "cbxClearSvsBackup";
            this.cbxClearSvsBackup.Size = new System.Drawing.Size(210, 21);
            this.cbxClearSvsBackup.TabIndex = 9;
            this.cbxClearSvsBackup.Text = "Clear SVS Backup Region";
            // 
            // lblSvsChevRight
            // 
            this.lblSvsChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSvsChevRight.AutoSize = true;
            this.lblSvsChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsChevRight.ForeColor = System.Drawing.Color.White;
            this.lblSvsChevRight.Location = new System.Drawing.Point(160, 3);
            this.lblSvsChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsChevRight.Name = "lblSvsChevRight";
            this.lblSvsChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblSvsChevRight.TabIndex = 27;
            this.lblSvsChevRight.Text = ".";
            this.lblSvsChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.Controls.Add(this.pnlLog, 0, 2);
            this.tlpLog.Controls.Add(this.tlpOutput, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(401, 0);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 4;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.Size = new System.Drawing.Size(547, 436);
            this.tlpLog.TabIndex = 2;
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlLog.Controls.Add(this.rtbLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(0, 35);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(4);
            this.pnlLog.Size = new System.Drawing.Size(547, 400);
            this.pnlLog.TabIndex = 3;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(4, 4);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(539, 392);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            // 
            // tlpOutput
            // 
            this.tlpOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpOutput.ColumnCount = 2;
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpOutput.Controls.Add(this.lnkUrls, 1, 0);
            this.tlpOutput.Controls.Add(this.lblOutputText, 0, 0);
            this.tlpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOutput.Location = new System.Drawing.Point(0, 0);
            this.tlpOutput.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOutput.Name = "tlpOutput";
            this.tlpOutput.RowCount = 1;
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.Size = new System.Drawing.Size(547, 34);
            this.tlpOutput.TabIndex = 4;
            // 
            // lnkUrls
            // 
            this.lnkUrls.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkUrls.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkUrls.AutoSize = true;
            this.lnkUrls.BackColor = System.Drawing.Color.Transparent;
            this.lnkUrls.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUrls.ForeColor = System.Drawing.Color.White;
            this.lnkUrls.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkUrls.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUrls.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.lnkUrls.Location = new System.Drawing.Point(456, 7);
            this.lnkUrls.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lnkUrls.Name = "lnkUrls";
            this.lnkUrls.Size = new System.Drawing.Size(88, 20);
            this.lnkUrls.TabIndex = 11;
            this.lnkUrls.Text = "Save · Clear";
            this.lnkUrls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutputText
            // 
            this.lblOutputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOutputText.Location = new System.Drawing.Point(0, 0);
            this.lblOutputText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOutputText.Name = "lblOutputText";
            this.lblOutputText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOutputText.Size = new System.Drawing.Size(407, 34);
            this.lblOutputText.TabIndex = 2;
            this.lblOutputText.Text = "Output";
            this.lblOutputText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tlpTitle.Size = new System.Drawing.Size(948, 40);
            this.tlpTitle.TabIndex = 0;
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
            this.lblTitle.Size = new System.Drawing.Size(908, 40);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Firmware Editor";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(908, 0);
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
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(948, 2);
            this.pnlSeperator.TabIndex = 97;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.Controls.Add(this.cmdApply, 2, 0);
            this.tlpButtons.Controls.Add(this.cmdCancel, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 479);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(948, 50);
            this.tlpButtons.TabIndex = 7;
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ForeColor = System.Drawing.Color.White;
            this.cmdApply.Location = new System.Drawing.Point(838, 8);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(0);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(100, 34);
            this.cmdApply.TabIndex = 13;
            this.cmdApply.Text = "Export";
            this.cmdApply.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.White;
            this.cmdCancel.Location = new System.Drawing.Point(728, 8);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 34);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // editorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(950, 530);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 530);
            this.Name = "editorWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmware Editor";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpVssOptions.ResumeLayout(false);
            this.tlpVssOptions.PerformLayout();
            this.tlpSerialA.ResumeLayout(false);
            this.tlpFsys.ResumeLayout(false);
            this.tlpSerialB.ResumeLayout(false);
            this.tlpSerialB.PerformLayout();
            this.tlpSerialC.ResumeLayout(false);
            this.tlpSvsOptions.ResumeLayout(false);
            this.tlpSvsOptions.PerformLayout();
            this.tlpLog.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.tlpOutput.ResumeLayout(false);
            this.tlpOutput.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Panel pnlSeperator;
        private UI.METCheckbox cbxOverwriteHwc;
        private System.Windows.Forms.TextBox tbxHwc;
        private UI.METCheckbox cbxMaskFsysCrc;
        private UI.METCheckbox cbxClearVssRegion;
        private UI.METCheckbox cbxClearSvsRegion;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.Button cmdFsysPath;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
        private UI.METCheckbox cbxClearVssBackup;
        private UI.METCheckbox cbxClearSvsBackup;
        private System.Windows.Forms.Label lblSsnText;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.Label lblFsysText;
        private System.Windows.Forms.TableLayoutPanel tlpFsys;
        private System.Windows.Forms.TableLayoutPanel tlpSerialA;
        private System.Windows.Forms.TableLayoutPanel tlpSerialB;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.TableLayoutPanel tlpSerialC;
        private System.Windows.Forms.Label lblNvramText;
        private System.Windows.Forms.TableLayoutPanel tlpVssOptions;
        private System.Windows.Forms.TableLayoutPanel tlpSvsOptions;
        private UI.METCheckbox cmdReplaceSerial;
        private UI.METCheckbox cbxReplaceFsysRgn;
        private System.Windows.Forms.Label lblSvsChevRight;
        private System.Windows.Forms.Label lblVssChevRight;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lblOutputText;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.TableLayoutPanel tlpOutput;
        internal System.Windows.Forms.LinkLabel lnkUrls;
    }
}