using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            for (int i = 0; i <= n; ++i)
                primes[i] = (i > 1);

            for (int i = 2; i <= n; ++i)
                if (primes[i])
                {
                    Console.Write($"{i} ");
                    for (int j = 2; i * j <= n; ++j)
                        primes[i * j] = false;
                }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
