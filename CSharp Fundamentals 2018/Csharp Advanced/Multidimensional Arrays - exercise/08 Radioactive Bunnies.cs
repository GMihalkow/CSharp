using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the Rows and Columns of the Matrix
            int[] RowsAndCols =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int Rows = RowsAndCols[0];
            int Cols = RowsAndCols[1];

            //Intitializing the Matrix
            char[,] PlayingField = new char[Rows, Cols];

            //Getting the Player's position
            int PlayerRow = 0;
            int PlayerCol = 0;

            //Filling the Matrix
            for (int row = 0; row < Rows; row++)
            {
                FillingTheMatrix(Cols, PlayingField, ref PlayerRow, ref PlayerCol, row);
            }

            //Getting movement information
            string Moves = Console.ReadLine();
            char[] BrokenDownMoves = Moves.ToCharArray();

            int counter = 0;

            for (int move = 0; move < BrokenDownMoves.Length; move++)
            {
                char command = BrokenDownMoves[move];

                //Player movement
                switch (command)
                {
                    //DOWN command DONE!
                    case 'D':
                        {
                            for (int row = PlayerRow; row < Rows; row++)
                            {
                                for (int col = PlayerCol; col < Cols; col++)
                                {
                                    if (row + 1 > Rows - 1)
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col;
                                        counter++;
                                        goto turn;

                                    }
                                    if (PlayingField[row + 1, col] == 'B')
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row + 1;
                                        PlayerCol = col;
                                        counter += 2;
                                        goto turn;
                                    }
                                    PlayingField[row + 1, col] = PlayingField[row, col];
                                    PlayingField[row, col] = '.';
                                    PlayerRow = row + 1;
                                    PlayerCol = col;
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                    //UP command DONE!
                    case 'U':
                        {
                            for (int row = PlayerRow; row < Rows; row++)
                            {
                                for (int col = PlayerCol; col < Cols; col++)
                                {
                                    if (row - 1 < 0)
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col;
                                        counter++;
                                        goto turn;
                                    }
                                    if (PlayingField[row - 1, col] == 'B')
                                    {

                                        PlayingField[row, col] = '.';
                                        PlayerRow = row - 1;
                                        PlayerCol = col;
                                        counter += 2;
                                        goto turn;
                                    }
                                    PlayingField[row - 1, col] = PlayingField[row, col];
                                    PlayingField[row, col] = '.';
                                    PlayerRow = row - 1;
                                    PlayerCol = col;
                                    break;
                                }
                                break;
                            }

                        }
                        break;
                    //LEFT command DONE!
                    case 'L':
                        {
                            for (int row = PlayerRow; row < Rows; row++)
                            {
                                for (int col = PlayerCol; col < Cols; col++)
                                {
                                    if (col - 1 < 0)
                                    {

                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col;
                                        counter++;
                                        goto turn;
                                    }
                                    if (PlayingField[row, col - 1] == 'B')
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col - 1;
                                        counter += 2;
                                        goto turn;
                                    }
                                    PlayingField[row, col - 1] = PlayingField[row, col];
                                    PlayingField[row, col] = '.';
                                    PlayerRow = row;
                                    PlayerCol = col - 1;
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                    //RIGHT command DONE!
                    case 'R':
                        {
                            for (int row = PlayerRow; row < Rows; row++)
                            {
                                for (int col = PlayerCol; col < Cols; col++)
                                {
                                    if (col + 1 > Cols - 1)
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col;
                                        counter++;
                                        goto turn;
                                    }
                                    if (PlayingField[row, col + 1] == 'B')
                                    {
                                        PlayingField[row, col] = '.';
                                        PlayerRow = row;
                                        PlayerCol = col + 1;
                                        counter += 2;
                                        goto turn;
                                    }
                                    PlayingField[row, col + 1] = PlayingField[row, col];
                                    PlayingField[row, col] = '.';
                                    PlayerRow = row;
                                    PlayerCol = col + 1;
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                }
                turn:;
                //Expanding the bunnies
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        if (PlayingField[row, col] == 'B')
                        {
                            restart:;
                            //Expanding UP
                            if (row - 1 < 0) goto start;
                            if (PlayingField[row - 1, col] == 'B') goto start;
                            if (PlayingField[row - 1, col] == 'P')
                            {
                                PlayingField[row - 1, col] = 'b';
                                PlayerRow = row - 1;
                                PlayerCol = col;
                                counter += 2;
                                goto restart;
                            }
                            PlayingField[row - 1, col] = 'b';

                            start:;
                            //Expanding DOWN
                            if (row + 1 > Rows - 1) goto next;
                            if (PlayingField[row + 1, col] == 'B') goto next;
                            if (PlayingField[row + 1, col] == 'P')
                            {
                                PlayingField[row + 1, col] = 'b';
                                PlayerRow = row + 1;
                                PlayerCol = col;
                                counter += 2;
                                goto next;
                            }
                            PlayingField[row + 1, col] = 'b';

                            next:;
                            //Expanding to the RIGHT
                            if (col + 1 > Cols - 1) goto nextOne;
                            if (PlayingField[row, col + 1] == 'B') goto nextOne;
                            if (PlayingField[row, col + 1] == 'P')
                            {
                                PlayingField[row, col + 1] = 'b';
                                PlayerRow = row;
                                PlayerCol = col + 1;
                                counter += 2;
                                goto nextOne;
                            }
                            PlayingField[row, col + 1] = 'b';

                            nextOne:;
                            //Expanding to the LEFT
                            if (col - 1 < 0) continue;
                            if (PlayingField[row, col - 1] == 'B') continue;
                            if (PlayingField[row, col - 1] == 'P')
                            {
                                PlayingField[row, col - 1] = 'b';
                                PlayerRow = row;
                                PlayerCol = col - 1;
                                counter += 2;
                                continue;
                            }
                            PlayingField[row, col - 1] = 'b';
                        }

                    }
                }

                //Renewing the Bunnies
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        if (PlayingField[row, col] == 'b')
                        {
                            PlayingField[row, col] = 'B';
                        }
                    }
                }
                if (counter == 1)
                {
                    for (int r = 0; r < Rows; r++)
                    {
                        for (int c = 0; c < Cols; c++)
                        {
                            Console.Write(PlayingField[r, c]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"won: {PlayerRow} {PlayerCol}");
                    return;
                }
                else if (counter == 2)
                {
                    for (int r = 0; r < Rows; r++)
                    {
                        for (int c = 0; c < Cols; c++)
                        {
                            Console.Write(PlayingField[r, c]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"dead: {PlayerRow} {PlayerCol}");
                    return;
                }
            }
        }

        private static void FillingTheMatrix(int Cols, char[,] PlayingField, ref int PlayerRow, ref int PlayerCol, int row)
        {
            string inputLine = Console.ReadLine();
            char[] floor = inputLine.ToCharArray();

            for (int col = 0; col < Cols; col++)
            {
                PlayingField[row, col] = floor[col];
                if (PlayingField[row, col] == 'P')
                {
                    PlayerCol = col;
                    PlayerRow = row;
                }
            }
        }
    }
}
