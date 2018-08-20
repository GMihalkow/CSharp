using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13_FUCKTORIEL
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            BigInteger total = 1;
            BigInteger sum = 0;

            Console.WriteLine(NUMBERS(number));
        }

        static BigInteger NUMBERS(BigInteger number/*, BigInteger sum*/)
        {
            for (BigInteger i = number; i >= 2; i--)
            {
                number = number * (i-1);
            }

            return number;
        }
    }
}
