using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            //Suppose there is a circle.
            //There are N petrol pumps on that circle. 
            //Petrol pumps are numbered 0 to (N−1) (both inclusive). 
            //You have two pieces of information corresponding to each of the petrol pump:
            //(1) the amount of petrol that particular petrol pump will give,
            //and (2) the distance from that petrol pump to the next petrol pump.

            //INPUT FORMAT:
            //⦁The first line will contain the value ofN

            int Number = int.Parse(Console.ReadLine());

            //⦁The next N lines will contain a pair of integers each
            //i.e. the amount of petrol that petrol pump will give
            //and the distance between that petrol pump and the next petrol pump

            Queue<int> Queue = new Queue<int>();

            int TotalSum = 0;

            for (int index = 0; index < Number; index++)
            {
                int[] input =
                    Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int PetrolPump = input[0];
                int DistanceToNextOne = input[1];
                int Sum = PetrolPump - DistanceToNextOne;

                Queue.Enqueue(Sum);
            }

            Queue<int> CloneQueue = new Queue<int>(Queue);

            for (int i = 0; i < Queue.Count(); i++)
            {

                while (CloneQueue.Count() != 0)
                {
                    TotalSum += CloneQueue.Dequeue();
                    if(TotalSum < 0)
                    {
                        Queue.Enqueue(Queue.Dequeue());
                        TotalSum = 0;
                        CloneQueue = new Queue<int>(Queue);
                        break;
                    }
                    if(CloneQueue.Count() == 0 && TotalSum >= 0)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
                
            }

            //OUTPUT FORMAT:
            //⦁An integer which will be
            //the smallest index of the petrol pump from which we can start the tour
        }
    }
}
