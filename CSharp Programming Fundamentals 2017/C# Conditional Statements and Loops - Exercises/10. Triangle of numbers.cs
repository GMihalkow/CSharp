using System;

namespace TRIANGLE_OF_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

         

            for (int i = 1; i <= n; i++)
            {
               
                for (int w = 1; w <= i; w++)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }

        }
    }
}

