// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METSwitch.cs
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
    [Designer(typeof(METSwitchDesigner))]
    public class METSwitch : CheckBox
    {
        #region Fields
        private bool _mouseHovered = false;
        private Color _borderColorInactive = Colours.BORDER_INACTIVE;
        private Color _borderColorActive = Colours.BORDER_ACTIVE;
        private Color _clientColorInactive = Colours.CLIENT_INACTIVE;
        private Color _clientColorActive = Colours.CLIENT_ACTIVE;
        private Color _checkedColor = Colours.CHECKED;
        private Color _switchHeadColor = Colours.SWITCH_HEAD_ENABLED;
        #endregion

        #region Constructor
        public METSwitch()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            BackColor = Color.Black;
        }
        #endregion

        #region Properties
        [Description("The border color of the control when inactive.")]
        [Category("Appearance (MET)")]
        public Color BorderColor
        {
            get => _borderColorInactive;
            set { _borderColorInactive = value; Invalidate(); }
        }

        [Description("The border color of the control when the mouse is over it.")]
        [Category("Appearance (MET)")]
        public Color BorderColorActive
        {
            get => _borderColorActive;
            set { _borderColorActive = value; Invalidate(); }
        }

        [Description("The background color of the control when inactive.")]
        [Category("Appearance (MET)")]
        public Color ClientColor
        {
            get => _clientColorInactive;
            set { _clientColorInactive = value; Invalidate(); }
        }

        [Description("The background color of the control when the mouse is over it.")]
        [Category("Appearance (MET)")]
        public Color ClientColorActive
        {
            get => _clientColorActive;
            set { _clientColorActive = value; Invalidate(); }
        }

        [Description("The color of the control when it is checked.")]
        [Category("Appearance (MET)")]
        public Color CheckedColor
        {
            get => _checkedColor;
            set { _checkedColor = value; Invalidate(); }
        }

        [Description("The color of the control switch head.")]
        [Category("Appearance (MET)")]
        public Color SwitchHeadColor
        {
            get => _switchHeadColor;
            set { _switchHeadColor = value; Invalidate(); }
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
            if (e != null && BackColor.A == 255)
            {
                e.Graphics.Clear(BackColor);
                return;
            }

            base.OnPaintBackground(e);
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            if (e == null) return;

            Color borderColor = GetBorderColor();
            Color clientColor = GetClientColor();
            Color switchHeadColor = GetSwitchHeadColor();

            DrawSwitchBorder(e.Graphics, borderColor);
            FillSwitchClientArea(e.Graphics, clientColor);
            DrawSwitchGap(e.Graphics);
            FillSwitchHead(e.Graphics, switchHeadColor);
        }

        private Color GetBorderColor()
        {
            return Enabled ? (Focused ? BorderColorActive : BorderColor) : Colours.DISABLED_CONTROL;
        }

        private Color GetClientColor()
        {
            return _mouseHovered ? (Checked ? CheckedColor : ClientColorActive) : (Checked ? CheckedColor : BackColor);
        }

        private Color GetSwitchHeadColor()
        {
            return Enabled ? SwitchHeadColor : Colours.SWITCH_HEAD_DISABLED;
        }

        private void DrawSwitchBorder(Graphics g, Color borderColor)
        {
            using (var pen = new Pen(borderColor, 2.0F))
            {
                var rect = new Rectangle(1, 1, Width - 2, ClientRectangle.Height - 2);
                g.DrawRectangle(pen, rect);
            }
        }

        private void FillSwitchClientArea(Graphics g, Color clientColor)
        {
            using (var brush = new SolidBrush(clientColor))
            {
                var innerRect = new Rectangle(2, 2, Width - 4, Height - 4);
                innerRect.Inflate(-2, -2);
                g.FillRectangle(brush, innerRect);
            }
        }

        private void DrawSwitchGap(Graphics g)
        {
            using (var pen = new Pen(BackColor, 2))
            {
                int gapWidth = (int)(Checked ? Width - Width / 3 - 1 : 1);
                var gapRect = new Rectangle(gapWidth, 0, (int)(Width / 3), Height);
                g.DrawRectangle(pen, gapRect);
            }
        }

        private void FillSwitchHead(Graphics g, Color switchHeadColor)
        {
            int switchHeadWidth = (int)(Width / 3);
            int switchHeadLeft = (int)(Checked ? Width - switchHeadWidth : 0);
            var rect = new Rectangle(switchHeadLeft, 0, switchHeadWidth, Height);

            using (var brush = new SolidBrush(switchHeadColor))
            {
                g.FillRectangle(brush, rect);
            }
        }
        #endregion

        #region Overridden Methods
        protected override void OnCheckedChanged(EventArgs e)
        {
            if (!Enabled)
            {
                Checked = false;
                return;
            }

            base.OnCheckedChanged(e);
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
            if (e?.Button == MouseButtons.Left)
            {
                Invalidate();
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