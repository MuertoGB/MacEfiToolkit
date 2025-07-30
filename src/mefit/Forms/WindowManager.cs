// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WindowManager.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    public static class WindowManager
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public enum ContextMenuPosition
        {
            TopRight,
            BottomLeft
        }

        public static void EnableFormDrag(Form form, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.MouseMove += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                        StartDrag(form);
                };
            }
        }

        private static void StartDrag(Form form)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(
                new HandleRef(form, form.Handle),
                WM_NCLBUTTONDOWN,
                (IntPtr)HT_CAPTION,
                IntPtr.Zero);
        }

        public static void HandleDragEnter(object sender, DragEventArgs e, Action applycolor)
        {
            // Check if the dragged data is a file.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Check if only one file is being dragged.
                if (draggedFiles.Length == 1)
                {
                    // Check if the dragged item is a file and not a folder.
                    string file = draggedFiles[0];
                    FileAttributes attributes = File.GetAttributes(file);

                    // If it's a file (not a folder) then allow the copy operation.
                    if ((attributes & FileAttributes.Directory) == 0)
                    {
                        e.Effect = DragDropEffects.Copy;
                        applycolor?.Invoke();
                        return;
                    }
                }
            }

            // Disable the drop effect.
            e.Effect = DragDropEffects.None;
        }

        public static void ShowContextMenuAtControlPoint(object sender, ContextMenuStrip contextmenu, ContextMenuPosition menuposition)
        {
            Control control = sender as Control;

            Point position;

            switch (menuposition)
            {
                case ContextMenuPosition.TopRight:
                    position = control.PointToScreen(new Point(control.Width + 1, -1));
                    break;
                case ContextMenuPosition.BottomLeft:
                    position = control.PointToScreen(new Point(0, control.Height + 1));
                    break;
                default:
                    throw new ArgumentException("Invalid ContextMenuPosition value.");
            }

            contextmenu.Show(position);
        }

        public static void ShowContextMenuAtCursor(object sender, EventArgs e, ContextMenuStrip contextmenu, bool showonleftclick)
        {
            MouseEventArgs args = e as MouseEventArgs;

            if (args != null && (args.Button == MouseButtons.Right ||
                (showonleftclick && args.Button == MouseButtons.Left)))
            {
                contextmenu.Show(Cursor.Position);
            }
        }
    }
}