// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METMessageBox.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    public partial class METMessageBox : Form
    {

        #region Static Members
        static System.Media.SystemSound MB_SOUND;
        static string MB_MESSAGE;

        static METMessageBoxType MB_TYPE;
        static METMessageBoxButtons MB_BUTTONS;
        static DialogResult MB_RESULT;
        #endregion

        #region Overrides
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams crParams = base.CreateParams;

                crParams.ClassStyle = crParams.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return crParams;
            }
        }
        #endregion

        #region Contructor
        public METMessageBox()
        {
            InitializeComponent();

            lblTitle.MouseMove += metMessage_MouseMove;

            Load += new EventHandler(METMessageBox_Load);
            Shown += new EventHandler(METMessageBox_Shown);
            KeyDown += new KeyEventHandler(METMessageBox_KeyDown);
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            switch (MB_TYPE)
            {
                case METMessageBoxType.Error:
                    lblTitle.ForeColor = Colours.ERROR_BOX;
                    lblTitle.Text = AppStrings.AS_ERROR;
                    MB_SOUND = System.Media.SystemSounds.Hand;
                    break;
                case METMessageBoxType.Warning:
                    lblTitle.ForeColor = Colours.WARNING_BOX;
                    lblTitle.Text = AppStrings.AS_WARNING;
                    MB_SOUND = System.Media.SystemSounds.Exclamation;
                    break;
                case METMessageBoxType.Information:
                    lblTitle.ForeColor = Colours.INFO_BOX;
                    lblTitle.Text = AppStrings.AS_INFO;
                    MB_SOUND = System.Media.SystemSounds.Beep;
                    break;
                case METMessageBoxType.Question:
                    lblTitle.ForeColor = Colours.INFO_BOX;
                    lblTitle.Text = AppStrings.AS_INFO;
                    MB_SOUND = System.Media.SystemSounds.Beep;
                    break;
            }

            lblMessage.Text = MB_MESSAGE;

            if (MB_BUTTONS == METMessageBoxButtons.Okay)
            {
                cmdYes.Hide();
                cmdNo.Text = "OKAY";
            }
            if (MB_BUTTONS != METMessageBoxButtons.Okay)
            {
                cmdYes.Show();
                cmdNo.Show();
                cmdNo.Text = "NO";
            }
        }

        private void METMessageBox_Shown(object sender, EventArgs e)
        {
            if (!Settings.ReadBool(SettingsBoolType.DisableMessageSounds))
                MB_SOUND.Play();

            UITools.FlashForecolor(lblTitle);
        }
        #endregion

        #region KeyDown Events
        private void METMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MB_RESULT = DialogResult.Cancel;
                Close();
            }
        }
        #endregion

        #region Mouse Events
        private void metMessage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }
        #endregion

        #region Overriden Events
        public static DialogResult Show(
            Form owner,
            string message,
            METMessageBoxType type,
            METMessageBoxButtons buttons = METMessageBoxButtons.Okay)
        {
            MB_MESSAGE = message;
            MB_TYPE = type;
            MB_BUTTONS = buttons;

            using (METMessageBox messageBox = new METMessageBox())
            {
                if (owner == null)
                {
                    messageBox.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    messageBox.StartPosition = FormStartPosition.CenterParent;
                }

                messageBox.ShowDialog(owner);
            }

            return MB_RESULT;
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            MB_RESULT =
                DialogResult.Cancel;

            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            MB_RESULT =
                DialogResult.Yes;

            Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            if (MB_BUTTONS == METMessageBoxButtons.Okay)
            {
                MB_RESULT =
                    DialogResult.OK;
            }
            else
            {
                MB_RESULT =
                    DialogResult.Cancel;
            }

            Close();
        }
        #endregion

    }
}