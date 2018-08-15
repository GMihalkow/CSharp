using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            int[] Numbers =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToArray();

            Func<int[], int[]> Sorter = n =>
            {
                //Taking the even numbers
                int[] EvenNumbers;
                EvenNumbers = n.Where(w => w % 2 == 0).OrderBy(x=>x).ToArray();
                //Taking the odd numbers
                int[] OddNumbers;
                OddNumbers = n.Where(p => p % 2 != 0).OrderBy(x => x).ToArray();

                //Combinin them
                int[] CombinedArr = EvenNumbers.Concat(OddNumbers).ToArray();
                return CombinedArr;
            };

            Console.WriteLine(string.Join(" ", Sorter(Numbers)));
        }
    }
}
