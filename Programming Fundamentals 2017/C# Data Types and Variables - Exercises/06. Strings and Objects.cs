using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_STRINGS_AND_OBJECTS
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";

            object obj = hello + " " + world;

            Console.WriteLine(obj);
            
        }
    }
}
