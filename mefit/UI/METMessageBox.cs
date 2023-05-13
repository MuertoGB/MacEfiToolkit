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
        static string boxTitle;
        static string boxMessage;
        static System.Media.SystemSound boxSound;
        static MsgType boxType;
        static MsgButton boxButtons;
        static DialogResult boxResult;
        #endregion

        #region Private Colours
        private readonly Color clrCrit = Color.FromArgb(255, 50, 50);
        private readonly Color clrWarn = Color.FromArgb(255, 100, 70);
        private readonly Color clrInfo = Color.FromArgb(0, 120, 180);
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

            switch (boxType)
            {
                case MsgType.Critical:
                    labIcon.ForeColor = clrCrit;
                    labIcon.Text = "\xEB90";
                    boxSound = System.Media.SystemSounds.Hand;
                    break;
                case MsgType.Warning:
                    labIcon.ForeColor = clrWarn;
                    labIcon.Text = "\xE7BA";
                    boxSound = System.Media.SystemSounds.Exclamation;
                    break;
                case MsgType.Information:
                    labIcon.ForeColor = clrInfo;
                    labIcon.Text = "\xF167";
                    boxSound = System.Media.SystemSounds.Beep;
                    break;
                case MsgType.Question:
                    labIcon.ForeColor = clrInfo;
                    labIcon.Text = "\xE9CE";
                    boxSound = System.Media.SystemSounds.Beep;
                    break;
            }

            labTitle.Text = boxTitle;
            labMessage.Text = boxMessage;

            if (boxButtons == MsgButton.Okay)
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
            boxSound.Play();
            InterfaceUtils.FlashForecolor(labTitle); // "this" is the current form instance
            InterfaceUtils.FlashForecolor(cmdClose);
        }
        #endregion

        #region Overriden Events
        public static DialogResult Show(Form owner, string title, string message, MsgType type, MsgButton buttons = MsgButton.Okay)
        {

            boxTitle = title;
            boxMessage = message;
            boxType = type;
            boxButtons = buttons;

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
            return boxResult;
        }
        #endregion

        #region Button Events
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            boxResult = DialogResult.Cancel;
            Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            boxResult = DialogResult.Yes;
            Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            boxResult = DialogResult.No;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            boxResult = DialogResult.Cancel;
            Close();
        }
        #endregion

    }
}