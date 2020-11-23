using System;
using System.Collections.Generic;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new FamilyTree();
            var ties = new List<string>();

            string firstData = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                    break;

                string[] inputs = line.Split(' ');

                if (inputs[1] == "-" || inputs[2] == "-")
                {
                    ties.Add(line);
                }
                else
                {
                    string fullName = $"{inputs[0]} {inputs[1]}";
                    DateTime birthday = DateTime.Parse(inputs[2]);

                    familyTree.AddPerson(fullName, birthday);
                }
            }

            Console.WriteLine();

            foreach (var tie in ties)
            {
                string[] inputs = tie.Split(' ');
                int len = inputs.Length;

                bool parentDateGiven = DateTime.TryParse(inputs[0], out DateTime parentBirthday),
                        childDateGiven = DateTime.TryParse(inputs[len - 1], out DateTime childBirthday);

                if (parentDateGiven && childDateGiven)
                {
                    familyTree.TieParentToChild(parentBirthday, childBirthday);
                }
                else
                {
                    string parentName = $"{inputs[0]} {inputs[1]}";
                    string childName = $"{inputs[len - 2]} {inputs[len - 1]}";

                    if (!parentDateGiven && childDateGiven)
                        familyTree.TieParentToChild(parentName, childBirthday);
                    else if (parentDateGiven && !childDateGiven)
                        familyTree.TieParentToChild(parentBirthday, childName);
                    else
                        familyTree.TieParentToChild(parentName, childName);
                }
            }

            Person person;
            bool firstDateGiven = DateTime.TryParse(firstData, out DateTime firstBirthday);

            person = (firstDateGiven)
                        ? familyTree.FindPerson(firstBirthday)
                        : familyTree.FindPerson(firstData);

            PrintPerson(person);

            Console.ReadKey();
        }

        static void PrintPerson(Person person)
        {
            Console.WriteLine(person);

            Console.WriteLine("Parents:");
            foreach (var parent in person.Parents)
                Console.WriteLine(parent);

            Console.WriteLine("Children:");
            foreach (var child in person.Children)
                Console.WriteLine(child);
        }
    }
}
