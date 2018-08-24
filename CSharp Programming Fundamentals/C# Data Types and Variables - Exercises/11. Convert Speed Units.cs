using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            int DistanceInMeters = int.Parse(Console.ReadLine());
            byte hours = byte.Parse(Console.ReadLine());
            byte minutes = byte.Parse(Console.ReadLine());
            byte seconds = byte.Parse(Console.ReadLine());

            float TotalSeconds = (hours * 3600) + (minutes * 60) + (seconds * 1);
            float TotalHours = hours + minutes / 60.0f + seconds / 3600.0f;

            float MetersPerSecond = DistanceInMeters / TotalSeconds;
            float KilometersPerHour = (DistanceInMeters / 1000.0f) / TotalHours;
            float MilesPerHour = (DistanceInMeters / 1609.0f) / (TotalHours);

            Console.WriteLine($"{MetersPerSecond}");
            Console.WriteLine($"{KilometersPerHour}");
            Console.WriteLine($"{MilesPerHour}");
        }
    }
}
