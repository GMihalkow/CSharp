using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            //integer N representing the number of elements to push onto the stack
            //an integer S representing the number of elements to pop from the stack 
            //integer X, an element that you should look for in the stack. 

            int[] NSX =
                 Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] NumberSequence =
                 Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int counter = 0;

            int N = NSX[0];//Number of pushed elements to the Stack
            int S = NSX[1];//Number of elements you must Pop from the Stack
            int X = NSX[2];//Find the element in the stack

            //Filling the Stack
            Stack<int> Stack = new Stack<int>(N);
            for (int i = 0; i < NumberSequence.Length; i++)
            {
                Stack.Push(NumberSequence[i]);
            }
            //Poping elements
            for (int i = 0; i < S; i++)
            {
                Stack.Pop();
            }
            
            if(Stack.Count() == 0)
            {
                Console.WriteLine("0");
                return;
            }

            foreach (var num in Stack)
            {
                counter++;
                if (num == X)
                {
                    Console.WriteLine("true");
                    break;
                }
                if(counter==Stack.Count())
                {
                    foreach (var item in Stack.OrderBy(x => x))
                    {
                        Console.WriteLine(item);
                        return;
                    }
                }
            }


        }
    }
}
