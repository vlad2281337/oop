using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 lines of words:");

            string[] words1 = Console.ReadLine().Split(' '),
                     words2 = Console.ReadLine().Split(' ');

            int len1 = words1.Length,
                len2 = words2.Length,
                minLen = Math.Min(len1, len2),
                leftEndLen = 0,
                rightEndLen = 0;

            for (int i = 0; i < minLen; ++i)
                if (words1[i] == words2[i])
                    ++leftEndLen;
                else if (words1[len1 - 1 - i] == words2[len2 - 1 - i])
                    ++rightEndLen;
                else
                    break;

            Console.Write("The length of the largest common end: ");
            Console.WriteLine((leftEndLen >= rightEndLen) ? leftEndLen : rightEndLen);

            Console.ReadKey();
        }
    }
}
