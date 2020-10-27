using System;
using System.Collections.Generic;
using Faker;
using FizzWare;
using FizzWare.NBuilder;
using System.Linq;

namespace Linq
{
    class Dummy
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    class Program
    {
        static int OrderByAge(Person p)
        {
            return p.Age;
        }
        static string OrderByFirstname(Person p)
        {
            return p.FirstName;
        }

        static bool FirstNameWithAnA(Person p)
        {
            return p.FirstName.StartsWith("A");
        }
        static bool FirstNameWithAnB(Person p)
        {
            return p.FirstName.StartsWith("B");
        }

        static Dummy Project(Person p)
        {
            return new Dummy { First = p.FirstName, Last = p.LastName };
        }

        static void Main(string[] args)
        {
            Dictionary<string, Func<List<int>, Stack<string>, Action<int[]>>>  obj1 = DoeIets();
            var obj2 = DoeIets();

            string letter = "C";
            List<Person> people = ConstructList();

            var q4 = from p in people 
                     where p.LastName.StartsWith("D") 
                     group p by p.Age into Group
                     select Group;

            foreach(var group in q4)
            {
                Console.WriteLine(group.Key);
                foreach(var item in group)
                {
                    Console.WriteLine(item.LastName);
                }
            }

            //Console.WriteLine(q4.Sum(p=>p.Age));

            foreach(var px in q4)
            {
                //Console.WriteLine(px);
            }


            var q3 = people.Select(p =>new { First = p.FirstName, Last = p.LastName });
            
            foreach(var d in q3)
            {
                //Console.WriteLine($"{d.First} {d.Last}");
            }


            //var query = people.OrderByDescending(OrderByFirstname);
            var query = people
                .Where(p => p.FirstName.StartsWith(letter))
                .OrderBy(p => p.Age);
                
            var q2 = query
                .ThenBy(p => p.LastName)
                .Skip(5)
                .Take(3);
                

            foreach(Person p in q2)
            {
                //Console.WriteLine(p);
            }


            Console.WriteLine(people.Average(p=>p.Age));
        }

        static List<Person> ConstructList()
        {
            return Builder<Person>
                .CreateListOfSize(1000)
                .All()
                .With(p => p.FirstName = Faker.Name.First())
                .With(p => p.LastName = Faker.Name.Last())
                .With(p => p.Age = Faker.RandomNumber.Next(0, 123))
                .Build()
                .ToList();

        }

        static Dictionary<string, Func<List<int>, Stack<string>, Action<int[]>>> DoeIets()
        {
            return null;
        }
    }
}
