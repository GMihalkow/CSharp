using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MAX_METHOD
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNUMBER = int.Parse(Console.ReadLine());
            int SECONDNUMBER= int.Parse(Console.ReadLine());
            int thirdNUMBER = int.Parse(Console.ReadLine());

            GetMax(firstNUMBER,SECONDNUMBER,thirdNUMBER);
        }

        static void GetMax(int firstNUMBER, int SECONDNUMBER, int thirdNUMBER)
        {
            if (firstNUMBER > SECONDNUMBER && firstNUMBER > thirdNUMBER)
            {
                Console.WriteLine(firstNUMBER);
            }
            else if (SECONDNUMBER > firstNUMBER && SECONDNUMBER > thirdNUMBER)
            {
                Console.WriteLine(SECONDNUMBER);
            }
            else
            {
                Console.WriteLine(thirdNUMBER);
            }
        }
    }
}
