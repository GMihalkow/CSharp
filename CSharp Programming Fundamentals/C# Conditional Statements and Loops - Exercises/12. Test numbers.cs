using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int n1 = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            var total = 0;
            var sum1 = 0;
            var sum2 = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int p = 1; p <= n1; p++)
                {
                    total++;
                    sum1 = sum2 + 3 * (i * p);

                    sum2 = sum1;
                    if (sum2 >= sum)
                    {
                        Console.WriteLine("{0} combinations", total);
                        Console.WriteLine("Sum: {0} >= {1}", sum2, sum);
                        return;
                    }
                    
                        
                    
                    
                }
               
            }
            Console.WriteLine("{0} combinations", total);
            Console.WriteLine("Sum: {0}", sum2);
            return;

        }
    }
}
