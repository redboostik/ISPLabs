using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Task1
{
    class Mercedes_Benz : Auto
    {
        public ModelMercedes_Benz model;
        public enum ModelMercedes_Benz
        {
            A_Class = 1,
            B_Class = 2,
            C_Class = 3,
            E_Class = 4,
            V_Class = 5
        }

        public Mercedes_Benz(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newTypeTransport,
                    int newWheels, int newDoors, double newClearance, AutoType newType, Engine newEngine,
                    ModelMercedes_Benz newModel)
            : base(newName, newWeight, newWidth, newLength, newMaxSpeed, newTypeTransport,
                  newWheels, newDoors, newClearance, newType, newEngine)
        {
            model = newModel;
        }
    }
}
