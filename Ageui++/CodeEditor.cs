using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace Ageui__
{
    public class CodeEditor : RichTextBox
    {
        public static Font SharedFont;

        public CodeEditor(string text) : base()
        {
            this.Text = text;

            this.KeyDown += CodeEditor_KeyDown;
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

        private void CodeEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                int line = GetLineFromCharIndex(SelectionStart);
                int column = SelectionStart - GetFirstCharIndexFromLine(line);

                if(Lines[line].Skip(column).Count() == 0)
                {
                    SelectionLength = 0;
                    SelectedText = " ";
                    SelectionStart -= 1;
                }
            }
        }
    }
}
