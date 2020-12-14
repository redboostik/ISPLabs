using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OptionsManager
{
    public class XmlReader
    {
        Dictionary<string, string> XmlElements = new Dictionary<string, string>();
        public XmlReader(string path)
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
