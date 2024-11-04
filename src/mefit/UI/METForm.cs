// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METForm.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit;
using Mac_EFI_Toolkit.UI;
using System;
using System.Windows.Forms;

public class METForm : Form
{
    #region Internal Members
    internal const int WS_MINIMIZEBOX = 0x20000;
    internal const int CS_DBLCLKS = 0x8;
    internal const int CS_DROP = 0x20000;
    #endregion

    #region Constructor
    public METForm()
    {
        // Wire event handler.
        Load += METForm_Load;
    }
    #endregion

    #region Window Events
    private void METForm_Load(object sender, EventArgs e)
    {
        if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
            BackColor = AccentColorHelper.GetWindowsAccentColor();
    }
    #endregion

    #region Overrides Methods
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams Params = base.CreateParams;

            Params.Style |=
                WS_MINIMIZEBOX;

            Params.ClassStyle =
                Params.ClassStyle |
                CS_DBLCLKS |
                CS_DROP;

            return Params;
        }
    }
    #endregion
}