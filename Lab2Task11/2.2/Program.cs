using System;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] exclusionDictionary = { ",", "...", "!", "?", ":", ";", ".", "-"};

            string myString = Console.ReadLine();
            string[] splitString = myString.Split(' ');

            for (int i = 0; i < splitString.Length; i++) {

                int exclusionIterator = 0;

                for(int j = 0; j < exclusionDictionary.Length; j++) {

                    bool exclusionFlag = true;

                    for(int k = 0; k < exclusionDictionary[j].Length; k++)
                        if(splitString[i][splitString[i].Length - 1 - k] != exclusionDictionary[j][k]) {

                            exclusionFlag = false;
                    }

                    exclusionIterator = j;
                    if (exclusionFlag) break;
                }

                if (splitString[i][splitString[i].Length - 1] == exclusionDictionary[exclusionIterator][0]) {

                    Console.Write(exclusionDictionary[exclusionIterator]);
                }

                Console.WriteLine(splitString[i]);
            }

        }
    }
}
