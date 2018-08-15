using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Department
{
    private Dictionary<string, List<Employee>> outputWorkers = new Dictionary<string, List<Employee>>();
    private string department;
    private List<decimal> averageSalaries = new List<decimal>();

    public Dictionary<string, List<Employee>> OutputWorkers { get { return this.outputWorkers; } set { this.outputWorkers = value; } }
    public string NewDepartment { get { return this.department; } set { this.department = value; } }

    public void RefreshList(string departm, Employee emp)
    {
        this.department = departm;
        if (outputWorkers.ContainsKey(departm))
        {
            outputWorkers[departm].Add(emp);
        }
        else
        {
            outputWorkers.Add(departm, new List<Employee>());
            outputWorkers[departm].Add(emp);
        }
    }


    public void PrintOutput()
    {
        foreach (var department in outputWorkers.OrderByDescending(w=>w.Value.Select(p => p.PersonSalary).Average()))
        {
            Console.WriteLine($"Highest Average Salary: {department.Key}");
            foreach (var worker in department.Value.OrderByDescending(x => x.PersonSalary))
            {
                Console.WriteLine($"{worker.PersonName} {worker.PersonSalary:f2} {worker.PersonEmail} {worker.PersonAge}");
            }
            break;
        }
    }
}