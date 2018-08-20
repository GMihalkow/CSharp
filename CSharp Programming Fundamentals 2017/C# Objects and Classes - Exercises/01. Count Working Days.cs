using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

    class Program
    {
        static void Main(string[] args)
         {
             DateTime StartDate = DateTime.ParseExact(
            Console.ReadLine(), "dd-MM-yyyy",
            CultureInfo.InvariantCulture);

             DateTime EndDate = DateTime.ParseExact(
            Console.ReadLine(), "dd-MM-yyyy",
            CultureInfo.InvariantCulture);

        DateTime[] holidays =
     {
             DateTime.ParseExact(
            "01-01-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "03-03-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "01-05-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "06-05-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "24-05-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "06-09-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "22-09-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "01-11-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "24-12-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "25-12-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture),

            DateTime.ParseExact(
            "26-12-2016", "dd-MM-yyyy",
            CultureInfo.InvariantCulture)
        //GO ON HOME
    };

            int CountOfWorkingDays = 0;


           for (DateTime i = StartDate;
            i <= EndDate;
            i = i.AddDays(1))
           {
              if (i.DayOfWeek != DayOfWeek.Saturday
                && i.DayOfWeek != DayOfWeek.Sunday)
              {
                bool isNotHoliday = true;
                foreach (var holiday in holidays)
                {
                    if (holiday.Day == i.Day 
                        && holiday.Month == i.Month)
                    {
                        isNotHoliday = false;
                        break;
                    }
                }
                if (isNotHoliday)
                {
                    CountOfWorkingDays++;
                }
              }
           }
              Console.WriteLine(CountOfWorkingDays);
         }
    }

