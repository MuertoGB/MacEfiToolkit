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
    #region Internal Members
    private const int WM_SETTINGCHANGE = 0x001A;
    private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;

    private const int WS_MINIMIZEBOX = 0x20000;
    private const int CS_DBLCLKS = 0x8;
    private const int CS_DROP = 0x20000;

    private static List<FormEx> openForms = new List<FormEx>();
    #endregion

    #region Constructor
    public FormEx()
    {
        // Wire event handlers.
        Load += METForm_Load;

        // Resister this instance.
        openForms.Add(this);
    }
    #endregion

    #region Window Events
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Remove this instance from the list when closed.
        openForms.Remove(this);
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
        Screen currentScreen = Screen.FromControl(this);
        Rectangle screenBounds = currentScreen.WorkingArea;

        // Adjust edges if they're outside the screen bounds.
        Top = Top < screenBounds.Top ? screenBounds.Top : Top; // Top
        Left = Left < screenBounds.Left ? screenBounds.Left : Left; // Left
        Left = Right > screenBounds.Right ? screenBounds.Right - Width : Left; // Right
        Top = Bottom > screenBounds.Bottom ? screenBounds.Bottom - Height : Top; // Bottom
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
    #endregion

    #region Accent Colour
    public static void UpdateAccentColor()
    {
        lock (openForms)
        {
            foreach (FormEx form in openForms)
            {
                form.Invoke((MethodInvoker)(() => form.SetAccentColor()));
            }
        }
    }

    private void SetAccentColor()
    {
        if (Settings.ReadBool(SettingsBoolType.UseAccentColor))
        {
            BackColor = AccentColorHelper.GetSystemAccentColor();
            return;
        }

        BackColor = Colours.ClrAppBorderDefault;
    }
    #endregion
}