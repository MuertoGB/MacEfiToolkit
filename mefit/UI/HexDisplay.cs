using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.UI
{
    class HexDisplay
    {
        internal static void HexDump(byte[] bin, RichTextBox rtb)
        {
            var encoding = Encoding.UTF8;
            var sb = new StringBuilder();

            for (int i = 0; i < bin.Length; i += 16)
            {
                rtb.SelectionColor = Color.FromArgb(0, 120, 180);
                rtb.AppendText($"{i:X8}h: ");

                for (int j = i; j < i + 16; j++)
                {
                    if (j < bin.Length)
                    {
                        byte b = bin[j];
                        sb.Append($"{b:X2} ");
                        rtb.SelectionColor = Color.White;
                        rtb.AppendText($"{b:X2} ");
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                }

                sb.Append("  ");
                rtb.SelectionColor = Color.Green;

                for (int j = i; j < i + 16 && j < bin.Length; j++)
                {
                    byte b = bin[j];
                    if (b >= 0x20 && b <= 0x7e)
                    {
                        sb.Append(encoding.GetString(new[] { b }));
                        rtb.SelectionColor = Color.Tomato;
                        rtb.AppendText(encoding.GetString(new[] { b }));
                    }
                    else
                    {
                        sb.Append(".");
                        rtb.SelectionColor = Color.FromArgb(100, 100, 100);
                        rtb.AppendText(".");
                    }
                }

                sb.Append(Environment.NewLine);
                rtb.AppendText(Environment.NewLine);
            }
        }

    }
}
