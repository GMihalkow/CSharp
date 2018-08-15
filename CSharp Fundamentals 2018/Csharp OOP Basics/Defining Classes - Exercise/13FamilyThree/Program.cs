using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DateTime date;
        string personToFind = Console.ReadLine();
        bool IsDate = DateTime.TryParse(personToFind, out date);

        if (IsDate == true)
        {

        }
        else
        {

        }

        string grandmaMemories;
        while ((grandmaMemories = Console.ReadLine()) != "End")
        {
            string[] eldersInfo;
            string elderNames = string.Empty;
            string elderBirthDate = string.Empty;
            

            if (grandmaMemories.Contains("-"))
            {
                eldersInfo =
                    grandmaMemories
                    .Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
            else
            {
                eldersInfo =
                    grandmaMemories
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
        }
    }
}