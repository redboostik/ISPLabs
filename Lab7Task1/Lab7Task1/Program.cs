using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Lab7Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RationalNumber> numbers = new List<RationalNumber>
            {
                new RationalNumber("123.123"),
                new RationalNumber("100.123"),
                new RationalNumber("1.0"),
                new RationalNumber("3"),
                new RationalNumber("15/3"),
            };
            Console.WriteLine(numbers[0] == numbers[1]);
            Console.WriteLine(numbers[0] <= numbers[1]);
            Console.WriteLine(numbers[0] >= numbers[1]);
            Console.WriteLine(numbers[0] != numbers[1]);

            Console.WriteLine(numbers[0] > numbers[1]);
            Console.WriteLine(numbers[0] < numbers[1]);

            numbers.Sort();

            foreach(var x in numbers)
            {
                Console.WriteLine(x.ToStringDouble());
            }

            RationalNumber r1 = new RationalNumber("123.123");
            RationalNumber r2 = new RationalNumber("100.123");

            Console.WriteLine((r1 + r2).ToStringDouble());
            Console.WriteLine((r1 - r2).ToStringDouble());
            Console.WriteLine((r1 * r2).ToStringDouble());
            Console.WriteLine((r1 / r2).ToStringDouble());

            Console.WriteLine(r1.ToStringDouble());
            Console.WriteLine(r1.ToStringInt());
            Console.WriteLine(r1.ToStringRational());
            Console.WriteLine(r1.Equals(r2));
            Console.WriteLine(r1.GetHashCode());

            int intNumber = 10;

            Console.WriteLine((r1 + intNumber).ToStringDouble());
            Console.WriteLine((r1 - intNumber).ToStringDouble());
            Console.WriteLine((r1 * intNumber).ToStringDouble());
            Console.WriteLine((r1 / intNumber).ToStringDouble());

            long longNumber = 10;

            Console.WriteLine((r1 + longNumber).ToStringDouble());
            Console.WriteLine((r1 - longNumber).ToStringDouble());
            Console.WriteLine((r1 * longNumber).ToStringDouble());
            Console.WriteLine((r1 / longNumber).ToStringDouble());

            double doubleNumber = 10.4;

            Console.WriteLine((r1 + doubleNumber).ToStringDouble());
            Console.WriteLine((r1 - doubleNumber).ToStringDouble());
            Console.WriteLine((r1 * doubleNumber).ToStringDouble());
            Console.WriteLine((r1 / doubleNumber).ToStringDouble());


        }
    }
}
