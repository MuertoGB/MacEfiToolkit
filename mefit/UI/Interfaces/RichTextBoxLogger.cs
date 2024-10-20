using Mac_EFI_Toolkit;
using System.Windows.Forms;

public class RichTextBoxLogger : ILogger
{
    public void WriteLog(RichTextBox rtbLog, string message, RtbLogPrefix prefix)
    {
        // If rtbLog is nothing, skip logging data.
        if (rtbLog == null)
        {
            return;
        }

        // Log the message to the RichTextBox
        Logger.WriteLogTextToRtb(message, prefix, rtbLog);
    }
}