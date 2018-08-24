using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_INTERSECTION_OF_CIRCLES
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Intersept = true;

            CIRCLE c = new CIRCLE() {
                X =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray()
            };
            CIRCLE c1 = new CIRCLE() { Y = 
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray()};

            double Distance = Math.Sqrt(Math.Pow((c1.Y[0] - c.X[0]), 2) + Math.Pow((c1.Y[1] - c.X[1]), 2));

            if (Distance <= (c.X[2] + c1.Y[2]))
            {
                Intersept = true;
                Console.WriteLine("Yes");
            }
            else
            {
                Intersept = false;
                Console.WriteLine("No");
            }
        }
        
    }

    class CIRCLE
    {
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public int R { get; set; }

        
    }


}
