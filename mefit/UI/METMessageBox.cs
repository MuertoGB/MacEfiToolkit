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
    public enum MessageBoxType
    {
        Error, Warning, Information, Question
    }

    public enum MessageBoxButtons
    {
        Okay, YesNoCancel
    }
    #endregion

    public partial class METMessageBox : Form
    {

        #region Static Members
        static string strMmbTitle;
        static string strMmbMessage;
        static MessageBoxType mtMmbType;
        static MessageBoxButtons mbMmbButton;
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
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            lblMessageIcon.Font = Program.FONT_MDL2_REG_20;

            switch (mtMmbType)
            {
                case MessageBoxType.Error:
                    lblMessageIcon.ForeColor = Colours.ERROR_RED;
                    lblMessageIcon.Text = Chars.STATUS_ERROR_FULL;
                    ssMmbSound = System.Media.SystemSounds.Hand;
                    break;
                case MessageBoxType.Warning:
                    lblMessageIcon.ForeColor = Colours.WARNING_ORANGE;
                    lblMessageIcon.Text = Chars.INCIDENT_TRIANGLE;
                    ssMmbSound = System.Media.SystemSounds.Exclamation;
                    break;
                case MessageBoxType.Information:
                    lblMessageIcon.ForeColor = Colours.INFO_BLUE;
                    lblMessageIcon.Text = Chars.INFO_SOLID;
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
                case MessageBoxType.Question:
                    lblMessageIcon.ForeColor = Colours.INFO_BLUE;
                    lblMessageIcon.Text = Chars.UNKNOWN;
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
            }

            lblTitle.Text = strMmbTitle;
            lblMessage.Text = strMmbMessage;

            if (mbMmbButton == MessageBoxButtons.Okay)
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
        public static DialogResult Show(Form owner, string title, string message, MessageBoxType type, MessageBoxButtons buttons = MessageBoxButtons.Okay)
        {
            strMmbTitle = title;
            strMmbMessage = message;
            mtMmbType = type;
            mbMmbButton = buttons;

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
            return drMmbResult;
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (mbMmbButton == MessageBoxButtons.Okay)
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