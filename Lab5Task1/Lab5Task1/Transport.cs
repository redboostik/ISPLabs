using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Task1
{
    public class Transport
    {
        public static int countTransport = 0;
        private static int idCount = 0;
        public string name { get; set; }
        public int idTransport { get; private set; }
        public int weight { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public int maxSpeed { get; set; }
        public typeTransport type { get; set; }
        public enum typeTransport
        {
            air = 1,
            water = 2,
            space = 3,
            land = 4
        }

        public int passengers { get; set; }
        public DateTime year { get; set; }
        public double cost { set; get; }
        public Transport()
        {

        }
        public Transport(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newType)
        {
            name = newName;
            idTransport = idCount;
            idCount++;
            countTransport++;
            weight = newWeight;
            width = newWidth;
            length = newLength;
            maxSpeed = newMaxSpeed;
            type = newType;
            year = new DateTime(1);
            cost = -1;
            passengers = -1;
        }
        public Transport(string newName, int newWeight, double newWidth, double newLength, int newMaxSpeed, typeTransport newType,
                            int newPassengers, DateTime newYear, double newCost)
            : this(newName, newWeight, newWidth, newLength, newMaxSpeed, newType)
        {
            passengers = newPassengers;
            year = newYear;
            cost = newCost;
        }

        public virtual void outInfo()
        {
            Console.WriteLine($"Name: {name}\n");
            Console.WriteLine($"Id: {idTransport}\n");
            Console.WriteLine($"Weight: {weight}\n");
            Console.WriteLine($"Width: {width}\n");
            Console.WriteLine($"Legth: {length}\n");
            Console.WriteLine($"Max speed: {maxSpeed}\n");
            Console.WriteLine($"Type: {type}\n");
            Console.WriteLine("Passengers: " + (passengers == -1 ? " unknown" : passengers.ToString()) + '\n');
            Console.WriteLine("Year: " + (year.Year == 1 ? " unknown" : year.Year.ToString()) + '\n');
            Console.WriteLine("Cost: " + (cost == -1 ? " unknown" : cost.ToString() + '\n'));


        }
    }
}
