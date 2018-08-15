using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Coordinats
{
    private List<Rectangle> rectanglescoordinats = new List<Rectangle>();

    public List<Rectangle> RectanglesCoordinats
    {
        get { return this.rectanglescoordinats; }
        set { this.rectanglescoordinats = value; }
    }

    public void AddingCoordinats(Rectangle rect)
    {
        rectanglescoordinats.Add(rect);
    }

    public void Checkingdecimalersections(string rectangleID1, string rectangleID2)
    {
        decimal Ax1 = 0;
        decimal Ay1 = 0;
        decimal Ax2 = 0;
        decimal Ay2 = 0;

        decimal Bx1 = 0;
        decimal By1 = 0;
        decimal Bx2 = 0;
        decimal By2 = 0;

        foreach (var rect in rectanglescoordinats)
        {
            if (rect.ID == rectangleID1)
            {
                Ax1 = rect.X1;
                Ay1 = rect.Y1;
                Ax2 = rect.X2;
                Ay2 = rect.Y2;
            }

            if (rect.ID == rectangleID2)
            {
                Bx1 = rect.X1;
                By1 = rect.Y1;
                Bx2 = rect.X2;
                By2 = rect.Y2;
            }
        }

        bool X1 = false;
        bool Y1 = false;
        bool X2 = false;
        bool Y2 = false;

        if (Ax1 <= Bx2)
        {
            X1 = true;
        }
        if (Ax2 >= Bx1)
        {
            X2 = true;
        }
        if (Ay1 >= By2)
        {
            Y1 = true;
        }
        if (Ay2 <= By1)
        {
            Y2 = true;
        }

        if (X1 = true && Y1 == true && X2 == true && Y2 == true)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }

    }
}
