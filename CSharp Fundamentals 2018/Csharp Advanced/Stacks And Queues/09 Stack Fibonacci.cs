using System;
using System.Numerics;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace _09_Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<ulong> Stack = new Stack<ulong>();
            Stack.Push(1);
            Stack.Push(0);

            for (int i = 1; i <= n; i++)
            {
                ulong FirstNum = Stack.Pop();
                ulong SecondNum = Stack.Peek();
                ulong temp = Stack.Pop();
                Stack.Push(FirstNum + SecondNum);
                Stack.Push(temp);
            }

            Console.WriteLine(Stack.Pop());
        }
    }
}
