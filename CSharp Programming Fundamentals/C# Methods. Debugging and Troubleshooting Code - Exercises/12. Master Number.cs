using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_MASTER_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            MASTERNUM(number);
        }
        
        static int MASTERNUM(int number)
        {
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i > 99 && i < 1000)
                {
                    var total = i % 10;
                    var total1 = (i/10) % 10;
                    var total2 = i / 100 % 10;

                    var sum = total + total1 + total2;

                    if (sum % 7 == 0)
                    {
                        for (int w = 0; w < 1; w++)
                        {                          
                            num2 = num2 * 10 + (i / 100) % 10;
                            num1 = num1 * 10 + (i / 10) % 10;
                            num = num * 10 + i % 10;                      
                        }

                        if (total == total2 || ((num == total2 && num1 == total1) && num2 == total))
                        {
                            if (total % 2 == 0 || total2 % 2 == 0 || total1 % 2 == 0)
                            {
                                Console.WriteLine(i);
                            }
                        }

                    }
                }


                if (i > 0 && i < 100)
                {
                    var total = i % 10;
                    var total1 = (i / 10) % 10;
                  
                    var sum = total + total1;

                    if (sum % 7 == 0)
                    {
                        for (int w = 0; w < 1; w++)
                        {
                            num1 = num1 * 10 + (i / 10) % 10;
                            num = num * 10 + i % 10;
                        }

                        if (total1 == total || ((num == total1 && num1 == total)))
                        {
                            if (total % 2 == 0 || total1 % 2 == 0)
                            {
                                Console.WriteLine(i);

                            }
                        }

                    }
                }

                if (i > 999 && i < 9999)
                {
                    var total = i % 10;
                    var total1 = (i / 10) % 10;
                    var total2 = i / 100 % 10;
                    var total3 = i / 1000 % 10;

                    var sum = total + total1 + total2 + total3;

                    if (sum % 7 == 0)
                    {
                        for (int w = 0; w < 1; w++)
                        {
                            num3 = num3 * 10 + (i / 1000) % 10;
                            num2 = num2 * 10 + (i / 100) % 10;
                            num1 = num1 * 10 + (i / 10) % 10;
                            num = num * 10 + i % 10;
                        }

                        if (total == total3 && total1 == total2 ||  ((num == total3 && num1 == total1) && num2 == total2 && num3 == total ))
                        {
                            if (total % 2 == 0 || total2 % 2 == 0 || total1 % 2 == 0 || total3 % 2 == 0)
                            {
                                Console.WriteLine(i);
                            }
                        }

                    }
                }
            

            if (i > 9999 && i < 99999)
            {
                var total = i % 10;
                var total1 = (i / 10) % 10;
                var total2 = i / 100 % 10;
                var total3 = i / 1000 % 10;
                var total4 = i / 10000 % 10;

                var sum = total + total1 + total2 + total3 + total4;

                if (sum % 7 == 0)
                {
                    for (int w = 0; w < 1; w++)
                    {
                        num4 = num4 * 10 + (i / 10000) % 10;
                        num3 = num3 * 10 + (i / 1000) % 10;
                        num2 = num2 * 10 + (i / 100) % 10;
                        num1 = num1 * 10 + (i / 10) % 10;
                        num = num * 10 + i % 10;
                    }

                    if (total == total4 && (total1 == total3) || ((num == total4 && num1 == total3) && num2 == total2 && num3 == total1 && num4 == total))
                    {
                        if (total % 2 == 0 || total2 % 2 == 0 || total1 % 2 == 0 || total3 % 2 == 0 || total4 % 2 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }

                }
            }
        }
            return number;
        }
    }
}
