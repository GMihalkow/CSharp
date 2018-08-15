using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] InputSequence =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int Rows = InputSequence[0];
            int Cols = InputSequence[1];

            int counter = 0;
            int sum = 0;
            int oldSum = 0;
            int biggestSum = 0;

            int[,] LargestSequence = new int[3, 3];

            int[,] RectangleMatrix = new int[Rows, Cols];

            //Filling the RectangleMatrix with elements
            for (int row = 0; row < Rows; row++)
            {
                int[] Numbers =
                    Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < Cols; col++)
                {
                    RectangleMatrix[row, col] = Numbers[col];
                }
            }

            for (int row = 0; row < Rows; row++)
            {
                oldSum = sum;
                if (row + 2 > Rows - 1) continue;
                sum = 0;
                for (int col = 0; col < Cols; col++)
                {
                    oldSum = sum;
                    counter++;
                    if (col + 2 > Cols - 1) continue;
                    sum = 0;
                    sum += RectangleMatrix[row, col];
                    sum += RectangleMatrix[row + 1, col];
                    sum += RectangleMatrix[row + 2, col];

                    sum += RectangleMatrix[row, col + 1];
                    sum += RectangleMatrix[row + 1, col + 1];
                    sum += RectangleMatrix[row + 2, col + 1];

                    sum += RectangleMatrix[row, col + 2];
                    sum += RectangleMatrix[row + 1, col + 2];
                    sum += RectangleMatrix[row + 2, col + 2];

                    if (sum <= oldSum)
                    {
                        if (biggestSum >= oldSum)
                        {

                        }
                        else
                        {
                            biggestSum = oldSum;
                        }

                    }
                    else
                    {
                        if (biggestSum >= sum)
                        {

                        }
                        else
                        {
                            LargestSequence[0, 0] = RectangleMatrix[row, col];
                            LargestSequence[1, 0] = RectangleMatrix[row + 1, col];
                            LargestSequence[2, 0] = RectangleMatrix[row + 2, col];

                            LargestSequence[0, 1] = RectangleMatrix[row, col + 1];
                            LargestSequence[1, 1] = RectangleMatrix[row + 1, col + 1];
                            LargestSequence[2, 1] = RectangleMatrix[row + 2, col + 1];

                            LargestSequence[0, 2] = RectangleMatrix[row, col + 2];
                            LargestSequence[1, 2] = RectangleMatrix[row + 1, col + 2];
                            LargestSequence[2, 2] = RectangleMatrix[row + 2, col + 2];

                            biggestSum = sum;
                        }
                    }
                }
            }

            Console.WriteLine("Sum = " + biggestSum);
            Console.WriteLine($"{LargestSequence[0,0]} {LargestSequence[0,1]} {LargestSequence[0, 2]}\n{LargestSequence[1,0]} {LargestSequence[1,1]} {LargestSequence[1,2]}\n{LargestSequence[2,0]} {LargestSequence[2,1]} {LargestSequence[2,2]}");
        }
    }
}
