﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METPrompt.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.Forms;
using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    public partial class METPrompt : FormEx
    {
        #region Enums
        public enum PType
        {
            Error,
            Warning,
            Information,
            Question
        }

        public enum PButtons
        {
            Okay,
            YesNo
        }
        #endregion

        #region Public Members
        public static SystemSound PromptSound;
        public static string PromptMessage;
        public static PType PromptType;
        public static PButtons PromptButtons;
        public static DialogResult PromptResult;
        #endregion

        #region Constants
        private const int MAX_WIDTH = 350;
        private const int MAX_HEIGHT = 800;
        private const int PADDING_WIDTH = 20;
        private const int PADDING_HEIGHT = 60;
        private const string INFO_STRING = "INFORMATION";
        private const string WARN_STRING = "WARNING";
        private const string ERROR_STRING = "ERROR";
        #endregion

        #region Constructor
        public METPrompt()
        {
            InitializeComponent();

            // Attach event handlers.
            WireEventHandlers();

            // Enable drag.
            WindowManager.EnableFormDrag(this, lblTitle);
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            // Set title and color based on the message type.
            switch (PromptType)
            {
                case PType.Error:
                    lblTitle.ForeColor = ApplicationColors.Error;
                    lblTitle.Text = ERROR_STRING;
                    PromptSound = System.Media.SystemSounds.Hand;
                    break;
                case PType.Warning:
                    lblTitle.ForeColor = ApplicationColors.Warning;
                    lblTitle.Text = WARN_STRING;
                    PromptSound = System.Media.SystemSounds.Exclamation;
                    break;
                case PType.Information:
                    lblTitle.ForeColor = ApplicationColors.Information;
                    lblTitle.Text = INFO_STRING;
                    PromptSound = System.Media.SystemSounds.Beep;
                    break;
                case PType.Question:
                    lblTitle.ForeColor = ApplicationColors.Information;
                    lblTitle.Text = INFO_STRING;
                    PromptSound = System.Media.SystemSounds.Beep;
                    break;
            }

            lblMessage.Text = PromptMessage;

            if (PromptButtons == PButtons.Okay)
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
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableMessageSounds))
            {
                PromptSound.Play();
            }

            FlashForecolor(lblTitle);
        }
        #endregion

        #region User Interface
        public static DialogResult Show(Form owner, string message, PType type, PButtons buttons = PButtons.Okay)
        {
            SetMessageBoxParameters(message, type, buttons);

            using (METPrompt prompt = new METPrompt())
            {
                prompt.StartPosition = owner == null
                    ? FormStartPosition.CenterScreen
                    : FormStartPosition.CenterParent;

                DialogResult dlgResult = prompt.ShowDialog(owner);

                return PromptResult;
            }
        }

        private void AdjustFormSize()
        {
            lblMessage.MaximumSize = new Size(MAX_WIDTH, MAX_HEIGHT);
            lblMessage.AutoSize = true;

            tlpMain.AutoSize = true;
            tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Size preferredSize = lblMessage.PreferredSize;
            int idealWidth = Math.Min(preferredSize.Width, MAX_WIDTH);
            int idealHeight = Math.Min(preferredSize.Height, MAX_HEIGHT);

            this.ClientSize = new Size(idealWidth + PADDING_WIDTH, idealHeight + PADDING_HEIGHT);

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
            PromptResult = PromptButtons == PButtons.Okay ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Private Events
        private void WireEventHandlers()
        {
            Load += new EventHandler(METMessageBox_Load);
            Shown += new EventHandler(METMessageBox_Shown);
            KeyDown += new KeyEventHandler(METMessageBox_KeyDown);
        }

        private static void SetMessageBoxParameters(string message, PType type, PButtons buttons)
        {
            PromptMessage = message;
            PromptType = type;
            PromptButtons = buttons;
        }

        private static async void FlashForecolor(Control control)
        {
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableFlashingUI))
            {
                Color original = control.ForeColor;
                Int32 msDelay = 70;

                for (int i = 0; i < 6; i++)
                {
                    control.ForeColor = Color.FromArgb(100, 100, 100);
                    await Task.Delay(msDelay);
                    control.ForeColor = original;
                    await Task.Delay(msDelay);
                }
            }
        }
        #endregion
    }
}