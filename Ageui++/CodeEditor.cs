using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Ageui__
{
    public class CodeEditor : SyntaxHighlighter.SyntaxRichTextBox
    {
        public static Font SharedFont = new Font("나눔고딕코딩", 15);
        public CodeEditor(string text) : base()
        {
            this.Text = text;
            this.Font = SharedFont;
            ProcessAllLines();
        }
        
        public new String Text
        {
            get
            {
                int max = base.Lines.Max(s => s.TrimEnd().Length);
                return string.Join("\r\n",
                    (from l in base.Lines
                     select l.PadRight(max)));
            }

            set
            {
                base.Text = value;
            }
        }
    }
}
