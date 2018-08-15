using System;
using System.Linq;

namespace _03OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Familiy FamilyMembers = new Familiy();

            for (int i = 0; i < membersCount; i++)
            {
                string input = Console.ReadLine();
                string[] Parameters =
                    input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string memberName = Parameters[0];
                int memberAge = int.Parse(Parameters[1]);
                Person member = new Person(memberName, memberAge);
                FamilyMembers.AddMember(member);
            }

            Console.WriteLine(FamilyMembers.GetOldestMember().Name + " " + FamilyMembers.GetOldestMember().Age);
        }
    }
}
