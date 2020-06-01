using System;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');

            for(int i = ss.Length - 1; i >= 0; i--){

                Console.WriteLine(ss[i]);
            }

        }
    }
}
