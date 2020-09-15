using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            int n = strArray.Length;
            int[] sumArray = new int[n];

            for (int i = 0; i < k; ++i)
            {
                int tmp = numArray[n - 1];

                for (int j = n - 1; j > 0; --j)
                    numArray[j] = numArray[j - 1];

                numArray[0] = tmp;

                for (int j = 0; j < n; ++j)
                    sumArray[j] += numArray[j];
            }

            Console.WriteLine("Rotated and summed array:");

            foreach (int sum in sumArray)
                Console.Write($"{sum} ");
            Console.WriteLine();

            Console.ReadKey();
        }

        static int[] ParseArray(string[] strArray)
        {
            int[] numArray = new int[strArray.Length];

            for (int i = 0; i < strArray.Length; ++i)
                numArray[i] = int.Parse(strArray[i]);

            return numArray;
        }
    }
}
