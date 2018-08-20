using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_VOWEL_OF_DIGIT
{
    class Program
    {
        static void Main(string[] args)
        {

            string vowel = Console.ReadLine();
            string stop = String.Empty;
            switch (vowel)
            {

                case "a":
                case "e": 
                case "i": 
                case "o": 
                
                case "u": 
                case "y":
                    stop = "vowel"; break;

                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    stop = "digit"; break;

                default:
                    stop = "other";
                    break;
            }
            Console.WriteLine(stop);

        }
    }
}
