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

    #region Enums
    public enum MsgType
    {
        Critical, Warning, Information, Question
    }

    public enum MsgButton
    {
        Okay, YesNoCancel
    }
    #endregion

    public partial class METMessageBox : Form
    {

        #region Static Members
        static string strMmbTitle;
        static string strMmbMessage;
        static MsgType mtMmbType;
        static MsgButton mbMmbButton;
        static DialogResult drMmbResult;
        static System.Media.SystemSound ssMmbSound;
        #endregion

        #region Overrides
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams crParams = base.CreateParams;
                crParams.ClassStyle = crParams.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
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

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.closeChar;
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            lblMessageIcon.Font = Program.FONT_MDL2_REG_20;

            switch (mtMmbType)
            {
                case MsgType.Critical:
                    lblMessageIcon.ForeColor = Colours.clrError;
                    lblMessageIcon.Text = "\xEB90";
                    ssMmbSound = System.Media.SystemSounds.Hand;
                    break;
                case MsgType.Warning:
                    lblMessageIcon.ForeColor = Colours.clrWarn;
                    lblMessageIcon.Text = "\xE7BA";
                    ssMmbSound = System.Media.SystemSounds.Exclamation;
                    break;
                case MsgType.Information:
                    lblMessageIcon.ForeColor = Colours.clrInfo;
                    lblMessageIcon.Text = "\xF167";
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
                case MsgType.Question:
                    lblMessageIcon.ForeColor = Colours.clrInfo;
                    lblMessageIcon.Text = "\xE9CE";
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
            }

            lblTitle.Text = strMmbTitle;
            lblMessage.Text = strMmbMessage;

            if (mbMmbButton == MsgButton.Okay)
            {
                cmdNo.Hide();
                cmdYes.Hide();
            }
            else
            {
                cmdCancel.Text = "Cancel";
            }

        }

        private void METMessageBox_Shown(object sender, EventArgs e)
        {
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableMessageSounds))
            {
                ssMmbSound.Play();
            }

            InterfaceUtils.FlashForecolor(lblTitle);
            InterfaceUtils.FlashForecolor(cmdClose);
        }
        #endregion

        #region Mouse Events
        private void metMessage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region Overriden Events
        public static DialogResult Show(Form owner, string title, string message, MsgType type, MsgButton buttons = MsgButton.Okay)
        {

            strMmbTitle = title;
            strMmbMessage = message;
            mtMmbType = type;
            mbMmbButton = buttons;

            using (var msgForm = new METMessageBox())
            {
                if (owner == null)
                {
                    msgForm.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    msgForm.StartPosition = FormStartPosition.CenterParent;
                }
                msgForm.ShowDialog(owner);
            }
            return drMmbResult;
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (mbMmbButton == MsgButton.Okay)
            {
                drMmbResult = DialogResult.OK;
            }
            else
            {
                drMmbResult = DialogResult.Cancel;
            }
            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            drMmbResult = DialogResult.Yes;
            Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            drMmbResult = DialogResult.No;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            drMmbResult = DialogResult.Cancel;
            Close();
        }
        #endregion

    }
}