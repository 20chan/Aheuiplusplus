using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aheui__;

namespace Ageui__
{
    public partial class MainForm : Form
    {
        List<string> _openedFiles;
        public MainForm()
        {
            InitializeComponent();
            _openedFiles = new List<string>();

#if DEBUG
            Open("D:\\test.aheui");
#endif
        }

        public MainForm(string[] files) : this()
        {
            Open(files);
        }

        private void Error(string text)
        {
            MessageBox.Show(text, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Open(params string[] files)
        {
            foreach(var file in files)
            {
                if (!File.Exists(file))
                {
                    Error("파일이 존재하지 않습니다!");
                    return;
                }
                if (_openedFiles.Contains(file))
                {
                    Error("이미 파일이 열려있습니다!");
                    return;
                }

                _openedFiles.Add(file);
                AddTabPage(file);
            }
        }

        private void AddTabPage(string file)
        {
            CodeEditor c = new CodeEditor(File.ReadAllText(file, Encoding.UTF8));
            c.Dock = DockStyle.Fill;
            TabPage t = new TabPage(Path.GetFileName(file));
            t.Controls.Add(c);
            this.tabControl1.TabPages.Add(t);

            this.treeView1.Nodes[0].Nodes.Add(Path.GetFileName(file));
        }

        private string GetCurrentScript()
        {
            return ((RichTextBox)tabControl1.SelectedTab.Controls[0].Controls[0]).Text;
        }

        private void Run()
        {
            IntAheui aheui = new IntAheui(GetCurrentScript(), false);
        }

        private void StartDebug()
        {

            IntAheui aheui = new IntAheui(GetCurrentScript(), true);
        }

        private void 폰트FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                CodeEditor.SharedFont = fontDialog1.Font;
                foreach(TabPage p in tabControl1.TabPages)
                {
                    p.Controls[0].Font = fontDialog1.Font;
                }
            }
        }
    }
}
