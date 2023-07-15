using Mac_EFI_Toolkit.UI.Renderers;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    internal class METContextMenuStrip : ContextMenuStrip
    {

        #region Constructor
        public METContextMenuStrip()
        {
            Renderer = new METMenuRenderer();
        }
        #endregion

    }
}