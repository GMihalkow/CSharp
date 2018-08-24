using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_INTEGER_TO_HEX_AND_BINARY
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string hex = number.ToString("X");

            Console.WriteLine(hex);
            string ToBinary = Convert.ToString(Convert.ToInt32(hex, 16), 2);

            Console.WriteLine(ToBinary);

            
        }
    }
}
