// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// UITools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        #region Flash ForeColor
        internal static async void FlashForecolor(Control control)
        {
            if (!Settings.ReadBoolean(Settings.BooleanKey.DisableFlashingUI))
            {
                Color original = control.ForeColor;

                for (int i = 0; i < 3; i++)
                {
                    control.ForeColor = Color.FromArgb(control.ForeColor.A, 130, 130, 130);
                    await Task.Delay(70);
                    control.ForeColor = original;
                    await Task.Delay(70);
                }
            }
        }
        #endregion

        #region Explorer
        internal static void ShowExplorerFileHighlightPrompt(Form owner, string filepath)
        {
            DialogResult result =
                METPrompt.Show(
                        owner,
                        $"{APPSTRINGS.FILE_SAVE_SUCCESS_NAV}",
                        METPrompt.PType.Information,
                        METPrompt.PButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                HighlightPathInExplorer(filepath, owner);
            }
        }

        internal static void ShowOpenFolderInExplorerPrompt(Form owner, string folderpath)
        {
            DialogResult result =
                METPrompt.Show(
                        owner,
                        $"{APPSTRINGS.FILES_SAVE_SUCCESS_NAV}",
                        METPrompt.PType.Information,
                        METPrompt.PButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Process.Start("explorer.exe", folderpath);
            }
        }

        /// <summary>
        /// Navigate to, and highlight a file in Windows Explorer.
        /// </summary>
        /// <param name="filepath">The path of the file to open and highlight in Windows Explorer.</param>
        /// <param name="owner">The form instance used to display prompts to the user.</param>
        internal static void HighlightPathInExplorer(string filepath, Form owner)
        {
            if (!File.Exists(filepath))
            {
                METPrompt.Show(
                    owner,
                    $"File does not exist: {filepath}",
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            Process.Start("explorer.exe", $"/select,\"{filepath}\"");
        }

        internal static void OpenFolderInExplorer(string folderpath, Form owner)
        {
            if (!Directory.Exists(folderpath))
            {
                METPrompt.Show(
                    owner,
                    $"Directory does not exist: {folderpath}",
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            DirectoryInfo info = new DirectoryInfo(folderpath);

            if (!info.Attributes.HasFlag(FileAttributes.Directory))
            {
                METPrompt.Show(
                    owner,
                    $"The path is not a directory: {folderpath}",
                    METPrompt.PType.Warning,
                    METPrompt.PButtons.Okay);

                return;
            }

            Process.Start("explorer.exe", folderpath);
        }
        #endregion

        #region Context Menu Position
        internal static void ShowContextMenuAtControlPoint(object sender, ContextMenuStrip contextmenu, MenuPosition menuposition)
        {
            Control control = sender as Control;

            if (control == null)
            {
                throw new ArgumentException("Invalid sender object type. Expected a Control.");
            }

            Point position;

            switch (menuposition)
            {
                case MenuPosition.TopRight:
                    position = control.PointToScreen(new Point(control.Width + 1, -1));
                    break;
                case MenuPosition.BottomLeft:
                    position = control.PointToScreen(new Point(0, control.Height + 1));
                    break;
                default:
                    throw new ArgumentException("Invalid MenuPosition value.");
            }

            contextmenu.Show(position);
        }

        internal static void ShowContextMenuAtCursor(object sender, EventArgs e, ContextMenuStrip contextmenu, bool showonleftclick)
        {
            MouseEventArgs args = e as MouseEventArgs;

            if (args != null && (args.Button == MouseButtons.Right || (showonleftclick && args.Button == MouseButtons.Left)))
            {
                contextmenu.Show(Cursor.Position);
            }
        }
        #endregion

        #region Form Drag
        public static void EnableFormDrag(Form form, params Control[] controls)
        {
            foreach (Control control in controls)
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

        private static void StartDrag(Form form)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(new HandleRef(form, form.Handle), WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
        }
        #endregion

        #region Nested panel text color setter
        internal static void ApplyNestedPanelLabelForeColor(TableLayoutPanel tablelayoutpanel, Color color)
        {
            foreach (Control control in tablelayoutpanel.Controls)
            {
                if (control is Label label && label.Text == APPSTRINGS.NA)
                {
                    label.ForeColor = color;
                }
                else if (control is TableLayoutPanel nestedTableLayoutPanel)
                {
                    ApplyNestedPanelLabelForeColor(nestedTableLayoutPanel, color);
                }
            }
        }
        #endregion
    }
}