using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OptionsManager
{
    public class JsonReader
    {
        JObject info;
        public JsonReader(string path)
        {

            string text = File.ReadAllText(path);
                info = JObject.Parse(text);
        }

        public T GetElement<T>(string element)
        {
            JToken tok = info[element];

            return tok.ToObject<T>();
        }
        public static T ToObj<T>(string text)
        {
            return JObject.Parse(text).ToObject<T>();
        }

    }   
}