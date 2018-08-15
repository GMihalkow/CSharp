using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COUNT_THE_INTEGERS
{
    class Program
    {
        static void Main(string[] args)
        {

            var total = 0;


            for (int i = 1; i <= 101; i++)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    total++;
                }
                catch (Exception)
                {
                    Console.WriteLine("{0}", total);
                    return;
                }
            }
        }
    }
}
