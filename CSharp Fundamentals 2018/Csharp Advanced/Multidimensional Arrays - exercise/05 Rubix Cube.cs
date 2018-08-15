using System;
using System.Linq;

namespace _05_Rubix
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
            int CommandsCount = int.Parse(Console.ReadLine());

            int Rows = RowsAndCols[0];
            int Cols = RowsAndCols[1];
            int counter = 0;

            int[] TempRow = new int[Rows];
            int[] TempCol = new int[Cols];


            //Filling the Matrix
            int[,] Matrix = new int[Rows, Cols];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    counter++;
                    Matrix[row, col] = counter;

                }
            }

            for (int i = 0; i < CommandsCount; i++)
            {
                string command = Console.ReadLine();
                string[] ExactCommand =
                    command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int moves = int.Parse(ExactCommand[2]);

                //DOWN COMMAND WORKS!
                if (ExactCommand[1] == "down")
                {
                    if (moves % Rows == 2 && moves > 10000)
                    {
                        ExactCommand[2] = ((moves / 1000).ToString());
                    }
                    DownCommand(Rows, TempRow, Matrix, ExactCommand);
                }

                //UP COMMAND WORKS!
                if (ExactCommand[1] == "up")
                {
                    if (moves % Rows == 2 && moves > 10000)
                    {
                        ExactCommand[2] = ((moves / 1000).ToString());
                    }
                    UpCommand(Rows, TempRow, Matrix, ExactCommand);
                }

                //LEFT COMMAND WORKS!
                if (ExactCommand[1] == "left")
                {
                    if (moves % Cols == 2 && moves > 10000)
                    {
                        ExactCommand[2] = ((moves / 1000).ToString());
                    }
                    LeftCommand(Cols, TempCol, Matrix, ExactCommand);
                }

                //RIGHT COMMAND WORKS!(I think so)
                if (ExactCommand[1] == "right")
                {
                    if (moves % Cols == 2 && moves > 10000)
                    {
                        ExactCommand[2] = ((moves / 1000).ToString());
                    }
                    RightCommand(Cols, TempCol, Matrix, ExactCommand);
                }
            }

            int tempNumber = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    //FIRST ONE WORKS!
                    if (row == 0 && col == 0)
                    {
                        if (Matrix[row, col] == 1)
                        {
                            Console.WriteLine("No swap required");
                            continue;
                        }
                        else
                        {
                            for (int r = row; r < Rows; r++)
                            {
                                for (int c = 0; c < Cols; c++)
                                {
                                    if (Matrix[r, c] == 1)
                                    {
                                        tempNumber = Matrix[r, c];
                                        Matrix[r, c] = Matrix[row, col];
                                        Matrix[row, col] = tempNumber;
                                        Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                        // Console.WriteLine($"{Matrix[0, 0]} {Matrix[0, 1]} {Matrix[0, 2]}\n{Matrix[1, 0]} {Matrix[1, 1]} {Matrix[1, 2]}\n{Matrix[2, 0]} {Matrix[2, 1]} {Matrix[2, 2]}");
                                        goto start;
                                    }
                                }
                            }
                        }

                    }
                    else//SECOND ONE IN PROGRESS!
                    {
                        if (col - 1 < 0)
                        {
                            if (Matrix[row - 1, Cols - 1] == Matrix[row, col] - 1)
                            {
                                Console.WriteLine("No swap required");
                            }
                            else
                            {
                                for (int r = 0; r < Rows; r++)
                                {
                                    for (int c = Cols - 1; c >= 0; c--)
                                    {
                                        if (Matrix[r, c] - 1 == Matrix[row - 1, Cols - 1])
                                        {
                                            tempNumber = Matrix[row, col];
                                            Matrix[row, col] = Matrix[r, c];
                                            Matrix[r, c] = tempNumber;
                                            Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                            goto start;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Matrix[row, col] - 1 == Matrix[row, col - 1])
                            {
                                Console.WriteLine("No swap required");
                            }
                            else
                            {
                                for (int r = 0; r < Rows; r++)
                                {
                                    for (int c = 0; c < Cols; c++)
                                    {
                                        if (Matrix[r, c] - 1 == Matrix[row, col - 1])
                                        {
                                            tempNumber = Matrix[row, col];
                                            Matrix[row, col] = Matrix[r, c];
                                            Matrix[r, c] = tempNumber;

                                            Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                            goto start;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    start:;
                }

            }

        }

        private static void RightCommand(int Cols, int[] TempCol, int[,] Matrix, string[] ExactCommand)
        {
            int StaticRow = int.Parse(ExactCommand[0]);
            int Times = int.Parse(ExactCommand[2]);

            for (int t = 0; t < Times; t++)
            {
                int LastNum = Matrix[StaticRow, Cols - 1];

                for (int x = 0; x < Cols; x++)
                {
                    TempCol[x] = Matrix[StaticRow, x];
                }
                for (int col = Cols - 1; col >= 0; col--)
                {
                    if (col - 1 < 0)
                    {
                        Matrix[StaticRow, 0] = LastNum;
                        //Console.WriteLine($"{Matrix[0, 0]} {Matrix[0, 1]} {Matrix[0, 2]}\n{Matrix[1, 0]} {Matrix[1, 1]} {Matrix[1, 2]}\n{Matrix[2, 0]} {Matrix[2, 1]} {Matrix[2, 2]}");
                        break;
                    }
                    Matrix[StaticRow, col] = TempCol[col - 1];
                    // Console.WriteLine($"{Matrix[0, 0]} {Matrix[0, 1]} {Matrix[0, 2]}\n{Matrix[1, 0]} {Matrix[1, 1]} {Matrix[1, 2]}\n{Matrix[2, 0]} {Matrix[2, 1]} {Matrix[2, 2]}");

                }
            }
        }

        private static void LeftCommand(int Cols, int[] TempCol, int[,] Matrix, string[] ExactCommand)
        {
            int StaticRow = int.Parse(ExactCommand[0]);
            int Times = int.Parse(ExactCommand[2]);

            for (int turns = 0; turns < Times; turns++)
            {
                int FirstNum = Matrix[StaticRow, 0];

                for (int x = 0; x < Cols; x++)
                {
                    TempCol[x] = Matrix[StaticRow, x];
                }
                for (int col = 0; col < Cols; col++)
                {
                    if (col + 1 > Cols - 1)
                    {
                        Matrix[StaticRow, Cols - 1] = FirstNum;
                        break;
                    }
                    Matrix[StaticRow, col] = TempCol[col + 1];
                }
            }
        }

        private static void UpCommand(int Rows, int[] TempRow, int[,] Matrix, string[] ExactCommand)
        {
            int StaticCol = int.Parse(ExactCommand[0]);
            int Times = int.Parse(ExactCommand[2]);

            for (int turns = 0; turns < Times; turns++)
            {
                int FirstNum = Matrix[0, StaticCol];
                for (int x = 0; x < Rows; x++)
                {
                    TempRow[x] = Matrix[x, StaticCol];
                }
                for (int row = Rows - 1; row >= 0; row--)
                {


                    if (row - 1 < 0)
                    {
                        Matrix[Rows - 1, StaticCol] = FirstNum;
                        break;
                    }
                    Matrix[row - 1, StaticCol] = TempRow[row];

                }
            }
        }

        private static void DownCommand(int Rows, int[] TempRow, int[,] Matrix, string[] ExactCommand)
        {
            int StaticCol = int.Parse(ExactCommand[0]);
            int Times = int.Parse(ExactCommand[2]);

            for (int turn = 0; turn < Times; turn++)
            {
                int LastNum = Matrix[Rows - 1, StaticCol];

                for (int x = 0; x < Rows; x++)
                {
                    TempRow[x] = Matrix[x, StaticCol];
                }

                for (int row = 0; row < Rows; row++)
                {
                    if (row + 1 > Rows - 1)
                    {
                        Matrix[0, StaticCol] = LastNum;
                        break;
                    }
                    Matrix[row + 1, StaticCol] = TempRow[row];
                }
            }
        }
    }
}
