using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FIBONACCI
{
    class Program
    {

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine("1");
                return;
            }

            if (number < 3)
            {
                Console.WriteLine(number);
            
                return;               
            }
            Console.WriteLine(FIBONACCI(number));
        }

        static int FIBONACCI(int number)
        {
            int num = number;

            int first = 0;
            int second = 1;
            //FIBONACCI ALGORITHM
            for (int i = 0 ; i <= number; i++)
            {
                int temp = first;
                first = second;
                second = temp + first;
            }


            return first;
        }
    }
}
