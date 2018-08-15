using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class DateModifier
{
    public DateTime startDate;
    public DateTime endDate;
    public TimeSpan remainder;

    public DateTime Parse(string firstDate)
    {
        var date = DateTime.Parse(firstDate);
        return date;
    }

    public void DaysExcluder(DateTime startDate, DateTime endDate)
    {
        remainder = startDate - endDate;
        Console.WriteLine(Math.Abs(remainder.Days));
    }
}
