using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];

            for (int i = 0; i < 26; ++i)
                alphabet[i] = (char)('a' + i);

            Console.WriteLine("Enter a word:");
            string word = Console.ReadLine().ToLower();

            foreach (char ch in word)
            {
                int index = BinarySearch(alphabet, ch);
                Console.WriteLine($"{ch} -> {index}");
            }

            Console.ReadKey();
        }

        static int BinarySearch(char[] array, char value)
        {
            int l = 0, r = array.Length;

            while (l <= r)
            {
                int med = l + (r - l) / 2;

                if (array[med] < value)
                    l = med + 1;
                else if (array[med] > value)
                    r = med - 1;
                else
                    return med;
            }

            return -1;
        }
    }
}
