using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTRAUNT_DISCOUNT
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string pack = Console.ReadLine();

            var total = 0.0;
            var percent = 0.0;
            var end = 0.0;

            var small = 2500;
            var terra = 5000;
            var great = 7500;



            if (group > 0 && group <= 50)
            {

                /*  total = group + 500;
                  percent = total - (total * 0.15);
                  end = percent / group;*/

                switch (pack)
                {
                    case "Normal":
                        {
                            var normal = 500; total = small + normal; percent = total - (total * 0.05); end = percent / group;
                            Console.WriteLine("We can offer you the Small Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                    case "Gold":
                        {
                            var gold = 750; total = small + gold; percent = total - (total * 0.10); end = percent / group;
                            Console.WriteLine("We can offer you the Small Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                    case "Platinum":
                        {
                            var plat = 1000; total = small + plat; percent = total - (total * 0.15); end = percent / group;
                            Console.WriteLine("We can offer you the Small Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                }


            }
            else if (group > 50 && group <= 100)
            {

                /*  total = group + 500;
                  percent = total - (total * 0.15);
                  end = percent / group;*/

                switch (pack)
                {
                    case "Normal":
                        {
                            var normal = 500; total = terra + normal; percent = total - (total * 0.05); end = percent / group;
                            Console.WriteLine("We can offer you the Terrace");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                    case "Gold":
                        {
                            var gold = 750; total = terra + gold; percent = total - (total * 0.10); end = percent / group;
                            Console.WriteLine("We can offer you the Terrace");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;

                    case "Platinum":
                        {
                            var plat = 1000; total = terra + plat; percent = total - (total * 0.15); end = percent / group;
                            Console.WriteLine("We can offer you the Terrace");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                }


            }

            else if (group > 100 && group <= 120)
            {

                /*  total = group + 500;
                  percent = total - (total * 0.15);
                  end = percent / group;*/

                switch (pack)
                {
                    case "Normal":
                        {
                            var normal = 500; total = great + normal; percent = total - (total * 0.05); end = percent / group;
                            Console.WriteLine("We can offer you the Great Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;

                    case "Gold":
                        {
                            var gold = 750; total = great + gold; percent = total - (total * 0.10); end = percent / group;
                            Console.WriteLine("We can offer you the Great Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;

                    case "Platinum":
                        {
                            var plat = 1000; total = great + plat; percent = total - (total * 0.15); end = percent / group;
                            Console.WriteLine("We can offer you the Great Hall");
                            Console.WriteLine("The price per person is {0:f2}$", end);
                        }
                        break;
                }
            }
            else if (group <= 0 || group > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }

        }
       

    }
}
