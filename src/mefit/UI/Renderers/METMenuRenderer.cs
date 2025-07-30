// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METMenuRenderer.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI.Renderers
{
    public class METMenuRenderer : ToolStripRenderer
    {
        private readonly Color BorderColor = Color.FromArgb(80, 80, 80);
        private readonly Color ItemHoverBorderColor = Color.FromArgb(50, 70, 90);
        private readonly Color ItemHoverColor = Color.FromArgb(30, 50, 70);

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            Rectangle rect = e.AffectedBounds;

            using (Pen pen = new Pen(BorderColor))
            {
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

            Rectangle rectItemBorder = new Rectangle(rect.X + 3, rect.Y + 2, rect.Width - 6, rect.Height - 4);

            using (SolidBrush brush = new SolidBrush(e.Item.Selected ? ItemHoverColor : Color.Transparent))
            using (Pen pen = new Pen(ItemHoverBorderColor))
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(brush, rectItemBorder);
                    e.Graphics.DrawRectangle(pen, rectItemBorder);
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

                using (SolidBrush brush = new SolidBrush(Color.Transparent))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }

                using (SolidBrush brush = new SolidBrush(BorderColor))
                {
                    e.Graphics.DrawLine(new Pen(brush), left, y, right, y);
                }
            }
        }
    }
}