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
        }

        public MainForm(string file) : this()
        {
            Open(file);
        }

        private void Error(string text)
        {
            MessageBox.Show(text, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Open(string file)
        {
            if(!File.Exists(file))
            {
                Error("파일이 존재하지 않습니다!");
                return;
            }
            if(_openedFiles.Contains(file))
            {
                Error("이미 파일이 열려있습니다!");
                return;
            }

            _openedFiles.Add(file);
            AddTabPage(file);
        }

        private void AddTabPage(string file)
        {
            CodeEditor c = new CodeEditor(File.ReadAllText(file));
            c.Dock = DockStyle.Fill;
            TabPage t = new TabPage(Path.GetFileName(file));
            t.Controls.Add(c);
            this.tabControl1.TabPages.Add(t);
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
    }
}
