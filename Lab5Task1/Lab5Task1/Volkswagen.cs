using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Task1
{
    class Volkswagen : Auto
    {
        ModelVolkswagen model;
        public enum ModelVolkswagen
        {
            Fox = 1,
            Polo = 2,
            Beetle = 3,
            Golf = 4,
            Jetta = 5
        }

        public Volkswagen(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newTypeTransport,
                    int newWheels, int newDoors, double newClearance, AutoType newType, Engine newEngine,
                    ModelVolkswagen newModel)
            :base(newName, newWeight, newWidth, newLength, newMaxSpeed, newTypeTransport,
                  newWheels, newDoors, newClearance, newType, newEngine)
        {
            model = newModel;
        }
    }


}
