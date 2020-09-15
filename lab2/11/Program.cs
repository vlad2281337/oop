using System;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            bool found = false;

            for (int i = 0; i < numArray.Length; ++i)
            {
                int leftSum = 0, rightSum = 0;

                for (int j = 0; j < i; ++j)
                    leftSum += numArray[j];

                for (int j = i + 1; j < numArray.Length; ++j)
                    rightSum += numArray[j];

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("no");

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
