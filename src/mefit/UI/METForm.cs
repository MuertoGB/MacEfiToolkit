// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METForm.cs
// Released under the GNU GLP v3.0

using System.Windows.Forms;

public class METForm : Form
{
    internal const int WS_MINIMIZEBOX = 0x20000;
    internal const int CS_DBLCLKS = 0x8;
    internal const int CS_DROP = 0x20000;

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
}