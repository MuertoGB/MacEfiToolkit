// Quick and dirty TLP for the startup window D&D TLP adorner.

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class METTableLayout : TableLayoutPanel
{
    private Color _gradientStartColor =
        Color.FromArgb(100, 100, 100);
    private Color _gradientEndColor =
        Color.FromArgb(70, 70, 70);

    public Color GradientStartColor
    {
        get { return _gradientStartColor; }
        set
        {
            _gradientStartColor = value;
            this.Invalidate();
        }
    }

    public Color GradientEndColor
    {
        get { return _gradientEndColor; }
        set
        {
            _gradientEndColor = value;
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int inset = 10;
        int thickness = 2;

        Rectangle borderRect =
            new Rectangle(
                inset,
                inset,
                this.Width - 1 - 2 * inset,
                this.Height - 1 - 2 * inset);

        using (LinearGradientBrush gradientBrush =
            new LinearGradientBrush(
                new Rectangle(
                    0,
                    0,
                    this.Width,
                    this.Height),
                _gradientStartColor,
                _gradientEndColor,
                LinearGradientMode.Vertical))
        using (Pen gradientPen = new Pen(gradientBrush, thickness))
        {
            RectangleF outerRect =
                new RectangleF(
                    inset - thickness / 2f,
                    inset - thickness / 2f,
                    borderRect.Width + thickness,
                    borderRect.Height + thickness);

            e.Graphics.DrawRectangle(
                gradientPen,
                outerRect.X,
                outerRect.Y,
                outerRect.Width,
                outerRect.Height);
        }
    }
}