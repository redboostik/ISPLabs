using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsManager;
namespace FileManager
{
    public class FileManager
    {
        string TargetDirectory { get; set; }
        string FileName { get; set; }
        public FileManager(XmlReader xmlReader)
        {
            TargetDirectory = xmlReader.GetElement("TargetDirectory");
            FileName = xmlReader.GetElement("FileName");
        }
        public FileManager(JsonReader jsonReader)
        {
            TargetDirectory = jsonReader.GetElement<string>("TargetDirectory");
            FileName = jsonReader.GetElement<string>("FileName");
        }
        public FileManager CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
            return this;
        }
        public FileManager CreateFile(string path)
        {
            File.Create(path);
            return this;
        }
        public FileManager AddText(string path,string text)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(text);
            }
            return this;
        }
        public void AddTextToFile(string text)
        {
            CreateDirectory(TargetDirectory).CreateFile($"{TargetDirectory}\\{FileName}.txt").AddText($"{TargetDirectory}\\{FileName}.txt", text);
            return;
        }
    }
}
