using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Company
{
    private string name;
    private string companyname;
    private string department;
    private decimal salary;

    public Company(string personName, string companyName, string personDepartment, decimal personSalary)
    {
        this.name = personName;
        this.companyname = companyName;
        this.department = personDepartment;
        this.salary = personSalary;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string CompanyName
    {
        get { return this.companyname; }
        set { this.companyname = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }
}

