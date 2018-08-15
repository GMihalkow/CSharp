using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Stacks_and_Queues_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Numbers =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> Stack = new Stack<int>();
            for (int i = 0; i < Numbers.Length; i++)
            {
                Stack.Push(Numbers[i]);
            }

            while (Stack.Count() > 0)
            {
                Console.Write($"{Stack.Pop()} ");
            }

        }
    }
}
