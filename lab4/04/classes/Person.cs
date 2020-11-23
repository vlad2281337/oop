using System;
using System.Collections.Generic;
using System.Text;

namespace _04.classes
{
    public abstract class Person
    {
        protected string name;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length <= 1 || value.Length > 20)
                    throw new ArgumentException("Name must be 2-20 characters");
                name = value;
            }
        }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
            => Name;
    }
}
