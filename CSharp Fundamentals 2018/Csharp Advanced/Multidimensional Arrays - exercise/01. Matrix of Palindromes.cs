using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Multidimensional_Arrays___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int FirstLetter = 97;

            string[,] Sequence = new string[rows, cols];

            int temp = 97;

            int a = temp;
            int b = temp;
            int c = temp;

            string textA = Encoding.ASCII.GetString(new byte[] { (byte)a });
            string textB = Encoding.ASCII.GetString(new byte[] { (byte)b });
            string textC = Encoding.ASCII.GetString(new byte[] { (byte)c });

            for (int row = 0; row < rows; row++)
            {
                a = temp;
                b = temp;
                c = temp;

                textA = Encoding.ASCII.GetString(new byte[] { (byte)a });
                textB = Encoding.ASCII.GetString(new byte[] { (byte)b });
                textC = Encoding.ASCII.GetString(new byte[] { (byte)c });

                for (int col = 0; col < cols; col++)
                {
                    textB = Encoding.ASCII.GetString(new byte[] { (byte)b }); 
                    Sequence[row, col] = (textA + textB + textC).ToString();
                    Console.Write(Sequence[row, col]);
                    b++;
                    
                       
                        Console.Write(" ");

                    
                }
                temp++;
                Console.WriteLine();
            }
        }
    }
}
