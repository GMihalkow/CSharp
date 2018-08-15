using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int RowsCount = int.Parse(Console.ReadLine());
            int counter = 0;
            int ElementsCount = 0;

            int[][] JaggedArray = new int[RowsCount][];
            int[][] SecondArray = new int[RowsCount][];
            int[][] ReversedSecondArray = new int[RowsCount][];

            //Filling the FirstArray
            for (int row = 0; row < RowsCount; row++)
            {
                int[] TempRowArr =
                    Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                JaggedArray[row] = new int[TempRowArr.Length];

                counter = 0;
                foreach (var number in TempRowArr)
                {
                    JaggedArray[row][counter] = number;
                    counter++;
                }
            }
            //Filling the SecondArray
            for (int row = 0; row < RowsCount; row++)
            {
                int[] TempRowArr =
                    Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                SecondArray[row] = new int[TempRowArr.Length];

                counter = 0;
                foreach (var number in TempRowArr)
                {
                    SecondArray[row][counter] = number;
                    counter++;
                }
            }

            //Reversing the SecondArray
            for (int row = 0; row < RowsCount; row++)
            {
                ReversedSecondArray[row] = SecondArray[row].Reverse().ToArray();
            }

            //Combining the arrays
            int[][] CombinedArray = new int[RowsCount][];
            for (int row = 0; row < RowsCount; row++)
            {
                CombinedArray[row] = new int[JaggedArray[row].Length + ReversedSecondArray[row].Length];

                counter = 0;
                foreach (var number in JaggedArray[row])
                {
                    CombinedArray[row][counter] = number;
                    counter++;
                    ElementsCount++;
                }
                foreach (var number in ReversedSecondArray[row])
                {
                    CombinedArray[row][counter] = number;
                    counter++;
                    ElementsCount++;
                }
            }

            //Comparing the lengths
            int comparison = 1;
            for (int row = 0; row < RowsCount; row++)
            {
                if(row+1 > RowsCount - 1)
                {
                    break;
                }
                if (CombinedArray[row].Length == CombinedArray[row + 1].Length)
                {
                    comparison++;
                }
            }

            //Printing the results
            if (comparison == RowsCount)
            {
                for (int row = 0; row < RowsCount; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", CombinedArray[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {ElementsCount}");
            }
        }
    }
}
