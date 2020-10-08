using System;
using System.Collections.Generic;


namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]),
                m = int.Parse(inputs[1]);

            for (int i = 0; i < n; ++i)
            {
                Rectangle rectangle = ParseRectangleFromConsole();
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < m; ++i)
            {
                (string firstId, string secondId) = ParseIdPairFromConsole();

                Rectangle firstRectangle = FindRectangleById(rectangles, firstId);
                Rectangle secondRectangle = FindRectangleById(rectangles, secondId);

                bool rectanglesIntersect = firstRectangle.IntersectsWith(secondRectangle);
                Console.WriteLine(rectanglesIntersect);
            }

            Console.ReadKey();
        }

        static Rectangle ParseRectangleFromConsole()
        {
            string[] inputs = Console.ReadLine().Replace('.', ',').Split(' ');

            string id = inputs[0];
            double width = double.Parse(inputs[1]),
                    height = double.Parse(inputs[2]),
                    x = double.Parse(inputs[3]),
                    y = double.Parse(inputs[4]);

            return new Rectangle(id, width, height, x, y);
        }

        static (string, string) ParseIdPairFromConsole()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            return (inputs[0], inputs[1]);
        }

        static Rectangle FindRectangleById(List<Rectangle> list, string id)
        {
            foreach (var item in list)
                if (item.Id == id)
                    return item;
            throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}
