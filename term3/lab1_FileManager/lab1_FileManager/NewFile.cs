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
    public partial class NewFile : Form
    {
        string path = "";
        Form1 parent;
        public NewFile(string parentPath, Form1 p)
        {
            path = parentPath;
            parent = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPath = path + "\\" + textBox1.Text;
            if(path == "")
            {
                MessageBox.Show("You can't create file in this directory");
                this.Close();
                return;
            }
            if (textBox1.Text == "" || (!textBox1.Text.Contains(".") && textBox1.Text[textBox1.Text.Length -1] != '.') || textBox1.Text.Contains("\\")  || textBox1.Text.Contains("/") || textBox1.Text.Contains(":") || textBox1.Text.Contains("?") || textBox1.Text.Contains("\"") || textBox1.Text.Contains("<") || textBox1.Text.Contains(">"))
            {
                MessageBox.Show("Wrong Name");
                return;
            }
            if(File.Exists(path + "/" + textBox1.Text))
            {
                MessageBox.Show("File with this name already exists");
                return;
            }
            
            FileStream file = File.Create(path + "\\" + textBox1.Text);
            file.Close();

            parent.GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
            this.Close();
        }
    }
}
