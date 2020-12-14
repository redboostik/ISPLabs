using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Info
    {
        Address address { get; set; }
        AddressType addressType { get; set; }
        BusinessEntity businessEntity { get; set; }
        BusinessEntityAddress businessEntityAddress { get; set; }
        BusinessEntityContact businessEntityContact { get; set; }
        public Info(Address add, AddressType addT, BusinessEntity buE, BusinessEntityAddress buEAdd,BusinessEntityContact buECon)
        {
            address = add;
            addressType = addT;
            businessEntity = buE;
            businessEntityAddress = buEAdd;
            businessEntityContact = buECon;
        }
    }
}
