using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using OptionsManager;
using Models;
namespace ServiceLayer
{
    public class ServiceLayer
    {
        DataAccessLayer.DataAccessLayer DAL;
        public ServiceLayer(XmlReader xml)
        {
            DAL = new DataAccessLayer.DataAccessLayer(xml);
        }
        public ServiceLayer(JsonReader json)
        {
            DAL = new DataAccessLayer.DataAccessLayer(json);
        }

        public Info GetInfo(int id)
        {
            
            var businessEntity =  DAL.GetBusinessEntity(id);

            var businessEntityAddresses = DAL.GetBusinessEntityAddresses();
            var businessEntityAddress = businessEntityAddresses.SingleOrDefault(x => x.BusinessEntityID == businessEntity.BusinessEntityID);

            var addresses = DAL.GetAddresses();
            var address = addresses.SingleOrDefault(x => x.AddressID == businessEntityAddress.AddressID);

            var addressTypes = DAL.GetAddressTypes();
            var addressType = addressTypes.SingleOrDefault(x => x.AddressTypeID == businessEntityAddress.AddressTypeID);

            var businessEntityContacts = DAL.GetBusinessEntityContacts();
            var businessEntityContact = businessEntityContacts.SingleOrDefault(x => x.BusinessEntityID == businessEntity.BusinessEntityID);

            return new Info(address, addressType, businessEntity, businessEntityAddress, businessEntityContact);
        }

        
    }
}
