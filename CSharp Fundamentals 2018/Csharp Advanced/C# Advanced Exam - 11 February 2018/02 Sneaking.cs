using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int Rows = int.Parse(Console.ReadLine());
            List<List<char>> PlayingField = new List<List<char>>();

            //filling the list with data about the field
            for (int row = 0; row < Rows; row++)

            {
                string inputData = Console.ReadLine();
                char[] charredInput = inputData.ToCharArray();

                PlayingField.Add(charredInput.ToList());

            }

            string Moves = Console.ReadLine();
            string command = string.Empty;
            for (int moveIndex = 0; moveIndex < Moves.Length; moveIndex++)
            {
                command = Moves[moveIndex].ToString();
                for (int row = 0; row < Rows; row++)
                {
                    //Enemy movement
                    int colCounter = PlayingField[row].Count;
                    for (int col = 0; col < colCounter; col++)
                    {
                        if (PlayingField[row][col] == 'b')
                        {

                            if (col + 1 > colCounter - 1)
                            {
                                PlayingField[row][col] = 'd';

                                continue;
                            }
                            if (PlayingField[row][col + 1] == 'S')
                            {
                                continue;
                            }
                            PlayingField[row][col] = '.';
                            PlayingField[row][col + 1] = 'b';
                            col++;
                            continue;
                        }

                        if (PlayingField[row][col] == 'd')
                        {
                            if (col - 1 < 0)
                            {
                                PlayingField[row][col] = 'b';
                                continue;
                            }
                            if (PlayingField[row][col - 1] == 'S')
                            {
                                continue;
                            }
                            PlayingField[row][col - 1] = 'd';
                            PlayingField[row][col] = '.';
                            continue;
                        }
                    }

                }

                for (int row = 0; row < Rows; row++)
                {
                    if (PlayingField[row].Contains('b')
                                ||
                                PlayingField[row].Contains('d'))
                    {
                        if (PlayingField[row].Contains('b'))
                        {

                            if ((PlayingField[row].IndexOf('b')
                                <
                                PlayingField[row].IndexOf('S')) && PlayingField[row].Contains('S'))
                            {
                                int SamIndex = PlayingField[row].IndexOf('S');
                                Console.WriteLine($"Sam died at {row}, {SamIndex}");

                                PlayingField[row][SamIndex] = 'X';
                                goto end;
                            }
                        }
                        if (PlayingField[row].Contains('d'))
                        {
                            if ((PlayingField[row].IndexOf('d')
                                >
                                PlayingField[row].IndexOf('S')) && PlayingField[row].Contains('S'))
                            {
                                int SamIndex = PlayingField[row].IndexOf('S');
                                Console.WriteLine($"Sam died at {row}, {SamIndex}");


                                PlayingField[row][SamIndex] = 'X';
                                goto end;
                            }
                        }
                    }
                }
                for (int SamRow = 0; SamRow < Rows; SamRow++)
                {
                    int colCounter = PlayingField[SamRow].Count;
                    for (int SamCol = 0; SamCol < colCounter; SamCol++)
                    {
                        if (PlayingField[SamRow][SamCol] == 'S')
                        {
                            switch (command)
                            {
                                case "U":
                                    {
                                        PlayingField[SamRow][SamCol] = '.';
                                        PlayingField[SamRow - 1][SamCol] = 'S';
                                        if (PlayingField[SamRow - 1].Contains('N'))
                                        {
                                            int NikoladzeIndex = PlayingField[SamRow - 1].IndexOf('N');
                                            PlayingField[SamRow - 1][NikoladzeIndex] = 'X';
                                            Console.WriteLine("Nikoladze killed!");
                                            goto end;
                                        }
                                        goto restart;
                                    }
                                    break;
                                case "W":
                                    {
                                        if (PlayingField[SamRow].Contains('N'))
                                        {
                                            int NikoladzeIndex = PlayingField[SamRow].IndexOf('N');
                                            PlayingField[SamRow][NikoladzeIndex] = 'X';
                                            Console.WriteLine("Nikoladze killed!");
                                            goto end;
                                        }
                                        goto restart;
                                    }
                                    break;
                                case "D":
                                    {
                                        PlayingField[SamRow][SamCol] = '.';
                                        PlayingField[SamRow + 1][SamCol] = 'S';
                                        if (PlayingField[SamRow + 1].Contains('N'))
                                        {
                                            int NikoladzeIndex = PlayingField[SamRow + 1].IndexOf('N');
                                            PlayingField[SamRow + 1][NikoladzeIndex] = 'X';
                                            Console.WriteLine("Nikoladze killed!");
                                            goto end;
                                        }
                                        goto restart;
                                    }
                                    break;
                                case "L":
                                    {
                                        PlayingField[SamRow][SamCol] = '.';
                                        PlayingField[SamRow][SamCol - 1] = 'S';
                                        if (PlayingField[SamRow].Contains('N'))
                                        {
                                            int NikoladzeIndex = PlayingField[SamRow].IndexOf('N');
                                            PlayingField[SamRow][NikoladzeIndex] = 'X';
                                            Console.WriteLine("Nikoladze killed!");
                                            goto end;
                                        }
                                        goto restart;
                                    }
                                    break;
                                case "R":
                                    {
                                        PlayingField[SamRow][SamCol] = '.';
                                        PlayingField[SamRow][SamCol + 1] = 'S';
                                        if (PlayingField[SamRow].Contains('N'))
                                        {
                                            int NikoladzeIndex = PlayingField[SamRow].IndexOf('N');
                                            PlayingField[SamRow][NikoladzeIndex] = 'X';
                                            Console.WriteLine("Nikoladze killed!");
                                            goto end;
                                        }
                                        goto restart;
                                    }
                                    break;
                            }
                        }
                    }

                }
                restart:;
            }

            end:;
            for (int row = 0; row < Rows; row++)
            {
                int colCounter = PlayingField[row].Count;
                for (int col = 0; col < colCounter; col++)
                {

                    Console.Write($"{PlayingField[row][col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
