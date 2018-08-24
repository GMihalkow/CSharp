using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_EMPLOYEE_DATA
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Amanda";
            string lastname = "Jonson";
            sbyte age = 27;
            string sex = "f";
            long ID = 8306112507;
            int number = 27563571;

            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID: {4}\nUnique Employee number: {5}",
                name,lastname,age,sex,ID,number);

        }
    }
}
