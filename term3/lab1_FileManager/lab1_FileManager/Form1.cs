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
using System.IO.Compression;

namespace lab1_FileManager
{
   
    public partial class Form1 : Form
    {
        string path = "";
        string pathPrev = "";

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            LoadMain();
            
        }
        private string LoadMain()
        {
            path = "";
            pathPrev = "";
            GoToListBox1(DriveInfo.GetDrives().ToArray().Select(x => x.Name).ToArray());
            return "";
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new NewFile(path, this);
            form.ShowDialog();

        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new NewFolder(path, this);
            
            form.ShowDialog();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            if (path != "" && index == 0)
            {
                path = Directory.GetParent(path) == null ? LoadMain() :
                    Directory.GetParent(path).FullName;
            }
            else
            {
                pathPrev = path;
                if(path != "")if (path[path.Length - 1] != '\\' || path[path.Length - 1] != '/') path += '\\';
                path +=  listBox1.Items[index].ToString();
            }

            
            if (path != "")
            {
                if (Directory.Exists(path)) GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                else
                if(File.Exists(path))
                {
                    Form readText = new textReader(path);
                    readText.Show();
                    path = pathPrev;
                }else
                {
                    MessageBox.Show("Invalid file/folder path.The directory may have been deleted");
                    LoadMain();
                }
            }
        }
        public void GoToListBox1(String[] colect)
        {
            listBox1.Items.Clear();
            if(path != "")
            {
                listBox1.Items.Add("...");
            }
            foreach(var obj in colect)
            {
                listBox1.Items.Add(obj.Remove(0, path.Length + (path.Length >3 ? 1 : 0)));
            }
            listBox1.Update();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if(index <= 0)
            {
                MessageBox.Show("Deletion failed. The file/folder to delete is not selected.");
                return;
            }else
            {
                string delPath = path;
                if (delPath != "") if (delPath[delPath.Length - 1] != '\\' || delPath[delPath.Length - 1] != '/') delPath += '\\'; 
                delPath += listBox1.Items[index].ToString();
                if (Directory.Exists(delPath))
                {
                    try
                    {
                        Directory.Delete(delPath, true);
                    }catch(Exception ee)
                    {
                        MessageBox.Show("Deletion failed. The folder to delete is not exists.");
                    }
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
                else
                if (File.Exists(delPath))
                {
                    try
                    {
                        File.Delete(delPath);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Deletion failed. The file to delete is not exists.");
                    }
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
                else
                {
                    MessageBox.Show("Invalid file/folder path.The object may have been deleted");
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
            }

        }

        private void compressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index <= 0)
            {
                MessageBox.Show("Compressing failed. The file/folder to compress is not selected.");
                return;
            }
            else
            {
                string compressPath = path;
                if (compressPath != "") if (compressPath[compressPath.Length - 1] != '\\' || compressPath[compressPath.Length - 1] != '/') compressPath += '\\';
                string newCompressPath = compressPath;
                compressPath += listBox1.Items[index].ToString();

                if (File.Exists(compressPath))
                {
                    newCompressPath += listBox1.Items[index].ToString().Insert(
                        listBox1.Items[index].ToString().LastIndexOf('.') > 0 ? listBox1.Items[index].ToString().LastIndexOf('.') + 1 : (listBox1.Items[index].ToString().Length), "NEWCOMPRESSFILE");
                    if(File.Exists(newCompressPath))
                    {
                        MessageBox.Show("File with this name already compressed");
                        return;
                    }
                    try
                    {
                        using (FileStream sourceStream = new FileStream(compressPath, FileMode.OpenOrCreate))
                        {
                            using (FileStream targetStream = File.Create(newCompressPath))
                            {
                                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                                {
                                    sourceStream.CopyTo(compressionStream);
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Compressing failed. The file to compress is not exists.");
                    }
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
                else
                {
                    MessageBox.Show("Invalid file/folder path.The object may have been deleted");
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
            }
        }

        private void decompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index <= 0)
            {
                MessageBox.Show("Compressing failed. The file/folder to compress is not selected.");
                return;
            }
            else
            {
                string decompressPath = path;
                if (decompressPath != "") if (decompressPath[decompressPath.Length - 1] != '\\' || decompressPath[decompressPath.Length - 1] != '/') decompressPath += '\\';
                string newDecompressPath = decompressPath;
                decompressPath += listBox1.Items[index].ToString();
                MessageBox.Show(decompressPath);
                if (File.Exists(decompressPath))
                {
                    if(listBox1.Items[index].ToString().LastIndexOf("NEWCOMPRESSFILE") <= listBox1.Items[index].ToString().LastIndexOf('.'))
                    {
                        MessageBox.Show("This file not compressed");
                        return;
                    }
                    newDecompressPath += listBox1.Items[index].ToString().Remove(listBox1.Items[index].ToString().LastIndexOf("NEWCOMPRESSFILE"), "NEWCOMPRESSFILE".Length);
                    MessageBox.Show(newDecompressPath);
                    if (File.Exists(newDecompressPath))
                    {
                        MessageBox.Show("File with this name already decompressed");
                        return;
                    }
                    try
                    {
                        using (FileStream sourceStream = new FileStream(decompressPath, FileMode.OpenOrCreate))
                        {
                            using (FileStream targetStream = File.Create(newDecompressPath))
                            {
                                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                                {
                                    decompressionStream.CopyTo(targetStream);
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("decompressing failed. The file to compress is not exists.");
                    }
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
                else
                {
                    MessageBox.Show("Invalid file/folder path.The object may have been deleted");
                    GoToListBox1(Directory.GetDirectories(path).Concat(Directory.GetFiles(path)).ToArray());
                }
            }
        }
    }
}
