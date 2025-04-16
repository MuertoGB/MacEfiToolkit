// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// FormEx.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit;
using Mac_EFI_Toolkit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class FormEx : Form
{
    #region Private Members
    private const int WM_SETTINGCHANGE = 0x001A;
    private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;

    private const int WS_MINIMIZEBOX = 0x20000;
    private const int CS_DBLCLKS = 0x8;
    private const int CS_DROP = 0x20000;

    private static List<FormEx> _openForms = new List<FormEx>();
    #endregion

    #region Constructor
    public FormEx()
    {
        // Wire event handlers.
        Load += METForm_Load;

        // Resister this instance.
        _openForms.Add(this);
    }
    #endregion

    #region Window Events
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Remove this instance from the list when closed.
        _openForms.Remove(this);
        base.OnFormClosed(e);
    }

    private void METForm_Load(object sender, EventArgs e)
    {
        // Ensure the form is within screen bounds.
        AdjustFormToScreenBounds();

        // Set accent color.
        SetAccentColor();
    }

    private void AdjustFormToScreenBounds()
    {
        // Get the screen where the form is currently displayed.
        Screen screen = Screen.FromControl(this);
        Rectangle rect = screen.WorkingArea;

        // Adjust edges if they're outside the screen bounds.
        Top = Top < rect.Top ? rect.Top : Top; // Top
        Left = Left < rect.Left ? rect.Left : Left; // Left
        Left = Right > rect.Right ? rect.Right - Width : Left; // Right
        Top = Bottom > rect.Bottom ? rect.Bottom - Height : Top; // Bottom
    }
    #endregion

    #region Overrides Methods
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams Params = base.CreateParams;
            Params.Style |= WS_MINIMIZEBOX;
            Params.ClassStyle = Params.ClassStyle | CS_DBLCLKS | CS_DROP;
            return Params;
        }
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // Check for WM_SETTINGCHANGE and WM_DWMCOMPOSITIONCHANGED.
        if (m.Msg == WM_SETTINGCHANGE || m.Msg == WM_DWMCOMPOSITIONCHANGED)
        {
            // Call method to update accent color.
            UpdateAccentColor();
        }
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        UpdateAccentColor();
    }

    protected override void OnDeactivate(EventArgs e)
    {
        base.OnDeactivate(e);

        UpdateAccentColor();
    }
    #endregion

    #region Accent Colour
    public static void UpdateAccentColor()
    {
        lock (_openForms)
        {
            foreach (FormEx form in _openForms)
            {
                if (form == Form.ActiveForm)
                {
                    form.SetAccentColor(); // Active form gets accent color
                }
                else
                {
                    form.BackColor = Colours.InactiveWindow; // Inactive forms get the inactive color
                }
            }
        }
    }

    private void SetAccentColor()
    {
        if (Settings.ReadBoolean(Settings.BooleanKey.UseAccentColor))
        {
            BackColor = AccentColorHelper.GetSystemAccentColor();
            return;
        }

        BackColor = Colours.AppBorderDefault;
    }
    #endregion
}