// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Prompts.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common.Constants;
using Mac_EFI_Toolkit.UI;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.Forms
{
    internal class Prompts
    {
        internal static DialogResult ShowPatchFailedPrompt(Form owner)
        {
            return METPrompt.Show(
                owner,
                EFISTRINGS.FIRMWARE_MOD_FAILED_LOG,
                METPrompt.PType.Warning,
                METPrompt.PButtons.YesNo);
        }

        internal static DialogResult ShowPathSuccessPrompt(Form owner)
        {
            return METPrompt.Show(
                owner,
                EFISTRINGS.FIRMWARE_MOD_SUCCESS_SAVE,
                METPrompt.PType.Question,
                METPrompt.PButtons.YesNo);
        }
    }
}
