using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BOMB_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bomb =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> free = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb[0])
                {
                    int left = Math.Max(i - bomb[1], 0);
                    int right = Math.Min(i + bomb[1], numbers.Count - 1);
                    int length = right - left + 1;

                    numbers.RemoveRange(left, length);

                    i = 0;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
