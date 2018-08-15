using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_PAIRS_BY_DIFFERENCE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers =
               Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();


            int difference = int.Parse(Console.ReadLine());

            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {

                for (int w = i + 1; w <= numbers.Length - 1; w++)
                {
                    var total = Math.Abs(numbers[i] - numbers[w]);

                    if (total == difference)
                    {

                        sum++;

                    }

                }

            }

            Console.WriteLine(sum);

        }
    }
}
