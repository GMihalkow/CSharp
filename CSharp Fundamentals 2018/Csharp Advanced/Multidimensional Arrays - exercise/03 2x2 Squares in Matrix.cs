using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int Rows = inputNumbers[0];
            int Cols = inputNumbers[1];

            int counter = 0;
            int TotalCount = 0;


            string[,] Matrix = new string[Rows, Cols];

            //Filling the Matrix
            for (int row = 0; row < Rows; row++)
            {
                string[] Letters =
                    Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < Cols; col++)
                {
                    Matrix[row, col] = Letters[col];
                }
            }

            for (int row = 0; row < Rows; row++)
            {
                if (row + 1 > Rows - 1) continue;
                for (int col = 0; col < Cols; col++)
                {
                    if (col + 1 > Cols - 1) continue;
                    if ((int)char.Parse(Matrix[row, col]) == (int)char.Parse(Matrix[row, col + 1])
                        && (int)char.Parse(Matrix[row, col + 1]) == (int)char.Parse(Matrix[row + 1, col])
                        && (int)char.Parse(Matrix[row + 1, col]) == (int)char.Parse(Matrix[row + 1, col + 1]))
                    {
                        counter++;
                    }

                    if (counter == 1)
                    {
                        TotalCount++;
                        counter = 0;
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                if(counter==4)
                {
                    TotalCount++;
                    counter = 0;
                }
                else
                {
                    counter = 0;
                }
            }
            Console.WriteLine(TotalCount);
        }
    }
}
