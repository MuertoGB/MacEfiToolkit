// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METCheckbox.cs
// Released under the GNU GLP v3.0
// Extremely bad port from my UI framework,
// will refactor later, it works :shrug:

using Mac_EFI_Toolkit.UI.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    [Designer(typeof(METSwitchDesigner))]
    public class METSwitch : CheckBox
    {
        #region Fields
        private bool MouseHovered = false;
        #endregion

        #region Constructor
        public METSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Black;
        }
        #endregion

        #region Properties
        private Color BorderInactive_ = Colours.BORDER_INACTIVE;

        [Description("Set the control border color.")]
        [Category("Appearance (MET)")]
        public Color BorderColor
        {
            get { return BorderInactive_; }
            set
            {
                BorderInactive_ = value;
                Invalidate();
            }
        }

        private Color BorderActive_ = Colours.BORDER_ACTIVE;

        [Description("Set the control mouseover border color.")]
        [Category("Appearance (MET)")]
        public Color BorderColorActive
        {
            get { return BorderActive_; }
            set
            {
                BorderActive_ = value;
                Invalidate();
            }
        }

        private Color HeadColor_ = Colours.SWITCH_HEAD;

        [Description("Set the switch head color")]
        [Category("Appearance (MET)")]
        public Color SwitchHeadColor
        {
            get { return HeadColor_; }
            set
            {
                HeadColor_ = value;
                Invalidate();
            }
        }

        private Color CheckedColor_ = Colours.CHECKED;

        [Description("Set the control toggle on color.")]
        [Category("Appearance (MET)")]
        public Color CheckedColor
        {
            get { return CheckedColor_; }
            set
            {
                CheckedColor_ = value;
                Invalidate();
            }
        }

        private Color ClientActive_ = Colours.CLIENT_ACTIVE;

        [Description("Sets the mouseover background color when the switch is set to off.")]
        [Category("Appearance (MET)")]
        public Color ClientColorActive
        {
            get { return ClientActive_; }
            set
            {
                ClientActive_ = value;
                Invalidate();
            }
        }
        #endregion

        #region Paint Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e != null)
            {
                Graphics g = e.Graphics;
                if (BackColor.A == 255)
                {
                    g.Clear(BackColor);
                    return;
                }
            }

            base.OnPaintBackground(e);
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            if (e == null) return;

            Graphics g = e.Graphics;
            Color switchBorder, switchClient;

            // Determine the switch border color based on state
            if (Enabled)
            {
                switchBorder = Focused ? BorderColorActive : BorderColor;
            }
            else
            {
                switchBorder = Colours.DISABLED_CONTROL;
            }

            // Draw the switch border
            using (Pen pen = new Pen(switchBorder) { Width = 2.0F })
            {
                int innerWidth = Width - 2;
                Rectangle rect = new Rectangle(1, 1, innerWidth, ClientRectangle.Height - 2);
                g.DrawRectangle(pen, rect);
            }

            // Determine the switch client color based on state
            switchClient = MouseHovered
                ? Checked ? CheckedColor : ClientColorActive
                : Checked ? CheckedColor : BackColor;

            // Fill the switch client area
            using (SolidBrush brush = new SolidBrush(switchClient))
            {
                Rectangle innerRect = new Rectangle(2, 2, Width - 4, Height - 4);
                innerRect.Inflate(-2, -2);
                g.FillRectangle(brush, innerRect);
            }

            // Draw the 2px gap between switch head and client area
            using (Pen pen = new Pen(BackColor, 2)) // Set the pen width to 2 pixels
            {
                int gapWidth = (int)(Checked ? Width - Width / 3 - 1 : 1); // Adjust for 2 pixels
                Rectangle gapRect = new Rectangle(gapWidth, 0, (int)(Width / 3), Height);
                g.DrawRectangle(pen, gapRect);
            }

            // Fill the switch head area
            using (SolidBrush brush = new SolidBrush(Enabled ? SwitchHeadColor : Colours.SWITCH_HEAD_DISABLED))
            {
                int switchHeadWidth = (int)(Width / 3);
                int switchHeadLeft = (int)(Checked ? Width - switchHeadWidth : 0);
                Rectangle switchHeadRect = new Rectangle(switchHeadLeft, 0, switchHeadWidth, Height);
                g.FillRectangle(brush, switchHeadRect);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);
            OnPaintForeground(e);
        }
        #endregion

        #region Overridden Methods
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            MouseHovered = false;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            MouseHovered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeRedraw = true;
            base.OnResize(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Invalidate();
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Checked = !Checked;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        public override Size GetPreferredSize(Size preferredSize)
        {
            preferredSize.Width = 34;
            preferredSize.Height = 20;
            return preferredSize;
        }
        #endregion

    }
}