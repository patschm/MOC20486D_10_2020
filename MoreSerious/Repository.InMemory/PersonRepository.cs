using Entities;
using Fakes;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.InMemory
{
    public class PersonRepository : IPersonRepository
    {
        private static readonly List<Person> people;

        static PersonRepository()
        {
            PersonFake fk = new PersonFake();
            people = fk.Generate(500);
        }

        public bool Delete(int id)
        {
            Person tmp = people.FirstOrDefault(p => p.ID == id);
            if (tmp == null)
            {
                return false;
            }
            people.Remove(tmp);
            return true;
        }

        public IQueryable<Person> Get()
        {
            return people.AsQueryable();
        }

        public void Insert(Person person)
        {
            int highest = people.Max(e => e.ID);
            person.ID = ++highest;
            people.Add(person);
        }

        public bool Save()
        {
            return true;
        }

        public bool Update(Person person)
        {
            Person tmp = people.FirstOrDefault(p => p.ID == person.ID);
            if (tmp == null) return false;
            tmp.FirstName = person.FirstName;
            tmp.LastName = person.LastName;
            tmp.Age = person.Age;
            return true;
        }
    }
}
