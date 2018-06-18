using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>();
        var numberOfPeople = int.Parse(Console.ReadLine());

        while (numberOfPeople > 0)
        {
            var personData = Console.ReadLine().Split();
            Person person = new Person(personData[0], int.Parse(personData[1]));
            people.Add(person);

            numberOfPeople--;
        }

        var currentPeople = people.Where(a => a.Age > 30).OrderBy(p => p.Name);

        Console.WriteLine(string.Join(Environment.NewLine, currentPeople.Select(p => $"{p.Name} - {p.Age}")));
    
    }
}

