using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _10_CENTURIES_TO_NANOSECONDS
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte centuries = sbyte.Parse(Console.ReadLine());

            ulong years = (ulong)centuries * 100;
            double days = (double)years * 365.2422;
            ulong hours = (ulong)days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            BigInteger miliseconds =  seconds * 1000;
            BigInteger macro = miliseconds * 1000;
            BigInteger nanoseconds = miliseconds * 1000000;

            object objC = centuries;
            object objY = years;
            object objD = days;
            object objH = hours;
            object objM = minutes;
            object objS = seconds;
            object objMI = miliseconds;
            object objNa = nanoseconds;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
                centuries, years, (int)days, hours, minutes, seconds, miliseconds, macro, nanoseconds);

        }
    }
}
