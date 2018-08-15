using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_GEOMETRY_CALCULATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            TYPE(figure);

        }

        static string TYPE(string figure)
        {
            switch (figure)
            {
                case "triangle": double height = double.Parse(Console.ReadLine());
                    double side = double.Parse(Console.ReadLine()); Console.WriteLine("{0:f2}", (height * side) / 2);
                    break;
                case "square": double a = double.Parse(Console.ReadLine()); Console.WriteLine("{0:f2}", Math.Pow(a, 2));
                    break;
                case "rectangle": double b = double.Parse(Console.ReadLine()); double b1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:f2}", b * b1);
                    break;
                case "circle": double radius = double.Parse(Console.ReadLine()); Console.WriteLine("{0:f2}", (Math.PI * Math.Pow(radius, 2)));
                    break;
            }
            return figure;
        }
    }
}
