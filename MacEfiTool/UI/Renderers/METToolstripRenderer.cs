// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METToolstripRenderer.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI.Renderers
{
    class METToolstripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle r = new Rectangle(Point.Empty, e.Item.Size);
            Color c = e.Item.Selected ? Color.FromArgb(35, 45, 55) : Color.FromArgb(15, 15, 15);
            using (SolidBrush br = new SolidBrush(c))
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(br, r);
                }
            }
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Vertical || !(e.Item is ToolStripSeparator))
            {
                base.OnRenderSeparator(e);
            }
            else
            {
                Rectangle sep = new Rectangle(Point.Empty, e.Item.Size);
                using (SolidBrush br = new SolidBrush(Color.Transparent))
                {
                    e.Graphics.FillRectangle(br, sep);
                }
                int y = (int)(sep.Bottom - (sep.Height / 2) - 1);
                int l = sep.Left + 5;
                int r = sep.Right - 5;
                using (SolidBrush b = new SolidBrush(Color.FromArgb(90, 95, 100)))
                {
                    e.Graphics.DrawLine(new Pen(b), l, y, r, y);
                }
            }
        }
    }
}