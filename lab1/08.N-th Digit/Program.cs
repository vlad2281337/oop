using System;

    class Program
    {
        static void Main(string[] args)
        {
        int n, nDigit, number;
        
        
        number = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());

        nDigit = (int)(number / (Math.Pow(10 , (n-1)))) % 10;

        if (nDigit == 0)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine(nDigit);
        }

        Console.ReadLine();
    }
    }

