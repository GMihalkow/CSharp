using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Configuration;
using System.Numerics;
using System.Collections.Generic;

namespace _08_Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<ulong> Queue = new Queue<ulong>();
            Queue.Enqueue(0);
            Queue.Enqueue(1);
            Fibonacci(n, Queue);
        }

        private static void Fibonacci(int n, Queue<ulong> Queue)
        {
            for (int i = 1; i <= n; i++)
            {
                Queue.Enqueue(Queue.Dequeue() + Queue.Peek());

            }
            Console.WriteLine(Queue.Dequeue());
        }
    }
}
