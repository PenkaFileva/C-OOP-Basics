using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private const decimal MIN_SALARY = 460;
    private const int MIN_LENGHT = 3;
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < MIN_SALARY)
            {
                throw  new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }
            salary = value;
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value?.Length < MIN_LENGHT)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }
    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value?.Length < MIN_LENGHT)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
               throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            this.age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary)
        : this(firstName, lastName, age)
    {       
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age > 30)
        {
            salary = salary + salary * (percentage / 100);
        }
        else
        {
            salary = salary + salary * (percentage / 200);
        }
    }
    public override string ToString()
    {
        //return $"{this.firstName} {this.lastName} is {this.age} years old.";
        return $"{this.firstName} {this.lastName} gets {this.salary:f2} leva.";
    }
}

