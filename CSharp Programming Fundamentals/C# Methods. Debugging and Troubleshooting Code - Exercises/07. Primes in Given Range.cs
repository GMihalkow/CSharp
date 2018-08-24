using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PRIMES_IN_GIVEN_RANGE
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            PRIMES(start, end);
        }

        static int PRIMES(int start, int end)
        {
            int ctrl;

            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                ctrl = 0;
                for (int w = 2; w <= i/2; w++)
                {
                    if (i % w == 0)
                    {
                        ctrl++;
                        break;
                    }
                    
                }
                

                if (ctrl == 0 && i != 1)
                {
                    if (i > 0)
                    {
                        list.Add(i);
                    }
                    
                }
            }

            Console.WriteLine(String.Join(", ", list));
            return start;
        }
    }
}
