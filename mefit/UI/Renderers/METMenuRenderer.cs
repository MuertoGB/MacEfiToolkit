﻿// Mac EFI Toolkit
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
        private Color BorderColor = Color.FromArgb(80, 80, 80);
        private Color ItemHoveredColor = Color.FromArgb(120, 100, 100, 100);

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
            Rectangle highlightRect = new Rectangle(rect.X + 3, rect.Y + 2, rect.Width - 6, rect.Height - 4);

            Color clr = e.Item.Selected ? ItemHoveredColor : Color.Transparent;
            using (SolidBrush br = new SolidBrush(clr))
            using (Pen pen = new Pen(Color.FromArgb(ItemHoveredColor.R, ItemHoveredColor.G, ItemHoveredColor.B)))
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(br, highlightRect);
                    e.Graphics.DrawRectangle(pen, highlightRect);
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