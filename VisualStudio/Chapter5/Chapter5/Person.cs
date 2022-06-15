using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public class Person
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
    }
}
