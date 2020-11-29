using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Framework
{
    public class XMLReader
    {
        Dictionary<string, string> XmlElements = new Dictionary<string, string>();
        public XMLReader(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode node in root)
            {
                XmlElements.Add(node.Name, node.InnerText);
            }
        }

        public string GetElement(string name)
        {
            return XmlElements[name];
        }
    }
}
