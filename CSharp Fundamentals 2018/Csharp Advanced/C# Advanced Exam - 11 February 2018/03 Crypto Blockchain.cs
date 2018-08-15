using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03_Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Once we find the digits in one crypto block, 
            //split them into threes and convert them
            //to a string of characters by
            //subtracting the length of the entire crypto block from each number individually.

            string input = string.Empty;
            int RowsNumber = int.Parse(Console.ReadLine());
            for (int index = 0; index < RowsNumber; index++)
            {
                string temp = Console.ReadLine();
                input += temp;
            }

            string pattern = @"\[[^\[\{]*?(?<firstExample>\d{3,})[^\]\}]*?\]|\{[^\[\{]*?(?<secondExample>\d{3,})[^\]\}]*?\}";
            Regex RegexPattern = new Regex(pattern);
            Match NeededInfo = RegexPattern.Match(input);
            List<char> DecodedMessage = new List<char>();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                string firstExample = m.Groups["firstExample"].ToString();
                string secondExample = m.Groups["secondExample"].ToString();

                if (firstExample.Length % 3 != 0)
                {
                    firstExample = "";
                }
                if (secondExample.Length % 3 != 0)
                {
                    secondExample = "";
                }
                
                int SequecnceLength = m.Length;
                if (firstExample.Length >= 3)
                {
                    while (firstExample.Length != 0)
                    {
                        int temp = int.Parse(firstExample.Substring(0, 3));
                        firstExample = firstExample.Remove(0, 3);
                        int total = (temp - SequecnceLength);
                        char tempChar = (char)total;
                        DecodedMessage.Add(tempChar);
                    }
                }

                if (secondExample.Length >= 3)
                {
                    while (secondExample.Length != 0)
                    {
                        int temp = int.Parse(secondExample.Substring(0, 3));
                        secondExample = secondExample.Remove(0, 3);
                        int total = (temp - SequecnceLength);
                        char tempChar = (char)total;
                        DecodedMessage.Add(tempChar);
                    }
                }
            }

            Console.Write(string.Join("", DecodedMessage));
        }
    }
}
