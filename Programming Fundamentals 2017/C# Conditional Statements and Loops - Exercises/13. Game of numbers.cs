using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_OF_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n1 = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            var total = 0;

            for (int i = n; i <= n1; i++)
            {
                for (int w = n; w <= n1; w++)
                {
                    total++;
                    if ((i + w) == sum)
                    {
                        Console.WriteLine("Number found! {0} + {1} = {2}", w, i, sum);
                        return;
                    }
                }
            }
            Console.WriteLine("{0} combinations - neither equals {1}", total, sum);
        }
    }
}
