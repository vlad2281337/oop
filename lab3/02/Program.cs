using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            PrintPerson(person1);

            Person person2 = new Person(20);
            PrintPerson(person2);

            Person person3 = new Person("Bill", 36);
            PrintPerson(person3);

            Console.ReadKey();
        }

        static void PrintPerson(Person person)
        {
            Console.WriteLine($"Person {person.Name}, {person.Age}");
        }
    
    }
}
