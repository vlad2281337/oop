using System;
  class Program
    {
        static void Main(string[] args)
        {

        double a, b, c, res;

        a = double.Parse(Console.ReadLine());
        b = double.Parse(Console.ReadLine());
        c = double.Parse(Console.ReadLine());

        res = a * b * c;

        if (res > 0)
        {
            Console.WriteLine("Positive");
        }
        else
        {
            if (res < 0)
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Zero");
            }
        }
        Console.ReadKey();
    }
    }

