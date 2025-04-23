// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METContextMenuStrip.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI.Renderers;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI.Controls
{
    internal class METContextMenuStrip : ContextMenuStrip
    {
        private Color _bcDefault = Color.FromArgb(20, 20, 20);
        private Color _fcDefault = Color.White;
        private string _fontName = "Segoe UI";

        #region Constructor
        public METContextMenuStrip()
        {
            Renderer = new METMenuRenderer();
            BackColor = _bcDefault;
            ForeColor = _fcDefault;
            Font = new Font(_fontName, 10.2f, FontStyle.Regular);
            ShowImageMargin = false;
        }
        #endregion
    }
}