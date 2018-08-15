using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_REVERSE_CHARACTERS
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            object obj = Convert.ToString(c) + Convert.ToString(b) + Convert.ToString(a);

            Console.WriteLine(obj);


            //Console.WriteLine("{0}{1}{2}",c,b,a/* Convert.ToString(c), Convert.ToString(b), Convert.ToString(a)*/);

        }
    }
}
