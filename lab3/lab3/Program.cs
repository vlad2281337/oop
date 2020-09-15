using _03;
using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; ++i)
            {
                Person person = ParsePersonFromConsole();
                family.AddMember(person);
            }
            Console.WriteLine();

            Person oldestMember = family.GetOldestMember();
            if (oldestMember == null)
                Console.WriteLine("None");
            else
                Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

            Console.ReadKey();
        }

        static Person ParsePersonFromConsole()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string name = inputs[0];
            int age = int.Parse(inputs[1]);

            return new Person(name, age);
        }
    
    }
}
