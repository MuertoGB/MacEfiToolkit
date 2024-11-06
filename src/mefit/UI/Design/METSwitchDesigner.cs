// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METSwitchDesigner.cs
// Released under the GNU GLP v3.0

using System.Collections;
using System.Windows.Forms.Design;

namespace Mac_EFI_Toolkit.UI.Design
{
    public class METSwitchDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            string[] propList = new string[]
            {
                "Appearance",
                "BackgroundImage",
                "BackgroundImageLayout",
                "CheckAlign",
                "Font",
                "ForeColor",
                "FlatAppearance",
                "FlatStyle",
                "Image",
                "ImageAlign",
                "ImageIndex",
                "ImageKey",
                "ImageList",
                "RightToLeft",
                "Text",
                "TextAlign",
                "TextImageRelation",
                "UseVisualStyleBackColor",
                "Padding",
                "AutoEllipsis"
            };

            if (properties != null)
            {
                foreach (string item in propList)
                {
                    properties.Remove(item);
                }
            }

            base.PreFilterProperties(properties);
        }
    }
}