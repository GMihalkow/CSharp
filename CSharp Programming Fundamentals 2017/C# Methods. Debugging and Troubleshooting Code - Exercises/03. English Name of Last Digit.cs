using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _03_ENGLISH_NAME_OF_LAST_DIGIT
{
    class Program
    {
        static void Main(string[] args)
        {
            long number =long.Parse(Console.ReadLine());
            long total = number % 10;
            DIGIT((long)total);
        }
        
        static void DIGIT(long number)
        {
            long total = number % 10;
            string error = string.Empty;

           

            switch (total)
            {
                case 0: Console.WriteLine("zero");break;
                case 1: Console.WriteLine("one"); break;
                case 2: Console.WriteLine("two"); break;
                case 3: Console.WriteLine("three"); break;
                case 4: Console.WriteLine("four"); break;
                case 5: Console.WriteLine("five"); break;
                case 6: Console.WriteLine("six"); break;
                case 7: Console.WriteLine("seven"); break;
                case 8: Console.WriteLine("eight"); break;
                case 9: Console.WriteLine("nine"); break;
                case -1: Console.WriteLine("one"); break;
                case -2: Console.WriteLine("two"); break;
                case -3: Console.WriteLine("three"); break;
                case -4: Console.WriteLine("four"); break;
                case -5: Console.WriteLine("five"); break;
                case -6: Console.WriteLine("six"); break;
                case -7: Console.WriteLine("seven"); break;
                case -8: Console.WriteLine("eight"); break;
                case -9: Console.WriteLine("nine"); break;


            }
        }
    }
}
