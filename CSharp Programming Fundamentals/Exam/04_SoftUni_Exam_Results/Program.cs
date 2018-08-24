using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            string pattern = @"^(.*?)\-(.*?)\-([0-9]+)$";
            Regex regex = new Regex(pattern);

            string bannedPattern = @"^(.+?)-banned$";
            Regex bannedRegex = new Regex(bannedPattern);

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                if (bannedRegex.Match(input).Success == true)
                {
                    var bannedMatch = bannedRegex.Match(input);
                    var bannedGroups = bannedMatch.Groups;
                    string studentToBan = bannedGroups[1].ToString();

                    students.Remove(studentToBan);
                    continue;
                }

                if (regex.Match(input).Success == false) continue;
               
                var match = regex.Match(input);
                var groups = match.Groups;

                string studentName = groups[1].ToString();
                string course = groups[2].ToString();
                int points = int.Parse(groups[3].ToString());

                if (submissions.ContainsKey(course) == false)
                {
                    submissions.Add(course, 1);
                }
                else
                {
                    submissions[course]++;
                }

                if (students.ContainsKey(studentName))
                {
                    if (students[studentName].ContainsKey(course))
                    {
                        if (students[studentName][course] < points)
                        {
                            students[studentName][course] = points;
                        }
                    }
                    continue;
                }
                students.Add(studentName, new Dictionary<string, int>());
                students[studentName].Add(course, points);
            }

            students =
                students
                .OrderByDescending(x => x.Value.Values.Max())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in students)
            {
                foreach (var value in student.Value)
                {
                    Console.WriteLine($@"{student.Key} | {value.Value}");
                }
            }
            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
