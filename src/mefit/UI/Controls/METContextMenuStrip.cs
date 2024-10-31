// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METContextMenuStrip.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI.Renderers;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    internal class METContextMenuStrip : ContextMenuStrip
    {
        public METContextMenuStrip()
        {
            Renderer = new METMenuRenderer();
            BackColor = Color.FromArgb(20, 20, 20);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            ShowImageMargin = false;
        }
    }
}