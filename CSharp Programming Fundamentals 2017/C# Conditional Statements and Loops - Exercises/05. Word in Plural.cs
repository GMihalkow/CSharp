using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORDS_IN_PLURAL
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            
            if (word.EndsWith("y") == true)
            {
                word = word.Replace("y", String.Empty);
                Console.WriteLine("{0}ies", word);
                
            }
            else if (word.EndsWith("o") || word.EndsWith ("ch") || word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z") || word.EndsWith("sh") == true)
            {
                Console.WriteLine("{0}es", word);
            }
            else
            {
                Console.WriteLine("{0}s", word);
            }
        }
    }
}