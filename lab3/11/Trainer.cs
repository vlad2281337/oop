using System;
using System.Collections.Generic;
using System.Text;

namespace _11
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; private set; }

        public List<Pokemon> Pokemon { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Pokemon = new List<Pokemon>();
        }

        public void ChallengePokemon(string element)
        {
            if (this.HasPokemonOfElement(element))
            {
                ++NumberOfBadges;
            }
            else
                for (int i = 0; i < Pokemon.Count; ++i)
                {
                    var pokemon = Pokemon[i];
                    pokemon.TakeDamage();

                    if (!pokemon.IsAlive)
                        Pokemon.Remove(pokemon);
                }
        }

        public bool HasPokemonOfElement(string element)
        {
            foreach (var item in Pokemon)
                if (item.Element == element)
                    return true;
            return false;
        }

        public override string ToString()
            => $"{Name} {NumberOfBadges} {Pokemon.Count}";
    }
}
