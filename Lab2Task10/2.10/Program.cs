using System;

namespace _2._10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(get_double());
        }


        static double get_double()
        {
            double res = 0, devision = 1;
            string myString;
            int minusSign = 1;
            int i = 0;
            bool flagdevision = false;

            myString = Console.ReadLine();

            if (myString[i] == '-') {

                minusSign = -1;
                i++;
            }

            for (; i < myString.Length; i++)
                if (myString[i] >= '0' && myString[i] <= '9') {

                    res *= 10;
                    res += myString[i] - '0';

                    if (flagdevision) {

                        devision *= 10;
                    }
                } else {

                    if (myString[i] == '.') {

                        flagdevision = true;
                    }else {

                        Console.WriteLine("Wrong input, try again.");
                        return get_double();
                    }

                }

            return res / devision * minusSign;
        }
    }
}
