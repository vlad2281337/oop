using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 lines of characters:");

            string[] lineArray1 = Console.ReadLine().Split(' '),
                     lineArray2 = Console.ReadLine().Split(' ');

            char[] charArray1 = StringArrayToCharArray(lineArray1),
                   charArray2 = StringArrayToCharArray(lineArray2);

            bool equal = true, secondIsBigger = false;
            int minLen = Math.Min(charArray1.Length, charArray2.Length);

            for (int i = 0; i < minLen; ++i)
                if (charArray1[i] != charArray2[i])
                {
                    secondIsBigger = (charArray1[i] < charArray2[i]);
                    equal = false;
                    break;
                }

            if (equal)
                secondIsBigger = (charArray1.Length < charArray2.Length);

            PrintCharArray((secondIsBigger) ? charArray1 : charArray2);
            PrintCharArray((secondIsBigger) ? charArray2 : charArray1);

            Console.ReadKey();
        }

        static char[] StringArrayToCharArray(string[] strArray)
        {
            char[] charArray = new char[strArray.Length];

            for (int i = 0; i < strArray.Length; ++i)
                charArray[i] = strArray[i][0];

            return charArray;
        }

        static void PrintCharArray(char[] array)
        {
            foreach (char ch in array)
                Console.Write(ch);
            Console.WriteLine();
        }
    }
}
