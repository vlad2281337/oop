using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            int mostFreqNum = numArray[0], maxFreq = 1;

            for (int i = 0; i < numArray.Length; ++i)
            {
                int freq = 1;

                for (int j = i + 1; j < numArray.Length; ++j)
                    if (numArray[i] == numArray[j])
                        ++freq;

                if (freq > maxFreq)
                {
                    mostFreqNum = numArray[i];
                    maxFreq = freq;
                }
            }

            Console.WriteLine(mostFreqNum);

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
