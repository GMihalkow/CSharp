using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVAL_OF_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            var total = number1;
            var total1 = number2;

            if (number1 < number2)
            {
                for (int i = number1; i <= number2; i++)
                {
                    
                        Console.WriteLine("{0}", total);
                        total++;
                    
                    
                }
            }
            else 
            {
                for (int i = number2; i <= number1; i++)
                {
                    
                        Console.WriteLine("{0}", total1);
                        total1++;
                    
                }
            }
        }
    }
}