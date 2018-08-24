using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FIX_EMAILS
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = new Dictionary<string, string>();
            List<string> email = new List<string>();
            List<string> other = new List<string>();

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                string mail = Console.ReadLine();

                if (mail.Contains("bg"))
                {
                    all.Add(name, mail);
                }
            }

            foreach (var poshta in all)
            {
                Console.WriteLine($"{poshta.Key} -> {poshta.Value}");
            }
        }
    }
}
