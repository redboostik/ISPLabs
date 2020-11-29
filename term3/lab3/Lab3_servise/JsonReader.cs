using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Framework
{
    public class JsonReader
    {
        JObject info;
        public JsonReader(string path)
        {
            string text = "";
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                text = System.Text.Encoding.Default.GetString(array);
            }
            info = JObject.Parse(text);
        }
        public T GetElement<T>(string element)
        {
            JToken tok = info[element];
            
            return tok.ToObject<T>();
        }




    }
}
