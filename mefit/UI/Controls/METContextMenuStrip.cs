// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METContextMenuStrip.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI.Renderers;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    internal class METContextMenuStrip : ContextMenuStrip
    {
        public METContextMenuStrip() => Renderer = new METMenuRenderer();
    }
}