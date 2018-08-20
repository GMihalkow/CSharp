using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _14_FUCKTORIEL_TRAILING_ZONES
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            
            FUCKTORIEL(number);

        }

        static BigInteger FUCKTORIEL(BigInteger number)
        {

            int zeros = 0;

            for (BigInteger i = number; i >= 2; i--)
            {
                number = number * (i - 1);

            }

            while (number > 0)
            {
                BigInteger digit = number % 10;
                if (digit == 0)
                {
                    zeros++;
                }
                else
                {
                    break;
                }
                number = number / 10;
            }

            Console.WriteLine($"{zeros}");

            return number;
        }
    }
}
