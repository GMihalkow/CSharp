using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXERCISE_22._09._2017
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();


            if (text == "Athlete" || text == "Businessman" || text == "Businesswoman" || text == "SoftUni Student")
            {


                switch (text)
                {
                    case "Athlete": Console.WriteLine("Water"); break;
                    case "Businessman": Console.WriteLine("Coffee"); break;
                    case "Businesswoman": Console.WriteLine("Coffee"); break;
                    case "SoftUni Student": Console.WriteLine("Beer"); break;


                }
            }
            else
            {
                Console.WriteLine("Tea");
            }
            
         
        }
    }
}