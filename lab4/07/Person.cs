using System;
using System.Collections.Generic;
using System.Text;

namespace _07
{
    public class Person
    {
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public List<Person> Parents { get; }

        public List<Person> Children { get; }

        public Person()
        {
            Parents = new List<Person>();
            Children = new List<Person>();
        }

        public Person(string fullName, DateTime birthday) : this()
        {
            FullName = fullName;
            Birthday = birthday;
        }

        public override string ToString()
            => $"{FullName} {Birthday.ToShortDateString()}";
    }
}
