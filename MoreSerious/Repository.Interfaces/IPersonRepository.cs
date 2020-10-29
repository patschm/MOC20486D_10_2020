using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> Get();
        void Insert(Person p);
        bool Update(Person p);
        bool Delete(int id);

        bool Save(); // Optioneel
    }
}
