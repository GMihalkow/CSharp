using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BOOLEN_VARIABLE
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesORno = Console.ReadLine();

            if (yesORno == "True")
            {
                Console.WriteLine("Yes", Convert.ToBoolean(yesORno));
            }
            else
            {
                Console.WriteLine("No", Convert.ToBoolean(yesORno));
            }

        }
    }
}
    