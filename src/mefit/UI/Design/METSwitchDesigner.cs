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
        protected override void PreFilterProperties(IDictionary dictionary)
        {
            string[] properties = new string[]
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

            if (dictionary != null)
            {
                foreach (string property in properties)
                {
                    dictionary.Remove(property);
                }
            }

            base.PreFilterProperties(dictionary);
        }
    }
}