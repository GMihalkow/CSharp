using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_INDEX_OF_LETTERS
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letter = Console.ReadLine().ToCharArray();

            char[] alphabet =
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


            for (int i = 0; i < letter.Length; i++)
            {

                for (int x = 0; x < alphabet.Length; x++)
                {
                    if (letter[i] == alphabet[x]) 
                    {
                        Console.WriteLine($"{letter[i]} -> {x}");
                    }
                }
            }

        }
    }
}
