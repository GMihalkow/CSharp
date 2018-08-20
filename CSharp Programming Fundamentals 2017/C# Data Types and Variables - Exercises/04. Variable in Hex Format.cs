using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_VARIABLE_IN_HEXADECIMAL_FORMAT
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine("{0}", Convert.ToInt32(text, 16));
        }
    }
}
