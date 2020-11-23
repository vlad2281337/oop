using System;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                Engine engine = ParseEngineFromConsole();
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; ++i)
            {
                Car car = ParseCarFromConsole(engines);
                cars.Add(car);
            }

            Console.WriteLine();

            foreach (var car in cars)
                Console.WriteLine(car);

            Console.ReadKey();
        }

        static Engine ParseEngineFromConsole()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            string model = inputs[0];
            int power = int.Parse(inputs[1]);

            (int? displacement, string efficiency) = inputs.Length switch
            {
                2 => (null, null),
                3 => int.TryParse(inputs[2], out int result)
                        ? (result, null as string)
                        : (null as int?, inputs[2]),
                _ => (int.Parse(inputs[2]), inputs[3])
            };

            return new Engine(model, power, displacement, efficiency);
        }

        static Car ParseCarFromConsole(List<Engine> engines)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            string model = inputs[0],
                    engineModel = inputs[1];

            (int? weight, string color) = inputs.Length switch
            {
                2 => (null, null),
                3 => int.TryParse(inputs[2], out int result)
                        ? (result, null as string)
                        : (null as int?, inputs[2]),
                _ => (int.Parse(inputs[2]), inputs[3])
            };

            Engine engine = null;

            foreach (var item in engines)
                if (item.Model == engineModel)
                {
                    engine = item;
                    break;
                }

            return new Car(model, engine, weight, color);
        }
    }
}