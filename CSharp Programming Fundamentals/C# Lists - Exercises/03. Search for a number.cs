using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SEARCH_FOR_A_NUMBER
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                 Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            int[] numbersA =
                Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            //FIRST REPRESENTS HOW MANY NUMBERS YOU HAVE TO TAKE FROM THE LIST
            //SECOND REPRESENTS HOW MANY YOU SHOULD DELETE
            //THIRD REPRESENTS WHICH NUMBER WE HAVE TO SEARCH FOR

            numbers.Take(numbersA[0]).ToList(); 
            numbers.RemoveRange(0, numbersA[1]);
            if (numbers.Contains(numbersA[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }


            
        }
    }
}
