using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sequence
            //⦁	S1 = N
            //⦁	S2 = S1 + 1
            //⦁	S3 = 2 * S1 + 1
            //...

            //Using the Queue<T> class, write a program to prlong its first 50 members for given N.

            long Number = long.Parse(Console.ReadLine());
            long S1 = Number;
            
            Queue<long> Queue = new Queue<long>();
            Queue.Enqueue(S1);

            //Print this Queue
            Queue<long> ResultQueue = new Queue<long>();
            ResultQueue.Enqueue(S1);

            for (long i = 0; i < 50; i++)
            {
                //Filling the ResultQueue 
                //And Summing the numbers
                if (ResultQueue.Count() >= 50) break;
                long temp = Queue.Peek();

                Queue.Enqueue(temp + 1);
                ResultQueue.Enqueue(temp + 1);

                if (ResultQueue.Count() >= 50) break;

                Queue.Enqueue(2 * temp + 1);
                ResultQueue.Enqueue(2 * temp + 1);

                if (ResultQueue.Count() >= 50) break;

                Queue.Enqueue(Queue.Dequeue() + 2);
                ResultQueue.Enqueue(temp + 2);
                if (ResultQueue.Count() >= 50) break;

            }
            foreach (var element in ResultQueue)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
