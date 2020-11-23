using System;
using System.Collections.Generic;
using System.Text;

namespace _07
{
    public class FamilyTree
    {
        public List<Person> FamilyMembers { get; }

        public FamilyTree()
        {
            FamilyMembers = new List<Person>();
        }

        private void Bind(Person parent, Person child)
        {
            parent.Children.Add(child);
            child.Parents.Add(parent);
        }

        public void AddPerson(string fullName, DateTime birthday)
        {
            FamilyMembers.Add(new Person(fullName, birthday));
        }

        public void TieParentToChild(string parentName, string childName)
        {
            var parent = FindPerson(parentName);
            var child = FindPerson(childName);
            Bind(parent, child);
        }

        public void TieParentToChild(string parentName, DateTime childBirthday)
        {
            var parent = FindPerson(parentName);
            var child = FindPerson(childBirthday);
            Bind(parent, child);
        }

        public void TieParentToChild(DateTime parentBirthday, string childName)
        {
            var parent = FindPerson(parentBirthday);
            var child = FindPerson(childName);
            Bind(parent, child);
        }

        public void TieParentToChild(DateTime parentBirthday, DateTime childBirthday)
        {
            var parent = FindPerson(parentBirthday);
            var child = FindPerson(childBirthday);
            Bind(parent, child);
        }

        public Person FindPerson(string fullName)
        {
            foreach (var person in FamilyMembers)
                if (person.FullName == fullName)
                    return person;
            return null;
        }

        public Person FindPerson(DateTime birthday)
        {
            foreach (var person in FamilyMembers)
                if (person.Birthday == birthday)
                    return person;
            return null;
        }
    }
}
