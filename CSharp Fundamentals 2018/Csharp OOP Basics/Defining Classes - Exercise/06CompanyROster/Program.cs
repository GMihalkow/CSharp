using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Department printer = new Department();
        List<Department> endEmployees = new List<Department>();
        List<Employee> employees = new List<Employee>();
        int workersCount = int.Parse(Console.ReadLine());

        for (int index = 0; index < workersCount; index++)
        {
            string[] workerInfo =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string workerName = workerInfo[0];
            decimal workerSalary = decimal.Parse(workerInfo[1]);
            string workPosition = workerInfo[2];
            string workerDepartment = workerInfo[3];
            string email = @"n/a";
            string age = @"-1";

            if (workerInfo.Length == 5)
            {
                int num;
                bool IsAge = int.TryParse(workerInfo[4], out num);
                if (IsAge == true)
                {
                    age = workerInfo[4];
                }
                else
                {
                    email = workerInfo[4];
                }
            }
            else if (workerInfo.Length == 6)
            {
                age = workerInfo[5];
                email = workerInfo[4];
            }

            printer.RefreshList(workerDepartment, new Employee(workerName, workerSalary, workPosition, workerDepartment, email, age));
            endEmployees.Add(printer);            
        }
        printer.PrintOutput();
    }

}
