
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

using System.Threading.Tasks;

namespace OptionsManager
{
    public class JsonReader
    {
            
        Dictionary<string, object> info;
        public JsonReader(string path)
        {

            string text = "";
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                text = Encoding.UTF8.GetString(array);
            }
            info = ToObj<Dictionary<string, object>>(text);

        }

        public T GetElement<T>(string element)
        {
            return ToObj<T>(info[element].ToString());
        }


        private static T ToObj<T>(string textJson)
        {

            return JsonSerializer.Deserialize<T>(textJson);
        }

    }
}
