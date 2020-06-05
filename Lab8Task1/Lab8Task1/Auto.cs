using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Task1
{
    public class Auto : Transport, IRace
    {
        private static Program.outToDisplay print = Program.outMessage;
        public double speed { get; }
        const int constMass = 1000;
        const int constPower = 1000;
        public double AverageSpeed(int skill)
        {
            return (constMass / weight + constPower / engine.power + skill / 100) * maxSpeed;
        }

        public int CompareTo(IRace x)
        {
            if (this.AverageSpeed(0) == x.AverageSpeed(0)) return 0;
            return (this.AverageSpeed(0) > x.AverageSpeed(0) ? 1 : -1);
        }
        public void winner(string nameFirstCar, int speedFirstCar, string nameSecondCar, int speedSecondCar)
        {
            string s = "";
            if (speedFirstCar > speedSecondCar) s = nameFirstCar + " win\n";
            if (speedFirstCar < speedSecondCar) s = nameSecondCar + " win\n";
            if (speedFirstCar == speedSecondCar) s = "the race ended in a draw\n";
            print(s);
        }
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
            : base(newName, newWeight, newWidth, newLength, newMaxSpeed, newTypeTransport)
        {
            wheels = newWheels;
            doors = newDoors;
            clearance = newClearance;
            type = newType;
            engine = newEngine;
            speed = AverageSpeed(0);
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

            public Engine(TypeEngine newType, int newCylinders, int newValves, int newPower, int newTorque, double newVolume, double newConsumption)
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
                print($"Type: {type}\n");
                print($"Cylinders: {cylinders}\n");
                print($"Valves: {valves}\n");
                print($"Power: {power}\n");
                print($"Torque: {torque}\n");
                print($"Volume: {volume}\n");
                print($"Consumption: {consumption}\n");
            }
        }

        public override void outInfo()
        {
            base.outInfo();
            print($"Wheels: {wheels}\n");
            print($"Doors: {doors}\n");
            print($"Clearance: {clearance}\n");
            print($"type: {type}\n");
            engine.info();
        }
    }
}
