using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] CharredInput = input.ToCharArray();

            Queue<string> Queue = new Queue<string>();
            Stack<string> Stack = new Stack<string>();

            string Comparison = string.Empty;

            for (int i = 0; i < CharredInput.Length; i++)
            {
                if (CharredInput[i] == '(')
                {
                    Stack.Push(CharredInput[i].ToString());
                    Comparison += CharredInput[i];
                }
                else if (CharredInput[i] == '{')
                {
                    Stack.Push(CharredInput[i].ToString());
                    Comparison += CharredInput[i];
                }
                else if (CharredInput[i] == '[')
                {
                    Stack.Push(CharredInput[i].ToString());
                    Comparison += CharredInput[i];
                }
                else
                {
                    if (Stack.Count() > 0)
                    {

                        if (Stack.Peek() == "(")
                        {
                            Stack.Pop();
                            Comparison += ')';

                        }
                        else if (Stack.Peek() == "{")
                        {
                            Stack.Pop();
                            Comparison += '}';
                        }
                        else if (Stack.Peek() == "[")
                        {
                            Stack.Pop();
                            Comparison += ']';
                        }
                    }
                }
            }

            if(Comparison == input)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
