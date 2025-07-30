// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// UITools.cs
// Released under the GNU GLP v3.0

using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    public static class UITools
    {
        public static void HighlightFileInExplorer(string file)
        {
            if (!File.Exists(file))
                return;

            Process.Start("explorer.exe", $"/select,\"{file}\"");
        }

        public static void GoToFolderInExplorer(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            DirectoryInfo info =
                new DirectoryInfo(directory);

            if (!info.Attributes.HasFlag(FileAttributes.Directory))
                return;

            Process.Start("explorer.exe", directory);
        }

        public static void SetLabelColorInNestedPanels(TableLayoutPanel tableLayoutPanel, Color color, string matchString)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label && label.Text == matchString)
                {
                    SetLabelColor(label, color);
                }
                else if (control is TableLayoutPanel nestedPanel)
                {
                    SetLabelColorInNestedPanels(nestedPanel, color, matchString);
                }
            }
        }

        private static void SetLabelColor(Label label, Color color)
        {
            label.ForeColor = color;
        }
    }
}