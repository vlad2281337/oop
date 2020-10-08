using System;
using System.Collections.Generic;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Tournament")
                    break;

                string[] inputs = line.Split(' ');

                string trainerName = inputs[0],
                        pokemonName = inputs[1],
                        pokemonElement = inputs[2];
                int pokemonHealth = int.Parse(inputs[3]);

                Trainer trainer = null;
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                foreach (var item in trainers)
                    if (item.Name == trainerName)
                    {
                        trainer = item;
                        break;
                    }

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemon.Add(pokemon);
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                    break;

                foreach (var trainer in trainers)
                    trainer.ChallengePokemon(line);
            }

            Console.WriteLine();

            for (int i = 0; i < trainers.Count - 1; ++i)
                for (int j = i + 1; j < trainers.Count; ++j)
                    if (trainers[i].NumberOfBadges < trainers[j].NumberOfBadges)
                        (trainers[i], trainers[j]) = (trainers[j], trainers[i]);

            foreach (var trainer in trainers)
                Console.WriteLine(trainer);

            Console.ReadKey();
        }
    }
}
