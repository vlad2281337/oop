using System;

    class Program
    {
        static void Main(string[] args)
        {
        float a, b, h;
        a = float.Parse(Console.ReadLine());
        b = float.Parse(Console.ReadLine());
        h = float.Parse(Console.ReadLine());
        float avrg = ((a + b)/2) *h ;
        Math.Round(avrg, 1);

        Console.WriteLine(avrg);
        Console.ReadKey();
        }
    }

