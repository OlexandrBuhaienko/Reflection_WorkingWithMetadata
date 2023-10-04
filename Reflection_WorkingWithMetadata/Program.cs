using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Reflection_WorkingWithMetadata
{
    internal class Program
    {
        public static void GetMembersInfo(string stringType)
        {
            Type type = Type.GetType(stringType);
            var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine(memberInfo.Name);
            }
            Console.ReadLine();
        }
        public static void Main(string [] args)
        {
            string stringType = "Reflection_WorkingWithMetadata.Student";
            GetMembersInfo(stringType);
        }
    }
}