// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METMessageBox.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Threading.Tasks;
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

        #region Contructor
        public METMessageBox()
        {
            InitializeComponent();
            Load += new EventHandler(METMessageBox_Load);
            Shown += new EventHandler(METMessageBox_Shown);
        }
        #endregion

        #region Load Events
        private void METMessageBox_Load(object sender, EventArgs e)
        {
            labIcon.Font = Program.FONT_MDL2_REG_20;

            switch (mtMmbType)
            {
                case MsgType.Critical:
                    labIcon.ForeColor = Colours.clrError;
                    labIcon.Text = "\xEB90";
                    ssMmbSound = System.Media.SystemSounds.Hand;
                    break;
                case MsgType.Warning:
                    labIcon.ForeColor = Colours.clrUnknown;
                    labIcon.Text = "\xE7BA";
                    ssMmbSound = System.Media.SystemSounds.Exclamation;
                    break;
                case MsgType.Information:
                    labIcon.ForeColor = Colours.clrInfo;
                    labIcon.Text = "\xF167";
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
                case MsgType.Question:
                    labIcon.ForeColor = Colours.clrInfo;
                    labIcon.Text = "\xE9CE";
                    ssMmbSound = System.Media.SystemSounds.Beep;
                    break;
            }

            labTitle.Text = strMmbTitle;
            labMessage.Text = strMmbMessage;

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
            ssMmbSound.Play();
            InterfaceUtils.FlashForecolor(labTitle); // "this" is the current form instance
            InterfaceUtils.FlashForecolor(cmdClose);
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
            drMmbResult = DialogResult.Cancel;
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