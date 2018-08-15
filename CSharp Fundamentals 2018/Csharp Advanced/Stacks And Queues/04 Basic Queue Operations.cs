using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will be given an integer N representing the number of elements to enqueue (add)
            //integer S representing the number of elements to dequeue (remove)
            //integer X, an element that you should look for in the queue

            int[] Commands =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int N = Commands[0];//Number of elements to enqueue
            int S = Commands[1];//Number of elements to dequeue
            int X = Commands[2];//Element to look for

            int[] Numbers =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> Queue = new Queue<int>(N);
            //Filling the Queue up
            for (int i = 0; i < Numbers.Length; i++)
            {
                Queue.Enqueue(Numbers[i]);
            }

            //Removing elements from the Queue
            for (int i = 0; i < S; i++)
            {
                Queue.Dequeue();
            }
            //Checking the Length
            if (Queue.Count() == 0)
            {
                Console.WriteLine("0");
                return;
            }
            //Searching for the element X
            if (Queue.Contains(X))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                Console.WriteLine(Queue.Min());
            }

        }
    }
}
