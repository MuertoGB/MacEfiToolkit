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
    [DefaultBindingProperty("CheckState")]
    [DefaultProperty("Checked")]
    [Designer(typeof(METSwitchDesigner))]
    public class METSwitch : CheckBox
    {
        #region Fields
        private bool _mouseHovered = false;
        #endregion

        #region Constructor
        public METSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Black;
        }
        #endregion

        #region Properties
        private Color _borderColorInactive = Colours.BORDER_INACTIVE;
        [Description("The border color of the control when inactive.")]
        [Category("Appearance (MET)")]
        public Color BorderColor
        {
            get
            {
                return _borderColorInactive;
            }
            set
            {
                _borderColorInactive = value;
                Invalidate();
            }
        }

        private Color _borderColorActive = Colours.BORDER_ACTIVE;
        [Description("The border color of the control when the mouse is over it.")]
        [Category("Appearance (MET)")]
        public Color BorderColorActive
        {
            get
            {
                return _borderColorActive;
            }
            set
            {
                _borderColorActive = value;
                Invalidate();
            }
        }

        private Color _clientColorInactive = Colours.CLIENT_INACTIVE;
        [Description("The background color of the control when inactive.")]
        [Category("Appearance (MET)")]
        public Color ClientColor
        {
            get
            {
                return _clientColorInactive;
            }
            set
            {
                _clientColorInactive = value;
                Invalidate();
            }
        }

        private Color _clientColorActive = Colours.CLIENT_ACTIVE;
        [Description("The background color of the control when the mouse is over it.")]
        [Category("Appearance (MET)")]
        public Color ClientColorActive
        {
            get
            {
                return _clientColorActive;
            }
            set
            {
                _clientColorActive = value;
                Invalidate();
            }
        }

        private Color _checkedColor = Colours.CHECKED;
        [Description("The color of the control when it is checked.")]
        [Category("Appearance (MET)")]
        public Color CheckedColor
        {
            get
            {
                return _checkedColor;
            }
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }

        private Color _switchHeadColor = Colours.SWITCH_HEAD;

        [Description("The color of the control switch head.")]
        [Category("Appearance (MET)")]
        public Color SwitchHeadColor
        {
            get
            {
                return _switchHeadColor;
            }
            set
            {
                _switchHeadColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Paint Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);
            OnPaintForeground(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e != null)
            {
                if (BackColor.A == 255)
                {
                    e.Graphics.Clear(BackColor);
                    return;
                }
            }

            base.OnPaintBackground(e);
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            if (e == null)
                return;

            // Determine the switch border color based on state
            Color setCheckBorderColor = Enabled
                ? Focused ? BorderColorActive : BorderColor
                : Colours.DISABLED_CONTROL;

            // Draw the switch border
            using (Pen pen = new Pen(setCheckBorderColor) { Width = 2.0F })
            {
                int innerWidth = Width - 2;

                Rectangle rect =
                    new Rectangle(
                        1,
                        1,
                        innerWidth,
                        ClientRectangle.Height - 2);

                e.Graphics.DrawRectangle(
                    pen,
                    rect);
            }

            // Determine the switch client color based on state
            Color setClientColor = _mouseHovered
                ? Checked ? CheckedColor : ClientColorActive
                : Checked ? CheckedColor : BackColor;

            // Fill the switch client area
            using (SolidBrush brush = new SolidBrush(setClientColor))
            {
                Rectangle innerRect =
                    new Rectangle(
                        2,
                        2,
                       Width - 4,
                       Height - 4);

                innerRect.Inflate(-2, -2);

                e.Graphics.FillRectangle(
                    brush,
                    innerRect);
            }

            // Draw the 2px gap between switch head and client area
            using (Pen pen = new Pen(BackColor, 2)) // Set the pen width to 2 pixels
            {
                int gapWidth = (int)(Checked ? Width - Width / 3 - 1 : 1); // Adjust for 2 pixels

                Rectangle gapRect =
                    new Rectangle(
                        gapWidth,
                        0,
                        (int)(Width / 3),
                        Height);

                e.Graphics.DrawRectangle(
                    pen,
                    gapRect);
            }

            // Fill the switch head area
            using (SolidBrush brush = new SolidBrush(Enabled ? SwitchHeadColor : Colours.SWITCH_HEAD_DISABLED))
            {
                int switchHeadWidth = (int)(Width / 3);

                int switchHeadLeft = (int)(Checked ? Width - switchHeadWidth : 0);

                Rectangle rect =
                    new Rectangle(
                        switchHeadLeft,
                        0,
                        switchHeadWidth,
                        Height);

                e.Graphics.FillRectangle(
                    brush,
                    rect);
            }
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
            _mouseHovered = false;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            _mouseHovered = true;
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