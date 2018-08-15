using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class STUDENT
{
    public string Names { get; set; }
    public List<double> Grades = new List<double>();
    public double AvarageGrades { get; set; }
}
namespace _04_AVARAGE_GRADES
{
    class Program
    {
        static void Main(string[] args)
        {
            int StudentsCount = int.Parse(Console.ReadLine());

            List<STUDENT> ExcellentResults = new List<STUDENT>();

            for (int i = 0; i < StudentsCount; i++)
            {
                string[] Students =
                    Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                STUDENT next = new STUDENT();

                next.Names = Students[0];
                for (int x = 1; x < Students.Length; x++)
                {
                    next.Grades.Add(Convert.ToDouble(Students[x]));
                }
                next.AvarageGrades = next.Grades.Average();

                if (next.AvarageGrades >= 5.00)
                {
                    ExcellentResults.Add(next);
                }
            }
            ExcellentResults =
                ExcellentResults.OrderBy(v => v.Names)
                .ThenByDescending(u => u.AvarageGrades)
                .ToList();

            foreach (var t in ExcellentResults)
            {
                Console.WriteLine($"{t.Names} -> {t.AvarageGrades:F2}");
            }
        }
    }
   
}
