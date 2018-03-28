using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetPath()
        {
            //获取文件夹所在的位置,返回完整路径
            string FilePath;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return FilePath = dialog.SelectedPath;
            }
            else
            {
                return "wrong";
            }
        }

        private void GetNextFolder(string FilePath, List<string> FolderName, List<string> FolderFullName)
        {
            DirectoryInfo dir = new DirectoryInfo(FilePath);
            if (Directory.GetDirectories(FilePath).Length != 0)
            {
                foreach (DirectoryInfo f in dir.GetDirectories())
                {
                    FolderName.Add(f.Name);
                    FolderFullName.Add(f.FullName);
                }
            }
            else
            {
                foreach (FileInfo f in dir.GetFiles())
                {
                    FolderName.Add(f.Name);
                    FolderFullName.Add(f.FullName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> filesName = new List<string>();
            List<string> filesFullname = new List<string>();
            GetNextFolder(GetPath(), filesName, filesFullname);
            foreach(string f in filesName)
            {
                textBox1.Text = textBox1.Text + f;
            }
        }
    }
}
