using _03.classes;
using System;


namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = ParseIntegerPairFromConsole();
            var jediCoords = ParseIntegerPairFromConsole();
            var forceCoords = ParseIntegerPairFromConsole();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Let the Force be with you")
                    break;
            }

            Console.WriteLine();

            Galaxy galaxy = new Galaxy(dimensions.first, dimensions.second);
            galaxy.PlaceJedi(jediCoords.first, jediCoords.second);
            galaxy.PlaceForce(forceCoords.first, forceCoords.second);

            int starsTotal = galaxy.CollectStars();
            Console.WriteLine(starsTotal);

            Console.ReadKey();
        }

        static (int first, int second) ParseIntegerPairFromConsole()
        {
            var inputs = Console.ReadLine().Split(' ');
            return (int.Parse(inputs[0]), int.Parse(inputs[1]));
        }
    }
}
