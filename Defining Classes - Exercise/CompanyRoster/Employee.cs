using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{
    private string name;
    private int age;
    private decimal salary;
    private string position;
    private string email;
    private string department;

    public Employee(string name, decimal salary, string position,  string department)
    {
        this.name = name;        
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.age = -1;
        this.email = "n/a";
    }
    public string Name { get; set; }
    public int Age { 
        set { this.age = value; } 
    }
    public decimal Salary { get { return this.salary; } }
    public string Position { get; set; }
    public string Email { 
        set { this.email = value; } }
    public string Department { get { return this.department; } }

    //public Employee(string name, int age, decimal salary, 
    //    string position,string department)
    //    :this(name, salary, position, department)
    //{
    //    this.age = age;
    //}
    //
    //public Employee(string name, string email, decimal salary,
    //    string position, string department)
    //    : this(name, salary, position, department)
    //{
    //    this.email = email;
    //}   

    public string PrintEmployeeInfo()
    {
        return $"{this.name} {this.salary:f2} {this.email} {this.age}";
    }


}

