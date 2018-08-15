using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_COMPARING_FLOATS
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001D;

            bool large = true;

            
            
                double sum = Math.Abs((double)a - (double)b);
                
                if (sum < eps)
                {
                    large = true;
                    Console.WriteLine(large);
                }
                else
                {
                    large = false;
                    Console.WriteLine(large);
                }
        }
    }
}
