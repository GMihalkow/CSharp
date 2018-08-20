using System;

namespace _05_Cat_Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //top part of the watch
            for (int index = 0; index < n - 2; index++)
            {
                Console.Write(new string(' ', n));
                Console.WriteLine(new string('|', 2) + new string('_', n - 2) + new string('|', 2));
            }

            //middle part of the watch
            Console.WriteLine(new string(' ', n - 1) + "//" + new string(' ', n) + "\\\\");
            for (int index = 0; index < n - 4; index++)
            {
                if (n % 2 != 0 && index == n / 2 - 2)
                {
                    Console.WriteLine(new string(' ', n - 2) + "||" + new string(' ', n + 2) + "||" + "]");
                }
                else if(n % 2 == 0 && index == (n - 4) / 2 - 1)
                {
                    Console.WriteLine(new string(' ', n - 2) + "||" + new string(' ', n + 2) + "||" + "]");
                }
                else
                {
                    Console.WriteLine(new string(' ', n - 2) + "||" + new string(' ', n + 2) + "||");
                }
            }
            Console.WriteLine(new string(' ', n - 1) + "\\\\" + new string(' ', n) + "//");

            //bottom part of the watch
            for (int index = 0; index < n - 2; index++)
            {
                Console.Write(new string(' ', n));
                Console.WriteLine(new string('|', 2) + new string('_', n - 2) + new string('|', 2));
            }

            //input 5
            //output

            //       || ___ ||
            //       || ___ ||
            //       || ___ ||
            //       //     \\
            //      ||       ||]
            //       \\     //
            //       || ___ ||
            //       || ___ ||
            //       || ___ ||
        }
    }
}
