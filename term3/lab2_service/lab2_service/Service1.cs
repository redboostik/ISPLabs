using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace lab2_service
{
    public partial class Service1 : ServiceBase
    {
        private static Dictionary<string, bool> dict = new Dictionary<string, bool>();
        static byte[] array = new byte[100000];
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            loadInfo();
            Timer myTimer = new Timer(1000);
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
            pushInfo();
        }

        protected override void OnStop()
        {
        }
        static void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string pathSourse = "C:\\SourceDirectory";
            string[] dirs = Directory.GetFiles(pathSourse);
            foreach (var s in dirs)
            {
                string ss;
                if (!dict.ContainsKey(s))
                {
                    dict.Add(s, true);
                    ss = "C:\\TargetDirectory" + s.Remove(0, pathSourse.Length);
                    ss = ss.Replace('_', '\\');
                    string[] splitSS = ss.Split('\\').Where(x => x.Length != 0 && x.Length < 100).ToArray();
                    string fold = "";
                    for (int i = 0; i < splitSS.Length - 1; i++)
                    {
                        if (i != 0) fold += '\\';
                        fold += splitSS[i];
                        if (!Directory.Exists(fold))
                        {
                            Directory.CreateDirectory(fold);
                        }
                    }
                    FileStream sStream = new FileStream(s, FileMode.Open);
                    FileStream tStream = File.Create(ss);
                    sStream.CopyTo(tStream);
                    sStream.Close();
                    tStream.Close();
                    FileStream sourceStream = new FileStream(ss, FileMode.OpenOrCreate);
                    sourceStream.Read(array, 0, array.Length);
                    int iterator = 0;
                    sourceStream.Close();

                    while (array[iterator] != (char)0) iterator++;
                    Encryption secret = new Encryption();
                    byte[] buffer = Encoding.ASCII.GetBytes(secret.encryption(Encoding.UTF8.GetString(array, 0, iterator)));
                    FileStream sS = new FileStream(ss, FileMode.Create);
                    sS.Write(buffer, 0, buffer.Length);
                    sS.Close();
                    Archivator arch = new Archivator(ss);
                    arch.compressing();
                }
            }
        }

        static void loadInfo()
        {
            string path = "C:\\TargetDirectory\\base.info";
            FileStream sourceStream = new FileStream(path, FileMode.OpenOrCreate);

            try
            {

                sourceStream.Read(array, 0, array.Length);
                sourceStream.Close();
                string s = Encoding.UTF8.GetString(array, 0, array.Length);
                foreach (string ss in s.Split('\n').Where(x => x.Length != 0 && x.Length < 100).ToArray())
                {

                    dict.Add(ss, true);
                }
                Console.WriteLine("Loading Complite");
            }
            catch
            {
                Console.WriteLine("Loading failed");
            }
        }
        static void pushInfo()
        {
            string path = "C:\\TargetDirectory\\base.info";
            string s = "";
            foreach (var ss in dict.ToArray())
                if (ss.Value == true)
                {
                    if (s.Length != 0) s += '\n';
                    s += ss.Key;
                }

            byte[] buffer = Encoding.ASCII.GetBytes(s);
            FileStream sourceStream = new FileStream(path, FileMode.Create);
            sourceStream.Write(buffer, 0, buffer.Length);
            sourceStream.Close();
        }
    }
}
