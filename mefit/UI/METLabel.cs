// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METLabel.cs - Because fuck Auto Ellipsis.
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Windows.Forms;

public class METLabel : Label
{
    private ToolTip toolTip;

    public METLabel()
    {
        toolTip = new ToolTip { AutoPopDelay = 10000 };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

        Rectangle textRect = new Rectangle(ClientRectangle.Left + Padding.Left,
                                           ClientRectangle.Top + Padding.Top,
                                           ClientRectangle.Width - Padding.Horizontal,
                                           ClientRectangle.Height - Padding.Vertical);

        TextRenderer.DrawText(e.Graphics, Text, Font, textRect, ForeColor, flags);
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

}
