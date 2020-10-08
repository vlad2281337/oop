using System;
using System.Collections.Generic;

namespace _07
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

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                (string model, int kilometers) = ParseCommand(input);

                foreach (var car in cars)
                    if (car.Model == model)
                    {
                        if (car.HasEnoughFuelToMove(kilometers))
                            car.Drive(kilometers);
                        else
                            Console.WriteLine("Insufficient fuel for the drive");

                        break;
                    }
            }

            Console.WriteLine();

            foreach (var car in cars)
                Console.WriteLine(car);

            Console.ReadKey();
        }

        static Car ParseCarFromConsole()
        {
            string[] inputs = Console.ReadLine().Replace('.', ',').Split(' ');

            string model = inputs[0];
            double fuelAmount = double.Parse(inputs[1]),
                    fuelConsumption = double.Parse(inputs[2]);

            return new Car(model, fuelAmount, fuelConsumption);
        }

        static (string, int) ParseCommand(string str)
        {
            string[] inputs = str.Split(' ');

            if (inputs[0] != "Drive")
                throw new FormatException("Unknown command");

            string model = inputs[1];
            int kilometers = int.Parse(inputs[2]);

            return (model, kilometers);
        }
    }
}
