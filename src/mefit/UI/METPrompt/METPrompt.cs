// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METPrompt.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    public partial class METPrompt : FormEx
    {
        #region Static Members
        static SystemSound PromtSound;
        static string PromptMessage;
        static METPromptType PromptType;
        static METPromptButtons PromptButtons;
        static DialogResult PromptResult;
        #endregion

        #region Private Members
        private const string _strInfo =
            "INFORMATION";

        private const string _strWarning =
            "WARNING";

        private const string _strError =
            "ERROR";
        #endregion

        #region Constants
        private const int MAX_WIDTH = 350;
        private const int MAX_HEIGHT = 800;
        private const int PADDING_WIDTH = 20;
        private const int PADDING_HEIGHT = 60;
        #endregion

        #region Constructor
        public METPrompt()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            UITools.EnableFormDrag(this, lblTitle);
        }

        private void WireEventHandlers()
        {
            Load += new EventHandler(METMessageBox_Load);
            Shown += new EventHandler(METMessageBox_Shown);
            KeyDown += new KeyEventHandler(METMessageBox_KeyDown);
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            // Set title and color based on the message type.
            switch (PromptType)
            {
                case METPromptType.Error:
                    lblTitle.ForeColor = Colours.Error;
                    lblTitle.Text = _strError;
                    PromtSound = System.Media.SystemSounds.Hand;
                    break;
                case METPromptType.Warning:
                    lblTitle.ForeColor = Colours.Warning;
                    lblTitle.Text = _strWarning;
                    PromtSound = System.Media.SystemSounds.Exclamation;
                    break;
                case METPromptType.Information:
                    lblTitle.ForeColor = Colours.Information;
                    lblTitle.Text = _strInfo;
                    PromtSound = System.Media.SystemSounds.Beep;
                    break;
                case METPromptType.Question:
                    lblTitle.ForeColor = Colours.Information;
                    lblTitle.Text = _strInfo;
                    PromtSound = System.Media.SystemSounds.Beep;
                    break;
            }

            lblMessage.Text = PromptMessage;

            if (PromptButtons == METPromptButtons.Okay)
            {
                cmdYes.Hide();
                cmdNo.Text = "OKAY";
            }
            else
            {
                cmdYes.Show();
                cmdNo.Show();
                cmdNo.Text = "NO";
            }

            AdjustFormSize();
        }

        private void METMessageBox_Shown(object sender, EventArgs e)
        {
            if (!Settings.ReadBool(SettingsBoolType.DisableMessageSounds))
            {
                PromtSound.Play();
            }

            UITools.FlashForecolor(lblTitle);
        }
        #endregion

        #region Dynamic Resizing
        private void AdjustFormSize()
        {
            lblMessage.MaximumSize = new Size(MAX_WIDTH, MAX_HEIGHT);
            lblMessage.AutoSize = true;

            tlpMain.AutoSize = true;
            tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Size szPreffered = lblMessage.PreferredSize;
            int nIdealWidth = Math.Min(szPreffered.Width, MAX_WIDTH);
            int nIdealHeight = Math.Min(szPreffered.Height, MAX_HEIGHT);

            this.ClientSize = new Size(nIdealWidth + PADDING_WIDTH, nIdealHeight + PADDING_HEIGHT);

            if (this.Owner != null)
            {
                this.Location = new Point(
                    this.Owner.Location.X + (this.Owner.Width - this.Width) / 2,
                    this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2
                );
            }

            this.MaximumSize = this.Size;
        }
        #endregion

        #region KeyDown Events
        private void METMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PromptResult = DialogResult.Cancel;
                Close();
            }
        }
        #endregion

        #region Overriden Events
        public static DialogResult Show(Form owner, string message, METPromptType type, METPromptButtons buttons = METPromptButtons.Okay)
        {
            SetMessageBoxParameters(message, type, buttons);

            using (METPrompt metPrompt = new METPrompt())
            {
                metPrompt.StartPosition = owner == null
                    ? FormStartPosition.CenterScreen
                    : FormStartPosition.CenterParent;

                DialogResult dlgResult = metPrompt.ShowDialog(owner);

                return PromptResult;
            }
        }

        private static void SetMessageBoxParameters(string message, METPromptType type, METPromptButtons buttons)
        {
            PromptMessage = message;
            PromptType = type;
            PromptButtons = buttons;
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            PromptResult = DialogResult.Cancel;
            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            PromptResult = DialogResult.Yes;
            Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            PromptResult = PromptButtons == METPromptButtons.Okay ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}