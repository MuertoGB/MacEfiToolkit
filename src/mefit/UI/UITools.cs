// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// InterfaceUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{

    #region Enums
    internal enum MenuPosition
    {
        TopRight,
        BottomLeft
    }
    #endregion

    class UITools
    {
        internal static async void FlashForecolor(Control control)
        {
            if (!Settings.ReadBool(SettingsBoolType.DisableFlashingUI))
            {
                Color originalColor = control.ForeColor;

                for (int i = 0; i < 3; i++)
                {
                    control.ForeColor =
                        Color.FromArgb(
                            control.ForeColor.A,
                            130,
                            130,
                            130);

                    await Task.Delay(70);

                    control.ForeColor = originalColor;

                    await Task.Delay(70);
                }
            }
        }

        internal static void ShowExplorerNavigationPrompt(Form owner, string message, string path)
        {
            DialogResult result =
                METMessageBox.Show(
                        owner,
                        $"{message} Navigate to file?",
                        METMessageBoxType.Information,
                        METMessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                FileUtils.HighlightPathInExplorer(path);
        }

        internal static void ShowContextMenuAtControlPoint(object sender, ContextMenuStrip menu, MenuPosition menuPosition)
        {
            Control control = sender as Control;

            if (control == null)
                throw new ArgumentException(
                    "Invalid sender object type. Expected a Control.");

            Point position;

            switch (menuPosition)
            {
                case MenuPosition.TopRight:
                    position = control.PointToScreen(
                        new Point(
                            control.Width + 1,
                            -1));
                    break;
                case MenuPosition.BottomLeft:
                    position = control.PointToScreen(
                        new Point(
                            0,
                            control.Height + 1));
                    break;
                default:
                    throw new ArgumentException(
                        "Invalid MenuPosition value.");
            }

            menu.Show(position);
        }

        internal static void ShowContextMenuAtCursor(object sender, EventArgs e, ContextMenuStrip menu, bool showOnLeftClick)
        {
            MouseEventArgs mouseEventArgs =
                e as MouseEventArgs;

            if (mouseEventArgs != null
                && (mouseEventArgs.Button == MouseButtons.Right
                || (showOnLeftClick && mouseEventArgs.Button == MouseButtons.Left)))
                menu.Show(Cursor.Position);
        }

        internal static void SetHalfOpacity(Form f) =>
            f.Opacity = 0.5;

        internal static void SetNormalOpacity(Form f) =>
            f.Opacity = 1.0;
    }
}