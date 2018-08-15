using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAKE_INGRIDIENTS
{
    class Program
    {
        static void Main(string[] args)
        {

            var total = 0;
            for (int i = 0; i <= 20; i++)
            {
                string ingridient = Console.ReadLine();
               
                if (ingridient == "Bake!")
                {
                    Console.WriteLine("Preparing cake with {0} ingredients.", total);
                    return;
                }
                else
                {
                    Console.WriteLine("Adding ingredient {0}.", ingridient);
                    total++;
                }
            }
        }
    }
}
