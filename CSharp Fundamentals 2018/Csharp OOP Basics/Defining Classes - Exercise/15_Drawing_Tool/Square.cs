using System;
using System.Collections.Generic;
using System.Text;

public class Square
{
    private int size;

    public Square()
    {

    }

    public Square(int s)
    {
        this.size = s;
    }

    public void Draw(int s)
    {
        for (int index = 1; index <= s; index++)
        {
            Console.Write("|");
            if (index == 1 || index == s)
            {
                Console.Write(new string('-', s));
            }
            else
            {
                Console.Write(new string(' ', s));
            }
            Console.Write("|");
            Console.WriteLine();
        }
    }
}