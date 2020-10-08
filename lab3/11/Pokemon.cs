using System;
using System.Collections.Generic;
using System.Text;

namespace _11
{
    public class Pokemon
    {
        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }

        public bool IsAlive => Health > 0;

        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public void TakeDamage() => Health -= 10;
    }
}
