using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALORIES_COUNTER
{
    class Program
    {
        static void Main(string[] args)
        {
            int pizza = int.Parse(Console.ReadLine());

            var cheese = 500;
            var tomatosauce = 150;
            var salami = 600;
            var pepper = 50;

            var totalCHEESE = 0;
            var totalTOMATOSAUCE = 0;
            var totalSALAMI = 0;
            var totalPEPPER = 0;

            for (int i = 1; i <= pizza; i++)
            {
                string ing = Console.ReadLine().ToLower();

                if (ing == "cheese")
                {
                    totalCHEESE += cheese;
                }
                else if (ing == "tomato sauce")
                {
                    totalTOMATOSAUCE += tomatosauce;
                }
                else if (ing == "salami")
                {
                    totalSALAMI += salami;
                }
                else if (ing == "pepper")
                {
                    totalPEPPER += pepper;
                }


                if (i == pizza)
                {
                    Console.WriteLine("Total calories: {0}", totalCHEESE + totalPEPPER + totalSALAMI + totalTOMATOSAUCE);
                    
                }
                
            }
        }
    }
}
