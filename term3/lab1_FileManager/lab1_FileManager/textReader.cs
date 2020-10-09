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
    public partial class textReader : Form
    {
        string path = "";
        public textReader(string filePath)
        {
            path = filePath;
            InitializeComponent();
            FileStream myFile = File.OpenRead(path);
            byte[] info = new byte[myFile.Length];
            myFile.Read(info, 0, (int)myFile.Length);
            textBox1.Text = Encoding.ASCII.GetString(info);
            myFile.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream myFile = File.OpenWrite(path);
                byte[] info = Encoding.ASCII.GetBytes(textBox1.Text);
                myFile.Write(info, 0, info.Length);
                myFile.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't save file");
            }
        }
    }
}
