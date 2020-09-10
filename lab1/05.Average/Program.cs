using System;
    class Program
    {
        static void Main(string[] args)
            {
        float a, b, c;
        
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());
        float avrg = (a + b + c) / 3;

        Console.WriteLine(avrg);
        Console.ReadKey();
    }
    }

