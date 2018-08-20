using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_TRIANGLE_PROPERTIES
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            double area = (width * heigth) ;
            double P = (width * 2) + (heigth * 2);
            double diagonal = Math.Pow(width, 2) + Math.Pow(heigth, 2);
            

            Console.WriteLine($"{P}\n{area}\n{Math.Sqrt(diagonal)}");
            

        }
    }
}
