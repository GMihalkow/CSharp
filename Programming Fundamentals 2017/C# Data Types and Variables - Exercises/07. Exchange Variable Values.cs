using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXCHANGE_VARIABLE_VALUES
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte five = 5;
            sbyte ten = 10;

            sbyte neW = five;
            sbyte neWW = ten;

            Console.WriteLine("Before:");
            Console.WriteLine("a = {0}\nb = {1}\nAfter:\na = {2}\nb = {3}", five, ten, neWW, neW);
        }
    }
}
