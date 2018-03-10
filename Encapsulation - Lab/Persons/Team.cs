using System;
using System.Collections.Generic;
using System.Text;


public class Team
{
    private List<Person> firstTeam;

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
        //set { firstTeam = value; }
    }
    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
        //set { reserveTeam = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public Team(string name)
    {
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
        this.name = name;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);    
        }
    }
}
