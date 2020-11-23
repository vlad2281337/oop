using RawData.classes;
using System;
using System.Collections.Generic;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                Car car = ParseCarFromConsole();
                cars.Add(car);
            }

            string command = Console.ReadLine();
            Console.WriteLine();

            switch (command)
            {
                case "fragile":
                    {
                        foreach (var car in cars)
                            if (car.Cargo.Type == "fragile")
                                foreach (var tire in car.Tires)
                                    if (tire.Pressure < 1)
                                    {
                                        Console.WriteLine(car.Model);
                                        break;
                                    }

                        break;
                    }
                case "flamable":
                    {
                        foreach (var car in cars)
                            if (car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                                Console.WriteLine(car.Model);

                        break;
                    }
            }

            Console.ReadKey();
        }

        static Car ParseCarFromConsole()
        {
            string[] inputs = Console.ReadLine().Replace('.', ',').Split(' ');

            string model = inputs[0];
            int engineSpeed = int.Parse(inputs[1]),
                enginePower = int.Parse(inputs[2]),
                cargoWeight = int.Parse(inputs[3]);
            string cargoType = inputs[4];

            var tiresInfo = new (double, int)[4];

            for (int i = 0; i < 4; ++i)
            {
                double tirePressure = double.Parse(inputs[5 + i * 2]);
                int tireAge = int.Parse(inputs[6 + i * 2]);

                tiresInfo[i] = (tirePressure, tireAge);
            }

            Car car = new Car(model);

            car.Engine.Speed = engineSpeed;
            car.Engine.Power = enginePower;

            car.Cargo.Weight = cargoWeight;
            car.Cargo.Type = cargoType;

            for (int i = 0; i < 4; ++i)
                (car.Tires[i].Pressure, car.Tires[i].Age) = tiresInfo[i];

            return car;
        }
    }
}