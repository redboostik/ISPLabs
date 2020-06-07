using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Task1
{
    class Program
    {
        public delegate void outToDisplay(string message);
        static outToDisplay print = outMessage;
        public delegate void AddingNewFavoriteCar();
        public static event AddingNewFavoriteCar FavoriteEvent;
        static public List<Auto> Cars = new List<Auto>
        {
            new Auto(((Volkswagen.ModelVolkswagen)1).ToString(), 973, 1661, 3830, 148, (Transport.typeTransport)4, 4, 5, 1420,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 3, 2, 55, 3000, 1198, 6)),
            new Auto(((Volkswagen.ModelVolkswagen)2).ToString(), 1248, 1699, 3988, 175, (Transport.typeTransport)4, 4, 5, 1453,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)2, 4, 2, 90, 2500, 1598, 4.6)),
            new Auto(((Volkswagen.ModelVolkswagen)3).ToString(), 1510, 1808, 4277, 224, (Transport.typeTransport)4, 4, 2, 1554,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 6, 3, 200, 5000, 1984, 6.5)),
            new Auto(((Volkswagen.ModelVolkswagen)4).ToString(), 1348, 1759, 4204, 184, (Transport.typeTransport)4, 4, 5, 1517,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 2, 102, 3800, 1595, 6)),
            new Auto(((Volkswagen.ModelVolkswagen)5).ToString(), 1502, 1778, 4643, 209, (Transport.typeTransport)4, 4, 4, 1532,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)4, 5, 4, 150, 3500, 1390, 5.2)),

            new Auto(((Mercedes_Benz.ModelMercedes_Benz)1).ToString(), 1406, 1781, 4293, 249, (Transport.typeTransport)4, 4, 5, 1415,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 4, 365, 5000, 1991, 6.2)),
            new Auto(((Mercedes_Benz.ModelMercedes_Benz)2).ToString(), 1500, 2010, 4359, 220, (Transport.typeTransport)4, 4, 5, 1549,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 3, 170, 3400, 2143, 5.9)),
            new Auto(((Mercedes_Benz.ModelMercedes_Benz)3).ToString(), 1730, 1795, 4707, 250, (Transport.typeTransport)4, 4, 4, 1430,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 4, 457, 5000, 6208, 12)),
            new Auto(((Mercedes_Benz.ModelMercedes_Benz)4).ToString(), 1795, 1770, 4702, 249, (Transport.typeTransport)4, 4, 5, 1633,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 4, 457, 5000, 6208, 12.2)),
            new Auto(((Mercedes_Benz.ModelMercedes_Benz)5).ToString(), 1995, 1901, 4763, 220, (Transport.typeTransport)4, 4, 4, 1615,
                (Auto.AutoType)2, new Auto.Engine((Auto.Engine.TypeEngine)2, 4, 2, 224, 2800, 2987, 8.5)),

            new Auto(((Ferrari.ModelFerrari)1).ToString(), 1255, 1992, 4702, 350, (Transport.typeTransport)4, 4, 2, 1000,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)4, 12, 4, 963, 6750, 6262, 10.5)),
            new Auto(((Ferrari.ModelFerrari)2).ToString(), 1080, 1709, 4234, 245, (Transport.typeTransport)4, 4, 2, 1382,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 6, 2, 195, 5500, 2419, 6.7)),
            new Auto(((Ferrari.ModelFerrari)3).ToString(), 1503, 1791, 4641, 254, (Transport.typeTransport)4, 4, 2, 1496,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 300, 4200, 3405, 7.2)),
            new Auto(((Ferrari.ModelFerrari)4).ToString(), 1630, 1908, 4562, 195, (Transport.typeTransport)4, 4, 2, 1605,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 489, 5000, 4297, 8.3)),
            new Auto(((Ferrari.ModelFerrari)5).ToString(), 1485, 1937, 4527, 325, (Transport.typeTransport)4, 4, 2, 1606,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 570, 6000, 4499, 7.8)),
        };

        static int EnterIntWithRange(int left, int right)
        {
            int index = 0;
            bool flag = true;
            while (flag)
            {
                flag = false;
                try
                {
                    index = Convert.ToInt32(Console.ReadLine());
                    if (index < left || index > right)
                    {
                        print($"Wrong input. Try Again in range {left}, {right} ");
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    flag = true;
                    print($"Wrong input. Try Again in range {left}, {right} ");
                }
            }
            return index;
        }

        static void InfoCars()
        {
            while (true)
            {
                print("Menu:\n1 info about cars\n2 full info by index\n4 set cost by index\n3 race\n5 sort Cars by average speed\n6 add favorite car\n7 delete favorite car\n8 info about favorite cars\n9 exit\n");
                int choose = EnterIntWithRange(1, 9);
                if (choose == 1)
                {
                    foreach (var x in Cars)
                    {
                        print(x.name);
                    }
                }
                else
                if (choose == 2)
                {
                    print("Enter index");
                    int index = EnterIntWithRange(0, Cars.Count - 1);
                    Cars[index].outInfo();
                }
                else
                if (choose == 3)
                {
                    print("Enter index of first car\n");
                    int firstIndex = EnterIntWithRange(0, Cars.Count - 1);
                    print("Enter index of first car\n");
                    int secondIndex = EnterIntWithRange(0, Cars.Count - 1);
                    int flagCheck = Cars[firstIndex].CompareTo(Cars[secondIndex]);
                    if (flagCheck == 1) print($"Win {Cars[firstIndex].name}\n");
                    if (flagCheck == -1) print($"Win {Cars[secondIndex].name}\n");
                    if (flagCheck == 0) print("The race ended in a draw\n");
                }
                else
                if (choose == 4)
                {
                    print("Enter index of car\n");
                    int index = EnterIntWithRange(0, Cars.Count - 1);
                    print($"Enter cost of car {Cars[index].name}\n");
                    int cost = EnterIntWithRange(0, 1000000000);
                    Cars[index].cost = cost;
                }
                else
                if (choose == 5)
                {
                    Cars.Sort();
                }
                else
                if(choose == 6)
                {
                    print("Enter index of favorite car\n");
                    int index = EnterIntWithRange(0, Cars.Count - 1);
                    FavoriteEvent += Cars[index].outInfo;

                }
                else
                if (choose == 7)
                {
                    print("Enter index of favorite car\n");
                    int index = EnterIntWithRange(0, Cars.Count - 1);
                    FavoriteEvent -= Cars[index].outInfo;

                }
                else
                if(choose == 8)
                {
                    print("Favorite cars:\n");
                    FavoriteEvent?.Invoke();
                }
                else break;
            }
        }

        public static void outMessage(string message) => Console.WriteLine(message);

        static void Main(string[] args)
        {
            InfoCars();
        }
    }
}
