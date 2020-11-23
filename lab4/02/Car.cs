using System;
using System.Collections.Generic;
using System.Text;

namespace _02
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public Car(string model, Engine engine, int? weight = null, string color = null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
            => $"{Model}:\n\t{Engine}\n\tWeight: {Weight?.ToString() ?? "n/a"}" +
                $"\n\tColor: {Color ?? "n/a"}";
    }
}
