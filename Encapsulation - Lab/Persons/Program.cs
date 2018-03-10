using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


public class Program
{
    static void Main(string[] args)
    {
        var team = new Team("my team");
        var personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < personsCount; i++)
        {
            var input = Console.ReadLine().Split();
            try
            {
                var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                //persons.Add(person);
                team.AddPlayer(person);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(argex.Message);                
            }
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        //var percentage = decimal.Parse(Console.ReadLine());
        
        //persons.ForEach(p => p.IncreaseSalary(percentage));
        //persons.ForEach(p => Console.WriteLine(p));
        //persons.ForEach(p =>
        //{
        //    p.IncreaseSalary(percentage);
        //    Console.WriteLine(p);
        //});
        //persons.OrderBy(p => p.FirstName)
            //.ThenBy(p => p.Age)
            //.ToList()
            //.ForEach(p => Console.WriteLine(p));

        

    }
}

