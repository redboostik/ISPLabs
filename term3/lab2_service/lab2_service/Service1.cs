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
            LoadInfo();
            var myTimer = new Timer(1000);
            myTimer.Elapsed += new ElapsedEventHandler(MyTimer_Elapsed);
            myTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            PushInfo();
        }
        static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var pathSourse = "C:\\SourceDirectory";
            var dirs = Directory.GetFiles(pathSourse);
            foreach (var s in dirs)
            {
                var ss = "";
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
                    var sStream = new FileStream(s, FileMode.Open);
                    var tStream = File.Create(ss);
                    sStream.CopyTo(tStream);
                    sStream.Close();
                    tStream.Close();
                    var sourceStream = new FileStream(ss, FileMode.OpenOrCreate);
                    sourceStream.Read(array, 0, array.Length);
                    sourceStream.Close();

                    int iterator = 0;
                    while (array[iterator] != (char)0) iterator++;
                    var secret = new Encryption();
                    var buffer = Encoding.ASCII.GetBytes(secret.Encrypt(Encoding.UTF8.GetString(array, 0, iterator)));
                    var sS = new FileStream(ss, FileMode.Create);
                    sS.Write(buffer, 0, buffer.Length);
                    sS.Close();
                    var arch = new Archivator(ss);
                    arch.Compressing();
                }
            }
        }

        static void LoadInfo()
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
        static void PushInfo()
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
