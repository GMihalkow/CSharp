using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private int width;
    private int height;
    
    public Rectangle()
    {
    }
    public Rectangle(int w, int h)
    {
        this.width = w;
        this.height = h;
    }

    public void Draw(int w, int h)
    {
        for (int index = 1; index <= h; index++)
        {
            Console.Write("|");
            if (index == 1 || index == h)
            {
                Console.Write(new string('-', w));
            }
            else
            {
                Console.Write(new string(' ', w));
            }
            Console.Write("|");
            Console.WriteLine();
        }
    }
}