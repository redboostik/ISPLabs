using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Task1
{
    abstract public class Auto : Transport
    {
        public int wheels { get; set; }
        public int doors { get; set; }
        public double clearance { get; set; }
        public AutoType type { get; set; }
        public Engine engine { get; set; }
        public enum AutoType
        {
            truck = 1,
            bus = 2,
            car = 3

        }

        public Auto()
        {

        }

        public Auto(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newTypeTransport,
                    int newWheels, int newDoors, double newClearance, AutoType newType, Engine newEngine)
            :base (newName, newWeight, newWidth, newLength, newMaxSpeed, newTypeTransport)
        {
            wheels = newWheels;
            doors = newDoors;
            clearance = newClearance;
            type = newType;
            engine = newEngine;
        }
        public struct Engine
        {
            public enum TypeEngine
            {
                petrol = 1,
                diesel = 2,
                electric = 3,
                Hybrid = 4
            }


            public TypeEngine type { get; set; }

            public int cylinders, valves, power, torque;
            public double volume, consumption;

            public Engine(TypeEngine newType, int newCylinders, int newValves, int newPower, int newTorque, double newVolume, double newConsumption )
            {
                type = newType;
                cylinders = newCylinders;
                valves = newValves;
                power = newPower;
                torque = newTorque;
                volume = newVolume;
                consumption = newConsumption;
            }
            public void info()
            {
                Console.WriteLine($"Type: {type}\n");
                Console.WriteLine($"Cylinders: {cylinders}\n");
                Console.WriteLine($"Valves: {valves}\n");
                Console.WriteLine($"Power: {power}\n");
                Console.WriteLine($"Torque: {torque}\n");
                Console.WriteLine($"Volume: {volume}\n");
                Console.WriteLine($"Consumption: {consumption}\n");
            }
        }

        public override void outInfo()
        {
            base.outInfo();
            Console.WriteLine($"Wheels: {wheels}\n");
            Console.WriteLine($"Doors: {doors}\n");
            Console.WriteLine($"Clearance: {clearance}\n");
            Console.WriteLine($"type: {type}\n");
            engine.info();
        }
    }
}
