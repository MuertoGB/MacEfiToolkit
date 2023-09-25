// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// UI Components
// METRadioButtonDesigner.cs
// Released under the GNU GLP v3.0

using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.Design;

namespace Mac_EFI_Toolkit.UI.Design
{
    class METRadioButtonDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary Properties)
        {
            List<string> PropList = new List<string>
            {
                "Appearance",
                "BackgroundImage",
                "BackgroundImageLayout",
                "CheckAlign",
                "FlatAppearance",
                "FlatStyle",
                "Image",
                "ImageAlign",
                "ImageIndex",
                "ImageKey",
                "ImageList",
                "RightToLeft",
                "TextAlign",
                "TextImageRelation",
                "UseVisualStyleBackColor",
                "Padding",
                "AutoEllipsis"
            };

            if (Properties != null)
            {
                foreach (string Item in PropList)
                {
                    Properties.Remove(Item);
                }
            }

            base.PreFilterProperties(Properties);
        }
    }
}