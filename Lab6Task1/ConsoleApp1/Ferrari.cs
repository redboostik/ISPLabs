using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Task1
{
    class Ferrari : Auto
    {
        public ModelFerrari model;
        public enum ModelFerrari
        {
            LaFerrari = 1,
            Dino = 2,
            Mondial = 3,
            California = 4,
            Italia = 5
        }

        public Ferrari(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newTypeTransport,
                    int newWheels, int newDoors, double newClearance, AutoType newType, Engine newEngine,
                    ModelFerrari newModel)
            : base(newName, newWeight, newWidth, newLength, newMaxSpeed, newTypeTransport,
                  newWheels, newDoors, newClearance, newType, newEngine)
        {
            model = newModel;
        }
    }
}
