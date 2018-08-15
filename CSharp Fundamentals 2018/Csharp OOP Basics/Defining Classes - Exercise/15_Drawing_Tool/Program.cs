using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square();
        Rectangle rectangle = new Rectangle();

        string figureName = Console.ReadLine();

        switch (figureName)
        {
            case "Rectangle":
                {
                    int width = int.Parse(Console.ReadLine());
                    int height = int.Parse(Console.ReadLine());
                    rectangle.Draw(width, height);
                }
                break;
            case "Square":
                {
                    int size = int.Parse(Console.ReadLine());
                    square.Draw(size);
                }
                break;
        }

        
        
    }
}
