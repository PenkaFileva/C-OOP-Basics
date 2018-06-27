using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();
        string command;

        while ((command = Console.ReadLine()) != "Tournament")
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            //pokemon = new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3]));          

            if (!trainers.Any(t => t.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName));
            }

            Trainer currentTrainer = trainers.First(t => t.Name == trainerName);
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            currentTrainer.AddPokemon(pokemon);
        }

        while ((command = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.IncreaseBadges();
                }
                else
                {
                    trainer.ReducePokemonsHealth();
                    trainer.RemoveDead();
                }
            }
        }

        var currentTrainers = trainers.OrderByDescending(t => t.Badges).ToList();

        foreach (var trainer in currentTrainers)
        {
            Console.WriteLine("{0} {1} {2}", trainer.Name, trainer.Badges, trainer.Pokemons.Count);
        }
    }
}
