using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string personName;
    private decimal personSalary;
    private string personPosition;
    private string personEmail;
    private string personAge;
    private List<decimal> averageSalary = new List<decimal>();

    public string PersonName { get { return this.personName; } set { this.personName = value; } }
    public decimal PersonSalary { get { return this.personSalary; } set { this.personSalary = value; } }
    public string PersonPosition { get { return this.personPosition; } set { this.personPosition = value; } }
    public string PersonEmail { get { return this.personEmail; } set { this.personEmail = value; } }
    public string PersonAge { get { return this.personAge; } set { this.personAge = value; } }
    public List<decimal> AverageSalary { get { return this.averageSalary; } set { this.averageSalary = value; } }


    public Employee(string name, decimal salary, string position, string department, string email, string age)
    {
        this.personName = name;
        this.personSalary = salary;
        this.personPosition = position;
        this.personEmail = email;
        this.personAge = age;
    }
}
