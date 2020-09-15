using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of integers:");

            string[] strArray = Console.ReadLine().Split(' ');
            int[] numArray = ParseArray(strArray);

            int bestSeqIndex = 0, bestSeqLen = 1,
                seqIndex = 0, seqLen = 1;

            for (int i = 1; i < numArray.Length; ++i)
            {
                bool equal = (numArray[i] == numArray[i - 1]);
                if (equal)
                    ++seqLen;

                if (seqLen > bestSeqLen)
                {
                    bestSeqIndex = seqIndex;
                    bestSeqLen = seqLen;
                }

                if (!equal)
                {
                    seqIndex = i;
                    seqLen = 1;
                }
            }

            for (int i = 0; i < bestSeqLen; ++i)
                Console.Write($"{numArray[bestSeqIndex + i]} ");
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
