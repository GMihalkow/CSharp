using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHOOSE_A_DRINK_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string proffesion = Console.ReadLine();
            int price = int.Parse(Console.ReadLine());

            double wat = 0.70;
            double cof = 1.00;
            double bir = 1.70;
            double tea = 1.20;

            if (proffesion == "Athlete" || proffesion == "Businessman" || proffesion == "Businesswoman" || proffesion == "SoftUni Student")
            {
                switch (proffesion)
                {
                    case "Athlete": Console.WriteLine("The Athlete has to pay {0:f2}.",wat * price ); break;
                    case "Businessman": Console.WriteLine("The Businessman has to pay {0:f2}.", cof * price ); break;
                    case "Businesswoman": Console.WriteLine("The Businesswoman has to pay {0:f2}.", cof * price); break;
                    case "SoftUni Student": Console.WriteLine("The SoftUni Student has to pay {0:f2}.", bir * price ); break;
                }
            }
            else
            {
                Console.WriteLine("The {0} has to pay {1:f2}.", proffesion, tea * price);
            }


        }
    }
}
