// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METMenuRenderer.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI.Renderers
{
    class METMenuRenderer : ToolStripRenderer
    {
        private Color BorderColor = Color.FromArgb(120, 120, 120);
        private Color ItemHoveredColor = Color.FromArgb(80, 60, 160, 235);

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            Rectangle bounds = e.AffectedBounds;

            using (Pen pen = new Pen(BorderColor))
            {
                e.Graphics.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
            Color clr = e.Item.Selected ? ItemHoveredColor : Color.Transparent;
            using (SolidBrush br = new SolidBrush(clr))
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(br, rect);
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
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                int y = rect.Bottom - (rect.Height / 2) - 1;
                int left = rect.Left + 5;
                int right = rect.Right - 5;

                using (SolidBrush br = new SolidBrush(Color.Transparent))
                {
                    e.Graphics.FillRectangle(br, rect);
                }

                using (SolidBrush sb = new SolidBrush(BorderColor))
                {
                    e.Graphics.DrawLine(new Pen(sb), left, y, right, y);
                }
            }
        }
    }
}