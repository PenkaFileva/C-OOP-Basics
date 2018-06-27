using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Trainer
{
    //name, number of badges and a collection of pokemon
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.Name = name;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }
    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Badges
    {
        get { return badges; }
        set { badges = value; }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }

    public void IncreaseBadges()
    {
        this.Badges ++;
    }

    public void ReducePokemonsHealth()
    {
        foreach (var pokemon in this.Pokemons)
        {
            pokemon.ReduceHealth();
        }
    }

    public void RemoveDead()
    {
        this.Pokemons = this.Pokemons
            .Where(p => p.Health > 0)
            .ToList();
        //foreach (var pokemon in this.Pokemons)
        //{
        //    if (pokemon.Health <= 0)
        //    {
        //        this.Pokemons.Remove(pokemon);
        //    }
        //}
    }
    //public override string ToString()
    //{
    //    return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    //}
}

