using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DIFFERENT_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n1 = int.Parse(Console.ReadLine());

            var total = n;

            if ((n1 - n) < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = n; i <= n1; i++)
                {

                    for (int w = i; w <= n1; w++)
                    {

                        for (int r = w; r <= n1; r++)
                        {

                            for (int q = r; q <= n1; q++)
                            {

                                for (int z = q; z <= n1; z++)
                                {
                                    if (q < z && r < q && w < r && i < w)
                                    {


                                        Console.WriteLine("{0} {1} {2} {3} {4}", i, w, r, q, z);

                                    }
                                }


                            }


                        }




                    }
                }
            }
        }
    }
}
