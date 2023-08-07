// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// ArrowDrawer.cs
// Released under the GNU GLP v3.0

// The hackiest drop arrow drawer you'll ever see. However it
// will do until I design a complete button.

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ArrowDrawer
{

    public static void Draw(Control control, Color color)
    {
        control.Paint += (sender, e) =>
        {
            int arrowX = control.Width / 2;
            int arrowY = control.Height - 6;

            using (SolidBrush brush = new SolidBrush(color))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

                Point[] arrowPoints = new Point[]
                {
                    new Point(arrowX - 3, arrowY - 3),
                    new Point(arrowX, arrowY),
                    new Point(arrowX + 3, arrowY - 3)
                };

                // Draw the arrow
                e.Graphics.FillPolygon(brush, arrowPoints);
            }
        };
    }
}