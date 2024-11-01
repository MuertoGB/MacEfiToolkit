// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// InterfaceUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
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
        #region Flash ForeColor
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
        #endregion

        #region Explorer
        internal static void ShowExplorerFileHighlight(Form owner, string path)
        {
            DialogResult result =
                METPrompt.Show(
                        owner,
                        $"{APPSTRINGS.FILE_SAVE_SUCCESS_NAV}",
                        METPromptType.Information,
                        METPromptButtons.YesNo);

            if (result == DialogResult.Yes)
                FileUtils.HighlightPathInExplorer(path);
        }

        internal static void ShowExplorerDirectory(Form owner, string path)
        {
            DialogResult result =
                METPrompt.Show(
                        owner,
                        $"{APPSTRINGS.FILES_SAVE_SUCCESS_NAV}",
                        METPromptType.Information,
                        METPromptButtons.YesNo);

            if (result == DialogResult.Yes)
                Process.Start("explorer.exe", path);
        }
        #endregion

        #region Context Menu Position
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
        #endregion

        #region Form Opacity
        internal static void SetHalfOpacity(Form f) =>
            f.Opacity = 0.5;

        internal static void SetNormalOpacity(Form f) =>
            f.Opacity = 1.0;
        #endregion

        public static void ConfigureWindowPosition(Form form)
        {
            if (form.Owner == null && form.Parent == null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        public static void EnableFormDrag(Form form, params Control[] dragControls)
        {
            foreach (var control in dragControls)
            {
                control.MouseMove += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        StartDrag(form);
                    }
                };
            }
        }

        // Private method to handle the drag functionality
        private static void StartDrag(Form form)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(new HandleRef(form, form.Handle),
                Program.WM_NCLBUTTONDOWN,
                (IntPtr)Program.HT_CAPTION,
                IntPtr.Zero);
        }

    }
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
}