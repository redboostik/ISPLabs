using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Lab4Task2
{
    class Program
    {
        [DllImport("Dll1.dll")]
        public static extern void insert(int firstCorner, int secondCorner, int massEdge);
        [DllImport("Dll1.dll")]
        public static extern void setNumberCorners(int num);

        [DllImport("Dll1.dll")]
        public static extern void erase(int firstCorner, int secondCorner);
        [DllImport("Dll1.dll")]
        public static extern int getRast(int startCorner, int finishCorner);
        static void Main(string[] args)
        {
           
            while(true)
            {
                Console.WriteLine("Enter: \n1 to set number of corners\n2 add edge\n3 erase edge\n4 get distantion\n5 exit");

                int choose = 0;
                bool f = true;
                while(f)
                {
                    f = false;
                    try
                    {
                        choose = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        f = true;
                    }
                }
                if (choose == 1)
                {
                    int n = 0;
                    f = true;
                    while (f)
                    {
                        f = false;
                        try
                        {
                            n = Convert.ToInt32(Console.ReadLine());
                        }
                        catch(Exception)
                        {
                            f = true;
                        }
                    }
                    setNumberCorners(n);
                }
                else
                if (choose == 2)
                {
                    f = true;
                    while(f)
                    {
                        f = false;
                        int[] ins = new int[3];
                        try
                        {
                            string s = Console.ReadLine();              
                            string[] a = s.Split(' ').Where(substr => substr != " ").ToArray();

                            for(int i = 0; i < 3; i++)
                            {
                                ins[i] = Convert.ToInt32(a[i]);
                            }
                        }
                        catch(Exception)
                        {
                            f = true;
                        }
                        insert(ins[0], ins[1], ins[2]);
                    }
                }
                else
                if (choose == 3)
                {
                    f = true;
                    while (f)
                    {
                        f = false;
                        int[] ins = new int[2];
                        try
                        {
                            string s = Console.ReadLine();
                            string[] a = s.Split(' ').Where(substr => substr != " ").ToArray();

                            for (int i = 0; i < 2; i++)
                            {
                                ins[i] = Convert.ToInt32(a[i]);
                            }
                        }
                        catch (Exception)
                        {
                            f = true;
                        }
                        erase(ins[0], ins[1]);
                    }
                }
                else
                if (choose == 4)
                {
                    f = true;
                    while (f)
                    {
                        f = false;
                        int[] ins = new int[2];
                        try
                        {
                            string s = Console.ReadLine();
                            string[] a = s.Split(' ').Where(substr => substr != " ").ToArray();

                            for (int i = 0; i < 2; i++)
                            {
                                ins[i] = Convert.ToInt32(a[i]);
                            }
                        }
                        catch (Exception)
                        {
                            f = true;
                        }
                        getRast(ins[0], ins[1]);
                    }
                }
                else
                if(choose == 5)
                {
                    break;
                }
                
            }
        }
    }
}
