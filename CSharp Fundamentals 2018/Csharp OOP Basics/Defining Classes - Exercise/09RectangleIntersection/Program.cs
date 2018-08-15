using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Coordinats CoordinatsSafe = new Coordinats();

        decimal[] rectanglesAndChecks =
            Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(decimal.Parse)
            .ToArray();

        decimal rectanglesCount = rectanglesAndChecks[0];
        decimal checksCount = rectanglesAndChecks[1];

        //rectangles information
        for (int index = 0; index < rectanglesCount; index++)
        {
            string[] rectangleInfo =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string ID = rectangleInfo[0];
            decimal width = decimal.Parse(rectangleInfo[1]);
            decimal height = decimal.Parse(rectangleInfo[2]);
            decimal x = decimal.Parse(rectangleInfo[3]);
            decimal y = decimal.Parse(rectangleInfo[4]);


            //getting rectangle coordinats 
            decimal x1 = x;
            decimal y1 = y;
            decimal x2 = x + width;
            decimal y2 = y - (height / 2);

            Rectangle rectangle = new Rectangle(ID, x1, y1, x2, y2);
            CoordinatsSafe.AddingCoordinats(rectangle);



        }

        //checks
        for (decimal index = 0; index < checksCount; index++)
        {
            string[] competitors =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (competitors.Length < 2)
            {
                break;
            }
            else
            {
                string firstRectangle = competitors[0];
                string secondRectangle = competitors[1];
                CoordinatsSafe.Checkingdecimalersections(firstRectangle, secondRectangle);

            }


        }
    }
}
