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
            if (!Settings.SettingsGetBool(SettingsBoolType.DisableFlashingUI))
            {
                Color originalColor = control.ForeColor;
                for (int i = 0; i < 3; i++)
                {
                    control.ForeColor = Color.FromArgb(control.ForeColor.A, 130, 130, 130);
                    await Task.Delay(70);
                    control.ForeColor = originalColor;
                    await Task.Delay(70);
                }
            }
        }

        internal static void SetTableLayoutPanelHeight(TableLayoutPanel control)
        {
            int totalHeight = 0;

            for (int i = 0; i < control.RowStyles.Count - 1; i++)
            {
                RowStyle rowStyle = control.RowStyles[i];
                totalHeight += (int)rowStyle.Height;
            }

            control.Height = totalHeight;
        }
    }
}