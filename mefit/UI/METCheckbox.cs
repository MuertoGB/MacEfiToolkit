// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METCheckbox.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.UI.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    [DefaultBindingProperty("CheckState")]
    [DefaultProperty("Checked")]
    [Designer(typeof(METCheckboxDesigner))]
    public class METCheckbox : CheckBox
    {

        #region Fields
        private bool MouseHovered = false;
        private bool MousePressed = false;
        #endregion

        #region Constructor
        public METCheckbox() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            MouseEnter += new EventHandler(ProcessMouse);
            MouseLeave += new EventHandler(ProcessMouse);
            BackColor = Color.Transparent;
            ForeColor = Colours.ENABLED_TEXT;
        }
        #endregion

        #region Properties
        private Color BorderInactive_ = Colours.BORDER_INACTIVE;
        [Description("Check area border color")]
        [Category("Appearance (MET)")]
        public Color BorderColor
        {
            get
            {
                return BorderInactive_;
            }
            set
            {
                BorderInactive_ = value;
                Invalidate();
            }
        }

        private Color BorderActive_ = Colours.BORDER_ACTIVE;
        [Description("Check area mouseover border color")]
        [Category("Appearance (MET)")]
        public Color BorderColorActive
        {
            get
            {
                return BorderActive_;
            }
            set
            {
                BorderActive_ = value;
                Invalidate();
            }
        }

        private Color ClientInactive_ = Colours.CLIENT_INACTIVE;
        [Description("Check area backcolor")]
        [Category("Appearance (MET)")]
        public Color ClientColor
        {
            get
            {
                return ClientInactive_;
            }
            set
            {
                ClientInactive_ = value;
                Invalidate();
            }
        }

        private Color ClientActive_ = Colours.CLIENT_ACTIVE;
        [Description("Check area mouseover color")]
        [Category("Appearance (MET)")]
        public Color ClientColorActive
        {
            get
            {
                return ClientActive_;
            }
            set
            {
                ClientActive_ = value;
                Invalidate();
            }
        }

        private Color Checked_ = Colours.CHECKED;
        [Description("Control checked color")]
        [Category("Appearance (MET)")]
        public Color CheckedColor
        {
            get
            {
                return Checked_;
            }
            set
            {
                Checked_ = value;
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

            int diameter = ClientRectangle.Height - 2;
            Rectangle innerRectangle = new Rectangle(2, 2, diameter - 2, diameter - 2);
            Rectangle outerRectangle = new Rectangle(2, 2, diameter - 2, diameter - 2);

            Color switchBorder = Enabled ? (Focused ? BorderColor : MouseHovered && MousePressed ? CheckedColor :
                                 MouseHovered ? BorderColorActive : BorderColor) : Colours.DISABLED_CONTROL;

            if (Focused)
            {
                using (Pen pen = new Pen(Color.White, 1))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle rect = ClientRectangle;
                    rect.Width -= 1; rect.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

            Color switchBack = MouseHovered ? ClientColorActive : ClientColor;

            using (var pen = new Pen(switchBorder, 2.0f))
            {
                e.Graphics.DrawRectangle(pen, outerRectangle);
            }

            innerRectangle.Inflate(-1, -1);

            using (var brush = new SolidBrush(switchBack))
            {
                e.Graphics.FillRectangle(brush, innerRectangle);
            }

            if (Checked)
            {
                innerRectangle = new Rectangle(1, 1, diameter, diameter);
                innerRectangle.Inflate(-5, -5); // Control size of check

                using (var brush = new SolidBrush(CheckedColor))
                {
                    e.Graphics.FillRectangle(brush, innerRectangle);
                }
            }

            var textArea = new Rectangle(outerRectangle.Width + 6, 0, Width - outerRectangle.Width - 6, Height);
            var textColor = Enabled ? ForeColor : Colours.DISABLED_TEXT;

            using (var format = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
            using (var brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawRectangle(Pens.Transparent, textArea);
                e.Graphics.DrawString(Text, Font, brush, textArea, format);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);
            OnPaintForeground(e);
        }
        #endregion

        #region Overriden Methods
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

        protected override void OnTextChanged(EventArgs e)
        {
            GetPreferredSizeN();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    MousePressed = true;
                    Invalidate();
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MousePressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            MouseHovered = true;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            MouseHovered = false;
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

        #endregion

        #region Custom Methods
        private void ProcessMouse(object sender, EventArgs e)
        {
            if (ClientRectangle.Contains(PointToClient(MousePosition)))
                if (!MouseHovered) { MouseHovered = true; Invalidate(); }
                else { MouseHovered = false; Invalidate(); }
        }
        private Size GetPreferredSizeN()
        {
            return GetPreferredSize(new Size(0, 0));
        }
        #endregion

    }
}