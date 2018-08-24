using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_FAST_PRIME_CHECKER
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int CHECK = 2; CHECK <= number; CHECK++)
            {
                bool PRIME = true;
                for (int DIVIDER = 2; DIVIDER <= Math.Sqrt(CHECK); DIVIDER++)
                {
                    if (CHECK % DIVIDER == 0 || number == 1 || number == 0)
                    {
                        PRIME = false;
                        break;
                    }
                }
                Console.WriteLine($"{CHECK} -> {PRIME}");
            }

        }
    }
}
