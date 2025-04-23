// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METLabel.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI.Controls
{
    public class METLabel : Label
    {
        #region Private Members
        private ToolTip _tooltip;
        private TextFormatFlags _tfFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
        #endregion

        #region Constructor
        public METLabel() => _tooltip = new ToolTip { AutoPopDelay = 15000 };
        #endregion

        #region Paint Methods
        protected override void OnPaint(PaintEventArgs e) => DrawText(e.Graphics, _tfFlags, ForeColor);

        protected virtual void OnPaintForeground(PaintEventArgs e) => DrawText(e.Graphics, _tfFlags, ForeColor);
        #endregion

        #region Custom Methods
        private void DrawText(Graphics graphics, TextFormatFlags textformatflags, Color textcolour)
        {
            Rectangle rect =
                new Rectangle(
                    ClientRectangle.Left + Padding.Left,
                    ClientRectangle.Top + Padding.Top,
                    ClientRectangle.Width - Padding.Horizontal,
                    ClientRectangle.Height - Padding.Vertical
                );

            // Override text color when the control is !enabled.
            textcolour = !Enabled ? Color.FromArgb(14, 14, 14) : ForeColor;

            TextRenderer.DrawText(graphics, Text, Font, rect, textcolour, textformatflags);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (IsTextEllipsized() && Text != _tooltip.GetToolTip(this))
            {
                _tooltip.SetToolTip(this, Text);
            }
            else if (!IsTextEllipsized())
            {
                _tooltip.SetToolTip(this, string.Empty);
            }
        }

        private bool IsTextEllipsized()
        {
            using (Graphics g = CreateGraphics())
            {
                Size textSize = TextRenderer.MeasureText(Text, Font);
                return textSize.Width > ClientSize.Width;
            }
        }
        #endregion

        #region Overriden Methods
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnParentEnabledChanged(EventArgs e)
        {
            base.OnParentEnabledChanged(e);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tooltip?.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}