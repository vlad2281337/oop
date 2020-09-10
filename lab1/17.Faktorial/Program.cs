using System;

    class Program
    {
        static void Main(string[] args)
        {

        int faktorio=1 , n;
        n = int.Parse(Console.ReadLine());

        for(int i=2; i<=n; i++)
        {
            faktorio = faktorio * i;
        }
        Console.WriteLine(faktorio);
        Console.ReadKey();
        }
    }

