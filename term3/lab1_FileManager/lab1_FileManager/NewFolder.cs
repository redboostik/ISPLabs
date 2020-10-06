using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab1_FileManager
{
    public partial class NewFolder : Form
    {
        string path = "";
        Form1 parent;
        public NewFolder(string parentPath, Form1 p)
        {
            parent = p;
            path = parentPath;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                MessageBox.Show("You can't create file in this directory");
                this.Close();
                return;
            }
            if (textBox1.Text == "" || textBox1.Text.Contains("\\") || textBox1.Text.Contains("/") || textBox1.Text.Contains(":") || textBox1.Text.Contains("?") || textBox1.Text.Contains("\"") || textBox1.Text.Contains("<") || textBox1.Text.Contains(">") )
            {
                MessageBox.Show("Wrong Name");
                return;
            }
            if (Directory.Exists(path + "\\" + textBox1.Text))
            {
                MessageBox.Show("Directory with this name already exists");
                return;
            }
            Directory.CreateDirectory(path + "\\" + textBox1.Text);
            parent.GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
            this.Close();
        }
    }
}
