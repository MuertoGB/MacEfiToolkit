using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Mac_EFI_Toolkit.UI.Design;

namespace Mac_EFI_Toolkit.UI
{
    [DefaultBindingProperty("CheckState")]
    //[DefaultEvent("CheckChanged")]
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
            ForeColor = Colours.EnabledText;
        }
        #endregion

        #region Properties
        private Color BorderInactive_ = Colours.BorderInactive;
        [Description("Check area border color")]
        [Category("Appearance (Gambol)")]
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

        private Color BorderActive_ = Colours.BorderActive;
        [Description("Check area mouseover border color")]
        [Category("Appearance (Gambol)")]
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

        private Color ClientInactive_ = Colours.ClientInactive;
        [Description("Check area backcolor")]
        [Category("Appearance (Gambol)")]
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

        private Color ClientActive_ = Colours.ClientActive;
        [Description("Check area mouseover color")]
        [Category("Appearance (Gambol)")]
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

        private Color Checked_ = Colours.Checked;
        [Description("Control checked color")]
        [Category("Appearance (Gambol)")]
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
            int Diameter = ClientRectangle.Height - 2;
            Rectangle InnerRectangle = new Rectangle(2, 2, Diameter - 2, Diameter - 2);
            Rectangle OuterRectangle = new Rectangle(2, 2, Diameter - 2, Diameter - 2);
            Color SwitchBorder, SwitchBack;

            if (e != null)
            {
                Graphics g = e.Graphics;

                if (Enabled)
                {
                    if (MouseHovered && MousePressed)
                    { SwitchBorder = Color.FromArgb(Colours.A, CheckedColor.R, CheckedColor.G, CheckedColor.B); }
                    else if (MouseHovered)
                    { SwitchBorder = BorderColorActive; }
                    else
                    { SwitchBorder = BorderColor; }
                }
                else { SwitchBorder = Colours.DisabledControl; }

                using (Pen P = new Pen(SwitchBorder, 2.0f))
                {
                    g.DrawRectangle(P, OuterRectangle);
                }

                InnerRectangle.Inflate(-1, -1);

                if (MouseHovered)
                { SwitchBack = ClientColorActive; }
                else { SwitchBack = ClientColor; }

                using (SolidBrush SB = new SolidBrush(SwitchBack))
                {
                    g.FillRectangle(SB, InnerRectangle);
                }

                if (Checked)
                {
                    InnerRectangle = new Rectangle(1, 1, Diameter, Diameter);
                    InnerRectangle.Inflate(-5, -5); // Control size of check
                    using (SolidBrush SB = new SolidBrush(CheckedColor))
                    {
                        g.FillRectangle(SB, InnerRectangle);
                    }
                }

                Rectangle TextArea = new Rectangle(OuterRectangle.Width + 6, 0, Width - OuterRectangle.Width - 6, Height);
                Color BC = Enabled ? ForeColor : Colours.DisabledText;

                using (StringFormat TF = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                using (SolidBrush SB = new SolidBrush(BC))
                {
                    g.DrawRectangle(Pens.Transparent, TextArea);
                    g.DrawString(Text, Font, SB, TextArea, TF);
                }

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
