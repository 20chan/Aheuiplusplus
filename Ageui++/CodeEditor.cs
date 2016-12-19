using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Ageui__
{
    public class CodeEditor : RichTextBox
    {
        public static Font SharedFont = new Font("나눔고딕코딩", 15);
        public readonly static Dictionary<string, Color> HighlightRules = new Dictionary<string, Color>()
        {
            { "[바-빟]", Color.Blue },
            { "[마-밓]", Color.Red },
            { "[하-힣]", Color.Gray },
        };

        public CodeEditor(string text) : base()
        {
            this.Text = text;

            this.KeyDown += CodeEditor_KeyDown;
            this.TextChanged += CodeEditor_TextChanged;
            this.Font = SharedFont;
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

        private void CodeEditor_TextChanged(object sender, EventArgs e)
        {
            Highlight();
        }

        private void Highlight()
        {
            int selected = SelectionStart;
            SelectAll();
            SelectionColor = Color.Black;
            SelectionBackColor = Color.White;
            foreach (var key in HighlightRules)
            {
                var ms = Regex.Matches(base.Text, key.Key);
                foreach (Match m in ms)
                {
                    Select(m.Index, m.Length);
                    SelectionColor = key.Value;
                }
            }
            SelectionStart = selected;
        }
    }
}
