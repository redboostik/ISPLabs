using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXmlGeneratorService
{
    public class SerializeXML
    {
        public string SerializeXmlWithXsd(object obj, string name)
        {
            return "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>\n<class xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"{name}\">" + SerializeXml(obj, 1) + "</class>";
        }
        public string SerializeXml(object obj)
        {
            return "<class>" + SerializeXml(obj, 1) + "</class>";
        }

        public string SerializeXsd(object obj)
        {
            return " <?xml version=\"1.0\" encoding=\"UTF - 8\"?>\n< xs:schema xmlns:xs = \"http://www.w3.org/2001/XMLSchema\" >\n< xs:element name = \"class\" >\n" +
                SerializeXsd(obj, 1) ;

        }
        public static string SerializeXml(object obj, int deep)
        {
            StringBuilder xml = new StringBuilder();

            var type = obj.GetType();

            if (type.IsPrimitive || type == typeof(string))
            {
                return xml.Append(obj.ToString()).ToString();
            }
            else

            if (type.GetInterface(nameof(IEnumerable)) != null)
            {
                xml.Append('\n');
                var index = 0;
                foreach (var item in (IEnumerable)obj)
                {
                    for (int i = 0; i < deep; i++) xml.Append('\t');
                    xml.Append($"<item{index}>{item}</item{index}>\n");
                    index++;
                }
                return xml.ToString();
            }
            else

            {
                xml.Append($"\n");
                var properties = type.GetProperties();
                var fields = type.GetFields();
                foreach (var property in properties)
                {

                    for (int i = 0; i < deep; i++) xml.Append('\t');
                    xml.Append($"<{property.Name}>");
                    xml.Append(SerializeXml(property.GetValue(obj), deep + 1));
                    if (xml[xml.Length - 1] == '\n') for (int i = 0; i < deep; i++) xml.Append('\t');
                    xml.Append($"</{property.Name}>\n");
                }
            }
            return xml.ToString();
        }

        public static string SerializeXsd(object obj, int deep)
        {
            StringBuilder xds = new StringBuilder();

            var type = obj.GetType();

            if (type.IsPrimitive || type == typeof(string))
            {
                return $" type = \"xs:{type.Name}\"/>\n";
            }
            else

            if (type.GetInterface(nameof(IEnumerable)) != null)
            {
                
                xds.Append(">\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("<xs:complexType>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("<xs:sequence>\n");
                var index = 0;
                foreach (var item in (IEnumerable)obj)
                {
                    for (int i = 0; i < deep; i++) xds.Append('\t');
                    xds.Append($"<xs:element name = \"item{index}\" type = \"xs:{item.GetType().Name}\" />\n");
                    index++;
                }
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:sequence>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:complexType>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:element>\n");
                
                return xds.ToString();
            }
            else

            { 
                xds.Append(">\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("<xs:complexType>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("<xs:sequence>\n");
                var properties = type.GetProperties();
                var fields = type.GetFields();
                foreach (var property in properties)
                {

                    for (int i = 0; i < deep; i++) xds.Append('\t');
                    xds.Append($"<xs:element name = \"{property.Name}\"");
                    xds.Append(SerializeXsd(property.GetValue(obj), deep + 1));
                }
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:sequence>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:complexType>\n");
                for (int i = 1; i < deep; i++) xds.Append('\t');
                xds.Append("</xs:element>\n");
            }
            return xds.ToString();
        }
    }
}

