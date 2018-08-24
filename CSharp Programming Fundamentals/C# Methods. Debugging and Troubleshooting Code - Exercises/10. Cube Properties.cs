using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CUBE_PROPERTIES
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = decimal.Parse(Console.ReadLine());
            string side = Console.ReadLine();


            PROPERTIES(a, side);
        }

        static decimal PROPERTIES(decimal a, string side)
        {
            switch (side)
            {
                case "volume": decimal V = (decimal)a * a * a; Console.WriteLine($"{V:f2}"); break;
                case "face": decimal diagonal = (decimal) a * (decimal)Math.Sqrt(2); Console.WriteLine($"{(diagonal):f2}"); break;
                case "space": decimal spaceD = (decimal)Math.Sqrt(3) * a; Console.WriteLine($"{spaceD:f2}"); break;
                case "area": decimal surface =  6 * ((decimal)a * a); Console.WriteLine($"{surface:f2}"); break;
                    
            }
            return a;
        }
    }
}
