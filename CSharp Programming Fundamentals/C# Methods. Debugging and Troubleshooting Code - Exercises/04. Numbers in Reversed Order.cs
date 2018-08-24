using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NUMBERS_IN_REVERSE_ORDER
{
    class Program
    {
        static void Main()
        {
            string number = (Console.ReadLine());
            // string result = string.Empty;
            Console.WriteLine(REVERSED(number));
        }

        static string REVERSED(string number)
        {

            string result = string.Empty;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result += number[i];
            }

            return result;
        }
    }
}
