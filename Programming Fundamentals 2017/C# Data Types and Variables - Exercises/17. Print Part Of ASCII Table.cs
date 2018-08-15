using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_PART_OF_ASCII_TABLE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberTWO = int.Parse(Console.ReadLine());

            char character = (char)number;

            for (int i = number; i <= numberTWO; i++)
            {
                
                string ascii = Encoding.ASCII.GetString(new byte[] { (byte)character });

                Console.Write($"{ascii} ");
                character++;
            }
        }
    }
}
