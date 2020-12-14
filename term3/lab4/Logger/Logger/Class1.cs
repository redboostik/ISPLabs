using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsManager;
using DataAccessLayer;
namespace Logger
{
    public class Logger
    {
        DataAccessLayer.DataAccessLayer DAL;
        public Logger(XmlReader xmlReader)
        {
            DAL = new DataAccessLayer.DataAccessLayer(xmlReader);
        }
        public Logger(JsonReader jsonReader)
        {
            DAL = new DataAccessLayer.DataAccessLayer(jsonReader);
        }
        public void Log(string message)
        {
            DAL.Log(DateTime.Now, message);
        }
    }
}
