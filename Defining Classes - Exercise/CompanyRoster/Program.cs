using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var numberOfEmployee = int.Parse(Console.ReadLine());
        Employee employee;

        var employees = new List<Employee>();
        for (int i = 0; i < numberOfEmployee; i++)
        {
            var employeeInfo = Console.ReadLine().Split(' ');

            employee = new Employee(
                employeeInfo[0],
                decimal.Parse(employeeInfo[1]),
                employeeInfo[2], employeeInfo[3]);

            if (employeeInfo.Length > 4)
            {
                if (int.TryParse(employeeInfo[4], out int age))
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = employeeInfo[4];
                }
            }
            if (employeeInfo.Length > 5)
            {
                employee.Age = int.Parse(employeeInfo[5]);
            }
            
            employees.Add(employee);
        }

        var depart = employees
            .GroupBy(em => em.Department)
            .Select(gr => new
            {
                Name = gr.Key,
                AvarageSalary = gr.Average(em => em.Salary),
                Employees = gr
            })
            .OrderByDescending(gr => gr.AvarageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {depart.Name}");
        foreach (var emp in depart.Employees.OrderByDescending(em => em.Salary))
        {
            Console.WriteLine(emp.PrintEmployeeInfo());
        }
    }
}

