using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
                control.ForeColor = Color.FromArgb(control.ForeColor.A, 80, 80, 80);
                await Task.Delay(80);
                control.ForeColor = originalColor;
                await Task.Delay(80);
            }
        }
    }
}
