﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Task1
{
    public class Auto : Transport, IRace
    {
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
            Console.WriteLine(s);
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
