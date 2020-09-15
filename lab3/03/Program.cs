using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Pesho";
            person1.Age = 20;
            PrintPerson(person1);

            Person person2 = new Person { Name = "Gosho", Age = 18 };
            PrintPerson(person2);

            Person person3 = new Person { Name = "Stamat", Age = 43 };
            PrintPerson(person3);

            Console.ReadKey();
        }

        static void PrintPerson(Person person)
        {
            Console.WriteLine($"Person {person.Name}, {person.Age}");
        }
    
    }
}
