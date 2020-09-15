using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            int n = strArray.Length, k = n / 4;
            int[] sumArray = new int[k * 2];

            for (int i = 0; i < k; ++i)
            {
                sumArray[i] = numArray[k + i] + numArray[k - 1 - i];
                sumArray[k * 2 - 1 - i] = numArray[n - k + i] + numArray[n - k - 1 - i];
            }

            Console.WriteLine("Folded and summed array:");

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
