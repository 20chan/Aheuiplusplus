using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ageui__
{
    public partial class CodeEditor : UserControl
    {
        public CodeEditor(string text = "")
        {
            InitializeComponent();
            this.richTextBox1.Text = text;
        }

        public void Highlight()
        {
            
        }
    }
}
