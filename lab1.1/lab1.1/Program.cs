using System;
using System.Linq;

namespace lab1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_ARRAY = 1001;

            int[] weight = new int[MAX_ARRAY];
            int[] worth = new int[MAX_ARRAY];
            int[] carring = new int[MAX_ARRAY * MAX_ARRAY];
            int n = 0, max_carring = 0, res = 0;
            bool flag = true;

            //input n
            Console.WriteLine("n: ");

            while (flag) {

                flag = false;

                try {

                    n = Convert.ToInt32(Console.ReadLine());
                    if (n >= MAX_ARRAY) flag = true;

                } catch (Exception) { 

                    Console.WriteLine("Wrong input. Try again");
                    flag = true;

                }
            }

            //input max_carryng
            Console.WriteLine("max carring : ");

            flag = true;

            while (flag) {

                flag = false;

                try {

                    max_carring = Convert.ToInt32(Console.ReadLine());
                    if (max_carring > MAX_ARRAY * MAX_ARRAY) flag = true;

                } catch (Exception) {

                    Console.WriteLine("Wrong input. Try again");
                    flag = true;

                }
            }

            //input weight
            Console.WriteLine("weight of items ");

            flag = true;

            while(flag) {

                flag = false;

                try {

                    string s = Console.ReadLine();
                    string[] splitS = s.Split(' ').Where( substr => substr != " ").ToArray();

                    for(int i = 0; i < splitS.Length; i++) {

                        weight[i] = Convert.ToInt32( splitS[i]);
                    }

                } catch (Exception) {

                    Console.WriteLine("Wrong input. Try again");
                    flag = true;
                }
            }

            //input worth
            Console.WriteLine("worth of items:");

            flag = true;

            while (flag) {

                flag = false;

                try {

                    string s = Console.ReadLine();
                    string[] splitS = s.Split(' ').Where(substr => substr != " ").ToArray();

                    for (int i = 0; i < splitS.Length; i++) {

                        worth[i] = Convert.ToInt32(splitS[i]);
                    }

                } catch (Exception) {

                    Console.WriteLine("Wrong input. Try again");
                    flag = true;

                }
            }

            carring[0] = 1;

            for (int i = 0; i < n; i++){

                for (int j = max_carring - 1; j >= 0; j--) {

                    if (carring[j] > 0 && j + weight[i] <= max_carring) {

                        carring[ j + weight[i]] = Math.Max( carring[j + weight[i]], carring[j] + worth[i]);
                    }
                }
            }

            for (int i = 0; i <= max_carring; i++) res = Math.Max(res, carring[i]);

            Console.WriteLine(res - 1);
        }


    }
}
