using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            var percent = 0.0;
            var percent1 = 0.0;
            var percent2 = 0.0;

            var total = 0.0;
            var total1 = 0.0;
            var total2 = 0.0;

            var MAYandOCTs = 50.0;
            var MAYandOCTd = 65.0;
            var MAYandOCTsu = 75.0;

            var JUNEandSEPTs = 60.0; 
            var JUNEandSEPTd = 72.0;
            var JUNEandSEPTsu = 82.0;

            var JULYAandAUGandDECs = 68.0;
            var JULYAandAUGandDECd= 77.0;
            var JULYAandAUGandDECsu = 89.0;

            if (nights > 7 && nights <= 14 && (month == "May" || month == "October" || month == "September") )
            {

                if (nights > 7 && nights <= 14 &&  (month == "May" || month == "October" ))
                {


                    switch (month)
                    {
                        case "May":
                            {
                                percent = MAYandOCTs - (MAYandOCTs * 0.05);
                                percent1 = MAYandOCTd - (MAYandOCTd * 0.05);
                                percent2 = MAYandOCTsu - (MAYandOCTsu * 0.05);

                                total = nights * percent; total1 = nights * MAYandOCTd; total2 = nights * MAYandOCTsu;
                                Console.WriteLine("Studio: {0:f2} lv.", total);
                                Console.WriteLine("Double: {0:f2} lv.", total1);
                                Console.WriteLine("Suite: {0:f2} lv.", total2);
                            }
                            return;
                        case "October":
                            {
                                percent = MAYandOCTs - (MAYandOCTs * 0.05);
                                percent1 = MAYandOCTd - (MAYandOCTd * 0.05);
                                percent2 = MAYandOCTsu - (MAYandOCTsu * 0.05);

                                total = (nights * percent) - percent; total1 = nights * MAYandOCTd; total2 = nights * MAYandOCTsu;
                                Console.WriteLine("Studio: {0:f2} lv.", total);
                                Console.WriteLine("Double: {0:f2} lv.", total1);
                                Console.WriteLine("Suite: {0:f2} lv.", total2);
                            }
                            return;

                    }

                }
                else if (nights > 7 && nights <= 14 && (month == "September"))
                {
                    switch (month)
                    {
                        
                           
                        case "September":
                            {
                                percent = JUNEandSEPTs - (JUNEandSEPTs * 0.10);
                                percent1 = JUNEandSEPTd - (JUNEandSEPTd * 0.10);
                                percent2 = JUNEandSEPTsu - (JUNEandSEPTsu * 0.10);

                                total = (nights * JUNEandSEPTs) - JUNEandSEPTs; total1 = nights * JUNEandSEPTd; total2 = nights * JUNEandSEPTsu;
                                Console.WriteLine("Studio: {0:f2} lv.", total);
                                Console.WriteLine("Double: {0:f2} lv.", total1);
                                Console.WriteLine("Suite: {0:f2} lv.", total2);
                            }
                            return;
                    }
                }

            }

            else if (nights > 14 && (month == "June" || month == "September"))
            {
                switch (month)
                {
                    case "June":
                        {
                            percent = JUNEandSEPTs - (JUNEandSEPTs * 10);
                            percent1 = JUNEandSEPTd - (JUNEandSEPTd * 0.10);
                            percent2 = JUNEandSEPTsu - (JUNEandSEPTsu * 0.10);

                            total = nights * JUNEandSEPTs; total1 = nights * percent1; total2 = nights * JUNEandSEPTsu;
                            Console.WriteLine("Studio: {0:f2} lv.", total);
                            Console.WriteLine("Double: {0:f2} lv.", total1);
                            Console.WriteLine("Suite: {0:f2} lv.", total2);
                        }
                        return;
                    case "September":
                        {
                            percent = JUNEandSEPTs - (JUNEandSEPTs * 0.10);
                            percent1 = JUNEandSEPTd - (JUNEandSEPTd * 0.10);
                            percent2 = JUNEandSEPTsu - (JUNEandSEPTsu * 0.10);

                            total = nights * JUNEandSEPTs; total1 = nights * percent1; total2 = nights * JUNEandSEPTsu;
                            Console.WriteLine("Studio: {0:f2} lv.", total);
                            Console.WriteLine("Double: {0:f2} lv.", total1);
                            Console.WriteLine("Suite: {0:f2} lv.", total2);
                        }
                        return;
                }
            }


            else if (nights > 14 && (month == "July" || month == "August" || month == "December"))
            {
                switch (month)
                {
                    case "July":
                        {
                            percent = JULYAandAUGandDECs - (JULYAandAUGandDECs * 15);
                            percent1 = JULYAandAUGandDECd - (JULYAandAUGandDECd * 0.15);
                            percent2 = JULYAandAUGandDECsu - (JULYAandAUGandDECsu * 0.15);

                            total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = percent2 * nights;
                            Console.WriteLine("Studio: {0:f2} lv.", total);
                            Console.WriteLine("Double: {0:f2} lv.", total1);
                            Console.WriteLine("Suite: {0:f2} lv.", total2);
                        }
                        return;
                    case "August":
                        {
                            percent = JULYAandAUGandDECs - (JULYAandAUGandDECs * 0.15);
                            percent1 = JULYAandAUGandDECd - (JULYAandAUGandDECd * 0.15);
                            percent2 = JULYAandAUGandDECsu - (JULYAandAUGandDECsu * 0.15);

                            total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = percent2 * nights;
                            Console.WriteLine("Studio: {0:f2} lv.", total);
                            Console.WriteLine("Double: {0:f2} lv.", total1);
                            Console.WriteLine("Suite: {0:f2} lv.", total2);
                        }
                        return;
                    case "December":
                        {
                            percent = JULYAandAUGandDECs - (JULYAandAUGandDECs * 0.15);
                            percent1 = JULYAandAUGandDECd - (JULYAandAUGandDECd * 0.15);
                            percent2 = JULYAandAUGandDECsu - (JULYAandAUGandDECsu * 0.15);

                            total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = percent2 * nights;
                            Console.WriteLine("Studio: {0:f2} lv.", total);
                            Console.WriteLine("Double: {0:f2} lv.", total1);
                            Console.WriteLine("Suite: {0:f2} lv.", total2);
                        }
                        return;
                }
            }

            switch (month)
            {
                case "May":
                    {
                        total = nights * MAYandOCTs; total1 = nights * MAYandOCTd; total2 = nights * MAYandOCTsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;
                case "October":
                    {
                        total = nights * MAYandOCTs; total1 = nights * MAYandOCTd; total2 = nights * MAYandOCTsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;

                case "June":
                    {
                        total = nights * JUNEandSEPTs; total1 = nights * JUNEandSEPTd; total2 = nights * JUNEandSEPTsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;
                case "September":
                    {
                        total = nights * JUNEandSEPTs; total1 = nights * JUNEandSEPTd; total2 = nights * JUNEandSEPTsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;

                case "July":
                    {
                        total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = nights * JULYAandAUGandDECsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;
                case "August":
                    {
                        total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = nights * JULYAandAUGandDECsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;
                case "December":
                    {
                        total = nights * JULYAandAUGandDECs; total1 = nights * JULYAandAUGandDECd; total2 = nights * JULYAandAUGandDECsu;
                        Console.WriteLine("Studio: {0:f2} lv.", total);
                        Console.WriteLine("Double: {0:f2} lv.", total1);
                        Console.WriteLine("Suite: {0:f2} lv.", total2);
                    }
                    break;
            }

        }
    }
}
