using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                Person person = ParsePersonFromConsole();
                people.Add(person);
            }
            Console.WriteLine();

            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n - 1; ++j)
                    if (string.Compare(people[j].Name, people[j + 1].Name) > 0)
                        (people[j], people[j + 1]) = (people[j + 1], people[j]);

            foreach (var person in people)
                if (person.Age > 30)
                    Console.WriteLine($"{person.Name} - {person.Age}");

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
}
