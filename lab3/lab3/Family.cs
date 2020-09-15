using System;
using System.Collections.Generic;
using System.Text;

namespace _03
{
    class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = null;

            foreach (var member in familyMembers)
                if (oldestMember == null || member.Age > oldestMember.Age)
                    oldestMember = member;

            return oldestMember;
        }

    }
}
