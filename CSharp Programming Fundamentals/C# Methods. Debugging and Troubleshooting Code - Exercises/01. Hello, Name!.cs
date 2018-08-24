using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METHODS_DEBUGGING_AND_TROUBLESHOOTING_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            NAME(name);
        }

        static void NAME(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
