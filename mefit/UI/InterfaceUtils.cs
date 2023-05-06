// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// InterfaceUtils.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    class InterfaceUtils
    {
        internal static async void FlashForecolor(Control control)
        {
            Color originalColor = control.ForeColor;
            for (int i = 0; i < 6; i++)
            {
                control.ForeColor = Color.FromArgb(control.ForeColor.A, 60, 60, 60);
                await Task.Delay(80);
                control.ForeColor = originalColor;
                await Task.Delay(80);
            }
        }
    }
}