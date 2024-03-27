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
        static string strTitle;
        static string strMessage;
        static METMessageBoxType messageBoxType;
        static METMessageBoxButtons messageBoxButtons;
        static DialogResult dialogResult;
        static System.Media.SystemSound ssMmbSound;
        #endregion

        #region Private Members
        private const string STATUS_ERROR_FULL = "\uEB90";
        private const string INCIDENT_TRIANGLE = "\uE814";
        private const string INFO_SOLID = "\uF167";
        private const string UNKNOWN = "\uE9CE";
        private const string EXIT_CROSS = "\uE947";
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

            lblMessageIcon.Font = Program.FONT_MDL2_REG_20;
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            switch (messageBoxType)
            {
                case METMessageBoxType.Error:
                    lblMessageIcon.ForeColor = Colours.ERROR_BOX;
                    lblMessageIcon.Text = STATUS_ERROR_FULL;
                    ssMmbSound = System.Media.SystemSounds.Hand;
                    break;
                case METMessageBoxType.Warning:
                    lblMessageIcon.ForeColor = Colours.WARNING_BOX;
                    lblMessageIcon.Text = INCIDENT_TRIANGLE;
                    ssMmbSound = System.Media.SystemSounds.Exclamation;
                    break;
                case METMessageBoxType.Information:
                    lblMessageIcon.ForeColor = Colours.INFO_BOX;
                    lblMessageIcon.Text = INFO_SOLID;
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
                case METMessageBoxType.Question:
                    lblMessageIcon.ForeColor = Colours.INFO_BOX;
                    lblMessageIcon.Text = UNKNOWN;
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
            }

            lblTitle.Text = strTitle;
            lblMessage.Text = strMessage;

            if (messageBoxButtons == METMessageBoxButtons.Okay)
            {
                cmdYes.Hide();
                cmdNo.Text = "Okay";
            }
            if (messageBoxButtons != METMessageBoxButtons.Okay)
            {
                cmdYes.Show();
                cmdNo.Show();
                cmdNo.Text = "No";
            }
        }

        private void METMessageBox_Shown(object sender, EventArgs e)
        {
            if (!Settings.ReadBool(SettingsBoolType.DisableMessageSounds))
                ssMmbSound.Play();

            InterfaceUtils.FlashForecolor(lblTitle);
            InterfaceUtils.FlashForecolor(cmdClose);
        }
        #endregion

        #region KeyDown Events
        private void METMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
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
            string title,
            string message,
            METMessageBoxType type,
            METMessageBoxButtons buttons = METMessageBoxButtons.Okay)
        {
            strTitle = title;
            strMessage = message;
            messageBoxType = type;
            messageBoxButtons = buttons;

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

            return dialogResult;
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            dialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            dialogResult =
                DialogResult.Yes;

            Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            if (messageBoxButtons == METMessageBoxButtons.Okay)
            {
                dialogResult =
                    DialogResult.OK;
            }
            else
            {
                dialogResult =
                    DialogResult.Cancel;
            }

            Close();
        }
        #endregion

    }
}