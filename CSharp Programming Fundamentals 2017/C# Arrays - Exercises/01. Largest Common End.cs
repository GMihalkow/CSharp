using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARRAYS___EXERCISE
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            var firstARR = first.Split(' ').ToArray();
            var secondARR = second.Split(' ').ToArray();

            int ctrl = 0;
            int ctrl1 = 0;
            var start = Math.Min(firstARR.Length, secondARR.Length);

           

            for (int i = 0; i < start; i++)
            {
                if (firstARR[i] == secondARR[i])
                {
                    ctrl++;
                }

            }



            if (ctrl > 0)
            {
                Console.WriteLine(ctrl);
                return;
            }
            Array.Reverse(firstARR);
            Array.Reverse(secondARR);

            for (int i = (start-1); i >= 0 ; i--)
            {
                if (firstARR[i] == secondARR[i])
                {
                    ctrl1++;
                }
            }

            if (ctrl1 > 0)
            {
                Console.WriteLine(ctrl1);
                return;
            }

            if (ctrl == 0 && ctrl1 == 0)
            {
                Console.WriteLine("0");
                return;
            }
            
        }
    }
}
