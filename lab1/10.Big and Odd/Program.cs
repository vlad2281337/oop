using System;

    class Program
    {
        static void Main(string[] args)
        {
        int n;
        Boolean result;

        n = int.Parse(Console.ReadLine());

        if (n > 20 && (n % 10) == 1)
        {
            result = true;
            Console.WriteLine(result);
        }
        else
        {
            result = false;
            Console.WriteLine(result);
        }
        Console.ReadKey();
        }
    }

