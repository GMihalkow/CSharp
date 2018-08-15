using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_COMPARE_CHAR_ARRAYS
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] first = 
                Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            char[] second = 
                Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            SUM(first, second);

        }

        static char[] SUM(char[] first, char[] second)
        {
            var totalF = 0;
            var totalS = 0;

            int all = Math.Max(first.Length, second.Length);

            if (first.Length == second.Length)
            {
                for (int i = 0; i < all; i++)
                {
                    if (first[i] > 32 && second[i] > 32)
                    {
                        totalF += first[i];
                        totalS += second[i];
                    }
                }

                if (totalF < totalS)
                {
                    Console.WriteLine(String.Join("", first));
                    Console.WriteLine(String.Join("", second));
                }
                else
                {
                    Console.WriteLine(String.Join("", second));
                    Console.WriteLine(String.Join("", first));
                }
                return first;
            }

            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    totalF += first[i];
                }
                for (int i = 0; i < second.Length; i++)
                {
                    totalS += second[i];
                }

                if (first.Length > second.Length)
                {
                    Console.WriteLine(String.Join("", second));
                    Console.WriteLine(String.Join("", first));
                }
                if (first.Length < second.Length)
                {
                    Console.WriteLine(String.Join("", first));
                    Console.WriteLine(String.Join("", second));
                }
                return first;
            }
        }
    }
}
