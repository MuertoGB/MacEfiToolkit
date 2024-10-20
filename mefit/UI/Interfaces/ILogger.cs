using Mac_EFI_Toolkit;
using System.Windows.Forms;

public interface ILogger
{
    void WriteLog(RichTextBox rtbLog, string message, RtbLogPrefix prefix);
}