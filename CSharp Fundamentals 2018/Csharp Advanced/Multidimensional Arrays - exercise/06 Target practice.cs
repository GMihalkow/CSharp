using System;
using System.Linq;

namespace _06_Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RowsAndCols =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int Rows = RowsAndCols[0];
            int Cols = RowsAndCols[1];

            char[,] Matrix = new char[Rows, Cols];

            //Dealing with the Snake crawling
            string Snake = Console.ReadLine();
            char[] SnakePieces = Snake.ToCharArray();
            char[] ReversedSnake = SnakePieces.Reverse().ToArray();
            int ReversedSnakeLength = ReversedSnake.Length - 1;
            int Temp = Cols - 1;
            int tempCol = 0;

            //Blast information
            int[] BlastInformation =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int ImpactRow = BlastInformation[0];
            int ImpactCol = BlastInformation[1];
            int ImpactRadius = BlastInformation[2];

            //Filling the Matrix
            FullMatrix(Rows, Cols, Matrix, ReversedSnake, ref ReversedSnakeLength, Temp, ref tempCol);

            //Blast Information
            int TempImpactCol = ImpactCol;
            int TempImpactRow = ImpactRow;
            int TempRadius = ImpactRadius;

            //Explosion (using the Pithagoras Theorem)
            Explosion(Rows, Cols, Matrix, ImpactRow, ImpactCol, ImpactRadius);

            //Parts falling down
            PartsFallinDown(Rows, Cols, Matrix);

            //Printin the end result
            EndResult(Rows, Cols, Matrix);

        }

        private static void EndResult(int Rows, int Cols, char[,] Matrix)
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Console.Write(Matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        private static void PartsFallinDown(int Rows, int Cols, char[,] Matrix)
        {
            for (int col = 0; col < Cols; col++)
            {
                for (int row = Rows - 1; row >= 0; row--)
                {
                    if (Matrix[row, col] == ' ')
                    {
                        for (int c = col; c < Cols; c++)
                        {
                            for (int r = row; r >= 0; r--)
                            {
                                if (Matrix[r, c] != ' ')
                                {
                                    Matrix[row, col] = Matrix[r, c];
                                    Matrix[r, c] = ' ';
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private static void FullMatrix(int Rows, int Cols, char[,] Matrix, char[] ReversedSnake, ref int ReversedSnakeLength, int Temp, ref int tempCol)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                for (int col = Temp; col >= 0; col--)
                {
                    if (ReversedSnakeLength < 0)
                    {
                        ReversedSnakeLength = ReversedSnake.Length - 1;
                    }
                    Matrix[row, col] = ReversedSnake[ReversedSnakeLength];
                    ReversedSnakeLength--;
                }
                if (row - 1 < 0) break;
                row--;
                if (ReversedSnakeLength != 0)
                {
                    tempCol = 0;
                }
                else
                {
                    tempCol = ReversedSnakeLength;
                }

                for (int c = tempCol; c < Cols; c++)
                {
                    if (ReversedSnakeLength < 0)
                    {
                        ReversedSnakeLength = ReversedSnake.Length - 1;

                    }
                    Matrix[row, c] = ReversedSnake[ReversedSnakeLength];
                    ReversedSnakeLength--;
                }

            }
        }

        private static void Explosion(int Rows, int Cols, char[,] Matrix, int ImpactRow, int ImpactCol, int ImpactRadius)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    double PithagorasTheorem = Math.Pow(((double)col - (double)ImpactCol), 2) + Math.Pow(((double)row - (double)ImpactRow), 2);
                    if (PithagorasTheorem <= Math.Pow((double)ImpactRadius, 2))
                    {
                        Matrix[row, col] = ' ';
                    }

                }
            }
        }
    }
}
