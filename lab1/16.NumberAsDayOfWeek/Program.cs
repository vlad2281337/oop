using System;

    class Program
    {
        static void Main(string[] args)
        {
        int  g, n;
        double k ;
        n = (int)double.Parse(Console.ReadLine());

        g = n % 7;
        if (g == 1)
        {
            Console.WriteLine("Monday");
        }
        if (g == 2)
        {
            Console.WriteLine("Tuesday");
        }
        if (g == 3)
        {
            Console.WriteLine("Wednes­day");
        }
        if (g == 4)
        {
            Console.WriteLine("Thursday");
        }
        if (g == 5)
        {
            Console.WriteLine("Friday");
        }
        if (g == 6)
        {
            Console.WriteLine("Saturday");
        }
        if (g == 7)
        {
            Console.WriteLine("Sunday");
        }
        if (g <= 0)
        {
            Console.WriteLine("Not Valid");
        }
        k = g % 1;
        if (k != 0)
        {
            Console.WriteLine("Not Valid");
        }
        Console.ReadKey();


    }
    }

