using System;
using System.Collections.Generic;
using IXmlGeneratorService;
using Models;
using OptionsManager;
using ServiceLayer;
using Logger;
namespace DataManager
{
    class Program
    {
        static void Main()
        {
            var jsonReader = new JsonReader("data.json");
            var service = new ServiceLayer.ServiceLayer(jsonReader);
            var listIdInfo = jsonReader.GetElement<List<int>>("IDs");
            var xmlGenerator = new SerializeXML();
            var fileWriter = new FileManager.FileManager(jsonReader) ;
            var logger = new Logger.Logger(jsonReader);
            foreach(var id in listIdInfo)
            {
                logger.Log($"getting Info_{id}");
                var item = service.GetInfo(id);
                logger.Log($"generate xml and xsd");
                var xml = xmlGenerator.SerializeXmlWithXsd(item, $"Info_{id}");
                var xsd = xmlGenerator.SerializeXsd(item);
                logger.Log($"create Info_{id}.xml and xsd");
                fileWriter.FileName = $"Info_{id}.xml";
                fileWriter.AddTextToFile(xml);
                fileWriter.FileName = $"Info_{id}.xsd";
                fileWriter.AddTextToFile(xsd);
            }
        }
    }
}
