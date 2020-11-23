using System;
using System.Collections.Generic;
using System.Text;

namespace _02
{
    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, int power, int? displacement = null, string efficiency = null)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public override string ToString()
            => $"{Model}:\n\t\tPower: {Power}\n\t\tDisplacement: " +
               $"{Displacement?.ToString() ?? "n/a"}\n\t\tEfficiency: {Efficiency ?? "n/a"}";
    }
}
