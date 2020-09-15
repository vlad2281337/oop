using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            Console.Write("diff = ");
            int diff = int.Parse(Console.ReadLine());

            int pairCount = 0;

            for (int i = 0; i < numArray.Length; ++i)
                for (int j = i + 1; j < numArray.Length; ++j)
                    if (Math.Abs(numArray[i] - numArray[j]) == diff)
                        ++pairCount;

            Console.WriteLine(pairCount);

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
