using System;

    class Program
    {
        static void Main(string[] args)
        {
        bool res;
        int n;
        n = int.Parse(Console.ReadLine());

            if((n%9)==0|| (n % 11) == 0|| (n % 13) == 0)
            {
            res = true;
            }
            else
            {
            res = false;
            }

        Console.WriteLine(res);
        Console.ReadKey();

        }
    }

