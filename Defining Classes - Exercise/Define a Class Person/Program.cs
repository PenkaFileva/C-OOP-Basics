using System;


public class Program
{
    static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(Console.ReadLine());
        var famili = new Family();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personInfo = Console.ReadLine().Split(' ');
            string personName = personInfo[0];
            int personAge = int.Parse(personInfo[1]);
            var person = new Person(personName, personAge);
            //person.Name = personName;
            //person.Age = personAge;
            famili.AddMember(person);
        }
        var oldestPerson = famili.GetOldestMember();       
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

