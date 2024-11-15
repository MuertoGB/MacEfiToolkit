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
        private ToolTip toolTip;
        private TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
        #endregion

        #region Constructor
        public METLabel() => toolTip = new ToolTip { AutoPopDelay = 15000 };
        #endregion

        #region Paint Methods
        protected override void OnPaint(PaintEventArgs e) => DrawText(e.Graphics, flags, ForeColor);

        protected virtual void OnPaintForeground(PaintEventArgs e) => DrawText(e.Graphics, flags, ForeColor);
        #endregion

        #region Custom Methods
        private void DrawText(Graphics graphics, TextFormatFlags flags, Color textColor)
        {
            Rectangle textRect =
                new Rectangle(
                    ClientRectangle.Left + Padding.Left,
                    ClientRectangle.Top + Padding.Top,
                    ClientRectangle.Width - Padding.Horizontal,
                    ClientRectangle.Height - Padding.Vertical);

            // Override text color when the control is !enabled.
            textColor = !Enabled ? Color.FromArgb(14, 14, 14) : ForeColor;

            TextRenderer.DrawText(graphics, Text, Font, textRect, textColor, flags);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (IsTextEllipsized() && Text != toolTip.GetToolTip(this))
            {
                toolTip.SetToolTip(this, Text);
            }
            else if (!IsTextEllipsized())
            {
                toolTip.SetToolTip(this, string.Empty);
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
                toolTip?.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}