using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int RowsAndCols = int.Parse(Console.ReadLine());

            int FirstDiagonalSum = 0;
            int SecondDiagonalSum = 0;

            int X = 0;

            int[,] MatrixSquare = new int[RowsAndCols, RowsAndCols];

            int Y = RowsAndCols-1;

            //Filling The Matrix
            for (int row = 0; row < RowsAndCols; row++)
            {
                int[] Numbers =
                    Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < RowsAndCols; col++)
                {
                    MatrixSquare[row, col] = Numbers[col];
                }
            }

            for (int row = 0; row < RowsAndCols; row++)
            {
                for (int col = 0; col < RowsAndCols; col++)
                {

                    if (X > RowsAndCols) break;

                    if(col == X)
                    {
                        FirstDiagonalSum += MatrixSquare[row, X];
                    }
                }

                for (int backwards = RowsAndCols-1; backwards >= 0; backwards--)
                {
                    if (backwards == Y)
                    {
                        SecondDiagonalSum += MatrixSquare[row, Y];
                    }
                }
                X++;
                Y--;
            }
            Console.WriteLine(Math.Abs(FirstDiagonalSum-SecondDiagonalSum));

        }
    }
}
