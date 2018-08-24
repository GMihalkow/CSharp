using System;

namespace _01_SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int studentsAnswered = 0;

            int hours = 0;

            while (studentsAnswered < studentsCount)
            {
                hours++;
                if (hours % 4 == 0) continue;

                studentsAnswered += firstEmployee;
                studentsAnswered += secondEmployee;
                studentsAnswered += thirdEmployee;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
