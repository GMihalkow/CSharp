using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_LOGS_AGGREGATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> UserLogs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var thing =  input.Split(' ').ToArray();
                string User = thing[1];
                string IP = thing[0];
                int Points = int.Parse(thing[2]);

                if (!UserLogs.ContainsKey(User))
                {
                    UserLogs.Add(User, new SortedDictionary<string, int>());
                }
                if (!UserLogs[User].ContainsKey(IP))
                {
                    UserLogs[User][IP] = 0;
                }
                UserLogs[User][IP] += Points;
            }

            foreach (var name in UserLogs)
            {
                Console.Write(name.Key + ":" + " " + name.Value.Values.Sum());
                Console.Write(" [");

                for (int i = 0; i < name.Value.Count; i++)
                {
                    var stuff = name.Value.ElementAt(i);

                    if (i == (name.Value.Count - 1))
                    {
                        Console.Write(stuff.Key);
                        break;
                    }
                    Console.Write(stuff.Key + ", ");
                }

                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}
