using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Task1
{
    class Program
    {

        static public List<Volkswagen> volkswagenCars = new List<Volkswagen>
        {
            new Volkswagen((Volkswagen.ModelVolkswagen)1 + " i", 973, 1661, 3830, 148, (Transport.typeTransport)4, 4, 5, 1420,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 3, 2, 55, 3000, 1198, 6), (Volkswagen.ModelVolkswagen)1),
            new Volkswagen("CROSSPOLO", 1248, 1699, 3988, 175, (Transport.typeTransport)4, 4, 5, 1453,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)2, 4, 2, 90, 2500, 1598, 4.6), (Volkswagen.ModelVolkswagen)2),
            new Volkswagen("Beetle Cabrio", 1510, 1808, 4277, 224, (Transport.typeTransport)4, 4, 2, 1554,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 6, 3, 200, 5000, 1984, 6.5), (Volkswagen.ModelVolkswagen)3),
            new Volkswagen("Golf Plus", 1348, 1759, 4204, 184, (Transport.typeTransport)4, 4, 5, 1517,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 2, 102, 3800, 1595, 6), (Volkswagen.ModelVolkswagen)4),
            new Volkswagen("Jetta", 1502, 1778, 4643, 209, (Transport.typeTransport)4, 4, 4, 1532,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)4, 5, 4, 150, 3500, 1390, 5.2), (Volkswagen.ModelVolkswagen)5)
        };
        static public List<Mercedes_Benz> mercedes_BenzCars = new List<Mercedes_Benz>
        {
            new Mercedes_Benz("MERCEDES BENZ A45 AMG 2013", 1406, 1781, 4293, 249, (Transport.typeTransport)4, 4, 5, 1415,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 4, 365, 5000, 1991, 6.2), (Mercedes_Benz.ModelMercedes_Benz)1),
            new Mercedes_Benz("MERCEDES BENZ В-CLASS W246", 1500, 2010, 4359, 220, (Transport.typeTransport)4, 4, 5, 1549,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 4, 3, 170, 3400, 2143, 5.9), (Mercedes_Benz.ModelMercedes_Benz)2),
            new Mercedes_Benz("MERCEDES BENZ С-CLASS AMG", 1730, 1795, 4707, 250, (Transport.typeTransport)4, 4, 4, 1430,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 4, 457, 5000, 6208, 12), (Mercedes_Benz.ModelMercedes_Benz)3),
            new Mercedes_Benz("MERCEDES BENZ C 63 AMG T-MODELL S204", 1795, 1770, 4702, 249, (Transport.typeTransport)4, 4, 5, 1633,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 4, 457, 5000, 6208, 12.2), (Mercedes_Benz.ModelMercedes_Benz)4),
            new Mercedes_Benz("MERCEDES BENZ VITO MIKROAVTOBUS", 1995, 1901, 4763, 220, (Transport.typeTransport)4, 4, 4, 1615,
                (Auto.AutoType)2, new Auto.Engine((Auto.Engine.TypeEngine)2, 4, 2, 224, 2800, 2987, 8.5), (Mercedes_Benz.ModelMercedes_Benz)5),
        };
        static public List<Ferrari> ferrariCars = new List<Ferrari>
        {
            new Ferrari("FERRARI LAFERRARI", 1255, 1992, 4702, 350, (Transport.typeTransport)4, 4, 2, 1000,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)4, 12, 4, 963, 6750, 6262, 10.5), (Ferrari.ModelFerrari)1),
            new Ferrari("FERRARI DINO 1968", 1080, 1709, 4234, 245, (Transport.typeTransport)4, 4, 2, 1382,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 6, 2, 195, 5500, 2419, 6.7), (Ferrari.ModelFerrari)2),
            new Ferrari("FERRARI MONDIAL", 1503, 1791, 4641, 254, (Transport.typeTransport)4, 4, 2, 1496,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 300, 4200, 3405, 7.2), (Ferrari.ModelFerrari)3),
            new Ferrari("FERRARI F149 CALIFORNIA", 1630, 1908, 4562, 195, (Transport.typeTransport)4, 4, 2, 1605,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 489, 5000, 4297, 8.3), (Ferrari.ModelFerrari)4),
            new Ferrari("FERRARI 458 ITALIA", 1485, 1937, 4527, 325, (Transport.typeTransport)4, 4, 2, 1606,
                (Auto.AutoType)3, new Auto.Engine((Auto.Engine.TypeEngine)1, 8, 3, 570, 6000, 4499, 7.8), (Ferrari.ModelFerrari)5),
        };
        static void Choose()
        {
            while(true)
            {
                Console.WriteLine("Choose model:\n1 Volkswagen\n2 Mersedes-Benz\n3 Ferrari\n4 exit");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1) InfoCars(1);
                if (choose == 2) InfoCars(2);
                if (choose == 3) InfoCars(3);
                if (choose == 4) break;
            }

        }

        static void InfoCars(int flag)
        {
            while(true)
            {
                Console.WriteLine("Menu:\n1 info about cars\n2 exit\n");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {

                    if (flag == 1)
                    {
                        foreach (var x in volkswagenCars)
                        {
                            x.outInfo();
                        }
                    }
                    else
                    if (flag == 2)
                    {
                        foreach (var x in mercedes_BenzCars)
                        {
                            x.outInfo();
                        }
                    }
                    else
                    {
                        foreach (var x in ferrariCars)
                        {
                            x.outInfo();
                        }
                    }
                }
                else break;
            }
        }
        static void Main(string[] args)
        {
            Choose();
            
        }
    }
}
