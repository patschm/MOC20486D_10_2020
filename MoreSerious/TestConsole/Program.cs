using System;
using System.Collections.Generic;
using Entities;
using Fakes;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonFake pFakes = new PersonFake();
            List<Person> people = pFakes.Generate(1000);

            //VoorEnAchterBeginnendMetM(people);
            ProjectieAchterEnLeeftijd(people);
            
        }

        private static void ProjectieAchterEnLeeftijd(List<Person> people)
        {
            var query = people.Select(p => new { Achternaam = p.LastName, Leeftijd = p.Age });

            query.ToList().ForEach(item => Console.WriteLine($"{item.Achternaam} ({item.Leeftijd})"));
        }

        private static void VoorEnAchterBeginnendMetM(List<Person> people)
        {
            var query2 = people.Where(p => p.FirstName.StartsWith("M") && p.LastName.StartsWith("M"));
            var query3 = from p in people where p.FirstName.StartsWith("M") && p.LastName.StartsWith("M") select p;

            foreach (var p in query2)
            {
                Console.WriteLine($"{p.ID}: {p.FirstName} {p.LastName} ({p.Age})");
            }
        }
    }
}
