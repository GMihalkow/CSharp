using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessonsSchedule =
                Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "course start")
            {
                string[] commands =
                     input
                     .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                if (commands.Count() == 0)
                {
                    continue;
                }
                string command = commands[0];

                switch (command)
                {
                    case "Add":
                        {
                            Add(commands, lessonsSchedule);
                        }
                        break;
                    case "Remove":
                        {
                            Remove(commands, lessonsSchedule);
                        }
                        break;
                    case "Insert":
                        {
                            Insert(commands, lessonsSchedule);
                        }
                        break;
                    case "Swap":
                        {
                            Swap(commands, lessonsSchedule);
                        }
                        break;
                    case "Exercise":
                        {
                            Exercise(commands, lessonsSchedule);
                        }
                        break;
                    default:
                        continue;
                }
            }


            for (int index = 0; index < lessonsSchedule.Count; index++)
            {
                Console.WriteLine($"{index + 1}.{lessonsSchedule[index]}");
            }
        }

        private static void Add(string[] commands, List<string> lessonsSchedule)
        {
            string lesson = commands[1];
            if (lessonsSchedule.Count() == 0)
            {
                lessonsSchedule.Add(lesson);
                return;
            }
            if ((lessonsSchedule.Any(l => l == lesson)) == true) return;

            lessonsSchedule.Add(lesson);
        }

        private static void Remove(string[] commands, List<string> lessonsSchedule)
        {
            string lesson = commands[1];
            if (lessonsSchedule.Count() == 0)
            {
                return;
            }
            if ((lessonsSchedule.Any(l => l == lesson) == true))
            {
                lessonsSchedule.Remove(lesson);
            }
            else if ((lessonsSchedule.Any(l => l == lesson + "-Exercise") == true))
            {
                lessonsSchedule.Remove(lesson + "-Exercise");
            }
            else
            {
                return;
            }
        }

        private static void Insert(string[] commands, List<string> lessonsSchedule)
        {
            string lesson = commands[1];
            int index;
            bool IsInteger = int.TryParse(commands[2], out index);
            if (IsInteger == false) return;

            if (lessonsSchedule.Count() == 0) return;
            if (commands.Count() < 3) return;

            if (index < 0 || index >= lessonsSchedule.Count) return;
            else if ((lessonsSchedule.Any(l => l == lesson)) == true) return;

            lessonsSchedule.Insert(index, lesson);
        }

        private static void Swap(string[] commands, List<string> lessonsSchedule)
        {
            if (lessonsSchedule.Count() == 0) return;
            if (commands.Count() < 3) return;

            if ((lessonsSchedule.Any(l => l == commands[1])) == false) return;
            if ((lessonsSchedule.Any(l => l == commands[2]) == false)) return;

            string firstLesson = lessonsSchedule.First(l => l == commands[1]);
            string secondLesson = lessonsSchedule.First(l => l == commands[2]);

            int firstIndex = lessonsSchedule.IndexOf(firstLesson);
            int secondIndex = lessonsSchedule.IndexOf(secondLesson);

            lessonsSchedule[firstIndex] = secondLesson;
            lessonsSchedule[secondIndex] = firstLesson;

            if ((lessonsSchedule.Any(l => l == secondLesson + "-Exercise")) == true)
            {
                string exercise = lessonsSchedule.First(l => l == secondLesson + "-Exercise");

                lessonsSchedule.Remove(exercise);
                lessonsSchedule.Insert(firstIndex + 1, exercise);
            }

            firstIndex = lessonsSchedule.IndexOf(firstLesson);
            secondIndex = lessonsSchedule.IndexOf(secondLesson);

            if ((lessonsSchedule.Any(l => l == firstLesson + "-Exercise")) == true)
            {
                string exercise = lessonsSchedule.First(l => l == firstLesson + "-Exercise");

                lessonsSchedule.Remove(exercise);
                lessonsSchedule.Insert(secondIndex + 1, exercise);
            }
        }

        private static void Exercise(string[] commands, List<string> lessonsSchedule)
        {
            string lesson = commands[1];
            if (commands.Count() < 2) return;

            if (lessonsSchedule.Count() == 0)
            {
                lessonsSchedule.Add(lesson);
                int lessonIndex = lessonsSchedule.IndexOf(lesson);
                lessonsSchedule.Insert(lessonIndex + 1, lesson + "-Exercise");
                return;
            }

            if (lessonsSchedule.Any(l => l == lesson + "-Exercise") == true) return;

            if ((lessonsSchedule.Any(l => l == lesson) == true))
            {
                int lessonIndex = lessonsSchedule.IndexOf(lesson);
                lessonsSchedule.Insert(lessonIndex + 1, lesson + "-Exercise");
            }
            else
            {
                lessonsSchedule.Add(lesson);
                lessonsSchedule.Add(lesson + "-Exercise");
            }
        }
    }
}
