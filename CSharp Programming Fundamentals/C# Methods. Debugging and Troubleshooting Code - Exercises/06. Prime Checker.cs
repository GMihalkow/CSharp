using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _06_PRIME_CHECKER
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            
            bool prime = true;
            Console.WriteLine(CHECKER(number, prime));
        }
        static bool CHECKER(long number, bool prime)
        {
            if (number == 0)
            {
                prime = false; return prime;
            }
            if (number == 1)
            {
                prime = false; return prime;
            }
            for (int p = 2; p <= Math.Sqrt(number); p++)
            {
                if (number % p == 0)
                {
                    prime = false;
                    return prime;
                }
            }
            prime = true;
            return prime;
        }
    }
}
