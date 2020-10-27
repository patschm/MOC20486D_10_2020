using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{ID}: {FirstName} {LastName} ({Age})";
        }
    }
}
